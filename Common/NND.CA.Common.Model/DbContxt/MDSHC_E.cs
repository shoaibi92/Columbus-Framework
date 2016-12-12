namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_E
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(9)]
        public string E_1_DEPRESSED { get; set; }

        [StringLength(1)]
        public string E_2_MOODDECLINE { get; set; }

        [StringLength(5)]
        public string E_3_BEHAVIOR { get; set; }

        [StringLength(1)]
        public string E_4_CHANGES { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(255)]
        public string STATUSUSER { get; set; }

        public DateTime STATUSDATE { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual MD MD { get; set; }
    }
}
