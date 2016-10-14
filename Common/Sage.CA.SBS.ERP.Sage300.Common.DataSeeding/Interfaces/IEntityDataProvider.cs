/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Data;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces
{
    /// <summary>
    /// Interface definition for entity data provider API
    /// </summary>
    public interface IEntityDataProvider
    {
        /// <summary>
        /// Gets seed data
        /// </summary>
        /// <returns>DataSet</returns>
        DataSet GetData();
    }
}
