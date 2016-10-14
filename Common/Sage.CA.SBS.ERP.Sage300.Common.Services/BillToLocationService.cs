// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services
{
    class BillToLocationService<T> : FlatService<T, ICommonBillToLocationEntity<T>>, IBillToLocationService<T> where T : BillToLocation, new()
    {
        /// <summary>
        /// To set Request Context
        /// </summary>
        /// <param name="context">Request Context</param>    
        public BillToLocationService(Context context)
            : base(context)
        {

        }

        /// <summary>
        /// Sets the Bill To Location Model Attributes.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        public void SetValue(BillToLocation model)
        {
            using (var repository = Resolve<ICommonBillToLocationEntity<T>>())
            {
                repository.SetValue(model, null);
            }
        }
    }
}
