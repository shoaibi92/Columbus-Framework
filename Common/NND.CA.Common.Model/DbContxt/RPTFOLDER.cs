namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTFOLDERS")]
    public partial class RPTFOLDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RPTFOLDER()
        {
            RPTUSERFOLDs = new HashSet<RPTUSERFOLD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RFOLDER_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string RFOLDERNAME { get; set; }

        public int RPARENT_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RPTUSERFOLD> RPTUSERFOLDs { get; set; }
    }
}
