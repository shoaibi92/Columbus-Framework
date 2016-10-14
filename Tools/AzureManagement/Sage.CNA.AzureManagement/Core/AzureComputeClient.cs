using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;

namespace Sage.CNA.AzureManagement.Core
{
    /// <summary>
    /// Compute management client wrapper
    /// </summary>
    public class AzureComputeClient : IDisposable
    {
        /// <summary>
        /// Compute management client property
        /// </summary>
        public ComputeManagementClient Instance { get; set; }

        /// <summary>
        /// Initializes compute client
        /// </summary>
        /// <param name="credential">Subscription credentials</param>
        public AzureComputeClient(SubscriptionCloudCredentials credential)
        {
            Instance = CloudContext.Clients.CreateComputeManagementClient(credential);
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