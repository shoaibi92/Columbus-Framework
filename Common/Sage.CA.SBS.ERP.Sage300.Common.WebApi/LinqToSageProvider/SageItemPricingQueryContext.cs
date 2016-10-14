/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
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
    /// The code in this SageItemPricingQueryContext class is very specific to this Sage provider.
    /// Thus, we encapsulated the Execute logic in this class instead of inserting it
    /// directly into the more generic IQueryProvider implementation.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model.</typeparam>
    internal class SageItemPricingQueryContext<THeader, TDetail, TService> : SageOrderedHeaderDetailQueryContext<THeader, TDetail, TService>
        where THeader : ItemPricing, new()
        where TDetail : ItemPricingDetail, new()
        where TService : IItemPricingService<THeader, TDetail>
    {
        #region Constructor.

        /// <summary>
        /// Initializes a new instance of SageItemPricingQueryContext class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SageItemPricingQueryContext(Context context)
            : base(context)
        {
        }

        #endregion

        #region The main Execute method.

        /// <summary>
        /// Executes the expression tree that is passed to it. 
        /// </summary>
        /// <param name="expression">The expression tree to be executed.</param>
        /// <param name="isEnumerable">True iff the result of the query is enumerable.</param>
        /// <returns>The value that results from executing the specified query.</returns>
        internal override object Execute(Expression expression, bool isEnumerable)
        {
            var onlyCountAllRecords = ExtractServiceParameters(expression);
            var enumerableResponse = BuildEnumerableResponse();

            // If we only want to count all the records, then return immediately.
            if (onlyCountAllRecords)
            {
                var longCount = (long)enumerableResponse.TotalResultsCount;
                return longCount;
            }

            // Copy the IEnumerable data to an IQueryable.
            var queryableData = enumerableResponse.Items.AsQueryable();

            // Copy the expression tree that was passed in, updating the type of the first
            // argument of the innermost Where() node. We also bypass certain types of calls.
            var treeCopier = new ItemPricingExpressionTreeModifier<THeader, TDetail, TService>(queryableData);
            var newExpressionTree = treeCopier.Visit(expression);

            // This step creates an IQueryable that executes by
            // replacing Queryable methods with Enumerable methods. 
            if (isEnumerable)
            {
                return queryableData.Provider.CreateQuery(newExpressionTree);
            }
            return queryableData.Provider.Execute(newExpressionTree);
        }

        #endregion

        #region Helper methods for the main Execute method.
        /// <summary>
        /// Builds an enumerable response.
        /// </summary>
        /// <returns>The desired enumerable response.</returns>
        protected override EnumerableResponse<THeader> BuildEnumerableResponse()
        {
            EnumerableResponse<THeader> enumerableResponse;
            if (Take > 0)
            {
                // If skip is not divisible by take, then slowly increment the amount
                // to take until the data that we want fits on a single page, then prune.
                var newTake = Take;
                while ((Skip / newTake + 1) * newTake < (Skip + Take))
                {
                    newTake++;
                }
                enumerableResponse = Service.Get(Skip / newTake, newTake, WhereExpression, OrderBy);
                enumerableResponse.Items = enumerableResponse.Items.Skip(Skip % newTake).Take(Take);

                foreach (THeader model in enumerableResponse.Items)
                {
                    //Get the ItemPricingDetail
                    var details = Service.GetDetail(Skip / newTake, newTake, model, null, null);
                    if (details != null)
                    {
                        model.ItemPricingDetails.Items = details.Items;
                        model.ItemPricingDetails.TotalResultsCount = details.TotalResultsCount;
                    }

                    //Get PriceListTaxAuthorities
                    var taxDetails = Service.GetTaxDetail(Skip/newTake, newTake, model, null, null);
                    if (taxDetails != null)
                    {
                        model.PriceListTaxAuthorities.Items = taxDetails.Items;
                        model.PriceListTaxAuthorities.TotalResultsCount = taxDetails.TotalResultsCount;
                    }

                    //Get PricingPriceChecks
                    var checkDetails = Service.GetPriceCheckDetail(Skip / newTake, newTake, model, null, null);
                    if (checkDetails != null)
                    {
                        model.PricingPriceChecks.Items = checkDetails.Items;
                        model.PricingPriceChecks.TotalResultsCount = checkDetails.TotalResultsCount;
                    }
                }
            }
            else
            {
                enumerableResponse = new EnumerableResponse<THeader>();
            }

            return enumerableResponse;
        }

        #endregion

    }
}
