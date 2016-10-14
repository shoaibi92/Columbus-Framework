using System;

namespace Sage.CNA.AzureManagement.Entities
{
    /// <summary>
    /// Cloud service Medata data
    /// </summary>
    public class CloudServiceMetadataEntity
    {
        /// <summary>
        /// Name of the cloud service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Deployment type
        /// </summary>
        public string DeploymentType { get; set; }

        /// <summary>
        /// Deployment Label
        /// </summary>
        public string DeploymentLabel { get; set; }

        /// <summary>
        /// Deployment URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Deployment Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Last Modified date
        /// </summary>
        public string LastModifiedDate { get; set; }

        /// <summary>
        /// Role Status
        /// </summary>
        public string RoleStatus { get; set; }
    }
}