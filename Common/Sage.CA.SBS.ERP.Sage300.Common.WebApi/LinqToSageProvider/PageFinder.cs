/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    internal sealed class PageFinder : ExpressionVisitor
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool OnlyCountAllRecords { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageFinder" /> class by visiting
        /// the expression so that Skip and Take are updated.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        public PageFinder(Expression node)
        {
            // For some reason, OData will take (PageSize + 1) records instead of PageSize.
            // To fix this, we do another check to make sure that Take is within the limit.
            // TODO: Investigate why this happens.
            var queryAttribute = new SageEnableQueryAttribute();

            Skip = 0;
            Take = queryAttribute.PageSize;
            OnlyCountAllRecords = false;

            Visit(node);
        }

        /// <summary>
        /// Visits the children of the <see cref="MethodCallExpression" /> and
        /// records the skip offset as well as the number of records to take.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Skip")
            {
                // ASSERT: Skip should be 0.
                if (Skip != 0)
                {
                    throw new NotSupportedException("At most one Skip() call allowed.");
                }

                Skip = ExtractIntParameter(node.Arguments[1]);
            }
            else if (node.Method.Name == "Take")
            {
                // Update Take if it is smaller than the previous Take() call.
                Take = Math.Min(Take, ExtractIntParameter(node.Arguments[1]));
            }
            else if (node.Method.Name == "LongCount")
            {
                // If we only want to count all the records,
                // then simulate a GET that takes only one record.
                Take = 1;
                OnlyCountAllRecords = true;
                return node;
            }

            // Recursively check for an inner Skip() or Take().
            Visit(node.Arguments[0]);

            return node;
        }

        /// <summary>
        /// Extracts the integer parameter from the given argument expression.
        /// </summary>
        /// <remarks>
        /// If the integer parameter is negative, then 0 is returned instead.
        /// </remarks>
        /// <param name="argExp">The argument expression to be parsed.</param>
        /// <returns>The desired integer parameter.</returns>
        private static int ExtractIntParameter(Expression argExp)
        {
            int result;

            // Since constant parameterization has been enabled (by default in OData),
            // it's possible for argExp to have type MemberExpression.
            var memExp = argExp as MemberExpression;
            if (memExp != null)
            {
                var intExp = Expression.Convert(memExp, typeof(int));
                var lamExp = Expression.Lambda<Func<int>>(intExp);
                var intFunc = lamExp.Compile();
                result = intFunc();
            }
            else
            {
                var constExp = argExp as ConstantExpression;
                if (constExp != null)
                {
                    result = (int)constExp.Value;
                }
                else
                {
                    throw new NotSupportedException("ERROR: argExp must either be a MemberExpression or a ConstantExpression.");
                }
            }

            if (result < 0) // Ignore negative integer parameters.
            {
                result = 0;
            }

            return result;
        }
    }
}