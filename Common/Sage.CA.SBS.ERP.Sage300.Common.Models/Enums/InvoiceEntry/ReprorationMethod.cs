// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ReprorationMethod
    /// </summary>
    public enum ReprorationMethod
    {
        /// <summary>
        /// Gets or sets Leave
        /// </summary>
        [EnumValue("Leave", typeof(EnumerationsResx))]
        Leave = 1,
        /// <summary>
        /// Gets or sets Prorate
        /// </summary>
        [EnumValue("Prorate", typeof(EnumerationsResx))]
        Prorate = 2,
        /// <summary>
        /// Gets or sets Expense
        /// </summary>
        [EnumValue("Expense", typeof(EnumerationsResx))]
        Expense = 3,
    }
}
