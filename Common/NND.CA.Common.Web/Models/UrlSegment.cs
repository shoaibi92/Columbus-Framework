/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Routing;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Models
{
    /// <summary>
    /// Url Segment
    /// </summary>
    public class UrlSegment
    {
        /// <summary>
        /// Tenant alias
        /// </summary>
        public string TenantAlias { get; set; }

        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Get Url Segment
        /// </summary>
        /// <param name="routeDataValues">Route Values</param>
        /// <param name="dataTokens">Data Tokens</param>
        /// <returns>UrlSegment</returns>
        public static UrlSegment Get(RouteValueDictionary routeDataValues, RouteValueDictionary dataTokens)
        {
            return new UrlSegment
            {
                TenantAlias =
                    routeDataValues.ContainsKey("tenantAlias")
                        ? routeDataValues["tenantAlias"].ToString()
                        : string.Empty,
                Controller =
                    routeDataValues.ContainsKey("controller")
                        ? routeDataValues["controller"].ToString()
                        : string.Empty,
                Action =
                    routeDataValues.ContainsKey("action") ? routeDataValues["action"].ToString() : string.Empty,
                Area = dataTokens.ContainsKey("area") ? dataTokens["area"].ToString() : string.Empty
            };
        }
    }
}
