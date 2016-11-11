/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Costant for CS partial views
    /// </summary>
    public static class CommonServices
    {
        #region Session Variables Used By CS

        /// <summary>
        /// Session Key for Currency Rates
        /// </summary>
        public const string SessionCurrencyRate = "csCurrencyRateCache";
        /// <summary>
        /// Session Key for CS Optional Fields
        /// </summary>
        public const string SessionOptionalField = "csOptionalFieldCache";

        /// <summary>
        /// Session Key for BK Deposit Details 
        /// </summary>
        public const string SessionDepositDetails = "bkDepositDetailsCache";

        /// <summary>
        /// Session Key for BK Bank Transaction Header  
        /// </summary>
        public const string SessionBankTransactionHeader = "bkTransactionHeaderCache";

        /// <summary>
        /// Session Key for Bank Currency
        /// </summary>
        public const string SessionBankCurrency = "csBankCurrencyCache";

        /// <summary>
        /// Session Key for Bank Check Stock
        /// </summary>
        public const string SessionCheckStock = "csCheckStockCache";
        #endregion

        /// <summary>
        /// Bank view
        /// </summary>
        public const string Bank = "~/Areas/CS/Views/Bank/Partials/_Bank.cshtml";

        /// <summary>
        ///  Bank profile view
        /// </summary>
        public const string BankProfile = "~/Areas/CS/Views/Bank/Partials/_Profile.cshtml";

        /// <summary>
        ///  Bank account view
        /// </summary>
        public const string BankAccount = "~/Areas/CS/Views/Bank/Partials/_Account.cshtml";

        /// <summary>
        ///  Bank address view
        /// </summary>
        public const string BankAddress = "~/Areas/CS/Views/Bank/Partials/_Address.cshtml";

        /// <summary>
        ///  Bank check stock view
        /// </summary>
        public const string BankCheckStocks = "~/Areas/CS/Views/Bank/Partials/_CheckStocks.cshtml";

        /// <summary>
        ///  Bank currency view
        /// </summary>
        public const string BankCurrency = "~/Areas/CS/Views/Bank/Partials/_Currency.cshtml";

        /// <summary>
        ///  Bank taxes view
        /// </summary>
        public const string BankTaxes = "~/Areas/CS/Views/Bank/Partials/_Taxes.cshtml";

        /// <summary>
        ///  Bank banlance view
        /// </summary>
        public const string BankBalance = "~/Areas/CS/Views/Bank/Partials/_Balance.cshtml";

        /// <summary>
        /// The bank localization
        /// </summary>
        public const string BankLocalization = "~/Areas/cs/Views/Bank/Partials/_Localization.cshtml";

        /// <summary>
        /// Bank service options view
        /// </summary>
        public const string BankOptions = "~/Areas/CS/Views/BankOptions/Partials/_Options.cshtml";

        /// <summary>
        ///  Bank service options company view
        /// </summary>
        public const string BankOptionsCompany = "~/Areas/CS/Views/BankOptions/Partials/_Company.cshtml";

        /// <summary>
        ///  Bank service options company view
        /// </summary>
        public const string BankOptionsgrid = "~/Areas/CS/Views/BankOptions/Partials/_DocumentsGrid.cshtml";

        /// <summary>
        ///  Bank service options processing view
        /// </summary>
        public const string BankOptionsProcessing = "~/Areas/CS/Views/BankOptions/Partials/_Processing.cshtml";

        /// <summary>
        ///  Bank service options documents view
        /// </summary>
        public const string BankOptionsDocuments = "~/Areas/CS/Views/BankOptions/Partials/_Documents.cshtml";

        /// <summary>
        /// The bank options localization
        /// </summary>
        public const string BankOptionsLocalization = "~/Areas/cs/Views/BankOptions/Partials/_Localization.cshtml";

        /// <summary>
        /// The bank distribution code localization
        /// </summary>
        public const string BankDistributionCodeLocalization = "~/Areas/CS/Views/BankDistributionCode/Partials/_Localization.cshtml";

        /// <summary>
        /// CurrencyRateType view
        /// </summary>
        public const string CurrencyRateType = "~/Areas/CS/Views/CurrencyRateType/Partial/_CurrencyRateType.cshtml";

        /// <summary>
        /// CurrencyRateType localization
        /// </summary>
        public const string CurrencyRateTypeLocalization = "~/Areas/CS/Views/CurrencyRateType/Partial/_Localization.cshtml";

        /// <summary>
        /// Bank Entry
        /// </summary>
        public const string BankEntry = "~/Areas/CS/Views/BankEntry/Partials/_BankEntry.cshtml";

        /// <summary>
        /// Bank Entry Grid
        /// </summary>
        public const string BankEntryGrid = "~/Areas/CS/Views/BankEntry/Partials/_BankEntryGrid.cshtml";

        /// <summary>
        /// Bank Entry Localization
        /// </summary>
        public const string BankEntryLocalization = "~/Areas/CS/Views/BankEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// The Bank Transfers Taxes
        /// </summary>
        public const string BankEntryTaxes = "~/Areas/CS/Views/BankEntry/Partials/_Taxes.cshtml";

        /// <summary>
        /// The Bank Transfers Taxes
        /// </summary>
        public const string BankEntryTaxesGrid = "~/Areas/CS/Views/BankEntry/Partials/_TaxesGrid.cshtml";

        /// <summary>
        /// The bank distributionCode
        /// </summary>
        public const string BankDistributionCode = "~/Areas/CS/Views/BankDistributionCode/Partials/_BankDistributionCode.cshtml";

        /// <summary>
        /// The bank distributionSet
        /// </summary>
        public const string BankDistributionSet = "~/Areas/CS/Views/BankDistributionSet/Partials/_BankDistributionSet.cshtml";

        /// <summary>
        /// Distribution Set
        /// </summary>
        public const string BankDistributionSetDetails = "~/Areas/CS//Views/BankDistributionSet/Partials/_BankDistributionSetGrid.cshtml";

        /// <summary>
        /// Distribution Set
        /// </summary>
        public const string BankDistributionSetLocalization = "~/Areas/CS//Views/BankDistributionSet/Partials/_Localization.cshtml";

        /// <summary>
        /// Fiscal Calendar Localization View
        /// </summary>
        public const string FiscalCalendarSetLocalization = "~/Areas/CS/Views/FiscalCalendar/Partials/_Localization.cshtml";

        /// <summary>
        /// Fiscal Calendar Details
        /// </summary>
        public const string FiscalCalendarDetails = "~/Areas/CS/Views/FiscalCalendar/Partials/_FiscalCalendar.cshtml";

        /// <summary>
        /// Tax Tracking Report
        /// </summary>
        public const string TaxTracking = "~/Areas/CS/Views/TaxTracking/Partials/_TaxTracking.cshtml";

        /// <summary>
        /// TransactionListing Report
        /// </summary>
        public const string TransactionListing = "~/Areas/CS/Views/TransactionListing/Partials/_TransactionListing.cshtml";

        /// <summary>
        /// TransactionListing Localization
        ///</summary>
        public const string TransactionListingLocalization = "~/Areas/CS/Views/TransactionListing/Partials/_Localization.cshtml";

        /// <summary>
        /// ImportOFXStatements Localization
        /// </summary>
        public const string ImportOFXStatementLocalization = "~/Areas/CS//Views/ImportOFXStatement/Partial/_Localization.cshtml";

        /// <summary>
        /// Export\Import controller name for ImportOFXStatement 
        /// </summary>
        public const string ControllerName = "importofxstatement";

        /// <summary>
        /// TaxRates
        /// </summary>
        public const string TaxRates = "~/Areas/CS/Views/TaxRate/Partial/_TaxRate.cshtml";

        /// <summary>
        /// TaxRatesLocalization
        /// </summary>
        public const string TaxRatesLocalization = "~/Areas/CS/Views/TaxRate/Partial/_Localization.cshtml";

        /// <summary>
        /// ImportOFXStatement View
        /// </summary>
        public const string ImportOFXStatement = "~/Areas/CS/Views/ImportOFXStatement/Partial/_ImportOFXStatement.cshtml";

        /// <summary>
        /// CurrencyRateType view
        /// </summary>
        public const string TaxClassLocalization = "~/Areas/CS/Views/TaxClass/Partials/_Localization.cshtml";

        /// <summary>
        /// CurrencyRateType view
        /// </summary>
        public const string TaxClassHeader = "~/Areas/CS/Views/TaxClass/Partials/_TaxClass.cshtml";

        /// <summary>
        /// CurrencyRateType view
        /// </summary>
        public const string TaxClassDetail = "~/Areas/CS/Views/TaxClass/Partials/_TaxClassDetail.cshtml";

        /// <summary>
        /// The bank distributionSet
        /// </summary>
        public const string TaxGroup = "~/Areas/CS/Views/TaxGroup/Partials/_TaxGroup.cshtml";

        /// <summary>
        /// Entry Type used in ImportOFXStatement Repository
        /// </summary>
        public const string UserEntered = "0";

        /// <summary>
        /// The tax group details
        /// </summary>
        public const string TaxGroupDetails = "~/Areas/CS//Views/TaxGroup/Partials/_TaxGroupDetails.cshtml";

        /// <summary>
        /// The tax group details
        /// </summary>
        public const string TaxRatesGrid = "~/Areas/CS/Views/TaxRate/Partial/_TaxRateGrid.cshtml";

        /// <summary>
        /// The tax group localization
        /// </summary>
        public const string TaxGroupLocalization = "~/Areas/CS//Views/TaxGroup/Partials/_Localization.cshtml";

        /// <summary>
        /// Tax Authorities
        /// </summary>
        public const string TaxAuthority = "~/Areas/CS/Views/TaxAuthority/Partials/_TaxAuthority.cshtml";

        /// <summary>
        /// Tax Authorities Localization
        /// </summary>
        public const string TaxAuthorityLocalization = "~/Areas/CS//Views/TaxAuthority/Partials/_Localization.cshtml";

        /// <summary>
        /// Tax Authorities Profile tab
        /// </summary>
        public const string TaxAuthorityProfileTab = "~/Areas/CS//Views/TaxAuthority/Partials/_ProfileTab.cshtml";

        /// <summary>
        /// Tax Authorities Accounts tab
        /// </summary>
        public const string TaxAuthorityAccountsTab = "~/Areas/CS//Views/TaxAuthority/Partials/_AccountsTab.cshtml";

        /// <summary>
        /// Filtering string for only Active fiscal year 
        /// </summary>
        public const string ActiveFiscalYear = "(ACTIVE = TRUE)";

        /// <summary>
        /// Tax Tracking Report Localization
        /// </summary>
        public const string TaxTrackingLocalization = "~/Areas/CS/Views/TaxTracking/Partials/_Localization.cshtml";

        /// <summary>
        /// Optional Fields partial view
        /// </summary>
        public const string OptionalFields = "~/Areas/CS/Views/OptionalFields/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// Optional Fiels Grid Details
        /// </summary>
        public const string OptionalFieldValues = "~/Areas/CS/Views/OptionalFields/Partials/_OptionalFieldValues.cshtml";

        /// <summary>
        /// Optional Fields Localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/CS/Views/OptionalFields/Partials/_Localization.cshtml";

        /// <summary>
        /// Deposit Status Report
        /// </summary>
        public const string DepositStatus = "~/Areas/CS/Views/DepositStatus/Partials/_DepositStatus.cshtml";

        /// <summary>
        /// Deposit Status Report Localization
        /// </summary>
        public const string DepositStatusLocalization = "~/Areas/CS/Views/DepositStatus/Partials/_Localization.cshtml";

        /// <summary>
        ///  Bank service options documents view
        /// </summary>
        public const string BankClearHistory = "~/Areas/CS/Views/BankClearHistory/Partials/_BankClearHistory.cshtml";

        /// <summary>
        /// The bank options localization
        /// </summary>
        public const string BankClearHistoryLocalization = "~/Areas/CS/Views/BankClearHistory/Partials/_Localization.cshtml";

        /// <summary>
        /// The Bank Transfers
        /// </summary>
        public const string BankTransfer = "~/Areas/CS/Views/BankTransfer/Partials/_BankTransfer.cshtml";

        /// <summary>
        /// The Bank Transfers localization
        /// </summary>
        public const string BankTransferLocalization = "~/Areas/CS/Views/BankTransfer/Partials/_Localization.cshtml";

        /// <summary>
        /// The Bank Transfers Details
        /// </summary>
        public const string BankTransferDetail = "~/Areas/CS/Views/BankTransfer/Partials/_BankTransferDetails.cshtml";

        /// <summary>
        /// The Bank Transfers Taxes
        /// </summary>
        public const string BankTransferTaxes = "~/Areas/CS/Views/BankTransfer/Partials/_Taxes.cshtml";

        /// <summary>
        /// The Bank Transfers Taxes
        /// </summary>
        public const string BankTransferTaxesGrid = "~/Areas/CS/Views/BankTransfer/Partials/_TaxesGrid.cshtml";

        /// <summary>
        /// The currency rate
        /// </summary>
        public const string CurrencyRate = "~/Areas/CS/Views/CurrencyRate/Partials/_CurrencyRate.cshtml";

        /// <summary>
        /// The currency rate details
        /// </summary>
        public const string CurrencyRateDetails = "~/Areas/CS/Views/CurrencyRate/Partials/_CurrencyRateDetails.cshtml";

        /// <summary>
        /// The currency rate localization
        /// </summary>
        public const string CurrencyRateLocalization = "~/Areas/CS/Views/CurrencyRate/Partials/_Localization.cshtml";

        /// <summary>
        /// Bank Check Register Grid for Print Check
        /// </summary>
        public const string BankCheckRegisterGrid = "~/Areas/CS/Views/PrintCheck/Partials/_BankCheckRegisterGrid.cshtml";

        /// <summary>
        /// Bank Check Register Grid for Print Check
        /// </summary>
        public const string PrintCheck = "~/Areas/CS/Views/PrintCheck/Partials/_PrintCheck.cshtml";

        /// <summary>
        /// Bank Check Register Grid for Print Check 
        /// </summary>
        public const string PrintCheckLocalization = "~/Areas/CS/Views/PrintCheck/Partials/_Localization.cshtml";

        /// <summary>
        /// CurrencyCodes view
        /// </summary>
        public const string CurrencyCode = "~/Areas/CS/Views/CurrencyCode/Partials/_CurrencyCode.cshtml";

        /// <summary>
        /// The currency rate localization
        /// </summary>
        public const string CurrencyCodeLocalization = "~/Areas/CS/Views/CurrencyCode/Partials/_Localization.cshtml";


        #region BankReconciliation

        /// <summary>
        /// The Bank Reconciliation Partial View
        /// </summary>
        public const string BankReconciliation = "~/Areas/CS/Views/BankReconciliation/Partials/_BankReconciliation.cshtml";

        /// <summary>
        /// The Bank Reconciliation Localization View
        /// </summary>
        public const string BankReconciliationLocalization = "~/Areas/CS/Views/BankReconciliation/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// WithdrawalStatus View
        /// </summary>
        public const string WithdrawalStatus = "~/Areas/CS/Views/WithdrawalStatus/Partial/_WithdrawalStatus.cshtml";

        /// <summary>
        /// WithdrawalStatus Localization
        /// </summary>
        public const string WithdrawalStatusLocalization = "~/Areas/CS/Views/WithdrawalStatus/Partial/_Localization.cshtml";

        #region PostEntries

        /// <summary>
        /// Post Entries Details
        /// </summary>
        public const string PostEntriesDetails = "~/Areas/CS/Views/PostEntries/Partials/_PostEntries.cshtml";

        /// <summary>
        /// Post Entries Localization View
        /// </summary>
        public const string PostEntriesLocalization = "~/Areas/CS/Views/PostEntries/Partials/_Localization.cshtml";

        /// <summary>
        /// Reconciliation Status View
        /// </summary>
        public const string ReconciliationStatus = "~/Areas/CS/Views/ReconciliationStatus/Partials/_ReconciliationStatus.cshtml";
        /// <summary>
        /// Reconciliation Status Localization View
        /// </summary>
        public const string ReconciliationStatusLocalization = "~/Areas/CS/Views/ReconciliationStatus/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// TransferPostingJournal Report
        /// </summary>
        public const string TransferPostingJournal = "~/Areas/CS/Views/TransferPostingJournal/Partials/_TransferPostingJournal.cshtml";

        /// <summary>
        /// TransferPostingJournal Report Localization
        /// </summary>
        public const string TransferPostingJournalLocalization = "~/Areas/CS/Views/TransferPostingJournal/Partials/_Localization.cshtml";

        /// <summary>
        /// Check Payment Register Report
        /// </summary>
        public const string CheckPaymentRegister = "~/Areas/CS/Views/CheckPaymentRegister/Partials/_CheckPaymentRegister.cshtml";

        /// <summary>
        /// Check Payment Register Report Localization
        /// </summary>
        public const string CheckPaymentRegisterLocalization = "~/Areas/CS/Views/CheckPaymentRegister/Partials/_Localization.cshtml";

        /// <summary>
        /// IntegrityChecker
        /// </summary>
        public const string IntegrityChecker = "~/Areas/CS/Views/IntegrityChecker/Partials/_IntegrityChecker.cshtml";

        /// <summary>
        /// Bank Reconciliation Clearing localization
        /// </summary>
        public const string CreateGLBatchLocalization = "~/Areas/CS/Views/CreateGLBatch/Partials/_Localization.cshtml";

        /// <summary>
        /// Bank Reconciliation Clearing
        /// </summary>
        public const string CreateGLBatch = "~/Areas/CS/Views/CreateGLBatch/Partials/_CreateGLBatch.cshtml";

        #region Deposit register

        /// <summary>
        /// Bank Reconciliation Clearing localization
        /// </summary>
        public const string DepositRegisterLocalization = "~/Areas/CS/Views/DepositRegister/Partials/_Localization.cshtml";

        /// <summary>
        /// Bank Reconciliation Clearing
        /// </summary>
        public const string DepositRegister = "~/Areas/CS/Views/DepositRegister/Partials/_DepositRegister.cshtml";

        #endregion Deposit register

        /// <summary>
        /// ReconciliationPostingJournal Report
        /// </summary>
        public const string ReconciliationPostingJournal = "~/Areas/CS/Views/ReconciliationPostingJournal/Partials/_ReconciliationPostingJournal.cshtml";

        /// <summary>
        /// ReconciliationPostingJournal Report Localization
        /// </summary>
        public const string ReconciliationPostingJournalLocalization = "~/Areas/CS/Views/ReconciliationPostingJournal/Partials/_Localization.cshtml";

        /// <summary>
        /// ReverseTransaction
        /// </summary>
        public const string ReverseTransaction = "~/Areas/CS/Views/ReverseTransaction/Partials/_ReverseTransaction.cshtml";

        /// <summary>
        /// ReverseTransaction Localization
        /// </summary>
        public const string ReverseTransactionLocalization = "~/Areas/CS/Views/ReverseTransaction/Partials/_Localization.cshtml";

        /// <summary>
        /// ReverseMultipleTransaction
        /// </summary>
        public const string ReverseMultipleTransaction = "~/Areas/CS/Views/ReverseTransaction/Partials/_ReverseMultipleTransaction.cshtml";

        /// <summary>
        /// ReverseMultipleTransactionDetail
        /// </summary>
        public const string ReverseMultipleTransactionDetail = "~/Areas/CS/Views/ReverseTransaction/Partials/_ReverseMultipleTransactionDetail.cshtml";

        /// <summary>
        /// ReverseSingleTransaction
        /// </summary>
        public const string ReverseSingleTransaction = "~/Areas/CS/Views/ReverseTransaction/Partials/_ReverseSingleTransaction.cshtml";
        /// <summary>
        /// Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptions = "~/Areas/CS/Views/PaymentProcessingOptions/Partials/_PaymentProcessingOptions.cshtml";

        /// <summary>
        /// Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptionsCompany = "~/Areas/CS/Views/PaymentProcessingOptions/Partials/_Company.cshtml";

        /// <summary>
        /// Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptionsCompanyProfile = "~/Areas/CS/Views/PaymentProcessingOptions/Partials/_CompanyProfile.cshtml";

        /// <summary>
        /// Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptionsProcessing = "~/Areas/CS/Views/PaymentProcessingOptions/Partials/_Processing.cshtml";

        /// <summary>
        /// Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptionsLocalization = "~/Areas/CS/Views/PaymentProcessingOptions/Partials/_Localization.cshtml";

        /// <summary>
        /// PaymentProcessingCode
        /// </summary>
        public const string PaymentProcessingCode = "~/Areas/CS/Views/PaymentProcessingCode/Partials/_PaymentProcessingCode.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string PaymentProcessingCodeLocalization = "~/Areas/CS/Views/PaymentProcessingCode/Partials/_Localization.cshtml";

        #region Integrity Checker

        /// <summary>
        /// The Data Integrity Partial View for Application Option
        /// </summary>
        public const string IntegrityCheck = "~/Areas/CS/Views/IntegrityChecker/Partials/_IntegrityChecker.cshtml";

        #endregion

        #region Reconcile OFX Statements

        /// <summary>
        /// ReconcileOFX Statement view
        /// </summary>
        public const string ReconcileOFXStatement = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_ReconcileOFXStatement.cshtml";

        /// <summary>
        /// ReconcileOFX Statement Grid View
        /// </summary>
        public const string ReconcileOFXStatementGrid = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_ReconcileOFXStatementGrid.cshtml";

        /// <summary>
        /// ReconcileOFX Statement Match OFX Popup window
        /// </summary>
        public const string MatchOFXTransactionPopup = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_MatchOFXTransaction.cshtml";

        /// <summary>
        /// ReconcileOFX Statement Match OFX Popup window
        /// </summary>
        public const string MatchOFXDepositSlipPopup = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_MatchOFXDepositSlip.cshtml";

        /// <summary>
        /// ReconcileOFX Statement Localization
        /// </summary>
        public const string ReconcileOFXStatementLocalization = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_Localization.cshtml";

        /// <summary>
        /// Match OFX Statement Grid For Deposits
        /// </summary>
        public const string MatchOFXStatementGridDeposits = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_ReconcileOFXStatementGridDeposit.cshtml";

        /// <summary>
        /// Match OFX Statement Grid For Transaction
        /// </summary>
        public const string MatchOFXStatementGridTransaction = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_ReconcileOFXStatementGridTransaction.cshtml";

        /// <summary>
        /// Match OFX Statement Grid For Deposits
        /// </summary>
        public const string MatchOFXStatementGridWithdrawals = "~/Areas/CS/Views/ReconcileOFXStatement/Partials/_ReconcileOFXStatementGridWithDrawals.cshtml";

        #endregion

        #region PostReconciliation

        /// <summary>
        /// Post Reconciliation Details
        /// </summary>
        public const string PostReconciliationDetails = "~/Areas/CS/Views/PostReconciliation/Partials/_PostReconciliation.cshtml";

        /// <summary>
        /// Post Reconciliation Localization View
        /// </summary>
        public const string PostReconciliationLocalization = "~/Areas/CS/Views/PostReconciliation/Partials/_Localization.cshtml";


        #endregion

        #region BankGLIntegration

        ///<summary>
        /// The BankGLIntegration Partial View
        /// </summary>
        public const string BankGLIntegration = "~/Areas/CS/Views/BankGLIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The BankGLIntegration localization
        /// </summary>
        public const string BankGLIntegrationLocalization = "~/Areas/CS/Views/BankGLIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The BankGLIntegration Options
        /// </summary>
        public const string BankGLIntegrationOptions = "~/Areas/CS/Views/BankGLIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The BankGLIntegration Transactions
        /// </summary>
        public const string BankGLIntegrationTransactions = "~/Areas/CS/Views/BankGLIntegration/Partials/_Transactions.cshtml";

        #endregion


        #region CompanyProfile

        /// <summary>
        /// The companyprofile localization
        /// </summary>
        public const string CompanyprofileLocalization = "~/Areas/CS/Views/CompanyProfile/Partials/_Localization.cshtml";

        /// <summary>
        /// The company profile address
        /// </summary>
        public const string CompanyProfileAddress = "~/Areas/CS/Views/CompanyProfile/Partials/_CompanyAddress.cshtml";

        /// <summary>
        /// The company profile option
        /// </summary>
        public const string CompanyProfileOption = "~/Areas/CS/Views/CompanyProfile/Partials/_CompanyOption.cshtml";
        /// <summary>
        ///companyprofile
        /// </summary>
        public const string Profile = "~/Areas/CS/Views/CompanyProfile/Partials/_Profile.cshtml";

        #endregion

        #region Reconcile Statement

        /// <summary>
        /// Reconcile Statement - Localization Partial View
        /// </summary>
        public const string ReconcileStatementLocalization = "~/Areas/CS/Views/ReconcileStatement/Partials/_Localization.cshtml";

        /// <summary>
        /// Reconcile Statement patial view
        /// </summary>
        public const string ReconcileStatement = "~/Areas/CS/Views/ReconcileStatement/Partials/_ReconcileStatement.cshtml";

        /// <summary>
        /// ReconcileStatement - Reconciliation Tab partial view
        /// </summary>
        public const string ReconcileStatementReconciliation = "~/Areas/CS/Views/ReconcileStatement/Partials/_Reconciliation.cshtml";

        /// <summary>
        /// ReconcileStatement - Summay Tab partial view
        /// </summary>
        public const string ReconcileStatementSummary = "~/Areas/CS/Views/ReconcileStatement/Partials/_Summary.cshtml";

        /// <summary>
        /// ReconcileStatement - Total Tab partial view
        /// </summary>
        public const string ReconcileStatementTotal = "~/Areas/CS/Views/ReconcileStatement/Partials/_Total.cshtml";

        /// <summary>
        /// ReconcileStatement - Book Balance Tab partial view
        /// </summary>
        public const string ReconcileStatementBookBalance = "~/Areas/CS/Views/ReconcileStatement/Partials/_BookBalance.cshtml";

        /// <summary>
        /// ReconcileStatement - Quick Clearing Popup
        /// </summary>
        public const string ReconcileStatementQuickClearing = "~/Areas/CS/Views/ReconcileStatement/Partials/_QuickClearing.cshtml";

        /// <summary>
        /// ReconcileStatement - Quick Clearing Localization
        /// </summary>
        public const string ReconcileStatementQuickClearingLocalization = "~/Areas/CS/Views/QuickClearing/Partials/_Localization.cshtml";

        /// <summary>
        /// ReconcileStatement - Deposit Detail partial view
        /// </summary>
        public const string DepositDetail = "~/Areas/CS/Views/ReconcileStatement/Partials/_DepositDetail.cshtml";

        #endregion

        #region BankEntryPostingJournal

        /// <summary>
        /// BankEntryPostingJournal Report
        /// </summary>
        public const string BankEntryPostingJournal = "~/Areas/CS/Views/BankEntryPostingJournal/Partials/_BankEntryPostingJournal.cshtml";

        /// <summary>
        /// BankEntryPostingJournal Localization
        ///</summary>
        public const string BankEntryPostingJournalLocalization = "~/Areas/CS/Views/BankEntryPostingJournal/Partials/_Localization.cshtml";

        #endregion

        #region Transaction History Inquiry

        /// <summary>
        ///Transaction History Inquiry Main page screen
        /// </summary>
        public const string TransactionHistoryInquiry =
            "~/Areas/CS/Views/TransactionHistoryInquiry/Partials/_TransactionHistoryInquiry.cshtml";

        /// <summary>
        /// Transaction History Inquiry grid to display Bank Transaction Details
        /// </summary>
        public const string TransactionHistoryInquiryGrid =
            "~/Areas/CS/Views/TransactionHistoryInquiry/Partials/_BankTransactionDetailGrid.cshtml";

        /// <summary>
        /// Transaction History Inquiry Localization
        /// </summary>
        public const string TransactionHistoryInquiryLocalization =
            "~/Areas/CS/Views/TransactionHistoryInquiry/Partials/_Localization.cshtml";

        #endregion

        /// <summary>
        /// CS - GLTransaction Report
        /// </summary>
        public const string GLTransactionReport = "~/Areas/CS/Views/GLTransaction/Partials/_GLTransaction.cshtml";

        /// <summary>
        /// Shared GL Transaction Report Localization
        /// </summary>
        public const string GLTransactionReportLocalization = "~/Areas/CS/Views/GLTransaction/Partials/_GLTransactionLocalization.cshtml";

        #region OEGLIntegration
        ///<summary>
        /// The OEGLIntegration Partial View
        /// </summary>
        public const string OEGLIntegration = "~/Areas/OE/Views/GLIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The OEGLIntegration localization
        /// </summary>
        public const string OEGLIntegrationLocalization = "~/Areas/OE/Views/GLIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The OEGLIntegration Options
        /// </summary>
        public const string OEGLIntegrationOptions = "~/Areas/OE/Views/GLIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The OEGLIntegration Transactions
        /// </summary>
        public const string OEGLIntegrationTransactions = "~/Areas/OE/Views/GLIntegration/Partials/_Transactions.cshtml";
        #endregion

        #region ICGLIntegration

        ///<summary>
        /// The ICGLIntegration Partial View
        /// </summary>
        public const string ICGLIntegration = "~/Areas/IC/Views/GLIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The ICGLIntegration localization
        /// </summary>
        public const string ICGLIntegrationLocalization = "~/Areas/IC/Views/GLIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The ICGLIntegration Options
        /// </summary>
        public const string ICGLIntegrationOptions = "~/Areas/IC/Views/GLIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The ICGLIntegration Transactions
        /// </summary>
        public const string ICGLIntegrationTransactions = "~/Areas/IC/Views/GLIntegration/Partials/_Transactions.cshtml";


        #endregion
        /// <summary>
        /// PayableClrAuditList Localization Partial View
        /// </summary>
        public const string PayableClrAuditListLocalization = "~/Areas/PO/Views/PayableClrAuditList/Partials/_Localization.cshtml";

        /// <summary>
        /// Payable Clr Audit List Partial View
        /// </summary>
        public const string PayableClrAuditList = "~/Areas/PO/Views/PayableClrAuditList/Partials/_PayableClrAuditList.cshtml";

        /// <summary>
        /// AgedPurchaseOrder Localization Partial View
        /// </summary>
        public const string AgedPurchaseOrderLocalization = "~/Areas/PO/Views/AgedPurchaseOrder/Partials/_Localization.cshtml";


        /// <summary>
        /// Aged Purchase Order  Partial View
        /// </summary>
        public const string AgedPurchaseOrder = "~/Areas/PO/Views/AgedPurchaseOrder/Partials/_AgedPurchaseOrder.cshtml";

        /// <summary>
        /// CSSchedules Partial View
        /// </summary>
        public const string CSSchedules = "~/Areas/CS/Views/Schedule/Partials/_Schedule.cshtml";

        /// <summary>
        /// CSSchedules Localization Partial View
        /// </summary>
        public const string CSSchedulesLocalization = "~/Areas/CS/Views/Schedule/Partials/_Localization.cshtml";

        /// <summary>
        /// CSSchedules Localization Partial View
        /// </summary>
        public const string CSSchedulesDetails = "~/Areas/CS/Views/Schedule/Partials/_ScheduleDetails.cshtml";

        /// <summary>
        /// CSSchedules Partial View
        /// </summary>
        public const string CSReminderList = "~/Areas/CS/Views/ReminderList/Partials/_ReminderList.cshtml";

        /// <summary>
        /// CSSchedules Localization Partial View
        /// </summary>
        public const string CSReminderListLocalization = "~/Areas/CS/Views/ReminderList/Partials/_Localization.cshtml";



    }
}
