/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Portal
{
    /// <summary>
    /// Class HelpEntityService For XML Based Menu Help.
    /// </summary>
    /// <typeparam name="T">MenuHelp</typeparam>
    public class HelpEntityService<T> : BaseService, IHelpService<T> where T : MenuHelp, new()
    {
        #region Constructor

        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public HelpEntityService(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the MenuHelp object for Menu Help Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns></returns>
        public List<T> GetMenuHelp(string fileLocation)
        {
            using (var repository =  ResolveDefault<IHelpEntity<T>>())
            {
                return repository.GetMenuHelp(fileLocation);
            }
        }

        /// <summary>
        /// Get access rights interface implementation
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            return null;
        }

        #endregion
    }
}
