// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord
{
    /// <summary>
    /// Tenant Model
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Tenant Id
        /// </summary>
        [Index(IsUnique = true)]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Site Id
        /// </summary>
        [Index(IsUnique = true)]
        [Required]
        public Guid SiteId { get; set; }

        /// <summary>
        ///     Gets or sets the Tenant unique internal name.
        /// </summary>
        [Index(IsUnique = true)]
        [Required]
        [MaxLength(36)]
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets the Production version of this Tenant.
        /// </summary>
        [MaxLength(50)]
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the Tenant status.
        /// </summary>
        [Required]
        public int Status { get; set; }

        /// <summary>
        ///     Gets or sets the Last updated timestamp of this record (as a unique number).
        /// </summary>
        [Timestamp]
        public byte[] UpdatedTimestamp { get; set; }

        /// <summary>
        ///     Gets or sets the Last updated datetime of this record
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }
        /// <summary>
        /// Gets or sets the Company of this Tenant.
        /// </summary>
        [StringLength(6)]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the Server Name of this Tenant.
        /// </summary>
        [StringLength(100)]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the Database Name of this Tenant.
        /// </summary>
        [StringLength(100)]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the Database Login of this Tenant.
        /// </summary>
        [StringLength(100)]
        public string DatabaseLogin { get; set; }

        /// <summary>
        /// Gets or sets the Database Password of this Tenant.
        /// </summary>
        [StringLength(500)]
        public string DatabasePassword { get; set; }
    }
}