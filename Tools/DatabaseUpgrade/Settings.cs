// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System.Collections.Generic;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.DatabaseUpgrade
{
    /// <summary> Settings class to hold info UI Settings </summary>
    public class Settings
    {
        #region Constructor
        /// <summary> Constructor setting defaults </summary>
        public Settings()
        {
            TransactionName = string.Empty;
            ScriptContent = null;
            Tenants = new List<Tenant>();
        }
        #endregion

        #region Public Properties
        /// <summary> Transaction Name </summary>
        public string TransactionName { get; set; }
        /// <summary> Script Content </summary>
        public IEnumerable<string> ScriptContent { get; set; }
        /// <summary> List of tenants </summary>
        public List<Tenant> Tenants { get; set; }
        #endregion
    }

}
