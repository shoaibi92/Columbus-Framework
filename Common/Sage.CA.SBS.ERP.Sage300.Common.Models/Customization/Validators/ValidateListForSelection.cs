/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators
{
    /// <summary>
    /// Class ValidateListForSelection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateListForSelection : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateListForSelection"/> class.
        /// </summary>
        public ValidateListForSelection() : base(() => CommonResx.NoOptionSelectedMessage) { }

        /// <summary>
        /// Provide a different implementaiton for IsValid function
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns>Function Result</returns>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var list = value as List<MultiSelect>;

                // ReSharper disable once LoopCanBeConvertedToQuery
                if (list != null)
                {
                    foreach (var listItem in list)
                    {
                        if (listItem.isSelected && !listItem.Disabled)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Format the error message
        /// </summary>
        /// <param name="name">Input message</param>
        /// <returns>Formatted message</returns>
        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name);
        }
    }
}