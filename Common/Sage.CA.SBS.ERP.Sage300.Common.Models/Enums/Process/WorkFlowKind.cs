/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process
{
    /// <summary>
    /// Enum WorkFlowKind
    /// </summary>
    public enum WorkFlowKind
    {

        /// <summary>
        /// The clear history
        /// </summary>
        ClearHistory = 1,

        /// <summary>
        /// The create new year
        /// </summary>
        CreateNewYear = 2,

        /// <summary>
        /// The period end maintenance
        /// </summary>
        PeriodEndMaintenance = 3,

        /// <summary>
        /// The create recurring entries batch
        /// </summary>
        CreateRecurringEntriesBatch = 4,

        /// <summary>
        /// The post journal
        /// </summary>
        PostJournal = 5,

        /// <summary>
        /// The batch list
        /// </summary>
        BatchList = 6,

        /// <summary>
        /// The posting journal update clear
        /// </summary>
        PostingJournalUpdateClear = 7,

        /// <summary>
        /// The batch status
        /// </summary>
        BatchStatus = 8,

        /// <summary>
        /// The export journal entry
        /// </summary>
        ExportJournalEntry = 9,

        /// <summary>
        /// The import journal entry
        /// </summary>
        ImportJournalEntry = 10,

        /// <summary>
        /// AP Create Recurring Payable Batch
        /// </summary>
        CreateRecurPayBatch = 11,

        /// <summary>
        /// PostBatch
        /// </summary>
        PostBatch = 12,

        /// <summary>
        /// The Process Year End(AP)
        /// </summary>
        APProcessYearEnd = 13,

        /// <summary>
        /// AP Create GL Batch
        /// </summary>
        APCreateGLBatch = 14,

        /// <summary>
        /// AR - The Create G/L Batch
        /// </summary>
        ARCreateGLBatch = 15,

        /// <summary>
        /// The AR process year end
        /// </summary>
        ARProcessYearEnd = 16,

        /// <summary>
        /// Invoice Batch List 
        /// </summary>
        InvoiceBatchList = 17,

        /// <summary>
        /// The Day end processing
        /// </summary>
        DayEndProcessing = 18,

        /// <summary>
        /// The Data Integrity
        /// </summary>
        DataIntegrity = 19,

        /// <summary>
        /// The Create GL Batch
        /// </summary>
        ICCreateGLBatch = 20,

        /// <summary>
        /// Payment Batch List 
        /// </summary>
        PaymentBatchList = 21,

        /// <summary>
        /// APPostBatch
        /// </summary>
        APPostBatch = 22,

        /// <summary>
        /// AP AgedPayable Report
        /// </summary>
        APAgedPayableReport = 23,

        /// <summary>
        /// AP AgeRetainageDocuments
        /// </summary>
        APAgeRetainage = 24,

        /// <summary>
        /// APSelectVendors
        /// </summary>
        APSelectVendors = 25,
        /// <summary>
        /// CSClearHistory
        /// </summary>
        CSClearHistory = 27,


        /// <summary>
        ///ImportOFXStatement
        /// </summary>
        ImportOFXStatement = 28,

        /// <summary>
        /// Deleting the blobs
        /// </summary>
        DeleteBlobs = 29,

        ///<summary>
        /// AR Invoice Batch List
        /// </summary>
        ARInvoiceBatchList = 30,

        /// <summary>
        /// Post Entries
        /// </summary>
        PostEntries = 31,

        /// <summary>
        /// A/R - Create Interest Batch
        /// </summary>
        ARCreateInterestBatch = 32,

        /// <summary>
        /// AP transactions control payments.
        /// </summary>
        ControlPayment = 33,

        /// <summary>
        /// AR Update Print Status.
        /// </summary>
        ARUpdatePrintStatus = 34,

        /// <summary>
        /// AR Receipt Batch List.
        /// </summary>
        ARReceiptBatchList = 35,

        /// <summary>
        /// Bank Reconciliation Clearing
        /// </summary>
        BankReconciliationClearing = 36,

        /// <summary>
        /// AR Select Customers
        /// </summary>
        ARSelectCustomer = 37,

        /// <summary>
        /// AR Aged Retainage Document
        /// </summary>
        ARAgedRetainageDocument = 38,

        /// <summary>
        /// AR Create Statement Process
        /// </summary>
        CreateStatement = 39,

        /// <summary>
        /// AP- CPRSElectronicFiling
        /// </summary>
        CPRSElectronicFiling = 40,

        /// <summary>
        /// BankTransactionReversal
        /// </summary>
        BankTransactionReversal = 41,

        /// <summary>
        /// AP Letter And Label Email
        /// </summary>
        APLetterAndLabelEmail = 42,

        /// <summary>
        /// AR- InvoiceReport
        /// </summary>
        ARInvoiceReport = 43,

        /// <summary>
        /// CS - Reconcile OFX Statements
        /// </summary>
        ReconcileOFXStatement = 44,

        /// <summary>
        /// CS - Bank Transaction - Post Reconciliation
        /// </summary>
        PostReconciliation = 45,

        /// <summary>
        /// AP CPRS Amount Checking
        /// </summary>
        APCprsAmountchecking = 46,

        /// <summary>
        /// AP Update Print Status.
        /// </summary>
        APUpdatePrintStatus = 47,

        /// <summary>
        /// AR Age Documents
        /// </summary>
        ARAgedDocument = 48,

        /// <summary>
        /// AR- Statements/Letters/Labels
        /// </summary>
        ARStatementLetterLabel = 49,

        /// <summary>
        /// AR- ReceiptReport
        /// </summary>
        ARReceiptReport = 50,



        /// <summary>
        /// AP Print 10991096 Form Report
        /// </summary>
        APPrint10991096FormReport = 51,

        /// <summary>
        /// The Create Batch
        /// </summary>
        POCreateGLBatch = 51,

        /// <summary>
        /// AR- Labels
        /// </summary>
        ARLabel = 53,

        /// <summary>
        /// PO-Create Batch
        /// </summary>
        POCreateBatch = 54,


        /// <summary>
        /// AP- Vendor Transaction
        /// </summary>
        VendorTransaction = 55,


        /// <summary>
        /// OE Report Service
        /// </summary>
        OEReportService = 56,

        /// <summary>
        /// BK - QuickClearing
        /// </summary>
        BKQuickClearing = 57,

        /// <summary>
        /// CS- ReconcileStatement
        /// </summary>
        BKReconcileStatement = 58,

        /// <summary>
        /// OE- CreateBatch
        /// </summary>
        OECreateBatch = 60,

        /// <summary>
        /// CreatePaymentBatch
        /// </summary>
        CreatePaymentBatch = 59,

        /// <summary>
        /// PO- ClearHistory
        /// </summary>
        POClearHistory = 61,

        /// <summary>
        /// IC Reset Printed Posting Journal
        /// </summary>
        ICResetPrintedPostingJournal = 62,

        /// <summary>
        /// IC ReportService
        /// </summary>
        ICReportService = 63,

        /// <summary>
        /// IC Mark Posting Journals Printed
        /// </summary>
        POMarkPostingJournalsPrinted = 64,

        /// <summary>
        /// PO ReportService
        /// </summary>
        POReportService = 65,


        /// <summary>
        /// OE- ClearHistory
        /// </summary>
        OEClearHistory = 66,

        /// <summary>
        /// PO- CreatePOsFromIC
        /// </summary>
        CreatePOsFromIC = 67,

        /// <summary>
        /// IC - LocationQuantity
        /// </summary>
        LocationQuantity = 68,

        /// <summary>
        /// PO -CreatePOsFromOE
        /// </summary>
        CreatePOsFromOE = 69,

        /// <summary>
        /// OE FlagPrintedRecord
        /// </summary>
        OEFlagPrintedRecord = 70,

        /// <summary>
        /// Order Entry - Email
        /// </summary>
        OrderConfirmationEmail = 71,

        /// <summary>
        /// Quotes - Email
        /// </summary>
        QuoteEmail = 72,

        /// <summary>
        /// IC Process Transaction
        /// </summary>
        ICProcessTransaction = 73,

        /// <summary>
        /// PO PurchaseOrderReportServices
        /// </summary>
        PoPurchaseOrderReportServices = 74,

        /// <summary>
        /// IC - Update Item Pricing
        /// </summary>
        ICUpdateItemPricing = 75,

        /// <summary>
        /// IC - GenerateInventoryWorksheet
        /// </summary>
        GenerateInventoryWorksheet = 76,

        /// <summary>
        /// Purchase Order Email
        /// </summary>
        PurchaseOrderEmail = 77,

        /// <summary>
        /// Create POs From Requisition
        /// </summary>
        CreatePOsFromRequisition = 78,

        /// <summary>
        /// OE QuoteProcess
        /// </summary>
        OEQuoteProcess = 79,

        /// <summary>
        /// OE Forms - Order Confirmation Report Process
        /// </summary>
        OrderConfirmationReportProcess = 80,

        /// <summary>
        /// PO ReturnReportServices
        /// </summary>
        PoReturnReportServices = 81,

        /// <summary>
        /// OE Forms - Invoice Report Process
        /// </summary>
        OEInvoiceReportProcess = 82,

        /// <summary>
        /// OE Forms - Invoice Report Process
        /// </summary>
        PoMailingLabelServices = 83,

        /// <summary>
        /// Return Report Email
        /// </summary>
        ReturnReportEmail = 84,

        /// <summary>
        /// Return Inventory Recon Posting
        /// </summary>
        InventoryReconPosting = 85,

        /// <summary>
        /// ShippingLabelProcess
        /// </summary>
        OEShippingLabelProcess = 86,

        /// <summary>
        /// OE Forms - Invoice Report Email
        /// </summary>
        OEInvoiceReportEmail = 87,

        /// <summary>
        /// OE Forms - CreditDebit Report Email
        /// </summary>
        OECreditDebitReportEmail = 88,

        /// <summary>
        /// OE Forms - CreditDebit Report Process
        /// </summary>
        OECreditDebitProcess = 89,

        /// <summary>
        /// PO Requisition Report Process
        /// </summary>
        PoRequisitionReportProcess = 90,

        /// <summary>
        /// OE Forms - Mailing Label Process
        /// </summary>
        PoMailingProcessService = 91,

        /// <summary>
        /// OE Forms - Picking Slips Report Process
        /// </summary>
        OEPickingSlipReportProcess = 92,

        /// <summary>
        /// IC Mark Labels Printed Status Update
        /// </summary>
        ICMarkLabelsPrinted = 93,

        /// <summary>
        /// IC Periodic Processing - Process Adjustments
        /// </summary>
        ICProcessAdjustment = 94,

        /// <summary>
        /// The posting journal update clear
        /// </summary>
        GLClearHistory = 95,

        /// <summary>
        /// AP Revaluation
        /// </summary>
        APRevaluation = 96,

        /// <summary>
        ///  AR Revaluation
        /// </summary>
        ARRevaluation = 97,

        /// <summary>
        /// PO Receiving Slip Report Process
        /// </summary>
        PoReceivingSlipReportProcess = 98,

        /// <summary>
        /// CS Schedules
        /// </summary>
        CSSchedules = 99,

        /// <summary>
        /// GL Create Allocation Batch
        /// </summary>
        GLCreateAllocationBatch = 100,
        /// <summary>
        /// BK Bank Deposit Printing Function
        /// </summary>
        BKBankDepositPrintingFunction = 101,

        /// <summary>
        /// AP Delete Inactive Record
        /// </summary>
        APDeleteInactiveRecord = 102,

        /// <summary>
        /// IC Delete Inactive Record
        /// </summary>
        ICDeleteInactiveRecord = 103,
        /// <summary>
        /// The I/C clear History
        /// </summary>
        ICClearHistory = 104,




        /// <summary>
        /// ICCopyItemPricing
        /// </summary>
        ICCopyItemPricing = 105,

        /// <summary>
        /// Refund Batch List
        /// </summary>
        RefundBatchList = 106,

        /// <summary>
        /// GL- Compute Fiscal Set Comparison
        /// </summary>
        GLComputeFiscalSetComparison = 107,

        /// <summary>
        /// GL- Create Account
        /// </summary>
        GLCreateAccount = 108,

        /// <summary>
        ///  AR CreateRecurringCharge
        /// </summary>
        ARCreateRecurringCharge = 115,

        /// <summary>
        ///  IC Quarantine Release
        /// </summary>
        ICQuarantineRelease = 116,

        /// <summary>
        ///  AR Create Retainage Batch
        /// </summary>
        ARCreateRetainageBatch = 117,

        /// <summary>
        /// AP Create Retainage Document Batch
        /// </summary>
        APCreateRetainageDocumentBatch = 118,

        /// <summary>
        ///  AR Create Write Off Batch
        /// </summary>
        ARCreateWriteOffBatch = 119,
		
		
        

        /// <summary>
        /// The A/R clear History
        /// </summary>
        ARClearHistory = 120,

        

        /// <summary>
        /// The A/R Clear Customer Comment
        /// </summary>
        ARClearCustomerComment = 122,

        /// <summary>
        /// ARAdjustmentBatchList
        /// </summary>
        ARAdjustmentBatchList = 121,

        ICSerialRegistration = 123,
		
       

        /// <summary>
        /// The A/P clear History
        /// </summary>
        APClearStatistic = 124,

        /// <summary>
        /// The A/P Clear Deleted And Posted Batches 
        /// </summary>
        APClearDeletedAndPostedBatch = 125,

        /// <summary>
        /// The A/P Clear Vendor Comment
        /// </summary>
        APClearVendorComment = 126,


        /// <summary>
        /// AR Delete Inactive Record
        /// </summary>
        ARDeleteInactiveRecord = 127,

        /// <summary>
        ///  AR Clear Statistic
        /// </summary>
        ARClearStatistic = 128,

        /// <summary>
        /// CS Reminder List
        /// </summary>
        CSRemiderList = 129,
        /// <summary>
        /// The A/P Clear History
        /// </summary>
        APClearHistory = 130,
        /// <summary>
        /// The A/R Clear DeletedAndPosted Batches 
        /// </summary>
        ARClearDeletedAndPostedBatche = 131,
		
		/// <summary>
        /// PostReceiptsandAdjustment
        /// </summary>
        PostReceiptsandAdjustment = 132,

        /// <summary>
        /// APAdjustmentBatchList
        /// </summary>
        APAdjustmentBatchList=133,

        /// <summary>
        /// The GL Consolidated Posted Transaction
        /// </summary>
        GLConsolidatePostedTransaction = 134,

        /// <summary>
        /// AR UpdateRecurringCharge process
        /// </summary>
        ARUpdateRecurringCharge = 135,
    }
}