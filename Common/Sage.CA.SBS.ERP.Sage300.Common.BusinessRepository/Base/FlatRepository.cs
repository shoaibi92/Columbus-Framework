/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Base Entity Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FlatRepository<T> : BaseRepository, IBusinessRepository<T>, ISecurity
        where T : ModelBase, new()
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
        /// Business Entity
        /// </summary>
        private IBusinessEntity _businessEntity;

        /// <summary>
        /// Initital PageNumber
        /// </summary>
        private const int InitialPageNumber = 0;

        /// <summary>
        /// First Default PageSize
        /// </summary>
        private const int FirstPageSize = 1;

        #endregion

        #region Protected Region

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract IBusinessEntity CreateBusinessEntities();

        /// <summary>
        /// Validator Filter
        /// </summary>
        /// <value>The valid record filter.</value>
        protected Func<T, Boolean> ValidRecordFilter { get; set; }

        /// <summary>
        /// Get Update Expression for Save model
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Expression</returns>
        protected abstract Expression<Func<T, Boolean>> GetUpdateExpression(T model);

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter)
            : this(context, DBLinkType.Company, mapper, activeFilter)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor with disable pooling. NOT to be generally used.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter, ObjectPoolType sessionPoolType)
            : this(context, DBLinkType.Company, mapper, activeFilter, null, sessionPoolType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlatRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="activeFilter">The active filter.</param>
        /// <param name="sessionPoolType">Type of the session pool.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, mapper, activeFilter, null, sessionPoolType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, mapper, activeFilter, null, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter)
            : base(context, dbLinkType)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter,
            IBusinessEntitySession session)
            : this(context, DBLinkType.Company, mapper, activeFilter, session)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        /// <param name="objectPoolType">Object Pool Type</param>
        protected FlatRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter,
            IBusinessEntitySession session, ObjectPoolType objectPoolType)
            : this(context, DBLinkType.Company, mapper, activeFilter, session, objectPoolType)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session)
            : this(context, dbLinkType, mapper, activeFilter, session, ObjectPoolType.Default)
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session, ObjectPoolType sessionPoolType)
            : this(context, dbLinkType, mapper, activeFilter, session, sessionPoolType, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected FlatRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session, ObjectPoolType sessionPoolType,
            BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, session, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        #endregion

        #region Properties

        public virtual ModelMapper<T> Mapper
        {
            get { return _mapper; }
        }

        #endregion

        #region IBusinessEntity

        /// <summary>
        /// Get details using primary key
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">key</param>
        /// <returns>T.</returns>
        public virtual T GetById<TKey>(TKey key)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            var fields = GetKeyField(_businessEntity);

            if (fields.Count != 1)
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError
                    {
                        Message = string.Format(CommonResx.GetKeysFailedMessage, key),
                        Priority = Priority.Error
                    }
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }
            _businessEntity.SetValue(fields[0].ID, key);
            return !_businessEntity.Read(false) ? null : _mapper.Map(_businessEntity);
        }

        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>List of data</returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            //Get all data
            return Get(-1, -1, filter, orderBy);
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>List of data</returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            return GetInternal(currentPageNumber, pageSize, filter, orderBy, true);
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="pageOptions">Extra option for pagination</param>
        /// <returns>List of data</returns>
        public virtual EnumerableResponse<T> Get(PageOptions<T> pageOptions)
        {
            if (pageOptions.ModifiedData.Count > 0)
            {
                return GetInternal(pageOptions);
            }

            return GetInternal(pageOptions.PageNumber, pageOptions.PageSize, pageOptions.Filter, pageOptions.OrderBy, true);
        }

        /// <summary>
        /// Get First or default record
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>Return first data</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var response = GetInternal(InitialPageNumber, FirstPageSize, filter, orderBy, false);

            if (response != null && response.Items != null)
            {
                return response.Items.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Gets total count
        /// </summary>
        /// <returns>Count</returns>
        public virtual int GetEntityCount()
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            return SetFilter(_businessEntity, null, _activeFilter);
        }

        /// <summary>
        /// Add New model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Model</returns>
        public virtual T Add(T model)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Add);
            AddRecord(model);
            return _mapper.Map(_businessEntity);
        }

        /// <summary>
        /// Save the model
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Model</returns>
        public virtual T Save(T model)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            var filter = GetUpdateExpression(model);

            if (Search(_businessEntity, filter))
            {
                CheckETag(_businessEntity, model);
                UpdateRecord(model);
            }
            else
            {
                throw ExceptionHelper.RowNotFoundException();
            }
            return _mapper.Map(_businessEntity);
        }

        /// <summary>
        /// Deletes the model
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>Model</returns>
        public virtual T Delete(Expression<Func<T, bool>> filter)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Delete);
            if (Search(_businessEntity, filter))
            {
                _businessEntity.Delete();
            }
            else
            {
                throw ExceptionHelper.RowNotFoundException(CommonResx.DeleteFailedNoRecordMessage);
            }
            return _mapper.Map(_businessEntity);
        }

        /// <summary>
        /// Next Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>T.</returns>
        public virtual T Next(Expression<Func<T, bool>> filter)
        {
            return Navigate(filter, Direction.Next);
        }

        /// <summary>
        /// Previous Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>T.</returns>
        public virtual T Previous(Expression<Func<T, bool>> filter)
        {
            return Navigate(filter, Direction.Previous);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Navigates Batches from repository
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="direction">Direction</param>
        /// <returns>T.</returns>
        private T Navigate(Expression<Func<T, bool>> filter, Direction direction)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Inquire);

            if (!Search(_businessEntity, filter)) throw ExceptionHelper.RowNotFoundException();

            SetBrowse(_businessEntity, null, _activeFilter);

            switch (direction)
            {
                case Direction.Next:
                    _businessEntity.Next();
                    break;

                case Direction.Previous:
                    _businessEntity.Previous();
                    break;
            }
            return _mapper.Map(_businessEntity);
        }

        /// <summary>
        /// Add Record
        /// </summary>
        /// <param name="model">model</param>
        private void AddRecord(T model)
        {
            _businessEntity.ClearRecord();
            _businessEntity.Init();

            _mapper.Map(model, _businessEntity);

            _businessEntity.Insert();
            _businessEntity.Process();
        }

        /// <summary>
        /// Update Record
        /// </summary>
        /// <param name="model">model</param>
        private void UpdateRecord(T model)
        {
            _mapper.Map(model, _businessEntity);
            _businessEntity.Update();
        }

        #endregion

        #region Secuirty Method

        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            return GetAccessRights(_businessEntity);
        }

        #endregion

        #region Export/Import

        /// <summary>
        /// Export Method
        /// </summary>
        /// <param name="request">export request details</param>
        /// <returns>dataset</returns>
        public virtual DataSet Export(ExportRequest request)
        {
            CheckRights(GetAccessRights(), SecurityType.Export);
            _businessEntity = CreateBusinessEntities();
            _businessEntity.Top();

            var entityData = request.DataMigrationList[0];
            var dataSet = new DataSet();

            if (entityData.Print)
            {
                entityData.Items = PropertyBuilder<T>.UpdateColumnNamesAndId(entityData.Items);
                var entityTable = FlatExport(_businessEntity, entityData);
                entityTable.TableName = CommonUtilities.GetExportImportTableName<T>(request.Name);
                dataSet.Tables.Add(entityTable);
            }

            return dataSet;
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="dataSet">dataset</param>
        /// <param name="request">import request</param>
        /// <returns>response/results</returns>
        public virtual ImportResponse Import(DataSet dataSet, ImportRequest request)
        {
            CheckRights(GetAccessRights(), SecurityType.Import);
            var response = new ImportResponse();
            var entityTable = CommonUtilities.GetExportImportTableName<T>(request.Name);
            var entityData = dataSet.Tables[entityTable];
            if (entityData == null && dataSet.Tables.Count > 0)
            {
                entityData = dataSet.Tables[0];
            }
            if (entityData != null)
            {
                _businessEntity = CreateBusinessEntities();
                var message = Import(entityData, _businessEntity, request.ImportType);
                message.BusinessEntity = entityTable;
                response.Messages.Add(message);
            }
            response.Results.AddRange(Helper.GetExceptions(Session));
            return response;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// CreateBusinessEntitiesInternal
        /// </summary>
        /// <returns>IBusinessEntity</returns>
        private IBusinessEntity CreateBusinessEntitiesInternal()
        {
            return CreateBusinessEntities();
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <param name="fetchTotalResultCount">If true then only fetch the total result</param>
        /// <returns>List of data</returns>
        private EnumerableResponse<T> GetInternal(int currentPageNumber, int pageSize, Expression<Func<T, bool>> filter,
            OrderBy orderBy, bool fetchTotalResultCount)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Inquire);

            var totalResultsCount = SetFilter(_businessEntity, filter, _activeFilter, orderBy, fetchTotalResultCount);

            // Added .Top() because data was not fetched in case order by was descending. 
            // Later we can remove Fetch and replace it with Top but this requires bit of more testing on screens using this method
            if (orderBy != null && orderBy.SortDirection == SortDirection.Descending)
            {
                // Set the pointer to first record if available. Not checking return value
                _businessEntity.Top();
            }
            else if (!_businessEntity.Fetch(false))
            {
                return new EnumerableResponse<T>();
            }

            return new EnumerableResponse<T>
            {
                Items = MapDataToModel(_businessEntity, _mapper, currentPageNumber, pageSize, totalResultsCount, ValidRecordFilter),
                TotalResultsCount = totalResultsCount
            };
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="pageOptions">Extra options for pagination</param>
        /// <returns>List of data</returns>
        private EnumerableResponse<T> GetInternal(PageOptions<T> pageOptions)
        {
            _businessEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Inquire);

            var filterCount = SetFilter(_businessEntity, pageOptions.Filter, _activeFilter, pageOptions.OrderBy);
            var insertedRecords = 0;
            var deletedRecords = 0;

            if (pageOptions.ModifiedData != null)
            {
                Count(pageOptions.ModifiedData.ToList(), out insertedRecords, out deletedRecords);
            }

            var totalResultsCount = filterCount + (insertedRecords - deletedRecords);

            if (totalResultsCount == 0)
            {
                return new EnumerableResponse<T>();
            }

            // If Latest Caching not used, then call latest caching.
            if (!pageOptions.LatestCachingNotUsed)
            {
                return new EnumerableResponse<T>
                {
                    Items = Get(_businessEntity, _mapper, pageOptions, filterCount, totalResultsCount, ValidRecordFilter),
                    TotalResultsCount = totalResultsCount
                };
            }

            // old caching logic.
            return new EnumerableResponse<T>
            {
                Items = MapDataToModel(_businessEntity, _mapper, pageOptions, filterCount, totalResultsCount, ValidRecordFilter),
                TotalResultsCount = totalResultsCount
            };


        }

        #endregion
    }
}