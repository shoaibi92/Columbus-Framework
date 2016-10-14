/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// To be removed in a future iteration as a generic resource service is unnecessary
    /// </summary>
    public interface IViewResourceService<TModel, TRepository> : IEntityService<TModel> where TModel : ModelBase, new()
    {
        /// <summary>
        /// The repository for handling the underlying business logic for this service
        /// </summary>
        TRepository Repository { get; set; }
    }
}
