namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_NPIListen360Clients
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string Dept_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string Client_ID { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(30)]
        public string PERM_CITY { get; set; }

        [StringLength(10)]
        public string PERM_POST { get; set; }

        [StringLength(3)]
        public string PERM_PROV { get; set; }

        [StringLength(12)]
        public string HomePhone { get; set; }

        [StringLength(40)]
        public string PermAddr_1 { get; set; }

        [StringLength(30)]
        public string PERM_CNTRY { get; set; }

        [Column("Job Unique Reference")]
        [StringLength(14)]
        public string Job_Unique_Reference { get; set; }

        [Key]
        [Column("Job Date", Order = 4)]
        public DateTime Job_Date { get; set; }

        [Key]
        [Column("Technician Name", Order = 5)]
        [StringLength(1)]
        public string Technician_Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(13)]
        public string Source { get; set; }

        [Key]
        [Column("Platinum Service", Order = 7)]
        [StringLength(1)]
        public string Platinum_Service { get; set; }

        public decimal? Revenue { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string RevenueCat { get; set; }

        public bool? Archived { get; set; }

        [StringLength(50)]
        public string ArchiveReason { get; set; }

        public DateTime? ArchiveDate { get; set; }

        [StringLength(50)]
        public string txtHTLastUpdate { get; set; }

        [StringLength(10)]
        public string HTStatusCode { get; set; }

        public DateTime? LastListen360UploadedDate { get; set; }
    }
}
