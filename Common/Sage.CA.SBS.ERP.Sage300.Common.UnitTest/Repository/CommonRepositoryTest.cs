//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity;
//using ACCPAC.Advantage;

//namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Repository
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [TestClass]
//    public class CommonRepositoryTest : BaseRepositoryTestFixture
//    {
//        private static BusinessRepository.Base.CommonRepository _repository;
//        private readonly Sage.CA.SBS.ERP.Sage300.Common.Models.Context _context;

//        /// <summary>
//        /// CommonRepositoryTest
//        /// </summary>
//        public CommonRepositoryTest()
//        {
//            _repository = GetRepository();
//            _context = CreateContext();
//            Register();
//        }

//        /// <summary>
//        ///  Unit Test for GetCurrency.
//        /// </summary>
//        [TestMethod]
//        public void CommonGetCurrency()
//        {
            
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.GetCurrency("CAD");
//            Assert.AreEqual("CAD", getVal.Code);
//        }

//        /// <summary>
//        /// Unit Test for CheckLicense.
//        /// </summary>
//        [TestMethod]
//        public void CommonCheckLicense()
//        {
          

//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.CheckLicense("GS","");
//            Assert.IsFalse(getVal);
//        }

//        /// <summary>
//        /// Unit Test for SaveUserPreference
//        /// </summary>
//        [TestMethod]
//        public void CommonSaveUserPreference()
//        {
            
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.SaveUserPreference("1", "User");
//            Assert.IsTrue(getVal);
            
//        }

//        /// <summary>
//        /// Unit Test for FiscalCalender
//        /// </summary>
//        [TestMethod]
//        public void CommonFiscalCalender()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.GetFiscalCalendar();
//            Assert.AreEqual("2020", getVal.LastYear.Year);
//        }

//       /// <summary>
//        /// Unit Test for DeleteUserPreference
//       /// </summary>
//        [TestMethod]
//        public void CommonDeleteUserPreference()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.DeleteUserPreference("aaa");
//            Assert.IsTrue(getVal);

//        }

//        /// <summary>
//        /// Unit Test for GetUserPreference
//        /// </summary>
//        [TestMethod]
//        public void CommonGetUserPreference()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            //Quotes are appended to value we should look in to it
//            var getVal = repositoryData.GetUserPreference("1");
//            Assert.AreNotEqual(getVal, "User");
//        }

//        /// <summary>
//        /// Unit Test for GetCompanies
//        /// </summary>
//        [TestMethod]
//        public void CommonGetCompanies()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.GetCompanies(_context);
//            Assert.AreNotEqual(getVal.Count, 0);
//        }

//        /// <summary>
//        /// Unit Test for GetInstalledReportForActiveApplication
//        /// </summary>
//        [TestMethod]
//        public void CommonGetInstalledReportForActiveApplication()
//        {
//             var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//             var getVal = repositoryData.GetInstalledReportForActiveApplication("1");
//             Assert.AreEqual(getVal.Count, 0);
//        }


//        /// <summary>
//        /// Unit Test for GetInstalledReportForActiveApplications
//        /// </summary>
//        [TestMethod]
//        public void CommonGetInstalledReportForActiveApplications()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.GetInstalledReportForActiveApplication("1","11");
//            Assert.AreEqual(getVal.Count, 0);
//        }

//        /// <summary>
//        /// Unit Test for HasAccess
//        /// </summary>
//        [TestMethod]
//        public void CommonHasAccess()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.HasAccess("1");
//            Assert.IsTrue(getVal);
//        }

//        /// <summary>
//        /// Unit Test for LockRsc
//        /// </summary>
//        [TestMethod]
//        public void CommonLockRsc()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.LockRsc("1",true);
//            Assert.AreNotEqual(getVal,"Success");
//        }
//        /// <summary>
//        /// Unit Test for LockRsc
//        /// </summary>
//        [TestMethod]
//        public void CommonUnLockRsc()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.UnLockRsc("1");
//            Assert.AreNotEqual(getVal, "NotLocked");
//        }

//        /// <summary>
//        /// Unit Test for LockRsc
//        /// </summary>
//        [TestMethod]
//        public void UnLockRsc()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            var getVal = repositoryData.UnLockRsc("1");
//            Assert.AreNotEqual(getVal, "NotLocked");
//        }


//        /// <summary>
//        /// Unit Test for LockRsc
//        /// </summary>
//        [TestMethod]
//        public void CommonUnlockApplication()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            repositoryData.UnlockApplication("1"); 
//        }

//         /// <summary>
//        /// Unit Test for UnLockRsc
//        /// </summary>
//        [TestMethod]
//        public void CommonUnlockOrg()
//        {
//            var repositoryData = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            repositoryData.UnlockOrg(); 
//        }
         
//        private BusinessRepository.Base.CommonRepository GetRepository()
//        {
//            if (_repository != null)
//            {
//                return _repository;
//            }
//            _repository = new BusinessRepository.Base.CommonRepository(_context, DBLinkType.Company);
//            return _repository;
//        }

//    }
//}
