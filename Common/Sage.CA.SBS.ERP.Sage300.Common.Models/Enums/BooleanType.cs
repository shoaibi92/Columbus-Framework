/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region NameSpace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum BooleanType
    /// </summary>
    public enum BooleanType
    {
        /// <summary>
        /// False
        /// </summary>
        [EnumValue("False", typeof(EnumerationsResx))]
        False = 0,

        /// <summary>
        /// True
        /// </summary>
        [EnumValue("True", typeof(EnumerationsResx))]
        True = 1,
    }
}
