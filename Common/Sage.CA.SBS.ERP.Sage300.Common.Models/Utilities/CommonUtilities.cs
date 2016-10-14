/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities
{
    /// <summary>
    /// Common utilities
    /// </summary>
    public static class CommonUtilities
    {
        #region Private Variables

        private const string Entity = "Entity";

        #endregion

        /// <summary>
        /// Get Business Entity Description - Export/Import table name
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="resourceKey">resource key</param>
        /// <returns>Description from resource file</returns>
        public static string GetExportImportTableName<T>(string resourceKey) where T : ModelBase
        {
            var constantClass = typeof(Constant);
            var constantField = constantClass.GetField(resourceKey);
            if (constantField == null)
            {
                return resourceKey;
            }
            var resxNamespace = constantField.GetValue(null).ToString();

            var modelClass = typeof(T);
            var modelField = modelClass.GetField("EntityName");
            var modelFieldValue = modelField.GetValue(null).ToString();
            var tableName = ResourceUtil.GetString(resxNamespace, modelFieldValue) ?? ResourceUtil.GetString(resxNamespace, Entity);

            if (tableName.Length > 31)
            {
                tableName = tableName.Substring(0, 31);
            }
            return tableName;
        }

        /// <summary>
        /// Comparer business models using their properties with Key attributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ModelKeyComparer<T> : IEqualityComparer<T> where T : ModelBase
        {
            /// <summary>
            /// Compare model base on their properties with Key attribute
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public bool Equals(T x, T y)
            {
                List<PropertyInfo> keyProperties = typeof(T).GetProperties().Where(p => Attribute.IsDefined(p, typeof(System.ComponentModel.DataAnnotations.KeyAttribute))).ToList();
                bool isEqual = true;

                foreach (var keyProperty in keyProperties)
                {
                    isEqual = keyProperty.GetValue(x, null) == keyProperty.GetValue(y, null);
                    if (!isEqual)
                    {
                        break;
                    }
                }

                return isEqual;
            }

            /// <summary>
            /// Return HashCode
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}