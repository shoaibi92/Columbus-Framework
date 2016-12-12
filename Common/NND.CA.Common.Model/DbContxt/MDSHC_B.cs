namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_B
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(2)]
        public string B_1_MEMORY { get; set; }

        [StringLength(2)]
        public string B_2_COGSKILLS { get; set; }

        [StringLength(2)]
        public string B_3_DELIRIUM { get; set; }

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
