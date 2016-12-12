namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallMeUserStatus
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string UserName { get; set; }

        public DateTime? LatestLoggedInDateTimeStamp { get; set; }
    }
}
