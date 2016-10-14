//using System.Threading;
//using Microsoft.Practices.Unity;
//using Moq;
//using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
//using Sage.CA.SBS.ERP.Sage300.Common.Models;
//using System.Collections.Generic;
//using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
//using Sage.CA.SBS.ERP.Sage300.Common.Services;

//namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Service.Mock
//{
//    /// <summary>
//    /// CommonServiceRepository
//    /// </summary>
//    public class CommonServiceRepository 
//    {
//        #region Private Members

//        /// <summary>
//        /// Context Object
//        /// </summary>
//        private readonly Context _context;

//          #region Constructor

//        /// <summary>
//        /// Construct to set the Context
//        /// </summary>
//        /// <param name="context">context</param>
//        public CommonServiceRepository(Context context)
//        {
//            _context = context;
//        }

//        #endregion

       
//        /// <summary>
//        /// Get the  Mock for CurrencyCode
//        /// </summary>
//        /// <returns>Account Set codes</returns>
//        public Context MockGetCurrencyCode()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetCurrency(It.IsAny<string>())).Returns(new Currency(){Code = "Test"});
//            return _context;
//        }


//        /// <summary>
//        /// Get the  Mock for GetCompany
//        /// </summary>
//        /// <returns>Account Set codes</returns>
//        public Context MockGetCompany(Context  contexts)
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetCompanies(contexts)).Returns(new List<Organization>(){new Organization{Id = "sds",Name="DD"}});
//            return _context;
//        }


//        /// <summary>
//        /// Get the  Mock for CheckLicense
//        /// </summary>
//        /// <returns></returns>
//        public Context MockCheckLicense()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.CheckLicense(It.IsAny<string>(),It.IsAny<string>())).Returns(true);
//            return _context;
//        }


//        /// <summary>
//        /// Get the  Mock for DeleteUserPreference
//        /// </summary>
//        /// <returns></returns>
//        public Context MockDeleteUserPreference()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.DeleteUserPreference(It.IsAny<string>())).Returns(true);
//            return _context;
//        }

//        /// <summary>
//        /// Get the  Mock for SaveUserPreference
//        /// </summary>
//        /// <returns></returns>
//        public Context MockSaveUserPreference()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.SaveUserPreference(It.IsAny<string>(),It.IsAny<string>())).Returns(true);
//            return _context;
//        }
        
//         /// <summary>
//        /// Get the  Mock for GetUserPreference
//        /// </summary>
//        /// <returns></returns>
//        public Context MockGetUserPreference()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetUserPreference(It.IsAny<string>())).Returns("User");
//            return _context;
//        }


//        /// <summary>
//        /// Get the  Mock for GetFiscalCalendar
//        /// </summary>
//        /// <returns></returns>
//        public Context MockGetFiscalCalendar()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetFiscalCalendar()).Returns(new FiscalCalendar());
//            return _context;
//        }



//        /// <summary>
//        /// Get the  Mock for GetInstalledReportForActiveApplication
//        /// </summary>
//        /// <returns></returns>
//        public Context MockGetInstalledReportForActiveApplications()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetInstalledReportForActiveApplication(It.IsAny<string>(),It.IsAny<string>())).Returns(new List<string>() { });
//            return _context;
//        }

//        /// <summary>
//        /// Get the  Mock for GetInstalledReportForActiveApplications
//        /// </summary>
//        /// <returns></returns>
//        public Context MockGetInstalledReportForActiveApplication()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.GetInstalledReportForActiveApplication(It.IsAny<string>())).Returns(new List<string>() { });
//            return _context;
//        }


//        /// <summary>
//        /// Get the  Mock for GetInstalledReportForActiveApplicatio
//        /// </summary>
//        /// <returns></returns>
//        public Context MockHasAccess()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.HasAccess(It.IsAny<string>())).Returns(true);
//            return _context;
//        }

//        /// <summary>
//        /// Get the  Mock for GetInstalledReportForActiveApplicatio
//        /// </summary>
//        /// <returns></returns>
//        public Context MockLockRsc()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default,mock.Object);
//            mock.Setup(x => x.LockRsc(It.IsAny<string>(), false)).Returns(new MultiUserStatus());
//            return _context;
//        }

//        /// <summary>
//        /// Get the  Mock for GetInstalledReportForActiveApplicatio
//        /// </summary>
//        /// <returns></returns>
//        public Context MockUnLockRsc()
//        {
//            var mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.UnLockRsc(It.IsAny<string>())).Returns(new MultiUserStatus());
//            return _context;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public Context MockDestroy()
//        {
//            Mock<ICommonRepository> mock = new Mock<ICommonRepository>();
//            _context.Container.RegisterInstance(UnityInjectionType.Default, mock.Object);
//            mock.Setup(x => x.UnlockApplication(It.IsAny<string>()));
//            return _context;
//        }
//        #endregion


//    }
//}
