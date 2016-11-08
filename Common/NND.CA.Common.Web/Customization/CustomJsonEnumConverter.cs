/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Newtonsoft.Json;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Newtonsoft.Json.Converters;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Customization
{
    /// <summary>
    /// Custom String Enum Converter, this converter will be used when we serialize the data from server to client.
    /// Enum value will get serialized to char when the enum has attiribute [StoredAsChar]
    /// </summary>
    public class CustomJsonEnumConverter : StringEnumConverter
    {
        /// <summary>
        /// Writes the json.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueType = value.GetType();

            if (valueType.IsEnum)
            {
                var enumField = valueType.GetField(value.ToString());

                if (EnumUtility.IsChar(enumField))
                {
                    // since enum has [StoredAsChar] attribute convert the value to char.
                    writer.WriteValue(EnumUtility.EnumToString(value));
                    return;
                }

                // since enum DO NOT have [StoredAsChar] attribute convert the value to int32.
                writer.WriteValue(Convert.ToInt32(value));
                return;

            }

            // write default value.
            base.WriteJson(writer, value, serializer);
        }
    }
}
