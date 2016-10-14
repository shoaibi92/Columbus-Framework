/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */
using System;

namespace Sage.CA.SBS.ERP.Sage300.DateTimeResearch
{
    partial class DateTimeResearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateTimeResearch));
            this.wrkBackground = new System.ComponentModel.BackgroundWorker();
            this.btnProceed = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.txtSourceDate = new System.Windows.Forms.TextBox();
            this.txtSourceOutput = new System.Windows.Forms.TextBox();
            this.lblSourceOutput = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.datTimePicker = new System.Windows.Forms.DateTimePicker();
            this.chkIncludeTime = new System.Windows.Forms.CheckBox();
            this.txtSourceFormat = new System.Windows.Forms.TextBox();
            this.lblSourceFormat = new System.Windows.Forms.Label();
            this.cboSourceTimezone = new System.Windows.Forms.ComboBox();
            this.lblSourceTimezone = new System.Windows.Forms.Label();
            this.lblSourceLocale = new System.Windows.Forms.Label();
            this.cboSourceLocale = new System.Windows.Forms.ComboBox();
            this.grpDestination = new System.Windows.Forms.GroupBox();
            this.txtDestinationOutput = new System.Windows.Forms.TextBox();
            this.lblDestinationOutput = new System.Windows.Forms.Label();
            this.txtDestinationFormat = new System.Windows.Forms.TextBox();
            this.lblDestinationFormat = new System.Windows.Forms.Label();
            this.cboDestinationTimezone = new System.Windows.Forms.ComboBox();
            this.lblDestinationTimezone = new System.Windows.Forms.Label();
            this.lblDestinationLocale = new System.Windows.Forms.Label();
            this.cboDestinationLocale = new System.Windows.Forms.ComboBox();
            this.txtDestinationDate = new System.Windows.Forms.TextBox();
            this.txtSourceDateYYYYMMDD = new System.Windows.Forms.TextBox();
            this.txtDestinationDateYYYYMMDD = new System.Windows.Forms.TextBox();
            this.tbrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.grpDestination.SuspendLayout();
            this.SuspendLayout();
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
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
            // tbrMain
            // 
            this.tbrMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProceed,
            this.btnExit,
            this.toolStripSeparator1,
            this.btnHelp});
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(621, 27);
            this.tbrMain.TabIndex = 0;
            this.tbrMain.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpDestination);
            this.splitContainer1.Size = new System.Drawing.Size(621, 266);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 15;
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.txtSourceDateYYYYMMDD);
            this.grpSource.Controls.Add(this.txtSourceDate);
            this.grpSource.Controls.Add(this.txtSourceOutput);
            this.grpSource.Controls.Add(this.lblSourceOutput);
            this.grpSource.Controls.Add(this.lblDate);
            this.grpSource.Controls.Add(this.datTimePicker);
            this.grpSource.Controls.Add(this.chkIncludeTime);
            this.grpSource.Controls.Add(this.txtSourceFormat);
            this.grpSource.Controls.Add(this.lblSourceFormat);
            this.grpSource.Controls.Add(this.cboSourceTimezone);
            this.grpSource.Controls.Add(this.lblSourceTimezone);
            this.grpSource.Controls.Add(this.lblSourceLocale);
            this.grpSource.Controls.Add(this.cboSourceLocale);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSource.Location = new System.Drawing.Point(0, 0);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(309, 266);
            this.grpSource.TabIndex = 0;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // txtSourceDate
            // 
            this.txtSourceDate.Location = new System.Drawing.Point(59, 190);
            this.txtSourceDate.Name = "txtSourceDate";
            this.txtSourceDate.ReadOnly = true;
            this.txtSourceDate.Size = new System.Drawing.Size(219, 20);
            this.txtSourceDate.TabIndex = 23;
            // 
            // txtSourceOutput
            // 
            this.txtSourceOutput.Location = new System.Drawing.Point(60, 164);
            this.txtSourceOutput.Name = "txtSourceOutput";
            this.txtSourceOutput.ReadOnly = true;
            this.txtSourceOutput.Size = new System.Drawing.Size(218, 20);
            this.txtSourceOutput.TabIndex = 22;
            // 
            // lblSourceOutput
            // 
            this.lblSourceOutput.AutoSize = true;
            this.lblSourceOutput.Location = new System.Drawing.Point(12, 167);
            this.lblSourceOutput.Name = "lblSourceOutput";
            this.lblSourceOutput.Size = new System.Drawing.Size(42, 13);
            this.lblSourceOutput.TabIndex = 21;
            this.lblSourceOutput.Text = "Output:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(21, 140);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 20;
            this.lblDate.Text = "Date:";
            // 
            // datTimePicker
            // 
            this.datTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datTimePicker.Location = new System.Drawing.Point(60, 138);
            this.datTimePicker.Name = "datTimePicker";
            this.datTimePicker.Size = new System.Drawing.Size(137, 20);
            this.datTimePicker.TabIndex = 19;
            this.datTimePicker.ValueChanged += new System.EventHandler(this.datTimePicker_ValueChanged);
            this.datTimePicker.Validated += new System.EventHandler(this.datTimePicker_Validated);
            // 
            // chkIncludeTime
            // 
            this.chkIncludeTime.AutoSize = true;
            this.chkIncludeTime.Location = new System.Drawing.Point(60, 115);
            this.chkIncludeTime.Name = "chkIncludeTime";
            this.chkIncludeTime.Size = new System.Drawing.Size(87, 17);
            this.chkIncludeTime.TabIndex = 18;
            this.chkIncludeTime.Text = "Include Time";
            this.chkIncludeTime.UseVisualStyleBackColor = true;
            // 
            // txtSourceFormat
            // 
            this.txtSourceFormat.Location = new System.Drawing.Point(60, 89);
            this.txtSourceFormat.Name = "txtSourceFormat";
            this.txtSourceFormat.ReadOnly = true;
            this.txtSourceFormat.Size = new System.Drawing.Size(221, 20);
            this.txtSourceFormat.TabIndex = 17;
            // 
            // lblSourceFormat
            // 
            this.lblSourceFormat.AutoSize = true;
            this.lblSourceFormat.Location = new System.Drawing.Point(12, 89);
            this.lblSourceFormat.Name = "lblSourceFormat";
            this.lblSourceFormat.Size = new System.Drawing.Size(42, 13);
            this.lblSourceFormat.TabIndex = 16;
            this.lblSourceFormat.Text = "Format:";
            // 
            // cboSourceTimezone
            // 
            this.cboSourceTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceTimezone.FormattingEnabled = true;
            this.cboSourceTimezone.Location = new System.Drawing.Point(60, 60);
            this.cboSourceTimezone.Name = "cboSourceTimezone";
            this.cboSourceTimezone.Size = new System.Drawing.Size(221, 21);
            this.cboSourceTimezone.TabIndex = 15;
            // 
            // lblSourceTimezone
            // 
            this.lblSourceTimezone.AutoSize = true;
            this.lblSourceTimezone.Location = new System.Drawing.Point(6, 63);
            this.lblSourceTimezone.Name = "lblSourceTimezone";
            this.lblSourceTimezone.Size = new System.Drawing.Size(56, 13);
            this.lblSourceTimezone.TabIndex = 14;
            this.lblSourceTimezone.Text = "Timezone:";
            this.lblSourceTimezone.Click += new System.EventHandler(this.lblSourceTimezone_Click);
            // 
            // lblSourceLocale
            // 
            this.lblSourceLocale.AutoSize = true;
            this.lblSourceLocale.Location = new System.Drawing.Point(12, 30);
            this.lblSourceLocale.Name = "lblSourceLocale";
            this.lblSourceLocale.Size = new System.Drawing.Size(42, 13);
            this.lblSourceLocale.TabIndex = 12;
            this.lblSourceLocale.Text = "Locale:";
            // 
            // cboSourceLocale
            // 
            this.cboSourceLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceLocale.FormattingEnabled = true;
            this.cboSourceLocale.Location = new System.Drawing.Point(60, 27);
            this.cboSourceLocale.Name = "cboSourceLocale";
            this.cboSourceLocale.Size = new System.Drawing.Size(221, 21);
            this.cboSourceLocale.TabIndex = 13;
            this.cboSourceLocale.SelectedIndexChanged += new System.EventHandler(this.cboSourceLocale_SelectedIndexChanged);
            // 
            // grpDestination
            // 
            this.grpDestination.Controls.Add(this.txtDestinationDateYYYYMMDD);
            this.grpDestination.Controls.Add(this.txtDestinationDate);
            this.grpDestination.Controls.Add(this.txtDestinationOutput);
            this.grpDestination.Controls.Add(this.lblDestinationOutput);
            this.grpDestination.Controls.Add(this.txtDestinationFormat);
            this.grpDestination.Controls.Add(this.lblDestinationFormat);
            this.grpDestination.Controls.Add(this.cboDestinationTimezone);
            this.grpDestination.Controls.Add(this.lblDestinationTimezone);
            this.grpDestination.Controls.Add(this.lblDestinationLocale);
            this.grpDestination.Controls.Add(this.cboDestinationLocale);
            this.grpDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDestination.Location = new System.Drawing.Point(0, 0);
            this.grpDestination.Name = "grpDestination";
            this.grpDestination.Size = new System.Drawing.Size(308, 266);
            this.grpDestination.TabIndex = 16;
            this.grpDestination.TabStop = false;
            this.grpDestination.Text = "Destination";
            // 
            // txtDestinationOutput
            // 
            this.txtDestinationOutput.Location = new System.Drawing.Point(60, 164);
            this.txtDestinationOutput.Name = "txtDestinationOutput";
            this.txtDestinationOutput.ReadOnly = true;
            this.txtDestinationOutput.Size = new System.Drawing.Size(215, 20);
            this.txtDestinationOutput.TabIndex = 23;
            // 
            // lblDestinationOutput
            // 
            this.lblDestinationOutput.AutoSize = true;
            this.lblDestinationOutput.Location = new System.Drawing.Point(13, 167);
            this.lblDestinationOutput.Name = "lblDestinationOutput";
            this.lblDestinationOutput.Size = new System.Drawing.Size(42, 13);
            this.lblDestinationOutput.TabIndex = 22;
            this.lblDestinationOutput.Text = "Output:";
            // 
            // txtDestinationFormat
            // 
            this.txtDestinationFormat.Location = new System.Drawing.Point(60, 89);
            this.txtDestinationFormat.Name = "txtDestinationFormat";
            this.txtDestinationFormat.ReadOnly = true;
            this.txtDestinationFormat.Size = new System.Drawing.Size(221, 20);
            this.txtDestinationFormat.TabIndex = 21;
            // 
            // lblDestinationFormat
            // 
            this.lblDestinationFormat.AutoSize = true;
            this.lblDestinationFormat.Location = new System.Drawing.Point(12, 92);
            this.lblDestinationFormat.Name = "lblDestinationFormat";
            this.lblDestinationFormat.Size = new System.Drawing.Size(42, 13);
            this.lblDestinationFormat.TabIndex = 20;
            this.lblDestinationFormat.Text = "Format:";
            // 
            // cboDestinationTimezone
            // 
            this.cboDestinationTimezone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinationTimezone.FormattingEnabled = true;
            this.cboDestinationTimezone.Location = new System.Drawing.Point(60, 60);
            this.cboDestinationTimezone.Name = "cboDestinationTimezone";
            this.cboDestinationTimezone.Size = new System.Drawing.Size(221, 21);
            this.cboDestinationTimezone.TabIndex = 19;
            // 
            // lblDestinationTimezone
            // 
            this.lblDestinationTimezone.AutoSize = true;
            this.lblDestinationTimezone.Location = new System.Drawing.Point(6, 63);
            this.lblDestinationTimezone.Name = "lblDestinationTimezone";
            this.lblDestinationTimezone.Size = new System.Drawing.Size(56, 13);
            this.lblDestinationTimezone.TabIndex = 18;
            this.lblDestinationTimezone.Text = "Timezone:";
            // 
            // lblDestinationLocale
            // 
            this.lblDestinationLocale.AutoSize = true;
            this.lblDestinationLocale.Location = new System.Drawing.Point(12, 30);
            this.lblDestinationLocale.Name = "lblDestinationLocale";
            this.lblDestinationLocale.Size = new System.Drawing.Size(42, 13);
            this.lblDestinationLocale.TabIndex = 16;
            this.lblDestinationLocale.Text = "Locale:";
            // 
            // cboDestinationLocale
            // 
            this.cboDestinationLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinationLocale.FormattingEnabled = true;
            this.cboDestinationLocale.Location = new System.Drawing.Point(60, 27);
            this.cboDestinationLocale.Name = "cboDestinationLocale";
            this.cboDestinationLocale.Size = new System.Drawing.Size(221, 21);
            this.cboDestinationLocale.TabIndex = 17;
            this.cboDestinationLocale.SelectedIndexChanged += new System.EventHandler(this.cboDestinationLocale_SelectedIndexChanged);
            // 
            // txtDestinationDate
            // 
            this.txtDestinationDate.Location = new System.Drawing.Point(60, 193);
            this.txtDestinationDate.Name = "txtDestinationDate";
            this.txtDestinationDate.ReadOnly = true;
            this.txtDestinationDate.Size = new System.Drawing.Size(214, 20);
            this.txtDestinationDate.TabIndex = 24;
            // 
            // txtSourceDateYYYYMMDD
            // 
            this.txtSourceDateYYYYMMDD.Location = new System.Drawing.Point(59, 216);
            this.txtSourceDateYYYYMMDD.Name = "txtSourceDateYYYYMMDD";
            this.txtSourceDateYYYYMMDD.ReadOnly = true;
            this.txtSourceDateYYYYMMDD.Size = new System.Drawing.Size(219, 20);
            this.txtSourceDateYYYYMMDD.TabIndex = 24;
            // 
            // txtDestinationDateYYYYMMDD
            // 
            this.txtDestinationDateYYYYMMDD.Location = new System.Drawing.Point(61, 223);
            this.txtDestinationDateYYYYMMDD.Name = "txtDestinationDateYYYYMMDD";
            this.txtDestinationDateYYYYMMDD.ReadOnly = true;
            this.txtDestinationDateYYYYMMDD.Size = new System.Drawing.Size(213, 20);
            this.txtDestinationDateYYYYMMDD.TabIndex = 25;
            // 
            // DateTimeResearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 293);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tbrMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DateTimeResearch";
            this.Text = "Date Time POC";
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grpDestination.ResumeLayout(false);
            this.grpDestination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker wrkBackground;
        private System.Windows.Forms.ToolStripButton btnProceed;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblSourceLocale;
        private System.Windows.Forms.ComboBox cboSourceLocale;
        private System.Windows.Forms.Label lblSourceTimezone;
        private System.Windows.Forms.GroupBox grpDestination;
        private System.Windows.Forms.Label lblDestinationTimezone;
        private System.Windows.Forms.Label lblDestinationLocale;
        private System.Windows.Forms.ComboBox cboDestinationLocale;
        private System.Windows.Forms.ComboBox cboSourceTimezone;
        private System.Windows.Forms.ComboBox cboDestinationTimezone;
        private System.Windows.Forms.TextBox txtSourceFormat;
        private System.Windows.Forms.Label lblSourceFormat;
        private System.Windows.Forms.TextBox txtDestinationFormat;
        private System.Windows.Forms.Label lblDestinationFormat;
        private System.Windows.Forms.DateTimePicker datTimePicker;
        private System.Windows.Forms.CheckBox chkIncludeTime;
        private System.Windows.Forms.TextBox txtSourceOutput;
        private System.Windows.Forms.Label lblSourceOutput;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDestinationOutput;
        private System.Windows.Forms.Label lblDestinationOutput;
        private System.Windows.Forms.TextBox txtSourceDate;
        private System.Windows.Forms.TextBox txtDestinationDate;
        private System.Windows.Forms.TextBox txtSourceDateYYYYMMDD;
        private System.Windows.Forms.TextBox txtDestinationDateYYYYMMDD;
    }
}

