/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Microsoft.Practices.Unity;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Controller
{
    /// <summary>
    /// Base Test Fixture for Controllers
    /// </summary>
    [TestClass]
    public abstract class BaseControllerTestFixture
    {
        /// <summary>
        /// Base Context that will be used
        /// </summary>
        protected Context Context;

        /// <summary>
        /// Register has to overloaded by every inherited class 
        /// </summary>
        public abstract void Register();

        /// <summary>
        /// Creates a context and assigns to Context
        /// </summary>
        protected void CreateContext()
        {
            Context = new Context
            {
                SessionId = "dmpg2qrxq2zvuequ22jtmyh2",
                ContextToken = Guid.NewGuid(),
                Container = new SageUnityContainer(),
                ScreenContext = new ScreenContext()
            };
            ConfigurationHelper.Initialize(Context.Container, string.Empty);

        }

        /// <summary>
        /// Register Common Types
        /// </summary>
        protected void RegisterCommonTypes()
        {
            Context.Container.RegisterType(typeof (ISessionCacheProvider), typeof (PsuedoSessionProvider));
        }
    }
}