/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Base Service class for Ordered Header detail service Stateless
    /// </summary>
    /// <typeparam name="T">Header entity</typeparam>
    /// <typeparam name="TU">Detail Entity</typeparam>
    /// <typeparam name="TEntity">Repositry</typeparam>
    public abstract class BaseOrderedHeaderDetailService<T, TU, TEntity> : BaseService,
        IOrderedHeaderDetailService<T, TU>
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TEntity : IOrderedHeaderDetailRepository<T, TU>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected BaseOrderedHeaderDetailService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        public virtual T NewHeader()
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
        public virtual T NewDetail(int pageNumber, int pageSize, TU currentDetail)
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
        public EnumerableResponse<T> Get(PageOptions<T> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">filter</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual EnumerableResponse<T> Get(T model=null,Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(model,filter, orderBy);
            }
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null,
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
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Get Records based on pase size 
        /// </summary>
        /// <param name="currentPageNumber">currentPageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="model"></param>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns> </returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,T model=null,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Retrieve first or default  based on the filter expression
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns></returns>
        public virtual T FirstOrDefault(T model=null,Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.FirstOrDefault(model,filter, orderBy);
            }
        }

        /// <summary>
        /// Retrieve first or default  based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null,
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
        public virtual T Save(T model)
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
        public virtual T Delete(Expression<Func<T, bool>> filter)
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
        public T Next(Expression<Func<T, bool>> filter)
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
        public virtual T Previous(Expression<Func<T, bool>> filter)
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
        public virtual T RefreshDetail(T model)
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
        public virtual T SetDetail(TU currentDetail)
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
        public virtual T ClearDetails(T model)
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
        public virtual TU ProcessDetail(TU detail)
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
        public virtual T Add(T model)
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
        public virtual T GetById<TKey>(TKey key)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetById(key);
            }
        }

        /// <summary>
        /// Gets access rights
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
        /// Gets the detail.
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="model">The model.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, T model = null, Expression<Func<TU, Boolean>> filter = null,
             OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(currentPageNumber, pageSize, model, filter, orderBy);
            }
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize,
            Expression<Func<TU, Boolean>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TU> GetDetail(T model, PageOptions<TU> pageOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(model, pageOptions);
            }
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public T Refresh(T header)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Refresh(header);
            }
        }

        /// <summary>
        /// Saves Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail(TU detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetail(detail);
            }
        }

        /// <summary>
        /// Saves details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails(IEnumerable<TU> details)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetails(details);
            }
        }

        /// <summary>
        /// Deletes the detail
        /// </summary>
        public bool DeleteDetail(Expression<Func<TU, bool>> filter,T model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.DeleteDetail(filter,model);
            }
        }

        /// <summary>
        /// Deletes all details
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteDetails(Expression<Func<TU, bool>> filter, T model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.DeleteDetails(filter, model);
            }
        }


        /// <summary>
        ///  Gets the Detail model
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public EnumerableResponse<TU> Get(int currentPageNumber, int pageSize, Expression<Func<TU, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
        }
    }
}