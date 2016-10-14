// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for Status 
    /// </summary> 
    public enum Status
    {
        /// <summary>
        /// Gets or sets Inactive 
        /// </summary>	
        [EnumValue("Inactive", typeof(CommonResx))]
        Inactive = 0,

        /// <summary>
        /// Gets or sets Active 
        /// </summary>	
        [EnumValue("Active", typeof(CommonResx))]
        Active = 1
    }
}