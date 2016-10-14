/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using CEDataService;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using SageNA.CE.UM.Client;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes
{
    /// <summary>
    /// This filter ensures that only users who have been authenticated
    /// and authorized via Sage ID can access a particular method.
    /// </summary>
    public class SageIdAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// The authenticator.
        /// </summary>
        private UMOAuth _authenticator;

        /// <summary>
        /// The authenticator.
        /// </summary>
        private UMOAuth Authenticator
        {
            get { return _authenticator ?? (_authenticator = new UMOAuth()); }
        }

        /// <summary>
        /// Returns true iff the given access token (taken from request body) is
        /// valid and the given requested tenant (taken from URL) is in the user's
        /// list of accessible tenants (taken from access token), or Sage ID
        /// integration has been disabled. Also stores userId and tenantId in the 
        /// route value dictionary.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns>True iff the user is authenticated and authorized.</returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var currRequest = HttpContext.Current.Request;
            var routeValueDict = currRequest.RequestContext.RouteData.Values;

            // Call the UMClient if Sage ID integration has been enabled
            var signOnResult = Authenticator.GetOAuthInfo(currRequest, false);
            if (!signOnResult.IsValid)
            {
                Logger.Info(string.Format("Sage ID sign on failed. Reason: {0}, Message: {1}",
                    signOnResult.Reason, signOnResult.SignOnInfoText), LoggingConstants.ModuleAuthentication);
                return false;
            }

            // Check if the user has tenant access.
            // Route parameter "tenant" will have value of TenantID
            var requestedTenant = (string)routeValueDict["tenant"];
            Guid requestedTenantId;
            if (!Guid.TryParse(requestedTenant, out requestedTenantId))
            {
                Logger.Info(
                    string.Format("Sage ID sign on failed. Unable to retrieve Tenant ID from request URL. The value '{0}' has invalid format.",
                        requestedTenant), LoggingConstants.ModuleAuthentication);
                return false;
            }

            //Check the requested tenant ID is valid
            var requestedUserInfo =
                signOnResult.User.AppUserAccessInfo.SingleOrDefault(u => u.TenantInfo.TenantId == requestedTenantId);
            if (requestedUserInfo == default(AppUserAccess))
            {
                Logger.Info(string.Format("Sage ID sign on failed. Requested Tenant ID '{0}' is not valid.", requestedTenant),
                    LoggingConstants.ModuleAuthentication);
                return false;
            }

            // Store the requested user's info in the routeValueDict.
            routeValueDict["userId"] = signOnResult.User.ProductUserId;
            routeValueDict["tenantId"] = requestedUserInfo.TenantInfo.TenantId;
            return true;
        }
    }
}