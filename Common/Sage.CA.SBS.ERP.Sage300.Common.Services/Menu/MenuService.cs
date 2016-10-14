/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Menu
{
    /// <summary>
    /// Menu Service Interface
    /// </summary>
    public class MenuService : BaseService, IMenuService
    {
        #region Constructor

        /// <summary>
        /// Constructor of MenuService
        /// </summary>
        /// <param name="context">Context</param>
        public MenuService(Context context)
            : base(context)
        {       
        }

        #endregion

        #region public

        /// <summary>
        /// Get Menu header base on the company
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<NavigableMenu> GetMenuHeader(string company)
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                repository.IsOptionalFieldActivated = IsOptionalFieldActived();
                repository.HasNationalAccountLicense = HasNationalAccountLicense();
                return repository.GetMenuHeader(company);
            }
        }

        /// <summary>
        /// Get all MenuItems base on the module
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="headerMenuId">string</param>
        /// <param name="removeHeader">bool</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetMenuItems(string company, string headerMenuId, bool removeHeader = true)
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                repository.IsOptionalFieldActivated = IsOptionalFieldActived();
                repository.HasNationalAccountLicense = HasNationalAccountLicense();
                return repository.GetMenuItems(company, headerMenuId, removeHeader);
            }
        }

        /// <summary>
        /// Save updated menu item
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="menuList">List of NavigableMenu</param>
        public void SaveAllMenuItems(string company, List<NavigableMenu> menuList)
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                repository.SaveAllMenuItems(company, menuList);
            }
        }

        /// <summary>
        /// Get all Widget items
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetWidgetItems(string company)
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                repository.IsOptionalFieldActivated = IsOptionalFieldActived();
                repository.HasNationalAccountLicense = HasNationalAccountLicense();
                return repository.GetWidgetItems(company);
            }
        }

        /// <summary>
        /// Get all Menu Items with filtering base on multicurrency, optional field and activation ... etc
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        public List<NavigableMenu> GetAllMenuItems(string company)
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                repository.IsOptionalFieldActivated = IsOptionalFieldActived();
                repository.HasNationalAccountLicense = HasNationalAccountLicense();
                return repository.GetAllMenuItems(company);
            }
        }

        /// <summary>
        /// GetAccessRights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<IMenuRepository>())
            {
                return repository.GetAccessRights();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Check optional field status
        /// </summary>
        /// <returns>bool</returns>
        private bool IsOptionalFieldActived()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.CheckLicense("OB", string.Empty);
            }
        }

        /// <summary>
        /// Check National Account License activation
        /// </summary>
        /// <returns></returns>
        private bool HasNationalAccountLicense()
        {
            using (var repository = Resolve<ICommonRepository>())
            {
                return repository.CheckLicense("NA", string.Empty);
            }
        }

        #endregion
    }
}
