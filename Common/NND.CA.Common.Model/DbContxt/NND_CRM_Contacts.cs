namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CRM_Contacts
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Contact_ID { get; set; }

        public int? ContactType_ID { get; set; }

        [StringLength(10)]
        public string Salutation { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(12)]
        public string HomePhone { get; set; }

        [StringLength(12)]
        public string WorkPhone { get; set; }

        [StringLength(12)]
        public string CellPhone { get; set; }

        [StringLength(40)]
        public string Address { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(3)]
        public string ProvState { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(30)]
        public string Region { get; set; }

        [StringLength(1)]
        public string FileStatus { get; set; }

        [StringLength(500)]
        public string SecretService { get; set; }

        public DateTime? RecordUpdatedOn { get; set; }
    }
}
