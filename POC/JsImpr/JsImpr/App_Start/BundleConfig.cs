using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace JsImpr
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
             bundles.Add(new LessBundle("~/Content/Styles/lessCss").Include(
                "~/Content/Styles/Kendo/kendo.common.min.css",
                "~/Content/Styles/Kendo/kendo.default.min.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Site.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Reset.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Buttons.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Calendar.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.DataGrid.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.DropDown.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.FormControls.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Window.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300datepicker.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Tabs.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Common.css",
                "~/Content/Styles/Sage.CA.SBS.ERP.Sage300.Grid.css"));

             bundles.Add(new LessBundle("~/Content/Styles/localizedLessCssR2").Include(
                 "~/Content/Styles/Kendo/kendo.common.min.css",
                 "~/Content/Styles/Kendo/kendo.default.min.css",
                 "~/Content/Styles/base.css",
                 "~/Content/Styles/custom.css"));
        }
    }
}