using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //[DefaultValue(0)]
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
