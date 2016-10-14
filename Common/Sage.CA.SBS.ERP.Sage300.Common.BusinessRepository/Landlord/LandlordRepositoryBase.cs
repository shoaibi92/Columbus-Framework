// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord
{
    /// <summary>
    /// Landlord Repository
    /// </summary>
    public abstract class LandlordRepositoryBase : ILandlordRepository
    {
        /// <summary>
        /// Gets the user tenant details from landlord database.
        /// </summary>
        /// <param name="productUserId">The sage identity identifier.</param>
        /// <param name="tenantId"> sage user id.</param>
        /// <returns>UserTenant</returns>
        public virtual UserTenant Get(Guid productUserId, Guid tenantId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                return
                    dbContext.UserTenants.Include("User")
                        .Include("Tenant")
                        .FirstOrDefault(
                            userTenant =>
                                userTenant.ProductUserId == productUserId
                                && userTenant.Tenant.TenantId == tenantId);

            }
        }

        /// <summary>
        /// Gets the tenant details from landlord database.
        /// </summary>
        /// <param name="tenantId">The sage tenant identifier.</param>
        /// <returns>Tenant</returns>
        public Tenant GetTenant(Guid tenantId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                return dbContext.Tenants.FirstOrDefault(tenant => tenant.TenantId == tenantId);
            }
        }

        /// <summary>
        /// Gets the user details from the landlord database
        /// </summary>
        /// <param name="productUserId">Product User Id</param>
        /// <returns>User</returns>
        public User GetUser(Guid productUserId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                return dbContext.Users.FirstOrDefault(user => user.ProductUserId == productUserId);
            }
        }

        /// <summary>
        /// Get shared directory
        /// </summary>
        /// <param name="tenantId">Tenant Id</param>
        /// <returns>shared directory</returns>
        public abstract string GetSharedDirectory(Guid tenantId);
        

        /// <summary>
        /// Get Tenants
        /// </summary>
        /// <returns>List of tenants</returns>
        public IList<Tenant> GetTenants()
        {
            using (var dbContext = new LandlordDbContext())
            {
                return dbContext.Tenants.ToList();
            }
        }

        /// <summary>
        /// Get Tenants by product user id
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns>List of tenants</returns>
        public IList<Tenant> GetTenantsByProductUserId(Guid productUserId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                return
                    dbContext.UserTenants.Where(ut => ut.ProductUserId == productUserId)
                        .Select(ut => ut.Tenant)
                        .ToList();
            }
        }

        /// <summary>
        /// Update First time user status to false
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns>True if update successful, false if Failed.</returns>
        public bool DisableFirstTimeUser(Guid productUserId)
        {
            using (var context = new LandlordDbContext())
            {
                var instance = context.Users.FirstOrDefault(user => user.ProductUserId == productUserId);

                if (instance != null)
                {
                    instance.FirstTimeUser = false;
                    context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public abstract Tenant AddTenant(Tenant tenant);

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public abstract User AddUser(User user);

        /// <summary>
        /// Adds user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public abstract UserTenant AddUserTenant(UserTenant userTenant);

        /// <summary>
        /// Updates tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public abstract Tenant UpdateTenant(Tenant tenant);

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public abstract User UpdateUser(User user);

        /// <summary>
        /// Updates user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public abstract UserTenant UpdateUserTenant(UserTenant userTenant);

        /// <summary>
        /// Deletes tenant.
        /// </summary>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public abstract void DeleteTenant(Guid tenantId);

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <returns></returns>
        public abstract void DeleteUser(Guid productUserId);

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public abstract void DeleteUserTenant(Guid productUserId, Guid tenantId);

    }
}
