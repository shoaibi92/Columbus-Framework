using System;
using System.Diagnostics;
using System.Windows.Forms;
using Sage.Tools.ModelGenerator.Reports;
using System.ComponentModel;

namespace Sage.Tools.ModelGenerator
{
    public partial class FrmReportModels : Form
    {

        #region Private Variables
        ///// <summary> Process Generation logic </summary>
        //private ProcessGeneration _generation;

        /// <summary> Information processed </summary>
        private readonly BindingList<Info> _gridInfo = new BindingList<Info>();

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
        
        public FrmReportModels()
        {
            InitializeComponent();
            InitInfo();
            InitEvents();
            ClearAllFields();
        }

        #endregion

        #region Events

        /// <summary> Initialize events for process generation class </summary>
        private void InitEvents()
        {
            ReportModelCreator.ProcessingEvent += ProcessingEvent;
            ReportModelCreator.StatusEvent += StatusEvent;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidateInputs()) return;
            var outputFolder = txtOutputFolder.Text.Trim() + "\\" + txtReportName.Text.Trim();

            try
            {
                var reportDefinition = ReportInputParser.Parse(txtReportDef.Text.Trim(), txtReportName.Text.Trim(),
                    txtProgramId.Text.Trim(), outputFolder);
                grdResourceInfo.Rows.Clear();
                ReportModelCreator.CreateModels(reportDefinition);

                grdResourceInfo.DataSource = _gridInfo;
                grdResourceInfo.Refresh();
            }
            catch (Exception ex)
            {
                ShowError(ex.ToString());
                return;
            }

            var msgResult =
                MessageBox.Show(string.Format("Files created successfully in the following path: \n{0}\n\nDo you want to open this folder?", outputFolder),
                    @"Report Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msgResult.Equals(DialogResult.Yes))
            {
                Process.Start(@outputFolder);
            }
            proProcessing.Value = 0;
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtReportDef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                txtReportDef.SelectAll();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            if (fbdOutputFolder.ShowDialog().Equals(DialogResult.OK))
            {
                txtOutputFolder.Text = fbdOutputFolder.SelectedPath;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        #endregion

        #region Private methods

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtReportName.Text))
            {
                ShowError("Please enter report Name!");
                return false;
            }

            if (string.IsNullOrEmpty(txtProgramId.Text))
            {
                ShowError("Please enter report Program Id !");
                return false;
            }

            if (string.IsNullOrEmpty(txtReportDef.Text))
            {
                ShowError("Please enter report definition text!");
                return false;
            }

            if (string.IsNullOrEmpty(txtOutputFolder.Text))
            {
                ShowError("Please select the output folder!");
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, caption: @"Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }

        /// <summary> Initialize info and modify grid display </summary>
        private void InitInfo()
        {
            // Assign binding to datasource (two binding)
            grdResourceInfo.DataSource = _gridInfo;

            // Assign widths and localized text
            grdResourceInfo.Columns[Info.FileNameColumnNo].Width = 200;
            grdResourceInfo.Columns[Info.FileNameColumnNo].HeaderText = Properties.Resources.FileName;

            grdResourceInfo.Columns[Info.StatusColumnNo].Width = 50;
            grdResourceInfo.Columns[Info.StatusColumnNo].ReadOnly = true;
            grdResourceInfo.Columns[Info.StatusColumnNo].HeaderText = Properties.Resources.Status;
        }

        /// <summary> Update status display </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="statusType">Status Type</param>
        /// <param name="text">Text for UI</param>
        /// <remarks>Invoked from threaded process</remarks>
        private void Status(string fileName, Info.StatusType statusType, string text)
        {
            // Add to info list
            var info = new Info
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

        /// <summary> Update processing display </summary>
        /// <param name="text">Text to display in status bar</param>
        /// <remarks>Invoked from threaded process</remarks>
        private void ProcessingEvent(string text)
        {
            var callBack = new ProcessingCallback(Processing);
            Invoke(callBack, new object[] { text });
        }

        /// <summary> Update processing display in status bar </summary>
        /// <param name="text">Text to display in status bar</param>
        private void Processing(string text)
        {
            lblProcessingFile.Text = text;

            if (proProcessing.Maximum != 0)
            {
                proProcessing.Value += 25;
            }

            sbrMain.Refresh();
        }

        /// <summary>
        /// Clear all the fields
        /// </summary>
        private void ClearAllFields()
        {
            txtReportName.Clear();
            txtReportDef.Clear();
            txtProgramId.Clear();
            txtOutputFolder.Clear();
            proProcessing.Value = 0;
            _rowIndex = -1;
            grdResourceInfo.Rows.Clear();
            txtReportName.Focus();
        }

        private void FrmReportModels_Load(object sender, EventArgs e)
        {

            // OBSOLETE
            Show();
            MessageBox.Show("Obsolete!! Use Class Generation Utility", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();

        }

        /* This method is not used, so commenting */
        //private void ShowInfo(string message)
        //{
        //    MessageBox.Show(message, caption: @"Information", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        //}

        /* This method is not used, so commenting */
        //private void ShowWarning(string message)
        //{
        //    MessageBox.Show(message, caption: @"Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
        //}

        #endregion
    }
}
