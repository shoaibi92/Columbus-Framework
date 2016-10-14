/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// Class DatabaseOperationHelper.
    /// Still we have unused methods which has to be removed once snapshot and back up restore is working on TC
    /// </summary>
    public static class DatabaseOperationHelper
    {
        #region Public Methods

        /// <summary>
        /// Takes a snapshot the the database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="token">The token.</param>
        /// <remarks>Expected to be used at the class init level to prepare a set of tests
        /// to roll back. Can be used at the test init level but this would have a touch more overhead then needed.</remarks>
        public static void TakeSnapshotOfDatabaseIfNeeded(string database, string token = null)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);

                MakeDatabaseMultiUser(connection, databaseName);
                CreateSnapShot(connection, token);
            }
        }

        /// <summary>
        /// Snapshots the exists.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool SnapshotExists(string database, string token = null)
        {
            bool retval;
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);
                retval = SnapshotExists(connection, databaseName, token);
            }
            return retval;
        }

        /// <summary>
        /// Restores the contents of the database from the prior snapshot.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="token">The token.</param>
        /// <remarks>Must only be used when the snapshot has been taken.
        /// Expected to be used to roll back after each test if desired.</remarks>
        public static void RestoreSnapshotOfDatabase(string database, string token = null)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);

                RestoreSnapShot(connection, databaseName, token);
            }
        }

        /// <summary>
        /// Restores the contents of the database from the prior snapshot and then drops the snapshot.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="token">The token.</param>
        /// <remarks>Expected to be used at the class cleanup level. Can be used after each test but this
        /// has a bit more overhead then is strictly needed.</remarks>
        public static void RestoreAndDropSnapshotOfDatabase(string database, string token)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);
                RestoreSnapShot(connection, databaseName, token);
                DropSnapShot(connection, token);
            }
        }

        /// <summary>
        /// Restores the backup of database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        public static void RestoreBackupOfDatabase(string database, string id = null, string path = null)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);

                SqlConnection.ClearAllPools();
                CloseDatabaseConnections(connection, databaseName);
                RestoreBackup(connection, databaseName, id, path);
            }
        }

        /// <summary>
        /// Creates the backup of database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="id">The identifier.</param>
        public static void CreateBackupOfDatabase(string database, string id = null)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);

                SqlConnection.ClearAllPools();
                CloseDatabaseConnections(connection, databaseName);
                CreateBackup(connection, databaseName, id);
            }
        }

        /// <summary>
        /// Creates the backup of database if needed.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        public static void CreateBackupOfDatabaseIfNeeded(string database, string id, string path)
        {
            var fileName = BackupFileName(database, id, path);
            if (File.Exists(fileName)) return;

            using (var connection = CreateConnection(database))
            {
                connection.Open();
                var databaseName = GetDatabaseName(connection);
                SqlConnection.ClearAllPools();
                CloseDatabaseConnections(connection, databaseName);
                CreateBackup(connection, databaseName, id, path);
            }
        }

        /// <summary>
        /// Supports snapshots or not
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public static bool SupportsSnapshot(string database)
        {
            using (var connection = CreateConnection(database))
            {
                connection.Open();
                const string getName = @"Select serverproperty('edition')";
                string databaseNameVersion;
                using (IDbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = getName;
                    databaseNameVersion = (string)cmd.ExecuteScalar();
                }
                if (databaseNameVersion.Contains("Express") || databaseNameVersion.Contains("Standard"))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Private Database helpers

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns>SqlConnection.</returns>
        private static SqlConnection CreateConnection(string databaseName)
        {
            var connectionString = string.Format(ConfigurationManager.ConnectionStrings["UnitTestDbContext"].ConnectionString, databaseName);
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Creates the snap shot.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="token">The token.</param>
        private static void CreateSnapShot(SqlConnection connection, string token = null)
        {
            DropSnapShot(connection, token);
            CreateSnapshotCore(connection, token);
        }

        /// <summary>
        /// Gets the name of the database.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns>System.String.</returns>
        private static string GetDatabaseName(SqlConnection connection)
        {
            const string getName = @"Select DB_NAME()";
            string databaseName;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = getName;
                databaseName = (string)cmd.ExecuteScalar();
            }
            return databaseName;
        }

        /// <summary>
        /// Change the current database to the named database.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <remarks>This is pretty much just a "use" statement.
        /// Note that the code expects the database of the connection to not change.
        /// We need to change it out for some operations, this gives a way to put it back.</remarks>
        private static void ChangeCurrentDatabase(SqlConnection connection, string databaseName)
        {
            //set the database back to the one we need since prior swapped to using.
            var getName = String.Format("Use [{0}];", databaseName);

            RunNonQuery(connection, getName);
        }

        /// <summary>
        /// Restores the snap shot.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="token">The token.</param>
        private static void RestoreSnapShot(SqlConnection connection, string databaseName, string token = null)
        {
            //force connections to close before we restore snapshot
            CloseDatabaseConnections(connection, databaseName);

            RestoreSnapShotCore(connection, databaseName, token);
        }

        /// <summary>
        /// Closes the database connections.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        private static void CloseDatabaseConnections(SqlConnection connection, string databaseName)
        {
            //cause all local connections to close. 
            //this is a HUGE time win for local tests.
            SqlConnection.ClearAllPools();

            //toggle database to force connections to close 
            MakeDatabaseSingleUser(connection, databaseName);
            MakeDatabaseMultiUser(connection, databaseName);
        }

        /// <summary>
        /// Creates the snapshot core.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="token">The token.</param>
        private static void CreateSnapshotCore(SqlConnection connection, string token = null)
        {
            const string createSnapshot = @"
                declare @dbName as nvarchar(128) = DB_NAME();
                declare @logicalName as nvarchar(300) = (select name from sys.database_files where type_desc='ROWS');
                declare @dbSnapName as nvarchar(128) = @logicalName+ 'SnapShot' + '{0}';
                declare @fileName as nvarchar(300)=(select physical_name from sys.database_files where type_desc='ROWS');
                set @fileName = LEFT(@fileName,Len(@fileName)-4)+ '{0}'+'.ss';
                DECLARE @SQL NVARCHAR(MAX)
                SET @SQL=N'CREATE DATABASE [' + @dbSnapName + '] ON (Name=''' + @logicalName + ''', FILENAME=''' +@filename + ''')AS SNAPSHOT OF [' + @dbName + ']';
                --print @sql
                EXEC SP_EXECUTESQL @SQL
                ";
            //consider making databaseName actually used.
            var sql = string.Format(createSnapshot, token ?? String.Empty);
            RunNonQuery(connection, sql);
        }

        /// <summary>
        /// Restores the snap shot core.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="token">The token.</param>
        private static void RestoreSnapShotCore(SqlConnection connection, string databaseName, string token = null)
        {
            const string restoreSnapshot =
                @" declare @logicalName as nvarchar(300) = (select name from sys.database_files where type_desc='ROWS');
                    declare @dbSnapName as nvarchar(128) = @logicalName + 'SnapShot' + '{0}';
                    declare @dbName as nvarchar(128) = DB_NAME();
                    use master;
                    IF EXISTS (SELECT Name FROM sys.databases WHERE NAME=@dbSnapName)
                        exec('RESTORE DATABASE [' + @dbName +'] from DATABASE_SNAPSHOT = ''' + @dbSnapName+ '''');";

            //consider making databaseName actually used.
            var sql = string.Format(restoreSnapshot, token ?? String.Empty);
            RunNonQuery(connection, sql);
            ChangeCurrentDatabase(connection, databaseName);
        }

        /// <summary>
        /// Drops the snap shot.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="token">The token.</param>
        private static void DropSnapShot(SqlConnection connection, string token = null)
        {
            const string dropSnapshot =
                @"declare @logicalName as nvarchar(300) = (select name from sys.database_files where type_desc='ROWS');
                  declare @dbSnapName as nvarchar(128) = @logicalName + 'SnapShot' + '{0}';

                IF EXISTS (SELECT Name FROM sys.databases WHERE NAME=@dbSnapName)
                    EXEC('DROP DATABASE [' + @dbSnapName +']')";

            //consider making databaseName actually used.
            var sql = string.Format(dropSnapshot, token ?? String.Empty);

            RunNonQuery(connection, sql);
        }

        //various methods of making a database drop connections...

        /// <summary>
        /// Makes the database single user.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        private static void MakeDatabaseSingleUser(SqlConnection connection, string databaseName)
        {
            const string forceSingleUser = "ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            var kickUsers = String.Format(forceSingleUser, databaseName);

            RunNonQuery(connection, kickUsers);
        }

        /// <summary>
        /// Makes the database multi user.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        private static void MakeDatabaseMultiUser(SqlConnection connection, string databaseName)
        {
            const string forceMultiUser = "ALTER DATABASE [{0}] SET MULTI_USER";
            var allowUsers = String.Format(forceMultiUser, databaseName);

            RunNonQuery(connection, allowUsers);
        }

        /// <summary>
        /// Snapshots the exists.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private static bool SnapshotExists(SqlConnection connection, string databaseName, string token = null)
        {
            var sql =
                @"declare @logicalName as nvarchar(300) = (select name from sys.database_files where type_desc='ROWS');
                  declare @dbSnapName as nvarchar(128) = @logicalName + 'SnapShot' + '{1}';

                SELECT count(Name) FROM sys.databases WHERE NAME=@dbSnapName
                ";

            sql = string.Format(sql, databaseName, token ?? String.Empty);
            var retval = RunScalar<int>(connection, sql) > 0;
            return retval;
        }

        /// <summary>
        /// Creates the backup.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        private static void CreateBackup(SqlConnection connection, string databaseName, string id = null,
            string path = null)
        {
            const string sqlCommand = @"
                    USE master
                    BACKUP DATABASE [{0}] 
                    TO DISK = N'{1}'
                    WITH FORMAT;
                ";
            var fileName = BackupFileName(databaseName, id, path);
            var sql = string.Format(sqlCommand, databaseName, fileName);
            RunNonQuery(connection, sql);
        }

        /// <summary>
        /// Restores the backup.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        private static void RestoreBackup(SqlConnection connection, string databaseName, string id = null,
            string path = null)
        {
            const string sqlCommand = @"
                    USE master
                    RESTORE DATABASE [{0}]
                    FROM  DISK = N'{1}' 
                    WITH  
                        FILE = 1,  
                        NOUNLOAD,  
                        REPLACE,
                        STATS = 10
                ";
            var fileName = BackupFileName(databaseName, id, path);
            var sql = string.Format(sqlCommand, databaseName, fileName);
            RunNonQuery(connection, sql);
        }

        /// <summary>
        /// Backups the name of the file.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private static string BackupFileName(string databaseName, string id, string path)
        {
            var fileName = string.IsNullOrEmpty(id)
                ? string.Format("{0}.bak", databaseName)
                : string.Format("{0}{1}.bak", databaseName, id);

            var pathBase = DatabaseBackupPath(path);
            var retval = Path.Combine(pathBase, fileName);

            return retval;
        }

        /// <summary>
        /// Databases the backup path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private static string DatabaseBackupPath(string path = null)
        {
            var defaultDatabaseBackupPath = ConfigurationHelper.GetConfigValue("DefaultDatabaseBackupPath");
            var envDatabasePathOverride = Environment.GetEnvironmentVariable(DatabasePathOverrideVariable);
            if (!string.IsNullOrEmpty(envDatabasePathOverride) && envDatabasePathOverride != "0")
            {
                path = envDatabasePathOverride;
            }

            //if we do not have a path, or the directory does not exist use the default base path.
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                if (!Directory.Exists(defaultDatabaseBackupPath))
                    Directory.CreateDirectory(defaultDatabaseBackupPath);

                _baseDatabaseBackupPath = defaultDatabaseBackupPath;
            }
            else
            {
                _baseDatabaseBackupPath = path;
            }

            return _baseDatabaseBackupPath;
        }

        /// <summary>
        /// The database path override variable
        /// </summary>
        private const string DatabasePathOverrideVariable = "SAGE_CRE_CLOUD_UNITTEST_DATABASE_BACKUP_PATH";

        /// <summary>
        /// The _base database backup path
        /// </summary>
        private static string _baseDatabaseBackupPath;

        /// <summary>
        /// The command timeout in seconds
        /// </summary>
        private const int CommandTimeoutInSeconds = 120;

        /// <summary>
        /// Runs the scalar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        /// <returns>T.</returns>
        private static T RunScalar<T>(SqlConnection connection, string command)
        {
            T retval;
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = command;
                cmd.CommandTimeout = CommandTimeoutInSeconds;
                retval = (T)cmd.ExecuteScalar();
            }
            return retval;
        }

        /// <summary>
        /// Runs the non query.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security",
            "CA2100:Review SQL queries for security vulnerabilities")]
        private static void RunNonQuery(SqlConnection connection, string command)
        {
            using (IDbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = command;
                cmd.CommandTimeout = CommandTimeoutInSeconds;
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}