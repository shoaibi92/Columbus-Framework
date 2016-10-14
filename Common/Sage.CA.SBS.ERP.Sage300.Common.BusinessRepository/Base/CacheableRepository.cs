/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ACCPAC.Advantage;

using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// BaseFinderRepository Work Still In-Progress
    /// </summary>
    public abstract class CacheableRepository<T> : FlatRepository<T> where T : ModelBase, new()
    {
        #region Private Variables

        /// <summary>
        /// Active Filter
        /// </summary>
        private readonly Expression<Func<T, bool>> _activeFilter;

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly ModelMapper<T> _mapper;

        /// <summary>
        /// EntityName
        /// </summary>
        private readonly string _entityName;

        /// <summary>
        /// BusinessEntity
        /// </summary>
        private IBusinessEntity _entity;

        /// <summary>
        /// Cachable
        /// </summary>
        private readonly bool _isCachable;

        private string CacheKey
        {
            get { return string.Format(@"{0}_{1}_{2}", Context.TenantId, typeof(T), "finderCache"); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Base Finder Repository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">mapper</param>
        /// <param name="entityName">name of the entity</param>
        /// <param name="activeFilter">active Filter</param>
        /// <param name="isCachable">data will be cached if true</param>
        /// <param name="validRecordFilter"></param>
        protected CacheableRepository(Context context, ModelMapper<T> mapper, string entityName,
            Expression<Func<T, bool>> activeFilter, bool isCachable, Func<T, bool> validRecordFilter)
            : base(context, mapper, activeFilter)
        {
            _mapper = mapper;
            _entityName = entityName;
            _activeFilter = activeFilter;
            _isCachable = isCachable;
            ValidRecordFilter = validRecordFilter;
        }

        /// <summary>
        /// Base Finder Repository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">mapper</param>
        /// <param name="entityName">name of the entity</param>
        /// <param name="activeFilter">active Filter</param>
        /// <param name="isCachable">data will be cached if true</param>
        /// <param name="session">Session</param>
        /// <param name="validRecordFilter">ValidRecordFilter</param>
        protected CacheableRepository(Context context, ModelMapper<T> mapper, string entityName,
            Expression<Func<T, bool>> activeFilter, bool isCachable, IBusinessEntitySession session,
            Func<T, bool> validRecordFilter)
            : base(context, mapper, activeFilter, session)
        {
            _mapper = mapper;
            _entityName = entityName;
            _activeFilter = activeFilter;
            _isCachable = isCachable;
            ValidRecordFilter = validRecordFilter;
        }

        #endregion

        #region Abstract Method

        /// <summary>
        /// Compose Entity
        /// </summary>
        /// <returns></returns>
        protected override IBusinessEntity CreateBusinessEntities()
        {
            //TODO: Compose entity logic should be changed

            //if (!string.IsNullOrEmpty(_entityName) && (!_isCachable || CacheHelper.Get<List<T>>(CacheKey) == null))
            _entity = OpenEntity(_entityName);


            return _entity;
        }

        /// <summary>
        /// Get Update Expression
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>No implementation required for finders</remarks>
        protected override Expression<Func<T, bool>> GetUpdateExpression(T model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get details for specific model data
        /// </summary>
        /// <param name="pageNumber">pageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="filter">Filter Expression</param>
        /// <param name="orderBy">Order By paramter name and sort direction</param>
        /// <returns>Enumerable Data</returns>
        public override EnumerableResponse<T> Get(int pageNumber, int pageSize, Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            if (_isCachable)
            {
                int totalResultsCount;
                return new EnumerableResponse<T>
                {
                    Items = GetCachedData(orderBy, pageNumber, pageSize, out totalResultsCount, filter),
                    TotalResultsCount = totalResultsCount
                };
            }

            return base.Get(pageNumber, pageSize, filter, orderBy);
        }

        #endregion

        #region IDisposable Methods

        /// <summary>
        /// Dispose View 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeEntity(_entity);
                _entity = null;
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get Model details from Cache if caching is enabled for repository
        /// </summary>
        /// <param name="orderBy">Order By paramter name and sort direction</param>
        /// <param name="pageNumber">pageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="totalResultsCount">totalResultsCount</param>
        /// <param name="filter">Filter Expression></param>
        /// <returns>IEnumerable data</returns>
        private IEnumerable<T> GetCachedData(OrderBy orderBy, int pageNumber, int pageSize, out int totalResultsCount,
            Expression<Func<T, bool>> filter = null)
        {
            var filterToApply = filter ?? _activeFilter;
            var dataList = CacheHelper.Get<List<T>>(CacheKey);

            if (dataList == null)
            {
                CreateBusinessEntities();
                _entity.ClearRecord();
                _entity.FilterSelect(string.Empty, true, 0, ViewFilterOrigin.FromStart);
                _entity.Read(false);
                dataList = MapDataToModel(_entity, _mapper, null, null, null, ValidRecordFilter).ToList();
                CacheHelper.Set(CacheKey, dataList);
            }

            var queryable = dataList.AsQueryable();
            if (filterToApply != null)
            {
                queryable = queryable.Where(filterToApply);
            }

            if (orderBy != null && !string.IsNullOrEmpty(orderBy.PropertyName))
            {
                queryable = queryable.OrderBy(orderBy);
            }

            totalResultsCount = queryable.Count();
            var resultList = queryable.Skip(pageNumber * pageSize).Take(pageSize).ToList();

            if (totalResultsCount > 0)
            {
                return SerializationUtil.DeepCopy(resultList).AsEnumerable();
            }

            return new List<T>().AsEnumerable();
        }

        #endregion
    }
}