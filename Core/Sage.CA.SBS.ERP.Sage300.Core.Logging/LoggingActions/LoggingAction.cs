/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.LoggingActions
{
    /// <summary>
    /// Class LoggingAction.
    /// </summary>
    public abstract class LoggingAction : ILoggingAction
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingAction"/> class.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        protected LoggingAction(ILoggingMessageContent messageContent)
        {
            LoggingMessageContent = messageContent;
        }

        #endregion

        /// <summary>
        /// The message content that is logged
        /// </summary>
        /// <value>The content of the logging message.</value>
        public ILoggingMessageContent LoggingMessageContent { get; set; }

        /// <summary>
        /// Write message to the configured trace log
        /// </summary>
        /// <param name="logger">Type of logger that needs to be invoked</param>
        public abstract void WriteMessageToTraceLog(ILogging logger);
    }
}