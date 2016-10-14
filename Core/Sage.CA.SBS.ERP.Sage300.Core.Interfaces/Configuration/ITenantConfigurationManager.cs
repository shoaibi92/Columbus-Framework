/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */


namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Configuration
{

    /// <summary>
    /// These all configurations will be based on tenant. Every tenant can have different set of configurations.
    /// </summary>
    public interface ITenantConfigurationManager
    {
        /// <summary>
        /// Default page size for displaying the records in the grid.
        /// </summary>
        int DefaultPageSize { get; }
    }
}
