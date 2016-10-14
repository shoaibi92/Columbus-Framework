/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging
{
    /// <summary>
    /// Interface ILoggingAction
    /// </summary>
    public interface ILoggingAction
    {
        /// <summary>
        /// The message content that needs to be logged
        /// </summary>
        /// <value>The content of the logging message.</value>
        ILoggingMessageContent LoggingMessageContent { get; set; }

        /// <summary>
        /// Writing the message to the log based on the logger type i.e. to use Azure/Enterprise Logger
        /// </summary>
        /// <param name="logger">The logger.</param>
        void WriteMessageToTraceLog(ILogging logger);
    }
}