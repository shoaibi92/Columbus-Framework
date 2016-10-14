using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry
{
    /// <summary>
    /// Base Invoice Detail Fields and Index Class
    /// </summary>
    public partial class BaseInvoiceDetail
    {
        /// <summary>
        /// BaseInvoiceDetail Fields Class
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
            /// Property for LineNumber 
            /// </summary>
            public const string LineNumber = "CNTLINE";

            /// <summary>
            /// Property for Destination 
            /// </summary>
            public const string Destination = "DESCOMP";

            /// <summary>
            /// Property for RouteNo 
            /// </summary>
            public const string RouteNo = "ROUTE";

            /// <summary>
            /// Property for DistributionCode 
            /// </summary>
            public const string DistributionCode = "IDDIST";

            /// <summary>
            /// Property for DistributionDescription 
            /// </summary>
            public const string DistributionDescription = "TEXTDESC";

            /// <summary>
            /// Property for TaxTotal 
            /// </summary>
            public const string TaxTotal = "AMTTOTTAX";

            /// <summary>
            /// Property for ManualTaxEntry 
            /// </summary>
            public const string ManualTaxEntry = "SWMANLTX";

            /// <summary>
            /// Property for BaseTax1 
            /// </summary>
            public const string BaseTax1 = "BASETAX1";

            /// <summary>
            /// Property for BaseTax2 
            /// </summary>
            public const string BaseTax2 = "BASETAX2";

            /// <summary>
            /// Property for BaseTax3 
            /// </summary>
            public const string BaseTax3 = "BASETAX3";

            /// <summary>
            /// Property for BaseTax4 
            /// </summary>
            public const string BaseTax4 = "BASETAX4";

            /// <summary>
            /// Property for BaseTax5 
            /// </summary>
            public const string BaseTax5 = "BASETAX5";

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
            /// Property for TaxRate1 
            /// </summary>
            public const string TaxRate1 = "RATETAX1";

            /// <summary>
            /// Property for TaxRate2 
            /// </summary>
            public const string TaxRate2 = "RATETAX2";

            /// <summary>
            /// Property for TaxRate3 
            /// </summary>
            public const string TaxRate3 = "RATETAX3";

            /// <summary>
            /// Property for TaxRate4 
            /// </summary>
            public const string TaxRate4 = "RATETAX4";

            /// <summary>
            /// Property for TaxRate5 
            /// </summary>
            public const string TaxRate5 = "RATETAX5";

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
            /// Property for GOrLAccount 
            /// </summary>
            public const string GLAccount = "IDGLACCT";

            /// <summary>
            /// Property for RetainageAllocatedTaxAccount 
            /// </summary>
            public const string RetainageAllocatedTaxAccount = "IDACCTTAX";

            /// <summary>
            /// Property for DistributedAmount 
            /// </summary>
            public const string DistributedAmount = "AMTDIST";

            /// <summary>
            /// Property for Comment 
            /// </summary>
            public const string Comment = "COMMENT";

            /// <summary>
            /// Property for DistributedAmountBeforeTaxes 
            /// </summary>
            public const string DistributedAmountBeforeTaxes = "AMTDISTNET";

            /// <summary>
            /// Property for TaxAmountIncludedinPrice 
            /// </summary>
            public const string TaxAmountIncludedinPrice = "AMTINCLTAX";

            /// <summary>
            /// Property for GOrLDistributedAmount 
            /// </summary>
            public const string GLDistributedAmount = "AMTGLDIST";

            /// <summary>
            /// Property for RecoverableTaxAmount1 
            /// </summary>
            public const string RecoverableTaxAmount1 = "AMTTAXREC1";

            /// <summary>
            /// Property for RecoverableTaxAmount2 
            /// </summary>
            public const string RecoverableTaxAmount2 = "AMTTAXREC2";

            /// <summary>
            /// Property for RecoverableTaxAmount3 
            /// </summary>
            public const string RecoverableTaxAmount3 = "AMTTAXREC3";

            /// <summary>
            /// Property for RecoverableTaxAmount4 
            /// </summary>
            public const string RecoverableTaxAmount4 = "AMTTAXREC4";

            /// <summary>
            /// Property for RecoverableTaxAmount5 
            /// </summary>
            public const string RecoverableTaxAmount5 = "AMTTAXREC5";

            /// <summary>
            /// Property for ExpenseSepTaxAmount1 
            /// </summary>
            public const string ExpenseSepTaxAmount1 = "AMTTAXEXP1";

            /// <summary>
            /// Property for ExpenseSepTaxAmount2 
            /// </summary>
            public const string ExpenseSepTaxAmount2 = "AMTTAXEXP2";

            /// <summary>
            /// Property for ExpenseSepTaxAmount3 
            /// </summary>
            public const string ExpenseSepTaxAmount3 = "AMTTAXEXP3";

            /// <summary>
            /// Property for ExpenseSepTaxAmount4 
            /// </summary>
            public const string ExpenseSepTaxAmount4 = "AMTTAXEXP4";

            /// <summary>
            /// Property for ExpenseSepTaxAmount5 
            /// </summary>
            public const string ExpenseSepTaxAmount5 = "AMTTAXEXP5";

            /// <summary>
            /// Property for TaxAllocatedTotal 
            /// </summary>
            public const string TaxAllocatedTotal = "AMTTAXTOBE";

            /// <summary>
            /// Property for ContractCode 
            /// </summary>
            public const string ContractCode = "CONTRACT";

            /// <summary>
            /// Property for ProjectCode 
            /// </summary>
            public const string ProjectCode = "PROJECT";

            /// <summary>
            /// Property for CategoryCode 
            /// </summary>
            public const string CategoryCode = "CATEGORY";

            /// <summary>
            /// Property for ProjectOrCategoryResource 
            /// </summary>
            public const string ProjectOrCategoryResource = "RESOURCE";

            /// <summary>
            /// Property for TransactionNumber 
            /// </summary>
            public const string TransactionNumber = "TRANSNBR";

            /// <summary>
            /// Property for CostClass 
            /// </summary>
            public const string CostClass = "COSTCLASS";

            /// <summary>
            /// Property for BillingType 
            /// </summary>
            public const string BillingType = "BILLTYPE";

            /// <summary>
            /// Property for ItemNumber 
            /// </summary>
            public const string ItemNumber = "IDITEM";

            /// <summary>
            /// Property for UnitofMeasure 
            /// </summary>
            public const string UnitofMeasure = "UNITMEAS";

            /// <summary>
            /// Property for Quantity 
            /// </summary>
            public const string Quantity = "QTYINVC";

            /// <summary>
            /// Property for Cost 
            /// </summary>
            public const string Cost = "AMTCOST";

            /// <summary>
            /// Property for BillingDate 
            /// </summary>
            public const string BillingDate = "BILLDATE";

            /// <summary>
            /// Property for BillingRate 
            /// </summary>
            public const string BillingRate = "BILLRATE";

            /// <summary>
            /// Property for BillingCurrency 
            /// </summary>
            public const string BillingCurrency = "BILLCURN";

            /// <summary>
            /// Property for CommentAttached 
            /// </summary>
            public const string CommentAttached = "SWIBT";

            /// <summary>
            /// Property for Discountable 
            /// </summary>
            public const string Discountable = "SWDISCABL";

            /// <summary>
            /// Property for OriginalLineIdentifier 
            /// </summary>
            public const string OriginalLineIdentifier = "OCNTLINE";

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
            /// Property for RetainageDueDateOverride 
            /// </summary>
            public const string RetainageDueDateOverride = "SWRTGDDTOV";

            /// <summary>
            /// Property for RetainageAmountOverride 
            /// </summary>
            public const string RetainageAmountOverride = "SWRTGAMTOV";

            /// <summary>
            /// Property for OptionalFields 
            /// </summary>
            public const string OptionalFields = "VALUES";

            /// <summary>
            /// Property for ProcessCommandCode 
            /// </summary>
            public const string ProcessCommandCode = "PROCESSCMD";

            /// <summary>
            /// Property for DestExists 
            /// </summary>
            public const string DestExists = "DESEXIST";

            /// <summary>
            /// Property for DestDescription 
            /// </summary>
            public const string DestDescription = "DESNAME";

            /// <summary>
            /// Property for DestStatus 
            /// </summary>
            public const string DestStatus = "DESSTAT";

            /// <summary>
            /// Property for DistCodeExists 
            /// </summary>
            public const string DistCodeExists = "DCODEEXIST";

            /// <summary>
            /// Property for DistCodeDescription 
            /// </summary>
            public const string DistCodeDescription = "DCODEDESC";

            /// <summary>
            /// Property for DistCodeStatus 
            /// </summary>
            public const string DistCodeStatus = "DCODESTAT";

            /// <summary>
            /// Property for RouteExists 
            /// </summary>
            public const string RouteExists = "ROUTEXIST";

            /// <summary>
            /// Property for RouteDescription 
            /// </summary>
            public const string RouteDescription = "ROUTNAME";

            /// <summary>
            /// Property for RouteStatus 
            /// </summary>
            public const string RouteStatus = "ROUTSTAT";

            /// <summary>
            /// Property for AcctExists 
            /// </summary>
            public const string AcctExists = "ACTEXIST";

            /// <summary>
            /// Property for AcctDescription 
            /// </summary>
            public const string AcctDescription = "ACTDESC";

            /// <summary>
            /// Property for AcctStatus 
            /// </summary>
            public const string AcctStatus = "ACTSTAT";

            /// <summary>
            /// Property for RetainageDistributionAmount 
            /// </summary>
            public const string RetainageDistributionAmount = "RTGDISTTC";

            /// <summary>
            /// Property for InvoicedRetainageDistribution 
            /// </summary>
            public const string InvoicedRetainageDistribution = "RTGINVDIST";

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
            /// Property for TaxReportingAllocatedTax 
            /// </summary>
            public const string TaxReportingAllocatedTax = "TXALLRC";

            /// <summary>
            /// Property for TaxReportingExpensedTax1 
            /// </summary>
            public const string TaxReportingExpensedTax1 = "TXEXP1RC";

            /// <summary>
            /// Property for TaxReportingExpensedTax2 
            /// </summary>
            public const string TaxReportingExpensedTax2 = "TXEXP2RC";

            /// <summary>
            /// Property for TaxReportingExpensedTax3 
            /// </summary>
            public const string TaxReportingExpensedTax3 = "TXEXP3RC";

            /// <summary>
            /// Property for TaxReportingExpensedTax4 
            /// </summary>
            public const string TaxReportingExpensedTax4 = "TXEXP4RC";

            /// <summary>
            /// Property for TaxReportingExpensedTax5 
            /// </summary>
            public const string TaxReportingExpensedTax5 = "TXEXP5RC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax1 
            /// </summary>
            public const string TaxReportingRecoverableTax1 = "TXREC1RC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax2 
            /// </summary>
            public const string TaxReportingRecoverableTax2 = "TXREC2RC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax3 
            /// </summary>
            public const string TaxReportingRecoverableTax3 = "TXREC3RC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax4 
            /// </summary>
            public const string TaxReportingRecoverableTax4 = "TXREC4RC";

            /// <summary>
            /// Property for TaxReportingRecoverableTax5 
            /// </summary>
            public const string TaxReportingRecoverableTax5 = "TXREC5RC";

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
            /// Property for FuncRetainageTaxAmount1 
            /// </summary>
            public const string FuncRetainageTaxAmount1 = "TXAMTRT1HC";

            /// <summary>
            /// Property for FuncRetainageTaxAmount2 
            /// </summary>
            public const string FuncRetainageTaxAmount2 = "TXAMTRT2HC";

            /// <summary>
            /// Property for FuncRetainageTaxAmount3 
            /// </summary>
            public const string FuncRetainageTaxAmount3 = "TXAMTRT3HC";

            /// <summary>
            /// Property for FuncRetainageTaxAmount4 
            /// </summary>
            public const string FuncRetainageTaxAmount4 = "TXAMTRT4HC";

            /// <summary>
            /// Property for FuncRetainageTaxAmount5 
            /// </summary>
            public const string FuncRetainageTaxAmount5 = "TXAMTRT5HC";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount1 
            /// </summary>
            public const string FuncTaxRecoverableAmount1 = "TXREC1HC";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount2 
            /// </summary>
            public const string FuncTaxRecoverableAmount2 = "TXREC2HC";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount3 
            /// </summary>
            public const string FuncTaxRecoverableAmount3 = "TXREC3HC";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount4 
            /// </summary>
            public const string FuncTaxRecoverableAmount4 = "TXREC4HC";

            /// <summary>
            /// Property for FuncTaxRecoverableAmount5 
            /// </summary>
            public const string FuncTaxRecoverableAmount5 = "TXREC5HC";

            /// <summary>
            /// Property for FuncTaxExpenseSepAmount1 
            /// </summary>
            public const string FuncTaxExpenseSepAmount1 = "TXEXP1HC";

            /// <summary>
            /// Property for FuncTaxExpenseSepAmount2 
            /// </summary>
            public const string FuncTaxExpenseSepAmount2 = "TXEXP2HC";

            /// <summary>
            /// Property for FuncTaxExpenseSepAmount3 
            /// </summary>
            public const string FuncTaxExpenseSepAmount3 = "TXEXP3HC";

            /// <summary>
            /// Property for FuncTaxExpenseSepAmount4 
            /// </summary>
            public const string FuncTaxExpenseSepAmount4 = "TXEXP4HC";

            /// <summary>
            /// Property for FuncTaxExpenseSepAmount5 
            /// </summary>
            public const string FuncTaxExpenseSepAmount5 = "TXEXP5HC";

            /// <summary>
            /// Property for FuncTaxAllocatedTotal 
            /// </summary>
            public const string FuncTaxAllocatedTotal = "TXALLHC";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount1 
            /// </summary>
            public const string FuncTaxAllocatedAmount1 = "TXALL1HC";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount2 
            /// </summary>
            public const string FuncTaxAllocatedAmount2 = "TXALL2HC";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount3 
            /// </summary>
            public const string FuncTaxAllocatedAmount3 = "TXALL3HC";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount4 
            /// </summary>
            public const string FuncTaxAllocatedAmount4 = "TXALL4HC";

            /// <summary>
            /// Property for FuncTaxAllocatedAmount5 
            /// </summary>
            public const string FuncTaxAllocatedAmount5 = "TXALL5HC";

            /// <summary>
            /// Property for TaxAllocatedAmount1 
            /// </summary>
            public const string TaxAllocatedAmount1 = "TXALL1TC";

            /// <summary>
            /// Property for TaxAllocatedAmount2 
            /// </summary>
            public const string TaxAllocatedAmount2 = "TXALL2TC";

            /// <summary>
            /// Property for TaxAllocatedAmount3 
            /// </summary>
            public const string TaxAllocatedAmount3 = "TXALL3TC";

            /// <summary>
            /// Property for TaxAllocatedAmount4 
            /// </summary>
            public const string TaxAllocatedAmount4 = "TXALL4TC";

            /// <summary>
            /// Property for TaxAllocatedAmount5 
            /// </summary>
            public const string TaxAllocatedAmount5 = "TXALL5TC";

            /// <summary>
            /// Property for FuncCost 
            /// </summary>
            public const string FuncCost = "AMTCOSTHC";

            /// <summary>
            /// Property for FuncDistributedAmount 
            /// </summary>
            public const string FuncDistributedAmount = "AMTDISTHC";

            /// <summary>
            /// Property for FuncDistributionNetofTaxes 
            /// </summary>
            public const string FuncDistributionNetofTaxes = "DISTNETHC";

            /// <summary>
            /// Property for FuncRetainageAmount 
            /// </summary>
            public const string FuncRetainageAmount = "RTGAMTHC";

            /// <summary>
            /// Property for FuncRetainageTaxAllocated 
            /// </summary>
            public const string FuncRetainageTaxAllocated = "TXALLRTHC";

            /// <summary>
            /// Property for RetainageTaxAllocated 
            /// </summary>
            public const string RetainageTaxAllocated = "TXALLRTTC";

            /// <summary>
            /// Property for FuncRetainageTaxExpensed 
            /// </summary>
            public const string FuncRetainageTaxExpensed = "TXEXPRTHC";

            /// <summary>
            /// Property for RetainageTaxExpensed 
            /// </summary>
            public const string RetainageTaxExpensed = "TXEXPRTTC";

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
            /// Property for CurrRetainageAmount 
            /// </summary>
            public const string CurrRetainageAmount = "RTGAMTOTC";

            /// <summary>
            /// Property for CurrRetainageDistAmount 
            /// </summary>
            public const string CurrRetainageDistAmount = "RTGDISTOTC";

            /// <summary>
            /// Property for FixedAsset 
            /// </summary>
            public const string FixedAsset = "SWFAS";

            /// <summary>
            /// Property for SageFixedAssetsOrgid 
            /// </summary>
            public const string SageFixedAssetsOrgid = "FAORGID";

            /// <summary>
            /// Property for SageFixedAssetsDatabase 
            /// </summary>
            public const string SageFixedAssetsDatabase = "FADATABASE";

            /// <summary>
            /// Property for SageFixedAssetsCompanyOrOrg 
            /// </summary>
            public const string SageFixedAssetsCompanyOrOrg = "FACOMPANY";

            /// <summary>
            /// Property for SageFixedAssetsTemplate 
            /// </summary>
            public const string SageFixedAssetsTemplate = "FATEMPLATE";

            /// <summary>
            /// Property for SageFixedAssetsAssetDescript 
            /// </summary>
            public const string SageFixedAssetsAssetDescript = "FADESC";
              
            /// <summary>
            /// Property for SageFixedAssetsAssetDescript 
            /// </summary>
            public const string SageFixedAssetsAssetDescription = "FADESC";

            /// <summary>
            /// Property for SeparateAssets 
            /// </summary>
            public const string SeparateAssets = "FASWSEPQTY";

            /// <summary>
            /// Property for SageFixedAssetsQuantity 
            /// </summary>
            public const string SageFixedAssetsQuantity = "FAQTY";

            /// <summary>
            /// Property for SageFixedAssetsUnitofMeasur 
            /// </summary>
            public const string SageFixedAssetsUnitofMeasure = "FAUOM";

            /// <summary>
            /// Property for SageFixedAssetsAssetValue 
            /// </summary>
            public const string SageFixedAssetsAssetValue = "FAAMTTC";

            /// <summary>
            /// Property for SageFixedAssetsFuncAssetVa 
            /// </summary>
            public const string SageFixedAssetsFuncAssetVa = "FAAMTHC";

            #endregion
        }

        /// <summary>
        /// BaseInvoiceDetail Index Class
        /// </summary>
        public partial class BaseIndex
        {
            
        }
    }
}
