namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBCOMPONENTS")]
    public partial class DBCOMPONENT
    {
        [Key]
        public int COMPSEQ { get; set; }

        [Required]
        [StringLength(200)]
        public string COMPNAME { get; set; }

        public int COMPVERSION { get; set; }

        public DateTime INTAKE { get; set; }
    }
}
