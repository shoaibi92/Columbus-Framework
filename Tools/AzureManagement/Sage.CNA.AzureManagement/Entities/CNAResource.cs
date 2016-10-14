using System.Collections.Generic;

namespace Sage.CNA.AzureManagement.Entities
{
    public class CNAResource
    {
        public CNAResource()
        {
            ChildResources = new List<CNAResource>();
            MoreInfo = string.Empty;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public CNAResourceType ResourceType { get; set; }

        public CNAServiceType ServiceType { get; set; }

        public bool Status { get; set; }

        public string MoreInfo { get; set; }

        public List<CNAResource> ChildResources { get; set; }
    }
}