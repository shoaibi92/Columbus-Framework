using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using CEDataService;
using Sage.Authorisation;
using Sage.Authorisation.Client;
using SageNA.CE.UM.Client;

namespace TokenGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Grab the token generation settings from the App.config file.
            txtClientID.Text = ConfigurationManager.AppSettings["ClientId"];
            txtScope.Text = ConfigurationManager.AppSettings["Scope"];

            // Initialize the configuration path for storing token data.
            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TenantInfoTest\TokenData";
        }

        /// <summary>
        /// Generates the access token.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (var auth = new OAuthClient(txtClientID.Text, txtPath.Text))
            {
                auth.SuppressInteractive = false;

                var startInfo = new AuthorisationInfo
                {
                    Scope = txtScope.Text,
                    ResponseType = "code",
                    State = "This is a device test state string.",
                    ResetDuration = false,
                    DeviceName = "MyDeviceName"
                };

                var result = auth.Authorise(startInfo, null);
                if (result.Success)
                {
                    txtToken.Text = result.AccessToken;
                    txtExpiryTime.Text = result.Expiry.ToString(CultureInfo.InvariantCulture);
                    btnGetTenants.Visible = true;
                }
            }
        }

        /// <summary>
        /// Resets the access token.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            using (var auth = new OAuthClient(txtClientID.Text, txtPath.Text))
            {
                auth.CleanUp();
            }

            txtToken.Text = "";
            txtExpiryTime.Text = "";
            btnGetTenants.Visible = false;
            gridTenants.Visible = false;
            labelTenants.Visible = false;
        }

        /// <summary>
        /// Gets the list of accessible tenants corresponding to the given login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetTenants_Click(object sender, EventArgs e)
        {
            var authenticator = new UMOAuth();
            var authResult = authenticator.GetOAuthInfo(txtToken.Text, false);
            var appUserAccessList = authResult.User.AppUserAccessInfo;
            var tenantInfoList = appUserAccessList.Select(x => x.TenantInfo).ToList();

            //--------------------------------------------------------------------------------
            // Uncomment this if you want the list of all tenant names.
            //--------------------------------------------------------------------------------
            // var tenantNameList = appUserAccessList.Select(x => x.TenantInfo.TenantName);
            //--------------------------------------------------------------------------------

            // Display the list of tenant info.
            var bindingTenantList = new BindingList<Tenant>(tenantInfoList);
            gridTenants.DataSource = bindingTenantList;
            gridTenants.Height = gridTenants.RowTemplate.Height * (gridTenants.RowCount + 1) - 3;
            gridTenants.Visible = true;
            labelTenants.Visible = true;
        }
    }
}
