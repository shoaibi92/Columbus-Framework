/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.IO;

#endregion




namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Email
{
    /// <summary>
    ///  Email model used as seed entitty
    /// </summary>
    public class EmailOption : ModelBase
    {

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        public string To { get; set; }
       
        /// <summary>
        /// Gets or Sets Cc
        /// </summary>
        public string Cc { get; set; }

        /// <summary>
        /// Gets or Sets Bcc
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        /// Gets or Sets Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or Sets Stream Attachment
        /// </summary>
        public Stream StreamAttachment { get; set; }

        /// <summary>
        /// Gets or Sets File Attachment
        /// </summary>
        public FileStream FileAttachment { get; set; }

    }
}
