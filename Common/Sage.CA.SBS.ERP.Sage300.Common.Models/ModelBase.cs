/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of properties for ModelBase
    /// </summary>
    public class ModelBase : ApplicationModelBase
    {
        /// <summary>
        /// This constructor initializes the Warnings list to be an empty list.
        /// This avoids the problem of serializing null collections.
        /// </summary>
        public ModelBase()
        {
            Warnings = new List<EntityError>();
        }

        /// <summary>
        /// Warnings
        /// </summary>
        /// <value>The warnings.</value>
        [IsMvcSpecific]
        [IgnorePreferencesAttribute]
        public IEnumerable<EntityError> Warnings { get; set; }

        /// <summary>
        /// ETag
        /// </summary>
        [IsMvcSpecific]
        public string ETag { get; set; }
    
        /// <summary>
        /// Is Deleted
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [IsMvcSpecific]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// To set this property when new line item is inserted.
        /// </summary>
        /// <value><c>true</c> if this instance is new line; otherwise, <c>false</c>.</value>
        [IsMvcSpecific]
        public bool IsNewLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has changed.
        /// </summary>
        /// <value><c>true</c> if this instance has changed; otherwise, <c>false</c>.</value>
        [IsMvcSpecific]
        public bool HasChanged { get; set; }

        /// <summary>
        /// Serial Number.
        /// </summary>
        [IsMvcSpecific]
        public int DisplayIndex { get; set; }

        /// <summary>
        /// Change Sequence.
        /// </summary>
        [IsMvcSpecific]
        public int ChangeSequence { get; set; }

        /// <summary>
        /// Key of the previous record. Used In UI
        /// </summary>
        [IsMvcSpecific]
        public string PreviousKey { get; set; }
    }
}