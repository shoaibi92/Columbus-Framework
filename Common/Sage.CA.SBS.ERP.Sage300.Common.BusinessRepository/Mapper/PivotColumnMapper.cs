/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// Class PivotColumnMapper.
    /// </summary>
    public class PivotColumnMapper
    {
        /// <summary>
        /// Maps the pivot columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="columnMappers">The column mappers.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> MapPivotColumns<T>(IBusinessEntity entity, Dictionary<string, Action<T, object>> columnMappers)
            where T : PivotColumnModelBase, new()
        {
            List<T> columnValues = new List<T>();
            T templateColumn = new T();
            T valueColumn;
            for (int loopCounter = templateColumn.StartIndex; loopCounter <= templateColumn.EndIndex; loopCounter++)
            {
                valueColumn = new T();

                foreach (string column in templateColumn.ColumnNamesFormat)
                {
                    valueColumn.ColumnIndex = loopCounter;
                    string columnName = string.Format(column, loopCounter);
                    var value = entity.GetValue<string>(columnName);

                    if (columnMappers.ContainsKey(column))
                    {
                        var action = columnMappers[column];
                        action(valueColumn, value);
                    }
                }
                columnValues.Add(valueColumn);
            }

            return columnValues;
        }

        /// <summary>
        /// Maps the pivot columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="values">The values.</param>
        /// <param name="columnMappers">The column mappers.</param>
        public void MapPivotColumns<T>(IBusinessEntity entity, List<T> values,
            Dictionary<string, Func<T, object>> columnMappers) where T : PivotColumnModelBase, new()
        {
            T templateColumn = new T();
            for (int loopCounter = templateColumn.StartIndex; loopCounter <= templateColumn.EndIndex; loopCounter++)
            {
                T rowValue = values[loopCounter - templateColumn.StartIndex];
                foreach (string column in templateColumn.ColumnNamesFormat)
                {
                    string columnName = string.Format(column, loopCounter);
                    if (columnMappers.ContainsKey(column))
                    {
                        var action = columnMappers[column];
                        object value = action(rowValue);
                        entity.SetValue(columnName, value, true);
                    }
                }
            }
        }
    }
}