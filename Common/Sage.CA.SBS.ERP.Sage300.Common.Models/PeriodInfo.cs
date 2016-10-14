/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Struct PeriodInfo
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PeriodInfo
    {
        /// <summary>
        /// The PGM i d1
        /// </summary>
        [FieldOffset(0)] private readonly byte PgmID1;

        /// <summary>
        /// The PGM i d2
        /// </summary>
        [FieldOffset(1)] private readonly byte PgmID2;

        /// <summary>
        /// The year1
        /// </summary>
        [FieldOffset(2)] private readonly byte Year1;

        /// <summary>
        /// The year2
        /// </summary>
        [FieldOffset(3)] private readonly byte Year2;

        /// <summary>
        /// The year3
        /// </summary>
        [FieldOffset(4)] private readonly byte Year3;

        /// <summary>
        /// The year4
        /// </summary>
        [FieldOffset(5)] private readonly byte Year4;

        /// <summary>
        /// The period
        /// </summary>
        [FieldOffset(6)] private readonly short Period;

        /// <summary>
        /// The date begin
        /// </summary>
        [FieldOffset(8)] private double DateBegin;

        /// <summary>
        /// The date end
        /// </summary>
        [FieldOffset(16)] private double DateEnd;

        /// <summary>
        /// The bo status
        /// </summary>
        [FieldOffset(24)] private readonly short BoStatus;

        // define a getter to return the Year.

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public string Year
        {
            get 
            { 
                return string.Format("{0}{1}{2}{3}",
                    Year1 == 0 ? "0" : Convert.ToString(Convert.ToChar(Year1)),
                    Year2 == 0 ? "0" : Convert.ToString(Convert.ToChar(Year2)),
                    Year3 == 0 ? "0" : Convert.ToString(Convert.ToChar(Year3)),
                    Year4 == 0 ? "0" : Convert.ToString(Convert.ToChar(Year4))
                );  
            }        
        }

        /// <summary>
        /// Gets or sets the begin date.
        /// </summary>
        /// <value>The begin date.</value>
        public double BeginDate
        {
            get { return DateBegin; }
            set { DateBegin = value; }
        }

        /// <summary>
        /// Gets BoStatus
        /// </summary>
        public short BOStatus
        {
            get { return BoStatus; }
        }

        /// <summary>
        /// Gets the Fiscal Period
        /// </summary>
        public short FiscalPeriod
        {
            get { return Period; }
        }

        /// <summary>
        /// Gets or sets the End date.
        /// </summary>
        /// <value>The End date.</value>
        public double EndDate
        {
            get { return DateEnd; }
            set { DateEnd = value; }
        }
    }
}