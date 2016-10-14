// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ProcessCommand 
    /// </summary>
    public enum ARInvoiceProcessCommand
    {
        /// <summary>
        /// Gets or Sets CalculateTax
        /// </summary>
        [EnumValue("CalculateTaxes", typeof(InvoiceResx))]
        CalculateTax = 0,

        /// <summary>
        /// Gets or Sets DistributeTax 
        /// </summary>
        [EnumValue("DistributeTaxes", typeof(InvoiceResx))]
        DistributeTax = 1,

        /// <summary>
        /// Gets or Sets SumTax
        /// </summary>
        [EnumValue("SumTaxes", typeof(InvoiceResx))]
        SumTax = 2,

        /// <summary>
        /// Gets or Sets TotalTax
        /// </summary>
        [EnumValue("TotalTaxes", typeof(InvoiceResx))]
        TotalTax = 3,

        /// <summary>
        /// Gets or Sets InsertOptionalField
        /// </summary>
        [EnumValue("InsertOptionalFields", typeof(InvoiceResx))]
        InsertOptionalField = 4,

        /// <summary>
        /// Gets or Sets DeriveTaxReportingExchangeRate
        /// </summary>
        [EnumValue("DeriveTaxReportingExchangeRate", typeof(InvoiceResx))]
        DeriveTaxReportingExchangeRate = 5,

        /// <summary>
        /// Gets or Sets InvoiceResx
        /// </summary>
        [EnumValue("EnableRateLookup", typeof(InvoiceResx))]
        EnableRateLookup = 8,

        /// <summary>
        /// Gets or Sets DisableRateLookup
        /// </summary>
        [EnumValue("DisableRateLookup", typeof(InvoiceResx))]
        DisableRateLookup = 9,

        /// <summary>
        /// Gets or Sets EnableTaxReportingRateLookup
        /// </summary>
        [EnumValue("EnableTaxReportingRateLookup", typeof(InvoiceResx))]
        EnableTaxReportingRateLookup = 10,

        /// <summary>
        /// Gets or Sets DisableTaxReportingRateLookup
        /// </summary>
        [EnumValue("DisableTaxReportingRateLookup", typeof(InvoiceResx))]
        DisableTaxReportingRateLookup = 11

    }
}