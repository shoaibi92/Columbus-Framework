/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.IC.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.IC.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// Class ItemPricingExpressionTreeModifier.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model.</typeparam>
    internal class ItemPricingExpressionTreeModifier<THeader, TDetail, TService> : ExpressionTreeModifier<THeader, TService>
        where THeader : ItemPricing, new()
        where TDetail : ItemPricingDetail, new()
        where TService : IItemPricingService<THeader, TDetail>
    {
        internal ItemPricingExpressionTreeModifier(IQueryable<THeader> data)
            : base(data)
        {
        }

        /// <summary>
        /// Visits the <see cref="ConstantExpression"/>, replacing the
        /// constant ItemPricingExpressionTreeModifier arg with the queryable data collection. 
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(ItemPricingQueryableSageData<THeader, TDetail, TService>))
                return Expression.Constant(QueryableData);
            return node;
        }
    }
}

