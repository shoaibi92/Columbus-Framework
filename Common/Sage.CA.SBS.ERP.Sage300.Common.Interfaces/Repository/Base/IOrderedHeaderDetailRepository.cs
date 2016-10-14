/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base
{
    /// <summary>
    /// Interface IOrderedHeaderDetailRepository Stateless
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    public interface IOrderedHeaderDetailRepository<T, TU> : IBusinessRepository<T>, ISecurity
        where T : ModelBase
        where TU : ModelBase
    {
        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        T NewHeader();

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail(TU detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail(TU detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TU> details);

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail(int pageNumber, int pageSize, TU currentDetail);

        /// <summary>
        /// To sync details data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail Model</param>
        /// <returns>Header Detail record</returns>
        T RefreshDetail(T model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        T ClearDetails(T model);

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="model">The model.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, T model, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);
        
        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);
        
        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="model">The header model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TU> GetDetail(T model, PageOptions<TU> pageOptions);
        
        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TU ProcessDetail(TU detail);

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        T Refresh(T header);

        /// <summary>
        /// Deletes the detail
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="model">model</param>
        /// <returns>true or false</returns>
        bool DeleteDetail(Expression<Func<TU, bool>> filter,T model);
        
        /// <summary>
        /// Deletes the detail and saves
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="model">model</param>
        /// <returns>true or false</returns>
        bool DeleteDetails(Expression<Func<TU, bool>> filter, T model);
		
		/// <summary>
        /// Get First or default record
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        T FirstOrDefault(T model, Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(T model, Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="model"></param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(int currentPageNumber, int pageSize, T model, Expression<Func<T, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<TU> Get(int currentPageNumber, int pageSize, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        ///  Unlocks the Application for specific module. 
        /// </summary>
        void UnlockApplication(string applicationId);

    }
}
