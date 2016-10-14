/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base
{
    /// <summary>
    /// Interface ICommonService
    /// </summary>
    public interface ICommonService : ISecurityService
    {
        /// <summary>
        /// Get List of companies
        /// </summary>
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
        /// Method to get the Fiscal Calendar defined
        /// </summary>
        /// <returns>Returns an object of type <see cref="FiscalCalendar" /></returns>
        FiscalCalendar GetFiscalCalendar();

        /// <summary>
        /// Release Session from object pool
        /// </summary>
        void ReleaseSession();

        /// <summary>
        /// Destroys session associated with the passed token in Context object (Context.ContextToken).
        /// </summary>
        void Destroy();

        /// <summary>
        /// Destroys session associated with the passed token in Context object (Context.ContextToken) and application identifier.
        /// </summary>
        void Destroy(string applicationIdentifier);

        /// <summary>
        /// Destroy pool based session id.
        /// </summary>
        void DestroyPool();

        /// <summary>
        /// Has access rights
        /// </summary>
        /// <returns>UserAccess</returns>
        bool HasAccess(string resourceId);

        /// <summary>
        /// Get the Blob Container based on tenent.
        /// </summary>
        /// <returns></returns>    
        IBlobContainer GetBlobContainer();

        /// <summary>
        /// Get the application cache of CNA
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        string PullTextFromCache(string blobName);

        /// <summary>
        /// Push the Json in to the cache.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        void PushTextInToCache(string blobName, string content);

        /// <summary>
        /// Get the application cache of CNA
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        Stream PullStreamFromCache(string blobName);

        /// <summary>
        /// Push the Json in to the cache.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        void PushStreamInToCache(string blobName, Stream content);

        /// <summary>
        /// Check Weather blob is valid.
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        bool IsBlobValid(string blobName);

        /// <summary>
        /// Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="exclusive"></param>
        /// <returns></returns>
        MultiUserStatus LockResource(string resource, bool exclusive);

        /// <summary>
        /// Un-Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        MultiUserStatus UnLockResource(string resource);

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
		
		/// <summary>
        /// Gets active applications
        /// </summary>
        /// <returns>list of active applications</returns>
        List<ActiveApplication> GetActiveApplications();
    }
}