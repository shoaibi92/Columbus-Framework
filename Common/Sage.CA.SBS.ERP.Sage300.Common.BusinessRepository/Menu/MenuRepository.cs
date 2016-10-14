/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu
{
    /// <summary>
    /// Menu Repository
    /// </summary>
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        #region Constructors

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        public MenuRepository(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        public MenuRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Sets Context and Session and defaults DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        public MenuRepository(Context context, IBusinessEntitySession session)
            : base(context, session)
        {
        }

        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        public MenuRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region public

        /// <summary>
        /// Flag for optional field for the system
        /// </summary>
        public bool IsOptionalFieldActivated { get; set; }

        /// <summary>
        /// Flag for national account license
        /// </summary>
        public bool HasNationalAccountLicense { get; set; }

        /// <summary>
        /// Get Menu header base on the company
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<NavigableMenu> GetMenuHeader(string company)
        {
            var result = new List<NavigableMenu>();

            var helperList = LoadData(company).Where(module => module.IsScreenUIModule);

            foreach (var menuModuleHelper in helperList)
            {
                result.Add(menuModuleHelper.ModuleHeader);
            }

            // sort the menuid header before return
            result.Sort((navigableMenu1, navigableMenu2) => string.CompareOrdinal(navigableMenu1.MenuId, navigableMenu2.MenuId));

            return result.AsEnumerable();
        }

        /// <summary>
        /// Get all MenuItems base on the module without any filtering
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="headerMenuId">string</param>
        /// <param name="removeHeader">bool</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetMenuItems(string company, string headerMenuId, bool removeHeader = true)
        {
            var result = new List<NavigableMenu>();
            var helper = LoadData(company).Where(module => module.IsScreenUIModule).FirstOrDefault(module => module.ModuleHeader.MenuId == headerMenuId);

            if (helper != null)
            {
                result = removeHeader
                    ? helper.GetMenuItems().Where(menu => menu.MenuId != headerMenuId).ToList()
                    : helper.GetMenuItems();
            }

            return result.Where(menu => !menu.IsHidden.HasValue || !menu.IsHidden.Value).ToList();
        }

        /// <summary>
        /// Save updated menu item
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="menuList">List of NavigableMenu</param>
        public void SaveAllMenuItems(string company, List<NavigableMenu> menuList)
        {
            var helperList = LoadData(company);

            foreach (var helper in helperList)
            {
                helper.SaveMenuItems(menuList, company);
            }
        }

        /// <summary>
        /// Get all Widget items
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetWidgetItems(string company)
        {
            var result = new List<NavigableMenu>();
            var helperList = LoadData(company);

            var kpiHelper = helperList.FirstOrDefault(helper => helper.Module == "KPI");

            if (kpiHelper != null)
            {
                result = kpiHelper.GetMenuItems();
            }

            return result;
        }

        /// <summary>
        /// Get all Menu Items with filtering base on multicurrency, optional field and activation ... etc
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetAllMenuItems(string company)
        {
            var result = new List<NavigableMenu>();

            var helperList = LoadData(company);

            foreach (var helper in helperList)
            {
                result.AddRange(helper.GetFilteredMenuItems());
            }

            // remove all KPI Menu Items and hidden items
            result = result.Where(menu => (!menu.IsWidget.HasValue || !menu.IsWidget.Value) &&
                                          (!menu.IsHidden.HasValue || !menu.IsHidden.Value)).ToList();

            return result;
        }

        /// <summary>
        /// GetAccessRights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private

        /// <summary>
        /// Load data from source
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>IEnumerable&lt;IMenuModuleHelper&gt;</returns>
        private IEnumerable<IMenuModuleHelper> LoadData(string company)
        {
            var result = new List<IMenuModuleHelper>();

            var menuModuleHelperManager = Context.Container.Resolve<IMenuModuleHelperManager>();

            var activeApplicationList =
                Session.GetActiveApplications().Where(application => application.IsInstalled).ToList();
            foreach (var moduleManager in menuModuleHelperManager.AllModuleManagers)
            {
                // get a list of application, filter down to only the installed onces, and match with module manager (except not UI ones)
                if (activeApplicationList.Exists(application => application.AppId == moduleManager.Value.Module.ToString()) || !moduleManager.Value.IsScreenUIModule)
                {
                    AddModule(moduleManager.Value, company, result, activeApplicationList);
                }
                if (moduleManager.Value.IsPlugInMenu)
                {
                    menuModuleHelperManager.HasPluginMenu = true;
                }   
            }

            // Since this method/activity is executed from the portal/home page, 
            // any resources/sessions have to be cleared/removed when this is complete
            // or else they will cause conflicts for those tasks requiring exclusive access
            BusinessPoolManager.DestroyPool(Context.SessionId);

            return result;
        }

        private void AddModule(IMenuModuleHelper value, string company, List<IMenuModuleHelper> result, List<Sage.CA.SBS.ERP.Sage300.Common.Models.ActiveApplication> activeApplicationList)
        {
            value.IsOptionalFieldEnable = IsOptionalFieldActivated;
            value.HasNationalAccountLicense = HasNationalAccountLicense;
            value.ActiveApplicationList = activeApplicationList;
            value.ProductSeries = Session.ProductSeries;
            value.Initialize(company, Context);
            result.Add(value);
        }

        #endregion
    }
}
