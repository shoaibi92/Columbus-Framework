// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region
using System;
using System.Text.RegularExpressions;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Common Time Utility methods
    /// </summary>
    public static class TimeUtil
    {
        /// <summary>
        /// Convert DateTime to TimeSpan
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ConvertToTimeSpan(DateTime value)
        {
            return new TimeSpan(value.Hour, value.Minute, value.Second);
        }

        /// <summary>
        /// Convert String To TimSpan
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ConvertToTimeSpan(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 8)
            {
                return TimeSpan.Zero;
            }
            var timecomponents = value.Split(':');

            return new TimeSpan(timecomponents.Length > 0 ? Convert.ToInt16(timecomponents[0]) : 0,
                timecomponents.Length > 1 ? Convert.ToInt16(timecomponents[1]) : 0,
                timecomponents.Length > 2 ? Convert.ToInt16(timecomponents[2]) : 0);
        }

        /// <summary>
        /// Get TimeFormat
        /// </summary>
        /// <param name="time">Time</param>
        /// <returns>Date Format</returns>
        public static string GetFormattedTime(string time)
        {
            if (string.IsNullOrEmpty(time))
            {
                return "00:00:00";
            }
            var formatedTime = Regex.Replace(time, RegularExpressions.TimeFormatFrom, RegularExpressions.TimeFormatTo);
            return formatedTime;
        }

    }
}