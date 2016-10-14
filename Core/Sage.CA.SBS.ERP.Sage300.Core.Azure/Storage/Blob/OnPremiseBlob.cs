/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.IO;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    /// <summary>
    /// OnPremise-specific blob implementation for one day caching for KPI
    /// </summary>
    public sealed class OnPremiseBlob : IBlob
    {
        private static string _blobName;
        private static OnPremiseBlob _instance ;
      
        /// <summary>
        /// prevent to create instance
        /// </summary>
        private OnPremiseBlob(string blobName)
        {
            _blobName = blobName;
        }

        /// <summary>
        /// Get the instance
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IBlob GetBlob(string blobName, Context context)
        {
            _blobName = blobName;
            _instance = _instance ??  new OnPremiseBlob(blobName);
            return (ConfigurationHelper.IsSageKPICachEnabled) ? _instance : null;
        }

        /// <summary>
        /// Check whether blob is valid.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsBlobValid(string blobName, Context context)
        {
            return ConfigurationHelper.IsSageKPICachEnabled && (InMemoryCacheProvider.InstanceOneDay.Get<string>(blobName) != null);
        }

        /// <summary>
        /// Get caching content
        /// </summary>
        /// <returns></returns>
        public string DownloadText()
        {
            return (ConfigurationHelper.IsSageKPICachEnabled) ? InMemoryCacheProvider.InstanceOneDay.Get<string>(_blobName) : null;
        }

        /// <summary>
        /// Set caching content
        /// </summary>
        /// <param name="text">caching content</param>
        public void UploadText(string text)
        {
            if (ConfigurationHelper.IsSageKPICachEnabled)
            {
                InMemoryCacheProvider.InstanceOneDay.Set(_blobName, text);    
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadByteArray()
        {
            throw new NotImplementedException();
        }

        public void UploadByteArray(byte[] content)
        {
            throw new NotImplementedException();
        }

        public void UploadByteArray(byte[] content, bool isPersistent)
        {
            throw new NotImplementedException();
        }

        public void UploadByteArray(byte[] content, BlobAccessCondition blobAccessCondition)
        {
            throw new NotImplementedException();
        }


        public Uri Uri
        {
            get { throw new NotImplementedException(); }
        }

        public void DownloadStream(Stream stream)
        {
            { throw new NotImplementedException(); }
        }

        public bool UploadStream(System.IO.Stream content)
        {
            throw new NotImplementedException();
        }

        public bool UploadBlock(long blockOffset, byte[] blockContent)
        {
            throw new NotImplementedException();
        }

        public void CommitUploadedBlocks()
        {
            throw new NotImplementedException();
        }

        public Stream OpenRead()
        {
            throw new NotImplementedException();
        }

        public long Length
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// SetMetadata
        /// </summary>
        /// <param name="dictionary">List of metadata</param>
        public void SetMetadata(Dictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }

    }
}
