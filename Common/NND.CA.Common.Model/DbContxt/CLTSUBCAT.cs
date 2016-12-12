namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSUBCATS")]
    public partial class CLTSUBCAT
    {
        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SUBCAT_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(30)]
        public string STRVAL { get; set; }

        public DateTime? DATEVAL { get; set; }

        [Column(TypeName = "text")]
        public string MEMOVAL { get; set; }

        [StringLength(30)]
        public string REFSTRVAL { get; set; }

        public DateTime? REFDATEVAL { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [Key]
        [StringLength(14)]
        public string CLTSUBCAT_ID { get; set; }

        [StringLength(1)]
        public string PRIMARYSUBCAT { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual SUBCATEGORY SUBCATEGORY { get; set; }
    }
}
