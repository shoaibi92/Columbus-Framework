// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
     /// <summary>
    /// Enum for POOERetainageBase
     /// </summary>
    //TODO: Name of this Enum has been changed because RateOverride was being used in AP screens and it started throwing ambigous reference error.
    //TODO:To abvoid changing all those changes renamed it.Have to look back at it if name has to be reverted back.
    public enum POOERetainageBase
     {
          /// <summary>
          /// Gets or sets TotalAfterTaxes
          /// </summary>
          TotalAfterTaxes = 0,
          /// <summary>
          /// Gets or sets TotalBeforeTaxes
          /// </summary>
          TotalBeforeTaxes = 1,
     }
}
