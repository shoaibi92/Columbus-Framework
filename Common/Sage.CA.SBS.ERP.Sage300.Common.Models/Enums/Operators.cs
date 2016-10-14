/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Operator Class having all allowed operations
    /// </summary>
    public enum Operator
    {
        /// <summary>
        /// Operator Greater Than
        /// </summary>
        [EnumValue("GreaterThan", typeof (CommonResx))] GreaterThan = 0,

        /// <summary>
        /// Operator Greater Than or Equal
        /// </summary>
        [EnumValue("GreaterThanOrEqual", typeof (CommonResx))] GreaterThanOrEqual = 1,

        /// <summary>
        /// Operator Less Than
        /// </summary>
        [EnumValue("LessThan", typeof (CommonResx))] LessThan = 2,

        /// <summary>
        /// Operator Less Than or Equal
        /// </summary>
        [EnumValue("LessThanOrEqual", typeof (CommonResx))] LessThanOrEqual = 3,

        /// <summary>
        /// Operator Not Equal
        /// </summary>
        [EnumValue("NotEqual", typeof (CommonResx))] NotEqual = 4,

        /// <summary>
        /// Operator Equal
        /// </summary>
        [EnumValue("Equal", typeof (CommonResx))] Equal = 5,

        /// <summary>
        /// Operator Like
        /// </summary>
        [EnumValue("Like", typeof (CommonResx))] Like = 6,

        /// <summary>
        /// Operator Starts With
        /// </summary>
        [EnumValue("StartsWith", typeof (CommonResx))] StartsWith = 7,

        /// <summary>
        /// Operator Contains
        /// </summary>
        [EnumValue("Contains", typeof (CommonResx))] Contains = 8
    }
}