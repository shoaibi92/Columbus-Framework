// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespaces

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation
{
    /// <summary>
    /// Enum for RateOverridden 
    /// </summary>
    public enum RateOverridden
    {
        /// <summary>
        /// Gets or sets No 
        /// </summary>	
        [EnumValue("No", typeof(CommonResx))]
        No = 0,

        /// <summary>
        /// Gets or sets Yes 
        /// </summary>	
        [EnumValue("Yes", typeof(CommonResx))]
        Yes = 1,
    }
}
