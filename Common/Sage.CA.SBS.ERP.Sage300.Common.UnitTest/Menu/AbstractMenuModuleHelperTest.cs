using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Menu
{
    /// <summary>
    /// Use for test AbstractMenuModuleHelper
    /// </summary>
    public class TestMenuModuleHelper : AbstractMenuModuleHelper
    {
        /// <summary>
        /// Return Module specified
        /// </summary>
        public override string Module
        {
            get { return "GL"; }
        }

        /// <summary>
        /// Return Name of the screen file
        /// </summary>
        public override string MenuDetailFileName
        {
            get { return "test.xml"; }
        }

        /// <summary>
        /// Initialize the module manager
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="context">Context</param>
        public override void Initialize(string company, Context context)
        {
            PrepareDataFile(string.Empty);
        }

        /// <summary>
        /// Return Menu Items with activation filter applied
        /// </summary>
        /// <returns>List</returns>
        public override List<NavigableMenu> GetFilteredMenuItems()
        {
            var criteriaList = new List<Func<NavigableMenu, bool>>();
            criteriaList.Add(x => x.MenuId != "2");
            return GetApplyFilteredMenuItems(criteriaList);
        }

        /// <summary>
        /// Helper function to return menuItem
        /// </summary>
        /// <returns></returns>
        public List<NavigableMenu> GetMenuItemsWithOutFilter()
        {
            return GetApplyFilteredMenuItems(null);
        }
    }


    /// <summary>
    /// Unit testing for AbstractMenuModuleHelper
    /// </summary>
    [TestClass]
    public class AbstractMenuModuleHelperTest
    {
        #region navigableMenuXmlString
        private string navigableMenuXmlString = @"
<Navigation>
  <item>
    <MenuID>104</MenuID>
    <MenuName>Accounts Payable</MenuName>
    <ResourceKey>Module_AccountsPayable</ResourceKey>
    <ParentMenuID>101</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>2</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <!--Third Level Menu Items Section Starts For Accounts Payable-->
  <item>
    <MenuID>113</MenuID>
    <MenuName>A/P Vendors</MenuName>
    <ResourceKey>AP_Vendors</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <item>
    <MenuID>115</MenuID>
    <MenuName>A/P Vendor Reports</MenuName>
    <ResourceKey>AP_VendorReports</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>true</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <item>
    <MenuID>125</MenuID>
    <MenuName>A/P Periodic Processing</MenuName>
    <ResourceKey>AP_PeriodicProcessing</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>true</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <item>
    <MenuID>126</MenuID>
    <MenuName>A/P Transactions</MenuName>
    <ResourceKey>AP_Transactions</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <item>
    <MenuID>127</MenuID>
    <MenuName>A/P Transaction Reports</MenuName>
    <ResourceKey>AP_TransactionReports</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>true</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <item>
    <MenuID>129</MenuID>
    <MenuName>A/P Setup</MenuName>
    <ResourceKey>AP_Setup</ResourceKey>
    <ParentMenuID>104</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>3</MenuItemLevel>
    <MenuItemOrder>6</MenuItemOrder>
    <ColOrder>-1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>true</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
  </item>
  <!--Third Level Menu Items Section End For Accounts Payable-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - A/P Periodic Processing-->
  <item>
    <MenuID>148</MenuID>
    <MenuName>A/P Periodic Processing</MenuName>
    <ResourceKey>AP_PeriodicProcessing</ResourceKey>
    <ParentMenuID>125</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>149</MenuID>
    <MenuName>1099 Electronic Filing</MenuName>
    <ResourceKey>AP_Vendors_1099ElectronicFiling</ResourceKey>
    <ParentMenuID>125</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/ElectronicFilingReport</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST-APHISTI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>152</MenuID>
    <MenuName>Create G/L Batch</MenuName>
    <ResourceKey>Common_CreateGLBatch</ResourceKey>
    <ParentMenuID>125</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CreateGLBatch</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPERIOD</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>150</MenuID>
    <MenuName>T5018(CPRS) Electronic Filing</MenuName>
    <ResourceKey>AP_PeriodicProcessing_T5028CPRSElectronicFiling</ResourceKey>
    <ParentMenuID>125</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CPRSElectronicFiling</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST-APHISTI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>158</MenuID>
    <MenuName>Year End</MenuName>
    <ResourceKey>Common_YearEnd</ResourceKey>
    <ParentMenuID>125</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/ProcessYearEnd</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>6</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APYEAR</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section End For Accounts Payable - A/P Periodic Processing-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - A/P Setup-->
  <item>
    <MenuID>187</MenuID>
    <MenuName>A/P Setup</MenuName>
    <ResourceKey>AP_Setup</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>188</MenuID>
    <MenuName>1099 / CPRS Codes</MenuName>
    <ResourceKey>AP_Setup_1099CPRSCodes</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CPRSCode</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>189</MenuID>
    <MenuName>Account Sets</MenuName>
    <ResourceKey>Common_Setup_AccountSets</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/AccountSet</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>190</MenuID>
    <MenuName>Distribution Codes</MenuName>
    <ResourceKey>Common_Setup_DistributionCodes</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/DistributionCode</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>191</MenuID>
    <MenuName>Distribution Sets</MenuName>
    <ResourceKey>AP_Setup_DistributionSets</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/DistributionSet</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>192</MenuID>
    <MenuName>E-mail Messages</MenuName>
    <ResourceKey>Common_Setup_EmailMessages</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/EmailMessage</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>6</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>193</MenuID>
    <MenuName>G/L Integration</MenuName>
    <ResourceKey>Common_Setup_GLIntegration</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/GLIntegration</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>7</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>195</MenuID>
    <MenuName>Optional Fields</MenuName>
    <ResourceKey>Common_OptionalFields</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/OptionalField</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>8</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>194</MenuID>
    <MenuName>Options</MenuName>
    <ResourceKey>Common_Setup_Options</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/Options</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>9</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>700</MenuID>
    <MenuName>Payment Codes</MenuName>
    <ResourceKey>Common_Setup_PaymentCodes</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PaymentCode</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>10</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>196</MenuID>
    <MenuName>Payment Selection Codes</MenuName>
    <ResourceKey>AP_Setup_PaymentSelectionCodes</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PaymentSelectionCode</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>11</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPAYMI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>197</MenuID>
    <MenuName>Terms</MenuName>
    <ResourceKey>Common_Setup_Terms</ResourceKey>
    <ParentMenuID>129</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/TermCode</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>12</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section End For Accounts Payable - A/P Setup-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - Transactions-->
  <item>
    <MenuID>162</MenuID>
    <MenuName>A/P Transactions</MenuName>
    <ResourceKey>AP_Transactions</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>165</MenuID>
    <MenuName>Control Payments</MenuName>
    <ResourceKey>AP_Transactions_ControlPayments</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/ControlPayment</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCONTROL</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>900</MenuID>
    <MenuName>Create Payment Batch</MenuName>
    <ResourceKey>AP_Transactions_CreatePaymentBatch</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CreatePaymentBatch</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPAYME</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>166</MenuID>
    <MenuName>Invoice Batch List</MenuName>
    <ResourceKey>Common_Transactions_InvoiceBatchList</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/InvoiceBatchList</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APINVOICEI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>167</MenuID>
    <MenuName>Invoice Entry</MenuName>
    <ResourceKey>Common_Transactions_InvoiceEntry</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/InvoiceEntry</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APINVOICEI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>169</MenuID>
    <MenuName>Payment Batch List</MenuName>
    <ResourceKey>AP_Transactions_PaymentBatchList</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PaymentBatchList</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>6</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPAYMI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>168</MenuID>
    <MenuName>Payment Entry</MenuName>
    <ResourceKey>AP_Transactions_PaymentEntry</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PaymentEntry</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>7</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPAYMI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>170</MenuID>
    <MenuName>Post Batches</MenuName>
    <ResourceKey>Common_Transactions_PostBatches</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PostBatch</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>8</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APADJUST-APINVOICE-APPAYM</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>1200</MenuID>
    <MenuName>Inquiry</MenuName>
    <ResourceKey>Common_Inquiry</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>11</MenuItemOrder>
    <ColOrder>2</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>173</MenuID>
    <MenuName>Payment Inquiry</MenuName>
    <ResourceKey>AP_Transactions_PaymentInquiry</ResourceKey>
    <ParentMenuID>126</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PaymentInquiry</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>12</MenuItemOrder>
    <ColOrder>2</ColOrder>
    <SecurityResourceKey>APPAYMI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section Start For Accounts Payable - Transactions-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - Transaction Reports-->
  <item>
    <MenuID>174</MenuID>
    <MenuName>A/P Transaction Reports</MenuName>
    <ResourceKey>AP_TransactionReports</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>175</MenuID>
    <MenuName>Aged Cash Requirements</MenuName>
    <ResourceKey>AP_TransReports_AgedCashRequirements</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/AgedCashRequirement</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>176</MenuID>
    <MenuName>Aged Payables</MenuName>
    <ResourceKey>AP_TransReports_AgedPayables</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/AgedPayable</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>177</MenuID>
    <MenuName>Aged Retainage</MenuName>
    <ResourceKey>AR_TransReports_AgedRetainage</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/AgedRetainage</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>178</MenuID>
    <MenuName>Batch Listing</MenuName>
    <ResourceKey>Common_BatchListing</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/BatchListing</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APINVOICEI-APPAYMI-APADJUSTI</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>180</MenuID>
    <MenuName>Check Register</MenuName>
    <ResourceKey>AP_TransReports_CheckRegister</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CheckRegister</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>6</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APPAYMI</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>181</MenuID>
    <MenuName>G/L Transactions</MenuName>
    <ResourceKey>GL_Transactions</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/GLTransaction</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>7</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APINVOICEI-APPAYMI-APADJUSTI-APPERIOD</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>182</MenuID>
    <MenuName>Posting Errors</MenuName>
    <ResourceKey>Common_TransactionReports_PostingErrors</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PostingError</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>8</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APINVOICEI-APPAYMI-APADJUSTI</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>184</MenuID>
    <MenuName>Vendor Transactions</MenuName>
    <ResourceKey>AP_TransactionReports_VendorTransactions</ResourceKey>
    <ParentMenuID>127</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/VendorTransaction</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>9</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section End For Accounts Payable - Transaction Reports-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - A/P Vendors-->
  <item>
    <MenuID>131</MenuID>
    <MenuName>A/P Vendors</MenuName>
    <ResourceKey>AP_Vendors</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>135</MenuID>
    <MenuName>Vendor Activity</MenuName>
    <ResourceKey>AP_Vendors_VendorActivity</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/VendorActivity</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHISTI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>136</MenuID>
    <MenuName>Vendor Groups</MenuName>
    <ResourceKey>AP_VendorGroups</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/VendorGroup</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>134</MenuID>
    <MenuName>Vendors</MenuName>
    <ResourceKey>AP_Vendors_Vendors</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/Vendor</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>137</MenuID>
    <MenuName>Inquiry</MenuName>
    <ResourceKey>Common_Inquiry</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>9</MenuItemOrder>
    <ColOrder>2</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>138</MenuID>
    <MenuName>1099 / CPRS Inquiry</MenuName>
    <ResourceKey>AP_Vendors_1099CPRSInquiry</ResourceKey>
    <ParentMenuID>113</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/CPRSInquiry</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>10</MenuItemOrder>
    <ColOrder>2</ColOrder>
    <SecurityResourceKey>APHISTI-APVENDOR</SecurityResourceKey>
    <IsReport>false</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section End For Accounts Payable - A/P Vendors-->
  <!--Fourth Level Menu Items Section Start For Accounts Payable - A/P Vendor Reports-->
  <item>
    <MenuID>139</MenuID>
    <MenuName>A/P Vendor Reports</MenuName>
    <ResourceKey>AP_VendorReports</ResourceKey>
    <ParentMenuID>115</ParentMenuID>
    <IsGroupHeader>true</IsGroupHeader>
    <ScreenURL>N/A</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>1</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>N/A</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>140</MenuID>
    <MenuName>Letters / Labels</MenuName>
    <ResourceKey>AP_VendorReports_LettersLabels</ResourceKey>
    <ParentMenuID>115</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/LetterAndLabel</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>2</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHIST</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>141</MenuID>
    <MenuName>Print 1099/1096 Forms</MenuName>
    <ResourceKey>AP_VendorReports_Print10991096Form</ResourceKey>
    <ParentMenuID>115</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/Print10991096Form</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>3</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHISTI-APVENDOR</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>142</MenuID>
    <MenuName>Print T5018 (CPRS) Forms</MenuName>
    <ResourceKey>AP_VendorReports_PrintT5018CPRSForm</ResourceKey>
    <ParentMenuID>115</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/PrintT5018CprsReport</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>4</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APHISTI-APVENDOR</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <item>
    <MenuID>144</MenuID>
    <MenuName>Vendors</MenuName>
    <ResourceKey>AP_Vendors_Vendors</ResourceKey>
    <ParentMenuID>115</ParentMenuID>
    <IsGroupHeader>false</IsGroupHeader>
    <ScreenURL>AP/VendorReport</ScreenURL>
    <MenuItemLevel>4</MenuItemLevel>
    <MenuItemOrder>5</MenuItemOrder>
    <ColOrder>1</ColOrder>
    <SecurityResourceKey>APCOMUI</SecurityResourceKey>
    <IsReport>true</IsReport>
    <IsActive>true</IsActive>
    <IsGroupEnd>false</IsGroupEnd>
    <IsWidget>false</IsWidget>
    <Isintelligence>false</Isintelligence>
    <ModuleName>AP</ModuleName>
  </item>
  <!--Fourth Level Menu Items Section End For Accounts Payable - A/P Vendor Reports-->
</Navigation>

        ";
        #endregion
        
        /// <summary>
        /// Util function to return Context
        /// </summary>
        /// <returns>Context</returns>
        private Context CreateContext()
        {
            var context = new Context
            {
                Container = new SageUnityContainer()
            };

            return context;
        }

        /// <summary>
        /// Get list of Navigable menus test data
        /// </summary>
        /// <returns></returns>
        private List<NavigableMenu> GetNavigableMenus()
        {
            var result = new List<NavigableMenu> {
                new NavigableMenu {MenuId="1"},
                new NavigableMenu {MenuId="2"},
                new NavigableMenu {MenuId="3"},
                new NavigableMenu {MenuId="4"}
            };

            return result;
        }

        /// <summary>
        /// Unit test GetApplyFilteredMenuItems
        /// </summary>
        [TestMethod]
        public void GetApplyFilteredMenuItemsTest()
        {
            var abstractMenuModuleHelper = new TestMenuModuleHelper();
            var context = CreateContext();
            context.Company = "Test";

            using (ShimsContext.Create())
            {
                ShimAbstractMenuModuleHelper.AllInstances.GetMenuDetailsStringBoolean = (a, b, c) => GetNavigableMenus();
                ShimAbstractMenuModuleHelper.AllInstances.HandleCreateDestinationFileString = (a, b) => string.Empty;

                abstractMenuModuleHelper.Initialize("testCompany", context);

                // use GetFilteredMenuItems to drive to test protected function ApplyFilteredMenuItemsTest
                var result = abstractMenuModuleHelper.GetFilteredMenuItems();

                Assert.IsNotNull(result);
                Assert.AreEqual(result.Count, 3);
                Assert.IsFalse(result.Any(x => x.MenuId == "2"));
            }
        }

        /// <summary>
        /// Unit testing for function GetMenuDetails
        /// </summary>
        [TestMethod]
        public void GetMenuDetailsTest()
        {
            var abstractMenuModuleHelper = new TestMenuModuleHelper();
            var context = CreateContext();
            context.Company = "Test";

            using (ShimsContext.Create())
            {
                ShimAbstractMenuModuleHelper.AllInstances.HandleCreateDestinationFileString = (a, b) => string.Empty;
                ShimAbstractMenuModuleHelper.AllInstances.ReadMenuXmlFileString = (a, b) => XDocument.Parse(navigableMenuXmlString);

                // use Initialize to drive PrepareDataFile and to drive GetMenuDetails test
                abstractMenuModuleHelper.Initialize(context.Company, context);

                // indirectly get the menuItem by calling
                var result = abstractMenuModuleHelper.GetMenuItemsWithOutFilter();

                Assert.IsNotNull(result);
                Assert.AreEqual(result.Count, 54);
            }
        }
    }
}
