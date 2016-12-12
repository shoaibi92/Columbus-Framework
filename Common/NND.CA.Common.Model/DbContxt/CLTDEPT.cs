namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTDEPT")]
    public partial class CLTDEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTDEPT()
        {
            CLNTRESORCs = new HashSet<CLNTRESORC>();
            CLTSERVS = new HashSet<CLTSERV>();
            CLTSTATES = new HashSet<CLTSTATE>();
            CLTSUPERS = new HashSet<CLTSUPER>();
            CLTSUPREQs = new HashSet<CLTSUPREQ>();
            ORDERS = new HashSet<ORDER>();
            SCHGROUPCLTS = new HashSet<SCHGROUPCLT>();
            USERVIPCLIENTS = new HashSet<USERVIPCLIENT>();
            VISITS = new HashSet<VISIT>();
            EMPCATS = new HashSet<EMPCAT>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTVISITOR_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(1)]
        public string CLTCONFIRM { get; set; }

        public DateTime? STARTDATE { get; set; }

        [StringLength(14)]
        public string DEFORDER { get; set; }

        public DateTime? TERMDATE { get; set; }

        public DateTime? DELDATE { get; set; }

        public DateTime? DISDATE { get; set; }

        public DateTime? DISREVDATE { get; set; }

        public DateTime? LVISDATE { get; set; }

        public DateTime? LSUPERVIS { get; set; }

        public DateTime? NEXTDATE { get; set; }

        [StringLength(1)]
        public string TRANSPAY { get; set; }

        [StringLength(1)]
        public string TRANSTIME { get; set; }

        [StringLength(1)]
        public string TRACKHRS { get; set; }

        [StringLength(1)]
        public string TRACKHRWKD { get; set; }

        [StringLength(1)]
        public string TRACKVISIT { get; set; }

        [StringLength(1)]
        public string TRKEMPPAY { get; set; }

        [StringLength(1)]
        public string DEBITLEAVE { get; set; }

        [StringLength(1)]
        public string TRACKATTND { get; set; }

        [StringLength(1)]
        public string DIRDEFHRS { get; set; }

        [StringLength(20)]
        public string COSTCENTRE { get; set; }

        [StringLength(2)]
        public string LEAVECODE { get; set; }

        [StringLength(30)]
        public string LEAVEDESCR { get; set; }

        [StringLength(30)]
        public string ATTENDCMT { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? EFFDATE { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        public DateTime? INTAKEDATE { get; set; }

        public DateTime? INTAKETIME { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string PENDING { get; set; }

        [StringLength(1)]
        public string PENDSTATUS { get; set; }

        [StringLength(40)]
        public string PENDREASON { get; set; }

        [StringLength(40)]
        public string PENDTEXT { get; set; }

        public DateTime? HELDSTART { get; set; }

        public DateTime? HELDSTOP { get; set; }

        public int? FREQUENCY { get; set; }

        [StringLength(10)]
        public string FREQUNITS { get; set; }

        [StringLength(1)]
        public string DISSTATUS { get; set; }

        [StringLength(14)]
        public string DISTRICT_ID { get; set; }

        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [StringLength(14)]
        public string DIETTYPE_ID { get; set; }

        [StringLength(14)]
        public string PACKAGE_ID { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [StringLength(10)]
        public string DEFSERVTYPE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string CHKCONFLICTS { get; set; }

        [StringLength(14)]
        public string CV_ID { get; set; }

        [StringLength(14)]
        public string NUMBER_ID { get; set; }

        [StringLength(1)]
        public string VIPCLIENT { get; set; }

        [StringLength(20)]
        public string DEPTRSOURCE { get; set; }

        public DateTime? DEPTRDATE { get; set; }

        [StringLength(20)]
        public string DEPTRREASON { get; set; }

        public DateTime? DEPTADMDATE { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTRESORC> CLNTRESORCs { get; set; }

        public virtual NUMBER NUMBER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual CLTVISITOR CLTVISITOR { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        public virtual DIETTYPE DIETTYPE { get; set; }

        public virtual MEALPACK MEALPACK { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSERV> CLTSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSTATE> CLTSTATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPER> CLTSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPREQ> CLTSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPCLT> SCHGROUPCLTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERVIPCLIENT> USERVIPCLIENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPCAT> EMPCATS { get; set; }
    }
}
