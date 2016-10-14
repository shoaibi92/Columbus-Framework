/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceLine
    /// </summary>
    public partial class POOEBaseInvoiceLine
    {
        

        /// <summary>
        /// Contains list of InvoiceLine Constants
        /// </summary>
        public class BaseFields
        {

            /// <summary>
            /// Property for InvoiceSequenceKey
            /// </summary>
            public const string InvoiceSequenceKey = "INVHSEQ";

            /// <summary>
            /// Property for DetailLineNumber
            /// </summary>
            public const string DetailLineNumber = "INVLREV";

            /// <summary>
            /// Property for InvoiceLineSequence
            /// </summary>
            public const string InvoiceLineSequence = "INVLSEQ";

            /// <summary>
            /// Property for InvoiceCommentSequence
            /// </summary>
            public const string InvoiceCommentSequence = "INVCSEQ";

            /// <summary>
            /// Property for OrderNumber
            /// </summary>
            public const string OrderNumber = "OEONUMBER";

            /// <summary>
            /// Property for StoredInDatabaseTable
            /// </summary>
            public const string StoredInDatabaseTable = "INDBTABLE";

            /// <summary>
            /// Property for PostedToIC
            /// </summary>
            public const string PostedToIC = "POSTEDTOIC";

            /// <summary>
            /// Property for CompletionStatus
            /// </summary>
            public const string CompletionStatus = "COMPLETION";

            /// <summary>
            /// Property for DateCompleted
            /// </summary>
            public const string DateCompleted = "DTCOMPLETE";

            /// <summary>
            /// Property for ReceiptSequenceKey
            /// </summary>
            public const string ReceiptSequenceKey = "RCPHSEQ";

            /// <summary>
            /// Property for ReceiptLineSequence
            /// </summary>
            public const string ReceiptLineSequence = "RCPLSEQ";

            /// <summary>
            /// Property for ItemExists
            /// </summary>
            public const string ItemExists = "ITEMEXISTS";

            /// <summary>
            /// Property for ItemNumber
            /// </summary>
            public const string ItemNumber = "ITEMNO";

            /// <summary>
            /// Property for Location
            /// </summary>
            public const string Location = "LOCATION";

            /// <summary>
            /// Property for ItemDescription
            /// </summary>
            public const string ItemDescription = "ITEMDESC";

            /// <summary>
            /// Property for VendorItemNumber
            /// </summary>
            public const string VendorItemNumber = "VENDITEMNO";

            /// <summary>
            /// Property for Comments
            /// </summary>
            public const string Comments = "HASCOMMENT";

            // TODO: The naming convention of this property has to be manually evaluated
            /// <summary>
            /// Property for ORDERUNIT
            /// </summary>
            public const string ORDERUNIT = "ORDERUNIT";

            /// <summary>
            /// Property for OrderUnitConversion
            /// </summary>
            public const string OrderUnitConversion = "ORDERCONV";

            /// <summary>
            /// Property for OrderUnitDecimals
            /// </summary>
            public const string OrderUnitDecimals = "ORDERDECML";

            /// <summary>
            /// Property for ReceiptUOM
            /// </summary>
            public const string ReceiptUOM = "RCPUNIT";

            /// <summary>
            /// Property for ReceivingConversionFactor
            /// </summary>
            public const string ReceivingConversionFactor = "RCPCONV";

            /// <summary>
            /// Property for ReceivingUnitDecimals
            /// </summary>
            public const string ReceivingUnitDecimals = "RCPDECML";

            /// <summary>
            /// Property for StockUnitDecimals
            /// </summary>
            public const string StockUnitDecimals = "STOCKDECML";

            /// <summary>
            /// Property for QuantityReceived
            /// </summary>
            public const string QuantityReceived = "RQRECEIVED";

            /// <summary>
            /// Property for StockingQuantityReceived
            /// </summary>
            public const string StockingQuantityReceived = "SQRECEIVED";

            /// <summary>
            /// Property for OrderedQuantityReceived
            /// </summary>
            public const string OrderedQuantityReceived = "OQRECEIVED";

            /// <summary>
            /// Property for UnitWeight
            /// </summary>
            public const string UnitWeight = "UNITWEIGHT";

            /// <summary>
            /// Property for ExtendedWeight
            /// </summary>
            public const string ExtendedWeight = "EXTWEIGHT";

            /// <summary>
            /// Property for UnitCost
            /// </summary>
            public const string UnitCost = "UNITCOST";

            /// <summary>
            /// Property for ExtendedCost
            /// </summary>
            public const string ExtendedCost = "EXTENDED";

            /// <summary>
            /// Property for TaxBase1
            /// </summary>
            public const string TaxBase1 = "TAXBASE1";

            /// <summary>
            /// Property for TaxBase2
            /// </summary>
            public const string TaxBase2 = "TAXBASE2";

            /// <summary>
            /// Property for TaxBase3
            /// </summary>
            public const string TaxBase3 = "TAXBASE3";

            /// <summary>
            /// Property for TaxBase4
            /// </summary>
            public const string TaxBase4 = "TAXBASE4";

            /// <summary>
            /// Property for TaxBase5
            /// </summary>
            public const string TaxBase5 = "TAXBASE5";

            /// <summary>
            /// Property for TaxClass1
            /// </summary>
            public const string TaxClass1 = "TAXCLASS1";

            /// <summary>
            /// Property for TaxClass2
            /// </summary>
            public const string TaxClass2 = "TAXCLASS2";

            /// <summary>
            /// Property for TaxClass3
            /// </summary>
            public const string TaxClass3 = "TAXCLASS3";

            /// <summary>
            /// Property for TaxClass4
            /// </summary>
            public const string TaxClass4 = "TAXCLASS4";

            /// <summary>
            /// Property for TaxClass5
            /// </summary>
            public const string TaxClass5 = "TAXCLASS5";

            /// <summary>
            /// Property for TaxRate1
            /// </summary>
            public const string TaxRate1 = "TAXRATE1";

            /// <summary>
            /// Property for TaxRate2
            /// </summary>
            public const string TaxRate2 = "TAXRATE2";

            /// <summary>
            /// Property for TaxRate3
            /// </summary>
            public const string TaxRate3 = "TAXRATE3";

            /// <summary>
            /// Property for TaxRate4
            /// </summary>
            public const string TaxRate4 = "TAXRATE4";

            /// <summary>
            /// Property for TaxRate5
            /// </summary>
            public const string TaxRate5 = "TAXRATE5";

            /// <summary>
            /// Property for TaxIncludable1
            /// </summary>
            public const string TaxIncludable1 = "TAXINCLUD1";

            /// <summary>
            /// Property for TaxIncludable2
            /// </summary>
            public const string TaxIncludable2 = "TAXINCLUD2";

            /// <summary>
            /// Property for TaxIncludable3
            /// </summary>
            public const string TaxIncludable3 = "TAXINCLUD3";

            /// <summary>
            /// Property for TaxIncludable4
            /// </summary>
            public const string TaxIncludable4 = "TAXINCLUD4";

            /// <summary>
            /// Property for TaxIncludable5
            /// </summary>
            public const string TaxIncludable5 = "TAXINCLUD5";

            /// <summary>
            /// Property for TaxAmount1
            /// </summary>
            public const string TaxAmount1 = "TAXAMOUNT1";

            /// <summary>
            /// Property for TaxAmount2
            /// </summary>
            public const string TaxAmount2 = "TAXAMOUNT2";

            /// <summary>
            /// Property for TaxAmount3
            /// </summary>
            public const string TaxAmount3 = "TAXAMOUNT3";

            /// <summary>
            /// Property for TaxAmount4
            /// </summary>
            public const string TaxAmount4 = "TAXAMOUNT4";

            /// <summary>
            /// Property for TaxAmount5
            /// </summary>
            public const string TaxAmount5 = "TAXAMOUNT5";

            /// <summary>
            /// Property for TaxRecoverableAmount1
            /// </summary>
            public const string TaxRecoverableAmount1 = "TXRECVAMT1";

            /// <summary>
            /// Property for TaxRecoverableAmount2
            /// </summary>
            public const string TaxRecoverableAmount2 = "TXRECVAMT2";

            /// <summary>
            /// Property for TaxRecoverableAmount3
            /// </summary>
            public const string TaxRecoverableAmount3 = "TXRECVAMT3";

            /// <summary>
            /// Property for TaxRecoverableAmount4
            /// </summary>
            public const string TaxRecoverableAmount4 = "TXRECVAMT4";

            /// <summary>
            /// Property for TaxRecoverableAmount5
            /// </summary>
            public const string TaxRecoverableAmount5 = "TXRECVAMT5";

            /// <summary>
            /// Property for TaxExpenseAmount1
            /// </summary>
            public const string TaxExpenseAmount1 = "TXEXPSAMT1";

            /// <summary>
            /// Property for TaxExpenseAmount2
            /// </summary>
            public const string TaxExpenseAmount2 = "TXEXPSAMT2";

            /// <summary>
            /// Property for TaxExpenseAmount3
            /// </summary>
            public const string TaxExpenseAmount3 = "TXEXPSAMT3";

            /// <summary>
            /// Property for TaxExpenseAmount4
            /// </summary>
            public const string TaxExpenseAmount4 = "TXEXPSAMT4";

            /// <summary>
            /// Property for TaxExpenseAmount5
            /// </summary>
            public const string TaxExpenseAmount5 = "TXEXPSAMT5";

            /// <summary>
            /// Property for TaxAllocatedAmount1
            /// </summary>
            public const string TaxAllocatedAmount1 = "TXALLOAMT1";

            /// <summary>
            /// Property for TaxAllocatedAmount2
            /// </summary>
            public const string TaxAllocatedAmount2 = "TXALLOAMT2";

            /// <summary>
            /// Property for TaxAllocatedAmount3
            /// </summary>
            public const string TaxAllocatedAmount3 = "TXALLOAMT3";

            /// <summary>
            /// Property for TaxAllocatedAmount4
            /// </summary>
            public const string TaxAllocatedAmount4 = "TXALLOAMT4";

            /// <summary>
            /// Property for TaxAllocatedAmount5
            /// </summary>
            public const string TaxAllocatedAmount5 = "TXALLOAMT5";

            /// <summary>
            /// Property for NetOfTax
            /// </summary>
            public const string NetOfTax = "TXBASEALLO";

            /// <summary>
            /// Property for TaxIncluded
            /// </summary>
            public const string TaxIncluded = "TXINCLUDED";

            /// <summary>
            /// Property for TaxExcluded
            /// </summary>
            public const string TaxExcluded = "TXEXCLUDED";

            /// <summary>
            /// Property for TotalTax
            /// </summary>
            public const string TotalTax = "TAXAMOUNT";

            /// <summary>
            /// Property for RecoverableTax
            /// </summary>
            public const string RecoverableTax = "TXRECVAMT";

            /// <summary>
            /// Property for ExpensedTax
            /// </summary>
            public const string ExpensedTax = "TXEXPSAMT";

            /// <summary>
            /// Property for AllocatedTax
            /// </summary>
            public const string AllocatedTax = "TXALLOAMT";

            /// <summary>
            /// Property for FuncNetOfTax
            /// </summary>
            public const string FuncNetOfTax = "TFBASEALLO";

            /// <summary>
            /// Property for FuncTaxIncludedAmount1
            /// </summary>
            public const string FuncTaxIncludedAmount1 = "TFINCLUDE1";

            /// <summary>
            /// Property for FuncTaxIncludedAmount2
            /// </summary>
            public const string FuncTaxIncludedAmount2 = "TFINCLUDE2";

            /// <summary>
            /// Property for FuncTaxIncludedAmount3
            /// </summary>
            public const string FuncTaxIncludedAmount3 = "TFINCLUDE3";

            /// <summary>
            /// Property for FuncTaxIncludedAmount4
            /// </summary>
            public const string FuncTaxIncludedAmount4 = "TFINCLUDE4";

            /// <summary>
            /// Property for FuncTaxIncludedAmount5
            /// </summary>
            public const string FuncTaxIncludedAmount5 = "TFINCLUDE5";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount1
            /// </summary>
            public const string FuncTaxRecoverableAmount1 = "TFRECVAMT1";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount2
            /// </summary>
            public const string FuncTaxRecoverableAmount2 = "TFRECVAMT2";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount3
            /// </summary>
            public const string FuncTaxRecoverableAmount3 = "TFRECVAMT3";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount4
            /// </summary>
            public const string FuncTaxRecoverableAmount4 = "TFRECVAMT4";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount5
            /// </summary>
            public const string FuncTaxRecoverableAmount5 = "TFRECVAMT5";

            /// <summary>
            /// Property for FuncTaxExpenseAmount1
            /// </summary>
            public const string FuncTaxExpenseAmount1 = "TFEXPSAMT1";

            /// <summary>
            /// Property for FuncTaxExpenseAmount2
            /// </summary>
            public const string FuncTaxExpenseAmount2 = "TFEXPSAMT2";

            /// <summary>
            /// Property for FuncTaxExpenseAmount3
            /// </summary>
            public const string FuncTaxExpenseAmount3 = "TFEXPSAMT3";

            /// <summary>
            /// Property for FuncTaxExpenseAmount4
            /// </summary>
            public const string FuncTaxExpenseAmount4 = "TFEXPSAMT4";

            /// <summary>
            /// Property for FuncTaxExpenseAmount5
            /// </summary>
            public const string FuncTaxExpenseAmount5 = "TFEXPSAMT5";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount1
            /// </summary>
            public const string FuncTaxAllocatedAmount1 = "TFALLOAMT1";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount2
            /// </summary>
            public const string FuncTaxAllocatedAmount2 = "TFALLOAMT2";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount3
            /// </summary>
            public const string FuncTaxAllocatedAmount3 = "TFALLOAMT3";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount4
            /// </summary>
            public const string FuncTaxAllocatedAmount4 = "TFALLOAMT4";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount5
            /// </summary>
            public const string FuncTaxAllocatedAmount5 = "TFALLOAMT5";

            /// <summary>
            /// Property for FuncExtendedAmount
            /// </summary>
            public const string FuncExtendedAmount = "FCEXTENDED";

            /// <summary>
            /// Property for ExpenseAccount
            /// </summary>
            public const string ExpenseAccount = "GLACEXPENS";

            /// <summary>
            /// Property for ManualProration
            /// </summary>
            public const string ManualProration = "MPRORATED";

            /// <summary>
            /// Property for StockItem
            /// </summary>
            public const string StockItem = "STOCKITEM";

            /// <summary>
            /// Property for ReceiptNumber
            /// </summary>
            public const string ReceiptNumber = "RCPNUMBER";

            /// <summary>
            /// Property for PurchaseOrderSequenceKey
            /// </summary>
            public const string PurchaseOrderSequenceKey = "PORHSEQ";

            /// <summary>
            /// Property for PurchaseOrderLineSequence
            /// </summary>
            public const string PurchaseOrderLineSequence = "PORLSEQ";

            /// <summary>
            /// Property for PurchaseOrderNumber
            /// </summary>
            public const string PurchaseOrderNumber = "PONUMBER";

            /// <summary>
            /// Property for NonStockClearingAccount
            /// </summary>
            public const string NonStockClearingAccount = "GLNONSTKCR";

            /// <summary>
            /// Property for ManufacturersItemNumber
            /// </summary>
            public const string ManufacturersItemNumber = "MANITEMNO";

            /// <summary>
            /// Property for DiscountPercentage
            /// </summary>
            public const string DiscountPercentage = "DISCPCT";

            /// <summary>
            /// Property for DiscountAmount
            /// </summary>
            public const string DiscountAmount = "DISCOUNT";

            /// <summary>
            /// Property for FuncDiscountAmount
            /// </summary>
            public const string FuncDiscountAmount = "DISCOUNTF";

            /// <summary>
            /// Property for PartInvOrigQtyReceived
            /// </summary>
            public const string PartInvOrigQtyReceived = "XRRQRECEVD";

            /// <summary>
            /// Property for PartInvPvQtyInvoicied
            /// </summary>
            public const string PartInvPvQtyInvoicied = "XIRQRECEVD";

            /// <summary>
            /// Property for PreviousInvoiceLines
            /// </summary>
            public const string PreviousInvoiceLines = "PVINVLINES";

            /// <summary>
            /// Property for FullyInvoiced
            /// </summary>
            public const string FullyInvoiced = "FULLYINV";

            /// <summary>
            /// Property for OptionalFields
            /// </summary>
            public const string OptionalFields = "VALUES";

            /// <summary>
            /// Property for PaymentDiscountable
            /// </summary>
            public const string PaymentDiscountable = "TERMDISCBL";

            /// <summary>
            /// Property for Contract
            /// </summary>
            public const string Contract = "CONTRACT";

            /// <summary>
            /// Property for Project
            /// </summary>
            public const string Project = "PROJECT";

            /// <summary>
            /// Property for Category
            /// </summary>
            public const string Category = "CCATEGORY";

            /// <summary>
            /// Property for CostClass
            /// </summary>
            public const string CostClass = "COSTCLASS";

            /// <summary>
            /// Property for BillingType
            /// </summary>
            public const string BillingType = "BILLTYPE";

            /// <summary>
            /// Property for BillingRate
            /// </summary>
            public const string BillingRate = "BILLRATE";

            /// <summary>
            /// Property for BillingCurrency
            /// </summary>
            public const string BillingCurrency = "BILLCURR";

            /// <summary>
            /// Property for ARItemNumber
            /// </summary>
            public const string ARItemNumber = "ARITEMNO";

            /// <summary>
            /// Property for ARUnitOfMeasure
            /// </summary>
            public const string ARUnitOfMeasure = "ARUNIT";

            /// <summary>
            /// Property for RetainagePercentage
            /// </summary>
            public const string RetainagePercentage = "RTGPERCENT";

            /// <summary>
            /// Property for RetentionPeriod
            /// </summary>
            public const string RetentionPeriod = "RTGDAYS";

            /// <summary>
            /// Property for RetainageAmount
            /// </summary>
            public const string RetainageAmount = "RTGAMOUNT";

            /// <summary>
            /// Property for RetainageDueDate
            /// </summary>
            public const string RetainageDueDate = "RTGDATEDUE";

            /// <summary>
            /// Property for RetainageAmountOverridden
            /// </summary>
            public const string RetainageAmountOverridden = "RTGAMTOVER";

            /// <summary>
            /// Property for RetainageDueDateOverridden
            /// </summary>
            public const string RetainageDueDateOverridden = "RTGDDTOVER";

            /// <summary>
            /// Property for TaxReportingAmount1
            /// </summary>
            public const string TaxReportingAmount1 = "TARAMOUNT1";

            /// <summary>
            /// Property for TaxReportingAmount2
            /// </summary>
            public const string TaxReportingAmount2 = "TARAMOUNT2";

            /// <summary>
            /// Property for TaxReportingAmount3
            /// </summary>
            public const string TaxReportingAmount3 = "TARAMOUNT3";

            /// <summary>
            /// Property for TaxReportingAmount4
            /// </summary>
            public const string TaxReportingAmount4 = "TARAMOUNT4";

            /// <summary>
            /// Property for TaxReportingAmount5
            /// </summary>
            public const string TaxReportingAmount5 = "TARAMOUNT5";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount1
            /// </summary>
            public const string TaxReportingAllocatedAmount1 = "TRALLOAMT1";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount2
            /// </summary>
            public const string TaxReportingAllocatedAmount2 = "TRALLOAMT2";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount3
            /// </summary>
            public const string TaxReportingAllocatedAmount3 = "TRALLOAMT3";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount4
            /// </summary>
            public const string TaxReportingAllocatedAmount4 = "TRALLOAMT4";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount5
            /// </summary>
            public const string TaxReportingAllocatedAmount5 = "TRALLOAMT5";

            /// <summary>
            /// Property for TaxReportingRecoverableAmt1
            /// </summary>
            public const string TaxReportingRecoverableAmt1 = "TRRECVAMT1";

            /// <summary>
            /// Property for TaxReportingRecoverableAmt2
            /// </summary>
            public const string TaxReportingRecoverableAmt2 = "TRRECVAMT2";

            /// <summary>
            /// Property for TaxReportingRecoverableAmt3
            /// </summary>
            public const string TaxReportingRecoverableAmt3 = "TRRECVAMT3";

            /// <summary>
            /// Property for TaxReportingRecoverableAmt4
            /// </summary>
            public const string TaxReportingRecoverableAmt4 = "TRRECVAMT4";

            /// <summary>
            /// Property for TaxReportingRecoverableAmt5
            /// </summary>
            public const string TaxReportingRecoverableAmt5 = "TRRECVAMT5";

            /// <summary>
            /// Property for TaxReportingExpenseAmount1
            /// </summary>
            public const string TaxReportingExpenseAmount1 = "TREXPSAMT1";

            /// <summary>
            /// Property for TaxReportingExpenseAmount2
            /// </summary>
            public const string TaxReportingExpenseAmount2 = "TREXPSAMT2";

            /// <summary>
            /// Property for TaxReportingExpenseAmount3
            /// </summary>
            public const string TaxReportingExpenseAmount3 = "TREXPSAMT3";

            /// <summary>
            /// Property for TaxReportingExpenseAmount4
            /// </summary>
            public const string TaxReportingExpenseAmount4 = "TREXPSAMT4";

            /// <summary>
            /// Property for TaxReportingExpenseAmount5
            /// </summary>
            public const string TaxReportingExpenseAmount5 = "TREXPSAMT5";

            /// <summary>
            /// Property for first
            /// </summary>
            public const string first = "FIRST";

            /// <summary>
            /// Property for TaxClass1Description
            /// </summary>
            public const string TaxClass1Description = "TAXCLASS1D";

            /// <summary>
            /// Property for TaxClass2Description
            /// </summary>
            public const string TaxClass2Description = "TAXCLASS2D";

            /// <summary>
            /// Property for TaxClass3Description
            /// </summary>
            public const string TaxClass3Description = "TAXCLASS3D";

            /// <summary>
            /// Property for TaxClass4Description
            /// </summary>
            public const string TaxClass4Description = "TAXCLASS4D";

            /// <summary>
            /// Property for TaxClass5Description
            /// </summary>
            public const string TaxClass5Description = "TAXCLASS5D";

            /// <summary>
            /// Property for ExpenseAccountDescription
            /// </summary>
            public const string ExpenseAccountDescription = "GLACEXPNSD";

            /// <summary>
            /// Property for IncludedTaxAmount1
            /// </summary>
            public const string IncludedTaxAmount1 = "TXINCLUDE1";

            /// <summary>
            /// Property for IncludedTaxAmount2
            /// </summary>
            public const string IncludedTaxAmount2 = "TXINCLUDE2";

            /// <summary>
            /// Property for IncludedTaxAmount3
            /// </summary>
            public const string IncludedTaxAmount3 = "TXINCLUDE3";

            /// <summary>
            /// Property for IncludedTaxAmount4
            /// </summary>
            public const string IncludedTaxAmount4 = "TXINCLUDE4";

            /// <summary>
            /// Property for IncludedTaxAmount5
            /// </summary>
            public const string IncludedTaxAmount5 = "TXINCLUDE5";

            /// <summary>
            /// Property for ExcludedTaxAmount1
            /// </summary>
            public const string ExcludedTaxAmount1 = "TXEXCLUDE1";

            /// <summary>
            /// Property for ExcludedTaxAmount2
            /// </summary>
            public const string ExcludedTaxAmount2 = "TXEXCLUDE2";

            /// <summary>
            /// Property for ExcludedTaxAmount3
            /// </summary>
            public const string ExcludedTaxAmount3 = "TXEXCLUDE3";

            /// <summary>
            /// Property for ExcludedTaxAmount4
            /// </summary>
            public const string ExcludedTaxAmount4 = "TXEXCLUDE4";

            /// <summary>
            /// Property for ExcludedTaxAmount5
            /// </summary>
            public const string ExcludedTaxAmount5 = "TXEXCLUDE5";

            /// <summary>
            /// Property for Completed
            /// </summary>
            public const string Completed = "ISCOMPLETE";

            /// <summary>
            /// Property for LinesTaxCalculationSees
            /// </summary>
            public const string LinesTaxCalculationSees = "TAXLINE";

            /// <summary>
            /// Property for LinesComplete
            /// </summary>
            public const string LinesComplete = "LINECMPL";

            /// <summary>
            /// Property for Line
            /// </summary>
            public const string Line = "LINE";

            /// <summary>
            /// Property for ExtendedStdCostInSrcCurr
            /// </summary>
            public const string ExtendedStdCostInSrcCurr = "EXSTDCOST";

            /// <summary>
            /// Property for ExtendedMRCostInSrcCurr
            /// </summary>
            public const string ExtendedMRCostInSrcCurr = "EXMRCOST";

            /// <summary>
            /// Property for ExtendedCost1InSrcCurr
            /// </summary>
            public const string ExtendedCost1InSrcCurr = "EXALT1COST";

            /// <summary>
            /// Property for ExtendedCost2InSrcCurr
            /// </summary>
            public const string ExtendedCost2InSrcCurr = "EXALT2COST";

            /// <summary>
            /// Property for NonStockClearingAccountDesc
            /// </summary>
            public const string NonStockClearingAccountDesc = "GLNONSTKCD";

            /// <summary>
            /// Property for NetExtendedCost
            /// </summary>
            public const string NetExtendedCost = "NETXTENDED";

            /// <summary>
            /// Property for PartInvOrigStkgQtyRec
            /// </summary>
            public const string PartInvOrigStkgQtyRec = "XRSQRECEVD";

            /// <summary>
            /// Property for PartInvStkgPvQtyInv
            /// </summary>
            public const string PartInvStkgPvQtyInv = "XISQRECEVD";

            /// <summary>
            /// Property for PartInvOrdPvQtyInv
            /// </summary>
            public const string PartInvOrdPvQtyInv = "XIOQRECEVD";

            /// <summary>
            /// Property for PartInvStkgICQtyAdj
            /// </summary>
            public const string PartInvStkgICQtyAdj = "XSQICADJ";

            // TODO: The naming convention of this property has to be manually evaluated
            /// <summary>
            /// Property for RCPLREV
            /// </summary>
            public const string RCPLREV = "RCPLREV";

            /// <summary>
            /// Property for Command
            /// </summary>
            public const string Command = "PROCESSCMD";

            /// <summary>
            /// Property for PaymentDiscountBaseWithTax
            /// </summary>
            public const string PaymentDiscountBaseWithTax = "TERMDBWT";

            /// <summary>
            /// Property for PaymentDiscountBaseWithoutTa
            /// </summary>
            public const string PaymentDiscountBaseWithoutTa = "TERMDBNT";

            /// <summary>
            /// Property for ProjectStyle
            /// </summary>
            public const string ProjectStyle = "CONTSTYLE";

            /// <summary>
            /// Property for ProjectType
            /// </summary>
            public const string ProjectType = "PROJTYPE";

            /// <summary>
            /// Property for AccountingMethod
            /// </summary>
            public const string AccountingMethod = "REVREC";

            /// <summary>
            /// Property for UnformattedContractCode
            /// </summary>
            public const string UnformattedContractCode = "UFMTCONTNO";

            /// <summary>
            /// Property for TaxReportingIncludedAmount1
            /// </summary>
            public const string TaxReportingIncludedAmount1 = "TRINCLUDE1";

            /// <summary>
            /// Property for TaxReportingIncludedAmount2
            /// </summary>
            public const string TaxReportingIncludedAmount2 = "TRINCLUDE2";

            /// <summary>
            /// Property for TaxReportingIncludedAmount3
            /// </summary>
            public const string TaxReportingIncludedAmount3 = "TRINCLUDE3";

            /// <summary>
            /// Property for TaxReportingIncludedAmount4
            /// </summary>
            public const string TaxReportingIncludedAmount4 = "TRINCLUDE4";

            /// <summary>
            /// Property for TaxReportingIncludedAmount5
            /// </summary>
            public const string TaxReportingIncludedAmount5 = "TRINCLUDE5";

            /// <summary>
            /// Property for TaxReportingExcludedAmount1
            /// </summary>
            public const string TaxReportingExcludedAmount1 = "TREXCLUDE1";

            /// <summary>
            /// Property for TaxReportingExcludedAmount2
            /// </summary>
            public const string TaxReportingExcludedAmount2 = "TREXCLUDE2";

            /// <summary>
            /// Property for TaxReportingExcludedAmount3
            /// </summary>
            public const string TaxReportingExcludedAmount3 = "TREXCLUDE3";

            /// <summary>
            /// Property for TaxReportingExcludedAmount4
            /// </summary>
            public const string TaxReportingExcludedAmount4 = "TREXCLUDE4";

            /// <summary>
            /// Property for TaxReportingExcludedAmount5
            /// </summary>
            public const string TaxReportingExcludedAmount5 = "TREXCLUDE5";

            /// <summary>
            /// Property for TaxReportingTotalAmount
            /// </summary>
            public const string TaxReportingTotalAmount = "TARAMOUNT";

            /// <summary>
            /// Property for TaxReportingIncludedAmount
            /// </summary>
            public const string TaxReportingIncludedAmount = "TRINCLUDED";

            /// <summary>
            /// Property for TaxReportingExcludedAmount
            /// </summary>
            public const string TaxReportingExcludedAmount = "TREXCLUDED";

            /// <summary>
            /// Property for TaxReportingRecoverableAmount
            /// </summary>
            public const string TaxReportingRecoverableAmount = "TRRECVAMT";

            /// <summary>
            /// Property for TaxReportingExpensedAmount
            /// </summary>
            public const string TaxReportingExpensedAmount = "TREXPSAMT";

            /// <summary>
            /// Property for TaxReportingAllocatedAmount
            /// </summary>
            public const string TaxReportingAllocatedAmount = "TRALLOAMT";

            /// <summary>
            /// Property for RetainageTaxBase1
            /// </summary>
            public const string RetainageTaxBase1 = "RAXBASE1";

            /// <summary>
            /// Property for RetainageTaxBase2
            /// </summary>
            public const string RetainageTaxBase2 = "RAXBASE2";

            /// <summary>
            /// Property for RetainageTaxBase3
            /// </summary>
            public const string RetainageTaxBase3 = "RAXBASE3";

            /// <summary>
            /// Property for RetainageTaxBase4
            /// </summary>
            public const string RetainageTaxBase4 = "RAXBASE4";

            /// <summary>
            /// Property for RetainageTaxBase5
            /// </summary>
            public const string RetainageTaxBase5 = "RAXBASE5";

            /// <summary>
            /// Property for RetainageTaxAmount1
            /// </summary>
            public const string RetainageTaxAmount1 = "RAXAMOUNT1";

            /// <summary>
            /// Property for RetainageTaxAmount2
            /// </summary>
            public const string RetainageTaxAmount2 = "RAXAMOUNT2";

            /// <summary>
            /// Property for RetainageTaxAmount3
            /// </summary>
            public const string RetainageTaxAmount3 = "RAXAMOUNT3";

            /// <summary>
            /// Property for RetainageTaxAmount4
            /// </summary>
            public const string RetainageTaxAmount4 = "RAXAMOUNT4";

            /// <summary>
            /// Property for RetainageTaxAmount5
            /// </summary>
            public const string RetainageTaxAmount5 = "RAXAMOUNT5";

            /// <summary>
            /// Property for RetainageTaxRecoverableAmt1
            /// </summary>
            public const string RetainageTaxRecoverableAmt1 = "RXRECVAMT1";

            /// <summary>
            /// Property for RetainageTaxRecoverableAmt2
            /// </summary>
            public const string RetainageTaxRecoverableAmt2 = "RXRECVAMT2";

            /// <summary>
            /// Property for RetainageTaxRecoverableAmt3
            /// </summary>
            public const string RetainageTaxRecoverableAmt3 = "RXRECVAMT3";

            /// <summary>
            /// Property for RetainageTaxRecoverableAmt4
            /// </summary>
            public const string RetainageTaxRecoverableAmt4 = "RXRECVAMT4";

            /// <summary>
            /// Property for RetainageTaxRecoverableAmt5
            /// </summary>
            public const string RetainageTaxRecoverableAmt5 = "RXRECVAMT5";

            /// <summary>
            /// Property for RetainageTaxExpenseAmount1
            /// </summary>
            public const string RetainageTaxExpenseAmount1 = "RXEXPSAMT1";

            /// <summary>
            /// Property for RetainageTaxExpenseAmount2
            /// </summary>
            public const string RetainageTaxExpenseAmount2 = "RXEXPSAMT2";

            /// <summary>
            /// Property for RetainageTaxExpenseAmount3
            /// </summary>
            public const string RetainageTaxExpenseAmount3 = "RXEXPSAMT3";

            /// <summary>
            /// Property for RetainageTaxExpenseAmount4
            /// </summary>
            public const string RetainageTaxExpenseAmount4 = "RXEXPSAMT4";

            /// <summary>
            /// Property for RetainageTaxExpenseAmount5
            /// </summary>
            public const string RetainageTaxExpenseAmount5 = "RXEXPSAMT5";

            /// <summary>
            /// Property for RetainageTaxAllocatedAmount1
            /// </summary>
            public const string RetainageTaxAllocatedAmount1 = "RXALLOAMT1";

            /// <summary>
            /// Property for RetainageTaxAllocatedAmount2
            /// </summary>
            public const string RetainageTaxAllocatedAmount2 = "RXALLOAMT2";

            /// <summary>
            /// Property for RetainageTaxAllocatedAmount3
            /// </summary>
            public const string RetainageTaxAllocatedAmount3 = "RXALLOAMT3";

            /// <summary>
            /// Property for RetainageTaxAllocatedAmount4
            /// </summary>
            public const string RetainageTaxAllocatedAmount4 = "RXALLOAMT4";

            /// <summary>
            /// Property for RetainageTaxAllocatedAmount5
            /// </summary>
            public const string RetainageTaxAllocatedAmount5 = "RXALLOAMT5";

            /// <summary>
            /// Property for RetainageTaxTotalAmount
            /// </summary>
            public const string RetainageTaxTotalAmount = "RAXAMOUNT";

            /// <summary>
            /// Property for TaxAmountPlusRtgTaxAmt1
            /// </summary>
            public const string TaxAmountPlusRtgTaxAmt1 = "TXRXAMT1";

            /// <summary>
            /// Property for TaxAmountPlusRtgTaxAmt2
            /// </summary>
            public const string TaxAmountPlusRtgTaxAmt2 = "TXRXAMT2";

            /// <summary>
            /// Property for TaxAmountPlusRtgTaxAmt3
            /// </summary>
            public const string TaxAmountPlusRtgTaxAmt3 = "TXRXAMT3";

            /// <summary>
            /// Property for TaxAmountPlusRtgTaxAmt4
            /// </summary>
            public const string TaxAmountPlusRtgTaxAmt4 = "TXRXAMT4";

            /// <summary>
            /// Property for TaxAmountPlusRtgTaxAmt5
            /// </summary>
            public const string TaxAmountPlusRtgTaxAmt5 = "TXRXAMT5";

            /// <summary>
            /// Property for UnitCostIsManual
            /// </summary>
            public const string UnitCostIsManual = "UCISMANUAL";

            /// <summary>
            /// Property for WeightUnitOfMeasure
            /// </summary>
            public const string WeightUnitOfMeasure = "WEIGHTUNIT";

            /// <summary>
            /// Property for WeightConversion
            /// </summary>
            public const string WeightConversion = "WEIGHTCONV";

            /// <summary>
            /// Property for DefaultUnitWeight
            /// </summary>
            public const string DefaultUnitWeight = "DEFUWEIGHT";

            /// <summary>
            /// Property for DefaultExtendedWeight
            /// </summary>
            public const string DefaultExtendedWeight = "DEFEXTWGHT";

            /// <summary>
            /// Property for BillingRateConversionFactor
            /// </summary>
            public const string BillingRateConversionFactor = "BILLRATECV";

            /// <summary>
            /// Property for UnitBillingAmount
            /// </summary>
            public const string UnitBillingAmount = "UNITBILLSR";

            /// <summary>
            /// Property for ExtendedBillingAmount
            /// </summary>
            public const string ExtendedBillingAmount = "EXTBILLSR";

            /// <summary>
            /// Property for SerialLotQuantityToProcess
            /// </summary>
            public const string SerialLotQuantityToProcess = "XGENALCQTY";

            /// <summary>
            /// Property for NumberOfLotsToGenerate
            /// </summary>
            public const string NumberOfLotsToGenerate = "XLOTMAKQTY";

            /// <summary>
            /// Property for QuantityperLot
            /// </summary>
            public const string QuantityperLot = "XPERLOTQTY";

            /// <summary>
            /// Property for AllocateFromSerial
            /// </summary>
            public const string AllocateFromSerial = "SALLOCFROM";

            /// <summary>
            /// Property for AllocateFromLot
            /// </summary>
            public const string AllocateFromLot = "LALLOCFROM";

            /// <summary>
            /// Property for SerialLotWindowHandle
            /// </summary>
            public const string SerialLotWindowHandle = "METERHWND";

            /// <summary>
            /// Property for SerialQuantity
            /// </summary>
            public const string SerialQuantity = "SERIALQTY";

            /// <summary>
            /// Property for LotQuantity
            /// </summary>
            public const string LotQuantity = "LOTQTY";

            /// <summary>
            /// Property for ItemSerializedLotted
            /// </summary>
            public const string ItemSerializedLotted = "SLITEM";

            /// <summary>
            /// Property for DetailNumber
            /// </summary>
            public const string DetailNumber = "DETAILNUM";

        }
    }
}
