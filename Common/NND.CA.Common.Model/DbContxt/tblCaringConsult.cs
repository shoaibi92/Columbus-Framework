namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCaringConsult
    {
        [Key]
        [Column("Intakes Responsibility", Order = 0)]
        [StringLength(18)]
        public string Intakes_Responsibility { get; set; }

        [StringLength(20)]
        public string DEPTNAME { get; set; }

        public string DNType { get; set; }

        [StringLength(255)]
        public string ENTRYBY { get; set; }

        public DateTime? ChgDate { get; set; }

        public DateTime? NoteDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string Referral { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        public DateTime? Date_IN { get; set; }

        public DateTime? Time_In { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }
    }
}
