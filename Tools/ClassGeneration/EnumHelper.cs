// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System.Collections.Generic;
using System;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> Class to store enumerations </summary>
    public class EnumHelper
    {
        #region Public Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EnumHelper()
        {
            Values = new Dictionary<string, Object>();
        }
        #endregion

        #region Public Properties
        /// <summary> Field name for dictionary </summary>
        public string Name { get; set; }
        /// <summary> Enumeration values for field </summary>
        public Dictionary<string, Object> Values { get; set; }
        #endregion
    }
}