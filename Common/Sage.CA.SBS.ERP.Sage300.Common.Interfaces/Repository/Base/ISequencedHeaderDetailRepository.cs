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
    /// Interface ISequencedHeaderDetailRepository
    /// </summary>
    /// <typeparam name="THeader"></typeparam>
    /// <typeparam name="TDetail">The type of the tu.</typeparam>
    public interface ISequencedHeaderDetailRepository<THeader, TDetail> : IBusinessRepository<THeader>, ISecurity
        where THeader : ModelBase
        where TDetail : ModelBase
    {
        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        THeader NewHeader();

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        THeader SaveDetail(TDetail detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        THeader SetDetail(TDetail detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TDetail> details);

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        THeader NewDetail(int pageNumber, int pageSize, TDetail currentDetail);

        /// <summary>
        /// To sync details data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail Model</param>
        /// <returns>Header Detail record</returns>
        THeader RefreshDetail(THeader model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        THeader ClearDetails(THeader model);

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TDetail, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="extraOptions"></param>
        /// <returns></returns>
        EnumerableResponse<TDetail> GetDetail(PageOptions<TDetail> extraOptions);

        /// <summary>
        /// Get Previos Records
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        TDetail PreviousDetail(Expression<Func<TDetail, bool>> filter);

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TDetail ProcessDetail(TDetail detail);

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        THeader Refresh(THeader header);

    }
}
