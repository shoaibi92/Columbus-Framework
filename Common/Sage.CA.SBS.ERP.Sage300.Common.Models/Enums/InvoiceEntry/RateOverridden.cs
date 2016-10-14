// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
     /// <summary>
    /// Enum for POOERateOverridden
     /// </summary>
     //TODO: Name of this Enum has been changed because RateOverride was being used in AP screens and it started throwing ambigous reference error.
    //TODO:To abvoid changing all those changes renamed it.Have to look back at it if name has to be reverted back.
    public enum POOERateOverridden
     {
          /// <summary>
          /// Gets or sets No
          /// </summary>
         [EnumValue("No", typeof(CommonResx))] 
         No = 1,
          /// <summary>
          /// Gets or sets Yes
          /// </summary>
         [EnumValue("Yes", typeof(CommonResx))] 
         Yes = 0,
     }
}
