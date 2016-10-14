/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class CurrencyRate
    /// </summary>
    public class CompositeCurrencyRate
    {
        /// <summary>
        /// Gets or sets DateMatch
        /// </summary>
        public CurrencyDateMatch DateMatch { get; set; }

        /// <summary>
        /// Gets or sets HomeCurrency
        /// </summary>
        public string HomeCurrency { get; set; }

        /// <summary>
        /// Gets or sets Rate
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets RateDate
        /// </summary>
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Gets or sets RateOperator
        /// </summary>
        public CurrencyRateOperator RateOperator { get; set; }

        /// <summary>
        /// Gets or sets RateType
        /// </summary>
        public string RateType { get; set; }

        /// <summary>
        /// Gets or sets SourceCurrency
        /// </summary>
        public string SourceCurrency { get; set; }

        /// <summary>
        /// Gets or sets Spread
        /// </summary>
        public decimal Spread { get; set; }
    }

    /// <summary>
    /// Enum CurrencyDateMatch
    /// </summary>
    public enum CurrencyDateMatch
    {
        Exact = 1,
        Later = 2,
        Earlier = 3,
    }

    /// <summary>
    /// Enum CurrencyRateOperator
    /// </summary>
    public enum CurrencyRateOperator
    {
        Multiplication = 1,
        Division = 2,
    }
}
