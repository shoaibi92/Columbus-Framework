/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for VendorActivity
    /// </summary>
    public class VendorActivity : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorActivity"/> class.
        /// </summary>
        public VendorActivity()
        {
            LargestInvoiceVendCurr = new ActivityDetail();
        }

        /// <summary>
        /// Gets or sets LargestInvoiceVendCurr
        /// </summary>
        /// <value>The largest invoice vend curr.</value>
        public ActivityDetail LargestInvoiceVendCurr { get; set; }
    }
}