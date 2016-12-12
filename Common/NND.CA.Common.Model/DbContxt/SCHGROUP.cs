namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHGROUPS")]
    public partial class SCHGROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHGROUP()
        {
            DEPTSCHGROUPS = new HashSet<DEPTSCHGROUP>();
            SCHGROUPCLTS = new HashSet<SCHGROUPCLT>();
            SCHGROUPEMPS = new HashSet<SCHGROUPEMP>();
            VISITS = new HashSet<VISIT>();
            WFALERTTASKS = new HashSet<WFALERTTASK>();
        }

        [Key]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string RECCLASS { get; set; }

        [Required]
        [StringLength(80)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string SCHEDGROUP { get; set; }

        [StringLength(20)]
        public string SCHEDSUBGROUP { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(10)]
        public string EXT { get; set; }

        [StringLength(40)]
        public string ADDR1 { get; set; }

        [StringLength(40)]
        public string ADDR2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROV { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [Column(TypeName = "text")]
        public string DIRECTIONS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(80)]
        public string LOCATION { get; set; }

        [StringLength(30)]
        public string FFLOOR { get; set; }

        [StringLength(30)]
        public string FWARD { get; set; }

        [StringLength(30)]
        public string FUNIT { get; set; }

        [StringLength(30)]
        public string FROOM { get; set; }

        [StringLength(1)]
        public string BUDGETUNITS { get; set; }

        public decimal? BUDGETYEAR { get; set; }

        public decimal? BUDGETMONTH { get; set; }

        public decimal? BUDGETWEEK { get; set; }

        public decimal? BUDGETDAY { get; set; }

        [StringLength(14)]
        public string EMP_ID1 { get; set; }

        [StringLength(14)]
        public string EMP_ID2 { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string CLTDEFPAY { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(1)]
        public string CLTDEFBILL { get; set; }

        [StringLength(1)]
        public string CLTDEFDIR { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSCHGROUP> DEPTSCHGROUPS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual EMPLOYEE EMPLOYEE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPCLT> SCHGROUPCLTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPEMP> SCHGROUPEMPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS { get; set; }
    }
}
