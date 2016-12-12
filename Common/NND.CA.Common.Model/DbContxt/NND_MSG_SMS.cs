namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_SMS
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string MSGBody { get; set; }

        public DateTime? MSGSaveDateTime { get; set; }

        [StringLength(20)]
        public string MSGSentbyUser { get; set; }

        [StringLength(20)]
        public string DEPT_ID { get; set; }

        [StringLength(40)]
        public string NoProcuraIDCountry { get; set; }
    }
}
