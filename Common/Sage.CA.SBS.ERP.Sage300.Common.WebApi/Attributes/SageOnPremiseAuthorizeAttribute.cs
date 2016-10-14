// Copyright (c) 2015 Sage Software, Inc.  All rights reserved.

#region

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes
{
    /// <summary>
    /// This filter ensures that only users who have been authenticated
    /// and authorized via Sage ID can access a particular method.
    /// </summary>
    public class SageOnPremiseAuthorizeAttribute : AuthorizeAttribute
    {
        public ILandlordService LandlordService { get; set; }

        /// <summary>
        /// Calls when an action is being authorized.
        /// We currently require basic authentication taken in combination with the company code (OrgID from URL) to determine if the
        /// call is authorized.
        /// </summary>
        /// <param name="actionContext">The context.</param><exception cref="T:System.ArgumentNullException">The context parameter is null.</exception>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            var routeValueDict = request.GetRequestContext().RouteData.Values;

            if (ShouldHandleRequestAnonymously(request))
                return;

            try
            {
                var result = new AuthenticationResult();
                var authenticator = new AuthenticationSession();
                var company = routeValueDict["company"].ToString();
                var credentials = ExtractCredentialsFromAuthorizationHeader(request.Headers.Authorization);
                authenticator.Validate(credentials.Item1, credentials.Item2, company, result);

                if (!result.IsSuccess)
                    throw new AuthenticationSessionException("The credentials are invalid.", 0x0, null);
    
                // Currently for the On-Premise case, the tenantId in the web API request is ignored.
                // Should we mandate a "-" instead?
                //if (string.CompareOrdinal(routeValueDict["tenant"].ToString().Trim(), "-") != 0)
                //    throw new InvalidCredentialException("The tenantID is invalid.");

                routeValueDict["ApplicationUserId"] = credentials.Item1;
                routeValueDict["ApplicationUserPassword"] = credentials.Item2;
            }
            catch (AuthenticationSessionException)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                var host = actionContext.Request.RequestUri.DnsSafeHost;
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host)); // add a challenge to the error response
            }
        }

        /// <summary>
        /// Extracts the username and password from the Basic Authentication authorization header value
        /// </summary>
        /// <param name="value">The authorization header value</param>
        /// <returns>a Tuple containing 1) the username and 2) the password</returns>
        private static Tuple<string, string> ExtractCredentialsFromAuthorizationHeader(AuthenticationHeaderValue value)
        {
            try
            {
                if (value == null || value.Scheme != "Basic")
                    throw new Exception();

                var encoding = Encoding.GetEncoding("iso-8859-1");
                var credentials = encoding.GetString(Convert.FromBase64String(value.Parameter));
                var separator = credentials.IndexOf(':');
                return new Tuple<string, string>(credentials.Substring(0, separator), credentials.Substring(separator + 1));
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("The authorization header is invalid.");
            }
        }

        /// <summary>
        /// Returns whether the request can be handled anonymously (for on-premise), thereby skipping the BASIC authentication
        /// </summary>
        /// <param name="request">the request being examined</param>
        /// <returns>true if request can be handled anonymously; false otherwise.</returns>
        private static bool ShouldHandleRequestAnonymously(HttpRequestMessage request)
        {
            if (request.Method == HttpMethod.Get)
            {
                var routeValueDict = request.GetRequestContext().RouteData.Values;
                if (routeValueDict["company"] == null && string.Equals((string)routeValueDict["controller"], "Companies"))
                    return true;
            }
            return false;
        }
    }
}