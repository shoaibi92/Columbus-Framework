// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;
using Sage.CA.SBS.ERP.Sage300.Core.Logging.LoggingActions;
using System;
using System.Diagnostics;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging
{
    /// <summary>
    /// Logging helper instance class
    /// </summary>
    internal class LoggingHelperCore
    {
        #region Private Variables
        private readonly ILogging _logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Create Logging Helper with logger and ruleset
        /// </summary>
        /// <param name="logger"></param>
        public LoggingHelperCore(ILogging logger)
        {
            if (logger == null)
            {
               logger = new Logging();
            }
            _logger = logger;

        }
        #endregion

        #region Public Methods

        #region Critical method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id, user id and exception with a Severity of Critical.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        /// <param name="e">The exception to log</param>
        public void Critical(string message, string moduleName, Context context, Exception e)
        {
            ILoggingAction loggingAction = GetLoggingAction(TraceEventType.Critical, message, moduleName, context, e);
            loggingAction.WriteMessageToTraceLog(_logger);
        }

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Critical.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public void Critical(string message, string moduleName, Context context)
        {
            Critical(message, moduleName, context, null);
        }

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Critical.
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Critical(string message)
        {
            Critical(message, null, null, null);
        }

        #endregion

        #region Error method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id, user id and exception with a Severity of Error.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        /// <param name="e">The exception to log</param>
        public void Error(string message, string moduleName, Context context, Exception e)
        {
            ILoggingAction loggingAction = GetLoggingAction(TraceEventType.Error, message, moduleName, context, e);
            loggingAction.WriteMessageToTraceLog(_logger);
        }

        #endregion

        #region Warning method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id, user id and exception with a Severity of Warning.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        /// <param name="e">The exception to log</param>
        public void Warning(string message, string moduleName, Context context, Exception e)
        {
            ILoggingAction loggingAction = GetLoggingAction(TraceEventType.Warning, message, moduleName, context, e);
            loggingAction.WriteMessageToTraceLog(_logger);
        }

        #endregion

        #region Info method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id, user id and exception with a Severity of Info.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        /// <param name="e">The exception to log</param>
        public void Info(string message, string moduleName, Context context, Exception e)
        {
            ILoggingAction loggingAction = GetLoggingAction(TraceEventType.Information, message, moduleName, context, e);
            loggingAction.WriteMessageToTraceLog(_logger);
        }

        #endregion

        #region Verbose method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id, user id and exception with a Severity of Verbose.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        /// <param name="e">The exception to log</param>
        public void Verbose(string message, string moduleName, Context context, Exception e)
        {
            ILoggingAction loggingAction = GetLoggingAction(TraceEventType.Verbose, message, moduleName, context, e);
            loggingAction.WriteMessageToTraceLog(_logger);
        }

        #endregion

        /// <summary>
        /// Apply logging filters on cloud when the trace switch is modified
        /// </summary>
        public void UpdateLoggingFilters()
        {
            _logger.UpdateLoggingFilters();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Message is constructed and logged based on the severity or trace event type
        /// </summary>
        /// <param name="type">TraceEventType: Severity / Trace Event type</param>
        /// <param name="message">string: Custom Message to be logged</param>
        /// <param name="moduleName">string: Module from which the logging method is invoked</param>
        /// <param name="context">Context: Request context object</param>
        /// <param name="e">Exception: Exception that needs to be logged</param>
        /// <returns>Type of Logging action</returns>
        private ILoggingAction GetLoggingAction(TraceEventType type, string message, string moduleName, Context context,
            Exception e)
        {
            var messageContent = new LoggingMessageContent(type,
                context != null ? context.TenantAlias : string.Empty,
                context != null ? context.Company : string.Empty,
                context != null ? context.ApplicationUserId : string.Empty,
                message,
                moduleName,
                e);
            return GetDefaultAction(type, messageContent);
        }

        /// <summary>
        /// Get the default action for logging based on severity or trace event type
        /// </summary>
        /// <param name="eventType">Severity / Trace Event type</param>
        /// <param name="loggingMessageContent">Formatted message to be logged</param>
        /// <returns>Type of logging action</returns>
        private LoggingAction GetDefaultAction(TraceEventType eventType, ILoggingMessageContent loggingMessageContent)
        {
            LoggingAction action = null;
            switch (eventType)
            {
                case TraceEventType.Critical:
                    {
                        action = new CriticalLoggingAction(loggingMessageContent);
                    }
                    break;
                case TraceEventType.Error:
                    {
                        action = new ErrorLoggingAction(loggingMessageContent);
                    }
                    break;
                case TraceEventType.Warning:
                    {
                        action = new WarningLoggingAction(loggingMessageContent);
                    }
                    break;
                case TraceEventType.Information:
                    {
                        action = new InfoLoggingAction(loggingMessageContent);
                    }
                    break;
                case TraceEventType.Verbose:
                    {
                        action = new VerboseLoggingAction(loggingMessageContent);
                    }
                    break;
            }
            return action;
        }
        #endregion
    }
}
