// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System.Collections;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq.Expressions;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Mock User Repository
    /// </summary>
    /// <typeparam name="T">User</typeparam>
    public class MockUserRepository<T> : FlatRepository<T>, IUserEntity<T> where T : User, new()
    {
        #region Constructor
        /// <summary>
        /// User Repository Constructor to set Context
        /// </summary>
        /// <param name="context">Context object</param>
        public MockUserRepository(Context context)
            : base(context, null, null)
        {
        }

        /// <summary>
        /// User Repository Constructor to set Context and Session
        /// </summary>
        /// <param name="context">Context object</param>
        /// <param name="session">Session object</param>
        public MockUserRepository(Context context, IBusinessEntitySession session)
            : base(context, null, null, session)
        {
        }

        #endregion

        #region Abstract Methods
        /// <summary>
        /// Create entities for repository
        /// </summary>
        /// <returns>returns Business Entity object</returns>
        protected override IBusinessEntity CreateBusinessEntities()
        {
            return null;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Get Update Expression
        /// </summary>
        /// <param name="model">User Model</param>
        /// <returns>Expression with User Id filter</returns>
        protected override Expression<Func<T, bool>> GetUpdateExpression(T model)
        {
            return null;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Impl
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAvailableLanguages()
        {
            return null;
        }

        /// <summary>
        /// Get login user
        /// </summary>
        /// <typeparam name="TKey">Data type</typeparam>
        /// <param name="key">The login user</param>
        /// <returns>User</returns>
        public T GetUserLogin<TKey>(TKey key)
        {
            return new T {Email1 = "test.user@test.com", UserName = "User Name"};
        }

        #endregion


    }
}