using System.Collections.Generic;

namespace Sage.CNA.AzureInfo.Models
{
    /// <summary>
    /// Cloud service Medata data
    /// </summary>
    public class CloudServiceMetadataModel : BaseModel
    {
        /// <summary>
        /// Initialize objects
        /// </summary>
        public CloudServiceMetadataModel()
        {
            CloudServiceList = new List<CloudServiceMetadataEntityModel>();
            R2CloudServiceList = new List<CloudServiceMetadataEntityModel>();
            R3CloudServiceList = new List<CloudServiceMetadataEntityModel>();
        }

        /// <summary>
        /// Cloud service list
        /// </summary>
        public List<CloudServiceMetadataEntityModel> CloudServiceList { get; set; }

        /// <summary>
        /// R2 Cloud service list
        /// </summary>
        public List<CloudServiceMetadataEntityModel> R2CloudServiceList { get; set; }

        /// <summary>
        /// R3 Cloud service list
        /// </summary>
        public List<CloudServiceMetadataEntityModel> R3CloudServiceList { get; set; }
    }
}