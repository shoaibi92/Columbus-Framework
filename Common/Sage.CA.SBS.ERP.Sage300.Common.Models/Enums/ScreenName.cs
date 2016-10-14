/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Different UI screens
    /// </summary>
    public class ScreenName
    {
        #region others
        /// <summary>
        /// The none
        /// </summary>
        public const string None = "0";

        /// <summary>
        /// Home Screen
        /// </summary>
        public const string Home = "999999";

        /// <summary>
        /// Log in  Screen
        /// </summary>
        public const string Login = "999998";

        #endregion

        #region AS 1-200

        /// <summary>
        /// The SecurityGroup
        /// </summary>
        public const string SecurityGroup = "1";

        /// <summary>
        /// Restart Records Maintenance
        /// </summary>
        public const string RestartRecord = "2";

        /// <summary>
        /// DataIntegrity
        /// </summary>
        public const string DataIntegrity = "3";

        /// <summary>
        /// The user authorizations
        /// </summary>
        public const string UserAuthorizations = "4";

        /// <summary>
        /// User 
        /// </summary>
        public const string User = "5";

        /// <summary>
        /// PopupRestartRecord 
        /// </summary>
        public const string PopupRestartRecord = "6";

        /// <summary>
        /// Menu Customization screen identifier
        /// </summary>
        public const string MenuCustomization = "7";
        #endregion

        #region CS 201-400

        /// <summary>
        /// The Bank Options
        /// </summary>
        public const string BankOptions = "201";

        /// <summary>
        /// The Banks
        /// </summary>
        public const string Banks = "202";

        /// <summary>
        /// The bank distribution code
        /// </summary>
        public const string BankDistributionCode = "203";

        /// <summary>
        /// The bank distribution set
        /// </summary>
        public const string BankDistributionSet = "204";

        /// <summary>
        /// The Tax Classes
        /// </summary>
        public const string TaxClasses = "205";

        /// <summary>
        /// TaxRates
        /// </summary>
        public const string TaxRates = "206";

        /// <summary>
        /// The Tax TaxAuthorities
        /// </summary>
        public const string TaxAuthorities = "207";

        /// <summary>
        /// The currency rate type
        /// </summary>
        public const string CurrencyRateType = "208";

        /// <summary>
        /// The bank entry
        /// </summary>
        public const string BankEntry = "209";

        /// <summary>
        /// Clear History
        /// </summary>
        public const string CSClearHistory = "210";

        /// <summary>
        /// Withdrawal Status Report
        /// </summary>
        public const string WithdrawalStatus = "211";

        /// <summary>
        /// CS- Fiscal Calendar Screen Name
        /// </summary>
        public const string FiscalCalendar = "212";

        /// <summary>
        /// Bank Reconciliation
        /// </summary>
        public const string BankReconciliation = "213";

        /// <summary>
        /// Reconciliation status
        /// </summary>
        public const string ReconciliationStatus = "214";

        /// <summary>
        /// Deposit Register
        /// </summary>
        public const string DepositRegister = "215";

        /// <summary>
        /// Reconcile OFX Statement
        /// </summary>
        public const string ReconcileOFXStatement = "216";

        /// <summary>
        /// Post Reconciliation
        /// </summary>
        public const string PostReconciliation = "217";

        /// <summary>
        /// CS GL Integration
        /// </summary>
        public const string CSGLIntegration = "218";

        /// <summary>
        /// CS ReconcileStatement
        /// </summary>
        public const string ReconcileStatement = "219";

        /// <summary>
        /// CS - Payment Processing Options
        /// </summary>
        public const string PaymentProcessingOptions = "220";

        /// <summary>
        /// CS - Payment Processing Code
        /// </summary>
        public const string PaymentProcessingCode = "221";

        /// <summary>
        /// CS - Bank Entry Posting Journal
        /// </summary>
        public const string BankEntryPostingJournal = "222";

        /// <summary>
        /// BK - Bank Transaction Portal Superview
        /// </summary>
        public const string BKQuickClearing = "223";

        /// <summary>
        /// CS - GL Transaction
        /// </summary>
        public const string CSGLTransaction = "224";

        /// <summary>
        /// CS CurrencyCodes
        /// </summary>
        public const string CurrencyCodes = "225";

        /// <summary>
        /// The schedule
        /// </summary>
        public const string Schedule = "226";

        /// <summary>
        /// The currency rate
        /// </summary>
        public const string CurrencyRate = "227";

        /// <summary>
        /// The Tax Tracking Report
        /// </summary>
        public const string TaxTracking = "228";

        /// <summary> 
        /// Import OFX Statement
        /// </summary> 
        public const string ImportOFXStatement = "229";

        /// <summary>
        /// Post Entries
        /// </summary>
        public const string PostEntries = "230";

        /// <summary>
        /// Integrity Checker CS
        /// </summary>
        public const string BankServicesIntegrityCheck = "231";

        /// <summary>
        /// Bank Reconciliation Clearing
        /// </summary>
        public const string BankReconciliationClearing = "232";

        /// <summary>
        /// CS Schedules Process
        /// </summary>
        public const string CSSchedules = "233";

        /// <summary>
        /// Print Check
        /// </summary>
        public const string CSPrintCheck = "234";

        /// <summary>
        /// TaxGroup
        /// </summary>
        public const string TaxGroup = "235";

        /// <summary>
        /// CS Reminder List
        /// </summary>
        public const string CSReminderList = "236";

        #endregion

        #region GL 401-600
        /// <summary>
        /// The source journal profile
        /// </summary>
        public const string SourceJournalProfile = "401";

        /// <summary>
        /// The recurring entries
        /// </summary>
        public const string RecurringEntry = "402";

        /// <summary>
        /// The source code
        /// </summary>
        public const string SourceCode = "403";

        /// <summary>
        /// The account structures
        /// </summary>
        public const string AccountStructures = "404";

        /// <summary>
        /// The account groups
        /// </summary>
        public const string AccountGroups = "405";

        /// <summary>
        /// GL Optional Field
        /// </summary>
        public const string OptionalField = "406";

        /// <summary>
        /// The accounts
        /// </summary>
        public const string Accounts = "407";

        /// <summary>
        /// The batch list
        /// </summary>
        public const string BatchList = "409";

        /// <summary>
        /// The create new year
        /// </summary>
        public const string CreateNewYear = "410";

        /// <summary>
        /// The period end maintenance
        /// </summary>
        public const string PeriodEndMaintenance = "411";

        /// <summary>
        /// The create recurring entries batch
        /// </summary>
        public const string CreateRecurringEntriesBatch = "412";

        /// <summary>
        /// The batch listing
        /// </summary>
        public const string BatchListing = "413";

        /// <summary>
        /// The account group sort order
        /// </summary>
        public const string AccountGroupSortOrder = "414";

        /// <summary>
        /// The transaction listing
        /// </summary>
        public const string TransactionListing = "415";

        /// <summary>
        /// The post journal
        /// </summary>
        public const string PostJournal = "416";

        /// <summary>
        /// The posting journal
        /// </summary>
        public const string PostingJournal = "417";


        /// <summary>
        /// The batch status
        /// </summary>
        public const string BatchStatus = "418";

        /// <summary>
        /// The segment code
        /// </summary>
        public const string SegmentCode = "419";

        /// <summary>
        /// The journal entries
        /// </summary>
        public const string JournalEntries = "422";

        /// <summary>
        /// The chart of accounts
        /// </summary>
        public const string ChartOfAccounts = "422";

        /// <summary>
        /// The trial balance
        /// </summary>
        public const string TrialBalance = "423";

        /// <summary>
        /// The transaction details optional field
        /// </summary>
        public const string TransactionDetailsOptionalField = "424";

        /// <summary>
        /// The Account Group report
        /// </summary>
        public const string AccountGroupReport = "425";

        /// <summary>
        /// The rate type
        /// </summary>
        public const string RateType = "430";

        /// <summary>
        /// GL Options
        /// </summary>
        public const string GLOptions = "436";

        /// <summary>
        /// Check Payment Register Report
        /// </summary>
        public const string CheckPaymentRegister = "437";

        /// <summary>
        /// ReconciliationPostingJournal Report
        /// </summary>
        public const string ReconciliationPostingJournal = "438";

        /// <summary>
        /// Reverse Transaction screen
        /// </summary>
        public const string ReverseTransaction = "439";

        /// <summary>
        /// Cprs Amount checking
        /// </summary>
        public const string CprsAmountChecking = "440";

        /// <summary>
        /// The Gl transaction
        /// </summary>
        public const string GLTransaction = "441";

        /// <summary>
        /// Clear History
        /// </summary>
        public const string GLClearHistory = "442";

        /// <summary>
        /// Create Allocation Batch
        /// </summary>
        public const string GLCreateAllocationBatch = "443";

        /// <summary>
        /// Source Journal Profile Report
        /// </summary>
        public const string GLSourceJournalProfileReport = "444";

        /// <summary>
        /// Compute Fiscal Set Comparison
        /// </summary>
        public const string GLComputeFiscalSetComparison = "445";

        #region GLSourceCodeReport

        /// <summary>
        /// Source Code Report
        /// </summary>
        public const string GLSourceCodeReport = "446";

        #endregion

        public const string SourceJournal = "447";

        public const string CreateAccountPreview = "448";

        /// <summary>
        /// Revaluation Code
        /// </summary>
        public const string RevaluationCode = "449";

        /// <summary>
        /// CreateAccountsReport
        /// </summary>
        public const string CreateAccountsReport = "450";

        /// <summary>
        /// GLCreateAccount
        /// </summary>
        public const string GLCreateAccount = "451";

        #endregion

        #region AR 601-800

        /// <summary>
        /// AR-Receipt Entry
        /// </summary>
        public const string ReceiptEntry = "601";

        /// <summary>
        /// AR - Invoice Entry
        /// </summary>
        public const string ARInvoiceEntry = "602";

        /// <summary>
        /// AR GL Integration
        /// </summary>
        public const string ARGLIntegration = "603";

        /// <summary>
        /// AR-Invoice Batch List
        /// </summary>
        public const string ARInvoiceBatchList = "604";

        /// <summary>
        /// AR-Interest Profile
        /// </summary>
        public const string InterestProfile = "605";

        /// <summary>
        /// AR Item Sales Hist Rpt
        /// </summary>
        public const string ARItemSalesHistRpt = "606";

        /// <summary>
        /// A/R - G/L Transaction report
        /// </summary>
        public const string ARGLTransactions = "94";

        /// <summary>
        /// A/R - G/L Transaction report
        /// </summary>
        public const string ARCreateInterestBatch = "607";

        /// <summary>
        /// A/R - Customer Transactions Report
        /// </summary>
        public const string ARCustTransRpt = "608";

        /// <summary>
        /// AR- Payment Info Screen Name
        /// </summary>
        public const string PaymentInfo = "609";


        /// <summary>
        /// A/R - Batch Listing Report
        /// </summary>
        public const string ARBatchListingRpt = "610";

        /// <summary>
        /// A/R - Update Print Status
        /// </summary>
        public const string ARUpdatePrintStatus = "611";

        /// <summary>
        /// A/R -Receipt Batch List
        /// </summary>
        public const string ReceiptBatchList = "612";

        /// <summary>
        /// A/R - Select Customer
        /// </summary>
        public const string ARSelectCustomer = "613";

        /// <summary>
        /// A/R -Receipt
        /// </summary>
        public const string Receipt = "614";

        /// <summary>
        /// A/R -Invoice
        /// </summary>
        public const string ARInvoice = "615";
        /// <summary>
        /// A/R -ShipToLocation
        /// </summary>
        public const string ShipToLocation = "616";

        /// <summary>
        /// A/R - Customer Report
        /// </summary>
        public const string ARCustomerReport = "617";

        /// <summary>
        /// AR- Customer Screen Name
        /// </summary>
        public const string Customer = "618";

        /// <summary>
        /// AR Age Document Process Screen
        /// </summary>
        public const string ARAgeDocument = "619";

        /// <summary>
        /// AR - Aged Trial Balance Report Screen
        /// </summary>
        public const string ARAgedTrialBalance = "620";

        /// <summary>
        /// AR national account screen
        /// </summary>
        public const string NationalAccount = "621";

        ///<summary>
        /// CS Optional Fields
        /// </summary>
        public const string CSOptionalField = "622";

        /// <summary>
        /// Deposit Status Report
        /// </summary>
        public const string DepositStatus = "623";

        /// <summary>
        /// Deposit Status Report
        /// </summary>
        public const string BankTransfer = "624";

        /// <summary>
        /// Print Check Screen
        /// </summary>
        public const string PrintCheck = "625";

        /// <summary>
        /// AR- Label for Customer Report
        /// </summary>
        public const string ARLabel = "626";

        /// <summary>
        /// AR- Aged Retainage for Report
        /// </summary>
        public const string AgedRetainage = "627";

        /// <summary>
        /// AR- Aged Retainage Document 
        /// </summary>
        public const string ARAgedRetainageDocument = "628";

        /// <summary>
        /// Statement/Label/Letters Report
        /// </summary>
        public const string CreateStatement = "629";

        /// <summary>
        /// Invoice Batch List
        /// </summary>
        public const string InvoiceBatchList = "630";

        /// <summary>
        ///AR Email Messages
        /// </summary>
        public const string EmailMessage = "631";

        /// <summary>
        ///AR Sales Person
        /// </summary>
        public const string Salesperson = "632";

        /// <summary>
        /// Check Register
        /// </summary>
        public const string CheckRegister = "633";

        /// <summary>
        /// AR account set
        /// </summary>
        public const string ARAccountSet = "634";

        /// <summary>
        /// Payment Invoice Batch List
        /// </summary>
        public const string PaymentInvoiceBatchList = "635";

        /// <summary>
        /// The Dunning Messages
        /// </summary>
        public const string DunningMessages = "636";

        /// <summary>
        /// Vendor groups
        /// </summary>
        public const string VendorGroups = "637";

        /// <summary>
        ///  AR Transaction Post Batch
        /// </summary>
        public const string ARPostBatch = "638";

        /// <summary>
        ///Transaction History Inquiry
        /// </summary>
        public const string TransactionHistoryInquiry = "639";

        /// <summary>
        ///Transaction History Inquiry Report
        /// </summary>
        public const string TransactionHistoryInquiryReport = "640";

        /// <summary>
        /// Pre Payment
        /// </summary>
        public const string ARPrePayment = "641";

        /// <summary>
        /// The Distribution Code
        /// </summary>
        public const string DistributionCode = "642";

        /// <summary>
        ///  /// The Payment Code
        /// </summary>
        public const string PaymentCode = "643";

        /// <summary>
        /// The comment type
        /// </summary>
        public const string CommentType = "644";

        /// <summary>
        /// The billing cycle
        /// </summary>
        public const string BillingCycle = "645";

        /// <summary>
        /// Terms
        /// </summary>
        public const string Terms = "646";

        /// <summary>
        /// Customer Inquiry
        /// </summary>
        public const string CustomerInquiry = "647";

        /// <summary>
        /// AR-Adjustment Entry
        /// </summary>
        public const string AdjustmentEntry = "648";

        /// <summary>
        /// AR-Deposit Slip
        /// </summary>
        public const string ARDepositSlip = "649";

        /// <summary>
        /// AR Optional Field
        /// </summary>
        public const string AROptionField = "650";

        /// <summary>
        /// AR Receipt Inquiry
        /// </summary>
        public const string ReceiptInquiry = "651";

        /// <summary>
        /// AR Revaluation
        /// </summary>
        public const string ARRevaluation = "652";

        /// <summary>
        /// AR RevaluationHistory
        /// </summary>
        public const string ARRevaluationHistory = "653";

        /// <summary>
        /// AR Receipt Inquiry
        /// </summary>
        public const string ReceiptInquiryReport = "654";

        /// <summary>
        /// Customer Group
        /// </summary>
        public const string CustomerGroup = "655";

        /// <summary>
        /// Options
        /// </summary>
        public const string Options = "656";

        /// <summary>
        /// Payment
        /// </summary>
        public const string Payment = "657";

        /// <summary>
        /// ARBatchStatus
        /// </summary>
        public const string ARBatchStatus = "658";

        /// <summary>
        /// AR Refund Inquiry
        /// </summary>
        public const string RefundInquiry = "659";

        /// <summary>
        /// The create recurring charge batch
        /// </summary>
        public const string ARCreateRecurringCharge = "660";

        /// <summary>
        /// AR Posting Journal Report
        /// </summary>
        public const string ARPostingJournalReport = "661";

        /// <summary>
        /// AR Posting Journal Report
        /// </summary>
        public const string ARCreateRetainageBatch = "662";

        /// <summary>
        /// AR Refund Inquiry
        /// </summary>
        public const string RefundInquiryReport = "663";

        /// <summary>
        /// AR-Quick Receipt Entry
        /// </summary>
        public const string QuickReceiptEntry = "664";

        /// <summary>
        /// AR Create Write Off Batch
        /// </summary>
        public const string ARCreateWriteOffBatch = "665";

        /// <summary>
        ///  AR Refund Entry
        /// </summary>
        public const string ARRefundEntry = "666";

        /// <summary>
        /// Payment ARPaymentInformation
        /// </summary>
        public const string ARPaymentInformation = "667";

        /// <summary>
        /// AR Document Inquiry
        /// </summary>
        public const string DocumentInquiry = "668";

        /// <summary>
        ///  AR Clear History
        /// </summary>
        public const string ARClearHistory = "669";

        /// <summary>
        /// Receipt Information
        /// </summary>
        public const string ReceiptInformation = "670";

        /// <summary>
        /// AR Clear Statistic
        /// </summary>
        public const string ARClearStatistic = "671";


        /// <summary>
        /// AR Adjustment
        /// </summary>
        public const string ARAdjustmentBatchList = "700";


        /// <summary>
        /// AR Delete Inactive Record
        /// </summary>
        public const string ARDeleteInactiveRecord = "701";


        /// <summary>
        /// AR National Account Report
        /// </summary>
        public const string ARNationalAccountReport = "702";

        /// <summary>
        /// AR National Account Report
        /// </summary>
        public const string ARShipToLocationReport = "703";

        /// <summary>
        /// AR Recurring Charge screen
        /// </summary>
        public const string ARRecurringCharge = "704";

        /// <summary>
        /// AR Recurring Charge Create Invoice screen
        /// </summary>
        public const string ARCreateInvoice = "705";

        /// <summary>
        /// AR Update Recurring Charge screen
        /// </summary>
        public const string ARUpdateRecurringCharge = "706";

        #endregion

        #region AP 801-1000

        /// <summary>
        /// The Email Message
        /// </summary>
        public const string EmailMessages = "801";

        /// <summary>
        /// Recurring Payable
        /// </summary>
        public const string RecurringPayable = "802";

        /// <summary>
        /// Recurring Payable
        /// </summary>
        public const string CreateInvoice = "803";

        /// <summary>
        /// CreateRecurringPayableBatch
        /// </summary>
        public const string CreateRecurringPayableBatch = "804";

        /// <summary>
        ///Process Year End 
        /// </summary>
        public const string ProcessYearEnd = "805";

        /// <summary>
        /// Create GL Batch
        /// </summary>
        public const string CreateGLBatch = "806";

        /// <summary>
        /// AP Transaction PostBatch
        /// </summary>
        public const string APPostBatch = "807";

        /// <summary>
        /// AR Create GL Batch 
        /// </summary>
        public const string ARCreateGLBatch = "808";

        /// <summary>
        /// The Payment Code
        /// </summary>
        public const string PaymentCodes = "809";

        /// <summary>
        /// The CPRS Code
        /// </summary>
        public const string CPRSCode = "810";

        /// <summary>
        /// The Account Set
        /// </summary>
        public const string AccountSet = "811";

        /// <summary>
        /// AP Options
        /// </summary>
        public const string APOptions = "812";

        /// <summary>
        /// The bank distribution set
        /// </summary>
        public const string DistributionSet = "813";

        /// <summary>
        /// Aged Payable Reports
        /// </summary>
        public const string AgeDocument = "814";

        /// <summary>
        /// Aged Cash Requirement
        /// </summary>
        public const string AgedCashRequirement = "815";

        /// <summary>
        /// AP VendorsReport
        /// </summary>
        public const string APVendorsReport = "816";

        /// <summary>
        /// AP VendorReport
        /// </summary>
        public const string APVendorReport = "817";

        /// <summary>
        /// AP Letter And Label Report
        /// </summary>
        public const string LetterAndLabel = "818";

        /// <summary>
        /// AP Age Retainage
        /// </summary>
        public const string AgedRetainageReport = "819";

        /// <summary>
        /// Payment Batch List
        /// </summary>
        public const string PaymentBatchList = "820";

        /// <summary>
        /// Age Document
        /// </summary>
        public const string APAgedPayable = "821";

        /// <summary>
        /// Age Cash Requirement
        /// </summary>
        public const string APAgedCashRequirement = "822";

        /// <summary>
        /// AP Aged Retainage for processing
        /// </summary>
        public const string AgeRetainageDocument = "823";

        /// <summary>
        /// Create Payment Batch
        /// </summary>
        public const string CreatePaymentBatch = "824";

        /// <summary>
        /// Payment Selection Code
        /// </summary>
        public const string PaymentSelectionCode = "825";

        /// <summary>
        /// AP GL Integration
        /// </summary>
        public const string APGLIntegration = "826";

        /// <summary>
        /// AP Integrity Check for AS Data Integrity
        /// </summary>
        public const string IntegrityChecker = "827";

        /// <summary>
        /// APTerms
        /// </summary>
        public const string APTerms = "828";

        /// <summary>
        /// The control payments
        /// </summary>
        public const string ControlPayment = "829";

        /// <summary>
        /// Payment Inquiry Report
        /// </summary>
        public const string PaymentInquiryReport = "830";

        /// <summary>
        /// Payment Entry
        /// </summary>
        public const string PaymentEntry = "831";

        /// <summary>
        /// The print T5018 CPRS report
        /// </summary>
        public const string PrintT5018CprsReport = "832";

        /// <summary>
        /// AP1099CPRS Enquiry
        /// </summary>
        public const string AP1099CPRSEnquiryReport = "833";

        /// <summary>
        /// The ap optional field
        /// </summary>
        public const string APOptionalField = "834";

        /// <summary>
        /// CreateRecurringPayableBatch
        /// </summary>
        public const string CPRSElectronicFiling = "834";

        /// <summary>
        /// Posting Error
        /// </summary>
        public const string PostingError = "835";

        /// <summary>
        /// ElectronicFilingReport
        /// </summary>
        public const string ElectronicFilingReport = "836";

        /// <summary>
        /// Payment Inquiry
        /// </summary>
        public const string PaymentInquiry = "837";

        /// <summary>
        /// A/P - Batch Listing Report
        /// </summary>
        public const string APBatchListingRpt = "838";

        /// <summary>
        /// AP Print 1099/1096 Form Report
        /// </summary>
        public const string APPrint10991096Form = "839";

        /// <summary>
        /// AP Vendor Transaction Report
        /// </summary>
        public const string VendorTransaction = "840";

        /// <summary>
        /// AP Vendor Activity Document Information
        /// </summary>
        public const string DocumentInformation = "841";

        /// <summary>
        /// AP Vendor Activity Document Details
        /// </summary>
        public const string DocumentDetails = "842";

        /// <summary>
        /// CPRSAmount
        /// </summary>
        public const string CPRSAmount = "843";

        /// <summary>
        /// CPRSAmount
        /// </summary>
        public const string InvoicePrepayment = "844";

        /// <summary>
        /// The vendor
        /// </summary>
        public const string Vendor = "845";

        /// <summary>
        /// AP Invoice Entry
        /// </summary>
        public const string APInvoiceEntry = "846";

        /// <summary>
        /// Vendor Activity
        /// </summary>
        public const string VendorActivity = "847";

        /// <summary>
        /// AP Revaluation
        /// </summary>
        public const string APRevaluation = "848";

        /// <summary>
        /// AP RevaluationHistory
        /// </summary>
        public const string APRevaluationHistory = "849";

        /// <summary>
        /// AP RecurringPayable Report
        /// </summary>
        public const string APRecurringPayableReport = "850";

        /// <summary>
        /// AP Vendor Group Report
        /// </summary>
        public const string APVendorGroupReport = "851";

        /// <summary>
        /// Payment Information
        /// </summary>
        public const string PaymentInformation = "852";

        /// <summary>
        /// AP PostingJournal Report
        /// </summary>
        public const string APPostingJournalReport = "853";

        /// <summary>
        /// AP Delete Inactive Record
        /// </summary>
        public const string APDeleteInactiveRecord = "854";

        /// <summary>
        /// AP BatchStatusReport
        /// </summary>
        public const string BatchStatusReport = "855";

        /// <summary>
        /// AP BatchStatusReport
        /// </summary>
        public const string APRemitToLocation = "856";

        /// <summary>
        /// Remit-To Location 
        /// </summary>
        public const string RemitToLocation = "857";

        /// <summary>
        /// Remit-To Location Detail
        /// </summary>
        public const string RemitToLocationDetail = "858";

        /// <summary>
        /// AP Create Retainage Document Batch
        /// </summary>
        public const string APCreateRetainageDocumentBatch = "859";

        /// <summary>
        /// The adjustment batch list
        /// </summary>
        public const string AdjustmentBatchList = "860";

        /// <summary>
        /// AP Adjustment Entry
        /// </summary>
        public const string APAdjustmentEntry = "861";

        /// <summary>
        ///  AR Clear History
        /// </summary>
        public const string APClearHistory = "862";

        /// <summary>
        /// Screen Name AP Clear Statistic
        /// </summary>
        public const string APClearStatistic = "863";
        #endregion

        #region IC 1001-1200

        /// <summary>
        /// Category
        /// </summary>
        public const string Category = "1001";

        /// <summary>
        /// The Day End processing
        /// </summary>
        public const string DayEndProcessing = "1002";

        /// <summary>
        /// The Create GL Batch
        /// </summary>
        public const string CreateGLBatchIC = "1003";

        /// <summary>
        /// IC Optional Fields
        /// </summary>
        public const string ICOptionalFields = "1004";

        /// <summary>
        /// IC Price List
        /// </summary>
        public const string PriceList = "1005";

        /// <summary>
        /// IC Posting Journal
        /// </summary>
        public const string ICPostingJournal = "1006";

        /// <summary>
        /// The Item 
        /// </summary>
        public const string Item = "1007";

        /// <summary>
        /// AR PostingError Issues
        /// </summary>
        public const string ARPostingError = "1008";

        /// <summary>
        /// AR PostingError Issues
        /// </summary>
        public const string TransferPostingJournal = "1009";

        /// <summary>
        /// IC Selling Price Margin
        /// </summary>
        public const string SellingPriceMargin = "1010";

        /// <summary>
        /// IC Reorder
        /// </summary>
        public const string Reorder = "1011";

        /// <summary>
        /// IC G/L Integration
        /// </summary>
        public const string ICGLIntegration = "1012";

        /// <summary>
        /// IC Shipment
        /// </summary>
        public const string Shipment = "1013";

        /// <summary>
        /// IC Transaction Statistics
        /// </summary>
        public const string TransactionStatistics = "1014";
        /// <summary>
        /// IC Sale Statistics
        /// </summary>
        public const string SalesStatistic = "1015";

        /// <summary>
        /// IC Transaction Statistics Report
        /// </summary>
        public const string TransactionStatisticsReport = "1016";

        /// <summary>
        /// IC Receipt
        /// </summary>
        public const string ICReceipt = "1017";

        /// <summary>
        /// IC Price List
        /// </summary>
        public const string ICAlternateItemReport = "1018";

        /// <summary>
        /// IC Inventory Counts
        /// </summary>
        public const string InventoryCount = "1019";

        /// <summary>
        /// Inventory Movement
        /// </summary>
        public const string InventoryMovement = "1020";

        /// <summary>
        /// Cprs Amount checking
        /// </summary>
        public const string ICContractPricing = "1021";

        /// <summary>
        /// TransactionListReport
        /// </summary>
        public const string GLTransactionReport = "1022";

        /// <summary>
        /// IC Markup Analysis
        /// </summary>
        public const string MarkupAnalysis = "1023";

        /// <summary>
        /// InventoryWorksheet
        /// </summary>
        public const string InventoryWorksheet = "1024";

        /// <summary>
        /// IC Adjustment
        /// </summary>
        public const string Adjustment = "1025";

        /// <summary>
        /// Aged Inventory
        /// </summary>
        public const string AgedInventory = "1026";

        /// <summary>
        /// IC TransactionListing
        /// </summary>
        public const string ICTransactionListing = "1027";

        /// <summary>
        /// InventoryWorksheet
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string LIFOFIFO = "1028";

        /// <summary>
        /// InventoryWorksheet
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string LIFOFIFOInquiryInformation = "1029";

        /// <summary>
        ///Transaction History Inquiry
        /// </summary>
        public const string ICTransactionHistoryInquiry = "1030";

        /// <summary>
        /// BinShelf Label
        /// </summary>
        public const string BinShelfLabel = "1031";

        /// <summary>
        ///Transaction History Inquiry
        /// </summary>
        public const string ICUpdateItemPricing = "1032";

        /// <summary>
        ///Item Pricing
        /// </summary>
        public const string ItemPricing = "1049";

        /// <summary>
        /// IC - Generate Inventory Worksheet
        /// </summary>
        public const string ICGenerateInventoryWorksheet = "1033";
        /// <summary>
        /// IC-Transfer Screen
        /// </summary>
        public const string ICTransfer = "1034";

        /// <summary>
        /// IC-Transaction History Report
        /// </summary>
        public const string ICTransactionHistoryReport = "1035";

        /// <summary>
        /// IC Slow Moving Items
        /// </summary>
        public const string SlowMovingItems = "1036";

        /// <summary>
        /// IC Item Valuation
        /// </summary>
        public const string ItemValuation = "1037";

        /// <summary>
        /// IC Inventory Reconciliation Report
        /// </summary>
        public const string InvtReconciliation = "1038";

        /// <summary>
        /// IC Item Valuation
        /// </summary>
        public const string ItemLocationDocument = "1039";

        /// <summary>
        /// IC Post Transaction
        /// </summary>
        public const string PostTransaction = "1040";

        /// <summary>
        ///IC Stock ransaction Inquiry
        /// </summary>
        public const string ICStockTransactionInquiry = "1041";

        /// <summary>
        /// IC Transfer Slip
        /// </summary>
        public const string ICTransferSlip = "1042";

        /// <summary>
        /// IC Overstocked Items 
        /// </summary>
        public const string OverstockedItems = "1043";

        /// <summary>
        /// IC StockTransactions  
        /// </summary>
        public const string StockTransaction = "1044";

        /// <summary>
        /// IC SalesStatistics
        /// </summary>
        public const string ICSalesStatistics = "1045";

        /// <summary>
        /// IC Item Label  
        /// </summary>
        public const string ItemLabel = "1046";

        /// <summary>
        /// IC Physical Inventory Quantities
        /// </summary>
        public const string PhysicalInvQuantity = "1047";

        /// <summary>
        /// IC Item Status Report
        /// </summary>
        public const string ItemStatus = "1048";

        /// <summary>
        /// IC InternalUsage
        /// </summary>
        public const string ICInternalUsage = "1049";

        /// <summary>
        /// IC WarrantyContractList
        /// </summary>
        public const string ICWarrantyContractList = "1050";

        /// <summary>
        /// IC Serial Number Inquiry
        /// </summary>
        public const string ICSerialNumberInquiry = "1051";

        /// <summary>
        /// IC Process Adjustment
        /// </summary>
        public const string ICProcessAdjustment = "1052";

        /// <summary>
        /// IC Recall
        /// </summary>
        public const string Recall = "1053";

        /// <summary>
        /// IC Options
        /// </summary>
        public const string ICOptions = "1054";

        /// <summary>
        /// IC Account Sets
        /// </summary>
        public const string ICAccountSets = "1055";

        /// <summary>
        /// IC Item Pricing Detail
        /// </summary>
        public const string ItemPricingDetail = "1056";

        /// <summary>
        /// IC Item Structure
        /// </summary>
        public const string ItemStructure = "1057";

        /// <summary>
        /// IC Kitting Item
        /// </summary>
        public const string KittingItem = "1058";

        /// <summary>
        /// IC Locations
        /// </summary>
        public const string ICLocations = "1059";

        /// <summary>
        /// IC Location Details
        /// </summary>
        public const string LocationDetails = "1060";

        /// <summary>
        /// Manufacturers Items
        /// </summary>
        public const string ManufacturersItems = "1061";

        /// <summary>
        /// Price List Codes
        /// </summary>
        public const string PriceListCodes = "1062";

        /// <summary>
        /// IC Segment Code
        /// </summary>
        public const string ICSegmentCode = "1063";

        /// <summary>
        /// Units of Measure
        /// </summary>
        public const string UnitsOfMeasure = "1064";

        /// <summary>
        /// Weight Units of Measure
        /// </summary>
        public const string WeightUnitOfMeasure = "1065";

        /// <summary>
        /// ICCurrentTransactionsInquiryfor
        /// </summary>
        public const string ICCurrentTransactionsInquiryfor = "1066";

        /// <summary>
        /// IC SerialLotList
        /// </summary>
        public const string ICSerialLotList = "1067";

        /// <summary>
        /// ICSerialNumberTranssctionInquiry
        /// </summary>
        public const string ICSerialNumberTransactionInquiry = "1068";

        /// <summary>
        /// SerialLotTransaction Report
        /// </summary>
        public const string ICSerialLotTransaction = "1069";

        /// <summary>
        /// Customer Detail Report
        /// </summary>
        public const string CustomerDetailReport = "1070";

        /// <summary>
        /// IC LotRecallRelease
        /// </summary>
        public const string ICLotRecallRelease = "1071";

        /// <summary>
        /// IC ConstructItem
        /// </summary>
        public const string ConstructItem = "1072";

        /// <summary>
        /// IC CustomerDetail
        /// </summary>
        public const string CustomerDetail = "1073";

        /// <summary>
        /// IC ItemWizard
        /// </summary>
        public const string ItemWizard = "1074";

        /// <summary>
        /// IC WizardVendorDetail
        /// </summary>
        public const string WizardVendorDetail = "1075";

        /// <summary>
        /// IC ReceiptCost
        /// </summary>
        public const string ReceiptCost = "1076";

        /// <summary>
        /// IC VendorDetail
        /// </summary>
        public const string VendorDetail = "1077";


        /// <summary>
        /// ICLotNumberTransactionInquiry
        /// </summary>
        public const string ICLotNumberTransactionInquiry = "1078";

        /// <summary>
        /// IC Account Set Report
        /// </summary>
        public const string ICAccountSetReport = "1079";

        /// <summary>
        /// IC Location Report
        /// </summary>
        public const string ICLocationReport = "1080";

        /// <summary>
        /// IC Price List Code Report
        /// </summary>
        public const string ICPriceListCodeReport = "1081";

        /// <summary>
        /// IC Category Report
        /// </summary>
        public const string ICCategoryReport = "1082";

        /// <summary>
        /// IC Kitting Item Report
        /// </summary>
        public const string ICKittingItemReport = "1083";

        /// <summary>
        /// IC Vendor Detail Report
        /// </summary>
        public const string VendorDetailReport = "1084";

        /// <summary>
        /// IC Lot Number Inquiry
        /// </summary>
        public const string ICLotNumberInquiry = "1085";
        /// <summary>
        /// IC Reorder Quantity Report
        /// </summary>
        public const string ICReorderQuantityReport = "1086";

        /// <summary>
        /// ICQuarantine
        /// </summary>
        public const string ICQuarantine = "1087";

        /// <summary>
        /// IC Delete Inactive Record
        /// </summary>
        public const string ICDeleteInactiveRecord = "1088";

        /// <summary>
        /// IC Bills of Material Report
        /// </summary>
        public const string BillsOfMaterialReport = "1089";

        /// <summary>
        /// The ic restart
        /// </summary>
        public const string ICRestart = "1089";

        /// <summary>
        /// IC Assembly
        /// </summary>
        public const string ICAssembly = "1090";

        /// <summary>
        /// IC ClearHistory
        /// </summary>
        public const string ICClearHistory = "1091";

        /// <summary>
        /// IC Lot Number 
        /// </summary>
        public const string ICInventoryLotNumber = "1092";

        /// <summary>
        /// IC Copy Item Pricing
        /// </summary>
        public const string ICCopyItemPricing = "1094";

        /// <summary>
        /// ICSerialLotQoh
        /// </summary>
        public const string ICSerialLotQoh = "1095";

        /// <summary>
        /// Contract Pricing
        /// </summary>
        public const string ContractPricing = "1096";

        /// <summary>
        /// IC Serial Registration
        /// </summary>
        public const string ICSerialRegistration = "1097";

        /// <summary>
        /// IC Serial Lot Reconciliation
        /// </summary>
        public const string ICSerialLotReconciliation = "1098";

        /// <summary>
        /// IC Contract Code
        /// </summary>
        public const string ICContractCode = "1099";

        /// <summary>
        /// IC Bill Of Material Component Usage Inquiry
        /// </summary>
        public const string ICBOMComponentUsageInquiry = "1100";

        /// <summary>
        /// IC Copy Bills Of Material
        /// </summary>
        public const string ICCopyBillsOfMaterial = "1101";

        #endregion

        #region OE 1201-1400

        /// <summary>
        /// Sales Statistics Report
        /// </summary>
        public const string SalesStatisticsReport = "1201";

        /// <summary>
        /// OE- InvoiceActionReport Screen Name
        /// </summary>
        public const string InvoiceActionReport = "1202";

        /// <summary>
        ///OE-- CreateBatchOE
        /// </summary>
        public const string CreateBatchOE = "1203";

        /// <summary>
        /// OE-AgedOrder Report
        /// </summary>
        public const string AgedOrderReport = "1204";

        /// <summary>
        /// OE-ReportService Process
        /// </summary>
        public const string ReportServiceProcess = "1205";

        /// <summary>
        /// OE-Screen Name
        /// </summary>
        public const string OrderEntry = "1206";

        /// <summary>
        /// The credit debit note entry
        /// </summary>
        public const string CreditDebitNoteEntry = "1207";

        /// <summary>
        /// Sales History
        /// </summary>
        public const string SalesHistory = "1208";

        /// <summary>
        /// OE-SalespersonCommissions Report
        /// </summary>
        public const string SalespersonCommissionsReport = "1209";

        /// <summary>
        /// TransactionListReport
        /// </summary>
        public const string TransactionListReport = "1210";

        /// <summary>
        /// TransactionListReport
        /// </summary>
        public const string OeGlTransactionReport = "1211";

        /// <summary>
        /// OE GL Integration
        /// </summary>
        public const string OEGLIntegration = "1212";
        /// <summary>
        ///OE-- ClearHistoryOE
        /// </summary>
        public const string ClearHistoryOE = "1213";

        /// <summary>
        /// OE- OrderActionReport Screen Name
        /// </summary>
        public const string OrderActionReport = "1214";

        /// <summary>
        /// OE- QuotesReport Screen Name
        /// </summary>
        public const string QuotesReport = "1215";

        /// <summary>
        /// OE - Order Confirmations Report
        /// </summary>
        public const string OrderConfirmationReport = "1216";

        /// <summary>
        ///OE Email Messages
        /// </summary>
        public const string OEEmailMessage = "1217";

        /// <summary>
        /// OE Credit Debit Note
        /// </summary>
        public const string OECreditDebitNote = "1218";

        /// <summary>
        /// OE-ShipViaCode
        /// </summary>
        public const string OEShipViaCode = "1220";

        /// <summary>
        /// OE-ShipViaCode
        /// </summary>
        public const string ShippingLabel = "1221";

        /// <summary>
        /// Sales person inquiry
        /// </summary>
        public const string SalesPersonInquiry = "1222";

        /// <summary>
        /// OE-CurrentOrderInquiry
        /// </summary>
        public const string OECurrentOrderInquiry = "1223";

        /// <summary>
        /// OE - Invoice Report
        /// </summary>
        public const string OEInvoiceReport = "1224";

        /// <summary>
        /// OE - Sale Statistics
        /// </summary>
        public const string OESalesStatistic = "1225";

        /// <summary>
        /// OE- Sales History Report
        /// </summary>
        public const string SalesHistoryReport = "1226";

        /// <summary>
        /// OE- Picking Slips Report
        /// </summary>
        public const string PickingSlipReport = "1227";

        /// <summary>
        /// OE- Pending Shipment Inquiry
        /// </summary>
        public const string PendingShipmentInquiry = "1228";

        /// <summary>
        /// OE-Email Message Report
        /// </summary>
        public const string EmailMessageReport = "1229";

        /// <summary>
        /// Copy Order
        /// </summary>
        public const string CopyOrder = "1230";

        /// <summary>
        /// OE Optional Field
        /// </summary>
        public const string OEOptionField = "1231";

        /// <summary>
        /// OE MiscellaneousCharge
        /// </summary>
        public const string MiscellaneousCharge = "1232";

        /// <summary>
        /// OE Options
        /// </summary>
        public const string OEOptions = "1233";

        /// <summary>
        /// OE Template
        /// </summary>
        public const string Template = "1234";

        /// <summary>
        /// OE-ShipmentEntry
        /// </summary>
        public const string ShipmentEntry = "1235";

        /// <summary>
        /// OE- Invoice Entry
        /// </summary>
        public const string OEInvoiceEntry = "1236";
        #endregion

        #region PO 1401-1600

        /// <summary>
        /// The Create Batch
        /// </summary>
        public const string CreateBatchPO = "1401";

        /// <summary>
        /// The Gl Integration
        /// </summary>
        public const string POGLIntegration = "1402";

        /// <summary>
        /// P/O Options
        /// </summary>
        public const string POOptions = "1403";

        /// <summary>
        /// P/O Ship-Via Code
        /// </summary>
        public const string POShipViaCode = "1404";

        /// <summary>
        /// PO - Clear History Superview
        /// </summary>
        public const string POClearHistory = "1405";

        /// <summary>
        /// TransactionListReport
        /// </summary>
        public const string PoGlTransactionReport = "1406";

        /// <summary>
        /// PO PayableClrAuditList
        /// </summary>
        public const string POPayableClrAuditList = "1407";
        /// <summary>
        /// PO Shippable BackOrders Report
        /// </summary>
        public const string POShippableBackOrdersReport = "1408";

        /// <summary>
        /// PO PostingJournal Rpt
        /// </summary>
        public const string POPostingJournal = "1409";

        /// <summary>
        /// PO Create POs from IC
        /// </summary>
        public const string CreatePOsFromIC = "1410";

        /// <summary>
        /// PO Create POs From Requisition
        /// </summary>
        public const string CreatePOsFromRequisition = "1411";

        /// <summary>
        /// PO Transaction List Report
        /// </summary>
        public const string POTransactionList = "1422";

        /// <summary>
        /// PO Create POs from OE
        /// </summary>
        public const string CreatePOsFromOE = "1423";

        /// <summary>
        /// PO Purchase History Report 
        /// </summary>
        public const string POPurchaseHistoryReport = "1424";
        /// <summary>
        /// PO Create POs From Requisition
        /// </summary>
        public const string POAdditionalCost = "1412";

        /// <summary>
        /// PO PurchaseOrder Report
        /// </summary>
        public const string PurchaseOrderReport = "1425";

        /// <summary>
        /// PO Return Report
        /// </summary>
        public const string POReturnReport = "1426";
        /// <summary>
        /// PO Requisition Entry
        /// </summary>
        public const string PORequisitionEntry = "1427";

        /// <summary>
        /// The purchase order entry
        /// </summary>
        public const string PurchaseOrderEntry = "1428";

        /// <summary>
        /// The purchase order entry
        /// </summary>
        public const string POInvoiceEntry = "1429";
        /// <summary>
        /// The purchase order Receipt entry
        /// </summary>
        public const string POReceiptEntry = "1430";

        /// <summary>
        /// The purchase order Action Report
        /// </summary>
        public const string POPurchaseOrderAction = "1431";

        /// <summary>
        /// PO CreditDebitNote Entry
        /// </summary>
        public const string POCreditDebitNoteEntry = "1432";

        /// <summary>
        /// PO Return Entry
        /// </summary>
        public const string POReturnEntry = "1433";

        /// <summary>
        /// PO Return Entry
        /// </summary>
        public const string MailingLabelReport = "1434";

        /// <summary>
        /// PO Vendor Contract Cost
        /// </summary>
        public const string VendorContractCost = "1435";

        /// <summary>
        /// Mailing Label Process
        /// </summary>
        public const string MailingLabelProcess = "1436";

        /// <summary>
        /// Purchase History
        /// </summary>
        public const string PurchaseHistory = "1437";

        /// <summary>
        /// Distribute Proration
        /// </summary>
        public const string DistributeProration = "1438";

        /// <summary>
        /// Purcahse Statistics
        /// </summary>
        public const string PurcahseStatistic = "1439";

        /// <summary>
        /// Purchase Statistics Report
        /// </summary>
        public const string PurchaseStatisticsReport = "1440";

        /// <summary>
        /// PO Copy Purchase Order
        /// </summary>
        public const string POCopyPurchaseOrder = "1441";

        /// <summary>
        /// PO Receiving Slip Report
        /// </summary>
        public const string POReceivingSlipReport = "1442";

        /// <summary>
        /// PO Requisition Report
        /// </summary>
        public const string PORequisitionReport = "1443";

        /// <summary>
        /// PO Pending Receipts Inquiry 
        /// </summary>
        public const string POPendingReceiptsInquiry = "1444";

        /// <summary>
        /// PO Email Message Report
        /// </summary>
        public const string POEmailMessageReport = "1445";

        /// <summary>
        /// PO Optional Field
        /// </summary>
        public const string POOptionField = "1456";

        /// <summary>
        /// PO DropShipmentAddress
        /// </summary>
        public const string DropShipmentAddress = "1457";

        /// <summary>
        /// PO Template
        /// </summary>
        public const string POTemplate = "1458";

        /// <summary>
        /// PO Email Message
        /// </summary>
        public const string POEmailMessage = "1459";

        #endregion

        #region KPI 1601-1800

        /// <summary>
        /// The CashAccountWidget
        /// </summary>

        public const string AccountBalanceWidget = "1601";

        /// <summary>
        /// The CashPositionWidget
        /// </summary>

        public const string CashPositionWidget = "1602";

        /// <summary>
        /// The IncomeFromOperationWidget
        /// </summary>

        public const string IncomeFromOperationWidget = "1603";

        /// <summary>
        /// The TopVendorWidget
        /// </summary>

        public const string TopVendorWidget = "1604";

        /// <summary>
        /// The TopCustomersByCurrentAmountDueWidget"";
        /// </summary>

        public const string TopCustomersByCurrentAmountDueWidget = "1605";

        /// <summary>
        /// The TopCustomersByBillingWidget
        /// </summary>

        public const string TopCustomersByBillingWidget = "1606";

        /// <summary>
        /// The DocumentSchedPayments
        /// </summary>

        public const string DocumentSchedPayments = "1607";

        /// <summary>
        /// The Aged Payable
        /// </summary>

        public const string AgedPayable = "1608";

        /// <summary>
        /// The Aged Receivable 
        /// </summary>

        public const string AgedReceivable = "1609";

        /// <summary>
        /// The IncomeExpense 
        /// </summary>

        public const string IncomeExpense = "1610";

        /// <summary>
        /// The IncomeComparison 
        /// </summary>
        public const string IncomeComparison = "1611";
        /// <summary>
        /// The ExpenseComparison 
        /// </summary>
        public const string ExpenseComparison = "1612";

        /// <summary>
        /// The ExpiringVendorDiscount 
        /// </summary>

        public const string ExpiringVendorDiscount = "1613";

        /// <summary>
        /// The Aged Purchase Order Rpt 
        /// </summary>

        public const string AgedPurchaseOrderRpt = "1614";

        /// <summary>
        /// Activity Trend Widget
        /// </summary>
        public const string ActivityTrendWidget = "1615";

        /// <summary>
        /// Inventory Item Performance Widget
        /// </summary>
        public const string InventoryItemPerformance = "1616";

        /// <summary>
        /// Sales per Salesperson Widget
        /// </summary>
        public const string SalesPerSalesperson = "1618";

        /// <summary>
        /// ICInventoryReconPosting
        /// </summary>
        public const string ICInventoryReconPosting = "1619";

        /// <summary>
        /// ICReoderQuantity
        /// </summary>
        public const string ICReoderQuantity = "1620";

        /// <summary>
        /// Quarantine Release
        /// </summary>
        public const string ICQuarantineRelease = "1623";

        #endregion

        #region Visual Process Flow 1621-1622

        /// <summary>
        /// Visual Process Flow
        /// </summary>
        public const string VisualProcessFlow = "1621";
        #endregion

        /// <summary>
        /// AR-Refund Batch List
        /// </summary>
        public const string ARRefundBatchList = "1624";

        #region ARCustomerGroupReport

        public const string ARCustomerGroupReport = "1625";
        #endregion


        /// <summary>
        /// AR-ARPrintCheck
        /// </summary>
        public const string ARPrintCheck = "1626";

        #region GLConsolidatePostedTransaction

        public const string GLConsolidatePostedTransaction = "1627";

        #endregion
    }
}
