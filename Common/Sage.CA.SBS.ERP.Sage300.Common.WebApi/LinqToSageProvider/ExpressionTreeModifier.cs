/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// Class ExpressionTreeModifier.
    /// </summary>
    /// <typeparam name="TModel">The data model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    internal class ExpressionTreeModifier<TModel, TService> : ExpressionVisitor  
        where TModel : ModelBase, new()
        where TService : IEntityService<TModel>
    {
        protected IQueryable<TModel> QueryableData { get; private set; }

        internal ExpressionTreeModifier(IQueryable<TModel> data)
        {
            QueryableData = data;
        }

        /// <summary>
        /// Visits the <see cref="ConstantExpression"/>, replacing the
        /// constant QueryableSageData arg with the queryable data collection. 
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(QueryableSageData<TModel, TService>))
                return Expression.Constant(QueryableData);
            return node;
        }

        /// <summary>
        /// Visits the children of the <see cref="MethodCallExpression"/>, bypassing
        /// the blacklisted nodes. Each such node is either previously taken care of
        /// already (like Skip) or ignored entirely (like ThenBy).
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            string[] blacklist = 
            { 
                // Taken care of already.
                "Skip", "Take",
                "OrderBy", "OrderByDescending",
                // Ignored entirely.
                "ThenBy", "ThenByDescending"
            };
            if (blacklist.Contains(node.Method.Name))
            {
                return Visit(node.Arguments[0]);
            }
            return base.VisitMethodCall(node);
        }
    }
}