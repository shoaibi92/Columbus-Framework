/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvPaymentSchedule Fields
    /// </summary>
    public partial class POOEBaseInvPaymentSchedule
    {
        /// <summary>
        /// Contains list of InvPaymentSchedule Constants
        /// </summary>
        public class BaseFields
        {
            /// <summary>
            /// Property for InvoiceSequenceKey
            /// </summary>
            public const string InvoiceSequenceKey = "INVHSEQ";

            /// <summary>
            /// Property for PaymentNumber
            /// </summary>
            public const string PaymentNumber = "INVPREV";

            /// <summary>
            /// Property for StoredInDatabaseTable
            /// </summary>
            public const string StoredInDatabaseTable = "INDBTABLE";

            /// <summary>
            /// Property for BaseForDiscount
            /// </summary>
            public const string BaseForDiscount = "DISCBASE";

            /// <summary>
            /// Property for DiscountDate
            /// </summary>
            public const string DiscountDate = "DISCDATE";

            /// <summary>
            /// Property for DiscountPercentage
            /// </summary>
            public const string DiscountPercentage = "DISCPER";

            /// <summary>
            /// Property for DiscountAmount
            /// </summary>
            public const string DiscountAmount = "DISCAMT";

            /// <summary>
            /// Property for DueBase
            /// </summary>
            public const string DueBase = "DUEBASE";

            /// <summary>
            /// Property for DueDate
            /// </summary>
            public const string DueDate = "DUEDATE";

            /// <summary>
            /// Property for PercentageDue
            /// </summary>
            public const string PercentageDue = "DUEPER";

            /// <summary>
            /// Property for AmountDue
            /// </summary>
            public const string AmountDue = "DUEAMT";

            /// <summary>
            /// Property for Payment
            /// </summary>
            public const string Payment = "PAYMENT";
        }
    }
}
