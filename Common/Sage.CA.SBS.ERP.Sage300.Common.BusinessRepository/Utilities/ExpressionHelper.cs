/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Resources.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Expression Helper class - In-progress - still working on it support all filter condition
    /// </summary>
    public static class ExpressionHelper
    {
        #region Constants

        private const string GreaterThan = ">";
        private const string GreaterThanOrEqual = ">=";
        private const string LessThan = "<";
        private const string LessThanOrEqual = "<=";
        private const string Equal = "=";
        private const string NotEqual = "!=";
        private const string And = "AND";
        private const string Or = "OR";
        private const string Like = "LIKE";
        private const string Contains = "Contains";
        private const string StartsWith = "StartsWith";
        private const string EndsWith = "EndsWith";
        private const string True = "1";
        internal const string LeftBracket = "(";
        internal const string RightBracket = ")";
        private const string MethodLessThanOrEqual = "LessThanOrEqual";
        private const string MethodGreaterThanOrEqual = "GreaterThanOrEqual";
        private const string MethodLessThan = "LessThan";
        private const string MethodGreaterThan = "GreaterThan";
        private const string MethodStartsWith = "StartsWithExtension";
        private const string MethodContains = "ContainsExtension";

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
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string Translate<T>(Expression<Func<T, Boolean>> expression)
        {
            var sw = new Stopwatch();
            sw.Start();
            var translator = new ExpressionTranslator();
            string filter = translator.Translate(expression);

            Debug.WriteLine("Time to translate expression (ms) : [{0}]", sw.Elapsed.TotalMilliseconds);
            sw.Stop();
            return filter;
        }

        /// <summary>
        /// Add Expressions
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static Expression<Func<TModel, Boolean>> AddExpression<TModel>(IList<Expression<Func<TModel, Boolean>>> expressions) where TModel : ModelBase
        {
            Expression<Func<TModel, Boolean>> completeExpression = null;
            var parameterExpression = expressions[0].Parameters[0];
            foreach (var expression in expressions)
            {
                if (completeExpression == null)
                {
                    completeExpression = expression;
                }
                else
                {
                    var body = Expression.AndAlso(completeExpression.Body, expression.Body);
                    completeExpression = Expression.Lambda<Func<TModel, bool>>(body, parameterExpression);
                }
            }
            return completeExpression;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Gets the string representation of the expression node
        /// </summary>
        /// <param name="nodeType">expression node</param>
        /// <returns>string represenation of the passed expression node</returns>
        internal static string GetOperator(ExpressionType nodeType)
        {
            switch (nodeType)
            {
                case ExpressionType.GreaterThan:
                    return GreaterThan;
                case ExpressionType.GreaterThanOrEqual:
                    return GreaterThanOrEqual;
                case ExpressionType.LessThan:
                    return LessThan;
                case ExpressionType.LessThanOrEqual:
                    return LessThanOrEqual;
                case ExpressionType.NotEqual:
                    return NotEqual;
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return And;
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return Or;
                case ExpressionType.Not:
                    return NotEqual;
                default:
                    return Equal;
            }
        }

        /// <summary>
        /// Translates BinaryExpression expression. 
        /// </summary>
        /// <param name="expression">expression that needs to be translated</param>
        /// <param name="filter">translated filter</param>
        /// <returns>true if translation is successful else false</returns>
        internal static bool TryTranslateBinaryExpression(BinaryExpression expression, out string filter)
        {
            filter = string.Empty;
            string leftOperand;
            string rightOperand;
            if (expression == null) return false;

            if (!TryEvaluateOperand(expression.Left, expression, out leftOperand))
            {
                return false;
            }

            if (!TryEvaluateOperand(expression.Right, expression, out rightOperand))
            {
                return false;
            }

            filter = GetExpression(leftOperand, expression.NodeType, rightOperand);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">expression that needs to be translated</param>
        /// <param name="filter">translated filter</param>
        /// <returns>true if translation is successful else false</returns>
        internal static bool TryTranslateMethodCallExpression(MethodCallExpression expression, out string filter)
        {
            filter = string.Empty;
            string leftOperand;
            string rightOperand;

            if (IsStringComparisonMethod(expression))
            {
                //All extension methods are referred here.
                return TryTranslateStringComparisonExpression(expression, out filter);
            }

            if (!IsLikeMethod(expression)) return false;

            if (!TryEvaluateOperand(expression.Object, expression, out leftOperand))
            {
                return false;
            }

            if (!TryEvaluateOperand(expression.Arguments[0], expression, out rightOperand))
            {
                return false;
            }

            if (expression.Method.Name != Contains)
            {
                filter = GetExpression(leftOperand, Like, GetLikeExpression(expression.Method.Name, rightOperand));
            }
            else
            {
                filter = GetLikeFilter(leftOperand, rightOperand, expression.Object);
            }
            return true;
        }

        /// <summary>
        /// Get like filter
        /// </summary>
        /// <param name="leftOperand"></param>
        /// <param name="rightOperand"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static string GetLikeFilter(string leftOperand, string rightOperand, Expression expression)
        {
            int maximumLength = 0;

            //This should always be member access
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = expression as MemberExpression;
                if (memberExpression != null && memberExpression.Expression.NodeType == ExpressionType.Parameter)
                {
                    if (memberExpression.Member.DeclaringType != null)
                    {
                        var attributes =
                            memberExpression.Member.GetCustomAttributes(typeof (StringLengthAttribute)).ToList();
                        if (attributes.Any())
                        {
                            maximumLength = ((StringLengthAttribute) attributes[0]).MaximumLength;
                        }
                    }
                }
            }

            if (rightOperand.Length <= (maximumLength - 2))
            {
                return string.Format("{0}", GetExpression(leftOperand, Like, GetLikeExpression(Contains, rightOperand)));
            }

            if (maximumLength == rightOperand.Length)
            {
                return string.Format("{0}", GetExpression(leftOperand, Like, string.Format(@"""{0}""", rightOperand)));
            }

            return string.Format("( {0} OR {1} OR {2} )",
                GetExpression(leftOperand, Like, GetLikeExpression(StartsWith, rightOperand)),
                GetExpression(leftOperand, Like, GetLikeExpression(EndsWith, rightOperand)),
                GetExpression(leftOperand, Like, GetLikeExpression(Contains, rightOperand)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression">expression that needs to be translated</param>
        /// <param name="filter">translated filter</param>
        /// <returns>true if translation is successful else false</returns>
        private static bool TryTranslateStringComparisonExpression(MethodCallExpression expression, out string filter)
        {
            filter = string.Empty;
            string leftOperand;
            string rightOperand;

            if (!TryEvaluateOperand(expression.Arguments[0], expression, out leftOperand))
            {
                return false;
            }

            if (!TryEvaluateOperand(expression.Arguments[1], expression, out rightOperand))
            {
                return false;
            }

            switch (expression.Method.Name)
            {
                case MethodGreaterThanOrEqual:
                    filter = GetExpression(leftOperand, GreaterThanOrEqual, rightOperand);
                    break;
                case MethodGreaterThan:
                    filter = GetExpression(leftOperand, GreaterThan, rightOperand);
                    break;
                case MethodLessThanOrEqual:
                    filter = GetExpression(leftOperand, LessThanOrEqual, rightOperand);
                    break;
                case MethodLessThan:
                    filter = GetExpression(leftOperand, LessThan, rightOperand);
                    break;
                case MethodContains:
                    filter = GetLikeFilter(leftOperand, rightOperand, expression.Arguments[0]);
                    break;
                case MethodStartsWith:
                    filter = GetExpression(leftOperand, Like, GetLikeExpression(StartsWith, rightOperand));
                    break;
            }

            return true;
        }

        /// <summary>
        /// Translates MemberExpression expression. 
        /// </summary>
        /// <param name="expression">expression that needs to be translated</param>
        /// <param name="filter">translated filter</param>
        /// <returns>true if translation is successful else false</returns>
        internal static bool TryTranslateMemberAccess(MemberExpression expression, out string filter)
        {
            filter = string.Empty;
            string memberName;
            if (!TryEvaluateOperand(expression, expression, out memberName))
            {
                return false;
            }
            filter = GetExpression(memberName, ExpressionType.Equal, True);
            return true;
        }

        /// <summary>
        /// Translates UnaryExpression expression. 
        /// </summary>
        /// <param name="expression">expression that needs to be translated</param>
        /// <param name="filter">translated filter</param>
        /// <returns>true if translation is successful else false</returns>
        internal static bool TryTranslateUnary(UnaryExpression expression, out string filter)
        {
            filter = string.Empty;
            string memberName;
            if (!TryEvaluateOperand(expression, expression, out memberName))
            {
                return false;
            }
            filter = GetExpression(memberName, expression.NodeType, True);
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This method returns the member name understood by Accpac business component.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="propertyName">Propert Name</param>
        /// <returns>Returns the member name understood by Accpac business component</returns>
        private static string GetColumName(MemberExpression filter, string propertyName)
        {
            string memberName;

            if (filter.Member.DeclaringType == null)
            {
                throw new ArgumentException(string.Format(CommonResx.CannotBeBlankMessage, ExpressionsResx.DeclaringType));
            }

            //If declaring type is nullable, we need to retreive the inner expression
            if (IsNullableType(filter.Member.DeclaringType))
            {
                return GetColumName((MemberExpression) filter.Expression, string.Empty);
            }

            //Get the inner class "Fields" to retrieve the member name understood by Accpac business component.
            var fieldClass = filter.Member.DeclaringType.GetNestedType("Fields") ??
                             filter.Member.DeclaringType.GetNestedType("BaseFields");

            if (fieldClass == null)
            {
                throw new Exception(string.Format(CommonResx.RecordNotFoundMessage, ExpressionsResx.Collection,
                    ExpressionsResx.Fields));
            }

            if (string.IsNullOrEmpty(propertyName) || propertyName == "Value")
                //"Value" will be name of the property for nullable type
            {
                memberName = filter.Member.Name;
            }
            else
            {
                var properties = propertyName.Split('.');
                memberName = properties[properties.Length - 1];
            }

            var field = fieldClass.GetField(memberName);
            if (field == null)
            {
                throw new Exception(string.Format(CommonResx.RecordNotFoundMessage, ExpressionsResx.FieldName,
                    memberName));
            }

            return Convert.ToString(field.GetValue(null));
        }

        /// <summary>
        /// Checks for nullable type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsNullableType(Type type)
        {
            return (type == typeof (int?) || type == typeof (bool?) || type == typeof (float?) || type == typeof (long?) ||
                    type == typeof (double?) || type == typeof (DateTime?) | type == typeof (Decimal?));
        }

        /// <summary>
        /// Returns the filter expression based on passed parameters.
        /// </summary>
        /// <param name="leftOperand">leftOperand</param>
        /// <param name="expressionType">expressionType</param>
        /// <param name="rightOperand">rightOperand</param>
        /// <returns>filter expression</returns>
        private static string GetExpression(string leftOperand, ExpressionType expressionType, string rightOperand)
        {
            string operatorType = GetOperator(expressionType);
            return GetExpression(leftOperand, operatorType, rightOperand);
        }

        /// <summary>
        /// Returns the filter expression based on passed parameters.
        /// </summary>
        /// <param name="leftOperand">leftOperand</param>
        /// <param name="expressionType">expressionType</param>
        /// <param name="rightOperand">rightOperand</param>
        /// <returns>filter expression</returns>
        private static string GetExpression(string leftOperand, string expressionType, string rightOperand)
        {
            return string.Format("{0} {1} {2}", leftOperand, expressionType, rightOperand);
        }

        /// <summary>
        /// Get the expression for like operator based on method name
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetLikeExpression(string methodName, string value)
        {
            switch (methodName)
            {
                case Contains:
                {
                    return string.Format(@"""%{0}%""", value);
                }
                case StartsWith:
                {
                    return string.Format(@"""{0}%""", value);
                }
                case EndsWith:
                {
                    return string.Format(@"""%{0}""", value);
                }
                default:
                    throw new ArgumentException(string.Format(ExpressionsResx.NotSupportedMessage,
                        ExpressionsResx.Method, methodName));
            }
        }

        /// <summary>
        /// Validates the like expression. This expression is supported for methods - Contains,StartsWith,EndsWith.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static bool IsLikeMethod(MethodCallExpression expression)
        {
            if ((((expression.Method.Name == Contains || expression.Method.Name == StartsWith ||
                   expression.Method.Name == EndsWith)) && (!expression.Method.IsStatic)) &&
                (((expression.Type == typeof (bool)) && (expression.Arguments.Count == 1))))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// True if method is greaterthan, lessthan, greaterthanequalto or lessthanequalto
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static bool IsStringComparisonMethod(MethodCallExpression expression)
        {
            if ((expression.Method.Name == MethodGreaterThan || expression.Method.Name == MethodGreaterThanOrEqual ||
                 expression.Method.Name == MethodLessThan || expression.Method.Name == MethodLessThanOrEqual ||
                 expression.Method.Name == MethodContains || expression.Method.Name == MethodStartsWith))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compile and evaluate the value of the expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="parentExpression"></param>
        /// <returns></returns>
        private static string EvaluateExpression(Expression expression, Expression parentExpression)
        {
            var expressionObject = Expression.Lambda(expression).Compile().DynamicInvoke();
            return ConvertToStringExpression(expressionObject, parentExpression);
        }

        /// <summary>
        /// Evaluates operands and returns the filter
        /// </summary>
        /// <param name="expression">expression to evaluate</param>
        /// <param name="parentExpression">parent expression</param>
        /// <param name="result">filter result</param>
        /// <returns>true if success else false</returns>
        private static bool TryEvaluateOperand(Expression expression, Expression parentExpression, out string result)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                {
                    return TryEvaluateOperand((ConstantExpression) expression, parentExpression, out result);
                }
                case ExpressionType.MemberAccess:
                {
                    return TryEvaluateOperand((MemberExpression) expression, parentExpression, out result);
                }
                case ExpressionType.Convert:
                {
                    return TryEvaluateOperand((UnaryExpression) expression, parentExpression, out result);
                }
                default:
                {
                    //This should evaluate all the expression that results in a value.
                    //Parameter member type should not be part of this expression.
                    result = EvaluateExpression(expression, parentExpression);
                    return true;
                }
            }
        }

        /// <summary>
        /// Evaluates Unary expression and returns the filter
        /// </summary>
        /// <param name="expression">expression to evaluate</param>
        /// <param name="parentExpression">parent Expression</param>
        /// <param name="result">result</param>
        /// <returns>true if success else false</returns>
        private static bool TryEvaluateOperand(UnaryExpression expression, Expression parentExpression,
            out string result)
        {
            return TryEvaluateOperand(expression.Operand, parentExpression, out result);
        }

        /// <summary>
        /// Evaluates constant expression and returns the filter
        /// </summary>
        /// <param name="expression">expression to evaluate</param>
        /// <param name="parentExpression">parent expression</param>
        /// <param name="result">filter result</param>
        /// <returns>true if success else false</returns>
        private static bool TryEvaluateOperand(ConstantExpression expression, Expression parentExpression,
            out string result)
        {
            result = ConvertToStringExpression(expression.Value, parentExpression);
            return true;
        }

        /// <summary>
        /// Evaluates member expression and returns the filter
        /// </summary>
        /// <param name="expression">expression to evaluate</param>
        /// <param name="parentExpression">parent expression</param>
        /// <param name="result">filter result</param>
        /// <returns>true if success else false</returns>
        private static bool TryEvaluateOperand(MemberExpression expression, Expression parentExpression,
            out string result)
        {
            result = string.Empty;
            string parameterName;
            expression = ReduceMemberExpression(expression, out parameterName);

            switch (expression.Expression.NodeType)
            {
                case ExpressionType.Parameter:
                {
                    //Now we can get the ACCPAC column name based on the expression
                    result = GetColumName(expression, parameterName);
                    return true;
                }
                case ExpressionType.Constant:
                {
                    object expressionObject = null;

                    if (expression.Member is FieldInfo)
                    {
                        expressionObject = ((FieldInfo)expression.Member).GetValue(((ConstantExpression)expression.Expression).Value);
                    }
                    else if (expression.Member is PropertyInfo)
                    {
                        expressionObject = ((PropertyInfo)expression.Member).GetValue(((ConstantExpression)expression.Expression).Value);
                    }

                   
                    if (!string.IsNullOrEmpty(parameterName))
                    {
                        expressionObject = GetPropertyValue(expressionObject, parameterName);
                    }
                    result = ConvertToStringExpression(expressionObject, parentExpression);
                    return true;
                }
                default:
                {
                    if (string.IsNullOrEmpty(parameterName))
                    {
                        result = EvaluateExpression(expression, parentExpression);
                        return true;
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// Replace specific characters related to ACCPAC.
        /// </summary>
        /// <param name="stringToConvert">string to convert</param>
        /// <returns></returns>
        private static string ReplaceCharacters(string stringToConvert){
            var str = Convert.ToString(stringToConvert);
            //quotes and back slash are handled differently.
            if (str.EndsWith(@"\"))
            {
                str = str.Replace(@"\", @"\ ");
            }
            if (str.Contains(@""""))
            {
                str = str.Replace(@"""", @"\""");//Need to add forward space
            }
            return str;
        }

        /// <summary>
        /// Converts the object ot the string expression.
        /// For string - double quotes will be applied.
        /// </summary>
        /// <param name="objectValue">object be converted</param>
        /// <param name="parentExpression">parent expression</param>
        /// <returns>string expression</returns>
        private static string ConvertToStringExpression(object objectValue, Expression parentExpression)
        {
            //Evaluate for null
            if (objectValue == null)
            {
                return string.Format(@"""{0}""", string.Empty);
            }

            if (objectValue is DateTime)
            {
                return DateUtil.GetYearMonthDayDate((DateTime)objectValue, string.Empty);
            }

            if (objectValue is TimeSpan)
            {
                return ((TimeSpan)objectValue).ToString("hhmmss");
            }

            //Evaluate for boolean
            if (objectValue is bool)
            {
                //return 1 or 0 for boolean
                return Convert.ToInt16(objectValue).ToString(CultureInfo.InvariantCulture);
            }

            //Evaluate for string
            if (objectValue is string)
            {
                var str = ReplaceCharacters(Convert.ToString(objectValue));

                var methodCallExpression = parentExpression as MethodCallExpression;
                if (methodCallExpression != null &&
                    (IsLikeMethod(methodCallExpression) ||
                     (methodCallExpression.Method.Name == MethodContains ||
                      methodCallExpression.Method.Name == MethodStartsWith)))
                {
                    //don't do anything. This is taken cared in the method itself.
                    return str;
                }

                return string.Format(@"""{0}""", str);
            }

            if (objectValue.GetType().BaseType == typeof (Enum))
            {
                var enumObj = Enum.Parse(objectValue.GetType(), objectValue.ToString());
                var enumResult = EnumUtility.EnumToString(enumObj);
                return string.Format(@"""{0}""", enumResult); 
            }

            //Evalaute for others
            return Convert.ToString(objectValue);
        }

        /// <summary>
        /// Reduces the Member Expression
        /// </summary>
        /// <param name="expression">Member Expression</param>
        /// <param name="propertyName">Name of the property. This propery will have full name splitted by .
        /// For example for expression vender => vendor.Address.AddressLine1 = object2.Address.AddressLine2, property name will be AddressLine1 for operand1 and 
        /// Address.AddressLine2 for operand 2. Nullable types are ignored</param>
        /// <returns></returns>
        private static MemberExpression ReduceMemberExpression(MemberExpression expression, out string propertyName)
        {
            propertyName = string.Empty;
            while (true)
            {
                if (expression.Expression is MemberExpression)
                {
                    if (!IsNullableType(expression.Member.DeclaringType))
                    {
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            propertyName = "." + propertyName;
                        }
                        propertyName = expression.Member.Name + propertyName;
                    }
                    expression = expression.Expression as MemberExpression;
                }
                else
                {
                    break;
                }
            }
            return expression;
        }

        /// <summary>
        /// Get the value of a property
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        private static object GetPropertyValue(object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
            {
                obj = prop.GetValue(obj, null);
            }

            return obj;
        }

        #endregion
    }
}