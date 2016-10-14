namespace AzureMonitor
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.btnClearDefaultCache = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(49, 82);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(184, 74);
            this.btnClearCache.TabIndex = 1;
            this.btnClearCache.Text = "Clear Cache";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // btnClearDefaultCache
            // 
            this.btnClearDefaultCache.Location = new System.Drawing.Point(49, 166);
            this.btnClearDefaultCache.Name = "btnClearDefaultCache";
            this.btnClearDefaultCache.Size = new System.Drawing.Size(184, 78);
            this.btnClearDefaultCache.TabIndex = 2;
            this.btnClearDefaultCache.Text = "Clear Default Cache";
            this.btnClearDefaultCache.UseVisualStyleBackColor = true;
            this.btnClearDefaultCache.Click += new System.EventHandler(this.btnClearDefaultCache_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 256);
            this.Controls.Add(this.btnClearDefaultCache);
            this.Controls.Add(this.btnClearCache);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Button btnClearDefaultCache;
    }
}

