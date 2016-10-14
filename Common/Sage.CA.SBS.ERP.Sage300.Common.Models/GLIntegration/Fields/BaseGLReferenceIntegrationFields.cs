// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration
{
    /// <summary>
    /// Contains list of Base G/L Reference Integration Constants
    /// </summary>
    public partial class BaseGLReferenceIntegration
    {
        /// <summary>
        /// Contains list of G/L Reference Integration Fields Constants
        /// </summary>
        public class BaseFields
        {
            #region Properties
            /// <summary>
            /// Property for Source Transaction Type 
            /// </summary>
            public const string SourceTransactionType = "SOURCE";

            /// <summary>
            /// Property for GL Transaction Field 
            /// </summary>
            public const string GLTransactionField = "GLDEST";

            /// <summary>
            /// Property for Separator 
            /// </summary>
            public const string Separator = "SEPARATOR";

            /// <summary>
            /// Property for Example 
            /// </summary>
            public const string Example = "EXAMPLE";

            /// <summary>
            /// Property for Included Segment 1 
            /// </summary>
            public const string IncludedSegment1 = "SEGMENT1";

            /// <summary>
            /// Property for Included Segment 2 
            /// </summary>
            public const string IncludedSegment2 = "SEGMENT2";

            /// <summary>
            /// Property for Included Segment 3 
            /// </summary>
            public const string IncludedSegment3 = "SEGMENT3";

            /// <summary>
            /// Property for Included Segment 4 
            /// </summary>
            public const string IncludedSegment4 = "SEGMENT4";

            /// <summary>
            /// Property for Included Segment 5 
            /// </summary>
            public const string IncludedSegment5 = "SEGMENT5";
            #endregion
        }

        /// <summary>
        /// Contains list of G/L Reference Integration Index Constants
        /// </summary>
        public class BaseIndex
        {
            #region Properties
            /// <summary>
            /// Property Index for Source Transaction Type 
            /// </summary>
            public const int SourceTransactionType = 1;

            /// <summary>
            /// Property Index for GL Or Transaction Field 
            /// </summary>
            public const int GLTransactionField = 2;

            /// <summary>
            /// Property Index for Included Segment 1 
            /// </summary>
            public const int IncludedSegment1 = 5;

            /// <summary>
            /// Property Index for Included Segment 2 
            /// </summary>
            public const int IncludedSegment2 = 6;

            /// <summary>
            /// Property Index for Included Segment 3 
            /// </summary>
            public const int IncludedSegment3 = 7;

            /// <summary>
            /// Property Index for Included Segment 4 
            /// </summary>
            public const int IncludedSegment4 = 8;

            /// <summary>
            /// Property Index for Included Segment 5 
            /// </summary>
            public const int IncludedSegment5 = 9;
            #endregion
        }

    }
}
