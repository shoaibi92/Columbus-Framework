/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap
{
    /// <summary>
    /// Applies to Web or Worker
    /// </summary>
    public enum BootstrapAppliesTo
    {
        /// <summary>
        /// Web server
        /// </summary>
        Web,

        /// <summary>
        /// Worker server
        /// </summary>
        Worker,

        /// <summary>
        /// Web Api server
        /// </summary>
        WebApi
    }

    /// <summary>
    /// Applies to Web or Worker
    /// </summary>
    public static class BootstrapModule
    {
        /// <summary>
        /// Framework module
        /// </summary>
        public const string Framework = "Framework";

        /// <summary>
        /// Administrative services module
        /// </summary>
        public const string AS = "AS";

        /// <summary>
        /// Common Services module
        /// </summary>
        public const string CS = "CS";

        /// <summary>
        /// General Ledger module
        /// </summary>
        public const string GL = "GL";

        /// <summary>
        /// Accounts Receivable module
        /// </summary>
        public const string AR = "AR";

        /// <summary>
        /// Accounts Payable module
        /// </summary>
        public const string AP = "AP";

        /// <summary>
        /// Inventory Control Module
        /// </summary>
        public const string IC = "IC";

        /// <summary>
        /// KPI Model
        /// </summary>
        public const string KPI = "KPI";

        /// <summary>
        /// Order Entry Module
        /// </summary>
        public const string OE = "OE";

        /// <summary>
        /// Purchase Orders module
        /// </summary>
        public const string PO = "PO";

        /// <summary>
        /// Visual Process Flow
        /// </summary>
        public const string VPF = "VPF";

        /// <summary>
        /// Project and Job Costing
        /// </summary>
        public const string PM = "PM";
    }
    /// <summary>
    /// Bootstrap metadata
    /// </summary>
    public interface IBootstrapMetadata
    {
        /// <summary>
        /// Bootstrap Applies
        /// </summary>
        BootstrapAppliesTo[] AppliesTo { get; }

        /// <summary>
        /// Order of the of the boot straps
        /// </summary>
        [DefaultValue(0)]
        int Order { get; }

        /// <summary>
        /// Module name
        /// </summary>
        string Module { get; }

    }

    /// <summary>
    /// Bootstrap metadata informatin
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false), MetadataAttribute]
    public class BootstrapMetadataExportAttribute : ExportAttribute, IBootstrapMetadata
    {
        /// <summary>
        /// Bootstrap attribute constructor
        /// </summary>
        /// <param name="module"></param>
        /// <param name="appliesTo"></param>
        /// <param name="order"></param>
        public BootstrapMetadataExportAttribute(string module, BootstrapAppliesTo[] appliesTo, int order)
            : base(typeof(IBootstrapMetadata))
        {
            AppliesTo = appliesTo;
            Order = order;
            Module = module;
        }

        /// <summary>
        /// Module name
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// Bootstrapper AppliesTo
        /// </summary>
        public BootstrapAppliesTo[] AppliesTo { get; set; }

        /// <summary>
        /// Order od execution
        /// </summary>
        public int Order { get; set; }
    }
}
