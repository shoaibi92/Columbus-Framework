/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the Dynmamic Query functions
    /// </summary>
    /// <typeparam name="T">T of type ApplicationModelBase</typeparam>
    public interface IDynamicQueryRepository<T> : IRepository, IDisposable where T : ApplicationModelBase
    {
        /// <summary>
        /// Execute T-SQL Query
        /// </summary>
        /// <param name="id">ID in resource for T-SQL Query</param>
        /// <param name="args">Arguments for T-SQL Query, if any</param>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        DynamicQueryEnumerableResponse<T> Execute(string id, params object[] args);
    }
}