namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_EmployeeUsers
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string dept_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string LASTNAME { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        public DateTime? EmpIntakeDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(20)]
        public string EmpCatName { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CallMeUser { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsCorpUser { get; set; }
    }
}
