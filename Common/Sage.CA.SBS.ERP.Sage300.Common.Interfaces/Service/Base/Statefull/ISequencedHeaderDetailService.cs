/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base.Statefull
{
    /// <summary>
    /// Interface IOrderedHeaderDetailService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    public interface ISequencedHeaderDetailService<T, TU> : IEntityService<T>, ISecurityService
        where T : ModelBase, new()
        where TU : ModelBase, new()
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
        /// Refresh the details
        /// </summary>
        /// <param name="model">Ordered Header Model object</param>
        /// <returns>Updated Ordered header detail object</returns>
        T RefreshDetail(T model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        T ClearDetails(T model);

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
        /// <returns>T.</returns>
        EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);

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
        void Refresh(T header);
    }
}
