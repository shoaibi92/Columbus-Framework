namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_NPIDNC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactID { get; set; }

        [StringLength(255)]
        public string txtFirstname { get; set; }

        [StringLength(255)]
        public string txtLastname { get; set; }

        [StringLength(50)]
        public string txtPhone { get; set; }

        [StringLength(255)]
        public string txtStreet { get; set; }

        [StringLength(50)]
        public string txtCity { get; set; }

        [StringLength(50)]
        public string txtProvince { get; set; }

        [StringLength(50)]
        public string txtPostal { get; set; }

        [StringLength(10)]
        public string HTStatusCode { get; set; }

        [StringLength(50)]
        public string HTContactID { get; set; }

        [StringLength(50)]
        public string CRMContactID { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int? ContactTypeID { get; set; }

        [StringLength(50)]
        public string txtHTLastUpdate { get; set; }

        public DateTime? LastCalled { get; set; }

        public bool? NoCall { get; set; }

        public bool? NNDDNC { get; set; }

        [StringLength(250)]
        public string NNDDNCReason { get; set; }

        [StringLength(20)]
        public string DEPT_ID { get; set; }

        public bool? Archived { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        public DateTime? NNDDNCDateStamp { get; set; }
    }
}
