// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ProcessCommand 
    /// </summary>
    public enum InvoiceProcessCommand {

        /// <summary>
        /// Gets or sets CreateNewDepositSlip 
        /// </summary>	
        //[EnumValue("ProcessCommand_CreateNewDepositSlip", typeof(EnumerationsResx))]
        CreateNewDepositSlip = 0,
        /// <summary>
        /// Gets or sets UnlockBatchResource 
        /// </summary>	
        //[EnumValue("ProcessCommand_UnlockBatchResource", typeof(EnumerationsResx))]
        UnlockBatchResource = 1,
        /// <summary>
        /// Gets or sets LockBatchResourceShared 
        /// </summary>	
        //[EnumValue("ProcessCommand_LockBatchResourceShared", typeof(EnumerationsResx))]
        LockBatchResourceShared = 2,
        /// <summary>
        /// Gets or sets LockBatchResourceExclusive 
        /// </summary>	
        //[EnumValue("ProcessCommand_LockBatchResourceExclusive", typeof(EnumerationsResx))]
        LockBatchResourceExclusive = 3,
    }
}