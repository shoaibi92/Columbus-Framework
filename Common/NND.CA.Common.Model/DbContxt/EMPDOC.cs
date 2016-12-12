namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPDOCS")]
    public partial class EMPDOC
    {
        [Key]
        [StringLength(14)]
        public string EMPDOC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DOCTYPE_ID { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        public DateTime? DOCDATE { get; set; }

        [StringLength(255)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string DEFDOC { get; set; }

        [StringLength(60)]
        public string REFVALUE { get; set; }

        [StringLength(20)]
        public string RECTYPE { get; set; }

        [StringLength(200)]
        public string RECNAME { get; set; }

        public DateTime? RECDATE { get; set; }

        public int? RECSIZE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DOCTYPE DOCTYPE { get; set; }

        public virtual EMPFOLDER EMPFOLDER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual EMPDOCSX EMPDOCSX { get; set; }
    }
}
