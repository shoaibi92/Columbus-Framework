namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_P
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        public int? P_1A_DAYS { get; set; }

        public int? P_1A_HRS { get; set; }

        public int? P_1A_MINS { get; set; }

        public int? P_1B_DAYS { get; set; }

        public int? P_1B_HRS { get; set; }

        public int? P_1B_MINS { get; set; }

        public int? P_1C_DAYS { get; set; }

        public int? P_1C_HRS { get; set; }

        public int? P_1C_MINS { get; set; }

        public int? P_1D_DAYS { get; set; }

        public int? P_1D_HRS { get; set; }

        public int? P_1D_MINS { get; set; }

        public int? P_1E_DAYS { get; set; }

        public int? P_1E_HRS { get; set; }

        public int? P_1E_MINS { get; set; }

        public int? P_1F_DAYS { get; set; }

        public int? P_1F_HRS { get; set; }

        public int? P_1F_MINS { get; set; }

        public int? P_1G_DAYS { get; set; }

        public int? P_1G_HRS { get; set; }

        public int? P_1G_MINS { get; set; }

        public int? P_1H_DAYS { get; set; }

        public int? P_1H_HRS { get; set; }

        public int? P_1H_MINS { get; set; }

        public int? P_1I_DAYS { get; set; }

        public int? P_1I_HRS { get; set; }

        public int? P_1I_MINS { get; set; }

        public int? P_1J_DAYS { get; set; }

        public int? P_1J_HRS { get; set; }

        public int? P_1J_MINS { get; set; }

        [StringLength(27)]
        public string P_2_SPECIAL { get; set; }

        [StringLength(4)]
        public string P_3_EQUIP { get; set; }

        [StringLength(3)]
        public string P_4_VISITS { get; set; }

        [StringLength(1)]
        public string P_5_GOALS { get; set; }

        [StringLength(1)]
        public string P_6_CHANGENEED { get; set; }

        [StringLength(1)]
        public string P_7_TRADEOFFS { get; set; }

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
