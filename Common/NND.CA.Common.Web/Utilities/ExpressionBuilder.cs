/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Helper for Expression - which will resolve the class and create a filter expression
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ExpressionBuilder<T> where T : ModelBase
    {
        #region Private Constants

        private const string MethodLessThanOrEqual = "LessThanOrEqual";
        private const string MethodGreaterThanOrEqual = "GreaterThanOrEqual";
        private const string MethodLessThan = "LessThan";
        private const string MethodGreaterThan = "GreaterThan";
        private const string MethodStartsWith = "StartsWithExtension";
        private const string MethodContains = "ContainsExtension";

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to create the expression out of FIndFilter class
        /// </summary>
        /// <param name="filters">The filter objects</param>
        /// <returns>Expression</returns>
        public static Expression<Func<T, Boolean>> CreateExpression(IList<IList<Filter>> filters)
        {
            if (filters == null)
            {
                return null;
            }
            var parameterExp = Expression.Parameter(typeof (T), "model");

            Expression completeExpression = null;
            //filterRows are AND operations
            //filterColumns are OR operation
            foreach (var filterRow in filters)
            {
                if (filterRow == null)
                {
                    continue;
                }
                Expression andExpression = null;
                
                foreach (var filterColumn in
                    filterRow.Where(
                        filterColumn =>
                            filterColumn != null && filterColumn.Field != null && filterColumn.Field.field != null))
                {
                    if (filterColumn == null || (filterColumn.Value == null && !filterColumn.ApplyFilterIfNull))
                    {
                        continue;
                    }

                    var expression = GetExpression(filterColumn, parameterExp);

                    andExpression = andExpression == null ? expression : Expression.And(andExpression, expression);
                }

                if (andExpression != null)
                {
                    completeExpression = completeExpression == null
                        ? andExpression
                        : Expression.Or(completeExpression, andExpression);
                }
            }
            return completeExpression != null
                ? Expression.Lambda<Func<T, bool>>(completeExpression, parameterExp)
                : null;
        }

        /// <summary>
        /// Method to create the expression out of FIndFilter class
        /// </summary>
        /// <param name="filter">The filter object</param>
        /// <param name="parameterExp">Parameter expression</param>
        /// <returns>Expression</returns>
        public static Expression<Func<T, Boolean>> CreateExpression(Filter filter,
            ParameterExpression parameterExp = null)
        {
            if (filter == null || filter.Value == null || string.IsNullOrEmpty(filter.Value.ToString()))
            {
                return null;
            }
            if (parameterExp == null)
            {
                parameterExp = Expression.Parameter(typeof (T), "model");
            }

            var completeExpression = GetExpression(filter, parameterExp);

            return completeExpression != null
                ? Expression.Lambda<Func<T, bool>>(completeExpression, parameterExp)
                : null;
        }


        /// <summary>
        /// Method to create the expression out of FIndFilter class
        /// </summary>
        /// <param name="filter">The filter object</param>
        /// <param name="parameterExp">Parameter expression</param>
        /// <returns>Expression</returns>
        public static Expression<Predicate<T>> CreatePredicateExpression(Filter filter,
            ParameterExpression parameterExp = null)
        {
            if (filter == null ||
                ((filter.Value == null || filter.Value.ToString() == string.Empty) && !filter.ApplyFilterIfNull))
            {
                return null;
            }

            if (parameterExp == null)
            {
                parameterExp = Expression.Parameter(typeof(T), "model");
            }

            var completeExpression = GetExpression(filter, parameterExp);

            return completeExpression != null
                ? Expression.Lambda<Predicate<T>>(completeExpression, parameterExp)
                : null;
        }


        /// <summary>
        /// Add Expressions
        /// </summary>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static Expression<Func<T, Boolean>> AddExpression(IList<Expression<Func<T, Boolean>>> expressions)
        {
            Expression<Func<T, Boolean>> completeExpression = null;
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
                    completeExpression = Expression.Lambda<Func<T, bool>>(body, parameterExpression);
                }
            }
            return completeExpression;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Private method to get the expression
        /// </summary>
        /// <param name="filter">Filter object (single)</param>
        /// <param name="parameterExp">parameter expression</param>
        /// <returns>Expression</returns>
        private static Expression GetExpression(Filter filter, ParameterExpression parameterExp)
        {
            if ((filter.Value == null || filter.Value.ToString() == string.Empty) && !filter.ApplyFilterIfNull)
            {
                return null;
            }

            Expression propertyExp;
            PropertyInfo propertyInfo;
            var propertyName = filter.Field.fieldToQuery ?? filter.Field.field;

            if (propertyName.Contains("."))
            {
                var parts = propertyName.Split('.');
                propertyInfo = typeof (T).GetProperty(parts[0]);
                Expression propertyAccess = Expression.Property(parameterExp, propertyInfo);
                for (var i = 1; i < parts.Length; i++)
                {
                    propertyInfo = propertyInfo.PropertyType.GetProperty(parts[i]);
                    propertyAccess = Expression.Property(propertyAccess, propertyInfo);
                }
                propertyExp = propertyAccess;
            }
            else
            {
                propertyInfo = typeof (T).GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    propertyExp = Expression.Property(parameterExp, propertyInfo);
                }
                else
                {
                    return null;
                }
            }

            return GetExpression(filter, propertyExp, propertyInfo);
        }

        /// <summary>
        /// Get the expression based on filters and operator
        /// </summary>
        /// <param name="propertyExp"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="filterColumn"></param>
        /// <returns></returns>
        private static Expression GetExpression(Filter filterColumn, Expression propertyExp, PropertyInfo propertyInfo)
        {
            switch (filterColumn.Operator)
            {
                case Operator.LessThan:
                    if (propertyInfo.PropertyType == typeof (string))
                    {
                        return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodLessThan);
                    }

                    return Expression.LessThan(propertyExp, GetRightExpression(propertyInfo, filterColumn.Value));
                case Operator.LessThanOrEqual:
                    if (propertyInfo.PropertyType == typeof (string))
                    {
                        return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodLessThanOrEqual);
                    }

                    return Expression.LessThanOrEqual(propertyExp, GetRightExpression(propertyInfo, filterColumn.Value));
                case Operator.GreaterThan:
                    if (propertyInfo.PropertyType == typeof (string))
                    {
                        return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodGreaterThan);
                    }

                    return Expression.GreaterThan(propertyExp, GetRightExpression(propertyInfo, filterColumn.Value));
                case Operator.GreaterThanOrEqual:
                    if (propertyInfo.PropertyType == typeof (string))
                    {
                        return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodGreaterThanOrEqual);
                    }

                    return Expression.GreaterThanOrEqual(propertyExp,
                        GetRightExpression(propertyInfo, filterColumn.Value));
                case Operator.NotEqual:
                    return Expression.NotEqual(propertyExp, GetRightExpression(propertyInfo, filterColumn.Value));
                case Operator.Like:
                case Operator.Contains:
                    return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodContains);
                case Operator.StartsWith:
                    return GetStringComparisonExpression(propertyExp, filterColumn.Value, MethodStartsWith);
                default:
                    return Expression.Equal(propertyExp, GetRightExpression(propertyInfo, filterColumn.Value));
            }
        }

        /// <summary>
        /// Resolve Datatype, and convert the values to correct type
        /// </summary>
        /// <param name="propertyInfo">Property details of the class (generic)</param>
        /// <param name="constant">Initial Value</param>
        /// <returns>Converted Value</returns>
        private static Expression GetRightExpression(PropertyInfo propertyInfo, object constant)
        {
            if (propertyInfo.PropertyType.BaseType == typeof (Enum))
            {
                return Expression.Constant(EnumUtility.GetEnum(propertyInfo.PropertyType, constant.ToString()));

                //var fieldValue = constant.ToString();

                //// Expecting if the enum value is Char then the length of fieldValue will be one 1
                //// This condition is required, since it got used in many places.
                //if (fieldValue.Length == 1)
                //{
                //    var charValue = EnumUtility.IsStringHasNumber(fieldValue) ? Convert.ToInt32(fieldValue) : fieldValue[0];
                //    return Expression.Constant(Enum.Parse(propertyInfo.PropertyType, charValue.ToString(CultureInfo.InstalledUICulture)));
                //}

                //return Expression.Constant(Enum.Parse(propertyInfo.PropertyType, constant.ToString()));
            }

            if (propertyInfo.PropertyType == typeof (DateTime) || propertyInfo.PropertyType == typeof (DateTime?))
            {
                // If datetime is invalid use the minimum value of datetime.
                constant = DateUtil.GetDate(constant.ToString(), DateUtil.GetMinDate());

                Expression expression = Expression.Constant(constant);

                if (expression.Type != propertyInfo.PropertyType)
                {
                    return Expression.Convert(expression, propertyInfo.PropertyType);
                }
            }

            if (propertyInfo.PropertyType == typeof (Boolean))
            {
                if (constant.ToString() == "1" || constant.ToString() == "0")
                {
                    constant = Convert.ToInt16(constant);
                }
            }
            else if (propertyInfo.PropertyType == typeof(TimeSpan))
            {
                if (constant == null || string.IsNullOrEmpty(constant.ToString()))
                {
                    constant = TimeSpan.Zero;
                }
                constant = TimeUtil.ConvertToTimeSpan(constant.ToString());
            }

            return Expression.Constant(Convert.ChangeType(constant, propertyInfo.PropertyType));
        }

        /// <summary>
        /// Get Expression for Strings
        /// </summary>
        /// <param name="propertyExp">Property Expression</param>
        /// <param name="propertyValue">Property Value</param>
        /// <param name="methodName"></param>
        /// <returns>Expression</returns>
        private static Expression GetStringComparisonExpression(Expression propertyExp, object propertyValue,
            string methodName)
        {
            var method = typeof (StringExtensions).GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            var expressionValue = Expression.Constant(Convert.ChangeType(propertyValue, typeof(string)), typeof(string));
            return Expression.Call(null, method, propertyExp, expressionValue);
        }

        #endregion
    }
}