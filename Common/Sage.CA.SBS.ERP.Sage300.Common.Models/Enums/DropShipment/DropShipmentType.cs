// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment
{
    /// <summary>
    /// Enum for DropShipType
    /// </summary>
    public enum DropShipmentType
    {
        /// <summary>
        /// Gets or sets AddressEntered
        /// </summary>
        [EnumValue("AddressEntered", typeof (CommonResx))] AddressEntered = 2,

        /// <summary>
        /// Gets or sets InventoryLocationAddress
        /// </summary>
        [EnumValue("InventoryLocationAddress", typeof (CommonResx))] InventoryLocationAddress = 3,

        /// <summary>
        /// Gets or sets CustomerAddress
        /// </summary>
        [EnumValue("CustomerAddress", typeof (CommonResx))] CustomerAddress = 4,

        /// <summary>
        /// Gets or sets CustomerShipToAddress
        /// </summary>
        [EnumValue("CustomerShipToAddress", typeof (CommonResx))] CustomerShipToAddress = 5,
    }
}
