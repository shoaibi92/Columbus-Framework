/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceLineLot
    /// </summary>
    public partial class POOEBaseInvoiceLineLot : ModelBase
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
        /// Gets or sets LotNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(40, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string LotNumber { get; set; }

        /// <summary>
        /// Gets or sets InvoiceLineSequence
        /// </summary>
        public decimal InvoiceLineSequence { get; set; }

        /// <summary>
        /// Gets or sets ExpiryDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets LotQuantity
        /// </summary>
        public decimal LotQuantity { get; set; }

        /// <summary>
        /// Gets or sets LotStockQuantity
        /// </summary>
        public decimal LotStockQuantity { get; set; }
    }
}
