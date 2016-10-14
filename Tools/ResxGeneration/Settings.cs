/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.ResxGeneration
{
    /// <summary> Settings class to hold info UI Settings </summary>
    class Settings
    {
        #region Constructor
        /// <summary> Constructor setting defaults </summary>
        public Settings()
        {
            Overwrite = false;
            Languages = new Dictionary<string, string>();
        }
        #endregion

        #region Public Properties
        /// <summary> Overwrite boolean indictates whether or not an existing file will be overwritten </summary>
        public bool Overwrite { get; set; }
        /// <summary> Dictionary holding lanaguges to be processed </summary>
        public Dictionary<string, string> Languages { get; set; }
        #endregion
    }
}
