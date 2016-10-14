/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base.Statefull
{
    /// <summary>
    /// Batch Header Detail Entity Service
    /// </summary>
    /// <typeparam name="TBatch">Batch Entity</typeparam>
    /// <typeparam name="THeader">Header Entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TEntity">Repository</typeparam>
    public abstract class BatchHeaderDetailEntityService<TBatch,THeader, TDetail, TEntity> : BaseService,
       IBatchHeaderDetailService<TBatch,THeader, TDetail>
        where TBatch : ModelBase, new()
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TEntity : IBatchHeaderDetailRepository<TBatch,THeader, TDetail>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected BatchHeaderDetailEntityService(Context context):base(context)
        {
                
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TBatch> Get(PageOptions<TBatch> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TBatch> Get(Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.Get(filter,orderBy);
        }
        
        /// <summary>
        /// Get the records based on pagenumber and filter .
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Batch Filter</param>
        /// <param name="orderBy">Order by </param>
        /// <returns></returns>
        public virtual EnumerableResponse<TBatch> Get(int currentPageNumber, int pageSize, Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.Get(currentPageNumber,pageSize,filter, orderBy);
        }

        /// <summary>
        /// Get the first or Default record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">Order</param>
        /// <returns></returns>
        public virtual TBatch FirstOrDefault(Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.FirstOrDefault(filter, orderBy);
        }

        /// <summary>
        /// Add new model 
        /// </summary>
        /// <param name="model">Model to be added</param>
        /// <returns>T</returns>
        public virtual TBatch Add(TBatch model)
        {
            if (model == null) throw new ArgumentNullException("model");
            var repository = Resolve<TEntity>();
            return repository.Add(model);
        }

        /// <summary>
        /// Update model 
        /// </summary>
        /// <param name="model">Model to be updated</param>
        /// <returns>Updated model</returns>
        public virtual TBatch Save(TBatch model)
        {
            if (model == null) throw new ArgumentNullException("model");
            var repository = Resolve<TEntity>();
            return repository.Save(model);
        }

        /// <summary>
        /// Delete model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual TBatch Delete(Expression<Func<TBatch, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            var repository = Resolve<TEntity>();
            return repository.Delete(filter);
        }

        /// <summary>
        /// Get the next batch record
        /// </summary>
        /// <param name="filter">batch filter</param>
        /// <returns>Batch model</returns>
        public virtual TBatch Next(Expression<Func<TBatch, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.Next(filter);
        }

        /// <summary>
        /// Get the previous batch record
        /// </summary>
        /// <param name="filter">batch filter</param>
        /// <returns>Batch model</returns>
        public virtual TBatch Previous(Expression<Func<TBatch, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.Previous(filter);
        }

        /// <summary>
        /// Get the data based on the key value
        /// </summary>
        /// <typeparam name="TKey">Key of Batch Entity</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Batch model</returns>
        public virtual TBatch GetById<TKey>(TKey key)
        {
            var repository = Resolve<TEntity>();
            return repository.GetById(key);
        }

        /// <summary>
        /// Creates a new batch
        /// </summary>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch NewBatch()
        {
            var repository = Resolve<TEntity>();
            return repository.NewBatch();
        }

        /// <summary>
        /// Creates a new entry
        /// </summary>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch NewEntry()
        {
            var repository = Resolve<TEntity>();
            return repository.NewHeader();
        }

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch NewDetail(int pageNumber, int pageSize, TDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail(pageNumber,pageSize,currentDetail);
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch SetDetail(TDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail(currentDetail);
        }

        /// <summary>
        /// Refresh the details
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch RefreshDetail(TBatch model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail(model);
        }

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Saved Detail with updated info</param>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch SaveDetail(TDetail detail)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail(detail);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public List<EnablementAttribute> GetDynamicAttributesBatch()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesBatch();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public List<EnablementAttribute> GetDynamicAttributesHeader()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesHeader();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public List<EnablementAttribute> GetDynamicAttributesDetail()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail();
        }

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">List of details to be saved</param>
        /// <returns>Returns if Save is successful or not</returns>
        public virtual bool SaveDetails(IEnumerable<TDetail> details)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails(details);
        }

        /// <summary>
        /// Gets the Next Header record
        /// </summary>
        /// <returns>Returns the Batch and Header data.</returns>
        public virtual TBatch HeaderNext()
        {
            var repository = Resolve<TEntity>();
            return repository.HeaderNext();
        }

        /// <summary>
        /// Gets the Previous Header record
        /// </summary>
        /// <returns>Returns the Batch and Header data.</returns>
        public virtual TBatch HeaderPrevious()
        {
            var repository = Resolve<TEntity>();
            return repository.HeaderNext();
        }

        /// <summary>
        /// Get Journal entry
        /// </summary>
        /// <param name="filter">Filter - search condition</param>
        /// <returns>Returns the Batch and Header data</returns>
        public virtual TBatch GetHeader(Expression<Func<TBatch, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.GetHeader(filter);
        }

        /// <summary>
        /// Get Paged Journal Entry
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Current Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order by</param>
        /// <returns>List of Header model with total result count.</returns>
        public virtual EnumerableResponse<THeader> GetHeader(int pageNumber, int pageSize, Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetHeader(pageNumber,pageSize,filter,orderBy);
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>List of Header model with total result count.</returns>
        public virtual EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TDetail, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail(currentPageNumber,pageSize,filter,orderBy);
        }

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <param name="processValue">The process value.</param>
        /// <returns>TDetail - with processed/updated info.</returns>
        public virtual TDetail ProcessDetail(TDetail detail, int processValue)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail(detail, processValue);
        }

        /// <summary>
        /// Refreshes the Batch and Header view with the data from the model
        /// </summary>
        /// <param name="batch">Returns the Batch and Header data</param>
        public virtual TBatch Refresh(TBatch batch)
        {
            var repository = Resolve<TEntity>();
            return repository.Refresh(batch);
        }

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>Returns the Batch and Header data.</returns>
        public virtual TBatch GetHeaderById<TKey>(TKey key)
        {
            var repository = Resolve<TEntity>();
            return repository.GetHeaderById(key);
        }
    }
}
