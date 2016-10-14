/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for Vendor
    /// </summary>
    public partial class Vendor : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Vendor"/> class.
        /// </summary>
        public Vendor()
        {
            Address = new Address();
            Statistics = new VendorStatistics();
            Addresses = new List<Address>();
            AddressesAsEnumerableResponse = new EnumerableResponse<Address>();
        }

        /// <summary>
        /// Gets or sets Vendor Number
        /// </summary>
        /// <value>The vendor number.</value>
        public string VendorNumber { get; set; }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets ActiveInActiveStatus
        /// </summary>
        /// <value>The status description.</value>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets Address
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets Statistics
        /// </summary>
        /// <value>The statistics.</value>
        public VendorStatistics Statistics { get; set; }

        /// <summary>
        /// Gets or sets Activity
        /// </summary>
        /// <value>The activity.</value>
        public VendorActivity Activity { get; set; }

        /// <summary>
        /// Gets or Sets Addresses
        /// </summary>
        public IEnumerable<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or Sets Addresses
        /// </summary>
        public EnumerableResponse<Address> AddressesAsEnumerableResponse { get; set; }
    }
}