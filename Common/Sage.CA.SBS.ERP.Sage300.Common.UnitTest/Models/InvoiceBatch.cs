/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for Invoice batch List
    /// </summary>
    public partial class InvoiceBatch : ModelBase
    {
        /// <summary>
        /// Batch Number - CNTBTCH
        /// </summary>
        public int? BatchNumber { get; set; }

        /// <summary>
        /// Description - BTCHDESC
        /// </summary>
        public string BatchDescription { get; set; }

        /// <summary>
        /// Batch Status Description
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return EnumUtility.GetStringValue(Status);
            }
        }

        /// <summary>
        /// Batch Status - BTCHSTTS
        /// </summary>
        public BatchStatus Status { get; set; }

        /// <summary>
        /// Batch Total - AMTENTR
        /// </summary>
        public decimal AmountTotal { get; set; }

    }
}
