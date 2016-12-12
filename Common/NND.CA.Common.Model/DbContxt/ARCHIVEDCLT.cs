namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARCHIVEDCLTS")]
    public partial class ARCHIVEDCLT
    {
        [Key]
        [StringLength(14)]
        public string AARCHIVE_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ALASTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string AFIRSTNAME { get; set; }

        [StringLength(20)]
        public string AMIDDLENAME { get; set; }

        public DateTime? ABIRTHDATE { get; set; }

        public DateTime AARCHIVEDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string AARCHIVEUSER { get; set; }

        [StringLength(10)]
        public string ADBVERSION { get; set; }

        [Required]
        [StringLength(14)]
        public string ACLIENT_ID { get; set; }

        [StringLength(255)]
        public string ACOMMENTS { get; set; }
    }
}
