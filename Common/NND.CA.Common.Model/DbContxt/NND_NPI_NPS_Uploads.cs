namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_NPI_NPS_Uploads
    {
        [Key]
        public int UID { get; set; }

        [StringLength(16)]
        public string exDept_ID { get; set; }

        [StringLength(16)]
        public string exClEmp_ID { get; set; }

        [StringLength(30)]
        public string exTitle { get; set; }

        [StringLength(40)]
        public string exFirstName { get; set; }

        [StringLength(40)]
        public string exLastName { get; set; }

        [StringLength(40)]
        public string exEmailAddress { get; set; }

        [StringLength(16)]
        public string exPhone { get; set; }

        [StringLength(16)]
        public string exMobilePhone { get; set; }

        [StringLength(50)]
        public string exAddress { get; set; }

        [StringLength(40)]
        public string exCity { get; set; }

        [StringLength(40)]
        public string exRegion { get; set; }

        [StringLength(12)]
        public string exPostalCode { get; set; }

        [StringLength(30)]
        public string exCountry { get; set; }

        [StringLength(30)]
        public string exCompany { get; set; }

        [StringLength(30)]
        public string exJobUniqueReference { get; set; }

        public DateTime? exJobDate { get; set; }

        [StringLength(30)]
        public string exTechnician { get; set; }

        [StringLength(40)]
        public string exTechnicianName { get; set; }

        [StringLength(30)]
        public string exSource { get; set; }

        [StringLength(20)]
        public string exPlatinumService { get; set; }

        [StringLength(10)]
        public string exRevenue { get; set; }

        [StringLength(50)]
        public string exRevenueCat { get; set; }

        public int? ContactType { get; set; }

        [StringLength(50)]
        public string DataDateRange { get; set; }

        public int? SystemType { get; set; }

        public DateTime? SystinoSubmitDate { get; set; }

        public DateTime? DataPrepDate { get; set; }

        public int? DataBatchID { get; set; }
    }
}
