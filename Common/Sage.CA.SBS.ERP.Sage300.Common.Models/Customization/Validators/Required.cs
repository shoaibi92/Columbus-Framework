/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class Required.
    /// </summary>
    public class Required : Validator
    {
        /// <summary>
        /// Get the attribute
        /// </summary>
        /// <returns>Attribute.</returns>
        public override Attribute GetAttribute()
        {
            return new RequiredAttribute {ErrorMessage = ErrorMessage};
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

        /// <summary>
        /// Type of attribute
        /// </summary>
        /// <value>The type of the attribute.</value>
        public override Type AttributeType
        {
            get { return typeof (RequiredAttribute); }
        }
    }
}