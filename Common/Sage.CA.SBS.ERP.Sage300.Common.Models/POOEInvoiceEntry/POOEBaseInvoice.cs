/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Partial class for POOEBaseInvoice
    /// </summary>
    public partial class POOEBaseInvoice : ModelBase
    {
        #region Constructor

        public POOEBaseInvoice()
        {
            InvoicePaymentSchedule = new EnumerableResponse<POOEBaseInvPaymentSchedule>();
            InvoiceLine = new EnumerableResponse<POOEBaseInvoiceLine>();
            AdditionalCostSuperView = new EnumerableResponse<POOEInvBaseAddCostsSuperview>();
            OptionalFieldList = new EnumerableResponse<BaseInvoiceOptionalField>();
            MultipleReceiptsList = new EnumerableResponse<POOEBaseInvoiceReciepts>();
            LineComments = new EnumerableResponse<POOEBaseInvoiceComments>();
            InvoiceAddCostDistribution = new EnumerableResponse<POOEBaseAdditionalCost>();
        }

        #endregion

        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets NextLineSequence
        /// </summary>
        [IgnoreExportImport]
        public decimal NextLineSequence { get; set; }

        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        [IgnoreExportImport]
        public long Lines { get; set; }

        /// <summary>
        /// Gets or sets LinesComplete
        /// </summary>
        [IgnoreExportImport]
        public long LinesComplete { get; set; }

        /// <summary>
        /// Gets or sets Costs
        /// </summary>
        [IgnoreExportImport]
        public long Costs { get; set; }

        /// <summary>
        /// Gets or sets CostsComplete
        /// </summary>
        [IgnoreExportImport]
        public long CostsComplete { get; set; }

        /// <summary>
        /// Gets or sets Payments
        /// </summary>
        [IgnoreExportImport]
        public long Payments { get; set; }

        /// <summary>
        /// Gets or sets LinesTaxCalculationSees
        /// </summary>
        [IgnoreExportImport]
        public long LinesTaxCalculationSees { get; set; }

        /// <summary>
        /// Gets or sets Autotaxcalculationonsave
        /// </summary>
        [IgnoreExportImport]
        public AutoTaxCalculationOnSave Autotaxcalculationonsave { get; set; }

        /// <summary>
        /// Gets or sets Completed
        /// </summary>
        [IgnoreExportImport]
        public Completed Completed { get; set; }

        /// <summary>
        /// Gets or sets DateCompleted
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public DateTime DateCompleted { get; set; }

        /// <summary>
        /// Gets or sets LastPostingDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public DateTime LastPostingDate { get; set; }

        /// <summary>
        /// Gets or sets PurchaseOrderSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal PurchaseOrderSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets PurchaseOrderNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PurchaseOrderNumber", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceDate", ResourceType = typeof(InvoiceResx))]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets FiscalYear
        /// </summary>
        [StringLength(4, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "FiscalYear", ResourceType = typeof(CommonResx))]
        public string FiscalYear { get; set; }

        /// <summary>
        /// Gets or sets FiscalPeriod
        /// </summary>
        [Display(Name = "FiscalPeriod", ResourceType = typeof(CommonResx))]
        public POFiscalPeriod FiscalPeriod { get; set; }

        /// <summary>
        /// Gets or sets InvoiceNumber
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceNumber", ResourceType = typeof(InvoiceResx))]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorNumber", ResourceType = typeof(InvoiceResx))]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets VendorExists
        /// </summary>
        [IgnoreExportImport]
        public AutoTaxCalculationOnSave VendorExists { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Name", ResourceType = typeof(CommonResx))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Address1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine1", ResourceType = typeof(InvoiceResx))]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets Address2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine2", ResourceType = typeof(InvoiceResx))]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets Address3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine3", ResourceType = typeof(InvoiceResx))]
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or sets Address4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine4", ResourceType = typeof(InvoiceResx))]
        public string Address4 { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "City", ResourceType = typeof(InvoiceResx))]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets StateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "StateProvince", ResourceType = typeof(InvoiceResx))]
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets ZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ZIPPostalCode", ResourceType = typeof(InvoiceResx))]
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Country", ResourceType = typeof(InvoiceResx))]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Phone", ResourceType = typeof(InvoiceResx))]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets FaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Fax", ResourceType = typeof(InvoiceResx))]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets Contact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Contact", ResourceType = typeof(InvoiceResx))]
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets TermsCode
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TermsCode", ResourceType = typeof(InvoiceResx))]
        public string TermsCode { get; set; }

        /// <summary>
        /// Gets or sets FromDocument
        /// </summary>
        [Display(Name = "FromDocument", ResourceType = typeof(InvoiceResx))]
        public FromDocument FromDocument { get; set; }

        /// <summary>
        /// Gets or sets PrimaryVendor
        /// </summary>
        [IgnoreExportImport]
        public PrimaryVendor PrimaryVendor { get; set; }

        /// <summary>
        /// Gets or sets ReceiptSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal ReceiptSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ReceiptNumber
        /// </summary>
        [IgnoreExportImport]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReceiptNumber", ResourceType = typeof(InvoiceResx))]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets ReceiptDate
        /// </summary>
        [IgnoreExportImport]
        [ValidateDateFormatAllowNull(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReceiptDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? ReceiptDate { get; set; }

        /// <summary>
        /// Gets or sets ReturnSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal ReturnSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ReturnNumber
        /// </summary>
        [IgnoreExportImport]
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReturnNumber", ResourceType = typeof(InvoiceResx))]
        public string ReturnNumber { get; set; }

        /// <summary>
        /// Gets or sets ReturnDate
        /// </summary>
        [IgnoreExportImport]
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReturnDate", ResourceType = typeof(InvoiceResx))]
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Description", ResourceType = typeof(InvoiceResx))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Reference", ResourceType = typeof(InvoiceResx))]
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        [StringLength(250, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Comment", ResourceType = typeof(InvoiceResx))]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets Currency
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Currency", ResourceType = typeof(InvoiceResx))]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRate
        /// </summary>
        [Display(Name = "ExchangeRate", ResourceType = typeof(InvoiceResx))]
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets RateSpread
        /// </summary>
        [Display(Name = "RateSpread", ResourceType = typeof(InvoiceResx))]
        public decimal RateSpread { get; set; }

        /// <summary>
        /// Gets or sets RateType
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateType", ResourceType = typeof(InvoiceResx))]
        public string RateType { get; set; }

        /// <summary>
        /// Gets or sets RateMatchType
        /// </summary>
        [Display(Name = "RateMatchType", ResourceType = typeof(InvoiceResx))]
        public int RateMatchType { get; set; }

        /// <summary>
        /// Gets or sets RateDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateDate", ResourceType = typeof(InvoiceResx))]
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Gets or sets RateOperation
        /// </summary>
        [Display(Name = "RateOperation", ResourceType = typeof(InvoiceResx))]
        public RateOperation RateOperation { get; set; }

        /// <summary>
        /// Gets or sets RateOverridden
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "RateOverridden", ResourceType = typeof(InvoiceResx))]
        public POOERateOverridden RateOverridden { get; set; }

        /// <summary>
        /// Gets or sets DecimalPlaces
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "DecimalPlaces", ResourceType = typeof(CommonResx))]
        public int DecimalPlaces { get; set; }

        /// <summary>
        /// Gets or sets PaymentAsOfDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PaymentAsOfDate", ResourceType = typeof(InvoiceResx))]
        public DateTime PaymentAsOfDate { get; set; }

        /// <summary>
        /// Gets or sets TotalTermsAmountDue
        /// </summary>
        [IgnoreExportImport]
        public decimal TotalTermsAmountDue { get; set; }

        /// <summary>
        /// Gets or sets ExtendedWeight
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "ExtendedWeight", ResourceType = typeof(InvoiceResx))]
        public decimal ExtendedWeight { get; set; }

        /// <summary>
        /// Gets or sets ExtendedCost
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "ExtendedCost", ResourceType = typeof(InvoiceResx))]
        public decimal ExtendedCost { get; set; }

        /// <summary>
        /// Gets or sets Total
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "Total", ResourceType = typeof(InvoiceResx))]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets AdditionalCosts
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "AdditionalCosts", ResourceType = typeof(InvoiceResx))]
        public decimal AdditionalCosts { get; set; }

        /// <summary>
        /// Gets or sets QuantityReceived
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "QuantityReceived", ResourceType = typeof(InvoiceResx))]
        public decimal QuantityReceived { get; set; }

        /// <summary>
        /// Gets or sets TaxGroup
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxGroup", ResourceType = typeof(InvoiceResx))]
        public string TaxGroup { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority1
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxAuthority1", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority1 { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority2
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxAuthority2", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority2 { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority3
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxAuthority3", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority3 { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority4
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxAuthority4", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority4 { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority5
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxAuthority5", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority5 { get; set; }

        /// <summary>
        /// Gets or sets TaxClass1
        /// </summary>
        [Display(Name = "TaxClass1", ResourceType = typeof(InvoiceResx))]
        public int TaxClass1 { get; set; }

        /// <summary>
        /// Gets or sets TaxClass2
        /// </summary>
        [Display(Name = "TaxClass2", ResourceType = typeof(InvoiceResx))]
        public int TaxClass2 { get; set; }

        /// <summary>
        /// Gets or sets TaxClass3
        /// </summary>
        [Display(Name = "TaxClass3", ResourceType = typeof(InvoiceResx))]
        public int TaxClass3 { get; set; }

        /// <summary>
        /// Gets or sets TaxClass4
        /// </summary>
        [Display(Name = "TaxClass4", ResourceType = typeof(InvoiceResx))]
        public int TaxClass4 { get; set; }

        /// <summary>
        /// Gets or sets TaxClass5
        /// </summary>
        [Display(Name = "TaxClass5", ResourceType = typeof(InvoiceResx))]
        public int TaxClass5 { get; set; }

        /// <summary>
        /// Gets or sets TaxBase1
        /// </summary>
        [Display(Name = "TaxBase1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase1 { get; set; }

        /// <summary>
        /// Gets or sets TaxBase2
        /// </summary>
        [Display(Name = "TaxBase2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase2 { get; set; }

        /// <summary>
        /// Gets or sets TaxBase3
        /// </summary>
        [Display(Name = "TaxBase3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase3 { get; set; }

        /// <summary>
        /// Gets or sets TaxBase4
        /// </summary>
        [Display(Name = "TaxBase4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase4 { get; set; }

        /// <summary>
        /// Gets or sets TaxBase5
        /// </summary>
        [Display(Name = "TaxBase5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase5 { get; set; }

        /// <summary>
        /// Gets or sets IncludedTaxAmount1
        /// </summary>
        [Display(Name = "IncludedTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal IncludedTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets IncludedTaxAmount2
        /// </summary>
        [Display(Name = "IncludedTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal IncludedTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets IncludedTaxAmount3
        /// </summary>
        [Display(Name = "IncludedTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal IncludedTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets IncludedTaxAmount4
        /// </summary>
        [Display(Name = "IncludedTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal IncludedTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets IncludedTaxAmount5
        /// </summary>
        [Display(Name = "IncludedTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal IncludedTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets ExcludedTaxAmount1
        /// </summary>
        [Display(Name = "ExcludedTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal ExcludedTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets ExcludedTaxAmount2
        /// </summary>
        [Display(Name = "ExcludedTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal ExcludedTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets ExcludedTaxAmount3
        /// </summary>
        [Display(Name = "ExcludedTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal ExcludedTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets ExcludedTaxAmount4
        /// </summary>
        [Display(Name = "ExcludedTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal ExcludedTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets ExcludedTaxAmount5
        /// </summary>
        [Display(Name = "ExcludedTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal ExcludedTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount1
        /// </summary>
        [Display(Name = "TaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount2
        /// </summary>
        [Display(Name = "TaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount3
        /// </summary>
        [Display(Name = "TaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount4
        /// </summary>
        [Display(Name = "TaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount5
        /// </summary>
        [Display(Name = "TaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount1
        /// </summary>
        [Display(Name = "RecoverableTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount2
        /// </summary>
        [Display(Name = "RecoverableTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount3
        /// </summary>
        [Display(Name = "RecoverableTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount4
        /// </summary>
        [Display(Name = "RecoverableTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount5
        /// </summary>
        [Display(Name = "RecoverableTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount1
        /// </summary>
        [Display(Name = "TaxExpenseAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExpenseAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount2
        /// </summary>
        [Display(Name = "TaxExpenseAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExpenseAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount3
        /// </summary>
        [Display(Name = "TaxExpenseAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExpenseAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount4
        /// </summary>
        [Display(Name = "TaxExpenseAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExpenseAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount5
        /// </summary>
        [Display(Name = "TaxExpenseAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExpenseAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount1
        /// </summary>
        [Display(Name = "TaxAllocatedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount2
        /// </summary>
        [Display(Name = "TaxAllocatedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount3
        /// </summary>
        [Display(Name = "TaxAllocatedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount4
        /// </summary>
        [Display(Name = "TaxAllocatedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount5
        /// </summary>
        [Display(Name = "TaxAllocatedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets NetOfTax
        /// </summary>
        [Display(Name = "NetofTax", ResourceType = typeof(InvoiceResx))]
        public decimal NetOfTax { get; set; }

        /// <summary>
        /// Gets or sets TotalsTaxIncluded
        /// </summary>
        [Display(Name = "TaxIncluded", ResourceType = typeof(InvoiceResx))]
        public decimal TotalsTaxIncluded { get; set; }

        /// <summary>
        /// Gets or sets TotalsTaxExcluded
        /// </summary>
        [Display(Name = "TaxExcluded", ResourceType = typeof(InvoiceResx))]
        public decimal TotalsTaxExcluded { get; set; }

        /// <summary>
        /// Gets or sets TotalTax
        /// </summary>
        [Display(Name = "TotalTax", ResourceType = typeof(InvoiceResx))]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Gets or sets TotalTaxRecoverable
        /// </summary>
        [Display(Name = "TotalTaxRecoverable", ResourceType = typeof(InvoiceResx))]
        public decimal TotalTaxRecoverable { get; set; }

        /// <summary>
        /// Gets or sets TotalTaxExpensed
        /// </summary>
        [Display(Name = "TotalTaxExpensed", ResourceType = typeof(InvoiceResx))]
        public decimal TotalTaxExpensed { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocattedAmount
        /// </summary>
        [Display(Name = "TotalTaxAllocated", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocattedAmount { get; set; }

        /// <summary>
        /// Gets or sets Num1099CPRSClass
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "_1099CPRSClass", ResourceType = typeof(InvoiceResx))]
        public string Num1099CPRSClass { get; set; }

        /// <summary>
        /// Gets or sets The1099CPRSAmount
        /// </summary>
        [Display(Name = "The1099CPRSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal The1099CPRSAmount { get; set; }

        /// <summary>
        /// Gets or sets ManualProrationTotal
        /// </summary>
        [IgnoreExportImport]
        public decimal ManualProrationTotal { get; set; }

        /// <summary>
        /// Gets or sets ManualToProrate
        /// </summary>
        [IgnoreExportImport]
        public decimal ManualToProrate { get; set; }

        /// <summary>
        /// Gets or sets ManualProrationExpensed
        /// </summary>
        [IgnoreExportImport]
        public decimal ManualProrationExpensed { get; set; }

        /// <summary>
        /// Gets or sets ConversionSourceAmount
        /// </summary>
        [IgnoreExportImport]
        public decimal ConversionSourceAmount { get; set; }

        /// <summary>
        /// Gets or sets ConversionFunctionalAmount
        /// </summary>
        [IgnoreExportImport]
        public decimal ConversionFunctionalAmount { get; set; }

        /// <summary>
        /// Gets or sets MultipleReceipts
        /// </summary>
        [Display(Name = "MultipleReceipts", ResourceType = typeof(InvoiceResx))]
        public POOERateOverridden MultipleReceipts { get; set; }

        /// <summary>
        /// Gets or sets MultipleReceiptsBool 
        /// </summary>
        [IgnoreExportImport]
        public bool MultipleReceiptsBool { get; set; }
        /// <summary>
        /// Gets or sets Receipts
        /// </summary>
        [IgnoreExportImport]
        public long Receipts { get; set; }

        /// <summary>
        /// Gets or sets BillToLocation
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToLocation", ResourceType = typeof(InvoiceResx))]
        public string BillToLocation { get; set; }

        /// <summary>
        /// Gets or sets BillToLocationDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToLocInfo", ResourceType = typeof(InvoiceResx))]
        public string BillToLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets BillToAddress1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToAddress1", ResourceType = typeof(InvoiceResx))]
        public string BillToAddress1 { get; set; }

        /// <summary>
        /// Gets or sets BillToAddress2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToAddress2", ResourceType = typeof(InvoiceResx))]
        public string BillToAddress2 { get; set; }

        /// <summary>
        /// Gets or sets BillToAddress3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToAddress3", ResourceType = typeof(InvoiceResx))]
        public string BillToAddress3 { get; set; }

        /// <summary>
        /// Gets or sets BillToAddress4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToAddress4", ResourceType = typeof(InvoiceResx))]
        public string BillToAddress4 { get; set; }

        /// <summary>
        /// Gets or sets BillToCity
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToCity", ResourceType = typeof(InvoiceResx))]
        public string BillToCity { get; set; }

        /// <summary>
        /// Gets or sets BillToStateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToStateProvince", ResourceType = typeof(InvoiceResx))]
        public string BillToStateProvince { get; set; }

        /// <summary>
        /// Gets or sets BillToZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToZipPostalCode", ResourceType = typeof(InvoiceResx))]
        public string BillToZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets BillToCountry
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToCountry", ResourceType = typeof(InvoiceResx))]
        public string BillToCountry { get; set; }

        /// <summary>
        /// Gets or sets BillToPhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToPhoneNumber", ResourceType = typeof(InvoiceResx))]
        public string BillToPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets BillToFaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToFaxNumber", ResourceType = typeof(InvoiceResx))]
        public string BillToFaxNumber { get; set; }

        /// <summary>
        /// Gets or sets BillToContact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToContact", ResourceType = typeof(InvoiceResx))]
        public string BillToContact { get; set; }

        /// <summary>
        /// Gets or sets ShipToLocation
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToLocationCode", ResourceType = typeof(InvoiceResx))]
        public string ShipToLocation { get; set; }

        /// <summary>
        /// Gets or sets ShipToLocationDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToLocationDesc", ResourceType = typeof(InvoiceResx))]
        public string ShipToLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddress1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine1", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddress1 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddress2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine2", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddress2 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddress3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine3", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddress3 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddress4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine4", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddress4 { get; set; }

        /// <summary>
        /// Gets or sets ShipToCity
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToCity", ResourceType = typeof(InvoiceResx))]
        public string ShipToCity { get; set; }

        /// <summary>
        /// Gets or sets ShipToStateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToStateOrProv", ResourceType = typeof(InvoiceResx))]
        public string ShipToStateProvince { get; set; }

        /// <summary>
        /// Gets or sets ShipToZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToZipOrPostalCode", ResourceType = typeof(InvoiceResx))]
        public string ShipToZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets ShipToCountry
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToCountry", ResourceType = typeof(InvoiceResx))]
        public string ShipToCountry { get; set; }

        /// <summary>
        /// Gets or sets ShipToPhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToPhoneNumber", ResourceType = typeof(InvoiceResx))]
        public string ShipToPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets ShipToFaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToFaxNumber", ResourceType = typeof(InvoiceResx))]
        public string ShipToFaxNumber { get; set; }

        /// <summary>
        /// Gets or sets ShipToContact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactName", ResourceType = typeof(InvoiceResx))]
        public string ShipToContact { get; set; }

        /// <summary>
        /// Gets or sets RemitToLocation
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToLocation", ResourceType = typeof(InvoiceResx))]
        public string RemitToLocation { get; set; }

        /// <summary>
        /// Gets or sets RemitToLocationDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToDescription", ResourceType = typeof(InvoiceResx))]
        public string RemitToLocationDescription { get; set; }

        /// <summary>
        /// Gets or sets RemitToAddress1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToAddress1", ResourceType = typeof(InvoiceResx))]
        public string RemitToAddress1 { get; set; }

        /// <summary>
        /// Gets or sets RemitToAddress2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToAddress2", ResourceType = typeof(InvoiceResx))]
        public string RemitToAddress2 { get; set; }

        /// <summary>
        /// Gets or sets RemitToAddress3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToAddress3", ResourceType = typeof(InvoiceResx))]
        public string RemitToAddress3 { get; set; }

        /// <summary>
        /// Gets or sets RemitToAddress4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToAddress4", ResourceType = typeof(InvoiceResx))]
        public string RemitToAddress4 { get; set; }

        /// <summary>
        /// Gets or sets RemitToCity
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToCity", ResourceType = typeof(InvoiceResx))]
        public string RemitToCity { get; set; }

        /// <summary>
        /// Gets or sets RemitToStateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToStateProvince", ResourceType = typeof(InvoiceResx))]
        public string RemitToStateProvince { get; set; }

        /// <summary>
        /// Gets or sets RemitToZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToZipPostalCode", ResourceType = typeof(InvoiceResx))]
        public string RemitToZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets RemitToCountry
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToCountry", ResourceType = typeof(InvoiceResx))]
        public string RemitToCountry { get; set; }

        /// <summary>
        /// Gets or sets RemitToPhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToPhoneNumber", ResourceType = typeof(InvoiceResx))]
        public string RemitToPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets RemitToFaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToFaxNumber", ResourceType = typeof(InvoiceResx))]
        public string RemitToFaxNumber { get; set; }

        /// <summary>
        /// Gets or sets RemitToContact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToContact", ResourceType = typeof(InvoiceResx))]
        public string RemitToContact { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsExchangeRate
        /// </summary>
        [IgnoreExportImport]
        public decimal PredecessorsExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsRateType
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PredecessorsRateType { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsRateDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public DateTime PredecessorsRateDate { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsRateOperation
        /// </summary>
        [IgnoreExportImport]
        public PredecessorsRateOperation PredecessorsRateOperation { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsRateOverridden
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden PredecessorsRateOverridden { get; set; }

        /// <summary>
        /// Gets or sets TaxClass1Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxClass1Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass2Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxClass2Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass3Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxClass3Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass4Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxClass4Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass5Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxClass5Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority1Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuthority1Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority2Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuthority2Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority3Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuthority3Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority4Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuthority4Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuthority5Description
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuthority5Description { get; set; }

        /// <summary>
        /// Gets or sets CurrencyDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        [Display(Name = "CurrencyDescription", ResourceType = typeof(InvoiceResx))]
        public string CurrencyDescription { get; set; }

        /// <summary>
        /// Gets or sets RateTypeDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        [Display(Name = "RateTypeDescription", ResourceType = typeof(InvoiceResx))]
        public string RateTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets LastReceiptNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string LastReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets NumberOfPostedReceipts
        /// </summary>
        [IgnoreExportImport]
        public int NumberOfPostedReceipts { get; set; }

        /// <summary>
        /// Gets or sets TaxGroupDescription
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxGroupDescription", ResourceType = typeof(InvoiceResx))]
        public string TaxGroupDescription { get; set; }

        /// <summary>
        /// Gets or sets TermsCodeDescription
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TermsCodeDescription", ResourceType = typeof(InvoiceResx))]
        public string TermsCodeDescription { get; set; }

        /// <summary>
        /// Gets or sets PredecessorsRateTypeDescript
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PredecessorsRateTypeDescript { get; set; }

        /// <summary>
        /// Gets or sets NetOfTaxSum
        /// </summary>
        [IgnoreExportImport]
        public decimal NetOfTaxSum { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxIncluded1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxIncluded2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxIncluded3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxIncluded4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxIncluded5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAllocatedAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAllocatedAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAllocatedAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAllocatedAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAllocatedAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRecoverableAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRecoverableAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRecoverableAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRecoverableAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRecoverableAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExpenseAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExpenseAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExpenseAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExpenseAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExpenseAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExpenseAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxCalcAllocatedAmount
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxCalcAllocatedAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxCalcIncuded
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxCalcIncuded { get; set; }

        /// <summary>
        /// Gets or sets TaxCalcExcluded
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxCalcExcluded { get; set; }

        /// <summary>
        /// Gets or sets TotalUnbalancedTax
        /// </summary>
        [IgnoreExportImport]
        public decimal TotalUnbalancedTax { get; set; }

        /// <summary>
        /// Gets or sets TotalUnbalancedAllocatedTax
        /// </summary>
        [IgnoreExportImport]
        public decimal TotalUnbalancedAllocatedTax { get; set; }

        /// <summary>
        /// Gets or sets UnbalancedManualProrationAmou
        /// </summary>
        [IgnoreExportImport]
        public decimal UnbalancedManualProrationAmou { get; set; }

        /// <summary>
        /// Gets or sets InvoiceTotal
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceTotal", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceTotal { get; set; }

        /// <summary>
        /// Gets or sets Subtotal
        /// </summary>
        [IgnoreExportImport]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets TaxcalculationIspending
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden TaxcalculationIspending { get; set; }

        /// <summary>
        /// Gets or sets SubjectTo1099CPRSReporting
        /// </summary>
        [IgnoreExportImport]
        public AutoTaxCalculationOnSave SubjectTo1099CPRSReporting { get; set; }

        /// <summary>
        /// Gets or sets DocumentLocked
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden DocumentLocked { get; set; }

        /// <summary>
        /// Gets or sets IsDocumentDeletable
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden IsDocumentDeletable { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRateExists
        /// </summary>
        [IgnoreExportImport]
        public AllowedType ExchangeRateExists { get; set; }

        /// <summary>
        /// Gets or sets HasDetails
        /// </summary>
        [IgnoreExportImport]
        public AllowedType HasDetails { get; set; }

        /// <summary>
        /// Gets or sets NumberOfCostGroups
        /// </summary>
        [IgnoreExportImport]
        public long NumberOfCostGroups { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EmailAddress", ResourceType = typeof(InvoiceResx))]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets ContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsPhone", ResourceType = typeof(InvoiceResx))]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets ContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsFax", ResourceType = typeof(InvoiceResx))]
        public string ContactFax { get; set; }

        /// <summary>
        /// Gets or sets ContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsEmail", ResourceType = typeof(InvoiceResx))]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets BillToEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToEmail", ResourceType = typeof(InvoiceResx))]
        public string BillToEmail { get; set; }

        /// <summary>
        /// Gets or sets BillToContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToContactPhone", ResourceType = typeof(InvoiceResx))]
        public string BillToContactPhone { get; set; }

        /// <summary>
        /// Gets or sets BillToContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToContactFax", ResourceType = typeof(InvoiceResx))]
        public string BillToContactFax { get; set; }

        /// <summary>
        /// Gets or sets BillToContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BillToContactEmail", ResourceType = typeof(InvoiceResx))]
        public string BillToContactEmail { get; set; }

        /// <summary>
        /// Gets or sets ShipToEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToEmail", ResourceType = typeof(InvoiceResx))]
        public string ShipToEmail { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactsPhone", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactPhone { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactsFax", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactFax { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactsEmail", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactEmail { get; set; }

        /// <summary>
        /// Gets or sets RemitToEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToEmail", ResourceType = typeof(InvoiceResx))]
        public string RemitToEmail { get; set; }

        /// <summary>
        /// Gets or sets RemitToContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToContactPhone", ResourceType = typeof(InvoiceResx))]
        public string RemitToContactPhone { get; set; }

        /// <summary>
        /// Gets or sets RemitToContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToContactFax", ResourceType = typeof(InvoiceResx))]
        public string RemitToContactFax { get; set; }

        /// <summary>
        /// Gets or sets RemitToContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToContactEmail", ResourceType = typeof(InvoiceResx))]
        public string RemitToContactEmail { get; set; }

        /// <summary>
        /// Gets or sets DiscountPercentage
        /// </summary>
        [Display(Name = "DiscPercent", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets DiscountAmount
        /// </summary>
        [Display(Name = "DiscAmount", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets DiscountAmountSum
        /// </summary>
        [Display(Name = "DiscAmountSum", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public decimal DiscountAmountSum { get; set; }

        /// <summary>
        /// Gets or sets NetExtendedCost
        /// </summary>
        [IgnoreExportImport]
        public decimal NetExtendedCost { get; set; }

        /// <summary>
        /// Gets or sets OptionalFields
        /// </summary>
        [IgnoreExportImport]
        public long OptionalFields { get; set; }

        /// <summary>
        /// Gets or sets Command
        /// </summary>
        [IgnoreExportImport]
        public Command Command { get; set; }

        /// <summary>
        /// Gets or sets OnHold
        /// </summary>
        [Display(Name = "OnHold", ResourceType = typeof(InvoiceResx))]
        public AllowedType OnHold { get; set; }

        /// <summary>
        /// Gets or sets OnHoldBool 
        /// </summary>
        [IgnoreExportImport]
        public bool OnHoldBool { get; set; }

        /// <summary>
        /// Gets or sets PaymentDiscountBaseWithTax
        /// </summary>
        [Display(Name = "PaymentDiscountBaseWithTax", ResourceType = typeof(InvoiceResx))]
        public decimal PaymentDiscountBaseWithTax { get; set; }

        /// <summary>
        /// Gets or sets PaymentDiscountBaseWithoutTa
        /// </summary>
        [Display(Name = "PaymentDisctBaseWithoutTax", ResourceType = typeof(InvoiceResx))]
        public decimal PaymentDiscountBaseWithoutTa { get; set; }

        /// <summary>
        /// Gets or sets ProrationVersion
        /// </summary>
        [IgnoreExportImport]
        public ProrationVersion ProrationVersion { get; set; }

        /// <summary>
        /// Gets or sets HasRetainage
        /// </summary>
        [Display(Name = "HasRetainage", ResourceType = typeof(InvoiceResx))]
        public POOERateOverridden HasRetainage { get; set; }

        /// <summary>
        /// Gets or sets RetainageExchangeRate
        /// </summary>
        [Display(Name = "RetainageExchangeRate", ResourceType = typeof(InvoiceResx))]
        public RetainageExchangeRate RetainageExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets RetainageBase
        /// </summary>
        [IgnoreExportImport]
        public POOERetainageBase RetainageBase { get; set; }

        /// <summary>
        /// Gets or sets RetainageTermsCode
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RetainageTermsCode", ResourceType = typeof(InvoiceResx))]
        public string RetainageTermsCode { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmount
        /// </summary>
        [Display(Name = "RetainageAmount", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public decimal RetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets JobRelatedLines
        /// </summary>
        [IgnoreExportImport]
        public long JobRelatedLines { get; set; }

        /// <summary>
        /// Gets or sets JobRelatedCosts
        /// </summary>
        [IgnoreExportImport]
        public long JobRelatedCosts { get; set; }

        /// <summary>
        /// Gets or sets RetainageTermsCodeDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string RetainageTermsCodeDescription { get; set; }

        /// <summary>
        /// Gets or sets JobRelated
        /// </summary>
        [Display(Name = "JobRelated", ResourceType = typeof(InvoiceResx))]
        public AllowedType JobRelated { get; set; }

        /// <summary>
        /// Gets or sets UnretainedTotal
        /// </summary>
        [IgnoreExportImport]
        public decimal UnretainedTotal { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingCurrency
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingCurrencyCode", ResourceType = typeof(InvoiceResx))]
        public string TaxReportingCurrency { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExchangeRate
        /// </summary>
        [Display(Name = "TaxReportingExchangeRate", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateSpread
        /// </summary>
        [Display(Name = "TaxReportingRateSpread", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRateSpread { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateType
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingRateType", ResourceType = typeof(InvoiceResx))]
        public string TaxReportingRateType { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateMatchType
        /// </summary>
        [Display(Name = "TaxReportingRateMatchType", ResourceType = typeof(InvoiceResx))]
        public int TaxReportingRateMatchType { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingRateDate", ResourceType = typeof(InvoiceResx))]
        public DateTime TaxReportingRateDate { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateOperation
        /// </summary>
        [Display(Name = "TaxReportingRateOperation", ResourceType = typeof(InvoiceResx))]
        public RateOperation TaxReportingRateOperation { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateOverridden
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "TaxReportingRateOverride", ResourceType = typeof(InvoiceResx))]
        public POOERateOverridden TaxReportingRateOverridden { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingDecimalPlaces
        /// </summary>
        [IgnoreExportImport]
        public int TaxReportingDecimalPlaces { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount1
        /// </summary>
        [Display(Name = "TaxReportingAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount2
        /// </summary>
        [Display(Name = "TaxReportingAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount3
        /// </summary>
        [Display(Name = "TaxReportingAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount4
        /// </summary>
        [Display(Name = "TaxReportingAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount5
        /// </summary>
        [Display(Name = "TaxReportingAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount1
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount2
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount3
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount4
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount5
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount1
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount2
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount3
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount4
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount5
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmt1
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmt1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmt1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmt2
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmt2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmt2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmt3
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmt3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmt3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmt4
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmt4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmt4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmt5
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmt5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmt5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpenseAmount1
        /// </summary>
        [Display(Name = "TaxReportingExpenseAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpenseAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpenseAmount2
        /// </summary>
        [Display(Name = "TaxReportingExpenseAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpenseAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpenseAmount3
        /// </summary>
        [Display(Name = "TaxReportingExpenseAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpenseAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpenseAmount4
        /// </summary>
        [Display(Name = "TaxReportingExpenseAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpenseAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpenseAmount5
        /// </summary>
        [Display(Name = "TaxReportingExpenseAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpenseAmount5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount1
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount2
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount3
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount4
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount5
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets PredTaxReportingExchRate
        /// </summary>
        [IgnoreExportImport]
        public decimal PredTaxReportingExchRate { get; set; }

        /// <summary>
        /// Gets or sets PredTaxReportingRateType
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PredTaxReportingRateType { get; set; }

        /// <summary>
        /// Gets or sets PredTaxReportingRateDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public DateTime PredTaxReportingRateDate { get; set; }

        /// <summary>
        /// Gets or sets PredTaxReportingRateOper
        /// </summary>
        [IgnoreExportImport]
        public RateOperator PredTaxReportingRateOper { get; set; }

        /// <summary>
        /// Gets or sets PredTaxReportingRateOverrd
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden PredTaxReportingRateOverrd { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExchRateExists
        /// </summary>
        [IgnoreExportImport]
        public AllowedType TaxReportingExchRateExists { get; set; }

        /// <summary>
        /// Gets or sets DerivedTaxReportingExchRate
        /// </summary>
        [IgnoreExportImport]
        public decimal DerivedTaxReportingExchRate { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingCurrencyDesc
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        [Display(Name = "TaxReportingCurrencyDesc", ResourceType = typeof(InvoiceResx))]
        public string TaxReportingCurrencyDesc { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateTypeDesc
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxReportingRateTypeDesc { get; set; }

        /// <summary>
        /// Gets or sets PredTaxRepRateTypeDesc
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PredTaxRepRateTypeDesc { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingTotalAmount
        /// </summary>
        [Display(Name = "TaxReportingTotalAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncludedAmount
        /// </summary>
        [Display(Name = "TaxReportingIncludedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingIncludedAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcludedAmount
        /// </summary>
        [Display(Name = "TaxReportingExcludedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExcludedAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableAmount
        /// </summary>
        [Display(Name = "TaxReportingRecoverableAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedAmount
        /// </summary>
        [Display(Name = "TaxReportingExpensedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedAmount
        /// </summary>
        [Display(Name = "TaxReportingAllocatedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxBase1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxBase1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxBase2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxBase2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxBase3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxBase3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxBase4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxBase4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxBase5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxBase5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExcluded1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExcluded2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExcluded3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExcluded4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxExcluded5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncluded1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingIncluded1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncluded2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingIncluded2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncluded3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingIncluded3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncluded4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingIncluded4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingIncluded5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingIncluded5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcluded1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingExcluded1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcluded2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingExcluded2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcluded3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingExcluded3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcluded4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingExcluded4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExcluded5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxReportingExcluded5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepAllocatedAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepAllocatedAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepAllocatedAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepAllocatedAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepAllocatedAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepAllocatedAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepAllocatedAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepAllocatedAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepAllocatedAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepAllocatedAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepRecoverableAmt1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepRecoverableAmt1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepRecoverableAmt2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepRecoverableAmt2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepRecoverableAmt3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepRecoverableAmt3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepRecoverableAmt4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepRecoverableAmt4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepRecoverableAmt5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepRecoverableAmt5Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepExpenseAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepExpenseAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepExpenseAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepExpenseAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepExpenseAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepExpenseAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepExpenseAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepExpenseAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets TaxRepExpenseAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal TaxRepExpenseAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets ReportRetainageTax
        /// </summary>
        [IgnoreExportImport]
        public POOEReportRetainageTax ReportRetainageTax { get; set; }

        /// <summary>
        /// Gets or sets TaxStateVersion
        /// </summary>
        [IgnoreExportImport]
        public long TaxStateVersion { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase1
        /// </summary>
        [Display(Name = "RetainageTaxBase1", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase1 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase2
        /// </summary>
        [Display(Name = "RetainageTaxBase2", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase2 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase3
        /// </summary>
        [Display(Name = "RetainageTaxBase3", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase3 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase4
        /// </summary>
        [Display(Name = "RetainageTaxBase4", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase4 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase5
        /// </summary>
        [Display(Name = "RetainageTaxBase5", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase5 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount1
        /// </summary>
        [Display(Name = "RetainageTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount2
        /// </summary>
        [Display(Name = "RetainageTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount3
        /// </summary>
        [Display(Name = "RetainageTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount4
        /// </summary>
        [Display(Name = "RetainageTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount5
        /// </summary>
        [Display(Name = "RetainageTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxRecoverableAmt1
        /// </summary>
        [Display(Name = "RetainageTaxRecoverableAmt1", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxRecoverableAmt1 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxRecoverableAmt2
        /// </summary>
        [Display(Name = "RetainageTaxRecoverableAmt2", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxRecoverableAmt2 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxRecoverableAmt3
        /// </summary>
        [Display(Name = "RetainageTaxRecoverableAmt3", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxRecoverableAmt3 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxRecoverableAmt4
        /// </summary>
        [Display(Name = "RetainageTaxRecoverableAmt4", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxRecoverableAmt4 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxRecoverableAmt5
        /// </summary>
        [Display(Name = "RetainageTaxRecoverableAmt5", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxRecoverableAmt5 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpenseAmount1
        /// </summary>
        [Display(Name = "RetainageTaxExpenseAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpenseAmount1 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpenseAmount2
        /// </summary>
        [Display(Name = "RetainageTaxExpenseAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpenseAmount2 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpenseAmount3
        /// </summary>
        [Display(Name = "RetainageTaxExpenseAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpenseAmount3 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpenseAmount4
        /// </summary>
        [Display(Name = "RetainageTaxExpenseAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpenseAmount4 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpenseAmount5
        /// </summary>
        [Display(Name = "RetainageTaxExpenseAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpenseAmount5 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocatedAmount1
        /// </summary>
        [Display(Name = "RetainageTaxAllocatedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocatedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocatedAmount2
        /// </summary>RetainageTaxExpenseAmount5
        [Display(Name = "RetainageTaxAllocatedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocatedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocatedAmount3
        /// </summary>
        [Display(Name = "RetainageTaxAllocatedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocatedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocatedAmount4
        /// </summary>
        [Display(Name = "RetainageTaxAllocatedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocatedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocatedAmount5
        /// </summary>
        [Display(Name = "RetainageTaxAllocatedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocatedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets WarnOnRetainageTaxShift
        /// </summary>
        [IgnoreExportImport]
        public POOERateOverridden WarnOnRetainageTaxShift { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxTotalAmount
        /// </summary>
        [Display(Name = "RetainageTaxTotalAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountPlusRtgTaxAmt1
        /// </summary>
        [Display(Name = "TaxAmountPlusRtgTaxAmt1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountPlusRtgTaxAmt1 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountPlusRtgTaxAmt2
        /// </summary>
        [Display(Name = "TaxAmountPlusRtgTaxAmt2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountPlusRtgTaxAmt2 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountPlusRtgTaxAmt3
        /// </summary>
        [Display(Name = "TaxAmountPlusRtgTaxAmt3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountPlusRtgTaxAmt3 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountPlusRtgTaxAmt4
        /// </summary>
        [Display(Name = "TaxAmountPlusRtgTaxAmt4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountPlusRtgTaxAmt4 { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountPlusRtgTaxAmt5
        /// </summary>
        [Display(Name = "TaxAmountPlusRtgTaxAmt5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountPlusRtgTaxAmt5 { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxBase1Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxBase2Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxBase3Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxBase4Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxBase5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxBase5Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RetainageTaxAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxRecoverableAmt1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxRecoverableAmt1Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxRecoverableAmt2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxRecoverableAmt2Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxRecoverableAmt3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxRecoverableAmt3Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxRecoverableAmt4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxRecoverableAmt4Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxRecoverableAmt5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxRecoverableAmt5Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxExpenseAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxExpenseAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxExpenseAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxExpenseAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxExpenseAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxExpenseAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxExpenseAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxExpenseAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxExpenseAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxExpenseAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxAllocatedAmount1Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxAllocatedAmount1Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxAllocatedAmount2Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxAllocatedAmount2Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxAllocatedAmount3Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxAllocatedAmount3Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxAllocatedAmount4Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxAllocatedAmount4Sum { get; set; }

        /// <summary>
        /// Gets or sets RtgTaxAllocatedAmount5Sum
        /// </summary>
        [IgnoreExportImport]
        public decimal RtgTaxAllocatedAmount5Sum { get; set; }

        /// <summary>
        /// Gets or sets VendorAccountSet
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorAccountSet", ResourceType = typeof(InvoiceResx))]
        public string VendorAccountSet { get; set; }

        /// <summary>
        /// Gets or sets VendorAccountSetDescription
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorAcctSetDesc", ResourceType = typeof(InvoiceResx))]
        public string VendorAccountSetDescription { get; set; }

        /// <summary>
        /// Gets or sets PostingDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PostingDate", ResourceType = typeof(InvoiceResx))]
        public DateTime PostingDate { get; set; }

        /// <summary>
        /// Gets or sets EnteredBy
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EnteredBy", ResourceType = typeof(InvoiceResx))]
        public string EnteredBy { get; set; }

        /// <summary>
        /// Gets or sets NextDetailNumber
        /// </summary>
        [Display(Name = "NextDetailNumber", ResourceType = typeof(InvoiceResx))]
        public int NextDetailNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoicePaymentSchedule
        /// </summary>
        [IgnoreExportImport]
        public EnumerableResponse<POOEBaseInvPaymentSchedule> InvoicePaymentSchedule { get; set; }

        /// <summary>
        /// Gets or sets Invoice Line
        /// </summary>
        [IgnoreExportImport]
        public EnumerableResponse<POOEBaseInvoiceLine> InvoiceLine { get; set; }

        /// <summary>
        /// Gets or sets Invoice Line
        /// </summary>
        [IgnoreExportImport]
        public EnumerableResponse<BaseInvoiceOptionalField> OptionalFieldList { get; set; }

        /// <summary>
        /// Gets Autotaxcalculationonsave string value
        /// </summary>
        [IgnoreExportImport]
        public string AutotaxcalculationonsaveString
        {
            get { return EnumUtility.GetStringValue(Autotaxcalculationonsave); }
        }

        /// <summary>
        /// Gets Completed string value
        /// </summary>
        [IgnoreExportImport]
        public string CompletedString
        {
            get { return EnumUtility.GetStringValue(Completed); }
        }

        /// <summary>
        /// Gets FiscalPeriod string value
        /// </summary>
        [IgnoreExportImport]
        public string FiscalPeriodString
        {
            get { return EnumUtility.GetStringValue(FiscalPeriod); }
        }

        /// <summary>
        /// Gets VendorExists string value
        /// </summary>
        [IgnoreExportImport]
        public string VendorExistsString
        {
            get { return EnumUtility.GetStringValue(VendorExists); }
        }

        /// <summary>
        /// Gets FromDocument string value
        /// </summary>
        [IgnoreExportImport]
        public string FromDocumentString
        {
            get { return EnumUtility.GetStringValue(FromDocument); }
        }

        /// <summary>
        /// Gets RateOperation string value
        /// </summary>
        [IgnoreExportImport]
        public string RateOperationString
        {
            get { return EnumUtility.GetStringValue(RateOperation); }
        }

        /// <summary>
        /// Gets RateOverridden string value
        /// </summary>
        [IgnoreExportImport]
        public string RateOverriddenString
        {
            get { return EnumUtility.GetStringValue(RateOverridden); }
        }

        /// <summary>
        /// Gets MultipleReceipts string value
        /// </summary>
        [IgnoreExportImport]
        public string MultipleReceiptsString
        {
            get { return EnumUtility.GetStringValue(MultipleReceipts); }
        }

        /// <summary>
        /// Gets PredecessorsRateOperation string value
        /// </summary>
        [IgnoreExportImport]
        public string PredecessorsRateOperationString
        {
            get { return EnumUtility.GetStringValue(PredecessorsRateOperation); }
        }

        /// <summary>
        /// Gets PredecessorsRateOverridden string value
        /// </summary>
        [IgnoreExportImport]
        public string PredecessorsRateOverriddenString
        {
            get { return EnumUtility.GetStringValue(PredecessorsRateOverridden); }
        }

        /// <summary>
        /// Gets ReportRetainageTax string value
        /// </summary>
        [IgnoreExportImport]
        public string ReportRetainageTaxString
        {
            get { return EnumUtility.GetStringValue(ReportRetainageTax); }
        }

        /// <summary>
        /// Gets TaxReportingExchRateExists string value
        /// </summary>
        [IgnoreExportImport]
        public string TaxReportingExchRateExistsString
        {
            get { return EnumUtility.GetStringValue(TaxReportingExchRateExists); }
        }

        /// <summary>
        /// Gets PredTaxReportingRateOverrd string value
        /// </summary>
        [IgnoreExportImport]
        public string PredTaxReportingRateOverrdString
        {
            get { return EnumUtility.GetStringValue(PredTaxReportingRateOverrd); }
        }

        /// <summary>
        /// Gets TaxReportingRateOverridden string value
        /// </summary>
        [IgnoreExportImport]
        public string TaxReportingRateOverriddenString
        {
            get { return EnumUtility.GetStringValue(TaxReportingRateOverridden); }
        }

        /// <summary>
        /// Gets TaxReportingRateOperation string value
        /// </summary>
        [IgnoreExportImport]
        public string TaxReportingRateOperationString
        {
            get { return EnumUtility.GetStringValue(TaxReportingRateOperation); }
        }

        /// <summary>
        /// Gets JobRelated string value
        /// </summary>
        [IgnoreExportImport]
        public string JobRelatedString
        {
            get { return EnumUtility.GetStringValue(JobRelated); }
        }

        /// <summary>
        /// Gets RetainageBase string value
        /// </summary>
        [IgnoreExportImport]
        public string RetainageBaseString
        {
            get { return EnumUtility.GetStringValue(RetainageBase); }
        }

        /// <summary>
        /// Gets RetainageExchangeRate string value
        /// </summary>
        [IgnoreExportImport]
        public string RetainageExchangeRateString
        {
            get { return EnumUtility.GetStringValue(RetainageExchangeRate); }
        }

        /// <summary>
        /// Gets HasRetainage string value
        /// </summary>
        [IgnoreExportImport]
        public string HasRetainageString
        {
            get { return EnumUtility.GetStringValue(HasRetainage); }
        }

        /// <summary>
        /// Gets OnHold string value
        /// </summary>
        [IgnoreExportImport]
        public string OnHoldString
        {
            get { return EnumUtility.GetStringValue(OnHold); }
        }

        /// <summary>
        /// Gets HasDetails string value
        /// </summary>
        public string HasDetailsString
        {
            get { return EnumUtility.GetStringValue(HasDetails); }
        }

        /// <summary>
        /// Gets ExchangeRateExists string value
        /// </summary>
        [IgnoreExportImport]
        public string ExchangeRateExistsString
        {
            get { return EnumUtility.GetStringValue(ExchangeRateExists); }
        }

        /// <summary>
        /// Gets IsDocumentDeletable string value
        /// </summary>
        [IgnoreExportImport]
        public string IsDocumentDeletableString
        {
            get { return EnumUtility.GetStringValue(IsDocumentDeletable); }
        }

        /// <summary>
        /// Gets DocumentLocked string value
        /// </summary>
        [IgnoreExportImport]
        public string DocumentLockedString
        {
            get { return EnumUtility.GetStringValue(DocumentLocked); }
        }

        /// <summary>
        /// Gets SubjectTo1099CPRSReporting string value
        /// </summary>
        [IgnoreExportImport]
        public string SubjectTo1099CPRSReportingString
        {
            get { return EnumUtility.GetStringValue(SubjectTo1099CPRSReporting); }
        }

        /// <summary>
        /// Gets or sets Additional Cost Superview
        /// </summary>
        [IgnoreExportImport]
        public EnumerableResponse<POOEInvBaseAddCostsSuperview> AdditionalCostSuperView { get; set; }

        /// <summary>
        /// Gets or sets Multiple Receipts List 
        /// </summary>
        [IgnoreExportImport]
        public EnumerableResponse<POOEBaseInvoiceReciepts> MultipleReceiptsList { get; set; }

        /// <summary>
        /// Gets and sets LineComments
        /// </summary>
        public EnumerableResponse<POOEBaseInvoiceComments> LineComments { get; set; }

        /// <summary>
        /// Gets and sets InvoiceAddCostDistribution
        /// </summary>
        public EnumerableResponse<POOEBaseAdditionalCost> InvoiceAddCostDistribution { get; set; }

        /// <summary>
        /// Gets or sets ImportDeclarationNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ImportDeclarationNumber", ResourceType = typeof(InvoiceResx))]
        public string ImportDeclarationNumber { get; set; }
    }
}
