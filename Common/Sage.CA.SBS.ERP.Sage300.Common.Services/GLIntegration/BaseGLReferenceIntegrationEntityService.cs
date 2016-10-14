/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.BusinessRepository;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.GLIntegration
{
    /// <summary>
    /// Class for Base G/L Reference Integration Entity Service
    /// </summary>
    /// <typeparam name="T">Base GL Reference Integration</typeparam>
    /// <typeparam name="TEntity">Interface of Base GL Reference Integration Entity of T</typeparam>
    public abstract class BaseGLReferenceIntegrationEntityService<T, TEntity> : FlatService<T, TEntity>, IBaseGLReferenceIntegrationService<T>
        where T : BaseGLReferenceIntegration, new()
        where TEntity : IBaseGLReferenceIntegrationEntity<T>, ISecurity
    {

        #region Constructor

        /// <summary>
        /// Constructor with context 
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseGLReferenceIntegrationEntityService(Context context)
            : base(context)
        {
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get Reference Details
        /// </summary>
        /// <returns>list of Reference</returns>
        public virtual EnumerableResponse<ReferenceDetail> GetReferences()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetReferences();
            }
        }

        /// <summary>
        /// Save Reference Details
        /// </summary>
        /// <param name="referenceDetails">list of reference details</param>
        /// <returns>list of Reference/></returns>
        public virtual EnumerableResponse<ReferenceDetail> SaveReferences(IEnumerable<ReferenceDetail> referenceDetails)
        {
            using (var repository = Resolve<TEntity>())
            {
               return repository.SaveReferences(referenceDetails);
            }
        }

        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>G/L Reference Integration</returns>
        public virtual T UpdateReferenceIntegration(T model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.UpdateReferenceIntegration(model);
            }
        }

        #endregion
        
    }
}
