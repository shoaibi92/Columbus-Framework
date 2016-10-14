/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Linq;
using ACCPAC.Advantage;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// This class of views is mainly used to implement procedures that do not involve editing data. 
    /// Examples are consolidation, year-end procedures, and posting a batch
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ProcessingRepository<T> : BaseRepository, IProcessingRepository<T> where T : ModelBase, new()
    {
        #region Private Variables

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly ModelMapper<T> _mapper;

        /// <summary>
        /// Business Entity
        /// </summary>
        private IBusinessEntity _processEntity;

        #endregion

        #region Protected Region

        /// <summary>
        /// Compose business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract IBusinessEntity CreateBusinessEntities();

        #endregion

        #region Constructor

        /// <summary>
        /// ProcessingRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        protected ProcessingRepository(Context context,ModelMapper<T> mapper) : base(context)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// ProcessingRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected ProcessingRepository(Context context, ModelMapper<T> mapper, ObjectPoolType sessionPoolType)
            : base(context, sessionPoolType)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// ProcessingRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType"></param>
        protected ProcessingRepository(Context context, DBLinkType dbLinkType) : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// ProcessingRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session</param>
        protected ProcessingRepository(Context context, ModelMapper<T> mapper, IBusinessEntitySession session)
            : base(context, session)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Processing Repository Constructor for ObjectPool Type, BusinessEntitySessionParams module specific Application identifier and program name
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected ProcessingRepository(Context context, ModelMapper<T> mapper, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, sessionPoolType, businessEntitySessionParams)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Processing Repository Constructor for ObjectPool Type, BusinessEntitySessionParams module specific Application identifier and program name
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        protected ProcessingRepository(Context context, DBLinkType dbLinkType, ObjectPoolType sessionPoolType,
            BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, null, sessionPoolType, businessEntitySessionParams)
        {
        }

        #endregion

        #region IProcessingRepository

        /// <summary>
        /// Get Model
        /// </summary>
        /// <returns>T</returns>
        public virtual T Get()
        {
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            return new T();
        }

        /// <summary>
        /// Perform processing on the View
        /// </summary>
        public virtual T Process(T model)
        {
            _processEntity = CreateBusinessEntitiesInternal();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            _mapper.Map(model, _processEntity);
            _processEntity.Process();
            model = _mapper.Map(_processEntity);
            
            var results = GetExceptions();
            if (results.Count > 0)
            {
                var warnings = model.Warnings.ToList();
                warnings.AddRange(results);
                model.Warnings = warnings;
            }
            return model;
        }

        /// <summary>
        /// Get progress meter
        /// </summary>
        /// <returns>ProgressMeter object</returns>
        public virtual ProgressMeter GetProgressMeter()
        {
            IBusinessEntitySession session;

            //This method should not create a new session object
            if (BusinessPoolManager.TryGetSession(Context, DBLinkType.Company, BusinessEntitySessionParams, out session))
            {
                return session.GetMeter();
            }
            return null;
        }

        /// <summary>
        /// Cancel progress
        /// </summary>
        public virtual void Cancel()
        {
            IBusinessEntitySession session;
            //This method should not create a new session object
            if (BusinessPoolManager.TryGetSession(Context, DBLinkType.Company, BusinessEntitySessionParams, out session))
            {
                session.CancelMeter();
            }
        }

        #endregion

        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            return GetAccessRights(CreateBusinessEntitiesInternal());
        }

        #region Private methods

        /// <summary>
        /// CreateBusinessEntitiesInternal
        /// </summary>
        /// <returns>IBusinessEntity</returns>
        private IBusinessEntity CreateBusinessEntitiesInternal()
        {
            return _processEntity ?? (_processEntity = CreateBusinessEntities());
        }

        #endregion

    }
}