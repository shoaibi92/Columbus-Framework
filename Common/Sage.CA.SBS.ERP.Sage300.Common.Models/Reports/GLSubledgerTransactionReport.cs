// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// GLTransaction Report Common Model
    /// </summary>
    public partial class GLSubledgerTransactionReport : ReportBase
    {
        /// <summary>
        ///  Gets or sets ThroughPostingSequence 
        /// </summary>
        [Display(Name = "ThroughPostingSequence", ResourceType = typeof(CommonResx))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal ThroughPostingSequence { get; set; }

        /// <summary>
        ///  Gets or sets ReportFormat 
        /// </summary>
        [Display(Name = "ReportFormat", ResourceType = typeof(CommonResx))]
        public ReportFormat ReportFormat { get; set; }

        /// <summary>
        ///  Gets or sets SortBy 
        /// </summary>
        [Display(Name = "SortBy", ResourceType = typeof(CommonResx))]
        public SortByType SortBy { get; set; }

        /// <summary>
        ///  Gets or sets ReportCurrency 
        /// </summary>
        [Display(Name = "ReportCurrency", ResourceType = typeof(CommonResx))]
        public CurrencyType ReportCurrency { get; set; }

        /// <summary>
        /// Gets or sets SourceApplication 
        /// </summary>
        public string SourceApplication { get; set; }

        /// <summary>
        /// Gets or sets ReportNamePrefix 
        /// </summary>
        public string ReportNamePrefix { get; set; }

        /// <summary>
        /// Gets or sets PostingSequenceCaption 
        /// </summary>
        public string PostingSequenceCaption { get; set; }

        /// <summary>
        /// Gets or sets PostingSequenceTitle1 
        /// </summary>
        public string PostingSequenceTitle1 { get; set; }

        /// <summary>
        /// Gets or sets PostingSequenceTitle2 
        /// </summary>
        public string PostingSequenceTitle2 { get; set; }

        /// <summary>
        ///  Gets or sets FunctionalCurrencyDecimals 
        /// </summary>
        public decimal FunctionalCurrencyDecimals { get; set; }

        /// <summary>
        ///  Gets or sets MultiCurrency 
        /// </summary>
        public bool MultiCurrency { get; set; }
    }
}
