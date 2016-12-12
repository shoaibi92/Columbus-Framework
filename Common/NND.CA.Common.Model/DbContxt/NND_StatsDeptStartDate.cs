namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_StatsDeptStartDate
    {
        public int ID { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        public DateTime? StartDate { get; set; }

        public double? GAFPerc { get; set; }

        public double? FPFeePerc1 { get; set; }

        public double? FPFeePerc2 { get; set; }

        public double? FPFeePerc3 { get; set; }

        public bool? DeptActive { get; set; }

        public DateTime? StartDateLegal { get; set; }
    }
}
