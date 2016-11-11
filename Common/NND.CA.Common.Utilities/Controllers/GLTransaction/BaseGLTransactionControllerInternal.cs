/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLTransaction.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLTransaction;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLTransaction;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.GLTransaction
{
    /// <summary>
    /// Class for Base G/L Transaction Controller Internal methods
    /// </summary>
    /// <typeparam name="T">G/L Transaction</typeparam>
    /// <typeparam name="TViewModel">G/L Transaction View Model</typeparam>
    /// <typeparam name="TService">Base G/L Transaction Service Interface</typeparam>
    public class BaseGLTransactionControllerInternal<T, TViewModel, TService> :
        ReportControllerInternal<T, TViewModel, TService> where T : BaseGLTransaction, new()
        where TViewModel : BaseGLTransactionViewModel<T>, new()
        where TService : IBaseGLTransactionService<T>
    {
        /// <summary>
        /// Constructor for Controller Internal of Contract Pricing
        /// </summary>
        /// <param name="context">Context</param>
        public BaseGLTransactionControllerInternal(Context context) : base(context)
        {
        }

        /// <summary>
        /// Page Load
        /// </summary>
        /// <returns>It will return a  Model</returns>
        public override TViewModel Get()
        {
            var baseGLTransactionData = Service.Get();
            var viewModel = new TViewModel { Data = baseGLTransactionData, };
            return viewModel;
        }
    }

   

  
    
}
