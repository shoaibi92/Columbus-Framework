namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallForwardSettings
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [StringLength(50)]
        public string MasterComputerName { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool? SkypeIsRunning { get; set; }

        public bool? CallForwardingIsActive { get; set; }

        [StringLength(50)]
        public string CallForwardingIsActiveComputerName { get; set; }

        [StringLength(16)]
        public string CallForwardNumber { get; set; }

        public int? CallForwardAttempts { get; set; }

        public int? CallForwardRetryMinutes { get; set; }

        public bool? RunInTestMode { get; set; }

        public bool? PullDevCallmeRecords { get; set; }

        public bool? CallForwardFirstPopupOnly { get; set; }

        [StringLength(3)]
        public string AutoCallForwardDay { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime AutoCallForwardStartTime { get; set; }

        [StringLength(60)]
        public string AutoCallForwardPerson { get; set; }

        [StringLength(14)]
        public string AutoCallForwardNumber { get; set; }

        public bool? AutoCallEnable { get; set; }

        public bool? AutoCallForwardIsActiveEmailSent { get; set; }

        [StringLength(60)]
        public string smtpServer { get; set; }

        [StringLength(60)]
        public string AdminEmail { get; set; }

        [StringLength(60)]
        public string SchedulingStatusEmail { get; set; }

        public bool? EmailOnForwardActivation { get; set; }

        [StringLength(60)]
        public string EmailToOnForwardActivation { get; set; }

        [StringLength(60)]
        public string EmailCCOnForwardActivation { get; set; }

        [StringLength(50)]
        public string EmailSettingsSavedBy { get; set; }

        public bool? AllowDBCallMeDataPreparation { get; set; }

        public bool? DoDBCallMeDataPreparation { get; set; }

        public bool? DisplayCallmeRecordOwnershipColumn { get; set; }

        [StringLength(50)]
        public string SQLServerName { get; set; }

        [StringLength(500)]
        public string URL1 { get; set; }

        [StringLength(500)]
        public string URL2 { get; set; }

        [StringLength(500)]
        public string URL3 { get; set; }
    }
}
