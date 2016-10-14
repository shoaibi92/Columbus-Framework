/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.IO;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob
{
    /// <summary>
    /// IBlob
    /// </summary>
    public interface IBlob
    {
        /// <summary>
        /// Download blob contents as a string
        /// </summary>
        /// <returns></returns>
        string DownloadText();

        /// <summary>
        /// Upload text to the blob
        /// </summary>
        /// <param name="text"></param>
        void UploadText(string text);

        /// <summary>
        /// Delete the blob
        /// </summary>
        void Delete();
        
        /// <summary>
        /// Download Content as Byte Array
        /// </summary>
        /// <returns></returns>
        byte[] DownloadByteArray();

        /// <summary>
        /// Upload Byte Array to blob
        /// </summary>
        /// <returns></returns>
        void UploadByteArray(byte[] content);

        /// <summary>
        /// Uploads the byte array to blob
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="isPersistent">If true blob will not be deleted automatically.</param>
        void UploadByteArray(byte[] content, bool isPersistent);

        /// <summary>
        /// Uploads the byte array to blob
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="blobAccessCondition">Represents a set of access conditions to be used for operations against the blob services.</param>
        void UploadByteArray(byte[] content, BlobAccessCondition blobAccessCondition);
        
        /// <summary>
        /// Get the Uri for the blob
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Retrieve the specified blob as stream
        /// </summary>
        /// <param name="stream">Output stream</param>
        void DownloadStream(Stream stream);

        /// <summary>
        /// Uploads the stream to blob
        /// </summary>
        bool UploadStream(Stream content);

        /// <summary>
        /// Method to upload individual blocks of file
        /// </summary>
        /// <param name="blockOffset">Current block number</param>
        /// <param name="blockContent">Current block content</param>
        /// <returns></returns>
        bool UploadBlock(long blockOffset, byte[] blockContent);

        /// <summary>
        /// Method to commit all the uploaded chunks
        /// </summary>
        void CommitUploadedBlocks();

        /// <summary>
        /// Open stream to read blob's content
        /// </summary>
        /// <returns></returns>
        Stream OpenRead();

        /// <summary>
        /// Set Metadata
        /// </summary>
        /// <param name="dictionary"></param>
        void SetMetadata(Dictionary<string, string> dictionary);

        /// <summary>
        /// The the size of the blob (in bytes)
        /// </summary>
        long Length { get; }
        
        /// <summary>
        /// Check whether the blob is valid
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        bool IsBlobValid(string blobName, Context context);
    }
}
