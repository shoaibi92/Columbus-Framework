/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using TPA.TU.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;

namespace TPA.TU.Interfaces.BusinessRepository
{
     /// <summary>
    /// Interface for Account Group Entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAccountGroupEntity<T> : IBusinessRepository<T>, ISecurity where T : AccountGroup, new()
    {

        /// <summary>
        /// update Account Set status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T UpdateStatus(T model);
    }
}
