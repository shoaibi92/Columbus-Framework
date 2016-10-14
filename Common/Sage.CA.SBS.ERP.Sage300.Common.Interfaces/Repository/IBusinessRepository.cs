/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the functions exposed by the Business Views
    /// </summary>
    /// <typeparam name="T">T of type ModelBase</typeparam>
    public interface IBusinessRepository<T> : IExportImportRepository where T : ModelBase
    {
        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(int currentPageNumber, int pageSize, Expression<Func<T, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets the specified current page number.
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(PageOptions<T> pageOptions);

        /// <summary>
        /// Gets total count
        /// </summary>
        /// <returns></returns>
        int GetEntityCount();

        /// <summary>
        /// Get First or default record
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        T Save(T model);

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        T Add(T model);

        /// <summary>
        /// Deletes the model
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        T Delete(Expression<Func<T, Boolean>> filter);

        /// <summary>
        /// Next Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        T Next(Expression<Func<T, Boolean>> filter);

        /// <summary>
        /// Previous Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        T Previous(Expression<Func<T, Boolean>> filter);

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        T GetById<TKey>(TKey key);
    }
}