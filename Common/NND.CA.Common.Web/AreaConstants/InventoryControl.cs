/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants
{
    /// <summary>
    /// Costant for IC layout path
    /// </summary>
    public static class InventoryControl
    {
        #region Session Variables Used By IC

        /// <summary>
        /// Session Key for Segment 
        /// </summary>
        public const string SessionSegment = "icsegmentCache";

        /// <summary>
        /// Session Key for Item Segments
        /// </summary>
        public const string SessionSegmentCodes = "icSegmentCodes";

        /// <summary>
        /// Session Key for UOM 
        /// </summary>
        public const string SessionUom = "icuomCache";

        /// <summary>
        /// Session Key for WUOM 
        /// </summary>
        public const string SessionWuom = "icwuomCache";

        /// <summary>
        /// Session Key for Optional Field
        /// </summary>
        public const string SessionOptionalField = "icOptionalFieldCache";

        /// <summary>
        /// Session Key for Shipment Optional Field
        /// </summary>
        public const string SessionShipmentOptionalField = "icShipmentOptionalFieldCache";

        /// <summary>
        /// Session Key for Shipment Optional Field
        /// </summary>
        public const string SessionShipmentDetail = "icShipmentDetailCache";

        /// <summary>
        /// Session Key For Location.
        /// </summary>
        public const string SessionLocation = "location";

        /// <summary>
        /// Session Key For Location.
        /// </summary>
        public const string SessionItemLocation = "Itemlocation";

        /// <summary>
        /// Session key for Category
        /// </summary>
        public const string SessionCategory = "category";

        /// <summary>
        /// Session Key for UOMItem 
        /// </summary>
        public const string SessionUOMItem = "icUOMItemCache";

        /// <summary>
        /// Session Key for OptionalField Item 
        /// </summary>
        public const string SessionOptionalFieldItem = "icOptionalFieldItemCache";

        /// <summary>
        /// Session Key for TaxAuthority Item 
        /// </summary>
        public const string SessionTaxAuthorityItem = "icTaxAuthorityItemCache";

        /// <summary>
        /// Session Key for Price List Code Checks
        /// </summary>
        public const string SessionPriceListCodeChecks = "icPriceListCodeChecksCache";

        /// <summary>
        /// Session Key for Price List Code Taxes
        /// </summary>
        public const string SessionPriceListCodeTaxes = "icPriceListCodeTaxesCache";

        /// <summary>
        /// Session Key for Manufacturers Item
        /// </summary>
        public const string SessionManufacturersItem = "icManufacturersItemCache";

        /// <summary>
        /// Session Key for Vendor Item Number
        /// </summary>
        public const string SessionVendorItemNumber = "icVendorItemNumberCache";

        /// <summary>
        /// Session Key for Vendor Item Number
        /// </summary>
        public const string SessionCustomerItemNumber = "icCustomerItemNumberCache";

        /// <summary>
        /// Session Key for InventoryWorksheet
        /// </summary>
        public const string SessionInventoryWorksheet = "icInventoryWorksheetCache";

        /// <summary>
        /// Session Key for Vendor Item Number
        /// </summary>
        public const string SessionKittingItem = "icKittingItemCache";

        /// <summary>
        /// Session Key for ItemPriceCheck
        /// </summary>
        public const string SessionItemPriceCheck = "icItemPriceCheck";

        /// <summary>
        /// Session Key for ItemPriceTax
        /// </summary>
        public const string SessionItemPriceTax = "icItemPriceTax";

        /// <summary>
        /// Session Key for BasePriceDetail
        /// </summary>
        public const string SessionBasePriceDetail = "icBasePriceDetail";

        /// <summary>
        /// Session Key for SalePriceDetail
        /// </summary>
        public const string SessionSalePriceDetail = "icSalePriceDetail";

        /// <summary>
        /// Session Key for Adjustment
        /// </summary>
        public const string SessionAdjustment = "icAdjustmentCache";

        /// <summary>
        /// Session Key for Location Details
        /// </summary>
        public const string SessionLocationDetail = "icLocationDetail";

        /// <summary>
        /// Session Key for Reorder Quantity Optional Field 
        /// </summary>
        public const string SessionReorderQntOptField = "icReorderQntOptField";

        /// <summary>
        /// Session Key for Reorder Quantity Detail 
        /// </summary>
        public const string SessionReorderQntDetail = "icReorderQntDetail";

        /// <summary>
        /// Session Key for BOM Components
        /// </summary>
        public const string SessionBOMComponent = "icBOMComponentCache";

        /// <summary>
        /// Session Key for BOM Components
        /// </summary>
        public const string SessionItemWizardUom = "icItemUomCache";

        #endregion

        /// <summary>
        /// The options
        /// </summary>
        public const string Options = "~/Areas/IC/Views/ICOptions/Partials/_Options.cshtml";

        /// <summary>
        /// The options company
        /// </summary>
        public const string OptionsCompany = "~/Areas/IC/Views/ICOptions/Partials/_Company.cshtml";

        /// <summary>
        /// The options account
        /// </summary>
        public const string OptionsProcessing = "~/Areas/IC/Views/ICOptions/Partials/_Processing.cshtml";

        /// <summary>
        /// The options localization
        /// </summary>
        public const string OptionsLocalization = "~/Areas/IC/Views/ICOptions/Partials/_Localization.cshtml";

        /// <summary>
        /// The options posting
        /// </summary>
        public const string OptionsItems = "~/Areas/IC/Views/ICOptions/Partials/_Items.cshtml";

        /// <summary>
        /// The options segments
        /// </summary>
        public const string OptionsDocuments = "~/Areas/IC/Views/ICOptions/Partials/_Documents.cshtml";

        /// <summary>
        /// The options segment grid
        /// </summary>
        public const string OptionsCosting = "~/Areas/IC/Views/ICOptions/Partials/_Costing.cshtml";



        /// <summary>
        /// The Item Separator Grid
        /// </summary>
        public const string ItemSeparatorGrid = "~/Areas/IC/Views/ICOptions/Partials/_ItemSeparator.cshtml";

        /// <summary>
        /// The item segment grid
        /// </summary>
        public const string OptionsSegment = "~/Areas/IC/Views/ICOptions/Partials/_ItemSegments.cshtml";

        /// <summary>
        /// The SegmentCode
        /// </summary>
        public const string SegmentCode = "~/Areas/IC/Views/ICSegmentCode/Partials/_SegmentCode.cshtml";

        /// <summary>
        /// The SegmentCode localization
        /// </summary>
        public const string SegmentCodeLocalization = "~/Areas/IC/Views/ICSegmentCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The SegmentCode grid
        /// </summary>
        public const string SegmentCodeGrid = "~/Areas/IC/Views/ICSegmentCode/Partials/_SegmentCodeGrid.cshtml";

        /// <summary>
        /// The UnitsofMeasure
        /// </summary>
        public const string UnitsOfMeasure = "~/Areas/IC/Views/UnitsOfMeasure/Partials/_UnitsOfMeasure.cshtml";

        /// <summary>
        /// The UnitsofMeasure localization
        /// </summary>
        public const string UnitsOfMeasureLocalization = "~/Areas/IC/Views/UnitsOfMeasure/Partials/_Localization.cshtml";

        /// <summary>
        /// The UnitsofMeasure grid
        /// </summary>
        public const string UnitsOfMeasureGrid = "~/Areas/IC/Views/UnitsOfMeasure/Partials/_UnitsOfMeasureGrid.cshtml";

        ///<summary>
        /// The Document Numbers grid
        /// </summary>
        public const string DocumentNumberGrid = "~/Areas/IC/Views/ICOptions/Partials/_DocumentNumbers.cshtml";
        /// <summary>
        /// The UnitsofMeasure
        /// </summary>
        public const string WeightUnitsofMeasure = "~/Areas/IC/Views/WeightUnitOfMeasure/Partials/_WeightUnitOfMeasure.cshtml";

        /// <summary>
        /// The UnitsofMeasure localization
        /// </summary>
        public const string WeightUnitsofMeasureLocalization = "~/Areas/IC/Views/WeightUnitOfMeasure/Partials/_Localization.cshtml";

        /// <summary>
        /// The UnitsofMeasure grid
        /// </summary>
        public const string WeightUnitsofMeasureGrid = "~/Areas/IC/Views/WeightUnitOfMeasure/Partials/_WeightUnitOfMeasureGrid.cshtml";

        ///<summary>
        /// The Account Set
        /// </summary>
        public const string AccountSet = "~/Areas/IC/Views/AccountSet/Partials/_AccountSet.cshtml";

        ///<summary>
        /// The Account Set Grid
        /// </summary>
        public const string GlAccountSetDetails = "~/Areas/IC/Views/AccountSet/Partials/_GlAccountDetail.cshtml";

        /// <summary>
        /// The Account Set localization
        /// </summary>
        public const string AccountSetLocalization = "~/Areas/IC/Views/AccountSet/Partials/_Localization.cshtml";

        /// <summary>
        /// The ItemStructure
        /// </summary>
        public const string ItemStructure = "~/Areas/IC/Views/ItemStructure/Partials/_ItemStructure.cshtml";

        /// <summary>
        /// The ItemStructure localization
        /// </summary>
        public const string ItemStructureLocalization = "~/Areas/IC/Views/ItemStructure/Partials/_Localization.cshtml";

        /// <summary>
        /// The ItemStructure grid
        /// </summary>
        public const string ItemStructureGrid = "~/Areas/IC/Views/ItemStructure/Partials/_ItemStructureGrid.cshtml";

        /// <summary>
        /// The CreateGLBatch
        /// </summary>
        public const string ICCreateGLBatch = "~/Areas/IC/Views/CreateGLBatch/Partials/CreateGLBatch.cshtml";

        /// <summary>
        /// The OptionalField
        /// </summary>
        public const string OptionalField = "~/Areas/IC/Views/OptionalField/Partials/_OptionalField.cshtml";

        /// <summary>
        /// The OptionalField localization
        /// </summary>
        public const string OptionalFieldLocalization = "~/Areas/IC/Views/OptionalField/Partials/_Localization.cshtml";

        /// <summary>
        /// The OptionalField grid
        /// </summary>
        public const string OptionalFieldGrid = "~/Areas/IC/Views/OptionalField/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The OptionalField Settings
        /// </summary>
        public const string OptionalFieldSettings = "~/Areas/IC/Views/OptionalField/Partials/_OptionalFieldSettings.cshtml";

        /// <summary>
        /// Location view
        /// </summary>
        public const string Location = "~/Areas/IC/Views/Location/Partials/_Location.cshtml";

        /// <summary>
        /// The Location Localization
        /// </summary>
        public const string LocationLocalization = "~/Areas/IC/Views/Location/Partials/_Localization.cshtml";

        /// <summary>
        /// LocationAddress view
        /// </summary>
        public const string LocationAddress = "~/Areas/IC/Views/Location/Partials/_Address.cshtml";

        /// <summary>
        /// LocationContact view
        /// </summary>
        public const string LocationContact = "~/Areas/IC/Views/Location/Partials/_Contact.cshtml";

        /// <summary>
        /// LocationIntegration view
        /// </summary>
        public const string LocationIntegration = "~/Areas/IC/Views/Location/Partials/_Integration.cshtml";

        /// <summary>
        /// LocationItems view.
        /// </summary>
        public const string LocationItems = "~/Areas/IC/Views/Location/Partials/_Items.cshtml";

        /// <summary>
        ///Location Items Grid
        /// </summary>
        public const string LocationItemsGrid = "~/Areas/IC/Views/Location/Partials/_ItemsGrid.cshtml";

        /// <summary>
        /// Gl Segments Grid
        /// </summary>
        public const string LocationGLSegmentGrid = "~/Areas/IC/Views/Location/Partials/_GLSegmentGrid.cshtml";

        /// <summary>
        /// IC Category Header Partial View
        /// </summary>
        public const string Category = "~/Areas/IC/Views/Category/Partials/_Category.cshtml";

        /// <summary>
        /// The Category localization
        /// </summary>
        public const string CategoryLocalization = "~/Areas/IC/Views/Category/Partials/_Localization.cshtml";

        /// <summary>
        /// The Category Tax grid
        /// </summary>
        public const string CategoryTaxGrid = "~/Areas/IC/Views/Category/Partials/_CategoryTaxGrid.cshtml";

        /// <summary>
        /// The Category Options Tab
        /// </summary>
        public const string CategoryOption = "~/Areas/IC/Views/Category/Partials/_CategoryOption.cshtml";

        #region Price List Code

        /// <summary>
        /// The Price List Code
        /// </summary>
        public const string PriceListCode = "~/Areas/IC/Views/PriceListCode/Partials/_PriceListCode.cshtml";

        /// <summary>
        /// The Price List Code localization
        /// </summary>
        public const string PriceListCodeLocalization = "~/Areas/IC/Views/PriceListCode/Partials/_Localization.cshtml";

        /// <summary>
        /// The Discount
        /// </summary>
        public const string Discount = "~/Areas/IC/Views/PriceListCode/Partials/_Discount.cshtml";

        /// <summary>
        /// The Price Check
        /// </summary>
        public const string PriceCheck = "~/Areas/IC/Views/PriceListCode/Partials/_PriceCheck.cshtml";

        /// <summary>
        /// The Price Check grid
        /// </summary>
        public const string PriceCheckGrid = "~/Areas/IC/Views/PriceListCode/Partials/_PriceCheckGrid.cshtml";

        /// <summary>
        /// The Taxes
        /// </summary>
        public const string Tax = "~/Areas/IC/Views/PriceListCode/Partials/_Tax.cshtml";

        /// <summary>
        /// The Taxes grid
        /// </summary>
        public const string TaxGrid = "~/Areas/IC/Views/PriceListCode/Partials/_TaxGrid.cshtml";

        #endregion

        #region Item

        /// <summary>
        /// The Item
        /// </summary>
        public const string Item = "~/Areas/IC/Views/Item/Partials/_Item.cshtml";

        /// <summary>
        /// The Item localization
        /// </summary>
        public const string ItemLocalization = "~/Areas/IC/Views/Item/Partials/_Localization.cshtml";


        /// <summary>
        /// The Item Detail tab
        /// </summary>
        public const string ItemDetail = "~/Areas/IC/Views/Item/Partials/_ItemDetail.cshtml";

        /// <summary>
        /// The Item Unit tab
        /// </summary>
        public const string ItemUnit = "~/Areas/IC/Views/Item/Partials/_ItemUnit.cshtml";

        /// <summary>
        /// The Item tax tab
        /// </summary>
        public const string ItemTax = "~/Areas/IC/Views/Item/Partials/_ItemTax.cshtml";

        /// <summary>
        /// The Item tax Grid
        /// </summary>
        public const string ItemTaxGrid = "~/Areas/IC/Views/Item/Partials/_ItemTaxGrid.cshtml";

        /// <summary>
        /// The Item Optional Field tab
        /// </summary>
        public const string ItemOptionalField = "~/Areas/IC/Views/Item/Partials/_ItemOptionalField.cshtml";


        /// <summary>
        /// The Item Unit Grid
        /// </summary>
        public const string ItemUnitGrid = "~/Areas/IC/Views/Item/Partials/_ItemUnitGrid.cshtml";

        #endregion

        #region Contract Pricing

        /// <summary>
        /// Contract Pricing Localization Partial View
        /// </summary>
        public const string ContractPricingLocalization = "~/Areas/IC/Views/ContractPricingReport/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract Pricing Partial View
        /// </summary>
        public const string ContractPricingReport = "~/Areas/IC/Views/ContractPricingReport/Partials/_ContractPricing.cshtml";

        #endregion

        #region Contract Pricing

        /// <summary>
        /// Contract Pricing Localization For Finder implemenation
        /// </summary>
        public const string ContractPricingLocalizationFinder = "~/Areas/IC/Views/ContractPrice/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract Pricing Partial View For Finder implemenation
        /// </summary>
        public const string ContractPricingFinder = "~/Areas/IC/Views/ContractPrice/Partials/_ContractPricing.cshtml";

        #endregion

        #region Price List Report

        /// <summary>
        /// PriceList Report
        /// </summary>
        public const string PriceList = "~/Areas/IC/Views/PriceList/Partials/_PriceList.cshtml";

        /// <summary>
        /// PriceList Report Localization
        /// </summary>
        public const string PriceListLocalization = "~/Areas/IC/Views/PriceList/Partials/_Localization.cshtml";

        #endregion

        #region SalesStatistics Report

        /// <summary>
        /// SalesStatistics Report
        /// </summary>
        public const string SalesStatistics = "~/Areas/IC/Views/SalesStatisticsReport/Partials/_SalesStatistics.cshtml";

        /// <summary>
        /// SalesStatistics Report Localization
        /// </summary>
        public const string SalesStatisticsLocalization = "~/Areas/IC/Views/SalesStatisticsReport/Partials/_Localization.cshtml";

        #endregion

        #region Posting Journal Report

        /// <summary>
        /// PostingJournal Report
        /// </summary>
        public const string PostingJournal = "~/Areas/IC/Views/PostingJournal/Partials/_PostingJournal.cshtml";

        /// <summary>
        /// PostingJournal Report Localization
        /// </summary>
        public const string PostingJournalLocalization = "~/Areas/IC/Views/PostingJournal/Partials/_Localization.cshtml";

        #endregion

        #region Selling Price Margin Report

        /// <summary>
        /// SellingPriceMargin Report
        /// </summary>
        public const string SellingPriceMargin = "~/Areas/IC/Views/SellingPriceMargin/Partials/_SellingPriceMargin.cshtml";

        /// <summary>
        /// SellingPriceMargin Report Localization
        /// </summary>
        public const string SellingPriceMarginLocalization = "~/Areas/IC/Views/SellingPriceMargin/Partials/_Localization.cshtml";

        /// <summary>
        /// Sort By Partial view
        /// </summary>
        public const string SortBy = "~/Areas/IC/Views/Shared/Partials/_SortBy.cshtml";

        /// <summary>
        /// Common report localization 
        /// </summary>
        public const string ReportLocalization = "~/Areas/IC/Views/Shared/Partials/_ReportLocalization.cshtml";
        #endregion

        #region BinShelfLabels Report

        /// <summary>
        /// BinShelfLabelsReport
        /// </summary>
        public const string BinShelfLabel = "~/Areas/IC/Views/BinShelfLabel/Partials/_BinShelfLabel.cshtml";

        /// <summary>
        /// BinShelfLabels Report Localization
        /// </summary>
        public const string BinShelfLabelLocalization = "~/Areas/IC/Views/BinShelfLabel/Partials/_Localization.cshtml";

        #endregion


        #region Recall Report

        /// <summary>
        /// Recall Report
        /// </summary>
        public const string Recall = "~/Areas/IC/Views/Recall/Partials/_Recall.cshtml";

        /// <summary>
        /// Recall  Report Localization
        /// </summary>
        public const string RecallLocalization = "~/Areas/IC/Views/Recall/Partials/_Localization.cshtml";

        #endregion

        #region ItemLabel Report

        /// <summary>
        /// BinShelfLabelsReport
        /// </summary>
        public const string ItemLabel = "~/Areas/IC/Views/ItemLabel/Partials/_ItemLabel.cshtml";

        /// <summary>
        /// ItemLabe Report Localization
        /// </summary>
        public const string ItemLabelLocalization = "~/Areas/IC/Views/ItemLabel/Partials/_Localization.cshtml";

        #endregion

        #region Reorder Report

        /// <summary>
        /// Reorder Report
        /// </summary>
        public const string Reorder = "~/Areas/IC/Views/Reorder/Partials/_Reorder.cshtml";

        /// <summary>
        /// Reorder Report Localization
        /// </summary>
        public const string ReorderLocalization = "~/Areas/IC/Views/Reorder/Partials/_Localization.cshtml";

        ///// <summary>
        ///// Sort By Partial view
        ///// </summary>
        //public const string SortBy = "~/Areas/IC/Views/Shared/Partials/_SortBy.cshtml";

        ///// <summary>
        ///// Common report localization 
        ///// </summary>
        //public const string ReportLocalization = "~/Areas/IC/Views/Shared/Partials/_ReportLocalization.cshtml";
        #endregion

        #region ManufacturersItem
        /// <summary>
        /// Contract Pricing Localization For Finder implemenation
        /// </summary>
        public const string ManufacturersItemLocalization = "~/Areas/IC/Views/ManufacturersItem/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract Pricing Partial View For Finder implemenation
        /// </summary>
        public const string ManufacturersItem = "~/Areas/IC/Views/ManufacturersItem/Partials/_ManufacturersItem.cshtml";

        /// <summary>
        /// Contract Pricing Partial View For Finder implemenation
        /// </summary>
        public const string ManufacturersItemGrid = "~/Areas/IC/Views/ManufacturersItem/Partials/_ManufacturersItemGrid.cshtml";

        #endregion
        ///<summary>
        /// The GLTransaction Partial View
        /// </summary>
        public const string GLTransactionRpt = "~/Areas/IC/Views/GLTransaction/Partials/_GLTransaction.cshtml";

        #region Construct Item

        /// <summary>
        /// The ConstructItem
        /// </summary>
        public const string ConstructItem = "~/Areas/IC/Views/ConstructItem/_ConstructItem.cshtml";

        /// <summary>
        /// The ConstructItem localization
        /// </summary>
        public const string ConstructItemLocalization = "~/Areas/IC/Views/ConstructItem/_Localization.cshtml";

        /// <summary>
        /// The ConstructItem grid
        /// </summary>
        public const string ConstructItemGrid = "~/Areas/IC/Views/ConstructItem/_ConstructItemGrid.cshtml";

        #endregion

        #region Shipment

        /// <summary>
        /// The Shipment Partial View
        /// </summary>
        public const string Shipment = "~/Areas/IC/Views/Shipment/Partials/_Shipment.cshtml";

        /// <summary>
        /// The Shipment Detail Partial View
        /// </summary>
        public const string ShipmentGrid = "~/Areas/IC/Views/Shipment/Partials/_ShipmentGrid.cshtml";

        /// <summary>
        /// The Shipment Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string ShipmentOptionalFields = "~/Areas/IC/Views/Shipment/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The Shipment Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string ShipmentDetailOptionalFields = "~/Areas/IC/Views/Shipment/Partials/_DetailGridOptionalField.cshtml";

        /// <summary>
        /// The Shipment Exchange Rate popup Partial View
        /// </summary>
        public const string ShipmentExchangeRate = "~/Areas/IC/Views/Shipment/Partials/_ExchangeRate.cshtml";

        /// <summary>
        /// The Shipment localization
        /// </summary>
        public const string ShipmentLocalization = "~/Areas/IC/Views/Shipment/Partials/_Localization.cshtml";

        #endregion

        #region InventoryMovement Report

        /// <summary>
        /// InventoryMovement Report
        /// </summary>
        public const string InventoryMovement = "~/Areas/IC/Views/InventoryMovement/Partials/_InventoryMovement.cshtml";

        /// <summary>
        /// InventoryMovement Report Localization
        /// </summary>
        public const string InventoryMovementLocalization = "~/Areas/IC/Views/InventoryMovement/Partials/_Localization.cshtml";

        #endregion

        #region AgedInventory Report

        /// <summary>
        /// AgedInventory Report
        /// </summary>
        public const string AgedInventory = "~/Areas/IC/Views/AgedInventory/Partials/_AgedInventory.cshtml";

        /// <summary>
        /// AgedInventory Report Localization
        /// </summary>
        public const string AgedInventoryLocalization = "~/Areas/IC/Views/AgedInventory/Partials/_Localization.cshtml";

        #endregion

        #region Transaction Statistics
        ///<summary>
        /// The Transaction Statistics
        /// </summary>
        public const string TransactionStatistics = "~/Areas/IC/Views/TransactionStatistics/Partials/_TransactionStatistics.cshtml";

        ///<summary>
        /// The Transaction Statistics Grid
        /// </summary>
        public const string TransactionStatisticsGrid = "~/Areas/IC/Views/TransactionStatistics/Partials/_TransactionStatisticsGrid.cshtml";

        /// <summary>
        /// The Transaction Statistics localization
        /// </summary>
        public const string TransactionStatisticsLocalization = "~/Areas/IC/Views/TransactionStatistics/Partials/_Localization.cshtml";
        #endregion

        #region Vendor Detail

        /// <summary>
        /// VendorDetail Localization
        /// </summary>
        public const string VendorDetailLocalization = "~/Areas/IC/Views/VendorDetail/Partials/_Localization.cshtml";

        /// <summary>
        /// VendorDetail Partial View
        /// </summary>
        public const string VendorDetail = "~/Areas/IC/Views/VendorDetail/Partials/_VendorDetail.cshtml";

        /// <summary>
        /// VendorDetail Partial View For Grid implementation
        /// </summary>
        public const string VendorDetailGrid = "~/Areas/IC/Views/VendorDetail/Partials/_VendorDetailGrid.cshtml";

        #endregion

        #region Transaction Statistics Report

        /// <summary>
        /// IC Transaction Statistics Report
        /// </summary>
        public const string TransactionStatisticsReport = "~/Areas/IC/Views/TransactionStatisticsReport/Partials/_TransactionStatisticsReport.cshtml";
        /// <summary>
        /// IC Transaction Statistics Report Localization
        /// </summary>
        public const string TransactionStatisticsReportLocalization = "~/Areas/IC/Views/TransactionStatisticsReport/Partials/_Localization.cshtml";
        #endregion

        #region Item Pricing

        /// <summary>
        /// Item Pricing
        /// </summary>
        public const string ItemPricing = "~/Areas/IC/Views/ItemPricing/Partials/_ItemPricing.cshtml";

        /// <summary>
        /// Item Pricing Localization
        /// </summary>
        public const string ItemPricingLocalization = "~/Areas/IC/Views/ItemPricing/Partials/_Localization.cshtml";

        /// <summary>
        /// Item Pricing Grid
        /// </summary>
        public const string ItemPricingGrid = "~/Areas/IC/Views/ItemPricing/Partials/_ItemPricingGrid.cshtml";

        #endregion

        #region GLIntegration

        ///<summary>
        /// The ICGLIntegration Partial View
        /// </summary>
        public const string GLIntegration = "~/Areas/IC/Views/GLIntegration/Partials/_GLIntegration.cshtml";
        /// <summary>
        /// The ICGLIntegration localization
        /// </summary>
        public const string GLIntegrationLocalization = "~/Areas/IC/Views/GLIntegration/Partials/_Localization.cshtml";
        /// <summary>
        /// The ICGLIntegration Options
        /// </summary>
        public const string GLIntegrationOptions = "~/Areas/IC/Views/GLIntegration/Partials/_Options.cshtml";
        /// <summary>
        /// The ICGLIntegration Transactions
        /// </summary>
        public const string GLIntegrationTransactions = "~/Areas/IC/Views/GLIntegration/Partials/_Transactions.cshtml";


        #endregion

        #region Customer Detail

        /// <summary>
        /// VendorDetail Localization
        /// </summary>
        public const string CustomerDetailLocalization = "~/Areas/IC/Views/CustomerDetail/Partials/_Localization.cshtml";

        /// <summary>
        /// VendorDetail Partial View
        /// </summary>
        public const string CustomerDetail = "~/Areas/IC/Views/CustomerDetail/Partials/_CustomerDetail.cshtml";

        /// <summary>
        /// VendorDetail Partial View For Grid implementation
        /// </summary>
        public const string CustomerDetailGrid = "~/Areas/IC/Views/CustomerDetail/Partials/_CustomerDetailGrid.cshtml";


        /// <summary>
        /// ContractCode Partial View For Grid implementation
        /// </summary>
        public const string ContractCodeGrid = "~/Areas/IC/Views/ContractCode/Partials/_ContractCodeGrid.cshtml";

        /// <summary>
        /// WarrantyCode Partial View For Grid implementation
        /// </summary>
        public const string WarrantyCodeGrid = "~/Areas/IC/Views/WarrantyCode/Partials/_WarrantyCodeGrid.cshtml";
        #endregion

        #region Sale Statistics

        ///<summary>
        /// Sale Statistics
        /// </summary>
        public const string SalesStatistic = "~/Areas/IC/Views/SalesStatistic/Partials/_SalesStatistic.cshtml";

        ///<summary>
        /// Sale Statistics Grid
        /// </summary>
        public const string SalesStatisticGrid = "~/Areas/IC/Views/SalesStatistic/Partials/_SalesStatisticGrid.cshtml";

        /// <summary>
        /// Sale Statistics localization
        /// </summary>
        public const string SalesStatisticLocalization = "~/Areas/IC/Views/SalesStatistic/Partials/_Localization.cshtml";

        #endregion

        #region Alternate Item Report

        /// <summary>
        /// PriceList Report
        /// </summary>
        public const string AlternateItemReport = "~/Areas/IC/Views/AlternateItemReport/Partials/_AlternateItemReport.cshtml";

        /// <summary>
        /// PriceList Report Localization
        /// </summary>
        public const string AlternateItemReportLocalization = "~/Areas/IC/Views/AlternateItemReport/Partials/_Localization.cshtml";

        #endregion

        #region Inventory Count

        /// <summary>
        /// Inventory Count
        /// </summary>
        public const string InventoryCount = "~/Areas/IC/Views/InventoryCount/Partials/_InventoryCount.cshtml";

        /// <summary>
        /// Inventory Count Localization
        /// </summary>
        public const string InventoryCountLocalization = "~/Areas/IC/Views/InventoryCount/Partials/_Localization.cshtml";

        /// <summary>
        /// Inventory Count Grid
        /// </summary>
        public const string InventoryCountGrid = "~/Areas/IC/Views/InventoryCount/Partials/_InventoryCountGrid.cshtml";

        /// <summary>
        /// Inventory Count OptionalFields Popup
        /// </summary>
        public const string InventoryCountOptionalField = "~/Areas/IC/Views/InventoryCount/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// Inventory Count Detail OptionalFields Popup
        /// </summary>
        public const string InventoryCountDetailOptionalField = "~/Areas/IC/Views/InventoryCount/Partials/_DetailOptionalFieldGrid.cshtml";

        /// <summary>
        /// Inventory Count Quantities Popup
        /// </summary>
        public const string InventoryCountQuantity = "~/Areas/IC/Views/InventoryCount/Partials/_Quantity.cshtml";

        #endregion

        #region Receipt

        /// <summary>
        /// The Receipt Partial View
        /// </summary>
        public const string Receipt = "~/Areas/IC/Views/Receipt/Partials/_Receipt.cshtml";

        /// <summary>
        /// The Receipt Detail Partial View
        /// </summary>
        public const string ReceiptGrid = "~/Areas/IC/Views/Receipt/Partials/_ReceiptGrid.cshtml";

        /// <summary>
        /// The Receipt Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string ReceiptOptionalFields = "~/Areas/IC/Views/Receipt/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The Receipt Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string ReceiptDetailOptionalFields = "~/Areas/IC/Views/Receipt/Partials/_DetailGridOptionalField.cshtml";

        /// <summary>
        /// The Receipt Exchange Rate popup Partial View
        /// </summary>
        public const string ReceiptExchangeRate = "~/Areas/IC/Views/Receipt/Partials/_ExchangeRate.cshtml";

        /// <summary>
        /// The Receipt localization
        /// </summary>
        public const string ReceiptLocalization = "~/Areas/IC/Views/Receipt/Partials/_Localization.cshtml";

        #endregion

        #region Item Pricing Detail

        /// <summary>
        /// Item Prices tab
        /// </summary>
        public const string ItemPriceDetail = "~/Areas/IC/Views/ItemPricingDetail/_ItemPricingDetail.cshtml";

        /// <summary>
        /// Item Prices tab
        /// </summary>
        public const string ItemPrice = "~/Areas/IC/Views/ItemPricingDetail/_Price.cshtml";

        /// <summary>
        /// Item Discounts tab
        /// </summary>
        public const string ItemDiscount = "~/Areas/IC/Views/ItemPricingDetail/_Discount.cshtml";

        /// <summary>
        /// Item PriceCheck tab
        /// </summary>
        public const string ItemPriceCheck = "~/Areas/IC/Views/ItemPricingDetail/_PriceCheck.cshtml";

        /// <summary>
        /// Item PriceCheck Grid
        /// </summary>
        public const string ItemPriceCheckGrid = "~/Areas/IC/Views/ItemPricingDetail/_PriceCheckGrid.cshtml";

        /// <summary>
        /// Item Tax tab
        /// </summary>
        public const string ItemTaxes = "~/Areas/IC/Views/ItemPricingDetail/_Tax.cshtml";

        /// <summary>
        /// Item Tax Grid
        /// </summary>
        public const string ItemTaxesGrid = "~/Areas/IC/Views/ItemPricingDetail/_TaxGrid.cshtml";

        /// <summary>
        /// Base Price Units Of Measure
        /// </summary>
        public const string BasePriceUnitsOfMeasure = "~/Areas/IC/Views/ItemPricingDetail/_BasePriceUnitsOfMeasure.cshtml";

        /// <summary>
        /// Base Price Units Of Measure Grid
        /// </summary>
        public const string BasePriceUnitsOfMeasureGrid = "~/Areas/IC/Views/ItemPricingDetail/_BasePriceUnitsOfMeasureGrid.cshtml";

        /// <summary>
        /// Sale Price Units Of Measure
        /// </summary>
        public const string SalePriceUnitsOfMeasure = "~/Areas/IC/Views/ItemPricingDetail/_SalePriceUnitsOfMeasure.cshtml";

        /// <summary>
        /// Sale Price Units Of Measure Grid
        /// </summary>
        public const string SalePriceUnitsOfMeasureGrid = "~/Areas/IC/Views/ItemPricingDetail/_SalePriceUnitsOfMeasureGrid.cshtml";

        /// <summary>
        /// Item Pricing Detail Popup Screen
        /// </summary>
        public const string ItemPricingDetailPopupScreen = "~/Areas/IC/Views/ItemPricingDetail/_ItemPricingPopupScreens.cshtml";

        /// <summary>
        /// Default Price Header
        /// </summary>
        public const string DefaultPriceHeader = "~/Areas/IC/Views/ItemPricingDetail/_DefaultPriceHeader.cshtml";

        /// <summary>
        /// Default Base Price
        /// </summary>
        public const string DefaultBasePrice = "~/Areas/IC/Views/ItemPricingDetail/_DefaultBasePrice.cshtml";

        /// <summary>
        /// Default Sale Price
        /// </summary>
        public const string DefaultSalePrice = "~/Areas/IC/Views/ItemPricingDetail/_DefaultSalePrice.cshtml";

        #endregion

        #region Kitting Item
        /// <summary>
        /// 
        /// </summary>
        public const string KittingItem = "~/Areas/IC/Views/KittingItem/Partials/_KittingItem.cshtml";

        /// <summary>
        /// The Price List Code localization
        /// </summary>
        public const string KittingItemLocalization = "~/Areas/IC/Views/KittingItem/Partials/_Localization.cshtml";

        /// <summary>
        /// The Discount
        /// </summary>
        public const string KittingItemDetail = "~/Areas/IC/Views/KittingItem/Partials/_KittingItemDetail.cshtml";

        #endregion


        #region InventoryWorksheet
        /// <summary>
        /// The Inventory Worksheet Localization
        /// </summary>
        public const string InventoryWorksheetLocalization = "~/Areas/IC/Views/InventoryWorksheet/Partials/_Localization.cshtml";

        /// <summary>
        /// The Inventory Worksheet Partial View
        /// </summary>
        public const string InventoryWorksheet = "~/Areas/IC/Views/InventoryWorksheet/Partials/_InventoryWorksheet.cshtml";

        #endregion

        #region Markup Analysis Report

        /// <summary>
        /// MarkupAnalysis Report
        /// </summary>
        public const string MarkupAnalysis = "~/Areas/IC/Views/MarkupAnalysis/Partials/_MarkupAnalysis.cshtml";

        /// <summary>
        /// MarkupAnalysis Report Localization
        /// </summary>
        public const string MarkupAnalysisLocalization = "~/Areas/IC/Views/MarkupAnalysis/Partials/_Localization.cshtml";

        #endregion

        #region Adjustment

        /// <summary>
        /// 
        /// </summary>
        public const string Adjustment = "~/Areas/IC/Views/Adjustment/Partials/_Adjustment.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string AdjustmentDetail = "~/Areas/IC/Views/Adjustment/Partials/_AdjustmentDetail.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string AdjustmentLocalization = "~/Areas/IC/Views/Adjustment/Partials/_Localization.cshtml";

        /// <summary>
        /// The Adjustment Detail Grid Partial View
        /// </summary>
        public const string AdjustmentDetailGrid = "~/Areas/IC/Views/Adjustment/Partials/_AdjustmentDetailGrid.cshtml";

        /// <summary>
        /// The Adjustment ptionalFields popup Partial View
        /// </summary>
        public const string AdjustmentOptionalFields = "~/Areas/IC/Views/Adjustment/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The Adjustment Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string AdjustmentDetailOptionalFields = "~/Areas/IC/Views/Adjustment/Partials/_DetailOptionalFieldGrid.cshtml";

        #endregion

        #region Transaction Listing Report

        /// <summary>
        /// TransactionListing Report
        /// </summary>
        public const string TransactionListing = "~/Areas/IC/Views/TransactionListing/Partials/_TransactionListing.cshtml";

        /// <summary>
        /// TransactionListing Report Localization
        /// </summary>
        public const string TransactionListingLocalization = "~/Areas/IC/Views/TransactionListing/Partials/_Localization.cshtml";

        #endregion

        #region LIFO/FIFO Inquiry

        /// <summary>
        /// The LIFO/FIFO Inquiry
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string LIFOFIFOInquiry = "~/Areas/IC/Views/LIFOFIFOInquiry/Partials/_LIFOFIFOInquiry.cshtml";

        /// <summary>
        /// The LIFO/FIFO Inquiry localization
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string LIFOFIFOInquiryLocalization = "~/Areas/IC/Views/LIFOFIFOInquiry/Partials/_Localization.cshtml";

        /// <summary>
        /// The LIFO/FIFO Inquiry Grid
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string LifoFifoInquiryGrid = "~/Areas/IC/Views/LIFOFIFOInquiry/Partials/_LIFOFIFOInquiryGrid.cshtml";

        #endregion

        #region Receipt Cost / LIFO/FIFO Inquiry Information

        /// <summary>
        /// The LIFO/FIFO Inquiry Information Form
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string ReceiptCostInformation = "~/Areas/IC/Views/ReceiptCost/_ReceiptCostInformation.cshtml";

        /// <summary>
        /// The LIFO/FIFO Inquiry Information Grid
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string ReceiptCostInformationGrid = "~/Areas/IC/Views/ReceiptCost/_ReceiptCostInformationGrid.cshtml";

        /// <summary>
        /// The LIFO/FIFO Inquiry Information Grid
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string ReceiptCostInformationGridColumnsLocalization = "~/Areas/IC/Views/ReceiptCost/_Localization.cshtml";

        #endregion

        #region Transaction History Inquiry

        /// <summary>
        /// TransactionHistoryInquiry partial view.
        /// </summary>
        public const string TransactionHistoryInquiry = "~/Areas/IC/Views/TransactionHistoryInquiry/Partials/_TransactionHistoryInquiry.cshtml";

        /// <summary>
        /// The Transaction History Inquiry localization
        /// </summary>
        public const string TransactionHistoryInquiryLocalization = "~/Areas/IC/Views/TransactionHistoryInquiry/Partials/_Localization.cshtml";

        /// <summary>
        ///Transaction History Grid partial view
        /// </summary>
        public const string TransactionHistoryGrid = "~/Areas/IC/Views/TransactionHistoryInquiry/Partials/_TransactionHistoryGrid.cshtml";

        /// <summary>
        ///Transaction History Detail partial view
        /// </summary>
        public const string TransactionHistoryDetail = "~/Areas/IC/Views/TransactionHistoryInquiry/Partials/_TransactionHistoryInquiryDetail.cshtml";

        /// <summary>
        ///Transaction History Detail Grid partial view
        /// </summary>
        public const string TransactionHistoryDetailGrid = "~/Areas/IC/Views/TransactionHistoryInquiry/Partials/_TransactionHistoryInquiryDetailGrid.cshtml";

        #endregion

        #region Stock Transaction Inquiry

        /// <summary>
        /// Stock Transaction Inquiry partial view.
        /// </summary>
        public const string StockTransactionInquiry = "~/Areas/IC/Views/StockTransactionInquiry/Partials/_StockTransactionInquiry.cshtml";

        /// <summary>
        /// The Stock Transaction Inquiry localization
        /// </summary>
        public const string StockTransactionInquiryLocalization = "~/Areas/IC/Views/StockTransactionInquiry/Partials/_Localization.cshtml";

        /// <summary>
        /// The Stock Transaction Inquiry Grid
        /// </summary>
        public const string StockTransactionInquiryGrid = "~/Areas/IC/Views/StockTransactionInquiry/Partials/_StockTransactionInquiryGrid.cshtml";

        /// <summary>
        /// The Stock Transaction Inquiry Grid
        /// </summary>
        public const string StockTransactionInquiryDetailGrid = "~/Areas/IC/Views/StockTransactionInquiry/Partials/_StockTransactionInquiryDetailGrid.cshtml";

        /// <summary>
        /// The Stock Transaction Inquiry Detail
        /// </summary>
        public const string StockTransactionInquiryDetail = "~/Areas/IC/Views/StockTransactionInquiry/Partials/_StockTransactionInquiryDetail.cshtml";

        #endregion

        #region Transfer

        /// <summary>
        /// Transfer Header View
        /// </summary>
        public const string TransferHeader = "~/Areas/IC/Views/Transfer/Partials/_TransferHeader.cshtml";
        /// <summary>
        /// Transfer Details Grid View
        /// </summary>
        public const string TransferDetailGrid = "~/Areas/IC/Views/Transfer/Partials/_TransferDetailGrid.cshtml";

        /// <summary>
        /// The Transfer  OptionalFields popup Partial View
        /// </summary>
        public const string TransferOptionalField = "~/Areas/IC/Views/Transfer/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The Transfer Details  OptionalFields popup Partial View
        /// </summary>
        public const string TransferDetailOptionalField = "~/Areas/IC/Views/Transfer/Partials/_DetailOptionalFieldGrid.cshtml";

        /// <summary>
        ///Transfer Location Quantity View
        /// </summary>
        public const string TransferLocationQuantity = "~/Areas/IC/Views/Transfer/Partials/_LocationQuantity.cshtml";
        /// <summary>
        /// Transfer Localization
        /// </summary>
        public const string TransferLocalization = "~/Areas/IC/Views/Transfer/Partials/_Localization.cshtml";

        #endregion

        #region Update Item Pricing

        /// <summary>
        /// Update Item Pricing View
        /// </summary>
        public const string UpdateItemPricing = "~/Areas/IC/Views/UpdateItemPricing/Partials/_UpdateItemPricing.cshtml";

        /// <summary>
        /// Update Item Pricing Localization
        /// </summary>
        public const string UpdateItemPricingLocalization = "~/Areas/IC/Views/UpdateItemPricing/Partials/_Localization.cshtml";

        #endregion

        #region GenerateInventoryWorksheet
        /// <summary>
        /// Generate Inventory Worksheet Localization
        /// </summary>
        public const string GenerateInventoryWorksheetLocalization = "~/Areas/IC/Views/GenerateInventoryWorksheet/Partials/_Localization.cshtml";

        /// <summary>
        /// Generate Inventory Worksheet Partial View
        /// </summary>
        public const string GenerateInventoryWorksheet = "~/Areas/IC/Views/GenerateInventoryWorksheet/Partials/_GenerateInventoryWorksheet.cshtml";

        #endregion


        #region Slow Moving Items Report

        /// <summary>
        /// Slow Moving Items Report
        /// </summary>
        public const string SlowMovingItem = "~/Areas/IC/Views/SlowMovingItem/Partials/_SlowMovingItem.cshtml";

        /// <summary>
        /// Slow Moving Items Report Localization
        /// </summary>
        public const string SlowMovingItemLocalization = "~/Areas/IC/Views/SlowMovingItem/Partials/_Localization.cshtml";
        #endregion

        #region Item Status Report

        /// <summary>
        ///  Item Status Report
        /// </summary>
        public const string ItemStatus = "~/Areas/IC/Views/ItemStatus/Partials/_ItemStatus.cshtml";

        /// <summary>
        ///  Item Status Report Localization
        /// </summary>
        public const string ItemStatusLocalization = "~/Areas/IC/Views/ItemStatus/Partials/_Localization.cshtml";
        #endregion

        #region Transaction History Report

        /// <summary>
        /// TransactionHistory Report partial view.
        /// </summary>
        public const string TransactionHistoryReport = "~/Areas/IC/Views/TransactionHistory/Partials/_TransactionHistory.cshtml";

        /// <summary>
        /// TransactionHistory Report Localization partial view.
        /// </summary>
        public const string TransactionHistoryReportLocalization = "~/Areas/IC/Views/TransactionHistory/Partials/_Localization.cshtml";

        #endregion

        #region Item Valuation Report

        /// <summary>
        /// Reorder Item Valuation
        /// </summary>
        public const string ItemValuation = "~/Areas/IC/Views/ItemValuation/Partials/_ItemValuation.cshtml";

        /// <summary>
        /// Reorder Item Valuation Localization
        /// </summary>
        public const string ItemValuationLocalization = "~/Areas/IC/Views/ItemValuation/Partials/_Localization.cshtml";
        #endregion

        #region Overstock Items Report

        /// <summary>
        /// Reorder Item Valuation
        /// </summary>
        public const string OverstockedItems = "~/Areas/IC/Views/OverstockedItem/Partials/_OverstockedItem.cshtml";

        /// <summary>
        /// Reorder Item Valuation Localization
        /// </summary>
        public const string OverstockedItemsLocalization = "~/Areas/IC/Views/OverstockedItem/Partials/_Localization.cshtml";
        #endregion

        #region Stock Transaction Report

        /// <summary>
        /// Stock Transaction Report
        /// </summary>
        public const string StockTransaction = "~/Areas/IC/Views/StockTransaction/Partials/_StockTransaction.cshtml";

        /// <summary>
        /// Stock Transaction Report Localization
        /// </summary>
        public const string StockTransactionLocalization = "~/Areas/IC/Views/StockTransaction/Partials/_Localization.cshtml";
        #endregion

        #region Transfer Slip Report
        /// <summary>
        /// TransferSlip 
        /// </summary>
        public const string TransferSlip = "~/Areas/IC/Views/TransferSlip/Partials/_TransferSlip.cshtml";

        /// <summary>
        /// TransferSlip Localization
        /// </summary>
        public const string TransferSlipLocalization = "~/Areas/IC/Views/TransferSlip/Partials/_Localization.cshtml";
        #endregion

        #region Inventory Reconciliation Report

        /// <summary>
        /// InvtReconciliation Report
        /// </summary>
        public const string InvtReconciliation = "~/Areas/IC/Views/InvtReconciliation/Partials/_InvtReconciliation.cshtml";

        /// <summary>
        /// InvtReconciliation Report Localization
        /// </summary>
        public const string InvtReconciliationLocalization = "~/Areas/IC/Views/InvtReconciliation/Partials/_Localization.cshtml";

        #endregion

        #region Item Location Document

        /// <summary>
        /// Reorder Item Valuation
        /// </summary>
        public const string ItemLocationDocument = "~/Areas/IC/Views/ItemLocationDocument/Partials/_ItemLocationDocument.cshtml";
        /// <summary>
        /// Reorder Item Valuation
        /// </summary>
        public const string ItemLocationDocumentGrid = "~/Areas/IC/Views/ItemLocationDocument/Partials/__ItemLocationDocumentGrid.cshtml";

        /// <summary>
        /// Reorder Item Valuation Localization
        /// </summary>
        public const string ItemLocationDocumentLocalization = "~/Areas/IC/Views/ItemLocationDocument/Partials/_Localization.cshtml";

        /// <summary>
        /// Item Location Document Index
        /// </summary>
        public const string ItemLocationDocumentIndex = "~/Areas/IC/Views/ItemLocationDocument/Index.cshtml";
        #endregion

        #region  InventoryReconPosting
        /// <summary>
        /// The Inventory Inventory ReconPosting View
        /// </summary>
        public const string InventoryReconPosting = "~/Areas/IC/Views/InventoryReconPosting/Partials/_InventoryPosting.cshtml";

        /// <summary>
        /// The Inventory Inventory Recon Posting Localization
        /// </summary>
        public const string InventoryReconPostingLocalization = "~/Areas/IC/Views/InventoryReconPosting/Partials/_Localization.cshtml";

        #endregion

        #region Post Transaction

        /// <summary>
        /// Post Transaction
        /// </summary>
        public const string PostTransaction = "~/Areas/IC/Views/PostTransaction/Partials/_PostTransaction.cshtml";

        /// <summary>
        /// Post Transaction Localization
        /// </summary>
        public const string PostTransactionLocalization = "~/Areas/IC/Views/PostTransaction/Partials/_Localization.cshtml";

        #endregion

        #region Day End Processing

        /// <summary>
        /// Day End Processing
        /// </summary>
        public const string DayEndProcessing = "~/Areas/IC/Views/DayEndProcessing/Partials/_DayEndProcessing.cshtml";

        #endregion

        #region Location Details
        /// <summary>
        /// The Location Details
        /// </summary>
        public const string LocationDetail = "~/Areas/IC/Views/LocationDetail/Partials/_LocationDetail.cshtml";

        /// <summary>
        /// The Location Details localization
        /// </summary>
        public const string LocationDetailLocalization = "~/Areas/IC/Views/LocationDetail/Partials/_Localization.cshtml";

        /// <summary>
        /// The Location Details grid
        /// </summary>
        public const string LocationDetailGrid = "~/Areas/IC/Views/LocationDetail/Partials/_LocationDetailGrid.cshtml";

        #endregion
        #region Reorder Quantity

        /// <summary>
        /// Reorder Quantitie 
        /// </summary>
        public const string ReorderQuantity = "~/Areas/IC/Views/ReorderQuantity/Partials/_ReorderQuantity.cshtml";

        /// <summary>
        /// Reorder Quantitie Localization
        /// </summary>
        public const string ReorderQuantityLocalization = "~/Areas/IC/Views/ReorderQuantity/Partials/_Localization.cshtml";

        /// <summary>
        /// Reorder Quantity Details Grid
        /// </summary>
        public const string ReorderQuantityGrid = "~/Areas/IC/Views/ReorderQuantity/Partials/_ReorderQuantityGrid.cshtml";

        /// <summary>
        /// Reorder Quantity OptionalFields Popup
        /// </summary>
        public const string ReorderQuantityOptionalField = "~/Areas/IC/Views/ReorderQuantity/Partials/_OptionalFieldGrid.cshtml";


        #endregion

        #region Physical Inventory Quantity

        /// <summary>
        /// Physical Inventory Quantity
        /// </summary>
        public const string PhysicalInvQuantity = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_PhysicalInvQuantity.cshtml";

        /// <summary>
        /// Physical Inventory Quantity Localization
        /// </summary>
        public const string PhysicalInvQuantityLocalization = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_Localization.cshtml";

        /// <summary>
        /// Physical Inventory Quantity Grid
        /// </summary>
        public const string PhysicalInvQuantityGrid = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_PhysicalInvQuantityGrid.cshtml";

        /// <summary>
        /// Physical Inventory Quantity OptionalFields Popup
        /// </summary>
        public const string PhysicalInvQuantityOptionalField = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// Physical Inventory Quantity Detail OptionalFields Popup
        /// </summary>
        public const string PhysicalInvQuantityDetailOptionalField = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_DetailOptionalFieldGrid.cshtml";

        /// <summary>
        /// Physical Inventory Quantity Quantities Popup
        /// </summary>
        public const string PhysicalInvQuantityQuantity = "~/Areas/IC/Views/PhysicalInvQuantity/Partials/_Quantity.cshtml";

        #endregion

        #region InternalUsage

        /// <summary>
        /// The InternalUsage Partial View
        /// </summary>
        public const string InternalUsage = "~/Areas/IC/Views/InternalUsage/Partials/_InternalUsage.cshtml";

        /// <summary>
        /// The InternalUsage Detail Partial View
        /// </summary>
        public const string InternalUsageGrid = "~/Areas/IC/Views/InternalUsage/Partials/_InternalUsageGrid.cshtml";

        /// <summary>
        /// The InternalUsage Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string InternalUsageOptionalFields = "~/Areas/IC/Views/InternalUsage/Partials/_OptionalFieldGrid.cshtml";

        /// <summary>
        /// The InternalUsage Detail Grid OptionalFields popup Partial View
        /// </summary>
        public const string InternalUsageDetailOptionalFields = "~/Areas/IC/Views/InternalUsage/Partials/_DetailGridOptionalField.cshtml";

        /// <summary>
        /// The InternalUsage localization
        /// </summary>
        public const string InternalUsageLocalization = "~/Areas/IC/Views/InternalUsage/Partials/_Localization.cshtml";

        #endregion

        #region Serial Number Inquiry

        /// <summary>
        /// The Serial Number Inquiry View
        /// </summary>
        public const string SerialNumberInquiry = "~/Areas/IC/Views/SerialNumberInquiry/Partials/_SerialNumberInquiry.cshtml";

        /// <summary>
        /// The Serial Number Inquiry Grid
        /// </summary>
        public const string SerialNumberInquiryGrid = "~/Areas/IC/Views/SerialNumberInquiry/Partials/_SerialNumberInquiryGrid.cshtml";

        /// <summary>
        /// The Serial Number Inquiry Localization
        /// </summary>
        public const string SerialNumberInquiryLocalization = "~/Areas/IC/Views/SerialNumberInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Warranty Contract List Report

        /// <summary>
        /// WarrantyContract Report
        /// </summary>
        public const string WarrantyContractList = "~/Areas/IC/Views/WarrantyContractList/Partials/_WarrantyContractList.cshtml";

        /// <summary>
        /// WarrantyContractList Report Localization
        /// </summary>
        public const string WarrantyContractLocalization = "~/Areas/IC/Views/WarrantyContractList/Partials/_Localization.cshtml";

        #endregion

        #region I/C Periodic Processing - Process Adjustments

        /// <summary>
        /// Process Adjustments Localization
        /// </summary>
        public const string ProcessAdjustmentLocalization = "~/Areas/IC/Views/ProcessAdjustment/Partials/_Localization.cshtml";

        /// <summary>
        /// Process Adjustments report
        /// </summary>
        public const string ProcessAdjustment = "~/Areas/IC/Views/ProcessAdjustment/Partials/_ProcessAdjustment.cshtml";

        #endregion

        #region Quarantine

        /// <summary>
        /// Quarantine Localization Partial View
        /// </summary>
        public const string QuarantineLocalization = "~/Areas/IC/Views/Quarantine/Partials/_Localization.cshtml";

        /// <summary>
        /// Quarantine Partial View
        /// </summary>
        public const string Quarantine = "~/Areas/IC/Views/Quarantine/Partials/_Quarantine.cshtml";

        #endregion

        #region Item Wizard

        #region Wizard

        /// <summary>
        /// The item wizard localization
        /// </summary>
        public const string ItemWizardLocalization = "~/Areas/IC/Views/ItemWizard/Partials/_Localization.cshtml";

        /// <summary>
        /// The item wizard Header
        /// </summary>
        public const string ItemWizardHeader = "~/Areas/IC/Views/ItemWizard/Partials/_WizardHeader.cshtml";

        /// <summary>
        /// The item wizard
        /// </summary>
        public const string ItemWizard = "~/Areas/IC/Views/ItemWizard/Partials/_Wizard.cshtml";

        /// <summary>
        /// The item wizard welcome
        /// </summary>
        public const string ItemWizardWelcome = "~/Areas/IC/Views/ItemWizard/Partials/_Welcome.cshtml";

        /// <summary>
        /// The add itemlist information
        /// </summary>
        public const string ItemWizardAddItemSummary = "~/Areas/IC/Views/ItemWizard/Partials/_AddItemSummary.cshtml";

        /// <summary>
        /// The add item completed
        /// </summary>
        public const string ItemWizardAddItemCompleted = "~/Areas/IC/Views/ItemWizard/Partials/_AddItemCompleted.cshtml";

        #endregion

        #region Item


        /// <summary>
        /// The item wizard item localization
        /// </summary>
        public const string ItemWizardItemLocalization = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemLocalization.cshtml";

        /// <summary>
        /// The item basic
        /// </summary>
        public const string ItemWizardItem = "~/Areas/IC/Views/ItemWizard/Partials/Item/_Item.cshtml";

        /// <summary>
        /// The item basic
        /// </summary>
        public const string ItemWizardItemBasic = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemBasic.cshtml";

        /// <summary>
        /// The item unit
        /// </summary>
        public const string ItemWizardItemUnit = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemUnit.cshtml";

        /// <summary>
        /// The items taxes
        /// </summary>
        public const string ItemWizardItemTax = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemTax.cshtml";

        /// <summary>
        /// The items taxes
        /// </summary>
        public const string ItemWizardItemOptionalField = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemOptionalField.cshtml";

        /// <summary>
        /// The items taxes
        /// </summary>
        public const string ItemWizardTaxGrid = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemTaxGrid.cshtml";

        /// <summary>
        /// The items taxes
        /// </summary>
        public const string ItemWizardUnitGrid = "~/Areas/IC/Views/ItemWizard/Partials/Item/_ItemUnitGrid.cshtml";

        #endregion

        /// <summary>
        /// The serial number options
        /// </summary>
        public const string ItemWizardSerialNumberOptions = "~/Areas/IC/Views/ItemWizard/Partials/SerialNumber/_Welcome.cshtml";

        /// <summary>
        /// The lotnumber options
        /// </summary>
        public const string ItemWizardLotNumberOptions = "~/Areas/IC/Views/ItemWizard/Partials/LotNumber/_Welcome.cshtml";

        #region LocationDetails

        /// <summary>
        /// The item wizard location details
        /// </summary>
        public const string ItemWizardLocationDetails = "~/Areas/IC/Views/ItemWizard/Partials/LocationDetail/_LocationDetail.cshtml";

        #endregion

        #region Vendor Details

        /// <summary>
        /// The vendor details
        /// </summary>
        public const string ItemWizardVendorDetails = "~/Areas/IC/Views/ItemWizard/Partials/VendorDetail/_VendorDetail.cshtml";

        /// <summary>
        /// The vendor details
        /// </summary>
        public const string ItemWizardVendorDetailsGrid = "~/Areas/IC/Views/ItemWizard/Partials/VendorDetail/_VendorDetailGrid.cshtml";

        /// <summary>
        /// VendorDetail Localization
        /// </summary>
        public const string ItemWizardVendorDetailLocalization = "~/Areas/IC/Views/ItemWizard/Partials/VendorDetail/_Localization.cshtml";

        #endregion

        #region ItemPricing

        /// <summary>
        /// The item pricing
        /// </summary>
        public const string ItemWizardItemPricing = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricing/_ItemPricing.cshtml";

        /// <summary>
        /// The item wizard item pricing grid
        /// </summary>
        public const string ItemWizardItemPricingGrid = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricing/_ItemPricingGrid.cshtml";

        /// <summary>
        /// The item wizard item pricing localization
        /// </summary>
        public const string ItemWizardItemPricingLocalization = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricing/_Localization.cshtml";

        #endregion

        #region ManufacturersItem

        /// <summary>
        /// The manufacturers item
        /// </summary>
        public const string ItemWizardManufacturersItem = "~/Areas/IC/Views/ItemWizard/Partials/ManufacturersItem/_ManufacturersItem.cshtml";

        /// <summary>
        /// The item wizard manufacturers item grid
        /// </summary>
        public const string ItemWizardManufacturersItemGrid = "~/Areas/IC/Views/ItemWizard/Partials/ManufacturersItem/_ManufacturersItemGrid.cshtml";

        /// <summary>
        /// The item wizard manufacturers item localization
        /// </summary>
        public const string ItemWizardManufacturersItemLocalization = "~/Areas/IC/Views/ItemWizard/Partials/ManufacturersItem/_ManufacturersItemLocalization.cshtml";

        #endregion

        #region CustomerDetail
        /// <summary>
        /// The customer item number
        /// </summary>
        public const string ItemWizardCustomerDetail = "~/Areas/IC/Views/ItemWizard/Partials/CustomerDetail/_CustomerDetail.cshtml";

        /// <summary>
        /// VendorDetail Localization
        /// </summary>
        public const string ItemWizardCustomerDetailLocalization = "~/Areas/IC/Views/ItemWizard/Partials/CustomerDetail/_Localization.cshtml";

        /// <summary>
        /// VendorDetail Partial View For Grid implementation
        /// </summary>
        public const string ItemWizardCustomerDetailGrid = "~/Areas/IC/Views/ItemWizard/Partials/CustomerDetail/_CustomerDetailGrid.cshtml";

        #endregion

        #region KittingItem


        /// <summary>
        /// The item wizard kitting item localization
        /// </summary>
        public const string ItemWizardKittingItemLocalization = "~/Areas/IC/Views/ItemWizard/Partials/KittingItem/_Localization.cshtml";


        /// <summary>
        /// The item wizard kitting item components localization
        /// </summary>
        public const string ItemWizardKittingItemComponentLocalization = "~/Areas/IC/Views/ItemWizard/Partials/KittingItemComponent/_Localization.cshtml";

        /// <summary>
        /// The item wizard kitting item grid
        /// </summary>
        public const string ItemWizardKittingItemGrid = "~/Areas/IC/Views/ItemWizard/Partials/KittingItem/_KittingItemGrid.cshtml";

        /// <summary>
        /// The item wizard kitting item components
        /// </summary>
        public const string ItemWizardKittingItemComponent = "~/Areas/IC/Views/ItemWizard/Partials/KittingItemComponent/_KittingItemComponent.cshtml";

        /// <summary>
        /// The item wizard kitting item components grid
        /// </summary>
        public const string ItemWizardKittingItemComponentGrid = "~/Areas/IC/Views/ItemWizard/Partials/KittingItemComponent/_KittingItemComponentGrid.cshtml";

        /// <summary>
        /// The session kitting item component
        /// </summary>
        public const string SessionKittingItemComponent = "icKittingItemComponentCache";

        #endregion
        
        /// <summary>
        /// The bill of materials
        /// </summary>
        public const string ItemWizardBillOfMaterials = "~/Areas/IC/Views/ItemWizard/Partials/BillOfMaterials/_Welcome.cshtml";

        /// <summary>
        /// The kitting items
        /// </summary>
        public const string ItemWizardKittingItems = "~/Areas/IC/Views/ItemWizard/Partials/KittingItem/_KittingItem.cshtml";

        /// <summary>
        /// The reorder quantities
        /// </summary>
        public const string ItemWizardReorderQuantities = "~/Areas/IC/Views/ItemWizard/Partials/ReorderQuantity/_ReorderQuantity.cshtml";


        #region Item Pricing Detail

        /// <summary>
        /// Item Prices tab
        /// </summary>
        public const string ItemWizardItemPriceDetail = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_ItemPricingDetail.cshtml";

        /// <summary>
        /// Item Prices tab
        /// </summary>
        public const string ItemWizardItemPrice = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_Price.cshtml";

        /// <summary>
        /// Item Discounts tab
        /// </summary>
        public const string ItemWizardItemDiscount = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_Discount.cshtml";

        /// <summary>
        /// Item PriceCheck tab
        /// </summary>
        public const string ItemWizardItemPriceCheck = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_PriceCheck.cshtml";

        /// <summary>
        /// Item PriceCheck Grid
        /// </summary>
        public const string ItemWizardItemPriceCheckGrid = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_PriceCheckGrid.cshtml";

        /// <summary>
        /// Item Tax tab
        /// </summary>
        public const string ItemWizardItemTaxes = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_Tax.cshtml";

        /// <summary>
        /// Item Tax Grid
        /// </summary>
        public const string ItemWizardItemTaxesGrid = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_TaxGrid.cshtml";

        /// <summary>
        /// Base Price Units Of Measure
        /// </summary>
        public const string ItemWizardBasePriceUnitsOfMeasure = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_BasePriceUnitsOfMeasure.cshtml";

        /// <summary>
        /// Base Price Units Of Measure Grid
        /// </summary>
        public const string ItemWizardBasePriceUnitsOfMeasureGrid = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_BasePriceUnitsOfMeasureGrid.cshtml";

        /// <summary>
        /// Sale Price Units Of Measure
        /// </summary>
        public const string ItemWizardSalePriceUnitsOfMeasure = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_SalePriceUnitsOfMeasure.cshtml";

        /// <summary>
        /// Sale Price Units Of Measure Grid
        /// </summary>
        public const string ItemWizardSalePriceUnitsOfMeasureGrid = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_SalePriceUnitsOfMeasureGrid.cshtml";

        /// <summary>
        /// Item Pricing Detail Popup Screen
        /// </summary>
        public const string ItemWizardItemPricingDetailPopupScreen = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_ItemPricingPopupScreens.cshtml";

        /// <summary>
        /// Default Price Header
        /// </summary>
        public const string ItemWizardDefaultPriceHeader = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_DefaultPriceHeader.cshtml";

        /// <summary>
        /// Default Base Price
        /// </summary>
        public const string ItemWizardDefaultBasePrice = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_DefaultBasePrice.cshtml";

        /// <summary>
        /// Default Sale Price
        /// </summary>
        public const string ItemWizardDefaultSalePrice = "~/Areas/IC/Views/ItemWizard/Partials/ItemPricingDetail/_DefaultSalePrice.cshtml";

        #endregion

        #region Contract Pricing

        /// <summary>
        /// The item wizard contract pricing localization
        /// </summary>
        public const string ItemWizardContractPricingLocalization = "~/Areas/IC/Views/ItemWizard/Partials/ContractPricing/_Localization.cshtml";

        /// <summary>
        /// The item wizard contract pricing grid
        /// </summary>
        public const string ItemWizardContractPricingGrid = "~/Areas/IC/Views/ItemWizard/Partials/ContractPricing/_ContractPricingGrid.cshtml";

        /// <summary>
        /// The item contract pricing
        /// </summary>
        public const string ItemWizardItemContractPricing = "~/Areas/IC/Views/ItemWizard/Partials/ContractPricing/_ContractPricing.cshtml";

        #endregion

        #endregion

        #region CurrentTransactionsInquiry

        /// <summary>
        /// The options account
        /// </summary>
        public const string CurrentTransactionsInquiryLocalization = "~/Areas/IC/Views/CurrentTransactionsInquiry/Partials/_Localization.cshtml";

        /// <summary>
        /// Current Transactions Inquiry Partial View
        /// </summary>
        public const string CurrentTransactionsInquiry = "~/Areas/IC/Views/CurrentTransactionsInquiry/Partials/_CurrentTransactionsInquiry.cshtml";
        /// <summary>
        /// Current Transactions Inquiry Grid Partial View
        /// </summary>
        public const string CurrentTransactionsPurchaseOrderGrid = "~/Areas/IC/Views/CurrentTransactionsInquiry/Partials/_CurrentTransactionsPurchaseOrderGrid.cshtml";
        /// <summary>
        /// Current Transactions Inquiry Grid Partial View
        /// </summary>
        public const string CurrentTransactionsSalesOrderGrid = "~/Areas/IC/Views/CurrentTransactionsInquiry/Partials/_CurrentTransactionsSalesOrderGrid.cshtml";

        #endregion

        #region DeleteInactiveRecord

        /// <summary>
        /// The Delete Inactive Record View Path
        /// </summary>
        public const string DeleteInactiveRecord = "~/Areas/IC/Views/DeleteInactiveRecord/Partials/_DeleteInactiveRecord.cshtml";

        /// <summary>
        /// The Inventory Delete Inactive Record Localization
        /// </summary>
        public const string DeleteInactiveRecordLocalization = "~/Areas/IC/Views/DeleteInactiveRecord/Partials/_Localization.cshtml";

        #endregion

        #region Serial Number Transaction Inquiry

        /// <summary>
        /// The Serial Number Transaction Inquiry View
        /// </summary>
        public const string SerialNumberTransactionInquiry = "~/Areas/IC/Views/SerialNumberTransactionInquiry/Partials/_SerialNumberTransactionInquiry.cshtml";

        /// <summary>
        /// The Serial Number Inquiry Transaction Grid
        /// </summary>
        public const string SerialNumberTransactionInquiryGrid = "~/Areas/IC/Views/SerialNumberTransactionInquiry/Partials/_SerialNumberTransactionInquiryGrid.cshtml";

        /// <summary>
        /// The Serial Number Inquiry Transaction Localization
        /// </summary>
        public const string SerialNumberTransactionInquiryLocalization = "~/Areas/IC/Views/SerialNumberTransactionInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Serial Lot List Report

        /// <summary>
        /// SerialLotList Report
        /// </summary>
        public const string SerialLotList = "~/Areas/IC/Views/SerialLotList/Partials/_SerialLotList.cshtml";

        /// <summary>
        /// SerialLotList Report Localization
        /// </summary>
        public const string SerialLotListLocalization = "~/Areas/IC/Views/SerialLotList/Partials/_Localization.cshtml";

        #endregion

        #region Serial Lot Transaction Report
        /// <summary>
        /// The SerialLotTransaction Localization
        /// </summary>
        public const string SerialLotTransactionLocalization = "~/Areas/IC/Views/SerialLotTransaction/Partials/_Localization.cshtml";

        /// <summary>
        ///  The SerialLotTransaction view
        /// </summary>
        public const string SerialLotTransaction = "~/Areas/IC/Views/SerialLotTransaction/Partials/_SerialLotTransaction.cshtml";
        #endregion


        #region Customer Detail Report

        /// <summary>
        /// CustomerDetail Report
        /// </summary>
        public const string CustomerDetailReport = "~/Areas/IC/Views/CustomerDetailReport/Partials/_CustomerDetailReport.cshtml";

        /// <summary>
        /// CustomerDetail Report Localization
        /// </summary>
        public const string CustomerDetailReportLocalization = "~/Areas/IC/Views/CustomerDetailReport/Partials/_Localization.cshtml";

        /// <summary>
        /// LotRecallRelease Localization
        /// </summary>
        public const string LotRecallReleaseLocalization = "~/Areas/IC/Views/LotRecallRelease/Partials/_Localization.cshtml";

        /// <summary>
        /// LotRecallRelease view
        /// </summary>
        public const string LotRecallRelease = "~/Areas/IC/Views/LotRecallRelease/Partials/_LotRecallRelease.cshtml";

        /// <summary>
        /// LotRecallRelease grid view
        /// </summary>
        public const string LotRecallReleaseGrid = "~/Areas/IC/Views/LotRecallRelease/Partials/_LotRecallReleaseGrid.cshtml";

        #endregion

        #region Lot Number Transaction Inquiry

        /// <summary>
        /// The Lot Number Transaction Inquiry View
        /// </summary>
        public const string LotNumberTransactionInquiry = "~/Areas/IC/Views/LotNumberTransactionInquiry/Partials/_LotNumberTransactionInquiry.cshtml";

        /// <summary>
        /// The Lot Number Inquiry Transaction Grid
        /// </summary>
        public const string LotNumberTransactionInquiryGrid = "~/Areas/IC/Views/LotNumberTransactionInquiry/Partials/_LotNumberTransactionInquiryGrid.cshtml";

        /// <summary>
        /// The Lot Number Inquiry Transaction Localization
        /// </summary>
        public const string LotNumberTransactionInquiryLocalization = "~/Areas/IC/Views/LotNumberTransactionInquiry/Partials/_Localization.cshtml";

        #endregion

        #region CopyBillsOfMaterial

        /// <summary>
        /// Copy Bills Of Material
        /// </summary>
        public const string CopyBillsOfMaterial = "~/Areas/IC/Views/CopyBillsOfMaterial/Partials/_CopyBillsOfMaterial.cshtml";

        /// <summary>
        /// Copy Bills Of Material Grid
        /// </summary>
        public const string CopyBillsOfMaterialGrid = "~/Areas/IC/Views/CopyBillsOfMaterial/Partials/_CopyBillsOfMaterialGrid.cshtml";

        /// <summary>
        /// Copy Bills Of Material Localization
        /// </summary>
        public const string CopyBillsOfMaterialLocalization = "~/Areas/IC/Views/CopyBillsOfMaterial/Partials/_Localization.cshtml";


        #endregion


        #region Bills Of Material

        /// <summary>
        /// Bills Of Material
        /// </summary>
        public const string BillOfMaterial = "~/Areas/IC/Views/BOM/Partials/_BOM.cshtml";

        /// <summary>
        /// Bills Of Material Grid
        /// </summary>
        public const string BOMGrid = "~/Areas/IC/Views/BOM/Partials/_BOMGrid.cshtml";

        /// <summary>
        /// Bills Of Material Localization
        /// </summary>
        public const string BOMLocalization = "~/Areas/IC/Views/BOM/Partials/_Localization.cshtml";


        #endregion

		
	    #region Account Set Report

        /// <summary>
        /// Account Sets Report
        /// </summary>
        public const string AccountSetReport = "~/Areas/IC/Views/AccountSetReport/Partials/_AccountSetReport.cshtml";

        /// <summary>
        /// Account Set Report Localization
        /// </summary>
        public const string AccountSetReportLocalization = "~/Areas/IC/Views/AccountSetReport/Partials/_Localization.cshtml";

        #endregion

        #region Location Report

        /// <summary>
        /// Account Sets Report
        /// </summary>
        public const string LocationReport = "~/Areas/IC/Views/LocationReport/Partials/_LocationReport.cshtml";

        /// <summary>
        /// Account Set Report Localization
        /// </summary>
        public const string LocationReportLocalization = "~/Areas/IC/Views/LocationReport/Partials/_Localization.cshtml";

        #endregion

        #region Price List Code Report

        /// <summary>
        /// Account Sets Report
        /// </summary>
        public const string PriceListCodeReport = "~/Areas/IC/Views/PriceListCodeReport/Partials/_PriceListCodeReport.cshtml";

        /// <summary>
        /// Account Set Report Localization
        /// </summary>
        public const string PriceListCodeReportLocalization = "~/Areas/IC/Views/PriceListCodeReport/Partials/_Localization.cshtml";

        #endregion

        #region Category Report

        /// <summary>
        /// Account Sets Report
        /// </summary>
        public const string CategoryReport = "~/Areas/IC/Views/CategoryReport/Partials/_CategoryReport.cshtml";

        /// <summary>
        /// Account Set Report Localization
        /// </summary>
        public const string CategoryReportLocalization = "~/Areas/IC/Views/CategoryReport/Partials/_Localization.cshtml";

        #endregion

        #region Kitting Item Report

        /// <summary>
        /// Account Sets Report
        /// </summary>
        public const string KittingItemReport = "~/Areas/IC/Views/KittingItemReport/Partials/_KittingItemReport.cshtml";

        /// <summary>
        /// Account Set Report Localization
        /// </summary>
        public const string KittingItemReportLocalization = "~/Areas/IC/Views/KittingItemReport/Partials/_Localization.cshtml";


        #endregion

        #region Vendor Detail Report

        /// <summary>
        /// VendorDetail Report
        /// </summary>
        public const string VendorDetailReport = "~/Areas/IC/Views/VendorDetailReport/Partials/_VendorDetailReport.cshtml";

        /// <summary>
        /// VendorDetail Report Localization
        /// </summary>
        public const string VendorDetailReportLocalization = "~/Areas/IC/Views/VendorDetailReport/Partials/_Localization.cshtml";

        #endregion

        #region Clear History

        /// <summary>
        /// Clear History
        /// </summary>
        public const string ClearHistory = "~/Areas/IC/Views/ClearHistory/Partials/_ClearHistory.cshtml";

        /// <summary>
        /// Clear History Localization
        /// </summary>
        public const string ClearHistoryLocalization = "~/Areas/IC/Views/ClearHistory/Partials/_Localization.cshtml";

        #endregion

        #region Reorder Quantities Report
        /// <summary>
        /// Reorder Report
        /// </summary>
        public const string ReorderQuantityReport = "~/Areas/IC/Views/ReorderQuantityReport/Partials/_ReorderQuantityReport.cshtml";

        /// <summary>
        /// Reorder Report Localization
        /// </summary>
        public const string ReorderQuantityReportLocalization = "~/Areas/IC/Views/ReorderQuantityReport/Partials/_Localization.cshtml";
        #endregion
		
		 #region Bill Of Material Report

        /// <summary>
        /// PriceList Report
        /// </summary>
        public const string BillsOfMaterialReport = "~/Areas/IC/Views/BillsOfMaterialReport/Partials/_BillsOfMaterialReport.cshtml";

        /// <summary>
        /// PriceList Report Localization
        /// </summary>
        public const string BillsOfMaterialReportLocalization = "~/Areas/IC/Views/BillsOfMaterialReport/Partials/_Localization.cshtml";

        #endregion


        #region  Quarantine Release Report

        /// <summary>
        /// The Quarantine release View
        /// </summary>
        public const string QuarantineRelease = "~/Areas/IC/Views/QuarantineRelease/Partials/_QuarantineRelease.cshtml";

        /// <summary>
        /// The Quarantine Release Localization
        /// </summary>
        public const string QuarantineReleaseLocalization = "~/Areas/IC/Views/QuarantineRelease/Partials/_Localization.cshtml";

        #endregion
		        #region Copy Item Pricing

        /// <summary>
        /// Copy Item Pricing View
        /// </summary>
        public const string CopyItemPricing = "~/Areas/IC/Views/CopyItemPricing/Partials/_CopyItemPricing.cshtml";

        /// <summary>
        /// Copy Item Pricing Localization
        /// </summary>
        public const string CopyItemPricingLocalization = "~/Areas/IC/Views/CopyItemPricing/Partials/_Localization.cshtml";

        #endregion


        #region Assembly

        /// <summary>
        /// 
        /// </summary>
        public const string Assembly = "~/Areas/IC/Views/Assembly/Partials/_Assembly.cshtml";

        /// <summary>
        /// 
        /// </summary>
        public const string AssemblyLocalization = "~/Areas/IC/Views/Assembly/Partials/_Localization.cshtml";

        #endregion


        #region Lot Numbers
        /// <summary>
        /// Inventory Lot Number
        /// </summary>
        public const string InventoryLotNumber = "~/Areas/IC/Views/InventoryLotNumber/Partials/_InventoryLotNumber.cshtml";

        /// <summary>
        /// Localization
        /// </summary>
        public const string InventoryLotNumberLocalization = "~/Areas/IC/Views/InventoryLotNumber/Partials/_Localization.cshtml";

        /// <summary>
        /// Optional Fields
        /// </summary>
        public const string InventoryLotNumberOptionalField = "~/Areas/IC/Views/InventoryLotNumber/Partials/_InventoryLotNumberOptionalField.cshtml";
        
        #endregion Lot Numbers

        #region SerialLotQoh Report

        /// <summary>
        /// SerialLotQoh
        /// </summary>
        public const string SerialLotQoh = "~/Areas/IC/Views/SerialLotQoh/Partials/_SerialLotQoh.cshtml";

        /// <summary>
        /// SerialLotQoh Report Localization
        /// </summary>
        public const string SerialLotQohLocalization = "~/Areas/IC/Views/SerialLotQoh/Partials/_Localization.cshtml";

        #endregion

        #region Contract Price

        /// <summary>
        /// Contract Price Localization View
        /// </summary>
        public const string ContractPriceLocalization = "~/Areas/IC/Views/ContractPricing/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract Price Partial View
        /// </summary>
        public const string ContractPrice = "~/Areas/IC/Views/ContractPricing/Partials/_ContractPrice.cshtml";

        #endregion
		
        #region Contract Code

        /// <summary>
        /// Contract CodeLocalization Partial View
        /// </summary>
        public const string ContractCodeLocalization = "~/Areas/IC/Views/ContractCode/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract CodePartial View
        /// </summary>
        public const string ContractCode = "~/Areas/IC/Views/ContractCode/Partials/_ContractCode.cshtml";

        #endregion

        #region WarrantyCode

        /// <summary>
        /// Contract CodeLocalization Partial View
        /// </summary>
        public const string WarrantyCodeLocalization = "~/Areas/IC/Views/WarrantyCode/Partials/_Localization.cshtml";

        /// <summary>
        /// Contract CodePartial View
        /// </summary>
        public const string WarrantyCode = "~/Areas/IC/Views/WarrantyCode/Partials/_WarrantyCode.cshtml";

        #endregion
        
        #region Serial Registration

        /// <summary>
        /// SerialRegistration 
        /// </summary>
        public const string SerialRegistration = "~/Areas/IC/Views/SerialRegistration/Partials/_SerialRegistration.cshtml";

        /// <summary>
        /// SerialRegistration Localization
        /// </summary>
        public const string SerialRegistrationLocalization = "~/Areas/IC/Views/SerialRegistration/Partials/_Localization.cshtml";

        #endregion

        #region Serial Lot Reconciliation

        /// <summary>
        /// The Serial Lot Reconciliation View
        /// </summary>
        public const string SerialLotReconciliation = "~/Areas/IC/Views/SerialLotReconciliation/Partials/_SerialLotReconciliation.cshtml";

        /// <summary>
        /// The Serial Lot Reconciliation Localization
        /// </summary>
        public const string SerialLotReconciliationLocalization = "~/Areas/IC/Views/SerialLotReconciliation/Partials/_Localization.cshtml";

        /// <summary>
        /// The Serial Lot Reconciliation Serials tab
        /// </summary>
        public const string SerialTab = "~/Areas/IC/Views/SerialLotReconciliation/Partials/_Serial.cshtml";

        /// <summary>
        /// The Serial Lot Reconciliation Lots tab
        /// </summary>
        public const string LotTab = "~/Areas/IC/Views/SerialLotReconciliation/Partials/_Lot.cshtml";

        #endregion
		
		#region Lot Number Inquiry

        /// <summary>
        /// The Lot Number  Inquiry View
        /// </summary>
        public const string LotNumberInquiry = "~/Areas/IC/Views/LotNumberInquiry/Partials/_LotNumberInquiry.cshtml";

        /// <summary>
        /// The Lot Number Inquiry Grid
        /// </summary>
        public const string LotNumberInquiryGrid = "~/Areas/IC/Views/LotNumberInquiry/Partials/_LotNumberInquiryGrid.cshtml";

        /// <summary>
        /// The Lot Number Inquiry Localization
        /// </summary>
        public const string LotNumberInquiryLocalization = "~/Areas/IC/Views/LotNumberInquiry/Partials/_Localization.cshtml";

        #endregion

        #region Update Bills Of Material
        /// <summary>
        /// Localization
        /// </summary>
        public const string UpdateBillsOfMaterialLocalization = "~/Areas/IC/Views/UpdateBillsOfMaterial/Partials/_Localization.cshtml";
        #endregion
		
		#region Bill Of Material Component Usage Inquiry

        /// <summary>
        /// The Bill Of Material Component Usage Inquiry View
        /// </summary>
        public const string BomComponentUsageInquiry = "~/Areas/IC/Views/BOMComponentUsageInquiry/Partials/_BOMComponentUsageInquiry.cshtml";

        /// <summary>
        /// The Bill Of Material Component Usage Inquiry Grid
        /// </summary>
        public const string BomComponentUsageInquiryGrid = "~/Areas/IC/Views/BOMComponentUsageInquiry/Partials/_BOMComponentUsageInquiryGrid.cshtml";

        /// <summary>
        /// The Bill Of Material Component Usage Inquiry Localization
        /// </summary>
        public const string BomComponentUsageInquiryLocalization = "~/Areas/IC/Views/BOMComponentUsageInquiry/Partials/_Localization.cshtml";

        #endregion

    }
}
