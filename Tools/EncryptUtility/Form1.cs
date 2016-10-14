using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace EncryptString
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncryptByCert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCertThumbprint.Text))
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show("Thumbprint is missing.");
                return;
            }

            if (string.IsNullOrEmpty(txtSensitiveData.Text))
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show("Enter data to encrypt.");
                return;
            }

            try
            {
                var cert = CertificateHelper.GetCertificateFromFindCriteria(X509FindType.FindByThumbprint, txtCertThumbprint.Text);
                if (cert != null)
                {
                    lblCertName.Text = cert.FriendlyName;
                    CertificateCryptography agent = new CertificateCryptography(txtCertThumbprint.Text);
                    txtEncryptText.Text = agent.Encrypt(txtSensitiveData.Text);
                }
                else
                {
                    lblCertName.Text = string.Empty;
                    MessageBox.Show("Unable to find cert in local store.");
                    txtEncryptText.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecryptByThumbprint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCertThumbprint.Text))
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show("Thumbprint is missing.");                
                return;
            }

            if (string.IsNullOrEmpty(txtCertThumbprint.Text))
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show("Encrypted text is missing.");                
                return;
            }

            try
            {
                var cert = CertificateHelper.GetCertificateFromFindCriteria(X509FindType.FindByThumbprint, txtCertThumbprint.Text);
                if (cert != null)
                {
                    CertificateCryptography agent = new CertificateCryptography(txtCertThumbprint.Text);
                    txtDecryptedSensitiveData.Text = agent.Decrypt(txtEncryptText.Text);
                }
                else
                {
                    lblCertName.Text = string.Empty;
                    MessageBox.Show("Unable to find cert in local store.");
                    txtEncryptText.Text = string.Empty;                    
                }
            }
            catch (Exception ex)
            {
                lblCertName.Text = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }

 

    }
}
