/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob
{
    /// <summary>
    /// IBlob Container Factory
    /// </summary>
    public interface IBlobContainerFactory
    {
        /// <summary>
        /// Creates the blob container with the provided reference
        /// </summary>
        /// <param name="blobContainerId"></param>
        /// <returns></returns>
        IBlobContainer GetBlobContainer(string blobContainerId);
    }
}
