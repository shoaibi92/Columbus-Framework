/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceReciepts
    /// </summary>
    public partial class POOEBaseInvoiceReciepts
    {
        #region Properties

        /// <summary>
        /// Contains list of InvoiceReceipt Constants
        /// </summary>
        public class BaseFields
        {
            /// <summary>
            /// Property for InvoiceSequenceKey
            /// </summary>
            public const string InvoiceSequenceKey = "INVHSEQ";

            /// <summary>
            /// Property for LineNumber
            /// </summary>
            public const string LineNumber = "INVRREV";

            /// <summary>
            /// Property for ReceiptSequenceKey
            /// </summary>
            public const string ReceiptSequenceKey = "RCPHSEQ";

            /// <summary>
            /// Property for ReceiptNumber
            /// </summary>
            public const string ReceiptNumber = "RCPNUMBER";

            /// <summary>
            /// Property for StoredInDatabaseTable
            /// </summary>
            public const string StoredInDatabaseTable = "INDBTABLE";

            /// <summary>
            /// Property for Line
            /// </summary>
            public const string Line = "RCP";
        }

        #endregion
    }
}
