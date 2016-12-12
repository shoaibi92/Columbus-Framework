namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_I
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(2)]
        public string I_1_BLADDERCONT { get; set; }

        [StringLength(3)]
        public string I_2_BLADDERDEV { get; set; }

        [StringLength(1)]
        public string I_3_BOWELCONT { get; set; }

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
