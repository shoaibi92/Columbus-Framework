/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// DistributeProration Model
    /// </summary>
    public partial class DistributeProration : ModelBase
    {
        /// <summary>
        /// Constructor for DistributeProration
        /// </summary>
        public DistributeProration()
        {
            DistributeProrations = new EnumerableResponse<Proration>();
        }

        /// <summary>
        /// Gets or sets ManuallyProratedAmount
        /// </summary>
        [Display(Name = "ManuallyProratedAmount", ResourceType = typeof(DistributeProrationResx))]
        public string ManuallyProratedAmount { get; set; }

        /// <summary>
        /// Gets or sets AmountRemaining
        /// </summary>
        [Display(Name = "AmountRemaining", ResourceType = typeof(DistributeProrationResx))]
        public string AmountRemaining { get; set; }

        /// <summary>
        /// List of Distribute Prorations
        /// </summary>
        public EnumerableResponse<Proration> DistributeProrations { get; set; }
    }
}
