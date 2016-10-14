/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Portal
{
    /// <summary>
    /// Service exposing common methods
    /// </summary>
    public class MenuSecurityEntityService : BaseService, IMenuSecurityService
    {
        #region Constructor

        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public MenuSecurityEntityService(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To get list of Menus after getting checked against its resource key
        /// </summary>
        /// <param name="resourceIdList">resourceIdList</param>
        /// <returns></returns>
        public List<string> SecurityCheck(List<string> resourceIdList)
        {
            using (var repository = Resolve<IMenuSecurityEntity>())
            {
                return repository.SecurityCheck(resourceIdList);
            }
        }

        /// <summary>
        /// Is not used
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
