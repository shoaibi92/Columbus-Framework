namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_OnCallContactList
    {
        public int ID { get; set; }

        [StringLength(40)]
        public string OnCallPersonName { get; set; }

        [StringLength(16)]
        public string OnCallNumber { get; set; }

        public short? Priority { get; set; }
    }
}
