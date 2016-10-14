/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum FinderDisplayType
    /// </summary>
    public enum FinderDisplayType
    {
        /// <summary>
        /// Display the field only in filter dropdown as well as in Grid column
        /// </summary>
        All = 0,

        /// <summary>
        /// Display the field only in filter dropdown, not in Grid column
        /// </summary>
        Filter = 1,

        /// <summary>
        /// Display the field only in Grid, not in filter dropdown
        /// </summary>
        Grid = 2
    }
}