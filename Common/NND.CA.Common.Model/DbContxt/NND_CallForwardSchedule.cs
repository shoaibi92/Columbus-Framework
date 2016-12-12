namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallForwardSchedule
    {
        public int ID { get; set; }

        [StringLength(3)]
        public string AutoCallForwardDay { get; set; }

        public DateTime? AutoCallForwardStartTime { get; set; }

        [StringLength(60)]
        public string AutoCallForwardPerson { get; set; }

        [StringLength(14)]
        public string AutoCallForwardNumber { get; set; }

        public bool? AutoCallEnable { get; set; }

        public DateTime? TimeStamp { get; set; }

        [StringLength(14)]
        public string NightShiftOnCallNumber { get; set; }

        public bool? NightShiftOnCallActive { get; set; }

        [StringLength(60)]
        public string NightShiftOnCallPerson { get; set; }
    }
}
