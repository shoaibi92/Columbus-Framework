using System;
using System.ComponentModel.DataAnnotations;

namespace Sage.CNA.AzureInfo.Models
{
    /// <summary>
    /// Cloud service Medata data entity Model
    /// </summary>
    public class CloudServiceMetadataEntityModel : BaseModel
    {
        /// <summary>
        /// Name of the cloud service
        /// </summary>
        public string Name { get; set; }     
        
        /// <summary>
        /// Description of the cloud service
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Deployment type
        /// </summary>
        [Display(Name = "Deployment Type")]
        public string DeploymentType { get; set; }

        /// <summary>
        /// Deployment type
        /// </summary>
        [Display(Name = "Deployment Label")]
        public string DeploymentLabel { get; set; }

        /// <summary>
        /// Deployment Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Deployment URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        [Display(Name = "Last Deployed")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Last Modified date
        /// </summary>
        public string LastModifiedDate { get; set; }

        /// <summary>
        /// Highlight Class
        /// </summary>
        public string HighlightCssClass { get; set; }

        /// <summary>
        /// Role Status
        /// </summary>
        [Display(Name = "Status")]
        public string ConsolidatedRoleStatus { get; set; }
    }
}