/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class FiscalCalendar.
    /// </summary>
    public class FiscalCalendar
    {
        /// <summary>
        /// Gets or sets the first year.
        /// </summary>
        /// <value>The first year.</value>
        public Years FirstYear { get; set; }

        /// <summary>
        /// Gets or sets the last year.
        /// </summary>
        /// <value>The last year.</value>
        public Years LastYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fiscal application.
        /// </summary>
        /// <value><c>true</c> if this instance is fiscal application; otherwise, <c>false</c>.</value>
        public bool IsFiscalApp { get; set; }

        /// <summary>
        /// Gets or sets the year dates.
        /// </summary>
        /// <value>The year dates.</value>
        public YearDates YearDates { get; set; }
    }

    /// <summary>
    /// Class Years.
    /// </summary>
    public class Years
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public string Year { get; set; }

        /// <summary>
        /// Gets or sets the periods.
        /// </summary>
        /// <value>The periods.</value>
        public int Periods { get; set; }

        /// <summary>
        /// Gets or sets the quarter.
        /// </summary>
        /// <value>The quarter.</value>
        public int Quarter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// Class YearDates.
    /// </summary>
    public class YearDates
    {
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public string Year { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTime EndDate { get; set; }
    }
}