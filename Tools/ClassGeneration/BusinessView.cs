﻿// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

#region Namespaces
using System.Collections.Generic;
using System.Configuration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> BusinessView class to hold properties for a view </summary>
    public class BusinessView
    {
        #region Public Constants
        public const string ViewId = "ViewId";
        public const string ModelName = "ModelName";
        public const string Module = "Module";
        public const string Name = "Name";
        public const string ReportKey = "ReportKey";
        public const string ProgramId = "ProgramId";
        #endregion

        #region Constructor
        /// <summary> Constructor setting defaults </summary>
        public BusinessView()
        {
            Properties = new Dictionary<string, string>();
            Fields = new List<BusinessField>();            
            Enums = new Dictionary<string, EnumHelper>();
        }
        #endregion

        #region Public Properties
        /// <summary> Properties is the collection of business view properties </summary>
        public Dictionary<string, string> Properties { get; set; }
        /// <summary> Fields is the collection of business fields </summary>
        public List<BusinessField> Fields { get; set; }
        /// <summary> Enums is the collection of business enumerations </summary>
        public Dictionary<string, EnumHelper> Enums { get; set; }
        #endregion

    }

}
