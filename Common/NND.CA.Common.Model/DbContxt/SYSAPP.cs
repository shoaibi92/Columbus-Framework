namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSAPPS")]
    public partial class SYSAPP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYSAPP()
        {
            SYSAPPSDEPTs = new HashSet<SYSAPPSDEPT>();
            SYSAPPSLOGs = new HashSet<SYSAPPSLOG>();
        }

        [Key]
        [StringLength(14)]
        public string SYSAPP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(40)]
        public string APPNAME { get; set; }

        [Required]
        [StringLength(40)]
        public string APP_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string LICENSE_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string APPTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(200)]
        public string APPKEY { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string APPSETTINGS { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string SYSSETTINGS { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string LICENSES { get; set; }

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

        public DateTime? UTCAPPCHGDATE { get; set; }

        [StringLength(255)]
        public string EXTERNALUSERNAME { get; set; }

        [StringLength(128)]
        public string EXTERNALPASSWRD { get; set; }

        public virtual PORTALUSER PORTALUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSAPPSDEPT> SYSAPPSDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSAPPSLOG> SYSAPPSLOGs { get; set; }
    }
}
