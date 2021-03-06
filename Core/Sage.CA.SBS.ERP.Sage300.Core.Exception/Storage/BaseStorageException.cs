﻿/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage
{
    /// <summary>
    /// Class BaseStorageException.
    /// </summary>
    [Serializable]
    public class BaseStorageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStorageException"/> class.
        /// </summary>
        public BaseStorageException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStorageException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public BaseStorageException(String msg) : base(msg)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStorageException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public BaseStorageException(String msg, Exception innerException) : base(msg, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseStorageException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected BaseStorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}