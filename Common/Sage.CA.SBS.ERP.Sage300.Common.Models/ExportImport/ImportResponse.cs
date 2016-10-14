/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Class ImportResponse.
    /// </summary>
    public class ImportResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportResponse"/> class.
        /// </summary>
        public ImportResponse()
        {
            Messages = new List<ResponseMessage>();
            Errors = new List<string>();
            Results = new List<EntityError>();
        }

        /// <summary>
        /// Count of rows inserted/deleted/updated with the businuss entity details
        /// </summary>
        /// <value>The messages.</value>
        public IList<ResponseMessage> Messages { get; set; }

        /// <summary>
        /// Error Details
        /// </summary>
        /// <value>The errors.</value>
        public IList<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public List<EntityError> Results { get; set; }

        /// <summary>
        /// Response Token Id
        /// </summary>
        /// <value>The response identifier.</value>
        public int ResponseId { get; set; }

        /// <summary>
        /// Export status
        /// </summary>
        /// <value>The status.</value>
        public ProcessStatus Status { get; set; }

        /// <summary>
        /// Status string
        /// </summary>
        /// <value>The status string</value>
        public string StatusString
        {
            get { return EnumUtility.GetStringValue(Status); }
        }
    }
}