﻿/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base.Statefull;
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

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull
{
    /// <summary>
    /// Class OrderedHeaderDetailRepository.
    /// </summary>
    /// <typeparam name="THeader">The type of the header.</typeparam>
    /// <typeparam name="TDetail">The type of the detail.</typeparam>
    public abstract class OrderedHeaderDetailRepository<THeader, TDetail> : BaseRepository, IOrderedHeaderDetailRepository<THeader, TDetail>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
    {
        #region Private variables

        /// <summary>
        /// Batch Mapper
        /// </summary>
        private readonly ModelHierarchyMapper<THeader> _mapper;

        /// <summary>
        /// Header Active Filter
        /// </summary>
        private Expression<Func<THeader, bool>> _headerActiveFilter;

        /// <summary>
        /// Detail Active Filter
        /// </summary>
        private Expression<Func<TDetail, bool>> _detailActiveFilter;

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
        private ModelMapper<THeader> _headerMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        private ModelMapper<TDetail> _detailMapper;

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
        protected abstract OrderedHeaderDetailBusinessEntitySet<THeader, TDetail> CreateBusinessEntities();

        /// <summary>
        /// Validator Filter - Reserved
        /// </summary>
        /// <value>The valid record filter.</value>
        protected Func<THeader, Boolean> ValidRecordFilter { get; set; }

        /// <summary>
        /// Gets the Detail property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail> GetDetailModel(THeader header);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TDetail detail, IBusinessEntity detailEntity);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper for the entity</param>
        protected OrderedHeaderDetailRepository(Context context, ModelHierarchyMapper<THeader> mapper)
            : base(context)
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
        /// Initializes a new instance of the <see cref="OrderedHeaderDetailRepository{THeader, TDetail}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected OrderedHeaderDetailRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Business Entity Session</param>
        protected OrderedHeaderDetailRepository(Context context, ModelHierarchyMapper<THeader> mapper,
            IBusinessEntitySession session)
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
        public EnumerableResponse<THeader> Get(PageOptions<THeader> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the Header/Detail record based on the filter expression.
        /// </summary>
        /// <param name="filter">Filter expression specified on Header</param>
        /// <param name="orderBy">Records sorting order</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<THeader> Get(Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            return Get(InitialPageNumber, FirstPageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the header/detail record for specified pagenumber, pagesize and filter expression.
        /// </summary>
        /// <param name="currentPageNumber">Page number</param>
        /// <param name="pageSize">No. of records to be retrieved per page</param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<THeader> Get(int currentPageNumber, int pageSize,
            Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            CheckRights(_headerEntity, SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Header);
            var resultsCount = SetFilter(_headerEntity, filter, _headerActiveFilter, orderBy);
            if (!_headerEntity.Fetch(false)) return null;

            if (!Search(_detailEntity, _detailActiveFilter, orderBy)) throw ExceptionHelper.RowNotFoundException();

            return new EnumerableResponse<THeader>
            {
                Items =
                    MapDataToModel(new List<IBusinessEntity> { _headerEntity, _detailEntity }, _mapper, currentPageNumber,
                        pageSize, resultsCount, ValidRecordFilter),
                TotalResultsCount = resultsCount
            };
        }

        /// <summary>
        /// Gets the Details.
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public virtual EnumerableResponse<TDetail> GetDetail(int pageNumber, int pageSize, Expression<Func<TDetail, bool>> filter = null,
            OrderBy orderBy = null)
        {
            IsSessionAvailable();
            var resultsCount = SetFilter(_detailEntity, filter, _detailActiveFilter, orderBy);

            if (_detailEntity.Fetch(false))
            {
                _detailEntity.Top();
                return new EnumerableResponse<TDetail>
                {
                    Items = MapDataToModel(_detailEntity, _detailMapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetTotalRecords(_detailEntity)
                };
            }
            return new EnumerableResponse<TDetail> { Items = new List<TDetail>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the header/detail total records count.
        /// </summary>
        /// <returns>Header/Detail records count</returns>
        public virtual int GetEntityCount()
        {
            return SetFilter(_headerEntity, null, _headerActiveFilter);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesHeader()
        {
            return GetAttributes<THeader>(_headerEntity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail()
        {
            return GetAttributes<TDetail>(_detailEntity);
        }

        /// <summary>
        /// Gets first or default header/detail record based on the filter expression.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Returns null or first header/detail record</returns>
        public virtual THeader FirstOrDefault(Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
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
        public virtual THeader Save(THeader model)
        {
            IsSessionAvailable();

            CheckRights(GetAccessRights(), SecurityType.Modify);

            var header = model;
            _headerMapper.Map(header, _headerEntity);

            var details = GetDetailModel(header).ToList();
            if (_headerEntity.Exists)
            {
                SyncDetails(details);
                try
                {
                    _headerEntity.Update();
                }
                catch (BusinessException businessException)
                {
                    var errors = businessException.Errors;
                    var message = (errors != null && errors.Any()) ? errors.FirstOrDefault().Message : string.Empty;
                    var entityErrors = new List<EntityError<THeader>>
                    {
                        new EntityError<THeader>
                        {
                            Data = _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }),
                            Message = message,
                            Priority = Priority.Error
                        }
                    };
                    throw ExceptionHelper.BusinessException(businessException, entityErrors);
                }
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
        /// Save Details.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public virtual bool SaveDetails(IEnumerable<TDetail> details)
        {
            IsSessionAvailable();
            return SyncDetails(details);
        }

        /// <summary>
        /// Save for detail Entry.
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        public virtual THeader SaveDetail(TDetail detail)
        {
            IsSessionAvailable();
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
        /// Add new header/detail record.
        /// </summary>
        /// <param name="model">Object to be saved</param>
        /// <returns>added header/detail record</returns>
        public virtual THeader Add(THeader model)
        {
            IsSessionAvailable();

            CheckRights(GetAccessRights(), SecurityType.Modify);

            _headerMapper.Map(model, _headerEntity);

            var details = GetDetailModel(model);
            if (!_headerEntity.Exists)
            {
                SyncDetails(details);
                try
                {
                    _headerEntity.Insert();
                }
                catch (BusinessException businessException)
                {
                    var errors = businessException.Errors;
                    var message = (errors != null && errors.Any()) ? errors.FirstOrDefault().Message : string.Empty;
                    var entityErrors = new List<EntityError<THeader>>
                    {
                        new EntityError<THeader>
                        {
                            Data = _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity }),
                            Message = message,
                            Priority = Priority.Error
                        }
                    };
                    throw ExceptionHelper.BusinessException(businessException, entityErrors);
                }
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
            // If more than one detail items are retrieved then move the pointer to Top of the detail entity
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Deletes a header/detail record based on the filter expression.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Next header/detail record</returns>
        public virtual THeader Delete(Expression<Func<THeader, bool>> filter)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            if (_headerEntity.Exists)
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
        /// Navigates to next header/detail record.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Header/detail record</returns>
        public virtual THeader Next(Expression<Func<THeader, bool>> filter)
        {
            return Navigate(filter, Direction.Next);
        }

        /// <summary>
        /// Navigates to previous header/detail record.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Header/detail record</returns>
        public virtual THeader Previous(Expression<Func<THeader, bool>> filter)
        {
            return Navigate(filter, Direction.Previous);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>T.</returns>
        public virtual THeader GetById<TKey>(TKey key)
        {
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

        #endregion

        #region IOrderedHeaderDetailRepository Methods

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>T.</returns>
        public virtual THeader NewHeader()
        {
            IsSessionAvailable();
            CheckRights(_headerEntity, SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Header);
            _headerEntity.Init();
            //Not checking if .Read's return value since the record was just created
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
        public virtual THeader NewDetail(int pageNumber, int pageSize, TDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                _detailMapper.MapKey(currentDetail, _detailEntity);
                if (currentDetail.HasChanged && !currentDetail.IsNewLine)
                {
                    if (_detailEntity.Exists)
                    {
                        //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
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
        public virtual bool DeleteDetail(Expression<Func<TDetail, bool>> filter)
        {
            IsSessionAvailable();
            CheckRights(_headerEntity, SecurityType.Delete);
            var isDeleted = false;
            if (!Search(_detailEntity, filter)) throw ExceptionHelper.RowNotFoundException(CommonResx.DeleteFailedNoRecordMessage);
            if (_detailEntity.Exists)
            {
                _detailEntity.Delete();
                isDeleted = true;
            }
            return isDeleted;
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual THeader SetDetail(TDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                _detailMapper.MapKey(currentDetail, _detailEntity);
                if (_detailEntity.Exists)
                {
                    //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
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
        public virtual THeader RefreshDetail(THeader model)
        {
            IsSessionAvailable();
            _headerMapper.Map(model, _headerEntity);

            var detailModel = GetDetailModel(model);

            foreach (var detail in detailModel)
            {
                _detailMapper.MapKey(detail, _detailEntity);

                if (_detailEntity.Exists)
                {
                    //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
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
        public virtual THeader ClearDetails(THeader model)
        {
            IsSessionAvailable();
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
        public virtual TDetail ProcessDetail(TDetail detail)
        {
            IsSessionAvailable();
            var exists = _detailEntity.Exists;
            if (exists)
            {
                _detailMapper.MapKey(detail, _detailEntity);
                //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
                _detailEntity.Read(false);
            }
            ProcessMap(detail, _detailEntity);
            _detailEntity.SetValue(ProcessCommand, 0);
            _detailEntity.Process();
            // TODO: Verify if this Update is really required. This entity update is not captured in RvSpy but still We have added this to resolve bug D-07771 & D-07051
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
        public THeader Refresh(THeader header)
        {
            IsSessionAvailable();
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
                headerData.Items = PropertyBuilder<THeader>.UpdateColumnNamesAndId(headerData.Items);
                var headerTable = FlatExport(_headerEntity, headerData);
                headerTable.TableName = CommonUtilities.GetExportImportTableName<THeader>(request.Name);
                dataSet.Tables.Add(headerTable);
            }

            if (!detailData.Print) return dataSet;
            detailData.Items = PropertyBuilder<TDetail>.UpdateColumnNamesAndId(detailData.Items);
            var detailTable = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData);
            detailTable.TableName = CommonUtilities.GetExportImportTableName<TDetail>(request.Name);
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
            var headerTable = CommonUtilities.GetExportImportTableName<THeader>(request.Name);
            var detailTable = CommonUtilities.GetExportImportTableName<TDetail>(request.Name);
            var headerData = dataSet.Tables[headerTable];
            var detailData = dataSet.Tables[detailTable];
            var businessEntities = CreateBusinessEntities();
            _headerEntity = businessEntities.HeaderBusinessEntity;
            _detailEntity = businessEntities.DetailBusinessEntity;
            return OrderHeaderImport(headerData, _headerEntity, detailData, _detailEntity, request);
        }

        #endregion

        #region ISecurity Methods

        /// <summary>
        /// Get rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            return GetAccessRights(_headerEntity);
        }

        #endregion

        #region Private methods

        // TODO: This shall be changed once we get to know the total record count from the memory.
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
        /// Navigates to next or previous record based on the direction and filter.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="direction">Direction to fetch next or previous</param>
        /// <returns>Header entity record</returns>
        private THeader Navigate(Expression<Func<THeader, bool>> filter, Direction direction)
        {
            if (!Search(_headerEntity, filter)) throw ExceptionHelper.RowNotFoundException();
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
        /// Set the header, detail and optional fields entity with filter and mappers.
        /// </summary>
        /// <param name="businessEntitySet">Business entity set</param>
        private void SetupEntities(OrderedHeaderDetailBusinessEntitySet<THeader, TDetail> businessEntitySet)
        {
            _headerActiveFilter = businessEntitySet.HeaderFilter;
            _headerEntity = businessEntitySet.HeaderBusinessEntity;
            _headerMapper = businessEntitySet.HeaderMapper;

            _detailActiveFilter = businessEntitySet.DetailFilter;
            _detailEntity = businessEntitySet.DetailBusinessEntity;
            _detailMapper = businessEntitySet.DetailMapper;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <returns></returns>
        private bool SyncDetail(TDetail detail)
        {
            var isDetailUpdated = false;
            _detailMapper.MapKey(detail, _detailEntity);
            if (!_detailEntity.Exists && !detail.IsDeleted)
            {
                _detailEntity.Insert();
                detail.IsNewLine = false;
            }
            if (!_detailEntity.Read(false)) throw ExceptionHelper.RowNotFoundException();
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
        /// Synchronizes the details.
        /// </summary>
        /// <param name="details">The details.</param>
        private bool SyncDetails(IEnumerable<TDetail> details)
        {
            var isDetailUpdated = false;
            if (details == null)
            {
                return false;
            }

            var allDetails = details as IList<TDetail> ?? details.ToList();
            var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);

            if (newLine != null)
            {
                isDetailUpdated = InsertDetail(newLine);
            }
            foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted).Where(detail => detail != newLine))
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
        private bool InsertDetail(TDetail newLine)
        {
            _detailMapper.MapKey(newLine, _detailEntity);
            if (!_detailEntity.Exists && newLine.IsDeleted)
            {
                _detailEntity.ClearRecord();
                return true;
            }
            _detailMapper.Map(newLine, _detailEntity);
            // The reason for the exists check is that when an exception is thrown,
            // new line will still be true.
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
            return true;
        }

        /// <summary>
        /// Clears the business entities.
        /// </summary>
        private void ClearBusinessEntities(ClearLevel clearLevel)
        {
            switch (clearLevel)
            {
                case ClearLevel.Header:
                    _headerEntity.Cancel();
                    _detailEntity.Cancel();
                    break;
                case ClearLevel.Detail:
                    _detailEntity.Cancel();
                    break;
            }
        }

        #endregion
    }
}
