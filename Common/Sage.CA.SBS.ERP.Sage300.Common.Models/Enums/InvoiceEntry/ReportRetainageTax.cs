// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ReportRetainageTax
    /// </summary>
    //TODO: Name of this Enum has been changed because RateOverride was being used in AP screens and it started throwing ambigous reference error.
    //TODO:To abvoid changing all those changes renamed it.Have to look back at it if name has to be reverted back.
    public enum POOEReportRetainageTax
    {
        /// <summary>
        /// Gets or sets AtTimeOfOriginalDocument
        /// </summary>
        AtTimeOfOriginalDocument = 0,
        /// <summary>
        /// Gets or sets AsPerTaxAuthority
        /// </summary>
        AsPerTaxAuthority = 1,
    }
}
