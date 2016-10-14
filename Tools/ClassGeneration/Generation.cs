// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> UI for Class Generation Tool </summary>
    public partial class Generation : Form
    {
        #region Private Vars
        /// <summary> Process Generation logic </summary>
        private ProcessGeneration _generation;
       
        /// <summary> Information processed </summary>
        private readonly BindingList<Info> _gridInfo = new BindingList<Info>();

        /// <summary> Dynamic Query Infomation </summary>
        private readonly BindingList<BusinessField> _dynamicQueryFields = new BindingList<BusinessField>();

        /// <summary> Report Infomation </summary>
        private BindingList<BusinessField> _reportFields = new BindingList<BusinessField>();

        /// <summary> Reports </summary>
        private readonly Dictionary<string, BindingList<BusinessField>> _reports = new Dictionary<string, BindingList<BusinessField>>();

        /// <summary> Row index for grid </summary>
        private int _rowIndex = -1;

        #endregion

        #region Delegates
        /// <summary> Delegate to update UI with name of file being processed </summary>
        /// <param name="text">Text for UI</param>
        delegate void ProcessingCallback(string text);

        /// <summary> Delegate to update UI with status of file being processed </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="statusType">Status Type</param>
        /// <param name="text">Text for UI</param>
        delegate void StatusCallback(string fileName, Info.StatusType statusType, string text);

        #endregion

        #region Constructor
        /// <summary> Generation Class </summary>
        public Generation()
        {
            InitializeComponent();
            InitInfo();
            InitDynamicQueryFields();
            InitReportFields();
            InitEvents();
            ProcessingSetup("", 0, true);
            Processing("");

            cboRepositoryType.Focus();
        }
        #endregion

        #region Private Methods/Routines/Events
        /// <summary> Initialize events for process generation class </summary>
        private void InitEvents()
        {
            _generation = new ProcessGeneration();
            _generation.ProcessingEvent += ProcessingEvent;
            _generation.StatusEvent += StatusEvent;

            // Default to Unknown Repository
            cboRepositoryType.SelectedIndex = Convert.ToInt32(RepositoryType.Unknown);
        }

        #region Toolbar Events
        /// <summary> Proceed toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Process if there is something to process</remarks>
        private void btnProceed_Click(object sender, EventArgs e)
        {
            // Build settings and validate that settings have been selected (view, output folder, resx name, user, password, version, database))
            txtViewID.Text = txtViewID.Text.ToUpper();
            txtViewID.Refresh();

            var settings = BuildSettings();
            if (ValidSettings(settings))
            {
                // Setup display before processing
                _gridInfo.Clear();
                ProcessingSetup(Properties.Resources.ProcessingView, _gridInfo.Count, false);
                grdResourceInfo.DataSource = _gridInfo;
                grdResourceInfo.Refresh();

                _rowIndex = -1;

                // Start background worker for processing (async)
                wrkBackground.RunWorkerAsync(settings);
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
            _generation.Dispose();
            Close();
        }

        /// <summary> Display Help toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Display wiki link
            System.Diagnostics.Process.Start(Properties.Resources.Browser, Properties.Resources.WikiLink);
        }
       #endregion

        /// <summary> Initialize info and modify grid display </summary>
        private void InitInfo()
        {
            // Assign binding to datasource (two binding)
            grdResourceInfo.DataSource = _gridInfo;

            // Assign widths and localized text
            grdResourceInfo.Columns[Info.FileNameColumnNo].Width = 375;
            grdResourceInfo.Columns[Info.FileNameColumnNo].HeaderText = Properties.Resources.FileName;


            grdResourceInfo.Columns[Info.StatusColumnNo].Width = 50;
            grdResourceInfo.Columns[Info.StatusColumnNo].ReadOnly = true;
            grdResourceInfo.Columns[Info.StatusColumnNo].HeaderText = Properties.Resources.Status;
        }

        /// <summary> Initialize dynamic query info and modify grid display </summary>
        private void InitDynamicQueryFields()
        {
            // Assign binding to datasource (two binding)
            grdDynamicQueryFields.DataSource = _dynamicQueryFields;

            // Assign widths and localized text
            GenericInit(grdDynamicQueryFields, 0, 50, Properties.Resources.ID, false, false);
            GenericInit(grdDynamicQueryFields, 1, 150, Properties.Resources.Field, false, false);
            GenericInit(grdDynamicQueryFields, 2, 150, Properties.Resources.Field, true, false);
            GenericInit(grdDynamicQueryFields, 3, 290, Properties.Resources.Description, false, false);

            // Remove and re-add as combobox column
            grdDynamicQueryFields.Columns.Remove("Type");
            var column = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = Properties.Resources.Type,
                DropDownWidth = 100,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            // Add enums to drop down list
            foreach (BusinessDataType businessDataType in Enum.GetValues(typeof(BusinessDataType)))
            {
                // Do not add enumerations type
                if (!businessDataType.Equals(BusinessDataType.Enumeration))
                {
                    column.Items.Add(businessDataType);
                }
            }

            // Re-add column
            grdDynamicQueryFields.Columns.Insert(4, column);
            grdDynamicQueryFields.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            GenericInit(grdDynamicQueryFields, 5, 50, Properties.Resources.Size, true, false);
            GenericInit(grdDynamicQueryFields, 6, 75, Properties.Resources.IsReadOnly, false, false);
            GenericInit(grdDynamicQueryFields, 7, 75, Properties.Resources.IsCalculated, false, false);
            GenericInit(grdDynamicQueryFields, 8, 75, Properties.Resources.IsRequired, false, false);
            GenericInit(grdDynamicQueryFields, 9, 75, Properties.Resources.IsKey, false, false);
            GenericInit(grdDynamicQueryFields, 10, 75, Properties.Resources.IsUpperCase, false, false);
            GenericInit(grdDynamicQueryFields, 11, 75, Properties.Resources.IsAlphaNumeric, false, false);
            GenericInit(grdDynamicQueryFields, 12, 75, Properties.Resources.IsNumeric, false, false);
            GenericInit(grdDynamicQueryFields, 13, 75, Properties.Resources.IsDynamicEnablement, false, false);
        }

        /// <summary> Initialize report info and modify grid display </summary>
        private void InitReportFields()
        {
            // Assign binding to datasource (two binding)
            grdReportFields.DataSource = _reportFields;

            // Assign widths and localized text
            GenericInit(grdReportFields, 0, 50, Properties.Resources.ID, false, false);
            GenericInit(grdReportFields, 1, 150, Properties.Resources.ServerField, true, true);
            GenericInit(grdReportFields, 2, 150, Properties.Resources.Field, true, false);
            GenericInit(grdReportFields, 3, 290, Properties.Resources.Description, false, false);

            // Remove and re-add as combobox column
            grdReportFields.Columns.Remove("Type");
            var column = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = Properties.Resources.Type,
                DropDownWidth = 100,
                Width = 75,
                FlatStyle = FlatStyle.Flat
            };
            // Only add string type
            column.Items.Add(BusinessDataType.String);

            // Re-add column
            grdReportFields.Columns.Insert(4, column);
            grdReportFields.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdReportFields.Columns[4].Visible = false;

            GenericInit(grdReportFields, 5, 50, Properties.Resources.Size, true, false);
            GenericInit(grdReportFields, 6, 75, Properties.Resources.IsReadOnly, false, false);
            GenericInit(grdReportFields, 7, 75, Properties.Resources.IsCalculated, false, false);
            GenericInit(grdReportFields, 8, 75, Properties.Resources.IsRequired, false, false);
            GenericInit(grdReportFields, 9, 75, Properties.Resources.IsKey, false, false);
            GenericInit(grdReportFields, 10, 75, Properties.Resources.IsUpperCase, false, false);
            GenericInit(grdReportFields, 11, 75, Properties.Resources.IsAlphaNumeric, false, false);
            GenericInit(grdReportFields, 12, 75, Properties.Resources.IsNumeric, false, false);
            GenericInit(grdReportFields, 13, 75, Properties.Resources.IsDynamicEnablement, false, false);
        }

        /// <summary> Generic init for grid </summary>
        /// <param name="grid">Grid control</param>
        /// <param name="column">Column Number</param>
        /// <param name="width">Column Width</param>
        /// <param name="text">Header Text</param>
        /// <param name="visible">True for visible otherwise False</param>
        /// <param name="readOnly">True for read only otherwise False</param>
        private void GenericInit(DataGridView grid, int column, int width, string text, bool visible, bool readOnly)
        {
            grid.Columns[column].Width = width;
            grid.Columns[column].HeaderText = text;
            grid.Columns[column].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns[column].Visible = visible;
            grid.Columns[column].ReadOnly = readOnly;

            // Show read only in InactiveCaption color
            if (readOnly)
            {
                grid.Columns[column].DefaultCellStyle.BackColor = SystemColors.InactiveCaption;
            }
        }

        /// <summary> Setup processing display in status bar </summary>
        /// <param name="text">Text to display in status bar</param>
        /// <param name="count">Count for progress bar</param>
        /// <param name="enableToolbar">True to enable otherwise false</param>
        private void ProcessingSetup(string text, int count, bool enableToolbar)
        {
            tbrMain.Enabled = enableToolbar;

            lblProcessing.Text = text;

            proProcessing.Maximum = count;
            proProcessing.Value = 0;
            
            sbrMain.Refresh();
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
            Invoke(callBack, new object[] { text });
        }

        /// <summary> Update status display </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="statusType">Status Type</param>
        /// <param name="text">Text for UI</param>
        /// <remarks>Invoked from threaded process</remarks>
        private void Status(string fileName, Info.StatusType statusType, string text)
        {
            // Add to info list
            var info = new Info()
            {
                FileName = fileName
            };

            info.SetStatus(statusType);

            _gridInfo.Add(info);

            // rebind to grid
            grdResourceInfo.DataSource = _gridInfo;

            // Incrememnt row
            _rowIndex++;

            // Set status and text into tool tip for cell
            grdResourceInfo.CurrentCell = grdResourceInfo[Info.StatusColumnNo, _rowIndex];
            grdResourceInfo.CurrentCell.ToolTipText = text;

            grdResourceInfo.Refresh();
        }

        /// <summary> Update status display </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="statusType">Status Type</param>
        /// <param name="text">Text for UI</param>
        /// <remarks>Invoked from threaded process</remarks>
        private void StatusEvent(string fileName, Info.StatusType statusType, string text)
        {
            var callBack = new StatusCallback(Status);
            Invoke(callBack, new object[] { fileName, statusType, text });
        }

        /// <summary> Generic routine for displaying a message dialog </summary>
        /// <param name="message">Message to display</param>
        /// <param name="icon">Icon to display</param>
        /// <param name="args">Message arguments, if any</param>
        private void DisplayMessage(string message, MessageBoxIcon icon, params object[] args)
        {
            MessageBox.Show(string.Format(message, args), Text, MessageBoxButtons.OK, icon);
        }

        /// <summary> Build settings for background worker </summary>
        /// <returns>Settings</returns>
        private Settings BuildSettings()
        {
            var businessView = new BusinessView();
            var repositoryType =
                (RepositoryType) Enum.Parse(typeof (RepositoryType), cboRepositoryType.SelectedIndex.ToString());

            // Dynamic Query is not based upon ACCPAC view
            if (repositoryType.Equals(RepositoryType.DynamicQuery))
            {
                businessView.Properties.Add(BusinessView.ViewId, txtDynamicQueryViewID.Text.Trim());
                businessView.Properties.Add(BusinessView.Module, cboDynamicQueryModule.Text.Trim());
                businessView.Properties.Add(BusinessView.ModelName, txtDynamicQueryModelName.Text.Trim());
                businessView.Properties.Add(BusinessView.Name, txtDynamicQueryName.Text.Trim());
                businessView.Fields = _dynamicQueryFields.ToList();
            }

            // Report is not based upon ACCPAC view
            if (repositoryType.Equals(RepositoryType.Report))
            {
                var reportKey = cboReportKeys.Text.Trim();
                businessView.Properties.Add(BusinessView.ViewId, Guid.NewGuid().ToString());
                businessView.Properties.Add(BusinessView.ReportKey, reportKey);
                businessView.Properties.Add(BusinessView.Module, (reportKey != string.Empty ?
                    reportKey.Substring(0, 2).ToUpper() : string.Empty));
                businessView.Properties.Add(BusinessView.ModelName, txtReportModelName.Text.Trim());
                businessView.Properties.Add(BusinessView.Name, txtReportName.Text.Trim());
                businessView.Properties.Add(BusinessView.ProgramId, txtReportProgramId.Text.Trim().ToUpper());
                businessView.Fields = _reportFields.ToList();
            }

            return new Settings
            {
                ViewId = txtViewID.Text.Trim(),
                OutputFolder = txtOutputFolder.Text.Trim(),
                User = txtUser.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Version = txtVersion.Text.Trim(),
                Database = txtDatabase.Text.Trim(),
                GenerateFinder = chkGenerateFinder.Checked,
                RepositoryType = repositoryType,
                BusinessView = businessView,
                GenerateDynamicEnablement = chkGenerateDynamicEnablement.Checked,
                ResxName = txtResxName.Text.Trim()
            };
        }

        /// <summary> Validate the settings </summary>
        /// <param name="settings">Settings</param>
        /// <returns>True if valid otherwise false</returns>
        /// <remarks>At least one language must be selected</remarks>
        private bool ValidSettings(Settings settings)
        {
            return _generation.ValidSettings(settings);
        }

        /// <summary> Background worker started event </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Background worker will run process</remarks>
        private void wrkBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            _generation.Process((Settings)e.Argument);
        }

        /// <summary> Background worker completed event </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Background worker has completed process</remarks>
        private void wrkBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //DisplayMessage(Properties.Resources.ProcessingComplete, MessageBoxIcon.Information);
            ProcessingSetup("", 0, true);
            Processing("");
            _generation.Dispose();
        }

        /// <summary> Add a row toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            _dynamicQueryFields.Add(new BusinessField());
        }

        /// <summary> Delete the current row toolbar button </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (grdDynamicQueryFields.CurrentRow != null)
            {
                grdDynamicQueryFields.Rows.Remove(grdDynamicQueryFields.CurrentRow);
            }
        }

        /// <summary> Delete all rows toolbar button</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnDeleteRows_Click(object sender, EventArgs e)
        {
            foreach (var row in grdDynamicQueryFields.Rows)
            {
                grdDynamicQueryFields.Rows.Remove((DataGridViewRow)row);
            }
        }

        /// <summary> Enable/Disable tab pages based upon selection</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void cboRepositoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Locals
            var type =
                (RepositoryType) Enum.Parse(typeof (RepositoryType), ((ComboBox) sender).SelectedIndex.ToString());

            // Enable/Disable based upon type
            if (type.Equals(RepositoryType.DynamicQuery) || type.Equals(RepositoryType.Report))
            {
                // Enable
                tabPageDynamicQuery.Enabled = type.Equals(RepositoryType.DynamicQuery);
                tabPageReport.Enabled = type.Equals(RepositoryType.Report);

                // Select tab page
                if (type.Equals(RepositoryType.DynamicQuery))
                {
                    tabGeneration.SelectedTab = tabPageDynamicQuery;
                }
                else
                {
                    tabGeneration.SelectedTab = tabPageReport;   
                }

                txtViewID.Text = string.Empty;
                txtViewID.Enabled = false;
                grpDefaults.Enabled = false;
            }
            else
            {
                // Disable
                tabPageDynamicQuery.Enabled = false;
                tabPageReport.Enabled = false;
                txtViewID.Enabled = true;
                grpDefaults.Enabled = true;
            }

            // Reset focus
            txtOutputFolder.Focus();

        }

        /// <summary> Get report info from file </summary>
        /// <param name="fileName">Report ini file name</param>
        private void AddReports(string fileName)
        {
            // Validate name first
            if (string.IsNullOrEmpty(fileName))
            {
                // Report INI file is invalid
                DisplayMessage(Properties.Resources.InvalidReportSetting, MessageBoxIcon.Error);
                return;
            }

            // Initialize first
            cboReportKeys.Text = string.Empty;
            cboReportKeys.Items.Clear();
            _reportFields.Clear();
            _reports.Clear();
            

            try
            {
                // Read report ini file
                var lines = File.ReadAllLines(@fileName);
                var reportFound = false;
                var inReportFields = false;
                BindingList<BusinessField> bindingList = null;
                var reportName = string.Empty;

                // Iterate and look for reports
                foreach (var line in lines)
                {
                    // If a report was found [xxxxxxxx], look for the fields
                    if (reportFound)
                    {
                        // If fields were found #=..., process the fields
                        if (inReportFields)
                        {
                            // Evaluate to determine field, non-field or end of report fields

                            // End of report?
                            if (string.IsNullOrEmpty(line))
                            {
                                // Add to dictionary and reset
                                _reports.Add(reportName, bindingList);
                                reportFound = false;
                                inReportFields = false;
                                bindingList = null;
                                reportName = string.Empty;
                            }
                            else
                            {
                                // Add the field
                                AddReportField(line, bindingList);
                            }

                        }
                        else
                        {
                            // Is this the start of the report fields?
                            if (line.StartsWith("2="))
                            {
                                // The start of the report fields
                                inReportFields = true;

                                // Add the field
                                AddReportField(line, bindingList);
                            }
                        }
                    }
                    else
                    {
                        // Is this a report line?
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            // A report was found
                            reportFound = true;
                            reportName = line.Replace("[", "").Replace("]", "");
                            bindingList = new BindingList<BusinessField>();
                        }
                    }

                    // Get next line
                }

                // Set reports found into control
                var list = _reports.Keys.ToList();
                list.Sort();

                foreach (var key in list)
                {
                    cboReportKeys.Items.Add(key);
                }
            }
            catch
            {
                DisplayMessage(Properties.Resources.InvalidReportSetting, MessageBoxIcon.Error);
            }

        }

        /// <summary> Get report field info from line </summary>
        /// <param name="line">Line in file to be parsed</param>
        /// <param name="bindingList">Binding list containing field</param>
        private void AddReportField(string line, BindingList<BusinessField> bindingList)
        {
            try
            {
                // Split based upon '=' delimiter
                var parsedLine = line.Split('=');

                // Ensure it is a field (i.e. [0] will be numeric)
                if (Convert.ToInt32(parsedLine[0].Trim()) > 0)
                {
                    var parsedField = parsedLine[1].Split(' ');
                    var fieldName = parsedField[0].Trim().Replace("?", "");
                    var newFieldName = fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1).ToLower();

                    var businessField = new BusinessField
                    {
                        Id = Convert.ToInt32(parsedLine[0].Trim()),
                        ServerFieldName = fieldName,
                        Name = newFieldName,
                        Type = BusinessDataType.String
                    };

                    bindingList.Add(businessField);
                }
            }
            catch
            {
                // Non-numeric field ends up here and will be skipped
            }

        }

        /// <summary> Display fields for selected report</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void cboReportKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Locals
            var reportName = ((ComboBox) sender).Text;

            if (!string.IsNullOrEmpty(reportName))
            {
                _reportFields = _reports[reportName];
                grdReportFields.DataSource = _reportFields;
                txtReportProgramId.Text = reportName;
            }
        }
        
        /// <summary> Get Report Info from report.ini file</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnLoadIniFile_Click(object sender, EventArgs e)
        {
            // Get report information from ini file
            AddReports(txtReportIniFile.Text.Trim());
        }

        /// <summary> Report INI search dialog</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnIniDialog_Click(object sender, EventArgs e)
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
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtReportIniFile.Text = dialog.FileName.Trim();
                // Get report information from ini file
                AddReports(txtReportIniFile.Text);
            }
        }

        /// <summary> Output folder search dialog</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            // Init dialog
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            // Show the dialog and evaluate action
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = dialog.SelectedPath;
            }
        }

#endregion



    }
}
