/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Process
{
    /// <summary>
    /// Interface IWorkerService
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IWorkerService")]
    public interface IWorkerService
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>ProgressMeter.</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IWorkerService/GetStatus",
            ReplyAction = "http://tempuri.org/IWorkerService/GetStatusResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof (Workflow.Models.WorkerFault),
            Action = "http://tempuri.org/IWorkerService/GetStatusWorkerFaultFault", Name = "WorkerFault",
            Namespace = "http://schemas.datacontract.org/2004/07/Sage.CA.SBS.ERP.Sage300.Workflow.Models")]
        ProgressMeter GetStatus(int unitOfWorkInstanceId);

        /// <summary>
        /// Gets the status asynchronous.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ProgressMeter&gt;.</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IWorkerService/GetStatus",
            ReplyAction = "http://tempuri.org/IWorkerService/GetStatusResponse")]
        System.Threading.Tasks.Task<ProgressMeter> GetStatusAsync(int unitOfWorkInstanceId);

        /// <summary>
        /// Cancels the work.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IWorkerService/CancelWork",
            ReplyAction = "http://tempuri.org/IWorkerService/CancelWorkResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof (Workflow.Models.WorkerFault),
            Action = "http://tempuri.org/IWorkerService/GetStatusWorkerFaultFault", Name = "WorkerFault",
            Namespace = "http://schemas.datacontract.org/2004/07/Sage.CA.SBS.ERP.Sage300.Workflow.Models")]
        void CancelWork(int unitOfWorkInstanceId);

        /// <summary>
        /// Cancels the work asynchronous.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IWorkerService/CancelWork",
            ReplyAction = "http://tempuri.org/IWorkerService/CancelWorkResponse")]
        System.Threading.Tasks.Task CancelWorkAsync(int unitOfWorkInstanceId);
    }

    /// <summary>
    /// Interface IWorkerServiceChannel
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWorkerServiceChannel : IWorkerService, System.ServiceModel.IClientChannel
    {
    }

    /// <summary>
    /// Class WorkerServiceClient.
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public class WorkerServiceClient : System.ServiceModel.ClientBase<IWorkerService>, IWorkerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceClient"/> class.
        /// </summary>
        public WorkerServiceClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public WorkerServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public WorkerServiceClient(string endpointConfigurationName, string remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public WorkerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerServiceClient"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public WorkerServiceClient(System.ServiceModel.Channels.Binding binding,
            System.ServiceModel.EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>ProgressMeter.</returns>
        public ProgressMeter GetStatus(int unitOfWorkInstanceId)
        {
            return Channel.GetStatus(unitOfWorkInstanceId);
        }

        /// <summary>
        /// Gets the status asynchronous.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;ProgressMeter&gt;.</returns>
        public System.Threading.Tasks.Task<ProgressMeter> GetStatusAsync(int unitOfWorkInstanceId)
        {
            return Channel.GetStatusAsync(unitOfWorkInstanceId);
        }

        /// <summary>
        /// Cancels the work.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        public void CancelWork(int unitOfWorkInstanceId)
        {
            Channel.CancelWork(unitOfWorkInstanceId);
        }

        /// <summary>
        /// Cancels the work asynchronous.
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The unit of work instance identifier.</param>
        /// <returns>System.Threading.Tasks.Task.</returns>
        public System.Threading.Tasks.Task CancelWorkAsync(int unitOfWorkInstanceId)
        {
            return Channel.CancelWorkAsync(unitOfWorkInstanceId);
        }
    }
}