/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes
{
    /// <summary>
    /// If this attribute is applied this property will no longer be used in export and import
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreExportImportAttribute : Attribute
    {
    }
}