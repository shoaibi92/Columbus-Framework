using Microsoft.Azure;

namespace Sage.CNA.AzureManagement.Core
{
    /// <summary>
    /// Base Azure management class
    /// </summary>
    public abstract class BaseAzureManagement
    {
        /// <summary>
        /// Azure subscription client
        /// </summary>
        protected readonly AzureCredential CloudCredential;

        /// <summary>
        /// Base Constructor
        /// </summary>
        /// <param name="credentials">Subscription credentials</param>
        protected BaseAzureManagement(AzureCredential credentials)
        {
            CloudCredential = credentials;
        }
    }
}
