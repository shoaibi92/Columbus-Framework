/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Abstract class for all validators
    /// </summary>
    public abstract class Validator
    {
        /// <summary>
        /// Error Message
        /// </summary>
        [XmlAttribute]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Type of attribute
        /// </summary>
        [XmlIgnore]
        public abstract Type AttributeType { get; }

        /// <summary>
        /// Get the attribute
        /// </summary>
        /// <returns></returns>
        public abstract Attribute GetAttribute();

        /// <summary>
        /// True if the new validator valid
        /// </summary>
        /// <param name="existingAttribute"></param>
        /// <returns></returns>
        public abstract bool IsValid(Attribute existingAttribute);
    }
}