/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the functions exposed by the Processing Business Views
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProcessingRepository<T> : ISecurity, IRepository, IDisposable where T : ModelBase
    {
        /// <summary>
        /// Get Model 
        /// </summary>
        /// <returns>TModel</returns>
        T Get();

        /// <summary>
        /// Process an entity
        /// </summary>
        /// <returns></returns>
        T Process(T model);

        /// <summary>
        /// Get the pogress update
        /// </summary>
        /// <returns>ProgressMeter</returns>
        ProgressMeter GetProgressMeter();

        /// <summary>
        /// Cancels the process
        /// </summary>
        void Cancel();

        /// <summary>
        ///  Unlocks the Application for specific module. 
        /// </summary>
        void UnlockApplication(string applicationId);

        /// <summary>
        /// Destroy Sessions which are not in use.
        /// </summary>
        void DestroyUnusedSessions();

        /// <summary>
        /// Unlock the current session object.
        /// </summary>
        void UnlockOrganisation();
    }
}