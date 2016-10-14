using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesSplit
    {
        /// <summary>
        /// Gets or sets Salesperson1 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Salesperson1 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson2 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Salesperson2 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson3 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Salesperson3 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson4 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Salesperson4 { get; set; }

        /// <summary>
        /// Gets or sets Salesperson5 
        /// </summary>
        [StringLength(8, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Salesperson5 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage1 
        /// </summary>

        public decimal SalesSplitPercentage1 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage2 
        /// </summary>

        public decimal SalesSplitPercentage2 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage3 
        /// </summary>

        public decimal SalesSplitPercentage3 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage4 
        /// </summary>

        public decimal SalesSplitPercentage4 { get; set; }

        /// <summary>
        /// Gets or sets SalesSplitPercentage5 
        /// </summary>

        public decimal SalesSplitPercentage5 { get; set; }
		 
    }

    /// <summary>
    /// Table Representaion of Sales Split Columns.
    /// </summary>
    public class SalesSplitTable : ModelBase
    {
        public int LineNumber { get; set; }

        public string SalesPerson { get; set; }

        public decimal SalesSplitPercentage { get; set; }

        public string SalesPersonCode { get; set; }
    }
}
