// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Enum for ProcessingCommand
    /// </summary>
    public enum ProcessingCommand
    {
        /// <summary>
        /// Default Enum None
        /// </summary>
        [EnumValue("Blank", typeof(EnumerationsResx))] 
        None = 0,

        /// <summary>
        /// Gets or sets Getdefaultprocessingcode
        /// </summary>
        [EnumValue("Getdefaultprocessingcode", typeof(EnumerationsResx))] 
        Getdefaultprocessingcode = 1,

        /// <summary>
        /// Gets or sets Getdefaultcardsprocessingcode,bank,Andcurrency
        /// </summary>
        [EnumValue("GetdefaultcardsprocessingcodebankAndcurrency", typeof(EnumerationsResx))] 
        GetdefaultcardsprocessingcodebankAndcurrency = 2,
    }
}