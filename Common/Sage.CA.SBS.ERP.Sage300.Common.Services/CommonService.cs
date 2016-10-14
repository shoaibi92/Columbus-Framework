/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region
using System;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using System.Collections.Generic;
using System.IO;
using ActiveApplication = Sage.CA.SBS.ERP.Sage300.Common.Models.ActiveApplication;
using Currency = Sage.CA.SBS.ERP.Sage300.Common.Models.Currency;
using FiscalCalendar = Sage.CA.SBS.ERP.Sage300.Common.Models.FiscalCalendar;
using Organization = Sage.CA.SBS.ERP.Sage300.Common.Models.Organization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services
{
    /// <summary>
    /// Service exposing common methods
    /// </summary>
    public class CommonService : BaseService, ICommonService
    {
        #region Constructor

        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public CommonService(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get List of companies
        /// </summary>
        /// <returns></returns>
        public List<Organization> GetCompanies(Context context)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetCompanies(context);
            }
        }

        /// <summary>
        /// Checks for license
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appVersion"></param>
        /// <returns></returns>
        public bool CheckLicense(string appId, string appVersion)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.CheckLicense(appId, appVersion);
            }
        }

        /// <summary>
        /// Release Session from object pool
        /// </summary>
        public void ReleaseSession()
        {
            BusinessPoolManager.ReleaseSession(Context);
        }

        /// <summary>
        /// Destroys session associated with the passed token in Context object (Context.ContextToken).
        /// </summary>
        public void Destroy()
        {
            BusinessPoolManager.Destroy(Context);
        }
        
        /// <summary>
        /// Destroys session associated with the passed token in Context object (Context.ContextToken) and application identifier.
        /// </summary>
        /// <param name="applicationIdentifier">application identifier</param>
        public void Destroy(string applicationIdentifier)
        {
            BusinessPoolManager.Destroy(Context.SessionId, applicationIdentifier);
        }

        /// <summary>
        /// Destroy pool based on session id.
        /// </summary>
        public void DestroyPool()
        {
            BusinessPoolManager.DestroyPool(Context.SessionId);
        }

        /// <summary>
        /// Get Currency
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public Currency GetCurrency(string currencyCode)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetCurrency(currencyCode);
            }
        }

        /// <summary>
        /// Get container based on tenant
        /// </summary>
        /// <returns>IBlobContainer</returns>
        public IBlobContainer GetBlobContainer()
        {
            var container = Context.Container.Resolve<IBlobContainerFactory>();
            //Container names must start with a letter or number, and can contain only letters, numbers, and the dash (-) character.
            //Every dash (-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.
            //All letters in a container name must be lowercase.
            //Container names must be from 3 through 63 characters long.
            return container.GetBlobContainer(Context.TenantId.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Get Export/Import based on tenant
        /// </summary>
        /// <returns>IExportImport</returns>
        public IExportImport GetExportImport()
        {
            return Context.Container.Resolve<IExportImport>();
        }

        /// <summary>
        /// Save the User Preference.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>True if saved else false</returns>
        public bool SaveUserPreference(string key, string value)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.SaveUserPreference(key, value);
            }
        }

        /// <summary>
        /// Delete the User Preference.
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>True if deleted else false</returns>
        public bool DeleteUserPreference(string key)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.DeleteUserPreference(key);
            }
        }

        /// <summary>
        /// Get the User Preferences.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public string GetUserPreference(string key)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetUserPreference(key);
            }
        }

        /// <summary>
        /// Is not used
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            return null;
        }

        /// <summary>
        /// Method to get the Fiscal Calendar defined
        /// </summary>
        /// <returns>Returns an object of type <see cref="Models.FiscalCalendar" /></returns>
        public FiscalCalendar GetFiscalCalendar()
        {
            using (var entity = Resolve<ICommonRepository>())
            {
                return entity.GetFiscalCalendar();
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Destroy pool when session ends
        /// </summary>
        /// <param name="sessionId"></param>
        public static void DestroyPool(string sessionId)
        {
            BusinessPoolManager.DestroyPool(sessionId);
        }

        /// <summary>
        /// Clear Session Logs
        /// </summary>
        public static void ClearSessionLogs()
        {
            BusinessPoolManager.ClearSessionLogs();
        }

        #endregion

        ///<summary>
        /// Get installed reports for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetInstalledReportForActiveApplication(key);
            }
        }

        ///<summary>
        /// Get installed reports by application Id for the Activated Application based
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <param name="applicationId">Application Id</param>
        /// <returns>Installed Reports</returns>
        public List<string> GetInstalledReportForActiveApplication(string key, string applicationId)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetInstalledReportForActiveApplication(key, applicationId);
            }
        }

        /// <summary>
        /// Has Access - checks weather the user has access for the particular resource id
        /// </summary>
        /// <param name="resourceId">security key (resource id)</param>
        /// <returns>true if has access otherwise false.</returns>
        public bool HasAccess(string resourceId)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.HasAccess(resourceId);
            }
        }

        /// <summary>
        /// Get the application cache of CNA
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public string PullTextFromCache(string blobName)
        {

            var blob = GetBlob(blobName);
            if (blob != null)
            {
                return blob.DownloadText();
            }
            return null;
        }

        /// <summary>
        ///  Push the Json in to the cache.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void PushTextInToCache(string blobName, string content)
        {
            var blob = GetBlob(blobName);
            if (blob != null)
            {
                blob.UploadText(content);
            }
        }


        /// <summary>
        /// Get the application cache of CNA
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public Stream PullStreamFromCache(string blobName)
        {
            var blob = GetBlob(blobName);
            if (blob != null)
            {
                Stream downloadedStream = new MemoryStream();
                blob.DownloadStream(downloadedStream);
                return downloadedStream;
            }
            return null;
        }

        /// <summary>
        ///  Push the Json in to the cache.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void PushStreamInToCache(string blobName, Stream content)
        {
            var blob = GetBlob(blobName);
            if (blob != null)
            {
                blob.UploadStream(content);
            }
        }

        /// <summary>
        ///  Check whether blob is valid.
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public bool IsBlobValid(string blobName)
        {
            var blob = BlobFactory.GetBlob(blobName, Context);
            if (blob != null)
            {
                return blob.IsBlobValid(blobName, Context);
            }
            return false;
        }

        /// <summary>
        /// Get blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        private IBlob GetBlob(string blobName)
        {
            return BlobFactory.GetBlob(blobName, Context);
        }

        /// <summary>
        /// Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="exclusive"></param>
        /// <returns></returns>
        public MultiUserStatus LockResource(string resource, bool exclusive)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.LockRsc(resource, exclusive);
            }
        }

        /// <summary>
        /// Un Lock Resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public MultiUserStatus UnLockResource(string resource)
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.UnLockRsc(resource);
            }
        }

        /// <summary>
        /// Method to get Fiscal Period from Date
        /// </summary>
        /// <returns>Returns an object of type PeriodInfo</returns>
        public PeriodInfo GetPeriodFromDate()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetPeriodFromDate();
            }
        }

        /// <summary>
        /// Method to Verify Session Date
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        public SessionDateWarning VerifySessionDate()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.VerifySessionDate();
            }
        }

        /// <summary>
        /// Get user's language information
        /// </summary>
        /// <returns>language code (ENG for english)</returns>
        public string GetUserLanguage()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetUserLanguage();
            }
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
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.IsBlockCombinationWith(currency,currencyCode,date,blockDateMatch);
            }
        }
		
		/// <summary>
        /// Gets active applications
        /// </summary>
        /// <returns>list of active applications</returns>
        public List<ActiveApplication> GetActiveApplications()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.GetActiveApplications();
            }
        }
    }
}