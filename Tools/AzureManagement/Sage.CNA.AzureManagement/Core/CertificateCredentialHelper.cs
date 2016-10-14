using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure;

namespace Sage.CNA.AzureManagement.Core
{
    /// <summary>
    /// Credential Certificate Helper
    /// </summary>
    public static class CertificateCredentialHelper
    {
        /// <summary>
        /// Create certificate object from certifiacate data
        /// </summary>
        /// <param name="subscriptionId">Azure subscription Id</param>
        /// <param name="base64EncodedCert">Base64encoded certifiacate data</param>
        /// <returns></returns>
        public static SubscriptionCloudCredentials GetCredentials(
            string subscriptionId,
            string base64EncodedCert)
        {
            return new CertificateCloudCredentials(subscriptionId,
                new X509Certificate2(Convert.FromBase64String(base64EncodedCert)));
        }
    }
}