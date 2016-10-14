using Sage.CNA.AzureManagement;
using Sage.CNA.AzureManagement.Core;
using Sage.CNA.AzureManagement.Entities;
using Sage.CNA.Web.CloudStatus.Helper;
using System.Web.Http;

namespace Sage.CNA.Web.CloudStatus.Controllers
{
    /// <summary>
    /// CNA2 Environment Resource Status API
    /// </summary>
    public class StatusController : ApiController
    {
        /// <summary>
        /// Gets the status of the CNA2 resources
        /// </summary>
        /// <param name="cs">Azure Cloud Service Name</param>
        /// <param name="slot">Cloud Service Deployment Slot - Default value production</param>
        /// <param name="sa">Storage account name - should be part of the same subscription</param>
        /// <returns>CNA Resource status Object</returns>
        public CNAResource Get(string cs = "", string slot = "production", string sa = "")
        {
            if (string.IsNullOrEmpty(cs))
            {
                return new CNAResource { Description = "Cloud Service name is empty" };
            }

            slot = slot.ToLower();

            if (!(slot == "production" || slot == "staging"))
            {
                return new CNAResource { Description = "Cloud Service slot name must be either production or staging" };
            }

            // Azure credentials
            var azureCredential = new AzureCredential(
                ConfigurationHelper.SubscriptionId,
                ConfigurationHelper.CertificateData);

            var healthChecker = new CloudServiceHealthChecker(azureCredential);
            var statusInfo = healthChecker.GetCloudServiceMetadata(cs, slot, sa);

            return statusInfo;
        }
    }
}
