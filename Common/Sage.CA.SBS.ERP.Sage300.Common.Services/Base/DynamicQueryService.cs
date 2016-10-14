/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Class DynamicService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public abstract class DynamicQueryService<T, TEntity> : BaseService, IDynamicQueryEntityService<T>, ISecurityService
        where T : ApplicationModelBase, new()
        where TEntity : IDynamicQueryRepository<T>, ISecurity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context.</param>
        protected DynamicQueryService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Execute T-SQL Query
        /// </summary>
        /// <param name="id">ID in resource for T-SQL Query</param>
        /// <param name="args">Arguments for T-SQL Query, if any</param>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        public virtual DynamicQueryEnumerableResponse<T> Execute(string id, params object[] args)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Execute(id, args);
            }
        }

        /// <summary>
        /// Get access rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetAccessRights();
            }
        }

    }
}