// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;


namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    
    
    /// <summary>
    /// Interface for Bill To Location Entity.
    /// </summary>
    public interface ICommonBillToLocationEntity<T> : IBusinessRepository<T>, ISecurity where T : BillToLocation, new()
    {
        /// <summary>
        /// Sets the Bill To Location Model Attributes.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        BillToLocation SetValue(BillToLocation model, IBusinessEntity _headerEntity);
    }
}
