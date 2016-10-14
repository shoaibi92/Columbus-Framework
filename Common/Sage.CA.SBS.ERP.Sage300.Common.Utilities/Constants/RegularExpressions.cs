// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants
{
    /// <summary>
    /// Regular Expressions Constants
    /// </summary>
    public class RegularExpressions
    {
        /// <summary>
        /// The numeric expression
        /// </summary>
        public const string OnlyNumeric = "^[0-9]*$";

        /// <summary>
        /// From time Format
        /// </summary>
        public const string TimeFormatFrom = @"(\w{2})(\w{2})(\w{2})";

        /// <summary>
        ///  To time Format
        /// </summary>
        public const string TimeFormatTo = @"$1:$2:$3";
    }
}