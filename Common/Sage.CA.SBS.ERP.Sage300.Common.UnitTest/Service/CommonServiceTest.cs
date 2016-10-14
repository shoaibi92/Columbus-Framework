//using System;
//using System.Collections.Generic;
//using Sage.CA.SBS.ERP.Sage300.Common.Models;
//using Sage.CA.SBS.ERP.Sage300.Common.Services;
//using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Service
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [TestClass]
//    public class CommonServiceTest : BaseRepositoryTestFixture
//    {
//       /// <summary>
//        /// 
//        /// </summary>
//        /// 
//        /// 
//        private readonly Context _expectedContext = new Context
//        {
  
//           Company = "aa",
//           TenantName = "111",
//           TenantId = new Guid("95247f5e-ad53-41a6-9262-8efa5568b28b"),
//        };

//        /// <summary>
//        /// Test method Get Currency
//        /// </summary>
//        [TestMethod]
//        public void TestGetCurrency()
//        {
//          var context = CommonServiceData.MockGetCurrencyCode();
//          var testTargetService = new CommonService(context);
//          var currency = testTargetService.GetCurrency("111");
//          Assert.AreEqual("Test",currency.Code);
//        }

//         /// <summary>
//         /// Test Method for Getcompanies
//         /// </summary>
//         /// <returns></returns>
//         [TestMethod]
//         public void TestGetCompanies()
//         {

//             var context = CommonServiceData.MockGetCompany(_expectedContext);
//             var testCompanies = new CommonService(context);
//             var company = testCompanies.GetCompanies(_expectedContext);
//             Assert.AreEqual(1, company.Count); 
//         }


//      /// <summary>
//     /// Test Method for CheckLicense
//      /// </summary>
//         [TestMethod]
//         public void TestCheckLicense()
//         {
//            var context = CommonServiceData.MockCheckLicense();
//            var testLicense = new CommonService(context);
//            var license = testLicense.CheckLicense("11", "11");
//            Assert.IsTrue(license); 
//         }

//        /// <summary>
//         /// Test Method for SaveUserPreference
//        /// </summary>
//         [TestMethod]
//         public void TestSaveUserPreference()
//         {
//             var context = CommonServiceData.MockSaveUserPreference();
//             var testPreference = new CommonService(context);
//             var userPreference = testPreference.SaveUserPreference("AA", "AA");
//             Assert.IsTrue(userPreference); 
//         }

//         /// <summary>
//         /// Test Method for DeleteUserPreference
//         /// </summary>
//          [TestMethod]
//         public void TestDeleteUserPreference()
//         {
//             var context = CommonServiceData.MockDeleteUserPreference();
//             var testPreference = new CommonService(context);
//             var userPreference = testPreference.DeleteUserPreference("AA");
//             Assert.IsTrue(userPreference);
//         }



//          /// <summary>
//          /// Test Method for GetUserPreference
//          /// </summary>
//          [TestMethod]
//          public void TestGetUserPreference()
//          {
//              var context = CommonServiceData.MockGetUserPreference();
//              var testTargetService = new CommonService(context);
//              var user = testTargetService.GetUserPreference("User");
//              Assert.IsTrue(user.Equals("User"));
//          }

//          /// <summary>
//          /// Test Method for GetFiscalCalendar
//          /// </summary>
//          [TestMethod]
//          public void TestGetFiscalCalendar()
//          {
//              var context = CommonServiceData.MockGetFiscalCalendar();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.GetFiscalCalendar();
//              Assert.AreEqual(data.FirstYear,null);
//          }

//          /// <summary>
//          /// Test Method for GetInstalledReportForActiveApplication
//          /// </summary>
//          [TestMethod]
//          public void TestGetInstalledReportForActiveApplication()
//          {
//              var context = CommonServiceData.MockGetInstalledReportForActiveApplication();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.GetInstalledReportForActiveApplication("1");
//              Assert.AreEqual(data.Count, 0);
//          }



//          /// <summary>
//          /// Test Method for GetInstalledReportForActiveApplications
//          /// </summary>
//          [TestMethod]
//          public void TestGetInstalledReportForActiveApplications()
//          {
//              var context = CommonServiceData.MockGetInstalledReportForActiveApplications();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.GetInstalledReportForActiveApplication("1","1");
//              Assert.AreEqual(data.Count, 0);
//          }

//          /// <summary>
//          /// Test Method for HasAccess
//          /// </summary>
//          [TestMethod]
//          public void TestHasAccess()
//          {
//              var context = CommonServiceData.MockHasAccess();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.HasAccess("1");
//              Assert.IsTrue(data);
//          }

//          /// <summary>
//          /// Test Method for LockResource
//          /// </summary>
//          [TestMethod]
//          public void TestLockResource()
//          {
//              var context = CommonServiceData.MockLockRsc();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.LockResource("1",true);
//              Assert.AreNotEqual(data,"Success");
//          }

//        /// <summary>
//         /// Test Method forUnLockResource
//        /// </summary>
//        /// <param name="resource"></param>
//          [TestMethod]
//          public void TestUnLockResource(string resource)
//          {
//              var context = CommonServiceData.MockUnLockRsc();
//              var testTargetService = new CommonService(context);
//              var data = testTargetService.UnLockResource("1");
//              Assert.AreNotEqual(data, "NotLocked");
//          }
      
//    }
//}
