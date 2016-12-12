namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_StarWars_Prepped
    {
        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(20)]
        public string CLTFirstName { get; set; }

        [StringLength(30)]
        public string CLTLastName { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [Column("Postal/Zip")]
        [StringLength(14)]
        public string Postal_Zip { get; set; }

        [StringLength(12)]
        public string Home_Phone { get; set; }

        [StringLength(50)]
        public string EmailAddr { get; set; }

        public DateTime? BirthDate { get; set; }

        [Key]
        [Column("Postal/Zip Valid", Order = 0)]
        [StringLength(3)]
        public string Postal_Zip_Valid { get; set; }

        [Key]
        [Column("Home Phone Valid", Order = 1)]
        [StringLength(3)]
        public string Home_Phone_Valid { get; set; }

        [Key]
        [Column("Email Valid", Order = 2)]
        [StringLength(3)]
        public string Email_Valid { get; set; }

        [Key]
        [Column("DOB Valid", Order = 3)]
        [StringLength(3)]
        public string DOB_Valid { get; set; }

        [Key]
        [Column("Has Consult File", Order = 4)]
        [StringLength(3)]
        public string Has_Consult_File { get; set; }

        [Key]
        [Column("Client file created in reporting month", Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_file_created_in_reporting_month { get; set; }

        [Key]
        [Column("CCT in reporting month", Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CCT_in_reporting_month { get; set; }

        [Key]
        [Column("First Visit With Rev in Reporting Month", Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int First_Visit_With_Rev_in_Reporting_Month { get; set; }

        [Column("Client File Intake date")]
        public DateTime? Client_File_Intake_date { get; set; }

        [Column("Consult Intake date")]
        public DateTime? Consult_Intake_date { get; set; }

        [Column("First visit with Rev date")]
        public DateTime? First_visit_with_Rev_date { get; set; }
    }
}
