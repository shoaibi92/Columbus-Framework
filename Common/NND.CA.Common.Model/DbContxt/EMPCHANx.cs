namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPCHANGES")]
    public partial class EMPCHANx
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string DESCR { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        [StringLength(200)]
        public string USERDATA { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
