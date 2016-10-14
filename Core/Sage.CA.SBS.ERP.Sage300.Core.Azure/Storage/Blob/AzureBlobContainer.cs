/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    /// <summary>
    /// Azure-specific blob container implementation
    /// </summary>
    public class AzureBlobContainer : IBlobContainer
    {

        #region Private Members

        /// <summary>
        /// Cloud blob container being wrapped
        /// </summary>
        private readonly CloudBlobContainer _cloudBlobContainer;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor specifying the cloud blob container instance
        /// </summary>
        /// <param name="cloudBlobContainer"></param>
        public AzureBlobContainer(CloudBlobContainer cloudBlobContainer)
        {
            if (cloudBlobContainer == null)
            {
                throw new ArgumentNullException();
            }

            _cloudBlobContainer = cloudBlobContainer;
        }

        #endregion


        #region IStorageBlobContainer Members

        /// <summary>
        /// Get a reference to a blob with the provided name (whether it exists yet or not)
        /// And provide a shared access key for that blob
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="permissions">Blob Permissions</param>
        /// <returns></returns>
        public string GetBlobSharedAccessKey(string blobName, BlobPermissions permissions)
        {
            try
            {
                // Get a block blob reference 
                CloudBlockBlob blob = _cloudBlobContainer.GetBlockBlobReference(blobName);

                // Set the start and expiration date for this shared access key:
                // Set the start time to be now minus five minutes to adjust for clock drift
                // Set the expiry time to be one hour after that
                DateTime sharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
                DateTime sharedAccessExpiryTime = sharedAccessStartTime.AddHours(1);

                var sharedAccessBlobPermissionspermissions = SharedAccessBlobPermissions.None;

                switch (permissions)
                {
                    case BlobPermissions.Read:
                        sharedAccessBlobPermissionspermissions = SharedAccessBlobPermissions.Read;
                        break;
                    case BlobPermissions.Write:
                        sharedAccessBlobPermissionspermissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;
                        break;
                }

                // Get a new shared access signature for this blob
                // That will be valid for the default amount of time
                string sharedAccessKey = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy
                {
                    Permissions =
                       sharedAccessBlobPermissionspermissions,
                    SharedAccessStartTime = sharedAccessStartTime,
                    SharedAccessExpiryTime = sharedAccessExpiryTime
                });
                return sharedAccessKey;
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobCreateSharedAccessKeyError, blobName), err);
            }
        }

        /// <summary>
        /// Extend the expiry time for the given shared access key
        /// </summary>
        /// <param name="sharedAccessKey"></param>
        /// <returns></returns>
        public string ExtendBlobSharedAccessKey(string sharedAccessKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a reference to the blob with the given name within this container.
        /// Return a reference of the given type.
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public IBlob GetBlobReference(string blobName)
        {
            try
            {
                // Get a blob reference of the requested type
                CloudBlockBlob blob = _cloudBlobContainer.GetBlockBlobReference(blobName);

                // Package as azure implementation of IStorageBlob
                return new AzureBlockBlob(blob);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobContainerGetBlobReferenceError, blobName, _cloudBlobContainer.Name),
                    err);
            }
        }

        /// <summary>
        /// Get a reference to a directory within this container
        /// </summary>
        /// <param name="relativeAddress"></param>
        /// <returns></returns>
        public IBlobDirectory GetDirectoryReference(string relativeAddress)
        {
            try
            {
                CloudBlobDirectory directory = _cloudBlobContainer.GetDirectoryReference(relativeAddress);
                return new AzureBlobDirectory(directory);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobContainerGetDirectoryError, relativeAddress, _cloudBlobContainer.Name),
                    err);
            }
        }

        /// <summary>
        /// Delete the blob container
        /// </summary>
        public void Delete()
        {
            try
            {
                _cloudBlobContainer.Delete();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobContainerDeleteError, _cloudBlobContainer.Name), err);
            }
        }

        /// <summary>
        /// Gets a list of snapshot identifiers for a blob
        /// </summary>
        /// <param name="blobUri"></param>
        /// <returns></returns>
        public List<DateTime> GetSnapshots(Uri blobUri)
        {
            try
            {

                List<IListBlobItem> snapshots = _cloudBlobContainer.ListBlobs(
                    useFlatBlobListing: true,
                    blobListingDetails: BlobListingDetails.Snapshots
                    ).Where(item => ((ICloudBlob) item).SnapshotTime.HasValue && item.Uri.Equals(blobUri)).ToList();

                return snapshots.Select(snapshot =>
                {
                    var dateTimeOffset = ((ICloudBlob) snapshot).SnapshotTime;
                    return dateTimeOffset != null ? dateTimeOffset.Value.UtcDateTime : DateTime.MinValue;
                }).ToList();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobContainerGetSnapshotError, _cloudBlobContainer.Name), err);
            }
        }

        /// <summary>
        /// Get the URI for the blob container
        /// </summary>
        public Uri Uri
        {
            get { return _cloudBlobContainer.Uri; }
        }

        /// <summary>
        /// Delete all the Blobs in the container. All blobs whose last modified time are older than Current Time - TimeSpan (passed) will be deleted.
        /// </summary>
        /// <param name="timeSpan">Time based on which blob files will be deleted</param>
        public void DeleteBlobs(TimeSpan timeSpan)
        {
            try
            {
                var blobs = _cloudBlobContainer.ListBlobs(null, true);

                foreach (var blobitem in blobs)
                {
                    var blob = blobitem as CloudBlockBlob;

                    if (blob != null)
                    {
                        try
                        {

                            blob.FetchAttributes();

                            if (blob.Metadata != null && blob.Metadata.ContainsKey(Helper.Persistent) &&
                                blob.Metadata[Helper.Persistent] == "1")
                            {
                                continue;
                            }

                            if (blob.Properties.LastModified.HasValue &&
                                blob.Properties.LastModified.Value.Add(timeSpan) < DateTime.UtcNow)
                            {
                                blob.DeleteIfExists();
                                Logger.Info(
                                    string.Format("Blob Deleted :{0}- {1}", _cloudBlobContainer.Name, blob.Name),
                                    LoggingConstants.ModuleWorkerRole);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(
                                string.Format("Unable to delete blob : {0}- {1}", _cloudBlobContainer.Name, blob.Name),
                                ex);
                        }
                    }
                }
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobContainerDeleteError, _cloudBlobContainer.Name), err);
            }
        }
        #endregion
    }
}
