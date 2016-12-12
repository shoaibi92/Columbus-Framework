namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOOKUPVALS")]
    public partial class LOOKUPVAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOOKUPVAL()
        {
            ASSESSMDS = new HashSet<ASSESSMD>();
            ASSESSMENTS = new HashSet<ASSESSMENT>();
            ASSESSOASIS = new HashSet<ASSESSOASI>();
            ASSESSRAIs = new HashSet<ASSESSRAI>();
            ASSQMDSHCDEPENDS = new HashSet<ASSQMDSHCDEPEND>();
            ASSSECTS = new HashSet<ASSSECT>();
            ASSSECTS1 = new HashSet<ASSSECT>();
            AUTOORDPLANs = new HashSet<AUTOORDPLAN>();
            AUTOORDPLANSERVS = new HashSet<AUTOORDPLANSERV>();
            BILLRECVALs = new HashSet<BILLRECVAL>();
            CLTATTRIBs = new HashSet<CLTATTRIB>();
            CLTLANGs = new HashSet<CLTLANG>();
            CLTRULES = new HashSet<CLTRULE>();
            CLTSUPERS = new HashSet<CLTSUPER>();
            CLTSUPREQs = new HashSet<CLTSUPREQ>();
            CLTSUPREQs1 = new HashSet<CLTSUPREQ>();
            EMPATTRIBs = new HashSet<EMPATTRIB>();
            EMPDATES = new HashSet<EMPDATE>();
            EMPLANGs = new HashSet<EMPLANG>();
            EMPLDEPTs = new HashSet<EMPLDEPT>();
            EMPLDEPTs1 = new HashSet<EMPLDEPT>();
            EMPSUPERS = new HashSet<EMPSUPER>();
            EMPSUPREQs = new HashSet<EMPSUPREQ>();
            EMPSUPREQs1 = new HashSet<EMPSUPREQ>();
            EQUIPPRES = new HashSet<EQUIPPRE>();
            FUNDERS = new HashSet<FUNDER>();
            FUNDERS1 = new HashSet<FUNDER>();
            FUNDERS2 = new HashSet<FUNDER>();
            FUNDERS3 = new HashSet<FUNDER>();
            INFCONTACTs = new HashSet<INFCONTACT>();
            INFCONTACTCHARS = new HashSet<INFCONTACTCHAR>();
            LABORAGREEs = new HashSet<LABORAGREE>();
            LABORAGREEs1 = new HashSet<LABORAGREE>();
            LABORAGREEs2 = new HashSet<LABORAGREE>();
            LABORAGREEs3 = new HashSet<LABORAGREE>();
            LBRGRPS = new HashSet<LBRGRP>();
            LBRGRPS1 = new HashSet<LBRGRP>();
            MDS = new HashSet<MD>();
            MDSCAPS = new HashSet<MDSCAP>();
            ORDDATES = new HashSet<ORDDATE>();
            ORDPLANs = new HashSet<ORDPLAN>();
            ORDPLANSERVS = new HashSet<ORDPLANSERV>();
            PAYRECVALs = new HashSet<PAYRECVAL>();
            POSITIONS = new HashSet<POSITION>();
            SUPERTYPES = new HashSet<SUPERTYPE>();
            WFALERTTASKS = new HashSet<WFALERTTASK>();
            INFCONTACTs1 = new HashSet<INFCONTACT>();
        }

        [Key]
        [StringLength(14)]
        public string LOOKUPVAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(60)]
        public string LOOKVALUE { get; set; }

        [StringLength(30)]
        public string REFVAL { get; set; }

        [StringLength(80)]
        public string DESCR { get; set; }

        [StringLength(255)]
        public string AUXVALUE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSMD> ASSESSMDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSMENT> ASSESSMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSOASI> ASSESSOASIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSRAI> ASSESSRAIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQMDSHCDEPEND> ASSQMDSHCDEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOORDPLAN> AUTOORDPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOORDPLANSERV> AUTOORDPLANSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLRECVAL> BILLRECVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTATTRIB> CLTATTRIBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTLANG> CLTLANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTRULE> CLTRULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPER> CLTSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPREQ> CLTSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPREQ> CLTSUPREQs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPATTRIB> EMPATTRIBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDATE> EMPDATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLANG> EMPLANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPER> EMPSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPREQ> EMPSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPREQ> EMPSUPREQs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPPRE> EQUIPPRES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDER> FUNDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDER> FUNDERS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDER> FUNDERS2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDER> FUNDERS3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACTCHAR> INFCONTACTCHARS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LABORAGREE> LABORAGREEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LABORAGREE> LABORAGREEs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LABORAGREE> LABORAGREEs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LABORAGREE> LABORAGREEs3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRGRP> LBRGRPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRGRP> LBRGRPS1 { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD> MDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSCAP> MDSCAPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDDATE> ORDDATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDPLAN> ORDPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDPLANSERV> ORDPLANSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECVAL> PAYRECVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POSITION> POSITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPERTYPE> SUPERTYPES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs1 { get; set; }
    }
}
