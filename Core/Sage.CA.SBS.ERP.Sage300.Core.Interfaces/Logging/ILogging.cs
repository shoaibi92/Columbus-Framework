/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging
{
    /// <summary>
    /// Interface ILogging
    /// </summary>
    public interface ILogging
    {
        /// <summary>
        /// To log message of critical severity
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Critical(string message);

        /// <summary>
        /// To log message of error severity
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Error(string message);

        /// <summary>
        /// To log message of warning severity
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Warning(string message);

        /// <summary>
        /// To log message of Information type
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Info(string message);

        /// <summary>
        /// To log message in Verbose
        /// </summary>
        /// <param name="message">Message to ve logged</param>
        void Verbose(string message);

        /// <summary>
        /// Applying logging filters (if any)
        /// </summary>
        void UpdateLoggingFilters();
    }
}