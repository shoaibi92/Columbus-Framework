/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base
{
    /// <summary>
    /// Interface ICommonRepository
    /// </summary>
    public interface ICommonRepository : IRepository, IDisposable
    {
        /// <summary>
        /// Gets the list of companies
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        List<Organization> GetCompanies(Context context);

        /// <summary>
        /// Gets the Currency
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>Currency.</returns>
        Currency GetCurrency(string currencyCode);

        /// <summary>
        /// Checks for license
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appVersion"></param>
        /// <returns></returns>
        bool CheckLicense(string appId, string appVersion);

        /// <summary>
        ///  Unlocks the Application for specific module. 
        /// </summary>
        void UnlockApplication(string applicationId);

        /// <summary>
        ///  Unlocks the Application for default module. 
        /// </summary>
        void UnlockApplication();

        /// <summary>
        ///  Unlocks an organization's data that was previously locked. 
        /// </summary>
        void UnlockOrg();

        /// <summary>
        /// Save the User Preference.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>True if saved else false</returns>
        bool SaveUserPreference(string key, string value);

        /// <summary>
        /// Get the User Preferences.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        string GetUserPreference(string key);

        /// <summary>
        /// Delete the User Preference.
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>True if deleted else false</returns>
        bool DeleteUserPreference(string key);

        /// <summary>
        /// Get installed reports for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <returns>Installed Reports</returns>
        List<string> GetInstalledReportForActiveApplication(string key);

        /// <summary>
        /// Get installed reports by application Id for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <param name="applicationId">Application Id</param>
        /// <returns>Installed Reports</returns>
        List<string> GetInstalledReportForActiveApplication(string key, string applicationId);

        /// <summary>
        /// Get the Fiscal Calendar
        /// </summary>
        /// <returns>Returns an object of type <see cref="FiscalCalendar" /></returns>
        FiscalCalendar GetFiscalCalendar();

        /// <summary>
        /// Has access rights
        /// </summary>
        /// <returns>UserAccess</returns>
        bool HasAccess(string resourceId);

        /// <summary>
        /// Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="exclusive"></param>
        MultiUserStatus LockRsc(string resource, bool exclusive);

        /// <summary>
        /// Un Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        MultiUserStatus UnLockRsc(string resource);

        /// <summary>
        /// Method to get Period from Session Date
        /// </summary>
        /// <returns>Returns PeriodInfo from IBusinessEntity object</returns>
        PeriodInfo GetPeriodFromDate();

        /// <summary>
        /// Method to verify Session Date
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        SessionDateWarning VerifySessionDate();

        /// <summary>
        /// Method to get user's language information
        /// </summary>
        /// <returns>language code (ENG for english)</returns>
        string GetUserLanguage();

        /// <summary>
        ///  Determines if the currency and the specified currency code belong in the same currency block, both as members, or one as a member and the other as its master.
        /// </summary>
        /// <param name="currency">Currency code </param>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="date">Date</param>
        /// <param name="blockDateMatch">Block Date Match</param>
        /// <returns>true/false</returns>
        bool IsBlockCombinationWith(string currency, string currencyCode, DateTime date, int blockDateMatch);
		
		/// Gets active applications
        /// </summary>
        /// <returns>list of active applcations</returns>
        List<ActiveApplication> GetActiveApplications();
    }
}