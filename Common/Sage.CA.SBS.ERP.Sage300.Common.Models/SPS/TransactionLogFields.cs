// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of TransactionLog Constants
    /// </summary>
    public partial class TransactionLog
    {
        /// <summary>
        /// The entity name
        /// </summary>
        public const string EntityName = "YP0700";

        #region Properties

        /// <summary>
        /// Contains list of TransactionLog Constants
        /// </summary>
        public class Fields
        {
            /// <summary>
            /// Property for TransactionID
            /// </summary>
            public const string TransactionID = "TRANSID";

            /// <summary>
            /// Property for Bank
            /// </summary>
            public const string Bank = "BANK";

            /// <summary>
            /// Property for CurrencyCode
            /// </summary>
            public const string CurrencyCode = "CODECURN";

            /// <summary>
            /// Property for Action
            /// </summary>
            public const string Action = "ACTION";

            /// <summary>
            /// Property for ResponseIndicator
            /// </summary>
            public const string ResponseIndicator = "RESPIND";

            /// <summary>
            /// Property for ResponseCode
            /// </summary>
            public const string ResponseCode = "RESPCD";

            /// <summary>
            /// Property for ResponseMessage
            /// </summary>
            public const string ResponseMessage = "RESPMSG";

            /// <summary>
            /// Property for GuidFromMessage
            /// </summary>
            public const string GuidFromMessage = "GUID";

            /// <summary>
            /// Property for ExpireDate
            /// </summary>
            public const string ExpireDate = "EXPDATE";

            /// <summary>
            /// Property for Last4
            /// </summary>
            public const string Last4 = "LAST4";

            /// <summary>
            /// Property for PaymentDescription
            /// </summary>
            public const string PaymentDescription = "PMTDESC";

            /// <summary>
            /// Property for PaymentTypeID
            /// </summary>
            public const string PaymentTypeID = "PMTTYPEID";

            /// <summary>
            /// Property for Reference1
            /// </summary>
            public const string Reference1 = "REF1";

            /// <summary>
            /// Property for Reference2
            /// </summary>
            public const string Reference2 = "REF2";

            /// <summary>
            /// Property for Amount
            /// </summary>
            public const string Amount = "AMOUNT";

            /// <summary>
            /// Property for AuthorizationCode
            /// </summary>
            public const string AuthorizationCode = "AUTHCODE";

            /// <summary>
            /// Property for VanReference
            /// </summary>
            public const string VanReference = "VANREF";

            /// <summary>
            /// Property for Name
            /// </summary>
            public const string Name = "NAME";

            /// <summary>
            /// Property for AddressLine1
            /// </summary>
            public const string AddressLine1 = "ADDR1";

            /// <summary>
            /// Property for AddressLine2
            /// </summary>
            public const string AddressLine2 = "ADDR2";

            /// <summary>
            /// Property for City
            /// </summary>
            public const string City = "CITY";

            /// <summary>
            /// Property for State
            /// </summary>
            public const string State = "STATE";

            /// <summary>
            /// Property for ZipCode
            /// </summary>
            public const string ZipCode = "ZIPCODE";

            /// <summary>
            /// Property for Country
            /// </summary>
            public const string Country = "COUNTRY";

            /// <summary>
            /// Property for Email
            /// </summary>
            public const string Email = "EMAIL";

            /// <summary>
            /// Property for Telephone
            /// </summary>
            public const string Telephone = "TEL";

            /// <summary>
            /// Property for Fax
            /// </summary>
            public const string Fax = "FAX";

            /// <summary>
            /// Property for AvsResult
            /// </summary>
            public const string AvsResult = "AVSRESULT";

            /// <summary>
            /// Property for CvvResult
            /// </summary>
            public const string CvvResult = "CVVRESULT";

            /// <summary>
            /// Property for Timestamp
            /// </summary>
            public const string Timestamp = "TIMESTAMP";

            /// <summary>
            /// Property for BatchReference
            /// </summary>
            public const string BatchReference = "BATCHREF";

            /// <summary>
            /// Property for SettlementType
            /// </summary>
            public const string SettlementType = "SETLTYPE";

            /// <summary>
            /// Property for SettlementDate
            /// </summary>
            public const string SettlementDate = "SETLDATE";

            /// <summary>
            /// Property for TransactionType
            /// </summary>
            public const string TransactionType = "TRANSTYPE";

            /// <summary>
            /// Property for ProcessingDate
            /// </summary>
            public const string ProcessingDate = "DTPROCESS";

            /// <summary>
            /// Property for TaxAmount
            /// </summary>
            public const string TaxAmount = "TAXAMOUNT";

            /// <summary>
            /// Property for CustomerNumber
            /// </summary>
            public const string CustomerNumber = "IDCUST";

            /// <summary>
            /// Property for ProcessingCode
            /// </summary>
            public const string ProcessingCode = "PROCESSCOD";

            /// <summary>
            /// Property for CardID
            /// </summary>
            public const string CardID = "IDCARD";

            /// <summary>
            /// Property for DocumentNumber
            /// </summary>
            public const string DocumentNumber = "DOCNUMBER";

            /// <summary>
            /// Property for CardDescription
            /// </summary>
            public const string CardDescription = "CARDDESC";

            /// <summary>
            /// Property for CardComment
            /// </summary>
            public const string CardComment = "CARDCMNT";

            /// <summary>
            /// Property for SPSRequestProcessCompletedFl
            /// </summary>
            public const string SpsRequestProcessCompletedFl = "ISCOMPLETE";

            /// <summary>
            /// Property for Application
            /// </summary>
            public const string Application = "APP";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains list of TransactionLog Constants
        /// </summary>
        public class Index
        {
            /// <summary>
            /// Property Indexer for TransactionID
            /// </summary>
            public const int TransactionID = 1;

            /// <summary>
            /// Property Indexer for Bank
            /// </summary>
            public const int Bank = 2;

            /// <summary>
            /// Property Indexer for CurrencyCode
            /// </summary>
            public const int CurrencyCode = 3;

            /// <summary>
            /// Property Indexer for Action
            /// </summary>
            public const int Action = 4;

            /// <summary>
            /// Property Indexer for ResponseIndicator
            /// </summary>
            public const int ResponseIndicator = 5;

            /// <summary>
            /// Property Indexer for ResponseCode
            /// </summary>
            public const int ResponseCode = 6;

            /// <summary>
            /// Property Indexer for ResponseMessage
            /// </summary>
            public const int ResponseMessage = 7;

            /// <summary>
            /// Property Indexer for GuidFromMessage
            /// </summary>
            public const int GuidFromMessage = 8;

            /// <summary>
            /// Property Indexer for ExpireDate
            /// </summary>
            public const int ExpireDate = 9;

            /// <summary>
            /// Property Indexer for Last4
            /// </summary>
            public const int Last4 = 10;

            /// <summary>
            /// Property Indexer for PaymentDescription
            /// </summary>
            public const int PaymentDescription = 11;

            /// <summary>
            /// Property Indexer for PaymentTypeID
            /// </summary>
            public const int PaymentTypeID = 12;

            /// <summary>
            /// Property Indexer for Reference1
            /// </summary>
            public const int Reference1 = 13;

            /// <summary>
            /// Property Indexer for Reference2
            /// </summary>
            public const int Reference2 = 14;

            /// <summary>
            /// Property Indexer for Amount
            /// </summary>
            public const int Amount = 15;

            /// <summary>
            /// Property Indexer for AuthorizationCode
            /// </summary>
            public const int AuthorizationCode = 16;

            /// <summary>
            /// Property Indexer for VanReference
            /// </summary>
            public const int VanReference = 17;

            /// <summary>
            /// Property Indexer for Name
            /// </summary>
            public const int Name = 18;

            /// <summary>
            /// Property Indexer for AddressLine1
            /// </summary>
            public const int AddressLine1 = 19;

            /// <summary>
            /// Property Indexer for AddressLine2
            /// </summary>
            public const int AddressLine2 = 20;

            /// <summary>
            /// Property Indexer for City
            /// </summary>
            public const int City = 21;

            /// <summary>
            /// Property Indexer for State
            /// </summary>
            public const int State = 22;

            /// <summary>
            /// Property Indexer for ZipCode
            /// </summary>
            public const int ZipCode = 23;

            /// <summary>
            /// Property Indexer for Country
            /// </summary>
            public const int Country = 24;

            /// <summary>
            /// Property Indexer for Email
            /// </summary>
            public const int Email = 25;

            /// <summary>
            /// Property Indexer for Telephone
            /// </summary>
            public const int Telephone = 26;

            /// <summary>
            /// Property Indexer for Fax
            /// </summary>
            public const int Fax = 27;

            /// <summary>
            /// Property Indexer for AvsResult
            /// </summary>
            public const int AvsResult = 28;

            /// <summary>
            /// Property Indexer for CvvResult
            /// </summary>
            public const int CvvResult = 29;

            /// <summary>
            /// Property Indexer for Timestamp
            /// </summary>
            public const int Timestamp = 30;

            /// <summary>
            /// Property Indexer for BatchReference
            /// </summary>
            public const int BatchReference = 31;

            /// <summary>
            /// Property Indexer for SettlementType
            /// </summary>
            public const int SettlementType = 32;

            /// <summary>
            /// Property Indexer for SettlementDate
            /// </summary>
            public const int SettlementDate = 33;

            /// <summary>
            /// Property Indexer for TransactionType
            /// </summary>
            public const int TransactionType = 34;

            /// <summary>
            /// Property Indexer for ProcessingDate
            /// </summary>
            public const int ProcessingDate = 35;

            /// <summary>
            /// Property Indexer for TaxAmount
            /// </summary>
            public const int TaxAmount = 36;

            /// <summary>
            /// Property Indexer for CustomerNumber
            /// </summary>
            public const int CustomerNumber = 37;

            /// <summary>
            /// Property Indexer for ProcessingCode
            /// </summary>
            public const int ProcessingCode = 38;

            /// <summary>
            /// Property Indexer for CardID
            /// </summary>
            public const int CardID = 39;

            /// <summary>
            /// Property Indexer for DocumentNumber
            /// </summary>
            public const int DocumentNumber = 40;

            /// <summary>
            /// Property Indexer for CardDescription
            /// </summary>
            public const int CardDescription = 41;

            /// <summary>
            /// Property Indexer for CardComment
            /// </summary>
            public const int CardComment = 42;

            /// <summary>
            /// Property Indexer for SPSRequestProcessCompletedFl
            /// </summary>
            public const int SpsRequestProcessCompletedFl = 43;

            /// <summary>
            /// Property Indexer for Application
            /// </summary>
            public const int Application = 44;
        }

        #endregion

    }
}
