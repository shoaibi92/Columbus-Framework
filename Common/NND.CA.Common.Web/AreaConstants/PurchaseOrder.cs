/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Costant for IC layout path
    /// </summary>
    public static class PurchaseOrder
    {
        #region Purchase Order

        /// <summary>
        /// The CreateBatch
        /// </summary>
        public const string POCreateBatch = "~/Areas/PO/Views/CreateBatch/Partials/_CreateBatch.cshtml";

        #region Options

        /// <summary>
        /// P/O Options
        /// </summary>
        public const string Options = "~/Areas/PO/Views/Options/Partials/_Options.cshtml";

        /// <summary>
        /// P/O Options-Localization
        /// </summary>
        public const string OptionsLocalization = "~/Areas/PO/Views/Options/Partials/_Localization.cshtml";

        /// <summary>
        /// P/O Options-Company
        /// </summary>
        public const string OptionsCompany = "~/Areas/PO/Views/Options/Partials/_Company.cshtml";

        /// <summary>
        /// P/O Options-Processing
        /// </summary>
        public const string OptionsProcessing = "~/Areas/PO/Views/Options/Partials/_Processing.cshtml";

        /// <summary>
        /// P/O Options-Documents
        /// </summary>
        public const string OptionsDocument = "~/Areas/PO/Views/Options/Partials/_Documents.cshtml";


        #endregion

        #endregion

        #region GL Integration

        ///<summary>
        /// The GL Integration Partial View
        /// </summary>
        public const string GLIntegration = "~/Areas/PO/Views/GLIntegration/Partials/_GLIntegration.cshtml";

        /// <summary>
        /// The GL Integration localization
        /// </summary>
        public const string GLIntegrationLocalization = "~/Areas/PO/Views/GLIntegration/Partials/_Localization.cshtml";

        /// <summary>
        /// The GL Integration Options
        /// </summary>
        public const string GLIntegrationOptions = "~/Areas/PO/Views/GLIntegration/Partials/_Options.cshtml";

        /// <summary>
        /// The GL Integration Transactions
        /// </summary>
        public const string GLIntegrationTransactions = "~/Areas/PO/Views/GLIntegration/Partials/_Transactions.cshtml";

        ///<summary>
        /// The GLTransaction Partial View
        /// </summary>
        public const string GLTransactionRpt = "~/Areas/PO/Views/GLTransaction/Partials/_GLTransaction.cshtml";

        #endregion

        #region Ship-Via Code

        /// <summary>
        /// The ShipViaCode Localization
        /// </summary>
        public const string ShipViaCodeLocalization =
            "~/Areas/PO/Views/ShipViaCode/Partials/_ShipViaCodeLocalization.cshtml";

        /// <summary>
        /// The ShipViaCode
        /// </summary>
        public const string ShipViaCode = "~/Areas/PO/Views/ShipViaCode/Partials/_ShipViaCode.cshtml";

        /// <summary>
        /// The Contact tab
        /// </summary>
        public const string Contact = "~/Areas/PO/Views/ShipViaCode/Partials/_Contact.cshtml";

        /// <summary>
        /// The ShipVia tab
        /// </summary>
        public const string ShipVia = "~/Areas/PO/Views/ShipViaCode/Partials/_ShipVia.cshtml";

        #endregion

        #region Setup -> Template

        /// <summary>
        /// The PO Template 
        /// </summary>
        public const string POTemplate = "~/Areas/PO/Views/Template/Partials/_Template.cshtml";

        /// <summary>
        /// The PO Template Localization
        /// </summary>
        public const string POTemplateLocalization = "~/Areas/PO/Views/Template/Partials/_Localization.cshtml";

        /// <summary>
        /// The PO Order
        /// </summary>
        public const string POTemplateOrder = "~/Areas/PO/Views/Template/Partials/_Order.cshtml";

        /// <summary>
        /// The PO Vendor tab
        /// </summary>
        public const string POTemplateVendor = "~/Areas/PO/Views/Template/Partials/_Vendor.cshtml";

        #endregion

        /// <summary>
        /// The Clear History
        /// </summary>
        public const string POClearHistory = "~/Areas/PO/Views/ClearHistory/Partials/_ClearHistory.cshtml";

        public const string POClearHistoryLocalization = "~/Areas/PO/Views/ClearHistory/Partials/_Localization.cshtml";

        #region Shippable BackOrders Report

        /// <summary>
        /// Shippable Back Orders Report
        /// </summary>
        public const string POShippablebackOrdersReport =
            "~/Areas/PO/Views/ShippableBackOrderReport/Partials/_ShippableBackOrderReport.cshtml";

        public const string POShippableBackOrdersReportLocalization =
            "~/Areas/PO/Views/ShippableBackOrderReport/Partials/_Localization.cshtml";

        #endregion

        ///<summary>
        /// The Posting Journal Rpt Partial View
        /// </summary>
        public const string PostingJournalRpt = "~/Areas/PO/Views/PostingJournal/Partials/_PostingJournal.cshtml";

        public const string PostingJournalLocalization = "~/Areas/PO/Views/PostingJournal/Partials/_Localization.cshtml";

        #region Create POs From IC

        /// <summary>
        /// CreatePOsFromIC Partial View
        /// </summary>
        public const string CreatePOsFromIC = "~/Areas/PO/Views/CreatePOsFromIC/Partials/_CreatePOsFromIC.cshtml";

        /// <summary>
        /// CreatePOsFromIC Localization 
        /// </summary>
        public const string CreatePOsFromICLocalization =
            "~/Areas/PO/Views/CreatePOsFromIC/Partials/_Localization.cshtml";

        /// <summary>
        /// CreatePOsFromIC Options Partial View
        /// </summary>
        public const string CreatePOsFromICOptions = "~/Areas/PO/Views/CreatePOsFromIC/Partials/_Options.cshtml";

        /// <summary>
        /// CreatePOsFromIC Optional Field Partial View
        /// </summary>
        public const string CreatePOsFromICOptionalField =
            "~/Areas/PO/Views/CreatePOsFromIC/Partials/_OptionalField.cshtml";

        /// <summary>
        /// CreatePOsFromIC Detail Optional Field Partial View
        /// </summary>
        public const string CreatePOsFromICDetailOptField =
            "~/Areas/PO/Views/CreatePOsFromIC/Partials/_DetailOptionalField.cshtml";

        /// <summary>
        /// Session Key for Optional Field 
        /// </summary>
        public const string CreatePOsFromICSessionOptField = "CreatePOsICOptFieldCache";

        /// <summary>
        /// Session Key for Detail Optional Field 
        /// </summary>
        public const string CreatePOsFromICSessionDetailOptField = "CreatePOsICDetailOptFieldCache";

        #endregion

        #region Purchase Statistics

        public const string PurchaseStatistics =
            "~/Areas/PO/Views/PurchaseStatistic/Partials/_PurchaseStatistic.cshtml";

        public const string PurchasesGrid = "~/Areas/PO/Views/PurchaseStatistic/Partials/_PurchasesGrid.cshtml";

        public const string PurchasesLocalization = "~/Areas/PO/Views/PurchaseStatistic/Partials/_Localization.cshtml";

        public const string PurchasesInvoicesCreditDebitNotesGrid =
            "~/Areas/PO/Views/PurchaseStatistic/Partials/_InvoicesCreditDebitNotesGrid.cshtml";

        #endregion

        #region Vendor Contract Cost

        ///<summary>
        /// The Vendor Contract Cost Partial View
        /// </summary>
        public const string VendorContractCost =
            "~/Areas/PO/Views/VendorContractCost/Partials/_VendorContractCost.cshtml";

        /// <summary>
        /// The Vendor Contract Cost localization
        /// </summary>
        public const string VendorContractCostLocalization =
            "~/Areas/PO/Views/VendorContractCost/Partials/_Localization.cshtml";

        /// <summary>
        /// The Vendor Contract Cost Base Units Partial View
        /// </summary>
        public const string VendorContractCostBaseUnits =
            "~/Areas/PO/Views/VendorContractCost/Partials/_BaseUnits.cshtml";

        /// <summary>
        /// The Vendor Contract Cost Sales Units Partial View
        /// </summary>
        public const string VendorContractCostSalesUnits =
            "~/Areas/PO/Views/VendorContractCost/Partials/_SalesUnits.cshtml";

        ///<summary>
        /// The Vendor Contract Cost Included Taxes Partial View
        /// </summary>
        public const string VendorContractCostIncludedTaxes =
            "~/Areas/PO/Views/VendorContractCost/Partials/_IncludedTaxes.cshtml";

        /// <summary>
        /// The Vendor Contract Cost Detail Partial View
        /// </summary>
        public const string VendorContractCostDetail =
            "~/Areas/PO/Views/VendorContractCost/Partials/_VendorContractCostDetail.cshtml";

        /// <summary>
        /// The Vendor Contract Cost Grid Partial View
        /// </summary>
        public const string VendorContractCostGrid =
            "~/Areas/PO/Views/VendorContractCost/Partials/_VendorContractCostGrid.cshtml";

        ///<summary>
        /// The Vendor Contract Cost Included Taxes grid Partial View
        /// </summary>
        public const string VendorContractCostIncludedTaxesGrid =
            "~/Areas/PO/Views/VendorContractCost/Partials/_VendorContractCostTaxesGrid.cshtml";

        ///<summary>
        /// The Vendor discounts grid Partial View
        /// </summary>
        public const string DiscountsGrid =
            "~/Areas/PO/Views/VendorContractCost/Partials/_DiscountGrid.cshtml";

        ///<summary>
        /// The Base Price Unit grid Partial View
        /// </summary>
        public const string BasePriceUnitsOfMeasureGrid =
            "~/Areas/PO/Views/VendorContractCost/Partials/_BasePriceUnitsOfMeasureGrid.cshtml";
        
        ///<summary>
        /// The Base Price Unit Partial View
        /// </summary>
        public const string BasePriceUnitsOfMeasure =
           "~/Areas/PO/Views/VendorContractCost/Partials/_BasePriceUnitsOfMeasure.cshtml";

         ///<summary>
        /// The Sale Price Unit Partial View
        /// </summary>
        public const string SalePriceUnitsOfMeasure =
           "~/Areas/PO/Views/VendorContractCost/Partials/_SalePriceUnitsOfMeasure.cshtml";

        ///<summary>
        /// The Sale Price Unit grid Partial View
        /// </summary>
        public const string SalePriceUnitsOfMeasureGrid =
           "~/Areas/PO/Views/VendorContractCost/Partials/_SalePriceUnitsOfMeasureGrid.cshtml";

        ///<summary>
        /// The Vendor discounts grid Partial View
        /// </summary>
        public const string CostTabPopupScreens =
           "~/Areas/PO/Views/VendorContractCost/Partials/_CostTabPopupScreens.cshtml";
        #endregion

        #region Purchase Order Entry

        /// <summary>
        /// The purchase order entry
        /// </summary>
        public const string PurchaseOrderEntry =
            "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_PurchaseOrderEntry.cshtml";

        /// <summary>
        /// The purchase order entry localization
        /// </summary>
        public const string PurchaseOrderEntryLocalization =
            "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// The order
        /// </summary>
        public const string Order = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_Order.cshtml";

        /// <summary>
        /// The taxes
        /// </summary>
        public const string Taxes = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_Tax.cshtml";

        /// <summary>
        /// The po optional field
        /// </summary>
        public const string POOptionalField = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The po detail optional field
        /// </summary>
        public const string PODetailOptionalField = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_DetailOptionalField.cshtml";

        /// <summary>
        /// The rates
        /// </summary>
        public const string Rates = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_Rate.cshtml";

        /// <summary>
        /// The totals
        /// </summary>
        public const string Totals = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_Total.cshtml";

        /// <summary>
        /// The purchase order line grid
        /// </summary>
        public const string PurchaseOrderLineGrid = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_PurchaseOrderLineDetailGrid.cshtml";

        /// <summary>
        /// Comments/Instruction
        /// </summary>
        public const string POCommentInstruction = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_CommentInstruction.cshtml";

        /// <summary>
        /// The create po requisition
        /// </summary>
        public const string CreatePORequisition = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_CreatePOFromRequisition.cshtml";

        /// <summary>
        /// Ship To Location Info
        /// </summary>
        public const string POShipToLocationInfo = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_ShipToLocationInfo.cshtml";

        /// <summary>
        /// PO Entry- Detail Item Taxes
        /// </summary>
        public const string PODetailItemTaxes = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_DetailTaxes.cshtml";

        /// <summary>
        /// PO Entry- Header Item Taxes
        /// </summary>
        public const string POHeaderItemTaxes = "~/Areas/PO/Views/PurchaseOrderEntry/Partials/_VendorTaxes.cshtml";

        #endregion

        #region Purchase Order  Credit Debit NOte Entry
        public const string creditdebitTaxes = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Taxes.cshtml";
        #endregion

        #region Session
        /// <summary>
        /// ApSession Key for Optional Field 
        /// </summary>
        public const string PoSessionOptionalField = "poOptionalFieldCache";
        /// <summary>
        /// ApSession Key for Tax Detail
        /// </summary>
        public const string PoSessionTaxDetail = "poTaxDetailCache";

        public const string PoSessionVendorContractcost = "poSessionVendorContractcost";
        #endregion

        #region Additional Cost
        public const string AddCostPartial = "~/Areas/PO/Views/AdditionalCost/Partials/_AdditionalCost.cshtml";

        public const string AddCostLocalization = "~/Areas/PO/Views/AdditionalCost/Partials/_Localization.cshtml";
        public const string AddCostOptFields = "~/Areas/PO/Views/AdditionalCost/Partials/_OptionalFields.cshtml";

        public const string AddCostTaxGrid = "~/Areas/PO/Views/AdditionalCost/Partials/_TaxDetailGrid.cshtml";
        #endregion

        #region Purchase History Report

        /// <summary>
        /// Partial View For Purchase History Report
        /// </summary>
        public const string PurchaseHistoryRpt = "~/Areas/PO/Views/PurchaseHistoryReport/Partials/_PurchaseHistory.cshtml";
        public const string PurchaseHistoryLocalization = "~/Areas/PO/Views/PurchaseHistoryReport/Partials/_Localization.cshtml";

        #endregion

        #region Create POs From Requisition

        /// <summary>
        /// Create POs From Requisition Partial View
        /// </summary>
        public const string CreatePOsFromRequisition = "~/Areas/PO/Views/CreatePOsFromRequisition/Partials/_CreatePOsFromRequisition.cshtml";

        /// <summary>
        /// Create POs From Requisition Options Tab
        /// </summary>
        public const string CreatePOsFromRequisitionOptions = "~/Areas/PO/Views/CreatePOsFromRequisition/Partials/_Options.cshtml";

        /// <summary>
        /// Create POs From Requisition Optional Field Tab
        /// </summary>
        public const string CreatePOsFromRequisitionOptionalField = "~/Areas/PO/Views/CreatePOsFromRequisition/Partials/_OptionalField.cshtml";

        /// <summary>
        /// Create POs From Requisition Detail Optional Field Tab
        /// </summary>
        public const string CreatePOsFromRequisitionDetailOptionalField = "~/Areas/PO/Views/CreatePOsFromRequisition/Partials/_DetailOptionalField.cshtml";

        /// <summary>
        /// Create POs From Requisition Localization Partial View
        /// </summary>
        public const string CreatePOsFromRequisitionLocalization = "~/Areas/PO/Views/CreatePOsFromRequisition/Partials/_Localization.cshtml";

        /// <summary>
        /// Session Key for Optional Field 
        /// </summary>
        public const string CreatePOsFromRequisitionSessionOptField = "CreatePOsRequisitionOptFieldCache";

        /// <summary>
        /// Session Key for Detail Optional Field 
        /// </summary>
        public const string CreatePOsFromRequisitionSessionDetailOptField = "CreatePOsRequisitionDetailOptFieldCache";

        #endregion

        #region CreatePOsFromOE


        /// <summary>
        /// CreatePOsFromOE Partial View
        /// </summary>
        public const string CreatePOsFromOEIndex = "~/Areas/PO/Views/CreatePOsFromOE/Index.cshtml";

        /// <summary>
        /// CreatePOsFromOE Partial View
        /// </summary>
        public const string CreatePOsFromOE = "~/Areas/PO/Views/CreatePOsFromOE/Partials/_CreatePOsFromOE.cshtml";

        /// <summary>
        /// CreatePOsFromOE Localization View
        /// </summary>
        public const string CreatePOsFromOELocalization = "~/Areas/PO/Views/CreatePOsFromOE/Partials/_Localization.cshtml";

        /// <summary>
        /// CreatePOsFromOE OptionalField View
        /// </summary>
        public const string CreatePOsFromOEOptionalFields = "~/Areas/PO/Views/CreatePOsFromOE/Partials/_OptionalFields.cshtml";
        /// <summary>
        /// CreatePOsFromOE Detail Optional Field View
        /// </summary>
        public const string CreatePOsFromOEDetailOptionalFields = "~/Areas/PO/Views/CreatePOsFromOE/Partials/_DetailOptionalFields.cshtml";

        /// <summary>
        /// CreatePOsFromOE Detail Optional Field View
        /// </summary>
        public const string CreatePOsFromDetailOptions = "~/Areas/PO/Views/CreatePOsFromOE/Partials/_Options.cshtml";

        #endregion

        #region Optionalfields

        /// <summary>
        /// Session Key for Item Segments
        /// </summary>
        public const string SessionOptionalField = "poOptionalFieldCache";

        /// <summary>
        /// Session Key for Item Segments
        /// </summary>
        public const string SessionOptionalDetailField = "poOptionalFieldDetailCache";

        /// <summary>
        /// The OptionalField
        /// </summary>
        public const string OptionalField = "~/Areas/PO/Views/OptionalField/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The OptionalField localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/PO/Views/OptionalField/Partials/_Localization.cshtml";

        /// <summary>
        /// The OptionalField grid
        /// </summary>
        public const string OptionalFieldGrid = "~/Areas/PO/Views/OptionalField/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The OptionalField Settings
        /// </summary>
        public const string OptionalFieldSettings =
            "~/Areas/PO/Views/OptionalField/Partials/_OptionalFieldSettings.cshtml";

        /// <summary>
        /// Session Key for Interest Batch Optional Field 
        /// </summary>
        public const string SessionInterestBatchOptionalField = "poInterestBatchOptionalFieldCache";

        /// <summary>
        /// Session Key for Interest Batch Detail Optional Field 
        /// </summary>
        public const string SessionInterestBatchDetailOptionalField = "poInterestBatchDetailOptionalFieldCache";

        #endregion

        ///<summary>
        /// The PurchaseOrder Rpt Partial View
        /// </summary>
        public const string PurchaseOrderReport = "~/Areas/PO/Views/PurchaseOrderReport/Partials/_PurchaseOrderReport.cshtml";
        public const string PurchaseOrderReportLocalization = "~/Areas/PO/Views/PurchaseOrderReport/Partials/_Localization.cshtml";

        #region Requisition Entry

        public const string RequisitionEntry = "~/Areas/PO/Views/RequisitionEntry/Partials/_RequisitionEntry.cshtml";

        public const string HeaderOptionalFieldTab = "~/Areas/PO/Views/RequisitionEntry/Partials/_HeaderOptionalFieldTab.cshtml";

        public const string RequisitionEntryLocalization = "~/Areas/PO/Views/RequisitionEntry/Partials/_Localization.cshtml";

        public const string RequisitionLineGrid = "~/Areas/PO/Views/RequisitionEntry/Partials/_RequisitionLineGrid.cshtml";

        public const string RequisitionTab = "~/Areas/PO/Views/RequisitionEntry/Partials/_RequistionTab.cshtml";

        public const string TotalTab = "~/Areas/PO/Views/RequisitionEntry/Partials/_TotalTab.cshtml";

        public const string RequistionDetailOptionalField = "~/Areas/PO/Views/RequisitionEntry/Partials/_DetailOptionalFields.cshtml";
        public const string RequistionCommentInstruction = "~/Areas/PO/Views/RequisitionEntry/Partials/_CommentAndInstruction.cshtml";
        #endregion

        #region Returns Report
        /// <summary>
        /// The Return Report Localization
        /// </summary>
        public const string ReturnReportLocalization = "~/Areas/PO/Views/ReturnReport/Partials/_ReturnReportLocalization.cshtml";
        /// <summary>
        /// The Return Report
        /// </summary>
        public const string ReturnReport = "~/Areas/PO/Views/ReturnReport/Partials/_ReturnReport.cshtml";

        #endregion

        #region ReceiptEntry

        #region Localization

        public const string ReceiptEntryLocalization = "~/Areas/PO/Views/ReceiptEntry/Partials/_Localization.cshtml";

        #endregion

        #region Tabs

        public const string ReceiptEntry = "~/Areas/PO/Views/ReceiptEntry/Partials/_ReceiptEntry.cshtml";

        public const string Receipt = "~/Areas/PO/Views/ReceiptEntry/Partials/_Receipt.cshtml";

        public const string ReceiptTax = "~/Areas/PO/Views/ReceiptEntry/Partials/_Taxes.cshtml";

        public const string ReceiptTaxGrid = "~/Areas/PO/Views/ReceiptEntry/Partials/_TaxGrid.cshtml";

        public const string ReceiptOptionalField = "~/Areas/PO/Views/ReceiptEntry/Partials/_OptionalFields.cshtml";

        public const string ReceiptAdditionalCost = "~/Areas/PO/Views/ReceiptEntry/Partials/_AdditionalCosts.cshtml";

        public const string ReceiptAdditionalCostGrid = "~/Areas/PO/Views/ReceiptEntry/Partials/_AdditionalCostGrid.cshtml";

        public const string ReceiptTotal = "~/Areas/PO/Views/ReceiptEntry/Partials/_Totals.cshtml";

        public const string ReceiptRates = "~/Areas/PO/Views/ReceiptEntry/Partials/_Rates.cshtml";

        public const string ReceiptEntryGrid = "~/Areas/PO/Views/ReceiptEntry/Partials/_ReceiptGrid.cshtml";

        public const string TaxGridLocalization = "~/Areas/PO/Views/Taxes/_Localization.cshtml";
        public const string TaxGrid = "~/Areas/PO/Views/Taxes/_TaxGrid.cshtml";

        #endregion

        #region ReceiptEntry PopUp

        public const string ReceiptBillToLocationInfo = "~/Areas/PO/Views/ReceiptEntry/Partials/_BillToLocationInfo.cshtml";

        public const string ReceiptShipToLocationInfo = "~/Areas/PO/Views/ReceiptEntry/Partials/_ShipToLocationInfo.cshtml";

        public const string VendorInfo = "~/Areas/PO/Views/ReceiptEntry/Partials/_VendorInfo.cshtml";

        public const string ReceiptVendorInfo = "~/Areas/PO/Views/ReceiptEntry/Partials/_ReceiptVendorInfo.cshtml";

        public const string ReceiptInvoice = "~/Areas/PO/Views/ReceiptEntry/Partials/_Invoice.cshtml";

        public const string ReceiptDetailCostsTaxes = "~/Areas/PO/Views/ReceiptEntry/Partials/_DetailCostsTaxes.cshtml";

        public const string ReceiptComment = "~/Areas/PO/Views/ReceiptEntry/Partials/_Comment.cshtml";

        public const string ReceiptAddCostTaxes = "~/Areas/PO/Views/ReceiptEntry/Partials/_AddCostsTaxes.cshtml";
        public const string ReceiptAddCostTaxesGrid = "~/Areas/PO/Views/ReceiptEntry/Partials/_AdditonalCostTaxesGrid.cshtml";

        public const string ReceiptAddCostVendorTaxesGrid = "~/Areas/PO/Views/ReceiptEntry/Partials/AdditionalCostVendorTaxesGrid.cshtml";

        public const string ReceiptAddCostVendorTaxes = "~/Areas/PO/Views/ReceiptEntry/Partials/_AddCostVendorTaxes.cshtml";

        /// <summary>
        /// The po detail optional field
        /// </summary>
        public const string ReceiptPODetailOptionalField = "~/Areas/PO/Views/ReceiptEntry/Partials/_DetailOptionalField.cshtml";

        

        public const string ReceiptAdditionalCostVendorTaxes = "~/Areas/PO/Views/ReceiptEntry/Partials/AdditionalCostVendorTaxesGrid.cshtml";
        public const string ReceiptMultiplePO = "~/Areas/PO/Views/ReceiptEntry/Partials/_MultiplePO.cshtml";

        /// <summary>
        /// The po detail optional field Additional Cost
        /// </summary>
        public const string ReceiptAddCostOptFields = "~/Areas/PO/Views/ReceiptEntry/Partials/_AddCostOptField.cshtml";
        public const string ReceiptAddCostVendorOptFields = "~/Areas/PO/Views/ReceiptEntry/Partials/_AddCostVendorOptField.cshtml";


        #endregion

        #endregion

        #region Transaction List Report
        /// <summary>
        /// Transaction List Report
        /// </summary>
        public const string TransactionList = "~/Areas/PO/Views/TransactionList/Partials/_TransactionList.cshtml";
        public const string TransactionListLocalization = "~/Areas/PO/Views/TransactionList/Partials/_Localization.cshtml";
        #endregion

        #region Invoice Entry

        public const string InvoiceEntry = "~/Areas/PO/Views/InvoiceEntry/Partials/_InvoiceEntry.cshtml";
        public const string InvoiceEntryLocalization = "~/Areas/PO/Views/InvoiceEntry/Partials/_Localization.cshtml";
        public const string InvoiceEntryInvoiceTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_Invoice.cshtml";
        public const string InvoiceEntryTaxesTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_Taxes.cshtml";
        public const string InvoiceEntryTermsTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_Terms.cshtml";
        public const string InvoiceEntryAdditionalCostTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_AdditionalCost.cshtml";
        public const string InvoiceEntryTotalsTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_Totals.cshtml";
        public const string InvoiceEntryOptionalFieldsTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_OptionalFields.cshtml";
        public const string InvoiceEntryRatesTab = "~/Areas/PO/Views/InvoiceEntry/Partials/_Rates.cshtml";
        public const string InvoiceEntryLine = "~/Areas/PO/Views/InvoiceEntry/Partials/_LinesGrid.cshtml";
        public const string InvoiceEntryTaxesGrid = "~/Areas/PO/Views/InvoiceEntry/Partials/_TaxesGrid.cshtml";
        public const string InvoiceEntryPaymentSchedule = "~/Areas/PO/Views/InvoiceEntry/Partials/_TermsGrid.cshtml";
        public const string DetailOptionalField = "~/Areas/PO/Views/InvoiceEntry/Partials/_LineOptionalField.cshtml";
        public const string MultipleReceipts = "~/Areas/PO/Views/InvoiceEntry/Partials/_MultipleReceipts.cshtml";
        public const string MultipleReceiptsGrid = "~/Areas/PO/Views/InvoiceEntry/Partials/_MultipleReceiptsGrid.cshtml";
        public const string CommentGrid = "~/Areas/PO/Views/InvoiceEntry/Partials/_CommentGrid.cshtml";
        public const string AdditionalCostOptionalField = "~/Areas/PO/Views/InvoiceEntry/Partials/_AdditionalCostOptionalField.cshtml";
        public const string InvoiceDistributeCost = "~/Areas/PO/Views/InvoiceEntry/Partials/_DistributeCost.cshtml";
        public const string InvoiceDistributeCostGrid = "~/Areas/PO/Views/InvoiceEntry/Partials/_DistributeCostGrid.cshtml";
        public const string InvoiceEntryDetailTaxes = "~/Areas/PO/Views/InvoiceEntry/Partials/_DetailTaxes.cshtml";
        public const string InvoiceEntryVendorTaxes = "~/Areas/PO/Views/InvoiceEntry/Partials/_VendorTax.cshtml";
        public const string InvoiceEntryAdditionalCostTaxes = "~/Areas/PO/Views/InvoiceEntry/Partials/_AdditionalCostDetailTaxes.cshtml";
        public const string InvoiceEntryRemitToLocation = "~/Areas/PO/Views/InvoiceEntry/Partials/_RemitToLocation.cshtml";

        #endregion

        #region Purchase Order Action
        public const string PurchaseOrderActionRpt = "~/Areas/PO/Views/PurchaseOrderAction/Partials/_PurchaseOrderAction.cshtml";
        public const string PurchaseOrderActionLocalization = "~/Areas/PO/Views/PurchaseOrderAction/Partials/_Localization.cshtml";
        #endregion

        #region EmailMessage
        /// <summary>
        /// Email Message partial view
        /// </summary>
        public const string EmailMessagePartial = "~/Areas/PO/Views/EmailMessage/Partials/_EmailMessage.cshtml";

        /// <summary>
        /// Email Message localization partial view
        /// </summary>
        public const string LocalizationEmailMessagePartial =
            "~/Areas/PO/Views/EmailMessage/Partials/_Localization.cshtml";
        #endregion

        #region Return Entry

        public const string ReturnEntry = "~/Areas/PO/Views/ReturnEntry/Partials/_ReturnEntry.cshtml";
        public const string ReturnEntryLocalization = "~/Areas/PO/Views/ReturnEntry/Partials/_Localization.cshtml";
        public const string ReturnLineGrid = "~/Areas/PO/Views/ReturnEntry/Partials/_ReturnLineGrid.cshtml";

        public const string ReturnEntryReturnTab = "~/Areas/PO/Views/ReturnEntry/Partials/_Return.cshtml";
        public const string ReturnEntryTaxesTab = "~/Areas/PO/Views/ReturnEntry/Partials/_Taxes.cshtml";
        public const string ReturnEntryOptionalFieldsTab = "~/Areas/PO/Views/ReturnEntry/Partials/_OptionalFields.cshtml";
        public const string ReturnEntryRatesTab = "~/Areas/PO/Views/ReturnEntry/Partials/_Rates.cshtml";
        public const string ReturnEntryTotalsTab = "~/Areas/PO/Views/ReturnEntry/Partials/_Totals.cshtml";

        public const string ReturnEntryVendorInformation = "~/Areas/PO/Views/ReturnEntry/Partials/_VendorInformation.cshtml";
        public const string ReturnEntryBillToLocation = "~/Areas/PO/Views/ReturnEntry/Partials/_BillToLocation.cshtml";
        public const string ReturnEntryDetailTaxes = "~/Areas/PO/Views/ReturnEntry/Partials/_DetailTaxes.cshtml";
        public const string ReturnEntryDetailComments = "~/Areas/PO/Views/ReturnEntry/Partials/_DetailComments.cshtml";
        public const string ReturnEntryDetailOptionalFields = "~/Areas/PO/Views/ReturnEntry/Partials/_DetailOptionalFields.cshtml";

        public const string ReturnEntryTaxesTabTaxGrid = "~/Areas/PO/Views/ReturnEntry/Partials/_TaxesGrid.cshtml";
        #endregion

        #region Mailing Label Report
        /// <summary>
        /// The Return Report Localization
        /// </summary>
        public const string MailingLabelReportLocalization = "~/Areas/PO/Views/MailingLabelReport/Partials/_Localization.cshtml";
        /// <summary>
        /// The Return Report
        /// </summary>
        public const string MailingLabelReport = "~/Areas/PO/Views/MailingLabelReport/Partials/_MailingLabelReport.cshtml";

        #endregion

        #region Credit debit note entry

        /// <summary>
        /// Credit debit note entry partial view
        /// </summary>
        public const string CreditDebitNoteEntry = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_CreditDebitNoteEntry.cshtml";

        /// <summary>
        /// Credit debit note entry localization partial view
        /// </summary>
        public const string CreditDebitNoteLocalization = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Localization.cshtml";

        /// <summary>
        /// Credit debit note tab partial view
        /// </summary>
        public const string CreditDebitNote = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_CreditDebitNote.cshtml";

        /// <summary>
        /// Credit debit note detail grid  partial view
        /// </summary>
        public const string CreditDebitNoteDetailGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_CreditDebitNoteDetailGrid.cshtml";

        /// <summary>
        /// Credit debit note AdditionalCost partial view
        /// </summary>
        public const string CreditDebitNoteAdditionalCost = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_AdditionalCost.cshtml";

        /// <summary>
        /// Credit debit note tax partial view
        /// </summary>
        public const string CreditDebitNoteTax = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Taxes.cshtml";

        /// <summary>
        /// Credit debit note optional field partial view
        /// </summary>
        public const string CreditDebitNoteOptionalField = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_OptionalField.cshtml";

        /// <summary>
        /// Credit debit note total partial view
        /// </summary>
        public const string CreditDebitNoteTotal = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Totals.cshtml";

        /// <summary>
        /// Credit debit note rate partial view
        /// </summary>
        public const string CreditDebitNoteRate = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Rates.cshtml";

        /// <summary>
        /// Credit debit note additional cost grid partial view
        /// </summary>
        public const string CreditDebitNoteAdditionalCostGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_AdditionalCostGrid.cshtml";

        /// <summary>
        /// Credit debit note additional cost tax grid details partial view
        /// </summary>
        public const string AdditionalCostTaxDetailGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_AdditionalCostTaxDetail.cshtml";

        /// <summary>
        /// Credit Debit Comments/Instruction View
        /// </summary>
        public const string CreditDebitDetailComments = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_Comments.cshtml";

        /// <summary>
        ///Vendor Information View
        /// </summary>
        public const string CreditDebitNoteVendorInfo = "~/Areas/PO/Views/Common/VendorInformation/_VendorInfo.cshtml";

        /// <summary>
        ///Vendor Information View
        /// </summary>
        public const string CreditDebitNoteVendorInformation = "~/Areas/PO/Views/Common/VendorInformation/_VendorInformation.cshtml";

        /// <summary>
        ///Vendor Information Localization View
        /// </summary>
        public const string VendorInfoLocalization = "~/Areas/PO/Views/Common/VendorInformation/_Localization.cshtml";

        /// <summary>
        ///Remit-to Location View
        /// </summary>
        public const string CreditDebitNoteRemitToLocation = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_RemitToLocation.cshtml";

        /// <summary>
        ///Bill-to Location View
        /// </summary>
        public const string CreditDebitNoteBillToLocation = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_BillToLocation.cshtml";

        /// <summary>
        ///Detail line optional field grid
        /// </summary>
        public const string CrdrNoteDetailLineOptionalFieldGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_DetailLineOptionalField.cshtml";

        /// <summary>
        ///Additional cost line optional field grid
        /// </summary>
        public const string AdditionalCostOptionalFieldGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_AddCostOptionalField.cshtml";

        /// <summary>
        /// Credit debit note item tax grid details partial view
        /// </summary>
        public const string ItemTaxDetailGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_ItemTaxDetail.cshtml";

        /// <summary>
        /// Credit debit note distribute cost grid partial view
        /// </summary>
        public const string DistributeCost = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_DistributeCost.cshtml";

        /// <summary>
        /// Credit debit note distribute cost grid partial view
        /// </summary>
        public const string DistributeCostGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_DistributeCostGrid.cshtml";

        /// <summary>
        /// Credit debit note vendor tax grid partial view
        /// </summary>
        public const string CreditDebitNoteVendorTaxGrid = "~/Areas/PO/Views/CreditDebitNoteEntry/Partials/_VendorTaxGrid.cshtml";
        #endregion

        #region Pending Receipts Inquiry
        /// <summary>
        /// Pending Receipts Inquiry
        /// </summary>
        public const string PendingReceiptsInquiry = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_PendingReceiptsInquiry.cshtml";

        /// <summary>
        /// Pending ReceiptsInquiry Filter
        /// </summary>
        public const string PendingReceiptsInquiryFilter = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_PendingReceiptsInquiryFilter.cshtml";

        /// <summary>
        /// Pending Receipts Inquiry Grid
        /// </summary>
        public const string PendingReceiptsInquiryGrid = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_PendingReceiptsInquiryGrid.cshtml";

        /// <summary>
        /// Pending Receipts Inquiry Localization
        /// </summary>
        public const string PendingReceiptsInquiryLocalization = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_Localization.cshtml";

        /// <summary>
        /// Pending Receipts Inquiry Detail
        /// </summary>
        public const string PendingReceiptsInquiryDetail = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_PendingReceiptsInquiryDetail.cshtml";

        /// <summary>
        /// Pending Receipts Inquiry Detail Grid
        /// </summary>
        public const string PendingReceiptsInquiryDetailGrid = "~/Areas/PO/Views/PendingReceiptsInquiry/Partials/_PendingReceiptsInquiryDetailGrid.cshtml";


        #endregion

        #region Purchase Statistics Report

        /// <summary>
        /// PO Purchase Statistics Report
        /// </summary>
        public const string PurchaseStatisticsReport = "~/Areas/PO/Views/PurchaseStatisticsReport/Partials/_PurchaseStatisticsReport.cshtml";
        /// <summary>
        /// PO Purchase Statistics Report Localization
        /// </summary>
        public const string PurchaseStatisticsReportLocalization = "~/Areas/PO/Views/PurchaseStatisticsReport/Partials/_Localization.cshtml";

        #endregion
        #region Copy Purchase Order
        /// <summary>
        /// Copy Purchase Order Partial View
        /// </summary>
        public const string CopyPurchaseOrder = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_CopyPurchaseOrder.cshtml";

        /// <summary>
        /// Copy Pos Partial view
        /// </summary>
        public const string CopyPos = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_CopyPos.cshtml";

        /// <summary>
        /// Copy PO Detail Grid Line
        /// </summary>
        public const string CopyPoDetailGridLine = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_CopyPurchaseOrderDetailGrid.cshtml";

        /// <summary>
        /// The purchase order entry localization
        /// </summary>
        public const string CopyPurchaseOrderLocalization = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_Localization.cshtml";

        /// <summary>
        /// The po optional field
        /// </summary>
        public const string CopyPoOptionalField = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The po detail optional field
        /// </summary>
        public const string CopyPoDetailOptionalField = "~/Areas/PO/Views/CopyPurchaseOrder/Partials/_DetailOptionalField.cshtml";

        #endregion

        #region Purchase History

        /// <summary>
        ///  Purchase History Partial View
        /// </summary>
        public const string PurchaseHistory = "~/Areas/PO/Views/PurchaseHistory/Partials/_PurchaseHistory.cshtml";

        /// <summary>
        ///  Purchase History Partial View
        /// </summary>
        public const string PurchaseHistoryGrid = "~/Areas/PO/Views/PurchaseHistory/Partials/_PurchaseHistoryGrid.cshtml";

        /// <summary>
        /// Purchase History localization
        /// </summary>
        public const string
            PurchaseHistoryInquireLocalization =
            "~/Areas/PO/Views/PurchaseHistory/Partials/_Localization.cshtml";

        /// <summary>
        ///  Purchase History Detail Partial View
        /// </summary>
        public const string PurchaseHistoryDetailGrid = "~/Areas/PO/Views/PurchaseHistory/Partials/_PurchaseHistoryDetailGrid.cshtml";

        #endregion

        #region Purchase History Detail

        /// <summary>
        ///  Purchase History Detail Partial View
        /// </summary>
        public const string PurchaseHistoryDetail = "~/Areas/PO/Views/PurchaseHistory/Partials/_PurchaseHistoryDetail.cshtml";

        /// <summary>
        ///  Purchase History Detail Partial View
        /// </summary>
        public const string PurchaseHistoryInquiryDetailGrid = "~/Areas/PO/Views/PurchaseHistory/Partials/_PurchaseHistoryDetailGrid.cshtml";

        #endregion

        #region Comment Instruction

        /// <summary>
        /// Shared DocumentHistoryGrid
        /// </summary>
        public const string CommentLocalization = "~/Areas/PO/Views/Common/CommentInstruction/_Localization.cshtml";

        /// <summary>
        /// The layout
        /// </summary>
        public const string CommentInstruction = "~/Areas/PO/Views/Common/CommentInstruction/_CommentInstruction.cshtml";

        #endregion Comment Instruction

        #region DropShipmentAddress

        /// <summary>
        /// Drop Shipment Address partial view
        /// </summary>
        public const string DropShipmentAddressPartial = "~/Areas/PO/Views/DropShipmentAddress/_DropShip.cshtml";

        /// <summary>
        /// Drop Shipment Address partial view
        /// </summary>
        public const string DropShipmentAddressLocalization = "~/Areas/PO/Views/DropShipmentAddress/_Localization.cshtml";

        #endregion

        #region Bill To Location
        public const string CommonBillToLocation = "~/Areas/PO/Views/BillToLocation/_BillToLocation.cshtml";
        #endregion

        #region PO Distribute Proration

        /// <summary>
        /// Distribute Proration Index page
        /// </summary>
        public const string DistributeProrationIndex = "~/Areas/PO/Views/DistributeProration/Index.cshtml";

        /// <summary>
        /// Distribute Proration
        /// </summary>
        public const string DistributeProration = "~/Areas/PO/Views/DistributeProration/Partials/_DistributeProration.cshtml";

        /// <summary>
        /// Distribute Proration Localization
        /// </summary>
        public const string DistributeProrationLocalization = "~/Areas/PO/Views/DistributeProration/Partials/_Localization.cshtml";

        #endregion

        #region PO Form - Receiving Slips
        /// <summary>
        /// Receiving Slip
        /// </summary>
        public const string ReceivingSlipReport= "~/Areas/PO/Views/ReceivingSlipReport/Partials/_ReceivingSlipReport.cshtml";

        /// <summary>
        /// Receiving Slip Localization
        /// </summary>
        public const string ReceivingSlipReportLocalization = "~/Areas/PO/Views/ReceivingSlipReport/Partials/_Localization.cshtml";

        #endregion

        #region Requisition Report
        /// <summary>
        /// The Requisition Report Localization
        /// </summary>
        public const string RequisitionReportLocalization = "~/Areas/PO/Views/RequisitionReport/Partials/_Localization.cshtml";
        /// <summary>
        /// The Requisition Report
        /// </summary>
        public const string RequisitionReport = "~/Areas/PO/Views/RequisitionReport/Partials/_RequisitionReport.cshtml";

        #endregion

        #region Email Message Report
        /// <summary>
        /// Email Message Report Localization
        /// </summary>
        public const string EmailMessageReportLocalization = "~/Areas/PO/Views/EmailMessageReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Email Message Report
        /// </summary>
        public const string EmailMessageReport = "~/Areas/PO/Views/EmailMessageReport/Partials/_EmailMessageReport.cshtml";
        #endregion
    }
}