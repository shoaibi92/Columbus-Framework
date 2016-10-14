/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Microsoft.Practices.Unity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Class for Unity Dependency Resolver methods
    /// </summary>
    public class UnityDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Intailizing IUnity Container
        /// </summary>
        /// <param name="container">IUnity Container</param>
        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        /// <summary>
        /// Gets Service based on Service Type
        /// </summary>
        /// <param name="serviceType">Service Type</param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            Object result = null;

            if (_container.IsRegistered(serviceType))
            {
                result = _container.Resolve(serviceType);
            }

            return result;
        }

        /// <summary>
        ///  Gets Service based on Service Type
        /// </summary>
        /// <param name="serviceType">Service Type</param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<Object> result;

            if (_container.IsRegistered(serviceType))
            {
                result = _container.ResolveAll(serviceType);
            }
            else
            {
                result = new List<Object>();
            }

            return result;
        }

        /// <summary>
        /// UnityContainer 
        /// </summary>
        private readonly IUnityContainer _container;
    }
}