// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation.Mappers
{
	/// <summary>
	/// Mapper for Revaluation Business view
	/// </summary>
	/// <typeparam name="T">Revaluation model</typeparam>
	public class RevaluationEntryMapper<T> : ModelMapper<T> where T : RevaluationEntry, new ()
    {
        #region Private members

        private readonly UpdateTarget _updateTarget;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new instance of <see cref="RevaluationEntryMapper{T}"/> class
        /// </summary>
		/// <param name="context">Context</param>
        /// <param name="updateTarget">Specifies what fields need to be updated</param>
        public RevaluationEntryMapper(Context context, UpdateTarget updateTarget)
			: base(context)
        {
            _updateTarget = updateTarget;
        }

		#endregion

		#region ModelMapper methods

		/// <summary>
        /// Maps the business view to a new instance of model class
		/// </summary>
		/// <param name="entity">Business Entity</param>
		/// <returns>Mapped Model</returns>
		public override T Map(IBusinessEntity entity)
		{
			var model = base.Map(entity);

			model.CurrencyCode = entity.GetValue<string>(RevaluationEntry.Index.CurrencyCode);
            model.ThroughDate = entity.GetValue<DateTime>(RevaluationEntry.Index.ThroughDate);
            model.RateDate = entity.GetValue<DateTime>(RevaluationEntry.Index.RateDate);
            model.ExchangeRate = entity.GetValue<decimal>(RevaluationEntry.Index.ExchangeRate);
            model.RateType = entity.GetValue<string>(RevaluationEntry.Index.RateType);
            model.RateOperator = EnumUtility.GetEnum<RateOperator>(entity.GetValue<string>(RevaluationEntry.Index.RateOperator));
            model.RateOverridden = EnumUtility.GetEnum<RateOverridden>(entity.GetValue<string>(RevaluationEntry.Index.RateOverridden));
            model.OptionalFieldsCount = entity.GetValue<long>(RevaluationEntry.Index.OptionalField);
            model.EarliestBackdatedActivityDate = entity.GetValue<DateTime>(RevaluationEntry.Index.EarliestBackdatedActivityDate);
            model.ProcessCommandCode = EnumUtility.GetEnum<ProcessCommandCode>(entity.GetValue<string>(RevaluationEntry.Index.ProcessCommandCode));
            model.EarliestBackdatedTransactionDate = entity.GetValue<DateTime>(RevaluationEntry.Index.EarliestBackdatedTransactionDate);
            model.LastRevaluationDate = entity.GetValue<DateTime>(RevaluationEntry.Index.LastRevaluationDate);

			return model;
		}

		/// <summary>
		/// Maps model to the Business View
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		public override void Map(T model, IBusinessEntity entity)
		{
			if (model == null)
			{
				return;
			}

		    if (_updateTarget.HasFlag(UpdateTarget.CurrencyCode))
		    {
                entity.SetValue(RevaluationEntry.Index.CurrencyCode, model.CurrencyCode, true);
		    }
            if (_updateTarget.HasFlag(UpdateTarget.ThroughDate))
            {
                entity.SetValue(RevaluationEntry.Index.ThroughDate, model.ThroughDate, true);
            }
            if (_updateTarget.HasFlag(UpdateTarget.RateType))
            {
                entity.SetValue(RevaluationEntry.Index.RateType, model.RateType, true);
            }
            if (_updateTarget.HasFlag(UpdateTarget.RateDate))
            {
                entity.SetValue(RevaluationEntry.Index.RateDate, model.RateDate, true);
            }
            if (_updateTarget.HasFlag(UpdateTarget.ExchangeRate))
            {
                entity.SetValue(RevaluationEntry.Index.ExchangeRate, model.ExchangeRate, true);
            }
		}

		/// <summary>
		/// Maps Key
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		public override void MapKey(T model, IBusinessEntity entity)
		{
            entity.SetValue(RevaluationEntry.Index.CurrencyCode, model.CurrencyCode);
		}

		#endregion
	}
}
