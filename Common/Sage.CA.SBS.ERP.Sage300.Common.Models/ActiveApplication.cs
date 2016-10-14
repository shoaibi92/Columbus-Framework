/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains Active Application for organisation
    /// </summary>
    public class ActiveApplication
    {
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>The application identifier.</value>
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>The application version.</value>
        public string AppVersion { get; set; }

        /// <summary>
        /// Gets or sets the data level.
        /// </summary>
        /// <value>The data level.</value>
        public int DataLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is installed.
        /// </summary>
        /// <value><c>true</c> if this instance is installed; otherwise, <c>false</c>.</value>
        public bool IsInstalled { get; set; }

        /// <summary>
        /// Gets or sets the selector.
        /// </summary>
        /// <value>The selector.</value>
        public string Selector { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>The sequence.</value>
        public string Sequence { get; set; }

        /// <summary>
        /// Gets or sets the formatted application version.
        /// </summary>
        /// <value>The formatted application version.</value>
        public string FormattedAppVersion { get; set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets the name of the formatted application.
        /// </summary>
        /// <value>The name of the formatted application.</value>
        public string FormattedAppName { get; set; }

        /// <summary>
        /// Gets or sets the Application withoout Version
        /// </summary>
        public string AppNameWithoutVersion { get; set; }
    }
}