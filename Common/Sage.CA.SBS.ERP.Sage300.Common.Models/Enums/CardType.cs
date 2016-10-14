// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for CardType
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// Gets or sets 
        /// </summary>
        [EnumValue("Blank", typeof(EnumerationsResx))]
        Unknown = 0,
        /// <summary>
        /// Gets or sets AmericanExpress
        /// </summary>
        [EnumValue("AmericanExpress", typeof(EnumerationsResx))]
        AmericanExpress = 3,
        /// <summary>
        /// Gets or sets Visa
        /// </summary>
        [EnumValue("Visa", typeof(EnumerationsResx))]
        Visa = 4,
        /// <summary>
        /// Gets or sets MasterCard
        /// </summary>
        [EnumValue("MasterCard", typeof(EnumerationsResx))]
        MasterCard = 5,
        /// <summary>
        /// Gets or sets Discover
        /// </summary>
       [EnumValue("Discover", typeof(EnumerationsResx))]
        Discover = 6,
        /// <summary>
        /// Gets or sets JCB
        /// </summary>
        [EnumValue("JCB", typeof(EnumerationsResx))]
        JCB = 7,
        /// <summary>
        /// Gets or sets DebitCard
        /// </summary>
        [EnumValue("DebitCard", typeof(EnumerationsResx))]
        DebitCard = 68,
    }
}
