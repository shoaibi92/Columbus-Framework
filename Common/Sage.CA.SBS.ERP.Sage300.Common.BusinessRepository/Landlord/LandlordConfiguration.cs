/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord
{
    /// <summary>
    /// Landlord Configuration
    /// </summary>
    public class LandlordConfiguration : DbConfiguration
    {
        /// <summary>
        /// Sets the execution strategy
        /// DbExecutionStrategy and will retry on exceptions that are known to be possibly transient when working with SqlAzure.
        /// The default retry limit is 5, which means that the total amount of time spent between retries is 26 seconds plus the random factor.
        /// </summary>
        public LandlordConfiguration()
        {
            if (!ConfigurationHelper.IsOnPremise)
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            }
        }
    }
}
