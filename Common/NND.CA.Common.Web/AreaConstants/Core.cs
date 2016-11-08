// Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. 

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Menu Options
    /// </summary>
    public static class OptionsMenu
    {
        /// <summary>
        /// For Import
        /// </summary>
        public const string Import = "import";
        /// <summary>
        /// For Export
        /// </summary>
        public const string Export = "export";
    }

    /// <summary>
    /// Core - Area constants
    /// </summary>
    public static class Core
    {
        /// <summary>
        /// Layout
        /// </summary>
        public const string Menu = "~/Areas/Core/Views/Shared/_Menu.cshtml";

        /// <summary>
        /// Layout R3
        /// </summary>
        public const string OptionsMenu = "~/Areas/Core/Views/Shared/_OptionsMenu.cshtml";

        /// <summary>
        /// Option menu with disable check
        /// </summary>
        public const string OptionsMenuDisableCheck = "~/Areas/Core/Views/Shared/_OptionsMenuDisableCheck.cshtml";

        /// <summary>
        /// Layout
        /// </summary>
        public const string ReportOptions = "~/Areas/Core/Views/Shared/_ReportOptions.cshtml";

        /// <summary>
        /// Layout
        /// </summary>
        public const string Error = "~/Areas/Core/Views/Error/Index.cshtml";

        /// <summary>
        /// Processing status layout
        /// </summary>
        public const string ProcessingStatus = "~/Areas/Core/Views/Shared/_ProcessingStatus.cshtml";

        /// <summary>
        /// Grid Preferences
        /// </summary>
        public const string GridPreferences = "~/Areas/Core/Views/Shared/GridPreferences.cshtml";

        /// <summary>
        /// Finder Preferences
        /// </summary>
        public const string FinderPreferences = "~/Areas/Core/Views/Find/FindPreference.cshtml";

        /// <summary>
        /// Fiscal Calendar
        /// </summary>
        public const string FiscalCalendar = "~/Areas/Core/Views/Shared/FiscalCalendar.cshtml";

        /// <summary>
        /// The core bundle
        /// </summary>
        public const string CoreBundle = "~/bundles/core";

        /// <summary>
        /// Hamburger Menu
        /// </summary>
        public const string HamburgerMenu = "~/Areas/Core/Views/Shared/LabelMenuPopup.cshtml";

        /// <summary>
        /// The wizard
        /// </summary>
        public const string Wizard = "~/Areas/Core/Views/Wizard/_Wizard.cshtml";

        /// <summary>
        /// Authentication On Premise Login view
        /// </summary>
        public const string OnPremiseLoginView = "~/Areas/Core/Views/Authentication/OnPremiseLogin.cshtml";

        /// <summary>
        /// Authentication On Premise Login
        /// </summary>
        public const string OnPremiseLogin = "~/Areas/Core/Views/Authentication/Partials/_OnPremiseLogin.cshtml";

        /// <summary>
        /// Authentication On Premise Login bundle
        /// </summary>
        public const string OnPremiseLoginBundle = "~/bundles/OnPremiseLogin";

        /// <summary>
        /// On Premise Tenant Alias
        /// </summary>
        public const string OnPremiseTenantAlias = "OnPremise";

        /// <summary>
        /// On Premise Product user Id
        /// </summary>
        public const string OnPremiseProductUserId = "0b201abe-df66-48a4-9643-e84b89da950b";

        /// <summary>
        /// Authentication On Localization
        /// </summary>
        public const string OnPremiseLocalization = "~/Areas/Core/Views/Authentication/Partials/_Localization.cshtml";

        #region GLIntegration
        /// <summary>
        /// GLIntegration Transactions Options
        /// </summary>
        public const string GLIntegrationTransactionsOptions = "~/Areas/Core/Views/GLIntegration/Partials/_TransactionsOptions.cshtml";

        /// <summary>
        /// GLIntegration Posting Sequence
        /// </summary>
        public const string GLIntegrationPostingSequence = "~/Areas/Core/Views/GLIntegration/Partials/_GLPostingSequence.cshtml";

        /// <summary>
        /// GLIntegration Source Code
        /// </summary>
        public const string GLIntegrationSourceCode = "~/Areas/Core/Views/GLIntegration/Partials/_GLSourceCodes.cshtml";

        /// <summary>
        /// GLIntegration ReferenceIntegration 
        /// </summary>
        public const string GLReferenceIntegration = "~/Areas/Core/Views/GLIntegration/Partials/_GLReferenceIntegration.cshtml";

        /// <summary>
        /// GLIntegration Detail - popupWindow
        /// </summary>
        public const string GLIntegrationDetail = "~/Areas/Core/Views/GLIntegration/Partials/_GLIntegrationDetail.cshtml";
        /// <summary>
        /// Optional Fields
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/Core/Views/OptionalFields/_Localization.cshtml";

        /// <summary>
        /// The layout
        /// </summary>
        public const string OptionalFields = "~/Areas/Core/Views/OptionalFields/OptionalFields.cshtml";

        #endregion
    }
}
