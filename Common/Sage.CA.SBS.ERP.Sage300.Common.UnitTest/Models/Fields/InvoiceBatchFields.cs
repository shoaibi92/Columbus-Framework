/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of Invoice Batch Constants
    /// </summary>
    public partial class InvoiceBatch
    {
        /// <summary>
        /// Entity Name
        /// </summary>
        public const string EntityName = "AP0020";

        /// <summary>
        /// Contains InvoiceBatch Fields Constants
        /// </summary>
        public class Fields
        {
            #region Field Names - Note:These field names should be same as the name of the properties defined in other partial class

            /// <summary>
            /// Batch Number
            /// </summary>
            public const string BatchNumber = "CNTBTCH";

            /// <summary>
            /// Batch Description
            /// </summary>
            public const string BatchDescription = "BTCHDESC";

            /// <summary>
            /// Batch Status
            /// </summary>
            public const string Status = "BTCHSTTS";

            /// <summary>
            /// Total Amount
            /// </summary>
            public const string AmountTotal = "AMTENTR";

            #endregion
        }

        /// <summary>
        /// Contains InvoiceBatch Index Constants
        /// </summary>
        public class Index
        {
            #region Field Index

            /// <summary>
            /// The batch number
            /// </summary>
            public const int BatchNumber = 1;

            #endregion
        }
    }
}