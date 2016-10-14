// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for ReportFormat
    /// </summary>
    public enum ReportFormat
    {
        /// <summary>
        /// Report Format Detail
        /// </summary>
        [EnumValue("Detail", typeof(EnumerationsResx))]
        Detail = 0,

        /// <summary>
        /// Report Format Summary
        /// </summary>
        [EnumValue("Summary", typeof(EnumerationsResx))]
        Summary = 1,
    }
}
