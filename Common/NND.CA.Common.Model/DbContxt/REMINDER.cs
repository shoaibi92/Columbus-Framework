namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REMINDERS")]
    public partial class REMINDER
    {
        [Key]
        [StringLength(14)]
        public string REMIND_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        [StringLength(14)]
        public string NOTIFYUSER { get; set; }

        public DateTime? NOTIFYDATE { get; set; }

        public DateTime? NOTIFYTIME { get; set; }

        [StringLength(1)]
        public string PRIVATE { get; set; }

        [StringLength(14)]
        public string PRIVUSER { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        [Column(TypeName = "text")]
        public string DETAILS { get; set; }

        [StringLength(1)]
        public string REMINDTYPE { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }
    }
}
