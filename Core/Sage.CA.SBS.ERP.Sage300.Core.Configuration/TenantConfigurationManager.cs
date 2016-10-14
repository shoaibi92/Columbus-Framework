/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Configuration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Configuration
{
    /// <summary>
    /// Class TenantConfigurationManager.
    /// </summary>
    public class TenantConfigurationManager : ITenantConfigurationManager
    {
        // ReSharper disable once NotAccessedField.Local
        private string _tenantId;

        /// <summary>
        /// Constructor for tenant configuration
        /// </summary>
        /// <param name="tenantId">ID of the Tenant for which the configuration needs to be retrieved</param>
        public TenantConfigurationManager(string tenantId)
        {
            _tenantId = tenantId;
        }

        /// <summary>
        /// Default page size for displaying the records in the grid.
        /// </summary>
        /// <value>The default size of the page.</value>
        public int DefaultPageSize
        {
            get
            {
                //Currently this is hardcoded. Once we have tenant configuration tables these needs to be modified to fetch from database.
                return 10;
            }
        }


    }
}