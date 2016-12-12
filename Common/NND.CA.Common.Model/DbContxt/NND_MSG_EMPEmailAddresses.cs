namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_EMPEmailAddresses
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        [StringLength(20)]
        public string ByUser { get; set; }
    }
}
