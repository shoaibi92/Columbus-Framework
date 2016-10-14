/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System.Globalization;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    /// <summary>
    /// Blob container factory for azure-specific blob containers
    /// </summary>
    public class AzureBlobContainerFactory : IBlobContainerFactory
    {

        #region IBlobContainerFactory Members

        /// <summary>
        /// Creates the blob container with the provided reference
        /// </summary>
        /// <param name="blobContainerId"></param>
        /// <returns></returns>
        public IBlobContainer GetBlobContainer(string blobContainerId)
        {
            CloudBlobContainer blobContainer = null;
            try
            {
                CloudBlobClient blobClient =
                    Helper.CreateCloudStorageAccount().CreateCloudBlobClient();

                if (blobClient != null)
                {

                    // CORS should be enabled once at service startup
                    // Given a BlobClient, download the current Service Properties 
                    var blobServiceProperties = blobClient.GetServiceProperties();

                    // Enable and Configure CORS
                    ConfigureCors(blobServiceProperties);

                    // Commit the CORS changes into the Service Properties
                    blobClient.SetServiceProperties(blobServiceProperties);

                    blobContainer = blobClient.GetContainerReference(blobContainerId);

                    if (blobContainer.CreateIfNotExists())
                    {
                        // New container
                        // Set permissions so that it is not accessible by anonymous user request
                        // We will control access using shared access signatures at the blob level
                        var blobContainerPermissions = new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Off
                        };
                        blobContainer.SetPermissions(blobContainerPermissions);
                    }
                }
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(CultureInfo.CurrentCulture, StorageResx.BlobContainerCreationError, blobContainerId),
                    err);
            }

            return new AzureBlobContainer(blobContainer);
        }

        /// <summary>
        /// ConfigureCors
        /// </summary>
        /// <param name="serviceProperties"></param>
        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule
            {
                AllowedHeaders = new List<string> { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List<string> { "*" },
                ExposedHeaders = new List<string> { "*" },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }

        #endregion
    }
}
