/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceReciepts
    /// </summary>
    public partial class POOEBaseInvoiceReciepts : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets LineNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "LineNumber", ResourceType = typeof(InvoiceResx))]
        public decimal LineNumber { get; set; }

        /// <summary>
        /// Gets or sets ReceiptSequenceKey
        /// </summary>
        [IgnoreExportImport]
        [Display(Name = "ReceiptSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal ReceiptSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets ReceiptNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "ReceiptNumber", ResourceType = typeof(InvoiceResx))]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets StoredInDatabaseTable
        /// </summary>
        [IgnoreExportImport]
        public AllowedType StoredInDatabaseTable { get; set; }

        /// <summary>
        /// Gets or sets Line
        /// </summary>
        [IgnoreExportImport]
        public long Line { get; set; }
    }
}
