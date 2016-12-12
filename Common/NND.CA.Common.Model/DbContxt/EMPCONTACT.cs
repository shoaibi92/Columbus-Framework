namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPCONTACTS")]
    public partial class EMPCONTACT
    {
        [Key]
        [StringLength(14)]
        public string CONTACT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(30)]
        public string TYPE { get; set; }

        [StringLength(10)]
        public string RELATION { get; set; }

        [Required]
        [StringLength(30)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(40)]
        public string ADDRESS_2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(12)]
        public string WORK_PHONE { get; set; }

        [StringLength(10)]
        public string EXT { get; set; }

        [StringLength(12)]
        public string HOME_PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(12)]
        public string CELLPHONE { get; set; }

        [StringLength(12)]
        public string PAGERNUM { get; set; }

        [StringLength(12)]
        public string VOICEMAIL { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
