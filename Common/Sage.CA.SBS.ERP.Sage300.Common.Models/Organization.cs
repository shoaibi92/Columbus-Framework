/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class Organization.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the system.
        /// </summary>
        /// <value>The system.</value>
        public string System { get; set; }

        /// <summary>
        /// Gets or sets the is security enabled flag
        /// </summary>
        /// <value>The system.</value>
        public bool IsSecurityEnabled { get; set; }
    }
}