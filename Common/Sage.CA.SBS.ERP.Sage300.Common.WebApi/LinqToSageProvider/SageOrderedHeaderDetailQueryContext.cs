/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// The code in this SageOrderedHeaderDetailQueryContext class is very specific to this Sage provider.
    /// Thus, we encapsulated the Execute logic in this class instead of inserting it
    /// directly into the more generic IQueryProvider implementation.
    /// </summary>
    /// <typeparam name="THeader">The header model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    /// <typeparam name="TDetail">The detail model.</typeparam>
    internal class SageOrderedHeaderDetailQueryContext<THeader, TDetail, TService> : SageQueryContext<THeader, TService>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TService : IOrderedHeaderDetailService<THeader, TDetail>
    {
        #region Private Property

        private readonly Dictionary<string, string> _detailNameDictionary = new Dictionary<string, string>();

        #endregion

        private void InitializeDictionary()
        {
            _detailNameDictionary["ItemUnitOfMeasure"] = "UnitOfMeasureItems";
            _detailNameDictionary["CustomerOptionalFieldValues"] = "CustomerOptionalFieldValues";
            _detailNameDictionary["CustGrpOptFldValue"] = "CustGrpOptFldValue";
            _detailNameDictionary["CategoryTaxAuthority"] = "CategoryTaxAuthDetail";
        }

        #region Constructor.

        /// <summary>
        /// Initializes a new instance of SageOrderedHeaderDetailQueryContext class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SageOrderedHeaderDetailQueryContext(Context context)
            : base(context)
        {
            InitializeDictionary();
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
            var treeCopier = new OrderedHeaderDetailExpressionTreeModifier<THeader, TDetail, TService>(queryableData);
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

                var tdetailType = typeof(TDetail);
                var tdetailName = tdetailType.Name;
                var tdetailPropertyName = _detailNameDictionary[tdetailName];

                foreach (THeader model in enumerableResponse.Items)
                {
                    var genericList = typeof(List<>).MakeGenericType(tdetailType);

                    //Get the model details from database
                    var options = Service.GetDetail(Skip/newTake, newTake, model, null, null);
                    if (options == null)
                    {
                        continue;
                    }

                    var enumReponse = options.Items;
                    //Get the details field of the current model
                    var modelType = model.GetType();
                    var modelDetailsProp = modelType.GetProperty(tdetailPropertyName);
                    var modelDetails = modelDetailsProp.GetValue(model);
                    //Get the items of the details field
                    var modelDetailsItemsProp = modelDetails.GetType().GetProperty("Items");

                    dynamic optionList = Activator.CreateInstance(genericList);

                    //Set the details of the current model
                    foreach (var option in enumReponse)
                    {
                        optionList.Add(option);
                    }

                    modelDetailsItemsProp.SetValue(modelDetails, optionList);

                    var modelDetailsTotalCountProp = modelDetails.GetType().GetProperty("TotalResultsCount");
                    modelDetailsTotalCountProp.SetValue(modelDetails, options.TotalResultsCount);
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