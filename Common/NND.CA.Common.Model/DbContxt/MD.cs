namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDS")]
    public partial class MD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MD()
        {
            MDSHCCAPS = new HashSet<MDSHCCAP>();
            MDSLOGs = new HashSet<MDSLOG>();
            MDSNOTES = new HashSet<MDSNOTE>();
            CLTMEDS = new HashSet<CLTMED>();
        }

        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(255)]
        public string STATUSUSER { get; set; }

        public DateTime STATUSDATE { get; set; }

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

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [StringLength(14)]
        public string STATUSREASON_ID { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual CLTFOLDER CLTFOLDER { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual MDSHC_A MDSHC_A { get; set; }

        public virtual MDSHC_AA MDSHC_AA { get; set; }

        public virtual MDSHC_B MDSHC_B { get; set; }

        public virtual MDSHC_BB MDSHC_BB { get; set; }

        public virtual MDSHC_C MDSHC_C { get; set; }

        public virtual MDSHC_CC MDSHC_CC { get; set; }

        public virtual MDSHC_D MDSHC_D { get; set; }

        public virtual MDSHC_E MDSHC_E { get; set; }

        public virtual MDSHC_F MDSHC_F { get; set; }

        public virtual MDSHC_G MDSHC_G { get; set; }

        public virtual MDSHC_H MDSHC_H { get; set; }

        public virtual MDSHC_I MDSHC_I { get; set; }

        public virtual MDSHC_J MDSHC_J { get; set; }

        public virtual MDSHC_K MDSHC_K { get; set; }

        public virtual MDSHC_L MDSHC_L { get; set; }

        public virtual MDSHC_M MDSHC_M { get; set; }

        public virtual MDSHC_N MDSHC_N { get; set; }

        public virtual MDSHC_O MDSHC_O { get; set; }

        public virtual MDSHC_P MDSHC_P { get; set; }

        public virtual MDSHC_Q MDSHC_Q { get; set; }

        public virtual MDSHC_X MDSHC_X { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSHCCAP> MDSHCCAPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSLOG> MDSLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSNOTE> MDSNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMED> CLTMEDS { get; set; }
    }
}
