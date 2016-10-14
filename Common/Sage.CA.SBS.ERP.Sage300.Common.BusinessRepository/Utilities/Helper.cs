/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Class Helper.
    /// </summary>
    public static class Helper
    {
        #region Session Constants

        /// <summary>
        /// Application Identifer
        /// </summary>
        public const string ApplicationIdentifier = "WX";

        /// <summary>
        /// Program Name
        /// </summary>
        public const string ProgramName = "WX1000";

        /// <summary>
        /// Application Version
        /// </summary>
        public const string ApplicationVersion = "64A";

        #endregion

        /// <summary>
        /// Get Exceptions
        /// </summary>
        /// <param name="session">Business Entity Session</param>
        /// <returns>List of error</returns>
        public static List<EntityError> GetExceptions(IBusinessEntitySession session)
        {
            var distinctErrors = session.Errors.GroupBy(error => error.Message).Select(group => group.First()).ToList();
            session.ClearErrors();
            return distinctErrors;
        }

        /// <summary>
        /// Get system type by string
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Type.</returns>
        public static Type GetSystemType(string type)
        {
            switch (type)
            {
                case "Byte":
                case "byte":
                case "System.Byte":
                    return typeof(byte);
                case "Time":
                case "time":
                case "Date":
                case "date":
                case "System.DateTime":
                case "System.Nullable<System.DateTime>":
                    return typeof(DateTime);
                case "Int":
                case "int":
                case "System.Int32":
                    return typeof(int);
                case "Bool":
                case "bool":
                case "System.Boolean":
                    return typeof(bool);
                case "Long":
                case "long":
                case "System.Int64":
                    return typeof(float);
                case "Decimal":
                case "decimal":
                case "System.Decimal":
                    return typeof(decimal);
                default:
                    return typeof(string);
            }
        }

        /// <summary>
        /// Returns table name for the view
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <returns>System.String.</returns>
        public static string GetTableName(IBusinessEntity businessEntity)
        {
            if (businessEntity == null || string.IsNullOrEmpty(businessEntity.Description))
                return string.Empty;

            return businessEntity.Description.Replace(" ", "_");
        }

        /// <summary>
        /// Check if the object is null or empty
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns><c>true</c> if the specified object is null; otherwise, <c>false</c>.</returns>
        public static bool IsNull(object obj)
        {
            if (obj == null || string.IsNullOrEmpty(Convert.ToString(obj, CultureInfo.InvariantCulture)))
                return true;

            return false;
        }

        /// <summary>
        /// Is the business entity item editable?
        /// </summary>
        /// <param name="field">Field Item</param>
        /// <returns>true/false</returns>
        public static bool IsEditable(ViewField field)
        {
            return field.Attributes.HasFlag(ViewFieldAttributes.Editable) &&
                   !field.Attributes.HasFlag(ViewFieldAttributes.Calculated);
        }

        /// <summary>
        /// Is the business entity item enabled?
        /// </summary>
        /// <param name="field">Field Item</param>
        /// <returns>true/false</returns>
        public static bool IsEnabled(ViewField field)
        {
            return field.Attributes.HasFlag(ViewFieldAttributes.Enabled);
        }

        /// <summary>
        /// Is the business entity item required?
        /// </summary>
        /// <param name="field">Field Item</param>
        /// <returns>true/false</returns>
        public static bool IsRequired(ViewField field)
        {
            return field.Attributes.HasFlag(ViewFieldAttributes.Required);
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Generic Type T</typeparam>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        /// <returns>T</returns>
        public static T Resolve<T>(Context context, IBusinessEntitySession session)
        {
            return context.Container.Resolve<T>(UnityInjectionType.Session, new ParameterOverride("context", context),
                new ParameterOverride("session", session));
        }

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">Generic Type T</typeparam>
        /// <param name="context">Context</param>
        /// <returns>T</returns>
        public static T Resolve<T>(Context context)
        {
            return context.Container.Resolve<T>(UnityInjectionType.Default, new ParameterOverride("context", context));
        }

        /// <summary>
        /// Get Count
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int GetRecordCount(IBusinessEntity entity)
        {
            entity.Top();
            int total = 0;
            do
            {
                total++;
            } while (entity.Next());

            if (!entity.Exists && total == 1)
            {
                return 0;
            }
            return total;
        }

        /// <summary>
        /// Retrieves the status of the Entity Return Code
        /// </summary>
        /// <param name="returnCode">View return code</param>
        /// <returns>True if Error</returns>
        public static bool IsViewError(int returnCode)
        {
            return returnCode > (int)EntityReturnCode.Success
                 && returnCode != (int)EntityReturnCode.Warning;

        }

        /// <summary>
        /// Retrieves the status of the Entity Return Code
        /// </summary>
        /// <param name="returnCode">returnCode</param>
        /// <returns>Boolean</returns>
        public static bool IsViewSuccess(int returnCode)
        {
            return returnCode <= (int)EntityReturnCode.Success || returnCode == (int)EntityReturnCode.Warning;
        }

        #region User Preferences related methods

        /// <summary>
        /// Compares two objects and returns the differences 
        /// </summary>
        /// <param name="T">Model</param>
        /// <param name="oldModel">model with default values</param>
        /// <param name="newModel">model with changed values</param>
        /// <param name="propertyList">dictionary filled with properties and new values</param>
        /// <param name="appendToPropertyName">used in case of subclasses</param>
        /// <returns>dictionary of all propertyname and changes value</returns>
        public static Dictionary<string, object> Compare(Type T, object oldModel, object newModel,
            Dictionary<string, object> propertyList = null, string appendToPropertyName = "")
        {
            if (propertyList == null)
            {
                propertyList = new Dictionary<string, object>();
            }
            var properties = T.GetProperties();

            foreach (var property in properties)
            {
                if (property.GetSetMethod(true) == null)
                {
                    continue;
                }

                if (property.GetCustomAttributes().FirstOrDefault(attr => attr is IgnorePreferencesAttribute) != null)
                {
                    continue;
                }

                var propertyName = property.Name;
                object oldValue = null;
                object newValue = null;
                if (oldModel != null)
                {
                    oldValue = property.GetValue(oldModel, null);
                }
                if (newModel != null)
                {
                    newValue = property.GetValue(newModel, null);
                }
                if (((oldValue == null || string.IsNullOrEmpty(oldValue.ToString())))
                    && (newValue == null || string.IsNullOrEmpty(newValue.ToString())) ||
                    (oldValue != null && oldValue.Equals(newValue)) ||
                    (newValue != null && newValue.Equals(oldValue)))
                {
                    continue;
                }
                propertyName = appendToPropertyName + propertyName;
                if (property.PropertyType.IsPrimitive || property.PropertyType.IsValueType ||
                    property.PropertyType.IsEnum || property.PropertyType == typeof(string))
                {
                    if (oldValue == null || newValue == null || !oldValue.Equals(newValue))
                    {
                        propertyList.Add(propertyName, newValue);
                    }
                }
                else if (property.PropertyType.Name == (typeof(IEnumerable<ModelBase>)).Name ||
                    property.PropertyType.Name == (typeof(IList<ModelBase>)).Name ||
                     property.PropertyType.Name == (typeof(List<ModelBase>)).Name)
                {
                    GetValueFromIEnumerableObject(propertyList, oldValue, newValue, propertyName);
                }
                else if (property.PropertyType.Name == (typeof(EnumerableResponse<ModelBase>)).Name)
                {
                    GetValueFromEnumerableResponseObject(propertyList, oldValue, newValue, propertyName);
                }
                else if (property.PropertyType.IsClass)
                {
                    Compare(property.PropertyType, oldValue, newValue, propertyList, (propertyName + "."));
                }
            }
            return propertyList;
        }

        /// <summary>
        /// Iterate each item in the enumeration (all the items) list and checks for changed value
        /// </summary>
        /// <param name="propertyList">the current list of dicstionary being build</param>
        /// <param name="oldValue">base model values</param>
        /// <param name="newValue">new model, with changed values</param>
        /// <param name="propertyName">property name</param>
        private static void GetValueFromEnumerableResponseObject(Dictionary<string, object> propertyList, object oldValue, object newValue, string propertyName)
        {
            var oldValueItem = oldValue.GetType().GetProperty("Items").GetValue(oldValue, null);
            var newValueItem = newValue.GetType().GetProperty("Items").GetValue(newValue, null);
            GetValueFromIEnumerableObject(propertyList, oldValueItem, newValueItem, propertyName);
        }

        /// <summary>
        /// Iterate each item in the enumeration list and checks for changed value
        /// </summary>
        /// <param name="propertyList">the current list of dicstionary being build</param>
        /// <param name="oldValue">base model values</param>
        /// <param name="newValue">new model, with changed values</param>
        /// <param name="propertyName">property name</param>
        private static void GetValueFromIEnumerableObject(Dictionary<string, object> propertyList, object oldValue, object newValue, string propertyName)
        {
            var collectionItems1 = new List<object>();
            List<object> collectionItems2 = new List<object>();
            var collectionItemsCount1 = 0;
            var collectionItemsCount2 = 0;

            if (oldValue != null)
            {
                collectionItems1 = ((IEnumerable<object>)oldValue).ToList();
                collectionItemsCount1 = collectionItems1.Count();
            }
            if (newValue != null)
            {
                collectionItems2 = ((IEnumerable<object>)newValue).ToList();
                collectionItemsCount2 = collectionItems2.Count();
            }
            if ((oldValue == null && newValue == null) || (oldValue != null && oldValue.Equals(newValue)) ||
                (newValue != null && newValue.Equals(oldValue)))
            {
                return;
            }
            if (collectionItemsCount1 == 0 && collectionItemsCount2 == 0)
            {
                return;
            }
            //TODO: If collectionItemsCount1 > collectionItemsCount2, we would skip the rest of collectionItems1. Was this intentional????
            for (var i = 0; i < collectionItemsCount2; i++)
            {
                var collectionItem2 = collectionItems2.ElementAt(i);
                if (i > collectionItemsCount1 - 1)
                {
                    propertyList.Add(propertyName + "[" + i + "]", collectionItem2);
                    continue;
                }
                var collectionItem1 = collectionItems1.ElementAt(i);
                Type collectionItemType = collectionItem1.GetType();
                if (collectionItem1.Equals(collectionItem2))
                {
                    continue;
                }
                Compare(collectionItemType, collectionItem1, collectionItem2, propertyList,
                    (propertyName + "[" + i + "]" + "."));
            }
        }

        /// <summary>
        /// Merge the actual model with user preferences value
        /// </summary>
        /// <typeparam name="TU">Model to return</typeparam>
        /// <param name="dictionary">user preferences dictionary items</param>
        /// <param name="model">model with default calues</param>
        /// <returns>model with updated values</returns>
        public static TU Merge<TU>(Dictionary<string, object> dictionary, TU model)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return model;
            }
            foreach (var item in dictionary)
            {
                dynamic modelProperty = model;
                PropertyInfo propertyInfo;
                var propertyName = item.Key;
                var isEnumeration = false;
                var enumerationIndex = 0;
                var enumerationProperty = "";

                //Extract PropertyName, Index and Sub Propery from the dictionary key
                //example: OptionalField[2].Value
                if (propertyName.Contains('['))
                {
                    var startIndex = propertyName.IndexOf('[');
                    var endIndex = propertyName.IndexOf(']');
                    var index = endIndex - startIndex;
                    if (propertyName.Substring(startIndex + index, 1) == "]")
                    {
                        isEnumeration = true;
                        enumerationIndex = Convert.ToInt16(propertyName.Substring(startIndex + 1, index - 1));
                        if (propertyName.Length > startIndex + index + 1)
                        {
                            enumerationProperty = propertyName.Substring(startIndex + index + 2);
                        }
                        propertyName = propertyName.Substring(0, startIndex);
                    }
                }

                if (propertyName.Contains("."))
                {
                    var parts = propertyName.Split('.');
                    propertyInfo = model.GetType().GetProperty(parts[0]);
                    for (var i = 1; i < parts.Length; i++)
                    {
                        var baseModelValue = propertyInfo.GetValue(modelProperty);
                        if (baseModelValue == null)
                        {
                            propertyInfo.SetValue(modelProperty, Activator.CreateInstance(propertyInfo.PropertyType));
                            modelProperty = propertyInfo.GetValue(modelProperty);
                        }
                        else
                        {
                            modelProperty = baseModelValue;
                        }
                        propertyInfo = propertyInfo.PropertyType.GetProperty(parts[i]);
                    }
                }
                else
                {
                    propertyInfo = model.GetType().GetProperty(propertyName);
                }
                if (isEnumeration)
                {
                    if (enumerationProperty == "")
                    {
                        if (propertyInfo.PropertyType.Name == (typeof(EnumerableResponse<ModelBase>)).Name)
                        {
                            modelProperty = propertyInfo.GetValue(modelProperty);
                            propertyInfo = modelProperty.GetType().GetProperty("Items");
                        }
                        var listOfItem = propertyInfo.GetValue(modelProperty);
                        listOfItem.GetType().GetMethod("Add").Invoke(listOfItem, new[] { item.Value });
                        propertyInfo.SetValue(modelProperty, listOfItem);
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.Name == (typeof(EnumerableResponse<ModelBase>)).Name)
                        {
                            modelProperty = propertyInfo.GetValue(modelProperty);
                            propertyInfo = propertyInfo.PropertyType.GetProperty("Items");
                        }
                        var enumerationValue = propertyInfo.GetValue(modelProperty);
                        var currentItem = enumerationValue[enumerationIndex];
                        var newPropertyInfo = currentItem.GetType().GetProperty(enumerationProperty);
                        SetValue(newPropertyInfo, item.Value, currentItem);
                        enumerationValue[enumerationIndex] = currentItem;
                        propertyInfo.SetValue(modelProperty, enumerationValue);
                    }
                }
                else
                {
                    SetValue(propertyInfo, item.Value, modelProperty);
                }
            }
            return model;
        }

        /// <summary>
        /// Set property value by casting the object to proper type
        /// </summary>
        /// <param name="propertyInfo">PropertyInfo</param>
        /// <param name="value">value as object</param>
        /// <param name="modelProperty">model object as dynamic</param>
        private static void SetValue(PropertyInfo propertyInfo, object value, dynamic modelProperty)
        {
            if (propertyInfo.PropertyType.IsEnum)
            {
                var enumValue = Enum.Parse(propertyInfo.PropertyType, value.ToString());
                propertyInfo.SetValue(modelProperty, enumValue, null);
            }
            else
            {
                var typeValue = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                var typedValue = (value == null) ? null : Convert.ChangeType(value, typeValue);
                propertyInfo.SetValue(modelProperty, typedValue, null);
            }
        }

        #endregion
    }
}