/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces
{
    /// <summary>
    /// Interface IDataProcessor
    /// </summary>
    public interface IDataProcessor
    {
        /// <summary>
        /// Property TotalFiles
        /// </summary>
        int TotalFiles { get; }

        /// <summary>
        /// Process the input data
        /// </summary>
        void Process();
    }
}
