/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Inquiry
{
    /// <summary>
    /// Base class for finder controller internal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public abstract class BaseInquiryControllerInternal<T, TService> : InternalControllerBase<TService>
        where T : ModelBase, new()
        where TService : IInquiryService<T>, ISecurityService
    { 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">context</param>
        protected BaseInquiryControllerInternal(Context context)
            : base(context)
        {
             
        }

        ///// <summary>
        ///// Gets the data(list of modelbase) from service.
        ///// </summary>
        ///// <returns>List of modelbase</returns>
        //public virtual IEnumerable<ModelBase> Get()
        //{
        //    // Get the Options service to get whether Fractional Quantities is selected
        //    var optionsService =
        //        Context.Container.Resolve<TService<Options>>(new ParameterOverride("context", Context));

        //    var options = optionsService.Get();

        //    var lifofifoInquirySummaries = new EnumerableResponse<T>();
        //    viewModel.LIFOFIFOInquirySummaries = lifofifoInquirySummaries;
        //    viewModel.Data = model;
        //    return viewModel;

        //    return viewModel;
        //}



        ///// <summary>
        ///// Method that returns the LIFO/FIFO Inquiry Summary on the passed search criteria
        ///// </summary>
        ///// <param name="model">An object of type <see cref="LIFOFIFOInquiry" /></param>
        ///// <param name="pageNumber">A page Number</param>
        ///// <param name="pageSize">A page size</param>
        ///// <param name="filter">A filter expression
        ///// <para>Here the object of type <!-- IList<IList<IList<Filter>>> --></para></param>
        ///// <returns>Returns an object type <see cref="LIFOFIFOInquiryViewModel{T}" /></returns>
        //internal IEnumerable<T> Get(T model, int pageNumber, int pageSize,
        //    IList<IList<IList<Filter>>> filter)
        //{
        //    var viewModel = new LIFOFIFOInquiryViewModel<T>();

        //    if (model.IsPageLoad)
        //    {
        //        // An expression to generate the filter expression from the passed
        //        Expression<Func<LIFOFIFOInquirySummary, bool>> filterExpression = null;

        //        foreach (var filterExp in filter)
        //        {
        //            // If the filter expression is not loaded, then load the filter expression from the first item in the list
        //            if (filterExpression != null)
        //            {
        //                // Get the parameter expression
        //                var parameterExpression = filterExpression.Parameters[0];

        //                // Get the next filter expressions in the series looping through
        //                var simpleFilterExpression = ExpressionBuilder<LIFOFIFOInquirySummary>.CreateExpression(filterExp);

        //                // Form a single expression by passing the existing one and the latest
        //                var body = Expression.AndAlso(filterExpression.Body, simpleFilterExpression.Body);

        //                filterExpression = Expression.Lambda<Func<LIFOFIFOInquirySummary, bool>>(body, parameterExpression);
        //            }
        //            else
        //                filterExpression = ExpressionBuilder<LIFOFIFOInquirySummary>.CreateExpression(filterExp);
        //        }

        //        var orderBy = OrderBy();

        //        var pageOptions = new PageOptions<LIFOFIFOInquirySummary>
        //        {
        //            PageNumber = pageNumber,
        //            PageSize = pageSize,
        //            Filter = filterExpression,
        //            OrderBy = orderBy
        //        };

        //        var lifofifoInquirySummaries = Service.Get(pageOptions);

        //        if (lifofifoInquirySummaries.Items.Any())
        //        {
        //            var serialNumber = 1;
        //            foreach (var item in lifofifoInquirySummaries.Items.Where(item => item.SerialNumber == 0))
        //            {
        //                item.SerialNumber = serialNumber;
        //                serialNumber++;
        //            }
        //        }
        //        else
        //        {
        //            viewModel.LIFOFIFOInquirySummaries = new EnumerableResponse<LIFOFIFOInquirySummary>();
        //        }

        //        viewModel.LIFOFIFOInquirySummaries = lifofifoInquirySummaries;
        //        viewModel.LIFOFIFOInquirySummaries.TotalResultsCount = lifofifoInquirySummaries.Items.Count();
        //        viewModel.Data = model;

        //        return viewModel;
        //    }
        //    else
        //    {
        //        var lifofifoInquirySummaries = new EnumerableResponse<LIFOFIFOInquirySummary>();
        //        viewModel.LIFOFIFOInquirySummaries = lifofifoInquirySummaries;
        //        viewModel.Data = model;
        //        return viewModel;
        //    }
        //}


    }
}
