namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONSUBCATS")]
    public partial class CONSUBCAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string SUBCAT_ID { get; set; }

        [StringLength(30)]
        public string STRVAL { get; set; }

        public DateTime? DATEVAL { get; set; }

        [Column(TypeName = "text")]
        public string MEMOVAL { get; set; }

        [StringLength(30)]
        public string REFSTRVAL { get; set; }

        public DateTime? REFDATEVAL { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual SUBCATEGORY SUBCATEGORY { get; set; }
    }
}
