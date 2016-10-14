// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage
{
    /// <summary>
    /// Wrapper exception thrown by the Queue and Queue helper.
    /// Inner exceptions will include the specific provider error
    /// </summary>
    [Serializable]
    public class QueueException : BaseStorageException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueException"/> class.
        /// </summary>
        public QueueException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public QueueException(String msg) : base(msg)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public QueueException(String msg, Exception innerException) : base(msg, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected QueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}