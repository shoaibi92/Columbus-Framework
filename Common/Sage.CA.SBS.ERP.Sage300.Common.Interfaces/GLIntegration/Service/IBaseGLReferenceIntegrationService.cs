/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.Service
{
    /// <summary>
    /// Interface IBaseGLReferenceIntegrationService
    /// </summary>
    /// <typeparam name="T">Base G/L Reference Integration</typeparam>
    public interface IBaseGLReferenceIntegrationService<T> : IEntityService<T>, ISecurityService where T : ModelBase, new()
    {

        /// <summary>
        /// Get Reference Details
        /// </summary>
        /// <returns>list of Reference/></returns>
        EnumerableResponse<ReferenceDetail> GetReferences();

        /// <summary>
        /// Save Reference Details
        /// </summary>
        /// <param name="referenceDetails">List of Reference details<ReferenceDetail/></param>
        /// <returns>list of Reference</returns>
        EnumerableResponse<ReferenceDetail> SaveReferences(IEnumerable<ReferenceDetail> referenceDetails);

        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>G/L Reference Integration</returns>
        T UpdateReferenceIntegration(T model);
    }
}
