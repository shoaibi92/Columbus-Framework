// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using System;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Fiscal Year Set
    /// </summary>
    public class FiscalYearSet : ModelBase
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>The application identifier.</value>
        [Display(Name = "Period", ResourceType = typeof(CommonResx))]
        public string Period { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        [Display(Name = "Start", ResourceType = typeof(CommonResx))]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        [Display(Name = "End", ResourceType = typeof(CommonResx))]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [Display(Name = "Status", ResourceType = typeof(CommonResx))]
        public string Status { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        [Display(Name = "FiscalYear", ResourceType = typeof(CommonResx))]
        public string Year { get; set; }
    }

    /// <summary>
    /// Fiscal Calendar Year
    /// </summary>
    public class FiscalCalendarYear : ModelBase
    {
        /// <summary>
        /// Year
        /// </summary>
        [Display(Name = "FiscalYear", ResourceType = typeof(CommonResx))]
        public string Year { get; set; }
    }
}