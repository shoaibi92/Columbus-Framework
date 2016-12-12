namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LABORAGREE")]
    public partial class LABORAGREE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LABORAGREE()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
            DEPTAGREEs = new HashSet<DEPTAGREE>();
            LBREMPCATS = new HashSet<LBREMPCAT>();
            LBRPAYTABS = new HashSet<LBRPAYTAB>();
            LBRSTATS = new HashSet<LBRSTAT>();
        }

        [Key]
        [StringLength(14)]
        public string AGREE_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [StringLength(14)]
        public string STATUS_ID { get; set; }

        [StringLength(14)]
        public string EMPGRP_ID { get; set; }

        [StringLength(14)]
        public string GROUPTYPE { get; set; }

        [StringLength(30)]
        public string LASTNAME { get; set; }

        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(20)]
        public string TITLE { get; set; }

        [StringLength(40)]
        public string ADDRESS { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(40)]
        public string EMAIL { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        public DateTime? DEALDATE { get; set; }

        public int? WEEKSTART { get; set; }

        public DateTime? DAYSTART { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTAGREE> DEPTAGREEs { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL2 { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBREMPCAT> LBREMPCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRPAYTAB> LBRPAYTABS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRSTAT> LBRSTATS { get; set; }
    }
}
