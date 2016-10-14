// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation
{
    /// <summary>
    /// Partial class for Vendor Information
    /// </summary>
    public partial class VendorBase : ModelBase
    {
        [IgnoreExportImport]
        [IsMvcSpecific]
        public IDictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Address1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets Address2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets Address3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or sets Address4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Address4 { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets StateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string StateProvince { get; set; }

        /// <summary>
        /// Gets or sets ZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets Country
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets FaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets Email
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Contact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Contact { get; set; }

        /// <summary>
        /// Gets or sets ContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets ContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ContactFax { get; set; }

        /// <summary>
        /// Gets or sets ContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ContactEmail { get; set; }
    }
}
