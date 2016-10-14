/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEInvBaseAddCostsSuperview
    /// </summary>
    public partial class POOEInvBaseAddCostsSuperview : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets INVSREV
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        public decimal InvSrev { get; set; }

        /// <summary>
        /// Gets or sets InvoiceCostSequence
        /// </summary>
        [IgnoreExportImport]
        public decimal InvoiceCostSequence { get; set; }

        /// <summary>
        /// Gets or sets ReceiptSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal ReceiptSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ReceiptCostSequence
        /// </summary>
        [IgnoreExportImport]
        public decimal ReceiptCostSequence { get; set; }

        /// <summary>
        /// Gets or sets ReturnSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal ReturnSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ReturnCostSequence
        /// </summary>
        [IgnoreExportImport]
        public decimal ReturnCostSequence { get; set; }

        /// <summary>
        /// Gets or sets CompletionStatus
        /// </summary>
        [IgnoreExportImport]
        public CompletionStatus CompletionStatus { get; set; }

        /// <summary>
        /// Gets or sets DateCompleted
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [IgnoreExportImport]
        public DateTime DateCompleted { get; set; }

        /// <summary>
        /// Gets or sets StoredInDatabaseTable
        /// </summary>
        [IgnoreExportImport]
        public AllowedType StoredInDatabaseTable { get; set; }

        /// <summary>
        /// Gets or sets AdditionalCost
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "AdditionalCost", ResourceType = typeof(InvoiceResx))]
        public string AdditionalCost { get; set; }

        /// <summary>
        /// Gets or sets ExpenseAccount
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ExpenseAccount", ResourceType = typeof(InvoiceResx))]
        public string ExpenseAccount { get; set; }

        /// <summary>
        /// Gets or sets ReturnAccount
        /// </summary>
        [StringLength(45, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReturnAccount", ResourceType = typeof(InvoiceResx))]
        public string ReturnAccount { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        [Display(Name = "Amount", ResourceType = typeof(CommonResx))]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets ProrationMethod
        /// </summary>
        [Display(Name = "ProrationMethod", ResourceType = typeof(InvoiceResx))]
        public ProrationMethod ProrationMethod { get; set; }

        /// <summary>
        /// Gets or sets ReprorationMethod
        /// </summary>
        [Display(Name = "ReprorationMethod", ResourceType = typeof(InvoiceResx))]
        public ReprorationMethod ReprorationMethod { get; set; }

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
        /// Gets or sets CostTaxClass1
        /// </summary>
        [Display(Name = "CostTaxClass1", ResourceType = typeof(InvoiceResx))]
        public int CostTaxClass1 { get; set; }

        /// <summary>
        /// Gets or sets CostTaxClass2
        /// </summary>
        [Display(Name = "CostTaxClass2", ResourceType = typeof(InvoiceResx))]
        public int CostTaxClass2 { get; set; }

        /// <summary>
        /// Gets or sets CostTaxClass3
        /// </summary>
        [Display(Name = "CostTaxClass3", ResourceType = typeof(InvoiceResx))]
        public int CostTaxClass3 { get; set; }

        /// <summary>
        /// Gets or sets CostTaxClass4
        /// </summary>
        [Display(Name = "CostTaxClass4", ResourceType = typeof(InvoiceResx))]
        public int CostTaxClass4 { get; set; }

        /// <summary>
        /// Gets or sets CostTaxClass5
        /// </summary>
        [Display(Name = "CostTaxClass5", ResourceType = typeof(InvoiceResx))]
        public int CostTaxClass5 { get; set; }

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
        /// Gets or sets TaxIncludable1
        /// </summary>
        [Display(Name = "TaxIncludable1", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncludable1 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncludable2
        /// </summary>
        [Display(Name = "TaxIncludable2", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncludable2 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncludable3
        /// </summary>
        [Display(Name = "TaxIncludable3", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncludable3 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncludable4
        /// </summary>
        [Display(Name = "TaxIncludable4", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncludable4 { get; set; }

        /// <summary>
        /// Gets or sets TaxIncludable5
        /// </summary>
        [Display(Name = "TaxIncludable5", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncludable5 { get; set; }

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
        /// Gets or sets TaxRecoverableAmount1
        /// </summary>
        [Display(Name = "TaxRecoverableAmount1", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount1 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount2
        /// </summary>
        [Display(Name = "TaxRecoverableAmount2", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount2 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount3
        /// </summary>
        [Display(Name = "TaxRecoverableAmount3", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount3 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount4
        /// </summary>
        [Display(Name = "TaxRecoverableAmount4", ResourceType = typeof(InvoiceResx))]
        public decimal TaxRecoverableAmount4 { get; set; }

        /// <summary>
        /// Gets or sets TaxRecoverableAmount5
        /// </summary>
        [Display(Name = "TaxRecoverableAmount5", ResourceType = typeof(InvoiceResx))]
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
        /// Gets or sets NetOfTax
        /// </summary>
        [Display(Name = "NetofTax", ResourceType = typeof(InvoiceResx))]
        public decimal NetOfTax { get; set; }


        /// <summary>
        /// Gets or sets TaxIncluded
        /// </summary>
        [Display(Name = "TaxIncluded", ResourceType = typeof(InvoiceResx))]
        public decimal TaxIncluded { get; set; }

        /// <summary>
        /// Gets or sets TaxExcluded
        /// </summary>
        [Display(Name = "TaxExcluded", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExcluded { get; set; }

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
        /// Gets or sets TotalTaxAllocated
        /// </summary>
        [Display(Name = "TotalTaxAllocated", ResourceType = typeof(InvoiceResx))]
        public decimal TotalTaxAllocated { get; set; }

        /// <summary>
        /// Gets or sets FuncNetOfTax
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncNetOfTax { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxIncludedAmount1
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxIncludedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxIncludedAmount2
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxIncludedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxIncludedAmount3
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxIncludedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxIncludedAmount4
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxIncludedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxIncludedAmount5
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxIncludedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount1
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxAllocatedAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount2
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxAllocatedAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount3
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxAllocatedAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount4
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxAllocatedAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxAllocatedAmount5
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxAllocatedAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount1
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxRecoverableAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount2
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxRecoverableAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount3
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxRecoverableAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount4
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxRecoverableAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxRecoverableAmount5
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxRecoverableAmount5 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseAmount1
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxExpenseAmount1 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseAmount2
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxExpenseAmount2 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseAmount3
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxExpenseAmount3 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseAmount4
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxExpenseAmount4 { get; set; }

        /// <summary>
        /// Gets or sets FuncTaxExpenseAmount5
        /// </summary>
        [IgnoreExportImport]
        public decimal FuncTaxExpenseAmount5 { get; set; }

        /// <summary>
        /// Gets or sets ReceiptNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReceiptNumber", ResourceType = typeof(InvoiceResx))]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets ApplyToReceiptSequenceKey
        /// </summary>
        [IgnoreExportImport]
        public decimal ApplyToReceiptSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ApplyToReceiptNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ApplyToReceiptNumber", ResourceType = typeof(InvoiceResx))]
        public string ApplyToReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceCostGroupSequence
        /// </summary>
        [IgnoreExportImport]
        public decimal InvoiceCostGroupSequence { get; set; }

        /// <summary>
        /// Gets or sets OptionalFields
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "OptionalFields", ResourceType = typeof(InvoiceResx))]
        public long OptionalFields { get; set; }

        /// <summary>
        /// Gets or sets PaymentDiscountable
        /// </summary>
        [Display(Name = "PaymentDiscountable", ResourceType = typeof(InvoiceResx))]
        public AllowedType PaymentDiscountable { get; set; }

        /// <summary>
        /// Gets or sets Contract
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Contract { get; set; }

        /// <summary>
        /// Gets or sets Project
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Project { get; set; }

        /// <summary>
        /// Gets or sets CostCategory
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CostCategory", ResourceType = typeof(InvoiceResx))]
        public string CostCategory { get; set; }

        /// <summary>
        /// Gets or sets CostClass
        /// </summary>
        [IgnoreExportImport]
        public CostClass CostClass { get; set; }

        /// <summary>
        /// Gets or sets Resource
        /// </summary>
        [StringLength(24, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets BillingType
        /// </summary>
        [Display(Name = "BillingType", ResourceType = typeof(InvoiceResx))]
        public int BillingType { get; set; }

        /// <summary>
        /// Gets or sets BillingRate
        /// </summary>
        [Display(Name = "BillingRate", ResourceType = typeof(InvoiceResx))]
        public decimal BillingRate { get; set; }

        /// <summary>
        /// Gets or sets BillingCurrency
        /// </summary>
        [IgnoreExportImport]
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Gets or sets ARItemNumber
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ARItemNo", ResourceType = typeof(InvoiceResx))]
        public string ARItemNumber { get; set; }

        /// <summary>
        /// Gets or sets ARUnitOfMeasure
        /// </summary>
        [StringLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ARItemUOM", ResourceType = typeof(InvoiceResx))]
        public string ARUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets CalculateOverhead
        /// </summary>
        [Display(Name = "CalculateOverhead", ResourceType = typeof(InvoiceResx))]
        public AllowedType CalculateOverhead { get; set; }

        /// <summary>
        /// Gets or sets CalculateLabor
        /// </summary>
        [Display(Name = "CalculateLabor", ResourceType = typeof(InvoiceResx))]
        public AllowedType CalculateLabor { get; set; }

        /// <summary>
        /// Gets or sets RetainagePercentage
        /// </summary>
        [Display(Name = "RetainagePercentage", ResourceType = typeof(InvoiceResx))]
        public decimal RetainagePercentage { get; set; }

        /// <summary>
        /// Gets or sets RetentionPeriod
        /// </summary>
        [Display(Name = "RetentionPeriod", ResourceType = typeof(InvoiceResx))]
        public int RetentionPeriod { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmount
        /// </summary>
        [Display(Name = "RetainageAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageAmount { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RetainageDueDate", ResourceType = typeof(InvoiceResx))]
        public DateTime RetainageDueDate { get; set; }

        /// <summary>
        /// Gets or sets RetainageAmountOverridden
        /// </summary>
        [IgnoreExportImport]
        public AllowedType RetainageAmountOverridden { get; set; }

        /// <summary>
        /// Gets or sets RetainageDueDateOverridden
        /// </summary>
        [IgnoreExportImport]
        public AllowedType RetainageDueDateOverridden { get; set; }

        /// <summary>
        /// Gets or sets CostDistributions
        /// </summary>
        [IgnoreExportImport]
        public long CostDistributions { get; set; }

        /// <summary>
        /// Gets or sets ManualCostDistributions
        /// </summary>
        [IgnoreExportImport]
        public long ManualCostDistributions { get; set; }

        /// <summary>
        /// Gets or sets ExtraneousCostDistributions
        /// </summary>
        [IgnoreExportImport]
        public long ExtraneousCostDistributions { get; set; }

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
        /// Gets or sets ExpenseAccountDescription
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ExpenseAccountDescription { get; set; }

        /// <summary>
        /// Gets or sets ReturnExpenseAccountDesc
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ReturnExpenseAccountDesc { get; set; }

        /// <summary>
        /// Gets or sets TaxClass1Description
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string TaxClass1Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass2Description
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string TaxClass2Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass3Description
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string TaxClass3Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass4Description
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string TaxClass4Description { get; set; }

        /// <summary>
        /// Gets or sets TaxClass5Description
        /// </summary>
        [IgnoreExportImport]
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string TaxClass5Description { get; set; }

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
        /// Gets or sets ManualToProrate
        /// </summary>
        [IgnoreExportImport]
        public decimal ManualToProrate { get; set; }

        /// <summary>
        /// Gets or sets Completed
        /// </summary>
        [IgnoreExportImport]
        public Completed Completed { get; set; }

        /// <summary>
        /// Gets or sets LinesTaxCalculationSees
        /// </summary>
        [IgnoreExportImport]
        public long LinesTaxCalculationSees { get; set; }

        /// <summary>
        /// Gets or sets CostsComplete
        /// </summary>
        [IgnoreExportImport]
        public long CostsComplete { get; set; }

        /// <summary>
        /// Gets or sets Costs
        /// </summary>
        [IgnoreExportImport]
        public long Costs { get; set; }

        /// <summary>
        /// Gets or sets RCPSREV
        /// </summary>
        [IgnoreExportImport]
        public decimal RcpSrev { get; set; }

        /// <summary>
        /// Gets or sets Command
        /// </summary>
        [IgnoreExportImport]
        public Command Command { get; set; }

        /// <summary>
        /// Gets or sets PaymentDiscountBaseWithTax
        /// </summary>
        [IgnoreExportImport]
        public decimal PaymentDiscountBaseWithTax { get; set; }

        /// <summary>
        /// Gets or sets PaymentDiscountBaseWithoutTa
        /// </summary>
        [IgnoreExportImport]
        public decimal PaymentDiscountBaseWithoutTa { get; set; }

        /// <summary>
        /// Gets or sets JobRelatedCost
        /// </summary>
        [IgnoreExportImport]
        public long JobRelatedCost { get; set; }

        /// <summary>
        /// Gets or sets AmountDistributionSum
        /// </summary>
        [IgnoreExportImport]
        public decimal AmountDistributionSum { get; set; }

        /// <summary>
        /// Gets or sets BillingRateDistributionSum
        /// </summary>
        [IgnoreExportImport]
        public decimal BillingRateDistributionSum { get; set; }

        /// <summary>
        /// Gets or sets ProjectStyle
        /// </summary>
        [IgnoreExportImport]
        public ProjectStyle ProjectStyle { get; set; }

        /// <summary>
        /// Gets or sets ProjectType
        /// </summary>
        [IgnoreExportImport]
        public ProjectType ProjectType { get; set; }

        /// <summary>
        /// Gets or sets AccountingMethod
        /// </summary>
        [IgnoreExportImport]
        public AccountingMethod AccountingMethod { get; set; }

        /// <summary>
        /// Gets or sets UnformattedContractCode
        /// </summary>
        [IgnoreExportImport]
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string UnformattedContractCode { get; set; }

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
        /// Gets or sets Function
        /// </summary>
        [IgnoreExportImport]
        public int Function { get; set; }

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
        /// </summary>
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
        /// Get and Sets OptionalFieldString
        /// </summary>
        [IgnoreExportImport]
        public String OptionalFieldString { get; set; }

        /// <summary>
        /// Get and Sets DistributeProrationString
        /// </summary>
        [Display(Name = "DistributeProration", ResourceType = typeof(InvoiceResx))]
        [IgnoreExportImport]
        public String DistributeProrationString { get; set; }

        /// <summary>
        ///  Gets or sets Attributes
        /// </summary>
        [IgnoreExportImport]
        public IDictionary<string, object> Attributes { get; set; }
    }
}
