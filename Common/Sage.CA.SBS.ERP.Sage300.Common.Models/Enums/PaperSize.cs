/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for PaperSize
    /// </summary>
    public enum PaperSize
    {
        /// <summary>
        /// The legal
        /// </summary>
        [EnumValue("Legal", typeof (CommonResx))] Legal = 0,

        /// <summary>
        /// The letter or a4
        /// </summary>
        [EnumValue("LetterA4", typeof (CommonResx))] LetterOrA4 = 1,
    }
}