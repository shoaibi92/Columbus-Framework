// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sage300CUIWizard
{
    public partial class UserInputForm : Form
    {
        public string ThirdPartyCompanyName { get; set; }
        public string ThirdPartyApplicationId { get; set; }
        public string CompanyNamespace { get; set; }

        public UserInputForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ThirdPartyCompanyName = txtCompanyName.Text.Trim();

            if (string.IsNullOrEmpty(ThirdPartyCompanyName))
            {
                MessageBox.Show("Company name cannot be blank!");
                return;
            }

            ThirdPartyApplicationId = txtApplicationID.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(ThirdPartyApplicationId) || ThirdPartyApplicationId.Contains(" "))
            {
                MessageBox.Show("Module ID cannot be blank or contain any spaces!");
                return;
            }

            CompanyNamespace = txtNamespace.Text.Trim();
            if (string.IsNullOrEmpty(CompanyNamespace) || CompanyNamespace.Contains(" "))
            {
                MessageBox.Show("Namespace cannot be blank or contain any spaces!");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SetNamespace()
        {
            ThirdPartyCompanyName = txtCompanyName.Text.Trim();

            if (!string.IsNullOrEmpty(ThirdPartyCompanyName))
            {
                txtNamespace.Text = ThirdPartyCompanyName.Replace(" ", "");
            }
            else
            {
                txtNamespace.Text = "";
            }
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            SetNamespace();

        }
    }
}
