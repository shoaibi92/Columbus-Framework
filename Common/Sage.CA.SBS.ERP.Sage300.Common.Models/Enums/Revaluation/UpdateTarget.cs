/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation
{
    /// <summary>
    /// Defines what field caused the Revaluation line update
    /// </summary>
    [Flags]
    public enum UpdateTarget
    {
        /// <summary>
        /// CurrencyCode field
        /// </summary>
        CurrencyCode = 1,

        /// <summary>
        /// RevaluationDate
        /// </summary>
        ThroughDate = 1 << 1,

        /// <summary>
        /// RateType field
        /// </summary>
        RateType = 1 << 2,

        /// <summary>
        /// RateDate field
        /// </summary>
        RateDate = 1 << 3,

        /// <summary>
        /// ExchangeRate field
        /// </summary>
        ExchangeRate = 1 << 4,

        /// <summary>
        /// No particular field caused the update, all the fields need to be updated
        /// </summary>
        All = ~0
    }
}
