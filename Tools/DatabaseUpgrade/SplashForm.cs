// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System.Windows.Forms;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    /// <summary> Splash screen for Database Upgrade Utility </summary>
    public partial class SplashForm : Form
    {
        #region Private Vars
        /// <summary> Image counter for animated splash images </summary>
        private int _splashImage;
        #endregion

        #region Constructor
        /// <summary> Database Upgrade Utility - Splash Form</summary>
        public SplashForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            // Start the timer for animation
            timer1.Start();
        }
        #endregion

        #region Private routines
        /// <summary> Timer tick event for animation</summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Increment counter and validate boundaries
            _splashImage++;
            if (_splashImage > 3)
            {
                _splashImage = 1;
            }

            // Change image
            switch (_splashImage)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Splash1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Splash2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.Splash3;
                    break;
            }

            // Refresh Image
            pictureBox1.Refresh();
        }
        #endregion
    }
}
