﻿/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.LoggingActions
{
    /// <summary>
    /// Class CriticalLoggingAction. This class cannot be inherited.
    /// </summary>
    public sealed class CriticalLoggingAction : LoggingAction
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingAction" /> class.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        public CriticalLoggingAction(ILoggingMessageContent messageContent) : base(messageContent)
        {
        }

        #endregion

        /// <summary>
        /// Writing the formatted message of severity critical to the trace log
        /// </summary>
        /// <param name="logger">Type of logger into which logging is done i.e Enterprise Logging or Azure Logging</param>
        public override void WriteMessageToTraceLog(ILogging logger)
        {
            logger.Critical(LoggingMessageContent.FormattedMessage);
        }
    }
}