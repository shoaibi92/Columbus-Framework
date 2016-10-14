// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

// ReSharper disable CheckNamespace
namespace Sage.CA.SBS.ERP.Sage300.Common.Models
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Contains list of PaymentInfo Constants
    /// </summary>
    public partial class PaymentInfo
    {
        /// <summary>
        /// Entity Name
        /// </summary>
        public const string EntityName = "YP0406";

        #region Properties

        /// <summary>
        /// Contains list of PaymentInfo Constants
        /// </summary>
        public class Fields
        {
            /// <summary>
            /// Property for CustomerNumber
            /// </summary>
            public const string CustomerNumber = "IDCUST";

            /// <summary>
            /// Property for CardID
            /// </summary>
            public const string CardID = "IDCARD";

            /// <summary>
            /// Property for CardDescription
            /// </summary>
            public const string CardDescription = "DESC";

            /// <summary>
            /// Property for CardType
            /// </summary>
            public const string CardType = "CARDTYPE";

            /// <summary>
            /// Property for CardTypeString
            /// </summary>
            [IsMvcSpecific]
            public const string CardTypeString = "CARDTYPE";

            /// <summary>
            /// Property for ProcessCode
            /// </summary>
            public const string ProcessCode = "PROCESSCOD";

            /// <summary>
            /// Property for DateLastMaintained
            /// </summary>
            public const string DateLastMaintained = "DATELASTMN";

            /// <summary>
            /// Property for Status
            /// </summary>
            public const string Status = "SWACTV";

            /// <summary>
            /// Property for StatusString
            /// </summary>
            [IsMvcSpecific]
            public const string StatusString = "SWACTV";

            /// <summary>
            /// Property for InactiveDate
            /// </summary>
            public const string InactiveDate = "DATEINACTV";

            /// <summary>
            /// Property for DefaultCard
            /// </summary>
            public const string DefaultCard = "SWDEFCARD";

            /// <summary>
            /// Property for DefaultCardString
            /// </summary>
            [IsMvcSpecific]
            public const string DefaultCardString = "SWDEFCARD";

            /// <summary>
            /// Property for CardholderName
            /// </summary>
            public const string CardholderName = "NAMEONCARD";

            /// <summary>
            /// Property for BillingAddressLine1
            /// </summary>
            public const string BillingAddressLine1 = "BLADDR1";

            /// <summary>
            /// Property for BillingAddressLine2
            /// </summary>
            public const string BillingAddressLine2 = "BLADDR2";

            /// <summary>
            /// Property for BillingCity
            /// </summary>
            public const string BillingCity = "BLCITY";

            /// <summary>
            /// Property for BillingState
            /// </summary>
            public const string BillingState = "BLSTATE";

            /// <summary>
            /// Property for BillingCountry
            /// </summary>
            public const string BillingCountry = "BLCOUNTRY";

            /// <summary>
            /// Property for BillingZipcode
            /// </summary>
            public const string BillingZipcode = "BLZIPCODE";

            /// <summary>
            /// Property for VaultID
            /// </summary>
            public const string VaultID = "VAULTID";

            /// <summary>
            /// Property for MaskedCardNumber
            /// </summary>
            public const string MaskedCardNumber = "CARDNUMBER";

            /// <summary>
            /// Property for EXPDATE
            /// </summary>
            public const string Expdate = "Expdate";

            /// <summary>
            /// Property for Comment
            /// </summary>
            public const string Comment = "CARDCMNT";

            /// <summary>
            /// Property for MaskedCreditCardNumber
            /// </summary>
            public const string MaskedCreditCardNumber = "VNUMBER";

            /// <summary>
            /// Property for VEXPDATE
            /// </summary>
            public const string Vexpdate = "Vexpdate";

            /// <summary>
            /// Property for TotalAmount
            /// </summary>
            public const string TotalAmount = "VAMOUNT";

            /// <summary>
            /// Property for TaxAmount
            /// </summary>
            public const string TaxAmount = "VTAXAMT";

            /// <summary>
            /// Property for SubtotalAmount
            /// </summary>
            public const string SubtotalAmount = "VSUBAMT";

            /// <summary>
            /// Property for Time
            /// </summary>
            public const string Time = "VTIME";

            /// <summary>
            /// Property for AuthorizationCode
            /// </summary>
            public const string AuthorizationCode = "VAUTHCODE";

            /// <summary>
            /// Property for OneTimeUseSwitch
            /// </summary>
            public const string OneTimeUseSwitch = "SWONETIME";

            /// <summary>
            /// Property for Vproccode
            /// </summary>
            public const string Vproccode = "Vproccode";

            /// <summary>
            /// Property for ProcessingCommand
            /// </summary>
            public const string ProcessingCommand = "PROCESSCMD";

            /// <summary>
            /// Property for ProcessingCommandString
            /// </summary>
            [IsMvcSpecific]
            public const string ProcessingCommandString = "PROCESSCMD";

            /// <summary>
            /// Property for Bankcode
            /// </summary>
            public const string Bankcode = "BANK";

            /// <summary>
            /// Property for CurrencyCode
            /// </summary>
            public const string CurrencyCode = "CURRENCY";
        }

        #endregion Properties

        #region Properties

        /// <summary>
        /// Contains list of PaymentInfo Constants
        /// </summary>
        public class Index
        {
            /// <summary>
            /// Property Indexer for CustomerNumber
            /// </summary>
            public const int CustomerNumber = 1;

            /// <summary>
            /// Property Indexer for CardID
            /// </summary>
            public const int CardID = 2;

            /// <summary>
            /// Property Indexer for CardDescription
            /// </summary>
            public const int CardDescription = 3;

            /// <summary>
            /// Property Indexer for CardType
            /// </summary>
            public const int CardType = 4;

            /// <summary>
            /// Property Indexer for ProcessCode
            /// </summary>
            public const int ProcessCode = 5;

            /// <summary>
            /// Property Indexer for DateLastMaintained
            /// </summary>
            public const int DateLastMaintained = 6;

            /// <summary>
            /// Property Indexer for Status
            /// </summary>
            public const int Status = 7;

            /// <summary>
            /// Property Indexer for InactiveDate
            /// </summary>
            public const int InactiveDate = 8;

            /// <summary>
            /// Property Indexer for DefaultCard
            /// </summary>
            public const int DefaultCard = 9;

            /// <summary>
            /// Property Indexer for CardholderName
            /// </summary>
            public const int CardholderName = 10;

            /// <summary>
            /// Property Indexer for BillingAddressLine1
            /// </summary>
            public const int BillingAddressLine1 = 11;

            /// <summary>
            /// Property Indexer for BillingAddressLine2
            /// </summary>
            public const int BillingAddressLine2 = 12;

            /// <summary>
            /// Property Indexer for BillingCity
            /// </summary>
            public const int BillingCity = 13;

            /// <summary>
            /// Property Indexer for BillingState
            /// </summary>
            public const int BillingState = 14;

            /// <summary>
            /// Property Indexer for BillingCountry
            /// </summary>
            public const int BillingCountry = 15;

            /// <summary>
            /// Property Indexer for BillingZipcode
            /// </summary>
            public const int BillingZipcode = 16;

            /// <summary>
            /// Property Indexer for VaultID
            /// </summary>
            public const int VaultID = 17;

            /// <summary>
            /// Property Indexer for MaskedCardNumber
            /// </summary>
            public const int MaskedCardNumber = 18;

            /// <summary>
            /// Property Indexer for Expdate
            /// </summary>
            public const int Expdate = 19;

            /// <summary>
            /// Property Indexer for Comment
            /// </summary>
            public const int Comment = 20;

            /// <summary>
            /// Property Indexer for MaskedCreditCardNumber
            /// </summary>
            public const int MaskedCreditCardNumber = 50;

            /// <summary>
            /// Property Indexer for Vexpdate
            /// </summary>
            public const int Vexpdate = 51;

            /// <summary>
            /// Property Indexer for TotalAmount
            /// </summary>
            public const int TotalAmount = 52;

            /// <summary>
            /// Property Indexer for TaxAmount
            /// </summary>
            public const int TaxAmount = 53;

            /// <summary>
            /// Property Indexer for SubtotalAmount
            /// </summary>
            public const int SubtotalAmount = 54;

            /// <summary>
            /// Property Indexer for Time
            /// </summary>
            public const int Time = 55;

            /// <summary>
            /// Property Indexer for AuthorizationCode
            /// </summary>
            public const int AuthorizationCode = 56;

            /// <summary>
            /// Property Indexer for OneTimeUseSwitch
            /// </summary>
            public const int OneTimeUseSwitch = 57;

            /// <summary>
            /// Property Indexer for Vproccode
            /// </summary>
            public const int Vproccode = 58;

            /// <summary>
            /// Property Indexer for ProcessingCommand
            /// </summary>
            public const int ProcessingCommand = 59;

            /// <summary>
            /// Property Indexer for Bankcode
            /// </summary>
            public const int Bankcode = 60;

            /// <summary>
            /// Property Indexer for CurrencyCode
            /// </summary>
            public const int CurrencyCode = 61;
        }

        #endregion Properties
    }
}