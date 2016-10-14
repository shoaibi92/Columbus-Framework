using Microsoft.WindowsAzure;

namespace Sage.CNA.AzureManagement.Core
{
    /// <summary>
    /// Azure Credentials 
    /// </summary>
    public class AzureCredential
    {
        /// <summary>
        /// Azure subscription credentials
        /// </summary>
        public SubscriptionCloudCredentials Credentials { get; private set; }

        /// <summary>
        /// Certificate credentials
        /// </summary>
        /// <param name="subscriptionId">Azure subscription Id</param>
        /// <param name="certificateData">Azure Management certificate data</param>
        public AzureCredential(string subscriptionId, string certificateData)
        {
            Credentials = CertificateCredentialHelper.GetCredentials(
                subscriptionId,
                certificateData);
        }
    }
}