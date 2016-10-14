/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Optimization;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web
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
                new ScriptBundle("~/bundles/shared").Include(
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.JavaScriptExtensions.js", 
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Customization.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Cache.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Global.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.URL.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Controls.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.KendoHelpers.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Validate.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.GridPreferences.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.LabelMenuHelper.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Constants.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.iFrameHelper.js",
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.InquiryGrid.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/genericreport").Include(
                    "~/Areas/Shared/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Report.js"));

            #region GLTransaction Report

            bundles.Add(new ScriptBundle("~/bundles/GLTransactionReport").Include(
                "~/Areas/Shared/Scripts/Report/GLTransaction/Sage.CA.SBS.ERP.Sage300.Common.GLTransactionBehaviour.jS",
                "~/Areas/Shared/Scripts/Report/GLTransaction/Sage.CA.SBS.ERP.Sage300.Common.GLTransactionRepository.js",
                "~/Areas/Shared/Scripts/Report/GLTransaction/Sage.CA.SBS.ERP.Sage300.Common.GLTransactionKoExtn.js"));
            #endregion
        }
    }
}
