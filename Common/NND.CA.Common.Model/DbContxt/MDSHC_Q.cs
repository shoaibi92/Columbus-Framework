namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_Q
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(1)]
        public string Q_1_NUMMEDS { get; set; }

        [StringLength(4)]
        public string Q_2_PHYCHO { get; set; }

        [StringLength(1)]
        public string Q_3_OVERSIGHT { get; set; }

        [StringLength(1)]
        public string Q_4_ADHERENCE { get; set; }

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
