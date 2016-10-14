// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.OptionalFields;
using Enums = Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.OptionalFields;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
{
	/// <summary>
	/// Partial class for RevaluationOptionalField
	/// </summary>
	public partial class RevaluationOptionalFieldValue : ModelBase
	{
		/// <summary>
		/// Gets or sets CurrencyCode
		/// </summary>
		[Key]
		public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets OptionalField 
        /// </summary>
        [Key]
        public string OptionalField { get; set; }

        /// <summary>
        /// Gets or sets Value 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets Type 
        /// </summary> 
        public FieldType Type { get; set; }

        /// <summary>
        /// Gets or sets Length 
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets Decimals 
        /// </summary>
        public int Decimals { get; set; }

        /// <summary>
        /// Gets or sets AllowBlank 
        /// </summary>
        public YesNo AllowBlank { get; set; }

        /// <summary>
        /// Gets or sets Validate 
        /// </summary>
        public YesNo Validate { get; set; }

        /// <summary>
        /// Gets or sets ValueSet 
        /// </summary>
        public ValueSet ValueSet { get; set; }

        /// <summary>
        /// Gets or sets TypedValueFieldIndex 
        /// </summary>
        public long TypedValueFieldIndex { get; set; }

        /// <summary>
        /// Gets or sets TextValue 
        /// </summary>
        public string TextValue { get; set; }

        /// <summary>
        /// Gets or sets AmountValue 
        /// </summary>
        public decimal AmountValue { get; set; }

        /// <summary>
        /// Gets or sets NumberValue 
        /// </summary>
        public decimal NumberValue { get; set; }

        /// <summary>
        /// Gets or sets IntegerValue 
        /// </summary>
        public long IntegerValue { get; set; }

        /// <summary>
        /// Gets or sets YesOrNoValue 
        /// </summary>
        public YesNo YesNoValue { get; set; }

        /// <summary>
        /// Gets or sets DateValue 
        /// </summary>
        public string DateValue { get; set; }

        /// <summary>
        /// Gets or sets TimeValue 
        /// </summary>
        public DateTime? TimeValue { get; set; }

        /// <summary>
        /// Gets or sets OptionalFieldDescription 
        /// </summary>
        public string OptionalFieldDescription { get; set; }

        /// <summary>
        /// Gets or sets ValueDescription 
        /// </summary>
        public string ValueDescription { get; set; }
        /// <summary>
        /// Gets and sets SerialNumber
        /// </summary>
        [IgnoreExportImport]
        public string SerialNumber { get; set; }
	}
}
