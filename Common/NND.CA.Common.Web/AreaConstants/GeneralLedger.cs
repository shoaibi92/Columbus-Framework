/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Costant for GL layout path
    /// </summary>
    public static class GeneralLedger
    {
        #region Session Variables Used By GL

        /// <summary>
        /// Session key for Allocation 
        /// </summary>
        public const string SessionAllocation = "glallocationCache";

        /// <summary>
        /// Session Key for Optional Field 
        /// </summary>
        public const string SessionOptionalField = "gloptionalFieldCache";

        /// <summary>
        /// Session Key for Transaction Optional field 
        /// </summary>
        public const string SessionTranOptionalField = "gltranOptionalFieldCache";

        /// <summary>
        /// Session Key for Account Currency 
        /// </summary>
        public const string SessionAccountCurrency = "glaccountCurrencyCache";

        /// <summary>
        /// 
        /// </summary>
        public const string SessionRollupPreview = "glrollupPreviewCache";

        /// <summary>
        /// Session Key for Rollup 
        /// </summary>
        public const string SessionRollup = "glrollupCache";

        /// <summary>
        /// Session Key for Subledger 
        /// </summary>
        public const string SessionSubledger = "glsubledgerCache";

        /// <summary>
        /// Session Key for Segment 
        /// </summary>
        public const string SessionSegment = "glsegmentCache";

        /// <summary>
        /// Session Key for Optional 
        /// </summary>
        public const string SessionOptional = "gloptionalCache";

        /// <summary>
        /// Session Key for Optional 
        /// </summary>
        public const string SessionAutoAllocationOptionalField = "glAutoAllocationOptionalFieldCache";

        #endregion
        /// <summary>
        /// The account group sort code
        /// </summary>
        public const string AccountGroupSortCode = "~/Areas/GL//Views/AccountGroup/_Partials/_ChangeSortCode.cshtml";

        /// <summary>
        /// The options account
        /// </summary>
        public const string OptionsAccount = "~/Areas/GL/Views/Options/Partials/_Account.cshtml";

        /// <summary>
        /// The options company
        /// </summary>
        public const string OptionsCompany = "~/Areas/GL/Views/Options/Partials/_Company.cshtml";

        /// <summary>
        /// The options localization
        /// </summary>
        public const string OptionsLocalization = "~/Areas/GL/Views/Options/Partials/_Localization.cshtml";

        /// <summary>
        /// The options posting
        /// </summary>
        public const string OptionsPosting = "~/Areas/GL/Views/Options/Partials/_Posting.cshtml";

        /// <summary>
        /// The options segments
        /// </summary>
        public const string OptionsSegments = "~/Areas/GL/Views/Options/Partials/_Segments.cshtml";

        /// <summary>
        /// The options segment grid
        /// </summary>
        public const string OptionsGrid = "~/Areas/GL/Views/Options/Partials/_OptionsSegmentGrid.cshtml";

        /// <summary>
        /// The recurring entry details
        /// </summary>
        public const string RecurringEntryDetails =
            "~/Areas/GL/Views/RecurringEntry/Partials/_RecurringEntryDetail.cshtml";

        /// <summary>
        /// The recurring entry localization
        /// </summary>
        public const string RecurringEntryLocalization =
            "~/Areas/GL/Views/RecurringEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// The recurring entry
        /// </summary>
        public const string RecurringEntry =
            "~/Areas/GL/Views/RecurringEntry/Partials/_RecurringEntry.cshtml";

        /// <summary>
        /// The create recurring entries batch localization
        /// </summary>
        public const string CreateRecurringEntriesBatchLocalization =
            "~/Areas/GL/Views/CreateRecurringEntriesBatch/Partials/_Localization.cshtml";

        /// <summary>
        /// The Segment Code
        /// </summary>
        public const string SegmentCode =
           "~/Areas/GL/Views/SegmentCode/Partial/_SegmentCode.cshtml";
        /// <summary>
        /// The segment code localization
        /// </summary>
        public const string SegmentCodeLocalization = "~/Areas/GL/Views/SegmentCode/Partial/_Localization.cshtml";

        /// <summary>
        /// Account Group Partial Page
        /// </summary>
        public const string AccountGroupPage = "~/Areas/GL/Views/AccountGroup/_Partials/_AccountGroup.cshtml";

        /// <summary>
        /// The source code Partial Page
        /// </summary>
        public const string SourceCode = "~/Areas/GL/Views/SourceCode/Partial/_SourceCode.cshtml";

        /// <summary>
        /// The source code localization
        /// </summary>
        public const string SourceCodeLocalization = "~/Areas/GL/Views/SourceCode/Partial/_Localization.cshtml";

        /// <summary>
        /// The account group localization
        /// </summary>
        public const string AccountGroupLocalization = "~/Areas/GL//Views/AccountGroup/_Partials/_Localization.cshtml";

        /// <summary>
        /// The account structure localization
        /// </summary>
        public const string AccountStructureLocalization =
            "~/Areas/GL//Views/AccountStructure/Partials/_Localization.cshtml";

        /// <summary>
        /// The optional field localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/GL/Views/OptionalFields/Partial/_Localization.cshtml";

        /// <summary>
        /// The journal details
        /// </summary>
        public const string JournalDetails = "~/Areas/GL/Views/JournalEntry/Partials/_JournalDetail.cshtml";

        /// <summary>
        /// The optionalfield details
        /// </summary>
        public const string OptionalFieldsDetails = "~/Areas/GL/Views/OptionalFields/Partial/_OptionalFieldsGrid.cshtml";

        /// <summary>
        /// The journal entry
        /// </summary>
        public const string JournalEntry = "~/Areas/GL/Views/JournalEntry/Partials/_JournalEntry.cshtml";

        /// <summary>
        /// The journal batch localization
        /// </summary>
        public const string JournalBatchLocalization = "~/Areas/GL/Views/JournalEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// The journal batch reverse
        /// </summary>
        public const string JournalBatchReverse = "~/Areas/GL/Views/JournalEntry/Partials/_JournalBatchReverse.cshtml";

        /// <summary>
        /// The account localization
        /// </summary>
        public const string AccountLocalization = "~/Areas/GL/Views/Account/Partials/_Localization.cshtml";

        /// <summary>
        /// The journal batch optional field
        /// </summary>
        public const string JournalBatchOptionalField =
            "~/Areas/GL/Views/JournalEntry/Partials/_JournalBatchOptionalField.cshtml";

        /// <summary>
        /// The account detail
        /// </summary>
        public const string AccountDetail = "~/Areas/GL/Views/Account/Partials/_AccountDetail.cshtml";

        /// <summary>
        /// The account optional field
        /// </summary>
        public const string AccountOptionalField = "~/Areas/GL/Views/Account/Partials/_AccountOptionalField.cshtml";

        /// <summary>
        /// The account trans optional field
        /// </summary>
        public const string AccountTransOptionalField =
            "~/Areas/GL/Views/Account/Partials/_AccountTransOptionalField.cshtml";

        /// <summary>
        /// The account currency
        /// </summary>
        public const string AccountCurrency = "~/Areas/GL/Views/Account/Partials/_AccountCurrency.cshtml";

        /// <summary>
        /// The account currency grid
        /// </summary>
        public const string AccountCurrencyGrid = "~/Areas/GL/Views/Account/Partials/_AccountCurrencyGrid.cshtml";

        /// <summary>
        /// The account subledger
        /// </summary>
        public const string AccountSubledger = "~/Areas/GL/Views/Account/Partials/_AccountSubledger.cshtml";

        /// <summary>
        /// The batch list localization
        /// </summary>
        public const string BatchListLocalization = "~/Areas/GL/Views/BatchList/Partial/_Localization.cshtml";

        /// <summary>
        /// The batch list Partial View
        /// </summary>
        public const string BatchList = "~/Areas/GL/Views/BatchList/Partial/_BatchList.cshtml";

        /// <summary>
        /// The transaction listing
        /// </summary>
        public const string TransactionListing = "~/Areas/GL/Views/TransactionListing/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The transaction listing sort by
        /// </summary>
        public const string TransactionListingSortBy = "~/Areas/GL/Views/TransactionListing/Partials/_SortBy.cshtml";

        /// <summary>
        /// The transaction listing print range
        /// </summary>
        public const string TransactionListingPrintRange =
            "~/Areas/GL/Views/TransactionListing/Partials/_PrintRange.cshtml";

        /// <summary>
        /// The transaction listing include
        /// </summary>
        public const string TransactionListingInclude = "~/Areas/GL/Views/TransactionListing/Partials/_Include.cshtml";

        /// <summary>
        /// The transaction listing account group
        /// </summary>
        public const string TransactionListingAccountGroup =
            "~/Areas/GL/Views/TransactionListing/Partials/_AccountGroup.cshtml";

        /// <summary>
        /// The transaction listing paper size
        /// </summary>
        public const string TransactionListingPaperSize =
            "~/Areas/GL/Views/TransactionListing/Partials/_PaperSize.cshtml";

        /// <summary>
        /// The transaction listing localization
        /// </summary>
        public const string TransactionListingLocalization =
            "~/Areas/GL/Views/TransactionListing/Partials/_Localization.cshtml";

        /// <summary>
        /// The transaction details optional field localization
        /// </summary>
        public const string TransactionDetailsOptionalFieldLocalization =
            "~/Areas/GL/Views/Reports/TransactionDetailsOptionalField/Partials/_Localization.cshtml";

        /// <summary>
        /// The reports
        /// </summary>
        public const string Reports = "~/Areas/Shared/Views/Report/Partials/_Localization.cshtml";

        /// <summary>
        /// The account allocation
        /// </summary>
        public const string AccountAllocation = "~/Areas/GL/Views/Account/Partials/_AccountAllocation.cshtml";

        /// <summary>
        /// The account allocation grid
        /// </summary>
        public const string AccountAllocationGrid = "~/Areas/GL/Views/Account/Partials/_AccountAllocationGrid.cshtml";

        /// <summary>
        /// The Segment Code
        /// </summary>
        public const string SegmentCodeGrid = "~/Areas/GL/Views/SegmentCode/Partial/_SegmentCodeGrid.cshtml";


        /// <summary>
        /// The sort by
        /// </summary>
        public const string SortBy = "~/Areas/GL/Views/Shared/ReportUserControl/SortBy.cshtml";

        /// <summary>
        /// The segment
        /// </summary>
        public const string Segment = "~/Areas/GL/Views/Shared/ReportUserControl/Segment.cshtml";

        /// <summary>
        /// The include
        /// </summary>
        public const string Include = "~/Areas/GL/Views/Shared/ReportUserControl/Include.cshtml";

        /// <summary>
        /// The currency
        /// </summary>
        public const string Currency = "~/Areas/GL/Views/Shared/ReportUserControl/Currency.cshtml";

        /// <summary>
        /// The Date
        /// </summary>
        public const string Date = "~/Areas/GL/Views/Shared/ReportUserControl/Date.cshtml";

        /// <summary>
        /// The account group
        /// </summary>
        public const string AccountGroup = "~/Areas/GL/Views/Shared/ReportUserControl/AccountGroup.cshtml";

        /// <summary>
        /// The optional field grid
        /// </summary>
        public const string OptionalFieldGrid = "~/Areas/GL/Views/Shared/ReportUserControl/OptionalFieldGrid.cshtml";

        /// <summary>
        /// The transaction optional field grid
        /// </summary>
        public const string TransactionOptionalFieldGrid =
            "~/Areas/GL/Views/Shared/ReportUserControl/TransactionOptionalFieldGrid.cshtml";

        /// <summary>
        /// The segment grid
        /// </summary>
        public const string SegmentGrid = "~/Areas/GL/Views/Shared/ReportUserControl/SegmentGrid.cshtml";

        /// <summary>
        /// The sort account group
        /// </summary>
        public const string SortAccountGroup = "~/Areas/GL/Views/Shared/ReportUserControl/SortAccountGroup.cshtml";

        /// <summary>
        /// The paper size
        /// </summary>
        public const string PaperSize = "~/Areas/GL/Views/Shared/ReportUserControl/PaperSize.cshtml";

        /// <summary>
        /// The batch ListView
        /// </summary>
        public const string BatchListView = "~/Areas/GL/Views/BatchList/Index.cshtml";

        /// <summary>
        /// The roll up
        /// </summary>
        public const string RollUp = "~/Areas/GL/Views/Account/Partials/_AccountRollUp.cshtml";

        #region Posting Journal Report

        /// <summary>
        /// PostingJournal Report
        /// </summary>
        public const string PostingJournal = "~/Areas/GL/Views/PostingJournal/Partials/_PostingJournal.cshtml";

        /// <summary>
        /// The posting journal localization
        /// </summary>
        public const string PostingJournalLocalization = "~/Areas/GL/Views/PostingJournal/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// The report localization
        /// </summary>
        public const string ReportLocalization = "~/Areas/GL/Views/Shared/Partials/ReportLocalization.cshtml";

        /// <summary>
        /// The batch listing
        /// </summary>
        public const string BatchListing = "~/Areas/GL/Views/BatchListing/Partials/_BatchListing.cshtml";

        /// <summary>
        /// The batch status
        /// </summary>
        public const string BatchStatusReport = "~/Areas/GL/Views/BatchStatusReport/Partials/_BatchStatusReport.cshtml";

        /// <summary>
        /// The recurring entry report
        /// </summary>
        public const string RecurringEntryReport =
            "~/Areas/GL/Views/RecurringEntryReport/Partials/_RecurringEntryReport.cshtml";

        /// <summary>
        /// The Segment Code report
        /// </summary>
        public const string SegmentCodeReport = "~/Areas/GL/Views/SegmentCodeReport/Partials/_SegmentCodeReport.cshtml";

        /// <summary>
        /// The Account Structure
        /// </summary>
        public const string AccountStructure =
            "~/Areas/GL/Views/AccountStructure/Partials/_AccountStructure.cshtml";

        /// <summary>
        /// The rollup selector
        /// </summary>
        public const string RollupSelector = "~/Areas/GL/Views/Account/Partials/_accountRollupSelector.cshtml";

        /// <summary>
        /// The rollup selector preview
        /// </summary>
        public const string RollupSelectorPreview =
            "~/Areas/GL/Views/Account/Partials/_AccountRollupSelectorPreview.cshtml";

        /// <summary>
        /// The post journal localization
        /// </summary>
        public const string PostJournalLocalization = "~/Areas/GL/Views/PostJournal/Partials/_Localization.cshtml";

        /// <summary>
        /// Post Journal
        /// </summary>
        public const string PostJournal = "~/Areas/GL/Views/PostJournal/Partials/_PostJournal.cshtml";

        /// <summary>
        /// The recurring entries optional field
        /// </summary>
        public const string RecurringEntriesOptionalField =
            "~/Areas/GL/Views/RecurringEntry/Partials/_RecurringEntryOptionalField.cshtml";

        /// <summary>
        /// The chart of account localization
        /// </summary>
        public const string ChartOfAccountLocalization = "~/Areas/GL/Views/ChartOfAccount/Partials/_Localization.cshtml";

        /// <summary>
        /// The trial balance localization
        /// </summary>
        public const string TrialBalanceLocalization = "~/Areas/GL/Views/TrialBalance/Partials/_Localization.cshtml";

        /// <summary>
        /// The trial balance localization
        /// </summary>
        public const string TrialBalancePartial = "~/Areas/GL/Views/TrialBalance/Partials/_TrialBalance.cshtml";

        /// <summary>
        /// The account group report localization
        /// </summary>
        public const string AccountGroupReportLocalization =
            "~/Areas/GL/Views/AccountGroupReport/_Partials/_Localization.cshtml";

        /// <summary>
        /// The options
        /// </summary>
        public const string Options = "~/Areas/GL/Views/Options/Partials/_Options.cshtml";

        /// <summary>
        /// The optional fields
        /// </summary>
        public const string OptionalFields = "~/Areas/GL/Views/OptionalFields/Partial/_OptionalFields.cshtml";

        /// <summary>
        /// The Bank Distribution Code location
        /// </summary>
        public const string BankDistributionCode = "~/Areas/CS/Views/BankDistributionCode/Partials/_BankDistributionCode.cshtml";

        /// <summary>
        /// The Bank Distribution Code localization
        /// </summary>
        public const string BankDistributionCodeLocalization = "~/Areas/CS/Views/BankDistributionCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The Bank Distribution Code localization
        /// </summary>
        public const string BankDistributionCodeDetails =
            "~/Areas/CS/Views/BankDistributionCode/Partials/_BankDistributionCodeDetails.cshtml";

        /// <summary>
        /// The batchList grid
        /// </summary>
        public const string BatchListGrid = "~/Areas/GL/Views/BatchList/Partial/_BatchListGrid.cshtml";

        /// <summary>
        /// The account 
        /// </summary>
        public const string Account = "~/Areas/GL/Views/Account/Partials/_Account.cshtml";

        /// <summary>
        /// The Chart of Account Report 
        /// </summary>
        public const string ChartOfAccount = "~/Areas/GL/Views/ChartOfAccount/Partials/_ChartOfAccount.cshtml";

        /// <summary>
        /// The Transaction Listing Report 
        /// </summary>
        public const string TransactionListingPartial = "~/Areas/GL/Views/TransactionListing/Partials/_TransactionListing.cshtml";

        /// <summary>
        /// Account Group Change SortOrder
        /// </summary>
        public const string AccountGroupChangeSortOrderPartialView = "~/Areas/GL/Views/AccountGroup/_Partials/_ChangeSortCode.cshtml";

        /// <summary>
        /// Account Selector View Popup View
        /// </summary>
        public const string AccountSelectorViewPopup = "~/Areas/GL/Views/Account/AccountRollupSelector.cshtml";

        /// <summary>
        /// Account Transaction History Popup View
        /// </summary>
        public const string AccountTransactionHistoryPopupView = "~/Areas/GL/Views/Account/AccountTransactionHistory.cshtml";

        /// <summary>
        /// Account RollUp Currency Popup View
        /// </summary>
        public const string AccountGetRollUpCurrencyPopupView = "~/Areas/GL/Views/Account/CurrencyEnquiry.cshtml";

        /// <summary>
        /// The tax group
        /// </summary>
        public const string TaxGroup = "~/Areas/CS/Views/TaxGroup/Partials/_TaxGroup.cshtml";
        /// <summary>
        /// The Bank Distribution Code localization
        /// </summary>
        public const string TaxGroupLocalization = "~/Areas/CS/Views/TaxGroup/Partials/_Localization.cshtml";

        #region Clear History

        /// <summary>
        /// The Clear History
        /// </summary>
        public const string ClearHistory = "~/Areas/GL/Views/ClearHistory/Partials/_ClearHistory.cshtml";
        /// <summary>
        /// The Clear History localization
        /// </summary>
        public const string ClearHistoryLocalization = "~/Areas/GL/Views/ClearHistory/Partials/_Localization.cshtml";

        #endregion

        #region Create Allocation Batch

        /// <summary>
        /// The Create Allocation Batch
        /// </summary>
        public const string CreateAllocationBatch = "~/Areas/GL/Views/CreateAllocationBatch/Partials/_CreateAllocationBatch.cshtml";

        /// <summary>
        /// The Create Allocation Batch localization
        /// </summary>
        public const string CreateAllocationBatchLocalization = "~/Areas/GL/Views/CreateAllocationBatch/Partials/_Localization.cshtml";

        /// <summary>
        /// The Create Allocation Batch OptionalFields popup Partial View
        /// </summary>
        public const string CreateAllocationBatchOptionalFields = "~/Areas/GL/Views/CreateAllocationBatch/Partials/_OptionalFieldGrid.cshtml";

        #endregion

        #region SourceJournalProfileReport

        /// <summary>
        /// The Source Journal Profile Report
        /// </summary>
        public const string SourceJournalProfileReport = "~/Areas/GL/Views/SourceJournalProfileReport/Partials/_SourceJournalProfileReport.cshtml";

        /// <summary>
        /// The Source Journal Profile Report localization
        /// </summary>
        public const string SourceJournalProfileReportLocalization = "~/Areas/GL/Views/SourceJournalProfileReport/Partials/_Localization.cshtml";

        #endregion

        #region SourceJournalProfile

        /// <summary>
        /// The Source Journal Profile
        /// </summary>
        public const string SourceJournalProfile = "~/Areas/GL/Views/SourceJournalProfile/Partials/_SourceJournalProfile.cshtml";

        /// <summary>
        /// The Source Journal Profile localization
        /// </summary>
        public const string SourceJournalProfileLocalization = "~/Areas/GL/Views/SourceJournalProfile/Partials/_Localization.cshtml";

        /// <summary>
        /// The Source Journal Profile Grid
        /// </summary>
        public const string SourceJournalProfileGrid = "~/Areas/GL/Views/SourceJournalProfile/Partials/_SourceJournalProfileGrid.cshtml";

        #endregion

        #region Revaluation Code
        /// <summary>
        /// The Revaluation Code localization
        /// </summary>
        public const string RevaluationCodeLocalization = "~/Areas/GL/Views/RevaluationCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The Revaluation Code Partial
        /// </summary>
        public const string RevaluationCode = "~/Areas/GL/Views/RevaluationCode/Partials/_RevaluationCode.cshtml";
        #endregion

        #region GL- Compute Fiscal Set Comparison
        /// <summary>
        /// Processing- Compute Fiscal Set Comparison Localization
        /// </summary>
        public const string ComputeFiscalSetComparisonLocalization = "~/Areas/GL/Views/ComputeFiscalSetComparison/Partials/_Localization.cshtml";

        /// <summary>
        /// Processing- Compute Fiscal Set Comparison
        /// </summary>
        public const string ComputeFiscalSetComparison = "~/Areas/GL/Views/ComputeFiscalSetComparison/Partials/_ComputeFiscalSetComparison.cshtml";

        /// <summary>
        /// Processing- Compute Fiscal Set Comparison dertails
        /// </summary>
        public const string ComputeFiscalSetComparisonDetail = "~/Areas/GL/Views/ComputeFiscalSetComparison/Partials/_ComputeFiscalSetComparisonDetail.cshtml";

        #endregion

        #region Source Code Report

        /// <summary>
        /// The Source Code report
        /// </summary>
        public const string SourceCodeReport = "~/Areas/GL/Views/SourceCodeReport/Partial/_SourceCodeReport.cshtml";


        /// <summary>
        /// The Source Code report
        /// </summary>
        public const string SourceCodeReportLocalization = "~/Areas/GL/Views/SourceCodeReport/Partial/_Localization.cshtml";
        #endregion

        #region Source Journal Report

        /// <summary>
        /// Source Journal partial view
        /// </summary>
        public const string SourceJournal = "~/Areas/GL/Views/SourceJournal/Partials/_SourceJournal.cshtml";

        /// <summary>
        /// Source Journal - Journal Tab
        /// </summary>
        public const string SourceJournalJournal = "~/Areas/GL/Views/SourceJournal/Partials/_Journal.cshtml";

        /// <summary>
        ///  Source Journal - Account Tab
        /// </summary>
        public const string SourceJournalAccount = "~/Areas/GL/Views/SourceJournal/Partials/_Account.cshtml";

        /// <summary>
        ///  Source Journal - Ranges Tab
        /// </summary>
        public const string SourceJournalRange = "~/Areas/GL/Views/SourceJournal/Partials/_Range.cshtml";

        /// <summary>
        /// The Source Journal Localization
        /// </summary>
        public const string SourceJournalLocalization = "~/Areas/GL/Views/SourceJournal/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// Session Key for Fiscal Set Comparison
        /// </summary>
        public const string SessionFiscalSetComparison = "glFiscalSetComparison";

        #region Create Account
        /// <summary>
        /// Create Account Localization
        /// </summary>
        public const string CreateAccountLocalization = "~/Areas/GL/Views/CreateAccountInputCriteria/Partials/_Localization.cshtml";

        /// <summary>
        /// Create Account
        /// </summary>
        public const string CreateAccount = "~/Areas/GL/Views/CreateAccountInputCriteria/Partials/_CreateAccount.cshtml";

        /// <summary>
        /// Create Account Detail
        /// </summary>
        public const string CreateAccountDetail = "~/Areas/GL/Views/CreateAccountInputCriteria/Partials/_CreateAccountDetail.cshtml";

        #endregion

        #region Create Account Preview

        /// <summary>
        /// Url of Create Account Preview
        /// </summary>
        public const string CreateAccountPreviewForm = "~/Areas/GL/Views/CreateAccountPreview/Partials/_CreateAccountPreview.cshtml";

        /// <summary>
        /// Url of Create Account Preview Localization
        /// </summary>
        public const string CreateAccountPreviewLocalization = "~/Areas/GL/Views/CreateAccountPreview/Partials/_Localization.cshtml";

        /// <summary>
        /// Url of Create Account Preview Localization
        /// </summary>
        public const string CreateAccountPreviewGrid = "~/Areas/GL/Views/CreateAccountPreview/Partials/_CreateAccountPreviewGrid.cshtml";

        /// <summary>
        /// Url of Create Account Preview Currency
        /// </summary>
        public const string CreateAccountPreviewCurrency = "~/Areas/GL/Views/CreateAccountPreview/Partials/_Currency.cshtml";

        /// <summary>
        /// Url of Create Account Preview Optional Fields
        /// </summary>
        public const string CreateAccountPreviewOptionalFields = "~/Areas/GL/Views/CreateAccountPreview/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// Url of Create Account Preview Subledger
        /// </summary>
        public const string CreateAccountPreviewSubledger = "~/Areas/GL/Views/CreateAccountPreview/Partials/_Subledger.cshtml";

        /// <summary>
        /// Url of Create Account Preview Transaction Optional Fields
        /// </summary>
        public const string CreateAccountPreviewTransOptionalFields = "~/Areas/GL/Views/CreateAccountPreview/Partials/_TransOptionalFields.cshtml";

        #endregion

        #region Create Account Report

        /// <summary>
        /// Create Account Report
        /// </summary>
        public const string CreateAccountReport = "~/Areas/GL/Views/CreateAccountReport/Partials/_CreateAccountReport.cshtml";

        /// <summary>
        /// The Create Account Report localization
        /// </summary>
        public const string CreateAccountReportLocalization = "~/Areas/GL/Views/CreateAccountReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Segment Grid - Create Account Report
        /// </summary>
        public const string CreateAccountReportSegmentGrid = "~/Areas/GL/Views/CreateAccountReport/Partials/_SegmentGrid.cshtml";

        #endregion

        #region GL- Consolidate Posted Transaction
        /// <summary>
        /// Processing- Consolidate Posted Transaction Localization
        /// </summary>
        public const string ConsolidatePostedTransactionLocalization = "~/Areas/GL/Views/ConsolidatePostedTransaction/Partials/_Localization.cshtml";

        /// <summary>
        /// Processing- Consolidate Posted Transaction
        /// </summary>
        public const string ConsolidatePostedTransaction = "~/Areas/GL/Views/ConsolidatePostedTransaction/Partials/_ConsolidatePostedTransaction.cshtml";

        /// <summary>
        /// Processing- Consolidate Posted Transaction details
        /// </summary>
        public const string ConsolidatePostedTransactionDetail = "~/Areas/GL/Views/ConsolidatePostedTransaction/Partials/_ConsolidatePostedTransactionDetail.cshtml";

        #endregion

    }
}