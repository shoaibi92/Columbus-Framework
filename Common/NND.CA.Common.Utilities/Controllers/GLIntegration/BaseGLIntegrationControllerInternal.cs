/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.Service;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.GLIntegration
{
    /// <summary>
    /// Class for Base G/L Integration Controller Internal methods
    /// </summary>
    /// <typeparam name="TRef">G/L Reference Integration</typeparam>
    /// <typeparam name="TViewModel">G/L Integration View Model</typeparam>
    /// <typeparam name="TRefService">Base G/L Reference Integration Service Interface</typeparam>
    public class BaseGLIntegrationControllerInternal<TRef, TViewModel, TRefService> : InternalControllerBase<TRefService>
        where TRef : BaseGLReferenceIntegration, new()
        where TViewModel : BaseGLIntegrationViewModel<TRef>, new()
        where TRefService : IBaseGLReferenceIntegrationService<TRef>, ISecurityService
    {

        #region constructor
        /// <summary>
        /// Constructor for Base GL Integration Controller Internal class with context.
        /// </summary>
        /// <param name="context">Request context</param>
        public BaseGLIntegrationControllerInternal(Context context)
            : base(context)
        {

        }


        #endregion

        #region public methods
        /// <summary>
        /// Get G/L Integration Default/Empty Model
        /// </summary>
        /// <returns>G/L Integration view model</returns>
        public virtual TViewModel GetDefaultModel()
        {
            return new TViewModel
            {
                GLSourceCodes = new EnumerableResponse<GLSourceCode>(),
                GLPostingSequences = new EnumerableResponse<GLPostingSequence>(),
                ReferenceDetails = new EnumerableResponse<ReferenceDetail>()
            };
        }

        /// <summary>
        ///  Save G/L References
        /// </summary>
        /// <param name="model">List of ReferenceDetail to save</param>
        /// <returns>List of ReferenceDetail</returns>
        public virtual EnumerableResponse<ReferenceDetail> SaveReferences(EnumerableResponse<ReferenceDetail> model)
        {
            //save G/L Reference Integration
            if (model.Items.Any())
            {
                model = Service.SaveReferences(model.Items);
            }
            return model;
        }
      
        /// <summary>
        /// Get G/L SourceCode List
        /// </summary>
        /// <param name="model">G/L Integration view model to get source codes</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>G/L Integration view model</returns>
        public virtual TViewModel GetGLSourceCodes(TViewModel model, int pageNumber, int pageSize)
        {
            return new TViewModel
            {
                GLSourceCodes = GetGLSourceCodeList(model, pageNumber, pageSize),
                Data = model.Data,
                UserMessage = new UserMessage(model.Data)
            };
        }

        /// <summary>
        /// Get G/L Posting Sequence List
        /// </summary>
        /// <param name="model">G/L Integration view model to get posting sequence</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>G/L Integration view model</returns>
        public virtual TViewModel GetGLPostingSequences(TViewModel model, int pageNumber, int pageSize)
        {
            return new TViewModel
            {
                GLPostingSequences = GetGLPostingSequenceList(model, pageNumber, pageSize),
                Data = model.Data,
                UserMessage = new UserMessage(model.Data)
            };
        }

        /// <summary>
        /// Get G/L SourceCode List
        /// </summary>
        /// <param name="model">G/L Integration view model to get source codes</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>new list of G/L Source Code</returns>
        public virtual EnumerableResponse<GLSourceCode> GetGLSourceCodeList(TViewModel model, int pageNumber, int pageSize)
        {
            return new EnumerableResponse<GLSourceCode>();
        }

        /// <summary>
        /// Get G/L Posting Sequence List
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>new list of G/L Posting Sequence</returns>
        public virtual EnumerableResponse<GLPostingSequence> GetGLPostingSequenceList(TViewModel model, int pageNumber, int pageSize)
        {
            return new EnumerableResponse<GLPostingSequence>();
        }

        #endregion

        #region internal methods

        /// <summary>
        /// Get G/L Reference List
        /// </summary>
        /// <param name="model">G/L Integration view model to fill fetched data</param>
        /// <returns>G/L Integration view model</returns>
        internal TViewModel GetReferences(TViewModel model)
        {
            var glReferenceDetailList = Service.GetReferences();
            return new TViewModel
            {
                ReferenceDetails = glReferenceDetailList,
                Data = model.Data,
                UserMessage = new UserMessage(model.Data)
            };
        }

        /// <summary>
        /// Get G/L Reference List for page number and page size
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>list of ReferenceDetail></returns>
        internal virtual EnumerableResponse<ReferenceDetail> GetReferences(TViewModel model, int pageNumber, int pageSize)
        {
            return new EnumerableResponse<ReferenceDetail>
            {
                Items = model.ReferenceDetails.Items.Skip(pageNumber * pageSize).Take(pageSize),
                TotalResultsCount = model.ReferenceDetails.Items.Count()
            };
        }


        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>G/L Integration view model</returns>
        internal TViewModel UpdateReferenceIntegration(TRef model)
        {
            var updatedModel = Service.UpdateReferenceIntegration(model);

            return new TViewModel
            {
                Data = updatedModel,
                UserMessage = new UserMessage { IsSuccess = true }
            };
        }
        #endregion
    }
}
