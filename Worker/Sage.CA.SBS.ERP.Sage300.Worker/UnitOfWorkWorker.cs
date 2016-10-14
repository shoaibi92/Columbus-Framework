/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Handles unit of work processing
    /// </summary>
    public class UnitOfWorkWorker : IWorker
    {
        /// <summary>
        /// Constructor for use by derived classes
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="queue"></param>
        public UnitOfWorkWorker(IQueueProcessor processor, IQueue queue)
        {
            if (processor == null)
                throw new ArgumentNullException("processor");
            if (queue == null)
                throw new ArgumentNullException("queue");

            _processor = processor;
            _queue = queue;
        }

        /// <summary>
        /// Pull a message form the relevant queue and have it processed.
        /// </summary>
        /// <remarks>
        /// Exceptions are expected to get here and stop for the workers.
        /// </remarks>
        public void Execute()
        {
            var action = GetNextAction();
            if (action != null) action();
        }

        /// <summary>
        /// Return the next action to be executed or 
        /// </summary>
        /// <remarks>
        /// Exceptions are expected to get here and stop for the workers.
        /// </remarks>
        public Action GetNextAction()
        {
            Action retval = null;

            try
            {
                //note current dequeue time is set to be 1 hour.
                var message = _queue.Dequeue();
                if (message != null)
                {
                    retval = CreateActionFromMessage(message);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error while executing GetNextAction", LoggingConstants.ModuleWorkerRole, null, ex);
            }
            return retval;
        }

        /// <summary>
        /// Create action from queue message
        /// </summary>
        /// <param name="message">Queue message</param>
        /// <returns>Action - deligates</returns>
        private Action CreateActionFromMessage(IQueueMessage message)
        {
            Action retval = () =>
            {
                try
                {
                    ProcessMessage(message);
                    //Delete regardless of outcome to get it out of the queue
                    _queue.Delete(message);
                }
                catch (Exception ex)
                {
                    Logger.Error("Error while processing unit of work", LoggingConstants.ModuleWorkerRole, null, ex);
                }
            };
            return retval;
        }

        /// <summary>
        /// Process the queue message
        /// </summary>
        /// <param name="message"></param>
        private void ProcessMessage(IQueueMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            string logMessage = string.Format("QueueWorkerBase ready to DoWork for payload: {0}", message.Payload);
            Logger.Info(logMessage, LoggingConstants.ModuleWorkerRole);

            bool isSuccess = _processor.DoWork(message);

            if (!isSuccess)
            {
                logMessage = string.Format("QueueWorkerBase received a failed DoWork response for payload: {0}",
                    message.Payload);
                Logger.Error(logMessage, LoggingConstants.ModuleWorkerRole, null, null);
            }
            else
            {
                logMessage = string.Format("QueueWorkerBase completed DoWork for payload: {0}", message.Payload);
                Logger.Info(logMessage, LoggingConstants.ModuleWorkerRole);
            }
        }

        private readonly IQueueProcessor _processor;
        private readonly IQueue _queue;
    }
}
