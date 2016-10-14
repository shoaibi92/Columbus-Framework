/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// The code in this SageQueryContext class is very specific to this Sage provider.
    /// Thus, we encapsulated the Execute logic in this class instead of inserting it
    /// directly into the more generic IQueryProvider implementation.
    /// </summary>
    /// <typeparam name="TModel">The data model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    internal class SageQueryContext<TModel, TService>
        where TModel : ModelBase, new()
        where TService : IEntityService<TModel>
    {
        #region Properties.

        private Context _context;

        /// <summary>
        /// The filter where expression to be passed to the service layer.
        /// </summary>
        protected Expression<Func<TModel, bool>> WhereExpression { get; set; }

        /// <summary>
        /// The amount of records to skip.
        /// </summary>
        protected int Skip { get; set; }

        /// <summary>
        /// The amount of records to take.
        /// </summary>
        protected int Take { get; set; }

        /// <summary>
        /// The desired property and direction to sort.
        /// </summary>
        protected OrderBy OrderBy { get; set; }

        /// <summary>
        /// The service to be called.
        /// </summary>
        public TService Service
        {
            get
            {
                if (_service == null)
                {
                    _service = _context.Container.Resolve<TService>(new ParameterOverride("context", _context));
                }
                return _service;
            }
            set { _service = value; }
        }

        /// <summary>
        /// The service to be called.
        /// </summary>
        private TService _service;

        #endregion

        #region Constructor.

        /// <summary>
        /// Initializes a new instance of the <see cref="SageQueryContext&lt;TModel, TService&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SageQueryContext(Context context)
        {
            _context = context;
        }

        #endregion

        #region The main Execute method.

        /// <summary>
        /// Executes the expression tree that is passed to it. 
        /// </summary>
        /// <param name="expression">The expression tree to be executed.</param>
        /// <param name="isEnumerable">True iff the result of the query is enumerable.</param>
        /// <returns>The value that results from executing the specified query.</returns>
        internal virtual object Execute(Expression expression, bool isEnumerable)
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
            var treeCopier = new ExpressionTreeModifier<TModel, TService>(queryableData);
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
        /// Extracts the parameters to be passed to the service layer.
        /// ASSERT: Where() and Skip() appear at most once in expression.
        /// </summary>
        /// <param name="expression">The expression tree to be parsed.</param>
        /// <returns>True iff we only want to count all the records.</returns>
        protected bool ExtractServiceParameters(Expression expression) 
        {
            // Handle the enums:
            // - Remove nodes that try to convert enums to ints.
            // - Cast the corresponding constant expressions from int to enum.
            var enumCopier = new EnumModifier();
            var enumExp = enumCopier.Visit(expression);

            // For Where(), get the lambda expression predicate.
            var whereFinder = new InnermostWhereFinder<TModel>();
            WhereExpression = whereFinder.GetInnermostWhere(enumExp);

            // For Skip() and Take(), get their integer parameters.
            var pageFinder = new PageFinder(enumExp);
            Skip = pageFinder.Skip;
            Take = pageFinder.Take;
            var onlyCountAllRecords = pageFinder.OnlyCountAllRecords;

            // For OrderBy() and OrderByDescending(), get the property to be sorted.
            var orderFinder = new OrderFinder(enumExp);
            OrderBy = new OrderBy
            {
                PropertyName = orderFinder.PropName,
                SortDirection = orderFinder.SortDir
            };

            return onlyCountAllRecords;
        }

        /// <summary>
        /// Builds an enumerable response.
        /// </summary>
        /// <returns>The desired enumerable response.</returns>
        protected virtual EnumerableResponse<TModel> BuildEnumerableResponse()
        {
            EnumerableResponse<TModel> enumerableResponse;
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
            }
            else
            {
                enumerableResponse = new EnumerableResponse<TModel>();
            }

            return enumerableResponse;
        }

        #endregion
    }
}