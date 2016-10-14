using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Storage;
using System;

namespace Sage.CNA.AzureManagement.Core
{
    /// <summary>
    /// Storage management client wrapper
    /// </summary>
    public class AzureStorageClient : IDisposable
    {
        /// <summary>
        /// Storage management client property
        /// </summary>
        public StorageManagementClient Instance { get; set; }

        /// <summary>
        /// Initializes storage client
        /// </summary>
        /// <param name="credential">Subscription credentials</param>
        public AzureStorageClient(SubscriptionCloudCredentials credential)
        {
            Instance = CloudContext.Clients.CreateStorageManagementClient(credential);
        }

        /// <summary>
        /// Dispose the management client
        /// </summary>
        public void Dispose()
        {
            if (Instance != null)
                Instance.Dispose();
        }
    }
}