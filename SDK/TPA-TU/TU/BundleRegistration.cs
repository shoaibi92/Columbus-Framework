/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Optimization;

namespace TPA.Web
{
    /// <summary>
    /// Class for bundle registration
    /// </summary>
    internal static class BundleRegistration
    {
        /// <summary>
        /// Register bundles
        /// </summary>
        /// <param name="bundles"></param> 
        internal static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/TU/AccountGroup").Include(
                    "~/Areas/TU/Scripts/AccountGroup/TPA.TU.AccountGroupBehaviour.js",
                    "~/Areas/TU/Scripts/AccountGroup/TPA.TU.AccountGroupKoExtn.js",
                    "~/Areas/TU/Scripts/AccountGroup/TPA.TU.AccountGroupRepository.js"));

        }
    }
}
