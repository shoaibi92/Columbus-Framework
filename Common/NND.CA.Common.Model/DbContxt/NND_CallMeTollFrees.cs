namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallMeTollFrees
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(15)]
        public string TollFree { get; set; }

        [StringLength(50)]
        public string DesignComment { get; set; }

        public short? TimeZoneDifference { get; set; }

        public byte? DST { get; set; }

        public double? TimeDifference { get; set; }

        [StringLength(2)]
        public string StateProv { get; set; }

        [StringLength(100)]
        public string IntakeNumber { get; set; }

        [StringLength(100)]
        public string AdminNumber { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(25)]
        public string Partner1Firstname { get; set; }

        [StringLength(25)]
        public string Partner1LastName { get; set; }

        [StringLength(25)]
        public string Partner2Firstname { get; set; }

        [StringLength(25)]
        public string Partner2LastName { get; set; }

        [StringLength(40)]
        public string Partner1Email { get; set; }

        [StringLength(40)]
        public string Partner2Email { get; set; }

        [StringLength(30)]
        public string CSCDepartmentGrouping { get; set; }

        [StringLength(30)]
        public string Region { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        public bool? DashboardConsultCountActive { get; set; }

        public DateTime? WeDoFPIntakesFromDate { get; set; }

        [StringLength(400)]
        public string Partner1PicFileName { get; set; }

        [StringLength(400)]
        public string Partner2PicFileName { get; set; }
    }
}
