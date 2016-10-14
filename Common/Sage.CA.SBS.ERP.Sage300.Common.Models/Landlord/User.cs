// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord
{
    /// <summary>
    ///     User model
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Product User Id
        /// </summary>
        [Key]
        [Required]
        public Guid ProductUserId { get; set; }

        /// <summary>
        ///     Gets or sets the User display name.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the User email.
        /// </summary>
        [MaxLength(100)]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the First Time User
        ///     When the table gets created by EF, the default values will not be set.    
        ///     Came to know http://entityframework.codeplex.com/workitem/44, we have an open issue on Ef.
        ///     We expect the schema gets created earlier this shouldn't be an issue.
        /// </summary>
        [DefaultValue(1)]
        [Required]
        public bool FirstTimeUser { get; set; }

        /// <summary>
        ///     Gets or sets the User status.
        /// </summary>
        [MaxLength(20)]
        public string Status { get; set; }

        /// <summary>
        ///     Gets or sets the Last updated timestamp of this record (as a unique number).
        /// </summary>
        [Timestamp]
        public byte[] UpdatedTimestamp { get; set; }

        /// <summary>
        ///     Gets or sets the Last updated datetime of this record.
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}