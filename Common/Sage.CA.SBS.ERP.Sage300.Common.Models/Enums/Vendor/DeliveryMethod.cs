/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region NameSpace
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Vendor
{
    /// <summary>
    /// Enumeration for Delivery Method. This is used in 
    /// </summary>
    public enum DeliveryMethod
    {
        /// <summary>
        /// 
        /// </summary>
        [EnumValue("Mail", typeof(EnumerationsResx))]
        Mail = 0,

        /// <summary>
        /// 
        /// </summary>
        [EnumValue("Email", typeof(EnumerationsResx))]
        Email = 1,

        /// <summary>
        /// 
        /// </summary>
        [EnumValue("ContactEmail", typeof(EnumerationsResx))]
        ContactEmail  = 2
    }
}
