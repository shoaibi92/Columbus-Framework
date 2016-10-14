/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Configuration;
using System.Globalization;

namespace Sage.CA.SBS.ERP.Sage300.Core.Configuration
{
    /// <summary>
    /// Configuration helper
    /// </summary>
    public static class ConfigurationHelper
    {
        private static bool _isInitialized;

        /// <summary>
        /// Initialize Configuration
        /// </summary>
        /// <param name="container"></param>
        /// <param name="sessionApplicationName"></param>
        /// <param name="applicationIdentifier"></param>
        public static void Initialize(IUnityContainer container, string sessionApplicationName, string applicationIdentifier)
        {
            if (_isInitialized) return;
            Container = container;
            SessionApplicationName = sessionApplicationName;
            ApplicationIdentifier = applicationIdentifier;
            _isInitialized = true;
        }

        /// <summary>
        /// Initialize Configuration
        /// </summary>
        /// <param name="container"></param>
        /// <param name="sessionApplicationName"></param>
        public static void Initialize(IUnityContainer container, string sessionApplicationName)
        {
            Initialize(container, sessionApplicationName, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Blob File Time Out in minutes.
        /// </summary>
        public static double BlobTimeOut
        {
            get
            {
                double val;
                return Double.TryParse(GetConfigValue("BlobTimeOut"), out val) ? val : 60;
            }
        }

        /// <summary>
        /// True if sage id integration is enabled else false
        /// </summary>
        public static bool IsSageIdIntegrationEnabled
        {
            get
            {
                var isSageIdIntegrationEnabled = GetConfigValue("IsSageIdIntegrationEnabled", false);
                bool result;
                Boolean.TryParse(isSageIdIntegrationEnabled, out result);
                return result;
            }
        }

        /// <summary>
        /// Is the application running on premise
        /// </summary>
        /// <returns>True if application is running on premise otherwise false</returns>
        /// <remarks>Currently uses the IsSageIdIntegrationEnabled flag to determine</remarks>
        public static bool IsOnPremise
        {
            get
            {
                return !IsSageIdIntegrationEnabled;
            }
        }

        /// <summary>
        /// Default Company - Only Required for local development
        /// </summary>
        public static string DefaultCompany
        {
            get
            {
                var company = GetConfigValue("Company", false);
                if(string.IsNullOrEmpty(company))
                {
                    return "SAMLTD";
                }
                return company;
            }
        }

        /// <summary>
        /// True if sage KPI Cach is enabled else false
        /// </summary>
        public static bool IsSageKPICachEnabled
        {
            get
            {
                var isSageKPICachEnabled = GetConfigValue("IsSageKPICachEnabled", false);
                bool result;
                Boolean.TryParse(isSageKPICachEnabled, out result);
                return result;
            }
        }

        /// <summary>
        /// True if sage id integration is enabled else false
        /// </summary>
        public static bool IsPortalIntegrationEnabled
        {
            get
            {
                var isPortalIntegrationEnabled = GetConfigValue("IsPortalIntegrationEnabled", false);
                bool result;
                Boolean.TryParse(isPortalIntegrationEnabled, out result);
                return result;
            }
        }

        /// <summary>
        /// Get the local folder, for onpremise/cloud
        /// </summary>
        public static string LocalFolder
        {
            get
            {
                if (!IsRoleAvailable())
                {
                    return ConfigurationManager.AppSettings["LocalTempFolder"];
                }
                return RoleEnvironment.GetLocalResource("LocalTempFolder").RootPath;
            }
        }

        /// <summary>
        /// Gets the Session Pool Time Out in minutes
        /// </summary>
        public static string LearnMoreUrl
        {
            get { return GetConfigValue("LearnMoreUrl", false); }
        }

        /// <summary>
        /// Gets the location of the help menu location
        /// </summary>
        public static string HelpMenuLocation
        {
            get { return GetConfigValue("HelpMenuLocation", false); }
        }

        /// <summary>
        /// Gets the location of the help menu location
        /// </summary>
        public static string MenuLocation
        {
            get { return GetConfigValue("MenuLocation", false); }
        }
        /// <summary>
        /// Gets the Session Pool Time Out in minutes
        /// </summary>
        public static string LearnHelpUrl
        {
            get { return GetConfigValue("LearnHelpUrl", false); }
        }
        /// <summary>
        /// LearnSageIntelligence
        /// </summary>
        public static string LearnSageIntelligence
        {
            get { return GetConfigValue("Templates", false); }
        }

        /// <summary>
        /// Get Configuration Setting Value
        /// </summary>
        /// <param name="configName">Name Of Configuration Key</param>
        /// <returns>Value Of Configuration Setting (Or Null If Not Exists)</returns>
        public static string GetHelpConfigValue(string configName)
        {

            return GetConfigValue(configName, false);
        }

        /// <summary>
        /// Session Application Name
        /// </summary>
        public static string SessionApplicationName { get; private set; }

        /// <summary>
        /// Application Identifier
        /// </summary>
        public static string ApplicationIdentifier { get; private set; }


        /// <summary>
        /// Gets the Session Pool Time Out in minutes
        /// </summary>
        public static TimeSpan SessionPoolTimeOut
        {
            get
            {
                int val;
                return TimeSpan.FromMinutes(Int32.TryParse(GetConfigValue("SessionPoolTimeOut", false), out val) ? val : 30);
            }
        }

        /// <summary>
        /// Gets the Session Date Time Out in minutes.
        /// Session Date will be reset to today's date when today's date - session date is greater than this value.
        /// </summary>
        public static TimeSpan SessionDateTimeOut
        {
            get
            {
                int val;
                return TimeSpan.FromMinutes(Int32.TryParse(GetConfigValue("SessionDateTimeOut", false), out val) ? val : 30);
            }
        }

        /// <summary>
        /// Maximum number of threads can be created by worker role
        /// </summary>
        public static int MaximumThreadCount
        {
            get
            {
                int val;
                return Int32.TryParse(GetConfigValue("MaxThreadCount", false), out val) ? val : 5;
            }
        }

        /// <summary>
        /// Gets the Maximum Session Pool Size
        /// </summary>
        public static int MaxSessionPoolSize
        {
            get
            {
                int val;
                return Int32.TryParse(GetConfigValue("MaxSessionPoolSize", false), out val) ? val : 1;
            }
        }

        /// <summary>
        /// Maximum number of concurrent sessions allowed per user. If it is -1 then no restrictions.
        /// </summary>
        public static int MaxAllowedSessions
        {
            get
            {
                int val;
                return Int32.TryParse(GetConfigValue("MaxAllowedSessions", false), out val) ? val : 1;
            }
        }

        /// <summary>
        /// Is Session Pool Enabled
        /// </summary>
        public static bool SessionPoolEnabled
        {
            get
            {
                bool val;
                Boolean.TryParse(GetConfigValue("SessionPoolEnabled", false), out val);
                return val;
            }
        }

        /// <summary>
        /// If enabled session will be created and destroyed per user per page else it will be per user
        /// </summary>
        public static bool SessionPerPage
        {
            get
            {
                bool val;
                Boolean.TryParse(GetConfigValue("SessionPerPage", false), out val);
                return val;
            }
        }

        /// <summary>
        /// Get the redis cache host provider.
        /// </summary>
        public static string RedisHost
        {
            get { return GetConfigValue("RedisHost"); }
        }

        /// <summary>
        /// Get account key for redis cache.
        /// </summary>
        public static string RedisAccountKey
        {
            get { return GetConfigValue("RedisAccountKey"); }
        }

        /// <summary>
        /// Get port for redis cache.
        /// </summary>
        public static string RedisPort
        {
            get { return GetConfigValue("RedisPort"); }
        }

        /// <summary>
        /// True if redis cache is secured (ssl enabled).
        /// </summary>
        public static bool RedisIsSecured
        {
            get
            {
                bool val;
                if (Boolean.TryParse(GetConfigValue("RedisIsSecured", false), out val))
                {
                    return val;
                }
                return true;
            }
        }


        /// <summary>
        /// Get the cache provider
        /// </summary>
        public static string SageCacheProvider
        {
            get { return GetConfigValue("SageCacheProvider"); }
        }

        /// <summary>
        /// Message Visibility Timeout in minutes.
        /// </summary>
        public static TimeSpan MessageVisibilityTimeOut
        {
            get
            {
                int val;
                return TimeSpan.FromMinutes(Int32.TryParse(GetConfigValue("MessageVisibilityTimeOut"), out val) && val >= 60 ? val : 60);
            }
        }

        /// <summary>
        /// True if Role Environment is available else false
        /// </summary>
        /// <returns></returns>
        public static bool IsRoleAvailable()
        {
            try
            {
                return RoleEnvironment.IsAvailable;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the name of the azure role instance.
        /// </summary>
        /// <returns></returns>
        public static string RoleName
        {
            get
            {
                if (IsRoleAvailable())
                {
                    return RoleEnvironment.CurrentRoleInstance.Role.Name;
                }

                return System.Net.Dns.GetHostName();
            }
        }

        /// <summary>
        /// Gets the id of the azure role instance.
        /// </summary>
        /// <returns></returns>
        public static string RoleInstanceId
        {
            get
            {
                if (IsRoleAvailable())
                {
                    return RoleEnvironment.CurrentRoleInstance.Id;
                }

                return System.Net.Dns.GetHostName();
            }
        }

        /// <summary>
        /// Gets the deployment id of the azure role instance.
        /// </summary>
        /// <returns></returns>
        public static string DeploymentId
        {
            get
            {
                if (IsRoleAvailable())
                {
                    return RoleEnvironment.DeploymentId;
                }

                return "localhost";
            }
        }

        /// <summary>
        /// Allow to log session in Azure table if true
        /// </summary>
        /// <returns></returns>
        public static bool AllowSessionLogging
        {
            get
            {
                bool result;
                Boolean.TryParse(GetConfigValue("AllowSessionLogging"), out result);
                return result;
            }
        }


        /// <summary>
        /// Get Configuration Setting Value
        /// </summary>
        /// <param name="configName">Name Of Configuration Key</param>
        /// <returns>Value Of Configuration Setting (Or Null If Not Exists)</returns>
        public static string GetConfigValue(string configName)
        {
            return GetConfigValue(configName, true);
        }

        /// <summary>
        /// Get Configuration Setting Value
        /// </summary>
        /// <param name="configName">Name Of Configuration Key</param>
        /// <param name="includeRoleConfiguration">if true include role configuration else false.</param>
        /// <returns>Value Of Configuration Setting (Or Null If Not Exists)</returns>
        public static string GetConfigValue(string configName, bool includeRoleConfiguration)
        {
            try
            {
                if (includeRoleConfiguration && IsRoleAvailable())
                {
                    return RoleEnvironment.GetConfigurationSettingValue(configName);
                }
            }
            catch (RoleEnvironmentException)
            {
                // RoleManager Throws Exception If Configuration Key Does Not Exist
                // Mimicing Behavior Of System.Configuration.ConfigurationManager Which Does Not
                // Swallow Exception If Key Not Found - Fall Back To Lookup In Web/App Config
            }
            return ConfigurationManager.AppSettings[configName];
        }

        /// <summary>
        /// Get Unit Container
        /// </summary>
        public static IUnityContainer Container { get; private set; }

        /// <summary>
        /// WCF Host Name
        /// </summary>
        public static string WcfHostName
        {
            get
            {
                return IsRoleAvailable() && RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.ContainsKey("port")
                    ? RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["port"].IPEndpoint.Address.ToString()
                    : "localhost";
            }
        }

        /// <summary>
        /// WCF Port
        /// </summary>
        public static int WcfPort
        {
            get
            {
                return IsRoleAvailable() && RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.ContainsKey("port")
                    ? RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["port"].IPEndpoint.Port
                    : 10100;
            }
        }

        /// <summary>
        /// WCF Mex Port
        /// </summary>
        public static int WcfMexPort
        {
            get
            {
                return IsRoleAvailable() && RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.ContainsKey("mexport")
                    ? RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["mexport"].IPEndpoint.Port
                    : 10101;
            }
        }

        /// <summary>
        /// Base Shared Data Directory
        /// </summary>
        public static string SharedDataDirectory
        {
            get
            {
                return GetConfigValue("SharedDataDirectory", false);
            }
        }

        /// <summary>
        /// Sage Policy Url
        /// </summary>
        public static string PolicyUrl
        {
            get
            {
                return GetConfigValue("PolicyUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Copy Right Url
        /// </summary>
        public static string CopyrightUrl
        {
            get
            {
                return GetConfigValue("CopyrightUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Contact Us URL
        /// </summary>
        public static string ContactUrl
        {
            get
            {
                return GetConfigValue("ContactUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Contact Support URL
        /// </summary>
        public static string ContactSupportUrl
        {
            get
            {
                return GetConfigValue("ContactSupportUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Sage University URL
        /// </summary>
        public static string SageUniversityUrl
        {
            get
            {
                return GetConfigValue("SageUniversityUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Sage City URL
        /// </summary>
        public static string SageCityUrl
        {
            get
            {
                return GetConfigValue("SageCityUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// Sage Share Your Ideas URL
        /// </summary>
        public static string SageShareYourIdeasUrl
        {
            get
            {
                return GetConfigValue("SageShareYourIdeasUrl" + CultureInfo.CurrentCulture.Name, false);
            }
        }

        /// <summary>
        /// SystemStorageConnectionString
        /// </summary>
        public static string SystemStorageConnectionString
        {
            get
            {
                return GetConfigValue("SystemStorageConnectionString");
            }
        }

        /// <summary>
        /// Get Connection String
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionStringName)
        {
            var connectionInfo = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionInfo != null)
            {
                return connectionInfo.ConnectionString;
            }
            return connectionStringName;
        }

        /// <summary>
        /// Thumbprint for data encryption and decryption
        /// </summary>
        public static string DataCryptoThumbprint
        {
            get
            {
                return GetConfigValue("DataCryptoThumbprint");
            }
        }
    }
}
