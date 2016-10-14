/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using System.Linq.Expressions;
using TPA.TU.BusinessRepository.Mappers;
using TPA.TU.Interfaces.BusinessRepository;
using TPA.TU.Models;

namespace TPA.TU.BusinessRepository
{
    /// <summary>
    /// Account Set Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AccountGroupRepository<T> : FlatRepository<T>, IAccountGroupEntity<T> where T : AccountGroup, new()
    {
        #region Business Entity Variables

        /// <summary>
        /// TU Account Group 0001 - Header entity
        /// </summary>
        private IBusinessEntity _businessEntity;
        /// <summary>
        /// Mapper
        /// </summary>
        private ModelMapper<T> _mapper;

        #endregion

        #region Private Variables

        /// <summary>
        /// ActiveFilter Condition
        /// </summary>
        private static Expression<Func<T, Boolean>> ActiveFilter
        {
            get { return null; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Account Set Repository Constructor
        /// </summary>
        /// <param name="context">context</param>
        public AccountGroupRepository(Context context)
            : base(context, new AccountGroupMapper<T>(context), ActiveFilter)
        {
            SetFilter(context);
        }

        /// <summary>
        /// Account set constructor
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="session">session</param>
        public AccountGroupRepository(Context context, IBusinessEntitySession session)
            : base(context, new AccountGroupMapper<T>(context), ActiveFilter, session)
        {
            SetFilter(context);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create business entities 
        ///  </summary>
        private void CreateBusinessEntitiesInternal()
        {
            _businessEntity = OpenEntity(AccountGroup.EntityName);
        }


        /// <summary>
        /// Set Filter
        /// </summary>
        /// <param name="context"></param>
        private void SetFilter(Context context)
        {
            ValidRecordFilter = accountGroup => !string.IsNullOrEmpty(accountGroup.AccountGroupCode);
            _mapper = new AccountGroupMapper<T>(context);
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Create entities for repository
        /// </summary>
        /// <returns></returns>
        protected override IBusinessEntity CreateBusinessEntities()
        {
            CreateBusinessEntitiesInternal();
            return _businessEntity;
        }

        /// <summary>
        /// Get Update Expression
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Expression</returns>
        protected override Expression<Func<T, bool>> GetUpdateExpression(T model)
        {
            return entity => entity.AccountGroupCode.StartsWith(model.AccountGroupCode);
        }

        /// <summary>
        /// Update the status of the account set
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual T UpdateStatus(T model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);
            var filter = GetUpdateExpression(model);

            if (Search(_businessEntity, filter))
            {
                _mapper.Map(model, _businessEntity);
                _businessEntity.SetValue(AccountGroup.Index.Status, model.Status, true);
            }
            return _mapper.Map(_businessEntity);
        }


        #endregion

        /// <summary>
        /// Additional Access Check for Export and Import
        /// </summary>
        /// <returns>User Access</returns>
        public override UserAccess GetAccessRights()
        {
            var userAccess = base.GetAccessRights();
            if (SecurityCheck(Security.TUImport))
            {
                userAccess.SecurityType |= SecurityType.Import;
            }
            if (SecurityCheck(Security.TUExport))
            {
                userAccess.SecurityType |= SecurityType.Export;
            }
            return userAccess;
        }
    }
}
