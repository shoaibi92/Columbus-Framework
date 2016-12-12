namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATEDNOTES")]
    public partial class DATEDNOTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATEDNOTE()
        {
            CLNTNOTES = new HashSet<CLNTNOTE>();
            CONNOTES = new HashSet<CONNOTE>();
            EMPLNOTES = new HashSet<EMPLNOTE>();
            NOTEPROGRESSes = new HashSet<NOTEPROGRESS>();
            SPCNTTYPEs = new HashSet<SPCNTTYPE>();
        }

        [Key]
        [StringLength(14)]
        public string NOTE_ID { get; set; }

        public DateTime? NOTEDATE { get; set; }

        public DateTime? DATE_IN { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        [Column(TypeName = "text")]
        public string CONTENTS { get; set; }

        [StringLength(255)]
        public string ENTRYBY { get; set; }

        public DateTime? TIME_IN { get; set; }

        [StringLength(30)]
        public string NOTESTATUS { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? REPORTDATE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTNOTE> CLNTNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONNOTE> CONNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLNOTE> EMPLNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTEPROGRESS> NOTEPROGRESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPCNTTYPE> SPCNTTYPEs { get; set; }
    }
}
