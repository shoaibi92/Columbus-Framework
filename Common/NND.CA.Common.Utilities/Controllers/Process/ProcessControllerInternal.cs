/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Process
{
    /// <summary>
    /// Class ProcessControllerInternal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TViewModel">The type of the t view model.</typeparam>
    /// <typeparam name="TService">The type of the t service.</typeparam>
    public class ProcessControllerInternal<T, TViewModel, TService> : InternalControllerBase<TService>
        where T : ModelBase, new()
        where TViewModel : ProcessViewModel<T>, new()
        where TService : IProcessService<T>, ISecurityService
    {
        /// <summary>
        /// Constructor with context object
        /// </summary>
        /// <param name="context">Context</param>
        public ProcessControllerInternal(Context context) : base(context)
        {
        }

        
        /// <summary>
        /// Get
        /// </summary>
        /// <returns>View Model</returns>
        public virtual TViewModel Get()
        {
            var model = Service.Get();
            return new TViewModel
            {
                Data = model,
                UserMessage = new UserMessage(model),
                ProcessResult = new ProcessResult {ProgressMeter = new ProgressMeter()}
            };
        }

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>View Model</returns>
        public virtual TViewModel Process(T model)
        {
            return new TViewModel
            {
                WorkflowInstanceId = Service.Process(model),
                UserMessage = new UserMessage {IsSuccess = true}
            };
        }

        /// <summary>
        /// Get Progress
        /// </summary>
        /// <param name="workFlowInstance">Work Flow IInstance ID</param>
        /// <returns>View Model</returns>
        public async Task<TViewModel> ProgressAsync(int workFlowInstance)
        {
            var viewModel = new TViewModel
            {
                ProcessResult = await Service.GetProgressAsync(workFlowInstance),
                UserMessage = new UserMessage {IsSuccess = true}
            };
            if (viewModel.ProcessResult.ProgressMeter == null)
            {
                viewModel.ProcessResult.ProgressMeter = new ProgressMeter();
            }
            return viewModel;
        }

        /// <summary>
        /// Cancel Process
        /// </summary>
        /// <param name="workFlowInstance">Work Flow IInstance ID</param>
        /// <returns>View Model</returns>
        public async Task<TViewModel> CancelAsync(int workFlowInstance)
        {
            var viewModel = new TViewModel
            {
                ProcessResult = await Service.CancelProcessAsync(workFlowInstance),
                UserMessage = new UserMessage {IsSuccess = true}
            };
            if (viewModel.ProcessResult.ProgressMeter == null)
            {
                viewModel.ProcessResult.ProgressMeter = new ProgressMeter();
            }
            

            return viewModel;
        }
    }
}