// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Transactions type
    /// </summary>
    public enum Transaction
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// The transaction sale
        /// </summary>
        Sale = 1,

        /// <summary>
        /// The preauthorization
        /// </summary>
        Preauthorization = 2,

        /// <summary>
        /// The capture
        /// </summary>
        Capture = 3,

        /// <summary>
        /// The void preauthorization
        /// </summary>
        VoidPreauth = 4,

        /// <summary>
        /// The void Sale
        /// </summary>
        VoidSale = 5,

        /// <summary>
        /// The credit
        /// </summary>
        Credit = 6,

        /// <summary>
        /// The voidcredit
        /// </summary>
        Voidcredit = 7,

        /// <summary>
        /// The force
        /// </summary>
        Force = 8,

        /// <summary>
        /// The sale pending
        /// </summary>
        SalePending = 11,

        /// <summary>
        /// The preauth pending
        /// </summary>
        PreauthPending = 12,

        /// <summary>
        /// The capture pending
        /// </summary>
        CapturePending = 13,

        /// <summary>
        /// The voidpreauth pending
        /// </summary>
        VoidpreauthPending = 14,

        /// <summary>
        /// The voidsale pending
        /// </summary>
        VoidsalePending = 15,

        /// <summary>
        /// The credit pending
        /// </summary>
        CreditPending = 16,

        /// <summary>
        /// The voidcredit pending
        /// </summary>
        VoidcreditPending = 17
    }
}
