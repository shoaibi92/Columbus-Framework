using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// Class BaseTestFixture.
    /// </summary>
    public class BaseTestFixture
    {
        /// <summary>
        /// The is snapshot enabled
        /// </summary>
        private static readonly string IsSnapshotEnabled;

        /// <summary>
        /// Baserepositorytestfixture class constructor
        /// </summary>
        static BaseTestFixture()
        {
            IsSnapshotEnabled = ConfigurationManager.AppSettings["IsSnapshotEnabled"];
        }

        /// <summary>
        /// Call base to allow proper init
        /// </summary>
        /// <param name="context">The context.</param>
        public static void TestInitialize(TestContext context)
        {
            if (!String.IsNullOrEmpty(IsSnapshotEnabled) && IsSnapshotEnabled == "true")
                DatabaseTestFixtureRollbackHelper.TestSetup();
        }

        /// <summary>
        /// Call base to allow proper cleanup
        /// </summary>
        public static void TestCleanup()
        {
            if (!String.IsNullOrEmpty(IsSnapshotEnabled) && IsSnapshotEnabled == "true")
                DatabaseTestFixtureRollbackHelper.TestCleanup();
        }

        /// <summary>
        /// Call base to allow proper restore
        /// </summary>
        public static void TestRestore()
        {
            if (!String.IsNullOrEmpty(IsSnapshotEnabled) && IsSnapshotEnabled == "true")
                DatabaseTestFixtureRollbackHelper.TestRestore();
        }

        /// <summary>
        /// Register Common Types
        /// </summary>
        public void RegisterCommonTypes(Context context)
        {
            //Register Audit Types
            context.Container.RegisterType<IDatabaseAuditRepository<IDatabaseAudit>, DatabaseAuditRepository<IDatabaseAudit>>();
            context.Container.RegisterType<IDatabaseAudit, DatabaseAudit>();
        }

    }
}