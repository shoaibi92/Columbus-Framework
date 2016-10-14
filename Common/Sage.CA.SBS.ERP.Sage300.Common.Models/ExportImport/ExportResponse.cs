/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Export Response
    /// </summary>
    public class ExportResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportResponse"/> class.
        /// </summary>
        public ExportResponse()
        {
            StatusText = new List<string>();
            Results = new List<EntityError>();
        }

        /// <summary>
        /// File which has to be exported or whose content has to imported
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Name - what is being export
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Count of rows inserted/deleted/updated with the businuss entity details
        /// </summary>
        /// <value>The status text.</value>
        public IList<string> StatusText { get; set; }

        /// <summary>
        /// File which has to be exported or whose content has to imported
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

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