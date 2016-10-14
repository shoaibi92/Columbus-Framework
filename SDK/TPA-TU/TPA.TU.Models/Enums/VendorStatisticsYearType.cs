// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region Name Spaces

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace TPA.TU.Models.Enums
{
    /// <summary>
    /// Enumeration for Vendor Statistics Year Type 
    /// </summary>
    public enum VendorStatisticsYearType
    {
        /// <summary>
        /// Value for Calendar Year 
        /// </summary>
        [EnumValue("StatisticsAccumulate_CalendarYear", typeof(EnumerationsResx), 1)]
        CalendarYear = 1,

        /// <summary>
        /// Value for Fiscal Year 
        /// </summary>	
        [EnumValue("StatisticsAccumulate_FiscalYear", typeof(EnumerationsResx), 2)]
        FiscalYear = 2
    }
}
