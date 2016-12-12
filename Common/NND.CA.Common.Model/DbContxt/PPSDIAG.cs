namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PPSDIAGS")]
    public partial class PPSDIAG
    {
        [Key]
        [StringLength(10)]
        public string DIAGCODE { get; set; }

        [Required]
        [StringLength(5)]
        public string DG { get; set; }

        [Required]
        [StringLength(1)]
        public string ALLOWPRIMARY { get; set; }
    }
}
