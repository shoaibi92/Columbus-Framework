/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using System.Collections.Generic;
using UserAccess = Sage.CA.SBS.ERP.Sage300.Common.Models.UserAccess;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Portal
{
    /// <summary>
    /// Class NavigationEntityService For XML Based Menu.
    /// </summary>
    /// <typeparam name="T">NavigableMenu</typeparam>
    public class NavigationEntityService<T> : BaseService, INavigationService<T> where T : NavigableMenu, new()
    {
        #region Constructor

        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public NavigationEntityService(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the NavigableMenu object for Menu Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <param name="isReturnNonActiveMenu">bool</param>
        /// <returns></returns>
        public List<T> GetMenuDetails(string fileLocation, bool isReturnNonActiveMenu = false)
        {
            using (var repository = ResolveDefault<INavigationEntity<T>>())
            {
                return repository.GetMenuDetails(fileLocation, isReturnNonActiveMenu);
            }
        }

        /// <summary>
        /// Gets User Access Right
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            return null;
        }

        #endregion
    }
}
