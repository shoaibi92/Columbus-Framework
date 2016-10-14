// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    ///  Contains List Of GL Transaction Reports Fields
    /// </summary>
    public partial class GLSubledgerTransactionReport
    {
        /// <summary>
        /// Unique name
        /// </summary>
        public const string EntityName = "09880749-595C-4F94-887C-8E4E92A238CA";

        /// <summary>
        /// GL Transaction Reports Fields Constants
        /// </summary>
        public class Fields
        {
            #region Field Names

            /// <summary>
            /// Property for FunctionalCurrencyDecimals
            /// </summary>
            public const string FunctionalCurrencyDecimals = "FUNCDEC";

            /// <summary>
            /// Property for ThroughPostingSequence
            /// </summary>
            public const string ThroughPostingSequence = "TOSEQ";

            /// <summary>
            /// Property for SourceApplication
            /// </summary>
            public const string SourceApplication = "SRCEAPP";

            /// <summary>
            /// Property for ReportNamePrefix
            /// </summary>
            public const string ReportNamePrefix = "PREFIX";

            /// <summary>
            /// Property for MultiCurrency
            /// </summary>
            public const string MultiCurrency = "MULTICUR";

            /// <summary>
            /// Property for PostingSequenceCaption
            /// </summary>
            public const string PostingSequenceCaption = "SEQCAPTION";

            /// <summary>
            /// Property for PostingSequenceTitle1
            /// </summary>
            public const string PostingSequenceTitle1 = "SEQTITLE1";

            /// <summary>
            /// Property for PostingSequenceTitle2
            /// </summary>
            public const string PostingSequenceTitle2 = "SEQTITLE2";

            #endregion
        }
    }
}
