/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Enums
{
    /// <summary>
    /// Enum for ViewFieldAttributes
    /// </summary>
    public enum ViewFieldAttributes
    {
        /// <summary>
        /// The changed
        /// </summary>
        Changed = 1,

        /// <summary>
        /// The enabled
        /// </summary>
        Enabled = 2,

        /// <summary>
        /// The editable
        /// </summary>
        Editable = 4,

        /// <summary>
        /// The key
        /// </summary>
        Key = 8,

        /// <summary>
        /// The calculated
        /// </summary>
        Calculated = 16,

        /// <summary>
        /// The type
        /// </summary>
        Type = 32,

        /// <summary>
        /// The presentation
        /// </summary>
        Presentation = 64,

        /// <summary>
        /// The required
        /// </summary>
        Required = 128,

        /// <summary>
        /// The check editable
        /// </summary>
        CheckEditable = 256,
    }

    /// <summary>
    /// Enum for ViewFilterOrigin
    /// </summary>
    public enum ViewFilterOrigin
    {
        /// <summary>
        /// From start
        /// </summary>
        FromStart = 1,

        /// <summary>
        /// From current
        /// </summary>
        FromCurrent = 2,
    }

    /// <summary>
    /// Enum for ViewFieldPresentationType
    /// </summary>
    public enum ViewFieldPresentationType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 32,

        /// <summary>
        /// The list
        /// </summary>
        List = 76,

        /// <summary>
        /// The mask
        /// </summary>
        Mask = 77,
    }

    /// <summary>
    /// Enum for ViewFieldType
    /// </summary>
    public enum ViewFieldType
    {
        /// <summary>
        /// The character
        /// </summary>
        Char = 1,

        /// <summary>
        /// The byte
        /// </summary>
        Byte = 2,

        /// <summary>
        /// The date
        /// </summary>
        Date = 3,

        /// <summary>
        /// The time
        /// </summary>
        Time = 4,

        /// <summary>
        /// The real
        /// </summary>
        Real = 5,

        /// <summary>
        /// The decimal
        /// </summary>
        Decimal = 6,

        /// <summary>
        /// The int
        /// </summary>
        Int = 7,

        /// <summary>
        /// The long
        /// </summary>
        Long = 8,

        /// <summary>
        /// The bool
        /// </summary>
        Bool = 9,
    }

    /// <summary>
    /// Enum for ViewProtocol
    /// </summary>
    public enum ViewProtocol
    {
        /// <summary>
        /// The subclass none
        /// </summary>
        SubclassNone = 0,

        /// <summary>
        /// The basic flat
        /// </summary>
        BasicFlat = 0,

        /// <summary>
        /// The revision none
        /// </summary>
        RevisionNone = 0,

        /// <summary>
        /// The mask segments added
        /// </summary>
        MaskSegmentsAdded = 15,

        /// <summary>
        /// The basic batch
        /// </summary>
        BasicBatch = 16,

        /// <summary>
        /// The basic header
        /// </summary>
        BasicHeader = 32,

        /// <summary>
        /// The basic detail
        /// </summary>
        BasicDetail = 48,

        /// <summary>
        /// The basic super
        /// </summary>
        BasicSuper = 64,

        /// <summary>
        /// The mask basic
        /// </summary>
        MaskBasic = 112,

        /// <summary>
        /// The revision sequenced
        /// </summary>
        RevisionSequenced = 128,

        /// <summary>
        /// The revision ordered
        /// </summary>
        RevisionOrdered = 256,

        /// <summary>
        /// The mask revision
        /// </summary>
        MaskRevision = 896,

        /// <summary>
        /// The generate key
        /// </summary>
        GenerateKey = 1024,

        /// <summary>
        /// The header must exist
        /// </summary>
        HeaderMustExist = 2048,

        /// <summary>
        /// The subclass override
        /// </summary>
        SubclassOverride = 4096,

        /// <summary>
        /// The subclass alter
        /// </summary>
        SubclassAlter = 8192,

        /// <summary>
        /// The subclass join
        /// </summary>
        SubclassJoin = 12288,

        /// <summary>
        /// The mask subclass
        /// </summary>
        MaskSubclass = 28672,
    }

    /// <summary>
    /// Enum for ViewSecurity
    /// </summary>
    [Flags]
    public enum ViewSecurity
    {
        /// <summary>
        /// The add
        /// </summary>
        Add = 1,

        /// <summary>
        /// The modify
        /// </summary>
        Modify = 2,

        /// <summary>
        /// The delete
        /// </summary>
        Delete = 4,

        /// <summary>
        /// The inquire
        /// </summary>
        Inquire = 8,

        /// <summary>
        /// The post
        /// </summary>
        Post = 16,
    }

    /// <summary>
    /// Enum for ViewReferentialIntegrity
    /// </summary>
    public enum ViewReferentialIntegrity
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The cascade
        /// </summary>
        Cascade = 1,
    }

    /// <summary>
    /// Enum for ViewSystemAccess
    /// </summary>
    public enum ViewSystemAccess
    {
        /// <summary>
        /// The normal
        /// </summary>
        Normal = 0,

        /// <summary>
        /// The import
        /// </summary>
        Import = 1,

        /// <summary>
        /// The export
        /// </summary>
        Export = 2,

        /// <summary>
        /// The integrity check
        /// </summary>
        IntegrityCheck = 3,

        /// <summary>
        /// The macro
        /// </summary>
        Macro = 4,

        /// <summary>
        /// The activation
        /// </summary>
        Activation = 5,

        /// <summary>
        /// The conversion
        /// </summary>
        Conversion = 6,

        /// <summary>
        /// The posting
        /// </summary>
        Posting = 10,
    }

    /// <summary>
    /// Enum for ViewRotoType
    /// </summary>
    public enum ViewRotoType
    {
        /// <summary>
        /// The view
        /// </summary>
        View = 1,

        /// <summary>
        /// The view subclass
        /// </summary>
        ViewSubclass = 2,

        /// <summary>
        /// The view stub
        /// </summary>
        ViewStub = 3,
    }

    /// <summary>
    /// Enum for ViewRecordCreate
    /// </summary>
    public enum ViewRecordCreate
    {
        /// <summary>
        /// The no insert
        /// </summary>
        NoInsert = 0,

        /// <summary>
        /// The insert
        /// </summary>
        Insert = 1,

        /// <summary>
        /// The delay key
        /// </summary>
        DelayKey = 2,
    }

    /// <summary>
    /// Enum for ViewFilterStrictness
    /// </summary>
    public enum ViewFilterStrictness
    {
        /// <summary>
        /// The strict
        /// </summary>
        Strict = 1,

        /// <summary>
        /// The try
        /// </summary>
        Try = 2,

        /// <summary>
        /// The simulate
        /// </summary>
        Simulate = 3,
    }

    /// <summary>
    /// Enum for ViewKeys
    /// </summary>
    public enum ViewKeys
    {
    }
}