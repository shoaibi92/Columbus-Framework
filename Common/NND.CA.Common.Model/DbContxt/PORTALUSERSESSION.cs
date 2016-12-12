namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALUSERSESSIONS")]
    public partial class PORTALUSERSESSION
    {
        [Key]
        [StringLength(14)]
        public string SESSION_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string USERHASH { get; set; }

        [Required]
        [StringLength(255)]
        public string USERTOKEN { get; set; }

        public DateTime UTCEXPDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string APPSETTINGS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DATA { get; set; }

        public virtual PORTALUSER PORTALUSER { get; set; }
    }
}
