// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Tax Group Authority Class
    /// </summary>
    public class TaxGroupAuthority : ModelBase
    {
        /// <summary>
        /// Gets and Sets LineNumber
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets and Sets TaxAuthority
        /// </summary>
        [Display(Name = "TaxAuth", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthority { get; set; }

        /// <summary>
        /// Gets and Sets TaxAuthorityDescription
        /// </summary>
        [Display(Name = "ColAUTHDESC", ResourceType = typeof(InvoiceResx))]
        public string TaxAuthorityDescription { get; set; }

        /// <summary>
        /// Gets and Sets VendorTaxClass
        /// </summary>
        [Display(Name = "VenTaxClss", ResourceType = typeof(InvoiceResx))]
        public int VendorTaxClass { get; set; }

        /// <summary>
        /// Gets and Sets VendorTaxClassDescription
        /// </summary>
        [Display(Name = "ColVENDORCLSDSC", ResourceType = typeof(InvoiceResx))]
        public string VendorTaxClassDescription { get; set; }

        /// <summary>
        /// Gets and Sets ItemTaxClass
        /// </summary>
        [Display(Name = "ItemTaxClss", ResourceType = typeof(InvoiceResx))]
        public int ItemTaxClass { get; set; }

        /// <summary>
        /// Gets and Sets ItemTaxClassDecription
        /// </summary>
        [Display(Name = "ColITEMCLASDSC", ResourceType = typeof(InvoiceResx))]
        public string ItemTaxClassDecription { get; set; }

        /// <summary>
        /// Gets and Sets TaxIncluded
        /// </summary>
        [Display(Name = "TaxInclude", ResourceType = typeof(InvoiceResx))]
        public AllowedType TaxIncluded { get; set; }

        /// <summary>
        /// Gets and Sets TaxIncluded
        /// </summary>
        [Display(Name = "TaxInclude", ResourceType = typeof(InvoiceResx))]
        public decimal TaxInclude { get; set; }

        /// <summary>
        /// Gets and Sets TaxBase
        /// </summary>
        [Display(Name = "TaxBase", ResourceType = typeof(InvoiceResx))]
        public decimal TaxBase { get; set; }

        /// <summary>
        /// Gets and Sets TaxAmount
        /// </summary>
        [Display(Name = "TaxAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// Gets and Sets TaxReportingAmount
        /// </summary>
        [Display(Name = "TaxRCAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TaxReportingAmount { get; set; }

        /// <summary>
        /// Gets and Sets RetainageTaxAmount
        /// </summary>
        [Display(Name = "RetainageTaxAmount", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxAmount { get; set; }

        /// <summary>
        /// Gets and Sets RetainageTaxBase
        /// </summary>
        [Display(Name = "RetainageTaxBase", ResourceType = typeof(InvoiceResx))]
        public decimal RetainageTaxBase { get; set; }

        /// <summary>
        /// Gets and Sets TaxClass
        /// </summary>
        [Display(Name = "TaxClass", ResourceType = typeof(InvoiceResx))]
        public int TaxClass { get; set; }

        /// <summary>
        /// Gets and Sets for TaxClassDescription
        /// </summary>
        public string TaxClassDescription { get; set; }

        /// <summary>
        /// Gets and Sets TotalTaxAmount
        /// </summary>
        [Display(Name = "TotalTaxAmount", ResourceType = typeof(InvoiceResx))]
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets and Sets TaxExcluded
        /// </summary>
        [Display(Name = "TaxExcluded", ResourceType = typeof(InvoiceResx))]
        public decimal TaxExcluded { get; set; }

        /// <summary>
        /// Gets and Sets AllocatedTax
        /// </summary>
        public decimal AllocatedTax { get; set; }

        /// <summary>
        /// Gets and Sets RecoverableTax
        /// </summary>
        public decimal RecoverableTax { get; set; }

        /// <summary>
        /// Gets and Sets ExpenseTax
        /// </summary>
        public decimal ExpenseTax { get; set; }

        /// <summary>
        /// Get the Print Comment
        /// </summary>
        public IEnumerable<CustomSelectList> GetTaxIncluded
        {
            get
            {
                return EnumUtility.GetItemsList<AllowedType>();
            }
        }

        /// <summary>
        /// Gets TaxIncluded string value
        /// </summary>
        public string TaxIncludedString
        {
            get { return EnumUtility.GetStringValue(TaxIncluded); }
        }
    }
}
