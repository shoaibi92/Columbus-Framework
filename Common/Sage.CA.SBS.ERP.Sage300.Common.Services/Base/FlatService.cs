/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Class FlatService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public abstract class FlatService<T, TEntity> : BaseService, IEntityService<T>, ISecurityService
        where T : ModelBase, new() where TEntity : IBusinessRepository<T>, ISecurity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context.</param>
        protected FlatService(Context context) : base(context)
        {
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<T> Get(PageOptions<T> extraOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(extraOptions);
            }
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>EnumerableResponse&lt;T&gt;.</returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
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
        /// <returns>EnumerableResponse&lt;T&gt;.</returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
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
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>T.</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.FirstOrDefault(filter, orderBy);
            }
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">model</exception>
        public virtual T Save(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            using (var repository = Resolve<TEntity>())
            {
                return repository.Save(model);
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">filter</exception>
        public virtual T Delete(Expression<Func<T, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            using (var repository = Resolve<TEntity>())
            {
                return repository.Delete(filter);
            }
        }

        /// <summary>
        /// Get next
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>T.</returns>
        public virtual T Next(Expression<Func<T, bool>> filter)
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
        /// <returns>T.</returns>
        public virtual T Previous(Expression<Func<T, bool>> filter)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Previous(filter);
            }
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>T.</returns>
        /// <exception cref="System.ArgumentNullException">model</exception>
        public virtual T Add(T model)
        {
            if (model == null) throw new ArgumentNullException("model");
            using (var repository = Resolve<TEntity>())
            {
                return repository.Add(model);
            }
        }

        /// <summary>
        /// Get data By Id
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">key</param>
        /// <returns>T.</returns>
        public virtual T GetById<TKey>(TKey key)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetById(key);
            }
        }

        /// <summary>
        /// Get access rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetAccessRights();
            }
        }
    }
}