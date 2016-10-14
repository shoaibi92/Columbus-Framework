/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.ServiceModel;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces
{
    /// <summary>
    /// Service class, exposes some methods for web role
    /// </summary>
    [ServiceContract]
    public interface IWorkerService
    {
        /// <summary>
        /// Get status of workflow
        /// </summary>
        /// <param name="unitOfWorkInstanceId">unit of work instance id</param>
        /// <returns>Progressmeter</returns>
        [OperationContract]
        [FaultContract(typeof(WorkerFault))]
        ProgressMeter GetStatus(int unitOfWorkInstanceId);

        /// <summary>
        /// Health Status Check
        /// </summary>
        /// <param name="command">command for status</param>
        /// <returns>string status</returns>
        [OperationContract]
        [FaultContract(typeof(WorkerFault))]
        string GetHealthStatus(int command);

        /// <summary>
        /// Cancel the work
        /// </summary>
        /// <param name="unitOfWorkInstanceId">unit of work instance id</param>
        [OperationContract]
        [FaultContract(typeof(WorkerFault))]
        void CancelWork(int unitOfWorkInstanceId);
    }
}