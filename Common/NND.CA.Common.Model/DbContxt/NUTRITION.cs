namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NUTRITIONS")]
    public partial class NUTRITION
    {
        [Key]
        [StringLength(14)]
        public string NUTR_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime? RECORDDATE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(10)]
        public string FUNCTCODE { get; set; }

        [StringLength(25)]
        public string FUNCDESCR { get; set; }

        [StringLength(10)]
        public string INFCODE { get; set; }

        [StringLength(25)]
        public string SUPPDESCR { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string FURTHEVAL { get; set; }

        [StringLength(20)]
        public string TYPE { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? HISTDATE { get; set; }

        [StringLength(30)]
        public string HISTOUTCOM { get; set; }

        [StringLength(20)]
        public string HISTCODE { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
