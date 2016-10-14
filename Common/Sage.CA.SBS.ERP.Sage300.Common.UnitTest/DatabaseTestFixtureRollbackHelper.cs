/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// Class DatabaseTestFixtureRollbackHelper.
    /// </summary>
    public static class DatabaseTestFixtureRollbackHelper
    {
        #region Private Members

        /// <summary>
        /// The _test run path
        /// </summary>
        private static string _testRunPath;

        /// <summary>
        /// The _test run identifier
        /// </summary>
        private static string _testRunId;

        /// <summary>
        /// The with data
        /// </summary>
        private const string WithData = "withData";

        /// <summary>
        /// The company database
        /// </summary>
        private const string CompanyDatabase = "SAMLTD";

        /// <summary>
        /// The system data base
        /// </summary>
        private const string SystemDataBase = "SAMSYS";

        #endregion

        #region Public Methods

        /// <summary>
        /// Take backup of the cloud databases
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="testRunId">The test run identifier.</param>
        public static void ClassSetup(string path, string testRunId)
        {
            _testRunPath = path;
            _testRunId = testRunId;
            DatabaseOperationHelper.CreateBackupOfDatabaseIfNeeded(CompanyDatabase, _testRunId, _testRunPath);
            DatabaseOperationHelper.CreateBackupOfDatabaseIfNeeded(SystemDataBase, _testRunId, _testRunPath);
        }

        /// <summary>
        /// Restore and delete snapshot of the cloud databases
        /// </summary>
        public static void ClassCleanup()
        {
            if (string.IsNullOrEmpty(_testRunId))
            {
                DatabaseOperationHelper.RestoreBackupOfDatabase(CompanyDatabase);
                DatabaseOperationHelper.RestoreBackupOfDatabase(SystemDataBase);
            }
            else
            {
                DatabaseOperationHelper.RestoreBackupOfDatabase(CompanyDatabase, _testRunId, _testRunPath);
                DatabaseOperationHelper.RestoreBackupOfDatabase(SystemDataBase, _testRunId, _testRunPath);
            }
        }

        /// <summary>
        /// Take snapshot of the cloud databases
        /// </summary>
        public static void TestSetup()
        {
            // Snapshot is supported only in SQL Enterprise Edition. Check if the installed SQL edtion supports or not
            // If supports, take snapshot of database
            // If does not support, take backup of database
            var isDbSupportsSnapshot = DatabaseOperationHelper.SupportsSnapshot(CompanyDatabase);
            if (isDbSupportsSnapshot)
            {
                DatabaseOperationHelper.TakeSnapshotOfDatabaseIfNeeded(CompanyDatabase, WithData);
                DatabaseOperationHelper.TakeSnapshotOfDatabaseIfNeeded(SystemDataBase, WithData);
            }
            else
            {
                DatabaseOperationHelper.CreateBackupOfDatabase(CompanyDatabase);
                DatabaseOperationHelper.CreateBackupOfDatabase(SystemDataBase);
            }
        }

        /// <summary>
        /// Tests the restore.
        /// </summary>
        public static void TestRestore()
        {
            // Snapshot is supported only in SQL Enterprise Edition. Check if the installed SQL edtion supports or not
            // If supports, take snapshot of database
            // If does not support, take backup of database
            var isDbSupportsSnapshot = DatabaseOperationHelper.SupportsSnapshot(CompanyDatabase);
            if (isDbSupportsSnapshot)
            {
                DatabaseOperationHelper.RestoreSnapshotOfDatabase(CompanyDatabase, WithData);
                DatabaseOperationHelper.RestoreSnapshotOfDatabase(SystemDataBase, WithData);
            }
            else
            {
                DatabaseOperationHelper.RestoreBackupOfDatabase(CompanyDatabase);
                DatabaseOperationHelper.RestoreBackupOfDatabase(SystemDataBase);
            }
        }

        /// <summary>
        /// Restore the content of the cloud databases from snapshot
        /// </summary>
        /// <remarks>As a best practice each test should be independent and work from clean data.
        /// However if desired and the tests are data independent this can removed for a speed up.</remarks>
        public static void TestCleanup()
        {
            // Snapshot is supported only in SQL Enterprise Edition. Check if the installed SQL edtion supports or not
            // If supports, take snapshot of database
            // If does not support, take backup of database
            var isDbSupportsSnapshot = DatabaseOperationHelper.SupportsSnapshot(CompanyDatabase);
            if (isDbSupportsSnapshot)
            {
                DatabaseOperationHelper.RestoreAndDropSnapshotOfDatabase(CompanyDatabase, WithData);
                DatabaseOperationHelper.RestoreAndDropSnapshotOfDatabase(SystemDataBase, WithData);
            }
            else
            {
                DatabaseOperationHelper.RestoreBackupOfDatabase(CompanyDatabase);
                DatabaseOperationHelper.RestoreBackupOfDatabase(SystemDataBase);
            }
        }

        /// <summary>
        /// Snaphots the exists.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SnaphotExists()
        {
            //only check master we could check tenant but looking for a fast exist check here.
            return DatabaseOperationHelper.SnapshotExists(CompanyDatabase, WithData);
        }

        #endregion
    }
}