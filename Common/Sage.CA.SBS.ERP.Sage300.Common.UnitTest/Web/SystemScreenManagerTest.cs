using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Microsoft.QualityTools.Testing.Fakes;
using System.Web.Fakes;
using System.ComponentModel.Composition.Hosting.Fakes;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.CS.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Models;
using Sage.CA.SBS.ERP.Sage300.AS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.AS.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class SystemScreenManagerTest
    {
        /// <summary>
        /// Util function to return Context
        /// </summary>
        /// <returns>Context</returns>
        private Context CreateContext()
        {
            var context = new Context
            {
                Container = new SageUnityContainer()
            };

            UnityUtil.RegisterType<ICompanyProfileService<CompanyProfile>, CompanyProfileEntityService<CompanyProfile>>(context.Container);
            UnityUtil.RegisterType<IDataIntegrityService<DataIntegrity>, DataIntegrityEntityService<DataIntegrity>>(context.Container);
            UnityUtil.RegisterType<ICommonService, CommonService>(context.Container);

            return context;
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void InitializeTest()
        {
            Context context = CreateContext();
            context.Company = "Test";
            using (ShimsContext.Create())
            {
                //List<Lazy<IModuleManager, IBootstrapMetadata>> lazyList = new List<Lazy<IModuleManager, IBootstrapMetadata>>();
                //ISystemScreenManager systemScreenManager = new SystemScreenManager();


                ShimHttpRuntime.BinDirectoryGet = () => @"c:\";
                //ShimExportProvider.AllInstances.GetExportsOf2<IModuleManager, IBootstrapMetadata>(x => lazyList);




                
                //systemScreenManager.Initialize(context);
            }
        }
    }
}
