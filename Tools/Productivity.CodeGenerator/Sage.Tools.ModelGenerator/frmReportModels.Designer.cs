namespace Sage.Tools.ModelGenerator
{
    partial class FrmReportModels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportModels));
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtReportDef = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblReportName = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.txtProgramId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.fbdOutputFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.grdResourceInfo = new System.Windows.Forms.DataGridView();
            this.sbrMain = new System.Windows.Forms.StatusStrip();
            this.lblProcessing = new System.Windows.Forms.ToolStripStatusLabel();
            this.proProcessing = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProcessingFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.wrkBackground = new System.ComponentModel.BackgroundWorker();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdResourceInfo)).BeginInit();
            this.sbrMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(349, 502);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(93, 28);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "&Proceed";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtReportDef
            // 
            this.txtReportDef.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportDef.Location = new System.Drawing.Point(12, 132);
            this.txtReportDef.Multiline = true;
            this.txtReportDef.Name = "txtReportDef";
            this.txtReportDef.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReportDef.Size = new System.Drawing.Size(323, 398);
            this.txtReportDef.TabIndex = 4;
            this.txtReportDef.Text = resources.GetString("txtReportDef.Text");
            this.txtReportDef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportDef_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(541, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(9, 17);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(70, 13);
            this.lblReportName.TabIndex = 3;
            this.lblReportName.Text = "Report Name";
            // 
            // txtReportName
            // 
            this.txtReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportName.Location = new System.Drawing.Point(89, 12);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(516, 23);
            this.txtReportName.TabIndex = 0;
            this.txtReportName.Text = "AgedPayablesReport";
            // 
            // txtProgramId
            // 
            this.txtProgramId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramId.Location = new System.Drawing.Point(89, 41);
            this.txtProgramId.Name = "txtProgramId";
            this.txtProgramId.Size = new System.Drawing.Size(516, 23);
            this.txtProgramId.TabIndex = 1;
            this.txtProgramId.Text = "AP7303";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Program Id";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(9, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "For field names with camel case, add hyphen. Eg: FROM-BATCH";
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Location = new System.Drawing.Point(611, 71);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(27, 21);
            this.btnOutputFolder.TabIndex = 3;
            this.btnOutputFolder.Text = "...";
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(9, 75);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(74, 13);
            this.lblOutputFolder.TabIndex = 10;
            this.lblOutputFolder.Text = "Output Folder:";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtOutputFolder.Location = new System.Drawing.Point(89, 70);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(516, 23);
            this.txtOutputFolder.TabIndex = 2;
            this.txtOutputFolder.Text = "C:\\Users\\rajarajan.d\\Desktop";
            // 
            // grdResourceInfo
            // 
            this.grdResourceInfo.AllowUserToAddRows = false;
            this.grdResourceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResourceInfo.Location = new System.Drawing.Point(341, 132);
            this.grdResourceInfo.Name = "grdResourceInfo";
            this.grdResourceInfo.Size = new System.Drawing.Size(297, 364);
            this.grdResourceInfo.TabIndex = 22;
            // 
            // sbrMain
            // 
            this.sbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProcessing,
            this.proProcessing,
            this.lblProcessingFile});
            this.sbrMain.Location = new System.Drawing.Point(0, 546);
            this.sbrMain.Name = "sbrMain";
            this.sbrMain.Size = new System.Drawing.Size(648, 22);
            this.sbrMain.TabIndex = 12;
            this.sbrMain.Text = "statusStrip1";
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = false;
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(200, 17);
            this.lblProcessing.Text = "Processing Placeholder";
            // 
            // proProcessing
            // 
            this.proProcessing.Name = "proProcessing";
            this.proProcessing.Size = new System.Drawing.Size(150, 16);
            this.proProcessing.Step = 1;
            // 
            // lblProcessingFile
            // 
            this.lblProcessingFile.Name = "lblProcessingFile";
            this.lblProcessingFile.Size = new System.Drawing.Size(125, 17);
            this.lblProcessingFile.Text = "File Name Placeholder";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(452, 502);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 28);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmReportModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(648, 568);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.sbrMain);
            this.Controls.Add(this.grdResourceInfo);
            this.Controls.Add(this.btnOutputFolder);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProgramId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReportName);
            this.Controls.Add(this.lblReportName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtReportDef);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmReportModels";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Files Generator";
            this.Load += new System.EventHandler(this.FrmReportModels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResourceInfo)).EndInit();
            this.sbrMain.ResumeLayout(false);
            this.sbrMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtReportDef;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.TextBox txtProgramId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdOutputFolder;
        private System.Windows.Forms.DataGridView grdResourceInfo;
        private System.Windows.Forms.StatusStrip sbrMain;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessing;
        private System.Windows.Forms.ToolStripProgressBar proProcessing;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessingFile;
        private System.ComponentModel.BackgroundWorker wrkBackground;
        private System.Windows.Forms.Button btnClear;
    }
}

