// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

namespace Sage.CA.SBS.ERP.Sage300.DateTimeResearch
{
    /// <summary>
    /// Enum for Repository Types
    /// </summary>
    public enum RepositoryType
    {
        /// <summary>
        /// Unknown - Will not generate type specific files
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Flat Repository - Stateless
        /// </summary>
        Flat = 1,
        /// <summary>
        /// Process Repository
        /// </summary>
        Process = 2,
        /// <summary>
        /// Dynamic Query Repository
        /// </summary>
        DynamicQuery = 3,
        /// <summary>
        /// Report Repository
        /// </summary>
        Report = 4,
        /// <summary>
        /// Inquiry Repository
        /// </summary>
        Inquiry = 5
    }
}
