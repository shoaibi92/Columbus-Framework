/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.LoggingActions
{
    /// <summary>
    /// Class VerboseLoggingAction. This class cannot be inherited.
    /// </summary>
    public sealed class VerboseLoggingAction : LoggingAction
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VerboseLoggingAction"/> class.
        /// </summary>
        /// <param name="messageContent">Content of the message.</param>
        public VerboseLoggingAction(ILoggingMessageContent messageContent) : base(messageContent)
        {
        }

        #endregion

        /// <summary>
        /// Writing the formatted message of severity Verbose to the trace log
        /// </summary>
        /// <param name="logger">Type of logger into which logging</param>
        public override void WriteMessageToTraceLog(ILogging logger)
        {
            logger.Verbose(LoggingMessageContent.FormattedMessage);
        }
    }
}