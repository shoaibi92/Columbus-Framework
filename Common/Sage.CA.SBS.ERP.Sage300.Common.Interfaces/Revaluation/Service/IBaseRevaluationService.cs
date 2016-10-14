/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.Service
{
    /// <summary>
    /// Base Revaluation Entry Service interface
    /// </summary>
    /// <typeparam name="T">Repository model type</typeparam>
    /// <typeparam name="TU">Repository Optional Field model type</typeparam>
    public interface IBaseRevaluationService<T, TU> : IOrderedHeaderDetailService<T, TU>
        where T : RevaluationEntry, new()
        where TU : RevaluationOptionalFieldValue, new()
    {
        /// <summary>
        /// Updates Revaluation entry
        /// </summary>
        /// <param name="model">Model to update</param>
        /// <param name="updateTarget">Specifies what fields need to be updated</param>
        /// <returns>Revaluation model</returns>
        T Update(T model, UpdateTarget updateTarget);

        /// <summary>
        /// Updates Optional fields related to Revaluation entry
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="optionalFields">Optional fields to update</param>
        /// <returns>Revaluation model</returns>
        T UpdateOptionalFields(string currencyCode, IEnumerable<TU> optionalFields);

        /// <summary>
        /// Returns home currency for the current company
        /// </summary>
        /// <returns></returns>
        string GetHomeCurrency();

        /// <summary>
        /// Returns Composite Currency rate based on currency rate tables for specified source currency code, rate type and date
        /// </summary>
        /// <param name="sourceCurrencyCode">Source Currency Code</param>
        /// <param name="rateType">Rate Type</param>
        /// <param name="date">Rate Date</param>
        /// <returns>CompositeCurrencyRate</returns>
        CompositeCurrencyRate GetCurrencyRateComposite(string sourceCurrencyCode, string rateType, DateTime date);
    }
}
