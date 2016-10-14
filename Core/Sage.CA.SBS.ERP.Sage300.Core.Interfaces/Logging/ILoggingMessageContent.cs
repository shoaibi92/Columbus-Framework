/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Diagnostics;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging
{
    /// <summary>
    /// Interface ILoggingMessageContent
    /// </summary>
    public interface ILoggingMessageContent
    {
        /// <summary>
        /// Message header, message, and exception information, formatted.
        /// </summary>
        /// <value>The formatted message.</value>
        string FormattedMessage { get; set; }

        /// <summary>
        /// Incoming message text with exception information.
        /// </summary>
        /// <value>The message content with exceptions.</value>
        string MessageContentWithExceptions { get; }

        /// <summary>
        /// Trace event type to identify the severity of the message to be logged
        /// </summary>
        /// <value>The type of the original log.</value>
        TraceEventType OriginalLogType { get; }

        /// <summary>
        /// Configured Tenant ID  in which the application is running
        /// </summary>
        /// <value>The tenant identifier.</value>
        string Tenant { get; }

        /// <summary>
        /// User ID who is running the application
        /// </summary>
        /// <value>The user identifier.</value>
        string User { get; }

        /// <summary>
        /// Exception raised from the application
        /// </summary>
        /// <value>The attached exception.</value>
        Exception AttachedException { get; set; }
    }
}