// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> Class to get and set Enum value </summary>
    public class EnumValue : Attribute
    {
        #region Public Properties
        /// <summary> Gets or sets the value </summary>
        public string Value { get; set; }
        #endregion

        #region Public Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumValue"/> class.
        /// </summary>
        /// <param name="value">the enum value</param>
        public EnumValue(string value)
        {
            Value = value;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets Value for enumeration
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Value from EnumValue</returns>
        public static string GetValue(Enum value)
        {
            // Locals
            string output = null;
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];

                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
                return output;
            }
            return string.Empty;
        }
        #endregion

    }
}