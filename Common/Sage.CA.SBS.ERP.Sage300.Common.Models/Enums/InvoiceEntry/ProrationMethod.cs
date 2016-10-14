// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ProrationMethod
    /// </summary>
    public enum ProrationMethod
    {
        /// <summary>
        /// Gets or sets NoProration
        /// </summary>
        [EnumValue("NoProration", typeof(EnumerationsResx))]
        NoProration = 1,
        /// <summary>
        /// Gets or sets ProratebyQuantity
        /// </summary>
        [EnumValue("ProratebyQuantity", typeof(EnumerationsResx))]
        ProratebyQuantity = 2,
        /// <summary>
        /// Gets or sets ProratebyCost
        /// </summary>
        [EnumValue("ProratebyCost", typeof(EnumerationsResx))]
        ProratebyCost = 3,
        /// <summary>
        /// Gets or sets ProratebyWeight
        /// </summary>
        [EnumValue("ProratebyWeight", typeof(EnumerationsResx))]
        ProratebyWeight = 4,
        /// <summary>
        /// Gets or sets ProrateManually
        /// </summary>
        [EnumValue("ProrateManually", typeof(EnumerationsResx))]
        ProrateManually = 5,
    }
}
