namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_PlannerAlert
    {
        [Key]
        public int UID { get; set; }

        [StringLength(20)]
        public string AssignedUser { get; set; }

        [StringLength(3)]
        public string DayName { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(10)]
        public string Dur { get; set; }

        public DateTime? VisitStart { get; set; }

        [StringLength(25)]
        public string VisitType { get; set; }

        [StringLength(14)]
        public string Planner_ID { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        [StringLength(14)]
        public string emp_ID { get; set; }

        public int? BatchID { get; set; }

        public int? Hidden { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(3)]
        public string ProvState { get; set; }

        public double? DurNumeric { get; set; }

        [StringLength(50)]
        public string ClientFirstName { get; set; }

        [StringLength(50)]
        public string CSCDepartmentGrouping { get; set; }

        [StringLength(255)]
        public string VisitIntakeUser { get; set; }

        public DateTime? VisitIntake { get; set; }

        [StringLength(255)]
        public string VisitChgUser { get; set; }

        public DateTime? VisitChgDate { get; set; }
    }
}
