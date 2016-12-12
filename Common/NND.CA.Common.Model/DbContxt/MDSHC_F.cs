namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_F
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(2)]
        public string F_1_INVOLVE { get; set; }

        [StringLength(1)]
        public string F_2_CHANGE { get; set; }

        [StringLength(2)]
        public string F_3_ISOLATION { get; set; }

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
