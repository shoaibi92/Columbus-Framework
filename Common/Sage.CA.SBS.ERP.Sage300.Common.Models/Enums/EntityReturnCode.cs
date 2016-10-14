/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// This enum defines the Last Return Code value returned by the View
    /// </summary>
    public enum EntityReturnCode
    {
        /// <summary>
        /// Return Code for Success
        /// </summary>
        Success = 0,

        /// <summary>
        /// Return Code for Warning
        /// </summary>
        Warning = -1,

        /// <summary>
        /// Return Code for General
        /// </summary>
        General = 1000,

        /// <summary>
        /// Return Code for Record Not Found
        /// </summary>
        RecordNotFound = 1020,

        /// <summary>
        /// Return Code for Record No More Data
        /// </summary>
        RecordNoMoreData = 1021,

        /// <summary>
        /// Return Code for Record Exists
        /// </summary>
        RecordExists = 1022,

        /// <summary>
        /// Return Code for Record Duplicate
        /// </summary>
        RecordDuplicate = 1023,

        /// <summary>
        /// Return Code for Record Invalid
        /// </summary>
        RecordInvalid = 1024,

        /// <summary>
        /// Return Code for Record Locked
        /// </summary>
        RecordLocked = 1025,

        /// <summary>
        /// Return Code for Record Conflict
        /// </summary>
        RecordConflict = 1026,

        /// <summary>
        /// Return Code for Record Not Locked
        /// </summary>
        RecordNotLocked = 1027,

        /// <summary>
        /// Return Code for Table Exists
        /// </summary>
        TableExists = 1040,

        /// <summary>
        /// Return Code for Table Not Found
        /// </summary>
        TableNotFound = 1041,

        /// <summary>
        /// Return Code for Permission None
        /// </summary>
        PermissionNone = 1060,

        /// <summary>
        /// Return Code for Memory No More
        /// </summary>
        MemoryNoMore = 1080,

        /// <summary>
        /// Return Code for Memory Buffer Limit
        /// </summary>
        MemoryBufferLimit = 1081,

        /// <summary>
        /// Return Code for Filter Syntax
        /// </summary>
        FilterSyntax = 1100,

        /// <summary>
        /// Return Code for Filter Other
        /// </summary>
        FilterOther = 1101,

        /// <summary>
        /// Return Code for Key Invalid
        /// </summary>
        KeyInvalid = 1120,

        /// <summary>
        /// Return Code for Key Number
        /// </summary>
        KeyNumber = 1121,

        /// <summary>
        /// Return Code for Key Changed
        /// </summary>
        KeyChanged = 1122,

        /// <summary>
        /// Return Code for Field Invalid
        /// </summary>
        FieldInvalid = 1140,

        /// <summary>
        /// Return Code for Field Number
        /// </summary>
        FieldNumber = 1141,

        /// <summary>
        /// Return Code for Field Index
        /// </summary>
        FieldIndex = 1142,

        /// <summary>
        /// Return Code for Field Disabled
        /// </summary>
        FieldDisabled = 1143,

        /// <summary>
        /// Return Code for Field Readonly
        /// </summary>
        FieldReadonly = 1144,

        /// <summary>
        /// Return Code for Transaction None
        /// </summary>
        TransactionNone = 1160,

        /// <summary>
        /// Return Code for Transaction Open
        /// </summary>
        TransactionOpen = 1161,

        /// <summary>
        /// Return Code for Revision Protocol
        /// </summary>
        RevisionProtocol = 1180,

        /// <summary>
        /// Return Code for Database Parameter
        /// </summary>
        DatabaseParameter = 1200,

        /// <summary>
        /// Return Code for Database Limit
        /// </summary>
        DatabaseLimit = 1201,

        /// <summary>
        /// Return Code for Database Other
        /// </summary>
        DatabaseOther = 1202,

        /// <summary>
        /// Return Code for Database Dictionary 
        /// </summary>
        DatabaseDictionary = 1203,

        /// <summary>
        /// Return Code for RPC Failure
        /// </summary>
        RPCFailure = 1220,
    }
}
