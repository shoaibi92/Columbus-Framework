/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// class for building data migration model using reflection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class PropertyBuilder<T> where T : ModelBase
    {
        /// <summary>
        /// Updates the column names and identifier.
        /// </summary>
        /// <param name="gridFields">The grid fields.</param>
        /// <returns>IList&lt;GridField&gt;.</returns>
        public static IList<BusinessEntityField> UpdateColumnNamesAndId(IList<BusinessEntityField> gridFields)
        {
            var modelClass = typeof (T);
            var fieldClass = modelClass.GetNestedType("Fields");
            var indexClass = modelClass.GetNestedType("Index");
            foreach (var gridField in gridFields)
            {
                var field = fieldClass.GetField(gridField.field);
                if (field == null)
                {
                    if (modelClass.BaseType != null) 
                        fieldClass = modelClass.BaseType.GetNestedType("BaseFields");
                    field = fieldClass.GetField(gridField.field);
                }
                var index = indexClass.GetField(gridField.field);
                gridField.columnName = field.GetValue(null).ToString();
                gridField.columnId = Convert.ToInt16(index.GetValue(null));
            }
            return gridFields;
        }
    }
}