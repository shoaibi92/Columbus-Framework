using System.Collections.Generic;

namespace Sage.CNA.AzureManagement.Entities
{
    public class CNAHealthEntity
    {
        public CNAHealthEntity()
        {
            Resources = new List<CNAResource>();
        }

        public string CloudService { get; set; }

        public bool Status
        {
            get
            {
                return Resources.TrueForAll(resource => resource.Status);
            }
        }
        public string Description { get; set; }
        public List<CNAResource> Resources { get; set; }
    }
}
