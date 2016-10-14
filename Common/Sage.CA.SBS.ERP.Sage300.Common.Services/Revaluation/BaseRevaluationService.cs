// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Revaluation.Service;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Revaluation
{
    /// <summary>
    /// Base Revaluation Service implementation
    /// </summary>
    /// <typeparam name="T">Revaluation model type</typeparam>
    /// <typeparam name="TU">Revaluation optional field model type</typeparam>
    /// <typeparam name="TEntity">Revaluation repository type</typeparam>
    public class BaseRevaluationService<T, TU, TEntity> : BaseOrderedHeaderDetailService<T, TU, TEntity>, IBaseRevaluationService<T, TU>
        where T : RevaluationEntry, new()
        where TU : RevaluationOptionalFieldValue, new()
        where TEntity: IBaseRevaluationEntity<T, TU>
    {
        #region Constructor

        /// <summary>
        /// Instantiates a new instance of <see cref="BaseRevaluationService{T, TU, TEntity}"/> class
        /// </summary>
        /// <param name="context">Context</param>
        public BaseRevaluationService(Context context)
            : base(context)
        {

        }

        #endregion

        /// <summary>
        /// Updates Revaluation entry
        /// </summary>
        /// <param name="model">Model to update</param>
        /// <param name="updateTarget">Specifies what fields need to be updated</param>
        /// <returns>Revaluation model</returns>
        public T Update(T model, UpdateTarget updateTarget)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Update(model, updateTarget);
            }
        }

        /// <summary>
        /// Updates Optional fields related to Revaluation entry
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <param name="optionalFields">Optional fields to update</param>
        /// <returns>Revaluation model</returns>
        public T UpdateOptionalFields(string currencyCode, IEnumerable<TU> optionalFields)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.UpdateOptionalFields(currencyCode, optionalFields);
            }

        }

        /// <summary>
        /// Returns home currency for the current company
        /// </summary>
        /// <returns>Currency Code</returns>
        public string GetHomeCurrency()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetHomeCurrency();
            }
        }

        /// <summary>
        /// Returns Composite Currency rate based on currency rate tables for specified source currency code, rate type and date
        /// </summary>
        /// <param name="sourceCurrencyCode">Source Currency Code</param>
        /// <param name="rateType">Rate Type</param>
        /// <param name="date">Rate Date</param>
        /// <returns>CompositeCurrencyRate</returns>
        public CompositeCurrencyRate GetCurrencyRateComposite(string sourceCurrencyCode, string rateType, DateTime date)
        {
            try
            {
                using (var repository = Resolve<TEntity>())
                {
                    return repository.GetCurrencyRateComposite(sourceCurrencyCode, rateType, date);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
