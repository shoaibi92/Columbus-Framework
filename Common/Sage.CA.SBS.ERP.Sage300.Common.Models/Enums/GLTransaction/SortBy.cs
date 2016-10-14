/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region namespace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLTransaction
{
    /// <summary>
    /// Enum for Sort By
    /// </summary>
    public enum SortBy
    {
        /// <summary>
        /// Gets or sets AccountNo 
        /// </summary>
        [EnumValue("AccountNo", typeof(GLTransactionResx))]
        AccountNo = 0,

        /// <summary>
        /// Gets or sets YearOrPeriod 
        /// </summary>
        [EnumValue("YearOrPeriod", typeof(GLTransactionResx))]
        YearOrPeriod = 1,

        ///// <summary>
        ///// Gets or sets BatchOrEntryNo 
        ///// </summary>
        //[EnumValue("BatchOrEntryNo", typeof(GLTransactionsReportResx))]
        //BatchOrEntryNo = 2
    }
}
