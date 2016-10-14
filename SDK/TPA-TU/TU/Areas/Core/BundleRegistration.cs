/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Web.Optimization;

namespace Sage.CA.SBS.ERP.Sage300.Core.Web
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
            bundles.Add(new ScriptBundle("~/bundles/home").Include("~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Home.js"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                "~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.FinderGrid.js",
                "~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Plugin.Finder.js",
                "~/Areas/Core/Scripts/ExportImport/Sage.CA.SBS.ERP.Sage300.Common.Plugin.Export.js",
                "~/Areas/Core/Scripts/ExportImport/Sage.CA.SBS.ERP.Sage300.Common.Plugin.Import.js",
                 "~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.ReportOptions.js",
                 "~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.Constants.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/fiscalCalendar").Include("~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.FiscalCalendar.js"));
            bundles.Add(new ScriptBundle("~/bundles/Process").Include("~/Areas/Core/Scripts/Sage.CA.SBS.Sage300.Common.Process.js"));
            bundles.Add(new ScriptBundle("~/bundles/optionalFields").Include("~/Areas/Core/Scripts/Sage.CA.SBS.ERP.Sage300.Common.OptionalFields.js"));
            bundles.Add(new ScriptBundle("~/bundles/uploadFileToBlob").Include("~/Areas/Core/Scripts/ExportImport/Sage.CA.SBS.ERP.Sage300.Common.Upload.js"));

            #region NewTenant
            bundles.Add(
              new ScriptBundle("~/bundles/NewTenant").Include(
               "~/Areas/Core/Scripts/NewTenantSetup/NewTenantRepository.js",
                "~/Areas/Core/Scripts/NewTenantSetup/NewTenantBehaviour.js"));

            #endregion

            #region Tenant Selection
            bundles.Add(
              new ScriptBundle("~/bundles/tenantselection").Include(
                "~/Areas/Core/Scripts/Tenant/Sage.CA.SBS.ERP.Sage300.Common.TenantBehavior.js"));

            #endregion

            #region OnPremiseLogin
            bundles.Add(new ScriptBundle("~/bundles/OnPremiseLogin").Include(
                "~/Areas/Core/Scripts/Authentication/Sage.CA.SBS.ERP.Sage300.Core.OnPremiseLoginBehaviour.js",
                "~/Areas/Core/Scripts/Authentication/Sage.CA.SBS.ERP.Sage300.Core.OnPremiseLoginKoExtn.js",
                "~/Areas/Core/Scripts/Authentication/Sage.CA.SBS.ERP.Sage300.Core.OnPremiseLoginRepository.js"));
            #endregion

        }
    }
}