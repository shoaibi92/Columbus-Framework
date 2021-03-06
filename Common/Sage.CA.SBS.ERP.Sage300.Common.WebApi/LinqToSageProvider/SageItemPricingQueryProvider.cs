﻿/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
    /// This SageItemPricingQueryProvider class defines methods to create and execute queries
    /// that are described by an <see cref="T:System.Linq.IQueryable"/> object.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model</typeparam>
    public class SageItemPricingQueryProvider<THeader, TDetail, TService> : SageOrderedHeaderDetailQueryProvider<THeader, TDetail,TService>
        where THeader : ItemPricing, new()
        where TDetail : ItemPricingDetail, new()
        where TService : IItemPricingService<THeader, TDetail>
    {

        #region Constructor.

        /// <summary>
        /// Initializes a new instance of the <see cref="SageItemPricingQueryProvider{THeader,TDetail,TService}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SageItemPricingQueryProvider(Context context) : base(context)
        {
            SageQueryContext = new SageItemPricingQueryContext<THeader, TDetail, TService>(context);
        }

        #endregion

        #region IQueryProvider implementations.

        /// <summary>
        /// This non-generic CreateQuery should produce the same result as calling the 
        /// generic CreateQuery method with the correct type argument.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable"/> that can evaluate the query represented
        /// by the specified expression tree.
        /// </returns>
        public override IQueryable CreateQuery(Expression expression)
        {
            try
            {
                // ASSERT: The expression's type matches the TModel type.
                var closedType = typeof(ItemPricingQueryableSageData<THeader, TDetail, TService>);
                return (IQueryable)Activator.CreateInstance(closedType, new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        /// <summary>
        /// Queryable's collection-returning standard query operators call this method.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the elements of the <see cref="T:System.Linq.IQueryable`1"/> that is
        /// returned.
        /// </typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable`1"/> that can evaluate the query represented
        /// by the specified expression tree.
        /// </returns>
        public override IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return (IQueryable<TResult>)new ItemPricingQueryableSageData<THeader, TDetail, TService>(this, expression);
        }
        #endregion
    }
}

