/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections.Concurrent;
using System.Threading;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System;
using System.Globalization;

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Queue processor class
    /// Note: There should be only 1 instance of this class. TODO: Need to make this as singleton class
    /// </summary>
    public class UnitOfWorkProcessor : IQueueProcessor
    {
        private readonly IQueue _queue;
        private readonly IWorkflowManager _workflowManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private readonly Timer _timer;
        private readonly ConcurrentDictionary<string, IQueueMessage> _messagesToExtendLease;
        private readonly TimeSpan _leaseTimeSpan = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Default constructor, which will initialize the private proterties
        /// Queue and Workflow manager
        /// </summary>
        /// <param name="queue">Queue</param>
        /// <param name="manager">workflow Manager</param>
        public UnitOfWorkProcessor(IQueue queue, IWorkflowManager manager)
        {
            _queue = queue;
            _workflowManager = manager;
            _unitOfWorkManager = UnitOfWorkManagerFactory.Create(_workflowManager);

            if (!ConfigurationHelper.IsOnPremise)
            {
                _timer = new Timer(ExtendLease, null, TimeSpan.FromMinutes(50), Timeout.InfiniteTimeSpan);
                _messagesToExtendLease = new ConcurrentDictionary<string, IQueueMessage>();
            }
        }

        /// <summary>
        /// Extend the lease of the message as it is still running
        /// </summary>
        /// <param name="obj"></param>
        private void ExtendLease(object obj)
        {
            try
            {
                Logger.Verbose("ExtendLease Started.", LoggingConstants.ModuleWorkerRole);
                foreach (var queueMessage in _messagesToExtendLease)
                {
                    var message = queueMessage.Value;

                    if (message.NextVisibleTime.HasValue)
                    {
                        if (message.NextVisibleTime.Value.UtcDateTime - DateTime.UtcNow <=
                            _leaseTimeSpan.Add(TimeSpan.FromMinutes(5)))
                        {
                            //This will extend the lease by 1 hour
                            _queue.ExtendLease(message);
                            Logger.Verbose(
                                string.Format("Message [{0}] extended to [{1}].", message.Id, message.NextVisibleTime),
                                LoggingConstants.ModuleWorkerRole);
                        }
                    }
                }
                Logger.Verbose("ExtendLease Completed.", LoggingConstants.ModuleWorkerRole);
            }
            catch (Exception ex)
            {
                Logger.Error("ExtendLease failed", LoggingConstants.ModuleWorkerRole, null, ex);
            }
            finally
            {
                _timer.Change(_messagesToExtendLease.Count == 0 ? TimeSpan.FromMinutes(50) : _leaseTimeSpan,
                    Timeout.InfiniteTimeSpan);
            }
        }

        /// <summary>
        /// Does the actual work
        /// </summary>
        /// <param name="message">Queue Message</param>
        /// <returns>Status</returns>
        public bool DoWork(IQueueMessage message)
        {
            if (string.IsNullOrEmpty(message.Payload))
            {
                throw new ArgumentNullException("message");
            }
            try
            {
                //Get the unit of work instance
                var originalUnitOfWorkInstance =
                    _unitOfWorkManager.FindUnitOfWorkInstance(Convert.ToInt32(message.Payload));

                //create keep alive to pass down the call chain so long work flows can not become visible on queue.
             
                Action keepAlive;

                if (ConfigurationHelper.IsOnPremise)
                    keepAlive = () => { };
                else
                    keepAlive = () => _queue.ExtendLease(message);

                //Execute the unit of work
                ExecuteUnitOfWork(originalUnitOfWorkInstance, keepAlive, message);
                return true;
            }
            catch (UnitOfWorkExecuteException uowex)
            {
                var failedUnitOfWorkInstance = uowex.UnitOfWork;
                var error = string.Format("{0}:\r\n{1}", uowex.Message, uowex.StackTrace);

                if (uowex.InnerException != null)
                {
                    error += string.Format("\r\n{0}:\r\n{1}", uowex.InnerException.Message,
                        uowex.InnerException.StackTrace);
                }
                Logger.Error(string.Format("UnitOfWork Exception: {0}", failedUnitOfWorkInstance.UnitOfWorkInstanceId),
                    LoggingConstants.ModuleWorkerRole, null, uowex);
                _unitOfWorkManager.UpdateUnitOfWorkWithError(failedUnitOfWorkInstance.UnitOfWorkInstanceId, error);
                _unitOfWorkManager.UpdateUnitOfWorkStatus(failedUnitOfWorkInstance.UnitOfWorkInstanceId,
                    WorkStatusType.Error);
                _unitOfWorkManager.UpdateExecutionCompleteTime(failedUnitOfWorkInstance.UnitOfWorkInstanceId);
                //Retry if available
                TestAndRetryUnitOfWork(failedUnitOfWorkInstance);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Unrecoverable failed unit of work: {0}", message.Payload), ex);
                return false;
            }
        }

        /// <summary>
        /// Test and retry Unit of work
        /// </summary>
        /// <param name="failedUnitOfWorkInstance">Unit of Work instance</param>
        private void TestAndRetryUnitOfWork(UnitOfWorkInstance failedUnitOfWorkInstance)
        {
            try
            {
                if (failedUnitOfWorkInstance.RetryCount >= 2)
                {
                    Logger.Error(
                        string.Format("Max retry count hit for unit of work: {0}",
                            failedUnitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole, null,
                        null);

                    _workflowManager.UpdateWorkflowStatus(failedUnitOfWorkInstance.WorkflowInstanceId,
                        WorkStatusType.Error);
                    _workflowManager.UpdateExecutionCompleteTime(failedUnitOfWorkInstance.WorkflowInstanceId);
                    return;
                }

                Logger.Info(
                    string.Format("Incrementing unit of work: {0}", failedUnitOfWorkInstance.UnitOfWorkInstanceId),
                    LoggingConstants.ModuleWorkerRole);

                _unitOfWorkManager.IncrementRetryCount(failedUnitOfWorkInstance.UnitOfWorkInstanceId);
                var message =
                    _queue.CreateMessage(
                        failedUnitOfWorkInstance.UnitOfWorkInstanceId.ToString(CultureInfo.InvariantCulture));
                _queue.ScheduledEnqueue(message, DateTime.UtcNow.AddMinutes(1));
            }
            catch (Exception ex)
            {
                Logger.Error(
                    string.Format("Unrecoverable failed unit of work at retry: {0}",
                        failedUnitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole, null, ex);
            }
        }

        /// <summary>
        /// Execute unit of work
        /// </summary>
        /// <param name="unitOfWorkInstance">Unit of work ID</param>
        /// <param name="keepAlive">Keep Alive - deligates</param>
        /// <param name="message">Message</param>
        /// <returns>new instance of Unit of work</returns>
        private UnitOfWorkInstance ExecuteUnitOfWork(UnitOfWorkInstance unitOfWorkInstance, Action keepAlive, IQueueMessage message)
        {
            IQueueMessage outMessage;

            try
            {
                Logger.Info(string.Format("Unit of Work Started: {0}", unitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole);

                //Get the unit of work kind that describes the assembly and type then get the actual Type
                var kind = _unitOfWorkManager.UnitOfWorkKinds[unitOfWorkInstance.UnitOfWorkKindId];
                var qualified = string.Format("{0}, {1}", kind.TypeName, kind.AssemblyName);
                var type = Type.GetType(qualified, true);
               
                //Read the work flow instance
                var workflowInstance = _workflowManager.FindWorkflowInstance(unitOfWorkInstance.WorkflowInstanceId);

                _unitOfWorkManager.UpdateWorkerRoleAddress(unitOfWorkInstance.UnitOfWorkInstanceId, ConfigurationHelper.WcfHostName, ConfigurationHelper.WcfPort.ToString(CultureInfo.InvariantCulture));

                var unitOfWorkObject = (BaseUnitOfWork) Activator.CreateInstance(type,
                    new object[]
                    {
                        workflowInstance,
                        unitOfWorkInstance,
                        _queue,
                        keepAlive,
                        _workflowManager.Container
                    });

                //Execute the unit of work
                _unitOfWorkManager.UpdateExecutionStartTime(unitOfWorkInstance.UnitOfWorkInstanceId);

                if (!ConfigurationHelper.IsOnPremise)
                {
                    //Lease can be extended for these messages
                    _messagesToExtendLease.TryAdd(message.Id, message);
                }

                unitOfWorkObject.Execute();

                if (!ConfigurationHelper.IsOnPremise)
                {
                    _messagesToExtendLease.TryRemove(message.Id, out outMessage);
                }

               _unitOfWorkManager.UpdateExecutionCompleteTime(unitOfWorkInstance.UnitOfWorkInstanceId);
                _unitOfWorkManager.UpdateUnitOfWorkStatus(unitOfWorkInstance.UnitOfWorkInstanceId,
                    WorkStatusType.Completed);

                Logger.Info(string.Format("Unit of Work Completed: {0}", unitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole);
            }
            catch (Exception ex)
            {
                if (!ConfigurationHelper.IsOnPremise)
                {
                    _messagesToExtendLease.TryRemove(message.Id, out outMessage);
                }

                throw new UnitOfWorkExecuteException("Execute Unit of Work Failed", ex, unitOfWorkInstance);
            }
            //Progress the workflow
            return ProgressTheWorkflow(unitOfWorkInstance, keepAlive, message);
        }

        /// <summary>
        /// loop to next work
        /// </summary>
        /// <param name="previousUnitOfWorkInstance">Previous work ID</param>
        /// <param name="keepAlive">keep alive deligates</param>
        /// <param name="message">Message</param>
        /// <returns>Unit of Work instance</returns>
        private UnitOfWorkInstance ProgressTheWorkflow(UnitOfWorkInstance previousUnitOfWorkInstance, Action keepAlive, IQueueMessage message)
        {
            //Peek at the next unit of work kind
            var kind = _unitOfWorkManager.ReadNextUnitOfWorkKind(previousUnitOfWorkInstance);
            if (kind == null)
            {
                _workflowManager.UpdateWorkflowStatus(previousUnitOfWorkInstance.WorkflowInstanceId,
                    WorkStatusType.Completed);
                _workflowManager.UpdateExecutionCompleteTime(previousUnitOfWorkInstance.WorkflowInstanceId);

                Logger.Info(string.Format("Completing workflow: {0}", previousUnitOfWorkInstance.WorkflowInstanceId),
                    LoggingConstants.ModuleWorkerRole);

                return null;
            }
            if (kind.IsAsynchronous)
            {
                //Unit of work is complete and will not proceed until called upon

                Logger.Info(
                   string.Format("Waiting next asynchronous unit of work: {0}", previousUnitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole);

                return null;
            }
            var nextUnitOfWorkInstance =
                _unitOfWorkManager.ProgressToNextUnitOfWorkInstance(previousUnitOfWorkInstance.UnitOfWorkInstanceId);

            Logger.Info(
               string.Format("Synchronously executing next unit of work: {0}", nextUnitOfWorkInstance.UnitOfWorkInstanceId), LoggingConstants.ModuleWorkerRole);

            return ExecuteUnitOfWork(nextUnitOfWorkInstance, keepAlive, message);
        }

    }
}