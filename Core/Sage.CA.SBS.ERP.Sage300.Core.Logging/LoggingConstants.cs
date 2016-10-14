/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging
{
    /// <summary>
    /// Loggin constants
    /// </summary>
    public static class LoggingConstants
    {
        /// <summary>
        /// The format to be used for the Trace message
        /// </summary>
        internal static string DefaultFormat = "{0}-[Tenant:{1}] [Company:{2}] [Module:{3}] [User:{4}] - {5}";

        /// <summary>
        /// Module name for Javascript error
        /// </summary>
        public const string ModuleJavascriptError = "Javascript";

        /// <summary>
        /// Global error
        /// </summary>
        public const string ModuleGlobal = "Global";

        /// <summary>
        /// Authorization error
        /// </summary>
        public const string ModuleAuthorization = "Authorization";

        /// <summary>
        /// Authentication error
        /// </summary>
        public const string ModuleAuthentication = "Authentication";

        /// <summary>
        /// Controller error
        /// </summary>
        public const string ModuleController = "Controller";

        /// <summary>
        /// Export/Import 
        /// </summary>
        public const string ModuleExportImport = "Export/Import";

        /// <summary>
        /// Export/Import 
        /// </summary>
        public const string ModuleWorkerRole = "Worker Role";

        /// <summary>
        /// WCF exception
        /// </summary>
        public const string ModuleWcfException = "WCF";

        /// <summary>
        /// Database Audit
        /// </summary>
        public const string ModuleDatabaseAudit = "Database Audit";

        /// <summary>
        /// Session Audit
        /// </summary>
        public const string ModuleSessionAudit = "Session Audit";

        #region Log Message Type

        /// <summary>
        /// Application Error
        /// </summary>
        public const string ApplicationError = "Application";

        #endregion
    }
}
