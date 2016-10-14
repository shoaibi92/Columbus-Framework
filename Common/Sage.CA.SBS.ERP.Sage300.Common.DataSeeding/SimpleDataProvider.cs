/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Data;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding
{
    /// <summary>
    /// Reads seed data from an in-memory dataset
    /// </summary>
    public class SimpleDataProvider
        : IEntityDataProvider
    {
        #region Private Members
        private readonly DataSet _data;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public SimpleDataProvider(DataSet data)
        {
            _data = data;
        }

        /// <summary>
        /// Reads seed data
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return _data;
        }
    }
}
