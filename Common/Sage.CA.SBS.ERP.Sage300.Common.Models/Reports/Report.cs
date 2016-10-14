/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Report
    /// </summary>
    public class Report
    {
        
        /// <summary>
        /// Context
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// ReportProcessType
        /// </summary>
        public ReportProcessType ReportProcessType { get; set; }

        /// <summary>
        /// The Process method of this type is called if there is anytihng to process after report is generated 
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Name of the assembly.This is required if anything needs to be processed after the report is generated
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Model - This is required if anything needs to be processed after the report is generated
        /// </summary>
        public ModelBase ReportModel { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Report()
        {
            Parameters = new List<Parameter>();
            ReportProcessType = ReportProcessType.OnLoad;
        }

        /// <summary>
        /// Parameters of the report
        /// </summary>
        public List<Parameter> Parameters { get; set; }

        /// <summary>
        /// Menu Id
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// Program Id
        /// </summary>
        public string ProgramId { get; set; }

        /// <summary>
        /// Name of the report
        /// </summary>
        public string Name { get; set; }
    }
}