// Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved.

#region

using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using PropertyType = ACCPAC.Advantage.PropertyType;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Class for Business EntitySession
    /// </summary>
    public sealed class BusinessEntitySession : PooledObject, IBusinessEntitySession
    {
        #region Private Constants

        private const string ObjectHandle = "";

        /// <summary>
        /// Security resource name constants (for SecCheck)
        /// </summary>
        private const string RscAdmin = "**ADMIN**";

        private const char Dot = '.';
        private const int AppProgramName = 60000;

        #endregion

        #region Properties

        /// <summary>
        /// Dictionary of business enity
        /// </summary>
        private readonly ConcurrentDictionary<string, IBusinessEntity> _businessEntities;

        /// <summary>
        /// Used for locking - For metering
        /// </summary>
        private readonly object _syncMeter = new object();

        /// <summary>
        /// To check if object is destroyed or not
        /// </summary>
        private bool _isDestroyed;

        /// <summary>
        /// Applucation Id, can be used for lock/unlock
        /// </summary>
        private string _applicationId;

        /// <summary>
        /// true id application is unlocked
        /// </summary>
        public bool IsApplicationUnlocked { get; private set; }

        /// <summary>
        /// true, if organization is unlocked
        /// </summary>
        public bool IsOrgUnlocked { get; private set; }

        /// <summary>
        /// Container
        /// </summary>
        private IUnityContainer _container;

        /// <summary>
        /// Used for locking
        /// </summary>
        private readonly object _syncRoot = new object();

        /// <summary>
        /// DBLink Type
        /// </summary>
        public DBLinkType DbLinkType { get; private set; }

        /// <summary>
        /// Gets and sets Session
        /// </summary>
        private Session Session { get; set; }

        /// <summary>
        /// Gets and sets DbLink
        /// </summary>
        private DBLink DbLink { get; set; }

        /// <summary>
        /// Gets or sets Session
        /// </summary>
        /// <value>The session.</value>
        public IBusinessEntitySession EntitySession { get; set; }



        #endregion

        #region Constructor

        /// <summary>
        ///  TO Initialize Session 
        /// </summary>
        private BusinessEntitySession()
        {
            // Block object Creation, force use of InitializeSession to create instance of this type
            _businessEntities = new ConcurrentDictionary<string, IBusinessEntity>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get all the business entities
        /// </summary>
        /// <returns></returns>
        public ConcurrentDictionary<string, IBusinessEntity> BusinessEntities
        {
            get { return _businessEntities; }
        }


        /// <summary>
        /// Gets a list of company's for a session opened
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Models.Organization> GetCompanies(Context context)
        {
            var userTenant = GetUserTenant(context);
            var organizations = new List<Models.Organization>();
            using (var session = InitializeSession(context, Helper.ApplicationIdentifier, Helper.ProgramName, userTenant).Session)
            {

                for (var i = 0; i < session.Organizations.Count; i++)
                {
                    var organization = session.Organizations[i];
                    if (organization.Type == OrganizationType.System) continue;
                    organizations.Add(new Models.Organization
                    {
                        Id = organization.ID,
                        Name = organization.Name,
                        System = organization.Type.ToString(),
                        IsSecurityEnabled = organization.SecurityEnabled
                    });
                }
            }
            return organizations;
        }

        /// <summary>
        /// Initializes a session
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="applicationIdentifier">ApplicationName</param>
        /// <param name="programName">ProgramName</param>
        /// <returns>BusinessEntitySession</returns>
        public static BusinessEntitySession InitializeSession(Context context, DBLinkType dbLinkType,
            string applicationIdentifier = Helper.ApplicationIdentifier, string programName = Helper.ProgramName)
        {

            var userTenant = GetUserTenant(context);
            var session = InitializeSession(context, applicationIdentifier, programName, userTenant);
            session._container = context.Container;
            session.DbLinkType = dbLinkType;
            session = OpenSession(session, context, userTenant);
            session = OpenDbLink(dbLinkType, session);
            return session;
        }

        /// <summary>
        /// To know if session is opened
        /// </summary>
        /// <returns></returns>
        public bool IsSessionOpen()
        {

            return Session.IsOpened;
        }

        /// <summary>
        /// Gets the logged in Session Date
        /// TODO:This should be a property
        /// </summary>
        /// <returns>Date time</returns>
        public DateTime SessionDate()
        {
            return Session.SessionDate;
        }

        /// <summary>
        /// Gets the values of the specified field IDs (array of field IDs) from the first record of the specified view. 
        /// </summary>
        /// <param name="viewID"></param>
        /// <param name="fieldIDs"></param>
        /// <returns>The values are returned as an array with positions corresponding to the FieldIDs array.</returns>
        public object[] ParamGet(string viewID, int[] fieldIDs)
        {
            return DbLink.ParamGet(viewID, fieldIDs);
        }

        /// <summary>
        /// Get the period 
        /// </summary>
        /// <returns></returns>
        public PeriodInfo GetPeriodFromDate()
        {
            byte[] pInfoBytes;
            var fiscalCalendar = DbLink.FiscalCalendar;

            var pInfo = new PeriodInfo();
            if (fiscalCalendar.GetPeriodFromDate(Session.AppID, Session.SessionDate, out pInfoBytes))
            {
                pInfo = PeriodInfo(pInfoBytes);

                fiscalCalendar.GetPeriodInfo(Session.AppID, pInfo.Year, pInfo.FiscalPeriod, out pInfoBytes);
                pInfo = PeriodInfo(pInfoBytes);
            }
            return pInfo;
        }


        /// <summary>
        /// Check for session date
        /// </summary>
        /// <param name="appId">Application Id/Program Name</param>
        /// <param name="sessionDate">Session Date</param>
        /// <returns></returns>
        public bool GetPeriodFromDate(string appId, DateTime sessionDate)
        {
            byte[] pInfoBytes;
            var fiscalCalendar = DbLink.FiscalCalendar;
            return fiscalCalendar.GetPeriodFromDate(appId, sessionDate, out pInfoBytes);
        }

        /// <summary>
        /// Verify if the session date is in the range
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        public SessionDateWarning VerifySessionDate()
        {
            var fiscalCalendar = DbLink.FiscalCalendar;
            var warning = new SessionDateWarning();
            var company = DbLink.Company;
            short periods, qtr4Period;
            string year;
            bool periodOpen;

            //if this period exists in Fiscal Calendar
            if (fiscalCalendar.GetPeriod(Session.SessionDate, out periods, out year, out periodOpen))
            {
                bool active;

                if (fiscalCalendar.GetYear(year, out periods, out qtr4Period, out active))
                {
                    //if the year is inactive
                    if (!active)
                    {
                        warning.Message = AccountMessagesResx.SessionDateinInactiveYear;
                        warning.type = SessionDateWarningType.Inactive;
                        return warning;
                    }

                    //if the periods is locked;
                    if ((company.HandleLockedFiscalPeriods != CompanyHandleLockedFiscalPeriods.Ignore) && (periodOpen == false))
                    {
                        warning.Message = AccountMessagesResx.SessionDateinLockedPeriod;
                        warning.type = SessionDateWarningType.Locked;
                        return warning;
                    }

                    return null;
                }


            }

            warning.Message = AccountMessagesResx.SessionDateNotInCalendar;
            warning.type = SessionDateWarningType.NotInCalender;
            return warning;
        }

        /// <summary>
        /// Get the Fiscal Calendar
        /// </summary>
        /// <returns></returns>
        public Models.FiscalCalendar GetFiscalCalendar()
        {
            var fiscalCalendar = DbLink.FiscalCalendar;
            string year;
            short period;
            short quarter;
            bool isActive;

            fiscalCalendar.GetFirstYear(out year, out period, out quarter, out isActive);
            var firstYear = new Years { Year = year, Periods = period, Quarter = quarter, IsActive = isActive };

            fiscalCalendar.GetLastYear(out year, out period, out quarter, out isActive);
            var lastYear = new Years { Year = year, Periods = period, Quarter = quarter, IsActive = isActive };

            return new Models.FiscalCalendar
            {
                FirstYear = firstYear,
                LastYear = lastYear,
                IsFiscalApp = fiscalCalendar.IsFiscalApp(ProgramName, Helper.ApplicationVersion)
            };
        }

        /// <summary>
        /// Get the Period Info
        /// </summary>
        /// <param name="year"> Year</param>
        /// <param name="period">Period</param>
        /// <param name="pInfo">Period Info</param>
        /// <param name="appIdentifier">Application Identifier</param>
        /// <returns>true/false</returns>
        public bool GetPeriodInfo(string year, short period, out PeriodInfo pInfo, string appIdentifier)
        {
            byte[] pInfoBytes;
            var fiscalCalendar = DbLink.FiscalCalendar;
            var success = fiscalCalendar.GetPeriodInfo(appIdentifier, year, period, out pInfoBytes);
            //TODO : Check Return Value
            pInfo = PeriodInfo(pInfoBytes);

            return success;
        }



        /// <summary>
        /// Clear Errors
        /// </summary>
        public void ClearErrors()
        {
            Session.Errors.Clear();
        }

        /// <summary>
        /// Gets Error
        /// </summary>
        public List<EntityError> Errors
        {
            get
            {
                var errors = new List<EntityError>();

                if (Session.Errors == null)
                {
                    return errors;
                }

                for (var iIndex = 0; iIndex < Session.Errors.Count; iIndex++)
                {
                    var errorList = new EntityError
                    {
                        Message = Session.Errors[iIndex].Message,
                        Priority = (Priority)Session.Errors[iIndex].Priority
                    };
                    errors.Add(errorList);
                }
                return errors;
            }
        }

        /// <summary>
        /// Gets Currency details
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns></returns>
        public Models.Currency GetCurrency(string currencyCode)
        {
            var currency = currencyCode == null
                ? DbLink.GetCurrency(DbLink.Company.HomeCurrency)
                : DbLink.GetCurrency(currencyCode);

            return new Models.Currency
            {
                Code = currency.Code,
                Decimals = currency.Decimals,
                DecimalSeparator = currency.DecimalSeparator,
                Description = currency.Description,
                NegativeDisplay = (Models.CurrencyNegativeDisplay)currency.NegativeDisplay,
                Symbol = currency.Symbol,
                SymbolDisplay = (Models.CurrencySymbolDisplay)currency.SymbolDisplay,
                ThousandSeparator = currency.ThousandSeparator
            };
        }

        /// <summary>
        /// Get the details for Home Currency
        /// </summary>
        /// <returns></returns>
        public string HomeCurrency
        {
            get { return DbLink.Company.HomeCurrency; }
        }

        /// <summary>
        /// Get the details for Reporting Currency
        /// </summary>
        public string ReportingCurrency
        {
            get { return DbLink.Company.ReportingCurrency; }
        }

        /// <summary>
        /// Gets the Company Name
        /// </summary>
        public string CompanyName
        {
            get { return Session.CompanyName; }
        }

        /// <summary>
        /// Gets the Company
        /// </summary>
        public Models.Company Company
        {
            get
            {
                return new Models.Company
                    {
                        Address1 = DbLink.Company.Address1,
                        Address2 = DbLink.Company.Address2,
                        Address3 = DbLink.Company.Address3,
                        Address4 = DbLink.Company.Address4,
                        BranchCode = DbLink.Company.BranchCode,
                        City = DbLink.Company.City,
                        Contact = DbLink.Company.Contact,
                        Country = DbLink.Company.Country,
                        CountryCode = DbLink.Company.CountryCode,
                        EuroCurrency = DbLink.Company.EuroCurrency,
                        Fax = DbLink.Company.Fax,
                        FiscalPeriods = DbLink.Company.FiscalPeriods,
                        FourPeriodQuarter = DbLink.Company.FourPeriodQuarter,
                        GainLossAccountingMethod = (Models.Enums.CompanyGainLossAccountingMethod)DbLink.Company.GainLossAccountingMethod,
                        HandleInactiveGLAccounts = (UserMessageType)DbLink.Company.HandleInactiveGLAccounts,
                        HandleLockedFiscalPeriods = (UserMessageType)DbLink.Company.HandleLockedFiscalPeriods,
                        HandleNonexistentGLAccounts = (UserMessageType)DbLink.Company.HandleNonexistentGLAccounts,
                        HomeCurrency = DbLink.Company.HomeCurrency,
                        LegalName = DbLink.Company.LegalName,
                        LocationCode = DbLink.Company.LocationCode,
                        LocationType = DbLink.Company.LocationType,
                        Multicurrency = DbLink.Company.Multicurrency,
                        Name = DbLink.Company.Name,
                        OrgID = DbLink.Company.OrgID,
                        Phone = DbLink.Company.Phone,
                        PhoneFormat = DbLink.Company.PhoneFormat,
                        PhoneMask = DbLink.Company.PhoneMask,
                        PostCode = DbLink.Company.PostCode,
                        RateType = DbLink.Company.RateType,
                        ReportingCurrency = DbLink.Company.ReportingCurrency,
                        SessionWarnDays = DbLink.Company.SessionWarnDays,
                        State = DbLink.Company.State,
                        TaxNumber = DbLink.Company.TaxNumber
                    };
            }
        }

        /// <summary>
        /// Gets the Company Id
        /// </summary>
        public string CompanyId
        {
            get { return CommonUtil.Pad(Session.CompanyID, 6, false, ' '); }
        }

        /// <summary>
        /// Whether the company is multicurrency or not
        /// </summary>
        /// <returns></returns>
        public bool IsMultiCurrency
        {
            get { return DbLink.Company.Multicurrency; }
        }

        /// <summary>
        /// Check if user is admin or not
        /// </summary>
        public bool IsAdmin
        {
            get { return DbLink.SecCheck(RscAdmin); }
        }

        /// <summary>
        /// 
        /// </summary>
        public short SessionWarnDays
        {
            get { return DbLink.Company.SessionWarnDays; }
        }

        /// <summary>
        /// Gets RateType Description
        /// </summary>
        /// <param name="rateType">Rate Type</param>
        /// <returns></returns>
        public string GetRateTypeDescription(string rateType)
        {
            string rateTypeDescription;
            DbLink.GetCurrencyRateTypeDescription(rateType, out rateTypeDescription);
            return rateTypeDescription;
        }

        /// <summary>
        /// Security Check for a resource
        /// </summary>
        /// <param name="resourceId">Resource Id</param>
        /// <returns></returns>
        public bool SecurityCheck(string resourceId)
        {
            return IsAdmin || DbLink.SecCheck(resourceId);
        }

        /// <summary>
        /// Get zsize of the paper
        /// </summary>
        /// <returns>Size</returns>
        public int PaperSize()
        {
            const string objectId = "0";
            const string menuId = "0";
            const string keyword = "DEFAULT_RPT_SIZE";
            const string appId = "AS";
            int status;
            Session.PropertyGet(objectId, menuId, keyword, appId, Helper.ApplicationVersion, PropertyType.String, out status);
            return status;
        }

        /// <summary>
        /// ONLY REQUIRED FOR TESTING
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns></returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession session, bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadonly">If true, view will be readonly</param>
        /// <returns>Business Entity</returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession session,
           string consumingRepositoryName, Context context, bool isReadonly)
        {
            return OpenView(name, session, false, null, consumingRepositoryName, context, isReadonly);
        }

        /// <summary>
        /// Opens View using extra object
        /// This always returns a clean view i.e. cancel is always called before returning the view.
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="extra"></param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns></returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession session, object extra,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            return OpenView(name, session, false, extra, consumingRepositoryName, context, isReadOnly);
        }

        /// <summary>
        /// Opens View
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="maintainState">If true cancel will not be called until disposed else it will be called whenever this method is called</param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns></returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession session, bool maintainState,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            return OpenView(name, session, maintainState, null, consumingRepositoryName, context, isReadOnly);
        }

        /// <summary>
        /// Opens View using Open Extra Object
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="session">Current Session</param>
        /// <param name="maintainState">If true cancel will not be called until disposed else it will be called whenever this method is called</param>
        /// <param name="extra"></param>
        /// <param name="consumingRepositoryName">Name of the repository that is opening the view</param>
        /// <param name="context">Current Context</param>
        /// <param name="isReadOnly">If true, view will be readonly</param>
        /// <returns></returns>
        public IBusinessEntity OpenView(string name, IBusinessEntitySession session, bool maintainState, object extra,
            string consumingRepositoryName, Context context, bool isReadOnly)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            string key = ConstructKey(consumingRepositoryName, name, isReadOnly);
            IBusinessEntity businessEntity;

            lock (_syncRoot)
            {
                if (_businessEntities.TryGetValue(key, out businessEntity))
                {
                    if (!maintainState)
                    {
                        businessEntity.Cancel();
                    }
                    return businessEntity;
                }

                View view;

                using (new WADLogWatcher(string.Format("Open View - {0} for {1}", name, consumingRepositoryName), true)) //Added temporary to check performance
                {

                    var mode = (isReadOnly) ? ViewOpenModes.Readonly : ViewOpenModes.None;
                    view = DbLink.OpenView(name, mode, 0, ViewOpenDirectives.None, extra, null);
                }

                Trace.WriteLine(string.Format("BusinessEntitySession - View Created : {0} for {1}", name, consumingRepositoryName));
                businessEntity = _container.Resolve<IBusinessEntity>(new ParameterOverrides
                    {
                        {"session", session},
                        {"view", view},
                        {"name", name},
                        {"context", context}
                    });
                businessEntity.CreatedRepositoryName = consumingRepositoryName;

                _businessEntities.TryAdd(key, businessEntity);
            }

            return businessEntity;
        }

        /// <summary>
        /// Removes the view from cache
        /// </summary>
        /// <param name="name">Name of the view</param>
        /// <param name="consumingRepositoryName">Repository Name</param>
        /// <param name="isReadOnly">isReadOnly</param>
        public void RemoveViewFromCache(string name, string consumingRepositoryName, bool isReadOnly)
        {
            string key = ConstructKey(consumingRepositoryName, name, isReadOnly);
            IBusinessEntity businessEntity;
            lock (_syncRoot)
            {
                if (_businessEntities.TryRemove(key, out businessEntity))
                {
                    Trace.WriteLine(string.Format("BusinessEntitySession - View disposed : {0}", businessEntity.Name));
                    businessEntity.Destroy();
                }
            }
        }

        /// <summary>
        /// Gets FiscalPeriod
        /// </summary>
        /// <returns></returns>
        public FiscalPeriod GetFiscalPeriod()
        {
            short period;
            string year;
            bool periodOpen;
            //TODO:Need to check the retrun value
            DbLink.FiscalCalendar.GetPeriod(Session.SessionDate, out period, out year, out periodOpen);
            return new FiscalPeriod { Period = period, Year = year, IsPeriodOpen = periodOpen };
        }

        /// <summary>
        /// Resets the business entities
        /// </summary>
        public override void Reset()
        {
            lock (_syncRoot)
            {
                foreach (var businessEntity in _businessEntities)
                {
                    businessEntity.Value.Cancel();
                }
            }
        }

        /// <summary>
        /// Release the resources
        /// </summary>
        public override void Destroy()
        {
            Destroy(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the resources
        /// </summary>
        public void Destroy(bool disposing)
        {
            //All processing screens calls this method on a different thread so to avoid a usecase in which session is disposed at the same time 
            //while getting the meter, lock has been applied.
            lock (_syncMeter)
            {
                if (!_isDestroyed)
                {
                    if (disposing)
                    {
                        foreach (var businessEntity in _businessEntities.Values)
                        {
                            Trace.WriteLine(string.Format("BusinessEntitySession - View disposed : {0}",
                                businessEntity.Name));
                            businessEntity.Destroy();
                        }

                        _businessEntities.Clear();

                        if (DbLink != null)
                        {
                            DbLink.Dispose();
                        }

                        if (Session != null)
                        {
                            Trace.WriteLine("BusinessEntitySession - Session disposed");
                            Session.Dispose();
                        }
                    }
                    //Release unmanaged resource
                    _isDestroyed = true;
                }
            }
        }

        /// <summary>
        /// Report
        /// </summary>
        /// <param name="reportName">Name of the report</param>
        /// <param name="programId">Program Id</param>
        /// <param name="menuId">Menu Id</param>
        /// <returns></returns>
        public Report SelectReport(string reportName, string programId, string menuId)
        {
            return Session.ReportSelect(reportName, programId, menuId);
        }

        /// <summary>
        /// Validates license and returns true if license is valid
        /// </summary>
        /// <param name="appId">application id</param>
        /// <param name="appVersion">application version</param>
        /// <returns>True if license is ok else false</returns>
        public bool IsLicenseOk(string appId, string appVersion)
        {
            return Session.LicenseStatus(appId, appVersion) == LicenseStatus.OK;
        }

        /// <summary>
        /// Get Progress Meter from session
        /// </summary>
        /// <returns>ProgressMeter object</returns>
        public ProgressMeter GetMeter()
        {
            //All processing screens calls this method on a different thread so to avoid a usecase in which session is disposed at the same time 
            //while getting the meter, lock has been applied.
            lock (_syncMeter)
            {
                if (!Session.IsOpened || _isDestroyed) return null;

                var meter = Session.GetMeter();
                if (meter == null || !meter.IsRunning) return null;

                return new ProgressMeter
                {
                    Caption = meter.Caption,
                    IsRunning = true,
                    Label = meter.Label,
                    ShowCancel = meter.ShowCancel,
                    ShowGauge = meter.ShowGauge,
                    Percent = meter.Percent
                };
            }
        }

        /// <summary>
        /// Cancel the current progress
        /// </summary>
        public void CancelMeter()
        {
            //All processing screens calls this method on a different thread so to avoid a usecase in which session is disposed at the same time 
            //while getting the meter, lock has been applied.
            lock (_syncMeter)
            {
                if (!Session.IsOpened || _isDestroyed)
                {
                    return;
                }
                var meter = Session.GetMeter();
                if (meter != null)
                {
                    meter.Cancel();
                }
            }
        }

        /// <summary>
        /// Backedup property for ActiveApplication
        /// </summary>
        private List<Models.ActiveApplication> _activeApplications;

        /// <summary>
        /// ActiveApplication Property, Will be initialized only once
        /// </summary>
        public List<Models.ActiveApplication> ActiveApplications
        {
            get
            {
                if (_activeApplications == null)
                {
                    _activeApplications = InitializeActiveApplications();
                }
                return _activeApplications;
            }
        }

        /// <summary>
        /// Gets list of active applications
        /// </summary>
        /// <returns></returns>
        public List<Models.ActiveApplication> GetActiveApplications()
        {
            return ActiveApplications;
        }

        /// <summary>
        /// Saves the User Preference to database
        /// TODO : Remove the return type. This is not required.
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <param name="userPreferenceData">Data to be saved - Cannot exceed 3KB</param>
        /// <returns>True if save is successful, else False</returns>
        public bool SaveUserPreference(string viewName, string userPreferenceData)
        {
            try
            {
                int bytes = userPreferenceData.Length * sizeof(Char);
                const int maxSize = 3000;
                int splitSize = 1000;
                if (bytes < maxSize)
                {
                    splitSize = maxSize;
                }
                var splitData = Chunks(userPreferenceData, splitSize);
                var enumerable = splitData as string[] ?? splitData.ToArray();
                var numberOfChunks = enumerable.Count();
                var splitDataArray = enumerable.ToArray();
                splitDataArray[0] = numberOfChunks.ToString("00") + "|" + splitDataArray[0];

                for (int i = 0; i < numberOfChunks; i++)
                {
                    string key = viewName;
                    if (i != 0)
                    {
                        key = viewName + i;
                    }
                    DbLink.UsrPutProp(key, splitDataArray[i]);
                }
                return true;
            }
            catch (Exception exception)
            {
                //User preference issue must not block user interface. Log the issue and continue
                Logger.Error("Error in saving User Preference ", exception);
                return false;
            }
        }

        /// <summary>
        /// Deletes the User Preference to database
        /// TODO : Remove the return type. This is not required.
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <returns>True if save is successful, else False</returns>
        public bool DeleteUserPreference(string viewName)
        {
            try
            {

                string propertyValue;

                DbLink.UsrGetProp(viewName, out propertyValue);
                DbLink.UsrPutProp(viewName, string.Empty);

                var multipleChunks = propertyValue != null && propertyValue.IndexOf(@"|", StringComparison.InvariantCulture) == 2;
                if (multipleChunks)
                {
                    var splitChunks = propertyValue.Split('|');
                    var numberOfChunks = Convert.ToInt32(splitChunks[0]);
                    var userPreferenceStrings = new string[numberOfChunks];
                    userPreferenceStrings[0] = splitChunks[1];
                    for (var i = 1; i < numberOfChunks; i++)
                    {
                        DbLink.UsrPutProp(viewName + i, string.Empty);
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                //User preference issue must not block user interface. Log the issue and continue
                Logger.Error("Error in deleting User Preference ", exception);
                return false;
            }

        }

        /// <summary>
        /// Gets the preference of the user
        /// </summary>
        /// <param name="viewName">Unique name</param>
        /// <returns>Data preference saved for the user</returns>
        public string GetUserPreference(string viewName)
        {
            try
            {
                string propertyValue;
                DbLink.UsrGetProp(viewName, out propertyValue);

                var multipleChunks = propertyValue != null && propertyValue.IndexOf(@"|", StringComparison.InvariantCulture) == 2;

                if (multipleChunks)
                {
                    var splitChunks = propertyValue.Split('|');
                    int numberOfChunks = Convert.ToInt32(splitChunks[0]);
                    var userPreferenceStrings = new string[numberOfChunks];
                    userPreferenceStrings[0] = splitChunks[1];
                    for (int i = 1; i < numberOfChunks; i++)
                    {
                        DbLink.UsrGetProp(viewName + i, out userPreferenceStrings[i]);
                    }
                    return ConvertStringArrayToString(userPreferenceStrings).TrimEnd();
                }

                return propertyValue;
            }
            catch (Exception exception)
            {
                //User preference issue must not block user interface. Log the issue and continue
                Logger.Error("Error in retrieving User Preference ", exception);
                DeleteUserPreference(viewName);
                return null;
            }

        }

        /// <summary>
        /// Convert string array to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private string ConvertStringArrayToString(string[] array)
        {
            var builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value.TrimEnd());

            }
            return builder.ToString();
        }

        /// <summary>
        /// Reset Locks
        /// </summary>
        public override void ResetLocks()
        {
            LockOrg();
            LockApplication();
        }

        /// <summary>
        /// Unlock
        /// </summary>
        public override void Unlock()
        {
            UnlockOrg();
            UnlockApplication();
        }

        /// <summary>
        /// Reset Session Date
        /// </summary>
        /// <param name="sessionDate">Session Date</param>
        public override void ResetSessionDate(DateTime sessionDate)
        {
            if (Session.SessionDate.Date != sessionDate.Date)
            {
                Session.SessionDate = sessionDate;
            }
        }

        /// <summary>
        /// Unlocks the Application for specific module. 
        /// </summary>
        public void UnlockApplication(string applicationId)
        {
            Session.Multiuser.UnlockApp(CompanyId, applicationId);
            IsApplicationUnlocked = true;
            _applicationId = applicationId;
        }

        /// <summary>
        /// Unlocks the application.
        /// </summary>
        public void UnlockApplication()
        {
            UnlockApplication(Session.AppID);
        }

        /// <summary>
        /// Lock Res
        /// </summary>
        public MultiUserStatus LockRsc(string resource, bool exclusive)
        {
            return (MultiUserStatus)Session.Multiuser.LockRsc(resource, exclusive);
        }

        /// <summary>
        /// Un Lock Res
        /// </summary>
        public MultiUserStatus UnLockRsc(string resource)
        {
            return (MultiUserStatus)Session.Multiuser.UnlockRsc(resource);
        }

        /// <summary>
        /// Unlocks an organization's data that was previously locked. 
        /// </summary>
        public void UnlockOrg()
        {
            Session.Multiuser.UnlockOrg(CompanyId);
            IsOrgUnlocked = true;
        }

        /// <summary>
        /// Transaction Begin
        /// </summary>
        /// <returns></returns>
        public int TransactionBegin()
        {
            return DbLink.TransactionBegin();
        }

        /// <summary>
        /// Transaction Commit
        /// </summary>
        /// <returns></returns>
        public int TransactionCommit()
        {
            return DbLink.TransactionCommit();
        }

        /// <summary>
        /// Transaction Rollback
        /// </summary>
        /// <returns></returns>
        public int TransactionRollback()
        {
            return DbLink.TransactionRollback();
        }

        /// <summary>
        /// Get installed reports for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key)
        {
            var installedReports = new List<string>();
            var activeApplications = GetActiveApplications();
            foreach (var application in activeApplications)
            {
                if (IsApplicationActiveForCheckLanguageKey(application.AppId, key, string.Empty))
                {
                    installedReports.AddRange(GetInstalledReports(application.AppId));
                }
            }

            return installedReports;
        }

        /// <summary>
        /// Get installed reports by application Id for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <param name="applicationId">Application Id</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key, string applicationId)
        {
            var installedReports = new List<string>();
            if (IsApplicationActiveForCheckLanguageKey(applicationId, key, string.Empty))
            {
                installedReports.AddRange(GetInstalledReports(applicationId));
            }

            return installedReports;
        }

        /// <summary>
        /// Retrieves the specified key from the application initialization file. Returns whether the key is found or not.
        /// </summary>
        /// <param name="appId">Application Id</param>
        /// <param name="primaryKey">Primary Key to be searched</param>
        /// <param name="secondaryKey">Secondary Key to be searched</param>
        /// <returns>returns whether key is found or not</returns>
        public bool IsApplicationActiveForCheckLanguageKey(string appId, string primaryKey, string secondaryKey)
        {
            string temp;
            return Session.GetIniFileKey(appId, primaryKey, secondaryKey, out temp);
        }

        /// <summary>
        ///  Get Year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>model Years </returns>
        public Years GetYear(string year)
        {
            short period;
            short quarter;
            bool isActive;

            if (DbLink.FiscalCalendar.GetYear(year, out period, out quarter, out isActive))
            {
                return new Years { Year = year, Periods = period, Quarter = quarter, IsActive = isActive };
            }

            return null;
        }

        /// <summary>
        ///  Checks if the session date is present in  fiscal calendar
        /// </summary>
        /// <returns></returns>
        public bool StatusSessionDateInFiscal
        {
            get { return Session.StatusSessionDateInFiscal; }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~BusinessEntitySession()
        {
            Destroy(false);
        }

        /// <summary>
        /// Checks if the company phone format is set
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsPhoneFormat
        {
            get { return DbLink.Company.PhoneFormat; }
        }

        /// <summary>
        /// Retrieves the composite rate between the given source and home currencies. 
        /// If the currencies are non-block currencies, the call functions the same as GetCurrencyRate.
        /// </summary>
        /// <param name="homeCurrencyCode">String param for Home Currency Code</param>
        /// <param name="rateType">String param for Rate type</param>
        /// <param name="sourceCurrencyCode">String param for Source Currency Code </param>
        /// <param name="date">Accpac Session Date</param>
        /// <returns>Returns the corresponding Accpac Currency Rate object.</returns>
        public CompositeCurrencyRate GetCurrencyRateComposite(string homeCurrencyCode, string rateType,
            string sourceCurrencyCode, DateTime date)
        {
            var currencyRate = DbLink.GetCurrencyRateComposite(homeCurrencyCode, rateType, sourceCurrencyCode, date);
            return new CompositeCurrencyRate
            {
                DateMatch = (Models.CurrencyDateMatch)currencyRate.DateMatch,
                HomeCurrency = currencyRate.HomeCurrency,
                Rate = currencyRate.Rate,
                RateDate = currencyRate.RateDate,
                RateOperator = (Models.CurrencyRateOperator)currencyRate.RateOperator,
                RateType = currencyRate.RateType,
                SourceCurrency = currencyRate.SourceCurrency,
                Spread = currencyRate.Spread
            };

        }

        /// <summary>
        /// Returns the CurrencyTableDetail object corresponding to the specified parameter values
        /// </summary>
        /// <param name="currencyCode">String param for Currency Code</param>
        /// <param name="rateType">String param for Rate type</param>
        /// <returns>Returns the Currency Table object corresponding to the specified parameter values</returns>
        public CurrencyTableDetail GetCurrencyTable(string currencyCode, string rateType)
        {
            //return DbLink.GetCurrencyTable(currencyCode, rateType);
            var currencyTable = DbLink.GetCurrencyTable(currencyCode, rateType);
            return new CurrencyTableDetail
            {
                CurrencyCode = currencyTable.CurrencyCode,
                DateMatch = (Models.CurrencyDateMatch)currencyTable.DateMatch,
                Description = currencyTable.Description,
                RateOperator = (Models.CurrencyRateOperator)currencyTable.RateOperator,
                RateType = currencyTable.RateType,
                SourceOfRates = currencyTable.SourceOfRates
            };

        }


        /// <summary>
        /// Indicates how to handle locked fiscal periods for selected company
        /// </summary>
        public CompanyHandleLockedFiscalPeriods HandleLockedFiscalPeriods
        {
            get { return DbLink.Company.HandleLockedFiscalPeriods; }
        }

        /// <summary>
        /// Returns the object key passed in by the caller application.
        /// </summary>
        /// <returns>Returns String</returns>
        public string GetObjectKey()
        {
            return Session.GetObjectKey();
        }

        /// <summary>
        /// Get user's language information
        /// </summary>
        /// <returns>language code (ENG for english)</returns>
        public string UserLanguage
        {
            get { return Session.UserLanguage; }
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
        public bool DatesFromPeriod(short period, Period periodType, short periodLength, DateTime baseDate, out DateTime startDate, out DateTime endDate)
        {
            //TODO:Need to check the retrun value
            return DbLink.FiscalCalendar.DatesFromPeriod(period, (FiscalPeriodType)periodType, periodLength, baseDate, out startDate, out endDate);
        }

        /// <summary>
        /// Check if home currency exits in currency table or no
        /// </summary>
        /// <returns></returns>
        public bool CheckHomeCurrency()
        {
            return Session.StatusHomeCurrencyExists;
        }


        /// <summary>
        /// Products the series.
        /// </summary>
        /// <returns></returns>
        public ProductSeries ProductSeries
        {
            get { return Session.Product; }
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
            currency = currency ?? DbLink.Company.HomeCurrency;
            return DbLink.GetCurrency(currency).IsBlockCombinationWith(currencyCode, date, (CurrencyBlockDateMatch)blockDateMatch);
        }

        /// <summary>
        /// ApplicationID
        /// </summary>
        public string GetApplicationID
        {
            get { return Session.AppID; }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Splits the text based on the chunckSize
        /// </summary>
        /// <param name="text"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        private IEnumerable<string> Chunks(string text, int chunkSize)
        {
            int offset = 0;
            while (offset < text.Length)
            {
                int size = Math.Min(chunkSize, text.Length - offset);
                yield return text.Substring(offset, size);
                offset += size;
            }
        }

        /// <summary>
        /// Retrieves Installed Reports based on Application Id
        /// </summary>
        /// <param name="appId">Application Id</param>
        /// <returns>Installed Reports</returns>
        private string[] GetInstalledReports(string appId)
        {
            return Session.GetInstalledReports(appId);
        }

        /// <summary>
        /// Locks the Application for specific module. 
        /// </summary>
        private void LockApplication()
        {
            if (_applicationId == null)
            {
                return;
            }
            if (IsApplicationUnlocked)
            {
                Session.Multiuser.LockApp(CompanyId, _applicationId, false);
                _applicationId = null;
                IsApplicationUnlocked = false;
            }
        }

        /// <summary>
        /// Locks an organization's data that was previously unlocked. 
        /// </summary>
        private void LockOrg()
        {
            if (IsOrgUnlocked)
            {
                Session.Multiuser.LockOrg(CompanyId, false);
                IsOrgUnlocked = false;
            }
        }

        /// <summary>
        /// Get User Tenant
        /// </summary>
        /// <param name="context"></param>
        /// <returns>User Tenant</returns>
        private static UserTenant GetUserTenant(Context context)
        {
            if (context.ProductUserId == Guid.Empty && context.TenantId == Guid.Empty)
            {
                return new UserTenant() { Tenant = new Tenant() };
            }
            var repository = context.Container.Resolve<ILandlordRepository>();
            return repository.Get(context.ProductUserId, context.TenantId);
        }


        /// <summary>
        /// Initializing BusinessEntitySession
        /// </summary>
        /// <param name="context"></param>
        /// <param name="applicationIdentifier"></param>
        /// <param name="programName"></param>
        /// <param name="userTenant"></param>
        /// <returns></returns>
        private static BusinessEntitySession InitializeSession(Context context, string applicationIdentifier, string programName,
            UserTenant userTenant)
        {
            var viewSession = new BusinessEntitySession { Session = new Session() };
            var repository = context.Container.Resolve<ILandlordRepository>();
            var sage300TenantSddPath = repository.GetSharedDirectory(context.TenantId);

            using (new WADLogWatcher(string.Format("Init Session - {0}", applicationIdentifier), true)) //Added temporary to check performance
            {
			// skip LanPak and user management code in a4wcomsv by passing "1" to InitEx2
            viewSession.Session.InitEx2(sage300TenantSddPath, ObjectHandle, applicationIdentifier, programName,
                Helper.ApplicationVersion, 1);
            }
            return viewSession;
        }

        /// <summary>
        /// Opens Session
        /// </summary>
        /// <param name="viewSession"></param>
        /// <param name="context"></param>
        /// <param name="userTenant"></param>
        /// <returns></returns>
        private static BusinessEntitySession OpenSession(BusinessEntitySession viewSession, Context context, UserTenant userTenant)
        {
            SecureString password;

            if (ConfigurationHelper.IsOnPremise)
            {
                password = CertificateCryptography.ConvertToSecureString(Blowfish.Blowfish_Decrypt(Blowfish.LandlordPassKey, userTenant.ApplicationPassword));
            }
            else
            {
                password = !string.IsNullOrEmpty(ConfigurationHelper.DataCryptoThumbprint)
                ? CertificateCryptography.SecureDecrypt(userTenant.ApplicationPassword,
                    ConfigurationHelper.DataCryptoThumbprint)
                : CertificateCryptography.ConvertToSecureString(userTenant.ApplicationPassword);
            }

            Logger.Info(string.Format("ApplicationLoginId: {0}, Company: {1}, TenantId: {2}, ProductUserId: {3}, SessionDate: {4}", context.ApplicationUserId, context.Company, context.TenantId, context.ProductUserId, context.SessionDate), "OpenSession");

            using (new WADLogWatcher("Open Session", true)) //Added temporary to check performance
            {
                viewSession.Session.Open(userTenant.ApplicationLoginId, CertificateCryptography.SecureStringToString(password), context.Company, context.SessionDate, 0);
            }
            return viewSession;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInfoBytes">bytes to convert into Period info object</param>
        /// <returns>Period info</returns>
        private static PeriodInfo PeriodInfo(byte[] pInfoBytes)
        {
            var handle = GCHandle.Alloc(pInfoBytes, GCHandleType.Pinned);
            var pInfo = (PeriodInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PeriodInfo));
            handle.Free();
            return pInfo;
        }

        /// <summary>
        /// Opens DB Link
        /// </summary>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="viewSession">BusinessEntitySession</param>
        /// <returns>BusinessEntitySession</returns>
        private static BusinessEntitySession OpenDbLink(DBLinkType dbLinkType, BusinessEntitySession viewSession)
        {
            viewSession.DbLink = viewSession.Session.OpenDBLink(dbLinkType, DBLinkFlags.ReadWrite);
            return viewSession;
        }

        /// <summary>
        /// Gets list of active applications
        /// </summary>
        /// <returns></returns>
        private List<Models.ActiveApplication> InitializeActiveApplications()
        {
            var accpacApplication = DbLink.ActiveApplications;
            var activeApplications = new List<Models.ActiveApplication>();
            for (var i = 0; i < accpacApplication.Count; i++)
            {
                var activeApplication = accpacApplication[i];
                if (activeApplication != null && !string.IsNullOrEmpty(activeApplication.AppID))
                {
                    var activeApp = new Models.ActiveApplication
                    {
                        AppId = activeApplication.AppID,
                        AppVersion = activeApplication.AppVersion,
                        DataLevel = activeApplication.DataLevel,
                        IsInstalled = activeApplication.IsInstalled,
                        Selector = activeApplication.Selector,
                        Sequence = activeApplication.Sequence,
                        FormattedAppVersion =
                            activeApplication.AppVersion.Substring(0, 1) + Dot +
                            activeApplication.AppVersion.Substring(1, 2),
                        AppName = Session.RscGetString(activeApplication.Selector, AppProgramName)
                    };
                    activeApp.FormattedAppName =
                        !string.IsNullOrEmpty(Session.RscGetString(activeApplication.Selector, AppProgramName))
                            ? (Session.RscGetString(activeApplication.Selector, AppProgramName) + " " +
                               activeApp.FormattedAppVersion)
                            : (activeApp.Selector + " " + activeApp.FormattedAppVersion);
                    activeApp.AppNameWithoutVersion =
                        string.IsNullOrEmpty(Session.RscGetString(activeApplication.Selector, AppProgramName))
                            ? activeApp.Selector
                            : Session.RscGetString(activeApplication.Selector, AppProgramName);
                    activeApplications.Add(activeApp);
                }
            }
            return activeApplications;
        }

        /// <summary>
        /// Construct key for adding business entity into the pool 
        /// </summary>
        /// <param name="consumingRepositoryName">Name of the consuming repository</param>
        /// <param name="view">View name</param>
        /// <param name="isReadOnly">isReadOnly</param>
        /// <returns></returns>
        private static string ConstructKey(string consumingRepositoryName, string view, bool isReadOnly)
        {
            return string.Concat(consumingRepositoryName, "_", view, "_", isReadOnly);
        }

        #endregion


    }
}

