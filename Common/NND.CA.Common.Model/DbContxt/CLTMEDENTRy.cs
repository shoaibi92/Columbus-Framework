namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTMEDENTRIES")]
    public partial class CLTMEDENTRy
    {
        [Key]
        [StringLength(14)]
        public string CLTMEDENTRY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLTMED_ID { get; set; }

        [StringLength(20)]
        public string DOSAGE { get; set; }

        [StringLength(30)]
        public string DOSSTR { get; set; }

        [StringLength(30)]
        public string DOSUNITS { get; set; }

        [StringLength(20)]
        public string FREQUENCY { get; set; }

        [StringLength(20)]
        public string ROUTE { get; set; }

        public DateTime? TIME_GIVEN { get; set; }

        [StringLength(30)]
        public string ADMINBY { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [StringLength(20)]
        public string ADMINSITE { get; set; }

        [StringLength(1)]
        public string ADMINISTERED { get; set; }

        [StringLength(80)]
        public string ADMINCOMMENTS { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual CLTMED CLTMED { get; set; }
    }
}
