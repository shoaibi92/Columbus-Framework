/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class StringLength.
    /// </summary>
    public class StringLength : Validator
    {
        /// <summary>
        /// maximum
        /// </summary>
        /// <value>The maximum.</value>
        [XmlAttribute]
        public int Maximum { get; set; }

        /// <summary>
        /// minimum
        /// </summary>
        /// <value>The minimum.</value>
        [XmlAttribute]
        public int Minimum { get; set; }

        /// <summary>
        /// Get string length Attribute
        /// </summary>
        /// <returns>Attribute.</returns>
        public override Attribute GetAttribute()
        {
            return new StringLengthAttribute(Maximum) {ErrorMessage = ErrorMessage, MinimumLength = Minimum};
        }

        /// <summary>
        /// True if the new validator valid
        /// </summary>
        /// <param name="existingAttribute">The existing attribute.</param>
        /// <returns><c>true</c> if the specified existing attribute is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid(Attribute existingAttribute)
        {
            var attribute = existingAttribute as StringLengthAttribute;
            if (attribute == null)
            {
                return true;
            }
            if (Maximum <= attribute.MaximumLength & Minimum >= attribute.MinimumLength)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Type of attribute
        /// </summary>
        /// <value>The type of the attribute.</value>
        public override Type AttributeType
        {
            get { return typeof (StringLengthAttribute); }
        }
    }
}