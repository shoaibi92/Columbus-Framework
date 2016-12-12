namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSCONT")]
    public partial class MESSCONT
    {
        [Key]
        [StringLength(14)]
        public string MESS_ID { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(30)]
        public string NAME { get; set; }

        public int? SUGGLENGTH { get; set; }

        [StringLength(1)]
        public string USESUGG { get; set; }
    }
}
