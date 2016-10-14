// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation.Mappers
{
	/// <summary>
	/// Class for Revaluation mapping
	/// </summary>
	/// <typeparam name="T">Revaluation model type</typeparam>
	public class RevaluationProcessMapper<T> : ModelMapper<T> where T : RevaluationProcess, new ()
	{
		#region Constructor

		/// <summary>
		/// Constructor to set the Context
		/// </summary>
		/// <param name="context">Context</param>
        public RevaluationProcessMapper(Context context)
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

		    model.ProvisionalRevaluation = entity.GetValue<int>(RevaluationProcess.Index.ProvisionalRevaluation) == 1;
            
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

            entity.SetValue(RevaluationProcess.Index.ProvisionalRevaluation, model.ProvisionalRevaluation ? 1 : 0);
		}

		/// <summary>
		/// Map Key
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void MapKey(T model, IBusinessEntity entity)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
