/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Runtime.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Class WorkerFault.
    /// </summary>
    [DataContract]
    public class WorkerFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerFault"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public WorkerFault(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [DataMember]
        public string Message { get; set; }
    }
}