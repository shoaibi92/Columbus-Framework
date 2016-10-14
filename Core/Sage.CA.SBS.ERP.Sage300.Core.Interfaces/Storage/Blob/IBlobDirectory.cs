/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob
{
    /// <summary>
    /// IBlob Driectory
    /// </summary>
    public interface IBlobDirectory
    {
        /// <summary>
        /// Get a reference to a blob with the given name and type in this directory
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="snapshotDateTime"></param>
        /// <returns></returns>
        IBlob GetBlobReference(string blobName, DateTime? snapshotDateTime = null);

        /// <summary>
        /// Get a directory within this one
        /// </summary>
        /// <param name="subdirectoryName"></param>
        /// <returns></returns>
        IBlobDirectory GetSubdirectory(string subdirectoryName);

        /// <summary>
        /// Get the Uri for the blob directory
        /// </summary>
        Uri Uri { get; }
    }
}
