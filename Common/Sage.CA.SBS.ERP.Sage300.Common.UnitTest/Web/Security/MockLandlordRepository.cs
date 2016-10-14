// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Mock class for landlord repository
    /// </summary>
    public class MockLandlordRepository : LandlordRepositoryOnPremise
    {
        /// <summary>
        /// Adds user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public override UserTenant AddUserTenant(UserTenant userTenant)
        {
            return userTenant;
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public override User UpdateUser(User user)
        {
            return user;
        }
        /// <summary>
        /// Gets the user tenant details from landlord database.
        /// </summary>
        /// <param name="productUserId">The sage identity identifier.</param>
        /// <param name="tenantId"> sage user id.</param>
        /// <returns>UserTenant</returns>
        public override UserTenant Get(Guid productUserId, Guid tenantId)
        {
            return new UserTenant() { Tenant = new Tenant() };
        }

    }
}
