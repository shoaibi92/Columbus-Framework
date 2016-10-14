// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;


namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    
    
    /// <summary>
    /// Interface for Cost Service.
    /// </summary>
    public interface IBillToLocationService<T> : IEntityService<T>, ISecurityService where T : BillToLocation, new()
    {
        /// <summary>
        /// Sets the bill to location.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        void SetValue(BillToLocation model);
    }
}
