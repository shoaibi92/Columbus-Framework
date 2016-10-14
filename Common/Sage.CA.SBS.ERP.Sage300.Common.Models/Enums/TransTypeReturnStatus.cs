// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    public enum TransTypeReturnStatus
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// The error
        /// Error occurs when calling SPS, i.e. internet is down. Should continue the pending processg next time
        /// </summary>
        Error = 2,

        /// <summary>
        /// The cancel
        /// User cancels the process. No charge is made
        /// </summary>
        Cancel = 3,

        /// <summary>
        /// The card approved
        /// Card processed successfully through SPS and the charge is made
        /// </summary>
        CardApproved = 4,

        /// <summary>
        /// The card declined
        /// Card processed successfully through SPS and but it is declined. No charge is made
        /// </summary>
        CardDeclined = 5,

        /// <summary>
        /// The card error
        /// Card processed successfully through SPS but has error (i.e. address problem). The
        /// card number might still be good. No charge is made, and should try again later
        /// </summary>
        CardError = 6
    }
}
