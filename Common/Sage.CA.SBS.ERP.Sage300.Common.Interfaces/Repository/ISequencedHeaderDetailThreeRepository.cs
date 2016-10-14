/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
     /// <summary>
    /// Interface ISequencedHeaderDetailRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    /// <typeparam name="TDetail2">The type of the TDetail2.</typeparam>
    ///  <typeparam name="TDetail3">The type of the TDetail3.</typeparam>
    public interface ISequencedHeaderDetailThreeRepository<T, TU, TDetail2, TDetail3> : IBusinessRepository<T>, ISecurity
        where T : ModelBase
        where TU : ModelBase
        where TDetail2 : ModelBase
        where TDetail3 : ModelBase
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
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail2(TDetail2 detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail3(TDetail3 detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail(TU detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail2(TDetail2 detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail3(TDetail3 detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TU> details);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails2(IEnumerable<TDetail2> details);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails3(IEnumerable<TDetail3> details);

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail(int pageNumber, int pageSize, TU currentDetail);

        /// <summary>
        /// Creates a new detail 2
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail);


        /// <summary>
        /// Creates a new detail 3
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail);

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
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TU> GetDetail(PageOptions<TU> pageOptions);
             
             /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TDetail2> GetDetail2(PageOptions<TDetail2> pageOptions);

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail2> GetDetail2(int currentPageNumber, int pageSize, Expression<Func<TDetail2, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TDetail3> GetDetail3(PageOptions<TDetail3> pageOptions);

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail3> GetDetail3(int currentPageNumber, int pageSize, Expression<Func<TDetail3, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TU ProcessDetail(TU detail);

        /// <summary>
        /// Process for detail entity 2
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TDetail2 ProcessDetail2(TDetail2 detail);

        /// <summary>
        /// Process for detail entity 3
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TDetail3 ProcessDetail3(TDetail3 detail);

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        T Refresh(T header);

    }
}
