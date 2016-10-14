/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using System;

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    partial class DatabaseUpgrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseUpgrade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.btnProceed = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.splitBase = new System.Windows.Forms.SplitContainer();
            this.numAttempts = new System.Windows.Forms.NumericUpDown();
            this.lblAttempts = new System.Windows.Forms.Label();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.btnScriptDialog = new System.Windows.Forms.Button();
            this.txtTranName = new System.Windows.Forms.TextBox();
            this.txtScriptFile = new System.Windows.Forms.TextBox();
            this.lblScript = new System.Windows.Forms.Label();
            this.lblThreads = new System.Windows.Forms.Label();
            this.lblTranName = new System.Windows.Forms.Label();
            this.sbrMain = new System.Windows.Forms.StatusStrip();
            this.grpTenants = new System.Windows.Forms.GroupBox();
            this.grdTenants = new System.Windows.Forms.DataGridView();
            this.lblProcessing = new System.Windows.Forms.ToolStripStatusLabel();
            this.proProcessing = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProcessingFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBase)).BeginInit();
            this.splitBase.Panel1.SuspendLayout();
            this.splitBase.Panel2.SuspendLayout();
            this.splitBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.grpTenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTenants)).BeginInit();
            this.SuspendLayout();
            // 
            // tbrMain
            // 
            this.tbrMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProceed,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnExit,
            this.toolStripSeparator2,
            this.btnShowScript,
            this.toolStripSeparator3,
            this.btnHelp});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(1222, 27);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "toolStrip1";
            // 
            // btnProceed
            // 
            this.btnProceed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProceed.Image = ((System.Drawing.Image)(resources.GetObject("btnProceed.Image")));
            this.btnProceed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(24, 24);
            this.btnProceed.Text = "Proceed";
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(24, 24);
            this.btnCancel.Text = "Cancel Processing";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 24);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnShowScript
            // 
            this.btnShowScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowScript.Image = ((System.Drawing.Image)(resources.GetObject("btnShowScript.Image")));
            this.btnShowScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowScript.Name = "btnShowScript";
            this.btnShowScript.Size = new System.Drawing.Size(24, 24);
            this.btnShowScript.Text = "Show Script";
            this.btnShowScript.Click += new System.EventHandler(this.btnShowScript_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 24);
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // splitBase
            // 
            this.splitBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitBase.IsSplitterFixed = true;
            this.splitBase.Location = new System.Drawing.Point(0, 27);
            this.splitBase.Name = "splitBase";
            this.splitBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitBase.Panel1
            // 
            this.splitBase.Panel1.Controls.Add(this.numAttempts);
            this.splitBase.Panel1.Controls.Add(this.lblAttempts);
            this.splitBase.Panel1.Controls.Add(this.numThreads);
            this.splitBase.Panel1.Controls.Add(this.btnScriptDialog);
            this.splitBase.Panel1.Controls.Add(this.txtTranName);
            this.splitBase.Panel1.Controls.Add(this.txtScriptFile);
            this.splitBase.Panel1.Controls.Add(this.lblScript);
            this.splitBase.Panel1.Controls.Add(this.lblThreads);
            this.splitBase.Panel1.Controls.Add(this.lblTranName);
            // 
            // splitBase.Panel2
            // 
            this.splitBase.Panel2.Controls.Add(this.sbrMain);
            this.splitBase.Panel2.Controls.Add(this.grpTenants);
            this.splitBase.Size = new System.Drawing.Size(1222, 587);
            this.splitBase.TabIndex = 1;
            // 
            // numAttempts
            // 
            this.numAttempts.Location = new System.Drawing.Point(177, 16);
            this.numAttempts.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAttempts.Name = "numAttempts";
            this.numAttempts.Size = new System.Drawing.Size(36, 20);
            this.numAttempts.TabIndex = 4;
            this.numAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAttempts
            // 
            this.lblAttempts.AutoSize = true;
            this.lblAttempts.Location = new System.Drawing.Point(120, 17);
            this.lblAttempts.Name = "lblAttempts";
            this.lblAttempts.Size = new System.Drawing.Size(51, 13);
            this.lblAttempts.TabIndex = 3;
            this.lblAttempts.Text = "Attempts:";
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(67, 15);
            this.numThreads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(36, 20);
            this.numThreads.TabIndex = 2;
            this.numThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnScriptDialog
            // 
            this.btnScriptDialog.Location = new System.Drawing.Point(1134, 15);
            this.btnScriptDialog.Name = "btnScriptDialog";
            this.btnScriptDialog.Size = new System.Drawing.Size(25, 20);
            this.btnScriptDialog.TabIndex = 9;
            this.btnScriptDialog.Text = "...";
            this.btnScriptDialog.UseVisualStyleBackColor = true;
            this.btnScriptDialog.Click += new System.EventHandler(this.btnScriptDialog_Click);
            // 
            // txtTranName
            // 
            this.txtTranName.Location = new System.Drawing.Point(336, 15);
            this.txtTranName.Name = "txtTranName";
            this.txtTranName.Size = new System.Drawing.Size(189, 20);
            this.txtTranName.TabIndex = 6;
            // 
            // txtScriptFile
            // 
            this.txtScriptFile.Enabled = false;
            this.txtScriptFile.Location = new System.Drawing.Point(613, 15);
            this.txtScriptFile.Name = "txtScriptFile";
            this.txtScriptFile.Size = new System.Drawing.Size(515, 20);
            this.txtScriptFile.TabIndex = 8;
            this.txtScriptFile.TabStop = false;
            // 
            // lblScript
            // 
            this.lblScript.AutoSize = true;
            this.lblScript.Location = new System.Drawing.Point(551, 17);
            this.lblScript.Name = "lblScript";
            this.lblScript.Size = new System.Drawing.Size(56, 13);
            this.lblScript.TabIndex = 7;
            this.lblScript.Text = "Script File:";
            // 
            // lblThreads
            // 
            this.lblThreads.AutoSize = true;
            this.lblThreads.Location = new System.Drawing.Point(12, 17);
            this.lblThreads.Name = "lblThreads";
            this.lblThreads.Size = new System.Drawing.Size(49, 13);
            this.lblThreads.TabIndex = 1;
            this.lblThreads.Text = "Threads:";
            // 
            // lblTranName
            // 
            this.lblTranName.AutoSize = true;
            this.lblTranName.Location = new System.Drawing.Point(233, 17);
            this.lblTranName.Name = "lblTranName";
            this.lblTranName.Size = new System.Drawing.Size(97, 13);
            this.lblTranName.TabIndex = 5;
            this.lblTranName.Text = "Transaction Name:";
            // 
            // sbrMain
            // 
            this.sbrMain.Location = new System.Drawing.Point(0, 511);
            this.sbrMain.Name = "sbrMain";
            this.sbrMain.Size = new System.Drawing.Size(1222, 22);
            this.sbrMain.TabIndex = 29;
            this.sbrMain.Text = "statusStrip1";
            // 
            // grpTenants
            // 
            this.grpTenants.Controls.Add(this.grdTenants);
            this.grpTenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTenants.Location = new System.Drawing.Point(0, 0);
            this.grpTenants.Name = "grpTenants";
            this.grpTenants.Size = new System.Drawing.Size(1222, 533);
            this.grpTenants.TabIndex = 28;
            this.grpTenants.TabStop = false;
            // 
            // grdTenants
            // 
            this.grdTenants.AllowUserToAddRows = false;
            this.grdTenants.AllowUserToDeleteRows = false;
            this.grdTenants.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdTenants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTenants.Location = new System.Drawing.Point(3, 16);
            this.grdTenants.Name = "grdTenants";
            this.grdTenants.RowHeadersVisible = false;
            this.grdTenants.RowHeadersWidth = 30;
            this.grdTenants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTenants.Size = new System.Drawing.Size(1216, 514);
            this.grdTenants.TabIndex = 11;
            this.grdTenants.TabStop = false;
            this.grdTenants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTenants_CellContentClick);
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
            // DatabaseUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 614);
            this.Controls.Add(this.splitBase);
            this.Controls.Add(this.tbrMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseUpgrade";
            this.Text = "Database Upgrade Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseUpgrade_FormClosing);
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.splitBase.Panel1.ResumeLayout(false);
            this.splitBase.Panel1.PerformLayout();
            this.splitBase.Panel2.ResumeLayout(false);
            this.splitBase.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBase)).EndInit();
            this.splitBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.grpTenants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTenants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.SplitContainer splitBase;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Button btnScriptDialog;
        private System.Windows.Forms.TextBox txtTranName;
        private System.Windows.Forms.TextBox txtScriptFile;
        private System.Windows.Forms.Label lblScript;
        private System.Windows.Forms.Label lblThreads;
        private System.Windows.Forms.Label lblTranName;
        public System.Windows.Forms.DataGridView grdTenants;
        private System.Windows.Forms.GroupBox grpTenants;
        private System.Windows.Forms.StatusStrip sbrMain;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessing;
        private System.Windows.Forms.ToolStripProgressBar proProcessing;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessingFile;
        private System.Windows.Forms.NumericUpDown numAttempts;
        private System.Windows.Forms.Label lblAttempts;
        private System.Windows.Forms.ToolStripButton btnProceed;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnShowScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnHelp;
    }
}

