namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SQLtracePOCDec172013
    {
        [Key]
        public int RowNumber { get; set; }

        public int? EventClass { get; set; }

        [Column(TypeName = "ntext")]
        public string TextData { get; set; }

        [StringLength(128)]
        public string ApplicationName { get; set; }

        [StringLength(128)]
        public string NTUserName { get; set; }

        [StringLength(128)]
        public string LoginName { get; set; }

        public int? CPU { get; set; }

        public long? Reads { get; set; }

        public long? Writes { get; set; }

        public long? Duration { get; set; }

        public int? ClientProcessID { get; set; }

        public int? SPID { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
