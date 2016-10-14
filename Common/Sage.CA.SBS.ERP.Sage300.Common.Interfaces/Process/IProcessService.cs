/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Process
{
    /// <summary>
    /// Interface IProcessService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProcessService<T> : ISecurityService where T : ModelBase, new()
    {
        /// <summary>
        /// Gets the model
        /// </summary>
        /// <returns>T</returns>
        T Get();

        /// <summary>
        /// Process the business entity
        /// </summary>
        /// <param name="model">Model base</param>
        /// <returns>result- token</returns>
        int Process(T model);

        /// <summary>
        /// Get Progress status
        /// </summary>
        /// <param name="workFlowInstanceId">The work flow instance identifier.</param>
        /// <returns>ProcessResult</returns>
        Task<ProcessResult> GetProgressAsync(int workFlowInstanceId);

        /// <summary>
        /// Cancel the progress
        /// </summary>
        /// <param name="workFlowInstanceId">The work flow instance identifier.</param>
        /// <returns>ProcessResult</returns>
        Task<ProcessResult> CancelProcessAsync(int workFlowInstanceId);
    }
}