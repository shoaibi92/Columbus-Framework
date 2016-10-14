// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord
{
    /// <summary>
    /// User Tenant
    /// </summary>
    public class UserTenant
    {
        /// <summary>
        /// Unique id for UserTenant
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Product user Id
        /// </summary>
        [ForeignKey("User")]
        public Guid ProductUserId { get; set; }

        /// <summary>
        /// Unique id of a tenant
        /// </summary>
        [ForeignKey("Tenant")]
        [Required]
        [Column("Tenant_Id")]
        public int TenantId { get; set; }

        /// <summary>
        /// Sage300 login id
        /// </summary>
        /// <value>
        /// The application login identifier.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string ApplicationLoginId { get; set; }

        /// <summary>
        /// User password (encrypted)
        /// </summary>
        /// <value>
        /// The application password.
        /// </value>
        [MaxLength(500)]
        public string ApplicationPassword { get; set; }

        /// <summary>
        /// User 
        /// </summary>
        [ForeignKey("ProductUserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }
    }
}