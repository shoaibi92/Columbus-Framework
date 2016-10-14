// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.PODropShipment
{
    /// <summary>
    /// DropShipAddress
    /// </summary>
    public partial class DropShipAddress : ModelBase
    {
        /// <summary>
        /// Gets or sets DropShipType
        /// </summary>
        public DropShipmentType DropShipmentType { get; set; }

        /// <summary>
        /// Gets or sets DropShipCustomer
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipCustomer { get; set; }

        /// <summary>
        /// Gets or sets DropShipLocation
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipLocation { get; set; }

        /// <summary>
        /// Gets or sets CustomerShipToAddress
        /// </summary>
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string CustomerShipToAddress { get; set; }

        /// <summary>
        /// Gets or sets DropShipDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipDescription { get; set; }

        /// <summary>
        /// Gets or sets DropShipAddress1
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipAddress1 { get; set; }

        /// <summary>
        /// Gets or sets DropShipAddress2
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipAddress2 { get; set; }

        /// <summary>
        /// Gets or sets DropShipAddress3
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipAddress3 { get; set; }

        /// <summary>
        /// Gets or sets DropShipAddress4
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipAddress4 { get; set; }

        /// <summary>
        /// Gets or sets DropShipCity
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipCity { get; set; }

        /// <summary>
        /// Gets or sets DropShipStateProvince
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipStateProvince { get; set; }

        /// <summary>
        /// Gets or sets DropShipZipPostalCode
        /// </summary>
        [StringLength(20, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets DropShipCountry
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipCountry { get; set; }

        /// <summary>
        /// Gets or sets DropShipPhoneNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets DropShipFaxNumber
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipFaxNumber { get; set; }

        /// <summary>
        /// Gets or sets DropShipEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipEmail { get; set; }

        /// <summary>
        /// Gets or sets DropShipContact
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipContact { get; set; }

        /// <summary>
        /// Gets or sets DropShipContactPhone
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipContactPhone { get; set; }

        /// <summary>
        /// Gets or sets DropShipContactFax
        /// </summary>
        [StringLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipContactFax { get; set; }

        /// <summary>
        /// Gets or sets DropShipContactEmail
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string DropShipContactEmail { get; set; }
    }
}
