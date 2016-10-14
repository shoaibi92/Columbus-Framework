/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the functions exposed by the Batch Header Detail Business Views
    /// </summary>
    /// <typeparam name="TBatch">T of type ModelBase</typeparam>
    /// <typeparam name="THeader">T Header of type ModelBase</typeparam>
    /// <typeparam name="TDetail">T Detail of type ModelBase</typeparam>
    public interface IBatchHeaderDetailRepository<TBatch, THeader, TDetail> : IBusinessRepository<TBatch>
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
        /// Creates a new header
        /// </summary>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch NewHeader();

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        TBatch SetDetail(TDetail currentDetail);

        /// <summary>
        /// Gets the Next Header record
        /// </summary>
        /// <returns></returns>
        TBatch HeaderNext();

        /// <summary>
        /// Gets the Previous Header record
        /// </summary>
        /// <returns></returns>
        TBatch HeaderPrevious();

        /// <summary>
        /// Creates a New detail
        /// </summary>
        /// <returns></returns>
        TBatch NewDetail(int pageNumber, int pageSize, TDetail currentDetail);

        /// <summary>
        /// Clears the details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TBatch ClearDetails(TBatch model);

        /// <summary>
        /// Refresh the details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TBatch RefreshDetail(TBatch model);

        /// <summary>
        /// Get Journal entry
        /// </summary>
        /// <param name="filter">FilterExpression</param>
        /// <returns>Journal batch model</returns>
        TBatch GetHeader(Expression<Func<TBatch, bool>> filter);

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
        /// Get Paged Journal Entry
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Current Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order by</param>
        /// <returns></returns>
        EnumerableResponse<THeader> GetHeader(int pageNumber, int pageSize,
            Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize,
            Expression<Func<TDetail, Boolean>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <param name="processValue"></param>
        /// <returns></returns>
        TDetail ProcessDetail(TDetail detail, int processValue);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        TBatch SaveDetail(TDetail detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TDetail> details);

        /// <summary>
        /// Synchronizes the views with the data from the model
        /// </summary>
        /// <param name="batch">Batch model</param>
        TBatch Refresh(TBatch batch);


        /// <summary>
        /// To update journal batch
        /// </summary>
        /// <param name="model">Journal Batch model</param>
        /// <returns>Journal batch model</returns>
        TBatch UpdateBatch(TBatch model);

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TBatch GetHeaderById<TKey>(TKey key);

        /// <summary>
        /// Get a detail of the current header using the detail's unique key segement value 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>the detail's unique key segment value
        /// <returns>the model of the detail retrieved; null if the detail does not exist. </returns>
        TDetail GetDetailById<TKey>(TKey key);
    }
}