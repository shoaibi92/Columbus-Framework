/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Model Class for Posting Journal Report
    /// </summary>
    public partial class CommonPostingJournal : ReportBase
    {
        #region Common Model Properties

        /// <summary>
        /// Gets or sets MultiCurrency
        /// </summary>
        public bool MultiCurrency { get; set; }

        /// <summary>
        /// Gets or sets Reprint Previously Printed Journals
        /// </summary>
        [Display(Name = "Reprint", ResourceType = typeof(CommonResx))]
        public bool Reprint { get; set; }

        /// <summary>
        /// Gets or sets Regional Format
        /// </summary>
        public string RegionalFmt { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public string SwSnltlIc { get; set; }

        /// <summary>
        /// Gets or sets MultiCurrency
        /// </summary>
        [Display(Name = "IncludeJob", ResourceType = typeof(CommonResx))]
        public bool IncludeJob { get; set; }

        /// <summary>
        /// Gets or sets Include Optional Fields
        /// </summary>
        [Display(Name = "IncludeOptionalFields", ResourceType = typeof(CommonResx))]
        public bool OptionalField { get; set; }

        /// <summary>
        /// Gets or sets Is MB OF Active
        /// </summary>
        public bool IsMbOfActive { get; set; }

        /// <summary>
        /// Gets or sets Is SN LT Active
        /// </summary>
        public bool IsSnLtActive { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public string FunctionalDecimal { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public string Level1Name { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public string Level2Name { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public string Level3Name { get; set; }

        /// <summary>
        /// Gets or sets SWSNLTLIC
        /// </summary>
        public PaperSize PaperSize { get; set; }

        /// <summary>
        /// Gets or sets Is SN LT Active
        /// </summary>
        public bool IsPmActive { get; set; }

        #endregion
    }
}