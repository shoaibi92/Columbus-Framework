namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Query")]
    public partial class Query
    {
        [Key]
        [Column("Franchise Unique Reference", Order = 0)]
        [StringLength(14)]
        public string Franchise_Unique_Reference { get; set; }

        [Column("Customer Unique Reference")]
        [StringLength(50)]
        public string Customer_Unique_Reference { get; set; }

        [Key]
        [Column("Customer Title", Order = 1)]
        [StringLength(1)]
        public string Customer_Title { get; set; }

        [Column("Customer First Name")]
        [StringLength(255)]
        public string Customer_First_Name { get; set; }

        [Column("Customer Last Name")]
        [StringLength(255)]
        public string Customer_Last_Name { get; set; }

        [Key]
        [Column("Customer Email Address", Order = 2)]
        [StringLength(1)]
        public string Customer_Email_Address { get; set; }

        [Column("Customer Phone")]
        [StringLength(50)]
        public string Customer_Phone { get; set; }

        [Key]
        [Column("Customer Mobile Phone", Order = 3)]
        [StringLength(1)]
        public string Customer_Mobile_Phone { get; set; }

        [Column("Customer Address")]
        [StringLength(255)]
        public string Customer_Address { get; set; }

        [Column("Customer City")]
        [StringLength(50)]
        public string Customer_City { get; set; }

        [Column("Customer Region")]
        [StringLength(50)]
        public string Customer_Region { get; set; }

        [Column("Customer Postal Code")]
        [StringLength(50)]
        public string Customer_Postal_Code { get; set; }

        [Key]
        [Column("Customer Country", Order = 4)]
        [StringLength(6)]
        public string Customer_Country { get; set; }

        [Key]
        [Column("Customer Company", Order = 5)]
        [StringLength(1)]
        public string Customer_Company { get; set; }

        [Key]
        [Column("Job Unique Reference", Order = 6)]
        [StringLength(10)]
        public string Job_Unique_Reference { get; set; }

        [Key]
        [Column("Job Date", Order = 7)]
        [StringLength(10)]
        public string Job_Date { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string Technician { get; set; }

        [Key]
        [Column("Technician Name", Order = 9)]
        [StringLength(1)]
        public string Technician_Name { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(13)]
        public string Source { get; set; }

        [Key]
        [Column("Platinum Service", Order = 11)]
        [StringLength(1)]
        public string Platinum_Service { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Revenue { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(1)]
        public string RevenueCat { get; set; }

        public int? NPIScore { get; set; }

        [StringLength(8000)]
        public string Comments { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CallDate { get; set; }
    }
}
