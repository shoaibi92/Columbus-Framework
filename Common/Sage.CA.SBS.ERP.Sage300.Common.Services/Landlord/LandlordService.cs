// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Landlord
{
    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _repository;


        #region Constructor

        /// <summary>
        /// To set Request Context
        /// </summary>

        public LandlordService(ILandlordRepository repository)
        {
            _repository = repository;
        }

        #endregion

        /// <summary>
        /// Gets the user tenants.
        /// </summary>
        /// <param name="productUserId">The sage identity identifier.</param>
        /// <param name="sageTenantId">sage user id.</param>
        /// <returns></returns>
        public UserTenant Get(Guid productUserId, Guid sageTenantId)
        {
            return _repository.Get(productUserId, sageTenantId);
        }

        /// <summary>
        /// Gets the tenant details from landlord database.
        /// </summary>
        /// <param name="tenantId">The sage tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetTenant(Guid tenantId)
        {
            return _repository.GetTenant(tenantId);
        }

        /// <summary>
        /// Gets the User details from the landlord database
        /// </summary>
        /// <param name="productUserId">Product User Id</param>
        /// <returns>User</returns>
        public User GetUser(Guid productUserId)
        {
            return _repository.GetUser(productUserId);
        }

        /// <summary>
        /// Get Tenants
        /// </summary>
        /// <returns>
        /// List of tenants
        /// </returns>
        public IList<Tenant> GetTenants()
        {
            return _repository.GetTenants();
        }

        /// <summary>
        /// Get Tenants by product user id
        /// </summary>
        /// <param name="productUserId"></param>
        /// <returns>List of tenants</returns>
        public IList<Tenant> GetTenantsByProductUserId(Guid productUserId)
        {
            return _repository.GetTenantsByProductUserId(productUserId);
        }

        /// <summary>
        /// Get shared directory
        /// </summary>
        /// <param name="tenantId">Tenant Id</param>
        /// <returns>
        /// shared directory
        /// </returns>
        public string GetSharedDirectory(Guid tenantId)
        {
            return _repository.GetSharedDirectory(tenantId);
        }

        /// <summary>
        /// Updates the first time user.
        /// </summary>
        /// <param name="productUserId">The product user identifier.</param>
        /// <returns></returns>
        public bool DisableFirstTimeUser(Guid productUserId)
        {
            return _repository.DisableFirstTimeUser(productUserId);
        }

        /// <summary>
        /// Adds tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public Tenant AddTenant(Tenant tenant)
        {
            return _repository.AddTenant(tenant);
        }

        /// <summary>
        /// Adds user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public User AddUser(User user)
        {
            return _repository.AddUser(user);
        }

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public UserTenant AddUserTenant(UserTenant userTenant)
        {
            return _repository.AddUserTenant(userTenant);
        }

        /// <summary>
        /// Updates tenant.
        /// </summary>
        /// <param name="tenant">Tenant.</param>
        /// <returns>Tenant</returns>
        public Tenant UpdateTenant(Tenant tenant)
        {
            return _repository.UpdateTenant(tenant);
        }

        /// <summary>
        /// Updates user.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>User</returns>
        public User UpdateUser(User user)
        {
            return _repository.UpdateUser(user);
        }

        /// <summary>
        /// Updates user tenant.
        /// </summary>
        /// <param name="userTenant">User Tenant.</param>
        /// <returns>UserTenant</returns>
        public UserTenant UpdateUserTenant(UserTenant userTenant)
        {
            return _repository.UpdateUserTenant(userTenant);
        }

        /// <summary>
        /// Deletes tenant.
        /// </summary>
        /// <param name="tenantId">Tenant Id.</param>
        /// <returns></returns>
        public void DeleteTenant(Guid tenantId)
        {
            _repository.DeleteTenant(tenantId);
        }

        /// <summary>
        /// Deletes user.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <returns></returns>
        public void DeleteUser(Guid productUserId)
        {
            _repository.DeleteUser(productUserId);
        }

        /// <summary>
        /// Deletes user tenant.
        /// </summary>
        /// <param name="productUserId">User ID.</param>
        /// <param name="tenantId">Tenant ID.</param>
        /// <returns></returns>
        public void DeleteUserTenant(Guid productUserId, Guid tenantId)
        {
            _repository.DeleteUserTenant(productUserId, tenantId);
        }
    }
}