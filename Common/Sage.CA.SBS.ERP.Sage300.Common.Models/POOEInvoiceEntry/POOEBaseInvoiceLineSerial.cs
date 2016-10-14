/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceLineSerial
    /// </summary>
    public partial class POOEBaseInvoiceLineSerial : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets LineNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal LineNumber { get; set; }

        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(40, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceLineSequence
        /// </summary>
        public decimal InvoiceLineSequence { get; set; }

        /// <summary>
        /// Gets or sets SerialCount
        /// </summary>
        public long SerialCount { get; set; }
    }
}
