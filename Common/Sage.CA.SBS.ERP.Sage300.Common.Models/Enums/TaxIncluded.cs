/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.  */

#region Namespaces
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for TaxIncluded 
    /// </summary>
    public enum TaxIncluded
    {
        /// <summary>
        /// Gets or sets No 
        /// </summary>	
        [EnumValue("No", typeof(EnumerationsResx))]
        No = 0,

        /// <summary>
        /// Gets or sets Yes 
        /// </summary>	
        [EnumValue("Yes", typeof(EnumerationsResx))]
        Yes = 1,
    }
}

