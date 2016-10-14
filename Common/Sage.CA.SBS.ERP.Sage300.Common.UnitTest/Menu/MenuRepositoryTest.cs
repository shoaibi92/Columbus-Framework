using System.Globalization;
using Microsoft.Practices.Unity;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.AS.Services;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.CS.Services;
using System;
using System.Collections.Generic;
using System.Web.Fakes;
using System.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Menu
{
    /// <summary>
    /// Unit testing for MenuRepository
    /// </summary>
    [TestClass]
    public class MenuRepositoryTest
    {
        private enum MenuIdEnum { First = 111, Second = 222, Third = 333 };

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

            UnityUtil.RegisterType<IMenuModuleHelperManager, MenuModuleHelperManager>(context.Container);

            return context;
        }

        /// <summary>
        /// Get list of active application test data
        /// </summary>
        /// <returns></returns>
        private List<ActiveApplication> GetActiveApplicationList()
        {
            return new List<ActiveApplication>
            {
                new ActiveApplication{AppId="AR", IsInstalled=true},
                new ActiveApplication{AppId="AP", IsInstalled=true},
                new ActiveApplication{AppId="GL", IsInstalled=true}
            };
        }

        /// <summary>
        /// Get list of Navigable menus test data
        /// </summary>
        /// <returns></returns>
        private List<NavigableMenu> GetNavigableMenus()
        {
            var result = new List<NavigableMenu> {
                new NavigableMenu {MenuId="1"},
                new NavigableMenu {MenuId=((int)MenuIdEnum.Second).ToString(CultureInfo.InvariantCulture)},
                new NavigableMenu {MenuId="3"},
                new NavigableMenu {MenuId="4"}
            };

            return result;
        }

        /// <summary>
        /// Prepare Test casee for LoadData private function
        /// </summary>
        /// <param name="navigableMenus"></param>
        private void PrepareLoadData(List<NavigableMenu> navigableMenus)
        {

            IMenuModuleHelper helper1 = (new ShimAbstractMenuModuleHelper(new CoreMenuModuleHelper()) { ModuleHeaderGet = () => new NavigableMenu { MenuId = ((int)MenuIdEnum.Second).ToString(CultureInfo.InvariantCulture) }, GetMenuItems = () => navigableMenus, GetApplyFilteredMenuItemsListOfFuncOfNavigableMenuBoolean = a => navigableMenus, SaveMenuItemsListOfNavigableMenuString = (a, b) => { } }).Instance;
            IMenuModuleHelper helper2 = (new ShimAbstractMenuModuleHelper(new CoreMenuModuleHelper()) { ModuleHeaderGet = () => new NavigableMenu { MenuId = ((int)MenuIdEnum.First).ToString(CultureInfo.InvariantCulture) }, GetMenuItems = () => navigableMenus, GetApplyFilteredMenuItemsListOfFuncOfNavigableMenuBoolean = a => navigableMenus, SaveMenuItemsListOfNavigableMenuString = (a, b) => { } }).Instance;
            IMenuModuleHelper helper3 = (new ShimAbstractMenuModuleHelper(new CoreMenuModuleHelper()) { ModuleHeaderGet = () => new NavigableMenu { MenuId = ((int)MenuIdEnum.Third).ToString(CultureInfo.InvariantCulture) }, GetMenuItems = () => navigableMenus, GetApplyFilteredMenuItemsListOfFuncOfNavigableMenuBoolean = a => navigableMenus, SaveMenuItemsListOfNavigableMenuString = (a, b) => { } }).Instance;

            var lazyList = new List<Lazy<IMenuModuleHelper, IBootstrapMetadata>>
                                {
                                    new Lazy<IMenuModuleHelper, IBootstrapMetadata>(() => helper1 ,null),
                                    new Lazy<IMenuModuleHelper, IBootstrapMetadata>(() => helper2, null),
                                    new Lazy<IMenuModuleHelper, IBootstrapMetadata>(() => helper3, null)
                                };

            ShimMenuModuleHelperManager.AllInstances.AllModuleManagersGet = a => lazyList;
            ShimHttpRuntime.BinDirectoryGet = () => @"c:\";

            ShimHttpContext fakeHttpContext = new ShimHttpContext();
            ShimHttpServerUtility fakeHttpServerUtility = new ShimHttpServerUtility();
            fakeHttpServerUtility.MapPathString = a => @"c:\";
            fakeHttpContext.ServerGet = () => fakeHttpServerUtility;
            ShimHttpContext.CurrentGet = () => fakeHttpContext;

            ShimBaseRepository.AllInstances.SessionGet = a => new PseudoBusinessEntitySession();
            ShimPseudoBusinessEntitySession.AllInstances.GetActiveApplications = a => GetActiveApplicationList();
            //ShimCoreMenuModuleHelper.AllInstances.ModuleGet = a => BootstrapModule.AR;
            ShimCoreMenuModuleHelper.AllInstances.ModuleGet = a => "AR";

            ShimCoreMenuModuleHelper.AllInstances.InitializeStringContext = (a, b, c) => { };
            ShimCoreMenuModuleHelper.AllInstances.IsScreenUIModuleGet = a => true;
            ShimAbstractMenuModuleHelper.AllInstances.ActiveApplicationListGet = a => GetActiveApplicationList();
        }

        /// <summary>
        /// Unit testing for GetMenuHeader
        /// </summary>
        [TestMethod]
        public void GetMenuHeaderTest()
        {
            var context = CreateContext();
            context.Company = "Test";
            var menuRepository = new MenuRepository(context);

            using (ShimsContext.Create())
            {
                List<NavigableMenu> navigableMenus = GetNavigableMenus();
                PrepareLoadData(navigableMenus);
    
                var result = menuRepository.GetMenuHeader(context.Company).ToList();

                Assert.IsNotNull(result);
                Assert.AreEqual(result.Count(), 3);
                string lastValue = string.Empty;
                foreach (var item in result)
                {
                    Assert.IsTrue(string.CompareOrdinal(lastValue, item.MenuId) < 0);
                    lastValue = item.MenuId;
                }
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
            var menuRepository = new MenuRepository(context);

            using (ShimsContext.Create())
            {
                List<NavigableMenu> navigableMenus = GetNavigableMenus();
                PrepareLoadData(navigableMenus);

                var result = menuRepository.GetMenuItems(context.Company, ((int)MenuIdEnum.Second).ToString(CultureInfo.InvariantCulture), false);

                Assert.AreEqual(result.Count, navigableMenus.Count);
                for (int i = 0; i < result.Count; i++)
                {
                    Assert.AreEqual(result[i].MenuId, navigableMenus[i].MenuId);
                }

                result = menuRepository.GetMenuItems(context.Company, ((int)MenuIdEnum.Second).ToString(CultureInfo.InvariantCulture));

                Assert.AreEqual(result.Count, 3);
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
            var menuRepository = new MenuRepository(context);

            using (ShimsContext.Create())
            {
                var navigableMenus = GetNavigableMenus();
                PrepareLoadData(navigableMenus);

                menuRepository.SaveAllMenuItems(context.Company, new List<NavigableMenu>());
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
            var menuRepository = new MenuRepository(context);

            using (ShimsContext.Create())
            {
                List<NavigableMenu> navigableMenus = GetNavigableMenus();
                PrepareLoadData(navigableMenus);

                var result = menuRepository.GetWidgetItems(context.Company);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 0);
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
            var menuRepository = new MenuRepository(context);

            using (ShimsContext.Create())
            {
                List<NavigableMenu> navigableMenus = GetNavigableMenus();
                PrepareLoadData(navigableMenus);

                var result = menuRepository.GetAllMenuItems(context.Company);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count == 12);
            }
        }
    }
}
