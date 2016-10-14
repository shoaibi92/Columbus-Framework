// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for AutoTaxCalculationOnSave
    /// </summary>
    public enum AutoTaxCalculationOnSave
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
        Yes = 1
    }
}