/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Text;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Class ResponseMessage.
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// Business Entity Name
        /// </summary>
        /// <value>The business entity.</value>
        public string BusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        /// <value>The updated.</value>
        public int Updated { get; set; }

        /// <summary>
        /// Gets or sets the inserted.
        /// </summary>
        /// <value>The inserted.</value>
        public int Inserted { get; set; }

        /// <summary>
        /// Gets or sets the processed.
        /// </summary>
        /// <value>The processed.</value>
        public int Processed { get; set; }

        /// <summary>
        /// Gets or Sets the additional information
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Text, which will be displayed to USER as a status message
        /// </summary>
        /// <value>The response text.</value>
        public string ResponseText
        {
            get { return string.Format(CommonResx.ImportResponse, BusinessEntity, Updated, Inserted, Processed); }
        }
    }
}