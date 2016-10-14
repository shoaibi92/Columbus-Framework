/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Different Finders Types
    /// </summary>
    public enum FinderType
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// Account Set
        /// </summary>
        [EnumValue("FinderType_AccountSet", typeof (EnumerationsResx))] AccountSet,

        /// <summary>
        /// distribution Set
        /// </summary>
        [EnumValue("FinderType_DistributionSet", typeof (EnumerationsResx))] DistributionSet,

        /// <summary>
        /// Terms Set
        /// </summary>
        [EnumValue("FinderType_TermsCode", typeof (EnumerationsResx))] TermsCode,

        /// <summary>
        /// Batch Number
        /// </summary>
        [EnumValue("FinderType_BatchNumberCode", typeof (EnumerationsResx))] BatchNumberCode,

        /// <summary>
        /// Batch Number
        /// </summary>
        [EnumValue("FinderType_SourceLedgerCode", typeof (EnumerationsResx))] SourceLedgerCode,

        /// <summary>
        /// Batch Number
        /// </summary>
        [EnumValue("FinderType_SourceJournalProfile", typeof (EnumerationsResx))] SourceJournalProfile
    }
}