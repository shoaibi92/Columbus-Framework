/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Web.Mvc;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Used to decorate the action methods which does not need authentication
    /// </summary>
    public class NoAuthenticationRequiredAttribute : FilterAttribute
    {
    }
}