/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class FiscalPeriod.
    /// </summary>
    public class FiscalPeriod
    {
        /// <summary>
        /// Fiscal Period
        /// </summary>
        /// <value>The period.</value>
        public short Period { get; set; }

        /// <summary>
        /// Fiscal Year
        /// </summary>
        /// <value>The year.</value>
        public string Year { get; set; }

        /// <summary>
        /// Gets the year value.
        /// </summary>
        /// <value>The year value.</value>
        public int YearValue
        {
            get
            {
                int year = 0;
                if (!string.IsNullOrEmpty(Year))
                {
                    int.TryParse(Year, out year);
                }
                return year;
            }
        }

        /// <summary>
        /// If true period is open else closed
        /// </summary>
        /// <value><c>true</c> if this instance is period open; otherwise, <c>false</c>.</value>
        public bool IsPeriodOpen { get; set; }
    }
}