/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull
{
    /// <summary>
    /// This represents the repository type of Batch/Header/Detail and can be used only in 'Statefull' mode.
    /// </summary>
    /// <typeparam name="TBatch">The type of the t batch.</typeparam>
    /// <typeparam name="THeader">The type of the t header.</typeparam>
    /// <typeparam name="TDetail">The type of the t detail.</typeparam>
    public abstract class BatchHeaderDetailRepository<TBatch, THeader, TDetail> : BaseRepository,
        IBatchHeaderDetailRepository<TBatch, THeader, TDetail>, ISecurity
        where TBatch : ModelBase, new()
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
    {
        #region Private Variables


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

        #region Protected Region

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>List of views</returns>
        protected abstract BatchHeaderDetailBusinessEntitySet<TBatch, THeader, TDetail> CreateBusinessEntities();

        /// <summary>
        /// Validator Filter - Reserved
        /// </summary>
        /// <value>The valid record filter.</value>
        protected Func<TBatch, Boolean> ValidRecordFilter { get; set; }

        /// <summary>
        /// Gets the Header property of the Batch
        /// </summary>
        /// <param name="batch">Batch model</param>
        /// <returns>Header model</returns>
        protected abstract THeader GetHeaderModel(TBatch batch);

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

        /// <summary>
        /// Get Detail count from Header
        /// </summary>
        /// <param name="headerEntity">Header Entity</param>
        /// <returns>Number of details</returns>
        protected abstract int GetDetailCount(IBusinessEntity headerEntity);

        /// <summary>
        /// Batch Mapper
        /// </summary>
        protected readonly ModelHierarchyMapper<TBatch> Mapper;

        /// <summary>
        /// Batch Active Filter
        /// </summary>
        protected Expression<Func<TBatch, bool>> BatchActiveFilter;

        /// <summary>
        /// Header Active Filter
        /// </summary>
        protected Expression<Func<THeader, bool>> HeaderActiveFilter;

        /// <summary>
        /// Detail Active Filter
        /// </summary>
        protected Expression<Func<TDetail, bool>> DetailActiveFilter;

        /// <summary>
        /// Batch Business Entity
        /// </summary>
        protected IBusinessEntity BatchEntity;

        /// <summary>
        /// Header Business Entity
        /// </summary>
        protected IBusinessEntity HeaderEntity;

        /// <summary>
        /// Detail Business Entity
        /// </summary>
        protected IBusinessEntity DetailEntity;

        /// <summary>
        /// Instance Batch Mapper
        /// </summary>
        protected ModelMapper<TBatch> BatchMapper;

        /// <summary>
        /// Instance of Header Mapper
        /// </summary>
        protected ModelMapper<THeader> HeaderMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        protected ModelMapper<TDetail> DetailMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// BaseEntityRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        protected BatchHeaderDetailRepository(Context context, ModelHierarchyMapper<TBatch> mapper)
            : base(context)
        {
            Mapper = mapper;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();

            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Batch Header Detail Repository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session to be used</param>
        protected BatchHeaderDetailRepository(Context context, ModelHierarchyMapper<TBatch> mapper,
            IBusinessEntitySession session)
            : base(context, session)
        {
            Mapper = mapper;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();

            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Batch Header Detail Repository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        protected BatchHeaderDetailRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Batch Header Detail Repository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        protected BatchHeaderDetailRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region IBusinessRepository Methods

        /// <summary>
        /// Get Batch using primary key
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">key</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch GetById<TKey>(TKey key)
        {
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            var fields = GetKeyField(BatchEntity);
            //Assumes Batch key is at 1
            BatchEntity.SetValue(fields[0].ID, key);
            if (!BatchEntity.Read(false))
            {
                return null;
            }

            HeaderEntity.Top();
            HeaderEntity.Browse("", true);
            if (HeaderEntity.Fetch(false))
            {
                //TODO: Remove read
                HeaderEntity.Read(false);
                DetailEntity.Top();
            }
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Get Batch using primary key
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="key">key</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch GetHeaderById<TKey>(TKey key)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            var fields = GetKeyField(HeaderEntity);
            var previousValue = HeaderEntity.GetValue<TKey>(fields[1].ID);
            //Assumes Header key is at 1
            HeaderEntity.SetValue(fields[1].ID, key);
            if (!HeaderEntity.Read(false))
            {
                HeaderEntity.SetValue(fields[1].ID, previousValue);
                //Not checking if .Read's return value since we are reverting to a known previous value
                HeaderEntity.Read(false);
                return null;
            }
            DetailEntity.Top();

            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Get a detail of the current header using the detail's unique key segement value 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>the detail's unique key segment value
        /// <returns>the model of the detail retrieved; null if the detail does not exist. </returns>
        public virtual TDetail GetDetailById<TKey>(TKey key)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            var fields = GetKeyField(DetailEntity);
            DetailEntity.SetValue(fields[2].ID, key); //Assume the 3rd item is the detail's unique key segment
            return DetailEntity.Read(false) ? DetailMapper.Map(DetailEntity) : null;
        }

        /// <summary>
        /// Gets the specified current page number.
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TBatch> Get(PageOptions<TBatch> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Batch/Header/Detail that matches the filter
        /// </summary>
        /// <param name="filter">Filter to retrieve</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>Data that matches the filter</returns>
        public virtual EnumerableResponse<TBatch> Get(Expression<Func<TBatch, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return Get(InitialPageNumber, FirstPageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the Batch/Header/Detail for the defined page size
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>EnumerableResponse&lt;TBatch&gt;.</returns>
        public virtual EnumerableResponse<TBatch> Get(int currentPageNumber, int pageSize,
            Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
        {
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Batch);

            var resultsCount = SetFilter(BatchEntity, filter, BatchActiveFilter, orderBy);
            if (!BatchEntity.Fetch(false)) return null;

            if (!Search(HeaderEntity, HeaderActiveFilter, orderBy)) throw ExceptionHelper.RowNotFoundException();

            return new EnumerableResponse<TBatch>
            {
                Items =
                    MapDataToModel(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, Mapper,
                       currentPageNumber, pageSize, resultsCount, ValidRecordFilter),
                TotalResultsCount = resultsCount
            };
        }

        /// <summary>
        /// Get Header data
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch GetHeader(Expression<Func<TBatch, bool>> filter)
        {
            IsSessionAvailable();
            //Cancel the header record while retrieval in order to reset the filter criteria in Search
            HeaderEntity.Cancel();
            if (!Search(HeaderEntity, filter)) throw ExceptionHelper.RowNotFoundException();
            if (HeaderEntity.Read(false))
            {
                HeaderEntity.Previous();
            }
            if (!BatchEntity.Read(false)) return null;
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesBatch()
        {
            return GetAttributes<TBatch>(BatchEntity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesHeader()
        {
            return GetAttributes<THeader>(HeaderEntity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail()
        {
            return GetAttributes<TDetail>(DetailEntity);
        }

        /// <summary>
        /// Get Paged Header
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Current Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>EnumerableResponse&lt;THeader&gt;.</returns>
        public EnumerableResponse<THeader> GetHeader(int pageNumber, int pageSize,
            Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            IsSessionAvailable();
            HeaderEntity.Cancel();

            var headers = new List<THeader>();
            var resultCount = 0;

            if (Search(HeaderEntity, filter, orderBy))
            {
                resultCount = SetFilter(HeaderEntity, filter, HeaderActiveFilter, orderBy);
                HeaderEntity.Top();

                var startIndex = CommonUtil.ComputeStartIndex(pageNumber, pageSize);
                var endIndex = CommonUtil.ComputeEndIndex(pageNumber, pageSize, resultCount);
                var loopCounter = 1;
                do
                {
                    if (loopCounter >= startIndex)
                    {
                        var header = HeaderMapper.Map(HeaderEntity);
                        if (header != null)
                        {
                            headers.Add(header);
                        }
                    }
                    loopCounter++;
                } while (loopCounter <= endIndex && HeaderEntity.Next());

                HeaderEntity.Cancel();
            }
            return new EnumerableResponse<THeader> { Items = headers, TotalResultsCount = resultCount };
        }

        /// <summary>
        /// Get details data
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>EnumerableResponse&lt;TDetail&gt;.</returns>
        public virtual EnumerableResponse<TDetail> GetDetail(int pageNumber, int pageSize,
            Expression<Func<TDetail, bool>> filter = null, OrderBy orderBy = null)
        {
            IsSessionAvailable();
            var resultsCount = SetFilter(DetailEntity, filter, DetailActiveFilter, orderBy);
            if (DetailEntity.Fetch(false))
            {
                // Removed a call to method GetTotlaRecords because of Performance issue. Now Added below code to get Number of Details from the Header itself
                // This would return total count of detail no matter it's inserted to database or exists in memory
                // Fixed as part of the defect D-29548 : Performance issues in GL , AR, AP , Bank Entry Screens
                // Note : The implementation of the method GetDetailCount in all child class should have actual code of getting the count from Header, If not then just return 0 so that we still 
                //        have the existing code working

                var detailCount = GetDetailCount(HeaderEntity);
                var filteredResults = new EnumerableResponse<TDetail>
                {
                    Items = MapDataToModel(DetailEntity, DetailMapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = detailCount == 0 ? GetTotlaRecords(DetailEntity) : detailCount
                };
                return filteredResults;
            }
            return new EnumerableResponse<TDetail> { Items = new List<TDetail>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the Batch total count
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int GetEntityCount()
        {
            return SetFilter(BatchEntity, null, BatchActiveFilter);
        }

        /// <summary>
        /// Get First or default record
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>Return first data</returns>
        public virtual TBatch FirstOrDefault(Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
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
        public virtual TBatch Save(TBatch model)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);


            BatchMapper.Map(model, BatchEntity);
            BatchEntity.Update();

            var header = GetHeaderModel(model);
            HeaderMapper.Map(header, HeaderEntity);

            var details = GetDetailModel(header).ToList();
            bool isDetailUpdated;
            if (HeaderEntity.Exists)
            {
                isDetailUpdated = SyncDetails(details);
                DetailEntity.Top();
                if (!isDetailUpdated && details.Any())
                {
                    if (!DetailEntity.Read(false)) throw ExceptionHelper.RowNotFoundException();
                    DetailEntity.Update();
                }
                HeaderEntity.Update();
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


            ClearBusinessEntities(ClearLevel.Detail);
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Adds model
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch Add(TBatch model)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);


            BatchMapper.Map(model, BatchEntity);
            BatchEntity.Update();

            var header = GetHeaderModel(model);
            HeaderMapper.Map(header, HeaderEntity);

            var details = GetDetailModel(header);
            if (!HeaderEntity.Exists)
            {
                SyncDetails(details);
                HeaderEntity.Insert();
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
            ClearBusinessEntities(ClearLevel.Detail);
            DetailEntity.Top();
            return NewHeader();
        }

        /// <summary>
        /// Deletes the current batch's current header.
        /// </summary>
        /// <param name="filter">Filter is ignored. Deletes the current batch's current header</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch Delete(Expression<Func<TBatch, bool>> filter)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            if (HeaderEntity.Exists)
            {
                HeaderEntity.Delete();
                NewHeader();
            }
            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError {Message = CommonResx.DeleteFailedNoRecordMessage, Priority = Priority.Error}
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Deletes the current batch's current header.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch ClearDetails(TBatch model)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            var header = GetHeaderModel(model);
            HeaderMapper.Map(header, HeaderEntity);

            DetailEntity.Top();
            var detail = GetDetailModel(header);
            if (!detail.Any())
                return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
            do
            {
                if (DetailEntity.Read(false))
                {
                    DetailEntity.Delete();
                }
                DetailEntity.ClearRecord();
            } while (DetailEntity.Next());

            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Next Batch Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>TBatch.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual TBatch Next(Expression<Func<TBatch, bool>> filter)
        {
            //return Navigate(filter, Direction.Next);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Previous Batch Record NOTE: This method has not been tested
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>TBatch.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual TBatch Previous(Expression<Func<TBatch, bool>> filter)
        {
            //return Navigate(filter, Direction.Previous);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the batch model
        /// </summary>
        /// <param name="model">Batch model</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch UpdateBatch(TBatch model)
        {
            IsSessionAvailable();
            BatchMapper.Map(model, BatchEntity);
            BatchEntity.Update();
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }



        #endregion

        #region ISecurity Methods
        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            return GetAccessRights(BatchEntity);
        }
        #endregion

        #region Batch Header Detail Methods

        /// <summary>
        /// Creates a new batch and new header
        /// </summary>
        /// <returns>Returns the created batch and header data</returns>
        public virtual TBatch NewBatch()
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);
            ClearBusinessEntities(ClearLevel.Batch);

            BatchEntity.RecordCreate(ViewRecordCreate.Insert);
            //Not checking if .Read's return value since the record was just created
            BatchEntity.Read(false);

            HeaderEntity.RecordCreate(ViewRecordCreate.NoInsert);
            //Not checking if .Read's return value since the record was just created
            HeaderEntity.Read(false);

            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>TBatch.</returns>
        public virtual TBatch NewHeader()
        {
            IsSessionAvailable();
            CheckRights(HeaderEntity, SecurityType.Modify);
            ClearBusinessEntities(ClearLevel.Header);
            HeaderEntity.RecordCreate(ViewRecordCreate.NoInsert);
            //Not checking if .Read's return value since the record was just created
            HeaderEntity.Read(false);
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual TBatch SetDetail(TDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                DetailMapper.MapKey(currentDetail, DetailEntity);
                if (DetailEntity.Exists)
                {
                    //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
                    DetailEntity.Read(false);
                    DetailMapper.Map(currentDetail, DetailEntity);
                }
            }
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null, SetFilter(DetailEntity, DetailActiveFilter));
        }

        /// <summary>
        /// Creates a new Detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual TBatch NewDetail(int pageNumber, int pageSize, TDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                DetailMapper.MapKey(currentDetail, DetailEntity);
                if (currentDetail.HasChanged && !currentDetail.IsNewLine)
                {
                    if (!DetailEntity.Read(false)) throw ExceptionHelper.RowNotFoundException();
                    DetailMapper.Map(currentDetail, DetailEntity);
                    DetailEntity.Update();
                }
                else if (currentDetail.IsNewLine)
                {
                    DetailMapper.Map(currentDetail, DetailEntity);
                    DetailEntity.Insert();
                }

            }
            DetailEntity.RecordCreate(ViewRecordCreate.NoInsert);
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null, SetFilter(DetailEntity, DetailActiveFilter));
        }

        /// <summary>
        /// Gets the Next Header record, provided the batch is already set to a batch number. NOTE: This has not been tested
        /// </summary>
        /// <returns>TBatch.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual TBatch HeaderNext()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Previous Header record, provided the batch is already set to a batch number. NOTE: This has not been tested
        /// </summary>
        /// <returns>TBatch.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual TBatch HeaderPrevious()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process for detail
        /// </summary>
        /// <param name="detail">The detail.</param>
        /// <param name="processValue">The process value.</param>
        /// <returns>TDetail.</returns>
        public virtual TDetail ProcessDetail(TDetail detail, int processValue)
        {
            IsSessionAvailable();
            var exists = DetailEntity.Exists;
            DetailMapper.MapKey(detail, DetailEntity);
            if (exists)
            {
                //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
                DetailEntity.Read(false);
            }
            //_detailMapper.Map(detail, _detailEntity);
            ProcessMap(detail, DetailEntity);
            DetailEntity.SetValue(ProcessCommand, processValue);
            DetailEntity.Process();
            //TODO: Verify If this Update is really required. This entity update is not captured in RvSpy but still We have added this to resolve bug D-07771 & D-07051
            if (DetailEntity.Exists)
            {
                DetailEntity.Update();
            }
            return DetailMapper.Map(DetailEntity);
        }

        /// <summary>
        /// Refreshes the specified batch.
        /// </summary>
        /// <param name="batch">The batch.</param>
        public virtual TBatch Refresh(TBatch batch)
        {
            IsSessionAvailable();
            Mapper.Map(batch, new List<IBusinessEntity> { BatchEntity, HeaderEntity });
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null, SetFilter(DetailEntity, DetailActiveFilter));

        }

        /// <summary>
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual TBatch RefreshDetail(TBatch model)
        {
            IsSessionAvailable();
            BatchMapper.Map(model, BatchEntity);

            var header = GetHeaderModel(model);
            HeaderMapper.Map(header, HeaderEntity);

            var detailModel = GetDetailModel(header);
            //SyncDetail(detailModel);

            foreach (var detail in detailModel)
            {
                DetailMapper.MapKey(detail, DetailEntity);
                if (DetailEntity.Exists)
                {
                    //Not checking if .Read's return value since for records that are newly created .Read shouldn't be applied.
                    DetailEntity.Read(false);
                }
                DetailMapper.Map(detail, DetailEntity);
                if (DetailEntity.Exists)
                {
                    DetailEntity.Update();
                }
            }

            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null, SetFilter(DetailEntity, DetailActiveFilter));
        }


        /// <summary>
        /// Save Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public virtual bool SaveDetails(IEnumerable<TDetail> details)
        {
            IsSessionAvailable();
            return SyncDetails(details);
        }

        /// <summary>
        /// Save for detail Entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        public virtual TBatch SaveDetail(TDetail detail)
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
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null, SetFilter(DetailEntity, DetailActiveFilter));
        }


        #endregion

        #region Private methods
        //TODO: This shall be changed once we get to know the total record count from the memory.
        /// <summary>
        /// Gets the totla records.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>System.Int32.</returns>
        private int GetTotlaRecords(IBusinessEntity businessEntity)
        {
            int total = 0;
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
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">The details.</param>
        private bool SyncDetails(IEnumerable<TDetail> details)
        {
            bool isDetailUpdated = false;
            if (details != null)
            {
                IList<TDetail> allDetails = details as IList<TDetail> ?? details.ToList();
                var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);
                if (newLine != null)
                {
                    isDetailUpdated = InsertDetail(newLine);
                }
                foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted))
                {
                    if (detail != newLine)
                    {
                        isDetailUpdated = SyncDetail(detail);
                    }
                }
            }
            return isDetailUpdated;
        }

        private bool InsertDetail(TDetail newLine)
        {
            DetailMapper.Map(newLine, DetailEntity);
            //The reason for the exists check is that when an exception is thrown, new line will still be true.
            if (!DetailEntity.Exists && !newLine.IsDeleted)
            {
                DetailEntity.Insert();
            }
            else if (DetailEntity.Exists && !newLine.IsDeleted)
            {
                DetailEntity.Update();
            }
            else if (DetailEntity.Exists && newLine.IsDeleted)
            {
                DetailEntity.Delete();
            }
            else if (!DetailEntity.Exists && newLine.IsDeleted)
            {
                DetailEntity.ClearRecord();
            }

            return true;
        }

        private bool SyncDetail(TDetail detail)
        {
            bool isDetailUpdated = false;
            DetailMapper.MapKey(detail, DetailEntity);
            if (!DetailEntity.Read(false)) throw ExceptionHelper.RowNotFoundException();
            if (detail.IsDeleted && DetailEntity.Exists)
            {
                DetailEntity.Delete();
                DetailEntity.ClearRecord();
                isDetailUpdated = true;
            }
            else if (detail.IsDeleted && !DetailEntity.Exists)
            {
                DetailEntity.ClearRecord();
                isDetailUpdated = true;
            }
            else if (DetailEntity.Exists)
            {
                DetailMapper.Map(detail, DetailEntity);
                DetailEntity.Update();
                isDetailUpdated = true;
            }
            return isDetailUpdated;
        }
        /// <summary>
        /// Clears the business entities.
        /// </summary>
        private void ClearBusinessEntities(ClearLevel clearLevel)
        {
            switch (clearLevel)
            {
                case ClearLevel.Batch:
                    BatchEntity.Cancel();
                    HeaderEntity.Cancel();
                    DetailEntity.Cancel();
                    break;
                case ClearLevel.Header:
                    HeaderEntity.Cancel();
                    DetailEntity.Cancel();
                    break;
                case ClearLevel.Detail:
                    DetailEntity.Cancel();
                    break;
            }

        }

        /// <summary>
        /// Setups the entities.
        /// </summary>
        /// <param name="businessEntitySet">The business entity set.</param>
        private void SetupEntities(BatchHeaderDetailBusinessEntitySet<TBatch, THeader, TDetail> businessEntitySet)
        {
            BatchActiveFilter = businessEntitySet.BatchFilter;
            BatchEntity = businessEntitySet.BatchBusinessEntity;
            BatchMapper = businessEntitySet.BatchMapper;

            HeaderActiveFilter = businessEntitySet.HeaderFilter;
            HeaderEntity = businessEntitySet.HeaderBusinessEntity;
            HeaderMapper = businessEntitySet.HeaderMapper;

            DetailActiveFilter = businessEntitySet.DetailFilter;
            DetailEntity = businessEntitySet.DetailBusinessEntity;
            DetailMapper = businessEntitySet.DetailMapper;
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
            var businessEntities = CreateBusinessEntities();
            var batchFilter = GetExportImportFilter(request.Keys);

            businessEntities.BatchBusinessEntity.FilterSelect(batchFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);
            BatchEntity.Top();

            var headerData = request.DataMigrationList[0];
            var detailData = request.DataMigrationList[1];
            var dataSet = new DataSet();

            if (headerData != null && headerData.Print)
            {
                headerData.Items = PropertyBuilder<THeader>.UpdateColumnNamesAndId(headerData.Items);
                var headerTable = FlatExport(businessEntities.HeaderBusinessEntity, headerData);
                headerTable.TableName = CommonUtilities.GetExportImportTableName<THeader>(request.Name);
                dataSet.Tables.Add(headerTable);
            }

            if (headerData != null && detailData != null && detailData.Print)
            {
                detailData.Items = PropertyBuilder<TDetail>.UpdateColumnNamesAndId(detailData.Items);
                var detailTable = HeaderDetailExport(businessEntities.HeaderBusinessEntity, businessEntities.DetailBusinessEntity, headerData, detailData);
                detailTable.TableName = CommonUtilities.GetExportImportTableName<TDetail>(request.Name);
                dataSet.Tables.Add(detailTable);
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
            var headerTable = CommonUtilities.GetExportImportTableName<THeader>(request.Name);
            var detailTable = CommonUtilities.GetExportImportTableName<TDetail>(request.Name);
            var headerData = dataSet.Tables[headerTable];
            var detailData = dataSet.Tables[detailTable];
            var businessEntities = CreateBusinessEntities();
            var batchFilter = GetExportImportFilter(request.Keys);
            BatchEntity = businessEntities.BatchBusinessEntity;
            BatchEntity.FilterSelect(batchFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);
            BatchEntity.Top();
            if (headerData != null && detailData != null)
            {
                return OrderHeaderImport(headerData, businessEntities.HeaderBusinessEntity, detailData, businessEntities.DetailBusinessEntity, request);
            }
            return response;
        }

        /// <summary>
        /// Get the filter string for the keys
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected virtual string GetExportImportFilter(IList<string> keys)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Clear business entities level
    /// </summary>
    public enum ClearLevel
    {
        /// <summary>
        /// Batch and below
        /// </summary>
        Batch = 0,
        /// <summary>
        /// Header and below
        /// </summary>
        Header,
        /// <summary>
        /// Detail
        /// </summary>
        Detail
    }
}