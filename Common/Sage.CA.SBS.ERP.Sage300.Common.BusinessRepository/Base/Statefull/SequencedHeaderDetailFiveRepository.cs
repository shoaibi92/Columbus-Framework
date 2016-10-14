using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.PODropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull
{
    /// <summary>
    /// Class SequencedHeaderDetailFiveRepository.
    /// </summary>
    /// <typeparam name="THeader"></typeparam>
    /// <typeparam name="TDetail">The type of the TDetail.</typeparam>
    /// <typeparam name="TDetail2">The type of the TDetail2.</typeparam>
    /// <typeparam name="TDetail3">The type of the TDetail3.</typeparam>
    /// <typeparam name="TDetail4">The type of the TDetail4.</typeparam>
    /// <typeparam name="TDetail5">The type of the TDetail5.</typeparam>
    public abstract class SequencedHeaderDetailFiveRepository<THeader, TDetail, TDetail2, TDetail3, TDetail4, TDetail5> : BaseRepository, ISequencedHeaderDetailFiveRepository<THeader, TDetail, TDetail2, TDetail3, TDetail4, TDetail5>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TDetail4 : ModelBase, new()
        where TDetail5 : ModelBase, new()
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
        /// Detail 2 Active Filter
        /// </summary>
        private Expression<Func<TDetail2, bool>> _detail2ActiveFilter;

        /// <summary>
        /// Detail 3 Active Filter
        /// </summary>
        private Expression<Func<TDetail3, bool>> _detail3ActiveFilter;

        /// <summary>
        /// Detail 4 Active Filter
        /// </summary>
        private Expression<Func<TDetail4, bool>> _detail4ActiveFilter;

        /// <summary>
        /// Detail 5 Active Filter
        /// </summary>
        private Expression<Func<TDetail5, bool>> _detail5ActiveFilter;

        /// <summary>
        /// Header Business Entity
        /// </summary>
        private IBusinessEntity _headerEntity;

        /// <summary>
        /// Detail Business Entity
        /// </summary>
        private IBusinessEntity _detailEntity;


        /// <summary>
        /// Detail Business Entity 2
        /// </summary>
        private IBusinessEntity _detail2Entity;

        /// <summary>
        /// Detail Business Entity 3
        /// </summary>
        private IBusinessEntity _detail3Entity;

        /// <summary>
        /// Detail Business Entity 4
        /// </summary>
        private IBusinessEntity _detail4Entity;

        /// <summary>
        /// Detail Business Entity 5
        /// </summary>
        private IBusinessEntity _detail5Entity;

        /// <summary>
        /// Detail Business Entity 5
        /// </summary>
        private IBusinessEntity _distributionProrationEntity;

        /// <summary>
        /// Instance of Header Mapper
        /// </summary>
        private ModelMapper<THeader> _headerMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        private ModelMapper<TDetail> _detailMapper;

        /// <summary>
        /// Instance of Detail 2 Mapper
        /// </summary>
        private ModelMapper<TDetail2> _detail2Mapper;

        /// <summary>
        /// Instance of Detail 3 Mapper
        /// </summary>
        private ModelMapper<TDetail3> _detail3Mapper;

        /// <summary>
        /// Instance of Detail 4 Mapper
        /// </summary>
        private ModelMapper<TDetail4> _detail4Mapper;

        /// <summary>
        /// Instance of Detail 5 Mapper
        /// </summary>
        private ModelMapper<TDetail5> _detail5Mapper;

        /// <summary>
        /// Instance of DistributionProrationMapper
        /// </summary>
        private ModelMapper<Proration> _distributionProrationMapper;

        /// <summary>
        /// Instance of Bill To Locataion
        /// </summary>
        private ModelMapper<BillToLocation> _billToLocationMapper;

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

        /// <summary>
        /// Comment Identifier
        /// </summary>
        private const long CommentIdentifier = -999999999999999999;

        #endregion

        #region Protected methods

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract SequencedHeaderDetailFiveBusinessEntitySet<THeader, TDetail, TDetail2, TDetail3, TDetail4, TDetail5> CreateBusinessEntities();

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
        /// Gets the Detail property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail2> GetDetail2Model(THeader header);

        /// <summary>
        /// Gets the Detail 3 property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail3> GetDetail3Model(THeader header);

        /// <summary>
        /// Gets the Detail 4 property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail4> GetDetail4Model(THeader header);

        /// <summary>
        /// Gets the Detail 5 property of the Header
        /// </summary>
        /// <param name="header">Header</param>
        /// <returns>List of details</returns>
        protected abstract IEnumerable<TDetail5> GetDetail5Model(THeader header);

        /// <summary>
        /// Map for process detail
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="detailEntity"></param>
        protected abstract void ProcessMap(TDetail detail, IBusinessEntity detailEntity);

        /// <summary>
        /// Map for process detail 2
        /// </summary>
        /// <param name="detail2"></param>
        /// <param name="detail2Entity"></param>
        protected abstract void ProcessMap2(TDetail2 detail2, IBusinessEntity detail2Entity);

        /// <summary>
        /// Map for process detail 4
        /// </summary>
        /// <param name="detail3"></param>
        /// <param name="detail3Entity"></param>
        protected abstract void ProcessMap3(TDetail3 detail3, IBusinessEntity detail3Entity);

        /// <summary>
        /// Map for process detail 4
        /// </summary>
        /// <param name="detail4"></param>
        /// <param name="detail4Entity"></param>
        protected abstract void ProcessMap4(TDetail4 detail4, IBusinessEntity detail4Entity);

        /// <summary>
        /// Map for process detail 5
        /// </summary>
        /// <param name="detail5"></param>
        /// <param name="detail5Entity"></param>
        protected abstract void ProcessMap5(TDetail5 detail5, IBusinessEntity detail5Entity);

        /// <summary>
        /// Get Detail count from Header
        /// </summary>
        /// <param name="headerEntity">Header Entity</param>
        /// <returns>Number of details</returns>
        protected abstract int GetDetailCount(IBusinessEntity headerEntity);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper for the entity</param>
        protected SequencedHeaderDetailFiveRepository(Context context, ModelHierarchyMapper<THeader> mapper)
            : base(context)
        {
            _mapper = mapper;
            //// ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        protected SequencedHeaderDetailFiveRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequencedHeaderDetailFiveRepository{THeader, TDetail, TDetail2, TDetail3, TDetail4, TDetail5}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected SequencedHeaderDetailFiveRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor for Sequenced Header Detail Repository
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Business Entity Session</param>
        protected SequencedHeaderDetailFiveRepository(Context context, ModelHierarchyMapper<THeader> mapper,
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
        protected SequencedHeaderDetailFiveRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected SequencedHeaderDetailFiveRepository(Context context, ModelHierarchyMapper<THeader> mapper, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, mapper, null, ObjectPoolType.Default, businessEntitySessionParams)
        {
            _mapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected SequencedHeaderDetailFiveRepository(Context context, ModelHierarchyMapper<THeader> mapper, Expression<Func<THeader, bool>> activeFilter, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, mapper, activeFilter, ObjectPoolType.Default, businessEntitySessionParams)
        {
            _mapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = CreateBusinessEntities();
            SetupEntities(businessEntitySet);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected SequencedHeaderDetailFiveRepository(Context context, DBLinkType dbLinkType, ModelHierarchyMapper<THeader> mapper,
            Expression<Func<THeader, bool>> activeFilter, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
            _headerActiveFilter = activeFilter;
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
        protected SequencedHeaderDetailFiveRepository(Context context, DBLinkType dbLinkType, ModelHierarchyMapper<THeader> mapper,
            Expression<Func<THeader, bool>> activeFilter, IBusinessEntitySession session, ObjectPoolType sessionPoolType,
            BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, session, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
            _headerActiveFilter = activeFilter;
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
        /// Get the Header/Detail record based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression specified on Header</param>
        /// <param name="orderBy">Records sorting order</param>
        /// <returns>Header/Detail record</returns>
        public virtual EnumerableResponse<THeader> Get(Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
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
        public virtual EnumerableResponse<THeader> Get(int currentPageNumber, int pageSize,
            Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            CheckRights(_headerEntity, SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Header);
            var resultsCount = SetFilter(_headerEntity, filter, _headerActiveFilter, orderBy);

            if (!_headerEntity.Fetch(false))
            {
                return new EnumerableResponse<THeader> { Items = new List<THeader>(), TotalResultsCount = 0 };
            }

            Search(_detailEntity, _detailActiveFilter, orderBy);
            Search(_detail2Entity, _detail2ActiveFilter, orderBy);
            Search(_detail3Entity, _detail3ActiveFilter, orderBy);
            Search(_detail4Entity, _detail4ActiveFilter, orderBy);
            Search(_detail5Entity, _detail5ActiveFilter, orderBy);

            return new EnumerableResponse<THeader>
            {
                Items =
                    MapDataToModel(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity }, _mapper, currentPageNumber,
                        pageSize, resultsCount, ValidRecordFilter),
                TotalResultsCount = resultsCount
            };


        }

        /// <summary>
        /// Gets the Details
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public virtual EnumerableResponse<TDetail> GetDetail(int pageNumber, int pageSize, Expression<Func<TDetail, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDetailModels(_headerEntity, _detailEntity, _detailMapper, _detailActiveFilter, pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the Details 2
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details 2</returns>
        public virtual EnumerableResponse<TDetail2> GetDetail2(int pageNumber, int pageSize, Expression<Func<TDetail2, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDetailModels(_detail2Entity, _detail2Mapper, _detail2ActiveFilter, pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the Details 3
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details 3</returns>
        public virtual EnumerableResponse<TDetail3> GetDetail3(int pageNumber, int pageSize, Expression<Func<TDetail3, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDetailModels(_detail3Entity, _detail3Mapper, _detail3ActiveFilter, pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the Details 4
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details 4</returns>
        public virtual EnumerableResponse<TDetail4> GetDetail4(int pageNumber, int pageSize, Expression<Func<TDetail4, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDetailModels(_detail4Entity, _detail4Mapper, _detail4ActiveFilter, pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Gets the Details 5
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details 5</returns>
        public virtual EnumerableResponse<TDetail5> GetDetail5(int pageNumber, int pageSize, Expression<Func<TDetail5, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDetailModels(_detail5Entity, _detail5Mapper, _detail5ActiveFilter, pageNumber, pageSize, filter, orderBy);
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
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail2()
        {
            return GetAttributes<TDetail2>(_detail2Entity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail3()
        {
            return GetAttributes<TDetail3>(_detail3Entity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail4()
        {
            return GetAttributes<TDetail4>(_detail4Entity);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail5()
        {
            return GetAttributes<TDetail5>(_detail5Entity);
        }

        /// <summary>
        /// Gets first or default header/detail record based on the filter expression
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
            var details2 = GetDetail2Model(header).ToList();
            var details3 = GetDetail3Model(header).ToList();
            var details4 = GetDetail4Model(header).ToList();
            var details5 = GetDetail5Model(header).ToList();
            if (_headerEntity.Exists)
            {
                SyncDetails(details);
                SyncDetails2(details2);
                SyncDetails3(details3);
                SyncDetails4(details4);
                SyncDetails5(details5);

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
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity });
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
        /// Save Details 2
        /// </summary>
        /// <param name="details2"></param>
        /// <returns></returns>
        public virtual bool SaveDetails2(IEnumerable<TDetail2> details2)
        {
            IsSessionAvailable();
            return SyncDetails2(details2);
        }

        /// <summary>
        /// Save Details 3
        /// </summary>
        /// <param name="details3"></param>
        /// <returns></returns>
        public virtual bool SaveDetails3(IEnumerable<TDetail3> details3)
        {
            IsSessionAvailable();
            return SyncDetails3(details3);
        }

        /// <summary>
        /// Save Details 4
        /// </summary>
        /// <param name="details4"></param>
        /// <returns></returns>
        public virtual bool SaveDetails4(IEnumerable<TDetail4> details4)
        {
            IsSessionAvailable();
            return SyncDetails4(details4);
        }

        /// <summary>
        /// Save Details 5
        /// </summary>
        /// <param name="details5"></param>
        /// <returns></returns>
        public virtual bool SaveDetails5(IEnumerable<TDetail5> details5)
        {
            IsSessionAvailable();
            return SyncDetails5(details5);
        }

        /// <summary>
        /// Save for detail Entry
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
        /// Save for detail 2 Entry
        /// </summary>
        /// <param name="detail2">Detail model</param>
        /// <returns></returns>
        public virtual THeader SaveDetail2(TDetail2 detail2)
        {
            IsSessionAvailable();
            if (detail2.IsNewLine)
            {
                InsertDetail2(detail2);
            }
            else
            {
                SyncDetail2(detail2);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail2Entity });
        }

        /// <summary>
        /// Save for detail 3 Entry
        /// </summary>
        /// <param name="detail3">Detail model</param>
        /// <returns></returns>
        public virtual THeader SaveDetail3(TDetail3 detail3)
        {
            IsSessionAvailable();
            if (detail3.IsNewLine)
            {
                InsertDetail3(detail3);
            }
            else
            {
                SyncDetail3(detail3);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail3Entity });
        }

        /// <summary>
        /// Save for detail 4 Entry
        /// </summary>
        /// <param name="detail4">Detail model</param>
        /// <returns></returns>
        public virtual THeader SaveDetail4(TDetail4 detail4)
        {
            IsSessionAvailable();
            if (detail4.IsNewLine)
            {
                InsertDetail4(detail4);
            }
            else
            {
                SyncDetail4(detail4);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail4Entity });
        }

        /// <summary>
        /// Save for detail 5 Entry
        /// </summary>
        /// <param name="detail5">Detail model</param>
        /// <returns></returns>
        public virtual THeader SaveDetail5(TDetail5 detail5)
        {
            IsSessionAvailable();
            if (detail5.IsNewLine)
            {
                InsertDetail5(detail5);
            }
            else
            {
                SyncDetail5(detail5);
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail5Entity });
        }

        /// <summary>
        /// Add new header/detail record
        /// </summary>
        /// <param name="model">Object to be saved</param>
        /// <returns>added header/detail record</returns>
        public virtual THeader Add(THeader model)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);

            _headerMapper.Map(model, _headerEntity);

            var details = GetDetailModel(model);
            var details2 = GetDetail2Model(model);
            var details3 = GetDetail3Model(model);
            var details4 = GetDetail4Model(model);
            var details5 = GetDetail5Model(model);

            if (!_headerEntity.Exists)
            {
                SyncDetails(details);
                SyncDetails2(details2);
                SyncDetails3(details3);
                SyncDetails4(details4);
                SyncDetails5(details5);

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

            //If more than one detail items are retrieved then move the pointer to Top of the detail entity
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity });
        }

        /// <summary>
        /// Deletes a header/detail record based on the filter expression
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

            return NewHeader();
        }

        /// <summary>
        /// Navigates to next header/detail record
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Header/detail record</returns>
        public virtual THeader Next(Expression<Func<THeader, bool>> filter)
        {
            return Navigate(filter, Direction.Next);
        }

        /// <summary>
        /// Navigates to previous header/detail record
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

            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity });
        }

        #endregion

        #region Header Detail Five Repository Methods

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>T.</returns>
        public virtual THeader NewHeader()
        {
            CheckRights(_headerEntity, SecurityType.Inquire);
            ClearBusinessEntities(ClearLevel.Header);
            _headerEntity.Init();
            _headerEntity.RecordCreate(ViewRecordCreate.NoInsert);
            _headerEntity.Read(false);

            var headerModel = _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity });
            headerModel.Warnings = Helper.GetExceptions(Session);

            return headerModel;
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
            return NewDetailModels(_detailEntity, _detailMapper, _detailActiveFilter, currentDetail);
        }

        /// <summary>
        /// Creates a new Detail 2
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail2">The current detail 2.</param>
        /// <returns>TDetail 2.</returns>
        public virtual THeader NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail2)
        {
            return NewDetailModels(_detail2Entity, _detail2Mapper, _detail2ActiveFilter, currentDetail2);
        }

        /// <summary>
        /// Creates a new Detail 3
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail3">The current detail 3.</param>
        /// <returns>TDetail 3.</returns>
        public virtual THeader NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail3)
        {
            return NewDetailModels(_detail3Entity, _detail3Mapper, _detail3ActiveFilter, currentDetail3);
        }

        /// <summary>
        /// Creates a new Detail 4
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail4">The current detail 4.</param>
        /// <returns>TDetail 4.</returns>
        public virtual THeader NewDetail4(int pageNumber, int pageSize, TDetail4 currentDetail4)
        {
            return NewDetailModels(_detail4Entity, _detail4Mapper, _detail4ActiveFilter, currentDetail4);
        }

        /// <summary>
        /// Creates a new Detail 5
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail5">The current detail 5.</param>
        /// <returns>TDetail 5.</returns>
        public virtual THeader NewDetail5(int pageNumber, int pageSize, TDetail5 currentDetail5)
        {

            return NewDetailModels(_detail5Entity, _detail5Mapper, _detail5ActiveFilter, currentDetail5);
        }

        /// <summary>
        /// Deletes a detail
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail record</returns>
        public virtual bool DeleteDetail(Expression<Func<TDetail, bool>> filter)
        {
            return DeleteDetailModels(_detailEntity, filter);
        }

        /// <summary>
        /// Deletes a detail 2
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail 2 record</returns>
        public virtual bool DeleteDetail2(Expression<Func<TDetail2, bool>> filter)
        {
            return DeleteDetailModels(_detail2Entity, filter);
        }

        /// <summary>
        /// Deletes a detail 3
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail 3 record</returns>
        public virtual bool DeleteDetail3(Expression<Func<TDetail3, bool>> filter)
        {
            return DeleteDetailModels(_detail3Entity, filter);
        }

        /// <summary>
        /// Deletes a detail 4
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail 4 record</returns>
        public virtual bool DeleteDetail4(Expression<Func<TDetail4, bool>> filter)
        {
            return DeleteDetailModels(_detail4Entity, filter);
        }

        /// <summary>
        /// Deletes a detail 5
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>Previous detail 5 record</returns>
        public virtual bool DeleteDetail5(Expression<Func<TDetail5, bool>> filter)
        {
            return DeleteDetailModels(_detail5Entity, filter);
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
                    _detailEntity.Read(false);
                    _detailMapper.Map(currentDetail, _detailEntity);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity });
        }

        /// <summary>
        /// Sets pointer to the current Detail 2
        /// </summary>
        /// <param name="currentDetail2">The current detail 2.</param>
        /// <returns>TDetail2.</returns>
        public virtual THeader SetDetail2(TDetail2 currentDetail2)
        {
            IsSessionAvailable();
            if (currentDetail2 != null)
            {
                _detail2Mapper.MapKey(currentDetail2, _detailEntity);
                if (_detail2Entity.Exists)
                {
                    _detail2Entity.Read(false);
                    _detail2Mapper.Map(currentDetail2, _detailEntity);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail2Entity });
        }

        /// <summary>
        /// Sets pointer to the current Detail 3
        /// </summary>
        /// <param name="currentDetail3">The current detail 3.</param>
        /// <returns>TDetail3.</returns>
        public virtual THeader SetDetail3(TDetail3 currentDetail3)
        {
            IsSessionAvailable();
            if (currentDetail3 != null)
            {
                _detail3Mapper.MapKey(currentDetail3, _detailEntity);
                if (_detail3Entity.Exists)
                {
                    _detail3Entity.Read(false);
                    _detail3Mapper.Map(currentDetail3, _detailEntity);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail3Entity });
        }

        /// <summary>
        /// Sets pointer to the current Detail 4
        /// </summary>
        /// <param name="currentDetail4">The current detail 4.</param>
        /// <returns>TDetail4.</returns>
        public virtual THeader SetDetail4(TDetail4 currentDetail4)
        {
            IsSessionAvailable();
            if (currentDetail4 != null)
            {
                _detail4Mapper.MapKey(currentDetail4, _detailEntity);
                if (_detail4Entity.Exists)
                {
                    _detail4Entity.Read(false);
                    _detail4Mapper.Map(currentDetail4, _detailEntity);
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail4Entity });
        }

        /// <summary>
        /// Sets pointer to the current Detail 5
        /// </summary>
        /// <param name="currentDetail5">The current detail 5.</param>
        /// <returns>TDetail5.</returns>
        public virtual THeader SetDetail5(TDetail5 currentDetail5)
        {
            IsSessionAvailable();
            if (currentDetail5 != null)
            {
                _detail5Mapper.MapKey(currentDetail5, _detailEntity);
                if (_detail5Entity.Exists)
                {
                    _detail5Entity.Read(false);
                    _detail5Mapper.Map(currentDetail5, _detailEntity);
                }
            }

            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detail5Entity });
        }

        /// <summary>
        /// To refresh the details grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual THeader RefreshDetail(THeader model)
        {
            return RefreshDetailModels(_detailEntity, model);
        }

        /// <summary>
        /// To refresh the details 2 grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual THeader RefreshDetail2(THeader model)
        {
            return RefreshDetailModels(_detail2Entity, model);
        }

        /// <summary>
        /// To refresh the details 3 grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual THeader RefreshDetail3(THeader model)
        {
            return RefreshDetailModels(_detail3Entity, model);
        }

        /// <summary>
        /// To refresh the details 4 grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual THeader RefreshDetail4(THeader model)
        {
            return RefreshDetailModels(_detail4Entity, model);
        }

        /// <summary>
        /// To refresh the details 5 grid
        /// </summary>
        /// <param name="model">Batch Model</param>
        /// <returns>Batch Model</returns>
        public virtual THeader RefreshDetail5(THeader model)
        {
            return RefreshDetailModels(_detail5Entity, model);
        }

        /// <summary>
        /// To clear the details
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual THeader ClearDetails(THeader model)
        {
            return ClearDetailModel(_detailEntity, model);
        }

        /// <summary>
        /// To clear the details 2
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual THeader ClearDetails2(THeader model)
        {
            return ClearDetailModel(_detail2Entity, model);
        }

        /// <summary>
        /// To clear the details 3
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual THeader ClearDetails3(THeader model)
        {
            return ClearDetailModel(_detail3Entity, model);
        }

        /// <summary>
        /// To clear the details 4
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual THeader ClearDetails4(THeader model)
        {
            return ClearDetailModel(_detail4Entity, model);
        }

        /// <summary>
        /// To clear the details 5
        /// </summary>
        /// <param name="model">Ordered Header Detail model</param>
        /// <returns>Ordered Header object</returns>
        public virtual THeader ClearDetails5(THeader model)
        {
            return ClearDetailModel(_detail5Entity, model);
        }

        /// <summary>
        /// Common method for Clear Details
        /// </summary>
        /// <param name="businessEntity"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private THeader ClearDetailModel(IBusinessEntity businessEntity, THeader model)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            _headerMapper.Map(model, _headerEntity);

            var details = GetDetailModel(model);
            businessEntity.Top();
            if (!details.Any())
                return _mapper.Map(new List<IBusinessEntity> { _headerEntity, businessEntity });
            do
            {
                if (businessEntity.Read(false))
                    businessEntity.Delete();
                businessEntity.ClearRecord();
            } while (businessEntity.Next());
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, businessEntity });
        }

        /// <summary>
        /// Process for detail 
        /// </summary>
        /// <param name="detail">Sequence Header Detail 2</param>
        /// <returns>Sequence Header Detail object</returns>
        public virtual TDetail ProcessDetail(TDetail detail)
        {
            IsSessionAvailable();
            var exists = _detailEntity.Exists;
            if (exists)
            {
                _detailMapper.MapKey(detail, _detailEntity);
                _detailEntity.Read(false);
            }
            ProcessMap(detail, _detailEntity);
            _detailEntity.SetValue(ProcessCommand, 0);
            _detailEntity.Process();
            return _detailMapper.Map(_detailEntity);
        }

        /// <summary>
        /// Process for detail 2
        /// </summary>
        /// <param name="detail2">Sequence Header Detail 2</param>
        /// <returns>Sequence Header Detail object</returns>
        public virtual TDetail2 ProcessDetail2(TDetail2 detail2)
        {
            IsSessionAvailable();
            var exists = _detail2Entity.Exists;
            if (exists)
            {
                _detail2Mapper.MapKey(detail2, _detailEntity);
                _detail2Entity.Read(false);
            }
            ProcessMap2(detail2, _detailEntity);
            _detail2Entity.SetValue(ProcessCommand, 0);
            _detail2Entity.Process();
            return _detail2Mapper.Map(_detail2Entity);
        }

        /// <summary>
        /// Process for detail 3
        /// </summary>
        /// <param name="detail3">Sequence Header Detail 3</param>
        /// <returns>Sequence Header Detail object</returns>
        public virtual TDetail3 ProcessDetail3(TDetail3 detail3)
        {
            IsSessionAvailable();
            var exists = _detail3Entity.Exists;
            if (exists)
            {
                _detail3Mapper.MapKey(detail3, _detailEntity);
                _detail3Entity.Read(false);
            }
            ProcessMap3(detail3, _detailEntity);
            _detail3Entity.SetValue(ProcessCommand, 0);
            _detail3Entity.Process();
            return _detail3Mapper.Map(_detail3Entity);
        }

        /// <summary>
        /// Process for detail 4
        /// </summary>
        /// <param name="detail4">Sequence Header Detail 4</param>
        /// <returns>Sequence Header Detail object</returns>
        public virtual TDetail4 ProcessDetail4(TDetail4 detail4)
        {
            IsSessionAvailable();
            var exists = _detail4Entity.Exists;
            if (exists)
            {
                _detail4Mapper.MapKey(detail4, _detailEntity);
                _detail4Entity.Read(false);
            }
            ProcessMap4(detail4, _detailEntity);
            _detail4Entity.SetValue(ProcessCommand, 0);
            _detail4Entity.Process();
            return _detail4Mapper.Map(_detail4Entity);
        }

        /// <summary>
        /// Process for detail 5
        /// </summary>
        /// <param name="detail5">Sequence Header Detail 5</param>
        /// <returns>Sequence Header Detail object</returns>
        public virtual TDetail5 ProcessDetail5(TDetail5 detail5)
        {
            IsSessionAvailable();
            var exists = _detail5Entity.Exists;
            if (exists)
            {
                _detail5Mapper.MapKey(detail5, _detailEntity);
                _detail5Entity.Read(false);
            }
            ProcessMap5(detail5, _detailEntity);
            _detail5Entity.SetValue(ProcessCommand, 0);
            _detail5Entity.Process();
            return _detail5Mapper.Map(_detail5Entity);
        }
        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public THeader Refresh(THeader header)
        {
            _mapper.Map(header, new List<IBusinessEntity> { _headerEntity });
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, _detailEntity, _detail2Entity, _detail3Entity, _detail4Entity, _detail5Entity }, 0, 0, SetFilter(_detailEntity, _detailActiveFilter));
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
            var detailData2 = request.DataMigrationList[2];
            var detailData3 = request.DataMigrationList[3];
            var detailData4 = request.DataMigrationList[4];
            var detailData5 = request.DataMigrationList[5];

            var dataSet = new DataSet();

            if (headerData.Print)
            {
                headerData.Items = PropertyBuilder<THeader>.UpdateColumnNamesAndId(headerData.Items);
                var headerTable = FlatExport(_headerEntity, headerData);
                headerTable.TableName = CommonUtilities.GetExportImportTableName<THeader>(request.Name);
                dataSet.Tables.Add(headerTable);
            }

            if (detailData.Print)
            {
                detailData.Items = PropertyBuilder<TDetail>.UpdateColumnNamesAndId(detailData.Items);
                var detailTable = HeaderDetailExport(_headerEntity, _detailEntity, headerData, detailData);
                detailTable.TableName = CommonUtilities.GetExportImportTableName<TDetail>(request.Name);
                dataSet.Tables.Add(detailTable);
            }

            if (detailData2.Print)
            {
                detailData2.Items = PropertyBuilder<TDetail2>.UpdateColumnNamesAndId(detailData2.Items);
                var detailTable2 = HeaderDetailExport(_headerEntity, _detail2Entity, headerData, detailData2);
                detailTable2.TableName = CommonUtilities.GetExportImportTableName<TDetail2>(request.Name);
                dataSet.Tables.Add(detailTable2);
            }

            if (detailData3.Print)
            {
                detailData3.Items = PropertyBuilder<TDetail3>.UpdateColumnNamesAndId(detailData3.Items);
                var detailTable3 = HeaderDetailExport(_headerEntity, _detail3Entity, headerData, detailData3);
                detailTable3.TableName = CommonUtilities.GetExportImportTableName<TDetail3>(request.Name);
                dataSet.Tables.Add(detailTable3);
            }

            if (detailData4.Print)
            {
                detailData4.Items = PropertyBuilder<TDetail4>.UpdateColumnNamesAndId(detailData4.Items);
                var detailTable4 = HeaderDetailExport(_headerEntity, _detail4Entity, headerData, detailData4);
                detailTable4.TableName = CommonUtilities.GetExportImportTableName<TDetail4>(request.Name);
                dataSet.Tables.Add(detailTable4);
            }

            if (detailData5.Print)
            {
                detailData5.Items = PropertyBuilder<TDetail5>.UpdateColumnNamesAndId(detailData5.Items);
                var detailTable5 = HeaderDetailExport(_headerEntity, _detail5Entity, headerData, detailData5);
                detailTable5.TableName = CommonUtilities.GetExportImportTableName<TDetail5>(request.Name);
                dataSet.Tables.Add(detailTable5);
            }
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
            var detailTable2 = CommonUtilities.GetExportImportTableName<TDetail2>(request.Name);
            var detailTable3 = CommonUtilities.GetExportImportTableName<TDetail3>(request.Name);
            var detailTable4 = CommonUtilities.GetExportImportTableName<TDetail4>(request.Name);
            var detailTable5 = CommonUtilities.GetExportImportTableName<TDetail5>(request.Name);
            var headerData = dataSet.Tables[headerTable];
            var detailData = dataSet.Tables[detailTable];
            var detailData2 = dataSet.Tables[detailTable2];
            var detailData3 = dataSet.Tables[detailTable3];
            var detailData4 = dataSet.Tables[detailTable4];
            var detailData5 = dataSet.Tables[detailTable5];
            var businessEntities = CreateBusinessEntities();
            _headerEntity = businessEntities.HeaderBusinessEntity;
            _detailEntity = businessEntities.DetailBusinessEntity;
            _detail2Entity = businessEntities.Detail2BusinessEntity;
            _detail3Entity = businessEntities.Detail3BusinessEntity;
            _detail4Entity = businessEntities.Detail4BusinessEntity;
            _detail5Entity = businessEntities.Detail5BusinessEntity;
            return OrderHeaderImport(headerData, _headerEntity, detailData, _detailEntity, request);
        }

        /// <summary>
        /// Gets the Distribution Proration 
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of POOEBaseInvDistProration</returns>
        public virtual EnumerableResponse<Proration> GetDistributionProrations(int pageNumber, int pageSize, Expression<Func<Proration, bool>> filter = null,
            OrderBy orderBy = null)
        {
            return GetDistributionProrationModels(_distributionProrationEntity, _distributionProrationMapper, null, pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="lineRevision">Line number to set</param>
        /// <param name="amount">Amount to set</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        public virtual void RefreshDistributionProration(int lineRevision, string amount)
        {
            _distributionProrationEntity.SetValue(POOEBaseInvDistProration.BaseFields.LineRevision, lineRevision);
            if (_distributionProrationEntity.Read(false))
            {
                _distributionProrationEntity.SetValue(POOEBaseAdditionalCost.BaseFields.Amount, amount, true);
                _distributionProrationEntity.Update();
            }
        }

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="getAmountRemaining">Return Amount Remaining or Manually prorated amount</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        public virtual decimal GetDistributionAmountRemaining(bool getAmountRemaining)
        {
            return getAmountRemaining ? _detail3Entity.GetValue<decimal>(POOEBaseAdditionalCost.BaseFields.Amount) - _detail3Entity.GetValue<decimal>(POOEBaseAdditionalCost.BaseFields.AmountDistributionSum) : _detail3Entity.GetValue<decimal>(POOEBaseAdditionalCost.BaseFields.AmountDistributionSum);
        }

        /// <summary>
        /// Gets Manually Prorated Amount
        /// </summary>
        /// <returns>Amount</returns>
        public decimal GetManuallyProratedAmount()
        {
            return _detail3Entity.GetValue<decimal>(POOEBaseAdditionalCost.BaseFields.NetOfTax);
        }

        /// <summary>
        /// Gets the currency rate composite.
        /// </summary>
        /// <param name="rateType">Type of the rate.</param>
        /// <param name="sourceCurrencyCode">The source currency code.</param>
        /// <param name="date">The date.</param>
        /// <param name="homeCurrency">The home currency.</param>
        /// <returns></returns>
        public virtual CompositeCurrencyRate GetCurrencyRateComposite(string rateType,
            string sourceCurrencyCode, DateTime date, string homeCurrency = null)
        {
            return Session.GetCurrencyRateComposite(homeCurrency ?? Session.HomeCurrency, rateType, sourceCurrencyCode, date);
        }

        #region Comments & Instruction

        /// <summary>
        /// Gets the Details 2
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details 2</returns>
        public virtual EnumerableResponse<TDetail2> GetCommentInstruction(int pageNumber, int pageSize, Expression<Func<TDetail2, bool>> filter = null,
            OrderBy orderBy = null)
        {
            IsSessionAvailable();
            var commentFilter = ExpressionHelper.Translate(filter);
            var loopCounter = 1;

            _detail2Entity.SetValue(Constant.DefaultValue2, CommentIdentifier);
            _detail2Entity.Browse(commentFilter, true);

            var resultsCount = SetFilter(_detail2Entity, filter);
            var startIndex = CommonUtil.ComputeStartIndex(pageNumber, pageSize);
            var endIndex = CommonUtil.ComputeEndIndex(pageNumber, pageSize, resultsCount);

            if (_detail2Entity.Fetch(false))
            {
                var lineNumber = 0;
                var commentList = new List<TDetail2>();
                do
                {
                    if (loopCounter >= startIndex)
                    {
                        var commentDetail = _detail2Mapper.Map(_detail2Entity);
                        commentDetail.DisplayIndex = lineNumber++;
                        commentList.Add(commentDetail);
                    }

                    loopCounter++;
                } while (loopCounter <= endIndex && _detail2Entity.Next());


                return new EnumerableResponse<TDetail2>
                {
                    Items = commentList,
                    TotalResultsCount = GetTotalRecords(_detail2Entity)
                };
            }
            return new EnumerableResponse<TDetail2> { Items = new List<TDetail2>(), TotalResultsCount = Constant.DefaultValue0 };
        }

        public virtual int GetCommentInstructionCount(Expression<Func<TDetail2, bool>> filter = null)
        {
            var commentFilter = ExpressionHelper.Translate(filter);
            _detail2Entity.SetValue(Constant.DefaultValue2, CommentIdentifier);
            _detail2Entity.Browse(commentFilter, true);
            return GetTotalRecords(_detail2Entity);
        }

        /// <summary>
        /// Create New Comment/Instruction Line
        /// </summary>
        /// <param name="currentDetail">Current Line</param>
        /// <returns>Comments/Instruction</returns>
        public virtual TDetail2 NewCommentInstruction(TDetail2 currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                _detail2Mapper.MapKey(currentDetail, _detail2Entity);
            }

            _detail2Entity.RecordCreate(ViewRecordCreate.NoInsert);
            return _detail2Mapper.Map(_detail2Entity);
        }

        /// <summary>
        /// Insert/Update Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction model</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        public virtual TDetail2 SaveCommentInstruction(TDetail2 model, string comment, string lineType)
        {
            IsSessionAvailable();
            var isDirty = _detail2Entity.Dirty;
            _detail2Mapper.MapKey(model, _detail2Entity);

            if (!isDirty && _detail2Entity.Exists)
            {
                _detail2Entity.Read(false);
            }

            if (model.IsNewLine)
            {
                InsertCommentInstruction(model, comment, lineType);
            }
            else
            {
                SyncCommentInstruction(model, comment);
            }

            var updatedComment = _detail2Mapper.Map(_detail2Entity);
            updatedComment.DisplayIndex = model.DisplayIndex;
            return updatedComment;
        }

        #endregion Comments & Instruction

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

        /// <summary>
        /// Gets the total records.
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>System.Int32.</returns>
        public int GetTotalRecords(IBusinessEntity businessEntity)
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

        #endregion

        #region Private methods

        /// <summary>
        /// Navigates to next or previous record based on the direction and filter
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="direction">Direction to fetch next or previous</param>
        /// <returns>Header entity record</returns>
        private THeader Navigate(Expression<Func<THeader, bool>> filter, Direction direction)
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
        private void SetupEntities(SequencedHeaderDetailFiveBusinessEntitySet<THeader, TDetail, TDetail2, TDetail3, TDetail4, TDetail5> businessEntitySet)
        {
            _headerActiveFilter = businessEntitySet.HeaderFilter;
            _headerEntity = businessEntitySet.HeaderBusinessEntity;
            _headerMapper = businessEntitySet.HeaderMapper;

            _detailActiveFilter = businessEntitySet.DetailFilter;
            _detail2ActiveFilter = businessEntitySet.Detail2Filter;
            _detail3ActiveFilter = businessEntitySet.Detail3Filter;
            _detail4ActiveFilter = businessEntitySet.Detail4Filter;
            _detail5ActiveFilter = businessEntitySet.Detail5Filter;
            _detailEntity = businessEntitySet.DetailBusinessEntity;
            _detail2Entity = businessEntitySet.Detail2BusinessEntity;
            _detail3Entity = businessEntitySet.Detail3BusinessEntity;
            _detail4Entity = businessEntitySet.Detail4BusinessEntity;
            _detail5Entity = businessEntitySet.Detail5BusinessEntity;
            _detailMapper = businessEntitySet.DetailMapper;
            _detail2Mapper = businessEntitySet.Detail2Mapper;
            _detail3Mapper = businessEntitySet.Detail3Mapper;
            _detail4Mapper = businessEntitySet.Detail4Mapper;
            _detail5Mapper = businessEntitySet.Detail5Mapper;

            _distributionProrationMapper = businessEntitySet.DistributionProrationMapper;
            _distributionProrationEntity = businessEntitySet.DistributionProrationBusinessEntity;

            _billToLocationMapper = businessEntitySet.BillToLocation;
        }

        /// <summary>
        /// Sync Detail Records
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public virtual bool SyncDetail(TDetail detail)
        {
            return SyncDetailModels(_detailEntity, _detailMapper, detail);
        }

        /// <summary>
        /// Synchronizes the detail models.
        /// </summary>
        /// <typeparam name="TU">The type of the u.</typeparam>
        /// <param name="businessEntity">The business entity.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="detail">The detail.</param>
        /// <returns></returns>
        public virtual bool SyncDetailModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, TU detail) where TU : ModelBase, new()
        {
            var isDetailUpdated = false;
            mapper.MapKey(detail, businessEntity);
            if (!businessEntity.Exists && !detail.IsDeleted)
            {
                businessEntity.Insert();
                detail.IsNewLine = false;
            }

            businessEntity.Read(false);

            if (detail.IsDeleted)
            {
                if (businessEntity.Exists)
                {
                    businessEntity.Delete();
                }
                else
                {
                    businessEntity.ClearRecord();
                }

                isDetailUpdated = true;
            }
            else if (businessEntity.Exists)
            {
                mapper.Map(detail, businessEntity);
                businessEntity.Update();
                isDetailUpdated = true;
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// Sync Detail 2 Records
        /// </summary>
        /// <param name="detail2"></param>
        /// <returns></returns>
        private bool SyncDetail2(TDetail2 detail2)
        {
            return SyncDetailModels(_detail2Entity, _detail2Mapper, detail2);
        }

        /// <summary>
        /// Sync Detail 3 Records
        /// </summary>
        /// <param name="detail3"></param>
        /// <returns></returns>
        private bool SyncDetail3(TDetail3 detail3)
        {
            return SyncDetailModels(_detail3Entity, _detail3Mapper, detail3);
        }

        /// <summary>
        /// Sync Detail 4 Records
        /// </summary>
        /// <param name="detail4"></param>
        /// <returns></returns>
        private bool SyncDetail4(TDetail4 detail4)
        {
            return SyncDetailModels(_detail4Entity, _detail4Mapper, detail4);
        }

        /// <summary>
        /// Sync Detail 5 Records
        /// </summary>
        /// <param name="detail5"></param>
        /// <returns></returns>
        private bool SyncDetail5(TDetail5 detail5)
        {
            return SyncDetailModels(_detail5Entity, _detail5Mapper, detail5);
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">The details.</param>
        private bool SyncDetails(IEnumerable<TDetail> details)
        {
            return SyncDetailsModels(_detailEntity, _detailMapper, details);
        }

        /// <summary>
        /// Synchronizes the detail 2.
        /// </summary>
        /// <param name="details2">The details.</param>
        private bool SyncDetails2(IEnumerable<TDetail2> details2)
        {
            return SyncDetailsModels(_detail2Entity, _detail2Mapper, details2);
        }

        /// <summary>
        /// Synchronizes the detail 3.
        /// </summary>
        /// <param name="details3">The details.</param>
        private bool SyncDetails3(IEnumerable<TDetail3> details3)
        {
            return SyncDetailsModels(_detail3Entity, _detail3Mapper, details3);
        }

        /// <summary>
        /// Synchronizes the detail 4.
        /// </summary>
        /// <param name="details4">The details.</param>
        private bool SyncDetails4(IEnumerable<TDetail4> details4)
        {
            return SyncDetailsModels(_detail4Entity, _detail4Mapper, details4);
        }

        /// <summary>
        /// Synchronizes the detail 5.
        /// </summary>
        /// <param name="details5">The details.</param>
        private bool SyncDetails5(IEnumerable<TDetail5> details5)
        {
            return SyncDetailsModels(_detail5Entity, _detail5Mapper, details5);
        }

        /// <summary>
        /// Insert Detail records
        /// </summary>
        /// <param name="newLine"></param>
        /// <returns></returns>
        private bool InsertDetail(TDetail newLine)
        {
            return InsertDetailModels(_detailEntity, _detailMapper, newLine);
        }

        /// <summary>
        ///  Insert Detail 2 records
        /// </summary>
        /// <param name="newLine2"></param>
        /// <returns></returns>
        private bool InsertDetail2(TDetail2 newLine2)
        {
            return InsertDetailModels(_detail2Entity, _detail2Mapper, newLine2);
        }

        /// <summary>
        ///  Insert Detail 3 records
        /// </summary>
        /// <param name="newLine3"></param>
        /// <returns></returns>
        private bool InsertDetail3(TDetail3 newLine3)
        {
            return InsertDetailModels(_detail3Entity, _detail3Mapper, newLine3);
        }

        /// <summary>
        ///  Insert Detail 4 records
        /// </summary>
        /// <param name="newLine4"></param>
        /// <returns></returns>
        private bool InsertDetail4(TDetail4 newLine4)
        {
            return InsertDetailModels(_detail4Entity, _detail4Mapper, newLine4);
        }

        /// <summary>
        ///  Insert Detail 5 records
        /// </summary>
        /// <param name="newLine5"></param>
        /// <returns></returns>
        private bool InsertDetail5(TDetail5 newLine5)
        {
            return InsertDetailModels(_detail5Entity, _detail5Mapper, newLine5);
        }

        /// <summary>
        /// Refresh Detail Models 
        /// </summary>
        /// <param name="businessEntity"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private THeader RefreshDetailModels(IBusinessEntity businessEntity, THeader model)
        {
            IsSessionAvailable();
            _headerMapper.Map(model, _headerEntity);

            var detailModel = GetDetailModel(model);
            foreach (var detail in detailModel)
            {
                _detailMapper.MapKey(detail, businessEntity);

                if (businessEntity.Exists)
                {
                    businessEntity.Read(false);
                }
                if (!businessEntity.Exists)
                    detail.IsNewLine = true;

                _detailMapper.Map(detail, businessEntity);

                if (businessEntity.Exists)
                {
                    businessEntity.Update();
                }
            }
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, businessEntity });
        }

        /// <summary>
        /// Insert Detail Models
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="businessEntity"></param>
        /// <param name="mapper"></param>
        /// <param name="newLine"></param>
        /// <returns></returns>
        public virtual bool InsertDetailModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, TU newLine) where TU : ModelBase, new()
        {
            mapper.Map(newLine, businessEntity);
            if (!businessEntity.Exists && newLine.IsDeleted)
            {
                businessEntity.ClearRecord();
            }
            mapper.Map(newLine, businessEntity);

            if (!businessEntity.Exists && !newLine.IsDeleted)
            {
                businessEntity.Insert();
                newLine.IsNewLine = false;
            }
            else if (businessEntity.Exists && !newLine.IsDeleted)
            {
                businessEntity.Read(false);
                businessEntity.Update();
            }
            else if (_detailEntity.Exists && newLine.IsDeleted)
            {
                businessEntity.Read(false);
                businessEntity.Delete();
            }
            return true;
        }

        /// <summary>
        /// New Detail Model
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="businessEntity"></param>
        /// <param name="mapper"></param>
        /// <param name="activeFilter"></param>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        private THeader NewDetailModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, Expression<Func<TU, bool>> activeFilter, TU currentDetail) where TU : ModelBase, new()
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                mapper.MapKey(currentDetail, businessEntity);
                if (currentDetail.HasChanged && !currentDetail.IsNewLine)
                {
                    if (businessEntity.Exists)
                    {
                        businessEntity.Read(false);
                        mapper.Map(currentDetail, businessEntity);
                        businessEntity.Update();
                    }
                    else
                    {
                        mapper.Map(currentDetail, businessEntity);
                        businessEntity.Insert();
                    }
                }
                else if (currentDetail.IsNewLine)
                {
                    mapper.Map(currentDetail, businessEntity);
                    businessEntity.Insert();
                }
            }

            businessEntity.RecordCreate(ViewRecordCreate.NoInsert);
            return _mapper.Map(new List<IBusinessEntity> { _headerEntity, businessEntity });
        }

        /// <summary>
        /// Get Detail Model
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="businessEntity"></param>
        /// <param name="mapper"></param>
        /// <param name="activeFilter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private EnumerableResponse<TU> GetDetailModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, Expression<Func<TU, bool>> activeFilter, int pageNumber, int pageSize, Expression<Func<TU, bool>> filter, OrderBy orderBy)
        where TU : ModelBase, new()
        {
            IsSessionAvailable();
            var resultsCount = SetFilter(businessEntity, filter, activeFilter, orderBy);
            if (businessEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = MapDataToModel(businessEntity, mapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetTotalRecords(businessEntity)
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Get Detail Model
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="headerEntity"></param>
        /// <param name="detailEntity"></param>
        /// <param name="mapper"></param>
        /// <param name="activeFilter"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private EnumerableResponse<TU> GetDetailModels<TU>(IBusinessEntity headerEntity, IBusinessEntity detailEntity, ModelMapper<TU> mapper, Expression<Func<TU, bool>> activeFilter, int pageNumber, int pageSize, Expression<Func<TU, bool>> filter, OrderBy orderBy)
        where TU : ModelBase, new()
        {
            IsSessionAvailable();
            var resultsCount = SetFilter(detailEntity, filter, activeFilter, orderBy);
            if (detailEntity.Fetch(false))
            {
                return new EnumerableResponse<TU>
                {
                    Items = MapDataToModel(detailEntity, mapper, pageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetDetailCount(headerEntity)
                };
            }
            return new EnumerableResponse<TU> { Items = new List<TU>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Get List of Distribution Prorations
        /// </summary>
        /// <typeparam name="TU">TU model</typeparam>
        /// <param name="businessEntity">Entiry of type IBusinessEntity</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Active Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>List of TU</returns>
        private EnumerableResponse<TU> GetDistributionProrationModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, Expression<Func<TU, bool>> activeFilter, int pageNumber, int pageSize, Expression<Func<TU, bool>> filter, OrderBy orderBy)
        where TU : ModelBase, new()
        {
            var pageOptions = new PageOptions<TU>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Filter = filter
            };

            SetBrowse(businessEntity, pageOptions.Filter);

            return !businessEntity.Top() ? new EnumerableResponse<TU>() : Get(businessEntity, mapper, pageOptions);
        }

        /// <summary>
        /// Sync Detail Models
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="businessEntity"></param>
        /// <param name="mapper"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        private bool SyncDetailsModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, IEnumerable<TU> details) where TU : ModelBase, new()
        {
            var isDetailUpdated = false;
            if (details == null) return false;

            var allDetails = details as IList<TU> ?? details.ToList();
            var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);

            if (newLine != null)
            {
                isDetailUpdated = InsertDetailModels(businessEntity, mapper, newLine);

            }
            foreach (
                var detail in
                    allDetails.Where(detail => detail.HasChanged || detail.IsDeleted).Where(detail => detail != newLine))
            {
                isDetailUpdated = SyncDetailModels(businessEntity, mapper, detail);
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// Delete Detail Models
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="businessEntity"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private bool DeleteDetailModels<TU>(IBusinessEntity businessEntity, Expression<Func<TU, bool>> filter) where TU : ModelBase, new()
        {
            IsSessionAvailable();
            CheckRights(_headerEntity, SecurityType.Delete);
            var isDetailDeleted = false;
            Search(businessEntity, filter);
            if (businessEntity.Exists)
            {
                businessEntity.Delete();
                isDetailDeleted = true;
            }
            return isDetailDeleted;
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
                    _detail2Entity.Cancel();
                    _detail3Entity.Cancel();
                    _detail4Entity.Cancel();
                    _detail5Entity.Cancel();
                    break;
                case ClearLevel.Detail:
                    _detailEntity.Cancel();
                    _detail2Entity.Cancel();
                    _detail3Entity.Cancel();
                    _detail4Entity.Cancel();
                    _detail5Entity.Cancel();
                    break;
            }
        }

        #region Comment & Instruction

        /// <summary>
        /// Insert Comment/Instruction Line
        /// </summary>
        /// <param name="model">Comment/Instruction</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        private void InsertCommentInstruction(TDetail2 model, string comment, string lineType)
        {
            if (!model.IsDeleted && !_detail2Entity.Exists)
            {
                _detail2Entity.SetValue(Constant.DefaultValue5, lineType);
                _detail2Entity.SetValue(Constant.DefaultValue6, comment);
                _detail2Entity.Insert();
            }
        }

        /// <summary>
        /// Update Comment/Instruction Line
        /// </summary>
        /// <param name="model">Comment/Instruction</param>
        /// <param name="comment">Comment/Instruction to set</param>
        private void SyncCommentInstruction(TDetail2 model, string comment)
        {
            if (model.IsDeleted && _detail2Entity.Exists)
            {
                _detail2Entity.Delete();
                _detail2Entity.ClearRecord();
            }
            else if (model.IsDeleted)
            {
                _detail2Entity.ClearRecord();
            }
            else if (_detail2Entity.Exists)
            {
                _detail2Entity.SetValue(Constant.DefaultValue6, comment);
                _detail2Entity.Update();
            }
        }
        #endregion Comment & Instruction

        #endregion

        #region Drop Ship Address

        /// <summary>
        /// GetDropShipAddressDetail
        /// </summary>
        /// <returns></returns>
        public DropShipAddress GetDropShipAddressDetail()
        {
            var dropShipmentAddressMapper = new DropShipAddressMapper<DropShipAddress>(Context);
            return dropShipmentAddressMapper.Map(_detailEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void UpdateDropShipAddressDetail(DropShipAddress model)
        {
            var dropShipmentAddressMapper = new DropShipAddressMapper<DropShipAddress>(Context);
            dropShipmentAddressMapper.Map(model, _detailEntity);
        }

        /// <summary>
        /// CheckValidDropShipData
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        public void CheckValidDropShipData(DropShipAddress model, DropShipmentType type)
        {
            _detailEntity.SetValue(DropShipAddress.Fields.DropShipmentType, type);

            switch (type)
            {
                case DropShipmentType.InventoryLocationAddress: _detailEntity.SetValue(DropShipAddress.Fields.DropShipLocation, model.DropShipLocation, true);
                    break;
                case DropShipmentType.CustomerAddress: _detailEntity.SetValue(DropShipAddress.Fields.DropShipCustomer, model.DropShipCustomer, true);
                    break;
                case DropShipmentType.CustomerShipToAddress:
                    _detailEntity.SetValue(DropShipAddress.Fields.DropShipCustomer, model.DropShipCustomer, true);
                    _detailEntity.SetValue(DropShipAddress.Fields.CustomerShipToAddress, model.CustomerShipToAddress, true);
                    break;
            }
        }

        #endregion

        #region Bill To Location

        /// <summary>
        /// Gets Bill To Location
        /// </summary>
        /// <returns>Bill To Location Model</returns>
        public BillToLocation GetBillToLocation()
        {
            return
                _billToLocationMapper.Map(_headerEntity);
        }

        /// <summary>
        /// Sets the Bill To Location Model Attributes.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        public BillToLocation SetBillToLocation(BillToLocation model)
        {
            using (var repository = Resolve<Common.Interfaces.Repository.ICommonBillToLocationEntity<BillToLocation>>())
            {
                return repository.SetValue(model, _headerEntity);
            }
        }

        #endregion

        #region Vendor Information

        /// <summary>
        /// Get Vendor Information
        /// </summary>
        /// <returns>VendorBase</returns>
        public VendorBase GetVendorInformation()
        {
            var vendorInfoMapper = new POVendorInformationMapper<VendorBase>(Context);
            return vendorInfoMapper.Map(_headerEntity);
        }

        /// <summary>
        /// Set Vendor Information
        /// </summary>
        /// <param name="model">VendorBase</param>
        public void SetVendorInformation(VendorBase model)
        {
            var vendorInfoMapper = new POVendorInformationMapper<VendorBase>(Context);
            vendorInfoMapper.Map(model, _headerEntity);
        }

        #endregion
    }
}
