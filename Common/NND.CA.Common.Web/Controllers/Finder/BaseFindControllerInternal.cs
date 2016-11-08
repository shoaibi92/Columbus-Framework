/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Finder;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Finder
{
    /// <summary>
    /// Base class for finder controller internal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public abstract class BaseFindControllerInternal<T, TService> : InternalControllerBase<TService>
        where T : ModelBase, new()
        where TService : IEntityService<T>, ISecurityService
    {
        private readonly string _userPreferencesKey;
        private List<GridColumn> _userPreferences;
        private bool _isUserPreferencesLoaded;

        private readonly bool _hasAccessToAllFields;



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="userPreferencesKey">Key-For saving user specific data</param>
        protected BaseFindControllerInternal(Context context, string userPreferencesKey)
            : base(context)
        {
            _userPreferencesKey = userPreferencesKey;
            _hasAccessToAllFields = HasAccess(Common.Utilities.Security.Finder);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">context</param>
        protected BaseFindControllerInternal(Context context)
            : base(context)
        {
            var screenName = ScreenName.None;
            if (context.ScreenContext != null)
            {
                screenName = context.ScreenContext.ScreenName;
            }
            _userPreferencesKey =
                CommonUtil.StringToGuid(string.Format("{0}_{1}_{2}", screenName, GetType().Namespace, GetType().Name)).ToString();
            _hasAccessToAllFields = HasAccess(Common.Utilities.Security.Finder);
        }

        /// <summary>
        /// UserPreferences
        /// </summary>
        protected List<GridColumn> UserPreferences
        {
            get
            {
                if (_isUserPreferencesLoaded)
                {
                    return _userPreferences;
                }

                if (!string.IsNullOrEmpty(_userPreferencesKey))
                {
                    var commonService = Utilities.Utilities.Resolve<ICommonService>(Context);
                    string userPreferences = commonService.GetUserPreference(_userPreferencesKey);
                    if (userPreferences != null)
                    {
                        _userPreferences = JsonSerializer.DeserializeCompressed<List<GridColumn>>(userPreferences);
                    }
                }
                _isUserPreferencesLoaded = true;
                return _userPreferences;
            }
        }

        /// <summary>
        /// This returns list of columns to be displayed to the user.
        /// </summary>
        /// <returns>List of columns to be display</returns>
        public virtual IEnumerable<ModelBase> GetColumns()
        {
            List<string> preferenceColumns = null;

            if (UserPreferences != null)
            {
                preferenceColumns = (from gridColumn in UserPreferences where !gridColumn.isHidden select gridColumn.field).ToList();
            }

            List<string> defaultOrSelectedColumn = preferenceColumns ?? GetDefaultColumns();

            var allColumns = GetAllColumns().ToList();

            if (!_hasAccessToAllFields)
            {
                var accessibleColumns = allColumns.Where(col => GetDefaultColumns().Contains(((GridField)col).field) || GetMandatoryColumns().Contains(((GridField)col).field));
                allColumns = accessibleColumns.ToList();
            }

            var keyColumns = GetKeyColumns();
            var mandatoryColumns = GetMandatoryColumns();
            var mandatoryFilterColumns = GetMandatoryFilterColumns();

            var result = new List<ModelBase>();


            //add columns to be displayed to the user.
            foreach (var field in defaultOrSelectedColumn)
            {
                var column = allColumns.FirstOrDefault(col => ((GridField)col).field == field) as GridField;
                if (column != null)
                {
                    column.IsKey = keyColumns.Contains(field);
                    column = FormatGridField(column);
                    result.Add(column);
                }
            }

            //add columns
            foreach (var column in allColumns)
            {
                var gridField = column as GridField;

                if (gridField == null || result.Contains(column))
                {
                    continue;
                }

                //These will be hidden
                gridField.hidden = true;

                //add key columns. Data of these columns will also be populated.
                if (keyColumns.Contains(gridField.field))
                {
                    gridField.IsKey = true;
                    result.Add(gridField);
                    continue;
                }

                //add mandatory column as hidden if not there and mark it as mandatory.
                //Data of these columns will also be populated
                if (mandatoryColumns.Contains(gridField.field))
                {
                    result.Add(gridField);
                    continue;
                }
                //add mandatory filter column as hidden if not there.
                //These are only required for filter.
                if (mandatoryFilterColumns.Contains(gridField.field))
                {
                    gridField.FinderDisplayType = FinderDisplayType.Filter;
                    result.Add(gridField);
                }
            }
            return result;
        }

        /// <summary>
        /// All the columns of the grid should be implemented there.
        /// </summary>
        /// <returns>List of columns</returns>
        public abstract IEnumerable<ModelBase> GetAllColumns();

        /// <summary>
        /// Gets SchemaModel Fields
        /// </summary>
        /// <returns>List of Schedule Fields</returns>
        public virtual IEnumerable<ModelBase> GetSchemaModelFields()
        {
            //TODO: This comment has to be removed. The finders don't need schema. This caused 'ILLEGAL TOKEN' issue, because schema's field cannot start with number.
            //var allColumns = GetAllColumns().ToList();
            //if (!_hasAccessToAllFields)
            //{
            //    var accessibleColumns = allColumns.Where(col => GetDefaultColumns().Contains(((GridField)col).field));
            //    allColumns = accessibleColumns.ToList();
            //}
            ////By setting dataType as Date, the filter date will have the offset component (added by Kendo). By setting it as string, no offset will be added. This is the reason for the terinary operator.   
            //var schemaField = allColumns.Select(allColumn => new GridSchemaModelField { field = ((GridField)allColumn).field, type = (((GridField)allColumn).dataType == FinderConstant.DataTypeDate ? FinderConstant.DataTypeString : ((GridField)allColumn).dataType) }).Cast<ModelBase>().ToList();
            //return schemaField.AsEnumerable();

            return new List<ModelBase>();
        }

        /// <summary>
        /// User Preferences Key.
        /// </summary>
        public string UserPreferencesKey
        {
            get { return _userPreferencesKey; }
        }

        /// <summary>
        /// Save User Preferences
        /// </summary>
        /// <param name="columnPreferences">List of columns</param>
        public void SaveUserPreferences(List<GridColumn> columnPreferences)
        {
            if (columnPreferences != null && !string.IsNullOrEmpty(_userPreferencesKey))
            {
                var commonService = Utilities.Utilities.Resolve<ICommonService>(Context);
                commonService.SaveUserPreference(_userPreferencesKey,
                    JsonSerializer.SerializeWithCompression(columnPreferences));
            }
        }

        /// <summary>
        /// Reorder grid preferences
        /// </summary>
        /// <param name="fieldFrom">field which is reordered.</param>
        /// <param name="fieldTo">field is reordered after this field.</param>
        public void ReorderUserPreferences(string fieldFrom, string fieldTo)
        {
            List<GridColumn> preferences;
            if (string.IsNullOrEmpty(_userPreferencesKey))
            {
                return;
            }

            var commonService = Utilities.Utilities.Resolve<ICommonService>(Context);
            var userPreferences = commonService.GetUserPreference(_userPreferencesKey);
            if (userPreferences != null)
            {
                preferences = JsonSerializer.DeserializeCompressed<List<GridColumn>>(userPreferences);
            }
            else
            {
                var allColumns = GetAllColumns().ToList();
                if (!_hasAccessToAllFields)
                {
                    var accessibleColumns = allColumns.Where(col => GetDefaultColumns().Contains(((GridField)col).field));
                    allColumns = accessibleColumns.ToList();
                }
                preferences =
                    allColumns
                        .Select(
                            modelBase =>
                                new GridColumn
                                {
                                    field = ((GridField)modelBase).field,
                                    isHidden = ((GridField)modelBase).hidden
                                })
                        .ToList();
            }
            var newIndex = preferences.FindIndex(gridcolumn => gridcolumn.field == fieldTo);
            var old = preferences.Find(gridcolumn => gridcolumn.field == fieldFrom);
            preferences.Remove(old);
            preferences.Insert(newIndex, old);
            SaveUserPreferences(preferences);
        }

        /// <summary>
        /// Delete User Preferences
        /// </summary>
        public void DeleteUserPreferences()
        {
            if (!string.IsNullOrEmpty(_userPreferencesKey))
            {
                var commonService = Utilities.Utilities.Resolve<ICommonService>(Context);
                commonService.DeleteUserPreference(_userPreferencesKey);
            }
        }

        /// <summary>
        /// Returns key Columns
        /// </summary>
        /// <returns>List of key columns</returns>
        public virtual List<string> GetKeyColumns()
        {
            var type = typeof(T);
            var keyProperties =
                type.GetProperties()
                    .Where(propInfo => propInfo.GetCustomAttributes(typeof(KeyAttribute), false).Any())
                    .ToList();
            return keyProperties.Select(key => key.Name).ToList();
        }

        /// <summary>
        /// Returns mandatory columns (other than keys).
        /// </summary>
        /// <returns>List of mandatory columns</returns>
        public virtual List<string> GetMandatoryColumns()
        {
            return new List<string>();
        }

        /// <summary>
        /// Returns default columns. If this method is not overloaded get all columns.
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetDefaultColumns()
        {
            return GetAllColumns().Select(col => ((GridField)col).field).ToList();
        }

        /// <summary>
        /// Returns mandatory filter columns.  If this method is not overloaded all default columns will the there to filter.
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetMandatoryFilterColumns()
        {
            return GetDefaultColumns();
        }

        /// <summary>
        /// Gets the data(list of modelbase) from service.
        /// </summary>
        /// <param name="finderOptions">Finder Options</param>
        /// <param name="totalResultsCount">out - totalResultCount</param>
        /// <returns>List of modelbase</returns>
        public virtual IEnumerable<ModelBase> Get(FinderOption finderOptions, out int totalResultsCount)
        {
            if (finderOptions == null)
            {
                finderOptions = new FinderOption();
            }

            var filterToApply = GetFilterToApply<T>(finderOptions);
            var orderBy = new OrderBy
            {
                SortDirection = finderOptions.SortAsc ? SortDirection.Descending : SortDirection.Ascending
            };
            Service.IsReadOnly = true;
            var model = Service.Get(finderOptions.PageNumber, finderOptions.PageSize, filterToApply, orderBy);
            Service.IsReadOnly = false;
            SanitizeModelData(model.Items);
            totalResultsCount = model.TotalResultsCount;
            return model.Items;
        }

        /// <summary>
        /// Sanitize data before sending back for finder
        /// </summary>
        /// <param name="enumerable"></param>
        public virtual void SanitizeModelData(IEnumerable<T> enumerable)
        {
            // Optional for extended class to implement this function
        }

        /// <summary>
        /// Gets the model from service
        /// </summary>
        /// <param name="finderOptions">Finder Options</param>
        /// <returns>ModelBase</returns>
        public virtual ModelBase Get(FinderOption finderOptions)
        {
            if (finderOptions == null)
            {
                finderOptions = new FinderOption();
            }
            var filterToApply = GetFilterToApply<T>(finderOptions);
            Service.IsReadOnly = true;
            var model = Service.FirstOrDefault(filterToApply);
            Service.IsReadOnly = false;
            return model;
        }

        /// <summary>
        /// Get all available columns of finder grid to display "Edit Columns" list
        /// </summary>
        /// <returns>Dictionary</returns>
        public virtual Dictionary<string, string> GetEditableColumns()
        {
            var allColumns = GetAllColumns().ToList();

            if (!_hasAccessToAllFields)
            {
                var accessibleColumns = allColumns.Where(col => GetDefaultColumns().Contains(((GridField)col).field));
                allColumns = accessibleColumns.ToList();
            }
            allColumns = allColumns.Where(field => !((GridField)field).IgnorePreferences).ToList();

            if (UserPreferences == null)
            {
                return allColumns.ToDictionary(field => ((GridField)field).field, field => ((GridField)field).title);
            }

            var result = new Dictionary<string, string>();

            //add columns to be displayed to the user.
            foreach (var gridColumn in UserPreferences)
            {
                var column = allColumns.FirstOrDefault(col => ((GridField)col).field == gridColumn.field) as GridField;
                if (column != null)
                {
                    result.Add(gridColumn.field, column.title);
                }
            }
            return result;
        }


        /// <summary>
        /// Reorder colums based on default columns.
        /// This method should only be used if default colums are different for different screens. 
        /// </summary>
        /// <param name="columns">List of colums</param>
        /// <returns>Ordered list of colums</returns>
        protected List<GridField> Reorder(List<GridField> columns)
        {
            var defaultColumns = GetDefaultColumns();
            for (int i = 0; i < defaultColumns.Count; i++)
            {
                var defaultColumn = columns.FirstOrDefault(col => col.field == defaultColumns[i]);
                if (defaultColumn != null)
                {
                    if (columns.Remove(defaultColumn))
                    {
                        columns.Insert(i, defaultColumn);
                    }
                }
            }
            return columns;
        }


        /// <summary>
        /// Get the filter to apply
        /// </summary>
        /// <param name="finderOptions">Finder Options</param>
        /// <returns>Expression</returns>
        protected static Expression<Func<TU, bool>> GetFilterToApply<TU>(FinderOption finderOptions)
            where TU : ModelBase
        {
            var filterToApply = ExpressionBuilder<TU>.CreateExpression(finderOptions.AdvancedFilter);
            if (finderOptions.SimpleFilter != null)
            {
                ParameterExpression parameterExpression = null;
                if (filterToApply != null)
                {
                    parameterExpression = filterToApply.Parameters[0];
                }
                var simpleFilterExpression = ExpressionBuilder<TU>.CreateExpression(finderOptions.SimpleFilter,
                    parameterExpression);
                if (simpleFilterExpression != null)
                {
                    if (filterToApply != null)
                    {
                        var body = Expression.AndAlso(filterToApply.Body, simpleFilterExpression.Body);
                        filterToApply = Expression.Lambda<Func<TU, bool>>(body, parameterExpression);
                    }
                    else
                    {
                        filterToApply = simpleFilterExpression;
                    }
                }
            }
            return filterToApply;
        }

        /// <summary>
        /// Format GridField
        /// </summary>
        /// <param name="gridField">GridField</param>
        /// <returns>Formatted GridField</returns>
        private GridField FormatGridField(GridField gridField)
        {
            if (gridField.dataType == FinderConstant.DataTypeAmount || gridField.dataType == FinderConstant.DataTypeDecimal || gridField.dataType == FinderConstant.DataTypeSmallInt || gridField.dataType == FinderConstant.DataTypeInt || gridField.dataType == FinderConstant.DataTypeNumber)
            {
                if (gridField.customAttributes == null)
                {
                    gridField.customAttributes = new Dictionary<string, string>();
                }
                if (!gridField.customAttributes.ContainsKey("class"))
                {
                    gridField.customAttributes.Add("class", "input_Number_Right_Align");
                }
            }
            return gridField;
        }

        #region GetAllColumnsFormatted

        /// <summary>
        ///     Returns the All columns from the model as string, 
        ///     which can be used to copy and paste, in controller where GetAllColumns method override 
        /// </summary>
        /// <returns>All columns as formatted string</returns>
        public string GetAllColumnsFormatted()
        {
            var columns = new List<GridField>();
            var objectType = typeof(T);
            var allcolumnString = new StringBuilder();
            var indexClass = objectType.GetNestedType("Index");

            string gridFieldTemplate = "field = '{0}', title = {1}, attributes = {2}, headerAttributes = {3} {4} ";

            // Get all columns from model
            GetAllColumnsFromModel(objectType, indexClass, columns, 1);

            allcolumnString.Append("var column = new List<GridField> {");

            foreach (var gridField in columns)
            {
                allcolumnString.Append("new GridField {");

                var dataType = "FinderConstant.{0}";

                switch (gridField.dataType)
                {
                    case "string":
                        dataType = string.Format(dataType, "DataTypeString");
                        break;
                    case "datetime":
                        dataType = string.Format(dataType, "DataTypeDate");
                        break;
                    case "bool":
                        dataType = string.Format(dataType, "DataTypeBoolean");
                        break;
                    case "timespan":
                        dataType = string.Format(dataType, "DataTypeTime");
                        break;
                    case "number":
                    case "int32":
                    case "int64":
                        dataType = string.Format(dataType, "DataTypeNumber");
                        break;
                    case "decimal":
                    case "amount":
                        dataType = string.Format(dataType, "DataTypeAmount");
                        break;
                    case "smallint":
                        dataType = string.Format(dataType, "DataTypeSmallInt");
                        break;
                    default:
                        dataType = gridField.dataType;
                        break;
                }

                if (gridField.dataType == "enum")
                {
                    allcolumnString.Append(string.Format(gridFieldTemplate, gridField.field, gridField.title,
                        "FinderConstant.CssClassGridColumn10", "FinderConstant.CssClassGridColumn10", ""));
                }
                else
                {
                    allcolumnString.Append(string.Format(gridFieldTemplate, gridField.field, gridField.title,
                        "FinderConstant.CssClassGridColumn10", "FinderConstant.CssClassGridColumn10",
                        string.Format(", dataType = {0}", dataType)));
                }

                if (gridField.dataType == "string")
                {
                    if (gridField.customAttributes != null && gridField.customAttributes.Count > 0)
                    {
                        allcolumnString.Append(
                            ", customAttributes = new Dictionary<string, string> { {FinderConstant.CustomAttributeMaximumLength,");

                        allcolumnString.Append(string.Format("'{0}'",
                            gridField.customAttributes[FinderConstant.CustomAttributeMaximumLength]));

                        allcolumnString.Append("}}");
                    }
                }
                else if (gridField.dataType == "decimal" || gridField.dataType == "amount")
                {
                    allcolumnString.Append(
                        ", customAttributes = new Dictionary<string, string> { {'class',FinderConstant.CssClassInputNumberRightAlign}} ");
                }
                else if (gridField.dataType == "enum" && gridField.customAttributes != null)
                {
                    allcolumnString.Append(string.Format(", PresentationList = EnumUtility.GetItemsList<{0}>()",
                        gridField.customAttributes["enum"]));
                }

                allcolumnString.Append("},");
            }

            allcolumnString.Append("};");

            return allcolumnString.ToString().Replace("'", "\"");
        }

        /// <summary>
        /// Get columns
        /// </summary>
        /// <param name="objectType">Object Type</param>
        /// <param name="indexClass">Index Class</param>
        /// <param name="columns">List of Columns</param>
        /// <param name="level">Level</param>
        private void GetAllColumnsFromModel(Type objectType, Type indexClass, IList<GridField> columns, int level)
        {
            var props = objectType.GetProperties();
            foreach (var prop in props)
            {
                var attributes = prop.GetCustomAttributes().ToList();

                if (IgnoreProperty(attributes))
                {
                    continue;
                }
                if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType.IsEnum ||
                    prop.PropertyType == typeof(string))
                {
                    var gridField = GetPropertyAttributes(attributes, indexClass, prop);
                    if (gridField != null)
                    {
                        columns.Add(gridField);
                    }
                }
                else if (level == 1 && prop.PropertyType.IsClass && prop.PropertyType.IsSubclassOf(typeof(ModelBase)))
                {
                    GetAllColumnsFromModel(prop.PropertyType, indexClass, columns, level + 1);
                }
            }
        }

        /// <summary>
        /// Ignore property
        /// </summary>
        /// <param name="attributes">List of attributes</param>
        /// <returns></returns>
        private static bool IgnoreProperty(List<Attribute> attributes)
        {
            if (attributes.Exists(attr => attr is IgnoreExportImportAttribute))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get property attributes
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="indexClass"></param>
        /// <param name="property"></param>
        /// <returns>BusinessEntityField</returns>
        private static GridField GetPropertyAttributes(List<Attribute> attributes, Type indexClass,
            PropertyInfo property)
        {
            var index = indexClass.GetField(property.Name);
            if (index == null)
            {
                return null;
            }

            var gridField = new GridField
            {
                field = property.Name,
                attributes = FinderConstant.CssClassGridColumn10,
                headerAttributes = FinderConstant.CssClassGridColumn10,
            };

            string titleResource = "{0}.{1}";

            var displayAttribute = attributes.Find(attr => attr is DisplayAttribute);

            if (displayAttribute == null)
            {
                return null;
            }

            titleResource = string.Format(titleResource, (((DisplayAttribute)displayAttribute)).ResourceType.Name,
                (((DisplayAttribute)displayAttribute)).Name);

            gridField.title = titleResource;

            gridField.dataType = ((property.PropertyType)).Name.ToLower();

            if (gridField.dataType == "string")
            {
                var attribute = attributes.Find(attr => attr is StringLengthAttribute);
                if (attribute != null)
                {
                    var maxLength = ((StringLengthAttribute)(attribute)).MaximumLength;
                    gridField.customAttributes = new Dictionary<string, string>
                    {
                        {"maxLength", maxLength.ToString(CultureInfo.InvariantCulture)}
                    };
                }
            }
            else if (property.PropertyType.IsEnum)
            {
                gridField.dataType = "enum";
                gridField.customAttributes = new Dictionary<string, string> { { "enum", ((property.PropertyType)).Name } };
            }

            return gridField;
        }

        /// <summary>
        /// Get matched Filter for the input propertyName. Note that this will match the first criteria and return
        /// </summary>
        /// <param name="finderOptions">finderOptions</param>
        /// <param name="propertyName">propertyName to be matched</param>
        /// <returns>matched Filter object</returns>
        protected Filter GetMatchingFilter(FinderOption finderOptions, string propertyName)
        {
            if (finderOptions == null)
            {
                return null;
            }

            if (finderOptions.SimpleFilter != null && finderOptions.SimpleFilter.Field != null &&
                finderOptions.SimpleFilter.Field.field == propertyName)
            {
                return finderOptions.SimpleFilter;
            }

            if (finderOptions.AdvancedFilter != null && finderOptions.AdvancedFilter.Count > 0)
            {
                foreach (var filters in finderOptions.AdvancedFilter)
                {
                    var matchedFilter =
                        (from filter in filters
                         where filter.Field != null && filter.Field.field == propertyName
                         select filter).FirstOrDefault();
                    if (matchedFilter != null)
                        return matchedFilter;
                }
            }

            return null;
        }

        #endregion

        /// <summary>
        /// Check for user access, throws exception if user do not have the access
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        private bool HasAccess(string resourceId)
        {
            var commonService = Context.Container.Resolve<ICommonService>(new ParameterOverride("context", Context));
            return commonService.HasAccess(resourceId);
        }

    }
}
