namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLAIMBATCH")]
    public partial class CLAIMBATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLAIMBATCH()
        {
            BILLINVs = new HashSet<BILLINV>();
        }

        [Key]
        [StringLength(14)]
        public string CLAIMBATCH_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string BNAME { get; set; }

        [Required]
        [StringLength(10)]
        public string BTYPE { get; set; }

        [StringLength(40)]
        public string BFORMAT { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? SENTDATE { get; set; }

        [StringLength(255)]
        public string SENTUSER { get; set; }

        public DateTime? TRANSDATE { get; set; }

        [StringLength(255)]
        public string TRANSUSER { get; set; }

        public int? TOTALCLAIMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
