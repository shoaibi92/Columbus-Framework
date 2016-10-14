/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Email
{
    /// <summary>
    /// Class for Email Utility
    /// </summary>
    public static class EmailUtility
    {
        #region Properties

        /// <summary>
        /// Constant for Customer Id Place Holder
        /// </summary>
        private const string CustomerIdPlaceHolder = "$CUSTOMER_ID";

        /// <summary>
        /// Constant for Customer Name Place Holder
        /// </summary>
        private const string CustomerNamePlaceHolder = "$CUSTOMER_NAME";

        /// <summary>
        /// Constant for Customer Contact Place holder
        /// </summary>
        private const string CustomerContactPlaceholder = "$CUSTOMER_CONTACT";

        /// <summary>
        /// Constant for Company Phone Place holder
        /// </summary>
        private const string CompanyPhonePlaceholder = "$COMPANY_PHONE";

        /// <summary>
        /// Constant for Company Fax Place holder
        /// </summary>
        private const string CompanyFaxPlaceholder = "$COMPANY_FAX";

        /// <summary>
        /// Constant for Company Contact Place holder
        /// </summary>
        private const string CompanyContactPlaceholder = "$COMPANY_CONTACT";

        /// <summary>
        /// Constant for Company Name Place holder
        /// </summary>
        private const string CompanyNamePlaceholder = "$COMPANY_NAME";

        /// <summary>
        /// Constant for Invoice number Place holder
        /// </summary>
        private const string InvoiceNumberPlaceholder = "$INVOICE_NUMBER";


        #endregion

        #region Public Methods

        /// <summary>
        /// Replace email symbols
        /// </summary>
        /// <param name="message">Message Body</param>
        /// <param name="content">Email Subject and Signature Contents</param>
        /// <returns>Replaced Message</returns>
        public static string ReplaceSymbols(string message, EmailContent content)
        {
            if (string.IsNullOrEmpty(message)) { return message; }
            if (message.Contains(CustomerIdPlaceHolder))
            {
                message = message.Replace(CustomerIdPlaceHolder, content.CustomerNumber);
            }
            if (message.Contains(CustomerNamePlaceHolder))
            {
                message = message.Replace(CustomerNamePlaceHolder, content.CustomerName);
            }
            if (message.Contains(CustomerContactPlaceholder))
            {
                message = message.Replace(CustomerContactPlaceholder, content.ContactName);
            }
            if (message.Contains(CompanyPhonePlaceholder))
            {
                var formattedPhoneNumber = content.PhoneFormat
                    ? CommonUtil.FormatPhoneNumber(content.PhoneNumber)
                    : content.PhoneNumber;
                message = message.Replace(CompanyPhonePlaceholder, formattedPhoneNumber);
            }
            if (message.Contains(CompanyFaxPlaceholder))
            {
                var formattedFaxNumber = content.PhoneFormat
                    ? CommonUtil.FormatPhoneNumber(content.FaxNumber)
                    : content.PhoneNumber;
                message = message.Replace(CompanyFaxPlaceholder, formattedFaxNumber);
            }
            if (message.Contains(CompanyContactPlaceholder))
            {
                message = message.Replace(CompanyContactPlaceholder, content.ProfileContactName);
            }
            if (message.Contains(CompanyNamePlaceholder))
            {
                message = message.Replace(CompanyNamePlaceholder, content.CompanyName);
            }
            if (message.Contains(InvoiceNumberPlaceholder))
            {
                message = message.Replace(InvoiceNumberPlaceholder, content.InvoiceNumber);
            }


            return message;
        }

        #endregion
    }
}
