/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for EntityCorePropertyBase
    /// </summary>
    public class EntityCorePropertyBase : ModelBase
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}
