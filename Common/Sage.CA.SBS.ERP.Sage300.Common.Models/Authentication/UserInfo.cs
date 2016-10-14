/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication
{
    /// <summary>
    /// Person Information model
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// First name of the Person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Is Person Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Last name of the Person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Middle name of the Person
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Person id
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Primary Email of the Person
        /// </summary>
        public string PrimaryEmail { get; set; }

        /// <summary>
        /// User Management Url
        /// </summary>
        public string UserManagementUrl { get; set; }

        /// <summary>
        /// Is Guest user
        /// </summary>
        public bool IsGuest { get; set; }

        /// <summary>
        /// Product user id
        /// </summary>
        public Guid ProductUserId { get; set; }

        /// <summary>
        /// First Time User
        /// </summary>
        public bool FirstTimeUser { get; set; }

        /// <summary>
        /// Gets or sets the value specifying whether the user has been fully provisioned or not.
        /// </summary>
        public bool Provisioned { get; set; }
    }
}