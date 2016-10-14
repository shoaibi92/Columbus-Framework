using System;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation
{
    /// <summary>
    /// Partial class for RevaluationHistory
    /// </summary>
    public partial class RevaluationHistory : ModelBase
    {
        /// <summary>
        /// Gets or sets CurrencyCode
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets RevaluationDate
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime RevaluationDate { get; set; }

        /// <summary>
        /// Gets or sets SequenceNo
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public long SequenceNo { get; set; }

        /// <summary>
        /// Gets or sets RateDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Generated", ResourceType = typeof(CommonResx))]
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Gets or sets ExchangeRate
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets RateType
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
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
        /// Gets or sets RevaluationMethod
        /// </summary>
        public RevaluationMethod RevaluationMethod { get; set; }

        /// <summary>
        /// Gets or sets EarliestBackdatedActivityDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime EarliestBackdatedActivityDate { get; set; }

        /// <summary>
        /// Gets or sets PostingSequenceNo
        /// </summary>
        public decimal PostingSequenceNo { get; set; }

        /// <summary>
        /// Gets or sets SystemDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime SystemDate { get; set; }

        /// <summary>
        /// Gets or sets ModuleVersionCreatedIn
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ModuleVersionCreatedIn { get; set; }

        #region UI Strings

        /// <summary>
        /// Gets RateOperator string value
        /// </summary>
        public string RateOperatorString
        {
            get { return EnumUtility.GetStringValue(RateOperator); }
        }

        /// <summary>
        /// Gets RateOverridden string value
        /// </summary>
        public string RateOverriddenString
        {
            get { return EnumUtility.GetStringValue(RateOverridden); }
        }

        /// <summary>
        /// Gets RevaluationMethod string value
        /// </summary>
        public string RevaluationMethodString
        {
            get { return EnumUtility.GetStringValue(RevaluationMethod); }
        }

        #endregion
    }
}
