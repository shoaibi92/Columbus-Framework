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
	/// Class for RevaluationHistory mapping
	/// </summary>
	/// <typeparam name="T">Revaluation History model type</typeparam>
	public class RevaluationHistoryMapper<T> : ModelMapper<T> where T : RevaluationHistory, new ()
	{
		#region Constructor

		/// <summary>
		/// Constructor to set the Context
		/// </summary>
		/// <param name="context">Context</param>
		public RevaluationHistoryMapper(Context context)
			: base(context)
		{
		}

		#endregion

		#region ModelMapper methods

		/// <summary>
		/// Get Mapper
		/// </summary>
		/// <param name="entity">Business Entity</param>
		/// <returns>Mapped Model</returns>
		public override T Map(IBusinessEntity entity)
		{
			var model = base.Map(entity);

			model.CurrencyCode = entity.GetValue<string>(RevaluationHistory.Index.CurrencyCode);
			model.RevaluationDate = entity.GetValue<DateTime>(RevaluationHistory.Index.RevaluationDate);
			model.SequenceNo = entity.GetValue<long>(RevaluationHistory.Index.SequenceNo);
			model.RateDate = entity.GetValue<DateTime>(RevaluationHistory.Index.RateDate);
			model.ExchangeRate = entity.GetValue<decimal>(RevaluationHistory.Index.ExchangeRate);
			model.RateType = entity.GetValue<string>(RevaluationHistory.Index.RateType);
			model.RateOperator = EnumUtility.GetEnum<RateOperator>(entity.GetValue<string>(RevaluationHistory.Index.RateOperator));
			model.RateOverridden = EnumUtility.GetEnum<RateOverridden>(entity.GetValue<string>(RevaluationHistory.Index.RateOverridden));
			model.RevaluationMethod = EnumUtility.GetEnum<RevaluationMethod>(entity.GetValue<string>(RevaluationHistory.Index.RevaluationMethod));
			model.EarliestBackdatedActivityDate = entity.GetValue<DateTime>(RevaluationHistory.Index.EarliestBackdatedActivityDate);
			model.PostingSequenceNo = entity.GetValue<decimal>(RevaluationHistory.Index.PostingSequenceNo);
			model.SystemDate = entity.GetValue<DateTime>(RevaluationHistory.Index.SystemDate);
			model.ModuleVersionCreatedIn = entity.GetValue<string>(RevaluationHistory.Index.ModuleVersionCreatedIn);
			return model;
		}

		/// <summary>
		/// SetValue Mapper
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		public override void Map(T model, IBusinessEntity entity)
		{
			if (model == null)
			{
				return;
			}

			entity.SetValue(RevaluationHistory.Index.CurrencyCode, model.CurrencyCode);
			entity.SetValue(RevaluationHistory.Index.RevaluationDate, model.RevaluationDate);
			entity.SetValue(RevaluationHistory.Index.SequenceNo, model.SequenceNo);
			entity.SetValue(RevaluationHistory.Index.RateDate, model.RateDate);
			entity.SetValue(RevaluationHistory.Index.ExchangeRate, model.ExchangeRate);
			entity.SetValue(RevaluationHistory.Index.RateType, model.RateType);
			entity.SetValue(RevaluationHistory.Index.RateOperator, model.RateOperator);
			entity.SetValue(RevaluationHistory.Index.RateOverridden, model.RateOverridden);
			entity.SetValue(RevaluationHistory.Index.RevaluationMethod, model.RevaluationMethod);
			entity.SetValue(RevaluationHistory.Index.EarliestBackdatedActivityDate, model.EarliestBackdatedActivityDate);
			entity.SetValue(RevaluationHistory.Index.PostingSequenceNo, model.PostingSequenceNo);
			entity.SetValue(RevaluationHistory.Index.SystemDate, model.SystemDate);
			entity.SetValue(RevaluationHistory.Index.ModuleVersionCreatedIn, model.ModuleVersionCreatedIn);
		}

		/// <summary>
		/// Map Key
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		public override void MapKey(T model, IBusinessEntity entity)
		{
			entity.SetValue(RevaluationHistory.Index.CurrencyCode, model.CurrencyCode);
			entity.SetValue(RevaluationHistory.Index.RevaluationDate, model.RevaluationDate);
			entity.SetValue(RevaluationHistory.Index.SequenceNo, model.SequenceNo);
		}

		#endregion
	}
}
