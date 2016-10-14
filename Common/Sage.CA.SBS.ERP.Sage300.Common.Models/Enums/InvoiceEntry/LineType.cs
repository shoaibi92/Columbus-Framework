// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for LineType
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        [EnumValue("Comment", typeof(InvoiceResx))]
        Comment = 1,

        /// <summary>
        /// Gets or sets Instruction
        /// </summary>
        [EnumValue("Instruction", typeof(InvoiceResx))]
        Instruction = 2,
    }
}
