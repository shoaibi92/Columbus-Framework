/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
    /// <summary>
    /// Enum for Create G/L Transactions
    /// </summary>
    public enum DeferGLTransactions
    {
        /// <summary>
        /// Gets or sets During Posting 
        /// </summary>	
        [EnumValue("DuringPosting", typeof(GLIntegrationResx), 1)]
        DuringPosting = 0,
        /// <summary>
        /// Gets or sets On Request Using Create G/L Batch Icon 
        /// </summary>	
        [EnumValue("OnRequestGLBatch", typeof(EnumerationsResx), 2)]
        OnRequestUsingCreateGLBatchIcon = 1,
    }
}
