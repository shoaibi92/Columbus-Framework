namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_DatedNoteAlert
    {
        [Key]
        public int UID { get; set; }

        [StringLength(20)]
        public string AssignedUser { get; set; }

        [StringLength(50)]
        public string ClLocation { get; set; }

        [StringLength(250)]
        public string DNType { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(250)]
        public string EmpList { get; set; }

        public DateTime? DNChgDate { get; set; }

        [StringLength(10)]
        public string DNCHGUser { get; set; }

        [StringLength(100)]
        public string DNSubject { get; set; }

        [StringLength(14)]
        public string DNNote_ID { get; set; }

        public DateTime? DNNoteDate { get; set; }

        public DateTime? DNDate_IN { get; set; }

        [Column(TypeName = "text")]
        public string DNContents { get; set; }

        public DateTime? DNTime_In { get; set; }

        [StringLength(14)]
        public string ClDept_ID { get; set; }

        public int? BatchID { get; set; }

        public int? Hidden { get; set; }
    }
}
