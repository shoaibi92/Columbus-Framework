/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region namespace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLTransaction
{
    /// <summary>
    /// Enum for Report Format
    /// </summary>
    public enum ReportFormat
    {
        /// <summary>
        /// Gets or sets Detail 
        /// </summary>
        [EnumValue("Detail", typeof(GLTransactionResx))]
        Detail = 0,
        /// <summary>
        /// Gets or sets Summary 
        /// </summary>
        [EnumValue("Summary", typeof(GLTransactionResx))]
        Summary = 1
    }
}
