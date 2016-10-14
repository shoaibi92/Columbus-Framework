/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLTransaction
{
    /// <summary>
    /// Enum for Currency Type
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Gets or sets Functional Currency 
        /// </summary>
        [EnumValue("Functional", typeof(GLTransactionResx))]
        Functional= 0,

        /// <summary>
        /// Gets or sets Source Currency 
        /// </summary>
        [EnumValue("Source", typeof(GLTransactionResx))]
        Source = 1
    }
}
