// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    static class Program
    {

        /// <summary> Splash screen while tenants are loading </summary>
        public static SplashForm SplashForm = null;

        /// <summary> The main entry point for the application </summary>
        /// <param name="args">Command line arguments</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Display splash screen
            var splashThread = new Thread(new ThreadStart(
            delegate
            {
                SplashForm = new SplashForm();
                Application.Run(SplashForm);
            }
            ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            // Start main form
            var databaseUpgrade = new DatabaseUpgrade();
            databaseUpgrade.Load += databaseUpgrade_Load;

            Application.Run(databaseUpgrade);
        }

        /// <summary> Close the splash screen when the form is done loading and all tenants have been gathered </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        static void databaseUpgrade_Load(object sender, EventArgs e)
        {
            // Failsafe
            if (SplashForm == null)
            {
                return;
            }

            // Splash form is no longer needed
            SplashForm.Invoke(new Action(SplashForm.Close));
            SplashForm.Dispose();
            SplashForm = null;

            // Add checkbox to header for selecting/unselecting all
            var rect = ((DatabaseUpgrade)sender).grdTenants.GetCellDisplayRectangle((int)DatabaseUpgrade.TenantColumn.Select, -1, true);
            // set control header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4) + 1;
            var checkbox = new CheckBox
            {
                Name = "tenantCheckboxHeader",
                Size = new Size(18, 18),
                Location = rect.Location
            };
            checkbox.CheckedChanged += ((DatabaseUpgrade)sender).tenantHeader_CheckedChanged;
            ((DatabaseUpgrade)sender).grdTenants.Controls.Add(checkbox);

            // Add picturebox to header for clearing grid
            rect = ((DatabaseUpgrade)sender).grdTenants.GetCellDisplayRectangle((int)DatabaseUpgrade.TenantColumn.RowIndex, -1, true);
            // set control header to center of header cell. +1 pixel to position 
            rect.Y = 3;
            rect.X = rect.Location.X + (rect.Width / 4) + 1;
            var picturebox = new PictureBox
            {
                Name = "tenantPictureboxHeader",
                Size = new Size(18, 18),
                Location = rect.Location,
                Image = Properties.Resources.Reset24,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            picturebox.Click += ((DatabaseUpgrade)sender).tenantHeader_Click;
            ((DatabaseUpgrade)sender).grdTenants.Controls.Add(picturebox);
        }
    }
}
