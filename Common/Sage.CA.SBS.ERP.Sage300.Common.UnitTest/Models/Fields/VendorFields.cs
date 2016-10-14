/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of Vendor Fields Constants
    /// </summary>
    public partial class Vendor
    {
        /// <summary>
        /// Entity Name
        /// </summary>
        public const string EntityName = "AP0015";

        /// <summary>
        /// Vendor Fields Constants
        /// </summary>
        public class Fields
        {
            #region Field Names - Note:These field names should be same as the name of the properties defined in other partial class

            /// <summary>
            /// Vendor Number
            /// </summary>
            public const string VendorNumber = "VENDORID";

            /// <summary>
            ///  Status
            /// </summary>
            public const string IsActive = "SWACTV";

             /// <summary>
            /// address Line1
            /// </summary>
            public const string AddressLine1 = "TEXTSTRE1";

            #endregion
        }

        /// <summary>
        /// Vendor Index Constants
        /// </summary>
        public class Index
        {

            #region Field Index

            /// <summary>
            /// Vendor Number
            /// </summary>
            public const int VendorNumber = 1;

            /// <summary>
            /// Status
            /// </summary>
            public const int IsActive = 4;

            /// <summary>
            ///  Address Line 1
            /// </summary>
            public const int AddressLine1 = 11;

            /// <summary>
            ///  Account Set
            /// </summary>
            public const int AccountSet = 23;

            /// <summary>
            ///  Largest Invoice - Vend. Curr.
            /// </summary>
            public const int LargestInvoiceVendorCurrency = 71;

           #endregion

        }
    }
}
