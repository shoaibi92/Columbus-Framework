/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region


using Sage.CA.SBS.ERP.Sage300.Common.Models;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// The API definition of the functions exposed by the Business Views
    /// </summary>
    /// <typeparam name="T">T of type ModelBase</typeparam>
    public interface IInquiryService<T> where T : ModelBase
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        EnumerableResponse<T> Get(PageOptions<T> pageOptions);

        /// <summary>
        /// Gets the details.
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