namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPTSTATUS")]
    public partial class DEPTSTATU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string STATUSCODE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string RECCLASS { get; set; }

        [Required]
        [StringLength(20)]
        public string STATUSNAME { get; set; }

        [Required]
        [StringLength(40)]
        public string STATUSDESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string NOFREEFORM { get; set; }

        [Required]
        [StringLength(1)]
        public string AUTOORDERS { get; set; }

        [Required]
        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(14)]
        public string TYPE_ID { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(1)]
        public string RECTYPE2 { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID2 { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual LOOKUP LOOKUP1 { get; set; }

        public virtual NOTETYPE NOTETYPE { get; set; }
    }
}
