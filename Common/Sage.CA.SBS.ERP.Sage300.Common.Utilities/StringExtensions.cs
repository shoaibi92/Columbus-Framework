/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Extensions for string class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// LessThanOrEqual extension
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool LessThanOrEqual(this String str, string strToCompare)
        {
            return String.Compare(str, strToCompare, StringComparison.InvariantCultureIgnoreCase) <= 0;
        }

        /// <summary>
        /// GreaterThanOrEqual extension
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool GreaterThanOrEqual(this String str, string strToCompare)
        {
            return String.Compare(str, strToCompare, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// LessThan extension
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool LessThan(this String str, string strToCompare)
        {
            return String.Compare(str, strToCompare, StringComparison.InvariantCultureIgnoreCase) < 0;
        }

        /// <summary>
        /// GreaterThan extension
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool GreaterThan(this String str, string strToCompare)
        {
            return String.Compare(str, strToCompare, StringComparison.InvariantCultureIgnoreCase) > 0;
        }

        /// <summary>
        /// Contains extension
        /// This method take care when the string is null
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool ContainsExtension(this String str, string strToCompare)
        {
            if (str == null)
            {
                str = string.Empty;
            }
            return str.IndexOf(strToCompare, StringComparison.InvariantCultureIgnoreCase) >= 0 ;
        }

        /// <summary>
        /// Starts With extension
        /// This method take care when the string is null
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool StartsWithExtension(this String str, string strToCompare)
        {
            if (str == null)
            {
                str = string.Empty;
            }
            return str.StartsWith(strToCompare, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Ends With extension
        /// This method take care when the string is null
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToCompare"></param>
        /// <returns></returns>
        public static bool EndsWithExtension(this String str, string strToCompare)
        {
            if (str == null)
            {
                str = string.Empty;
            }
            return str.EndsWith(strToCompare, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Escape quotes
        /// </summary>
        /// <param name="str">string that contains quotes</param>
        /// <returns>String without quotes</returns>
        public static string EscapeQuotes(this string str)
        {
            if (str == null)
            {
                str = string.Empty;
            }
            return str.Replace(char.ConvertFromUtf32(34), "\"\"");
        }
    }
}