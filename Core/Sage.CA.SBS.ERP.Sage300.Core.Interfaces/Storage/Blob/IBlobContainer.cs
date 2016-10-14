/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob
{
    /// <summary>
    /// IBlob Container
    /// </summary>
    public interface IBlobContainer
    {
        /// <summary>
        /// Get a reference to a blob with the provided name (whether it exists yet or not)
        /// And provide a shared access key for that blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="permissions">Blob Permissions</param>
        /// <returns></returns>
        string GetBlobSharedAccessKey(string blobName, BlobPermissions permissions);

        /// <summary>
        /// Extend the expiry time for the given shared access key
        /// </summary>
        /// <param name="sharedAccessKey"></param>
        /// <returns></returns>
        string ExtendBlobSharedAccessKey(string sharedAccessKey);

        /// <summary>
        /// Get a blob reference.  This is getting the actual blob back without any shared access
        /// Signature verification, and is intended for use within the cloud.  This should not be
        /// Exposed via the web service.
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        IBlob GetBlobReference(string blobName);

        /// <summary>
        /// Get a reference to a directory within this container
        /// </summary>
        /// <param name="relativeAddress"></param>
        /// <returns></returns>
        IBlobDirectory GetDirectoryReference(string relativeAddress);

        /// <summary>
        /// Delete the blob container
        /// </summary>
        void Delete();

        /// <summary>
        /// Get the Uri for the blob container
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Returns the list of snapshots
        /// </summary>
        /// <param name="blobUri"></param>
        /// <returns></returns>
        List<DateTime> GetSnapshots(Uri blobUri);

        /// <summary>
        /// Delete all the Blobs in the container. All blobs whose last modified time are older than Current Time - TimeSpan (passed) will be deleted.
        /// </summary>
        /// <param name="timeSpan">Time based on which blob will be deleted</param>
        void DeleteBlobs(TimeSpan timeSpan);
    }
}
