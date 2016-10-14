// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration
{
    /// <summary>
    /// Class for G/L Reference Integration Details
    /// </summary>
    public class ReferenceDetail : ModelBase
    {
        /// <summary>
        /// Reference Detail Constructor
        /// </summary>
        public ReferenceDetail()
        {
            SourceTransactionTypeList = new List<Dictionary<string, object>>();
        }

        /// <summary>
        /// Get or Sets for SourceTransactionType
        /// </summary>
        public int SourceTransactionType { get; set; }
        /// <summary>
        /// Get or Sets for GLEntryDescription
        /// </summary>
        public BaseGLReferenceIntegration GLEntryDescription { get; set; }
        /// <summary>
        /// Get or Sets for GLDetailReference
        /// </summary>
        public BaseGLReferenceIntegration GLDetailReference { get; set; }
        /// <summary>
        /// Get or Sets for GLDetailDescription
        /// </summary>
        public BaseGLReferenceIntegration GLDetailDescription { get; set; }
        /// <summary>
        /// Get or Sets for GLDetailComment
        /// </summary>
        public BaseGLReferenceIntegration GLDetailComment { get; set; }
        /// <summary>
        /// Gets or sets Source Transaction Type List
        /// </summary>
        /// <remarks>G/L Source Transaction Type presentation list</remarks>
        public List<Dictionary<string, object>> SourceTransactionTypeList { get; set; }
    }
}
