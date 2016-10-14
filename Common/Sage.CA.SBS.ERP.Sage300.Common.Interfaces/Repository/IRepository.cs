/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// Export Import Related method (repository)
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// IsReadOnly property - opens business entity in readonly mode
        /// </summary>
        bool IsReadOnly { get; set; }
    }
}
