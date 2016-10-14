/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region 

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
     /// <summary>
    /// Base Service class for Ordered HEader detail service
    /// </summary>
    /// <typeparam name="THeader">Header entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TEntity">Repositry</typeparam>
    public abstract class SequencedHeaderDetailService<THeader, TDetail, TEntity> : BaseService,
        ISequencedHeaderDetailService<THeader, TDetail>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TEntity : ISequencedHeaderDetailRepository<THeader, TDetail>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected SequencedHeaderDetailService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        public virtual THeader NewHeader()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewHeader();
            }
        }

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual THeader NewDetail(int pageNumber, int pageSize, TDetail currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewDetail(pageNumber, pageSize, currentDetail);
            }
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<THeader> Get(PageOptions<THeader> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual EnumerableResponse<THeader> Get(System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(filter, orderBy);
            }
        }

        /// <summary>
        /// Get Records based on pase size 
        /// </summary>
        /// <param name="currentPageNumber">currentPageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns> </returns>
        public virtual EnumerableResponse<THeader> Get(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            using(var repository = Resolve<TEntity>())
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Retrieve first or default  based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns></returns>
        public virtual THeader FirstOrDefault(System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.FirstOrDefault(filter, orderBy);
            }
        }


        /// <summary>
        ///Save
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public virtual THeader Save(THeader model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Save(model);
            }
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual THeader Delete(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Delete(filter);
            }
        }

        /// <summary>
        /// Get next 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public THeader Next(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Next(filter);
            }
        }

        /// <summary>
        /// Get previous 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual THeader Previous(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Previous(filter);
            }
        }

        /// <summary>
        /// Refresh  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual THeader RefreshDetail(THeader model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.RefreshDetail(model);
            }
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual THeader SetDetail(TDetail currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SetDetail(currentDetail);
            }
        }

        /// <summary>
        /// Clear  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual THeader ClearDetails(THeader model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ClearDetails(model);
            }
        }

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TDetail ProcessDetail(TDetail detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ProcessDetail(detail);
            }
        }

        /// <summary>
        /// Insert a header record
        /// </summary>
        /// <param name="model">Ordered header detail model</param>
        /// <returns>Inserted ordered header record</returns>
        public virtual THeader Add(THeader model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Add(model);
            }
        }

        /// <summary>
        /// Gets the record by ID
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns>Header record</returns>
        public virtual THeader GetById<TKey>(TKey key)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetById(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetAccessRights();
            }
        }

        /// <summary>
        /// Retrieve Details records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<TDetail, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public void Refresh(THeader header)
        {
            using (var repository = Resolve<TEntity>())
            {
                repository.Refresh(header);
            }
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public THeader SaveDetail(TDetail detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetail(detail);
            }
        }

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails(IEnumerable<TDetail> details)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetails(details);
            }
        }

        /// <summary>
        /// Get Page Data
        /// </summary>
        /// <param name="extraOptions"></param>
        /// <returns></returns>
        public EnumerableResponse<TDetail> GetDetail(PageOptions<TDetail> extraOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(extraOptions);
            }
        }

        public TDetail PreviousDetail(Expression<Func<TDetail, bool>> filter)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.PreviousDetail(filter);
            }
        }
    }
}
