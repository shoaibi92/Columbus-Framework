using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// BaseInvoice  model
    /// </summary>
    public partial class BaseInvoice : ModelBase
    {
        /// <summary>
        /// Constructor for BaseInvoice
        /// </summary>
        public BaseInvoice()
        {
            InvoiceDetails = new EnumerableResponse<BaseInvoiceDetail>();
            OptionalFieldList = new EnumerableResponse<BaseInvoiceOptionalField>();
        }
        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        [Display(Name = "BatchNumber", ResourceType = typeof(InvoiceResx))]
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceName = "OnlyNumbersMessage", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets EntryNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        [Display(Name = "EntryNumber", ResourceType = typeof(InvoiceResx))]
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceName = "OnlyNumbersMessage", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string EntryNumber { get; set; }

        /// <summary>
        /// Gets or sets DocumentType 
        /// </summary>
        [Display(Name = "DocumentType", ResourceType = typeof(InvoiceResx))]
        public DocumentType DocumentType { get; set; }


        /// <summary>
        /// Gets or sets TransactionType 
        /// </summary>
        [Display(Name = "TransactionType", ResourceType = typeof(InvoiceResx))]
        public ARTransactionType TransactionType { get; set; }

        /// <summary>
        /// Gets or sets OrderNumber 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OrderNumber", ResourceType = typeof(InvoiceResx))]
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets PONumber 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PONumber", ResourceType = typeof(InvoiceResx))]
        public string PONumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceDescription", ResourceType = typeof(InvoiceResx))]
        public string InvoiceDescription { get; set; }


        /// <summary>
        /// Gets or sets ApplytoDocument 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ApplyToDocument", ResourceType = typeof(InvoiceResx))]
        public string ApplytoDocument { get; set; }

        /// <summary>
        /// Gets or sets AccountSet 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AccountSet", ResourceType = typeof(InvoiceResx))]
        public string AccountSet { get; set; }

        /// <summary>
        /// Gets or sets DocumentDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DocumentDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? DocumentDate { get; set; }

        /// <summary>
        /// Gets or sets AsofDate 
        /// </summary>
        [ValidateDateFormatAllowNullAttribute(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AsOfDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? AsofDate { get; set; }


        /// <summary>
        /// Gets or sets FiscalYear 
        /// </summary>
        [StringLength(4, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "FiscalYear", ResourceType = typeof(CommonResx))]
        public string FiscalYear { get; set; }

        /// <summary>
        /// Gets or sets FiscalPeriod 
        /// </summary>
        //[ValidateFiscalPeriod(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "FiscalPeriod", ResourceType = typeof(CommonResx))]
        public string FiscalPeriod { get; set; }

        /// <summary>
        /// Gets or sets CurrencyCode 
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CurrencyCode", ResourceType = typeof(InvoiceResx))]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets RateType 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateType", ResourceType = typeof(InvoiceResx))]
        public string RateType { get; set; }

        /// <summary>
        /// Gets or sets RateOverridden 
        /// </summary>
        [Display(Name = "RateOverridden", ResourceType = typeof(InvoiceResx))]
        public AllowedType RateOverridden { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRate 
        /// </summary>
        [Display(Name = "ExchangeRate", ResourceType = typeof(InvoiceResx))]
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets ApplytoExchangeRate 
        /// </summary>
        [Display(Name = "ApplytoExchangeRate", ResourceType = typeof(InvoiceResx))]
        public decimal ApplytoExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets Terms 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TermsCode", ResourceType = typeof(InvoiceResx))]
        public string Terms { get; set; }

        /// <summary>
        /// Gets or sets TermsCodeOverridden 
        /// </summary>
        [Display(Name = "TermsCodeOverridden", ResourceType = typeof(InvoiceResx))]
        public AllowedType TermsCodeOverridden { get; set; }

        /// <summary>
        /// Gets or sets DueDate 
        /// </summary>
        [ValidateDateFormatAllowNullAttribute(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DueDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets DiscountDate 
        /// </summary>
        [ValidateDateFormatAllowNullAttribute(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DiscountDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? DiscountDate { get; set; }

        /// <summary>
        /// Gets or sets DiscountPercentage 
        /// </summary>
        [Display(Name = "DiscPercent", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets DiscountAmountAvailable 
        /// </summary>
        [Display(Name = "DiscAmount", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountAmountAvailable { get; set; }

        /// <summary>
        /// Gets or sets NumberOfDetails 
        /// </summary>
        [Display(Name = "NumberofDetails", ResourceType = typeof(InvoiceResx))]
        public decimal NumberOfDetails { get; set; }

        /// <summary>
        /// Gets or sets Taxable 
        /// </summary>
        [Display(Name = "Taxable", ResourceType = typeof(InvoiceResx))]
        public AllowedType Taxable { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountControl 
        /// </summary>
        [Display(Name = "TaxAmountControl", ResourceType = typeof(InvoiceResx))]
        public TaxAmountControl TaxAmountControl { get; set; }

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
        /// Gets or sets NumberofScheduledPayments 
        /// </summary>
        [Display(Name = "NumberofScheduledPayments", ResourceType = typeof(InvoiceResx))]
        public decimal NumberofScheduledPayments { get; set; }

        /// <summary>
        /// Gets or sets PrepaymentNumber 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PrepaymentNumber", ResourceType = typeof(InvoiceResx))]
        public string PrepaymentNumber { get; set; }

        /// <summary>
        /// Gets or sets RateDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateDate", ResourceType = typeof(InvoiceResx))]
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Gets or sets AmountDue 
        /// </summary>
        [Display(Name = "AmountDue", ResourceType = typeof(InvoiceResx))]
        public decimal AmountDue { get; set; }

        /// <summary>
        /// Gets or sets TaxTotal 
        /// </summary>
        [Display(Name = "TotalTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets DocumentTotalIncludingTax 
        /// </summary>
        [Display(Name = "DocumentTotalIncludingTax", ResourceType = typeof(InvoiceResx))]
        public decimal DocumentTotalIncludingTax { get; set; }

        /// <summary>
        /// Gets or sets DrillDownApplicationSource 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DrillDownApplicationSource", ResourceType = typeof(InvoiceResx))]
        public string DrillDownApplicationSource { get; set; }

        /// <summary>
        /// Gets or sets DrillDownType 
        /// </summary>
        [Display(Name = "DrillDownType", ResourceType = typeof(InvoiceResx))]
        public int DrillDownType { get; set; }

        /// <summary>
        /// Gets or sets DrillDownLinkNumber 
        /// </summary>
        [Display(Name = "DrillDownLinkNumber", ResourceType = typeof(InvoiceResx))]
        public decimal DrillDownLinkNumber { get; set; }

        /// <summary>
        /// Gets or sets PropertyCode 
        /// </summary>
        [Display(Name = "PropertyCode", ResourceType = typeof(InvoiceResx))]
        public PropertyCode PropertyCode { get; set; }

        /// <summary>
        /// Gets or sets PropertyValue 
        /// </summary>
        [Display(Name = "PropertyValue", ResourceType = typeof(InvoiceResx))]
        public long PropertyValue { get; set; }

        /// <summary>
        /// Gets or sets JobRelated 
        /// </summary>
        [Display(Name = "JobRelated", ResourceType = typeof(InvoiceResx))]
        public AllowedType JobRelated { get; set; }

        /// <summary>
        /// Gets or sets ErrorBatch 
        /// </summary>
        [Display(Name = "ErrorBatch", ResourceType = typeof(InvoiceResx))]
        public long ErrorBatch { get; set; }

        /// <summary>
        /// Gets or sets ErrorEntry 
        /// </summary>
        [Display(Name = "ErrorEntry", ResourceType = typeof(InvoiceResx))]
        public long ErrorEntry { get; set; }

        /// <summary>
        /// Gets or sets PrepaymentAmount 
        /// </summary>
        [Display(Name = "PrepaymentAmount", ResourceType = typeof(InvoiceResx))]
        public decimal PrepaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets DateGenerated 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DateGenerated", ResourceType = typeof(InvoiceResx))]
        public DateTime DateGenerated { get; set; }

        /// <summary>
        /// Gets or sets DiscountBaseWithTax 
        /// </summary>
        [Display(Name = "DiscountBaseWithTax", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountBaseWithTax { get; set; }

        /// <summary>
        /// Gets or sets DiscountBaseWithoutTax 
        /// </summary>
        [Display(Name = "DiscountBaseWithoutTax", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountBaseWithoutTax { get; set; }

        /// <summary>
        /// Gets or sets DiscountBase 
        /// </summary>
        [Display(Name = "DiscBase", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountBase { get; set; }

        /// <summary>
        /// Gets or sets RetainageInvoice 
        /// </summary>
        [Display(Name = "RetainageInvoice", ResourceType = typeof(InvoiceResx))]
        public AllowedType RetainageInvoice { get; set; }

        /// <summary>
        /// Gets or sets HasRetainage 
        /// </summary>
        [Display(Name = "HasRetainage", ResourceType = typeof(InvoiceResx))]
        public AllowedType HasRetainage { get; set; }

        /// <summary>
        /// Gets or sets HasRetainageBool
        /// </summary>
        public bool HasRetainageBool { get; set; }

        /// <summary>
        /// Gets or sets OriginalDocNo 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OriginalDocument", ResourceType = typeof(InvoiceResx))]
        public string OriginalDocNo { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmount 
        /// </summary>
        [Display(Name = "RetainageAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets PercentRetained 
        /// </summary>
        [Display(Name = "RetainagePercent", ResourceType = typeof(InvoiceResx))]
        public decimal PercentRetained { get; set; }

        /// <summary>
        /// Gets or sets DaysRetained 
        /// </summary>
        [Display(Name = "DaysRetained", ResourceType = typeof(InvoiceResx))]
        public int DaysRetained { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RetainageDueDate", ResourceType = typeof(InvoiceResx))]
        public DateTime RetainageDueDate { get; set; }

        /// <summary>
        /// Gets or sets RetainageTermsCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RetainageTermsCode", ResourceType = typeof(InvoiceResx))]
        public string RetainageTermsCode { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDateOverride 
        /// </summary>
        [Display(Name = "RetainageDueDateOverride", ResourceType = typeof(InvoiceResx))]
        public AllowedType RetainageDueDateOverride { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmountOverride 
        /// </summary>
        [Display(Name = "RetainageAmountOverride", ResourceType = typeof(InvoiceResx))]
        public AllowedType RetainageAmountOverride { get; set; }

        /// <summary>
        /// Gets or sets RetainageExchangeRate 
        /// </summary>
        [Display(Name = "RetainageExchangeRate", ResourceType = typeof(InvoiceResx))]
        public RetainageExchangeRate RetainageExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets TaxBaseControl 
        /// </summary>
        [Display(Name = "TaxBaseControl", ResourceType = typeof(InvoiceResx))]
        public TaxAmountControl TaxBaseControl { get; set; }

        /// <summary>
        /// Gets or sets OptionalFields 
        /// </summary>
        [Display(Name = "OptionalFields", ResourceType = typeof(InvoiceResx))]
        public long OptionalFields { get; set; }

        /// <summary>
        /// Gets or sets SourceApplication 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "SourceApplication", ResourceType = typeof(InvoiceResx))]
        public string SourceApplication { get; set; }

        /// <summary>
        /// Gets or sets TaxStateVersion 
        /// </summary>
        [Display(Name = "TaxStateVersion", ResourceType = typeof(InvoiceResx))]
        public long TaxStateVersion { get; set; }

        /// <summary>
        /// Gets or sets ReportRetainageTax 
        /// </summary>
        [Display(Name = "ReportRetainageTax", ResourceType = typeof(InvoiceResx))]
        public int ReportRetainageTax { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingCurrencyCode 
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingCurrencyCode", ResourceType = typeof(InvoiceResx))]
        public string TaxReportingCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingCalculateMethod 
        /// </summary>
        [Display(Name = "TaxReportingCalculateMethod", ResourceType = typeof(InvoiceResx))]
        public TaxAmountControl TaxReportingCalculateMethod { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingCalculateMethod 
        /// </summary>
        [Display(Name = "TaxReportingCalculate", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxReportingCalculate { get; set; } //Ar Takes only Yes/No

        /// <summary>
        /// Gets or sets TaxReportingExchangeRate 
        /// </summary>
        [Display(Name = "TaxReportingExchangeRate", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateType 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingRateType", ResourceType = typeof(InvoiceResx))]
        public string TaxReportingRateType { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TaxReportingRateDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? TaxReportingRateDate { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateOperator 
        /// </summary>
        [Display(Name = "TaxReportingRateOperator", ResourceType = typeof(InvoiceResx))]
        public CurrencyCodeOperator TaxReportingRateOperator { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRateOverride 
        /// </summary>
        [Display(Name = "TaxReportingRateOverride", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxReportingRateOverride { get; set; }

        /// <summary>
        ///  Gets or sets TaxReportingRateOverride bool
        /// </summary>
        public bool TaxReportingRateOverrideBool;

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
        /// Gets or sets TaxReportingTotal 
        /// </summary>
        [Display(Name = "TaxReportingTotal", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingTotal { get; set; }

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
        /// Gets or sets FuncTaxBase1 
        /// </summary>
        [Display(Name = "FuncTaxBase1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxBase1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxBase2 
        /// </summary>
        [Display(Name = "FuncTaxBase2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxBase2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxBase3 
        /// </summary>
        [Display(Name = "FuncTaxBase3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxBase3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxBase4 
        /// </summary>
        [Display(Name = "FuncTaxBase4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxBase4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxBase5 
        /// </summary>
        [Display(Name = "FuncTaxBase5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxBase5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAmount1 
        /// </summary>
        [Display(Name = "FuncTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAmount2 
        /// </summary>
        [Display(Name = "FuncTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAmount3 
        /// </summary>
        [Display(Name = "FuncTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAmount4 
        /// </summary>
        [Display(Name = "FuncTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAmount5 
        /// </summary>
        [Display(Name = "FuncTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncDistributionOrTaxTotal 
        /// </summary>
        [Display(Name = "FuncDistributionwOrTaxTotal", ResourceType = typeof(InvoiceResx))]
        public decimal FuncDistributionOrTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageAmount 
        /// </summary>
        [Display(Name = "FuncRetainageAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets FuncDiscountAmount 
        /// </summary>
        [Display(Name = "FuncDiscountAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncDiscountAmount { get; set; }


        /// <summary>
        /// Gets or sets FuncPrepaymentAmount 
        /// </summary>
        [Display(Name = "FuncPrepaymentAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncPrepaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets FuncAmountDue 
        /// </summary>
        [Display(Name = "FuncAmountDue", ResourceType = typeof(InvoiceResx))]
        public decimal FuncAmountDue { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxTotal 
        /// </summary>
        [Display(Name = "TotalRetainageTax", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount1Total 
        /// </summary>
        [Display(Name = "TaxAmount1Total", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount1Total { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount2Total 
        /// </summary>
        [Display(Name = "TaxAmount2Total", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount2Total { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount3Total 
        /// </summary>
        [Display(Name = "TaxAmount3Total", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount3Total { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount4Total 
        /// </summary>
        [Display(Name = "TaxAmount4Total", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount4Total { get; set; }

        /// <summary>
        /// Gets or sets TaxAmount5Total 
        /// </summary>
        [Display(Name = "TaxAmount5Total", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount5Total { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmountfromDetails 
        /// </summary>
        [Display(Name = "RetainageAmountfromDetails", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageAmountFromDetails { get; set; }

        /// <summary>
        /// Gets or sets EnteredBy 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EnteredBy", ResourceType = typeof(InvoiceResx))]
        public string EnteredBy { get; set; }

        /// <summary>
        /// Gets or sets PostingDate 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PostingDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? PostingDate { get; set; }

        /// <summary>
        /// The Invoice details related to the Invoices
        /// </summary>
        /// <value>The invoice detail.</value>
        public EnumerableResponse<BaseInvoiceDetail> InvoiceDetails { get; set; }
        
        /// <summary>
        /// Gets or sets Originator 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OrigComp", ResourceType = typeof(InvoiceResx))]
        public string Originator { get; set; }

        /// <summary>
        /// Gets or sets VendorNumber or Customer Number
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string CustomerVendorNumber { get; set; }

        /// <summary>
        /// Gets and Sets Customer Number
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CustomerNumber", ResourceType = typeof(InvoiceResx))]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Gets and Sets Vendor Number
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorNumber", ResourceType = typeof(InvoiceResx))]
        [Key]
        public string VendorNumber { get; set; }

        /// <summary>
        /// Gets or sets DocumentNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DocumentNumber", ResourceType = typeof(InvoiceResx))]
        [Key]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets RemitToLocation 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToLocation", ResourceType = typeof(InvoiceResx))]
        public string RemitToLocation { get; set; }

        /// <summary>
        /// Gets or sets TermsOverridden 
        /// </summary>
        [Display(Name = "TermsCodeOverridden", ResourceType = typeof(InvoiceResx))]
        public AllowedType TermsOverridden { get; set; }

        /// <summary>
        /// Gets or sets Num1099OrCPRSAmount 
        /// </summary>
        [Display(Name = "_1099CPRSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal Num1099OrCPRSAmount { get; set; }

        /// <summary>
        /// Gets or sets DistributionSetAmount 
        /// </summary>
        [Display(Name = "DistributionAmount", ResourceType = typeof(InvoiceResx))]        
        public decimal DistributionSetAmount { get; set; }

        /// <summary>
        /// Gets or sets TotalDistributedTax 
        /// </summary>
        [Display(Name = "TotalDistributedTax", ResourceType = typeof(InvoiceResx))]
        public decimal TotalDistributedTax { get; set; }

        /// <summary>
        /// Gets or sets DocumentTotalBeforeTaxes 
        /// </summary>
        [Display(Name = "DocumentTotalBeforeTax", ResourceType = typeof(InvoiceResx))]
        public decimal DocumentTotalBeforeTaxes { get; set; }

        /// <summary>
        /// Gets or sets DistributedAllocatedTaxes 
        /// </summary>
        [Display(Name = "DistributedAllocatedTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal DistributedAllocatedTaxes { get; set; }


        /// <summary>
        /// Gets or sets DistributedTotalBeforeTaxes 
        /// </summary>
        [Display(Name = "DistributedTotalBeforeTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal DistributedTotalBeforeTaxes { get; set; }

        /// <summary>
        /// Gets or sets DistributedTotalIncludingTax 
        /// </summary>
        [Display(Name = "DistributedTotalIncludingTax", ResourceType = typeof(InvoiceResx))]
        public decimal DistributedTotalIncludingTax { get; set; }


        /// <summary>
        /// Gets or sets LocationName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LocationName", ResourceType = typeof(InvoiceResx))]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets AddressLine1 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine1", ResourceType = typeof(InvoiceResx))]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine2 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine2", ResourceType = typeof(InvoiceResx))]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine3 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine3", ResourceType = typeof(InvoiceResx))]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets AddressLine4 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AddressLine4", ResourceType = typeof(InvoiceResx))]
        public string AddressLine4 { get; set; }

        /// <summary>
        /// Gets or sets City 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "City", ResourceType = typeof(InvoiceResx))]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets StateOrProv 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "StateProvince", ResourceType = typeof(InvoiceResx))]
        public string StateOrProv { get; set; }

        /// <summary>
        /// Gets or sets ZipOrPostalCode 
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ZIPPostalCode", ResourceType = typeof(InvoiceResx))]
        public string ZipOrPostalCode { get; set; }

        /// <summary>
        /// Gets or sets Country 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Country", ResourceType = typeof(InvoiceResx))]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets ContactName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactName", ResourceType = typeof(InvoiceResx))]
        public string ContactName { get; set; }

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
        /// Gets or sets RecoverableTaxes 
        /// </summary>
        [Display(Name = "RecoverableTax", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxes { get; set; }

        /// <summary>
        /// Gets or sets VendorGroupCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorGroupCode", ResourceType = typeof(InvoiceResx))]
        public string VendorGroupCode { get; set; }

        /// <summary>
        /// Gets or sets TermsDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TermsCodeDescription", ResourceType = typeof(InvoiceResx))]
        public string TermsDescription { get; set; }

        /// <summary>
        /// Gets or sets DistributionSet 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DistributionSet", ResourceType = typeof(InvoiceResx))]
        public string DistributionSet { get; set; }

        /// <summary>
        /// Gets or sets Num1099OrCPRSCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "_1099CPRSCode", ResourceType = typeof(InvoiceResx))]
        public string Num1099OrCPRSCode { get; set; }

        /// <summary>
        /// Gets or sets GeneratePaymentSchedule 
        /// </summary>
        [Display(Name = "GeneratePaymentSchedule", ResourceType = typeof(InvoiceResx))]
        public int GeneratePaymentSchedule { get; set; }

        /// <summary>
        /// Gets or sets UndistributedAmount 
        /// </summary>
        [Display(Name = "UndistributedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal UndistributedAmount { get; set; }

        /// <summary>
        /// Gets or sets ExpensedSeparatelyTaxes 
        /// </summary>
        [Display(Name = "ExpensedSeparatelyTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal ExpensedSeparatelyTaxes { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountToBeAllocated 
        /// </summary>
        [Display(Name = "TaxAmountToBeAllocated", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountToBeAllocated { get; set; }

        /// <summary>
        /// Gets or sets CurrencyCodeOperator 
        /// </summary>
        [Display(Name = "CurrencyCodeOperator", ResourceType = typeof(InvoiceResx))]
        public CurrencyCodeOperator CurrencyCodeOperator { get; set; }

        /// <summary>
        /// Gets or sets RecoverableAccount1 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecoverableAccount1", ResourceType = typeof(InvoiceResx))]
        public string RecoverableAccount1 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableAccount2 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecoverableAccount2", ResourceType = typeof(InvoiceResx))]
        public string RecoverableAccount2 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableAccount3 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecoverableAccount3", ResourceType = typeof(InvoiceResx))]
        public string RecoverableAccount3 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableAccount4 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecoverableAccount4", ResourceType = typeof(InvoiceResx))]
        public string RecoverableAccount4 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableAccount5 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecoverableAccount5", ResourceType = typeof(InvoiceResx))]
        public string RecoverableAccount5 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepAccount1 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseSepAccount1", ResourceType = typeof(InvoiceResx))]
        public string ExpenseSepAccount1 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepAccount2 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseSepAccount2", ResourceType = typeof(InvoiceResx))]
        public string ExpenseSepAccount2 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepAccount3 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseSepAccount3", ResourceType = typeof(InvoiceResx))]
        public string ExpenseSepAccount3 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepAccount4 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseSepAccount4", ResourceType = typeof(InvoiceResx))]
        public string ExpenseSepAccount4 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepAccount5 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseSepAccount5", ResourceType = typeof(InvoiceResx))]
        public string ExpenseSepAccount5 { get; set; }

        /// <summary>
        /// Gets or sets ProcessCommandCode 
        /// </summary>
        [Display(Name = "ProcessCommandCode", ResourceType = typeof(InvoiceResx))]
        public ProcessCommandCode ProcessCommandCode { get; set; }

        /// <summary>
        /// Gets or sets DistRecoverableTaxes 
        /// </summary>
        [Display(Name = "DistRecoverableTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal DistRecoverableTaxes { get; set; }

        /// <summary>
        /// Gets or sets DistExpSeparatelyTaxes 
        /// </summary>
        [Display(Name = "DistExpSeparatelyTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal DistExpSeparatelyTaxes { get; set; }

        /// <summary>
        /// Gets or sets Email 
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EmailAddress", ResourceType = typeof(InvoiceResx))]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets ContactsPhone 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsPhone", ResourceType = typeof(InvoiceResx))]
        public string ContactsPhone { get; set; }

        /// <summary>
        /// Gets or sets ContactsFax 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsFax", ResourceType = typeof(InvoiceResx))]
        public string ContactsFax { get; set; }

        /// <summary>
        /// Gets or sets ContactsEmail 
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ContactsEmail", ResourceType = typeof(InvoiceResx))]
        public string ContactsEmail { get; set; }

        /// <summary>
        /// Gets or sets RecurringPayableCode 
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecurringPayableCode", ResourceType = typeof(InvoiceResx))]
        public string RecurringPayableCode { get; set; }

        /// <summary>
        /// Gets or sets DetailCount 
        /// </summary>
        [Display(Name = "NumberofDetails", ResourceType = typeof(InvoiceResx))]
        public long DetailCount { get; set; }

        /// <summary>
        /// Gets or sets OnHold 
        /// </summary>
        [Display(Name = "OnHold", ResourceType = typeof(InvoiceResx))]
        public AllowedType OnHold { get; set; }

        /// <summary>
        /// Gets or sets OnHoldBool 
        /// </summary>
        public bool OnHoldBool { get; set; }

        /// <summary>
        /// Gets or sets OrigExists 
        /// </summary>
        [IgnoreExportImport]
        public int OrigExists { get; set; }

        /// <summary>
        /// Gets or sets OrigName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string OrigName { get; set; }

        /// <summary>
        /// Gets or sets OrigStatus 
        /// </summary>
        [IgnoreExportImport]
        public int OrigStatus { get; set; }

        /// <summary>
        /// Gets or sets VendorExists 
        /// </summary>
        [IgnoreExportImport]
        public int VendorExists { get; set; }

        /// <summary>
        /// Gets or sets VendorName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name="VendorDescription",ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or sets VendorDistType 
        /// </summary>
        [IgnoreExportImport]
        public int VendorDistType { get; set; }

        /// <summary>
        /// Gets or sets VendorDistCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string VendorDistCode { get; set; }

        /// <summary>
        /// Gets or sets VendorAccount 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string VendorAccount { get; set; }

        /// <summary>
        /// Gets or sets VendorTaxReportType 
        /// </summary>
        [IgnoreExportImport]
        public int VendorTaxReportType { get; set; }

        /// <summary>
        /// Gets or sets RemitExists 
        /// </summary>
        [IgnoreExportImport]
        public int RemitExists { get; set; }

        /// <summary>
        /// Gets or sets RemitName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToDescription", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string RemitName { get; set; }

        /// <summary>
        /// Gets or sets Num1099OrCPRSExists 
        /// </summary>
        [IgnoreExportImport]
        public int Num1099OrCPRSExists { get; set; }

        /// <summary>
        /// Gets or sets Num1099OrCPRSDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string Num1099OrCPRSDescription { get; set; }

        /// <summary>
        /// Gets or sets DistSetExists 
        /// </summary>
        [IgnoreExportImport]
        public int DistSetExists { get; set; }

        /// <summary>
        /// Gets or sets DistSetDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DistributionSetDescription",ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string DistSetDescription { get; set; }

        /// <summary>
        /// Gets or sets DistSetMethod 
        /// </summary>
        [IgnoreExportImport]
        public int DistSetMethod { get; set; }

        /// <summary>
        /// Gets or sets TermExists 
        /// </summary>
        [IgnoreExportImport]
        public int TermExists { get; set; }

        /// <summary>
        /// Gets or sets TermUsePaymentSchedule 
        /// </summary>
        [IgnoreExportImport]
        public int TermUsePaymentSchedule { get; set; }

        /// <summary>
        /// Gets or sets RTGTermExists 
        /// </summary>
        [IgnoreExportImport]
        public int RTGTermExists { get; set; }

        /// <summary>
        /// Gets or sets RTGTermDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string RTGTermDescription { get; set; }

        /// <summary>
        /// Gets or sets PMLevel1Name 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PMLevel1Name { get; set; }

        /// <summary>
        /// Gets or sets PMLevel2Name 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PMLevel2Name { get; set; }

        /// <summary>
        /// Gets or sets PMLevel3Name 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string PMLevel3Name { get; set; }

        /// <summary>
        /// Gets or sets TaxGroupDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name="TaxGroupDescription",ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string TaxGroupDescription { get; set; }

        /// <summary>
        /// Gets or sets TaxAuth1Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuth1Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuth2Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuth2Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuth3Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuth3Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuth4Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuth4Description { get; set; }

        /// <summary>
        /// Gets or sets TaxAuth5Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string TaxAuth5Description { get; set; }

        /// <summary>
        /// Gets or sets AOrPVersionCreatedIn 
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AOrPVersionCreatedIn", ResourceType = typeof(InvoiceResx))]
        public string AorPVersionCreatedIn { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingAllocatedTax 
        /// </summary>
        [Display(Name = "TaxReportingAllocatedTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedTax { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax { get; set; }

        /// <summary>
        /// Gets or sets Func1099OrCPRSAmount 
        /// </summary>
        [Display(Name = "Func1099OrCPRSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal Func1099OrCPRSAmount { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountDue 
        /// </summary>
        [Display(Name = "AmountDue", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountDue { get; set; }

        /// <summary>
        /// Gets or sets VendorNameTax 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "VendorName", ResourceType = typeof(InvoiceResx))]
        public string VendorNameTax { get; set; }

        /// <summary>
        /// Gets or sets AcctSetDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public string AcctSetDescription { get; set; }

        /// <summary>
        /// Gets or sets ShipToLocationCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToLocationCode", ResourceType = typeof(InvoiceResx))]
        public string ShipToLocationCode { get; set; }

        /// <summary>
        /// Gets or sets SpecialInstructions 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "SpecialInstructions", ResourceType = typeof(InvoiceResx))]
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// Gets or sets InvoicePrinted 
        /// </summary>
        [Display(Name = "InvoicePrinted", ResourceType = typeof(InvoiceResx))]
        public AllowedType InvoicePrinted { get; set; }

        /// <summary>
        /// Gets or sets Salesperson1 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Salesperson1", ResourceType = typeof(InvoiceResx))]
        public string Salesperson1 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson2 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Salesperson2", ResourceType = typeof(InvoiceResx))]
        public string Salesperson2 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson3 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Salesperson3", ResourceType = typeof(InvoiceResx))]
        public string Salesperson3 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson4 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Salesperson4", ResourceType = typeof(InvoiceResx))]
        public string Salesperson4 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson5 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Salesperson5", ResourceType = typeof(InvoiceResx))]
        public string Salesperson5 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage1  
        /// </summary>
        [Display(Name = "SalesSplitPercentage1", ResourceType = typeof(InvoiceResx))]
        public decimal SalesSplitPercentage1 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage2 
        /// </summary>
        [Display(Name = "SalesSplitPercentage2", ResourceType = typeof(InvoiceResx))]
        public decimal SalesSplitPercentage2 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage3 
        /// </summary>

        [Display(Name = "SalesSplitPercentage3", ResourceType = typeof(InvoiceResx))]
        public decimal SalesSplitPercentage3 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage4 
        /// </summary>
        [Display(Name = "SalesSplitPercentage4", ResourceType = typeof(InvoiceResx))]
        public decimal SalesSplitPercentage4 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage5 
        /// </summary>
        [Display(Name = "SalesSplitPercentage5", ResourceType = typeof(InvoiceResx))]
        public decimal SalesSplitPercentage5 { get; set; }

        /// <summary>
        /// Gets or sets DoNotCalcTax 
        /// </summary>
        [Display(Name = "DoNotCalcTax", ResourceType = typeof(InvoiceResx))]
        public AllowedType DoNotCalcTax { get; set; }

        /// <summary>
        /// Gets or sets DoNotCalcTax 
        /// </summary>
        public bool DoNotCalcTaxBool;


        
        /// <summary>
        /// Gets or sets TaxableAmount 
        /// </summary>
        [Display(Name = "TaxableAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Gets or sets NonTaxableAmount 
        /// </summary>
        [Display(Name = "NonTaxableAmount", ResourceType = typeof(InvoiceResx))]
        public decimal NonTaxableAmount { get; set; }



        /// <summary>
        /// Gets or sets DocumentTotalBeforeTax 
        /// </summary>
        [Display(Name = "DocumentTotalBeforeTax", ResourceType = typeof(InvoiceResx))]
        public decimal DocumentTotalBeforeTax { get; set; }

        /// <summary>
        /// Gets or sets TotalPaymentAmountScheduled 
        /// </summary>
        [Display(Name = "TotalPaymentAmountScheduled", ResourceType = typeof(InvoiceResx))]
        public decimal TotalPaymentAmountScheduled { get; set; }

        /// <summary>
        /// Gets or sets RecurringChargeCode 
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecurringChargeCode", ResourceType = typeof(InvoiceResx))]
        public string RecurringChargeCode { get; set; }


        /// <summary>
        /// Gets or sets RecurringBillingCycle 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RecurringBillingCycle", ResourceType = typeof(InvoiceResx))]
        public string RecurringBillingCycle { get; set; }

        /// <summary>
        /// Gets or sets ShipToLocationName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToLocationName", ResourceType = typeof(InvoiceResx))]
        public string ShipToLocationName { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddressLine1 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine1", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddressLine2 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine2", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddressLine3 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine3", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets ShipToAddressLine4 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToAddressLine4", ResourceType = typeof(InvoiceResx))]
        public string ShipToAddressLine4 { get; set; }

        /// <summary>
        /// Gets or sets ShipToCity 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToCity", ResourceType = typeof(InvoiceResx))]
        public string ShipToCity { get; set; }

        /// <summary>
        /// Gets or sets ShipToStateOrProv 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToStateOrProv", ResourceType = typeof(InvoiceResx))]
        public string ShipToStateOrProv { get; set; }

        /// <summary>
        /// Gets or sets ShipToZipOrPostalCode 
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToZipOrPostalCode", ResourceType = typeof(InvoiceResx))]
        public string ShipToZipOrPostalCode { get; set; }

        /// <summary>
        /// Gets or sets ShipToCountry 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToCountry", ResourceType = typeof(InvoiceResx))]
        public string ShipToCountry { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactName 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactName", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactName { get; set; }

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
        /// Gets or sets CustOrNatlOverCreditFlag 
        /// </summary>
        [Display(Name = "CustOrNatlOverCreditFlag", ResourceType = typeof(InvoiceResx))]
        public ARCustOrNatlOverCreditFlag CustOrNatlOverCreditFlag { get; set; }

        /// <summary>
        /// Gets or sets RateOperator 
        /// </summary>
        [Display(Name = "RateOperator", ResourceType = typeof(InvoiceResx))]
        public CurrencyCodeOperator RateOperator { get; set; }

        /// <summary>
        /// Gets or sets ForceRereadofIBSTotals 
        /// </summary>
        [Display(Name = "ForceRereadofIBSTotals", ResourceType = typeof(InvoiceResx))]
        public int ForceRereadofIBSTotals { get; set; }

        /// <summary>
        /// Gets or sets ProcessCommand 
        /// </summary>
        [Display(Name = "ProcessCommand", ResourceType = typeof(InvoiceResx))]
        public ARInvoiceProcessCommand ProcessCommand { get; set; }

        /// <summary>
        /// Gets or sets ShipViaCode 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipViaCode", ResourceType = typeof(InvoiceResx))]
        public string ShipViaCode { get; set; }

        /// <summary>
        /// Gets or sets ShipViaDescription 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipViaDescription", ResourceType = typeof(InvoiceResx))]
        public string ShipViaDescription { get; set; }


        /// <summary>
        /// Gets or sets ShipToEmail 
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToEmail", ResourceType = typeof(InvoiceResx))]
        public string ShipToEmail { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactsPhone 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactsPhone", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactsPhone { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactsFax 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ShipToContactsFax { get; set; }

        /// <summary>
        /// Gets or sets ShipToContactsEmail 
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipToContactsEmail", ResourceType = typeof(InvoiceResx))]
        public string ShipToContactsEmail { get; set; }

        /// <summary>
        /// Gets or sets InvoiceType 
        /// </summary>
        [Display(Name = "InvoiceType", ResourceType = typeof(InvoiceResx))]
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets FiscalYearAndPeriod 
        /// </summary>
        [Display(Name = "FiscalYearAndPeriod", ResourceType = typeof(InvoiceResx))]
        public string FiscalYearAndPeriod { get; set; }

        /// <summary>
        /// Gets or sets AOrRVersionCreatedIn 
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AOrRVersionCreatedIn", ResourceType = typeof(InvoiceResx))]
        public string AOrRVersionCreatedIn { get; set; }

        /// <summary>
        /// Gets or sets FuncDistributionwOroTaxTotal 
        /// </summary>
        [Display(Name = "FuncDistributionwOroTaxTotal", ResourceType = typeof(InvoiceResx))]
        public decimal FuncDistributionwOroTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets LabelPrinted 
        /// </summary>
        [Display(Name = "LabelPrinted", ResourceType = typeof(InvoiceResx))]
        public AllowedType LabelPrinted { get; set; }

        /// <summary>
        /// Gets or sets ShipmentNumber 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ShipmentNumber", ResourceType = typeof(InvoiceResx))]
        public string ShipmentNumber { get; set; }

        /// <summary>
        /// Gets or sets DoOOrECostingandConsolidation 
        /// </summary>
        [Display(Name = "DoOOrECostingandConsolidation", ResourceType = typeof(InvoiceResx))]
        public AllowedType DoOOrECostingandConsolidation { get; set; }

        /* Enum equivelant String Properties*/
        /// <summary>
        /// To get the string of DocumentType property
        /// </summary>
        public string DocumentTypeString
        {
            get { return EnumUtility.GetStringValue(DocumentType); }
        }

        /// <summary>
        /// To get the string of TransactionType property
        /// </summary>
        public string TransactionTypeString
        {
            get { return EnumUtility.GetStringValue(TransactionType); }
        }

        /// <summary>
        /// To get the string of TransactionType property
        /// </summary>
        public string APTransactionTypeString
        {
            get { return EnumUtility.GetStringValue(APTransactionType); }
        }
        /// <summary>
        /// To get the string of InvoicePrinted property
        /// </summary>
        public string InvoicePrintedString
        {
            get { return EnumUtility.GetStringValue(InvoicePrinted); }
        }

        /// <summary>
        /// To get the string of ProcessCommandCode property
        /// </summary>
        public string ProcessCommandCodeString
        {
            get { return EnumUtility.GetStringValue(ProcessCommandCode); }
        }

        /// <summary>
        /// To get the string of PropertyCode property
        /// </summary>
        public string PropertyCodeString
        {
            get { return EnumUtility.GetStringValue(PropertyCode); }
        }
        /// <summary>
        /// To get the string of JobRelated property
        /// </summary>
        public string JobRelatedString
        {
            get { return EnumUtility.GetStringValue(JobRelated); }
        }
        /// <summary>
        /// To get the string of InvoiceType property
        /// </summary>
        public string InvoiceTypeString
        {
            get { return EnumUtility.GetStringValue(InvoiceType); }
        }

        /// <summary>
        /// To get the string of RetainageExchangeRate property
        /// </summary>
        public string RetainageExchangeRateString
        {
            get { return EnumUtility.GetStringValue(RetainageExchangeRate); }
        }

        /// <summary>
        /// To get the string of APTaxBaseControlString property
        /// </summary>
        public string APTaxBaseControlString
        {
            get { return EnumUtility.GetStringValue(TaxBaseControl); }
        }

        /// <summary>
        /// To get the string of APOnHold property
        /// </summary>
        public string APOnHoldString
        {
            get { return EnumUtility.GetStringValue(OnHold); }
        }

        /// <summary>
        /// To get the string of TaxReportingCalculateMethod property
        /// </summary>
        public string TaxReportingCalculateMethodString
        {
            get { return EnumUtility.GetStringValue(TaxReportingCalculateMethod); }
        }

        /// <summary>
        /// To get the string of TaxReportingRateOperator property
        /// </summary>
        public string TaxReportingRateOperatorString
        {
            get { return EnumUtility.GetStringValue(TaxReportingRateOperator); }
        }

        /// <summary>
        /// To get the string of TaxReportingRateOverride property
        /// </summary>
        public string TaxReportingRateOverrideString
        {
            get { return EnumUtility.GetStringValue(TaxReportingRateOverride); }
        }

        /// <summary>
        /// To get the string of LabelPrinted property
        /// </summary>
        public string LabelPrintedString
        {
            get { return EnumUtility.GetStringValue(LabelPrinted); }
        }

        /// <summary>
        /// To get the string of DoOOrECostingandConsolidation property
        /// </summary>
        public string DoOOrECostingandConsolidationString
        {
            get { return EnumUtility.GetStringValue(DoOOrECostingandConsolidation); }
        }

        /// <summary>
        /// To get the string of RetainageDueDateOverride property
        /// </summary>
        public string RetainageDueDateOverrideString
        {
            get { return EnumUtility.GetStringValue(RetainageDueDateOverride); }
        }

        /// <summary>
        /// To get the string of RetainageAmountOverride property
        /// </summary>
        public string RetainageAmountOverrideString
        {
            get { return EnumUtility.GetStringValue(RetainageAmountOverride); }
        }

        /// <summary>
        /// To get the string of HasRetainage property
        /// </summary>
        public string HasRetainageString
        {
            get { return EnumUtility.GetStringValue(HasRetainage); }
        }

        /// <summary>
        /// To get the string of RetainageInvoice property
        /// </summary>
        public string RetainageInvoiceString
        {
            get { return EnumUtility.GetStringValue(RetainageInvoice); }
        }

        /// <summary>
        /// To get the string of ProcessCommand property
        /// </summary>
        public string ProcessCommandString
        {
            get { return EnumUtility.GetStringValue(ProcessCommand); }
        }

        /// <summary>
        /// To get the string of RateOperator property
        /// </summary>
        public string RateOperatorString
        {
            get { return EnumUtility.GetStringValue(RateOperator); }
        }

        /// <summary>
        /// To get the string of CustOrNatlOverCreditFlag property
        /// </summary>
        public string CustOrNatlOverCreditFlagString
        {
            get { return EnumUtility.GetStringValue(CustOrNatlOverCreditFlag); }
        }

        /// <summary>
        /// To get the string of DoNotCalcTax property
        /// </summary>
        public string DoNotCalcTaxString
        {
            get { return EnumUtility.GetStringValue(DoNotCalcTax); }
        }

        /// <summary>
        /// To get the string of Taxable property
        /// </summary>
        public string TaxableString
        {
            get { return EnumUtility.GetStringValue(Taxable); }
        }

        /// <summary>
        /// To get the string of TaxAmountControl property
        /// </summary>
        public string TaxAmountControlString
        {
            get { return EnumUtility.GetStringValue(TaxAmountControl); }
        }

        /// <summary>
        /// To get the string of TermsCodeOverridden property
        /// </summary>
        public string TermsCodeOverriddenString
        {
            get { return EnumUtility.GetStringValue(TermsCodeOverridden); }
        }

        /// <summary>
        /// To get the string of RateOverridden property
        /// </summary>
        public string RateOverriddenString
        {
            get { return EnumUtility.GetStringValue(RateOverridden); }
        }

        /// <summary>
        /// To get the string of RateOverridden property
        /// </summary>
        public string APTermsOverriddenString
        {
            get { return EnumUtility.GetStringValue(APTermsOverridden); }
        }

        /// <summary>
        /// To get the string of APTaxInclusive1 property
        /// </summary>
        public string TaxInclusive1String
        {
            get { return EnumUtility.GetStringValue(TaxInclusive1); }
        }

        /// <summary>
        /// To get the string of APTaxInclusive2 property
        /// </summary>
        public string TaxInclusive2String
        {
            get { return EnumUtility.GetStringValue(TaxInclusive2); }
        }

        /// <summary>
        /// To get the string of APTaxInclusive3 property
        /// </summary>
        public string TaxInclusive3String
        {
            get { return EnumUtility.GetStringValue(TaxInclusive3); }
        }

        /// <summary>
        /// To get the string of APTaxInclusive4 property
        /// </summary>
        public string TaxInclusive4String
        {
            get { return EnumUtility.GetStringValue(TaxInclusive4); }
        }

        /// <summary>
        /// To get the string of APTaxInclusive5 property
        /// </summary>
        public string TaxInclusive5String
        {
            get { return EnumUtility.GetStringValue(TaxInclusive5); }
        }

        /// <summary>
        /// To get the string of APTaxAmountControl property
        /// </summary>
        public string APTaxAmountControlString
        {
            get { return EnumUtility.GetStringValue(APTaxAmountControl); }
        }

        /// <summary>
        /// To get the string of APCurrencyCodeOperator property
        /// </summary>
        public string APCurrencyCodeOperatorString
        {
            get { return EnumUtility.GetStringValue(CurrencyCodeOperator); }
        }

        /*End Of Enum to String Equivelant properties*/
        /// <summary>
        /// Gets and Sets OptionalFieldList
        /// </summary>
        public EnumerableResponse<BaseInvoiceOptionalField> OptionalFieldList { get; set; }

        /// <summary>
        /// Gets and Sets Sales Split
        /// </summary>
        public EnumerableResponse<SalesSplitTable> SalesSplit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerCurrency { get; set; }

        #region AP Invoice Entry Properties
        
        /// <summary>
        /// Gets or sets APOriginator 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "OrigComp", ResourceType = typeof(InvoiceResx))]
        public string APOriginator { get; set; }
        
        /// <summary>
        /// Gets or sets APRemitToLocation 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RemitToLocation", ResourceType = typeof(InvoiceResx))]
        public string APRemitToLocation { get; set; }

        /// <summary>
        /// Gets or sets APPONumber 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PONumber", ResourceType = typeof(InvoiceResx))]
        public string APPONumber { get; set; }

        /// <summary>
        /// Gets or sets APAccountSet 
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AccountSet", ResourceType = typeof(InvoiceResx))]
        public string APAccountSet { get; set; }

        /// <summary>
        /// Gets or sets TermsOverridden 
        /// </summary>
        public AllowedType APTermsOverridden { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountControl 
        /// </summary>
        [Display(Name = "TaxAmountControl", ResourceType = typeof(InvoiceResx))]
        public TaxAmountControl APTaxAmountControl { get; set; }

        /// <summary>
        /// Gets or sets APTaxClass1 
        /// </summary>
        [Display(Name = "TaxClass1", ResourceType = typeof(InvoiceResx))]
        public int APTaxClass1 { get; set; }

        /// <summary>
        /// Gets or sets APTaxClass2 
        /// </summary>
        [Display(Name = "TaxClass2", ResourceType = typeof(InvoiceResx))]
        public int APTaxClass2 { get; set; }

        /// <summary>
        /// Gets or sets APTaxClass3 
        /// </summary>
        [Display(Name = "TaxClass3", ResourceType = typeof(InvoiceResx))]
        public int APTaxClass3 { get; set; }

        /// <summary>
        /// Gets or sets APTaxClass4 
        /// </summary>
        [Display(Name = "TaxClass4", ResourceType = typeof(InvoiceResx))]
        public int APTaxClass4 { get; set; }

        /// <summary>
        /// Gets or sets APTaxClass5 
        /// </summary>
        [Display(Name = "TaxClass5", ResourceType = typeof(InvoiceResx))]
        public int APTaxClass5 { get; set; }

        /// <summary>
        /// Gets or sets APTotalDistributedTax 
        /// </summary>
        [Display(Name = "TotalDistributedTax", ResourceType = typeof(InvoiceResx))]
        public decimal APTotalDistributedTax { get; set; }

        /// <summary>
        /// Gets or sets APNumberofScheduledPayments 
        /// </summary>
        [Display(Name = "NumberofScheduledPayments", ResourceType = typeof(InvoiceResx))]
        public decimal APNumberofScheduledPayments { get; set; }
        
        /// <summary>
        /// Gets or sets APDocumentTotalIncludingTax 
        /// </summary>
        [Display(Name = "DocumentTotalIncludingTax", ResourceType = typeof(InvoiceResx))]
        public decimal APDocumentTotalIncludingTax { get; set; }

        
        /// <summary>
        /// Gets or sets APTaxInclusive1 
        /// </summary>
        [Display(Name = "TaxInclusive1", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive1 { get; set; }

        /// <summary>
        /// Gets or sets APTaxInclusive2 
        /// </summary>
        [Display(Name = "TaxInclusive2", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive2 { get; set; }

        /// <summary>
        /// Gets or sets APTaxInclusive3 
        /// </summary>
        [Display(Name = "TaxInclusive3", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive3 { get; set; }

        /// <summary>
        /// Gets or sets APTaxInclusive4 
        /// </summary>
        [Display(Name = "TaxInclusive4", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive4 { get; set; }

        /// <summary>
        /// Gets or sets APTaxInclusive5 
        /// </summary>
        [Display(Name = "TaxInclusive5", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive5 { get; set; }
        
        /// <summary>
        /// Gets or sets APTransactionType
        /// </summary>
        [Display(Name = "TransactionType", ResourceType = typeof(InvoiceResx))]
        public TransactionType APTransactionType { get; set; }
        
        /// <summary>
        ///Gets or Sets APTaxReportingType
        /// </summary>
        /// This property is added for AP Invoice Entry Tax Reporting Type 
        [IgnoreExportImport]
        public InvoiceTaxReportingType APTaxReportingType { get; set; }

        /// <summary>
        /// To get the string of APTaxAmountControl property
        /// </summary>
        public string APTaxReportingTypeString
        {
            get { return EnumUtility.GetStringValue(APTaxReportingType); }
        }
        #endregion
    }
}
