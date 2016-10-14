// Copyright (c) 2016 Sage Software, Inc.  All rights reserved.

using System;
using System.Linq;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using User = Sage.CA.SBS.ERP.Sage300.AS.Models.User;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// UserTenant Resolver for on-premise deployments
    /// </summary>
    public class UserTenantResolverOnPremise : IUserTenantResolver
    {
        private const int PasswordSize = 64;

        /// <summary>
        /// Finds the corresponding UserTenantInfo for the current session, creating it if necessary
        /// </summary>
        /// <param name="container">The Unity container</param>
        /// <param name="context">The current context</param>
        /// <param name="company">The Org ID of the company</param>
        /// <param name="userId">The 300 User ID signing in</param>
        /// <param name="password">The unencrypted password for the user</param>
        /// <returns>The corresponding UserTenantInfo for the current session </returns>
        public UserTenantInfo ResolveUserTenant(IUnityContainer container, Context context, string company, string userId, string password)
        {
            // Vars for landlord database tables
            var recordId = DeterministicGuid.CreateFrom(company + ":" + userId);
            var encryptedPassword = Blowfish.Blowfish_Encrypt(Blowfish.LandlordPassKey, password.PadRight(PasswordSize, ' '));

            // Modify context object
            context.ApplicationUserId = userId;
            context.Company = company;
            context.ProductUserId = recordId;
            context.TenantId = recordId;
            context.TenantAlias = AreaConstants.Core.OnPremiseTenantAlias;

            var landlordService = Utilities.Utilities.Resolve<ILandlordService>(context);
            var userTenant = landlordService.Get(context.ProductUserId, context.TenantId);
            if (userTenant != null)
            {
                if (string.CompareOrdinal(encryptedPassword, userTenant.ApplicationPassword) != 0)
                {
                    userTenant.ApplicationPassword = encryptedPassword;
                    landlordService.UpdateUserTenant(userTenant);
                }

                if (userTenant.Tenant.DatabasePassword != null)
                {
                    userTenant.Tenant.LastUpdated = DateTime.UtcNow;
                    userTenant.Tenant.DatabasePassword = null; // We decided to set DatabasePassword to null since it is not used for the on-premise scenario
                    landlordService.UpdateTenant(userTenant.Tenant);
                }
            }
            else
            {
                userTenant = new UserTenant
                {
                    ProductUserId = context.ProductUserId,
                    ApplicationLoginId = userId,
                    ApplicationPassword = encryptedPassword,
                    Tenant =
                        new Tenant
                        {
                            TenantId = context.TenantId,
                            SiteId = recordId,
                            InternalName = recordId.ToString("N"),
                            Status = (int)TenantStatus.Active,
                            Version = string.Empty,
                            LastUpdated = DateTime.UtcNow,
                            Company = company,
                            ServerName = string.Empty,
                            DatabaseLogin = userId,
                            DatabasePassword = null // We decided to set DatabasePassword to null since it is not used for the on-premise scenario
                        },
                    User =
                        new Common.Models.Landlord.User
                        {
                            ProductUserId = context.ProductUserId,
                            Name = userId,
                            Email = string.Empty,
                            Status = "Active",
                            LastUpdated = DateTime.UtcNow,
                        }
                };
                userTenant = landlordService.AddUserTenant(userTenant);

                // Get user properties in order to fill out tenant models
                var userService = Utilities.Utilities.Resolve<IUserService<User>>(context);
                var user = userService.GetUserLogin(userId);

                if (!string.IsNullOrEmpty(user.Email1))
                {
                    userTenant.User.Email = user.Email1;
                }

                if (!string.IsNullOrEmpty(user.UserName))
                {
                    userTenant.User.Name = user.UserName;
                }

                // Update landlord database based upon values retrieved from user
                if (!string.IsNullOrEmpty(user.Email1) || !string.IsNullOrEmpty(user.UserName))
                {
                    landlordService.UpdateUser(userTenant.User);
                }
            }

            // Build tenant structure
            var authenticationSession = container.Resolve<IAuthenticationSession>();
            var companies = authenticationSession.GetCompanies(context);

            var userTenantInfo = new UserTenantInfo
            {
                // UserTenantInfo
                IsValid = true,
                ProductUserId = context.ProductUserId,
                // UserInfo
                LoggedInUser =
                    new UserInfo
                    {
                        FirstName = userTenant.User.Name,
                        PrimaryEmail = userTenant.User.Email,
                        IsActive = true,
                        IsGuest = true,
                        ProductUserId = context.ProductUserId
                    },
                // TenantInfo
                SelectedTenant =
                    new TenantInfo
                    {
                        TenantId = context.TenantId,
                        Status = TenantStatus.Active,
                        TenantAlias = context.TenantAlias,
                        Company = company,
                        ApplicationUserId = userId,
                        Organizations = companies,
                        TenantName = companies.Single(org => org.Id.Equals(company)).Name
                    }
            };
            return userTenantInfo;
        }
    }
}