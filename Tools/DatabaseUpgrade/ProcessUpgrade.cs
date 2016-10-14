// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    /// <summary> Process Upgrade (worker) </summary>
    class ProcessUpgrade
    {
        #region Private Vars
        /// <summary> Settings from UI </summary>
        private Settings _settings;
        /// <summary> Cryptography Certificate </summary>
        private readonly CertificateCryptography _agent = new CertificateCryptography(ConfigurationManager.AppSettings["CertificateThumbprint"]);

        #endregion

        #region Public Delegates
        /// <summary> Delegate to update UI with name of tenant being processed </summary>
        /// <param name="text">Text for UI</param>
        public delegate void ProcessingEventHandler(string text);

        /// <summary> Delegate to update UI with tenant process status </summary>
        public delegate void StatusEventHandler();
        #endregion

        #region Public Events
        /// <summary> Event to update UI with name of tenant being processed </summary>
        public event ProcessingEventHandler ProcessingEvent;

        /// <summary> Event to update UI with tenant process status </summary>
        public event StatusEventHandler StatusEvent;
        #endregion

        #region Public Methods
        /// <summary> Cleanup </summary>
        public void Dispose()
        {
        }

        /// <summary> Start the upgrade process </summary>
        /// <param name="settings">Settings for processing</param>
        public void Process(Settings settings)
        {
            _settings = settings;

            // Iterate tenants
            foreach (var tenant in _settings.Tenants)
            {
                // Update display of tenant being processed
                if (ProcessingEvent != null)
                {
                    ProcessingEvent(tenant.InternalName);
                }

                // If the upgrade has been cancelled, mark tenant else continue with upgrade
                if (tenant.Cancel)
                {
                    tenant.SetUpgradeStatus(Tenant.UpgradeStatusType.Warning);
                    tenant.Attempts++;
                    tenant.Message = string.Format(Properties.Resources.ProcessingStopped, tenant.Attempts, tenant.Thread);
                    if (StatusEvent != null)
                    {
                        StatusEvent();
                    }
                }
                else
                {
                    // Execute script
                    ExecuteScript(tenant);
                }
            }
        }
        #endregion

        #region Private Methods

        /// <summary> Execute script on tenant </summary>
        /// <param name="tenant">Tenant</param>
        private void ExecuteScript(Tenant tenant)
        {
            // Decrpyt password
            var decryptedPassword = _agent.Decrypt(tenant.DatabasePassword);

            // Build connection string
            var connectionString = "Server=tcp:" + tenant.ServerName + 
                ",1433;Database=" + tenant.DatabaseName +
                ";User ID=" + tenant.DatabaseLogin + ";Password=" + decryptedPassword +
                ";Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                // Locals
                SqlTransaction transaction = null;

                try
                {
                    // Open the tenant connection
                    connection.Open();

                    var command = connection.CreateCommand();

                    // Start a local transaction
                    transaction = connection.BeginTransaction(_settings.TransactionName);

                    // Must assign both transaction object and connection 
                    // to Command object for a pending local transaction
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Build sql batch
                    var sqlBatch = new StringBuilder();

                    foreach (var line in _settings.ScriptContent)
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

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    tenant.SetUpgradeStatus(Tenant.UpgradeStatusType.Success);
                    tenant.Attempts++;
                    tenant.Message = string.Format(Properties.Resources.ProcessingComplete, tenant.Attempts, tenant.Thread);
                    if (StatusEvent != null)
                    {
                        StatusEvent();
                    }

                }
                catch (Exception ex)
                {
                    tenant.SetUpgradeStatus(Tenant.UpgradeStatusType.Error);
                    tenant.Attempts++;
                    tenant.Message = string.Format(Properties.Resources.ProcessingError, tenant.Attempts, tenant.Thread, ex.Message);
                    if (StatusEvent != null)
                    {
                        StatusEvent();
                    }

                    // Attempt to roll back the transaction. 
                    try
                    {
                        if (transaction != null)
                        {
                            transaction.Rollback();
                        }
                    }
                    catch
                    {
                        // Failsafe
                    }
                }
            }
        }

        #endregion
    }
}
