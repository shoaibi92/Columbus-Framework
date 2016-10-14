/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;


namespace Sage.CA.SBS.ERP.Sage300.Core.Logging
{
    
    /// <summary>
    /// Logging helper static class.  Use LoggingHelperCore for instance class.
    /// </summary>
    public class Logger
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static LoggingHelperCore _loggingHelperInstance;

        #region Constructor
        static Logger()
        {
            _loggingHelperInstance = new LoggingHelperCore(null);
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
        public static void Critical(string message, string moduleName, Context context, Exception e)
        {
            _loggingHelperInstance.Critical(message, moduleName, context, e);
        }

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Critical.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public static void Critical(string message, string moduleName, Context context)
        {
            Critical(message, moduleName, context, null);
        }

        /// <summary>
        /// Logs the given messageContent, and exception with a Severity of Critical.
        /// The entire messageContent and stack trace of the entire exception chain will be logged.  (Each inner exception is logged).  
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="e">The exception to log</param>
        public static void Critical(string message, string moduleName, Exception e)
        {
            _loggingHelperInstance.Critical(message, moduleName, null, e);
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
        public static void Error(string message, string moduleName, Context context, Exception e)
        {
            _loggingHelperInstance.Error(message, moduleName, context, e);
        }

        /// <summary>
        /// Logs the given messageContent and module namewith a Severity of Error.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public static void Error(string message, string moduleName, Context context)
        {
            Error(message, moduleName, context, null);
        }

        /// <summary>
        /// Logs the given messageContent with a Severity of Error.
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="e">The exception to log</param>
        public static void Error(string message, Exception e)
        {
            Error(message, null, null, e);
        }

        #endregion

        #region Warning method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Warning.
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public static void Warning(string message, string moduleName, Context context)
        {
            _loggingHelperInstance.Warning(message, moduleName, context, null);
        }

        #endregion

        #region Info method overloads

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Info.
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public static void Info(string message, string moduleName, Context context)
        {
            _loggingHelperInstance.Info(message, moduleName, context, null);
        }

        /// <summary>
        /// Log a messageContent with a Severity of Info
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        public static void Info(string message, string moduleName)
        {
            Info(message, moduleName, null);
        }
        #endregion

        #region Verbose method overloads
        
        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Verbose.
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        /// <param name="context">User ID under whose context the application is running</param>
        public static void Verbose(string message, string moduleName, Context context)
        {
            _loggingHelperInstance.Verbose(message, moduleName, context, null);
        }

        /// <summary>
        /// Logs the given messageContent, tenant id and user id with a Severity of Verbose.
        /// The given messageContent will have a ": " appended to the end.  For readability
        /// of your log messages, do not end the messageContent with any punctiation characters. 
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="moduleName">Module Name</param>
        public static void Verbose(string message, string moduleName)
        {
            Verbose(message, moduleName, null);
        }

        #endregion

        /// <summary>
        /// Update the logging filters for Azure, when the Azure configurations are changed and the WebRole is recycled.
        /// </summary>
        public static void UpdateLoggingFilters()
        {
            _loggingHelperInstance.UpdateLoggingFilters();
        }
        #endregion
    }
}
