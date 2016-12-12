namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LBRGRPS")]
    public partial class LBRGRP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string GROUP_TYPE { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }
    }
}
