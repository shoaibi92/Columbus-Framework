// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespaces
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using System.ComponentModel.Composition;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Administrative Web Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport(BootstrapModule.Framework, new[] { BootstrapAppliesTo.Web, BootstrapAppliesTo.Worker, BootstrapAppliesTo.WebApi }, 1)]
    public class CommonWebBootstrapper : IBootstrapperTask
    {
        /// <summary>
        /// Bootstrap activity execution
        /// </summary>
        /// <param name="container">The Unity container</param>
        public void Execute(IUnityContainer container)
        {
            if (ConfigurationHelper.IsOnPremise)
            {
                RegisterOnPremiseTypes(container);
            }
            else
            {
                RegisterAzureTypes(container);
            }
        }

        /// <summary>
        ///  Register types for on-premise deployment
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterOnPremiseTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IAuthenticationSession), typeof(AuthenticationSession));
            UnityUtil.RegisterType<IUserTenantResolver, UserTenantResolverOnPremise>(container);
        }

        /// <summary>
        ///  Register types for cloud deployment
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterAzureTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType<IUserTenantResolver, UserTenantResolver>(container);
        }
    }
}
