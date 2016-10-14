/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration
{
    /// <summary>
    /// Enum for Create G/L Transactions By 
    /// </summary>
    public enum CreateGLTransactionsBy
    {
        /// <summary>
        /// Gets or sets Adding to an Existing Batch 
        /// </summary>	
        [EnumValue("AddingToExistingBatch", typeof(GLIntegrationResx), 1)]
        AddingtoanExistingBatch = 1,
        /// <summary>
        /// Gets or sets Creating a New Batch 
        /// </summary>	
        [EnumValue("CreatingNewBatch", typeof(GLIntegrationResx), 2)]
        CreatingaNewBatch = 0,
        /// <summary>
        /// Gets or sets Creating and Posting a New Batch 
        /// </summary>	
        [EnumValue("CreatingandPostingNewBatch", typeof(GLIntegrationResx), 3)]
        CreatingandPostingaNewBatch = 2,
    }
}
