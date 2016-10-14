/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class CurrencyTableDetail
    /// </summary>
    public class CurrencyTableDetail
    {
        /// <summary>
        /// Gets or sets CurrencyCode
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets DateMatch
        /// </summary>
        public CurrencyDateMatch DateMatch { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets RateOperator
        /// </summary>
        public CurrencyRateOperator RateOperator { get; set; }

        /// <summary>
        /// Gets or sets RateType
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// Gets or sets SourceOfRates
        /// </summary>
        public string SourceOfRates { get; set; }
    }
}
