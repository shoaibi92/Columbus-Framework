/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Portal
{
    /// <summary>
    /// Class CommonRepository.
    /// </summary>
    public class MenuSecurityRespository : BaseRepository, IMenuSecurityEntity
    {
        #region Constructors

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        public MenuSecurityRespository(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        public MenuSecurityRespository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Sets Context and Session and defaults DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        public MenuSecurityRespository(Context context, IBusinessEntitySession session)
            : base(context, session)
        {
        }

        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        public MenuSecurityRespository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region Public Method

        /// <summary>
        /// To get list of Menus after getting checked against its resource key
        /// </summary>
        /// <param name="resourceIdList">resourceIdList</param>
        /// <returns>Installed Reports</returns>
        public List<string> SecurityCheck(List<string> resourceIdList)
        {
            var securityCheckList = resourceIdList.Where(item => Session.SecurityCheck(item)).ToList();
            return securityCheckList;
        }

        #endregion
    }
}
