namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_ErrorLookup
    {
        [Key]
        public int UID { get; set; }

        public int? ErrorID { get; set; }

        [StringLength(250)]
        public string ErrorDescription { get; set; }
    }
}
