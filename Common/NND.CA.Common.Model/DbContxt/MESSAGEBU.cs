namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSAGEBUS")]
    public partial class MESSAGEBU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MESSAGEBU()
        {
            MESSAGEBUSSUBS = new HashSet<MESSAGEBUSSUB>();
        }

        [Key]
        [StringLength(14)]
        public string MESSAGE_ID { get; set; }

        public int MESSAGETYPE { get; set; }

        public int CHANNELTYPE { get; set; }

        [Required]
        [StringLength(40)]
        public string MESSAGESOURCE { get; set; }

        [StringLength(40)]
        public string MESSAGETARGET { get; set; }

        [Required]
        [StringLength(60)]
        public string MESSAGEHEADER { get; set; }

        public int MESSAGESTATE { get; set; }

        public DateTime MESSAGEDATE { get; set; }

        public DateTime INTAKEDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? STATEDATE { get; set; }

        [StringLength(255)]
        public string STATEUSER { get; set; }

        public DateTime? UTCINTAKEDATE { get; set; }

        public DateTime? UTCSTATEDATE { get; set; }

        public DateTime? UTCMESSAGEDATE { get; set; }

        public virtual MESSAGEBUSDETAIL MESSAGEBUSDETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MESSAGEBUSSUB> MESSAGEBUSSUBS { get; set; }
    }
}
