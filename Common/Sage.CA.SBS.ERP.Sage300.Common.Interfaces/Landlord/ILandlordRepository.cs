// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord
{
    /// <summary>
    /// Interface Landlord Repository
    /// </summary>
    public interface ILandlordRepository
    {
        /// <summary>
        /// Gets the user tenants.
        /// </summary>
        /// <param name="productUserId">The sage identity identifier.</param>
        /// <param name="tenantId"> sage user id.</param>
        /// <returns></returns>
        UserTenant Get(Guid productUserId, Guid tenantId);
        
        /// <summary>
        /// Gets the tenant details from landlord database.
        /// </summary>
        /// <param name="tenantId">The sage tenant identifier.</param>
        /// <returns></returns>
        Tenant GetTenant(Guid tenantId);

        /// <summary>
        /// Gets the user details from the database.
        /// </summary>
        /// <param name="productUserId">Product User Id</param>
        /// <returns>User</returns>
        User GetUser(Guid productUserId);

        /// <summary>
        /// Get Tenants
        /// </summary>
        /// <returns>List of tenants</returns>
        IList<Tenant> GetTenants();

        /// <summary>
        /// Get Tenants by product user id
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns>List of tenants</returns>
        IList<Tenant> GetTenantsByProductUserId(Guid productUserId);

        /// <summary>
        /// Get shared directory
        /// </summary>
        /// <param name="tenantId">Tenant Id</param>
        /// <returns>shared directory</returns>
        string GetSharedDirectory(Guid tenantId);

        /// <summary>
        /// Updates the first time user to false
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        bool DisableFirstTimeUser(Guid productUserId);

        /// <summary>
        /// Adds tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        Tenant AddTenant(Tenant tenant);

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        User AddUser(User user);

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        UserTenant AddUserTenant(UserTenant userTenant);

        /// <summary>
        /// Updates tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        Tenant UpdateTenant(Tenant tenant);

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        User UpdateUser(User user);

        /// <summary>
        /// Updates user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        UserTenant UpdateUserTenant(UserTenant userTenant);

        /// <summary>
        /// Deletes tenant.
        /// </summary>
        /// <param name="tenantId">Tenant Id.</param>
        /// <returns></returns>
        void DeleteTenant(Guid tenantId);

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <returns></returns>
        void DeleteUser(Guid productUserId);

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        void DeleteUserTenant(Guid productUserId, Guid tenantId);
    }
}