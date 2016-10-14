/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web
{
    /// <summary>
    /// IUnityRegistration - Required for unity registration
    /// </summary>
    public interface IUnityRegistration
    {
        /// <summary>
        /// Register types
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        void RegisterTypes(IUnityContainer container);
    }
}