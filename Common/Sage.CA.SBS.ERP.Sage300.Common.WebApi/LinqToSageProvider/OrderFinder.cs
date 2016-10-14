/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    internal sealed class OrderFinder : ExpressionVisitor
    {
        public string PropName { get; set; }
        public SortDirection SortDir { get; set; }

        /// <summary>
        /// On initialization, visit the expression so that PropName and SortDir
        /// are updated.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        public OrderFinder(Expression node)
        {
            Visit(node);
        }

        /// <summary>
        /// Visits the children of the <see cref="MethodCallExpression" /> and
        /// records the property to be ordered on as well as the sort direction.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "OrderBy")
            {
                SortDir = SortDirection.Ascending;
                var lambdaExpression = (LambdaExpression)((UnaryExpression)(node.Arguments[1])).Operand;
                PropName = ((MemberExpression)lambdaExpression.Body).Member.Name;
            }
            else if (node.Method.Name == "OrderByDescending")
            {
                SortDir = SortDirection.Descending;
                var lambdaExpression = (LambdaExpression)((UnaryExpression)(node.Arguments[1])).Operand;
                PropName = ((MemberExpression)lambdaExpression.Body).Member.Name;
            }

            // Recursively check for an inner OrderBy() or OrderByDescending().
            Visit(node.Arguments[0]);

            return node;
        }
    }
}