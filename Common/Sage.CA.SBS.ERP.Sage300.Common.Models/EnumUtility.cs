/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains methods for Enum String
    /// </summary>
    public static class EnumUtility
    {
        /// <summary>
        /// Uses the StoredAsChar attribute to convert an Enum object to a string.
        /// Returns an empty string if its corresponding field can't be found.
        /// </summary>
        /// <param name="enumObj">Enum object.</param>
        /// <returns>System.String.</returns>
        public static string EnumToString(object enumObj)
        {
            // Convert from enumType to int.
            var enumInt = Convert.ToInt32(enumObj);

            // Use reflection to determine if enumObj stored its value as a char.
            var enumType = enumObj.GetType();
            var enumField = enumType.GetField(enumObj.ToString());

            if (enumField != null)
            {
                if (IsChar(enumField))
                {
                    // It's stored as a char, so cast from int to char to string.
                    return ((char)enumInt).ToString(CultureInfo.InvariantCulture);
                }

                // Else, the attribute wasn't found or it's stored as an int, so just
                // cast directly from int to string.
                return enumInt.ToString(CultureInfo.InvariantCulture);
            }
            // Else, the corresponding field can't be found, so return an empty string.
            return string.Empty;
        }

        /// <summary>
        /// Enums the has stored as character attribute.
        /// </summary>
        /// <param name="enumField">The enum field.</param>
        /// <returns></returns>
        public static bool IsChar(FieldInfo enumField)
        {
            if (enumField != null)
            {
                var attrs = enumField.GetCustomAttributes(typeof(StoredAsChar), false) as StoredAsChar[];
                if (attrs != null && attrs.Length > 0 && attrs[0].IsChar)
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Gets String Value
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>System.String.</returns>
        public static string GetStringValue(Enum value)
        {
            string output = null;
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            if (fi != null)
            {
                var attrs = fi.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];

                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
                return output;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets enum value
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>System.String.</returns>
        public static string GetValue(Enum value)
        {
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            string output = fi.GetRawConstantValue().ToString();
            return output;
        }


        /// <summary>
        /// Get the Enum select in list by order - Extended.
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;CustomSelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<CustomSelectList> GetOrderedItemsListEx<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var list = values.Select(GetEnumItem).Where(result => result != null).ToList();

            return list.OrderBy(e => e.DisplayOrder).Select(e => new CustomSelectList { Text = e.Name, Value = e.Value.ToString() });
        }

        /// <summary>
        /// Gets the enum item.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static EnumItem GetEnumItem<TEnum>(TEnum value) where TEnum : struct
        {
            var type = value.GetType();
            var fi = type.GetField(value.ToString());
            var attrs = fi.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];

            if (attrs != null)
            {
                return new EnumItem
                {
                    Name = attrs[0].Value,
                    DisplayOrder = attrs[0].DisplayOrder,
                    Value = EnumToString(value)
                };

            }
            return null;
        }

        /// <summary>
        /// Converts to EnumList
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Dictionary&lt;Enum, System.String&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">type</exception>
        public static Dictionary<Enum, string> ToEnumList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var enumValues = Enum.GetValues(type);
            return enumValues.Cast<Enum>()
                .ToDictionary(value => value, value => GetStringValue(value) + "|" + GetValue(value));
        }

        /// <summary>
        /// Get Enum for the given Enum Type.
        /// </summary>
        /// <param name="enumType">Enum Type</param>
        /// <param name="fieldValue">Field Value</param>
        /// <returns>enum object</returns>
        public static object GetEnum(Type enumType, string fieldValue)
        {
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("TEnum must be an Enumeration type.");
            }

            if (!string.IsNullOrEmpty(fieldValue))
            {
                // Expecting if the enum value is Char then the length of fieldValue will be one 1
                // This condition is required, since it got used in many places.
                if (fieldValue.Length == 1)
                {
                    var charValue = IsStringHasNumber(fieldValue) ? Convert.ToInt32(fieldValue) : fieldValue[0];

                    return Enum.Parse(enumType, charValue.ToString(CultureInfo.InstalledUICulture));
                }

                // based on the enum value / enum name - type of enum will get parsed.
                return Enum.Parse(enumType, fieldValue);
            }

            throw new ArgumentException("fieldValue is empty.");
        }

        /// <summary>
        /// Get the Enum string based on value
        /// </summary>
        /// <typeparam name="TEnum">&gt;Enum Type</typeparam>
        /// <param name="fieldValue">Field Value</param>
        /// <returns>Return enum value</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static TEnum GetEnum<TEnum>(string fieldValue)
        {
            var enumValue = default(TEnum);
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an Enumeration type");
            }

            if (!string.IsNullOrEmpty(fieldValue))
            {
                // Expecting if the enum value is Char then the length of fieldValue will be one 1
                // This condition is required, since it got used in many places.
                if (fieldValue.Length == 1)
                {
                    var charValue = IsStringHasNumber(fieldValue) ? Convert.ToInt32(fieldValue) : fieldValue[0];

                    return (TEnum)Enum.Parse(typeof(TEnum), charValue.ToString(CultureInfo.InstalledUICulture));
                }

                // based on the enum value / enum name - type of enum will get parsed.
                return (TEnum)Enum.Parse(typeof(TEnum), fieldValue);
            }

            return enumValue;
        }

        /// <summary>
        /// Determines whether [is string has number] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsStringHasNumber(string value)
        {
            // Expecting if the input value is having 1 character then it could be Char or other ascii value.
            if (value.Length == 1)
            {
                // Convert the input value into a byte[].
                byte[] asciiBytes = Encoding.ASCII.GetBytes(value);

                //32        space     20
                //33        !         21
                //34        "         22
                //35        #         23
                //36        $         24
                //37        %         25
                //38        &         26
                //39        '         27
                //40        (         28
                //41        )         29
                //42        *         2A
                //43        +         2B
                //44        ,         2C
                //45        -         2D
                //46        .         2E
                //47        /         2F

                // take the first ascii value
                var asciiValue = asciiBytes[0];

                // Check if any of the value is between the range.
                if (asciiValue >= 32 && asciiValue <= 47)
                {
                    // return false as this is not having number.
                    return false;
                }
            }

            //true if it doesn't contain letters
            var result = value.Any(x => !char.IsLetter(x));

            return result;
        }

        /// <summary>
        /// Get the Enum select list
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;CustomSelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<CustomSelectList> GetItemsList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<CustomSelectList> items = from enumValue in values
                                                  select
                                                      new CustomSelectList
                                                      {
                                                          Text = GetStringValue(ParseEnum(enumValue)),
                                                          Value = EnumToString(enumValue)
                                                      };
            return items;
        }

        /// <summary>
        /// Get the Enum select list
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;CustomSelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<CustomSelectList> GetCharItemsList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<CustomSelectList> items = from enumValue in values
                                                  select
                                                      new CustomSelectList
                                                      {
                                                          Text = GetStringValue(ParseEnum(enumValue)),
                                                          Value = Convert.ToChar(enumValue).ToString(CultureInfo.InvariantCulture)
                                                      };
            return items;
        }

        /// <summary>
        /// Get the Enum select list
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;CustomSelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<CustomSelectList> GetIntItemsList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<CustomSelectList> items = from enumValue in values
                                                  select
                                                      new CustomSelectList
                                                      {
                                                          Text = GetStringValue(ParseEnum(enumValue)),
                                                          Value = Convert.ToInt32(enumValue).ToString(CultureInfo.InvariantCulture)
                                                      };
            return items;
        }

        /// <summary>
        /// Get the Enum select in list by order
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;CustomSelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<CustomSelectList> GetOrderedItemsList<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var list = new List<EnumItem>();

            foreach (var value in values)
            {
                var type = value.GetType();
                var fi = type.GetField(value.ToString());
                var attrs = fi.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];

                if (attrs != null)
                {
                    var item = new EnumItem
                    {
                        Name = attrs[0].Value,
                        DisplayOrder = attrs[0].DisplayOrder,
                        Value = Convert.ToInt32(value).ToString(CultureInfo.InvariantCulture)
                    };

                    list.Add(item);
                }
            }

            return
                list.OrderBy(e => e.DisplayOrder)
                    .Select(
                        e =>
                            new CustomSelectList
                            {
                                Text = e.Name,
                                Value = Convert.ToInt32(e.Value).ToString(CultureInfo.InvariantCulture)
                            });
        }

        /// <summary>
        /// Get the Enum select list
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <returns>IEnumerable&lt;SelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<SelectList> GetItems<TEnum>() where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<SelectList> items = from enumValue in values
                                            select new SelectList { Text = GetStringValue(ParseEnum(enumValue)), Value = Convert.ToInt32(enumValue) };
            return items;
        }

        /// <summary>
        /// Get the Enum select list
        /// </summary>
        /// <typeparam name="TEnum">The type of the t enum.</typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>IEnumerable&lt;SelectList&gt;.</returns>
        /// <exception cref="System.ArgumentException">TEnum must be an Enumeration type</exception>
        public static IEnumerable<SelectList> GetItems<TEnum>(object defaultValue) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<SelectList> items = from enumValue in values
                                            select
                                                new SelectList
                                                {
                                                    Text = GetStringValue(ParseEnum(enumValue)),
                                                    Value = Convert.ToInt32(enumValue),
                                                    Selected = (enumValue.Equals(defaultValue))
                                                };
            return items;
        }

        /// <summary>
        /// Parse Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="tEnum"></param>
        /// <returns></returns>
        private static Enum ParseEnum<TEnum>(TEnum tEnum)
        {
            return tEnum as Enum;
        }
    }
}