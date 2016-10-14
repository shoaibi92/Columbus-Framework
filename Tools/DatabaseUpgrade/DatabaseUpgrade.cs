// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    /// <summary> UI for Database Upgrade Utility </summary>
    public partial class DatabaseUpgrade : Form
    {
        #region Private Vars
        /// <summary> Dictionary holding background workers </summary>
        private readonly Dictionary<int, BackgroundWorker> _workers = new Dictionary<int, BackgroundWorker>();

        /// <summary> Tenants to be processed </summary>
        private BindingList<Tenant> _tenants;
        #endregion

        #region Private Enums
        /// <summary> Enum to filter tenants to process only active tenants </summary>
        private enum TenantStatus
        {
            Active = 1
        }

        /// <summary> Enum to identify tenant column for grid </summary>
        public enum TenantColumn
        {
            RowIndex = 0,
            Select = 1, 
            Id = 2, 
            TenantId = 3, 
            SiteId = 4, 
            InternalName = 5, 
            Version = 6, 
            Status = 7, 
            UpdatedTimestamp = 8, 
            LastUpdated = 9,
            Company = 10,
            ServerName = 11,
            DatabaseName = 12,
            DatabaseLogin = 13, 
            DatabasePassword = 14, 
            UpgradeStatus = 15, 
            Message = 16, 
            Thread = 17,
            Cancel = 18,
            Attempts = 19
        }

        #endregion

        #region Delegates
        /// <summary> Delegate to update UI with name of tenant being processed </summary>
        /// <param name="text">Text for UI</param>
        delegate void ProcessingCallback(string text);

        /// <summary> Delegate to update UI with tenant process status </summary>
        private delegate void StatusCallback();
        #endregion

        #region Constructor
        /// <summary> Database Upgrade Utility</summary>
        public DatabaseUpgrade()
        {
            InitializeComponent();
            GetTenants();
            InitTenants();
            ProcessingSetup("", 0);
            Processing("");
        }
        #endregion

        #region Private Methods/Routines/Events

        /// <summary> Setup processing display in status bar </summary>
        /// <param name="text">Text to display in status bar</param>
        /// <param name="count">Count for progress bar</param>
        private void ProcessingSetup(string text, int count)
        {
            lblProcessing.Text = text;

            proProcessing.Maximum = count;
            proProcessing.Value = 0;

            sbrMain.Refresh();
        }

        /// <summary> Get tenants from landlord database </summary>
        private void GetTenants()
        {
            try
            {
                // Use EF to retrieve tenants
                using (var dbContext = new LandlordDbContext())
                {
                    // Filter tenants from landlord database
                    _tenants = new BindingList<Tenant>(dbContext.Tenants.Where(tenant => tenant.Status.Equals((int)TenantStatus.Active) &&
                        tenant.TenantId != null).ToList());

                    // Iterate tenants to assign row index value. Note: Passwords will be decrypted just before processing tenant database
                    var rowIndex = -1;
                    foreach (var tenant in _tenants)
                    {
                        rowIndex++;
                        tenant.RowIndex = rowIndex;
                        tenant.ServerName = tenant.ServerName + ".database.windows.net";
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MessageBoxIcon.Error);
            }

        }

        /// <summary> Initialize tenants and modify grid display </summary>
        private void InitTenants()
        {
            // Assign binding to datasource (two binding)
            grdTenants.DataSource = _tenants;

            // Assign widths, localized text, visibility and editability
            GenericInit(grdTenants, TenantColumn.RowIndex, 40, Properties.Resources.RowIndex, true, true);
            grdTenants.Columns[(int)TenantColumn.RowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GenericInit(grdTenants, TenantColumn.Select, 40, Properties.Resources.Select, true, false);
            GenericInit(grdTenants, TenantColumn.Id, 50, Properties.Resources.ID, false, true);
            GenericInit(grdTenants, TenantColumn.TenantId, 50, Properties.Resources.TenantId, false, true);
            GenericInit(grdTenants, TenantColumn.SiteId, 50, Properties.Resources.SiteId, false, true);
            GenericInit(grdTenants, TenantColumn.InternalName, 100, Properties.Resources.InternalName, true, true);
            GenericInit(grdTenants, TenantColumn.Version, 50, Properties.Resources.Version, false, true);
            GenericInit(grdTenants, TenantColumn.Status, 50, Properties.Resources.Status, false, true);
            GenericInit(grdTenants, TenantColumn.UpdatedTimestamp, 50, Properties.Resources.UpdatedTimestamp, false, true);
            GenericInit(grdTenants, TenantColumn.LastUpdated, 50, Properties.Resources.LastUpdated, false, true);
            GenericInit(grdTenants, TenantColumn.Company, 50, Properties.Resources.Company, false, true);
            GenericInit(grdTenants, TenantColumn.ServerName, 220, Properties.Resources.ServerName, true, true);
            GenericInit(grdTenants, TenantColumn.DatabaseName, 150, Properties.Resources.DatabaseName, true, true);
            GenericInit(grdTenants, TenantColumn.DatabaseLogin, 190, Properties.Resources.DatabaseLogin, true, true);
            GenericInit(grdTenants, TenantColumn.DatabasePassword, 50, Properties.Resources.DatabasePassword, false, true);
            GenericInit(grdTenants, TenantColumn.UpgradeStatus, 50, Properties.Resources.Status, true, true);
            GenericInit(grdTenants, TenantColumn.Message, 405, Properties.Resources.Message, true, true);
            GenericInit(grdTenants, TenantColumn.Thread, 50, Properties.Resources.Thread, false, true);
            GenericInit(grdTenants, TenantColumn.Cancel, 50, Properties.Resources.Cancel, false, true);
            GenericInit(grdTenants, TenantColumn.Attempts, 50, Properties.Resources.Attempts, false, true);
        }

        /// <summary> Generic init for grid </summary>
        /// <param name="grid">Grid control</param>
        /// <param name="column">Column Number</param>
        /// <param name="width">Column Width</param>
        /// <param name="text">Header Text</param>
        /// <param name="visible">True for visible otherwise False</param>
        /// <param name="readOnly">True for read only otherwise False</param>
        private static void GenericInit(DataGridView grid, TenantColumn column, int width, string text, bool visible,
            bool readOnly)
        {
            grid.Columns[(int)column].Width = width;
            grid.Columns[(int)column].HeaderText = text;
            grid.Columns[(int)column].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[(int)column].Visible = visible;
            grid.Columns[(int)column].ReadOnly = readOnly;
        }

        /// <summary> Update processing display in status bar </summary>
        /// <param name="text">Text to display in status bar</param>
        private void Processing(string text)
        {
            lblProcessingFile.Text = text;

            if (proProcessing.Maximum != 0)
            {
                proProcessing.Value++;
            }

            sbrMain.Refresh();
        }

        /// <summary> Update processing display </summary>
        /// <param name="text">Text to display in status bar</param>
        /// <remarks>Invoked from threaded process</remarks>
        private void ProcessingEvent(string text)
        {
            var callBack = new ProcessingCallback(Processing);
            Invoke(callBack, text);
        }

        /// <summary> Update upgrade status display </summary>
        private void Status()
        {
            // Simply refresh the display as the tenant bound to the grid was already updated
            grdTenants.Refresh();
        }

        /// <summary> Update upgrade status display </summary>
        /// <remarks>Invoked from threaded process</remarks>
        private void StatusEvent()
        {
            var callBack = new StatusCallback(Status);
            Invoke(callBack);
        }

        /// <summary> Generic routine for displaying a message dialog </summary>
        /// <param name="message">Message to display</param>
        /// <param name="icon">Icon to display</param>
        /// <param name="args">Message arguments, if any</param>
        private void DisplayMessage(string message, MessageBoxIcon icon, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), Text, MessageBoxButtons.OK, icon);
        }

        /// <summary> Validate the settings </summary>
        /// <returns>True if valid otherwise false</returns>
        private bool ValidSettings()
        {
            try
            {
                // Locals
                var tenantCount = _tenants.Count(tenant => tenant.IsSelected);
                var statusCount =
                    _tenants.Count(tenant => !tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.None));

                // Must specify a transaction name, script file must be valid, must have selected at least
                // one tenant, number of threads cannot exceed number of tenants selected, upgrade not already running and
                // tenant grid does not contain information from a previous upgrade
                return !txtTranName.Text.Trim().Equals(string.Empty) &&
                       !File.ReadAllLines(txtScriptFile.Text).Count().Equals(0) &&
                       !tenantCount.Equals(0) &&
                       tenantCount > numThreads.Value &&
                       _workers.Count.Equals(0) &&
                       statusCount.Equals(0);
            }
            catch
            {
                return false;
            }
        }

        /// <summary> Select/Unselect Tenants</summary>
        /// <param name="select">True to select all otherwise unselect all </param>
        private void AllTenants(bool select)
        {
            foreach (var tenant in _tenants)
            {
                tenant.IsSelected = select;
            }
            grdTenants.Refresh();
        }

        /// <summary> Reset Tenants</summary>
        private void ResetTenants()
        {
            // Set status and message to blank and reset the cancel flag
            foreach (var tenant in _tenants)
            {
                tenant.SetUpgradeStatus(Tenant.UpgradeStatusType.None);
                tenant.Message = string.Empty;
                tenant.Cancel = false;
                tenant.Attempts = 0;
            }
            grdTenants.Refresh();
        }

        /// <summary> Thread processing</summary>
        private void ThreadProcessing(bool retryAttempt)
        {
            // Locals
            var threads = (retryAttempt) ? 1 : (int) numThreads.Value;
            var tenants = (retryAttempt) ? 
                _tenants.Where(tenant => tenant.IsSelected && 
                tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.Error) && 
                tenant.Attempts < (int)numAttempts.Value) : 
                _tenants.Where(tenant => tenant.IsSelected);
            var thread = 0;
            var tenantCount = 0;
            var transactionName = txtTranName.Text.Trim();
            var scriptContent = File.ReadAllLines(txtScriptFile.Text);

            // Assign thread numbers to tenants by iterating tenants and assign thread 
            // to be used later to parse list to different threads
            foreach (var tenant in tenants)
            {
                // Increment thread and verify against max
                thread++;
                if (thread > threads)
                {
                    thread = 1;
                }

                // Assign
                tenant.Thread = thread;
                tenantCount++;
            }

            // Update display before processing
            ProcessingSetup(((retryAttempt) ? Properties.Resources.RetryingTenant : Properties.Resources.ProcessingTenant),
                tenantCount);

            // Background workers
            for (var i = 1; i < threads + 1; i++)
            {
                // Create and add tpo dictionary
                var worker = new BackgroundWorker { WorkerReportsProgress = false };
                _workers.Add(i, worker);

                // Create dynamic DoWork event and add to worker
                DoWorkEventHandler doWork = (sender, e) =>
                {
                    // Create process upgrade object for this thread and wire events
                    var processUpgrade = new ProcessUpgrade();
                    processUpgrade.ProcessingEvent += ProcessingEvent;
                    processUpgrade.StatusEvent += StatusEvent;

                    processUpgrade.Process((Settings)e.Argument);
                };
                worker.DoWork += doWork;

                // Create dynamic RunWorkerCompleted event and add to worker
                RunWorkerCompletedEventHandler runWorkerCompleted = (sender, e) =>
                {
                    // Get worker from dictionary and remove
                    foreach (var backgroundWorker in _workers.Where(backgroundWorker => backgroundWorker.Value == (BackgroundWorker)sender))
                    {
                        // Dispose first and then remove
                        backgroundWorker.Value.Dispose();
                        _workers.Remove(backgroundWorker.Key);
                        break;
                    }

                    // If not the last worker, then do not consider rerty logic next
                    if (!_workers.Count.Equals(0))
                    {
                        return;
                    }

                    // Cleanup display and determine if retry attempts are required for any failures
                    ProcessingSetup(Properties.Resources.UpgradeComplete, 0);
                    Processing("");
                    AttemptRetries();
                };
                worker.RunWorkerCompleted += runWorkerCompleted;

                // Start background worker
                var settings = new Settings
                {
                    TransactionName = transactionName,
                    ScriptContent = scriptContent,
                    Tenants = (retryAttempt) ? 
                    _tenants.Where(tenant => tenant.IsSelected &&
                    tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.Error) &&
                    tenant.Attempts < (int)numAttempts.Value && 
                    tenant.Thread.Equals(i)).ToList() : 
                    _tenants.Where(tenant => tenant.IsSelected && tenant.Thread.Equals(i)).ToList()
                };
                worker.RunWorkerAsync(settings);
            }
        }

        /// <summary> Stop upgrade, if in progress</summary>
        private void StopUpgrade()
        {
            // If any workers are in dictionary, this means that there are threads still running
            if (_workers.Count.Equals(0))
            {
                return;
            }

            // Iterate based up selected tenants that still awaiting upgrade
            foreach (var tenant in _tenants.Where(tenant => tenant.IsSelected && !tenant.Cancel && 
                tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.None)))
            {
                // Set tenant to cancel in order to prevent the upgrade process to be run on the tenant
                tenant.Cancel = true;
            }

        }

        /// <summary> Attempt retries</summary>
        private void AttemptRetries()
        {
            // Do not continue if number of attempts is one or there are no tenants in error
            if (numAttempts.Value.Equals(1) ||
                _tenants.Count(tenant => tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.Error)).Equals(0))
            {
                EnableControls(true);
                return;
            }

            // Do not continue if there are no tenants in error that have retyr attempts left to be performed
            if (_tenants.Count(tenant => tenant.IsSelected && 
                tenant.GetUpgradeStatusType().Equals(Tenant.UpgradeStatusType.Error) && 
                tenant.Attempts < (int)numAttempts.Value).Equals(0))
            {
                EnableControls(true);
                return;
            }

            // Perform retries on errors
            ThreadProcessing(true);
        }

        /// <summary> Enable/Disable controls </summary>
        /// <param name="value">True to enable otherwise false</param>
        private void EnableControls(bool value)
        {
            numThreads.Enabled = value;
            numAttempts.Enabled = value;
            txtTranName.Enabled = value;
            btnScriptDialog.Enabled = value;
            grdTenants.Enabled = value;
        }
        /// <summary> Common save tenant info to file routine </summary>
        //private void SaveTenantInfo()
        //{
            //// Init dialog
            //var dialog = new SaveFileDialog
            //{
            //    CheckFileExists = false,
            //    CheckPathExists = true,
            //    Filter = Properties.Resources.SaveFilter,
            //    FilterIndex = 1,
            //    RestoreDirectory = true
            //};

            //// Show the dialog and evaluate action
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Save tenant info which is bound to the grid to a text file
            //    try
            //    {
            //        var linesToWrite = _tenantInfo.Select(tenantInfo =>
            //            tenantInfo.RowIndex + " ; " +
            //            tenantInfo.IsSelected + " ; " +
            //            tenantInfo.TenantId + " ; " +
            //            tenantInfo.Version + " ; " +
            //            tenantInfo.InternalName + " ; " +
            //            tenantInfo.ServerName + " ; " +
            //            tenantInfo.DatabaseName + " ; " +
            //            tenantInfo.UserName + " ; " +
            //            tenantInfo.GetStatusType() + " ; " +
            //            tenantInfo.Message).ToArray();
            //        File.WriteAllLines(@dialog.FileName, linesToWrite);
            //    }
            //    catch
            //    {
            //        DisplayMessage(Properties.Resources.ErrorWritingTenantInfoFile, MessageBoxIcon.Error);
            //    }
            //}
        //}

        #endregion

        #region Toolbar Events

        /// <summary> Proceed toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Process if there is something to process</remarks>
        private void btnProceed_Click(object sender, EventArgs e)
        {
            // Validate that settings have been selected
            if (ValidSettings())
            {
                // Start the background threads
                EnableControls(false);
                ThreadProcessing(false);
            }
            else
            {
                // View or output folder is invalid
                DisplayMessage(Properties.Resources.InvalidSettings, MessageBoxIcon.Error);
            }
        }

        /// <summary> Exit toolbar button </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event Args</param>
        /// <remarks>Exit utility </remarks>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary> Display Help toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Display wiki link
            Process.Start(Properties.Resources.WikiLink);
        }

        /// <summary> Display script in notepad</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnShowScript_Click(object sender, EventArgs e)
        {
            try
            {
                // Display script in notepad
                Process.Start("notepad.exe", txtScriptFile.Text);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message, MessageBoxIcon.Error);
            }

        }
      
        /// <summary> SQl Script search dialog</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnScriptDialog_Click(object sender, EventArgs e)
        {
            // Init dialog
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = Properties.Resources.Filter,
                FilterIndex = 1,
                Multiselect = false
            };

            // Show the dialog and evaluate action
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtScriptFile.Text = dialog.FileName.Trim();
        }

        /// <summary> Stop the upgrade process by targetting tenants still to be upgraded </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Stop the upgrade (if running and tenants are still to be upgraded)
            StopUpgrade();
        }

        /// <summary> Update underlying data</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void grdTenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only care about Selected column
            if ((((DataGridView) sender).CurrentCell == null) || !((DataGridView) sender).CurrentCell.ColumnIndex.Equals((int)TenantColumn.Select))
            {
                return;
            }

            // Get bound row
            var rowIndex = ((DataGridView)sender).CurrentCell.RowIndex;
            var tenant = _tenants.Single(selectedTenant => selectedTenant.RowIndex.Equals(rowIndex));
            tenant.IsSelected = !tenant.IsSelected;
            grdTenants.Refresh();
        }

        /// <summary> Cancel closing if workers/threads are still running</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void DatabaseUpgrade_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check for running threads
            if (_workers.Count.Equals(0))
            {
                return;
            }

            // Workers are still running. Wait...
            DisplayMessage(Properties.Resources.WorkersRunning, MessageBoxIcon.Exclamation);
            e.Cancel = true;
        }

        /// <summary> Select/Unselct all tenants</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        public void tenantHeader_CheckedChanged(object sender, EventArgs e)
        {
            AllTenants(((CheckBox)grdTenants.Controls.Find("tenantCheckboxHeader", true)[0]).Checked);
        }

        /// <summary> Clear tenants</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        public void tenantHeader_Click(object sender, EventArgs e)
        {
            ResetTenants();
        }

        #endregion

    }
}
