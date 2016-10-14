/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// Model Mapper for the G/L Integration Entry Screens
    /// </summary>
    /// <typeparam name="TRef">G/L Reference Integration</typeparam>
    public abstract class BaseGLReferenceIntegrationMapper<TRef> : ModelMapper<TRef>
        where TRef : ModelBase, new()
    {

        #region Constructor

        /// <summary>
        /// Constructor with context
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseGLReferenceIntegrationMapper(Context context)
            : base(context)
        {
        }

        #endregion

        #region Abstact Methods

        /// <summary>
        /// Map Reference Integration
        /// </summary>
        /// <param name="model">Base G/L Reference Integration</param>
        /// <param name="entity">BusinessEntity</param>
        public abstract void SetReferenceIntegration(BaseGLReferenceIntegration model, IBusinessEntity entity);

        #endregion
    }
}
