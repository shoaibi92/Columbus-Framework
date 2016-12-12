namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Settings
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string ExchangeWebService { get; set; }

        [StringLength(200)]
        public string SQLServerName { get; set; }

        [StringLength(200)]
        public string TextingUserName { get; set; }

        [StringLength(200)]
        public string TextingUserPassword { get; set; }

        public int? TextingLoadMaxNbrMessagesAtATime { get; set; }

        public int? TextingCheckForNewMessagesInterval { get; set; }

        [StringLength(150)]
        public string MessageProcessingServerName { get; set; }

        [StringLength(500)]
        public string SMSGateway1CurrentSMSDeviceName { get; set; }

        [StringLength(500)]
        public string SMSGateway2CurrentSMSDeviceName { get; set; }

        [StringLength(500)]
        public string SMSGateway3CurrentSMSDeviceName { get; set; }

        [StringLength(500)]
        public string SMSGateway1CurrentSMSDeviceID { get; set; }

        [StringLength(500)]
        public string SMSGateway2CurrentSMSDeviceID { get; set; }

        [StringLength(500)]
        public string SMSGateway3CurrentSMSDeviceID { get; set; }

        [StringLength(500)]
        public string SMSGateway1Status { get; set; }

        [StringLength(500)]
        public string SMSGateway2Status { get; set; }

        [StringLength(500)]
        public string SMSGateway3Status { get; set; }

        [StringLength(500)]
        public string SMSGateway1StatusTimeStamp { get; set; }

        [StringLength(500)]
        public string SMSGateway2StatusTimeStamp { get; set; }

        [StringLength(500)]
        public string SMSGateway3StatusTimeStamp { get; set; }

        public int? TwilioCurrentPageNumber { get; set; }

        public int? TwilioLastProcessedMsgID { get; set; }

        public DateTime? TwilioLastProcessedDateTimeStampGMT { get; set; }

        [StringLength(500)]
        public string TwilioACCOUNTS_IDAC { get; set; }

        [StringLength(500)]
        public string TwilioAUTH_TOKEN { get; set; }

        [StringLength(1000)]
        public string AutoReplyMessageCanadaUSB { get; set; }

        [StringLength(1000)]
        public string AutoReplyMessageCanadaTwilio { get; set; }

        [StringLength(1000)]
        public string AutoReplyMessageUSATwilio { get; set; }

        [StringLength(14)]
        public string LimitTrafficToContactNumber { get; set; }

        [StringLength(200)]
        public string MasterComputerName { get; set; }
    }
}
