// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for DefaultCard
    /// </summary>
    public enum DefaultCard
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
