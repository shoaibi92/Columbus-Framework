namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_REPORT_DeptPostalCodes
    {
        [Key]
        [StringLength(20)]
        public string DepartmentName { get; set; }

        [StringLength(50)]
        public string TerritoryName { get; set; }

        [StringLength(5)]
        public string FSA { get; set; }
    }
}
