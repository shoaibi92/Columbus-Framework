// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord
{
    /// <summary>
    /// Landlord Repository On The Cloud
    /// </summary>
    public class LandlordRepository : LandlordRepositoryBase
    {
        /// <summary>
        /// Adds tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public override Tenant AddTenant(Tenant tenant)
        {
            return tenant;
        }

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public override User AddUser(User user)
        {
            return user;
        }

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
        /// Updates tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public override Tenant UpdateTenant(Tenant tenant)
        {
            return tenant;
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
        /// Updates user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public override UserTenant UpdateUserTenant(UserTenant userTenant)
        {
            return userTenant;
        }

        /// <summary>
        /// Deletes tenant.
        /// </summary>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public override void DeleteTenant(Guid tenantId)
        {
            
        }

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <returns></returns>
        public override void DeleteUser(Guid productUserId)
        {
            
        }

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public override void DeleteUserTenant(Guid productUserId, Guid tenantId)
        {
            
        }

        /// <summary>
        /// Gets shared directory impl
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public override string GetSharedDirectory(Guid tenantId)
        {
            var tenant = GetTenant(tenantId);
            if (tenant != null)
            {
                return RegistryHelper.SharedDataDirectory + tenant.InternalName;
            }
            return null;
            
        }
    }
}