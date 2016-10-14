using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.CS.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu;
using Microsoft.Practices.Unity;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Menu
{
    /// <summary>
    /// Unit testing for MenuService
    /// </summary>
    [TestClass]
    public class MenuServiceTest
    {
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

            UnityUtil.RegisterType<ICompanyProfileService<CompanyProfile>, CompanyProfileEntityService<CompanyProfile>>(context.Container);
            UnityUtil.RegisterType<IDataIntegrityService<DataIntegrity>, DataIntegrityEntityService<DataIntegrity>>(context.Container);
            UnityUtil.RegisterType<ICommonService, CommonService>(context.Container);
            UnityUtil.RegisterType<ICommonRepository, CommonRepository>(context.Container, UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType<IMenuRepository, MenuRepository>(context.Container, UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));

            return context;
        }

        private List<NavigableMenu> GetNavigableMenus()
        {
            var result = new List<NavigableMenu> {
                new NavigableMenu()
            };

            return result;
        }

        /// <summary>
        /// Unit testing for GetMenuHeader
        /// </summary>
        [TestMethod]
        public void GetMenuHeaderTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();
            
            using (ShimsContext.Create())
            {
                ShimCommonRepository.AllInstances.CheckLicenseStringString = (a, b, c) => true;
                ShimMenuRepository.AllInstances.GetMenuHeaderString = (a, b) => navigableMenuList;

                var result = menuService.GetMenuHeader(context.Company = "Test");

                Assert.AreEqual(result, navigableMenuList);
            }
        }

        /// <summary>
        /// Unit testing for GetMenuItems
        /// </summary>
        [TestMethod]
        public void GetMenuItemsTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();

            using (ShimsContext.Create())
            {
                ShimCommonRepository.AllInstances.CheckLicenseStringString = (a, b, c) => true;
                ShimMenuRepository.AllInstances.GetMenuItemsStringStringBoolean = (a, b, c, d) => navigableMenuList;

                var result = menuService.GetMenuItems(context.Company, string.Empty);
                Assert.AreEqual(result, navigableMenuList);
            }
        }

        /// <summary>
        /// Unit testing for GetWidgetItems
        /// </summary>
        [TestMethod]
        public void GetWidgetItemsTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();

            using (ShimsContext.Create())
            {
                ShimCommonRepository.AllInstances.CheckLicenseStringString = (a, b, c) => true;
                ShimMenuRepository.AllInstances.GetWidgetItemsString = (a, b) => navigableMenuList;

                var result = menuService.GetWidgetItems(context.Company);
                Assert.AreEqual(result, navigableMenuList);
            }
        }

        /// <summary>
        /// Unit testing for SaveAllMenuItems
        /// </summary>
        [TestMethod]
        public void SaveAllMenuItemsTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();

            using (ShimsContext.Create())
            {
                ShimMenuRepository.AllInstances.SaveAllMenuItemsStringListOfNavigableMenu = (a, b, c) => { };
                menuService.SaveAllMenuItems(context.Company, null);
            }
        }


        /// <summary>
        /// Unit testing for GetAllMenuItems
        /// </summary>
        [TestMethod]
        public void GetAllMenuItemsTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();

            using (ShimsContext.Create())
            {
                ShimCommonRepository.AllInstances.CheckLicenseStringString = (a, b, c) => true;
                ShimMenuRepository.AllInstances.GetAllMenuItemsString = (a, b) => navigableMenuList;

                var result = menuService.GetAllMenuItems(context.Company);
                Assert.AreEqual(result, navigableMenuList);
            }
        }


        /// <summary>
        /// Unit testing for GetAccessRights
        /// </summary>
        [TestMethod]
        public void GetAccessRightsTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuService = new MenuService(context);
            var navigableMenuList = GetNavigableMenus();
            var userAccess = new UserAccess {SecurityType = Common.Models.Enums.SecurityType.Modify};

            using (ShimsContext.Create())
            {
                ShimMenuRepository.AllInstances.GetAccessRights = (a) => userAccess;
                var result = menuService.GetAccessRights();

                Assert.AreEqual(userAccess, result);
            }
        }
    }
}
