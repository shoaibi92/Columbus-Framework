// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary>
    /// Enum for Data Types
    /// </summary>
    public enum BusinessDataType
    {
        /// <summary> double </summary>
        [EnumValue("double")] 
        Double = 0,
        /// <summary> long </summary>
        [EnumValue("long")]
        Long = 1,
        /// <summary> string </summary>
        [EnumValue("string")]
        String = 2,
        /// <summary> DateTime </summary>
        [EnumValue("DateTime")]
        DateTime = 3,
        /// <summary> int </summary>
        [EnumValue("int")]
        Integer = 4,
        /// <summary> decimal </summary>
        [EnumValue("decimal")]
        Decimal = 5,
        /// <summary> bool </summary>
        [EnumValue("bool")]
        Boolean = 6,
        /// <summary> TimeSpan </summary>
        [EnumValue("TimeSpan")]
        TimeSpan = 7,
        /// <summary> byte[] </summary>
        [EnumValue("byte[]")]
        Byte = 8,
        /// <summary> enumeration </summary>
        [EnumValue("enumeration")]
        Enumeration = 9
    }
}
