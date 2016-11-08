/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Class Shared.
    /// </summary>
    public static class Shared
    {
        #region Session Variables Used Accross

        /// <summary>
        /// User Management authorization information - holds the UserSignOnResult when logged in.
        /// </summary>
        public const string SessionAuthInfo = "authinfo";

        /// <summary>
        /// Login Resume - holds the flag to determine if resume login is allowed.
        /// </summary>
        public const string SessionResumeLogin = "ResumeLogin";

        /// <summary>
        /// User Language
        /// </summary>
        public const string UserPreferredLanguage = "userpreferredlanguage";

        /// <summary>
        /// SessionDate
        /// </summary>
        public const string SessionDate = "sessiondate";

        /// <summary>
        /// Holds the selected CE UM tenant's ID (which is a GUID).
        /// </summary>
        public const string SessionSelectedUmTenantId = "selectedumtenantid";

        /// <summary>
        /// Holds the selected company ID.
        /// </summary>
        public const string SessionCompanyId = "companyid";

        /// <summary>
        /// ASP Session Id
        /// </summary>
        public const string DotNetSessionId = "ASP.NET_SessionId";

        /// <summary>
        /// ApplicationRequestRouting Cookie
        /// </summary>
        public const string ApplicationRequestRoutingCookie = "ARRAffinity";

        #endregion
        /// <summary>
        /// The layout
        /// </summary>
        public const string Layout = "~/Areas/Shared/Views/Shared/_Layout.cshtml";

        /// <summary>
        /// The report footer partial view path
        /// </summary>
        public const string ReportFooter = "~/Areas/Shared/Views/Shared/_ReportFooter.cshtml";

        /// <summary>
        /// The setup footer partial view path
        /// </summary>
        public const string SetupFooter = "~/Areas/Shared/Views/Shared/_SetupFooter.cshtml";

        /// <summary>
        /// The processing footer partial view path
        /// </summary>
        public const string ProcessingFooter = "~/Areas/Shared/Views/Shared/_ProcessingFooter.cshtml";

        /// <summary>
        /// Common button base partial view
        /// </summary>
        public const string ButtonBase = "~/Areas/Shared/Views/Partials/_ButtonBase.cshtml";

        /// <summary>
        /// Common save button partial view
        /// </summary>
        public const string SaveButton = "~/Areas/Shared/Views/Partials/_SaveButton.cshtml";

        /// <summary>
        /// Common delete button partial view
        /// </summary>
        public const string DeleteButton = "~/Areas/Shared/Views/Partials/_DeleteButton.cshtml";

        /// <summary>
        /// Common optional button partial view
        /// </summary>
        public const string OptionalButton = "~/Areas/Shared/Views/Partials/_OptionalButton.cshtml";

        /// <summary>
        /// Common print button partial view
        /// </summary>
        public const string PrintButton = "~/Areas/Shared/Views/Partials/_PrintButton.cshtml";

        /// <summary>
        /// Common process button partial view
        /// </summary>
        public const string ProceedButton = "~/Areas/Shared/Views/Partials/_ProceedButton.cshtml";

        /// <summary>
        /// Common addline button partial view
        /// </summary>
        public const string AddLineButton = "~/Areas/Shared/Views/Partials/_AddLineButton.cshtml";

        /// <summary>
        /// Common deleteline button partial view
        /// </summary>
        public const string DeleteLineButton = "~/Areas/Shared/Views/Partials/_DeleteLineButton.cshtml";

        /// <summary>
        /// The grid actions partial view
        /// </summary>
        public const string GridActions = "~/Areas/Shared/Views/Shared/_GridActions.cshtml";

        /// <summary>
        /// Common generic button partial view
        /// </summary>
        public const string GenericButton = "~/Areas/Shared/Views/Partials/_GenericButton.cshtml";

        /// <summary>
        /// Localized Layout
        /// </summary>
        public const string LocalizedLayout = "~/Areas/Shared/Views/Shared/_LocalizedLayout.cshtml";
        
        /// <summary>
        /// Localized Layout for R2 Screens
        /// </summary>
        public const string LocalizedLayoutR2 = "~/Areas/Shared/Views/Shared/_LocalizedLayoutR2.cshtml";

        /// <summary>
        /// Localized Layout for R3 Screens
        /// </summary>
        public const string LocalizedLayoutR3 = "~/Areas/Shared/Views/Shared/_LocalizedLayoutR3.cshtml";

        #region Portal Constants

        /// <summary>
        /// Portal Layout
        /// </summary>
        public const string PortalLayout = "~/Views/Shared/_Layout.cshtml";

        /// <summary>
        /// The generic page layout (only header and footer)
        /// </summary>
        public const string GenericLayout = "~/Views/Shared/_GenericLayout.cshtml";

        /// <summary>
        /// Portal Menu
        /// </summary>
        public const string PortalMenu = "~/Views/Partials/_MenuUrl.cshtml";

        /// <summary>
        /// Portal Add Widget 
        /// </summary>
        public const string PortalAddWidget = "~/Views/Partials/_WidgetUrl.cshtml";

        /// <summary>
        /// Portal Widget Display
        /// </summary>
        public const string PortalWidget = "~/Views/Partials/_Widget.cshtml";

        /// <summary>
        /// Feature Tour
        /// </summary>
        public const string FeatureTour = "~/Views/Partials/_FeatureTour.cshtml";

        /// <summary>
        /// Default Help of portal
        /// </summary>
        public const string DefaultHelp = "~/Views/Partials/_HomePageHelp.cshtml";

        /// <summary>
        /// Menu Help for each screen-wise
        /// </summary>
        public const string MenuHelp = "~/Views/Partials/_MenuHelp.cshtml";

        /// <summary>
        /// Common Layout for Portal
        /// </summary>
        public const string CommonPortalLayout = "~/Views/Partials/_CommonLayout.cshtml";

        /// <summary>
        /// Portal Footer
        /// </summary>
        public const string PortalFooter = "~/Views/Partials/_Footer.cshtml";

        /// <summary>
        /// New Tenant Setup
        /// </summary>
        public const string NewTenantSetup = "~/Areas/Core/Views/NewTenant/Partials/_NewTenantSetup.cshtml";

        /// <summary>
        /// New Tenant Setup Localization
        /// </summary>
        public const string NewTenantSetupLocalization = "~/Areas/Core/Views/NewTenant/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// Shared Localization
        /// </summary>
        public const string SharedLocalization = "~/Areas/Shared/Views/Shared/_Localization.cshtml";

        /// <summary>
        /// Core Localization
        /// </summary>
        public const string CoreLocalization = "~/Areas/Core/Views/Shared/_Localization.cshtml";

        /// <summary>
        /// Shared GL Transaction Report Partial
        /// </summary>
        public const string GLTransactionReport = "~/Areas/Shared/Views/Report/GLTransaction/_GLSubledgerTransactionReport.cshtml";

        /// <summary>
        /// Shared DocumentHistoryGrid
        /// </summary>
        public const string DocumentHistoryGrid = "~/Areas/Shared/Views/DocumentHistory/DocumentHistory.cshtml";


        /// <summary>
        /// Shared DocumentHistoryGrid
        /// </summary>
        public const string DocumentHistoryLocalization = "~/Areas/Shared/Views/DocumentHistory/_Localization.cshtml";


        /// <summary>
        /// Shared DocumentHistoryGrid
        /// </summary>
        public const string TaxesLocalization = "~/Areas/Shared/Views/TaxesGrid/_Localization.cshtml";
        /// <summary>
        /// Shared DocumentHistoryGrid
        /// </summary>
        public const string TaxesGrid = "~/Areas/Shared/Views/TaxesGrid/TaxesGrid.cshtml";


        /// <summary>
        /// Shared SalesSplit
        /// </summary>
        public const string SalesSplitLocalization = "~/Areas/Shared/Views/SalesSplitGrid/_Localization.cshtml";
        /// <summary>
        /// Shared SalesSplit
        /// </summary>
        public const string SalesSplitGrid = "~/Areas/Shared/Views/SalesSplitGrid/_SalesSplitGrid.cshtml";

        /// <summary>
        /// Shared Item Quantity Grid Localization
        /// </summary>
        public const string QuantityGridLocalization = "~/Areas/Shared/Views/QuantityGrid/_Localization.cshtml";
        /// <summary>
        /// Shared Item Quantity Grid
        /// </summary>
        public const string QuantityGrid = "~/Areas/Shared/Views/QuantityGrid/_QuantityGrid.cshtml";
        
    }
}