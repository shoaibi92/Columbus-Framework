/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System.Collections.Generic;
using ActiveApplication = Sage.CA.SBS.ERP.Sage300.Common.Models.ActiveApplication;
using Currency = Sage.CA.SBS.ERP.Sage300.Common.Models.Currency;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Class CommonRepository.
    /// </summary>
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        public CommonRepository(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        public CommonRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Sets Context and Session and defaults DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        public CommonRepository(Context context, IBusinessEntitySession session)
            : base(context, session)
        {
        }

        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        public CommonRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        /// <summary>
        /// Gets the Currency
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>Currency.</returns>
        public Currency GetCurrency(string currencyCode)
        {
            return Session.GetCurrency(currencyCode);
        }

        /// <summary>
        /// Checks for license
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appVersion"></param>
        /// <returns></returns>
        public bool CheckLicense(string appId, string appVersion)
        {
            return Session.IsLicenseOk(appId, appVersion);
        }

        /// <summary>
        ///  Unlocks an organization's data that was previously locked. 
        /// </summary>
        public void UnlockOrg()
        {
            Session.UnlockOrg();
        }

        /// <summary>
        ///  Lock Resource
        /// </summary>
        public MultiUserStatus LockRsc(string resource, bool exclusive)
        {
            return Session.LockRsc(resource, exclusive);
        }

        /// <summary>
        ///  Un Lock Resource
        /// </summary>
        public MultiUserStatus UnLockRsc(string resource)
        {
            return Session.UnLockRsc(resource);
        }

        /// <summary>
        /// Unlocks the Application for default module.
        /// </summary>
        public void UnlockApplication()
        {
            Session.UnlockApplication();
        }

        /// <summary>
        /// Gets the list of companies
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public List<Models.Organization> GetCompanies(Context context)
        {
            return BusinessEntitySession.GetCompanies(context);
        }

        /// <summary>
        /// Save the User Preference.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>True if saved else false</returns>
        public bool SaveUserPreference(string key, string value)
        {
            return Session.SaveUserPreference(key, value);
        }

        /// <summary>
        /// Delete the User Preference.
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>True if deleted else false</returns>
        public bool DeleteUserPreference(string key)
        {
            return Session.DeleteUserPreference(key);
        }

        /// <summary>
        /// Get the User Preferences.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public string GetUserPreference(string key)
        {
            return Session.GetUserPreference(key);
        }

        /// <summary>
        /// Get installed reports for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key)
        {
            return Session.GetInstalledReportForActiveApplication(key);
        }

        /// <summary>
        /// Get installed reports by application Id for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <param name="applicationId">Application Id</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key, string applicationId)
        {
            return Session.GetInstalledReportForActiveApplication(key, applicationId);
        }

        /// <summary>
        /// Method to get the Fiscal Calendar defined
        /// </summary>
        /// <returns>Returns an object of type <see cref="Models.FiscalCalendar" /></returns>
        public Models.FiscalCalendar GetFiscalCalendar()
        {
            return Session.GetFiscalCalendar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public bool HasAccess(string resourceId)
        {
            return Session.SecurityCheck(resourceId);
        }

        /// <summary>
        /// Method to fetch the Period from Session date
        /// </summary>
        /// <returns>Returns an object of type <see cref="PeriodInfo" /></returns>
        public PeriodInfo GetPeriodFromDate()
        {
            return Session.GetPeriodFromDate();
        }

        /// <summary>
        /// Method to verify the Session date
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        public SessionDateWarning VerifySessionDate()
        {
            return Session.VerifySessionDate();
        }

        /// <summary>
        /// Get user's language information
        /// </summary>
        /// <returns>language code (ENG for english)</returns>
        public string GetUserLanguage()
        {
            return Session.UserLanguage;
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
            return Session.IsBlockCombinationWith(currency, currencyCode, date, blockDateMatch);
        }
		
        /// <summary>
        /// Gets active applications
        /// </summary>
        /// <returns>list of active applcations</returns>
        public List<ActiveApplication> GetActiveApplications()
        {
            return Session.GetActiveApplications();
        }
    }
}