/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceComments
    /// </summary>
    public partial class POOEBaseInvoiceComments : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets CommentIdentifier
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CommentIdentifier", ResourceType = typeof(InvoiceResx))]
        public decimal CommentIdentifier { get; set; }

        /// <summary>
        /// Gets or sets InvoiceCommentSequence
        /// </summary>
        [Display(Name = "InvoiceCommentSequence", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceCommentSequence { get; set; }

        /// <summary>
        /// Gets or sets StoredInDatabaseTable
        /// </summary>
        [IgnoreExportImport]
        public AllowedType StoredInDatabaseTable { get; set; }

        /// <summary>
        /// Gets or sets LineType
        /// </summary>
        [Display(Name = "LineType", ResourceType = typeof(InvoiceResx))]
        public LineType LineType { get; set; }

        /// <summary>
        /// Gets or sets Comment
        /// </summary>
        [StringLength(80, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Comment", ResourceType = typeof(InvoiceResx))]
        public string Comment { get; set; }
    }
}
