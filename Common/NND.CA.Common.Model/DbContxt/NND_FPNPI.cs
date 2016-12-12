namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FPNPI
    {
        public int ID { get; set; }

        public DateTime? NPIDate { get; set; }

        public int? FPNPIScore { get; set; }
    }
}
