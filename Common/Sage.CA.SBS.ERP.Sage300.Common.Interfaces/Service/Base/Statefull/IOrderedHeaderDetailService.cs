/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base.Statefull
{
    /// <summary>
    /// Interface IOrderedHeaderDetailService
    /// </summary>
    /// <typeparam name="THeader">The type of the header.</typeparam>
    /// <typeparam name="TDetail">The type of the detail.</typeparam>
    public interface IOrderedHeaderDetailService<THeader, TDetail> : IEntityService<THeader>, ISecurityService
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
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
        /// Refresh the details
        /// </summary>
        /// <param name="model">Ordered Header Model object</param>
        /// <returns>Updated Ordered header detail object</returns>
        THeader RefreshDetail(THeader model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        THeader ClearDetails(THeader model);

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesHeader();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail();

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>TDetail.</returns>
        EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TDetail, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TDetail.</returns>
        TDetail ProcessDetail(TDetail detail);

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        THeader Refresh(THeader header);
    }
}
