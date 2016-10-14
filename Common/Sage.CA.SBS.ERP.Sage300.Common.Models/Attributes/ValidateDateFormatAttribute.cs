/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes
{
    /// <summary>
    /// Attribute to validate date format
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateDateFormatAttribute : ValidationAttribute
    {
        /// <summary>
        /// This returns always true. This is only required to validate date format on client side
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    /// <summary>
    /// Attribute to validate date and check for format when not null
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateDateFormatAllowNullAttribute : ValidationAttribute
    {
        /// <summary>
        /// This returns always true. This is only required to validate date format on client side
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }

    public enum ModuleName
    {
        AP, AR, AS, CS, GL, IC, PO, OE
    }

    /// <summary>
    /// Attribute to validate Fiscal Period
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateFiscalPeriodAttribute : ValidationAttribute
    {
        public ModuleName ModuleName { get; set; }
        public ValidateFiscalPeriodAttribute(ModuleName module)
        {
            ModuleName = module;
        }

        /// <summary>
        /// This returns always true. This is only required to validate fiscal period
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var fiscalPeriod = value.ToString();
                int result;
                var isInt = Int32.TryParse(fiscalPeriod, out result);
                if (!isInt)
                {
                    switch (ModuleName)
                    {
                        case ModuleName.GL:
                            return (fiscalPeriod.ToUpper() == "CLS" || fiscalPeriod.ToUpper() == "ADJ");
                        default:
                            return false;
                    }

                }
                return true;
            }
            return true;
        }
    }

}