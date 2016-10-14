// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sage.CA.SBS.ERP.Sage300.DateTimeResearch
{
    /// <summary> UI for Date Time Research </summary>
    public partial class DateTimeResearch : Form
    {
        #region Private Vars
        #endregion

        #region Delegates
        #endregion

        #region Constructor
        /// <summary> Constructor </summary>
        public DateTimeResearch()
        {
            InitializeComponent();

            GetCultures();

            GetTimezones();

        }
        #endregion

        #region Private Methods/Routines/Events

        /// <summary> Get Cultures </summary>
        private void GetCultures()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).OrderBy(culture => culture.DisplayName);
            var sourceList = new BindingList<Binding>();
            var destinationList = new BindingList<Binding>();

            // Iterate for binding
            foreach (var culture in cultures)
            {
                sourceList.Add(new Binding() { DisplayName = culture.DisplayName, Name = culture.Name });
                destinationList.Add(new Binding() { DisplayName = culture.DisplayName, Name = culture.Name });
            }

            // Source
            cboSourceLocale.ValueMember = null;
            cboSourceLocale.DisplayMember = "DisplayName";
            cboSourceLocale.DataSource = sourceList;

            // Destination
            cboDestinationLocale.ValueMember = null;
            cboDestinationLocale.DisplayMember = "DisplayName";
            cboDestinationLocale.DataSource = destinationList;
        }

        /// <summary> Get Timezones </summary>
        private void GetTimezones()
        {
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            var sourceList = new BindingList<Binding>();
            var destinationList = new BindingList<Binding>();

            // Iterate for binding
            foreach (var timezone in timezones)
            {
                sourceList.Add(new Binding() { DisplayName = timezone.DisplayName, Name = timezone.Id });
                destinationList.Add(new Binding() { DisplayName = timezone.DisplayName, Name = timezone.Id });
            }

            // Source
            cboSourceTimezone.ValueMember = null;
            cboSourceTimezone.DisplayMember = "DisplayName";
            cboSourceTimezone.DataSource = sourceList;

            // Destination
            cboDestinationTimezone.ValueMember = null;
            cboDestinationTimezone.DisplayMember = "DisplayName";
            cboDestinationTimezone.DataSource = destinationList;
        }

        #region Toolbar Events
        /// <summary> Proceed toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Process if there is something to process</remarks>
        private void btnProceed_Click(object sender, EventArgs e)
        {
            //var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
            //              .Except(CultureInfo.GetCultures(CultureTypes.SpecificCultures));
        }

        /// <summary> Exit toolbar button </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event Args</param>
        /// <remarks>Exit utility </remarks>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary> Display Help toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Display wiki link
            //System.Diagnostics.Process.Start(Properties.Resources.Browser, Properties.Resources.WikiLink);
        }
       #endregion

        /// <summary> Generic routine for displaying a message dialog </summary>
        /// <param name="message">Message to display</param>
        /// <param name="icon">Icon to display</param>
        /// <param name="args">Message arguments, if any</param>
        private void DisplayMessage(string message, MessageBoxIcon icon, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), Text, MessageBoxButtons.OK, icon);
        }

        /// <summary> Get source culture to display format</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void cboSourceLocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            var culture = ((Binding) ((ComboBox) sender).SelectedItem).Name;
            txtSourceFormat.Text = CultureInfo.GetCultureInfo(culture).DateTimeFormat.ShortDatePattern;
            datTimePicker.CustomFormat = txtSourceFormat.Text;
        }

        /// <summary> Get destination culture to display format</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void cboDestinationLocale_SelectedIndexChanged(object sender, EventArgs e)
        {
            var culture = ((Binding)((ComboBox)sender).SelectedItem).Name;
            txtDestinationFormat.Text = CultureInfo.GetCultureInfo(culture).DateTimeFormat.ShortDatePattern;
        }

        /// <summary> Set culture and format date for display</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void datTimePicker_Validated(object sender, EventArgs e)
        {
            // Set culture to one selected for source
            var culture = ((Binding) (cboSourceLocale).SelectedItem).Name;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);

            // Display selected date
            var date = datTimePicker.Value;

            txtSourceOutput.Text = GetShortDate(date.Date.ToString(CultureInfo.CurrentCulture), string.Empty);
            string test = "18991230";
            var test1 = GetShortDate(test, string.Empty, true);

            var jt1 = DateTime.MinValue;
            var jt2 = new DateTime();
            var jt3 = default(DateTime);
            //var jt4 = DateTime.Parse(null);
            //var jt5 = DateTime.Parse(string.Empty);
            var jt6 = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
            var jt7 = date.ToShortDateString();
            var jt8 = date.ToString(jt6);
            DateTime jt9 = DateTime.Now;
            //var jt10 = Convert.ToDateTime(date.ToShortDateString()).ToString("MMddyyyy");
            DateTime dt;
            var jt10 = DateTime.TryParse(date.ToShortDateString(), out dt);
            var jt11 = dt.ToString("MMddyyyy");
            var jt12 = DateTime.Parse(date.ToShortDateString()).ToString(CultureInfo.CurrentCulture);
            var jt13 = GetShortDate(date.ToShortDateString(), string.Empty);
            var jt14 = default(DateTime);

            txtSourceDate.Text = date.Date.ToString(CultureInfo.CurrentCulture);

            var yyyymmdd = DateTime.Parse(txtSourceDate.Text);
            txtSourceDateYYYYMMDD.Text = string.Format("{0:yyyyMMdd}", yyyymmdd.Year.ToString() + yyyymmdd.Month + yyyymmdd.Day);

            // Destination
            culture = ((Binding)(cboDestinationLocale).SelectedItem).Name;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);

            // Display selected date

            txtDestinationOutput.Text = GetShortDate(date.Date.ToString(CultureInfo.CurrentCulture), string.Empty);
            txtDestinationDate.Text = date.Date.ToString(CultureInfo.CurrentCulture);

            yyyymmdd = DateTime.Parse(txtDestinationDate.Text);
            txtDestinationDateYYYYMMDD.Text = string.Format("{0:yyyyMMdd}", yyyymmdd.Year.ToString() + yyyymmdd.Month + yyyymmdd.Day);

        }

        /// <summary>
        /// Data Format
        /// </summary>
        /// <returns></returns>
        public static string DateFormat
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            }
        }

        /// <summary>
        /// Date Pattern
        /// </summary>
        /// <returns></returns>
        public static string DatePattern
        {
            get
            {
                return
                    DateFormat.Replace("-", string.Empty)
                    .Replace(".", string.Empty)
                    .Replace(" ", string.Empty)
                    .Replace("/", string.Empty);
            }
        }

        /// <summary>
        /// Returns Month-Day only format
        /// </summary>
        public static string MonthDayFormat
        {
            get
            {
                var result = DateFormat.Replace("y", "");
                return result.Trim(DateSeparator.ToCharArray());
            }
        }

        /// <summary>
        /// Date separator
        /// </summary>
        public static string DateSeparator
        {
            get
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            }
        }

        #endregion

        /// <summary>
        /// Get a Short date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <remarks>Short Date format is controlled by region settings</remarks>
        /// <returns>Short Date String or default value</returns>
        public static string GetShortDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.ToShortDateString() : defaultValue;
        }

        /// <summary>
        /// Get a Short date
        /// </summary>
        /// <param name="date">Date value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <remarks>Short Date format is controlled by region settings</remarks>
        /// <returns>Short Date String or default value</returns>
        public static string GetShortDate(DateTime date, string defaultValue)
        {
            // Return default or date
            return IsMinimumDate(date) ? defaultValue : date.ToShortDateString();
        }

        /// <summary>
        /// Get a Long date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <remarks>Long Date format is controlled by region settings</remarks>
        /// <returns>Long Date String or default value</returns>
        public static string GetLongDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.ToLongDateString() : defaultValue;
        }

        /// <summary>
        /// Get a Long date
        /// </summary>
        /// <param name="date">Date value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <remarks>Long Date format is controlled by region settings</remarks>
        /// <returns>Long Date String or default value</returns>
        public static string GetLongDate(DateTime date, string defaultValue)
        {
            // Return default or date
            return IsMinimumDate(date) ? defaultValue : date.ToLongDateString();
        }

        /// <summary>
        /// Get a Year Month Day date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Year Month Day Date String or default value</returns>
        public static string GetYearMonthDayDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToYearMonthDay(date) : defaultValue;
        }

        /// <summary>
        /// Get a Year Month Day date
        /// </summary>
        /// <param name="date">Potentially null date time value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <returns>Year Month Day Date String or default value</returns>
        public static string GetYearMonthDayDate(DateTime? date, string defaultValue)
        {
            // Validate and return
            return IsMinimumDate(date) ? defaultValue : ConvertToYearMonthDay(Convert.ToDateTime(date));
        }

        /// <summary>
        /// Get a Year Month Day date
        /// </summary>
        /// <param name="date">Date value</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <returns>Year Month Day Date String or default value</returns>
        public static string GetYearMonthDayDate(DateTime date, string defaultValue)
        {
            // Validate and return
            return IsMinimumDate(date) ? defaultValue : ConvertToYearMonthDay(date);
        }

        /// <summary>
        /// Get a Max Year Month Day date
        /// </summary>
        /// <returns>Max Year Month Day Date String</returns>
        public static string GetYearMonthDayMaxDate()
        {
            // Return max date
            return ConvertToYearMonthDay(DateTime.MaxValue);
        }

        /// <summary>
        /// Get a Month Day Year date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Month Day Year Date String or default value</returns>
        public static string GetMonthDayYearDate(string value, string defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToMonthDayYear(date) : defaultValue;
        }

        /// <summary>
        /// Get a Month Day Year date
        /// </summary>
        /// <param name="date">Potentially null date time value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <returns>Month Day Year Date String or default value</returns>
        public static string GetMonthDayYearDate(DateTime? date, string defaultValue)
        {
            // Validate and return
            return IsMinimumDate(date) ? defaultValue : ConvertToMonthDayYear(Convert.ToDateTime(date));
        }

        /// <summary>
        /// Get a Month Day Year date
        /// </summary>
        /// <param name="date">Date value</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <returns>Month Day Year Date String or default value</returns>
        public static string GetMonthDayYearDate(DateTime date, string defaultValue)
        {
            // Validate and return
            return IsMinimumDate(date) ? defaultValue : ConvertToMonthDayYear(date);
        }

        /// <summary>
        /// Get a date
        /// </summary>
        /// <param name="date">Potentially null date time value of date</param>
        /// <param name="defaultValue">Default value if date is null</param>
        /// <returns>Date</returns>
        public static DateTime? GetDate(DateTime? date, DateTime? defaultValue)
        {
            // Validate and return
            return IsMinimumDate(date) ? defaultValue : date;
        }

        /// <summary>
        /// Get a date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Date</returns>
        public static DateTime GetDate(string value, DateTime defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? date : defaultValue;
        }

        /// <summary>
        /// Get a date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Date</returns>
        public static DateTime? GetDate(string value, DateTime? defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? date : defaultValue;
        }

        /// <summary>
        /// Get a date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="format">Format of date string</param>
        /// <returns>Date</returns>
        public static DateTime GetDate(string value, DateTime defaultValue, string format)
        {
            // Return default if no value entered to convert
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, true, format, out date) ? date : defaultValue;
        }

        /// <summary>
        /// Get a date in specified format
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="format">Outout format for date</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Date in specified fromat</returns>
        public static string GetDate(string value, string defaultValue, string format, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? ConvertToFormat(date, format) : defaultValue;
        }

        /// <summary>
        /// Get Ticks in date
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="defaultValue">Default value if value is not a date or is null/empty/blank</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <returns>Ticks</returns>
        public static long GetTicks(string value, long defaultValue, bool isYearMonthDayFormat = false)
        {
            // Return default if no value entered to parse
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            // Parse, validate and return
            DateTime date;
            return IsDateValid(value, isYearMonthDayFormat, out date) ? date.Ticks : defaultValue;
        }

        /// <summary>
        /// Get the starting date for the week based upon the entered date
        /// </summary>
        /// <param name="date">Date to determine the starting date of the week</param>
        /// <returns>Starting date of the week</returns>
        /// <remarks>Saturday is considered to be the start of the week</remarks>
        public static DateTime GetWeekStartingDate(DateTime date)
        {
            // Return var and get day of the week
            DateTime startDate;
            var dayOfWeek = date.DayOfWeek;

            // Determine start date of week
            if (dayOfWeek.Equals(DayOfWeek.Saturday))
            {
                startDate = date;
            }
            else if (dayOfWeek.Equals(DayOfWeek.Sunday))
            {
                startDate = date.AddDays(-1);
            }
            else
            {
                startDate = date.AddDays(-(int)dayOfWeek - 1);
            }

            return startDate;
        }

        /// <summary>
        /// Is date a minimum date
        /// </summary>
        /// <param name="date">Date</param>
        /// <remarks>Minimum date is defined by date object (1/1/0001) or 12/30/1899</remarks>
        /// <returns>True if date is a minimum date otherwise false</returns>
        public static bool IsMinimumDate(DateTime? date)
        {
            // Is it a minimum date?
            return !date.HasValue || IsMinimumDate(Convert.ToDateTime(date));
        }

        /// <summary>
        /// Is date a minimum date
        /// </summary>
        /// <param name="date">Date</param>
        /// <remarks>Minimum date is defined by date object (1/1/0001) or 12/30/1899</remarks>
        /// <returns>True if date is a minimum date otherwise false</returns>
        public static bool IsMinimumDate(DateTime date)
        {
            return (date == default(DateTime) ||
                    (date.Year.Equals(1899) && date.Month.Equals(12) && date.Day.Equals(30)));
        }

        /// <summary>
        /// Is Date valid
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="isYearMonthDayFormat">True if value is in yyyyMMdd format otherwise false</param>
        /// <param name="date">Output date</param>
        /// <returns>True if date is valid otherwise false</returns>
        public static bool IsDateValid(string value, bool isYearMonthDayFormat, out DateTime date)
        {
            return IsDateValid(value, isYearMonthDayFormat, "yyyyMMdd", out date);
        }

        /// <summary>
        /// Is Date valid
        /// </summary>
        /// <param name="value">String value of date</param>
        /// <param name="useDateFormat">True to use date format otherwise false</param>
        /// <param name="format">Date Format</param>
        /// <param name="date">Output date</param>
        /// <returns>True if date is valid otherwise false</returns>
        public static bool IsDateValid(string value, bool useDateFormat, string format, out DateTime date)
        {
            // Parse date base upon format
            var isValid = useDateFormat ?
                DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date) :
                DateTime.TryParse(value, out date);

            // Extra validation for minimum date!
            if (isValid && IsMinimumDate(date))
            {
                // It is a minimum date therefore it is invalid
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Convert Date to Year Month Day
        /// </summary>
        /// <param name="date">Date value</param>
        /// <returns>Year Month Day Date String</returns>
        public static string ConvertToYearMonthDay(DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Convert Date to Month Day Year
        /// </summary>
        /// <param name="date">Date value</param>
        /// <returns>Month Day Year Date String</returns>
        public static string ConvertToMonthDayYear(DateTime date)
        {
            return date.ToString("MMddyyyy");
        }

        /// <summary>
        /// Convert Date to Specified Format
        /// </summary>
        /// <param name="date">Date value</param>
        /// <param name="format">Date format</param>
        /// <returns>Date String in specified format</returns>
        public static string ConvertToFormat(DateTime date, string format)
        {
            return date.ToString(format);
        }


        private void lblSourceTimezone_Click(object sender, EventArgs e)
        {

        }

        private void datTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }






    }

    public class Binding
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }
}
