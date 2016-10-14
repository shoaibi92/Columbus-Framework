
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// Base Invoice Fields and Index Class
    /// </summary>
    public partial class BaseInvoice
    {
        /// <summary>
        /// Base Invoice Fields Class
        /// </summary>
        public partial class BaseFields
        {
            #region Properties

            /// <summary>
            /// Property for BatchNumber 
            /// </summary>
            public const string BatchNumber = "CNTBTCH";

            /// <summary>
            /// Property for EntryNumber 
            /// </summary>
            public const string EntryNumber = "CNTITEM";

            /// <summary>
            /// Property for DocumentNumber 
            /// </summary>
            public const string DocumentNumber = "IDINVC";

            /// <summary>
            /// Gets and Sets Vendor Number
            /// </summary>
            public const string CustomerNumber = "IDCUST";

            /// <summary>
            /// Property for DocumentType 
            /// </summary>
            public const string DocumentType = "TEXTTRX";

            /// <summary>
            /// Property for TransactionType 
            /// </summary>
            public const string TransactionType = "IDTRX";

            /// <summary>
            /// Property for APTransactionType 
            /// </summary>
            public const string APTransactionType = "IDTRX";

            /// <summary>
            /// Property for OrderNumber 
            /// </summary>
            public const string OrderNumber = "ORDRNBR";

            /// <summary>
            /// Property for InvoiceDescription 
            /// </summary>
            public const string InvoiceDescription = "INVCDESC";

            /// <summary>
            /// Property for ApplytoDocument 
            /// </summary>
            public const string ApplytoDocument = "INVCAPPLTO";

            /// <summary>
            /// Property for DocumentDate 
            /// </summary>
            public const string DocumentDate = "DATEINVC";

            /// <summary>
            /// Property for AsofDate 
            /// </summary>
            public const string AsofDate = "DATEASOF";

            /// <summary>
            /// Property for FiscalYear 
            /// </summary>
            public const string FiscalYear = "FISCYR";

            /// <summary>
            /// Property for FiscalPeriod 
            /// </summary>
            public const string FiscalPeriod = "FISCPER";

            /// <summary>
            /// Property for CurrencyCode 
            /// </summary>
            public const string CurrencyCode = "CODECURN";

            /// <summary>
            /// Property for RateType 
            /// </summary>
            public const string RateType = "RATETYPE";

            /// <summary>
            /// Property for RateOverridden 
            /// </summary>
            public const string RateOverridden = "SWMANRTE";

            /// <summary>
            /// Property for ExchangeRate 
            /// </summary>
            public const string ExchangeRate = "EXCHRATEHC";

            /// <summary>
            /// Property for ApplytoExchangeRate 
            /// </summary>
            public const string ApplytoExchangeRate = "ORIGRATEHC";

            /// <summary>
            /// Property for Terms 
            /// </summary>
            public const string Terms = "TERMCODE";

            /// <summary>
            /// Property for TermsCodeOverridden 
            /// </summary>
            public const string TermsCodeOverridden = "SWTERMOVRD";

            /// <summary>
            /// Property for DueDate 
            /// </summary>
            public const string DueDate = "DATEDUE";

            /// <summary>
            /// Property for DiscountDate 
            /// </summary>
            public const string DiscountDate = "DATEDISC";

            /// <summary>
            /// Property for DiscountPercentage 
            /// </summary>
            public const string DiscountPercentage = "PCTDISC";

            /// <summary>
            /// Property for DiscountAmountAvailable 
            /// </summary>
            public const string DiscountAmountAvailable = "AMTDISCAVL";

            /// <summary>
            /// Property for LASTLINE 
            /// </summary>
            public const string NumberOfDetails = "LASTLINE";

            /// <summary>
            /// Property for Taxable 
            /// </summary>
            public const string Taxable = "SWTAXBL";

            /// <summary>
            /// Property for TaxGroup 
            /// </summary>
            public const string TaxGroup = "CODETAXGRP";

            /// <summary>
            /// Property for TaxAuthority1 
            /// </summary>
            public const string TaxAuthority1 = "CODETAX1";

            /// <summary>
            /// Property for TaxAuthority2 
            /// </summary>
            public const string TaxAuthority2 = "CODETAX2";

            /// <summary>
            /// Property for TaxAuthority3 
            /// </summary>
            public const string TaxAuthority3 = "CODETAX3";

            /// <summary>
            /// Property for TaxAuthority4 
            /// </summary>
            public const string TaxAuthority4 = "CODETAX4";

            /// <summary>
            /// Property for TaxAuthority5 
            /// </summary>
            public const string TaxAuthority5 = "CODETAX5";

            /// <summary>
            /// Property for TaxBase1 
            /// </summary>
            public const string TaxBase1 = "BASETAX1";

            /// <summary>
            /// Property for TaxBase2 
            /// </summary>
            public const string TaxBase2 = "BASETAX2";

            /// <summary>
            /// Property for TaxBase3 
            /// </summary>
            public const string TaxBase3 = "BASETAX3";

            /// <summary>
            /// Property for TaxBase4 
            /// </summary>
            public const string TaxBase4 = "BASETAX4";

            /// <summary>
            /// Property for TaxBase5 
            /// </summary>
            public const string TaxBase5 = "BASETAX5";

            /// <summary>
            /// Property for TaxAmount1 
            /// </summary>
            public const string TaxAmount1 = "AMTTAX1";

            /// <summary>
            /// Property for TaxAmount2 
            /// </summary>
            public const string TaxAmount2 = "AMTTAX2";

            /// <summary>
            /// Property for TaxAmount3 
            /// </summary>
            public const string TaxAmount3 = "AMTTAX3";

            /// <summary>
            /// Property for TaxAmount4 
            /// </summary>
            public const string TaxAmount4 = "AMTTAX4";

            /// <summary>
            /// Property for TaxAmount5 
            /// </summary>
            public const string TaxAmount5 = "AMTTAX5";

            /// <summary>
            /// Property for PrepaymentNumber 
            /// </summary>
            public const string PrepaymentNumber = "IDPPD";

            /// <summary>
            /// Property for RateDate 
            /// </summary>
            public const string RateDate = "DATERATE";

            /// <summary>
            /// Property for AmountDue 
            /// </summary>
            public const string AmountDue = "AMTDUE";

            /// <summary>
            /// Property for TaxTotal 
            /// </summary>
            public const string TaxTotal = "AMTTAXTOT";

            /// <summary>
            /// Property for DrillDownApplicationSource 
            /// </summary>
            public const string DrillDownApplicationSource = "DRILLAPP";

            /// <summary>
            /// Property for DrillDownType 
            /// </summary>
            public const string DrillDownType = "DRILLTYPE";

            /// <summary>
            /// Property for DrillDownLinkNumber 
            /// </summary>
            public const string DrillDownLinkNumber = "DRILLDWNLK";

            /// <summary>
            /// Property for PropertyCode 
            /// </summary>
            public const string PropertyCode = "PRPTYCODE";

            /// <summary>
            /// Property for PropertyValue 
            /// </summary>
            public const string PropertyValue = "PRPTYVALUE";

            /// <summary>
            /// Property for JobRelated 
            /// </summary>
            public const string JobRelated = "SWJOB";

            /// <summary>
            /// Property for ErrorBatch 
            /// </summary>
            public const string ErrorBatch = "ERRBATCH";

            /// <summary>
            /// Property for ErrorEntry 
            /// </summary>
            public const string ErrorEntry = "ERRENTRY";

            /// <summary>
            /// Property for PrepaymentAmount 
            /// </summary>
            public const string PrepaymentAmount = "AMTPPD";

            /// <summary>
            /// Property for DateGenerated 
            /// </summary>
            public const string DateGenerated = "DATEPRCS";

            /// <summary>
            /// Property for DiscountBaseWithTax 
            /// </summary>
            public const string DiscountBaseWithTax = "AMTDSBWTAX";

            /// <summary>
            /// Property for DiscountBaseWithoutTax 
            /// </summary>
            public const string DiscountBaseWithoutTax = "AMTDSBNTAX";

            /// <summary>
            /// Property for DiscountBase 
            /// </summary>
            public const string DiscountBase = "AMTDSCBASE";

            /// <summary>
            /// Property for RetainageInvoice 
            /// </summary>
            public const string RetainageInvoice = "SWRTGINVC";

            /// <summary>
            /// Property for OriginalDocNo 
            /// </summary>
            public const string OriginalDocNo = "RTGAPPLYTO";

            /// <summary>
            /// Property for HasRetainage 
            /// </summary>
            public const string HasRetainage = "SWRTG";

            /// <summary>
            /// Property for RetainageAmount 
            /// </summary>
            public const string RetainageAmount = "RTGAMT";

            /// <summary>
            /// Property for PercentRetained 
            /// </summary>
            public const string PercentRetained = "RTGPERCENT";

            /// <summary>
            /// Property for DaysRetained 
            /// </summary>
            public const string DaysRetained = "RTGDAYS";

            /// <summary>
            /// Property for RetainageDueDate 
            /// </summary>
            public const string RetainageDueDate = "RTGDATEDUE";

            /// <summary>
            /// Property for RetainageTermsCode 
            /// </summary>
            public const string RetainageTermsCode = "RTGTERMS";

            /// <summary>
            /// Property for RetainageDueDateOverride 
            /// </summary>
            public const string RetainageDueDateOverride = "SWRTGDDTOV";

            /// <summary>
            /// Property for RetainageAmountOverride 
            /// </summary>
            public const string RetainageAmountOverride = "SWRTGAMTOV";

            /// <summary>
            /// Property for RetainageExchangeRate 
            /// </summary>
            public const string RetainageExchangeRate = "SWRTGRATE";

            /// <summary>
            /// Property for OptionalFields 
            /// </summary>
            public const string OptionalFields = "VALUES";

            /// <summary>
            /// Property for SourceApplication 
            /// </summary>
            public const string SourceApplication = "SRCEAPPL";

            /// <summary>
            /// Property for TaxReportingCurrencyCode 
            /// </summary>
            public const string TaxReportingCurrencyCode = "CODECURNRC";

            /// <summary>
            /// Property for TaxReportingCalculateMethod 
            /// </summary>
            public const string TaxReportingCalculateMethod = "SWTXCTLRC";

            /// <summary>
            /// Property for TaxReportingExchangeRate 
            /// </summary>
            public const string TaxReportingExchangeRate = "RATERC";

            /// <summary>
            /// Property for TaxReportingRateType 
            /// </summary>
            public const string TaxReportingRateType = "RATETYPERC";

            /// <summary>
            /// Property for TaxReportingRateDate 
            /// </summary>
            public const string TaxReportingRateDate = "RATEDATERC";

            /// <summary>
            /// Property for TaxReportingRateOperator 
            /// </summary>
            public const string TaxReportingRateOperator = "RATEOPRC";

            /// <summary>
            /// Property for TaxReportingRateOverride 
            /// </summary>
            public const string TaxReportingRateOverride = "SWRATERC";

            /// <summary>
            /// Property for TaxReportingAmount1 
            /// </summary>
            public const string TaxReportingAmount1 = "TXAMT1RC";

            /// <summary>
            /// Property for TaxReportingAmount2 
            /// </summary>
            public const string TaxReportingAmount2 = "TXAMT2RC";

            /// <summary>
            /// Property for TaxReportingAmount3 
            /// </summary>
            public const string TaxReportingAmount3 = "TXAMT3RC";

            /// <summary>
            /// Property for TaxReportingAmount4 
            /// </summary>
            public const string TaxReportingAmount4 = "TXAMT4RC";

            /// <summary>
            /// Property for TaxReportingAmount5 
            /// </summary>
            public const string TaxReportingAmount5 = "TXAMT5RC";

            /// <summary>
            /// Property for TaxReportingTotal 
            /// </summary>
            public const string TaxReportingTotal = "TXTOTRC";

            /// <summary>
            /// Property for RetainageTaxBase1 
            /// </summary>
            public const string RetainageTaxBase1 = "TXBSERT1TC";

            /// <summary>
            /// Property for RetainageTaxBase2 
            /// </summary>
            public const string RetainageTaxBase2 = "TXBSERT2TC";

            /// <summary>
            /// Property for RetainageTaxBase3 
            /// </summary>
            public const string RetainageTaxBase3 = "TXBSERT3TC";

            /// <summary>
            /// Property for RetainageTaxBase4 
            /// </summary>
            public const string RetainageTaxBase4 = "TXBSERT4TC";

            /// <summary>
            /// Property for RetainageTaxBase5 
            /// </summary>
            public const string RetainageTaxBase5 = "TXBSERT5TC";

            /// <summary>
            /// Property for RetainageTaxAmount1 
            /// </summary>
            public const string RetainageTaxAmount1 = "TXAMTRT1TC";

            /// <summary>
            /// Property for RetainageTaxAmount2 
            /// </summary>
            public const string RetainageTaxAmount2 = "TXAMTRT2TC";

            /// <summary>
            /// Property for RetainageTaxAmount3 
            /// </summary>
            public const string RetainageTaxAmount3 = "TXAMTRT3TC";

            /// <summary>
            /// Property for RetainageTaxAmount4 
            /// </summary>
            public const string RetainageTaxAmount4 = "TXAMTRT4TC";

            /// <summary>
            /// Property for RetainageTaxAmount5 
            /// </summary>
            public const string RetainageTaxAmount5 = "TXAMTRT5TC";

            /// <summary>
            /// Property for FuncTaxBase1 
            /// </summary>
            public const string FuncTaxBase1 = "TXBSE1HC";

            /// <summary>
            /// Property for FuncTaxBase2 
            /// </summary>
            public const string FuncTaxBase2 = "TXBSE2HC";

            /// <summary>
            /// Property for FuncTaxBase3 
            /// </summary>
            public const string FuncTaxBase3 = "TXBSE3HC";

            /// <summary>
            /// Property for FuncTaxBase4 
            /// </summary>
            public const string FuncTaxBase4 = "TXBSE4HC";

            /// <summary>
            /// Property for FuncTaxBase5 
            /// </summary>
            public const string FuncTaxBase5 = "TXBSE5HC";

            /// <summary>
            /// Property for FuncTaxAmount1 
            /// </summary>
            public const string FuncTaxAmount1 = "TXAMT1HC";

            /// <summary>
            /// Property for FuncTaxAmount2 
            /// </summary>
            public const string FuncTaxAmount2 = "TXAMT2HC";

            /// <summary>
            /// Property for FuncTaxAmount3 
            /// </summary>
            public const string FuncTaxAmount3 = "TXAMT3HC";

            /// <summary>
            /// Property for FuncTaxAmount4 
            /// </summary>
            public const string FuncTaxAmount4 = "TXAMT4HC";

            /// <summary>
            /// Property for FuncTaxAmount5 
            /// </summary>
            public const string FuncTaxAmount5 = "TXAMT5HC";

            /// <summary>
            /// Property for FuncDistributionwOrTaxTotal 
            /// </summary>
            public const string FuncDistributionwOrTaxTotal = "AMTGROSHC";

            /// <summary>
            /// Property for FuncRetainageAmount 
            /// </summary>
            public const string FuncRetainageAmount = "RTGAMTHC";

            /// <summary>
            /// Property for FuncDiscountAmount 
            /// </summary>
            public const string FuncDiscountAmount = "AMTDISCHC";

            /// <summary>
            /// Property for FuncPrepaymentAmount 
            /// </summary>
            public const string FuncPrepaymentAmount = "AMTPPDHC";

            /// <summary>
            /// Property for FuncAmountDue 
            /// </summary>
            public const string FuncAmountDue = "AMTDUEHC";

            /// <summary>
            /// Property for RetainageTaxTotal 
            /// </summary>
            public const string RetainageTaxTotal = "TXTOTRTTC";

            /// <summary>
            /// Property for TaxAmount1Total 
            /// </summary>
            public const string TaxAmount1Total = "TXTOTAMT1";

            /// <summary>
            /// Property for TaxAmount2Total 
            /// </summary>
            public const string TaxAmount2Total = "TXTOTAMT2";

            /// <summary>
            /// Property for TaxAmount3Total 
            /// </summary>
            public const string TaxAmount3Total = "TXTOTAMT3";

            /// <summary>
            /// Property for TaxAmount4Total 
            /// </summary>
            public const string TaxAmount4Total = "TXTOTAMT4";

            /// <summary>
            /// Property for TaxAmount5Total 
            /// </summary>
            public const string TaxAmount5Total = "TXTOTAMT5";

            /// <summary>
            /// Property for RetainageAmountfromDetails 
            /// </summary>
            public const string RetainageAmountFromDetails = "RTGAMTDTL";

            /// <summary>
            /// Property for EnteredBy 
            /// </summary>
            public const string EnteredBy = "ENTEREDBY";

            /// <summary>
            /// Property for PostingDate 
            /// </summary>
            public const string PostingDate = "DATEBUS";

            /// <summary>
            /// Property for InvoicePrinted 
            /// </summary>
            public const string InvoicePrinted = "SWPRTINVC";

            /// <summary>
            /// Property for AccountSet 
            /// </summary>
            public const string AccountSet = "IDACCTSET";

            #region Properties Specific to AR

            /// <summary>
            /// Property for LabelPrintedString
            /// </summary>
            public const string LabelPrintedString = "SWPRTLBL";
            
            /// <summary>
            /// Property for ShipToLocationCode 
            /// </summary>
            public const string ShipToLocationCode = "IDSHPT";

            /// <summary>
            /// Property for SpecialInstructions 
            /// </summary>
            public const string SpecialInstructions = "SPECINST";

            /// <summary>
            /// Property for PONumber 
            /// </summary>
            public const string PONumber = "CUSTPO";

            /// <summary>
            /// Property for Salesperson1 
            /// </summary>
            public const string Salesperson1 = "CODESLSP1";

            /// <summary>
            /// Property for Salesperson2 
            /// </summary>
            public const string Salesperson2 = "CODESLSP2";

            /// <summary>
            /// Property for Salesperson3 
            /// </summary>
            public const string Salesperson3 = "CODESLSP3";

            /// <summary>
            /// Property for Salesperson4 
            /// </summary>
            public const string Salesperson4 = "CODESLSP4";

            /// <summary>
            /// Property for Salesperson5 
            /// </summary>
            public const string Salesperson5 = "CODESLSP5";

            /// <summary>
            /// Property for SalesSplitPercentage1 
            /// </summary>
            public const string SalesSplitPercentage1 = "PCTSASPLT1";

            /// <summary>
            /// Property for SalesSplitPercentage2 
            /// </summary>
            public const string SalesSplitPercentage2 = "PCTSASPLT2";

            /// <summary>
            /// Property for SalesSplitPercentage3 
            /// </summary>
            public const string SalesSplitPercentage3 = "PCTSASPLT3";

            /// <summary>
            /// Property for SalesSplitPercentage4 
            /// </summary>
            public const string SalesSplitPercentage4 = "PCTSASPLT4";

            /// <summary>
            /// Property for SalesSplitPercentage5 
            /// </summary>
            public const string SalesSplitPercentage5 = "PCTSASPLT5";

            /// <summary>
            /// Property for DoNotCalcTax 
            /// </summary>
            public const string DoNotCalcTax = "SWMANTX";

            /// <summary>
            /// Property for TaxClass1 
            /// </summary>
            public const string TaxClass1 = "TAXSTTS1";

            /// <summary>
            /// Property for TaxClass2 
            /// </summary>
            public const string TaxClass2 = "TAXSTTS2";

            /// <summary>
            /// Property for TaxClass3 
            /// </summary>
            public const string TaxClass3 = "TAXSTTS3";

            /// <summary>
            /// Property for TaxClass4 
            /// </summary>
            public const string TaxClass4 = "TAXSTTS4";

            /// <summary>
            /// Property for TaxClass5 
            /// </summary>
            public const string TaxClass5 = "TAXSTTS5";

            /// <summary>
            /// Property for TaxableAmount 
            /// </summary>
            public const string TaxableAmount = "AMTTXBL";

            /// <summary>
            /// Property for NonTaxableAmount 
            /// </summary>
            public const string NonTaxableAmount = "AMTNOTTXBL";

            /// <summary>
            /// Property for DocumentTotalBeforeTax 
            /// </summary>
            public const string DocumentTotalBeforeTax = "AMTINVCTOT";

            /// <summary>
            /// Property for NumberofScheduledPayments 
            /// </summary>
            public const string NumberofScheduledPayments = "AMTPAYMTOT";

            /// <summary>
            /// Property for TotalPaymentAmountScheduled 
            /// </summary>
            public const string TotalPaymentAmountScheduled = "AMTPYMSCHD";

            /// <summary>
            /// Property for DocumentTotalIncludingTax 
            /// </summary>
            public const string DocumentTotalIncludingTax = "AMTNETTOT";

            /// <summary>
            /// Property for RecurringChargeCode 
            /// </summary>
            public const string RecurringChargeCode = "IDSTDINVC";

            /// <summary>
            /// Property for RecurringBillingCycle 
            /// </summary>
            public const string RecurringBillingCycle = "IDBILL";

            /// <summary>
            /// Property for ShipToLocationName 
            /// </summary>
            public const string ShipToLocationName = "SHPTOLOC";

            /// <summary>
            /// Property for ShipToAddressLine1 
            /// </summary>
            public const string ShipToAddressLine1 = "SHPTOSTE1";

            /// <summary>
            /// Property for ShipToAddressLine2 
            /// </summary>
            public const string ShipToAddressLine2 = "SHPTOSTE2";

            /// <summary>
            /// Property for ShipToAddressLine3 
            /// </summary>
            public const string ShipToAddressLine3 = "SHPTOSTE3";

            /// <summary>
            /// Property for ShipToAddressLine4 
            /// </summary>
            public const string ShipToAddressLine4 = "SHPTOSTE4";

            /// <summary>
            /// Property for ShipToCity 
            /// </summary>
            public const string ShipToCity = "SHPTOCITY";

            /// <summary>
            /// Property for ShipToStateOrProv 
            /// </summary>
            public const string ShipToStateOrProv = "SHPTOSTTE";

            /// <summary>
            /// Property for ShipToZipOrPostalCode 
            /// </summary>
            public const string ShipToZipOrPostalCode = "SHPTOPOST";

            /// <summary>
            /// Property for ShipToCountry 
            /// </summary>
            public const string ShipToCountry = "SHPTOCTRY";

            /// <summary>
            /// Property for ShipToContactName 
            /// </summary>
            public const string ShipToContactName = "SHPTOCTAC";

            /// <summary>
            /// Property for ShipToPhoneNumber 
            /// </summary>
            public const string ShipToPhoneNumber = "SHPTOPHON";

            /// <summary>
            /// Property for ShipToFaxNumber 
            /// </summary>
            public const string ShipToFaxNumber = "SHPTOFAX";

            /// <summary>
            /// Property for CustOrNatlOverCreditFlag 
            /// </summary>
            public const string CustOrNatlOverCreditFlag = "SWPROCPPD";

            /// <summary>
            /// Property for RateOperator 
            /// </summary>
            public const string RateOperator = "CUROPER";

            /// <summary>
            /// Property for ForceRereadofIBSTotals 
            /// </summary>
            public const string ForceRereadofIBSTotals = "GETIBSINFO";

            /// <summary>
            /// Property for ProcessCommand 
            /// </summary>
            public const string ProcessCommand = "PROCESSCMD";

            /// <summary>
            /// Property for ShipViaCode 
            /// </summary>
            public const string ShipViaCode = "SHPVIACODE";

            /// <summary>
            /// Property for ShipViaDescription 
            /// </summary>
            public const string ShipViaDescription = "SHPVIADESC";

            /// <summary>
            /// Property for ShipToEmail 
            /// </summary>
            public const string ShipToEmail = "EMAIL";

            /// <summary>
            /// Property for ShipToContactsPhone 
            /// </summary>
            public const string ShipToContactsPhone = "CTACPHONE";

            /// <summary>
            /// Property for ShipToContactsFax 
            /// </summary>
            public const string ShipToContactsFax = "CTACFAX";

            /// <summary>
            /// Property for ShipToContactsEmail 
            /// </summary>
            public const string ShipToContactsEmail = "CTACEMAIL";

            /// <summary>
            /// Property for InvoiceType 
            /// </summary>
            public const string InvoiceType = "INVCTYPE";

            /// <summary>
            /// Property for AOrRVersionCreatedIn 
            /// </summary>
            public const string AOrRVersionCreatedIn = "ARVERSION";

            /// <summary>
            /// Property for TaxStateVersion 
            /// </summary>
            public const string TaxStateVersion = "TAXVERSION";

            /// <summary>
            /// Property for ReportRetainageTax 
            /// </summary>
            public const string ReportRetainageTax = "SWTXRTGRPT";

            /// <summary>
            /// Property for FuncDistributionwOroTaxTotal 
            /// </summary>
            public const string FuncDistributionwOroTaxTotal = "DISTNETHC";

            /// <summary>
            /// Property for LabelPrinted 
            /// </summary>
            public const string LabelPrinted = "SWPRTLBL";

            /// <summary>
            /// Property for ShipmentNumber 
            /// </summary>
            public const string ShipmentNumber = "IDSHIPNBR";

            /// <summary>
            /// Property for ShipmentNumber 
            /// </summary>
            public const string FuncDistributionOrTaxTotal = "AMTGROSHC";

            /// <summary>
            /// Property for DoOOrECostingandConsolidation 
            /// </summary>
            public const string DoOOrECostingandConsolidation = "SWOECOST";

            /// <summary>
            /// Property for DocumentTypeString 
            /// </summary>
            public const string DocumentTypeString = "TEXTTRX";

            /// <summary>
            /// Property for TaxReportingRateOperatorString 
            /// </summary>
            public const string TaxReportingRateOperatorString = "RATEOPRC";

            /// <summary>
            /// Property for InvoiceTypeString
            /// </summary>
            public const string InvoiceTypeString = "INVCTYPE";

            /// <summary>
            /// Property for ProcessCommand 
            /// </summary>
            public const string ProcessCommandString = "PROCESSCMD";

            #endregion

            #region Properties Specific to AP

            /// <summary>
            /// Property for Originator 
            /// </summary>
            public const string Originator = "ORIGCOMP";
            

            /// <summary>
            /// Property for RemitToLocation 
            /// </summary>
            public const string RemitToLocation = "IDRMITTO";


            /// <summary>
            /// Property for PONumber 
            /// </summary>
            public const string APPONumber = "PONBR";
            
            /// <summary>
            /// Property for TermsOverridden 
            /// </summary>
            public const string TermsOverridden = "SWTERMOVRD";
            
            /// <summary>
            /// Property for TaxAmountControl 
            /// </summary>
            public const string TaxAmountControl = "SWCALCTX";
            
            /// <summary>
            /// Property for TaxClass1 
            /// </summary>
            public const string APTaxClass1 = "TAXCLASS1";

            /// <summary>
            /// Property for TaxClass2 
            /// </summary>
            public const string APTaxClass2 = "TAXCLASS2";

            /// <summary>
            /// Property for TaxClass3 
            /// </summary>
            public const string APTaxClass3 = "TAXCLASS3";

            /// <summary>
            /// Property for TaxClass4 
            /// </summary>
            public const string APTaxClass4 = "TAXCLASS4";

            /// <summary>
            /// Property for TaxClass5 
            /// </summary>
            public const string APTaxClass5 = "TAXCLASS5";


            /// <summary>
            /// Property for Num1099OrCPRSAmount 
            /// </summary>
            public const string Num1099OrCPRSAmount = "AMT1099";

            /// <summary>
            /// Property for DistributionSetAmount 
            /// </summary>
            public const string DistributionSetAmount = "AMTDISTSET";

            /// <summary>
            /// Property for TotalDistributedTax 
            /// </summary>
            public const string TotalDistributedTax = "AMTTAXDIST";

            /// <summary>
            /// Property for DocumentTotalBeforeTaxes 
            /// </summary>
            public const string DocumentTotalBeforeTaxes = "AMTINVCTOT";

            /// <summary>
            /// Property for DistributedAllocatedTaxes 
            /// </summary>
            public const string DistributedAllocatedTaxes = "AMTALLOCTX";

            /// <summary>
            /// Property for NumberofScheduledPayments 
            /// </summary>
            public const string APNumberofScheduledPayments = "CNTPAYMSCH";

            /// <summary>
            /// Property for DistributedTotalBeforeTaxes 
            /// </summary>
            public const string DistributedTotalBeforeTaxes = "AMTTOTDIST";

            /// <summary>
            /// Property for DistributedTotalIncludingTax 
            /// </summary>
            public const string DistributedTotalIncludingTax = "AMTGROSDST";

            /// <summary>
            /// Property for LocationName 
            /// </summary>
            public const string LocationName = "TEXTRMIT";

            /// <summary>
            /// Property for AddressLine1 
            /// </summary>
            public const string AddressLine1 = "TEXTSTE1";

            /// <summary>
            /// Property for AddressLine2 
            /// </summary>
            public const string AddressLine2 = "TEXTSTE2";

            /// <summary>
            /// Property for AddressLine3 
            /// </summary>
            public const string AddressLine3 = "TEXTSTE3";

            /// <summary>
            /// Property for AddressLine4 
            /// </summary>
            public const string AddressLine4 = "TEXTSTE4";

            /// <summary>
            /// Property for City 
            /// </summary>
            public const string City = "NAMECITY";

            /// <summary>
            /// Property for StateOrProv 
            /// </summary>
            public const string StateOrProv = "CODESTTE";

            /// <summary>
            /// Property for ZipOrPostalCode 
            /// </summary>
            public const string ZipOrPostalCode = "CODEPSTL";

            /// <summary>
            /// Property for Country 
            /// </summary>
            public const string Country = "CODECTRY";

            /// <summary>
            /// Property for ContactName 
            /// </summary>
            public const string ContactName = "NAMECTAC";

            /// <summary>
            /// Property for PhoneNumber 
            /// </summary>
            public const string PhoneNumber = "TEXTPHON";

            /// <summary>
            /// Property for FaxNumber 
            /// </summary>
            public const string FaxNumber = "TEXTFAX";

            /// <summary>
            /// Property for RecoverableTaxes 
            /// </summary>
            public const string RecoverableTaxes = "AMTRECTAX";

            /// <summary>
            /// Property for VendorGroupCode 
            /// </summary>
            public const string VendorGroupCode = "CODEVNDGRP";

            /// <summary>
            /// Property for TermsDescription 
            /// </summary>
            public const string TermsDescription = "TERMSDESC";

            /// <summary>
            /// Property for DistributionSet 
            /// </summary>
            public const string DistributionSet = "IDDISTSET";

            /// <summary>
            /// Property for Num1099OrCPRSCode 
            /// </summary>
            public const string Num1099OrCPRSCode = "ID1099CLAS";


            /// <summary>
            /// Property for GeneratePaymentSchedule 
            /// </summary>
            public const string GeneratePaymentSchedule = "CREATESCHD";

            /// <summary>
            /// Property for DocumentTotalIncludingTax 
            /// </summary>
            public const string APDocumentTotalIncludingTax = "AMTGROSTOT";

            /// <summary>
            /// Property for UndistributedAmount 
            /// </summary>
            public const string UndistributedAmount = "AMTUNDISTR";

            /// <summary>
            /// Property for TaxInclusive1 
            /// </summary>
            public const string TaxInclusive1 = "SWTAXINCL1";

            /// <summary>
            /// Property for TaxInclusive2 
            /// </summary>
            public const string TaxInclusive2 = "SWTAXINCL2";

            /// <summary>
            /// Property for TaxInclusive3 
            /// </summary>
            public const string TaxInclusive3 = "SWTAXINCL3";

            /// <summary>
            /// Property for TaxInclusive4 
            /// </summary>
            public const string TaxInclusive4 = "SWTAXINCL4";

            /// <summary>
            /// Property for TaxInclusive5 
            /// </summary>
            public const string TaxInclusive5 = "SWTAXINCL5";

            /// <summary>
            /// Property for ExpensedSeparatelyTaxes 
            /// </summary>
            public const string ExpensedSeparatelyTaxes = "AMTEXPTAX";

            /// <summary>
            /// Property for TaxAmounttobeAllocated 
            /// </summary>
            public const string TaxAmountToBeAllocated = "AMTAXTOBE";

            /// <summary>
            /// Property for CurrencyCodeOperator 
            /// </summary>
            public const string CurrencyCodeOperator = "CODEOPER";

            /// <summary>
            /// Property for RecoverableAccount1 
            /// </summary>
            public const string RecoverableAccount1 = "ACCTREC1";

            /// <summary>
            /// Property for RecoverableAccount2 
            /// </summary>
            public const string RecoverableAccount2 = "ACCTREC2";

            /// <summary>
            /// Property for RecoverableAccount3 
            /// </summary>
            public const string RecoverableAccount3 = "ACCTREC3";

            /// <summary>
            /// Property for RecoverableAccount4 
            /// </summary>
            public const string RecoverableAccount4 = "ACCTREC4";

            /// <summary>
            /// Property for RecoverableAccount5 
            /// </summary>
            public const string RecoverableAccount5 = "ACCTREC5";

            /// <summary>
            /// Property for ExpenseSepAccount1 
            /// </summary>
            public const string ExpenseSepAccount1 = "ACCTEXP1";

            /// <summary>
            /// Property for ExpenseSepAccount2 
            /// </summary>
            public const string ExpenseSepAccount2 = "ACCTEXP2";

            /// <summary>
            /// Property for ExpenseSepAccount3 
            /// </summary>
            public const string ExpenseSepAccount3 = "ACCTEXP3";

            /// <summary>
            /// Property for ExpenseSepAccount4 
            /// </summary>
            public const string ExpenseSepAccount4 = "ACCTEXP4";

            /// <summary>
            /// Property for ExpenseSepAccount5 
            /// </summary>
            public const string ExpenseSepAccount5 = "ACCTEXP5";


            /// <summary>
            /// Property for ProcessCommandCode 
            /// </summary>
            public const string ProcessCommandCode = "PROCESSCMD";

            /// <summary>
            /// Property for DistRecoverableTaxes 
            /// </summary>
            public const string DistRecoverableTaxes = "AMTRECDIST";

            /// <summary>
            /// Property for DistExpSeparatelyTaxes 
            /// </summary>
            public const string DistExpSeparatelyTaxes = "AMTEXPDIST";

            /// <summary>
            /// Property for Email 
            /// </summary>
            public const string Email = "EMAIL";

            /// <summary>
            /// Property for ContactsPhone 
            /// </summary>
            public const string ContactsPhone = "CTACPHONE";

            /// <summary>
            /// Property for ContactsFax 
            /// </summary>
            public const string ContactsFax = "CTACFAX";

            /// <summary>
            /// Property for ContactsEmail 
            /// </summary>
            public const string ContactsEmail = "CTACEMAIL";

            /// <summary>
            /// Property for RecurringPayableCode 
            /// </summary>
            public const string RecurringPayableCode = "IDSTDINVC";
            
            /// <summary>
            /// Property for TaxBaseControl 
            /// </summary>
            public const string TaxBaseControl = "SWTXBSECTL";


            /// <summary>
            /// Property for DetailCount 
            /// </summary>
            public const string DetailCount = "DETAILCNT";

            /// <summary>
            /// Property for OnHold 
            /// </summary>
            public const string OnHold = "SWHOLD";

            /// <summary>
            /// Property for OrigExists 
            /// </summary>
            public const string OrigExists = "ORIGEXIST";

            /// <summary>
            /// Property for OrigName 
            /// </summary>
            public const string OrigName = "ORIGNAME";

            /// <summary>
            /// Property for OrigStatus 
            /// </summary>
            public const string OrigStatus = "ORIGSTAT";

            /// <summary>
            /// Property for VendorExists 
            /// </summary>
            public const string VendorExists = "VENEXIST";

            /// <summary>
            /// Property for VendorName 
            /// </summary>
            public const string VendorName = "VENNAME";

            /// <summary>
            /// Property for VendorNumber 
            /// </summary>
            public const string VendorNumber = "IDVEND";

            /// <summary>
            /// Property for VendorDistType 
            /// </summary>
            public const string VendorDistType = "VENDISTBY";

            /// <summary>
            /// Property for VendorDistCode 
            /// </summary>
            public const string VendorDistCode = "VENDISTCOD";

            /// <summary>
            /// Property for VendorAccount 
            /// </summary>
            public const string VendorAccount = "VENACCT";

            /// <summary>
            /// Property for VendorTaxReportType 
            /// </summary>
            public const string VendorTaxReportType = "VENTXRPTSW";

            /// <summary>
            /// Property for RemitExists 
            /// </summary>
            public const string RemitExists = "RMTEXIST";

            /// <summary>
            /// Property for RemitName 
            /// </summary>
            public const string RemitName = "RMTNAME";

            /// <summary>
            /// Property for Num1099OrCPRSExists 
            /// </summary>
            public const string Num1099OrCPRSExists = "CLSEXIST";

            /// <summary>
            /// Property for Num1099OrCPRSDescription 
            /// </summary>
            public const string Num1099OrCPRSDescription = "CLSDESC";

            /// <summary>
            /// Property for DistSetExists 
            /// </summary>
            public const string DistSetExists = "DSETEXIST";

            /// <summary>
            /// Property for DistSetDescription 
            /// </summary>
            public const string DistSetDescription = "DSETDESC";

            /// <summary>
            /// Property for DistSetMethod 
            /// </summary>
            public const string DistSetMethod = "DSETMETH";

            /// <summary>
            /// Property for TermExists 
            /// </summary>
            public const string TermExists = "TERMEXIST";

            /// <summary>
            /// Property for TermUsePaymentSchedule 
            /// </summary>
            public const string TermUsePaymentSchedule = "TERMMULPAY";

            /// <summary>
            /// Property for RTGTermExists 
            /// </summary>
            public const string RTGTermExists = "RTERMEXIST";

            /// <summary>
            /// Property for RTGTermDescription 
            /// </summary>
            public const string RTGTermDescription = "RTERMDESC";

            /// <summary>
            /// Property for PMLevel1Name 
            /// </summary>
            public const string PMLevel1Name = "PMLEV1NAME";

            /// <summary>
            /// Property for PMLevel2Name 
            /// </summary>
            public const string PMLevel2Name = "PMLEV2NAME";

            /// <summary>
            /// Property for PMLevel3Name 
            /// </summary>
            public const string PMLevel3Name = "PMLEV3NAME";

            /// <summary>
            /// Property for TaxGroupDescription 
            /// </summary>
            public const string TaxGroupDescription = "TXGRPDESC";

            /// <summary>
            /// Property for TaxAuth1Description 
            /// </summary>
            public const string TaxAuth1Description = "TXAU1DESC";

            /// <summary>
            /// Property for TaxAuth2Description 
            /// </summary>
            public const string TaxAuth2Description = "TXAU2DESC";

            /// <summary>
            /// Property for TaxAuth3Description 
            /// </summary>
            public const string TaxAuth3Description = "TXAU3DESC";

            /// <summary>
            /// Property for TaxAuth4Description 
            /// </summary>
            public const string TaxAuth4Description = "TXAU4DESC";

            /// <summary>
            /// Property for TaxAuth5Description 
            /// </summary>
            public const string TaxAuth5Description = "TXAU5DESC";

            /// <summary>
            /// Property for AOrPVersionCreatedIn 
            /// </summary>
            public const string AorPVersionCreatedIn = "APVERSION";
            
            /// <summary>
            /// Property for TaxReportingAllocatedTax 
            /// </summary>
            public const string TaxReportingAllocatedTax = "TXALLRC";

            /// <summary>
            /// Property for TaxReportingExpensedTax 
            /// </summary>
            public const string TaxReportingExpensedTax = "TXEXPRC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax 
            /// </summary>
            public const string TaxReportingRecoverableTax = "TXRECRC";
            
            /// <summary>
            /// Property for Func1099OrCPRSAmount 
            /// </summary>
            public const string Func1099OrCPRSAmount = "AMT1099HC";

            /// <summary>
            /// Property for AMTDUETC 
            /// </summary>
            public const string TaxAmountDue = "AMTDUETC";
            
            /// <summary>
            /// Property for TEXTVEN 
            /// </summary>
            public const string VendorNameTax = "TEXTVEN";

            /// <summary>
            /// Property for AcctSetDescription 
            /// </summary>
            public const string AcctSetDescription = "ASETDESC";

            #endregion            

            #endregion
        }

        /// <summary>
        /// Base Invoice Index Class
        /// </summary>
        public partial class BaseIndex
        {
        }
    }
}
