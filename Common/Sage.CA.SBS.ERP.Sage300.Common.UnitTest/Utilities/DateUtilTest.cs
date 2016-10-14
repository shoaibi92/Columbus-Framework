// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespsaces

using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Utilities
{
    /// <summary>
    /// Date Util Test class for implementing unit test methods
    /// </summary>
    [TestClass]
    public class DateUtilTest
    {
        #region Constants

        private const string MonthDayLocale = "en-US";
        private const string DayMonthLocale = "en-AU";

        private const string ShortMonthDayDate = "10/31/2015";
        private const string ShortMonthDayMinDate = "12/30/1899";
        private const string ShortMonthDayMaxDate = "12/31/9999";

        private const string ShortDayMonthDate = "31/10/2015";
        private const string ShortDayMonthMaxDate = "31/12/9999";

        private const string YearMonthDayDate = "20151031";
        private const string YearMonthDayMaxDate = "99991231";

        private const string MonthDayYear = "10312015";

        private const string LongMonthDayDate = "Saturday, October 31, 2015";
        private const string LongDayMonthDate = "Saturday, 31 October 2015";

        #endregion

        #region GetShortDate String Parameter Tests

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(ShortMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(ShortDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Year Month Day</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_3_YearMonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(YearMonthDayDate, string.Empty, true);
            // Assert
            Assert.AreEqual(ShortMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Default</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_4_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Min Date</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_5_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_6_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Year Month Day Failure</remarks>
        [TestMethod]
        public void GetShortDate_String_Test_7_YearMonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty, true);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetShortDate Date Parameter Tests

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortDate_Date_TesT_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(Convert.ToDateTime(ShortMonthDayDate), string.Empty);
            // Assert
            Assert.AreEqual(ShortMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortDate_Date_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(Convert.ToDateTime(ShortDayMonthDate), string.Empty);
            // Assert
            Assert.AreEqual(ShortDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Default</remarks>
        [TestMethod]
        public void GetShortDate_Date_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Min Date</remarks>
        [TestMethod]
        public void GetShortDate_Date_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetShortDate Object Parameter Tests

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortDate_Object_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(ShortMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortDate_Object_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(ShortDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Default</remarks>
        [TestMethod]
        public void GetShortDate_Object_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Min Date</remarks>
        [TestMethod]
        public void GetShortDate_Object_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetShortDate_Object_Test_5_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetShortDate Nullable Date Parameter Tests

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortDate_NullableDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortMonthDayDate);
            var retVal = DateUtil.GetShortDate(date, string.Empty);
            // Assert
            Assert.AreEqual(ShortMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortDate_NullableDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortDayMonthDate);
            var retVal = DateUtil.GetShortDate(date, string.Empty);
            // Assert
            Assert.AreEqual(ShortDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Default</remarks>
        [TestMethod]
        public void GetShortDate_NullableDate_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetShortDate
        /// </summary>
        /// <remarks>Evaluate GetShortDate for Min Date</remarks>
        [TestMethod]
        public void GetShortDate_NullableDate_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetShortMaxDate Tests

        /// <summary>
        /// Test method for GetShortMaxDate
        /// </summary>
        /// <remarks>Evaluate GetShortMaxDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortMaxDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortMaxDate();
            // Assert
            Assert.AreEqual(ShortMonthDayMaxDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortMaxDate
        /// </summary>
        /// <remarks>Evaluate GetShortMaxDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortMaxDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortMaxDate();
            // Assert
            Assert.AreEqual(ShortDayMonthMaxDate, retVal);
        }

        /// <summary>
        /// Test method for GetShortMaxDate
        /// </summary>
        /// <remarks>Evaluate GetShortMaxDate for Failure</remarks>
        [TestMethod]
        public void GetShortMaxDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortMaxDate();
            // Assert
            Assert.AreNotEqual(ShortDayMonthMaxDate, retVal);
        }
        #endregion

        #region GetShortNowDate Tests

        /// <summary>
        /// Test method for GetShortNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortNowDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortNowDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortNowDate();
            // Assert
            Assert.AreEqual(DateTime.Now.ToShortDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetShortNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortNowDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortNowDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortNowDate();
            // Assert
            Assert.AreEqual(DateTime.Now.ToShortDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetShortNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortNowDate for Failure</remarks>
        [TestMethod]
        public void GetShortNowDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortNowDate();
            // Assert
            Assert.AreNotEqual(ShortMonthDayMinDate, retVal);
        }
        #endregion

        #region GetShortUtcNowDate Tests

        /// <summary>
        /// Test method for GetShortUtcNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortUtcNowDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetShortUtcNowDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortUtcNowDate();
            // Assert
            Assert.AreEqual(DateTime.UtcNow.ToShortDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetShortUtcNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortUtcNowDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetShortUtcNowDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortUtcNowDate();
            // Assert
            Assert.AreEqual(DateTime.UtcNow.ToShortDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetShortUtcNowDate
        /// </summary>
        /// <remarks>Evaluate GetShortUtcNowDate for Failure</remarks>
        [TestMethod]
        public void GetShortUtcNowDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortUtcNowDate();
            // Assert
            Assert.AreNotEqual(ShortMonthDayMinDate, retVal);
        }
        #endregion

        #region GetLongDate String Parameter Tests

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(LongMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(LongDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Year Month Day</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_3_YearMonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(YearMonthDayDate, string.Empty, true);
            // Assert
            Assert.AreEqual(LongMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Default</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_4_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Min Date</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_5_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_6_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Year Month Day Failure</remarks>
        [TestMethod]
        public void GetLongDate_String_Test_7_YearMonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(ShortDayMonthDate, string.Empty, true);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetLongDate Date Parameter Tests

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetLongDate_Date_TesT_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(Convert.ToDateTime(ShortMonthDayDate), string.Empty);
            // Assert
            Assert.AreEqual(LongMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetLongDate_Date_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(Convert.ToDateTime(ShortDayMonthDate), string.Empty);
            // Assert
            Assert.AreEqual(LongDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Default</remarks>
        [TestMethod]
        public void GetLongDate_Date_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Min Date</remarks>
        [TestMethod]
        public void GetLongDate_Date_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetLongDate Nullable Date Parameter Tests

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetLongtDate_NullableDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortMonthDayDate);
            var retVal = DateUtil.GetLongDate(date, string.Empty);
            // Assert
            Assert.AreEqual(LongMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetLongtDate_NullableDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortDayMonthDate);
            var retVal = DateUtil.GetLongDate(date, string.Empty);
            // Assert
            Assert.AreEqual(LongDayMonthDate, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Default</remarks>
        [TestMethod]
        public void GetLongtDate_NullableDate_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetLongDate
        /// </summary>
        /// <remarks>Evaluate GetLongDate for Min Date</remarks>
        [TestMethod]
        public void GetLongtDate_NullableDate_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetLongMaxDate Tests

        /// <summary>
        /// Test method for GetLongMaxDate
        /// </summary>
        /// <remarks>Evaluate GetLongMaxDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetLongMaxDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongMaxDate();
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date.ToLongDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetLongMaxDate
        /// </summary>
        /// <remarks>Evaluate GetLongMaxDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetLongMaxDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongMaxDate();
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date.ToLongDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetLongMaxDate
        /// </summary>
        /// <remarks>Evaluate GetLongMaxDate for Failure</remarks>
        [TestMethod]
        public void GetLongMaxDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongMaxDate();
            // Assert
            Assert.AreNotEqual(DateTime.MinValue.Date.ToLongDateString(), retVal);
        }
        #endregion

        #region GetLongNowDate Tests

        /// <summary>
        /// Test method for GetLongNowDate
        /// </summary>
        /// <remarks>Evaluate GetLongNowDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetLongNowDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongNowDate();
            // Assert
            Assert.AreEqual(DateTime.Now.ToLongDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetLongNowDate
        /// </summary>
        /// <remarks>Evaluate GetLongNowDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetLongNowDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongNowDate();
            // Assert
            Assert.AreEqual(DateTime.Now.ToLongDateString(), retVal);
        }

        /// <summary>
        /// Test method for GetLongNowDate
        /// </summary>
        /// <remarks>Evaluate GetLongNowDate for Failure</remarks>
        [TestMethod]
        public void GetLongNowDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetLongNowDate();
            // Assert
            Assert.AreNotEqual(ShortMonthDayMinDate, retVal);
        }
        #endregion

        #region GetYearMonthDayDate String Parameter Tests

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Year Month Day</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_3_YearMonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(YearMonthDayDate, string.Empty, true);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Default</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_4_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Min Date</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_5_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_6_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Year Month Day Failure</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_String_Test_7_YearMonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortDayMonthDate, string.Empty, true);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetYearMonthDayDate Nullable Date Parameter Tests

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_NullableDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortMonthDayDate);
            var retVal = DateUtil.GetYearMonthDayDate(date, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_NullableDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortDayMonthDate);
            var retVal = DateUtil.GetYearMonthDayDate(date, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Default</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_NullableDate_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Min Date</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_NullableDate_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetYearMonthDayDate Object Parameter Tests

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Object_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Object_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Default</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Object_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Min Date</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Object_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Object_Test_4_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetYearMonthDayDate Date Parameter Tests

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Date_TesT_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(Convert.ToDateTime(ShortMonthDayDate), string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Date_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(Convert.ToDateTime(ShortDayMonthDate), string.Empty);
            // Assert
            Assert.AreEqual(YearMonthDayDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Default</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Date_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayDate for Min Date</remarks>
        [TestMethod]
        public void GetYearMonthDayDate_Date_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetYearMonthDayMaxDate Tests

        /// <summary>
        /// Test method for GetYearMonthDayMaxDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayMaxDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayMaxDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayMaxDate();
            // Assert
            Assert.AreEqual(YearMonthDayMaxDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayMaxDate
        /// </summary>
        /// <remarks>Evaluate GetShortMGetYearMonthDayMaxDateaxDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetYearMonthDayMaxDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayMaxDate();
            // Assert
            Assert.AreEqual(YearMonthDayMaxDate, retVal);
        }

        /// <summary>
        /// Test method for GetYearMonthDayMaxDate
        /// </summary>
        /// <remarks>Evaluate GetYearMonthDayMaxDate for Failure</remarks>
        [TestMethod]
        public void GetYearMonthDayMaxDateGetShortMaxDate_Test_3_Failure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetYearMonthDayMaxDate();
            // Assert
            Assert.AreNotEqual(ShortDayMonthMaxDate, retVal);
        }
        #endregion

        #region GetMonthDayYearDate String Parameter Tests

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(ShortMonthDayDate, string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Year Month Day</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_3_YearMonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(YearMonthDayDate, string.Empty, true);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Default</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_4_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Min Date</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_5_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(ShortMonthDayMinDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Month Day Failure</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_6_MonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(ShortDayMonthDate, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Year Month Day Failure</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_String_Test_7_YearMonthDayFailure()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetShortDate(ShortDayMonthDate, string.Empty, true);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetMonthDayYearDate Nullable Date Parameter Tests

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_NullableDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortMonthDayDate);
            var retVal = DateUtil.GetMonthDayYearDate(date, string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_NullableDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortDayMonthDate);
            var retVal = DateUtil.GetMonthDayYearDate(date, string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Default</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_NullableDate_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(null, string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Min Date</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_NullableDate_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetMonthDayYearDate Date Parameter Tests

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_Date_TesT_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(Convert.ToDateTime(ShortMonthDayDate), string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_Date_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(Convert.ToDateTime(ShortDayMonthDate), string.Empty);
            // Assert
            Assert.AreEqual(MonthDayYear, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Default</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_Date_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }

        /// <summary>
        /// Test method for GetMonthDayYearDate
        /// </summary>
        /// <remarks>Evaluate GetMonthDayYearDate for Min Date</remarks>
        [TestMethod]
        public void GetMonthDayYearDate_Date_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMonthDayYearDate(default(DateTime), string.Empty);
            // Assert
            Assert.AreEqual(string.Empty, retVal);
        }
        #endregion

        #region GetDate Nullable Date Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_NullableDate_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortMonthDayDate);
            var retVal = DateUtil.GetDate(date, null);
            // Assert
            Assert.AreEqual(date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetDate_NullableDate_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            DateTime? date = Convert.ToDateTime(ShortDayMonthDate);
            var retVal = DateUtil.GetDate(date, null);
            // Assert
            Assert.AreEqual(date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Default</remarks>
        [TestMethod]
        public void GetDate_NullableDate_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(null, null);
            // Assert
            Assert.AreEqual(null, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Min Date</remarks>
        [TestMethod]
        public void GetDate_NullableDate_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(default(DateTime), null);
            // Assert
            Assert.AreEqual(null, retVal);
        }
        #endregion

        #region GetDate Date Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_Date_TesT_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(Convert.ToDateTime(ShortMonthDayDate), DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortMonthDayDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetDate_Date_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(Convert.ToDateTime(ShortDayMonthDate), DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortDayMonthDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Default</remarks>
        [TestMethod]
        public void GetDate_Date_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(default(DateTime), DateTime.MaxValue.Date);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Min Date</remarks>
        [TestMethod]
        public void GetDate_Date_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(default(DateTime), DateTime.MaxValue.Date);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }
        #endregion
        
        #region GetDate String Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(ShortMonthDayDate, DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortMonthDayDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(ShortDayMonthDate, DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortDayMonthDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Min Date</remarks>
        [TestMethod]
        public void GetDate_String_Test_3_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(default(DateTime), DateTime.MaxValue.Date);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }
        #endregion

        #region GetDate Object Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_Object_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(ShortMonthDayDate, DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortMonthDayDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Day Month Locale</remarks>
        [TestMethod]
        public void GetDate_Object_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(Convert.ToDateTime(ShortDayMonthDate), DateTime.MaxValue);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortDayMonthDate).Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Default</remarks>
        [TestMethod]
        public void GetDate_Object_Test_3_Default()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate((object)null, DateTime.MaxValue.Date);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Min Date</remarks>
        [TestMethod]
        public void GetDate_Object_Test_4_MinDate()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(default(DateTime), DateTime.MaxValue.Date);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }
        #endregion

        #region GetDate String Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_1_YearMonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(YearMonthDayDate, DateTime.MaxValue, true);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortMonthDayDate).Date, retVal);
        }
        #endregion

        #region GetDate String Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_1_YearMonthDay_Nullable()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(null, DateTime.MaxValue.Date, true);
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_2_YearMonthDay_Nullable()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(null, null, true);
            // Assert
            Assert.AreEqual(null, retVal);
        }
        #endregion

        #region GetDate String Parameter Tests

        /// <summary>
        /// Test method for GetDate
        /// </summary>
        /// <remarks>Evaluate GetDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetDate_String_Test_1_MonthDay_Format()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetDate(MonthDayYear, DateTime.MaxValue, "MMddyyyy");
            // Assert
            DateTime date;
            DateTime.TryParseExact(MonthDayYear, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            Assert.AreEqual(date, retVal);
        }
        #endregion

        #region GetTicks String Parameter Tests

        /// <summary>
        /// Test method for GetTicks
        /// </summary>
        /// <remarks>Evaluate GetTicks for Month Day Locale</remarks>
        [TestMethod]
        public void GetTicks_String_Test_1_MonthDay()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetTicks(ShortMonthDayDate, 0);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortMonthDayDate).Ticks, retVal);
        }

        /// <summary>
        /// Test method for GetTicks
        /// </summary>
        /// <remarks>Evaluate GetTicks for Day Month Locale</remarks>
        [TestMethod]
        public void GetTicks_String_Test_2_DayMonth()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(DayMonthLocale);
            // Invoke Method
            var retVal = DateUtil.GetTicks(ShortDayMonthDate, 0);
            // Assert
            Assert.AreEqual(Convert.ToDateTime(ShortDayMonthDate).Ticks, retVal);
        }

        /// <summary>
        /// Test method for GetTicks
        /// </summary>
        /// <remarks>Evaluate GetTicks for Month Day Locale</remarks>
        [TestMethod]
        public void GetTicks_String_Test_3_MonthDayMin()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetTicks(ShortMonthDayMinDate, 0);
            // Assert
            Assert.AreEqual(0, retVal);
        }

        #endregion

        #region GetMinDate Tests

        /// <summary>
        /// Test method for GetMinDate
        /// </summary>
        /// <remarks>Evaluate GetMinDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetMinDate_Test_1()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMinDate();
            // Assert
            Assert.AreEqual(DateTime.MinValue.Date, retVal);
        }

        #endregion

        #region GetMaxDate Tests

        /// <summary>
        /// Test method for GetMaxDate
        /// </summary>
        /// <remarks>Evaluate GetMaxDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetMaxDate_Test_1()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetMaxDate();
            // Assert
            Assert.AreEqual(DateTime.MaxValue.Date, retVal);
        }
        #endregion

        #region GetNowDate Tests

        /// <summary>
        /// Test method for GetNowDate
        /// </summary>
        /// <remarks>Evaluate GetNowDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetNowDate_Test_1()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetNowDate();
            // Assert
            Assert.AreEqual(DateTime.Now.Date, retVal);
        }

        #endregion

        #region GetNewDate Tests

        /// <summary>
        /// Test method for GetNewDate
        /// </summary>
        /// <remarks>Evaluate GetNewDate for Month Day Locale</remarks>
        [TestMethod]
        public void GetNewDate_Test_1()
        {
            // Set Locale
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(MonthDayLocale);
            // Invoke Method
            var retVal = DateUtil.GetNewDate();
            // Assert
            Assert.AreEqual(new DateTime().Date, retVal);
        }

        #endregion

    }
}
