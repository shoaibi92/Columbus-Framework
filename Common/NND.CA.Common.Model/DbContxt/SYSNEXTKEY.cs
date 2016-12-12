namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSNEXTKEYS")]
    public partial class SYSNEXTKEY
    {
        [Key]
        [StringLength(50)]
        public string KEYTABLENAME { get; set; }

        public int NEXTKEYVALUE { get; set; }
    }
}
