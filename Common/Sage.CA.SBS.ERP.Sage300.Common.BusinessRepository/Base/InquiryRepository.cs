// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Inquiry Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class InquiryRepository<T> : BaseRepository, IInquiryRepository<T>
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
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract IBusinessEntity CreateBusinessEntities();

        #endregion

        #region Constructor


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        protected InquiryRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter)
            : this(context, DBLinkType.Company, mapper, activeFilter)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor with disable pooling. NOT to be generally used.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected InquiryRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter, ObjectPoolType sessionPoolType)
            : this(context, DBLinkType.Company, mapper, activeFilter, null, sessionPoolType)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected InquiryRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, mapper, activeFilter, null, ObjectPoolType.Default, businessEntitySessionParams)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Active Filter</param>
        protected InquiryRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
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
        protected InquiryRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="InquiryRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected InquiryRepository(Context context, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, ObjectPoolType.Default, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        protected InquiryRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter,
            IBusinessEntitySession session)
            : this(context, DBLinkType.Company, mapper, activeFilter, session)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        /// <param name="objectPoolType">Object Pool Type</param>
        protected InquiryRepository(Context context, ModelMapper<T> mapper, Expression<Func<T, bool>> activeFilter,
            IBusinessEntitySession session, ObjectPoolType objectPoolType)
            : this(context, DBLinkType.Company, mapper, activeFilter, session, objectPoolType)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="activeFilter">Filter</param>
        /// <param name="session">Session</param>
        protected InquiryRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session)
            : this(context, dbLinkType, mapper, activeFilter, session, ObjectPoolType.Default)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
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
        protected InquiryRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session, ObjectPoolType sessionPoolType)
            : this(context, dbLinkType, mapper, activeFilter, session, sessionPoolType, null)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
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
        protected InquiryRepository(Context context, DBLinkType dbLinkType, ModelMapper<T> mapper,
            Expression<Func<T, bool>> activeFilter, IBusinessEntitySession session, ObjectPoolType sessionPoolType,
            BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, session, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
            _activeFilter = activeFilter;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Additional Access Check for Export and Import
        /// </summary>
        /// <returns>User Access</returns>
        public UserAccess GetAccessRights()
        {
            _businessEntity = CreateBusinessEntities();
            return GetAccessRights(_businessEntity);
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public virtual T Get()
        {
            return new T();
        }

        /// <summary>
        /// Gets the specified page options.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public virtual EnumerableResponse<T> Get(PageOptions<T> pageOptions)
        {
            _businessEntity = CreateBusinessEntities();
            CheckRights(_businessEntity, SecurityType.Inquire);

            // Check if page options is null.
            if (pageOptions == null)
            {
                return null;
            }

            // set browse with the filter.
            SetBrowse(_businessEntity, pageOptions.Filter, _activeFilter);

            // Get will return the result of given _businessEntity and mapper.
            return !_businessEntity.Fetch(false) ? new EnumerableResponse<T>() : Get(_businessEntity, _mapper, pageOptions);
        }

        /// <summary>
        /// Gets the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual EnumerableResponse<T> Get(T model, PageOptions<T> pageOptions)
        {
            // Custom implementation can be done.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check If Module Is Active
        /// </summary>
        /// <param name="module">Module id</param>
        /// <returns>True if module is Active</returns>
        public virtual bool IsModuleActive(string module)
        {
            return IsApplicationActive(module);
        }

        #endregion
    }
}