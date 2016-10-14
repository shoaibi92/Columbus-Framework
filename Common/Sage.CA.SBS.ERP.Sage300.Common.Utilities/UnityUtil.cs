/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Microsoft.Practices.Unity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Utilities
{
    /// <summary>
    /// Class Unity Util.
    /// </summary>
    public static class UnityUtil
    {
        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">IUnityContainer</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>();
        }

        /// <summary>
        /// Register Type based on Constructor Name
        /// </summary>
        /// <typeparam name="TFrom">TFrom</typeparam>
        /// <typeparam name="TTo">TTo</typeparam>
        /// <param name="container">Container</param>
        /// <param name="name">ConstructorName</param>
        /// <param name="injectionMember">Injection Constructor Members</param>
        public static void RegisterType<TFrom, TTo>(IUnityContainer container, string name,
            params InjectionMember[] injectionMember) where TTo : TFrom
        {
            container.RegisterType<TFrom, TTo>(name, injectionMember);
        }

        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        /// <param name="from">Type to convert from</param>
        /// <param name="to">Type to convert to</param>
        public static void RegisterType(IUnityContainer container, Type from, Type to)
        {
            try
            {
                container.RegisterType(from, to);
            }
            catch
            {
                // Swallow error unitl AzureQueue is corrected                
            }
        }

        /// <summary>
        /// Register type if not already registered
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        /// <param name="from">Type to convert from</param>
        /// <param name="to">Type to convert to</param>
        /// <param name="name">The name.</param>
        /// <param name="injectionMember">The injection member.</param>
        public static void RegisterType(IUnityContainer container, Type from, Type to, string name,
            params InjectionMember[] injectionMember)
        {
            container.RegisterType(from, to, name, injectionMember);
        }
    }
}