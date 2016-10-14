/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Web;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models
{
    /// <summary>
    /// Report token
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReportViewModel<T> : ViewModelBase<T> where T : GenericReport, new()
    {
        /// <summary>
        /// Report Token
        /// </summary>
        public Guid ReportToken { get; set; }
    }
}