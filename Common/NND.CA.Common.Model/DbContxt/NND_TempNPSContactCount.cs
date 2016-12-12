namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_TempNPSContactCount
    {
        [StringLength(50)]
        public string ICEmailAddress { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CONTACT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactType { get; set; }

        [StringLength(10)]
        public string ICSalutation { get; set; }

        [StringLength(20)]
        public string ICFirstName { get; set; }

        [StringLength(30)]
        public string ICLastName { get; set; }

        [StringLength(12)]
        public string ICHOmePhone { get; set; }

        [StringLength(12)]
        public string ICWorkPhone { get; set; }

        [StringLength(12)]
        public string CELLPHONE { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(73)]
        public string ClientFullName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string Dept_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(14)]
        public string Client_ID { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmailAddr { get; set; }

        [StringLength(30)]
        public string PERM_CITY { get; set; }

        [StringLength(10)]
        public string PERM_POST { get; set; }

        [StringLength(3)]
        public string PERM_PROV { get; set; }

        [StringLength(10)]
        public string Home_Phone { get; set; }

        [StringLength(40)]
        public string PermAddr_1 { get; set; }

        [StringLength(30)]
        public string PERM_CNTRY { get; set; }

        [Key]
        [Column("Job Unique Reference", Order = 6)]
        [StringLength(10)]
        public string Job_Unique_Reference { get; set; }

        [Key]
        [Column("Job Date", Order = 7)]
        public DateTime Job_Date { get; set; }

        [Key]
        [Column("Technician Name", Order = 8)]
        [StringLength(1)]
        public string Technician_Name { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(13)]
        public string Source { get; set; }

        [Key]
        [Column("Platinum Service", Order = 10)]
        [StringLength(1)]
        public string Platinum_Service { get; set; }

        public decimal? Revenue { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(1)]
        public string RevenueCat { get; set; }
    }
}
