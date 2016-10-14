/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// Interface IBatchHeaderDetailService
    /// </summary>
    /// <typeparam name="TBatch">The type of the t batch.</typeparam>
    /// <typeparam name="THeader">The type of the t header.</typeparam>
    /// <typeparam name="TDetail">The type of the t detail.</typeparam>
    public interface IBatchHeaderDetailService<TBatch, THeader, TDetail> : IEntityService<TBatch>
        where TBatch : ModelBase
        where THeader : ModelBase
        where TDetail : ModelBase
    {
        /// <summary>
        /// Creates a new batch
        /// </summary>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch NewBatch();

        /// <summary>
        /// Creates a new entry
        /// </summary>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch NewEntry();

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch NewDetail(int pageNumber, int pageSize, TDetail currentDetail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch SetDetail(TDetail currentDetail);

        /// <summary>
        /// Refresh the details
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch RefreshDetail(TBatch model);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Saved Detail with updated info</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch SaveDetail(TDetail detail);

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesBatch();

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
        /// Save for detail entry
        /// </summary>
        /// <param name="details">List of details to be saved</param>
        /// <returns>Returns if Save is successful or not</returns>
        bool SaveDetails(IEnumerable<TDetail> details);

        /// <summary>
        /// Gets the Next Header record
        /// </summary>
        /// <returns>Returns the Batch and Header data.</returns>
        TBatch HeaderNext();

        /// <summary>
        /// Gets the Previous Header record
        /// </summary>
        /// <returns>Returns the Batch and Header data.</returns>
        TBatch HeaderPrevious();

        /// <summary>
        /// Get Journal entry
        /// </summary>
        /// <param name="filter">Filter - search condition</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch GetHeader(Expression<Func<TBatch, bool>> filter);

        /// <summary>
        /// Get Paged Journal Entry
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Current Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order by</param>
        /// <returns>List of Header model with total result count.</returns>
        EnumerableResponse<THeader> GetHeader(int pageNumber, int pageSize,
            Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>List of Header model with total result count.</returns>
        EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize,
            Expression<Func<TDetail, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <param name="processValue">The process value.</param>
        /// <returns>TDetail - with processed/updated info.</returns>
        TDetail ProcessDetail(TDetail detail, int processValue);

        /// <summary>
        /// Refreshes the Batch and Header view with the data from the model
        /// </summary>
        /// <param name="batch">Returns the Batch and Header data</param>
        TBatch Refresh(TBatch batch);

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns the Batch and Header data.</returns>
        TBatch GetHeaderById<TKey>(TKey key);
    }
}