/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.LoggingActions
{
    /// <summary>
    /// Class WarningLoggingAction. This class cannot be inherited.
    /// </summary>
    public sealed class WarningLoggingAction : LoggingAction
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WarningLoggingAction"/> class.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        public WarningLoggingAction(ILoggingMessageContent messageContent) : base(messageContent)
        {
        }

        #endregion

        /// <summary>
        /// Writing the formatted message of severity warning to the trace log
        /// </summary>
        /// <param name="logger">Type of logger into which logging is done</param>
        public override void WriteMessageToTraceLog(ILogging logger)
        {
            logger.Warning(LoggingMessageContent.FormattedMessage);
        }
    }
}