/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    internal class InnermostWhereFinder<TModel> : ExpressionVisitor
        where TModel : ModelBase, new()
    {
        private Expression<Func<TModel, bool>> _innermostWhereExpression;

        /// <summary>
        /// Gets the innermost where expression of the given expression.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The innermost where expression.</returns>
        public Expression<Func<TModel, bool>> GetInnermostWhere(Expression node)
        {
            Visit(node);
            return _innermostWhereExpression;
        }

        /// <summary>
        /// Visits the children of the <see cref="MethodCallExpression" />.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Where")
            {
                // ASSERT: _innermostWhereExpression should be null.
                if (_innermostWhereExpression != null)
                    throw new NotSupportedException("At most one Where() call allowed.");

                // Extract the lambda expression for partial evaluation.
                var unaryExpression = (UnaryExpression)(node.Arguments[1]);
                var lambdaExpression = (LambdaExpression)unaryExpression.Operand;
                _innermostWhereExpression = (Expression<Func<TModel, bool>>)Evaluator.PartialEval(lambdaExpression);
            }

            // Recursively check for an inner Where().
            Visit(node.Arguments[0]);

            return node;
        }
    }
}