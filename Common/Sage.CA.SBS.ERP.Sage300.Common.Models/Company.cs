/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class for the Company object used for common Email utility.
    /// </summary>
    public class Company
    {
        #region Properties

        /// <summary>
        /// Gets or sets Address1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        ///  Gets or sets Address2
        /// </summary>
        public string Address2 { get; set; }
        
        /// <summary>
        ///  Gets or sets Address3
        /// </summary>
        public string Address3 { get; set; }
        
        /// <summary>
        ///  Gets or sets Address4
        /// </summary>
        public string Address4 { get; set; }
        
        /// <summary>
        ///  Gets or sets BranchCode
        /// </summary>
        public string BranchCode { get; set; }
        
        /// <summary>
        ///  Gets or sets City
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        ///  Gets or sets Contact
        /// </summary>
        public string Contact { get; set; }
        
        /// <summary>
        ///  Gets or sets Country
        /// </summary>
        public string Country { get; set; }
        
        /// <summary>
        ///  Gets or sets CountryCode
        /// </summary>
        public string CountryCode { get; set; }
        
        /// <summary>
        ///  Gets or sets EuroCurrency
        /// </summary>
        public bool EuroCurrency { get; set; }
        
        /// <summary>
        ///  Gets or sets Fax
        /// </summary>
        public string Fax { get; set; }
        
        /// <summary>
        ///  Gets or sets FiscalPeriods
        /// </summary>
        public short FiscalPeriods { get; set; }
        
        /// <summary>
        ///  Gets or sets FourPeriodQuarter
        /// </summary>
        public short FourPeriodQuarter { get; set; }

        /// <summary>
        /// Gets or sets GainLossAccountingMethod
        /// </summary>
        public CompanyGainLossAccountingMethod GainLossAccountingMethod { get; set; }
        
        /// <summary>
        /// Gets or sets HandleInactiveGLAccounts
        /// </summary>
        public UserMessageType HandleInactiveGLAccounts { get; set; }
        
        /// <summary>
        /// Gets or sets HandleLockedFiscalPeriods
        /// </summary>
        public UserMessageType HandleLockedFiscalPeriods { get; set; }
        
        /// <summary>
        /// Gets or sets HandleNonexistentGLAccounts
        /// </summary>
        public UserMessageType HandleNonexistentGLAccounts { get; set; }
        
        /// <summary>
        ///  Gets or sets HomeCurrency
        /// </summary>
        public string HomeCurrency { get; set; }
        
        /// <summary>
        ///  Gets or sets LegalName
        /// </summary>
        public string LegalName { get; set; }
        
        /// <summary>
        ///  Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        
        /// <summary>
        ///  Gets or sets  LocationType
        /// </summary>
        public string LocationType { get; set; }
        
        /// <summary>
        ///  Gets or sets Multicurrency
        /// </summary>
        public bool Multicurrency { get; set; }
        
        /// <summary>
        ///  Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///  Gets or sets OrgID
        /// </summary>
        public string OrgID { get; set; }
        
        /// <summary>
        ///  Gets or sets Phone
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        ///  Gets or sets PhoneFormat
        /// </summary>
        public bool PhoneFormat { get; set; }
        
        /// <summary>
        ///  Gets or sets PhoneMask
        /// </summary>
        public string PhoneMask { get; set; }
        
        /// <summary>
        ///  Gets or sets PostCode
        /// </summary>
        public string PostCode { get; set; }
        
        /// <summary>
        ///  Gets or sets  RateType
        /// </summary>
        public string RateType { get; set; }
        
        /// <summary>
        ///  Gets or sets  ReportingCurrency
        /// </summary>
        public string ReportingCurrency { get; set; }
        
        /// <summary>
        ///  Gets or sets SessionWarnDays
        /// </summary>
        public short SessionWarnDays { get; set; }
        
        /// <summary>
        ///  Gets or sets State
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        ///  Gets or sets TaxNumber
        /// </summary>
        public string TaxNumber { get; set; }

        #endregion
    }
}
