// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using System;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
{
	/// <summary>
	/// Partial class for Revaluation
	/// </summary>
	public partial class RevaluationEntry : ModelBase
	{
		/// <summary>
		/// Gets or sets CurrencyCode
		/// </summary>
		[Key]
		[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
		[StringLength(3, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CurrencyCode", ResourceType = typeof(RevaluationResx))]
		public string CurrencyCode { get; set; }

		/// <summary>
		/// Gets or sets ThroughDate
		/// </summary>
		[ValidateDateFormat(ErrorMessageResourceName="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ThroughDate", ResourceType = typeof(RevaluationResx))]
		public DateTime ThroughDate { get; set; }

		/// <summary>
		/// Gets or sets RateDate
		/// </summary>
		[ValidateDateFormat(ErrorMessageResourceName="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateDate", ResourceType = typeof(RevaluationResx))]
		public DateTime RateDate { get; set; }

		/// <summary>
		/// Gets or sets ExchangeRate
		/// </summary>
        [Display(Name = "ExchangeRate", ResourceType = typeof(RevaluationResx))]
		public decimal ExchangeRate { get; set; }

		/// <summary>
		/// Gets or sets RateType
		/// </summary>
		[StringLength(2, ErrorMessageResourceName = "MaxLength",ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "RateType", ResourceType = typeof(RevaluationResx))]
		public string RateType { get; set; }

		/// <summary>
		/// Gets or sets RateOperator
		/// </summary>
        public RateOperator RateOperator { get; set; }

		/// <summary>
		/// Gets or sets RateOverridden
		/// </summary>
		public RateOverridden RateOverridden { get; set; }

		/// <summary>
		/// Gets or sets OptionalFields
		/// </summary>
		public long OptionalFieldsCount { get; set; }

		/// <summary>
		/// Gets or sets EarliestBackdatedActivityDate
		/// </summary>
		[ValidateDateFormat(ErrorMessageResourceName="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
		public DateTime EarliestBackdatedActivityDate { get; set; }

		/// <summary>
		/// Gets or sets ProcessCommandCode
		/// </summary>
		public ProcessCommandCode ProcessCommandCode { get; set; }

		/// <summary>
		/// Gets or sets EarliestBackdatedTransactionD
		/// </summary>
		[ValidateDateFormat(ErrorMessageResourceName="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
		public DateTime EarliestBackdatedTransactionDate { get; set; }

		/// <summary>
		/// Gets or sets LastRevaluationDate
		/// </summary>
		[ValidateDateFormat(ErrorMessageResourceName="DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
		public DateTime LastRevaluationDate { get; set; }
        
        /// <summary>
        /// Gets or sets List of Optional Fields values
        /// </summary>
        /// <value>The recurring entries.</value>
        public EnumerableResponse<RevaluationOptionalFieldValue> OptionalFields { get; set; }

        /// <summary>
        /// Gets optional fields description
        /// </summary>
        [Display(Name = "OptionalFields", ResourceType = typeof(CommonResx))]
        public string OptionalFieldsString
	    {
	        get
	        {
                return OptionalFieldsCount > 0 ? CommonResx.Yes : CommonResx.No;	            
	        }
	    }

        /// <summary>
        /// Gets or sets record internal ID
        /// </summary>
	    public string InternalId { get; set; }

        /// <summary>
        /// Gets or sets Rate spread value
        /// </summary>
	    public decimal RateSpread { get; set; }
	}
}
