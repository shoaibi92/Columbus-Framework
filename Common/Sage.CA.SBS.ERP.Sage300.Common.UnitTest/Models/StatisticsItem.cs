/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Contains list of properties for StatisticsItem
    /// </summary>
    public class StatisticsItem
    {
        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public double Amount { get; set; }

         /// <summary>
        /// Gets or sets TransactionTypeString
        /// </summary>
        public string TransactionTypeString
        {
            get
            {
                return EnumUtility.GetStringValue(TransactionType);
            }
        }

        /// <summary>
        /// Gets or sets TransactionType
        /// </summary>
        public TransactionType TransactionType { get; set; }

    }
}
