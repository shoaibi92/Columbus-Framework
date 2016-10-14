/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi
{
    /// <summary>
    /// Helper class to parse entity keys
    /// </summary>
    public class EntityKeyParser
    {
        private const char Encloser = '\'';
        private const char Separator = ',';
        private const char Equality = '=';

        /// <summary>
        /// Parse a raw entity key string (as passed in through an OData request) a list of key value pairs
        /// </summary>
        /// <param name="key">The raw entity key passed into the request</param>
        /// <returns></returns>
        public static List<KeyValuePair<string, object>> ParseKeySegments(string key)
        {
            // break up the string into segments using Separators that are not enclosed (e.g. "a=b, c=d" => {"a=b", "c=d"})
            var results = new List<KeyValuePair<string, object>>();
            var pattern = new Regex("(?:^|" + Separator + ")(" + Encloser + "(?:[^" + Encloser + "]+|" + Encloser + Encloser + ")*" + Encloser + "|[^" + Separator + "]*)", RegexOptions.Compiled);
            foreach (Match match in pattern.Matches(key))
            {
                if (match.Value.Length == 0)
                    throw new ArgumentException("Invalid entity key!");

                results.Add(ParseKeySegment(match.Value.TrimStart(Separator))); // for each segment separated, parse out the key and value pair
            }
            return results;
        }

        /// <summary>
        /// Parse the key value pair from a key segment specification
        /// </summary>
        /// <param name="segment">a string that represents a key value specification</param>
        /// <returns></returns>
        private static KeyValuePair<string, object> ParseKeySegment(string segment)
        {
            // break up the segment into key and value pairs
            var pattern = new Regex("(?:^|" + Equality + ")(" + Encloser + "(?:[^" + Encloser + "]+|" + Encloser + Encloser + ")*" + Encloser + "|[^" + Equality + "]*)", RegexOptions.Compiled);
            var matches = pattern.Matches(segment);
            if (matches.Count > 2)
                throw new ArgumentException("Invalid entity key!");
            var key = "";
            if (matches.Count == 2)
            {
                key = matches[0].Value.Trim();
            }
            var value = Unescape(matches[matches.Count - 1].Value.TrimStart(Equality));
            return new KeyValuePair<string, object>(key, value);
        }

        /// <summary>
        /// Unescapes a string value which may or may not be enclosed
        /// </summary>
        /// <param name="value">The string being unescaped</param>
        /// <returns></returns>
        private static string Unescape(string value)
        {
            var doubleEncloser = new string(Encloser, 2);
            var temp = value.Trim().Replace(doubleEncloser, "");
            if (temp.Length > 1 && (temp[0] == Encloser && temp[temp.Length - 1] == Encloser))
            {
                temp = value.Trim();
                return temp.Substring(1, temp.Length - 2).Replace(doubleEncloser, char.ToString(Encloser));
            }
            return value.Replace(doubleEncloser, char.ToString(Encloser));
        }
    }
}
