﻿#region

using System.ComponentModel;

#endregion

namespace Sage.CNA.WindowsService
{
    /// <summary>
    /// Class ProjectInstaller.
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectInstaller"/> class.
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}