using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models
{
    /// <summary>
    /// BaseInvoiceEntryViewModel 
    /// </summary>
    /// <typeparam name="T">ModelBase</typeparam>
    public class BaseInvoiceEntryViewModel<T> : ViewModelBase<T> where T : BaseInvoiceBatch, new()
    {
        /// <summary>
        /// Get or Set To Action
        /// </summary>
        /// <value>To action.</value>
        public string ToAction { get; set; }

        /// <summary>
        /// Get or Set To Action
        /// </summary>
        /// <value>The type of the action.</value>
        [DefaultValue("")]
        public string ActionType { get; set; }

        /// <summary>
        /// Gets and sets RetainageTermsCodeDescription
        /// </summary>
        [Display(Name = "TermsCodeDescription", ResourceType = typeof(InvoiceResx))]
        public string RetainageTermsCodeDescription { get; set; }

        /// <summary>
        /// Gets and sets CurrencyCodeDescription
        /// </summary>
        [Display(Name = "CurrencyDescription", ResourceType = typeof(InvoiceResx))]
        public string CurrencyCodeDescription { get; set; }

        /// <summary>
        /// Gets and sets RatesTypeDescription
        /// </summary>
        [Display(Name = "RateTypeDescription", ResourceType = typeof(InvoiceResx))]
        public string RatesTypeDescription { get; set; }

        /// <summary>
        /// Gets and sets TaxCurrencyCodeDescription
        /// </summary>
        [Display(Name = "CurrencyDescription", ResourceType = typeof(InvoiceResx))]
        public string TaxCurrencyCodeDescription { get; set; }

        /// <summary>
        /// Gets and sets TaxRatesTypeDescription
        /// </summary>
        [Display(Name = "RateTypeDescription", ResourceType = typeof(InvoiceResx))]
        public string TaxRatesTypeDescription { get; set; }

        /// <summary>
        /// Gets and Sets AmountDecimals. This value is set based on vendor currency code
        /// </summary>
        public int AmountDecimals { get; set; }

        /// <summary>
        /// Gets and Sets RetainageAllowed. This value is set based on Options Screen Retainage Allowed Checkbox.
        /// </summary>
        public bool RetainageAllowed { get; set; }

        /// <summary>
        /// Gets and Sets IsMulticurrency. This value is set based on Options Screen Multicurrency Checkbox.
        /// </summary>
        public bool IsMulticurrency { get; set; }

        /// <summary>
        /// Gets and Sets RateSpread. Stores Rate Spread.
        /// </summary>
        public decimal RateSpread { get; set; }

        /// <summary>
        /// Optional Field License
        /// </summary>
        public bool HasOptionalFieldLicense { get; set; }

        /// <summary>
        /// Gets and Sets TaxReportingRateSpread. Stores Tax Reporting Rate Spread.
        /// </summary>
        public decimal TaxReportingRateSpread { get; set; }

        /// <summary>
        /// Gets and Sets TaxReportDecimal. Stores the tax reporting currency decimal.
        /// </summary>
        public int TaxReportDecimal { get; set; }

        /// <summary>
        /// Gets ands sets  DetailTotalTax. Stores Data for detail taxes.
        /// </summary>
        public decimal DetailTotalTax { get; set; }

        /// <summary>
        /// Gets ands sets  DetailTotalRetainageTax. Stores Data for detail taxes.
        /// </summary>
        public decimal DetailTotalRetainageTax { get; set; }

        /// <summary>
        /// Gets ands sets  DetailTotalReportingTax. Stores Data for detail taxes.
        /// </summary>
        public decimal DetailTotalReportingTax { get; set; }

        /// <summary>
        ///   Get or set LoadAsDefault
        /// </summary>
        public bool LoadAsDefault { get; set; }


        #region Vendor Information

        /// <summary>
        ///  Get and set  Address1
        /// </summary>
        [Display(Name = "AddressLine1", ResourceType = typeof(InvoiceResx))]
        public string Address1 { get; set; }

        /// <summary>
        ///  Get and set  Address2
        /// </summary>
        [Display(Name = "AddressLine2", ResourceType = typeof(InvoiceResx))]
        public string Address2 { get; set; }

        /// <summary>
        ///  Get and set  Address3
        /// </summary>
        [Display(Name = "AddressLine3", ResourceType = typeof(InvoiceResx))]
        public string Address3 { get; set; }

        /// <summary>
        ///  Get and set  Address4
        /// </summary>
        [Display(Name = "AddressLine4", ResourceType = typeof(InvoiceResx))]
        public string Address4 { get; set; }

        /// <summary>
        ///  Get and set  City
        /// </summary>
        [Display(Name = "City", ResourceType = typeof(InvoiceResx))]
        public string City { get; set; }

        /// <summary>
        ///  Get and set StateOrProvince
        /// </summary>
        [Display(Name = "StateProvince", ResourceType = typeof(InvoiceResx))]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///  Get and set Country
        /// </summary>
        [Display(Name = "Country", ResourceType = typeof(InvoiceResx))]
        public string Country { get; set; }

        /// <summary>
        ///  Get and set Phone
        /// </summary>
        [Display(Name = "Phone", ResourceType = typeof(InvoiceResx))]
        public string Phone { get; set; }

        /// <summary>
        ///  Get and set Fax
        /// </summary>
        [Display(Name = "Fax", ResourceType = typeof(InvoiceResx))]
        public string Fax { get; set; }

        /// <summary>
        ///  Get and set PostalCode
        /// </summary>
        [Display(Name = "ZIPPostalCode", ResourceType = typeof(InvoiceResx))]
        public string PostalCode { get; set; }

        /// <summary>
        ///  Get and set Email
        /// </summary>
        [Display(Name = "EmailAddress", ResourceType = typeof(InvoiceResx))]
        public string Email { get; set; }

        /// <summary>
        ///  Get and set Contact Name
        /// </summary>
        [Display(Name = "ContactName", ResourceType = typeof(InvoiceResx))]
        public string ContactName { get; set; }

        /// <summary>
        ///  Get and set Contact Phone
        /// </summary>
        [Display(Name = "ContactsPhone", ResourceType = typeof(InvoiceResx))]
        public string ContactPhone { get; set; }

        /// <summary>
        ///  Get and set Contact Fax
        /// </summary>
        [Display(Name = "ContactsFax", ResourceType = typeof(InvoiceResx))]
        public string ContactFax { get; set; }

        /// <summary>
        ///  Get and set Contact Email
        /// </summary>
        [Display(Name = "ContactsEmail", ResourceType = typeof(InvoiceResx))]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Checks if phone format is available in the options
        /// </summary>
        public bool FormatPhone { get; set; }

        #endregion
    }
}