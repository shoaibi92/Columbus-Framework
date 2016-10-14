namespace EncryptString
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblCertName = new System.Windows.Forms.Label();
            this.txtDecryptedSensitiveData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDecryptByThumbprint = new System.Windows.Forms.Button();
            this.txtSensitiveData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEncryptByThumbprint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEncryptText = new System.Windows.Forms.TextBox();
            this.txtCertThumbprint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(899, 388);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblCertName);
            this.tabPage1.Controls.Add(this.txtDecryptedSensitiveData);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btnDecryptByThumbprint);
            this.tabPage1.Controls.Add(this.txtSensitiveData);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnEncryptByThumbprint);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtEncryptText);
            this.tabPage1.Controls.Add(this.txtCertThumbprint);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(891, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Encrypt/Decrypt by Thumbprint";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblCertName
            // 
            this.lblCertName.AutoSize = true;
            this.lblCertName.Location = new System.Drawing.Point(98, 26);
            this.lblCertName.Name = "lblCertName";
            this.lblCertName.Size = new System.Drawing.Size(0, 13);
            this.lblCertName.TabIndex = 10;
            // 
            // txtDecryptedSensitiveData
            // 
            this.txtDecryptedSensitiveData.Location = new System.Drawing.Point(112, 265);
            this.txtDecryptedSensitiveData.Name = "txtDecryptedSensitiveData";
            this.txtDecryptedSensitiveData.Size = new System.Drawing.Size(583, 20);
            this.txtDecryptedSensitiveData.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Decrypted Text";
            // 
            // btnDecryptByThumbprint
            // 
            this.btnDecryptByThumbprint.Location = new System.Drawing.Point(700, 78);
            this.btnDecryptByThumbprint.Name = "btnDecryptByThumbprint";
            this.btnDecryptByThumbprint.Size = new System.Drawing.Size(114, 23);
            this.btnDecryptByThumbprint.TabIndex = 7;
            this.btnDecryptByThumbprint.Text = "Decrypt";
            this.btnDecryptByThumbprint.UseVisualStyleBackColor = true;
            this.btnDecryptByThumbprint.Click += new System.EventHandler(this.btnDecryptByThumbprint_Click);
            // 
            // txtSensitiveData
            // 
            this.txtSensitiveData.Location = new System.Drawing.Point(101, 80);
            this.txtSensitiveData.Name = "txtSensitiveData";
            this.txtSensitiveData.Size = new System.Drawing.Size(583, 20);
            this.txtSensitiveData.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sensitive Data";
            // 
            // btnEncryptByThumbprint
            // 
            this.btnEncryptByThumbprint.Location = new System.Drawing.Point(700, 46);
            this.btnEncryptByThumbprint.Name = "btnEncryptByThumbprint";
            this.btnEncryptByThumbprint.Size = new System.Drawing.Size(114, 23);
            this.btnEncryptByThumbprint.TabIndex = 4;
            this.btnEncryptByThumbprint.Text = "Encrypt";
            this.btnEncryptByThumbprint.UseVisualStyleBackColor = true;
            this.btnEncryptByThumbprint.Click += new System.EventHandler(this.btnEncryptByCert_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Encrypt Text";
            // 
            // txtEncryptText
            // 
            this.txtEncryptText.Location = new System.Drawing.Point(101, 109);
            this.txtEncryptText.Multiline = true;
            this.txtEncryptText.Name = "txtEncryptText";
            this.txtEncryptText.Size = new System.Drawing.Size(583, 141);
            this.txtEncryptText.TabIndex = 6;
            // 
            // txtCertThumbprint
            // 
            this.txtCertThumbprint.Location = new System.Drawing.Point(101, 48);
            this.txtCertThumbprint.Name = "txtCertThumbprint";
            this.txtCertThumbprint.Size = new System.Drawing.Size(583, 20);
            this.txtCertThumbprint.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cert Thumbprint";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 396);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Encryption Tool";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEncryptText;
        private System.Windows.Forms.TextBox txtCertThumbprint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEncryptByThumbprint;
        private System.Windows.Forms.TextBox txtSensitiveData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDecryptedSensitiveData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDecryptByThumbprint;
        private System.Windows.Forms.Label lblCertName;
    }
}

