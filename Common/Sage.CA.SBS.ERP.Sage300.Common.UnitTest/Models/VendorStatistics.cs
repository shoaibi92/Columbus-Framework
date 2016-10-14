/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for VendorStatistics
    /// </summary>
    public class VendorStatistics : ModelBase
    {
        /// <summary>
        ///  Gets or sets VendorNumber
        /// </summary>
        public string VendorNumber { get; set; }

        /// <summary>
        ///  Gets or sets StatisticsListItems
        /// </summary>
        public List<StatisticsItem> StatisticsListItems { get; set; }       
    }
}