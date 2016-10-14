// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for SortByType
    /// </summary>
    public enum SortByType
    {
        /// <summary>
        /// SortBy Type Account
        /// </summary>
        [EnumValue("Account", typeof(EnumerationsResx))]
        Account = 0,

        /// <summary>
        /// SortBy Type YearAndPeriod
        /// </summary>
        [EnumValue("YearAndPeriod", typeof(EnumerationsResx))]
        YearAndPeriod = 1,
    }
}
