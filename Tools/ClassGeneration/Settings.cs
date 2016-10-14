// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> Settings class to hold info UI Settings </summary>
    public class Settings
    {
        #region Constructor
        /// <summary> Constructor setting defaults </summary>
        public Settings()
        {
            ViewId = string.Empty;
            OutputFolder = string.Empty;
            BusinessView = new BusinessView();
            RepositoryType = RepositoryType.Unknown;
            ResxName = string.Empty;
        }
        #endregion

        #region Public Properties
        /// <summary> View Id to process for class generation </summary>
        public string ViewId { get; set; }
        /// <summary> Output Folder for generated class files </summary>
        public string OutputFolder { get; set; }
        /// <summary> User for Business View </summary>
        public string User { get; set; }
        /// <summary> Password for Business View </summary>
        public string Password { get; set; }
        /// <summary> Version for Business View </summary>
        public string Version { get; set; }
        /// <summary> Database for Business View </summary>
        public string Database { get; set; }
        /// <summary> RepositoryType for Business View </summary>
        public RepositoryType RepositoryType { get; set; }
        /// <summary> Business View </summary>
        public BusinessView BusinessView { get; set; }
        /// <summary> Generate Finder </summary>
        public bool GenerateFinder { get; set; }
        /// <summary> Generate Dynamic Enablement </summary>
        public bool GenerateDynamicEnablement { get; set; }
        /// <summary> Resx Name for Display Attributes </summary>
        public string ResxName { get; set; }
        #endregion
    }

}
