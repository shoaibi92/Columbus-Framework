namespace TokenGenerator
{
    partial class MainForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScope = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpiryTime = new System.Windows.Forms.TextBox();
            this.btnGetTenants = new System.Windows.Forms.Button();
            this.gridTenants = new System.Windows.Forms.DataGridView();
            this.labelTenants = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTenants)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.AutoSize = true;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGenerate.Location = new System.Drawing.Point(16, 112);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(649, 79);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate Access Token";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnReset.Location = new System.Drawing.Point(673, 112);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(649, 79);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Access Token";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtClientID
            // 
            this.txtClientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtClientID.Location = new System.Drawing.Point(144, 15);
            this.txtClientID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtClientID.Size = new System.Drawing.Size(1179, 24);
            this.txtClientID.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(36, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Client ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScope
            // 
            this.txtScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtScope.Location = new System.Drawing.Point(144, 47);
            this.txtScope.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtScope.Name = "txtScope";
            this.txtScope.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtScope.Size = new System.Drawing.Size(1179, 24);
            this.txtScope.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(57, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Scope:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPath.Location = new System.Drawing.Point(144, 79);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPath.Size = new System.Drawing.Size(1179, 24);
            this.txtPath.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(11, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Token Path:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtToken
            // 
            this.txtToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtToken.Location = new System.Drawing.Point(16, 223);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtToken.Name = "txtToken";
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtToken.Size = new System.Drawing.Size(1307, 24);
            this.txtToken.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(11, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Access Token:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(11, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Expiry Time:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExpiryTime
            // 
            this.txtExpiryTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtExpiryTime.Location = new System.Drawing.Point(15, 281);
            this.txtExpiryTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExpiryTime.Name = "txtExpiryTime";
            this.txtExpiryTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtExpiryTime.Size = new System.Drawing.Size(1307, 24);
            this.txtExpiryTime.TabIndex = 13;
            // 
            // btnGetTenants
            // 
            this.btnGetTenants.AutoSize = true;
            this.btnGetTenants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetTenants.Location = new System.Drawing.Point(15, 314);
            this.btnGetTenants.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetTenants.Name = "btnGetTenants";
            this.btnGetTenants.Size = new System.Drawing.Size(1309, 79);
            this.btnGetTenants.TabIndex = 15;
            this.btnGetTenants.Text = "Get Tenants Per Login?";
            this.btnGetTenants.UseVisualStyleBackColor = true;
            this.btnGetTenants.Visible = false;
            this.btnGetTenants.Click += new System.EventHandler(this.btnGetTenants_Click);
            // 
            // gridTenants
            // 
            this.gridTenants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTenants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridTenants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTenants.Location = new System.Drawing.Point(15, 422);
            this.gridTenants.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridTenants.Name = "gridTenants";
            this.gridTenants.Size = new System.Drawing.Size(1308, 170);
            this.gridTenants.TabIndex = 16;
            this.gridTenants.Visible = false;
            // 
            // labelTenants
            // 
            this.labelTenants.AutoSize = true;
            this.labelTenants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTenants.Location = new System.Drawing.Point(12, 394);
            this.labelTenants.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTenants.Name = "labelTenants";
            this.labelTenants.Size = new System.Drawing.Size(246, 25);
            this.labelTenants.TabIndex = 17;
            this.labelTenants.Text = "List of Accessible Tenants:";
            this.labelTenants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTenants.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1336, 602);
            this.Controls.Add(this.labelTenants);
            this.Controls.Add(this.gridTenants);
            this.Controls.Add(this.btnGetTenants);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtExpiryTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtScope);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Text = "Token Generator Application";
            ((System.ComponentModel.ISupportInitialize)(this.gridTenants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScope;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExpiryTime;
        private System.Windows.Forms.Button btnGetTenants;
        private System.Windows.Forms.DataGridView gridTenants;
        private System.Windows.Forms.Label labelTenants;
    }
}

