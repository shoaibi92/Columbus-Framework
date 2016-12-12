namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_RPT_CallMeSignInCount
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [StringLength(50)]
        public string DateRange { get; set; }

        public int? SignInCount { get; set; }
    }
}
