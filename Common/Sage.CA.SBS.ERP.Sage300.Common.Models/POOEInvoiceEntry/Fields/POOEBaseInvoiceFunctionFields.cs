/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceFunction Fields
    /// </summary>
    public partial class POOEBaseInvoiceFunction
    {
        /// <summary>
        /// Contains list of InvoiceFunction Constants
        /// </summary>
        public class BaseFields
        {
            /// <summary>
            /// Property for InvoiceSequenceKey
            /// </summary>
            public const string InvoiceSequenceKey = "INVHSEQ";

            /// <summary>
            /// Property for SequenceToRetrieve
            /// </summary>
            public const string SequenceToRetrieve = "LOADSEQ";

            /// <summary>
            /// Property for Vendor
            /// </summary>
            public const string Vendor = "VDCODE";

            /// <summary>
            /// Property for ReceiptNumber
            /// </summary>
            public const string ReceiptNumber = "LOADRCPNUM";

            /// <summary>
            /// Property for ReturnNumber
            /// </summary>
            public const string ReturnNumber = "LOADRETNUM";

            /// <summary>
            /// Property for NewTermsCodeEntered
            /// </summary>
            public const string NewTermsCodeEntered = "NEWTERMS";

            /// <summary>
            /// Property for ScheduleCalculationMethod
            /// </summary>
            public const string ScheduleCalculationMethod = "TERMSCALC";

            /// <summary>
            /// Property for PredecessorTimestamp
            /// </summary>
            public const string PredecessorTimestamp = "PREADTSTMP";

            /// <summary>
            /// Property for Function
            /// </summary>
            public const string Function = "FUNCTION";
        }
    }
}
