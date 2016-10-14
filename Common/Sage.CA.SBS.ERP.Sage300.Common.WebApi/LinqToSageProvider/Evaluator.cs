/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// Class Evaluator.
    /// </summary>
    public static class Evaluator
    {
        #region Partial evaluation (for InnermostWhereFinder).

        /// <summary> 
        /// Performs evaluation and replacement of independent sub-trees.
        /// </summary> 
        /// <param name="expression">The root of the expression tree.</param>
        /// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
        /// <returns>A new tree with sub-trees evaluated and replaced.</returns> 
        public static Expression PartialEval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
        {
            return new SubtreeEvaluator(new Nominator(fnCanBeEvaluated).Nominate(expression)).Eval(expression);
        }

        /// <summary> 
        /// Performs evaluation and replacement of independent sub-trees.
        /// </summary> 
        /// <param name="expression">The root of the expression tree.</param>
        /// <returns>A new tree with sub-trees evaluated and replaced.</returns> 
        public static Expression PartialEval(Expression expression)
        {
            return PartialEval(expression, CanBeEvaluatedLocally);
        }

        private static bool CanBeEvaluatedLocally(Expression expression)
        {
            return expression.NodeType != ExpressionType.Parameter;
        }

        /// <summary> 
        /// Evaluates and replaces sub-trees when first candidate is reached (top-down).
        /// </summary> 
        class SubtreeEvaluator : ExpressionVisitor
        {
            readonly HashSet<Expression> _candidates;

            internal SubtreeEvaluator(HashSet<Expression> candidates)
            {
                _candidates = candidates;
            }

            internal Expression Eval(Expression exp)
            {
                return Visit(exp);
            }

            public override Expression Visit(Expression exp)
            {
                if (exp == null)
                {
                    return null;
                }
                if (_candidates.Contains(exp))
                {
                    return Evaluate(exp);
                }
                return base.Visit(exp);
            }

            private static Expression Evaluate(Expression e)
            {
                if (e.NodeType == ExpressionType.Constant)
                {
                    return e;
                }
                var lambda = Expression.Lambda(e);
                var fn = lambda.Compile();
                return Expression.Constant(fn.DynamicInvoke(null), e.Type);
            }
        }

        /// <summary> 
        /// Performs bottom-up analysis to determine which nodes can possibly 
        /// be part of an evaluated sub-tree. 
        /// </summary> 
        class Nominator : ExpressionVisitor
        {
            readonly Func<Expression, bool> _fnCanBeEvaluated;
            HashSet<Expression> _candidates;
            bool _cannotBeEvaluated;

            internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
            {
                _fnCanBeEvaluated = fnCanBeEvaluated;
            }

            internal HashSet<Expression> Nominate(Expression expression)
            {
                _candidates = new HashSet<Expression>();
                Visit(expression);
                return _candidates;
            }

            public override Expression Visit(Expression expression)
            {
                if (expression == null)
                    return null;

                var saveCannotBeEvaluated = _cannotBeEvaluated;
                _cannotBeEvaluated = false;
                base.Visit(expression);

                if (!_cannotBeEvaluated)
                {
                    if (_fnCanBeEvaluated(expression))
                    {
                        _candidates.Add(expression);
                    }
                    else
                    {
                        _cannotBeEvaluated = true;
                    }
                }
                _cannotBeEvaluated |= saveCannotBeEvaluated;
                return expression;
            }
        }

        #endregion

        #region GetValue compilation (for DELETE).

        /// <summary>
        /// Partially evaluates the given filter, then compiles the filter's GetValue
        /// method. An example of how the lambda expression's body changes:
        /// BEFORE: Convert(System.String UnformattedAccount.GetValue(m)) == "1001"
        ///  AFTER: m.UnformattedAccount == "1001"
        /// </summary>
        /// <param name="filter">The filter to be partially evaluated/compiled.</param>
        /// <returns>The new compiled expression.</returns>
        public static Expression CompileGetValue(LambdaExpression filter)
        {
            var evaluatedFilter = PartialEval(filter);
            var getValueModifier = new GetValueModifier();
            return getValueModifier.Visit(evaluatedFilter);
        }

        class GetValueModifier : ExpressionVisitor
        {
            /// <summary>
            /// Visits the children of the <see cref="UnaryExpression" />.
            /// </summary>
            /// <param name="node">The expression to be visited.</param>
            /// <returns>The modified expression, if it or any subexpression was modified;
            /// otherwise, returns the original expression.</returns>
            protected override Expression VisitUnary(UnaryExpression node)
            {
                if (node.NodeType == ExpressionType.Convert)
                {
                    var callNode = (MethodCallExpression) node.Operand;
                    var constNode = (ConstantExpression) callNode.Object;
                    Debug.Assert(constNode != null, "constNode must not be null");
                    var memberInfo = (MemberInfo) constNode.Value;
                    var paramNode = callNode.Arguments[0];
                    return Expression.MakeMemberAccess(paramNode, memberInfo);
                }
                return base.VisitUnary(node);
            }
        }

        #endregion
    }
}