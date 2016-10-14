// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Email
{
    /// <summary>
    /// Class for Email Content
    /// </summary>
    public class EmailContent
    {
        #region Properties

        /// <summary>
        /// Property for Customer Number
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Property for Customer Name
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Property for Contact Name
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Property for Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Property for Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Property for Fax Number
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Property for Phone Format
        /// </summary>
        public bool PhoneFormat { get; set; }

        /// <summary>
        /// Property for Profile Contact Name
        /// </summary>
        public string ProfileContactName { get; set; }

        /// <summary>
        /// Property for Invoice Number
        /// </summary>
        public string InvoiceNumber { get; set; }


        #endregion
    }
}
