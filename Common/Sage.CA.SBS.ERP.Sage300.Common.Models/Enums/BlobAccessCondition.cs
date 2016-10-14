/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Represents a set of access conditions to be used for operations against the blob services.
    /// </summary>
    public enum BlobAccessCondition
    {
        /// <summary>
        /// Gets or sets an ETag value for a condition specifying that the given ETag must not match the ETag of the specified resource.
        /// </summary>
        IfNoneMatchETag,
    }
}
