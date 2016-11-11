/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Constant file for Order Entry module
    /// </summary>
    public static class OrderEntry
    {
        #region Session
        /// <summary>
        /// Session Key for Optional Field 
        /// </summary>
        public const string SessionMiscChargeOptionalField = "oemiscchargeoptionalFieldCache";

        /// <summary>
        /// Session Key for Optional Field 
        /// </summary>
        public const string SessionMiscChargeTaxDetail = "oemiscchargetaxtetailcache";

        /// <summary>
        /// The credit debit note session optional field
        /// </summary>
        public const string CreditDebitNoteSessionOptionalField = "creditdebitnotesessionoptionalfield";
        #endregion

        #region Sales Statistics Report

        /// <summary>
        /// OE Sales Statistics Report
        /// </summary>
        public const string SalesStatisticsReport = "~/Areas/OE/Views/SalesStatisticsReport/Partials/_SalesStatisticsReport.cshtml";
        /// <summary>
        /// OE Sales Statistics Report Localization
        /// </summary>
        public const string SalesStatisticsReportLocalization = "~/Areas/OE/Views/SalesStatisticsReport/Partials/_Localization.cshtml";

        /// <summary>
        /// OE Invoice Action report
        /// </summary>
        public const string InvoiceActionReport = "~/Areas/OE/Views/InvoiceActionReport/Partials/_InvoiceActionReport.cshtml";
        /// <summary>
        /// OE Invoice Action report Localization
        /// </summary>
        public const string InvoiceActionReportLocalization = "~/Areas/OE/Views/InvoiceActionReport/Partials/_Localization.cshtml";

        /// <summary>
        /// The CreateBatch
        /// </summary>
        public const string OECreateBatch = "~/Areas/OE/Views/CreateBatch/Partials/_CreateBatch.cshtml";

        #endregion

        #region AgedOrder
        /// <summary>
        ///Aged Order Localization
        /// </summary>
        public const string AgedOrderReportLocalization = "~/Areas/OE/Views/AgedOrderReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Aged Order report cshtml
        /// </summary>
        public const string AgedOrderReport = "~/Areas/OE/Views/AgedOrderReport/Partials/_AgedOrderReport.cshtml";
        #endregion

        #region TransactionList Report
        /// <summary>
        /// Transaction List Report Localization
        /// </summary>
        public const string TransactionListReportLocalization = "~/Areas/OE/Views/TransactionListReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Transaction List Report
        /// </summary>
        public const string TransactionListReport = "~/Areas/OE/Views/TransactionListReport/Partials/_TransactionListReport.cshtml";

        #endregion

        #region Credit Debit Note Entry

        /// <summary>
        /// The credit debit note entry
        /// </summary>
        public const string CreditDebitNoteEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitNoteEntry.cshtml";

        /// <summary>
        /// Customer Bill To Address
        /// </summary>
        public const string CreditDebitCustomerBillToAddress = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CustomerBillToAddress.cshtml";

        /// <summary>
        /// Ship to Address
        /// </summary>
        public const string CreditDebitShipToAddress = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_ShipToAddress.cshtml";

        /// <summary>
        /// Pre-Credit Check
        /// </summary>
        public const string PreCreditCheck = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_PreCreditCheck.cshtml";

        /// <summary>
        /// Pre-Credit Check
        /// </summary>
        public const string CreditDebitNoteTab = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitNote.cshtml";

        /// <summary>
        /// Location Quantity Order Entry
        /// </summary>
        public const string CreditDebitLocationQuantity = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_LocationQuantity.cshtml";

        /// <summary>
        /// The credit debit note entry localization
        /// </summary>
        public const string CreditDebitNoteEntryLocalization = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Credit Debit Detail Grid
        /// </summary>
        public const string CreditDebitDetail = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitDetailGrid.cshtml";

        /// <summary>
        /// Credit Debit Comments/Instruction Grid
        /// </summary>
        public const string CreditDebitDetailCommentsInstructionGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitDetailCommentsInstructionGrid.cshtml";

        /// <summary>
        /// Credit Debit Comments/Instruction View
        /// </summary>
        public const string CreditDebitDetailCommentsInstruction = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitDetailCommentsInstruction.cshtml";

        /// <summary>
        /// Credit Debit Price Approval View
        /// </summary>
        public const string PriceApproval = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_PriceApproval.cshtml";

        /// <summary>
        /// Credit Debit Taxes Grid
        /// </summary>
        public const string CreditDebitTaxesGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitTaxesGrid.cshtml";

        /// <summary>
        /// Credit Debit Taxes Tab Grid
        /// </summary>
        public const string CreditDebitTaxesTabGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitNoteTaxes.cshtml";

        /// <summary>
        /// Credit Debit Customer Tab
        /// </summary>
        public const string CreditDebitCustomerEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitCustomerEntry.cshtml";

        public const string CreditDebitNoteOptionalFieldsTab = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_OptionalFields.cshtml";

        /// <summary>
        /// Item Quantity on SO Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitQuantityonSoGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitQuantityOnSOGrid.cshtml";

        /// <summary>
        /// Item Quantity on PO Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitQuantityonPoGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitQuantityOnPOGrid.cshtml";

        /// <summary>
        /// Item Quantity Committed Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitQuantityCommittedGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitQuantityCommittedGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity on SO Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitAllLocQuantitySoGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitAllLocQuantityOnSOGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity on PO Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitAllLocQuantityPoGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitAllLocQuantityOnPOGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity Committed Grid for CreditDebit Entry
        /// </summary>
        public const string CreditDebitAllLocQuantityCommittedGridEntry = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitAllLocQuantityCommittedGrid.cshtml";


        /// <summary>
        /// Credit Debit Kitting Component Grid
        /// </summary>
        public const string KittingComponentGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_KittingComponentGrid.cshtml";

        /// <summary>
        /// Kitting item Quantity Pannel 
        /// </summary>
        public const string CreditDebitKittingLocationQuantity = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_KittingLocationQuantity.cshtml";

        /// <summary>
        /// Credit Debit Item Taxes Grid
        /// </summary>
        public const string ItemTaxesGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_ItemTaxesGrid.cshtml";

        /// <summary>
        /// Sales file for Credit Debit Note Entry
        /// </summary>
        public const string CreditDebitNoteSalesTab = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_SalesSplit.cshtml";

        /// <summary>
        /// Credit Debit Rates Tab
        /// </summary>
        public const string CreditDebitNoteRatesTab = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_Rates.cshtml";

        //Bom components starts
        /// <summary>
        /// Bom Component Grid
        /// </summary>
        public const string BomGrid = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_BomGrid.cshtml";

        public const string BomComponents = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/BomComponents.cshtml";
        //Bom components ends

        /// <summary>
        /// Total tab
        /// </summary>
        public const string CreditDebitNoteTotalsTab = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_Totals.cshtml";

        /// <summary>
        /// Credit Debit Detail Optional Field  Grid 
        /// </summary>
        public const string CreditDebitDetailOptionalField = "~/Areas/OE/Views/CreditDebitNoteEntry/Partials/_CreditDebitDetailOptionalField.cshtml";
        #endregion

        #region GL Transaction

        ///<summary>
        /// The GLTransaction Partial View
        /// </summary>
        public const string GlTransactionRpt = "~/Areas/OE/Views/GLTransaction/Partials/_GLTransaction.cshtml";

        #endregion

        #region Sales History

        /// <summary>
        ///  Sales History Partial View
        /// </summary>
        public const string SalesHistory = "~/Areas/OE/Views/SalesHistory/Partials/_SalesHistory.cshtml";

        /// <summary>
        ///  Sales History Partial View
        /// </summary>
        public const string SalesHistoryGrid = "~/Areas/OE/Views/SalesHistory/Partials/_SalesHistoryGrid.cshtml";

        /// <summary>
        /// Sales History localization
        /// </summary>
        public const string SalesHistoryLocalization =
            "~/Areas/OE/Views/SalesHistory/Partials/_Localization.cshtml";

        #endregion

        #region Sales History Detail

        /// <summary>
        ///  Sales History Detail Partial View
        /// </summary>
        public const string SalesHistoryDetail = "~/Areas/OE/Views/SalesHistory/Partials/_SalesHistoryDetail.cshtml";

        /// <summary>
        ///  Sales History Detail Partial View
        /// </summary>
        public const string SalesHistoryDetailGrid = "~/Areas/OE/Views/SalesHistory/Partials/_SalesHistoryDetailGrid.cshtml";

        #endregion

        #region SalespersonCommissionsReport

        /// <summary>
        /// OE Invoice Action report
        /// </summary>
        public const string SalespersonCommissionsReport = "~/Areas/OE/Views/SalespersonCommissionReport/Partials/_SalespersonCommissionReport.cshtml";
        /// <summary>
        /// OE Invoice Action report Localization
        /// </summary>
        public const string SalespersonCommissionsReportLocalization = "~/Areas/OE/Views/SalespersonCommissionReport/Partials/_Localization.cshtml";

        #endregion

        #region Optionalfields

        /// <summary>
        /// Session Key for Item Segments
        /// </summary>
        public const string SessionOptionalField = "oeOptionalFieldCache";

        /// <summary>
        /// The OptionalField
        /// </summary>
        public const string OptionalField = "~/Areas/OE/Views/OptionalField/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The OptionalField localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/OE/Views/OptionalField/Partials/_Localization.cshtml";

        /// <summary>
        /// The OptionalField grid
        /// </summary>
        public const string OptionalFieldGrid = "~/Areas/OE/Views/OptionalField/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The OptionalField Settings
        /// </summary>
        public const string OptionalFieldSettings =
            "~/Areas/OE/Views/OptionalField/Partials/_OptionalFieldSettings.cshtml";

        /// <summary>
        /// Session Key for Interest Batch Optional Field 
        /// </summary>
        public const string SessionInterestBatchOptionalField = "oeInterestBatchOptionalFieldCache";

        /// <summary>
        /// Session Key for Interest Batch Detail Optional Field 
        /// </summary>
        public const string SessionInterestBatchDetailOptionalField = "oeInterestBatchDetailOptionalFieldCache";

        #endregion

        #region OEClearHistory

        /// <summary>
        /// OE ClearHistory
        /// </summary>
        public const string OEClearHistory = "~/Areas/OE/Views/ClearHistory/Partials/_ClearHistory.cshtml";
        /// <summary>
        /// OE ClearHistory
        /// </summary>
        public const string OEClearHistoryLocalization = "~/Areas/OE/Views/ClearHistory/Partials/_Localization.cshtml";

        #endregion

        #region Order Entry

        /// <summary>
        /// The OrderEntry
        /// </summary>
        public const string OrderEntryScreen = "~/Areas/OE/Views/OrderEntry/Partials/_OrderEntry.cshtml";
        /// <summary>
        /// Localization file for Order Entry
        /// </summary>
        public const string OrderEntryLocalization = "~/Areas/OE/Views/OrderEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Order partial view 
        /// </summary>
        public const string Order = "~/Areas/OE/Views/OrderEntry/Partials/_Order.cshtml";

        /// <summary>
        /// Rates partial view 
        /// </summary>
        public const string Rates = "~/Areas/OE/Views/OrderEntry/Partials/_Rates.cshtml";

        /// <summary>
        /// Customer file for Order Entry
        /// </summary>
        public const string Customer = "~/Areas/OE/Views/OrderEntry/Partials/_Customer.cshtml";

        /// <summary>
        /// Taxes file for Order Entry
        /// </summary>
        public const string Taxes = "~/Areas/OE/Views/OrderEntry/Partials/_Taxes.cshtml";

        /// <summary>
        /// Total file for Order Entry
        /// </summary>
        public const string Total = "~/Areas/OE/Views/OrderEntry/Partials/_Total.cshtml";

        /// <summary>
        /// Order Detail Grid for Order Entry
        /// </summary>
        public const string OrderEntryDetail = "~/Areas/OE/Views/OrderEntry/Partials/_OrderDetailGrid.cshtml";

        /// <summary>
        /// Location Quantity Order Entry
        /// </summary>
        public const string LocationQuantity = "~/Areas/OE/Views/OrderEntry/Partials/_LocationQuantity.cshtml";

        /// <summary>
        /// Customer Bill-To Address file for Order Entry
        /// </summary>
        public const string CustomerBillToAddress = "~/Areas/OE/Views/OrderEntry/Partials/_CustomerBillToAddress.cshtml";

        /// <summary>
        /// Ship-To Address file for Order Entry
        /// </summary>
        public const string ShipToAddress = "~/Areas/OE/Views/OrderEntry/Partials/_ShipToAddress.cshtml";

        /// <summary>
        /// Ship-To Address file for Order Entry
        /// </summary>
        public const string CreateOrderFromQuotes = "~/Areas/OE/Views/OrderEntry/Partials/_CreateOrderFromQuotes.cshtml";

        /// <summary>
        /// Pre Credit Check file for Order Entry
        /// </summary>
        public const string PreCreditCheckOrderEntry = "~/Areas/OE/Views/OrderEntry/Partials/_PreCreditCheck.cshtml";

        /// <summary>
        /// Prepayment for Order Entry
        /// </summary>
        public const string PrepaymentOrderEntry = "~/Areas/OE/Views/OrderEntry/Partials/_Prepayment.cshtml";

        /// <summary>
        /// Prepayment for Order Entry
        /// </summary>
        public const string BankRate = "~/Areas/OE/Views/OrderEntry/Partials/_BankRate.cshtml";

        /// <summary>
        /// Item Quantity on SO Grid for Order Entry
        /// </summary>
        public const string QuantityonSoGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_QuantityOnSOGrid.cshtml";

        /// <summary>
        /// Item Quantity on PO Grid for Order Entry
        /// </summary>
        public const string QuantityonPoGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_QuantityOnPOGrid.cshtml";

        /// <summary>
        /// Item Quantity Committed Grid for Order Entry
        /// </summary>
        public const string QuantityCommittedGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_QuantityCommittedGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity on SO Grid for Order Entry
        /// </summary>
        public const string AllLocQuantitySoGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_AllLocQuantityOnSOGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity on PO Grid for Order Entry
        /// </summary>
        public const string AllLocQuantityPoGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_AllLocQuantityOnPOGrid.cshtml";

        /// <summary>
        /// All Location Item Quantity Committed Grid for Order Entry
        /// </summary>
        public const string AllLocQuantityCommittedGridEntry = "~/Areas/OE/Views/OrderEntry/Partials/_AllLocQuantityCommittedGrid.cshtml";

        /// <summary>
        /// Sales file for Order Entry
        /// </summary>
        public const string Sales = "~/Areas/OE/Views/OrderEntry/Partials/_Sales.cshtml";

        /// <summary>
        /// Sales file for Order Entry
        /// </summary>
        public const string OEOptionalField = "~/Areas/OE/Views/OrderEntry/Partials/_OptionalField.cshtml";
        /// <summary>
        /// Sales file for Order Entry
        /// </summary>
        public const string DetailTax = "~/Areas/OE/Views/OrderEntry/Partials/_DetailTaxGrid.cshtml";

        /// <summary>
        /// Order entry Comments/Instruction Grid
        /// </summary>
        public const string CommentsInstructionGrid = "~/Areas/OE/Views/OrderEntry/Partials/_CommentsInstructionGrid.cshtml";
        /// <summary>
        /// Order entry Comments/Instruction partial
        /// </summary>
        public const string CommentsInstruction = "~/Areas/OE/Views/OrderEntry/Partials/_CommentsInstruction.cshtml";

        /// <summary>
        /// Order entry OrderToShipmentDrillDownGrid Grid
        /// </summary>
        public const string OrderToShipmentDrillDownGrid = "~/Areas/OE/Views/OrderEntry/Partials/_OrderToShipmentDrillDownGrid.cshtml";
        /// <summary>
        /// Detail Optional Field for Order Entry
        /// </summary>
        public const string DetailOptionalField = "~/Areas/OE/Views/OrderEntry/Partials/_DetailOptionalField.cshtml";
        /// <summary>
        /// Order Confirmations Report Delivery Method
        /// </summary>
        public const string OrderConfirmationDeliveryMethod = "~/Areas/OE/Views/OrderConfirmationReport/Partials/_DeliveryMethod.cshtml";

        /// <summary>
        /// Order Confirmation report
        /// </summary>
        public const string OrderConfirmationReport = "~/Areas/OE/Views/OrderConfirmationReport/Partials/_OrderConfirmationReport.cshtml";

        /// <summary>
        /// Order Confirmation Localization
        /// </summary>
        public const string OrderConfirmationReportLocalization = "~/Areas/OE/Views/OrderConfirmationReport/Partials/_Localization.cshtml";


        /// <summary>
        /// Invoice Report Delivery Method
        /// </summary>
        public const string InvoiceDeliveryMethod = "~/Areas/OE/Views/InvoiceReport/Partials/_DeliveryMethod.cshtml";

        /// <summary>
        /// Invoice report
        /// </summary>
        public const string InvoiceReport = "~/Areas/OE/Views/InvoiceReport/Partials/_InvoiceReport.cshtml";

        /// <summary>
        /// Invoice Report Localization
        /// </summary>
        public const string InvoiceReportLocalization = "~/Areas/OE/Views/InvoiceReport/Partials/_Localization.cshtml";


        /// <summary>
        /// Picking Slip Report Delivery Method
        /// </summary>
        public const string PickingSlipDeliveryMethod = "~/Areas/OE/Views/PickingSlipReport/Partials/_DeliveryMethod.cshtml";

        /// <summary>
        /// Picking Slip report
        /// </summary>
        public const string PickingSlipReport = "~/Areas/OE/Views/PickingSlipReport/Partials/_PickingSlipReport.cshtml";

        /// <summary>
        /// Picking Slip report Localization
        /// </summary>
        public const string PickingSlipReportLocalization = "~/Areas/OE/Views/PickingSlipReport/Partials/_Localization.cshtml";

        /// <summary>
        ///Aged Order Localization
        /// </summary>
        public const string CommonTaxesLocalization = "~/Areas/OE/Views/Common/TaxesGrid/_Localization.cshtml";
        /// <summary>
        ///Aged Order Localization
        /// </summary>
        public const string CommonTaxesGrid = "~/Areas/OE/Views/Common/TaxesGrid/_TaxesGrid.cshtml";
        /// <summary>
        ///Aged Order Localization
        /// </summary>
        public const string TotalTaxesGrid = "~/Areas/OE/Views/OrderEntry/Partials/_TaxesGrid.cshtml";

        /// <summary>
        /// Preauthorize Partial View for Order Entry
        /// </summary>
        public const string Preauthorize = "~/Areas/OE/Views/OrderEntry/Partials/_Preauthorize.cshtml";
        /// <summary>
        /// Preauthorize Partial View for Order Entry
        /// </summary>
        public const string PrepaymentBatchDetailsOrderEntry = "~/Areas/OE/Views/OrderEntry/Partials/_PrepaymentBatch.cshtml";

        /// <summary>
        /// Process Credit Card Partial View for Order Entry
        /// </summary>
        public const string ProcessCreditCard = "~/Areas/OE/Views/OrderEntry/Partials/_ProcessCreditCard.cshtml";

        /// <summary>
        /// SPS Partial View for Order Entry
        /// </summary>
        public const string OrderEntrySpsPartial = "~/Areas/OE/Views/OrderEntry/Partials/_SPSProcessCreditCard.cshtml";

        /// <summary>
        /// BOM Component view for Order Entry
        /// </summary>
        public const string BomComponentViewPartial = "~/Areas/OE/Views/OrderEntry/Partials/_BOMComponents.cshtml";


        /// <summary>
        /// Credit Debit Kitting Component Grid
        /// </summary>
        public const string OEKittingComponentGrid = "~/Areas/OE/Views/OrderEntry/Partials/_KittingComponentGrid.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string OEKittingLocationQuantity = "~/Areas/OE/Views/OrderEntry/Partials/_KittingLocationQuantity.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string PrintForm = "~/Areas/OE/Views/OrderEntry/Partials/_PrintForm.cshtml";

        /// <summary>
        /// Session Payment Info for Order Entry
        /// </summary>
        public const string SessiontOrderPaymentInfo = "oeOrderPaymentInfoCache";

        #endregion

        #region OrderActionReport
        /// <summary>
        /// OE Order Action report
        /// </summary>
        public const string OrderActionReport = "~/Areas/OE/Views/OrderActionReport/Partials/_OrderActionReport.cshtml";
        /// <summary>
        /// OE Order Action report Localization
        /// </summary>
        public const string OrderActionReportLocalization = "~/Areas/OE/Views/OrderActionReport/Partials/_Localization.cshtml";

        #endregion

        #region MiscellaneousCharge
        /// <summary>
        /// The MiscellaneousCharge
        /// </summary>
        public const string MiscellaneousCharge = "~/Areas/OE/Views/MiscellaneousCharge/Partials/_MiscellaneousCharge.cshtml";

        /// <summary>
        /// The MiscellaneousCharge localization
        /// </summary>
        public const string MiscellaneousChargeLocalization = "~/Areas/OE/Views/MiscellaneousCharge/Partials/_Localization.cshtml";

        /// <summary>
        /// The MiscellaneousCharge TaxDetails
        /// </summary>
        public const string MiscellaneousChargeTaxDetail = "~/Areas/OE/Views/MiscellaneousCharge/Partials/_MiscellaneousChargeTaxDetail.cshtml";

        /// <summary>
        /// The MiscellaneousCharge OptionalField
        /// </summary>
        public const string MiscellaneousChargeOptionalField = "~/Areas/OE/Views/MiscellaneousCharge/Partials/_MiscellaneousChargeOptionalField.cshtml";

        #endregion

        #region  OE Template

        public const string Template = "~/Areas/OE/Views/Template/Partials/_Template.cshtml";
        public const string TemplateLocalization = "~/Areas/OE/Views/Template/Partials/_Localization.cshtml";
        public const string TemplateOrder = "~/Areas/OE/Views/Template/Partials/_Order.cshtml";
        public const string TemplateCustomer = "~/Areas/OE/Views/Template/Partials/_Customer.cshtml";

        #endregion

        #region OE Posting Journals

        ///<summary>
        /// The Posting Journal Rpt Partial View
        /// </summary>
        public const string PostingJournalRpt = "~/Areas/OE/Views/PostingJournal/Partials/_PostingJournal.cshtml";
        public const string PostingJournalLocalization = "~/Areas/OE/Views/PostingJournal/Partials/_Localization.cshtml";

        #endregion

        #region Quotes

        ///<summary>
        /// Quotes Report Partial View
        /// </summary>
        public const string QuoteReport = "~/Areas/OE/Views/Quote/Partials/_Quote.cshtml";

        /// <summary>
        /// Quotes Report Localization
        /// </summary>
        public const string QuoteLocalization = "~/Areas/OE/Views/Quote/Partials/_Localization.cshtml";

        #endregion

        #region OE Ship Via Codes

        /// <summary>
        /// The OrderEntry
        /// </summary>
        public const string ShipViaCode = "~/Areas/OE/Views/ShipViaCode/Partials/_ShipViaCode.cshtml";
        /// <summary>
        /// Localization file for Order Entry
        /// </summary>
        public const string ShipViaCodesLocalization = "~/Areas/OE/Views/ShipViaCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The Contact tab
        /// </summary>
        public const string Contact = "~/Areas/OE/Views/ShipViaCode/Partials/_Contact.cshtml";

        /// <summary>
        /// The ShipVia tab
        /// </summary>
        public const string ShipVia = "~/Areas/OE/Views/ShipViaCode/Partials/_ShipVia.cshtml";

        #endregion

        #region Current Order Inquiry

        public const string CurrentOrderInquiryGrid = "~/Areas/OE/Views/CurrentOrderInquiry/Partials/_CurrentOrderInquiryGrid.cshtml ";

        public const string CurrentOrderInquiry = "~/Areas/OE/Views/CurrentOrderInquiry/Partials/_CurrentOrderInquiry.cshtml ";

        public const string LocalizationCurrentOrderInquiry = "~/Areas/OE/Views/CurrentOrderInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Shipping Label Report
        /// <summary>
        /// The Return Report Localization
        /// </summary>
        public const string ShippingLabelReportLocalization = "~/Areas/OE/Views/ShippingLabelReport/Partials/_Localization.cshtml";
        /// <summary>
        /// The Return Report
        /// </summary>
        public const string ShippingLabelReport = "~/Areas/OE/Views/ShippingLabelReport/Partials/_ShippingLabelReport.cshtml";


        #endregion

        #region Sales Person Inquiry
        /// <summary>
        ///  Sales Person Inquiry Partial View
        /// </summary>
        public const string SalesPersonInquiry = "~/Areas/OE/Views/SalesPersonInquiry/Partials/_SalesPersonInquiry.cshtml";

        /// <summary>
        ///  Sales Person Inquiry Grid Partial View
        /// </summary>
        public const string SalesPersonInquiryGrid = "~/Areas/OE/Views/SalesPersonInquiry/Partials/_SalesPersonInquiryGrid.cshtml";

        /// <summary>
        /// Sales Person Inquiry localization
        /// </summary>
        public const string SalesPersonInquiryLocalization = "~/Areas/OE/Views/SalesPersonInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Email Message

        /// <summary>
        /// Email Message partial view
        /// </summary>
        public const string EmailMessagePartial = "~/Areas/OE/Views/EmailMessage/Partials/_EmailMessage.cshtml";

        /// <summary>
        /// Email Message localization partial view
        /// </summary>
        public const string LocalizationEmailMessagePartial =
            "~/Areas/OE/Views/EmailMessage/Partials/_Localization.cshtml";

        #endregion

        #region Sale Statistics

        ///<summary>
        /// Sale Statistics
        /// </summary>
        public const string SalesStatistic = "~/Areas/OE/Views/SalesStatistic/Partials/_SalesStatistic.cshtml";

        /// <summary>
        /// Sale Statistics localization
        /// </summary>
        public const string SalesStatisticLocalization = "~/Areas/OE/Views/SalesStatistic/Partials/_Localization.cshtml";

        /// <summary>
        /// Sale Statistics SalesGrid
        /// </summary>
        public const string SalesGrid = "~/Areas/OE/Views/SalesStatistic/Partials/_SalesGrid.cshtml";

        /// <summary>
        /// Sale Statistics InvoicesCreditDebitNotesGrid
        /// </summary>
        public const string InvoicesCreditDebitNotesGrid =
            "~/Areas/OE/Views/SalesStatistic/Partials/_InvoicesCreditDebitNotesGrid.cshtml";

        #endregion

        #region OE Option

        public const string OEOption = "~/Areas/OE/Views/OEOptions/Partials/_Option.cshtml";
        public const string OEOptionCompany = "~/Areas/OE/Views/OEOptions/Partials/_Company.cshtml";
        public const string OEOptionProcessing = "~/Areas/OE/Views/OEOptions/Partials/_Processing.cshtml";
        public const string OEOptionDocument = "~/Areas/OE/Views/OEOptions/Partials/_Document.cshtml";
        public const string OEOptionLocalization = "~/Areas/OE/Views/OEOptions/Partials/_Localization.cshtml";

        #endregion

        #region Sales History Report
        /// <summary>
        ///Sales History Report Localization
        /// </summary>
        public const string SalesHistoryReportLocalization = "~/Areas/OE/Views/SalesHistoryReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Sales History Report
        /// </summary>
        public const string SalesHistoryReport = "~/Areas/OE/Views/SalesHistoryReport/Partials/_SalesHistoryReport.cshtml";

        #endregion

        #region CreditDebit Notes Report
        /// <summary>
        /// The Return Report Localization
        /// </summary>
        public const string CreditDebitNoteReportLocalization = "~/Areas/OE/Views/CreditDebitNote/Partials/_Localization.cshtml";
        /// <summary>
        /// The Return Report
        /// </summary>
        public const string CreditDebitNoteReport = "~/Areas/OE/Views/CreditDebitNote/Partials/_CreditDebitNote.cshtml";

        #endregion

        #region Copy Order
        /// <summary>
        /// Copy  Order Partial View
        /// </summary>
        public const string CopyOrder = "~/Areas/OE/Views/CopyOrder/Partials/_CopyOrder.cshtml";

        /// <summary>
        /// Optional fields grid
        /// </summary>
        public const string CopyOrderDetailGrid = "~/Areas/OE/Views/CopyOrder/Partials/_CopyOrderDetailGrid.cshtml";

        /// <summary>
        /// The Copy order  localization
        /// </summary>
        public const string CopyOrderLocalization = "~/Areas/OE/Views/CopyOrder/Partials/_Localization.cshtml";

        /// <summary>
        /// Orders Tab view
        /// </summary>
        public const string CopyOrdersData = "~/Areas/OE/Views/CopyOrder/Partials/_CopyOrdersData.cshtml";

        /// <summary>
        /// Orders Tab view
        /// </summary>
        public const string CopyOrdersOptionalFields = "~/Areas/OE/Views/CopyOrder/Partials/_OptionalFields.cshtml";
        /// <summary>
        /// Detail Optional field
        /// </summary>
        public const string CopyOrderDetailOptionalFields = "~/Areas/OE/Views/CopyOrder/Partials/_DetailOptionalField.cshtml";


        /// <summary>
        /// Kit Component
        /// </summary>
        public const string CopyOrderKittingComponentGrid = "~/Areas/OE/Views/CopyOrder/Partials/_KittingComponentGrid.cshtml";
        #endregion

        #region Pending Shipment Inquiry

        /// <summary>
        /// Pending Shipment Inquiry localization
        /// </summary>
        public const string PendingShipmentInquiryLocalization = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_Localization.cshtml";

        /// <summary>
        ///  Pending Shipment Inquiry Partial View
        /// </summary>
        public const string PendingShipmentInquiry = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PendingShipment.cshtml";

        /// <summary>
        /// Pending Shipment Inquiry Grid
        /// </summary>
        public const string PendingShipmentInquiryGrid = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PendingShipmentGrid.cshtml";

        #endregion

        #region Pending Shipment Detail

        /// <summary>
        ///  Pending Shipment Inquiry PopUp
        /// </summary>
        public const string PendingShipmentDetailpopup = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PendingShipmentDetail.cshtml";

        /// <summary>
        /// Pending Shipment Inquiry Detail Grid
        /// </summary>
        public const string PendingShipmentPopupGrid = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PendingShipmentDetailGrid.cshtml";

        #endregion

        #region Pending Shipment PO-Detail

        /// <summary>
        ///  Pending Shipment PO-Detail Partial View
        /// </summary>
        public const string PendingShipmentPODetailpopup = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PurchaseOrderDetail.cshtml";
        /// <summary>
        /// Pending Shipment PO-Detail Grid
        /// </summary>
        public const string PurchaseOrderDetailPopupGrid = "~/Areas/OE/Views/PendingShipmentInquiry/Partials/_PurchaseOrderDetailGrid.cshtml";

        #endregion

        #region Email Message Report

        /// <summary>
        /// Email Message Report Localization
        /// </summary>
        public const string EmailMessageReportLocalization = "~/Areas/OE/Views/EmailMessageReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Email Message Report
        /// </summary>
        public const string EmailMessageReport = "~/Areas/OE/Views/EmailMessageReport/Partials/_EmailMessageReport.cshtml";
        #endregion

        #region OE Shipment Entry

        public const string ShipmentEntry = "~/Areas/OE/Views/ShipmentEntry/Partials/_ShipmentEntry.cshtml";
        public const string ShipmentEntryCustomer = "~/Areas/OE/Views/ShipmentEntry/Partials/_Customer.cshtml";
        public const string ShipmentEntryLocalization = "~/Areas/OE/Views/ShipmentEntry/Partials/_Localization.cshtml";
        public const string ShipmentEntryOptionalFields = "~/Areas/OE/Views/ShipmentEntry/Partials/_OptionalFields.cshtml";
        public const string ShipmentEntryRates = "~/Areas/OE/Views/ShipmentEntry/Partials/_Rates.cshtml";
        public const string ShipmentEntrySalesSplit = "~/Areas/OE/Views/ShipmentEntry/Partials/_SalesSplit.cshtml";
        public const string ShipmentEntryShipment = "~/Areas/OE/Views/ShipmentEntry/Partials/_Shipment.cshtml";
        public const string ShipmentEntryShipmentGrid = "~/Areas/OE/Views/ShipmentEntry/Partials/_ShipmentGrid.cshtml";
        public const string ShipmentEntryTaxes = "~/Areas/OE/Views/ShipmentEntry/Partials/_Taxes.cshtml";
        public const string ShipmentEntryTaxesGrid = "~/Areas/OE/Views/ShipmentEntry/Partials/_TaxesGrid.cshtml";
        public const string ShipmentEntryTotals = "~/Areas/OE/Views/ShipmentEntry/Partials/_Totals.cshtml";
        public const string ShipmentCommentsInstructionGrid = "~/Areas/OE/Views/ShipmentEntry/Partials/_CommentsInstructionGrid.cshtml";
        
        /// <summary>
        /// Location Quantity Shipment  Entry
        /// </summary>
        public const string ShipmentEntryLocationQuantity = "~/Areas/OE/Views/ShipmentEntry/Partials/_ShipmentEntryLocationQuantity.cshtml";


        #endregion

        #region OE Invoice Entry

        /// <summary>
        /// Invoice entry screen
        /// </summary>
        public const string InvoiceEntryScreen = "~/Areas/OE/Views/InvoiceEntry/Partials/_InvoiceEntry.cshtml";

        /// <summary>
        /// Localization file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryLocalization = "~/Areas/OE/Views/InvoiceEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Invoice partial view 
        /// </summary>
        public const string InvoiceEntryInvoice = "~/Areas/OE/Views/InvoiceEntry/Partials/_Invoice.cshtml";

        /// <summary>
        /// Rates partial view 
        /// </summary>
        public const string InvoiceEntryRates = "~/Areas/OE/Views/InvoiceEntry/Partials/_Rates.cshtml";
        /// <summary>
        /// Invoice Deatil partial view 
        /// </summary>
        public const string InvoiceEntryDetailGrid = "~/Areas/OE/Views/InvoiceEntry/Partials/_InvoiceDetailGrid.cshtml";

        /// <summary>
        /// Customer file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryCustomer = "~/Areas/OE/Views/InvoiceEntry/Partials/_Customer.cshtml";

        /// <summary>
        /// Taxes file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryTaxes = "~/Areas/OE/Views/InvoiceEntry/Partials/_Taxes.cshtml";
        /// <summary>
        /// Taxes file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryTaxesGrid = "~/Areas/OE/Views/InvoiceEntry/Partials/_TaxesGrid.cshtml";

        /// <summary>
        /// Total file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryTotal = "~/Areas/OE/Views/InvoiceEntry/Partials/_Total.cshtml";

       
        /// <summary>
        /// Sales file for Invoice Entry
        /// </summary>
        public const string InvoiceEntrySales = "~/Areas/OE/Views/InvoiceEntry/Partials/_Sales.cshtml";

        /// <summary>
        /// Optional fields file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryOptionalField = "~/Areas/OE/Views/InvoiceEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// CustomerBillToAddress file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryCustomerBillToAddress = "~/Areas/OE/Views/InvoiceEntry/Partials/_CustomerBillToAddress.cshtml";

        /// <summary>
        /// CustomerBillToAddress file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryShipToAddress = "~/Areas/OE/Views/InvoiceEntry/Partials/_ShipToAddress.cshtml";

        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryLocationQuantity = "~/Areas/OE/Views/InvoiceEntry/Partials/_LocationQuantity.cshtml";

        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryQuantityonSo = "~/Areas/OE/Views/InvoiceEntry/Partials/_QuantityOnSOGrid.cshtml";

        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryQuantityonPo = "~/Areas/OE/Views/InvoiceEntry/Partials/_QuantityOnPOGrid.cshtml";
        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryQuantityCommitted = "~/Areas/OE/Views/InvoiceEntry/Partials/_QuantityCommittedGrid.cshtml";
        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryAllLocQuantitySo = "~/Areas/OE/Views/InvoiceEntry/Partials/_AllLocQuantityOnSOGrid.cshtml";
        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryAllLocQuantityPo = "~/Areas/OE/Views/InvoiceEntry/Partials/_AllLocQuantityOnPOGrid.cshtml";
        /// <summary>
        /// LocationQuantity file for Invoice Entry
        /// </summary>
        public const string InvoiceEntryAllLocQuantityCommitted = "~/Areas/OE/Views/InvoiceEntry/Partials/_AllLocQuantityCommittedGrid.cshtml";

        /// <summary>
        /// Invoice Entry Kitting Component Grid
        /// </summary>
        public const string InvoiceEntryKittingComponentGrid = "~/Areas/OE/Views/InvoiceEntry/Partials/_KittingComponentGrid.cshtml";

        /// <summary>
        /// Invoice Entry Kitting Location quantity
        /// </summary>
        public const string InvoiceEntryKittingLocationQuantity = "~/Areas/OE/Views/InvoiceEntry/Partials/_KittingLocationQuantity.cshtml";

         /// <summary>
        /// Invoice EntryMultiple shipment to invoice partial page
        /// </summary>
        public const string InvoiceEntryMultipleShipments = "~/Areas/OE/Views/InvoiceEntry/Partials/_MultipleShipments.cshtml";
        
        #endregion
    }
}
