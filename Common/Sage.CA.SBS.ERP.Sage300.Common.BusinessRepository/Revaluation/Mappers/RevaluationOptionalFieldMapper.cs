// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.OptionalFields;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Revaluation.Mappers
{
	/// <summary>
	/// Class for RevaluationOptionalField mapping
	/// </summary>
	/// <typeparam name="T">Revaluation Optional Field type</typeparam>
	public class RevaluationOptionalFieldMapper<T> : ModelMapper<T> where T : RevaluationOptionalFieldValue, new ()
	{
		#region Constructor

		/// <summary>
		/// Constructor to set the Context
		/// </summary>
		/// <param name="context">Context</param>
		public RevaluationOptionalFieldMapper(Context context)
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

            model.Type = EnumUtility.GetEnum<FieldType>(entity.GetValue<string>(RevaluationOptionalFieldValue.Index.Type));
            model.CurrencyCode = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.CurrencyCode);
            model.OptionalField = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.OptionalField);

		    var value = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.Value);
		    switch (model.Type)
		    {
                case FieldType.Date:
		            value = DateUtil.GetShortDate(value, string.Empty, true);
		            break;
                case FieldType.Time:
		            value = string.IsNullOrEmpty(value) ? string.Empty : TimeUtil.GetFormattedTime(value);
		            break;
		    }
		    model.Value = value;

            model.Length = entity.GetValue<int>(RevaluationOptionalFieldValue.Index.Length);
            model.Decimals = entity.GetValue<int>(RevaluationOptionalFieldValue.Index.Decimals);
            model.AllowBlank = (YesNo)entity.GetValue<int>(RevaluationOptionalFieldValue.Index.AllowBlank);
            model.Validate = (YesNo)entity.GetValue<int>(RevaluationOptionalFieldValue.Index.Validate);
            model.ValueSet = EnumUtility.GetEnum<ValueSet>(entity.GetValue<string>(RevaluationOptionalFieldValue.Index.ValueSet));
            model.TypedValueFieldIndex = entity.GetValue<long>(RevaluationOptionalFieldValue.Index.TypedValueFieldIndex);
            model.TextValue = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.TextValue);
            model.AmountValue = entity.GetValue<decimal>(RevaluationOptionalFieldValue.Index.AmountValue);
            model.NumberValue = entity.GetValue<decimal>(RevaluationOptionalFieldValue.Index.NumberValue);
            model.IntegerValue = entity.GetValue<long>(RevaluationOptionalFieldValue.Index.IntegerValue);
            model.YesNoValue = (YesNo)entity.GetValue<int>(RevaluationOptionalFieldValue.Index.YesNoValue);
            model.DateValue = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.DateValue);
            model.TimeValue = entity.GetValue<DateTime>(RevaluationOptionalFieldValue.Index.TimeValue);
            model.OptionalFieldDescription = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.OptionalFieldDescription);
            model.ValueDescription = entity.GetValue<string>(RevaluationOptionalFieldValue.Index.ValueDescription);
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

            entity.SetValue(RevaluationOptionalFieldValue.Index.CurrencyCode, model.CurrencyCode);
            entity.SetValue(RevaluationOptionalFieldValue.Index.OptionalField,
                !string.IsNullOrEmpty(model.OptionalField) ? model.OptionalField.ToUpper() : model.OptionalField);

            if (model.ValueSet == ValueSet.No) 
                return;

            switch (model.Type)
            {
                case FieldType.Text:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.TextValue, model.Value, model.Validate == YesNo.Yes);
                    break;
                case FieldType.Integer:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.IntegerValue, model.Value, model.Validate == YesNo.Yes);
                    break;
                case FieldType.Amount:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.AmountValue, model.Value, model.Validate == YesNo.Yes);
                    break;
                case FieldType.Number:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.NumberValue, model.Value, model.Validate == YesNo.Yes);
                    break;
                case FieldType.Date:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.DateValue, DateUtil.GetDate(model.Value, null));
                    break;
                case FieldType.Time:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.TimeValue, model.Value, model.Validate == YesNo.Yes);
                    break;
                case FieldType.YesOrNo:
                    entity.SetValue(RevaluationOptionalFieldValue.Index.YesNoValue, model.Value, model.Validate == YesNo.Yes);
                    break;
            }
        }

		/// <summary>
		/// Map Key
		/// </summary>
		/// <param name="model">Model</param>
		/// <param name="entity">Business Entity</param>
		public override void MapKey(T model, IBusinessEntity entity)
		{
            entity.SetValue(RevaluationOptionalFieldValue.Index.CurrencyCode, model.CurrencyCode);
            entity.SetValue(RevaluationOptionalFieldValue.Index.OptionalField, model.OptionalField);
		}

		#endregion
	}
}
