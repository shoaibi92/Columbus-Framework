/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Order By Helper class to get the property index and sort direction 
    /// </summary>
    public static class OrderByHelper
    {
        /// <summary>
        /// Get Parameter Name Index
        /// </summary>
        /// <param name="orderBy">Order By paramter name and sort direction</param>
        /// <returns>Property Index</returns>
        public static int GetIndex<T>(OrderBy orderBy) where T : ModelBase
        {
            if (orderBy == null || string.IsNullOrEmpty(orderBy.PropertyName)) return 0;
            return GetIndex(typeof(T), orderBy.PropertyName);
        }

        /// <summary>
        /// Get Sort Direction Is Ascending or not
        /// </summary>
        /// <param name="orderBy">Order By paramter name and sort direction</param>
        /// <returns>True or False if SortDirection.Ascending</returns>
        public static bool IsAscending(OrderBy orderBy)
        {
            if (orderBy == null) return true;
            return orderBy.SortDirection == SortDirection.Ascending;
        }

        /// <summary>
        /// Get Parameter Name Index
        /// </summary>
        /// <param name="model">Generic Model</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Index of property name</returns>
        public static int GetIndex(Type model, string propertyName)
        {
            Type fieldClass = model.GetNestedType("Keys");

            if (fieldClass == null)
            {
                return 0;
            }
            FieldInfo field = fieldClass.GetField(propertyName);

            if (field == null)
            {
                return 0;
            }
            return Convert.ToInt32(field.GetValue(null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="orderBy">Order By paramter name and sort direction</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, OrderBy orderBy)
        {
            var properties = orderBy.PropertyName.Split('.');
            var type = typeof(T);

            var arg = Expression.Parameter(type, "p");
            Expression expr = arg;
            foreach (var prop in properties)
            {
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);
            var methodName = orderBy.SortDirection == SortDirection.Ascending ? "OrderBy" : "OrderByDescending";

            return
                (IOrderedQueryable<T>)
                    typeof(Queryable).GetMethods()
                        .Single(
                            method =>
                                method.Name == methodName && method.IsGenericMethodDefinition &&
                                method.GetGenericArguments().Length == 2 && method.GetParameters().Length == 2)
                        .MakeGenericMethod(typeof(T), type)
                        .Invoke(null, new object[] { queryable, lambda });
        }
    }
}