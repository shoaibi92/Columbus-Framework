using System.ComponentModel.DataAnnotations;

namespace NND.CA.Common.Web.DBAccess
{
    public class GoogleDataModel
    {
        [Key]
        [Required]
        public string id { get; set; }
    }
}