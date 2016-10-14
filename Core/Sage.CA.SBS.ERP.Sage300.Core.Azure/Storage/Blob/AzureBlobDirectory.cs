/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    /// <summary>
    /// 
    /// </summary>
    public class AzureBlobDirectory : IBlobDirectory
    {
        #region Private Members

        /// <summary>
        /// Cloud blob directory being wrapped
        /// </summary>
        private readonly CloudBlobDirectory _cloudBlobDirectory;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor specifying the cloud blob directory instance
        /// </summary>
        /// <param name="cloudBlobDirectory"></param>
        public AzureBlobDirectory(CloudBlobDirectory cloudBlobDirectory)
        {
            if (cloudBlobDirectory == null)
            {
                throw new ArgumentNullException();
            }

            _cloudBlobDirectory = cloudBlobDirectory;
        }

        #endregion

        #region IStorageBlobDirectory Members

        /// <summary>
        /// Get a reference to the blob with the given name within this container and directory.
        /// Return a reference of the given type.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="snapshotDateTime"></param>
        /// <returns></returns>
        public IBlob GetBlobReference(string blobName, DateTime? snapshotDateTime = null)
        {
            try
            {
                DateTime? snapshot = null;
                if (snapshotDateTime.HasValue)
                {
                    snapshot = new DateTime(snapshotDateTime.Value.Ticks, DateTimeKind.Utc);
                }

                // Get a blob reference of the requested type
                CloudBlockBlob blob = _cloudBlobDirectory.GetBlockBlobReference(blobName, snapshot);

                // Package as azure implementation of IStorageBlob
                return new AzureBlockBlob(blob);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDirectoryGetBlobReferenceError, blobName,
                        _cloudBlobDirectory.Uri.AbsolutePath), err);
            }
        }

        /// <summary>
        /// Get a subdirectory under this one
        /// </summary>
        /// <param name="subdirectoryName"></param>
        /// <returns></returns>
        public IBlobDirectory GetSubdirectory(string subdirectoryName)
        {
            try
            {
                CloudBlobDirectory directory = _cloudBlobDirectory.GetSubdirectoryReference(subdirectoryName);
                return new AzureBlobDirectory(directory);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDirectoryGetSubdirectoryError, subdirectoryName,
                        _cloudBlobDirectory.Uri.AbsolutePath), err);
            }
        }

        /// <summary>
        /// Get the URI for the blob directory
        /// </summary>
        public Uri Uri
        {
            get { return _cloudBlobDirectory.Uri; }
        }

        #endregion
    }
}
