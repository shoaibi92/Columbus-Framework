/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Web.Http.OData;
using System.Web.Http.OData.Query;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes
{
    /// <summary>
    /// Enables the following OData query options.
    /// </summary>
    public class SageEnableQueryAttribute : EnableQueryAttribute
    {
        public SageEnableQueryAttribute()
        {
            // For options such as startswith/endswith, don't check if the property is null.
            HandleNullPropagation = HandleNullPropagationOption.False;
            // Don't specify a default ordering. Suppresses ThenBy() calls.
            EnsureStableOrdering = false;
            // Increase the default 100 to 300. Each clause of the form "property op constant"
            // uses about 6 nodes, so this allows us to use about 300/6 = 50 such clauses.
            MaxNodeCount = 300;
            // Set page size
            PageSize = WebApiConfigurationHelper.PageSize == 0 ? int.MaxValue - 1 : WebApiConfigurationHelper.PageSize;
        }
    }
}