namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FinDashboardRevActuals
    {
        [Key]
        public int UID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FYStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReportStartDate { get; set; }

        [StringLength(20)]
        public string Dept_ID { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth001 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth002 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth003 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth004 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth005 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth006 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth007 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth008 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth009 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth010 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth011 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth012 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth013 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth014 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth015 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth016 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth017 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth018 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth019 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth020 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth021 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth022 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth023 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth024 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth025 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth026 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth027 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth028 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth029 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth030 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth031 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth032 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth033 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth034 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth035 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth036 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth037 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth038 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth039 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth040 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth041 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth042 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth043 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth044 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth045 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth046 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth047 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth048 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth049 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth050 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth051 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth052 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth053 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth054 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth055 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth056 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth057 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth058 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth059 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth060 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth061 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth062 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth063 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth064 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth065 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth066 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth067 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth068 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth069 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth070 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth071 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth072 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth073 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth074 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth075 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth076 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth077 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth078 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth079 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth080 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth081 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth082 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth083 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth084 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth085 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth086 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth087 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth088 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth089 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth090 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth091 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth092 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth093 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth094 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth095 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth096 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth097 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth098 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth099 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth100 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth101 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth102 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth103 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth104 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth105 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth106 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth107 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth108 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth109 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth110 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth111 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth112 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth113 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth114 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth115 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth116 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth117 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth118 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth119 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth120 { get; set; }

        [Column(TypeName = "money")]
        public decimal? ActualMonth { get; set; }

        public int? ArchiveID { get; set; }

        [StringLength(100)]
        public string ArchiveName { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTimeStamp { get; set; }

        [StringLength(50)]
        public string InactiveDeptName { get; set; }

        [StringLength(20)]
        public string InactiveTier { get; set; }

        public DateTime? LegalStartDate { get; set; }
    }
}
