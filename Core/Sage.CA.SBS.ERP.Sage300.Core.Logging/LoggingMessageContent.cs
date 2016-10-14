/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Diagnostics;
using System.Text;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Logging;
using Sage.CA.SBS.ERP.Sage300.Core.Logging.ExceptionHandler;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging
{
    /// <summary>
    /// Class LoggingMessageContent. This class cannot be inherited.
    /// </summary>
    internal sealed class LoggingMessageContent : ILoggingMessageContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingMessageContent"/> class.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="tenant">The tenant identifier.</param>
        /// <param name="company">The company identifier.</param>
        /// <param name="user">The user identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="moduleName">Name of the module.</param>
        /// <param name="e">The e.</param>
        public LoggingMessageContent(TraceEventType eventType, string tenant, string company, string user,
            string message, string moduleName, Exception e)
        {
            OriginalLogType = eventType;
            Company = company;
            ModuleName = moduleName;
            Tenant = tenant;
            User = user;
            AttachedException = e;

            IncomingMessage = message;
            BuildMessage();
        }

        /// <summary>
        /// Gets or sets the incoming message.
        /// </summary>
        /// <value>The incoming message.</value>
        private string IncomingMessage { get; set; }

        #region Properties

        /// <summary>
        /// Message header, message, and exception information, formatted.
        /// </summary>
        /// <value>The formatted message.</value>
        public string FormattedMessage { get; set; }

        /// <summary>
        /// Incoming message text with exception information.
        /// </summary>
        /// <value>The message content with exceptions.</value>
        public string MessageContentWithExceptions { get; private set; }

        /// <summary>
        /// Trace event type to identify the severity of the message to be logged
        /// </summary>
        /// <value>The type of the original log.</value>
        public TraceEventType OriginalLogType { get; private set; }

        /// <summary>
        /// Configured Tenant ID  in which the application is running
        /// </summary>
        /// <value>The tenant identifier.</value>
        public string Tenant { get; private set; }

        /// <summary>
        /// User ID who is running the application
        /// </summary>
        /// <value>The user identifier.</value>
        public string User { get; private set; }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public string ModuleName { get; private set; }

        /// <summary>
        /// Gets the company identifier.
        /// </summary>
        /// <value>The company identifier.</value>
        public string Company { get; private set; }

        /// <summary>
        /// Exception raised from the application
        /// </summary>
        /// <value>The attached exception.</value>
        public Exception AttachedException { get; set; }

        #endregion

        /// <summary>
        /// Builds the message.
        /// </summary>
        private void BuildMessage()
        {
            //First join messageContent with attached exception info.
            var messageBuilder = new StringBuilder(IncomingMessage);

            if (AttachedException != null)
            {
                messageBuilder.Append(string.Format(":{0}{1}", Environment.NewLine,
                    ExceptionFormatter.ExceptionToString(AttachedException)));
            }
            MessageContentWithExceptions = messageBuilder.ToString();

            //Now build formatted messageContent
            messageBuilder.Clear();
            messageBuilder.AppendFormat(LoggingConstants.DefaultFormat,
                new object[] {OriginalLogType.ToString(), Tenant, Company, ModuleName, User, MessageContentWithExceptions});
            FormattedMessage = messageBuilder.ToString();
        }
    }
}