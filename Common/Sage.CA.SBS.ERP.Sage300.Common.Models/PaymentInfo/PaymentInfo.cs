// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

#endregion Namespace

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Partial class for PaymentInfo
    /// </summary>
    public partial class PaymentInfo : ModelBase
    {
        /// <summary>
        /// Gets or sets CustomerNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CustomerID", ResourceType = typeof(SPSCommonResx))]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Gets or sets CardID
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CardID", ResourceType = typeof(SPSCommonResx))]
        public string CardID { get; set; }

        /// <summary>
        /// Gets or sets CardDescription
        /// </summary>
        [Display(Name = "Desc", ResourceType = typeof(SPSCommonResx))]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string CardDescription { get; set; }

        /// <summary>
        /// Gets or sets CardType
        /// </summary>
        [Display(Name = "CreditCardType", ResourceType = typeof(CommonResx))]
        public CardType CardType { get; set; }

        /// <summary>
        /// Gets or sets CardType
        /// </summary>
        [IgnoreExportImport]
        public string CardTypeString
        {
            get
            {
                return EnumUtility.GetStringValue(CardType);
            }
        }

        /// <summary>
        /// Gets or sets ProcessCode
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ProcessingCode", ResourceType = typeof(SPSCommonResx))]
        public string ProcessCode { get; set; }

        /// <summary>
        /// Gets or sets DateLastMaintained
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime? DateLastMaintained { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        [Display(Name = "Status", ResourceType = typeof(CommonResx))]
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets StatusString
        /// </summary>
        [IgnoreExportImport]
        public string StatusString
        {
            get
            {
                return EnumUtility.GetStringValue(Status);
            }
        }

        /// <summary>
        /// Gets or sets InactiveDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime? InactiveDate { get; set; }

        /// <summary>
        /// Gets or sets DefaultCard
        /// </summary>
        [Display(Name = "DefaultCardFlag", ResourceType = typeof(SPSCommonResx))]
        public DefaultCard DefaultCard { get; set; }

        /// <summary>
        /// Gets or sets DefaultCardString
        /// </summary>
        [IgnoreExportImport]
        public string DefaultCardString
        {
            get
            {
                return EnumUtility.GetStringValue(DefaultCard);
            }
        }

        /// <summary>
        /// Gets or sets CardholderName
        /// </summary>
        [StringLength(103, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CardHolderName", ResourceType = typeof(SPSCommonResx))]
        public string CardholderName { get; set; }

        /// <summary>
        /// Gets or sets BillingAddressLine1
        /// </summary>
        [Display(Name = "AddressLine1", ResourceType = typeof(InvoiceResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets BillingAddressLine2
        /// </summary>
        [Display(Name = "AddressLine2", ResourceType = typeof(InvoiceResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets BillingCity
        /// </summary>
        [Display(Name = "City", ResourceType = typeof(SPSCommonResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingCity { get; set; }

        /// <summary>
        /// Gets or sets BillingState
        /// </summary>
        [Display(Name = "State", ResourceType = typeof(SPSCommonResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets BillingCountry
        /// </summary>
        [Display(Name = "Country", ResourceType = typeof(SPSCommonResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingCountry { get; set; }

        /// <summary>
        /// Gets or sets BillingZipcode
        /// </summary>
        [Display(Name = "Zipcode", ResourceType = typeof(SPSCommonResx))]
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingZipcode { get; set; }

        /// <summary>
        /// Gets or sets VaultID
        /// </summary>
        [StringLength(36, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        //[Display(Name = "VaultID", ResourceType = typeof(PaymentInfoResx))]
        public string VaultID { get; set; }

        /// <summary>
        /// Gets or sets MaskedCardNumber
        /// </summary>
        [Display(Name = "CCNumber", ResourceType = typeof(SPSCommonResx))]
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string MaskedCardNumber { get; set; }

        /// <summary>
        /// Gets or sets Expdate
        /// </summary>
        [Display(Name = "ExpirationDate", ResourceType = typeof(CommonResx))]
        [StringLength(4, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Expdate { get; set; }

        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        [StringLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Comment", ResourceType = typeof(SPSCommonResx))]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets MaskedCreditCardNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CCNumber", ResourceType = typeof(SPSCommonResx))]
        public string MaskedCreditCardNumber { get; set; }

        /// <summary>
        /// Gets or sets Vexpdate
        /// </summary>
        [StringLength(5, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Vexpdate { get; set; }

        /// <summary>
        /// Gets or sets TotalAmount
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets or sets SubtotalAmount
        /// </summary>
        public decimal SubtotalAmount { get; set; }

        /// <summary>
        /// Gets or sets Time
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Time", ResourceType = typeof(CommonResx))]
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets AuthorizationCode
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets OneTimeUseSwitch
        /// </summary>
        public int OneTimeUseSwitch { get; set; }

        /// <summary>
        /// Gets or sets Vproccode
        /// </summary>
        public int Vproccode { get; set; }

        /// <summary>
        /// Gets or sets ProcessingCommand
        /// </summary>
        public ProcessingCommand ProcessingCommand { get; set; }

        /// <summary>
        /// Gets or sets ProcessingCommandString
        /// </summary>
        [IgnoreExportImport]
        public string ProcessingCommandString
        {
            get
            {
                return EnumUtility.GetStringValue(ProcessingCommand);
            }
        }

        /// <summary>
        /// Gets or sets Bankcode
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Bank", ResourceType = typeof(SPSCommonResx))]
        public string Bankcode { get; set; }

        /// <summary>
        /// Gets or sets CurrencyCode
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CurrencyCode", ResourceType = typeof(InvoiceResx))]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Document Number
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Transaction
        /// </summary>
        public Transaction Transaction { get; set; }

        /// <summary>
        /// TransTypeReturnStatus
        /// </summary>
        public TransTypeReturnStatus TransactionReturnStatus { get; set; }

        /// <summary>
        /// Gets or sets XMLString
        /// </summary>
        [IgnoreExportImport]
        public string XMLString { get; set; }

        /// <summary>
        /// The CHK customer address
        /// </summary>
        public bool ChkCustomerAddress { get; set; }

        /// <summary>
        /// Gets or sets ResposeFromSps
        /// </summary>
        [IgnoreExportImport]
        public bool bResposeFromSps { get; set; }

        /// <summary>
        /// Gets or sets IsExistingCardId
        /// </summary>
        [IgnoreExportImport]
        public bool IsExistingCardId { get; set; }
    }
}