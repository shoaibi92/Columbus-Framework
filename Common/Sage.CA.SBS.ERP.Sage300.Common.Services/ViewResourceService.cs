/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services
{
    /// <summary>
    /// To be removed in a future iteration as a generic resource service is unnecessary
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public class ViewResourceService<TModel, TRepository> : BaseService, IViewResourceService<TModel, TRepository>
        where TModel : ModelBase, new()
        where TRepository : IViewResourceRepository<TModel>
    {
        /// <summary>
        /// The repository for handling the underlying business logic for this service
        /// </summary>
        public TRepository Repository { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context</param>
        public ViewResourceService(Context context) : base(context)
        {
        }

        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public EnumerableResponse<TModel> Get(Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TModel> Get(PageOptions<TModel> pageOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public EnumerableResponse<TModel> Get(int currentPageNumber, int pageSize, Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            if (Repository == null)
                Repository = Resolve<TRepository>();

            return Repository.Get(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Get First record
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new model 
        /// </summary>
        /// <param name="model">Model to be added</param>
        /// <returns>T</returns>
        public TModel Add(TModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update model 
        /// </summary>
        /// <param name="model">Model to be updated</param>
        /// <returns>Updated model</returns>
        public TModel Save(TModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TModel Delete(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Next Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public TModel Next(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Previous Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public TModel Previous(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        public TModel GetById<TKey>(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}