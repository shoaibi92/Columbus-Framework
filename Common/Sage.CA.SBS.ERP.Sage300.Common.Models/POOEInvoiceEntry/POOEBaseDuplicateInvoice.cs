using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Partial class for POOEBaseDuplicateInvoice
    /// </summary>
    public partial class POOEBaseDuplicateInvoice : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets InvoiceNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceNumber", ResourceType = typeof(InvoiceResx))]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets RequireNewEntry
        /// </summary>
        [Display(Name = "RequireNewEntry", ResourceType = typeof(InvoiceResx))]
        public AllowedType RequireNewEntry { get; set; }

        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Vendor", ResourceType = typeof(InvoiceResx))]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Date", ResourceType = typeof(CommonResx))]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Total
        /// </summary>
        [Display(Name = "Total", ResourceType = typeof(InvoiceResx))]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets NumberOfDuplicates
        /// </summary>
        [Display(Name = "NumberOfDuplicates", ResourceType = typeof(InvoiceResx))]
        public int NumberOfDuplicates { get; set; }

        /// <summary>
        /// Gets or sets Function
        /// </summary>
        [Display(Name = "Function", ResourceType = typeof(InvoiceResx))]
        public int Function { get; set; }

        #region UI Strings

        /// <summary>
        /// Gets RequireNewEntry string value
        /// </summary>
        public string RequireNewEntryString
        {
            get { return EnumUtility.GetStringValue(RequireNewEntry); }
        }

        #endregion
    }
}
