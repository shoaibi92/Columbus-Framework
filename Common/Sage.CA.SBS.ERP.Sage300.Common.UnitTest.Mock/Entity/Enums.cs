using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPseudoEntity.Enums
{
    public enum ViewFieldAttributes
    {
        Changed = 1,
        Enabled = 2,
        Editable = 4,
        Key = 8,
        Calculated = 16,
        Type = 32,
        Presentation = 64,
        Required = 128,
        CheckEditable = 256,
    }

    public enum ViewFilterOrigin
    {
        FromStart = 1,
        FromCurrent = 2,
    }

    public enum ViewFieldPresentationType
    {
        None = 32,
        List = 76,
        Mask = 77,
    }

    public enum ViewFieldType
    {
        Char = 1,
        Byte = 2,
        Date = 3,
        Time = 4,
        Real = 5,
        Decimal = 6,
        Int = 7,
        Long = 8,
        Bool = 9,
    }
    public enum ViewProtocol
    {
        SubclassNone = 0,
        BasicFlat = 0,
        RevisionNone = 0,
        MaskSegmentsAdded = 15,
        BasicBatch = 16,
        BasicHeader = 32,
        BasicDetail = 48,
        BasicSuper = 64,
        MaskBasic = 112,
        RevisionSequenced = 128,
        RevisionOrdered = 256,
        MaskRevision = 896,
        GenerateKey = 1024,
        HeaderMustExist = 2048,
        SubclassOverride = 4096,
        SubclassAlter = 8192,
        SubclassJoin = 12288,
        MaskSubclass = 28672,
    }

    [Flags]
    public enum ViewSecurity
    {
        Add = 1,
        Modify = 2,
        Delete = 4,
        Inquire = 8,
        Post = 16,
    }

    public enum ViewReferentialIntegrity
    {
        None = 0,
        Cascade = 1,
    }

    public enum ViewSystemAccess
    {
        Normal = 0,
        Import = 1,
        Export = 2,
        IntegrityCheck = 3,
        Macro = 4,
        Activation = 5,
        Conversion = 6,
        Posting = 10,
    }

    public enum ViewRotoType
    {
        View = 1,
        ViewSubclass = 2,
        ViewStub = 3,
    }

    public enum ViewRecordCreate
    {
        NoInsert = 0,
        Insert = 1,
        DelayKey = 2,
    }

    public enum ViewFilterStrictness
    {
        Strict = 1,
        Try = 2,
        Simulate = 3,
    }
}
