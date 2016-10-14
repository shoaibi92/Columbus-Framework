/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    public class SessionDateWarning
    {

        /// <summary>
        /// Message to show
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Warning type
        /// </summary>
        public SessionDateWarningType type { get; set; }
    }
}
