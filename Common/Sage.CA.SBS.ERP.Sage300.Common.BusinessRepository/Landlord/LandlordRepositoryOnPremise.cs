// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using System;
using System.Data.Entity;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord
{
    public class LandlordRepositoryOnPremise : LandlordRepositoryBase
    {
        /// <summary>
        /// Adds tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public override Tenant AddTenant(Tenant tenant)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.Tenants.Add(tenant);
                dbContext.SaveChanges();
                return tenant;
            }
        }

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public override User AddUser(User user)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return user;
            }
        }

        /// <summary>
        /// Adds user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public override UserTenant AddUserTenant(UserTenant userTenant)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.UserTenants.Add(userTenant);
                dbContext.SaveChanges();
                return userTenant;
            }
        }

        /// <summary>
        /// Updates tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public override Tenant UpdateTenant(Tenant tenant)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.Entry(tenant).State = EntityState.Modified;
                dbContext.SaveChanges();
                return tenant;
            }
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public override User UpdateUser(User user)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();
                return user;
            }
        }

        /// <summary>
        /// Updates user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public override UserTenant UpdateUserTenant(UserTenant userTenant)
        {
            using (var dbContext = new LandlordDbContext())
            {
                dbContext.Entry(userTenant).State = EntityState.Modified;
                dbContext.SaveChanges();
                return userTenant;
            }
        }

        /// <summary>
        /// Deletes tenant.
        /// </summary>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public override void DeleteTenant(Guid tenantId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                var tenant = dbContext.Tenants.Find(tenantId);
                dbContext.Tenants.Remove(tenant);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <returns></returns>
        public override void DeleteUser(Guid productUserId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                var user = dbContext.Users.Find(productUserId);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public override void DeleteUserTenant(Guid productUserId, Guid tenantId)
        {
            using (var dbContext = new LandlordDbContext())
            {
                // check if user tenant exists
                if (dbContext.UserTenants.Include("User")
                        .Include("Tenant").Any(userTenant => userTenant.ProductUserId == productUserId && userTenant.Tenant.TenantId == tenantId))
                {
                    // get the related User Tenant and then remove Tenant record
                    var userTenant = dbContext.UserTenants.Include("User")
                        .Include("Tenant").FirstOrDefault(userTenants => userTenants.ProductUserId == productUserId && userTenants.Tenant.TenantId == tenantId);
                    if (userTenant != null)
                    {
                        dbContext.UserTenants.Remove(userTenant);
                        dbContext.Users.Remove(dbContext.Users.FirstOrDefault(user => user.ProductUserId == productUserId));
                        dbContext.Tenants.Remove(dbContext.Tenants.FirstOrDefault(tenant => tenant.TenantId == tenantId));
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Get shared directory impl
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public override string GetSharedDirectory(Guid tenantId)
        {
            // tenantId is ignored for onPrem
            return RegistryHelper.SharedDataDirectory;
        }
    }
}
