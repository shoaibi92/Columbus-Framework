/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the functions exposed by the Processing Business Views
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInquiryRepository<T> : ISecurity, IRepository, IDisposable where T : ModelBase
    {
        /// <summary>
        ///  Initialize Entities
        /// </summary>
        /// <returns>T model</returns>
        T Get();

        /// <summary>
        /// Gets the specified current page number.
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(PageOptions<T> pageOptions);

        /// <summary>
        /// Gets the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(T model, PageOptions<T> pageOptions);

        /// <summary>
        /// Check If Module Is Active
        /// </summary>
        /// <param name="module">Module id</param>
        /// <returns>True if module is Active</returns>
        bool IsModuleActive(string module);
    }
}