/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class Currency.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the decimals.
        /// </summary>
        /// <value>The decimals.</value>
        public ushort Decimals { get; set; }

        /// <summary>
        /// Gets or sets the decimal separator.
        /// </summary>
        /// <value>The decimal separator.</value>
        public char DecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the negative display.
        /// </summary>
        /// <value>The negative display.</value>
        public CurrencyNegativeDisplay NegativeDisplay { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the symbol display.
        /// </summary>
        /// <value>The symbol display.</value>
        public CurrencySymbolDisplay SymbolDisplay { get; set; }

        /// <summary>
        /// Gets or sets the thousand separator.
        /// </summary>
        /// <value>The thousand separator.</value>
        public char ThousandSeparator { get; set; }
    }

    /// <summary>
    /// Enum CurrencyNegativeDisplay
    /// </summary>
    public enum CurrencyNegativeDisplay
    {
        /// <summary>
        /// The trailing minus
        /// </summary>
        TrailingMinus = 1,

        /// <summary>
        /// The leading minus
        /// </summary>
        LeadingMinus = 2,

        /// <summary>
        /// The brackets
        /// </summary>
        Brackets = 3,
    }

    /// <summary>
    /// Enum CurrencySymbolDisplay
    /// </summary>
    public enum CurrencySymbolDisplay
    {
        /// <summary>
        /// The before with space
        /// </summary>
        BeforeWithSpace = 1,

        /// <summary>
        /// The before without space
        /// </summary>
        BeforeWithoutSpace = 2,

        /// <summary>
        /// The after with space
        /// </summary>
        AfterWithSpace = 3,

        /// <summary>
        /// The after without space
        /// </summary>
        AfterWithoutSpace = 4,
    }
}