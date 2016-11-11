/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.CSharp;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NND.CA.Common.Model;

#endregion

namespace NND.CA.Common.Web
{
    /// <summary>
    /// Export/Import controller internal - base
    /// </summary>

    //public class BaseExportImportControllerInternal<T, TService> : InternalControllerBase<TService>, IExportImportController
    //    where T : ModelBase, new()
    //    where TService : IEntityService<T>, ISecurityService
    public class BaseExportImportControllerInternal
    {
        public BaseExportImportControllerInternal(Context context)
    //: base(context)
        {
        }
    }
}