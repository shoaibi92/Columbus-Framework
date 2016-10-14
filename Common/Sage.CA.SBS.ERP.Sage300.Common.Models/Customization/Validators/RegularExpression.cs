/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class RegularExpression.
    /// </summary>
    public class RegularExpression : Validator
    {
        /// <summary>
        /// Regular Expression
        /// </summary>
        /// <value>The pattern.</value>
        [XmlAttribute]
        public string Pattern { get; set; }

        /// <summary>
        /// Get Regular Expression Attribute
        /// </summary>
        /// <returns>Attribute.</returns>
        public override Attribute GetAttribute()
        {
            return new RegularExpressionAttribute(Pattern) {ErrorMessage = ErrorMessage};
        }

        /// <summary>
        /// Is the new validator valid
        /// </summary>
        /// <param name="existingAttribute">The existing attribute.</param>
        /// <returns><c>true</c> if the specified existing attribute is valid; otherwise, <c>false</c>.</returns>
        public override bool IsValid(Attribute existingAttribute)
        {
            return true;
        }

        /// <summary>
        /// Type of attribute
        /// </summary>
        /// <value>The type of the attribute.</value>
        public override Type AttributeType
        {
            get { return typeof (RegularExpressionAttribute); }
        }
    }
}