//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NND.CA.Common.Utilities
//{
//    public static class DateUtil
//    {

//        #region Public Properties
//        /// <summary>
//        /// Data Format
//        /// </summary>
//        /// <returns></returns>
//        public static string DateFormat
//        {
//            get { return CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern; }
//        }

//        /// <summary>
//        /// Date Pattern
//        /// </summary>
//        /// <returns></returns>
//        public static string DatePattern
//        {
//            get
//            {
//                return
//                    DateFormat.Replace("-", string.Empty)
//                    .Replace(".", string.Empty)
//                    .Replace(" ", string.Empty)
//                    .Replace("/", string.Empty);
//            }
//        }

//        /// <summary>
//        /// Returns Month-Day only format
//        /// </summary>
//        public static string MonthDayFormat
//        {
//            get
//            {
//                var result = DateFormat.Replace("y", "");
//                return result.Trim(DateSeparator.ToCharArray());
//            }
//        }

//        /// <summary>
//        /// Date separator
//        /// </summary>
//        public static string DateSeparator
//        {
//            get { return CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator; }
//        }

//        #endregion

//        #region Public Methods
//        /// <summary>
//        /// Get a Short date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <remarks>Short Date format is controlled by region settings</remarks>
//        /// <returns>Short Date String or default value</returns>
//        public static string GetShortDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.ToShortDateString() : defaultValue;
//        }

//        /// <summary>
//        /// Get a Short date
//        /// </summary>
//        /// <param name="date">Date value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <remarks>Short Date format is controlled by region settings</remarks>
//        /// <returns>Short Date String or default value</returns>
//        public static string GetShortDate(DateTime date, string defaultValue)
//        {
//            // Return default or date
//            return IsMinimumDate(date) ? defaultValue : date.ToShortDateString();
//        }

//        /// <summary>
//        /// Get a Short date
//        /// </summary>
//        /// <param name="value">Date value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <remarks>Short Date format is controlled by region settings</remarks>
//        /// <returns>Short Date String or default value</returns>
//        public static string GetShortDate(object value, string defaultValue)
//        {
//            DateTime date;

//            try
//            {
//                date = Convert.ToDateTime(value);
//            }
//            catch
//            {
//                return defaultValue;
//            }

//            // Return default or date
//            return IsMinimumDate(date) ? defaultValue : date.ToShortDateString();
//        }

//        /// <summary>
//        /// Get a Short date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Short Date String or default value</returns>
//        public static string GetShortDate(DateTime? date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : Convert.ToDateTime(date).ToShortDateString();
//        }

//        /// <summary>
//        /// Get a Max Short Date
//        /// </summary>
//        /// <returns>Max Short Date String</returns>
//        public static string GetShortMaxDate()
//        {
//            // Return max date
//            return GetMaxDate().ToShortDateString();
//        }

//        /// <summary>
//        /// Get a Now Short Date
//        /// </summary>
//        /// <returns>Now Short Date String</returns>
//        public static string GetShortNowDate()
//        {
//            // Return now date
//            return GetNowDate().ToShortDateString();
//        }

//        /// <summary>
//        /// Get a UTC Now Short Date
//        /// </summary>
//        /// <returns>UTC Now Short Date String</returns>
//        public static string GetShortUtcNowDate()
//        {
//            // Return utc now date
//            return DateTime.UtcNow.ToShortDateString();
//        }

//        /// <summary>
//        /// Get a Long date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <remarks>Long Date format is controlled by region settings</remarks>
//        /// <returns>Long Date String or default value</returns>
//        public static string GetLongDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.ToLongDateString() : defaultValue;
//        }

//        /// <summary>
//        /// Get a Long date
//        /// </summary>
//        /// <param name="date">Date value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <remarks>Long Date format is controlled by region settings</remarks>
//        /// <returns>Long Date String or default value</returns>
//        public static string GetLongDate(DateTime date, string defaultValue)
//        {
//            // Return default or date
//            return IsMinimumDate(date) ? defaultValue : date.ToLongDateString();
//        }

//        /// <summary>
//        /// Get a Long date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Long Date String or default value</returns>
//        public static string GetLongDate(DateTime? date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : Convert.ToDateTime(date).ToLongDateString();
//        }

//        /// <summary>
//        /// Get a Max Long Date
//        /// </summary>
//        /// <returns>Max Long Date String</returns>
//        public static string GetLongMaxDate()
//        {
//            // Return max date
//            return GetMaxDate().ToLongDateString();
//        }

//        /// <summary>
//        /// Get a Now Long Date
//        /// </summary>
//        /// <returns>Now Long Date String</returns>
//        public static string GetLongNowDate()
//        {
//            // Return now date
//            return GetNowDate().ToLongDateString();
//        }

//        /// <summary>
//        /// Get a Year Month Day date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Year Month Day Date String or default value</returns>
//        public static string GetYearMonthDayDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToYearMonthDay(date) : defaultValue;
//        }

//        /// <summary>
//        /// Get a Year Month Day date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Year Month Day Date String or default value</returns>
//        public static string GetYearMonthDayDate(DateTime? date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : ConvertToYearMonthDay(Convert.ToDateTime(date));
//        }

//        /// <summary>
//        /// Get a Year Month Day date
//        /// </summary>
//        /// <param name="value">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Year Month Day Date String or default value</returns>
//        public static string GetYearMonthDayDate(object value, string defaultValue)
//        {
//            DateTime date;

//            try
//            {
//                date = Convert.ToDateTime(value);
//            }
//            catch
//            {
//                return defaultValue;
//            }

//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : ConvertToYearMonthDay(date);
//        }

//        /// <summary>
//        /// Get a Year Month Day date
//        /// </summary>
//        /// <param name="date">Date value</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Year Month Day Date String or default value</returns>
//        public static string GetYearMonthDayDate(DateTime date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : ConvertToYearMonthDay(date);
//        }

//        /// <summary>
//        /// Get a Max Year Month Day date
//        /// </summary>
//        /// <returns>Max Year Month Day Date String</returns>
//        public static string GetYearMonthDayMaxDate()
//        {
//            // Return max date
//            return ConvertToYearMonthDay(GetMaxDate());
//        }

//        /// <summary>
//        /// Get a Month Day Year date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Month Day Year Date String or default value</returns>
//        public static string GetMonthDayYearDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToMonthDayYear(date) : defaultValue;
//        }

//        /// <summary>
//        /// Get a Month Day Year date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Month Day Year Date String or default value</returns>
//        public static string GetMonthDayYearDate(DateTime? date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : ConvertToMonthDayYear(Convert.ToDateTime(date));
//        }

//        /// <summary>
//        /// Get a Month Day Year date
//        /// </summary>
//        /// <param name="date">Date value</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <returns>Month Day Year Date String or default value</returns>
//        public static string GetMonthDayYearDate(DateTime date, string defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : ConvertToMonthDayYear(date);
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if date is null</param>
//        /// <returns>Date</returns>
//        public static DateTime? GetDate(DateTime? date, DateTime? defaultValue)
//        {
//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : Convert.ToDateTime(date).Date;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="date">Potentially null date time value of date</param>
//        /// <param name="defaultValue">Default value if date is null</param>
//        /// <returns>Date</returns>
//        public static DateTime GetDate(DateTime? date, DateTime defaultValue)
//        {
//            DateTime convertedDate;

//            try
//            {
//                convertedDate = Convert.ToDateTime(date);
//            }
//            catch
//            {
//                return defaultValue;
//            }

//            // Validate and return
//            return IsMinimumDate(convertedDate) ? defaultValue : convertedDate.Date;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if date is null</param>
//        /// <returns>Date</returns>
//        public static DateTime GetDate(string value, DateTime defaultValue)
//        {
//            DateTime date;

//            try
//            {
//                date = Convert.ToDateTime(value);
//            }
//            catch
//            {
//                return defaultValue;
//            }

//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : date.Date;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if date is null</param>
//        /// <returns>Date</returns>
//        public static DateTime GetDate(object value, DateTime defaultValue)
//        {
//            DateTime date;

//            try
//            {
//                date = Convert.ToDateTime(value);
//            }
//            catch
//            {
//                return defaultValue;
//            }

//            // Validate and return
//            return IsMinimumDate(date) ? defaultValue : date.Date;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Date</returns>
//        public static DateTime GetDate(string value, DateTime defaultValue, bool isYearMonthDayFormat)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? Convert.ToDateTime(date).Date : defaultValue;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Date</returns>
//        public static DateTime? GetDate(string value, DateTime? defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? Convert.ToDateTime(date).Date : defaultValue;
//        }

//        /// <summary>
//        /// Get a date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="format">Format of date string</param>
//        /// <returns>Date</returns>
//        public static DateTime GetDate(string value, DateTime defaultValue, string format)
//        {
//            // Return default if no value entered to convert
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, true, format, out date) ? date.Date : defaultValue;
//        }

//        /// <summary>
//        /// Get a date in specified format
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="format">Outout format for date</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Date in specified fromat</returns>
//        public static string GetDate(string value, string defaultValue, string format, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToFormat(date, format) : defaultValue;
//        }

//        /// <summary>
//        /// Get Ticks in date
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <returns>Ticks</returns>
//        public static long GetTicks(string value, long defaultValue, bool isYearMonthDayFormat = false)
//        {
//            // Return default if no value entered to parse
//            if (string.IsNullOrWhiteSpace(value))
//            {
//                return defaultValue;
//            }

//            // Parse, validate and return
//            DateTime date;
//            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.Ticks : defaultValue;
//        }

//        /// <summary>
//        /// Get Ticks in date
//        /// </summary>
//        /// <returns>Ticks</returns>
//        public static long GetTicks()
//        {
//            return GetNowDate().Ticks;
//        }

//        /// <summary>
//        /// Get the starting date for the week based upon the entered date
//        /// </summary>
//        /// <param name="date">Date to determine the starting date of the week</param>
//        /// <returns>Starting date of the week</returns>
//        /// <remarks>Saturday is considered to be the start of the week</remarks>
//        public static DateTime GetWeekStartingDate(DateTime date)
//        {
//            // Return var and get day of the week
//            DateTime startDate;
//            var dayOfWeek = date.DayOfWeek;

//            // Determine start date of week
//            if (dayOfWeek.Equals(DayOfWeek.Saturday))
//            {
//                startDate = date;
//            }
//            else if (dayOfWeek.Equals(DayOfWeek.Sunday))
//            {
//                startDate = date.AddDays(-1);
//            }
//            else
//            {
//                startDate = date.AddDays(-(int)dayOfWeek - 1);
//            }

//            return startDate;
//        }

//        /// <summary>
//        /// Get a Min Date
//        /// </summary>
//        /// <returns>Min Date</returns>
//        public static DateTime GetMinDate()
//        {
//            // Return min date
//            return DateTime.MinValue.Date;
//        }

//        /// <summary>
//        /// Get a Max Date
//        /// </summary>
//        /// <returns>Max Date</returns>
//        public static DateTime GetMaxDate()
//        {
//            // Return max date
//            return DateTime.MaxValue.Date;
//        }

//        /// <summary>
//        /// Get a Now Date
//        /// </summary>
//        /// <returns>Now Date</returns>
//        public static DateTime GetNowDate()
//        {
//            // Return now date
//            return DateTime.Now.Date;
//        }

//        /// <summary>
//        /// Get a New Date
//        /// </summary>
//        /// <returns>New Date</returns>
//        public static DateTime GetNewDate()
//        {
//            // Return now date
//            return new DateTime().Date;
//        }

//        /// <summary>
//        /// Is date a minimum date
//        /// </summary>
//        /// <param name="value">Date</param>
//        /// <remarks>Minimum date is defined by date object (1/1/0001) or 12/30/1899</remarks>
//        /// <returns>True if date is a minimum date otherwise false</returns>
//        public static bool IsMinimumDate(string value)
//        {
//            DateTime date;

//            try
//            {
//                date = Convert.ToDateTime(value);
//            }
//            catch
//            {
//                return false;
//            }

//            // Is it a minimum date?
//            return IsMinimumDate(date);
//        }


//        /// <summary>
//        /// Is date a minimum date
//        /// </summary>
//        /// <param name="date">Date</param>
//        /// <remarks>Minimum date is defined by date object (1/1/0001) or 12/30/1899</remarks>
//        /// <returns>True if date is a minimum date otherwise false</returns>
//        public static bool IsMinimumDate(DateTime? date)
//        {
//            // Is it a minimum date?
//            return !date.HasValue || IsMinimumDate(Convert.ToDateTime(date));
//        }

//        /// <summary>
//        /// Is date a minimum date
//        /// </summary>
//        /// <param name="date">Date</param>
//        /// <remarks>Minimum date is defined by date object (1/1/0001) or 12/30/1899 or 12/31/1899 or 01/01/1901</remarks>
//        /// <returns>True if date is a minimum date otherwise false</returns>
//        public static bool IsMinimumDate(DateTime date)
//        {
//            // Simplistic check!
//            return (date.Year < 1902);
//        }

//        /// <summary>
//        /// Is Date valid
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
//        /// <param name="date">Output date</param>
//        /// <returns>True if date is valid otherwise false</returns>
//        public static bool IsDateValid(string value, bool isYearMonthDayFormat, out DateTime date)
//        {
//            return IsDateValid(value, isYearMonthDayFormat, "yyyyMMdd", out date);
//        }

//        /// <summary>
//        /// Is Date valid
//        /// </summary>
//        /// <param name="value">String value of date</param>
//        /// <param name="useDateFormat">True to use date format otherwise false</param>
//        /// <param name="format">Date Format</param>
//        /// <param name="date">Output date</param>
//        /// <returns>True if date is valid otherwise false</returns>
//        public static bool IsDateValid(string value, bool useDateFormat, string format, out DateTime date)
//        {
//            // Multi-tiered approach to parse date
//            // 1. If format is specified, try that first
//            // 2. If format fails or no format, then try without format
//            var isValid = false;
//            date = default(DateTime);

//            // Attempt parsing based upon format
//            if (useDateFormat)
//            {
//                isValid = DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
//                    out date);
//            }

//            // If format parse was unsuccessful OR no format, then attempt parse without format
//            if (!isValid)
//            {
//                isValid = DateTime.TryParse(value, out date);
//            }

//            // Extra validation for minimum date!
//            if (isValid && IsMinimumDate(date))
//            {
//                // It is a minimum date therefore it is invalid
//                isValid = false;
//            }

//            return isValid;
//        }

//        /// <summary>
//        /// Convert Date to Year Month Day
//        /// </summary>
//        /// <param name="date">Date value</param>
//        /// <returns>Year Month Day Date String</returns>
//        public static string ConvertToYearMonthDay(DateTime date)
//        {
//            return date.ToString("yyyyMMdd");
//        }

//        /// <summary>
//        /// Convert Date to Month Day Year
//        /// </summary>
//        /// <param name="date">Date value</param>
//        /// <returns>Month Day Year Date String</returns>
//        public static string ConvertToMonthDayYear(DateTime date)
//        {
//            return date.ToString("MMddyyyy");
//        }

//        /// <summary>
//        /// Convert Date to Specified Format
//        /// </summary>
//        /// <param name="date">Date value</param>
//        /// <param name="format">Date format</param>
//        /// <returns>Date String in specified format</returns>
//        public static string ConvertToFormat(DateTime date, string format)
//        {
//            return date.ToString(format);
//        }

//        #endregion
//    }
//}
