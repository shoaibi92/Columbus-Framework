/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Base class for report repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseReportRepository<T> : BaseRepository, IReportRepository<T>, ISecurity where T : ReportBase, new()
    {
        #region Private Variables

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IReportMapper<T> _mapper;

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract IBusinessEntity CreateBusinessEntities();

        /// <summary>
        /// View Name
        /// </summary>
        private readonly string _viewName;

        /// <summary>
        /// Resource Id
        /// </summary>
        private readonly string _resourceId;

        #endregion

        #region Constructor

        /// <summary>
        /// BaseEntityRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session</param>
        /// <param name="viewName">View Name</param>
        /// <param name="resourceId">Resource Id - This is required to check security.</param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, IBusinessEntitySession session,
            string viewName, string resourceId)
            : this(context, mapper, session, viewName,resourceId, null)
        {
            
        }

        /// <summary>
        /// BaseEntityRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session</param>
        /// <param name="viewName">View Name</param>
        /// <param name="resourceId">Resource Id - This is required to check security.</param>
        /// <param name="businessEntitySessionParams"></param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, IBusinessEntitySession session,
            string viewName, string resourceId, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, DBLinkType.Company, session,ObjectPoolType.Default, businessEntitySessionParams)
        {
            _mapper = mapper;
            _viewName = viewName;
            _resourceId = resourceId;
        }

        /// <summary>
        /// BaseEntityRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="viewName">View Name</param>
        /// <param name="resourceId">Resource Id - This is required to check security.</param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, string viewName, string resourceId)
            : this(context, mapper, null, viewName, resourceId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReportRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, string viewName, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, mapper, null, viewName, null, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// BaseEntityRepository Constructor
        /// TODO: This needs to be removed
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="viewName"></param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, string viewName)
            : this(context, mapper, null, viewName, null)
        {
        }

        /// <summary>
        /// BaseEntityRepository Constructor
        /// TODO: This needs to be removed
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType"></param>
        protected BaseReportRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// BaseEntityRepository Constructor
        /// TODO: This needs to be removed
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session</param>
        protected BaseReportRepository(Context context, IReportMapper<T> mapper, IBusinessEntitySession session)
            : this(context, mapper, session, null, null)
        {
        }

        #endregion

        /// <summary>
        /// Get Model 
        /// Constructs the empty T
        /// </summary>
        /// <param name="applyUserPreferences">should apply user preferences?</param>
        /// <returns>T</returns>
        public virtual T Get(bool applyUserPreferences = true)
        {
            CheckRights(GetReportAccessRights(), SecurityType.Print);
            return applyUserPreferences ? GetUserPreference() : GetDefaultModel();
        }

        

        /// <summary>
        /// Execute the report
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Guid - Cache Token</returns>
        public virtual Guid Execute(T model)
        {

            CheckRights(GetReportAccessRights(), SecurityType.Print);
            var report = _mapper.Map(model);
            var token = Guid.NewGuid();
            CacheHelper.Set(token.ToString(), report);
            if (ConfigurationHelper.IsOnPremise)
            {
                var auth = HttpContext.Current.Session["authinfo"] as UserTenantInfo;
                var serializedAuth = JsonSerializer.Serialize(auth);
                var pathAuth = Path.Combine(RegistryHelper.SharedDataDirectory, string.Format("{0}.auth", HttpContext.Current.Session.SessionID));
                File.WriteAllText(pathAuth, serializedAuth);

                var serializedReport = JsonSerializer.Serialize(report);
                var pathReport = Path.Combine(RegistryHelper.SharedDataDirectory, string.Format("{0}.rpt", HttpContext.Current.Session.SessionID));
                File.WriteAllText(pathReport, serializedReport);
            }
            return token;
        }

        /// <summary>
        /// Saves the User Preference
        /// </summary>
        /// <param name="model">Model to be saved</param>
        /// <returns>True, if successful</returns>
        public virtual bool SaveUserPreference(T model)
        {
            CheckRights(GetReportAccessRights(), SecurityType.Print);
            var oldModel = Get(false);
            var result = Helper.Compare(typeof(T), oldModel, model);
            if (result.Count == 0)
            {
                return DeleteUserPreference();
            }
            return Session.SaveUserPreference(_viewName, JsonSerializer.SerializeWithCompression(result));
        }

        /// <summary>
        /// Deletes the User Preference to database
        /// </summary>
        /// <returns>True if save is successful, else False</returns>
        public virtual bool DeleteUserPreference()
        {
            CheckRights(GetReportAccessRights(), SecurityType.Print);
            return Session.DeleteUserPreference(_viewName);
        }

        #region Secuirty Method

        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            return GetReportAccessRights();
        }

        

        #endregion

        /// <summary>
        /// Gets access rights
        /// </summary>
        /// <returns>User Access</returns>
        protected virtual UserAccess GetReportAccessRights()
        {
            var userAccess = new UserAccess();
            if (!string.IsNullOrEmpty(_resourceId))
            {
                if (SecurityCheck(_resourceId))
                {
                    AddSecurityType(userAccess, SecurityType.Print);
                }
            }
            else
            {
                //Added for backward compatibility. Else will get executed when Security is taken care by implementing repository (and base.Execute is called)
                AddSecurityType(userAccess,SecurityType.Inquire);
                AddSecurityType(userAccess, SecurityType.Print);
            }
            return userAccess;
        }

        /// <summary>
        /// Gets the base model for Get method
        /// </summary>
        /// <returns></returns>
        protected virtual T GetDefaultModel()
        {
            return new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected T GetUserPreference()
        {
            var model = Get(false);
            var userPreferenceJson = Session.GetUserPreference(_viewName);
            if (string.IsNullOrEmpty(userPreferenceJson))
            {
                return model;
            }
            var dictionary = JsonSerializer.DeserializeCompressed<Dictionary<string, object>>(userPreferenceJson);
            if (dictionary.Count == 0)
            {
                return model;
            }
            try
            {
                model = Helper.Merge(dictionary, model);
            }
            catch (Exception exception)
            {
                Logger.Error("Error in Report - User Preferences", exception);
                //In case of user, do not block the user and delete the saved preferences
                DeleteUserPreference();
                return model;
            }
            return model;
        }

        /// <summary>
        /// Validates license and returns true if license is valid
        /// </summary>
        /// <param name="appId">resourceID</param>
        /// <returns>Returns true if license is ok else false</returns>
        protected bool IsValidLicense(string appId)
        {
            var validLicense = false;
            var appVersion = Session.GetActiveApplications().FirstOrDefault(m => m.AppId.Equals(appId));
            if (appVersion != null && !string.IsNullOrEmpty(appVersion.AppVersion))
            {
                validLicense = Session.IsLicenseOk(appId, appVersion.AppVersion);
            }
            return validLicense;
        }

    }
}