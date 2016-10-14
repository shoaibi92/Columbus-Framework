/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// Generic handler for exposing a set of Sage views as a resource 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IViewResourceRepository<TModel> : IBusinessRepository<TModel> where TModel : ModelBase, new()
    {
        /// <summary>
        /// Initialize this repository with the given parameters
        /// </summary>
        /// <param name="topLevelEntity">The top level view resource entity to be handled</param>
        /// <param name="consumer">The unique identifier for this class instance</param>
        void Initialize(IViewEntity topLevelEntity, string consumer);

        /// <summary>
        /// Gets a record in the resource
        /// </summary>
        /// <param name="keySegments">The key value pairs that identifies a record to be retrieved</param>
        TModel Get(List<KeyValuePair<string, object>> keySegments);

        /// <summary>
        /// Deletes a record in the resource
        /// </summary>
        /// <param name="keySegments">The key value pairs that identifies a record to be deleted</param>
        void Delete(List<KeyValuePair<string, object>> keySegments);

        /// <summary>
        /// Replaces an existing record in the resource
        /// </summary>
        /// <param name="keySegments">The key value pairs that identifies a record to be replaced</param>
        /// <param name="model"></param>
        TModel Replace(List<KeyValuePair<string, object>> keySegments, ModelBase model);
    }
}