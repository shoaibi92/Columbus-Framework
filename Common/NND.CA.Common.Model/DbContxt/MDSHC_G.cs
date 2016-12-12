namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_G
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(14)]
        public string G_1_PRI_ID { get; set; }

        [StringLength(1)]
        public string G_1E_PRILIVES { get; set; }

        [StringLength(1)]
        public string G_1F_PRIREL { get; set; }

        [StringLength(6)]
        public string G_1_PRIHELP { get; set; }

        [StringLength(14)]
        public string G_1_SEC_ID { get; set; }

        [StringLength(1)]
        public string G_1E_SECLIVES { get; set; }

        [StringLength(1)]
        public string G_1F_SECREL { get; set; }

        [StringLength(6)]
        public string G_1_SECHELP { get; set; }

        [StringLength(4)]
        public string G_2_CARESTATUS { get; set; }

        public decimal? G_3A_WEEKDAYS { get; set; }

        public decimal? G_3B_WEEKENDS { get; set; }

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
        public string G_1AA_LASTNAME { get; set; }

        [StringLength(20)]
        public string G_1AB_FIRSTNAME { get; set; }

        [StringLength(30)]
        public string G_1A_TYPE { get; set; }

        [StringLength(30)]
        public string G_1BC_LASTNAME { get; set; }

        [StringLength(20)]
        public string G_1BD_FIRSTNAME { get; set; }

        [StringLength(30)]
        public string G_1B_TYPE { get; set; }

        public virtual INFCONTACT INFCONTACT { get; set; }

        public virtual INFCONTACT INFCONTACT1 { get; set; }

        public virtual MD MD { get; set; }
    }
}
