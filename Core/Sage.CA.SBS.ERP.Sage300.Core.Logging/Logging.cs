/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.WindowsAzure.ServiceRuntime;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;
using System;
using System.Diagnostics;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging
{
    internal class Logging : ILogging
    {
        #region Constructor

        public Logging()
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(new LogWriterFactory().Create());
        }

        #endregion

        private const string GeneralCategory = "General";

        #region Public Methods

        /// <summary>
        /// Overloaded method to log critical errors
        /// </summary>
        /// <param name="message"></param>
        public void Critical(string message)
        {
            Log(message, TraceEventType.Critical, GeneralCategory);
        }

        /// <summary>
        /// Overloaded method to log errors
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            Log(message, TraceEventType.Error, GeneralCategory);
        }

        /// <summary>
        /// Overloaded method to log warnings
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            Log(message, TraceEventType.Warning, GeneralCategory);
        }

        /// <summary>
        /// Overloaded method to log information
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            Log(message, TraceEventType.Information, GeneralCategory);
        }

        /// <summary>
        /// Overloaded method to log verbose information
        /// </summary>
        /// <param name="message"></param>
        public void Verbose(string message)
        {
            Log(message, TraceEventType.Verbose, GeneralCategory);
        }

        /// <summary>
        /// Updates logging filters
        /// </summary>
        public void UpdateLoggingFilters()
        {
            var setting = ConfigurationHelper.GetConfigValue("SageCloudDiagnosticTraceLevel");
            var sourceLevel = SourceLevelFromString(setting);

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Writer.Configure(cfg =>
            {
                var traceListeners = cfg.AllTraceListeners.ToList();
                if (traceListeners.Count > 0)
                {
                    traceListeners[0].Filter = new EventTypeFilter(sourceLevel);
                }
            });

            Verbose(string.Format(LoggingConstants.DefaultFormat, TraceEventType.Verbose, Guid.Empty, string.Empty,
                string.Empty, Guid.Empty,
                string.Format(
                    "GetTraceSwitchValuesFromRoleConfiguration in AzureLogging for Role {0} - Trace Switch Value set to [{1}]",
                    RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : "Undefined", setting)));
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Log the message with severity based on the trace category configured in web.config
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="traceCategory"></param>
        private void Log(string message, TraceEventType severity, string traceCategory)
        {
            if (Microsoft.Practices.EnterpriseLibrary.Logging.Logger.IsLoggingEnabled())
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(message, traceCategory, 1, 0, severity);
            }
        }

        private SourceLevels SourceLevelFromString(string str)
        {
            SourceLevels level;
            try
            {
                level = (SourceLevels) Enum.Parse(typeof (SourceLevels), str, true);
            }
            catch (ArgumentException exp)
            {
                // Invalid value - just default to error.
                level = SourceLevels.Error;
                Error(exp.Message);
            }

            return level;
        }


        #endregion
    }
}
