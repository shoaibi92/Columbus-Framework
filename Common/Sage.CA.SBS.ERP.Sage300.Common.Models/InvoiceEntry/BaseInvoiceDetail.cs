using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// BaseInvoiceDetail Model
    /// </summary>
    public partial class BaseInvoiceDetail : ModelBase
    {
        /// <summary>
        /// Constructor for BaseInvoiceDetail
        /// </summary>
        public BaseInvoiceDetail()
        {
            DetailTaxes = new EnumerableResponse<TaxGroupAuthority>();
            DetailOptionalFieldList = new EnumerableResponse<BaseInvoiceOptionalField>();
        }
        /// <summary>
        /// Gets or sets BatchNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "BatchNumber", ResourceType = typeof(InvoiceResx))]
        [Key]
        public string BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets EntryNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(5, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "EntryNumber", ResourceType = typeof(InvoiceResx))]
        [Key]
        public string EntryNumber { get; set; }

        /// <summary>
        /// Gets or sets TransactionNumber 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "TransactionNumber", ResourceType = typeof(InvoiceResx))]
        public string TransactionNumber { get; set; }

        /// <summary>
        /// Gets or sets LineNumber 
        /// </summary>
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        [Key]
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets or sets DistributionCode 
        /// </summary>
        [Display(Name = "DistributionCode", ResourceType = typeof(InvoiceResx))]
        public string DistributionCode { get; set; }

        /// <summary>
        /// Gets or sets DistributionDescription 
        /// </summary>
        [Display(Name = "DistributionCodeDescription", ResourceType = typeof(InvoiceResx))]
        public string DistributionDescription { get; set; }

        /// <summary>
        /// Gets or sets GLAccount 
        /// </summary>
        [Display(Name = "GLAccount", ResourceType = typeof(InvoiceResx))]
        public string GLAccount { get; set; }

        /// <summary>
        /// Gets or sets AcctDescription 
        /// </summary>
        [Display(Name = "AccountDescription", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public string AcctDescription { get; set; }

        /// <summary>
        /// Gets or sets DistributedAmount 
        /// </summary>
        [Display(Name = "Amount", ResourceType = typeof(CommonResx))]
        public decimal DistributedAmount { get; set; }

        /// <summary>
        /// Gets or sets DistributedAmountBeforeTaxes 
        /// </summary>
        [Display(Name = "DistNetOfTax", ResourceType = typeof(InvoiceResx))]
        public decimal DistributedAmountBeforeTaxes { get; set; }

        /// <summary>
        /// Gets or sets TaxAmountIncludedinPrice 
        /// </summary>
        [Display(Name = "IncludedTaxAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmountIncludedinPrice { get; set; }

        /// <summary>
        /// Gets or sets TaxAllocatedTotal 
        /// </summary>
        [Display(Name = "AllocatedTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAllocatedTotal { get; set; }

        /// <summary>
        /// Gets or sets GOrLDistributedAmount 
        /// </summary>
        [Display(Name = "GLDistAmount", ResourceType = typeof(InvoiceResx))]
        public decimal GLDistributedAmount { get; set; }

        /// <summary>
        /// Gets or sets Discountable 
        /// </summary>
        [Display(Name = "Discountable", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag Discountable { get; set; }

        /// <summary>
        /// Gets or sets Discountable string
        /// </summary>
        [Display(Name = "Discountable", ResourceType = typeof(InvoiceResx))]
        public string DiscountableString { get; set; }

        /// <summary>
        /// Gets or sets Comment 
        /// </summary>
        [Display(Name = "Comment", ResourceType = typeof(InvoiceResx))]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets OptionalFields 
        /// </summary>
        [Display(Name = "OptionalFields", ResourceType = typeof(CommonResx))]
        public long OptionalFields { get; set; }

        /// <summary>
        /// Gets or sets OptionalFieldString 
        /// </summary>
        [Display(Name = "OptionalFields", ResourceType = typeof(CommonResx))]
        public string OptionalFieldString { get; set; }

        /// <summary>
        /// Gets or sets Destination 
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets RouteNo 
        /// </summary>
        [Display(Name = "RouteNo", ResourceType = typeof(InvoiceResx))]
        public int RouteNo { get; set; }

        /// <summary>
        /// Gets or sets TaxTotal 
        /// </summary>
        [Display(Name = "TotalTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets ManualTaxEntry 
        /// </summary>
        [Display(Name = "ManualTaxEntry", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag ManualTaxEntry { get; set; }

        /// <summary>
        /// Gets or sets BaseTax1 
        /// </summary>
        [Display(Name = "BaseTax1", ResourceType = typeof(InvoiceResx))]
        public decimal BaseTax1 { get; set; }

        /// <summary>
        /// Gets or sets BaseTax2 
        /// </summary>
        [Display(Name = "BaseTax2", ResourceType = typeof(InvoiceResx))]
        public decimal BaseTax2 { get; set; }

        /// <summary>
        /// Gets or sets BaseTax3 
        /// </summary>
        [Display(Name = "BaseTax3", ResourceType = typeof(InvoiceResx))]
        public decimal BaseTax3 { get; set; }

        /// <summary>
        /// Gets or sets BaseTax4 
        /// </summary>
        [Display(Name = "BaseTax4", ResourceType = typeof(InvoiceResx))]
        public decimal BaseTax4 { get; set; }

        /// <summary>
        /// Gets or sets BaseTax5 
        /// </summary>
        [Display(Name = "BaseTax5", ResourceType = typeof(InvoiceResx))]
        public decimal BaseTax5 { get; set; }

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
        /// Gets or sets TaxInclusive1 
        /// </summary>
        [Display(Name = "TaxInclusive1", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive1 { get; set; }

        /// <summary>
        /// Gets or sets TaxInclusive2 
        /// </summary>
        [Display(Name = "TaxInclusive2", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive2 { get; set; }

        /// <summary>
        /// Gets or sets TaxInclusive3 
        /// </summary>
        [Display(Name = "TaxInclusive3", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive3 { get; set; }

        /// <summary>
        /// Gets or sets TaxInclusive4 
        /// </summary>
        [Display(Name = "TaxInclusive4", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive4 { get; set; }

        /// <summary>
        /// Gets or sets TaxInclusive5 
        /// </summary>
        [Display(Name = "TaxInclusive5", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxInclusive5 { get; set; }

        /// <summary>
        /// Gets or sets TaxRate1 
        /// </summary>
        [Display(Name = "TaxRate1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRate1 { get; set; }

        /// <summary>
        /// Gets or sets TaxRate2 
        /// </summary>
        [Display(Name = "TaxRate2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRate2 { get; set; }

        /// <summary>
        /// Gets or sets TaxRate3 
        /// </summary>
        [Display(Name = "TaxRate3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRate3 { get; set; }

        /// <summary>
        /// Gets or sets TaxRate4 
        /// </summary>
        [Display(Name = "TaxRate4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRate4 { get; set; }

        /// <summary>
        /// Gets or sets TaxRate5 
        /// </summary>
        [Display(Name = "TaxRate5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRate5 { get; set; }

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
        /// Gets or sets RetainageAllocatedTaxAccount 
        /// </summary>
        [Display(Name = "RetainageAllocatedTaxAccount", ResourceType = typeof(InvoiceResx))]
        public string RetainageAllocatedTaxAccount { get; set; }

        /// <summary>
        /// Gets or sets RecoverableTaxAmount1 
        /// </summary>
        [Display(Name = "RecoverableTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableTaxAmount2 
        /// </summary>
        [Display(Name = "RecoverableTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableTaxAmount3 
        /// </summary>
        [Display(Name = "RecoverableTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableTaxAmount4 
        /// </summary>
        [Display(Name = "RecoverableTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets RecoverableTaxAmount5 
        /// </summary>

        [Display(Name = "RecoverableTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal RecoverableTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepTaxAmount1 
        /// </summary>

        [Display(Name = "ExpenseSepTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal ExpenseSepTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepTaxAmount2 
        /// </summary>
        [Display(Name = "ExpenseSepTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal ExpenseSepTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepTaxAmount3 
        /// </summary>
        [Display(Name = "ExpenseSepTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal ExpenseSepTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepTaxAmount4 
        /// </summary>
        [Display(Name = "ExpenseSepTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal ExpenseSepTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets ExpenseSepTaxAmount5 
        /// </summary>
        [Display(Name = "ExpenseSepTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal ExpenseSepTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets ContractCode 
        /// </summary>
        [Display(Name = "ContractCode", ResourceType = typeof(InvoiceResx))]
        public string ContractCode { get; set; }

        /// <summary>
        /// Gets or sets ProjectCode 
        /// </summary>
        [Display(Name = "ProjectCode", ResourceType = typeof(InvoiceResx))]
        public string ProjectCode { get; set; }

        /// <summary>
        /// Gets or sets CategoryCode 
        /// </summary>
        [Display(Name = "CategoryCode", ResourceType = typeof(InvoiceResx))]
        public string CategoryCode { get; set; }

        /// <summary>
        /// Gets or sets ProjectOrCategoryResource 
        /// </summary>
        [Display(Name = "ProjectOrCategoryResource", ResourceType = typeof(InvoiceResx))]
        public string ProjectOrCategoryResource { get; set; }

        /// <summary>
        /// Gets or sets CostClass 
        /// </summary>
        [Display(Name = "CostClass", ResourceType = typeof(InvoiceResx))]
        public CostClass CostClass { get; set; }

        /// <summary>
        /// Gets or sets BillingType 
        /// </summary>
        [Display(Name = "BillingType", ResourceType = typeof(InvoiceResx))]
        public BillingType BillingType { get; set; }

        /// <summary>
        /// Gets or sets ItemNumber 
        /// </summary>
        [Display(Name = "ItemNumber", ResourceType = typeof(InvoiceResx))]
        public string ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets UnitofMeasure 
        /// </summary>
        [Display(Name = "UnitOfMeasure", ResourceType = typeof(InvoiceResx))]
        public string UnitofMeasure { get; set; }

        /// <summary>
        /// Gets or sets Quantity 
        /// </summary>
        [Display(Name = "Quantity", ResourceType = typeof(CommonResx))]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets Cost 
        /// </summary>
        [Display(Name = "Cost", ResourceType = typeof(InvoiceResx))]
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets BillingDate 
        /// </summary>
        [Display(Name = "BillingDate", ResourceType = typeof(InvoiceResx))]
        public string BillingDate { get; set; }

        /// <summary>
        /// Gets or sets BillingRate 
        /// </summary>
        [Display(Name = "BillingRate", ResourceType = typeof(InvoiceResx))]
        public decimal BillingRate { get; set; }

        /// <summary>
        /// Gets or sets BillingCurrency 
        /// </summary>
        [Display(Name = "BillingCurrency", ResourceType = typeof(InvoiceResx))]
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Gets or sets CommentAttached 
        /// </summary>
        [Display(Name = "CommentAttached", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag CommentAttached { get; set; }

        /// <summary>
        /// Gets or sets OriginalLineIdentifier 
        /// </summary>
        [Display(Name = "OriginalLineNumber", ResourceType = typeof(InvoiceResx))]
        public decimal OriginalLineIdentifier { get; set; }

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
        [Display(Name = "RetentionPeriod", ResourceType = typeof(InvoiceResx))]
        public int DaysRetained { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDate 
        /// </summary>
        [Display(Name = "RetainageDueDate", ResourceType = typeof(InvoiceResx))]
        public string RetainageDueDate { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDateOverride 
        /// </summary>
        [Display(Name = "RetainageDueDateOverride", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag RetainageDueDateOverride { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmountOverride 
        /// </summary>
        [Display(Name = "RetainageAmountOverride", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag RetainageAmountOverride { get; set; }

        /// <summary>
        /// Gets or sets ProcessCommandCode 
        /// </summary>
        [Display(Name = "ProcessCommandCode", ResourceType = typeof(InvoiceResx))]
        public ProcessCommandCode ProcessCommandCode { get; set; }

        /// <summary>
        /// Gets or sets DestExists 
        /// </summary>
        [IgnoreExportImport]
        public int DestExists { get; set; }

        /// <summary>
        /// Gets or sets DestDescription 
        /// </summary>
        [IgnoreExportImport]
        public string DestDescription { get; set; }

        /// <summary>
        /// Gets or sets DestStatus 
        /// </summary>
        [IgnoreExportImport]
        public int DestStatus { get; set; }

        /// <summary>
        /// Gets or sets DistCodeExists 
        /// </summary>
        [IgnoreExportImport]
        public int DistCodeExists { get; set; }

        /// <summary>
        /// Gets or sets DistCodeDescription 
        /// </summary>
        [IgnoreExportImport]
        public string DistCodeDescription { get; set; }

        /// <summary>
        /// Gets or sets DistCodeStatus 
        /// </summary>
        [IgnoreExportImport]
        public int DistCodeStatus { get; set; }

        /// <summary>
        /// Gets or sets RouteExists 
        /// </summary>
        [IgnoreExportImport]
        public int RouteExists { get; set; }

        /// <summary>
        /// Gets or sets RouteDescription 
        /// </summary>
        [IgnoreExportImport]
        public string RouteDescription { get; set; }

        /// <summary>
        /// Gets or sets RouteStatus 
        /// </summary>
        [IgnoreExportImport]
        public int RouteStatus { get; set; }

        /// <summary>
        /// Gets or sets AcctExists 
        /// </summary>
        [IgnoreExportImport]
        public int AcctExists { get; set; }

        /// <summary>
        /// Gets or sets AcctStatus 
        /// </summary>
        [IgnoreExportImport]
        public int AcctStatus { get; set; }

        /// <summary>
        /// Gets or sets RetainageDistributionAmount 
        /// </summary>
        [Display(Name = "RetainageDistributionAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageDistributionAmount { get; set; }

        /// <summary>
        /// Gets or sets InvoicedRetainageDistribution 
        /// </summary>
        [Display(Name = "InvoicedRetainageDistribution", ResourceType = typeof(InvoiceResx))]
        public decimal InvoicedRetainageDistribution { get; set; }

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
        /// Gets or sets TaxReportingAllocatedTax 
        /// </summary>
        [Display(Name = "TaxReportingAllocatedTax", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAllocatedTax { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax1 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax2 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax3 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax4 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingExpensedTax5 
        /// </summary>
        [Display(Name = "TaxReportingExpensedTax5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingExpensedTax5 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax1 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax1 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax2 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax2 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax3 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax3 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax4 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax4 { get; set; }

        /// <summary>
        /// Gets or sets TaxReportingRecoverableTax5 
        /// </summary>
        [Display(Name = "TaxReportingRecoverableTax5", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingRecoverableTax5 { get; set; }

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
        /// Gets or sets FuncRetainageTaxAmount1 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxAmount2 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxAmount3 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxAmount4 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxAmount5 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount1 
        /// </summary>
        [Display(Name = "FuncTaxRecoverableAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxRecoverableAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount2 
        /// </summary>
        [Display(Name = "FuncTaxRecoverableAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxRecoverableAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount3 
        /// </summary>
        [Display(Name = "FuncTaxRecoverableAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxRecoverableAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount4 
        /// </summary>
        [Display(Name = "FuncTaxRecoverableAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxRecoverableAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount5 
        /// </summary>
        [Display(Name = "FuncTaxRecoverableAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxRecoverableAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseSepAmount1 
        /// </summary>
        [Display(Name = "FuncTaxExpenseSepAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxExpenseSepAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseSepAmount2 
        /// </summary>
        [Display(Name = "FuncTaxExpenseSepAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxExpenseSepAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseSepAmount3 
        /// </summary>
        [Display(Name = "FuncTaxExpenseSepAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxExpenseSepAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseSepAmount4 
        /// </summary>
        [Display(Name = "FuncTaxExpenseSepAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxExpenseSepAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseSepAmount5 
        /// </summary>
        [Display(Name = "FuncTaxExpenseSepAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxExpenseSepAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedTotal 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedTotal", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedTotal { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount1 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount2 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount3 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount4 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount5 
        /// </summary>
        [Display(Name = "FuncTaxAllocatedAmount5", ResourceType = typeof(InvoiceResx))]
        public decimal FuncTaxAllocatedAmount5 { get; set; }

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
        /// Gets or sets FuncCost 
        /// </summary>
        [Display(Name = "FuncCost", ResourceType = typeof(InvoiceResx))]
        public decimal FuncCost { get; set; }

        /// <summary>
        /// Gets or sets FuncDistributedAmount 
        /// </summary>
        [Display(Name = "FuncDistributedAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncDistributedAmount { get; set; }

        /// <summary>
        /// Gets or sets FuncDistributionNetofTaxes 
        /// </summary>
        [Display(Name = "FuncDistributionNetofTaxes", ResourceType = typeof(InvoiceResx))]
        public decimal FuncDistributionNetofTaxes { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageAmount 
        /// </summary>
        [Display(Name = "FuncRetainageAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxAllocated 
        /// </summary>
        [Display(Name = "FuncRetainageTaxAllocated", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxAllocated { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxAllocated 
        /// </summary>
        [Display(Name = "RetainageTaxAllocated", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAllocated { get; set; }

        /// <summary>
        /// Gets or sets FuncRetainageTaxExpensed 
        /// </summary>
        [Display(Name = "FuncRetainageTaxExpensed", ResourceType = typeof(InvoiceResx))]
        public decimal FuncRetainageTaxExpensed { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxExpensed 
        /// </summary>
        [Display(Name = "RetainageTaxExpensed", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxExpensed { get; set; }

        /// <summary>
        /// Gets or sets RetainageTaxTotal 
        /// </summary>
        [Display(Name = "RetainageTaxTotal", ResourceType = typeof(InvoiceResx))]
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
        /// Gets or sets CurrRetainageAmount 
        /// </summary>
        [Display(Name = "CurrRetainageAmount", ResourceType = typeof(InvoiceResx))]
        public decimal CurrRetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets CurrRetainageDistAmount 
        /// </summary>
        [Display(Name = "CurrRetainageDistAmount", ResourceType = typeof(InvoiceResx))]
        public decimal CurrRetainageDistAmount { get; set; }

        /// <summary>
        /// Gets or sets FixedAsset 
        /// </summary>
        [Display(Name = "FASFixedAssets", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag FixedAsset { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsOrgid 
        /// </summary>
        [Display(Name = "SageFixedAssetsOrgID", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsOrgid { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsDatabase 
        /// </summary>
        [Display(Name = "SageFixedAssetsDatabase", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsDatabase { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsCompanyOrOrg 
        /// </summary>
        [Display(Name = "SageFixedAssetsCompanyOrOrg", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsCompanyOrOrg { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsTemplate 
        /// </summary>
        [Display(Name = "SageFixedAssetsTemplate", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsTemplate { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsAssetDescription 
        /// </summary>
        [Display(Name = "SageFixedAssetsAssetDescription", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsAssetDescription { get; set; }

        /// <summary>
        /// Gets or sets SeparateAssets 
        /// </summary>
        [Display(Name = "FASSeparateAssets", ResourceType = typeof(InvoiceResx))]
        public BatchPrintedFlag SeparateAssets { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsQuantity 
        /// </summary>
        [Display(Name = "SageFixedAssetsQuantity", ResourceType = typeof(InvoiceResx))]
        public decimal SageFixedAssetsQuantity { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsUnitofMeasure 
        /// </summary>
        [Display(Name = "SageFixedAssetsUnitofMeasure", ResourceType = typeof(InvoiceResx))]
        public string SageFixedAssetsUnitofMeasure { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsAssetValue 
        /// </summary>
        [Display(Name = "SageFixedAssetsAssetValue", ResourceType = typeof(InvoiceResx))]
        public decimal SageFixedAssetsAssetValue { get; set; }

        /// <summary>
        /// Gets or sets SageFixedAssetsFuncAssetVa 
        /// </summary>
        [Display(Name = "SageFixedAssetsFuncAssetVa", ResourceType = typeof(InvoiceResx))]
        public decimal SageFixedAssetsFuncAssetVa { get; set; }

        // AR Invoice Entry Attributes

        /// <summary>
        /// Gets or sets COGSAmount 
        /// </summary>
        [Display(Name = "COGSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal COGSAmount { get; set; }

        /// <summary>
        /// Gets or sets COGSAccount 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "COGSAccount", ResourceType = typeof(InvoiceResx))]
        public string COGSAccount { get; set; }

        /// <summary>
        /// Gets or sets Comments 
        /// </summary>
        [StringLength(250, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets CurrAlternateBaseAmount 
        /// </summary>
        [Display(Name = "CurrAlternateBaseAmount", ResourceType = typeof(InvoiceResx))]
        public decimal CurrAlternateBaseAmount { get; set; }

        /// <summary>
        /// Gets or sets CurrCOGSAmount 
        /// </summary>
        [Display(Name = "CurrCOGSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal CurrCOGSAmount { get; set; }

        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets ExtendedAmountwOroTIP 
        /// </summary>
        [Display(Name = "ExtendedAmountwOroTIP", ResourceType = typeof(InvoiceResx))]
        public decimal ExtendedAmountwOroTIP { get; set; }

        /// <summary>
        /// Gets or sets ExtendedAmountwOrTIP 
        /// </summary>
        [Display(Name = "ExtendedAmountwOrTIP", ResourceType = typeof(InvoiceResx))]
        public decimal ExtendedAmountwOrTIP { get; set; }

        /// <summary>
        /// Gets or sets FuncExtendedAmountwOroTIP 
        /// </summary>

        public decimal FuncExtendedAmountwOroTIP { get; set; }


        /// <summary>
        /// Gets or sets FuncExtendedAmountwOrTIP 
        /// </summary>
        [Display(Name = "FuncExtendedAmountwOrTIP", ResourceType = typeof(InvoiceResx))]
        public decimal FuncExtendedAmountwOrTIP { get; set; }


        /// <summary>
        /// Gets or sets FuncCOGSAmount 
        /// </summary>

        [Display(Name = "FuncCOGSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal FuncCOGSAmount { get; set; }


        /// <summary>
        /// Gets or sets Price 
        /// </summary>

        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets IDINVC 
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string IDINVC { get; set; }


        /// <summary>
        /// Gets or sets IDJOBPROJ 
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string IDJOBPROJ { get; set; }

        /// <summary>
        /// Gets or sets InventoryAccount 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InventoryAccount", ResourceType = typeof(InvoiceResx))]
        public string InventoryAccount { get; set; }

        /// <summary>
        /// Gets or sets InvoicedRetainageAlternateBas 
        /// </summary>

        [Display(Name = "InvoicedRetainageAlternateBas", ResourceType = typeof(InvoiceResx))]
        public decimal InvoicedRetainageAlternateBas { get; set; }

        /// <summary>
        /// Gets or sets InvoicedRetainageCOGS 
        /// </summary>

        [Display(Name = "InvoicedRetainageCOGS", ResourceType = typeof(InvoiceResx))]
        public decimal InvoicedRetainageCOGS { get; set; }


        /// <summary>
        /// Gets or sets ItemCost 
        /// </summary>

        [Display(Name = "ItemCost", ResourceType = typeof(InvoiceResx))]
        public decimal ItemCost { get; set; }

        /// <summary>
        /// Gets or sets FuncPrice 
        /// </summary>

        [Display(Name = "FuncPrice", ResourceType = typeof(InvoiceResx))]
        public decimal FuncPrice { get; set; }

        /// <summary>
        /// Gets or sets PrintComment 
        /// </summary>
        [Display(Name = "PrintComment", ResourceType = typeof(InvoiceResx))]
        public int PrintComment { get; set; }

        /// <summary>
        /// Gets or sets RetainageAlternateBaseAmount 
        /// </summary>

        [Display(Name = "RetainageAlternateBaseAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageAlternateBaseAmount { get; set; }

        /// <summary>
        /// Gets or sets RetainageCOGSAmount 
        /// </summary>

        [Display(Name = "RetainageCOGSAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageCOGSAmount { get; set; }

        /// <summary>
        /// Gets or sets RevenueAccount 
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RevenueAccount", ResourceType = typeof(InvoiceResx))]
        public string RevenueAccount { get; set; }

        /// <summary>
        /// Gets or sets SWMANLITEM 
        /// </summary>

        public int SWMANLITEM { get; set; }

        /// <summary>
        /// Gets or sets SWMANLTX 
        /// </summary>

        public int SWMANLTX { get; set; }

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
        /// Gets or sets TaxIncluded1 
        /// </summary>
        [Display(Name = "TaxIncluded1", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded1 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded2 
        /// </summary>
        [Display(Name = "TaxIncluded2", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded2 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded3 
        /// </summary>

        [Display(Name = "TaxIncluded3", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded3 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded4 
        /// </summary>

        [Display(Name = "TaxIncluded4", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded4 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncluded5 
        /// </summary>

        [Display(Name = "TaxIncluded5", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded5 { get; set; }

        /// <summary>
        /// Gets or sets Values 
        /// </summary>
        public long Values { get; set; }

        /// <summary>
        /// Gets or Sets DetailTaxes
        /// </summary>
        public EnumerableResponse<TaxGroupAuthority> DetailTaxes { get; set; }

        /// <summary>
        /// Gets or Sets DetailOptionalFieldList
        /// </summary>
        public EnumerableResponse<BaseInvoiceOptionalField> DetailOptionalFieldList { get; set; }
    }
}
