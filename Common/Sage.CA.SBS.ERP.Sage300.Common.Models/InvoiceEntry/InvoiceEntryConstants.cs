/* Copyright (c) 1994-2015 Sage Software; Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// Class which stores the Invoice Entry Constants that are matching to Constants defined in Javascript.
    /// </summary>
    public class InvoiceEntryConstants
    {
        /// <summary>
        /// Class that stores the Date Related constants
        /// </summary>
        public class DateFields
        {
            public const string DiscountDate = "DiscDate";
            public const string DueDate = "DueDate";
            public const string AsofDate = "AsofDate";
            public const string TaxReportingRateDate = "TaxRateDate";
            public const string RateDate = "RateDate";
            public const string DocumentDate = "DocDate";
            public const string PostingDate = "PostingDate";
            public const string BatchDate = "BatchDate";
            public const string InvoiceDate = "InvoiceDate";
        }

        /// <summary>
        /// Class that stores Invoice Entry Detail related constants.
        /// </summary>
        public class DetailFields
        {
            public const string DistributionCode = "DistCode";
            public const string Description = "DistDisc";
            public const string GLAccount = "GLAccount";
            public const string Discountable = "Discountable";
            public const string Comment = "Comment";
            public const string RetainageDueDate = "RtgDueDate";
            public const string DaysRetained = "DaysRetained";
            public const string RetainageAmount = "RtgAmount";
            public const string PercentRetained = "PercentRetained";
            public const string DistributionAmount = "DistAmount";
            public const string OriginalLineIdentifier = "OriginalLineIdentifier";

            //PO Invoice Entry Related Extra column
            public const string ItemDescription = "ItemDesc";
            public const string QuantityReceived = "QuantityReceived";
            public const string UnitCost = "UnitCost";
            public const string ExtendedCost = "ExtendedCost";
            public const string WeightUnitOfMeasure = "WUOM";
            public const string UnitWeight = "UnitWeight";
            public const string ExtendedWeight = "ExtendedWeight";
            public const string VendorItemNumber = "VendorItemNumber";
            public const string ExpenseAccount = "ExpenseAccount";
            public const string NonStockClearingAccount = "NonStkClearingAcc";
            public const string ManufacturersItemNumber = "ManufacturersItemNumber";
            public const string PaymentDiscountable = "PaymentDiscountable";

        }

        /// <summary>
        /// Class that stores constants for export which we AP Invoice Entry does not need to export.
        /// </summary>
        public class NotExportFields
        {
            public const string CustomerPONumber = "CUSTPO";
            public const string TaxClass1 = "TAXSTTS1";
            public const string TaxClass2 = "TAXSTTS2";
            public const string TaxClass3 = "TAXSTTS3";
            public const string TaxClass5 = "TAXSTTS4";
            public const string TaxClass4 = "TAXSTTS5";
            public const string NumberofScheduledPayments = "AMTPAYMTOT";
            public const string DocumentTtlIncludingTax = "AMTNETTOT";
            public const string InvoicePrinted = "SWPRTINVC";

        }


        /// <summary>
        /// Class that stores constants Invoice Prepayment related.
        /// </summary>
        public class InvoiceEntryPrepaymentFields
        {
            public const int EntryDescription = 1;
            public const int EntryReference = 2;
            public const int RemitTo = 3;
            public const int PaymentCode = 4;
            public const int PrintCheck = 5;
            public const int CheckLanguage = 6;
            public const int VendorAmount = 7;
            public const int BatchDate = 8;
            public const int PostingDate = 9;
            public const int PaymentDate = 10;
            public const int PaymentBatchDescription = 11;
            public const int PaymentRateType = 12;
            public const int RateDate = 13;
            public const int PaymentAccountSet = 14;
            public const int CashAccount = 15;
            public const int ActivationDate = 16;
            public const int BankCode = 17;
            public const int BankCurrencyCode = 18;
            public const int CheckNumber = 19;
            public const int BankRateDate = 20;
            public const int VendorRateDate = 21;
            public const int VendorExchangeRate = 22;
            public const int BankExchangeRate = 23;
            public const int BankRateType = 24;
            public const int VendorRateType = 25;
            public const int PaymentAmount = 36;
            //Prepay RemitToLocation Constants
            public const int RemitToLoc = 26;
            public const int AddressLine1 = 27;
            public const int AddressLine2 = 28;
            public const int AddressLine3 = 29;
            public const int AddressLine4 = 30;
            public const int RemitPayee = 31;
            public const int City = 32;
            public const int State = 33;
            public const int Country = 34;
            public const int PostalCode = 35;
        }
        public const string InvoiceNumber = "InvoiceNumber";
        public const string DiscountPercentage = "DiscPercentage";
        public const string DiscountAmount = "DiscAmount";
        public const string DiscountBase = "DiscBase";
        public const string TermsCode = "TermsCode";
        public const string RemitToLocation = "RemitToLoc";
        public const string DistributionSet = "DistSet";
        public const string RateType = "RateType";
        public const string Retainage = "Retainage";
        public const string Terms = "Terms";
        public const string OnHold = "OnHold";
        public const string AccountSet = "AccountSet";
        public const string BatchDescription = "BatchDesc";
        public const string RetainageTerms = "RtgTerms";
        public const string TaxGroup = "TaxGroup";
        public const string TaxReportingRateType = "TaxRateType";
        public const string DocumentNumber = "DocNumber";
        public const string ApplyToDocument = "ApplyToDoc";
        public const string OriginialDocumentNumber = "OrigDocNo";
        public const string TaxBase1 = "TaxBase1";
        public const string TaxBase2 = "TaxBase2";
        public const string TaxBase3 = "TaxBase3";
        public const string TaxBase4 = "TaxBase4";
        public const string TaxBase5 = "TaxBase5";
        public const string RetainageTermsCode = "RetainageTermsCode";
        public const string RetainageExchangeRate = "RetainageExchangeRate";
        public const string TaxReportingExchangeRate = "TaxExchangeRate";
        public const string RateExchangeRate = "RateExchangeRate";
        public const string DocumentTotalIncludingTax = "DocumentTotalIncTax";
        public const string InvoiceDescription = "InvoiceDesc";
        public const string PONumber = "PONumber";
        public const string OrderNumber = "OrderNumber";
        public const string InvoiceType = "InvoiceType";
        public const string DocumentType = "DocumentType";
        public const string _1099CPRS = "_1099CPRS";
        public const string _1099CPRSAmount = "_1099CPRSAmount";
        public const string DistributionSetAmount = "DistSetAmount";

        //PO Invoice Entry Related Fields
        public const string VendorNumber = "VendorNumber";
        public const string ReceiptNumber = "ReceiptNumber";
        public const string TotalDiscPercentage = "TotalDiscPercentage";
        public const string TotalDiscAmount = "TotalDiscAmount";
        public const string TotalComment = "TotalComment";
        public const string Reference = "Reference";
        public const string InvoiceTotal = "InvoiceTotal";
        public const string BillToLocation = "BillToLoc";
        public const string FullyInvoiced = "FullyInvoiced";
        public const string MultipleReceipts = "MultiReceipts";
        public const string DefaultLoad = "Load";

        //PO Invoice Entry Attribute Related Constants
        public const string Vendor = "Vendor";
        public const string Name = "Name";
        public const string MultipleReceiptsAttribute = "MultipleReceipts";

        //Tax Related Constants
        public const string TaxClass1 = "TaxClass1";
        public const string TaxClass2 = "TaxClass2";
        public const string TaxClass3 = "TaxClass3";
        public const string TaxClass4 = "TaxClass4";
        public const string TaxClass5 = "TaxClass5";
        public const string TaxAmount1 = "TaxAmount1";
        public const string TaxAmount2 = "TaxAmount2";
        public const string TaxAmount3 = "TaxAmount3";
        public const string TaxAmount4 = "TaxAmount4";
        public const string TaxAmount5 = "TaxAmount5";
        public const string TaxReportingAmount1 = "TaxReportingAmount1";
        public const string TaxReportingAmount2 = "TaxReportingAmount2";
        public const string TaxReportingAmount3 = "TaxReportingAmount3";
        public const string TaxReportingAmount4 = "TaxReportingAmount4";
        public const string TaxReportingAmount5 = "TaxReportingAmount5";
        public const string TaxIncludable1 = "TaxIncluded1";
        public const string TaxIncludable2 = "TaxIncluded2";
        public const string TaxIncludable3 = "TaxIncluded3";
        public const string TaxIncludable4 = "TaxIncluded4";
        public const string TaxIncludable5 = "TaxIncluded5";
        public const string The1099CPRSAmount = "The1099CPRSAmount";
        public const string Num1099CPRSClass = "Num1099CPRSClass";
    }
}
