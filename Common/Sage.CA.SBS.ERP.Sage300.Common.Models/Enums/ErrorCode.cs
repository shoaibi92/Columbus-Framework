/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Standard (PLUSAPI) error codes
    /// </summary>
    public enum ErrorCodes
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        Success = 0,
        /// <summary>
        /// open failed
        /// </summary>
        Open = 1,
        /// <summary>
        /// close failed
        /// </summary>
        Close = 2,
        /// <summary>
        /// seek failed
        /// </summary>
        Seek = 3,
        /// <summary>
        /// read failed
        /// </summary>
        Read = 4,
        /// <summary>
        /// write failed
        /// </summary>
        Write = 5,
        /// <summary>
        /// EOF (end of file) reached
        /// </summary>
        EOF = 6,
        /// <summary>
        /// disk is full
        /// </summary>
        DiskFull = 7,
        /// <summary>
        /// data is corrupt or invalid
        /// </summary>
        BadData = 8,
        /// <summary>
        /// file locked or permission denied
        /// </summary>
        NoAccess = 9,
        /// <summary>
        /// create failed
        /// </summary>
        Create = 10,
        /// <summary>
        /// delete failed
        /// </summary>
        Delete = 11,
        /// <summary>
        /// byte lock failed
        /// </summary>
        Lock = 12,
        /// <summary>
        /// invalid file handle
        /// </summary>
        BadHandle = 13,
        /// <summary>
        /// file not found
        /// </summary>
        BadFile = 14,
        /// <summary>
        /// path not found
        /// </summary>
        BadPath = 15,
        /// <summary>
        /// incorrect password
        /// </summary>
        BadPW = 31,
        /// <summary>
        /// incorrect password
        /// </summary>
        BufferSize = 32,
        /// <summary>
        /// insufficient memory
        /// </summary>
        NoMemory = 33,
        /// <summary>
        /// no more handles
        /// </summary>
        NoHandles = 34,
        /// <summary>
        /// record with same key already exists
        /// </summary>
        DuplicateKey = 50,
        /// <summary>
        /// key/record not found
        /// </summary>
        NotFound = 51
    }
}
