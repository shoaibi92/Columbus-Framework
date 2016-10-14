/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
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
    /// Class OrderedHeaderDetailRepository Stateless.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    public abstract class OrderedHeaderDetailRepository<T, TU> : BaseRepository, IOrderedHeaderDetailRepository<T, TU>
        where T : ModelBase, new()
        where TU : ModelBase, new()
    {
        #region Private variables

        /// <summary>
        /// Batch Mapper
        /// </summary>
        private readonly ModelHierarchyMapper<T> _mapper;

        /// <summary>
        /// Header Active Filter
        /// </summary>
        private Expression<Func<T, bool>> _headerActiveFilter;

        /// <summary>
        /// Detail Active Filter
        /// </summary>
        private Expression<Func<TU, bool>> _detailActiveFilter;

        /// <summary>
        /// Header Business Entity
        /// </summary>
        private IBusinessEntity _headerEntity;

        /// <summary>
        /// Detail Business Entity
        /// </summary>
        private IBusinessEntity _detailEntity;

        /// <summary>
        /// Instance of Header Mapper
        /// </summary>
        private ModelMapper<T> _headerMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        private ModelMapper<TU> _detailMapper;

        /// <summary>
        /// Initital PageNumber
        /// </summary>
        private const int InitialPageNumber = 0;

        /// <summary>
        /// First Default PageSize
        /// </summary>
        private const int FirstPageSize = 1;

        /// <summary>
        /// Process command
        /// </summary>
        private const string ProcessCommand = "PROCESSCMD";

        #endregion

        #region Protected methods

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract OrderedHeaderDetailBusinessEntitySet<T, TU> CreateBusinessEntities();


        /// <summary>
        /// Validator Filter - Reserved
        /// </summary>
        /// <value>The valid record filter.</value>
        protected Func<T, Boolean> ValidRecordFilter { get; set; }

        /// <summary>
        /// Gets the Detail property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TU> GetDetailModel(T header);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TU detail, IBusinessEntity detailEntity);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper for the entity</param>
        protected OrderedHeaderDetailRepository(Context context, ModelHierarchyMapper<T> mapper)
            : this(context, mapper, ObjectPoolType.Default, null)
        {

        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dbLinkType"></param>
        /// <param name="mapper"></param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType, ModelHierarchyMapper<T> mapper)
            : this(context, dbLinkType, mapper, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedHeaderDetailRepository{T, TU}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedHeaderDetailRepository{T, TU}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sessionPoolType">Type of the session pool.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected OrderedHeaderDetailRepository(Context context, ModelHierarchyMapper<T> mapper, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);

        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Business Entity Session</param>
        protected OrderedHeaderDetailRepository(Context context, ModelHierarchyMapper<T> mapper, IBusinessEntitySession session)
            : base(context, session)
        {
            _mapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dbLinkType"></param>
        /// <param name="mapper"></param>
        /// <param name="session"></param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType, ModelHierarchyMapper<T> mapper, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
            _mapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="session">Business Entity Session</param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region IBusinessRepository Methods

        /// <summary>
        /// Gets the specified current page number.
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<T> Get(PageOptions<T> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the Header/Detail record based on the filter expression
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">Filter expression specified on Header</param>
        /// <param name="orderBy">Records sorting order</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(T model, Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            return Get(InitialPageNumber, FirstPageSize, model, filter, orderBy);
        }

        /// <summary>
        /// Get the Header/Detail record based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression specified on Header</param>
        /// <param name="orderBy">Records sorting order</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            return Get(InitialPageNumber, FirstPageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the header/detail record for specified pagenumber, pagesize and filter expression
        /// </summary>
        /// <param name="currentPageNumber">Page number</param>
        /// <param name="pageSize">No. of records to be retrieved per page</param>
        /// <param name="model"></param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize, T model,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);

            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            CheckRights(_headerEntity, SecurityType.Inquire);
            //ClearBusinessEntities(ClearLevel.Header);
            var resultsCount = SetFilter(_headerEntity, filter, _headerActiveFilter, orderBy);

            Search(_detailEntity, _detailActiveFilter, orderBy);

            if (_headerEntity.Fetch(false))
            {
                return new EnumerableResponse<T>
                {
                    Items =
                        MapDataToModel(new List<IBusinessEntity> { _headerEntity, _detailEntity }, _mapper,
                            currentPageNumber, pageSize, resultsCount, ValidRecordFilter),
                    TotalResultsCount = resultsCount
                };
            }

            return new EnumerableResponse<T> { Items = new List<T>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the header/detail record for specified pagenumber, pagesize and filter expression
        /// </summary>
        /// <param name="currentPageNumber">Page number</param>
        /// <param name="pageSize">No. of records to be retrieved per page</param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);

            CheckRights(_headerEntity, SecurityType.Inquire);

            //Reset the state before fetching
            _headerEntity.Init();

            var resultsCount = SetFilter(_headerEntity, filter, _headerActiveFilter, orderBy);
            if (!_headerEntity.Fetch(false))
                return new EnumerableResponse<T> { Items = new List<T>(), TotalResultsCount = 0 };

            Search(_detailEntity, _detailActiveFilter, orderBy);

            return new EnumerableResponse<T>
            {
                Items =
                    MapDataToModel(new List<IBusinessEntity> { _headerEntity, _detailEntity }, _mapper, currentPageNumber,
                        pageSize, resultsCount, ValidRecordFilter),
                TotalResultsCount = resultsCount
            };
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="model">The model.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TU> GetDetail(int pageNumber, int pageSize, T model, Expression<Func<TU, bool>> filter = null,
            OrderBy orderBy = null)
        {

            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);

            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            var resultsCount = SetFilter(_detailEntity, filter, _detailActiveFilter, orderBy);

            if (_detailEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = MapDataToModel(_detailEntity, _detailMapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = resultsCount
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="model">The header model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public EnumerableResponse<TU> GetDetail(T model, PageOptions<TU> pageOptions)
        {
            if (pageOptions.ModifiedData == null || pageOptions.ModifiedData.Count == 0)
            {
                return GetDetail(pageOptions.PageNumber, pageOptions.PageSize, pageOptions.Filter, pageOptions.OrderBy);
            }

            CreateBusinessEntities();
            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            var resultsCount = SetFilter(_detailEntity, pageOptions.Filter, _detailActiveFilter, pageOptions.OrderBy);

            var insertedRecords = 0;
            var deletedRecords = 0;

            if (pageOptions.ModifiedData != null)
            {
                Count(pageOptions.ModifiedData.ToList(), out insertedRecords, out deletedRecords);
            }

            var totalResultsCount = resultsCount + (insertedRecords - deletedRecords);

            if (totalResultsCount == 0)
            {
                return new EnumerableResponse<TU>();
            }

            //No need to check return type, in case server does not have any record, we need to merge and return cached item
            _detailEntity.Fetch(false);

            return new EnumerableResponse<TU>
            {
                Items = Get(_detailEntity, _detailMapper, pageOptions, resultsCount, totalResultsCount),
                TotalResultsCount = totalResultsCount
            };
        }

        /// <summary>
        /// Gets the header/detail total records count
        /// </summary>
        /// <returns>Header/Detail records count</returns>
        public virtual int GetEntityCount()
        {
            CreateBusinessEntities();
            return SetFilter(_headerEntity, null, _headerActiveFilter);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public List<EnablementAttribute> GetDynamicAttributesHeader()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public List<EnablementAttribute> GetDynamicAttributesDetail()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets first or default header/detail record based on the filter expression
        /// </summary>
        /// <param name="model"></param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Returns null or first header/detail record</returns>
        public virtual T FirstOrDefault(T model, Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var response = Get(InitialPageNumber, FirstPageSize, model, filter, orderBy);

            if (response != null && response.Items != null)
            {
                return response.Items.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Gets first or default header/detail record based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Returns null or first header/detail record</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var response = Get(InitialPageNumber, FirstPageSize, filter, orderBy);

            if (response != null && response.Items != null)
            {
                return response.Items.FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// Updates the model, this even takes care of Save for details optional field as well.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TBatch.</returns>
        public virtual T Save(T model)
        {
            CreateBusinessEntities();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            _headerMapper.MapKey(model, _headerEntity);

            if (_headerEntity.Read(false))
            {
                //Optional fields will break if we remove this. Once this issue is fixed in optional fields, this needs to be removed.
                if (!string.IsNullOrEmpty(model.ETag))
                {
                    CheckETag(_headerEntity, model);
                }
                var header = model;
                var details = GetDetailModel(header).ToList();
                SyncDetails(details);
                _headerMapper.Map(header, _headerEntity);
                _headerEntity.Update();
            }

            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError
                    {
                        Message = string.Format(CommonResx.UpdateFailedMessage, CommonResx.HeaderEntity),
                        Priority = Priority.Error
                    }
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Save Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public virtual bool SaveDetails(IEnumerable<TU> details)
        {
            return SyncDetails(details);
        }

        /// <summary>
        /// Save for detail Entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        public virtual T SaveDetail(TU detail)
        {
            if (detail.IsNewLine)
            {
                InsertDetail(detail);
            }
            else
            {
                SyncDetail(detail);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Add new header/detail record
        /// </summary>
        /// <param name="model">Object to be saved</param>
        /// <returns>added header/detail record</returns>
        public virtual T Add(T model)
        {
            CreateBusinessEntities();
            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            CheckRights(GetAccessRights(), SecurityType.Modify);

            var details = GetDetailModel(model);
            if (!_headerEntity.Exists)
            {
                SyncDetails(details);
                _headerMapper.Map(model, _headerEntity);
                _headerEntity.Insert();
            }
            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError
                    {
                        Message = string.Format(CommonResx.UpdateFailedMessage, CommonResx.HeaderEntity),
                        Priority = Priority.Error
                    }
                };

                throw ExceptionHelper.BusinessException(entityErrors);
            }

            _detailEntity.Top();
            //If more than one detail items are retrieved then move the pointer to Top of the detail entity
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Deletes a header/detail record based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Next header/detail record</returns>
        public virtual T Delete(Expression<Func<T, bool>> filter)
        {
            CreateBusinessEntities();
            _headerEntity.Read(false);
            CheckRights(GetAccessRights(), SecurityType.Modify);
            if (Search(_headerEntity, filter))
            {
                _headerEntity.Delete();
            }
            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError {Message = CommonResx.DeleteFailedNoRecordMessage, Priority = Priority.Error}
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Navigates to next header/detail record
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Header/detail record</returns>
        public virtual T Next(Expression<Func<T, bool>> filter)
        {
            return Navigate(filter, Direction.Next);
        }

        /// <summary>
        /// Navigates to previous header/detail record
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Header/detail record</returns>
        public virtual T Previous(Expression<Func<T, bool>> filter)
        {
            return Navigate(filter, Direction.Previous);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public virtual T GetById<TKey>(TKey key)
        {
            CreateBusinessEntities();
            CheckRights(_headerEntity, SecurityType.Inquire);
            var fields = GetKeyField(_headerEntity);
            _headerEntity.SetValue(fields[0].ID, key);
            if (!_headerEntity.Read(false))
            {
                return null;
            }
            _detailEntity.Top();
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Gets the Details
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public virtual EnumerableResponse<TU> GetDetail(int pageNumber, int pageSize, Expression<Func<TU, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var resultsCount = SetFilter(_detailEntity, filter, _detailActiveFilter, orderBy);

            if (_detailEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = MapDataToModel(_detailEntity, _detailMapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = resultsCount// GetTotalRecords(_detailEntity)
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }


        #endregion

        #region IOrderedHeaderDetailRepository Methods

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>T.</returns>
        public virtual T NewHeader()
        {
            CheckRights(_headerEntity, SecurityType.Inquire);
            //ClearBusinessEntities(ClearLevel.Header);
            _headerEntity.Init();
            _headerEntity.Read(false);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Creates a new Detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T NewDetail(int pageNumber, int pageSize, TU currentDetail)
        {
            if (currentDetail != null)
            {
                _detailMapper.MapKey(currentDetail, _detailEntity);
                if (currentDetail.HasChanged && !currentDetail.IsNewLine)
                {
                    if (_detailEntity.Exists)
                    {
                        _detailEntity.Read(false);
                        _detailMapper.Map(currentDetail, _detailEntity);
                        _detailEntity.Update();
                    }
                    else
                    {
                        _detailMapper.Map(currentDetail, _detailEntity);
                        _detailEntity.Insert();
                    }
                }
                else if (currentDetail.IsNewLine)
                {
                    _detailMapper.Map(currentDetail, _detailEntity);
                    _detailEntity.Insert();
                }
            }

            _detailEntity.RecordCreate(ViewRecordCreate.NoInsert);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
        }

        /// <summary>
        /// Deletes a detail
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail record</returns>
        public virtual bool DeleteDetail(Expression<Func<TU, bool>> filter)
        {
            CheckRights(_headerEntity, SecurityType.Delete);
            var isDeleted = false;
            Search(_detailEntity, filter);
            if (_detailEntity.Exists)
            {
                _detailEntity.Delete();
                isDeleted = true;
            }
            return isDeleted;
        }

        /// <summary>
        /// Deletes all details
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="model">model</param>
        /// <returns>Previous detail record</returns>
        public virtual bool DeleteDetails(Expression<Func<TU, bool>> filter, T model)
        {
            CreateBusinessEntities();
            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            var isDeleted = false;

            CheckRights(_headerEntity, SecurityType.Delete);

            var resultsCount = SetFilter(_detailEntity, filter);
            if (_detailEntity.Fetch(false))
            {
                var details = MapDataToModel(_detailEntity, _detailMapper);
                foreach (var detail in details)
                {
                    detail.IsDeleted = true;
                }
                SyncDetails(details);
                _headerEntity.Update();
                isDeleted = true;
            }

            return isDeleted;
        }
        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T SetDetail(TU currentDetail)
        {
            if (currentDetail != null)
            {
                _detailMapper.MapKey(currentDetail, _detailEntity);
                if (_detailEntity.Exists)
                {
                    _detailEntity.Read(false);
                    _detailMapper.Map(currentDetail, _detailEntity);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
        }

        /// <summary>
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual T RefreshDetail(T model)
        {
            CreateBusinessEntities();
            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            _headerMapper.Map(model, _headerEntity);

            var detailModel = GetDetailModel(model);

            foreach (var detail in detailModel)
            {
                _detailMapper.MapKey(detail, _detailEntity);

                if (_detailEntity.Exists)
                {
                    _detailEntity.Read(false);
                }
                if (!_detailEntity.Exists)
                    detail.IsNewLine = true;

                _detailMapper.Map(detail, _detailEntity);

                if (_detailEntity.Exists)
                {
                    _detailEntity.Update();
                }
            }

            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
        }

        /// <summary>
        /// To clear the details
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual T ClearDetails(T model)
        {
            CreateBusinessEntities();
            _headerMapper.MapKey(model, _headerEntity);
            _headerEntity.Read(false);

            CheckRights(GetAccessRights(), SecurityType.Modify);
            _headerMapper.Map(model, _headerEntity);

            var details = GetDetailModel(model);
            _detailEntity.Top();
            if (!details.Any())
                return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
            do
            {
                if (_detailEntity.Read(false))
                    _detailEntity.Delete();
                _detailEntity.ClearRecord();
            } while (_detailEntity.Next());
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Process for detail
        /// </summary>
        /// <param name="detail">Ordered Header Detail</param>
        /// <returns>Ordered Header Detail object</returns>
        public virtual TU ProcessDetail(TU detail)
        {
            var exists = _detailEntity.Exists;
            if (exists)
            {
                _detailMapper.MapKey(detail, _detailEntity);
                _detailEntity.Read(false);
            }
            ProcessMap(detail, _detailEntity);
            _detailEntity.SetValue(ProcessCommand, 0);
            _detailEntity.Process();
            //TODO: Verify If this Update is really required. This entity update is not captured in RvSpy but still We have added this to resolve bug D-07771 & D-07051
            if (_detailEntity.Exists)
            {
                _detailEntity.Update();
            }
            return _detailMapper.Map(_detailEntity);
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public T Refresh(T header)
        {
            _mapper.Map(header, new List<IBusinessEntity> { _headerEntity });
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
        }

        /// <summary>
        /// Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>DataSet.</returns>
        public virtual DataSet Export(ExportRequest request)
        {
            CheckRights(GetAccessRights(), SecurityType.Export);
            CreateBusinessEntities();
            var headerData = request.DataMigrationList[0];
            var detailData = request.DataMigrationList[1];
            var dataSet = new DataSet();
            if (headerData.Print)
            {
                headerData.Items = PropertyBuilder<T>.UpdateColumnNamesAndId(headerData.Items);
                var headerTable = FlatExport(_headerEntity, headerData);
                headerTable.TableName = CommonUtilities.GetExportImportTableName<T>(request.Name);
                dataSet.Tables.Add(headerTable);
            }

            if (!detailData.Print) return dataSet;
            detailData.Items = PropertyBuilder<TU>.UpdateColumnNamesAndId(detailData.Items);
            var detailTable = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData);
            detailTable.TableName = CommonUtilities.GetExportImportTableName<TU>(request.Name);
            dataSet.Tables.Add(detailTable);
            return dataSet;
        }

        /// <summary>
        /// Imports the specified data set.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <param name="request">The request.</param>
        /// <returns>ImportResponse.</returns>
        public virtual ImportResponse Import(DataSet dataSet, ImportRequest request)
        {
            CheckRights(GetAccessRights(), SecurityType.Import);
            var headerTable = CommonUtilities.GetExportImportTableName<T>(request.Name);
            var detailTable = CommonUtilities.GetExportImportTableName<TU>(request.Name);
            var headerData = dataSet.Tables[headerTable];
            var detailData = dataSet.Tables[detailTable];
            var businessEntities = CreateBusinessEntities();
            _headerEntity = businessEntities.HeaderBusinessEntity;
            _detailEntity = businessEntities.DetailBusinessEntity;
            var importResponse = OrderHeaderImport(headerData, _headerEntity, detailData, _detailEntity, request);
            importResponse.Messages[0].BusinessEntity = headerTable;
            importResponse.Messages[1].BusinessEntity = detailTable;
            importResponse.Results.AddRange(Helper.GetExceptions(Session));
            return importResponse;
        }

        /// <summary>
        /// Method to Delete the detail record
        /// </summary>
        /// <param name="filter">A filter expression</param>
        /// <param name="model">A model object</param>
        /// <returns>Returns a boolean value</returns>
        public bool DeleteDetail(Expression<Func<TU, bool>> filter, T model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISecurity Methods

        /// <summary>
        /// Get rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            CreateBusinessEntities();
            return GetAccessRights(_headerEntity);
        }

        #endregion

        #region Private methods

        //TODO: This shall be changed once we get to know the total record count from the memory.
        /// <summary>
        /// Gets the total records.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>System.Int32.</returns>
        private int GetTotalRecords(IBusinessEntity businessEntity)
        {
            var total = 0;
            businessEntity.Top();
            do
            {
                if (businessEntity.Read(false))
                {
                    total++;
                }

            } while (businessEntity.Next());
            if (!businessEntity.Exists && total == 1)
            {
                return 0;
            }
            return total;
        }

        /// <summary>
        /// Navigates to next or previous record based on the direction and filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="direction">Direction to fetch next or previous</param>
        /// <returns>Header entity record</returns>
        private T Navigate(Expression<Func<T, bool>> filter, Direction direction)
        {
            Search(_headerEntity, filter);
            SetBrowse(_headerEntity, null, _headerActiveFilter);
            switch (direction)
            {
                case Direction.Next:
                    _headerEntity.Next();
                    break;
                case Direction.Previous:
                    _headerEntity.Previous();
                    break;
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Set the header, detail and optional fields entity with filter and mappers
        /// </summary>
        /// <param name="businessEntitySet">Business entity set</param>
        private void SetupEntities(OrderedHeaderDetailBusinessEntitySet<T, TU> businessEntitySet)
        {
            _headerActiveFilter = businessEntitySet.HeaderFilter;
            _headerEntity = businessEntitySet.HeaderBusinessEntity;
            _headerMapper = businessEntitySet.HeaderMapper;

            _detailActiveFilter = businessEntitySet.DetailFilter;
            _detailEntity = businessEntitySet.DetailBusinessEntity;
            _detailMapper = businessEntitySet.DetailMapper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        private bool SyncDetail(TU detail)
        {
            var isDetailUpdated = false;
            _detailMapper.MapKey(detail, _detailEntity);
            if (!_detailEntity.Exists && !detail.IsDeleted)
            {
                _detailEntity.Insert();
                detail.IsNewLine = false;
            }
            _detailEntity.Read(false);
            if (detail.IsDeleted && _detailEntity.Exists)
            {
                _detailEntity.Delete();
                isDetailUpdated = true;
            }
            else if (detail.IsDeleted && !_detailEntity.Exists)
            {
                _detailEntity.ClearRecord();
                isDetailUpdated = true;
            }
            else if (_detailEntity.Exists)
            {
                _detailMapper.Map(detail, _detailEntity);
                _detailEntity.Update();
                isDetailUpdated = true;
            }
            return isDetailUpdated;
        }
        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">The details.</param>
        private bool SyncDetails(IEnumerable<TU> details)
        {
            var isDetailUpdated = false;
            if (details == null) return false;

            var allDetails = details as IList<TU> ?? details.ToList();

            //fix for second time delete exist record and add same record again
            //issue fix,delete first then add
            foreach (var detail in allDetails.Where(detail => detail.IsDeleted))
            {
                isDetailUpdated = SyncDetail(detail);
            }

            foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsNewLine))
            {
                isDetailUpdated = SyncDetail(detail);
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newLine"></param>
        /// <returns></returns>
        private bool InsertDetail(TU newLine)
        {
            _detailEntity.Read(false);
            _detailMapper.Map(newLine, _detailEntity);
            //The reason for the exists check is that when an exception is thrown, new line will still be true.
            if (!_detailEntity.Exists && !newLine.IsDeleted)
            {
                _detailEntity.Insert();
                newLine.IsNewLine = false;
            }
            else if (_detailEntity.Exists && !newLine.IsDeleted)
            {
                _detailEntity.Update();
            }
            else if (_detailEntity.Exists && newLine.IsDeleted)
            {
                _detailEntity.Delete();
            }
            else if (!_detailEntity.Exists && newLine.IsDeleted)
            {
                _detailEntity.ClearRecord();
            }

            return true;
        }


        /// <summary>
        ///  Gets the detail model
        /// </summary>
        /// <param name="currentPageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public EnumerableResponse<TU> Get(int currentPageNumber, int pageSize, Expression<Func<TU, bool>> filter = null, OrderBy orderBy = null)
        {
            CreateBusinessEntities();
            _headerEntity.Read(false);

            var resultsCount = SetFilter(_detailEntity, filter, _detailActiveFilter, orderBy);

            if (_detailEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = MapDataToModel(_detailEntity, _detailMapper, currentPageNumber, pageSize, resultsCount),
                    TotalResultsCount = resultsCount
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }


        #endregion
    }
}