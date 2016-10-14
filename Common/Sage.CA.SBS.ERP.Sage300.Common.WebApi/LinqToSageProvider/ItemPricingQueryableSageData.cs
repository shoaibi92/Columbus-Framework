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
using Sage.CA.SBS.ERP.Sage300.IC.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.IC.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// This ItemPricingQueryableSageData class provides functionality to evaluate queries for ItemPricing models.
    /// NOTE: ItemPricingQueryableSageData indirectly implements the IQueryable interface.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model</typeparam>
    public class ItemPricingQueryableSageData<THeader, TDetail, TService> : OrderedHeaderDetailQueryableSageData<THeader,TDetail, TService>
        where THeader : ItemPricing, new()
        where TDetail : ItemPricingDetail, new()
        where TService : IItemPricingService<THeader, TDetail>
    {
        #region Two constructors.

        /// <summary> 
        /// Initializes a new instance of ItemPricingQueryableSageData class.
        /// </summary>
        /// <remarks>
        /// This constructor is called by the ODataController layer to create the data source.
        /// </remarks>
        public ItemPricingQueryableSageData(Context context) : base(context)
        {
            Provider = new SageItemPricingQueryProvider<THeader, TDetail, TService>(context);
            Expression = Expression.Constant(this);
        }

        /// <summary> 
        /// Initializes a new instance of ItemPricingQueryableSageData class.
        /// </summary>
        /// <remarks>
        /// This constructor is called internally by Provider.CreateQuery(). 
        /// </remarks>
        /// <param name="provider">The query provider associated with this data source.</param>
        /// <param name="expression">The associated expression tree.</param>
        public ItemPricingQueryableSageData(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        #endregion

    }
}

