namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIMEDUTY")]
    public partial class TIMEDUTY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime TIMEDATE { get; set; }

        [StringLength(14)]
        public string EMPCAT_ID { get; set; }

        [StringLength(1)]
        public string ON_CALL { get; set; }

        public decimal? VNDAY { get; set; }

        public decimal? VNEVENING { get; set; }

        public decimal? VNNIGHT { get; set; }

        public decimal? OFFPLAN { get; set; }

        public decimal? OFFSUPER { get; set; }

        public decimal? ADMIN { get; set; }

        public decimal? CHUPDATES { get; set; }

        public decimal? PHYCONTACT { get; set; }

        public decimal? PATCONFER { get; set; }

        public decimal? WHCREPORTS { get; set; }

        public decimal? VHCREPORTS { get; set; }

        public decimal? CONFHC { get; set; }

        public decimal? EDUORIENT { get; set; }

        public decimal? EDUSPECIAL { get; set; }

        public decimal? EDUINSERV { get; set; }

        public decimal? EDUOTHER { get; set; }

        public decimal? TEAMMEET { get; set; }

        public decimal? TRAVELTIME { get; set; }

        public decimal? COMMINTER { get; set; }

        public decimal? COMMCOMM { get; set; }

        public decimal? COMMSTUD { get; set; }

        public decimal? VOLCOMM { get; set; }

        public decimal? COMMPAID { get; set; }

        public decimal? ONCALLWAIT { get; set; }

        public decimal? PAYHOURS { get; set; }

        public decimal? HOMEMAKING { get; set; }

        public decimal? OTHERTIME { get; set; }

        public decimal? ONCALLOUT { get; set; }

        public virtual EMPCAT EMPCAT { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }
    }
}
