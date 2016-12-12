namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLTABLES")]
    public partial class BILLTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLTABLE()
        {
            BILLRECS = new HashSet<BILLREC>();
            DEPTBILLTABLES = new HashSet<DEPTBILLTABLE>();
            FUNDDEPTs = new HashSet<FUNDDEPT>();
        }

        [Key]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTBILLTABLE> DEPTBILLTABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }
    }
}
