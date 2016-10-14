/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.BusinessRepository
{
    /// <summary>
    /// Interface for Base G/L Reference Integration Entity 
    /// </summary>
    /// <typeparam name="T">Base Model</typeparam>
    public interface IBaseGLReferenceIntegrationEntity<T> : IBusinessRepository<T>, ISecurity where T : ModelBase, new()
    {

        /// <summary>
        /// Get Reference Details
        /// </summary>
        /// <returns>List Of Reference Detail<ReferenceDetail/></returns>
        EnumerableResponse<ReferenceDetail> GetReferences();

        /// <summary>
        /// Save Reference Details
        /// </summary>
        /// <param name="referenceDetails">List Of Reference Detail<ReferenceDetail/></param>
        /// <returns>List Of Reference Detail<ReferenceDetail/></returns>
        EnumerableResponse<ReferenceDetail> SaveReferences(IEnumerable<ReferenceDetail> referenceDetails);

        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>G/L Reference Integration</returns>
        T UpdateReferenceIntegration(T model);
    }
}
