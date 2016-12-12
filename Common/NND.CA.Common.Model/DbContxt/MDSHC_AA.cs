namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_AA
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(1)]
        public string AA_3A_HEALTHNUM { get; set; }

        [StringLength(3)]
        public string AA_3B_PROV { get; set; }

        [StringLength(12)]
        public string AA_4_POSTAL { get; set; }

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

        [StringLength(30)]
        public string AA_1_LASTNAME { get; set; }

        [StringLength(20)]
        public string AA_1_FIRSTNAME { get; set; }

        [StringLength(20)]
        public string AA_1_MIDDLENAME { get; set; }

        [StringLength(20)]
        public string AA_2_CASERECORD { get; set; }

        [StringLength(20)]
        public string AA_3A_HEALTHNUMVALUE { get; set; }

        [StringLength(1)]
        public string AA_4_POSTAL_FLAG { get; set; }

        public virtual MD MD { get; set; }
    }
}
