// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region

using System;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Class CommonUtil.
    /// </summary>
    public static class CommonUtil
    {
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int GetUserDefaultLocaleName(StringBuilder lpBuffer, UInt32 uiSize);

        /// <summary>
        /// This method is created to work around a problem in C# library where
        /// we cannot retrieve the default locale information once the culture
        /// has been overriden in a thread
        /// </summary>
        /// <returns>Default Culture set in Windows's regional setting</returns>
        internal static CultureInfo GetUserDefaultCultureInfo()
        {
            var sbBuffer = new StringBuilder(1024);
            return GetUserDefaultLocaleName(sbBuffer, (UInt32)sbBuffer.Capacity) > 0 ? CultureInfo.GetCultureInfoByIetfLanguageTag(sbBuffer.ToString()) : null;
        }

        /// <summary>
        /// Clone the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">object ot clone</param>
        /// <returns>T(Cloned Object)</returns>
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// Read the xml file and  Deserailize object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">Path of xml file</param>
        /// <returns>T</returns>
        public static T DeSerialize<T>(string filePath)
        {
            try
            {
                T obj;
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = XmlReader.Create(new Uri(filePath).LocalPath))
                {
                    obj = (T)serializer.Deserialize(reader);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
        /// <summary>
        /// Comoutes Start Index
        /// </summary>
        /// <param name="currentPageNumber">Current PageNumber</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>int</returns>
        public static int ComputeStartIndex(int? currentPageNumber, int? pageSize)
        {
            int startIndex = 0;
            if (currentPageNumber.HasValue && pageSize.HasValue)
            {
                if (currentPageNumber >= 0)
                {
                    startIndex = (currentPageNumber.Value * pageSize.Value) + 1;
                }
                else
                {
                    startIndex = 1;
                }
            }
            return startIndex;
        }

        /// <summary>
        /// Computes EndIndex
        /// </summary>
        /// <param name="currentPageNumber">Current PageNumber</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="totalRecords">Total Records</param>
        /// <returns>int</returns>
        public static int ComputeEndIndex(int? currentPageNumber, int? pageSize, int? totalRecords)
        {
            int endIndex;
            if (currentPageNumber.HasValue && pageSize.HasValue)
            {
                if (currentPageNumber >= 0 || totalRecords == null)
                {
                    int startIndex = (currentPageNumber.Value * pageSize.Value) + 1;
                    endIndex = (startIndex + pageSize.Value) - 1;
                }
                else
                {
                    endIndex = totalRecords.Value + 1;
                }
            }
            else
            {
                endIndex = totalRecords.HasValue ? totalRecords.Value + 1 : int.MaxValue;
            }
            return endIndex;
        }

        /// <summary>
        /// To pad zero's either leading or trailing
        /// </summary>
        /// <param name="value">string value</param>
        /// <param name="length">Length</param>
        /// <param name="padLeft">Pad Left</param>
        /// <param name="padChar">Pad Char</param>
        /// <returns>string</returns>
        public static string Pad(string value, int length, bool padLeft = false, char padChar = '0')
        {
            var paddedValue = padLeft ? value.PadLeft(length, padChar) : value.PadRight(length, padChar);
            return paddedValue;
        }

        /// <summary>
        /// To remove all the leading zero's
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="padChar">Pad Character</param>
        /// <returns>string</returns>
        public static string TrimStartZero(string number, char padChar = '0')
        {
            return number.TrimStart(padChar);
        }

        /// <summary>
        /// To get redundant character as text for the length specified
        /// </summary>
        /// <param name="c">Character</param>
        /// <param name="n">Length</param>
        /// <returns>System.String.</returns>
        public static string Repeat(char c, int n)
        {
            return new String(c, n);
        }

        /// <summary>
        ///  Converts the value base on the Data type Selected For Trial Balnce,TDOF,COA and TL Report generation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetReportOptionalValue(string value, string type)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (type == "3") //For Data Type Date
                {
                    value = DateUtil.GetYearMonthDayDate(value, string.Empty);
                }
                if (type == "100" || type == "6" || type == "8") //For Data Type Amount,number & integer
                {
                    value = value.Replace(",", string.Empty).Trim();
                }
                if (type == "4") //For Data Type Time
                {
                    value = value.Replace(":", string.Empty).Trim();
                }
                if (type == "9") //For Data Type Yes/No
                {
                    value = value.ToUpperInvariant() == "YES" ? "1" : "0";
                }
            }

            return value;
        }

        /// <summary>
        /// To do string comparison and return integer
        /// </summary>
        /// <param name="to">To</param>
        /// <param name="from">From</param>
        /// <param name="cultureInfo">Culture Info</param>
        /// <param name="compareOptions">The compare options.</param>
        /// <returns>int</returns>
        public static int StrCompare(string to, string from, CultureInfo cultureInfo, CompareOptions compareOptions)
        {
            return string.Compare(to, from, cultureInfo, compareOptions);
        }

        /// <summary>
        /// Used for getting default value for a decimal number based on the precision
        /// </summary>
        /// /// <param name="number"></param>
        /// <param name="totalLength"></param>
        /// <param name="precision"></param>
        /// <param name="negative"></param>
        /// <returns></returns>
        public static string GetDecimalDefaultFormat(char number, int totalLength, int precision, bool negative)
        {
            int intPart = totalLength - precision;
            string numberFormat = string.Format("{0}{1}{2}{3}", negative ? "-" : string.Empty, Repeat(number, intPart),
                precision > 0 ? "." : string.Empty, Repeat(number, precision));
            numberFormat = negative ? numberFormat : numberFormat.Trim();
            return numberFormat;
        }

        /// <summary>
        /// To get decimal regular expression
        /// </summary>
        /// <param name="totalLength"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static string GetDecimalRegularExpression(int totalLength, int precision)
        {
            int intPart = totalLength - precision;
            if (precision > 0)
            {
                return string.Format(@"^[-|\s]\d{{1,{0}}}(\.\d{{1,{1}}})?", intPart, precision);
            }
            return string.Format(@"^[-|\s]\d{{1,{0}}}", intPart);
        }

        /// <summary>
        /// To compose AND filter
        /// </summary>
        /// <param name="expr1">Expression Boolean Value</param>
        /// <param name="expr2">Expression Boolean Value</param>
        /// <returns>Expression Boolean Value</returns>
        public static Expression<Func<TFilterBase, bool>> BuildFilterExpressions<TFilter, TFilterBase>(
            Expression<Func<TFilter, bool>> expr1, Expression<Func<TFilterBase, bool>> expr2)
        {
            Expression<Func<TFilterBase, bool>> resultFilter = null;

            if (expr1 != null && expr2 != null)
            {
                ParameterExpression param = expr2.Parameters[0];
                var expbody = Expression.AndAlso(expr1.Body, expr2.Body);
                resultFilter = Expression.Lambda<Func<TFilterBase, bool>>(expbody, param);
            }
            return resultFilter;
        }

        /// <summary>
        /// Removes the delimeter.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns>formatted string output</returns>
        public static string RemoveDelimeter(string accountNumber)
        {
            var value = accountNumber.Replace("-", string.Empty);
            value = value.Replace("/", string.Empty);
            value = value.Replace("'\'", string.Empty);
            value = value.Replace("*", string.Empty);
            value = value.Replace(".", string.Empty);

            return value;
        }

        /// <summary>
        /// Retrieves the status of the Entity Return Code
        /// </summary>
        /// <param name="returnCode"></param>
        /// <returns></returns>
        public static bool IsViewError(int returnCode)
        {
            return false;
        }

        /// <summary>
        /// Retrieves the status of the Entity Return Code
        /// </summary>
        /// <param name="returnCode">returnCode</param>
        /// <returns>Boolean</returns>
        public static bool IsViewSuccess(int returnCode)
        {
            if (returnCode <= Constant.ErrnumSuccess || returnCode == Constant.ErrnumWarning)
            { return true; }
            return false;
        }

        /// <summary>
        /// Convert string to Guid
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>Guid</returns>
        public static Guid StringToGuid(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            return new Guid(data);
        }

        /// <summary>
        /// Set Culture
        /// <param name="cultureName">Name of the culture</param>
        /// </summary>
        public static void SetCulture(string cultureName)
        {
            var ci = CultureInfo.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = ci;
            var customCulture = (CultureInfo)ci.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            customCulture.NumberFormat.NumberGroupSeparator = ",";
            customCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            customCulture.NumberFormat.CurrencyGroupSeparator = ",";
            customCulture.NumberFormat.PercentDecimalSeparator = ".";
            customCulture.NumberFormat.PercentGroupSeparator = ",";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }

        /// <summary>
        /// Scan a given string, and strip out all extraneous characters (mainly punctuation)
        /// Retain only letters and digits (optionally, retain "&",  "-" and " " as well)
        /// </summary>
        /// <param name="input">An Input String</param>
        /// <param name="keepDash">Whether to keep Hyphen (-) symbol</param>
        /// <param name="keepAmp"></param>
        /// <param name="keepSpace"></param>
        /// <returns></returns>
        public static string StripSpecialChars(string input, bool keepDash, bool keepAmp, bool keepSpace)
        {
            var result = string.Empty;
            var temp = result;

            if (!string.IsNullOrEmpty(input))
            {
                temp = input.Trim().ToUpper();

                var pattern = "[^A-Z0-9" + (keepAmp ? "&" : string.Empty) + (keepSpace ? @"\s" : string.Empty) + (keepDash ? "-" : string.Empty) + "]";

                Regex expression = new Regex(pattern);

                result = expression.Replace(temp, string.Empty);
            }

            return result;

        }

        /// <summary>
        /// Formats the Phone/Fax Number.
        /// </summary>
        /// <param name="phoneNumber">Phone/Fax Number</param>
        /// <returns>Formatted Phone/Fax Number</returns>
        public static string FormatPhoneNumber(string phoneNumber)
        {
            var format = "{0:(###) ### - ";
            var repeat = phoneNumber.Length - 6;
            format = String.Concat(format, String.Concat(Enumerable.Repeat('#', repeat > 0 ? repeat : 0)), "}");
            double parsePhoneNumber;
            double.TryParse(phoneNumber, out parsePhoneNumber);
            var formattedNumber = String.Format(format, parsePhoneNumber);
            return formattedNumber;
        }

        /// <summary>
        /// Get Executing Assembly folder path
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyDirectory()
        {
            var uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}