/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Error model to show up on Error screen
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Message to show on Error page
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Reason for the Error
        /// </summary>
        public string Reason { get; set; }
    }
}