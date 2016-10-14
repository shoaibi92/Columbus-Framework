/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using System;
using System.Collections.Generic;
using Currency = Sage.CA.SBS.ERP.Sage300.Common.Models.Currency;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity
{
    /// <summary>
    /// Interface for Business Entity Session
    /// </summary>
    public interface IBusinessEntitySession : IDisposable
    {
        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        /// <returns>Business Entity</returns>
        IBusinessEntity OpenView(string name, IBusinessEntitySession session,
            string consumingRepositoryName, Context context, bool isReadonly);

        /// <summary>
        /// Open View using Open Extra Object
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="extra">Current Session</param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        /// <returns>Business Entity</returns>
        IBusinessEntity OpenView(string name, IBusinessEntitySession session, object extra,
            string consumingRepositoryName, Context context, bool isReadonly);

        /// <summary>
        /// Opens View 
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="maintainState">If true cancel will not be called until disposed else it will be called whenever this method is called</param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        /// <returns>Business Entity</returns>
        IBusinessEntity OpenView(string name, IBusinessEntitySession session, bool maintainState,
            string consumingRepositoryName, Context context, bool isReadonly);

        /// <summary>
        /// Opens View 
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        /// <returns>Business Entity</returns>
        IBusinessEntity OpenView(string name, IBusinessEntitySession session, bool isReadonly);

        /// <summary>
        /// Removes the view from cache
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="consumingRepositoryName">Repository Name</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        void RemoveViewFromCache(string name, string consumingRepositoryName, bool isReadonly);

        /// <summary>
        /// Gets Home currency
        /// </summary>
        /// <value>The home currency.</value>
        string HomeCurrency { get; }

        /// <summary>
        /// Get Reporting Currency
        /// </summary>
        /// <value>The reporting currency.</value>
        string ReportingCurrency { get; }

        /// <summary>
        /// Gets Company Name
        /// </summary>
        /// <value>The name of the company.</value>
        string CompanyName { get; }

        /// <summary>
        /// Gets the Company
        /// </summary>
        Models.Company Company { get; }

        /// <summary>
        /// Gets Company ID
        /// </summary>
        /// <value>The id of the company.</value>
        string CompanyId { get; }

        /// <summary>
        /// Check if user is admin or not
        /// </summary>
        /// <value><c>true</c> if this instance is admin; otherwise, <c>false</c>.</value>
        bool IsAdmin { get; }

        /// <summary>
        /// Gets if IsMultiCurrency true
        /// </summary>
        /// <value><c>true</c> if this instance is multi currency; otherwise, <c>false</c>.</value>
        bool IsMultiCurrency { get; }

        /// <summary>
        /// true, if Session.UnlockApplication is called
        /// </summary>
        bool IsApplicationUnlocked { get; }

        /// <summary>
        /// true, if Session.UnlockOrg is called
        /// </summary>
        bool IsOrgUnlocked { get; }

        /// <summary>
        /// Gets Company Session Warning Days
        /// </summary>
        /// <value>The session warn days.</value>
        short SessionWarnDays { get; }

        /// <summary>
        /// Gets Currency details
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>Currency</returns>
        Currency GetCurrency(string currencyCode);

        /// <summary>
        /// Gets list of errors
        /// </summary>
        /// <value>The errors.</value>
        List<EntityError> Errors { get; }

        /// <summary>
        /// Gets RateType Description
        /// </summary>
        /// <param name="rateType">Rate Type</param>
        /// <returns>String that describes rate type</returns>
        string GetRateTypeDescription(string rateType);

        /// <summary>
        /// Gets FiscalPeriod
        /// </summary>
        /// <returns>FiscalPeriod</returns>
        FiscalPeriod GetFiscalPeriod();

        /// <summary>
        /// To know if session is opened
        /// </summary>
        /// <returns><c>true</c> if [is session open]; otherwise, <c>false</c>.</returns>
        bool IsSessionOpen();

        /// <summary>
        /// Clear Session Errors
        /// </summary>
        void ClearErrors();

        /// <summary>
        /// Report
        /// </summary>
        /// <param name="reportName">Name of the report</param>
        /// <param name="programId">Program Id</param>
        /// <param name="menuId">Menu Id</param>
        /// <returns>Report.</returns>
        Report SelectReport(string reportName, string programId, string menuId);

        /// <summary>
        /// Validates license and returns true if license is valid
        /// </summary>
        /// <param name="appId">application id</param>
        /// <param name="appVersion">application version</param>
        /// <returns>True if license is ok else false</returns>
        bool IsLicenseOk(string appId, string appVersion);

        /// <summary>
        /// Get Progress Meter from the session
        /// </summary>
        /// <returns>Progressmeter object</returns>
        ProgressMeter GetMeter();

        /// <summary>
        /// Cancel the current session progress
        /// </summary>
        void CancelMeter();

        /// <summary>
        /// PaperSize for reports
        /// </summary>
        /// <returns>System.Int32.</returns>
        int PaperSize();

        /// <summary>
        /// Gets the logged in Session date
        /// </summary>
        /// <returns>DateTime.</returns>
        DateTime SessionDate();

        /// <summary>
        /// Get the Period From Date
        /// </summary>
        /// <returns>Year of the Period From Date</returns>
        PeriodInfo GetPeriodFromDate();

        /// <summary>
        /// Verify if the session date is valid
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        SessionDateWarning VerifySessionDate();

        /// <summary>
        /// Gets the fiscal
        /// </summary>
        /// <returns>Models.FiscalCalendar.</returns>
        Models.FiscalCalendar GetFiscalCalendar();

        /// <summary>
        /// Gets the values of the specified field IDs (array of field IDs) from the first record of the specified view.
        /// </summary>
        /// <param name="viewID"></param>
        /// <param name="fieldIDs"></param>
        /// <returns>The values are returned as an array with positions corresponding to the FieldIDs array.</returns>
        object[] ParamGet(string viewID, int[] fieldIDs);

        /// <summary>
        /// Get the Period Info
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="period">Period</param>
        /// <param name="pInfo">pInfo</param>
        ///  <param name="appIdentifier">Application Identifier</param>
        /// <returns> bool </returns>
        bool GetPeriodInfo(string year, short period, out PeriodInfo pInfo, string appIdentifier);

        /// <summary>
        /// Gets the list of Active Applications
        /// </summary>
        /// <returns>List&lt;Models.ActiveApplication&gt;.</returns>
        List<Models.ActiveApplication> GetActiveApplications();

        /// <summary>
        /// Security Check for a resource
        /// </summary>
        /// <param name="resourceId">Resource Id</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SecurityCheck(string resourceId);

        /// <summary>
        /// Saves the User Preference to database
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <param name="userPreferenceData">Data to be saved - Cannot exceed 3KB</param>
        /// <returns>True if save is successful, else False</returns>
        bool SaveUserPreference(string viewName, string userPreferenceData);

        /// <summary>
        /// Deletes the User Preference to database
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <returns>True if save is successful, else False</returns>
        bool DeleteUserPreference(string viewName);

        /// <summary>
        /// Gets the preference of the user
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <returns>Data preference saved for the user</returns>
        string GetUserPreference(string viewName);


        /// <summary>
        /// Begins a transaction on the current DB Link
        /// </summary>
        /// <returns></returns>
        int TransactionBegin();

        /// <summary>
        /// Commits the transaction on the current DB Link
        /// </summary>
        /// <returns></returns>
        int TransactionCommit();

        /// <summary>
        /// Rollback the transaction on the current DB Link
        /// </summary>
        /// <returns></returns>
        int TransactionRollback();

        /// <summary>
        ///  Get Year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>model Years </returns>
        Years GetYear(string year);

        /// <summary>
        ///  Checks if the session date is present in  fiscal calendar
        /// </summary>
        /// <returns></returns>
        bool StatusSessionDateInFiscal { get; }

        /// <summary>
        ///  Unlocks the Application for specific module. 
        /// </summary>
        void UnlockApplication(string applicationId);

        /// <summary>
        ///  Unlocks the Application for default module. 
        /// </summary>
        void UnlockApplication();

        /// <summary>
        ///  LockRsc
        /// </summary>
        MultiUserStatus LockRsc(string resource, bool exclusiveapplicationId);

        /// <summary>
        ///  Un LockRsc
        /// </summary>
        MultiUserStatus UnLockRsc(string resource);

        /// <summary>
        /// Unlocks an organization's data that was previously locked. 
        /// </summary>
        void UnlockOrg();

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
        /// Checks if the company phone format is set
        /// </summary>
        ///<value>true/false</value>
        bool IsPhoneFormat { get; }

        /// <summary>
        /// Retrieves the composite rate between the given source and home currencies. 
        /// If the currencies are non-block currencies, the call functions the same as GetCurrencyRate.
        /// </summary>
        /// <param name="homeCurrencyCode">String param for Home Currency Code</param>
        /// <param name="rateType">String param for Rate type</param>
        /// <param name="sourceCurrencyCode">String param for Source Currency Code </param>
        /// <param name="sessionDate">Accpac Session Date</param>
        /// <returns>Returns the corresponding Currency Rate object.</returns>
        CompositeCurrencyRate GetCurrencyRateComposite(string homeCurrencyCode, string rateType, string sourceCurrencyCode, DateTime sessionDate);

        /// <summary>
        /// Returns the CurrencyTableDetail object corresponding to the specified parameter values
        /// </summary>
        /// <param name="currencyCode">String param for Currency Code</param>
        /// <param name="rateType">String param for Rate type</param>
        /// <returns>Returns the Currency Table object corresponding to the specified parameter values</returns>
        CurrencyTableDetail GetCurrencyTable(string currencyCode, string rateType);

        /// <summary>
        /// Indicates how to handle locked fiscal periods for selected company
        /// </summary>
        CompanyHandleLockedFiscalPeriods HandleLockedFiscalPeriods { get; }

        /// <summary>
        /// Returns the object key passed in by the caller application.
        /// </summary>
        /// <returns>Returns String</returns>
        string GetObjectKey();

        /// <summary>
        /// Get user's language information
        /// </summary>
        /// <returns>language code (ENG for english)</returns>
        string UserLanguage { get; }

        /// <summary>
        /// Check for session date
        /// </summary>
        /// <param name="appId">Application Id/Program Name</param>
        /// <param name="sessionDate">Session Date</param>
        /// <returns></returns>
        bool GetPeriodFromDate(string appId, DateTime sessionDate);

        /// <summary>
        /// Calculates the period start and end dates, given a period number, period type, period length and base date. 
        /// </summary>                
        /// <param name="period">Period</param>
        /// <param name="periodType">Fiscal Period Type</param>
        /// <param name="periodLength">Period Length</param>
        /// <param name="baseDate">Base Date</param>
        /// <param name="startDate">Fiscal Start Date</param>
        /// <param name="endDate">Fiscal End Date</param>
        /// <returns>Returns whether or not the start and end dates were successfully determined.</returns>
        bool DatesFromPeriod(short period, Period periodType, short periodLength, DateTime baseDate, out DateTime startDate, out DateTime endDate);

        /// <summary>
        /// Check if home currency exits in currency table or no
        /// </summary>
        /// <returns></returns>
        bool CheckHomeCurrency();

        /// <summary>
        /// Products the series.
        /// </summary>
        /// <returns></returns>
        ProductSeries ProductSeries { get; }

        /// <summary>
        ///  Determines if the currency and the specified currency code belong in the same currency block, both as members, or one as a member and the other as its master.
        /// </summary>
        /// <param name="currency">Currency code </param>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="date">Date</param>
        /// <param name="blockDateMatch">Block Date Match</param>
        /// <returns>true/false</returns>
        bool IsBlockCombinationWith(string currency, string currencyCode, DateTime date, int blockDateMatch);

        /// <summary>
        /// Get Application ID
        /// </summary>
        string GetApplicationID { get; }
    }
}