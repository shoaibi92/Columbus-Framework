/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Email
{
    /// <summary>
    /// Class EmailResponse
    /// </summary>
    public class EmailResponse
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResponse"/> class.
        /// </summary>
        public EmailResponse()
        {
            Results = new List<EntityError>();
        }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public List<EntityError> Results { get; set; }

        /// <summary>
        /// Process status
        /// </summary>
        /// <value>The status.</value>
        public ProcessStatus Status { get; set; }
    }
}
