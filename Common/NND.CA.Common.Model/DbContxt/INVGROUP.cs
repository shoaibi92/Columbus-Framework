namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVGROUPS")]
    public partial class INVGROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVGROUP()
        {
            FUNDDEPTs = new HashSet<FUNDDEPT>();
        }

        [Key]
        [StringLength(14)]
        public string INVGROUP_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public int STARTINV { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string SPECIALGRP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }
    }
}
