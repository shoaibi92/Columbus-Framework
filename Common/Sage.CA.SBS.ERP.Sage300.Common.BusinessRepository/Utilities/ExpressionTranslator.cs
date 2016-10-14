/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;
using System.Text;

using Sage.CA.SBS.ERP.Sage300.Common.Resources.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Expression Translator class - In-progress - still working on it support all filter condition
    /// </summary>
    internal class ExpressionTranslator
    {
        #region Variables

        private readonly StringBuilder _filterBuilder = new StringBuilder();

        #endregion

        #region Public Methods

        /// <summary>
        /// This method translates the expression into string understood by Accpac business components.
        /// Expressions can be of this format
        ///          expression ::= [condition] [Boolean operator] [condition]
        ///            conditon ::= [field-name] [relation-operator] [operand]
        ///    Boolean-operator ::= AND | OR
        ///             operand ::= [field-name] | [constant]
        /// relational-operator ::= > | &lt; | = | &lt;= | >= | != | LIKE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">expression to translate</param>
        /// <returns>translated string</returns>
        public string Translate<T>(Expression<Func<T, Boolean>> expression)
        {
            if (expression == null)
            {
                return string.Empty;
            }
            Visit(expression.Body);
            return _filterBuilder.ToString();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Translates the expression and appends this filter to the filterBuilder
        /// </summary>
        /// <param name="expression"></param>
        private void Visit(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Equal:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.NotEqual:
                    TranslateBinary((BinaryExpression) expression);
                    break;
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    VisitBinary((BinaryExpression) expression);
                    break;
                case ExpressionType.Not:
                    TranslateUnary((UnaryExpression) expression);
                    break;
                case ExpressionType.MemberAccess:
                    TranslateMemberAccess((MemberExpression) expression);
                    break;
                case ExpressionType.Call: //Support for Contains, StartsWith, EndsWith
                    TranslateMethodCall((MethodCallExpression) expression);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExpressionsResx.NotSupportedMessage2,
                        ExpressionsResx.ExpressionType, expression.NodeType));
            }
        }

        /// <summary>
        /// Breaks the expression and calls appropiate translator for left and right expression.
        /// </summary>
        /// <param name="expression">expression to translate</param>
        private void VisitBinary(BinaryExpression expression)
        {
            _filterBuilder.Append(string.Format(" {0} ", ExpressionHelper.LeftBracket));
            Visit(expression.Left);
            _filterBuilder.Append(string.Format(" {0} ", ExpressionHelper.RightBracket));
            _filterBuilder.Append(string.Format(" {0} ", ExpressionHelper.GetOperator(expression.NodeType)));
            _filterBuilder.Append(string.Format(" {0} ", ExpressionHelper.LeftBracket));
            Visit(expression.Right);
            _filterBuilder.Append(string.Format(" {0} ", ExpressionHelper.RightBracket));
        }

        /// <summary>
        /// Translates MethodCallExpression expression and appends this filter to the filterBuilder
        /// Supports - Contains,StartsWith and EndsWith
        /// </summary>
        /// <param name="expression">expression to translate</param>
        private void TranslateMethodCall(MethodCallExpression expression)
        {
            string filter;
            if (ExpressionHelper.TryTranslateMethodCallExpression(expression, out filter))
            {
                _filterBuilder.Append(filter);
                return;
            }
            throw new Exception(string.Format(ExpressionsResx.NotSupportedMessage, ExpressionsResx.Method,
                ExpressionsResx.Expression));
        }

        /// <summary>
        /// Translates BinaryExpression expression and appends this filter to the filterBuilder
        /// </summary>
        /// <param name="expression">expression to translate</param>
        private void TranslateBinary(BinaryExpression expression)
        {
            string filter;

            if (ExpressionHelper.TryTranslateBinaryExpression(expression, out filter))
            {
                _filterBuilder.Append(filter);
                return;
            }
            throw new ArgumentException(string.Format(ExpressionsResx.NotSupportedMessage, ExpressionsResx.Binary,
                ExpressionsResx.Expression));
        }

        /// <summary>
        /// Translates MemberExpression expression and appends this filter to the filterBuilder
        /// </summary>
        /// <param name="expression">expression to translate</param>
        private void TranslateMemberAccess(MemberExpression expression)
        {
            string filter;

            if (ExpressionHelper.TryTranslateMemberAccess(expression, out filter))
            {
                _filterBuilder.Append(filter);
                return;
            }
            throw new ArgumentException(string.Format(ExpressionsResx.NotSupportedMessage, ExpressionsResx.Member,
                ExpressionsResx.Expression));
        }

        /// <summary>
        /// Translates UnaryExpression expression and appends this filter to the filterBuilder
        /// </summary>
        /// <param name="expression">expression to translate</param>
        private void TranslateUnary(UnaryExpression expression)
        {
            string filter;

            if (ExpressionHelper.TryTranslateUnary(expression, out filter))
            {
                _filterBuilder.Append(filter);
                return;
            }
            throw new ArgumentException(string.Format(ExpressionsResx.NotSupportedMessage, ExpressionsResx.Unary,
                ExpressionsResx.Expression));
        }

        #endregion
    }
}