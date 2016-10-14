/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// This OrderedHeaderDetailQueryableSageData class provides functionality to evaluate queries for OrderedHeaderDetail models.
    /// NOTE: OrderedHeaderDetailQueryableSageData indirectly implements the IQueryable interface.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model</typeparam>
    public class OrderedHeaderDetailQueryableSageData<THeader, TDetail, TService> : QueryableSageData<THeader, TService>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TService : IOrderedHeaderDetailService<THeader, TDetail>
    {
        #region Two constructors.

        /// <summary> 
        /// Initializes a new instance of OrderedHeaderDetailQueryableSageData class.
        /// </summary>
        /// <remarks>
        /// This constructor is called by the ODataController layer to create the data source.
        /// </remarks>
        public OrderedHeaderDetailQueryableSageData(Context context)
        {
            Provider = new SageOrderedHeaderDetailQueryProvider<THeader, TDetail, TService>(context);
            Expression = Expression.Constant(this);
        }

        /// <summary> 
        /// Initializes a new instance of OrderedHeaderDetailQueryableSageData class.
        /// </summary>
        /// <remarks>
        /// This constructor is called internally by Provider.CreateQuery(). 
        /// </remarks>
        /// <param name="provider">The query provider associated with this data source.</param>
        /// <param name="expression">The associated expression tree.</param>
        public OrderedHeaderDetailQueryableSageData(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        #endregion

    }
}
