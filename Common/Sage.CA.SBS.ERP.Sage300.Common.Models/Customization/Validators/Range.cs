/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class Range.
    /// </summary>
    public class Range : Validator
    {
        /// <summary>
        /// Maximum value
        /// </summary>
        /// <value>The maximum.</value>
        [XmlAttribute]
        public double Maximum { get; set; }

        /// <summary>
        /// Minimum value
        /// </summary>
        /// <value>The minimum.</value>
        [XmlAttribute]
        public double Minimum { get; set; }

        /// <summary>
        /// Type of attribute
        /// </summary>
        /// <value>The type of the attribute.</value>
        public override Type AttributeType
        {
            get { return typeof (RangeAttribute); }
        }

        /// <summary>
        /// Get Range attribute
        /// </summary>
        /// <returns>Attribute.</returns>
        public override Attribute GetAttribute()
        {
            return new RangeAttribute(Minimum, Maximum) {ErrorMessage = ErrorMessage};
        }

        /// <summary>
        /// True if the new validator valid
        /// </summary>
        /// <param name="existingAttribute">The existing attribute.</param>
        /// <returns><c>true</c> if the specified existing attribute is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid(Attribute existingAttribute)
        {
            return true;
        }
    }
}