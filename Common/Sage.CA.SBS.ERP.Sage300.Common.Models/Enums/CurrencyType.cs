// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for CurrencyType
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Currency Type Functional
        /// </summary>
        [EnumValue("Functional", typeof(EnumerationsResx))]
        Functional = 0,

        /// <summary>
        /// Currency Type Source
        /// </summary>
        [EnumValue("Source", typeof(EnumerationsResx))]
        Source = 1,
    }
}
