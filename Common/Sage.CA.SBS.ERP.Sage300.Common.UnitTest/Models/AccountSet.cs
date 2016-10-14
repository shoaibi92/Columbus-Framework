/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for AccountSet
    /// </summary>
    public partial class AccountSet : EntityCorePropertyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountSet"/> class.
        /// </summary>
        public AccountSet()
        {
            Code = string.Empty;
            Description = string.Empty;
        }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        /// <value>The status.</value>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        /// <value>The status string.</value>
        public string StatusString
        {
            get { return EnumUtility.GetStringValue(Status); }
        }
    }
}