/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Class FlatService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public abstract class InquiryService<T, TEntity> : BaseService, IInquiryService<T>, ISecurityService
        where T : ModelBase, new()
        where TEntity : IInquiryRepository<T>, ISecurity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context.</param>
        protected InquiryService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get();
            }
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<T> Get(PageOptions<T> pageOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(pageOptions);
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

        /// <summary>
        /// Gets the details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        public EnumerableResponse<T> Get(T model, PageOptions<T> pageOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get(model, pageOptions);
            }
        }


        public bool IsModuleActive(string module)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.IsModuleActive(module);
            }
        }
    }
}