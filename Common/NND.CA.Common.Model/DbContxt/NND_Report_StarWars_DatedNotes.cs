namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_StarWars_DatedNotes
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string Note_ID { get; set; }

        public string DNType { get; set; }

        [StringLength(255)]
        public string ENTRYBY { get; set; }

        public DateTime? ChgDate { get; set; }

        public DateTime? NoteDate { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        public DateTime? Date_IN { get; set; }

        public DateTime? Time_In { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string Client_ID { get; set; }
    }
}
