/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceComments  Fields
    /// </summary>
    public partial class POOEBaseInvoiceComments
    {
        #region Properties
        /// <summary>
        /// Contains list of InvoiceComment Constants
        /// </summary>
        public class BaseFields
        {
            /// <summary>
            /// Property for InvoiceSequenceKey
            /// </summary>
            public const string InvoiceSequenceKey = "INVHSEQ";

            /// <summary>
            /// Property for CommentIdentifier
            /// </summary>
            public const string CommentIdentifier = "INVCREV";

            /// <summary>
            /// Property for InvoiceCommentSequence
            /// </summary>
            public const string InvoiceCommentSequence = "INVCSEQ";

            /// <summary>
            /// Property for StoredInDatabaseTable
            /// </summary>
            public const string StoredInDatabaseTable = "INDBTABLE";

            /// <summary>
            /// Property for LineType
            /// </summary>
            public const string LineType = "COMMENTTYP";

            /// <summary>
            /// Property for Comment
            /// </summary>
            public const string Comment = "COMMENT";
        }
        #endregion
    }
}
