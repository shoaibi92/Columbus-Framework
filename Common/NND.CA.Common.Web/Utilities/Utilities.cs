// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

using Newtonsoft.Json;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Class for Utilities methods
    /// </summary>
    public static class Utilities
    {
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetUserDefaultLocaleName(StringBuilder lpBuffer, UInt32 uiSize);
        
        /// <summary>
        /// Gets the current application pool user Culture
        /// </summary>
        /// <returns>Default Culture set in Windows's regional setting</returns>
        public static CultureInfo GetUserDefaultCultureInfo()
        {
            var sbBuffer = new StringBuilder(1024);
            return GetUserDefaultLocaleName(sbBuffer, (UInt32)sbBuffer.Capacity) > 0 ? CultureInfo.GetCultureInfoByIetfLanguageTag(sbBuffer.ToString()) : null;
        }


        /// <summary>
        /// Converting model to JsonNetResult
        /// </summary>
        /// <typeparam name="T">Base model</typeparam>
        /// <param name="viewmodel">View model</param>
        /// <returns></returns>
        public static JsonNetResult JsonNet<T>(T viewmodel)
        {
            return new JsonNetResult { Formatting = Formatting.None, Data = viewmodel };
        }

        /// <summary>
        /// Deserializing JsonData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(string jsonData)
        {
            return new JavaScriptSerializer().Deserialize<T>(jsonData);
        }

        /// <summary>
        /// Deserializing JsonData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static List<T> DeserializeJsonList<T>(string jsonData)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(jsonData);
        }

        /// <summary>
        /// Culture
        /// </summary>
        public static string Culture
        {
            get { return CultureInfo.CurrentCulture.Name; }
        }

        /// <summary>
        /// Return Grid Template
        /// </summary>
        /// <param name="field">field Name</param>
        /// <returns></returns>
        public static string GetGridTemplate(string field)
        {
            return string.Format("#= sg.utls.kndoUI.getFormattedDate({0}) #", field);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="field"></param>
       /// <returns></returns>
        public static string GetGridTimeTemplate(string field)
        {
            return string.Format("#= sg.utls.checkIfValidTimeFormat({0}) #", field);
        }

        /// <summary>
        /// Method to create a grid template for formatting decimal values
        /// </summary>
        /// <param name="field">Field to be formatted to</param>
        /// <param name="decimalPlaces">Decimal precision value
        /// <para>By default the decimal places will be fixed to 6 precision</para>
        /// </param>
        /// <returns>Returns a grid template value</returns>
        public static string GetFormattedDecimal(string field, string decimalPlaces = "6")
        {
            return string.Format("#= sg.utls.kndoUI.getFormattedDecimal({0}, {1}) #", field, decimalPlaces);
        }

        /// <summary>
        /// Method to create a grid template for formatting decimal number values
        /// </summary>
        /// <param name="field">Field to be formatted to</param>
        /// <param name="decimalPlaces">Decimal precision value
        /// <para>By default the decimal places will be fixed to 6 precision</para>
        /// </param>
        /// <returns>Returns a grid template value</returns>
        public static string GetFormattedDecimalNumber(string field, string decimalPlaces = "6")
        {
            return string.Format("#= sg.utls.kndoUI.getFormattedDecimalNumber({0}, {1}) #", field, decimalPlaces);
        }

        /// <summary>
        /// GetLearnMoreUrl
        /// </summary>
        /// <param name="cshid">cshid</param>
        /// <returns>learn more link</returns>
        public static string GetLearnMoreUrl(string cshid)
        {
            return string.Format(ConfigurationHelper.LearnMoreUrl, GetHelpCulture(), string.Format("cshid={0}", cshid));
        }

        /// <summary>
        /// GetLearnMoreUrl
        /// </summary>
        /// <param name="query">cshid</param>
        /// <returns>learn more link</returns>
        public static string GetHelpUrl(string query)
        {
            return string.Format(ConfigurationHelper.LearnMoreUrl, GetHelpCulture(), string.Format("search-{0}", query));
        }

        /// <summary>
        /// GetHelpCulture
        /// </summary>
        /// <returns>Culture to be used for help links</returns>
        /// <remarks>This routine allows for the re-direction of help culture</remarks>
        public static string GetHelpCulture()
        {
            // Cultures
            const string cultureEng = "en-US";
            const string cultureFra = "fr-CA";
            const string cultureChn = "zh-Hans";
            const string cultureCht = "zh-Hant";
            const string cultureEsn = "es";

            // Re-direct the culture, if needed
            switch (Culture)
            {
                case cultureEng:
                    // No re-direction for English
                    return Culture;
                case cultureFra:
                    // No re-direction for French
                    return Culture;
                case cultureChn:
                    // Re-direct Simplified Chinese to English
                    return cultureEng;
                case cultureCht:
                    // Re-direct Traditional Chinese to English
                    return cultureEng;
                case cultureEsn:
                    // Re-direct Spanish to English
                    return cultureEng;
                default:
                    // Default to English if some other culture is specified
                    return cultureEng;
            }
        }

        /// <summary>
        /// GetSageIntelligence
        /// </summary>
        /// <param name="query">cshid</param>
        /// <returns>learn more link</returns>
        public static string GetSageIntelligence(string query)
        {
            return string.Format(ConfigurationHelper.LearnSageIntelligence, Culture, string.Format("search-{0}", query));
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Generic Type T</typeparam>
        /// <param name="name">Name</param>
        /// <param name="context">Context</param>
        /// <returns>T</returns>
        public static T Resolve<T>(string name, Context context)
        {
            return context.Container.Resolve<T>(name.ToLowerInvariant(), new ParameterOverride("context", context));
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Generic Type T</typeparam>
        /// <param name="context">Context</param>
        /// <returns>T</returns>
        public static T Resolve<T>(Context context)
        {
            return context.Container.Resolve<T>(new ParameterOverride("context", context));
        }

        /// <summary>
        /// Return Session Provider
        /// </summary>
        /// <param name="context"></param>
        /// <returns>ISessionCacheProvider</returns>
        public static ISessionCacheProvider ResolveSessionHelper(Context context)
        {
            return context.Container.Resolve<ISessionCacheProvider>();
        }

        /// <summary>
        /// Get Url Prefix.
        /// </summary>
        /// <returns></returns>
        public static string GetUrlPrefix()
        {
            var signOnResult = GetStoredUserSignOnResult();

            var tenantAlias = signOnResult.SelectedTenant != null ? signOnResult.SelectedTenant.TenantAlias.Trim() : string.Empty;
            var url = string.Format("/{0}/", tenantAlias);
            return url;
        }

        /// <summary>
        /// Gets the SignOnResult from MVC Session object
        /// </summary>
        /// <returns>UserTenantInfo</returns>
        public static UserTenantInfo GetStoredUserSignOnResult()
        {
            try
            {
                return SessionUtility.Provider.Get<UserTenantInfo>(Shared.SessionAuthInfo);
            }
            catch
            {
                return default(UserTenantInfo);
            }
        }

        /// <summary>
        /// Store SignOnResult in MVC Session object
        /// </summary>
        public static void StoreUserSignOnResult(UserTenantInfo userTenantInfo)
        {
            try
            {
                SessionUtility.Provider.Set(Shared.SessionAuthInfo, userTenantInfo);
            }
            catch
            {
                // Ignore
            }
        }

        /// <summary>
        /// Gets the resume Login from MVC Session object
        /// </summary>
        /// <returns>Authentication</returns>
        public static string GetResumeLogin()
        {
            try
            {
                return SessionUtility.Provider.Get<string>(Shared.SessionResumeLogin);
            }
            catch (Exception)
            {
                return default(string);
            }
        }

        /// <summary>
        /// Sets the resume Login from MVC Session object
        /// </summary>
        public static void SetResumeLogin(string resumeLogin)
        {
            try
            {
                SessionUtility.Provider.Set(Shared.SessionResumeLogin, resumeLogin);
            }
            catch
            {
                // Ignore
            }
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="productUserId">The product user identifier.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public static Context GetContext(Guid tenantId, Guid productUserId, IUnityContainer container)
        {
            var context = new Context { TenantId = tenantId, ProductUserId = productUserId, Container = container };

            return context;
        }

        /// <summary>
        /// Checks whether the request is Ajax or not.
        /// </summary>
        /// <param name="request">HttpRequestBase</param>
        /// <returns>True if it's an ajax request else fails</returns>
        public static bool IsAjaxRequest(HttpRequestBase request)
        {
            //TODO- This doesn't works
            if (request.IsAjaxRequest())
            {
                return true;
            }
            if (request.ContentType.ToLower().Contains("application/json"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the selected tenant to session.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="userTenantInfo">The user person tenant information.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public static bool SetSelectedTenantToSession(Guid tenantId, UserTenantInfo userTenantInfo,
            IUnityContainer container)
        {
            var selectedTenant = userTenantInfo.Tenants.SingleOrDefault(tenant => (tenant.TenantId == tenantId));

            if (selectedTenant == null)
            {
                return false;
            }

            // set the company for selected tenant.
            var context = GetContext(tenantId, userTenantInfo.LoggedInUser.ProductUserId, container);
            var commonService = Resolve<ICommonService>(context);

            selectedTenant.Organizations = commonService.GetCompanies(context);

            if (selectedTenant.Organizations != null)
            {
                var defaultOrganization = selectedTenant.Organizations.FirstOrDefault();
                selectedTenant.Company = defaultOrganization == null ? null : defaultOrganization.Id.Trim();
            }
            else
            {
                Logger.Info("No company information available.", "SetSelectedTenantToSession");
            }

            // Set the user for the selected tenant
            var landlordService = Resolve<ILandlordService>(context);
            var userTenant = landlordService.Get(userTenantInfo.LoggedInUser.ProductUserId, tenantId);

            if (userTenant != null)
            {
                selectedTenant.ApplicationUserId = userTenant.ApplicationLoginId;
            }

            // set the selected tenant.
            userTenantInfo.SelectedTenant = selectedTenant;
            StoreUserSignOnResult(userTenantInfo);
            return true;
        }

        /// <summary>
        /// Get cookie
        /// </summary>
        /// <param name="httpContext">Http Context</param>
        /// <param name="name">Cookie name</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Cookie value</returns>
        public static string GetCookie(HttpContextBase httpContext, string name, string defaultValue)
        {
            // Return cookie or default value
            return httpContext.Request.Cookies[name] == null ? defaultValue : httpContext.Request.Cookies[name].Value;
        }

        /// <summary>
        /// Set cookie
        /// </summary>
        /// <param name="httpContext">Http Context</param>
        /// <param name="name">Cookie name</param>
        /// <param name="value">Cookie value cookie</param>
        public static void SetCookie(HttpContextBase httpContext, string name, string value)
        {
            // Store in new cookie or update existing cookie
            if (httpContext.Request.Cookies[name] == null)
            {
                httpContext.Response.Cookies.Add(new HttpCookie(name)
                {
                    Value = value,
                    Expires = DateUtil.GetMaxDate(),
                    HttpOnly = true
                });
            }
            else
            {
                httpContext.Response.Cookies[name].Value = value;
                httpContext.Response.Cookies[name].Expires = DateUtil.GetMaxDate();
                httpContext.Response.Cookies[name].HttpOnly = true;
            }

        }

        /// <summary>
        /// Generates user specific key for persisting information in the database
        /// </summary>
        /// <param name="context">Context object</param>
        /// <param name="keyValue">key value</param>
        /// <returns>user specific key value</returns>
        public static string GenerateUserSpecificKey(Context context, string keyValue)
        {
            var key = string.Format("{0}_{1}_{2}", context.Company, context.ApplicationUserId, keyValue);
            var md5 = new MD5CryptoServiceProvider();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            
            return Convert.ToBase64String(hashBytes, 0, hashBytes.Length);
        }
    }
}