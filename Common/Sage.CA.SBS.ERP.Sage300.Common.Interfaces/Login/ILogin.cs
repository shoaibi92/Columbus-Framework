// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Login
{
    /// <summary>
    /// Interface for Login
    /// </summary>
    public interface ILogin
    {
        #region Public Properties

        /// <summary>
        /// List of companies to be displayed in UI
        /// </summary>
        IEnumerable<CustomSelectList> CompanyDisplayList { get; }

        /// <summary>
        /// User Id
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        string Company { get; set; }

        #endregion

    }
}