/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using System;
using System.Collections.Generic;
using Organization = Sage.CA.SBS.ERP.Sage300.Common.Models.Organization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
{
    /// <summary>
    /// Class that implements PseudoBusinessEntitySession
    /// </summary>
    public class PseudoBusinessEntitySession : IBusinessEntitySession
    {
        /// <summary>
        /// Dictionary of views
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private IDictionary<string, IBusinessEntity> _views = new Dictionary<string, IBusinessEntity>();

        /// <summary>
        /// To know if session is open
        /// </summary>
        /// <returns>Returns true if session is open</returns>
        public bool IsSessionOpen()
        {
            return true;
        }

        /// <summary>
        /// Clear Errors
        /// </summary>
        public void ClearErrors()
        {
        }

        /// <summary>
        /// Verify Session Date
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        public SessionDateWarning VerifySessionDate()
        {
            return null;
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="entitySessionntity">Current Session</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns>IBusinessEntity.</returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession entitySessionntity, bool isReadOnly)
        {
            return OpenView(name, entitySessionntity, false, "TEST", null, isReadOnly);
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="entitySessionntity">Current Session</param>
        /// <param name="consumingRepositoryName"></param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">View Is ReadOnly</param>
        /// <returns>IBusinessEntity.</returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession entitySessionntity,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            return OpenView(name, entitySessionntity, false, consumingRepositoryName, context, isReadOnly);
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="entitySessionntity">Current Session</param>
        /// <param name="extra">extra</param>
        /// <param name="consumingRepositoryName"></param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns>IBusinessEntity.</returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession entitySessionntity, object extra,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            return OpenView(name, entitySessionntity, false, consumingRepositoryName, context, isReadOnly);
        }

        /// <summary>
        /// This method doesn't do anything.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="consumingRepositoryName"></param>
        /// <param name="isReadOnly">View Is ReadOnly</param>
        public void RemoveViewFromCache(string name, string consumingRepositoryName, bool isReadOnly)
        {
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="entitySessionntity">Current Session</param>
        /// <param name="maintainState">if set to <c>true</c> [maintain state].</param>
        /// <param name="consumingRepositoryName"></param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">Open view read only mode</param>
        /// <returns>IBusinessEntity.</returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession entitySessionntity, bool maintainState,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            IBusinessEntity view;
            if (_views.ContainsKey(name))
            {
                view = _views[name];
            }
            else
            {
                view = new PseudoBusinessEntity(this, name, context);
                _views[name] = view;
            }
            return view;
        }

        /// <summary>
        /// Get the details for Home Currency
        /// </summary>
        /// <value>The home currency.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <returns></returns>
        public string HomeCurrency
        {
            get { return "INR"; }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }

        /// <summary>
        /// Get the details for Home Currency
        /// </summary>
        /// <value>The reporting currency.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <returns></returns>
        public string ReportingCurrency
        {
            get { return "INR"; }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }

        /// <summary>
        /// Gets the Company Name
        /// </summary>
        /// <value>The name of the company.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public string CompanyName
        {
            get { return "SAMINC"; }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }

        /// <summary>
        /// Gets the Company
        /// </summary>
        public Models.Company Company
        {
            get { return new Models.Company(); }
        }

        /// <summary>
        /// Whether the company is multicurrency or not
        /// </summary>
        /// <value><c>true</c> if this instance is multi currency; otherwise, <c>false</c>.</value>
        /// <returns></returns>
        public bool IsMultiCurrency
        {
            get { return true; }
        }

        /// <summary>
        /// Gets Currency details
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>Currency</returns>
        public Models.Currency GetCurrency(string currencyCode)
        {
            Models.Currency currency = new Models.Currency();
            currency.Code = "USD";
            currency.Description = "US Dollars";
            return currency;
        }

        /// <summary>
        /// Gets RateType Description
        /// </summary>
        /// <param name="rateType">Rate Type</param>
        /// <returns>String that describes rate type</returns>
        public string GetRateTypeDescription(string rateType)
        {
            return "DAILYSPOTRATE";
        }

        /// <summary>
        /// Gets FiscalPeriod
        /// </summary>
        /// <returns>FiscalPeriod</returns>
        public FiscalPeriod GetFiscalPeriod()
        {
            var fiscalPeriod = new FiscalPeriod();
            fiscalPeriod.Year = "2013";
            fiscalPeriod.Period = 12;
            return fiscalPeriod;
        }

        /// <summary>
        /// Get the Period Info
        /// </summary>
        /// <param name="year"></param>
        /// <param name="period"></param>
        /// <param name="pInfo"></param>
        /// <param name="appIdentifier">Application Identifier</param>
        /// <returns> bool </returns>
        public bool GetPeriodInfo(string year, short period, out PeriodInfo pInfo, string appIdentifier)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets and sets Session
        /// </summary>
        /// <value>The session.</value>
        public Session Session { get; set; }

        /// <summary>
        /// Method to dispose
        /// </summary>
        public void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }

        /// <summary>
        /// Disposes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose(Context context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Report
        /// </summary>
        /// <param name="reportName">Name of the report</param>
        /// <param name="programId">Program Id</param>
        /// <param name="menuId">Menu Id</param>
        /// <returns>Report.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Report SelectReport(string reportName, string programId, string menuId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets and sets list of errors
        /// </summary>
        /// <value>The errors.</value>
        public List<EntityError> Errors { get { return new List<EntityError>(); } }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public string Token
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public Guid Key
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the last used date time.
        /// </summary>
        /// <value>The last used date time.</value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public DateTime LastUsedDateTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets or sets the return to pool.
        /// </summary>
        /// <value>The return to pool.</value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public Action<Interfaces.Utilities.IPool> ReturnToPool
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is in use.
        /// </summary>
        /// <value><c>true</c> if this instance is in use; otherwise, <c>false</c>.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsInUse
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Releases the resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ReleaseResources()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <returns>IBusinessEntitySession.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IBusinessEntitySession InitializeSession(Context context, DBLinkType dbLinkType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates license and returns true if license is valid
        /// </summary>
        /// <param name="appId">application id</param>
        /// <param name="appVersion">application version</param>
        /// <returns>True if license is ok else false</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsLicenseOk(string appId, string appVersion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Progress Meter from the session
        /// </summary>
        /// <returns>Progressmeter object</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ProgressMeter GetMeter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel the current session progress
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CancelMeter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if user is admin or not
        /// </summary>
        /// <value><c>true</c> if this instance is admin; otherwise, <c>false</c>.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsAdmin
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the logged in Session date
        /// </summary>
        /// <returns>DateTime.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public DateTime SessionDate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the values of the specified field IDs (array of field IDs) from the first record of the specified view. 
        /// </summary>
        /// <param name="viewID"></param>
        /// <param name="fieldIDs"></param>
        /// <returns>The values are returned as an array with positions corresponding to the FieldIDs array.</returns>
        public object[] ParamGet(string viewID, int[] fieldIDs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the Period From Date
        /// </summary>
        /// <returns>Year of the Period From Date</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PeriodInfo GetPeriodFromDate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the list of installed companies
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>List&lt;Organization&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Organization> GetCompanies(Context context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// PaperSize for reports
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int PaperSize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the Fiscal Calendar
        /// </summary>
        /// <returns>Models.FiscalCalendar.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Models.FiscalCalendar GetFiscalCalendar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Company Session Warning Days
        /// </summary>
        /// <value>The session warn days.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public short SessionWarnDays
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets list of active applications
        /// </summary>
        /// <returns>List&lt;Models.ActiveApplication&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Models.ActiveApplication> GetActiveApplications()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Security Check for a resource
        /// </summary>
        /// <param name="resourceId">Resource Id</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool SecurityCheck(string resourceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="userPreferenceData"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveUserPreference(string viewName, string userPreferenceData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetUserPreference(string viewName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the user preference
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public bool DeleteUserPreference(string viewName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Company Id
        /// </summary>
        public string CompanyId
        {
            get { return "SAMLTD"; }
        }

        /// <summary>
        /// Transaction Begin
        /// </summary>
        /// <returns></returns>
        public int TransactionBegin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transaction Commit
        /// </summary>
        /// <returns></returns>
        public int TransactionCommit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transaction Rollback
        /// </summary>
        /// <returns></returns>
        public int TransactionRollback()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Get Year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>model Years </returns>
        public Years GetYear(string year)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Checks if the session date is present in  fiscal calendar
        /// </summary>
        /// <returns></returns>
        public bool StatusSessionDateInFiscal
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// This is not implemented
        /// </summary>
        public void UnlockOrg()
        {
            //Don't do anything
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<string> GetInstalledReportForActiveApplication(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public List<string> GetInstalledReportForActiveApplication(string key, string applicationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unlocks the Application for specific module.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UnlockApplication(string applicationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unlocks the Application for default module.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UnlockApplication()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsApplicationUnlocked
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOrgUnlocked
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Checks if the company phone format is set
        /// </summary>
        /// <value>true/false</value>
        /// <returns></returns>
        public bool IsPhoneFormat
        {
            get { return true; }
        }

        /// <summary>
        /// Retrieves the composite rate between the given source and home currencies. 
        /// If the currencies are non-block currencies, the call functions the same as GetCurrencyRate.
        /// </summary>
        /// <param name="homeCurrencyCode">String param for Home Currency Code</param>
        /// <param name="defaultRateType">String param for Rate type</param>
        /// <param name="sourceCurrencyCode">String param for Source Currency Code </param>
        /// <param name="sessionDate">Accpac Session Date</param>
        /// <returns>Returns the corresponding Accpac Currency Rate object.</returns>
        public CompositeCurrencyRate GetCurrencyRateComposite(string homeCurrencyCode, string defaultRateType, string sourceCurrencyCode, DateTime sessionDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the CurrencyTableDetail object corresponding to the specified parameter values
        /// </summary>
        /// <param name="currencyCode">String param for Currency Code</param>
        /// <param name="rateType">String param for Rate type</param>
        /// <returns>Returns the Currency Table object corresponding to the specified parameter values</returns>
        public CurrencyTableDetail GetCurrencyTable(string currencyCode, string rateType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="exclusiveapplicationId"></param>
        public MultiUserStatus LockRsc(string resource, bool exclusiveapplicationId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Un Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        public MultiUserStatus UnLockRsc(string resource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indicates how to handle locked fiscal periods for selected company
        /// </summary>
        public CompanyHandleLockedFiscalPeriods HandleLockedFiscalPeriods
        {
            get { return CompanyHandleLockedFiscalPeriods.Error; }
        }

        /// <summary>
        /// Returns the object key passed in by the caller application.
        /// </summary>
        /// <returns>Returns String</returns>
        public string GetObjectKey()
        {
            return string.Empty;
        }

        /// <summary>
        /// Returns the user's language information 
        /// </summary>
        public string UserLanguage
        {
            get { return "ENG"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetPeriodFromDate(string appId, DateTime sessionDate)
        {
            throw new NotImplementedException();
        }


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
        public bool DatesFromPeriod(short period, Period periodType, short periodLength, DateTime baseDate,
            out DateTime startDate, out DateTime endDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if home currency exits in currency table or no
        /// </summary>
        /// <returns></returns>
        public bool CheckHomeCurrency()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Products the series.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public ProductSeries ProductSeries
        {
            get { return ACCPAC.Advantage.ProductSeries.Enterprise; }
        }

        /// <summary>
        ///  Determines if the currency and the specified currency code belong in the same currency block, both as members, or one as a member and the other as its master.
        /// </summary>
        /// <param name="currency">Currency code </param>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="date">Date</param>
        /// <param name="blockDateMatch">Block Date Match</param>
        /// <returns>true/false</returns>
        public bool IsBlockCombinationWith(string currency, string currencyCode, DateTime date, int blockDateMatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Application ID
        /// </summary>
        public string GetApplicationID
        {
            get { throw new NotImplementedException(); }
        }

    }
}