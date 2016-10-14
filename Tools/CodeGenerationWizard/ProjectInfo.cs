// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System.Collections.Generic;
using EnvDTE;

namespace Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard
{
    /// <summary> Class to hold information for projects to be modified with generated code </summary>
    public class ProjectInfo
    {
        #region Public Properties
        /// <summary> Project Folder Name </summary>
        public string ProjectFolder { get; set; }

        /// <summary> ProjectName without Extension </summary>
        public string ProjectName { get; set; }

        /// <summary> Project Model</summary>
        public Project Project { get; set; }

        /// <summary> Subfolders per project</summary>
        public Dictionary<string, string> Subfolders { get; set; }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
