using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models
{
    /// <summary>
    /// PO OE Base Invoice View Model
    /// </summary>
    /// <typeparam name="T">POOEBaseInvoice model</typeparam>
    public class POOEBaseInvoiceViewModel<T> : ViewModelBase<T> where T : POOEBaseInvoice, new()
    {
        /// <summary>
        ///POOEBaseInvoiceViewModel constructor
        /// </summary>
        public POOEBaseInvoiceViewModel()
        {
            ItemTaxes = new EnumerableResponse<TaxGroupAuthority>();
            VendorTaxes = new EnumerableResponse<TaxGroupAuthority>();
        }
        /// <summary>
        /// Get or Set is AttributesHeader
        /// </summary>
        public IDictionary<string, object> AttributesHeader { get; set; }

        /// <summary>
        /// Get or Set is AttributesPaymentSchedule
        /// </summary>
        public IDictionary<string, object> AttributesPaymentSchedule { get; set; }
            

        /// <summary>
        /// Gets or sets AmountDecimal
        /// </summary>
        public int AmountDecimal { get; set; }

        /// <summary>
        /// Gets or sets AmountDecimal
        /// </summary>
        public int TaxReportingDecimal { get; set; }

        /// <summary>
        /// Optional Field License
        /// </summary>
        public bool HasOptionalFieldLicense { get; set; }

        /// <summary>
        ///   Gets or sets  ItemTaxes
        /// </summary>
        public EnumerableResponse<TaxGroupAuthority> ItemTaxes { get; set; }

        /// <summary>
        ///   Gets or sets  VendorTaxes
        /// </summary>
        public EnumerableResponse<TaxGroupAuthority> VendorTaxes { get; set; }
        
    }
    
    /// <summary>
    /// This class is added to pass as detail Line parameter
    /// </summary>
    public class AdditionalCostParameter
    {
        /// <summary>
        /// Line Index
        /// </summary>
        public int DisplayIndex { get; set; }

        /// <summary>
        /// Purchase Order Sequence Key
        /// </summary>
        public decimal SequenceNumber { get; set; }

        /// <summary>
        /// Line Key
        /// </summary>
        public decimal LineNumber { get; set; }
        
        /// <summary>
        /// New Line
        /// </summary>
        public bool IsNewLine { get; set; }

        /// <summary>
        /// Has Line Changed
        /// </summary>
        public bool HasChanged { get; set; }

        /// <summary>
        /// Event Type
        /// </summary>
        public int EventType { get; set; }
    }
}