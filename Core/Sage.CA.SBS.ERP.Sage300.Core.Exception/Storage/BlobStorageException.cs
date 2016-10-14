#region

using System;
using System.Runtime.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage
{
    /// <summary>
    /// Wrapper exception thrown by the blob and blob helper.
    /// Inner exceptions will include the specific provider error
    /// </summary>
    [Serializable]
    public class BlobStorageException : BaseStorageException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobStorageException"/> class.
        /// </summary>
        public BlobStorageException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobStorageException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public BlobStorageException(String msg) : base(msg)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobStorageException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public BlobStorageException(String msg, Exception innerException) : base(msg, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobStorageException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected BlobStorageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}