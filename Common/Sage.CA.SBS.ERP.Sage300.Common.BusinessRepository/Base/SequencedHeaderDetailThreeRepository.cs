using System;
using System.Collections.Generic;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities;
using System.Data;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Class Sequenced Header Detail Three Repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    /// <typeparam name="TDetail2">The type of the TDetail2.</typeparam>
    /// <typeparam name="TDetail3">The type of the TDetail3.</typeparam>
    public abstract class SequencedHeaderDetailThreeRepository<T, TU, TDetail2, TDetail3> : BaseRepository, ISequencedHeaderDetailThreeRepository<T, TU, TDetail2, TDetail3>
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
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
        /// Detail Active Filter 2
        /// </summary>
        private Expression<Func<TDetail2, bool>> _detailActiveFilter2;

        /// <summary>
        /// Detail Active Filter 3
        /// </summary>
        private Expression<Func<TDetail3, bool>> _detailActiveFilter3;

        /// <summary>
        /// Header Business Entity
        /// </summary>
        private IBusinessEntity _headerEntity;

        /// <summary>
        /// Detail Business Entity
        /// </summary>
        private IBusinessEntity _detailEntity;

        /// <summary>
        /// Detail 2 Business Entity
        /// </summary>
        private IBusinessEntity _detailEntity2;

        /// <summary>
        /// Detail 3 Business Entity
        /// </summary>
        private IBusinessEntity _detailEntity3;


        /// <summary>
        /// Instance of Header Mapper
        /// </summary>
        private ModelMapper<T> _headerMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        private ModelMapper<TU> _detailMapper;

        /// <summary>
        /// Instance of Detail Mapper 2
        /// </summary>
        private ModelMapper<TDetail2> _detailMapper2;

        /// <summary>
        /// Instance of Detail Mapper 3
        /// </summary>
        private ModelMapper<TDetail3> _detailMapper3;

        /// <summary>
        /// Initial PageNumber
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
        protected abstract SequencedHeaderDetailThreeBusinessEntitySet<T, TU, TDetail2, TDetail3> CreateBusinessEntities();

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
        /// Gets the Detail 2 property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail2> GetDetailModel2(T header);

        /// <summary>
        /// Gets the Detail 3 property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail3> GetDetailModel3(T header);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TU detail, IBusinessEntity detailEntity);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail2"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TDetail2 detail2, IBusinessEntity detailEntity);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail3"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TDetail3 detail3, IBusinessEntity detailEntity);

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper for the entity</param>
        protected SequencedHeaderDetailThreeRepository(Context context, ModelHierarchyMapper<T> mapper)
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
        protected SequencedHeaderDetailThreeRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Business Entity Session</param>
        protected SequencedHeaderDetailThreeRepository(Context context, ModelHierarchyMapper<T> mapper,
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
        protected SequencedHeaderDetailThreeRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
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
        /// <param name="filter">Filter expression specified on Header</param>
        /// <param name="orderBy">Records sorting order</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            return Get(InitialPageNumber, FirstPageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the header/detail record for specified page number, page size and filter expression
        /// </summary>
        /// <param name="currentPageNumber">Page number</param>
        /// <param name="pageSize">No. of records to be retrieved per page</param>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order of the records</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            CheckRights(_headerEntity, SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Header);
            var resultsCount = SetFilter(_headerEntity, filter, _headerActiveFilter, orderBy);
            _headerEntity.Fetch(false);

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
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TU> GetDetail(PageOptions<TU> pageOptions)
        {
            var filterCount = SetFilter(_detailEntity, pageOptions.Filter, _detailActiveFilter, pageOptions.OrderBy);

            var insertedRecords = 0;
            var deletedRecords = 0;

            if (pageOptions.ModifiedData != null)
            {
                Count(pageOptions.ModifiedData.ToList(), out insertedRecords, out deletedRecords);
                _detailEntity.Top();
            }

            var totalResultsCount = filterCount + (insertedRecords - deletedRecords);

            if (_detailEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = Get(_detailEntity, _detailMapper, pageOptions, filterCount, totalResultsCount),
                    TotalResultsCount = totalResultsCount
                };
            }

            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
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
                    TotalResultsCount = GetTotalRecords(_detailEntity)
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the detail2.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TDetail2> GetDetail2(PageOptions<TDetail2> pageOptions)
        {
            var filterCount = SetFilter(_detailEntity2, pageOptions.Filter, _detailActiveFilter2, pageOptions.OrderBy);

            var insertedRecords = 0;
            var deletedRecords = 0;

            if (pageOptions.ModifiedData != null)
            {
                Count(pageOptions.ModifiedData.ToList(), out insertedRecords, out deletedRecords);
                _detailEntity2.Top();
            }

            var totalResultsCount = filterCount + (insertedRecords - deletedRecords);

            if (_detailEntity2.Fetch(false))
            {
                return new EnumerableResponse<TDetail2>
                {
                    Items = Get(_detailEntity2, _detailMapper2, pageOptions, filterCount, totalResultsCount),
                    TotalResultsCount = totalResultsCount
                };
            }
            return new EnumerableResponse<TDetail2> { Items = new List<TDetail2>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the Details 2
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public virtual EnumerableResponse<TDetail2> GetDetail2(int pageNumber, int pageSize, Expression<Func<TDetail2, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var resultsCount = SetFilter(_detailEntity2, filter, _detailActiveFilter2, orderBy);

            if (_detailEntity2.Fetch(false))
            {
                return new EnumerableResponse<TDetail2>
                {
                    Items = MapDataToModel(_detailEntity2, _detailMapper2, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetTotalRecords(_detailEntity2)
                };
            }
            return new EnumerableResponse<TDetail2> { Items = new List<TDetail2>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the detail3.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<TDetail3> GetDetail3(PageOptions<TDetail3> pageOptions)
        {
            var filterCount = SetFilter(_detailEntity3, pageOptions.Filter, _detailActiveFilter3, pageOptions.OrderBy);

            var insertedRecords = 0;
            var deletedRecords = 0;

            if (pageOptions.ModifiedData != null)
            {
                Count(pageOptions.ModifiedData.ToList(), out insertedRecords, out deletedRecords);
                _detailEntity3.Top();
            }

            var totalResultsCount = filterCount + (insertedRecords - deletedRecords);


            if (_detailEntity3.Fetch(false))
            {
                return new EnumerableResponse<TDetail3>
                {
                    Items = Get(_detailEntity3, _detailMapper3, pageOptions, filterCount, totalResultsCount),
                    TotalResultsCount = totalResultsCount
                };
            }
            return new EnumerableResponse<TDetail3> { Items = new List<TDetail3>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the Details 3
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public virtual EnumerableResponse<TDetail3> GetDetail3(int pageNumber, int pageSize, Expression<Func<TDetail3, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var resultsCount = SetFilter(_detailEntity3, filter, _detailActiveFilter3, orderBy);

            if (_detailEntity3.Fetch(false))
            {
                return new EnumerableResponse<TDetail3>
                {
                    Items = MapDataToModel(_detailEntity3, _detailMapper3, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetTotalRecords(_detailEntity3)
                };
            }
            return new EnumerableResponse<TDetail3> { Items = new List<TDetail3>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Gets the header/detail total records count
        /// </summary>
        /// <returns>Header/Detail records count</returns>
        public virtual int GetEntityCount()
        {
            return SetFilter(_headerEntity, null, _headerActiveFilter);
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
            CheckRights(GetAccessRights(), SecurityType.Modify);


            var header = model;
            _headerMapper.Map(header, _headerEntity);

            var details = GetDetailModel(header).ToList();
            var details2 = GetDetailModel2(header).ToList();
            var details3 = GetDetailModel3(header).ToList();

            if (_headerEntity.Exists)
            {
                SyncDetails(details);
                SyncDetails2(details2);
                SyncDetails3(details3);
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

            return model;
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
        /// Save Details 2
        /// </summary>
        /// <param name="details2"></param>
        /// <returns></returns>
        public virtual bool SaveDetails2(IEnumerable<TDetail2> details2)
        {
            return SyncDetails2(details2);
        }

        /// <summary>
        /// Save Details 3
        /// </summary>
        /// <param name="details3"></param>
        /// <returns></returns>
        public virtual bool SaveDetails3(IEnumerable<TDetail3> details3)
        {
            return SyncDetails3(details3);
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
        /// Save for detail Entry
        /// </summary>
        /// <param name="detail2">Detail model</param>
        /// <returns></returns>
        public virtual T SaveDetail2(TDetail2 detail2)
        {
            if (detail2.IsNewLine)
            {
                InsertDetail2(detail2);
            }
            else
            {
                SyncDetail2(detail2);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 });
        }

        /// <summary>
        /// Save for detail Entry
        /// </summary>
        /// <param name="detail2">Detail model</param>
        /// <returns></returns>
        public virtual T SaveDetail3(TDetail3 detail2)
        {
            if (detail2.IsNewLine)
            {
                InsertDetail3(detail2);
            }
            else
            {
                SyncDetail3(detail2);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 });
        }

        /// <summary>
        /// Add new header/detail record
        /// </summary>
        /// <param name="model">Object to be saved</param>
        /// <returns>added header/detail record</returns>
        public virtual T Add(T model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);

            _headerMapper.Map(model, _headerEntity);

            var details = GetDetailModel(model);
            var details2 = GetDetailModel2(model);
            var details3 = GetDetailModel3(model);

            if (!_headerEntity.Exists)
            {
                SyncDetails(details);
                SyncDetails2(details2);
                SyncDetails3(details3);

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
            _detailEntity2.Top();
            _detailEntity3.Top();
            //If more than one detail items are retrieved then move the pointer to Top of the detail entity
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detailEntity2, _detailEntity3 });
        }

        /// <summary>
        /// Deletes a header/detail record based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Next header/detail record</returns>
        public virtual T Delete(Expression<Func<T, bool>> filter)
        {
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
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detailEntity2, _detailEntity3 });
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
            CheckRights(_headerEntity, SecurityType.Inquire);
            var fields = GetKeyField(_headerEntity);
            _headerEntity.SetValue(fields[0].ID, key);

            if (!_headerEntity.Read(false))
            {
                return null;
            }
            _detailEntity.Top();
            _detailEntity2.Top();
            _detailEntity3.Top();

            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detailEntity2, _detailEntity3 });
        }

        #endregion

        #region IOrderedHeaderDetailRepository Methods

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>T.</returns>
        public virtual T NewHeader()
        {
            CheckRights(_headerEntity, SecurityType.Add);
            ClearBusinessEntities(ClearLevel.Header);
            _headerEntity.Init();
            _headerEntity.Read(false);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detailEntity2, _detailEntity3 });
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
        /// Creates a new Detail 2
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail2">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail2)
        {
            if (currentDetail2 != null)
            {
                _detailMapper2.MapKey(currentDetail2, _detailEntity2);
                if (currentDetail2.HasChanged && !currentDetail2.IsNewLine)
                {
                    if (_detailEntity2.Exists)
                    {
                        _detailEntity2.Read(false);
                        _detailMapper2.Map(currentDetail2, _detailEntity2);
                        _detailEntity2.Update();
                    }
                    else
                    {
                        _detailMapper2.Map(currentDetail2, _detailEntity2);
                        _detailEntity2.Insert();
                    }
                }
                else if (currentDetail2.IsNewLine)
                {
                    _detailMapper2.Map(currentDetail2, _detailEntity2);
                    _detailEntity2.Insert();
                }
            }

            _detailEntity2.RecordCreate(ViewRecordCreate.NoInsert);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 }, 0, 0, SetFilter(_detailEntity2, _detailActiveFilter2));
        }

        /// <summary>
        /// Creates a new Detail 3
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail2">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail2)
        {
            if (currentDetail2 != null)
            {
                _detailMapper3.MapKey(currentDetail2, _detailEntity2);
                if (currentDetail2.HasChanged && !currentDetail2.IsNewLine)
                {
                    if (_detailEntity3.Exists)
                    {
                        _detailEntity3.Read(false);
                        _detailMapper3.Map(currentDetail2, _detailEntity3);
                        _detailEntity3.Update();
                    }
                    else
                    {
                        _detailMapper3.Map(currentDetail2, _detailEntity3);
                        _detailEntity3.Insert();
                    }
                }
                else if (currentDetail2.IsNewLine)
                {
                    _detailMapper3.Map(currentDetail2, _detailEntity3);
                    _detailEntity3.Insert();
                }
            }

            _detailEntity3.RecordCreate(ViewRecordCreate.NoInsert);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 }, 0, 0, SetFilter(_detailEntity3, _detailActiveFilter3));
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
                _detailEntity.ClearRecord();
                isDeleted = true;
            }
            return isDeleted;
        }

        /// <summary>
        /// Deletes a detail 2
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail record</returns>
        public virtual bool DeleteDetail2(Expression<Func<TDetail2, bool>> filter)
        {
            CheckRights(_headerEntity, SecurityType.Delete);
            var is2Deleted = false;
            Search(_detailEntity2, filter);
            if (_detailEntity2.Exists)
            {
                _detailEntity2.Delete();
                _detailEntity2.ClearRecord();
                is2Deleted = true;
            }
            return is2Deleted;
        }


        /// <summary>
        /// Deletes a detail 2
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail record</returns>
        public virtual bool DeleteDetail3(Expression<Func<TDetail3, bool>> filter)
        {
            CheckRights(_headerEntity, SecurityType.Delete);
            var is3Deleted = false;
            Search(_detailEntity3, filter);
            if (_detailEntity3.Exists)
            {
                _detailEntity3.Delete();
                _detailEntity3.ClearRecord();
                is3Deleted = true;
            }
            return is3Deleted;
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
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T SetDetail2(TDetail2 currentDetail)
        {
            if (currentDetail != null)
            {
                _detailMapper2.MapKey(currentDetail, _detailEntity2);
                if (_detailEntity.Exists)
                {
                    _detailEntity2.Read(false);
                    _detailMapper2.Map(currentDetail, _detailEntity2);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 }, 0, 0, SetFilter(_detailEntity2, _detailActiveFilter2));
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual T SetDetail3(TDetail3 currentDetail)
        {
            if (currentDetail != null)
            {
                _detailMapper3.MapKey(currentDetail, _detailEntity3);
                if (_detailEntity3.Exists)
                {
                    _detailEntity3.Read(false);
                    _detailMapper3.Map(currentDetail, _detailEntity3);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 }, 0, 0, SetFilter(_detailEntity3, _detailActiveFilter3));
        }

        /// <summary>
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual T RefreshDetail(T model)
        {
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
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual T RefreshDetail2(T model)
        {
            _headerMapper.Map(model, _headerEntity);

            var detailModel = GetDetailModel2(model);
            foreach (var detail in detailModel)
            {
                _detailMapper2.MapKey(detail, _detailEntity2);

                if (_detailEntity2.Exists)
                {
                    _detailEntity2.Read(false);
                }
                if (!_detailEntity2.Exists)
                    detail.IsNewLine = true;

                _detailMapper2.Map(detail, _detailEntity2);

                if (_detailEntity2.Exists)
                {
                    _detailEntity2.Update();
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 }, 0, 0, SetFilter(_detailEntity2, _detailActiveFilter));
        }

        /// <summary>
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual T RefreshDetail3(T model)
        {
            _headerMapper.Map(model, _headerEntity);

            var detailModel = GetDetailModel3(model);
            foreach (var detail in detailModel)
            {
                _detailMapper3.MapKey(detail, _detailEntity2);

                if (_detailEntity3.Exists)
                {
                    _detailEntity3.Read(false);
                }
                if (!_detailEntity3.Exists)
                    detail.IsNewLine = true;

                _detailMapper3.Map(detail, _detailEntity3);

                if (_detailEntity3.Exists)
                {
                    _detailEntity3.Update();
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 }, 0, 0, SetFilter(_detailEntity3, _detailActiveFilter));
        }

        /// <summary>
        /// To clear the details
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual T ClearDetails(T model)
        {
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
        /// To clear the details
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual T ClearDetails2(T model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);
            _headerMapper.Map(model, _headerEntity);

            var details2 = GetDetailModel2(model);
            _detailEntity2.Top();
            if (!details2.Any())
                return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 });
            do
            {
                if (_detailEntity2.Read(false))
                    _detailEntity2.Delete();
                _detailEntity2.ClearRecord();
            } while (_detailEntity2.Next());
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity2 });
        }

        /// <summary>
        /// To clear the details
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual T ClearDetails3(T model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);
            _headerMapper.Map(model, _headerEntity);

            var details3 = GetDetailModel3(model);
            _detailEntity3.Top();
            if (!details3.Any())
                return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 });
            do
            {
                if (_detailEntity3.Read(false))
                    _detailEntity3.Delete();
                _detailEntity3.ClearRecord();
            } while (_detailEntity3.Next());
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity3 });
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
        /// Process for detail 2
        /// </summary>
        /// <param name="detail2">Ordered Header Detail</param>
        /// <returns>Ordered Header Detail object</returns>
        public virtual TDetail2 ProcessDetail2(TDetail2 detail2)
        {
            var exists = _detailEntity2.Exists;
            if (exists)
            {
                _detailMapper2.MapKey(detail2, _detailEntity2);
                _detailEntity2.Read(false);
            }
            ProcessMap(detail2, _detailEntity2);
            _detailEntity2.SetValue(ProcessCommand, 0);
            _detailEntity2.Process();
            //TODO: Verify If this Update is really required. This entity update is not captured in RvSpy but still We have added this to resolve bug D-07771 & D-07051
            if (_detailEntity2.Exists)
            {
                _detailEntity2.Update();
            }
            return _detailMapper2.Map(_detailEntity2);
        }

        /// <summary>
        /// Process for detail 3
        /// </summary>
        /// <param name="detail3">Ordered Header Detail</param>
        /// <returns>Ordered Header Detail object</returns>
        public virtual TDetail3 ProcessDetail3(TDetail3 detail3)
        {
            var exists = _detailEntity3.Exists;
            if (exists)
            {
                _detailMapper3.MapKey(detail3, _detailEntity3);
                _detailEntity3.Read(false);
            }
            ProcessMap(detail3, _detailEntity3);
            _detailEntity3.SetValue(ProcessCommand, 0);
            _detailEntity3.Process();
            //TODO: Verify If this Update is really required. This entity update is not captured in RvSpy but still We have added this to resolve bug D-07771 & D-07051
            if (_detailEntity3.Exists)
            {
                _detailEntity3.Update();
            }
            return _detailMapper3.Map(_detailEntity3);
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public T Refresh(T header)
        {
            _mapper.Map(header, new List<IBusinessEntity> { _headerEntity });
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detailEntity2, _detailEntity3 }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
        }

        /// <summary>
        /// Exports the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>DataSet.</returns>
        public virtual DataSet Export(ExportRequest request)
        {
            CreateBusinessEntities();

            var headerData = request.DataMigrationList[0];
            var detailData = request.DataMigrationList[1];
            var detailData2 = request.DataMigrationList[2];
            var detailData3 = request.DataMigrationList[3];
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
            detailData2.Items = PropertyBuilder<TDetail2>.UpdateColumnNamesAndId(detailData2.Items);
            detailData3.Items = PropertyBuilder<TDetail3>.UpdateColumnNamesAndId(detailData3.Items);
            var detailTable = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData);
            var detailTable2 = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData2);
            var detailTable3 = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData3);
            detailTable.TableName = CommonUtilities.GetExportImportTableName<TU>(request.Name);
            detailTable2.TableName = CommonUtilities.GetExportImportTableName<TDetail2>(request.Name);
            detailTable3.TableName = CommonUtilities.GetExportImportTableName<TDetail3>(request.Name);
            dataSet.Tables.Add(detailTable);
            dataSet.Tables.Add(detailTable2);
            dataSet.Tables.Add(detailTable3);
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
            var headerTable = CommonUtilities.GetExportImportTableName<T>(request.Name);
            var detailTable = CommonUtilities.GetExportImportTableName<TU>(request.Name);
            var detailTable2 = CommonUtilities.GetExportImportTableName<TDetail2>(request.Name);
            var detailTable3 = CommonUtilities.GetExportImportTableName<TDetail3>(request.Name);
            var headerData = dataSet.Tables[headerTable];
            var detailData = dataSet.Tables[detailTable];
            var detailData2 = dataSet.Tables[detailTable2];
            var detailData3 = dataSet.Tables[detailTable3];
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
        private void SetupEntities(SequencedHeaderDetailThreeBusinessEntitySet<T, TU, TDetail2, TDetail3> businessEntitySet)
        {
            _headerActiveFilter = businessEntitySet.HeaderFilter;
            _headerEntity = businessEntitySet.HeaderBusinessEntity;
            _headerMapper = businessEntitySet.HeaderMapper;

            _detailActiveFilter = businessEntitySet.DetailFilter;
            _detailActiveFilter2 = businessEntitySet.DetailFilter2;
            _detailActiveFilter3 = businessEntitySet.DetailFilter3;
            _detailEntity = businessEntitySet.DetailBusinessEntity;
            _detailEntity2 = businessEntitySet.DetailBusinessEntity2;
            _detailEntity3 = businessEntitySet.DetailBusinessEntity3;
            _detailMapper = businessEntitySet.DetailMapper;
            _detailMapper2 = businessEntitySet.DetailMapper2;
            _detailMapper3 = businessEntitySet.DetailMapper3;
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
            _detailEntity.Read(false);
            if (!_detailEntity.Exists && !detail.IsDeleted)
            {
                _detailEntity.Insert();
                detail.IsNewLine = false;
            }
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
        /// 
        /// </summary>
        /// <param name="detail2"></param>
        /// <returns></returns>
        private bool SyncDetail2(TDetail2 detail2)
        {
            var isDetail2Updated = false;
            _detailMapper2.MapKey(detail2, _detailEntity2);
            if (!_detailEntity.Exists && !detail2.IsDeleted)
            {
                _detailEntity.Insert();
                detail2.IsNewLine = false;
            }
            _detailEntity2.Read(false);
            if (detail2.IsDeleted && _detailEntity2.Exists)
            {
                _detailEntity2.Delete();
                isDetail2Updated = true;
            }
            else if (detail2.IsDeleted && !_detailEntity2.Exists)
            {
                _detailEntity2.ClearRecord();
                isDetail2Updated = true;
            }
            else if (_detailEntity2.Exists)
            {
                _detailMapper2.Map(detail2, _detailEntity2);
                _detailEntity2.Update();
                isDetail2Updated = true;
            }
            return isDetail2Updated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detail3"></param>
        /// <returns></returns>
        private bool SyncDetail3(TDetail3 detail3)
        {
            var isDetail3Updated = false;
            _detailMapper3.MapKey(detail3, _detailEntity3);
            if (!_detailEntity3.Exists && !detail3.IsDeleted)
            {
                _detailEntity3.Insert();
                detail3.IsNewLine = false;
            }
            _detailEntity3.Read(false);
            if (detail3.IsDeleted && _detailEntity3.Exists)
            {
                _detailEntity3.Delete();
                isDetail3Updated = true;
            }
            else if (detail3.IsDeleted && !_detailEntity3.Exists)
            {
                _detailEntity3.ClearRecord();
                isDetail3Updated = true;
            }
            else if (_detailEntity3.Exists)
            {
                _detailMapper3.Map(detail3, _detailEntity3);
                _detailEntity3.Update();
                isDetail3Updated = true;
            }
            return isDetail3Updated;
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
            //var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);

            //if (newLine != null)
            //{
            //    isDetailUpdated = InsertDetail(newLine);
            //}

            foreach (var newLine in allDetails.Where(newLine => newLine.IsNewLine))
            {
                isDetailUpdated = InsertDetail(newLine);
            }

            foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted))
            {
                isDetailUpdated = SyncDetail(detail);
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details2">The details.</param>
        private bool SyncDetails2(IEnumerable<TDetail2> details2)
        {
            var isDetail2Updated = false;
            if (details2 == null) return false;

            var allDetails = details2 as IList<TDetail2> ?? details2.ToList();
            var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);

            if (newLine != null)
            {
                isDetail2Updated = InsertDetail2(newLine);
            }
            foreach (var detail2 in allDetails.Where(detail2 => detail2.HasChanged || detail2.IsDeleted).Where(detail2 => detail2 != newLine))
            {
                isDetail2Updated = SyncDetail2(detail2);
            }
            return isDetail2Updated;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details3">The details.</param>
        private bool SyncDetails3(IEnumerable<TDetail3> details3)
        {
            var isDetail3Updated = false;
            if (details3 == null) return false;

            var allDetails = details3 as IList<TDetail3> ?? details3.ToList();
            var newLine = allDetails.FirstOrDefault(detail3 => detail3.IsNewLine);

            if (newLine != null)
            {
                isDetail3Updated = InsertDetail3(newLine);
            }
            foreach (var detail3 in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted).Where(detail => detail != newLine))
            // foreach (var detail3 in allDetails)
            {
                isDetail3Updated = SyncDetail3(detail3);
            }
            return isDetail3Updated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newLine"></param>
        /// <returns></returns>
        private bool InsertDetail(TU newLine)
        {
            _detailEntity.RecordCreate(ViewRecordCreate.NoInsert);
            _detailMapper.Map(newLine, _detailEntity);
            if (!_detailEntity.Exists && newLine.IsDeleted)
            {
                _detailEntity.ClearRecord();
            }
            _detailMapper.Map(newLine, _detailEntity);

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
        /// 
        /// </summary>
        /// <param name="newLine2"></param>
        /// <returns></returns>
        private bool InsertDetail2(TDetail2 newLine2)
        {
            _detailMapper2.Map(newLine2, _detailEntity2);
            if (!_detailEntity2.Exists && newLine2.IsDeleted)
            {
                _detailEntity2.ClearRecord();
            }
            _detailMapper2.Map(newLine2, _detailEntity2);
            if (!_detailEntity2.Exists && !newLine2.IsDeleted)
            {
                _detailEntity2.Insert();
                newLine2.IsNewLine = false;
            }
            else if (_detailEntity2.Exists && !newLine2.IsDeleted)
            {
                _detailEntity2.Update();
            }
            else if (_detailEntity2.Exists && newLine2.IsDeleted)
            {
                _detailEntity2.Delete();
            }


            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newLine3"></param>
        /// <returns></returns>
        private bool InsertDetail3(TDetail3 newLine3)
        {
            _detailMapper3.Map(newLine3, _detailEntity3);
            if (!_detailEntity3.Exists && newLine3.IsDeleted)
            {
                _detailEntity3.ClearRecord();
            }
            _detailMapper3.Map(newLine3, _detailEntity3);
            if (!_detailEntity3.Exists && !newLine3.IsDeleted)
            {
                _detailEntity3.Insert();
                newLine3.IsNewLine = false;
            }
            else if (_detailEntity3.Exists && !newLine3.IsDeleted)
            {
                _detailEntity3.Update();
            }
            else if (_detailEntity3.Exists && newLine3.IsDeleted)
            {
                _detailEntity3.Delete();
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
                    _detailEntity2.Cancel();
                    _detailEntity3.Cancel();
                    break;
                case ClearLevel.Detail:
                    _detailEntity.Cancel();
                    _detailEntity2.Cancel();
                    _detailEntity3.Cancel();
                    break;
            }
        }

        #endregion

    }
}
