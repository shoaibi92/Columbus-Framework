// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Xml;
using Sage.CA.SBS.ERP.Sage300.LandlordDatabaseSetup.Resources;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.LandlordDatabaseSetup
{
    /// <summary> Class for Landlord Database Setup worker </summary>
    public static class LandlordDatabaseSetup
    {
        #region Private Constants
        /// <summary> Source path for xml and sql files </summary>
        private const string SourcePath = @"..\\..\\..\\..\\Database\\Sage.Landlord\\Scripts\";
        
        /// <summary> XML Configuration file </summary>
        private const string ConfigFile = "LandlordDatabaseSetup.config";

        /// <summary> Worker Role Service </summary>
        private const string WorkerRoleService = "Sage.CNA.WindowsService";
        #endregion

        #region Public Methods
        /// <summary> Process the script(s) </summary>
        /// <param name="args">Connection arguments</param>
        /// <remarks>Argument [0] is the Server Name</remarks>
        /// <remarks>Argument [1] is the Server Port</remarks>
        /// <remarks>Argument [2] is the Database Name</remarks>
        /// <remarks>Argument [3] is the User ID</remarks>
        /// <remarks>Argument [4] is the User Password</remarks>
        /// <returns>Return zero for success otherwise non-zero</returns>
        public static int Process(string[] args)
        {
            // Build connection string
            var connectionString = "Data Source=tcp:" + args[0] + ", " + args[1] + 
                ";Initial Catalog=" + args[2] + ";User id=" + args[3] + 
                ";Password=" + args[4] + ";";

            using (var connection = new SqlConnection(connectionString))
            {
                // Locals
                SqlTransaction transaction = null;
                var scripts = GetScripts();
                try
                {
                    // Open the connection
                    Console.WriteLine(LandlordDatabaseSetupResx.OpeningConnection);
                    Console.WriteLine("");
                    connection.Open();

                    // Start a local transaction
                    var command = connection.CreateCommand();
                    transaction = connection.BeginTransaction("LandlordDatabaseSetup");

                    // Must assign both transaction object and connection 
                    // to Command object for a pending local transaction
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Process scripts
                    foreach (var script in scripts)
                    {
                        // Process script
                        Console.WriteLine(LandlordDatabaseSetupResx.Processing, script);
                        var retVal = ProcessScript(command, File.ReadLines(GetPath() + script));
                        if (!retVal.Equals((int)ProcessingResult.Success))
                        {
                            throw new Exception();
                        }
                    }
                    // Attempt to commit the transaction.
                    transaction.Commit();

                    // Success processing the scripts
                    Console.WriteLine("");
                    return (int)ProcessingResult.Success;
                }
                catch
                {
                    // Error. Rollback transaction if started!
                    try
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                        // Error establishing connection
                        Console.WriteLine(LandlordDatabaseSetupResx.ErrorEstablishingConnection);
                        return (int)ProcessingResult.ErrorEstablishingConnection;
                    }
                    catch
                    {
                        // Failsafe
                        Console.WriteLine(LandlordDatabaseSetupResx.ErrorRollingBackTransaction);
                        return (int)ProcessingResult.ErrorRollingBack;
                    }
                }
            }
        }

        /// <summary> Restart worker role </summary>
        public static void RestartWorkerRole()
        {
            try
            {
                // Restart WorkerRole Windows Service
                Console.Write(LandlordDatabaseSetupResx.RestartingWorkerRole);
                var sc = new ServiceController(WorkerRoleService);

                // Stop the service if it is running
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    sc.Stop();
                    sc.Refresh();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMinutes(3));
                }

                // Start the service if it is stopped
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    sc.Refresh();
                }

                Console.Write("");

            }
            catch
            {
                // Swallow the error as the service may be installed on another machine
            }
        }

        #endregion

        #region Private Methods
        /// <summary> Process the script </summary>
        /// <param name="command">SQL Command object</param>
        /// <param name="lines">Script lines to process</param>
        /// <returns>Return zero for success otherwise non-zero</returns>
        private static int ProcessScript(IDbCommand command, IEnumerable<string> lines)
        {
            try
            {
                // Build sql batch
                var sqlBatch = new StringBuilder();

                foreach (var line in lines.Where(line => !string.IsNullOrEmpty(line)))
                {
                    if (line.Trim().Equals("GO"))
                    {
                        command.CommandText = sqlBatch.ToString();
                        command.ExecuteNonQuery();
                        sqlBatch.Clear();
                    }
                    else
                    {
                        sqlBatch.AppendLine(line);
                    }
                }

                // Success processing the script
                return (int)ProcessingResult.Success;

            }
            catch
            {
                // Error processing the script
                Console.WriteLine(LandlordDatabaseSetupResx.ErrorProcessingScript);
                return (int)ProcessingResult.ErrorProcessingScript;   
            }
        }

        /// <summary> Get Scripts </summary>
        /// <returns>Returns scripts to be executed from xml configuration file </returns>
        private static IEnumerable<string> GetScripts()
        {
            // Locals
            var scripts = new List<string>();

            // Iterate xml configuration file
            using (var reader = XmlReader.Create(GetPath() + ConfigFile))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                            case XmlNodeType.Text:
                                // Script to execute
                                scripts.Add(reader.Value);
                            break;
                    }
                }
            }
            return scripts;
        }

        /// <summary> Get Path </summary>
        /// <returns>Return path for scripts and xml configuration file </returns>
        private static string GetPath()
        {
            return Debugger.IsAttached ? SourcePath : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
        }

        #endregion
    }
}
