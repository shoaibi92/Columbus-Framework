namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSERVS")]
    public partial class CLTSERV
    {
        [Key]
        [StringLength(14)]
        public string REQ_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SERV_ID { get; set; }

        [StringLength(1)]
        public string SERVTYPE { get; set; }

        public DateTime? ATTACHDATE { get; set; }

        public DateTime? ISSUEDATE { get; set; }

        [StringLength(20)]
        public string REFNUMBER { get; set; }

        [StringLength(1)]
        public string REQUIRED { get; set; }

        [Column(TypeName = "text")]
        public string DETDESCR { get; set; }

        [StringLength(1)]
        public string CHANGED { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        [StringLength(1)]
        public string SOURCE { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [StringLength(1)]
        public string DELEGATED { get; set; }

        public DateTime? DEFEXPDATE { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }

        public virtual SERVREQ SERVREQ { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
