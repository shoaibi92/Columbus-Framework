/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Constant file for Account Payable module
    /// </summary>
    public static class AccountPayable
    {
        #region Session

        /// <summary>
        /// ApSession key for Allocation 
        /// </summary>
        public const string ApSessionAllocation = "apallocationCache";

        /// <summary>
        /// ApSession Key for Optional Field 
        /// </summary>
        public const string ApSessionOptionalField = "apoptionalFieldCache";

        /// <summary>
        /// ApSession Key for Transaction Optional field 
        /// </summary>
        public const string ApSessionTranOptionalField = "aptranOptionalFieldCache";

        /// <summary>
        /// ApSession Key for Account Currency 
        /// </summary>
        public const string ApSessionAccountCurrency = "apaccountCurrencyCache";

        /// <summary>
        /// 
        /// </summary>
        public const string ApSessionRollupPreview = "aprollupPreviewCache";

        /// <summary>
        /// ApSession Key for Rollup 
        /// </summary>
        public const string ApSessionRollup = "aprollupCache";

        /// <summary>
        /// ApSession Key for Subledger 
        /// </summary>
        public const string ApSessionSubledger = "apsubledgerCache";

        /// <summary>
        /// ApSession Key for Segment 
        /// </summary>
        public const string ApSessionSegment = "apsegmentCache";

        /// <summary>
        /// ApSession Key for Optional 
        /// </summary>
        public const string ApSessionOptional = "apoptionalCache";


        /// <summary>
        /// ApSession Key for 1099/CPRS Inquiry 
        /// </summary>
        public const string ApSessionCPRSInquiry = "apCPRSInquiryCache";

        /// <summary>
        /// ApSession Key for Remit-To Location Vendor
        /// </summary>
        public const string SessionRemitToLocationVendor = "sessionremittolocationvendor";

        #endregion

        #region InvoiceBatchList
        /// <summary>
        /// The Invoice batch list Partial View
        /// </summary>
        public const string InvoiceBatchList = "~/Areas/AP/Views/InvoiceBatchList/Partial/_InvoiceBatchList.cshtml";

        /// <summary>
        /// The batchList grid
        /// </summary>
        public const string InvoiceBatchListGrid = "~/Areas/AP/Views/InvoiceBatchList/Partial/_InvoiceBatchListGrid.cshtml";

        /// <summary>
        /// The batch list localization
        /// </summary>
        public const string InvoiceBatchListLocalization = "~/Areas/AP/Views/InvoiceBatchList/Partial/_Localization.cshtml";
        #endregion

        #region AdjustmentBatchList
        /// <summary>
        /// The Adjustment batch list Partial View
        /// </summary>
        public const string AdjustmentBatchList = "~/Areas/AP/Views/AdjustmentBatchList/Partial/_AdjustmentBatchList.cshtml";

        /// <summary>
        /// The batchList grid
        /// </summary>
        public const string AdjustmentBatchListGrid = "~/Areas/AP/Views/AdjustmentBatchList/Partial/_AdjustmentBatchListGrid.cshtml";

        /// <summary>
        /// The batch list localization
        /// </summary>
        public const string AdjustmentBatchListLocalization = "~/Areas/AP/Views/AdjustmentBatchList/Partial/_Localization.cshtml";
        #endregion

        #region APEmailMessages

        /// <summary>
        /// The Email Message localization
        /// </summary>
        public const string EmailMessagesLocalization = "~/Areas/AP/Views/EmailMessage/Partials/_Localization.cshtml";

        //Account Payable region

        /// <summary>
        /// The Email Message Partial View
        /// </summary>
        public const string EmailMessages = "~/Areas/AP/Views/EmailMessage/Partials/_EmailMessage.cshtml";
        #endregion

        #region Recurring Payable

        /// <summary>
        /// The Recurring Payable localization
        /// </summary>
        public const string RecurringPayableLocalization = "~/Areas/AP/Views/RecurringPayable/Partials/_Localization.cshtml";

        /// <summary>
        /// The Recurring Payable Partial View
        /// </summary>
        public const string RecurringPayable = "~/Areas/AP/Views/RecurringPayable/Partials/_RecurringPayable.cshtml";

        /// <summary>
        /// The Recurring Payable Detail Partial View
        /// </summary>
        public const string RecurringPayableDetail = "~/Areas/AP/Views/RecurringPayable/Partials/_Detail.cshtml";

        /// <summary>
        /// The Recurring Payable Invoice Partial View
        /// </summary>
        public const string RecurringPayableInvoice = "~/Areas/AP/Views/RecurringPayable/Partials/_Invoice.cshtml";

        /// <summary>
        /// The Recurring Payable OptionalFields Partial View
        /// </summary>
        public const string RecurringPayableOptionalFields = "~/Areas/AP/Views/RecurringPayable/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// The Recurring Payable Statistics Partial View
        /// </summary>
        public const string RecurringPayableStatistics = "~/Areas/AP/Views/RecurringPayable/Partials/_Statistics.cshtml";

        /// <summary>
        /// The Recurring Payable TaxTotals Partial View
        /// </summary>
        public const string RecurringPayableTaxTotals = "~/Areas/AP/Views/RecurringPayable/Partials/_TaxTotals.cshtml";

        /// <summary>
        /// The Recurring Payable RemitToInfo Partial View
        /// </summary>
        public const string RecurringPayableRemitToInfo = "~/Areas/AP/Views/RecurringPayable/Partials/_RemitToInfo.cshtml";

        /// <summary>
        /// The Recurring Payable VendorInfo Partial View
        /// </summary>
        public const string RecurringPayableVendorInfo = "~/Areas/AP/Views/RecurringPayable/Partials/_VendorInfo.cshtml";

        /// <summary>
        /// The Recurring Payable Optional Fields Details Partial View
        /// </summary>
        public const string RecurringPayableOptionalFieldsDetails = "~/Areas/AP/Views/RecurringPayable/Partials/_OptionalFieldsGrid.cshtml";

        /// <summary>
        /// Recurring Payable Grid
        /// </summary>
        public const string RecurringPayableDetailGrid = "~/Areas/AP/Views/RecurringPayable/Partials/_DetailGrid.cshtml";

        ///// <summary>
        ///// The Recurring Payable CreateInvoice Partial View
        ///// </summary>
        //public const string RecurringPayableCreateInvoice = "~/Areas/AP/Views/RecurringPayable/Partials/_CreateInvoice.cshtml";

        /// <summary>
        /// The Recurring Payable CreateInvoice Partial View
        /// </summary>
        public const string RecurringPayableCreateInvoice = "~/Areas/AP/Views/CreateInvoice/Partials/_CreateInvoice.cshtml";

        /// <summary>
        /// The Recurring Payable CreateInvoice localization
        /// </summary>
        public const string RecurringPayableCreateInvoiceLocalization = "~/Areas/AP/Views/CreateInvoice/Partials/_Localization.cshtml";

        /// <summary>
        /// The Recurring Payable CreateInvoice Partial View
        /// </summary>
        public const string RecurringPayableDetailAccountTax = "~/Areas/AP/Views/RecurringPayable/Partials/_DetailAccountTax.cshtml";

        /// <summary>
        /// The Recurring Payable DetailGrid OptionalFields popup Partial View
        /// </summary>
        public const string RecurringPayableDetailOptionalFields = "~/Areas/AP/Views/RecurringPayable/Partials/_DetailGridOptionalField.cshtml";

        /// <summary>
        /// Invoice Entry Taxes Grid
        /// </summary>
        public const string RecurringPayableTaxesGrid = "~/Areas/AP/Views/RecurringPayable/Partials/_TaxesGrid.cshtml";

        #endregion

        #region Recurring Payable Report

        /// <summary>
        /// The Age Payable Reports localization
        /// </summary>
        public const string RecurringPayableReportLocalization = "~/Areas/AP/Views/RecurringPayableReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Aged Payables reports Partials view
        /// </summary>
        public const string RecurringPayableReport = "~/Areas/AP/Views/RecurringPayableReport/Partials/_RecurringPayableReport.cshtml";

        #endregion

        #region Recurring Payable Report

        /// <summary>
        /// The Vendor Group Report localization
        /// </summary>
        public const string VendorGroupReportLocalization = "~/Areas/AP/Views/VendorGroupReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Vendor Group Report Partials view
        /// </summary>
        public const string VendorGroupReport = "~/Areas/AP/Views/VendorGroupReport/Partials/_VendorGroupReport.cshtml";

        #endregion

        #region CreateRecurringPayableBatch
        /// <summary>
        /// Create Recurring Payable Batch
        /// </summary>
        public const string CreateRecurringPayableBatch = "~/Areas/AP/Views/CreateRecurringPayableBatch/Partials/_CreateRecurPayBatch.cshtml";

        /// <summary>
        /// Create Recurring Payable Batch Localization
        /// </summary>
        public const string CreateRecurringPayableBatchLocalization = "~/Areas/AP/Views/CreateRecurringPayableBatch/Partials/_Localization.cshtml";

        #endregion

        #region Process Year End

        /// <summary>
        /// AP Process Year End
        /// </summary>
        public const string APProcessYearEnd = "~/Areas/AP/Views/ProcessYearEnd/Partials/_ProcessYearEnd.cshtml";


        /// <summary>
        /// Process Year End Localization
        /// </summary>
        public const string ProcessYearEndLocalization = "~/Areas/AP/Views/ProcessYearEnd/Partials/_Localization.cshtml";
        #endregion

        #region CreateGLBatch
        /// <summary>
        /// Create GL Batch
        /// </summary>

        public const string APCreateGLBatch = "~/Areas/AP/Views/CreateGLBatch/Partials/_CreateGLBatch.cshtml";


        /// <summary>
        /// Create GL Batch Localization
        /// </summary>
        public const string CreateGLBatchLocalization = "~/Areas/AP/Views/CreateGLBatch/Partials/_Localization.cshtml";

        #endregion

        #region ProcessingStatus

        /// <summary>
        /// Processing Status 
        /// </summary>
        public const string ProcessingStatus = "~/Areas/Core/Views/Shared/_ProcessingStatus.cshtml";

        #endregion

        #region CPRS Code
        /// <summary>
        /// The CPRS Code Localization
        /// </summary>
        public const string CPRSCodeLocalization = "~/Areas/AP/Views/CPRSCode/Partials/_Localization.cshtml";
        /// <summary>
        /// The CPRS Code Partial View
        /// </summary>
        public const string CPRSCodePartial = "~/Areas/AP/Views/CPRSCode/Partials/_CPRSCode.cshtml";

        #endregion

        #region Distribution Code

        /// <summary>
        /// Distribution code Localization
        /// </summary>
        public const string DistributionCodeLocalization = "~/Areas/AP/Views/DistributionCode/Partials/_Localization.cshtml";

        #endregion

        #region Payment Code

        /// <summary>
        /// The Ap Payment Code Partial View
        /// </summary>
        public const string PaymentCode = "~/Areas/AP/Views/PaymentCode/Partials/_PaymentCode.cshtml";
        #endregion

        #region Account Set

        /// <summary>
        /// The Account set Partial View
        /// </summary>
        public const string AccountSet = "~/Areas/AP/Views/AccountSet/Partials/_AccountSet.cshtml";
        /// <summary>
        /// The Account set localization
        /// </summary>
        public const string AccountSetupLocalization = "~/Areas/AP/Views/AccountSet/Partials/_Localization.cshtml";

        #endregion

        #region Options

        /// <summary>
        /// Options localization partial view
        /// </summary>
        public const string OptionsLocalization = "~/Areas/AP/Views/Options/Partials/_Localization.cshtml";

        /// <summary>
        /// The options Company
        /// </summary>
        public const string OptionsCompany = "~/Areas/AP/Views/Options/Partials/_Company.cshtml";

        /// <summary>
        /// The options Processing
        /// </summary>
        public const string OptionsProcessing = "~/Areas/AP/Views/Options/Partials/_Processing.cshtml";

        /// <summary>
        /// The options Numbering
        /// </summary>
        public const string OptionsNumbering = "~/Areas/AP/Views/Options/Partials/_Numbering.cshtml";

        /// <summary>
        /// Options Numbering Documnet partial view 
        /// </summary>
        public const string OptionsNumberingDocumnet = "~/Areas/AP/Views/Options/Partials/_NumberingDocument.cshtml";

        /// <summary>
        /// Options Numbering Next Batch Posting Sequence partial view 
        /// </summary>
        public const string OptionsNumberingNextBatchPostingSequence = "~/Areas/AP/Views/Options/Partials/_NumberingNextBatchPostingSequenceNumber.cshtml";

        /// <summary>
        /// The options Retainage
        /// </summary>
        public const string OptionsRetainage = "~/Areas/AP/Views/Options/Partials/_Retainage.cshtml";

        /// <summary>
        /// The options Aging Periods Grid
        /// </summary>
        public const string OptionsAgingPeriodsGrid = "~/Areas/AP/Views/Options/Partials/_AgingPeriodsGrid.cshtml";

        /// <summary>
        /// The Options Retainage Grid
        /// </summary>
        public const string OptionsRetainageGrid = "~/Areas/AP/Views/Options/Partials/_RetainageGrid.cshtml";

        #endregion

        #region CheckRegister

        /// <summary>
        /// The Check Register Partial View
        /// </summary>
        public const string CheckRegister = "~/Areas/AP/Views/CheckRegister/Partials/_CheckRegister.cshtml";

        /// <summary>
        /// The Check Register localization
        /// </summary>
        public const string CheckRegisterLocalization = "~/Areas/AP/Views/CheckRegister/Partials/_Localization.cshtml";

        #endregion

        #region PaymentBatchList

        /// <summary>
        /// The Payment batch list Partial View
        /// </summary>
        public const string PaymentBatchList = "~/Areas/AP/Views/PaymentBatchList/Partial/_PaymentBatchList.cshtml";

        /// <summary>
        /// The Payment batch List grid
        /// </summary>
        public const string PaymentBatchListGrid = "~/Areas/AP/Views/PaymentBatchList/Partial/_PaymentBatchListGrid.cshtml";

        /// <summary>
        /// The Payment batch list localization
        /// </summary>
        public const string PaymentBatchListLocalization = "~/Areas/AP/Views/PaymentBatchList/Partial/_Localization.cshtml";


        #endregion

        #region PostBatch

        /// <summary>
        /// The Email Messages localization
        /// </summary>
        public const string PostBatchLocalization = "~/Areas/AP/Views/PostBatch/Partials/_Localization.cshtml";

        //Account Payable region

        /// <summary>
        /// The Email Messages Partial View
        /// </summary>
        public const string PostBatch = "~/Areas/AP/Views/PostBatch/Partials/_PostBatch.cshtml";
        #endregion

        #region Distribution Code

        /// <summary>
        /// Distribution code partial view
        /// </summary>
        public const string DistributionCodePartial = "~/Areas/AP/Views/DistributionCode/Partials/_DistributionCode.cshtml";

        #endregion

        #region Payment Code

        /// <summary>
        /// Payment code Localization
        /// </summary>
        public const string LocalizationPaymentCodePartial = "~/Areas/AP/Views/PaymentCode/Partials/_Localization.cshtml";


        #endregion

        #region Account Set

        #endregion

        #region Options

        /// <summary>
        /// The options
        /// </summary>
        public const string Options = "~/Areas/AP/Views/Options/Partials/_Options.cshtml";

        /// <summary>
        /// The options Transactions
        /// </summary>
        public const string OptionsTransactions = "~/Areas/AP/Views/Options/Partials/_Transactions.cshtml";

        #endregion

        #region CheckRegister

        #endregion

        #region Report Localization

        /// <summary>
        /// The report localization
        /// </summary>
        public const string ReportLocalization = "~/Areas/AP/Views/Shared/Partials/ReportLocalization.cshtml";

        #endregion

        #region Age Payables Reports

        /// <summary>
        /// The Age Payable Reports localization
        /// </summary>
        public const string AgedPayableLocalization = "~/Areas/AP/Views/AgedPayable/Partials/_Localization.cshtml";

        /// <summary>
        /// Aged Payables reports Partials view
        /// </summary>
        public const string AgedPayable = "~/Areas/AP/Views/AgedPayable/Partials/_AgedPayable.cshtml";
        #endregion

        #region Print 1099/1096 Form Reports

        /// <summary>
        /// The Age Payable Reports localization
        /// </summary>
        public const string Print10991096FormLocalization = "~/Areas/AP/Views/Print10991096Form/Partials/_Localization.cshtml";

        /// <summary>
        /// Aged Payables reports Partials view
        /// </summary>
        public const string Print10991096Form = "~/Areas/AP/Views/Print10991096Form/Partials/_Print10991096Form.cshtml";
        #endregion

        #region Transaction Reports Common

        /// <summary>
        /// Common for  Report -Show block
        /// </summary>
        public const string Show = "~/Areas/AP/Views/AgedPayable/Partials/_Show.cshtml";

        /// <summary>
        /// Common for  Report -TransactionTypes block
        /// </summary>
        public const string TransactionTypes = "~/Areas/AP/Views/AgedPayable/Partials/_TransactionTypes.cshtml";

        /// <summary>
        /// Common for  Report -Include block
        /// </summary>
        public const string Include = "~/Areas/AP/Views/AgedPayable/Partials/_Include.cshtml";

        /// <summary>
        /// Common for Select Vendors By
        /// </summary>
        public const string SelectVendorsBy = "~/Areas/AP/Views/AgedPayable/Partials/_SelectVendorsBy.cshtml";

        /// <summary>
        /// Common for sort vendors by aged payable reports and aged cash requirements
        /// </summary>
        public const string SortVendorsBy = "~/Areas/AP/Views/AgedPayable/Partials/_SortVendorsBy.cshtml";


        /// <summary>
        /// Common for  Report -Show block
        /// </summary>
        public const string AgedCashRequirementShow = "~/Areas/AP/Views/AgedCashRequirement/Partials/_AgedCashShow.cshtml";

        /// <summary>
        /// Common for  Report -TransactionTypes block
        /// </summary>
        public const string AgedCashRequirementTransactionTypes = "~/Areas/AP/Views/AgedCashRequirement/Partials/_AgedCashTransactionTypes.cshtml";

        /// <summary>
        /// Common for  Report -Include block
        /// </summary>
        public const string AgedCashRequirementInclude = "~/Areas/AP/Views/AgedCashRequirement/Partials/_AgedCashInclude.cshtml";

        #endregion

        #region VendorsReport
        /// <summary>
        /// Vendors Report
        /// </summary>
        public const string ApVendorsReport = "~/Areas/AP/Views/VendorReport/Partials/_VendorsReport.cshtml";

        /// <summary>
        /// For Select Vendors By block
        /// </summary>
        public const string ApVendorsReportSelVendrBy = "~/Areas/AP/Views/VendorReport/Partials/_SelectVendorsBy.cshtml";

        #region Vendors Report LetterAndLabel

        /// <summary>
        /// Letter And Label Localization
        /// </summary>
        public const string LabelAndLetterLocalization = "~/Areas/AP/Views/LetterAndLabel/Partials/_Localization.cshtml";

        /// <summary>
        /// Letter And Label report cshtml
        /// </summary>
        public const string ApLetterAndLabel = "~/Areas/AP/Views/LetterAndLabel/Partials/_LetterAndLabel.cshtml";

        /// <summary>
        /// Letter And Label Select Vendors By
        /// </summary>
        public const string LetterAndLabelSelectVendorsBy = "~/Areas/AP/Views/LetterAndLabel/Partials/_SelectVendorsBy.cshtml";

        /// <summary>
        /// Letter And Label Sort Vendors By
        /// </summary>
        public const string LetterAndLabelSortVendorsBy = "~/Areas/AP/Views/LetterAndLabel/Partials/_SortVendorsBy.cshtml";

        /// <summary>
        /// Letter And Label Delivery Method
        /// </summary>
        public const string DeliveryMethod = "~/Areas/AP/Views/LetterAndLabel/Partials/_DeliveryMethod.cshtml";
        #endregion

        /// <summary>
        /// For Sort Vendors By block
        /// </summary>
        public const string ApVendorsReportSortVendrBy = "~/Areas/AP/Views/VendorReport/Partials/_SortVendorsBy.cshtml";

        /// <summary>
        /// For Localization
        /// </summary>
        public const string ApVendorsReportLocalization = "~/Areas/AP/Views/VendorReport/Partials/_Localization.cshtml";

        #region PrintT5018CprsReport
        /// <summary>
        /// Letter And Label Localization
        /// </summary>
        public const string PrintT5018CprsReportLocalization = "~/Areas/AP/Views/PrintT5018CprsReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Letter And Label report cshtml
        /// </summary>
        public const string PrintT5018CprsReport = "~/Areas/AP/Views/PrintT5018CprsReport/Partials/_PrintT5018CprsReport.cshtml";
        #endregion

        #region RemitToLocation
        /// <summary>
        /// Vendors Report
        /// </summary>
        public const string RemitToLocationReport = "~/Areas/AP/Views/RemitToLocationReport/Partials/_RemitToLocationReport.cshtml";

        /// <summary>
        /// The Age Payable Reports localization
        /// </summary>
        public const string RemitToLocationReportLocalization = "~/Areas/AP/Views/RemitToLocationReport/Partials/_Localization.cshtml";
        #endregion

        #endregion

        #region VendorGroups

        /// <summary>
        /// The Email Messages localization
        /// </summary>
        public const string VendorGroupLocalization = "~/Areas/AP/Views/VendorGroup/Partials/_Localization.cshtml";

        //Account Payable region

        /// <summary>
        /// The Vendor Groups Invoicing Partial View
        /// </summary>
        public const string VendorGroup = "~/Areas/AP/Views/VendorGroup/Partials/_VendorGroup.cshtml";

        /// <summary>
        /// The Vendor Groups Invoicing Partial View
        /// </summary>
        public const string VendorGroupData = "~/Areas/AP/Views/VendorGroup/Partials/_Group.cshtml";

        /// <summary>
        /// The Vendor Groups Invoicing Partial View
        /// </summary>
        public const string VendorGroupInvoicing = "~/Areas/AP/Views/VendorGroup/Partials/_Invoicing.cshtml";

        /// <summary>
        /// The Vendor Groups Invoicing Partial View
        /// </summary>
        public const string VendorGroupOptinalFields = "~/Areas/AP/Views/VendorGroup/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// The Vendor Groups Invoicing Partial View
        /// </summary>
        public const string VendorGroupStatistics = "~/Areas/AP/Views/VendorGroup/Partials/_Statistics.cshtml";

        /// <summary>
        /// Tax Group Grid
        /// </summary>
        public const string TaxGroupGrid = "~/Areas/AP/Views/VendorGroup/Partials/_TaxGroupGrid.cshtml";

        #endregion

        /// <summary>
        /// The Age Cash Requirement Reports localization
        /// </summary>
        public const string AgedCashRequirementLocalization = "~/Areas/AP/Views/AgedCashRequirement/Partials/_Localization.cshtml";

        /// <summary>
        /// The Age Cash Requirement localization
        /// </summary>
        public const string AgedCashRequirementSelectVendorsBy = "~/Areas/AP/Views/AgedCashRequirement/Partials/SelectVendorsBy.cshtml";

        /// <summary>
        /// The Age Cash Requirement Reports SortVendorsBy
        /// </summary>
        public const string AgedCashRequirementSortVendorsBy = "~/Areas/AP/Views/AgedCashRequirement/Partials/_SortVendorsBy.cshtml";

        /// <summary>
        /// The Age Payable Reports localization
        /// </summary>
        public const string AgedCashLocalization = "~/Areas/AP/Views/AgedCashRequirement/Partials/_Localization.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string DistributionSet = "~/Areas/AP/Views/DistributionSet/Partials/_DistributionSet.cshtml";

        /// <summary>
        /// The Bank Distribution Code localization
        /// </summary>
        public const string DistributionSetLocalization = "~/Areas/AP/Views/DistributionSet/Partials/_Localization.cshtml";

        /// <summary>
        /// The Bank Distribution Code localization
        /// </summary>
        public const string DistributionSetDetails =
            "~/Areas/AP/Views/DistributionSet/Partials/_DistributionSetDetails.cshtml";


        #region AP Age Retainage
        /// <summary>
        /// AP Age Retainage
        /// </summary>
        public const string AgedRetainage = "~/Areas/AP/Views/AgedRetainage/Partials/_AgedRetainage.cshtml";
        /// <summary>
        /// AP Age Retainage Localization
        /// </summary>
        public const string AgedRetainageLocalization = "~/Areas/AP/Views/AgedRetainage/Partials/_Localization.cshtml";

        #endregion

        #region Vendor

        /// <summary>
        /// Vendor partial view.
        /// </summary>
        public const string Vendor = "~/Areas/AP/Views/Vendor/Partials/_Vendor.cshtml";

        /// <summary>
        /// Vendor Localization
        /// </summary>
        public const string VendorLocalization = "~/Areas/AP/Views/Vendor/Partials/_Localization.cshtml";

        /// <summary>
        /// Vendor Address tab
        /// </summary>
        public const string VendorAddress = "~/Areas/AP/Views/Vendor/Partials/_Address.cshtml";

        /// <summary>
        /// Vendor Contact Tab
        /// </summary>
        public const string VendorContact = "~/Areas/AP/Views/Vendor/Partials/_Contact.cshtml";

        /// <summary>
        /// Vendor Processing Tab
        /// </summary>
        public const string VendorProcessing = "~/Areas/AP/Views/Vendor/Partials/_Processing.cshtml";

        /// <summary>
        /// Vendor Processing Tab
        /// </summary>
        public const string VendorInvoicing = "~/Areas/AP/Views/Vendor/Partials/_Invoicing.cshtml";

        /// <summary>
        /// Vendor Statistics Tab
        /// </summary>
        public const string VendorStatistics = "~/Areas/AP/Views/Vendor/Partials/_Statistics.cshtml";

        /// <summary>
        /// Vendor Activity Tab
        /// </summary>
        public const string VendorActivity = "~/Areas/AP/Views/Vendor/Partials/_Activity.cshtml";

        /// <summary>
        /// Vendor Optional Fields Tab
        /// </summary>
        public const string VendorOptionalFields = "~/Areas/AP/Views/Vendor/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// Vendor Comment Tab
        /// </summary>
        public const string VendorComment = "~/Areas/AP/Views/Vendor/Partials/_Comment.cshtml";

        #endregion

        #region InvoiceEntry

        /// <summary>
        /// Invoice Entry Document 
        /// </summary>
        public const string InvoiceEntryDocument = "~/Areas/AP/Views/InvoiceEntry/Partials/_Document.cshtml";

        /// <summary>
        /// Invoice Entry Taxes 
        /// </summary>
        public const string InvoiceEntryDetail = "~/Areas/AP/Views/InvoiceEntry/Partials/_InvoiceDetail.cshtml";

        /// <summary>
        /// Invoice Entry Taxes 
        /// </summary>
        public const string InvoiceEntryTaxes = "~/Areas/AP/Views/InvoiceEntry/Partials/_Taxes.cshtml";

        /// <summary>
        /// Invoice Entry Taxes Grid
        /// </summary>
        public const string InvoiceEntryTaxesGrid = "~/Areas/AP/Views/InvoiceEntry/Partials/_TaxesGrid.cshtml";

        /// <summary>
        /// Invoice Entry Taxes Grid
        /// </summary>
        public const string InvoiceDetailTaxesGrid = "~/Areas/AP/Views/InvoiceEntry/Partials/_DetailTaxes.cshtml";

        /// <summary>
        /// Invoice Entry Taxes Grid
        /// </summary>
        public const string InvoiceEntryTaxesReportingCurrencyGrid = "~/Areas/AP/Views/InvoiceEntry/Partials/_TaxesReporingCurrency.cshtml";

        /// <summary>
        /// Invoice Entry Retainage 
        /// </summary>
        public const string InvoiceEntryRetainage = "~/Areas/AP/Views/InvoiceEntry/Partials/_Retainage.cshtml";

        /// <summary>
        /// Invoice Entry Terms 
        /// </summary>
        public const string InvoiceEntryTerms = "~/Areas/AP/Views/InvoiceEntry/Partials/_Terms.cshtml";

        /// <summary>
        /// Invoice Entry Taxes Grid
        /// </summary>
        public const string InvoiceEntryTermsGrid = "~/Areas/AP/Views/InvoiceEntry/Partials/_TermsGrid.cshtml";

        /// <summary>
        /// Invoice Entry OptionalField 
        /// </summary>
        public const string InvoiceEntryOptionalField = "~/Areas/AP/Views/InvoiceEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// Invoice Entry Rates 
        /// </summary>
        public const string InvoiceEntryRates = "~/Areas/AP/Views/InvoiceEntry/Partials/_Rates.cshtml";

        /// <summary>
        /// Invoice Entry Totals
        /// </summary>
        public const string InvoiceEntryTotals = "~/Areas/AP/Views/InvoiceEntry/Partials/_Totals.cshtml";

        /// <summary>
        /// The Invoice Entry
        /// </summary>
        public const string InvoiceEntry = "~/Areas/AP/Views/InvoiceEntry/Partials/_InvoiceEntry.cshtml";

        /// <summary>
        /// Invoice Entry Detail Optional Field 
        /// </summary>
        public const string DetailOptionalField = "~/Areas/AP/Views/InvoiceEntry/Partials/_DetailOptionalField.cshtml";

        /// <summary>
        /// The Invoice Entry localization
        /// </summary>
        public const string InvoiceEntryLocalization = "~/Areas/AP/Views/InvoiceEntry/Partials/_Localization.cshtml";
        /// <summary>
        /// The Invoice Entry BatchDetails
        /// </summary>
        public const string InvoiceEntryBatchDetails = "~/Areas/AP/Views/InvoiceEntry/Partials/_BatchDetails.cshtml";
        /// <summary>
        /// The Invoice Entry VendorDetails
        /// </summary>
        public const string InvoiceEntryVendorDetails = "~/Areas/AP/Views/InvoiceEntry/Partials/_VendorDetails.cshtml";

        /// <summary>
        /// The Invoice Entry RemitToLocation
        /// </summary>
        public const string InvoiceEntryRemitToDetails = "~/Areas/AP/Views/InvoiceEntry/Partials/_RemitToDetails.cshtml";

        /// <summary>
        /// The Invoice Entry Prepayment
        /// </summary>
        public const string InvoiceEntryPrepayment = "~/Areas/AP/Views/InvoiceEntry/Partials/_Prepayment.cshtml";

        /// <summary>
        /// The Invoice Entry Prepayment Details
        /// </summary>
        public const string InvoiceEntryPrepaymentDetails = "~/Areas/AP/Views/InvoiceEntry/Partials/_PrepaymentBatchDetails.cshtml";

        /// <summary>
        /// The Invoice Entry Prepayment optional fields
        /// </summary>
        public const string InvoiceEntryPrepaymentOptionalField = "~/Areas/AP/Views/InvoiceEntry/Partials/_PrepaymentOptionalField.cshtml";

        /// <summary>
        /// Invoice Entry Prepayment Batch Info
        /// </summary>
        public const string InvoiceEntryPrepaymentBatchInfo = "~/Areas/AP/Views/InvoiceEntry/Partials/_PrepaymentBatchInfo.cshtml";

        /// <summary>
        /// Invoice Entry Prepayment Rates
        /// </summary>
        public const string InvoiceEntryPrepaymentRates = "~/Areas/AP/Views/InvoiceEntry/Partials/_RateOverride.cshtml";

        /// <summary>
        /// Invoice Entry Prepayment Rates
        /// </summary>
        public const string InvoiceEntryPrepaymentRemitToLoc = "~/Areas/AP/Views/InvoiceEntry/Partials/_PrepaymentRemitToLocation.cshtml";

        #endregion

        #region Payment Inquiry

        /// <summary>
        /// Payment Inquiry Main page screen
        /// </summary>
        public const string PaymentInquiry =
            "~/Areas/AP/Views/PaymentInquiry/Partials/_PaymentInquiry.cshtml";

        /// <summary>
        /// Payment Inquiry grid to display Posted Payments
        /// </summary>
        public const string PaymentInquiryGrid =
            "~/Areas/AP/Views/PaymentInquiry/Partials/_PostedPaymentsGrid.cshtml";

        /// <summary>
        /// Payment Inquiry Localization
        /// </summary>
        public const string PaymentInquiryLocalization =
            "~/Areas/AP/Views/PaymentInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Payment Information

        /// <summary>
        /// Payment Transaction Columns
        /// </summary>
        public const string PaymentTransactionsColumns =
            "~/Areas/AP/Views/PaymentInformation/_PaymentTransactionsColumns.cshtml";

        /// <summary>
        /// Payment Inquiry form details
        /// </summary>
        public const string PaymentInformationForm =
            "~/Areas/AP/Views/PaymentInformation/_PaymentInformation.cshtml";

        /// <summary>
        /// Payment Inquiry details grid
        /// </summary>
        public const string PaymentInformationTransactionDetailsGrid =
            "~/Areas/AP/Views/PaymentInformation/_PaymentInformationGrid.cshtml";

        /// <summary>
        /// Payment Inquiry details grid
        /// </summary>
        public const string PaymentInformationPaymentDetailsGrid =
            "~/Areas/AP/Views/PaymentInformation/_PaymentInformationGrid.cshtml";

        #endregion

        #region Vendor Activity

        /// <summary>
        /// Vendor Activity main form
        /// </summary>
        public const string VendorActivityForm =
            "~/Areas/AP/Views/VendorActivity/Partials/_VendorActivity.cshtml";

        /// <summary>
        /// Vendor Activity - Activity Tab
        /// </summary>
        public const string VendorActivityTab =
            "~/Areas/AP/Views/VendorActivity/Partials/_Activity.cshtml";

        /// <summary>
        /// Vendor Activity - Aging Tab
        /// </summary>
        public const string VendorActivityAging =
            "~/Areas/AP/Views/VendorActivity/Partials/_Aging.cshtml";

        /// <summary>
        /// Vendor Activity - Localization
        /// </summary>
        public const string VendorActivityLocalization =
            "~/Areas/AP/Views/VendorActivity/Partials/_Localization.cshtml";

        /// <summary>
        /// Vendor Activity - Payments Tab
        /// </summary>
        public const string VendorActivityPayments =
            "~/Areas/AP/Views/VendorActivity/Partials/_Payments.cshtml";

        /// <summary>
        /// Vendor Activity - Transactions Tab
        /// </summary>
        public const string VendorActivityTransactions =
            "~/Areas/AP/Views/VendorActivity/Partials/_Transactions.cshtml";

        /// <summary>
        /// Vendor Activity - Transaction details grid
        /// </summary>
        public const string TransactionDetailsGrid =
            "~/Areas/AP/Views/VendorActivity/Partials/_TransactionDetailsGrid.cshtml";

        /// <summary>
        /// Vendor Activity - Transaction details grid
        /// </summary>
        public const string PaymentDetailsGrid =
            "~/Areas/AP/Views/VendorActivity/Partials/_PaymentDetailsGrid.cshtml";

        /// <summary>
        /// Vendor Activity - Optional Fields grid
        /// </summary>
        public const string VendorActivityOptionalFieldGrid =
            "~/Areas/AP/Views/VendorActivity/Partials/_OptionalFields.cshtml";

        #endregion

        #region Document Information

        /// <summary>
        /// Document Information - Form
        /// </summary>
        public const string DocumentInformationDetails =
            "~/Areas/AP/Views/DocumentInformation/_DocumentInformation.cshtml";

        /// <summary>
        /// Document Information - Columns used by a grid
        /// </summary>
        public const string DocumentInformationColumns =
            "~/Areas/AP/Views/DocumentInformation/_DocumentPaymentColumns.cshtml";

        /// <summary>
        /// Document Information - Grid used in the form
        /// </summary>
        public const string DocumentInformationGrid =
            "~/Areas/AP/Views/DocumentInformation/_DocumentPaymentsGrid.cshtml";

        #endregion

        #region Document Details

        /// <summary>
        /// Document Details - Form
        /// </summary>
        public const string DocumentDetailsForm =
            "~/Areas/AP/Views/DocumentDetails/_DocumentDetails.cshtml";

        /// <summary>
        /// Document Details - Columns used by a grid
        /// </summary>
        public const string DocumentDetailsColumns =
            "~/Areas/AP/Views/DocumentDetails/_DocumentDetailsColumns.cshtml";

        /// <summary>
        /// Document Details - Grid used in the form
        /// </summary>
        public const string DocumentDetailsGrid =
            "~/Areas/AP/Views/DocumentDetails/_DocumentDetailsGrid.cshtml";

        #endregion

        #region createPaymentBatch
        /// <summary>
        /// The select Tab Partial View
        /// </summary>
        public const string SelectTab = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_Select.cshtml";

        /// <summary>
        /// The select Tab Partial View
        /// </summary>
        public const string CriteriaTab = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_Criteria.cshtml";

        /// <summary>
        /// The Exclusion Tab Partial View
        /// </summary>
        public const string ExclusionTab = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_Exclusion.cshtml";

        /// <summary>
        ///The Rates Tab Partial View
        /// </summary>
        public const string RatesTab = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_Rates.cshtml";

        /// <summary>
        /// The OptionalFields Tab Partial View
        /// </summary>
        public const string OptionalFieldsTab = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_OptionalFields.cshtml";
        /// <summary>
        /// The CreatePaymentBatch list localization
        /// </summary>
        public const string CreatePaymentBatchLocalization = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_Localization.cshtml";

        /// <summary>
        /// The Create Payment Batch Partial View
        /// </summary>
        public const string CreatePaymentBatch = "~/Areas/AP/Views/CreatePaymentBatch/Partials/_CreatePaymentBatch.cshtml";

        #endregion

        #region Payment Selection Code
        /// <summary>
        /// The Payment Selection Code Partial View
        /// </summary>
        public const string PaymentSelectionCodePartial = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_PaymentSelectionCode.cshtml";

        /// <summary>
        /// The select Tab Partial View
        /// </summary>
        public const string PaymentSelectionSelectTab = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_Select.cshtml";

        /// <summary>
        /// The select Tab Partial View
        /// </summary>
        public const string PaymentSelectionCriteriaTab = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_Criteria.cshtml";

        /// <summary>
        /// The Exclusion Tab Partial View
        /// </summary>
        public const string PaymentSelectionExclusionTab = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_Exclusion.cshtml";

        /// <summary>
        /// The OptionalFields Tab Partial View
        /// </summary>
        public const string PaymentSelectionOptionalFieldsTab = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// The CreatePaymentBatch list localization
        /// </summary>
        public const string PaymentSelectionCodeLocalization = "~/Areas/AP/Views/PaymentSelectionCode/Partials/_Localization.cshtml";
        #endregion

        #region GLTransaction
        ///<summary>
        /// The GLTransaction Partial View
        /// </summary>
        public const string GLTransaction = "~/Areas/AP/Views/GLTransaction/Partials/_GLTransaction.cshtml";
        /// <summary>
        /// The GLTransaction localization
        /// </summary>
        public const string GLTransactionLocalization = "~/Areas/AP/Views/GLTransaction/Partials/_Localization.cshtml";
        #endregion GLTransaction

        #region GL Integration

        ///<summary>
        /// The GLIntegration Partial View
        /// </summary>
        public const string GLIntegration = "~/Areas/AP/Views/GLIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The GLIntegration localization
        /// </summary>
        public const string GLIntegrationLocalization = "~/Areas/AP/Views/GLIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The GLIntegration Options
        /// </summary>
        public const string GLIntegrationOptions = "~/Areas/AP/Views/GLIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The GLIntegration Transactions
        /// </summary>
        public const string GLIntegrationTransactions = "~/Areas/AP/Views/GLIntegration/Partials/_Transactions.cshtml";

        #region GL Reference Integration
        ///<summary>
        /// The GLIntegration Partial View
        /// </summary>
        public const string GLReferenceIntegration = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The GLIntegration localization
        /// </summary>
        public const string GLReferenceIntegrationLocalization = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The GLIntegration Options
        /// </summary>
        public const string GLReferenceIntegrationOptions = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The GLIntegration Transactions
        /// </summary>
        public const string GLReferenceIntegrationTransactions = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_Transactions.cshtml";

        /// <summary>
        /// The GLIntegration Transactions
        /// </summary>
        public const string GLIntegrationSourceCode = "~/Areas/AP/Views/GLIntegration/Partials/_GLSourceCodes.cshtml";
        /// <summary>
        /// The GLIntegration Detail
        /// </summary>
        public const string GLReferenceIntegrationDetail = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_Detail.cshtml";

        /// <summary>
        /// The GLIntegration Detail
        /// </summary>
        public const string GLReferenceIntegrationGrid = "~/Areas/AP/Views/GLReferenceIntegration/Partials/_GLReferenceIntegrationGrid.cshtml";

        #endregion

        #endregion

        #region Integrity Checker

        /// <summary>
        /// The Data Integrity Partial View for Application Option
        /// </summary>
        public const string IntegrityCheck = "~/Areas/AP/Views/IntegrityChecker/Partials/_IntegrityChecker.cshtml";

        #endregion

        #region A/P terms

        /// <summary>
        /// Terms code partial view
        /// </summary>
        public const string TermCodePartial = "~/Areas/AP/Views/TermCode/Partials/_TermCode.cshtml";

        /// <summary>
        /// The Term code localization
        /// </summary>
        public const string TermCodeLocalization = "~/Areas/AP/Views/TermCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The TermListGrid
        /// </summary>
        public const string TermListGrid = "~/Areas/AP/Views/TermCode/Partials/_TermCodeGrid.cshtml";
        #endregion

        #region Control Payment

        /// <summary>
        /// The control payment bundle.
        /// </summary>
        public const string ControlPaymentBundle = "~/bundles/ControlPayment";

        /// <summary>
        /// The control payments partial view.
        /// </summary>
        public const string ControlPayment = "~/Areas/AP/Views/ControlPayment/Partials/_ControlPayment.cshtml";

        /// <summary>
        /// The control payments localization.
        /// </summary>
        public const string ControlPaymentLocalization = "~/Areas/AP/Views/ControlPayment/Partials/_Localization.cshtml";

        /// <summary>
        /// The control payments single document partial view.
        /// </summary>
        public const string ControlPaymentSingleDocument = "~/Areas/AP/Views/ControlPayment/Partials/_SingleDocument.cshtml";

        /// <summary>
        /// The control payments range of documents partial view.
        /// </summary>
        public const string ControlPaymentRangeOfDocuments = "~/Areas/AP/Views/ControlPayment/Partials/_RangeOfDocument.cshtml";

        #endregion

        #region Payment Entry

        /// <summary>
        /// Payment Entry partial view
        /// </summary>
        public const string PaymentEntryPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_PaymentEntry.cshtml";

        /// <summary>
        /// PaymentEntryDocumentTaxPartial partial view
        /// </summary>
        public const string PaymentEntryDocumentTaxPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DocumentTax.cshtml";

        /// <summary>
        /// DocumnentTaxGridPartial partial view
        /// </summary>
        public const string DocumentTaxGridPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DocumentTaxGrid.cshtml";
        /// <summary>
        /// TaxReportCurrencyPartial partial view
        /// </summary>
        public const string TaxReportCurrencyPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_TaxesReporingCurrency.cshtml";

        /// <summary>
        /// Payment Entry localization
        /// </summary>
        public const string PaymentEntryLocalization = "~/Areas/AP/Views/PaymentEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Payment Entry Batch partial view
        /// </summary>
        public const string PaymentEntryBatchPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_Batch.cshtml";

        /// <summary>
        /// Payment Entry Vendor partial view
        /// </summary>
        public const string PaymentEntryVendorPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_Vendor.cshtml";

        /// <summary>
        /// Rate Override partial view
        /// </summary>
        public const string RateOverridePartial = "~/Areas/AP/Views/PaymentEntry/Partials/_RateOverride.cshtml";

        /// <summary>
        /// Payment Entry Document History partial view
        /// </summary>
        public const string DocumentHistoryPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DocumentHistory.cshtml";

        /// <summary>
        /// Payment Entry Document History Grid partial view
        /// </summary>
        public const string DocumentHistoryGridPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DocumentHistoryGrid.cshtml";

        /// <summary>
        /// Payment Entry optioanl field partial view
        /// </summary>
        public const string PaymentEntryOptionalFieldPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// Payment Entry Remit to location partial view
        /// </summary>
        public const string PaymentEntryRemitToLocPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_RemitToLocation.cshtml";

        /// <summary>
        /// Payment Entry Remit to location partial view
        /// </summary>
        public const string PaymentEntryAdvanceCreditPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_AdvanceCredit.cshtml";

        /// <summary>
        /// Payment Entry Remit to location partial view
        /// </summary>
        public const string PaymentEntryAdvanceCreditGridPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_AdvanceCreditGrid.cshtml";

        /// <summary>
        /// Payment Entry Applied Payment partial view
        /// </summary>
        public const string PaymentEntryAppliedPaymentPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_AppliedPaymentGrid.cshtml";

        /// <summary>
        /// Payment Entry Document grid partial view
        /// </summary>
        public const string PaymentEntryDocumentPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DocumentGrid.cshtml";

        /// <summary>
        /// Payment Entry Misc. Payment partial view
        /// </summary>
        public const string PaymentEntryMiscPaymentPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_MiscellaneousPaymentGrid.cshtml";

        /// <summary>
        /// Payment Entry Misc. Adjustment entry partial view
        /// </summary>
        public const string PaymentEntryMiscAdjustmentPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_MiscellaneousAdj.cshtml";

        /// <summary>
        /// Payment Entry Misc. Adjustment entry grid partial view
        /// </summary>
        public const string PaymentEntryMiscAdjustmentGridPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_MiscellaneousAdjGrid.cshtml";

        /// <summary>
        /// Payment Entry OrderBy partial view
        /// </summary>
        public const string PaymentEntryOrderByPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_OrderBy.cshtml";

        /// <summary>
        /// DetailAcctTaxGridPartial partial view
        /// </summary>
        public const string DetailAcctTaxGridPartial = "~/Areas/AP/Views/PaymentEntry/Partials/_DetailAccountTaxGrid.cshtml";

        #endregion

        #region AP Batch Status Report

        /// <summary>
        /// AR Batch Listing Report
        /// </summary>
        public const string APBatchStatus = "~/Areas/AP/Views/BatchStatusReport/Partials/_BatchStatusReport.cshtml";

        /// <summary>
        /// AR Batch Listing Report Localization
        /// </summary>
        public const string APBatchStatusLocalization = "~/Areas/AP/Views/BatchStatusReport/Partials/_Localization.cshtml";

        #endregion

        #region CPRS Amount
        /// <summary>
        /// The CPRS Amount Localization
        /// </summary>
        public const string CPRSAmountLocalization = "~/Areas/AP/Views/CprsAmount/Partials/_Localization.cshtml";
        /// <summary>
        /// The CPRS Amount Partial View
        /// </summary>
        public const string CPRSAmountPartial = "~/Areas/AP/Views/CprsAmount/Partials/_CPRSAmount.cshtml";

        #endregion

        #region AP OptionalFields

        /// <summary>
        /// The OptionalField
        /// </summary>
        public const string OptionalField = "~/Areas/AP/Views/OptionalField/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The OptionalField localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/AP/Views/OptionalField/Partials/_Localization.cshtml";

        /// <summary>
        /// The OptionalField grid
        /// </summary>
        public const string OptionalFieldGrid = "~/Areas/AP/Views/OptionalField/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The OptionalField Settings
        /// </summary>
        public const string OptionalFieldSettings = "~/Areas/AP/Views/OptionalField/Partials/_OptionalFieldSettings.cshtml";

        /// <summary>
        /// Session Key for Item Segments
        /// </summary>
        public const string SessionOptionalField = "apOptionalFieldCache";

        #endregion

        #region CPRS ElectronicFiling
        /// <summary>
        /// The CPRS ElectronicFiling Localization
        /// </summary>
        public const string CPRSElectronicFilingLocalization = "~/Areas/AP/Views/CPRSElectronicFiling/Partials/_Localization.cshtml";
        /// <summary>
        /// The CPRS ElectronicFiling Partial View
        /// </summary>
        public const string CPRSElectronicFilingPartial = "~/Areas/AP/Views/CPRSElectronicFiling/Partials/_CPRSElectronicFiling.cshtml";

        #endregion

        #region AP Posting Errors

        /// <summary>
        /// Posting Error Localization
        /// </summary>
        public const string PostingErrorLocalization = "~/Areas/AP/Views/PostingError/Partials/_Localization.cshtml";

        /// <summary>
        /// Posting Error
        /// </summary>
        public const string PostingError = "~/Areas/AP/Views/PostingError/Partials/_PostingError.cshtml";

        #endregion

        #region 1099 ElectronicFiling
        /// <summary>
        /// The 1099 ElectronicFiling Localization
        /// </summary>
        public const string ElectroinFilingLocalization = "~/Areas/AP/Views/ElectronicFilingReport/Partials/_Localization.cshtml";
        /// <summary>
        /// The 1099 ElectronicFiling Partial View
        /// </summary>
        public const string ElectroinFilingPartial = "~/Areas/AP/Views/ElectronicFilingReport/Partials/_ElectronicFiling.cshtml";

        #endregion

        #region AP Batch Listing Report

        /// <summary>
        /// AR Batch Listing Report
        /// </summary>
        public const string APBatchListing = "~/Areas/AP/Views/BatchListing/Partials/_BatchListing.cshtml";

        /// <summary>
        /// AR Batch Listing Report Localization
        /// </summary>
        public const string APBatchListingLocalization = "~/Areas/AP/Views/BatchListing/Partials/_Localization.cshtml";

        #endregion

        #region CPRS Inquiry
        /// <summary>
        /// The CPRS Inquiry Localization
        /// </summary>
        public const string CPRSInquiryLocalization = "~/Areas/AP/Views/CPRSInquiry/Partials/_Localization.cshtml";
        /// <summary>
        /// The CPRS Amount Partial View
        /// </summary>
        public const string CPRSInquiryPartial = "~/Areas/AP/Views/CPRSInquiry/Partials/_CPRSInquiry.cshtml";

        #endregion

        #region Vendor Transaction

        /// <summary>
        /// Vendor Transaction
        /// </summary>
        public const string VendorTransaction = "~/Areas/AP/Views/VendorTransaction/Partials/_VendorTransaction.cshtml";

        /// <summary>
        /// Vendor Transaction Localization
        /// </summary>
        public const string VendorTransactionLocalization = "~/Areas/AP/Views/VendorTransaction/Partials/_Localization.cshtml";

        #endregion

        #region Posting Journal Report

        /// <summary>
        /// PostingJournal Report
        /// </summary>
        public const string PostingJournal = "~/Areas/AP/Views/PostingJournal/Partials/_PostingJournal.cshtml";

        /// <summary>
        /// The posting journal localization
        /// </summary>
        public const string PostingJournalLocalization = "~/Areas/AP/Views/PostingJournal/Partials/_Localization.cshtml";

        #endregion

        #region Delete Inactive Record

        /// <summary>
        /// Delete Inactive Record
        /// </summary>
        public const string APDeleteInactiveRecord = "~/Areas/AP/Views/DeleteInactiveRecord/Partials/_DeleteInactiveRecord.cshtml";

        /// <summary>
        /// Delete Inactive Record Localization
        /// </summary>
        public const string DeleteInactiveRecordLocalization = "~/Areas/AP/Views/DeleteInactiveRecord/Partials/_Localization.cshtml";

        #endregion

        #region Remit-To Location

        /// <summary>
        /// Remit-To Location  RemitToLocationGrid
        /// </summary>
        public const string RemitToLocation = "~/Areas/AP/Views/RemitToLocation/Partials/_RemitToLocation.cshtml";

        /// <summary>
        /// Remit-To Location Localization
        /// </summary>
        public const string RemitToLocationLocalization = "~/Areas/AP/Views/RemitToLocation/Partials/_Localization.cshtml";

        /// <summary>
        /// Remit-To Location Grid
        /// </summary>
        public const string RemitToLocationGrid = "~/Areas/AP/Views/RemitToLocation/Partials/_RemitToLocationGrid.cshtml";

        /// <summary>
        /// Remit-To Location Detail
        /// </summary>
        public const string RemitToLocationDetail = "~/Areas/AP/Views/RemitToLocationDetail/Partials/_RemitToLocationDetail.cshtml";

        /// <summary>
        /// Remit-To Location Detail Localization
        /// </summary>
        public const string RemitToLocationDetailLocalization = "~/Areas/AP/Views/RemitToLocationDetail/Partials/_Localization.cshtml";

        /// <summary>
        /// Remit-To Location Detail Address Tab 
        /// </summary>
        public const string AddressTab = "~/Areas/AP/Views/RemitToLocationDetail/Partials/_Address.cshtml";

        /// <summary>
        /// Remit-To Location Detail Contact Tab
        /// </summary>
        public const string ContactTab = "~/Areas/AP/Views/RemitToLocationDetail/Partials/_Contact.cshtml";

        /// <summary>
        /// Remit-To Location Detail Optional Field Tab
        /// </summary>
        public const string OptionalFieldTab = "~/Areas/AP/Views/RemitToLocationDetail/Partials/_OptionalField.cshtml";

        public const string ApSessionRemitToLocation = "apsessionremittolocation";

        #endregion

        #region Revaluation

        public const string Revaluation = "~/Areas/Shared/Views/Revaluation/_Index.cshtml";

        public const string RevaluationHistory = "~/Areas/Shared/Views/RevaluationHistory/_Index.cshtml";

        #endregion

        #region Create Retainage Document Batch

        /// <summary>
        /// Create Retainage Document Batch Localization
        /// </summary>
        public const string CreateRetainageDocumentBatchLocalization = "~/Areas/AP/Views/CreateRetainageDocumentBatch/Partials/_Localization.cshtml";

        /// <summary>
        /// Create Retainage Document Batch Partial View
        /// </summary>
        public const string CreateRetainageDocumentBatch = "~/Areas/AP/Views/CreateRetainageDocumentBatch/Partials/_CreateRetainageDocumentBatch.cshtml";

        #endregion

        #region Reciept Inquiry
        /// <summary>
        /// Payment Inquiry grid to display Posted Payments
        /// </summary>
        public const string ReceiptInquiryGrid =
            "~/Areas/AP/Views/ReceiptInquiry/Partials/_PostedPaymentsGrid.cshtml";
        #endregion

        #region Adjustment Entry

        /// <summary>
        /// Adjustment Entry Partial
        /// </summary>
        public const string AdjustmentEntry = "~/Areas/AP/Views/AdjustmentEntry/Partials/_AdjustmentEntry.cshtml";

        /// <summary>
        /// Adjustment Entry Localization Partial
        /// </summary>
        public const string AdjustmentEntryLocalization = "~/Areas/AP/Views/AdjustmentEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Adjustment Entry Document Tab Partial
        /// </summary>
        public const string AdjustmentEntryDocument = "~/Areas/AP/Views/AdjustmentEntry/Partials/_Document.cshtml";

        /// <summary>
        /// Adjustment Entry Retainage Tab Partial
        /// </summary>
        public const string AdjustmentEntryRetainage = "~/Areas/AP/Views/AdjustmentEntry/Partials/_Retainage.cshtml";

        /// <summary>
        /// Adjustment Entry OptionalField Tab Partial
        /// </summary>
        public const string AdjustmentEntryOptionalField = "~/Areas/AP/Views/AdjustmentEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// Adjustment Entry Rates Tab Partial
        /// </summary>
        public const string AdjustmentEntryRates = "~/Areas/AP/Views/AdjustmentEntry/Partials/_Rates.cshtml";

        /// <summary>
        /// Adjustment Entry BatchInformation Tab Partial
        /// </summary>
        public const string AdjustmentEntryBatchInfoPartial = "~/Areas/AP/Views/AdjustmentEntry/Partials/_BatchInformation.cshtml";

        /// <summary>
        /// Adjustment Entry BatchInformation Tab Partial
        /// </summary>
        public const string AdjustmentGLDistributionGrid = "~/Areas/AP/Views/AdjustmentEntry/Partials/_AdjustmentDetail.cshtml";

        #endregion

        #region Clear History

        /// <summary>
        /// Clear History
        /// </summary>
        public const string ClearHistory = "~/Areas/AP/Views/ClearHistory/Partials/_ClearHistory.cshtml";

        /// <summary>
        /// Clear History Localization 
        /// </summary>
        public const string ClearHistoryLocalization = "~/Areas/AP/Views/ClearHistory/Partials/_Localization.cshtml";


        #endregion

        #region Clear Statistic

        /// <summary>
        /// Clear History
        /// </summary>
        public const string ClearStatistic = "~/Areas/AP/Views/ClearStatistic/Partials/_ClearStatistic.cshtml";

        /// <summary>
        /// Clear History Localization 
        /// </summary>
        public const string ClearStatisticLocalization = "~/Areas/AP/Views/ClearStatistic/Partials/_Localization.cshtml";


        #endregion

    }
}
