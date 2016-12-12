namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_ProcuraQbFPSetup
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string FPSystemUserName { get; set; }

        [StringLength(50)]
        public string FromEmailAddress { get; set; }

        [StringLength(50)]
        public string ToEmailAddress { get; set; }

        [StringLength(300)]
        public string ProcuraQBAttachmentFolder { get; set; }

        [StringLength(50)]
        public string smtpServer { get; set; }

        public bool? FinanceUser { get; set; }
    }
}
