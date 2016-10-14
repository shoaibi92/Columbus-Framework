/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Diagnostics;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    internal class EnumModifier : ExpressionVisitor
    {
        /// <summary>
        /// Stores the type of the enum that is currently being processed.
        /// Its value is set when an enum type is found, then reset to null once
        /// it is used for casting purposes.
        /// </summary>
        private Type _enumType;

        /// <summary>
        /// Visits the <see cref="ConstantExpression" />.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            // If _enumType was previously updated, then cast node and reset _enumType.
            if (_enumType != null)
            {
                var enumData = Enum.ToObject(_enumType, node.Value);
                _enumType = null;
                return Expression.Constant(enumData);
            }
            return node;
        }

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
                // Check if the operand's base type is an enum.
                var operType = node.Operand.Type;
                if (operType.BaseType == typeof(Enum))
                {
                    Debug.Assert(_enumType == null, "_enumType must be reset to null");

                    // Remember the _enumType and skip node conversion.
                    _enumType = operType;
                    return Visit(node.Operand);
                }
                // Else, we're converting to some non-enum type, which is fine.
            }
            return base.VisitUnary(node);
        }

        /// <summary>
        /// Visits the children of the <see cref="BinaryExpression" />.
        /// </summary>
        /// <param name="node">The expression to be visited.</param>
        /// <returns>The modified expression, if it or any subexpression was modified;
        /// otherwise, returns the original expression.</returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            // Comparisons are still well-defined if we change types.
            // We must explicitly override this method to skip validation.
            if (node.NodeType == ExpressionType.Equal
                || node.NodeType == ExpressionType.NotEqual)
            {
                // IMPORTANT: Left must be visited before right!
                // This way, we can extract the correct _enumType for casting.
                var left = Visit(node.Left);
                var convert = VisitAndConvert(node.Conversion, "VisitBinary");
                var right = Visit(node.Right);
                return node.Update(left, convert, right);
            }
            return base.VisitBinary(node);
        }
    }
}