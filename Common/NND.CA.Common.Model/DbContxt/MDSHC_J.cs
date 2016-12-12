namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_J
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(6)]
        public string J_1_HEART { get; set; }

        [StringLength(6)]
        public string J_1_NEURO { get; set; }

        [StringLength(4)]
        public string J_1_MUSCULO { get; set; }

        [StringLength(2)]
        public string J_1_SENSES { get; set; }

        [StringLength(1)]
        public string J_1_MOOD { get; set; }

        [StringLength(4)]
        public string J_1_INFECTIONS { get; set; }

        [StringLength(6)]
        public string J_1_OTHER { get; set; }

        [StringLength(10)]
        public string J_2A_DIAGCODE { get; set; }

        [StringLength(10)]
        public string J_2B_DIAGCODE { get; set; }

        [StringLength(10)]
        public string J_2C_DIAGCODE { get; set; }

        [StringLength(10)]
        public string J_2D_DIAGCODE { get; set; }

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
