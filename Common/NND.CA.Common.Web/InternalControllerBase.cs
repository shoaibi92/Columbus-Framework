/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Dynamic;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Class for Controller InternalBase
    /// </summary>
    /// <typeparam name="T">Base type</typeparam>
    public class InternalControllerBase<T> where T : ISecurityService
    {
        /// <summary>
        /// Context
        /// </summary>
        protected readonly Context Context;

        /// <summary>
        /// Service Reference
        /// </summary>
        protected T Service;

        /// <summary>
        /// Provides access to Session Cache
        /// </summary>
        protected ISessionCacheProvider SessionHelper
        {
            get { return SessionUtility.Provider; }
        }

        /// <summary>
        /// Parameter
        /// </summary>
        protected const string Parameter = "context";

        /// <summary>
        /// TO initialize Context and UnityContainer
        /// </summary>
        /// <param name="context">Context</param>
        protected InternalControllerBase(Context context)
        {
            Context = context;
            Service = context.Container.Resolve<T>(new ParameterOverride(Parameter, Context));
        }

        #region MergeChangeItemToCache Old

        /// <summary>
        /// MergeChangeItemToCache
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TKeyType">The type of the key type.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <param name="keyProperty">The key property.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getPagedData">The get paged data.</param>
        /// <param name="keyFilter">The key filter.</param>
        /// <param name="newLineModel">The new line model.</param>
        /// <returns></returns>
        //[Obsolete("Please use MergeChangeItem method.")]
        protected EnumerableResponse<TModel> MergeChangeItemToCache<TModel, TKeyType>(EnumerableResponse<TModel> model,
               int pageNumber, int pageSize, int insertIndex, string keyProperty, string cacheKey,
               Func<int, int, EnumerableResponse<TModel>> getPagedData, Func<TModel, TKeyType> keyFilter, TModel newLineModel)
            where TModel : ModelBase
            where TKeyType : struct
        {
            var cachedList = SessionHelper.Get<List<TModel>>(cacheKey);
            bool hasDataChanged = false;

            if (model != null && model.Items != null)
            {
                hasDataChanged = model.Items.Any(c => c.HasChanged) || model.Items.Any(c => c.IsNewLine) ||
                                 model.Items.Any(c => c.IsDeleted) || insertIndex > 0;
            }

            if (cachedList == null)
            {
                //Commenting this for now. Once all the screens are fixed, this needs to be added.
                if (!hasDataChanged)
                {
                    return getPagedData(pageNumber, pageSize);
                }

                //once the data is modified load all the data in cache
                var data = getPagedData(-1, -1);
                cachedList = data.Items.ToList();
                SessionHelper.Set(cacheKey, cachedList);
            }

            if (model != null && model.Items != null)
            {
                if (hasDataChanged)
                {
                    //Remove item from the Cache for the current page and update with the new changed items
                    if (cachedList.Any())
                    {
                        foreach (var item in model.Items)
                        {
                            var removeFilter = new Filter
                            {
                                Field = new GridField { field = keyProperty },
                                Operator = Operator.Equal,
                                Value = keyFilter(item)
                            };

                            var removeExpression = ExpressionBuilder<TModel>.CreateExpression(removeFilter);
                            var record = cachedList.AsQueryable().FirstOrDefault(removeExpression);

                            if (record != null)
                            {
                                cachedList.Remove(record);
                            }
                        }
                    }

                    cachedList.AddRange(model.Items);
                    //Set updated item to cache
                    SessionHelper.Set(cacheKey, cachedList);
                }

                cachedList = cachedList.ToList();
            }

            //If insert index is passed add new lin
            if (insertIndex > 0)
            {
                var deletedList = cachedList.Where(d => d.IsDeleted);

                cachedList = AddNewLine(cachedList.Where(d => d.IsDeleted != true), newLineModel, insertIndex);

                //Set updated item to cache
                cachedList.AddRange(deletedList);

                //Set updated item to cache
                SessionHelper.Set(cacheKey, cachedList);
            }

            var cachedListCount = cachedList.Count;

            cachedList = cachedList.Where(c => c.IsDeleted != true).OrderBy(c => c.DisplayIndex).ToList();

            return new EnumerableResponse<TModel>
            {
                Items = cachedList.Skip(pageNumber * pageSize).Take(pageSize),
                TotalResultsCount = cachedList.Count(),
                CachedListCount = cachedListCount
            };
        }

        #endregion

        /// <summary>
        /// AddNewLine
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="newData">The new data.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <returns></returns>
        protected List<TModel> AddNewLine<TModel>(IEnumerable<TModel> model, TModel newData, int insertIndex)
            where TModel : ModelBase
        {
            var list = model.OrderBy(i => i.DisplayIndex).ToList();

            //If list is empty add item to index 0 position
            if (list.Count == 0)
            {
                insertIndex = 0;
            }

            list.Insert(insertIndex, newData);

            int displayNumber = 1;

            foreach (var item in list)
            {
                item.DisplayIndex = displayNumber++;
            }

            return list;
        }

        /// <summary>
        /// Get Data For Save From Cache
        /// </summary>
        /// <returns></returns>
        protected EnumerableResponse<TModel> GetDataForSave<TModel, TKeyType>(EnumerableResponse<TModel> model,
            string cacheKey, string keyProperty, Func<TModel, TKeyType> keyFilter)
            where TModel : ModelBase
            where TKeyType : struct
        {
            var items = SessionHelper.Get<List<TModel>>(cacheKey);

            if (items != null)
            {
                MergeChangeItemToCache(model, 0, 0, 0, keyProperty, cacheKey, null, keyFilter, null);
                items = SessionHelper.Get<List<TModel>>(cacheKey);
            }
            else
            {
                if (model.Items != null)
                {
                    items = model.Items.ToList();
                }

            }

            if (items != null && items.Any())
            {
                items.RemoveAll(c => (c.IsDeleted && c.IsNewLine));
                items = items.Where(c => c.HasChanged || c.IsNewLine || c.IsDeleted).ToList();
            }

            return new EnumerableResponse<TModel> { Items = items };

        }

        /// <summary>
        /// Get user access, throws exception if user can not view the page
        /// </summary>
        /// <returns>User Access</returns>
        public UserAccess GetAccessRights()
        {
            var userAccess = Service.GetAccessRights();
            if (userAccess.SecurityType == SecurityType.None)
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError {Message = CommonResx.NotAuthorizedMesage, Priority = Priority.Error}
                };
                throw ExceptionHelper.SecurityException(entityErrors);
            }
            return userAccess;
        }

        /// <summary>
        /// Construct Error Message
        /// </summary>
        /// <param name="errorText">Text to show to user</param>
        /// <returns></returns>
        protected UserMessage ConstructErrorMessage(string errorText)
        {
            var errorList = new List<EntityError>();
            var entityError = new EntityError { Message = errorText, Priority = Priority.Error };
            errorList.Add(entityError);

            return new UserMessage { IsSuccess = false, Errors = errorList, };
        }

        /// <summary>
        /// Creates the session key.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        protected string CreateSessionKey<TModel>(string keyName)
        {
            return string.Format(@"{0}_{1}_{2}", Context.ContextToken, typeof(TModel), keyName);
        }

        /// <summary>
        /// Generate Key
        /// </summary>
        /// <returns></returns>
        protected long GenerateKey()
        {
            return DateUtil.GetTicks() / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// Create Dynamic Property
        /// </summary>
        /// <param name="newTypeName">Type Name</param>
        /// <param name="columnList">Dynamic Properties List</param>
        /// <param name="baseClassType">Base Class Type</param>
        /// <returns>Type</returns>
        protected Type CreateDynamicProperty(string newTypeName, List<DynamicProperty> columnList, Type baseClassType)
        {
            bool noNewProperties = true;

            AssemblyBuilder assemblyBldr = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName("tmpAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBldr = assemblyBldr.DefineDynamicModule("tmpModule");

            // create a new type builder
            TypeBuilder typeBldr = moduleBldr.DefineType(newTypeName, TypeAttributes.Public | TypeAttributes.Class, baseClassType);

            // Loop over the attributes that will be used as the 
            Activator.CreateInstance(baseClassType);

            //Assign Nullable Property Type
            foreach (var property in columnList)
            {
                string propertyName = property.PropertyName;

                Type propertyType = property.PropertyDataType;

                if (propertyType == typeof(DateTime))
                {
                    propertyType = typeof(DateTime?);
                }

                if (propertyType == typeof(TimeSpan))
                {
                    propertyType = typeof(TimeSpan?);
                }

                if (propertyType == typeof(bool))
                {
                    propertyType = typeof(bool?);
                }

                if (propertyType == typeof(decimal))
                {
                    propertyType = typeof(decimal?);
                }

                if (propertyType == typeof(int))
                {
                    propertyType = typeof(int?);
                }

                // Generate a private field for the property
                FieldBuilder fldBldr = typeBldr.DefineField(propertyName, propertyType, FieldAttributes.Private);

                // Generate a public property
                PropertyBuilder prptyBldr = typeBldr.DefineProperty(propertyName, PropertyAttributes.None, propertyType, new[] { propertyType });
                // The property set and property get methods need the 
                // following attributes:
                const MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
                // Define the "get" accessor method for newly created private field.
                MethodBuilder currGetPropMthdBldr = typeBldr.DefineMethod("get_value", getSetAttr, propertyType, null);

                // Intermediate Language stuff... as per Microsoft
                ILGenerator currGetIl = currGetPropMthdBldr.GetILGenerator();
                currGetIl.Emit(OpCodes.Ldarg_0);
                currGetIl.Emit(OpCodes.Ldfld, fldBldr);
                currGetIl.Emit(OpCodes.Ret);

                // Define the "set" accessor method for the newly created private field.
                MethodBuilder currSetPropMthdBldr = typeBldr.DefineMethod("set_value", getSetAttr, null, new[] { propertyType });

                //Intermediate Language
                ILGenerator currSetIl = currSetPropMthdBldr.GetILGenerator();
                currSetIl.Emit(OpCodes.Ldarg_0);
                currSetIl.Emit(OpCodes.Ldarg_1);
                currSetIl.Emit(OpCodes.Stfld, fldBldr);
                currSetIl.Emit(OpCodes.Ret);

                // Assign the two methods created above to the 
                // PropertyBuilder's Set and Get
                prptyBldr.SetGetMethod(currGetPropMthdBldr);
                prptyBldr.SetSetMethod(currSetPropMthdBldr);
                noNewProperties = false;
            }

            //return the base class
            if (noNewProperties)
            {
                return baseClassType;
            }

            // Generate (and deliver) my type
            return typeBldr.CreateType();
        }

        /// <summary>
        /// IsPropertyExist
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected static bool IsPropertyExist(Type obj, string propertyName)
        {
            PropertyInfo myPropInfo = obj.GetProperty(propertyName);
            return (myPropInfo != null);
        }

        /// <summary>
        /// Construct Dynamic Column Filter
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldType">Type of the field.</param>
        /// <param name="value">The value.</param>
        /// <param name="filterOperator">The Filter Operator.</param>
        /// <returns></returns>
        protected string ConstructDynamicColumnFilter(string fieldName, object fieldType, object value, Operator filterOperator = Operator.Equal)
        {
            var operatorValue = Convert.ToInt16(EnumUtility.GetValue(filterOperator));
            string[] operators = { ">", ">=", "<", "<=", "<>", "=", "LIKE" };

            //Construct filter for DateTime
            if ((Type)fieldType == typeof(DateTime))
            {
                return string.Format("{0} {1} {2}", fieldName, operators[operatorValue], DateUtil.GetYearMonthDayDate(value, string.Empty));
            }

            //Construct filter for TimeSpan
            if ((Type)fieldType == typeof(TimeSpan))
            {
                TimeSpan timeValue;
                TimeSpan.TryParse(Convert.ToString(value), out timeValue);
                return string.Format("{0} {1} {2}", fieldName, operators[operatorValue], timeValue.ToString("hhmmss"));
            }

            //Construct filter for bool
            if ((Type)fieldType == typeof(bool))
            {
                //return 1 or 0 for boolean
                return string.Format("{0} {1} {2}", fieldName, operators[operatorValue], Convert.ToInt16(value).ToString(CultureInfo.InvariantCulture));
            }

            //Construct filter for string
            if ((Type)fieldType == typeof(string))
            {
                // Fix for D-23279 but this is temporary fix.
               if (value != null && fieldName.Equals("UPSZONE"))
                {
                    value = value.ToString().ToUpper();
                }

                if (filterOperator == Operator.StartsWith)
                {
                    return string.Format("{0} LIKE \"{1}%\"", fieldName, value);
                }
                if (filterOperator == Operator.Contains)
                {
                    return string.Format("{0} LIKE \"%{1}%\"", fieldName, value);
                }
                if (filterOperator == Operator.Like)
                {
                    return string.Format("{0} LIKE \"{1}\"", fieldName, value);
                }
            }

            //Construct filter for others
            return string.Format("{0} {1} {2}", fieldName, operators[operatorValue], Convert.ToString(value));
        }

        /// <summary>
        /// Creates a JSON friendly object
        /// </summary>
        /// <param name="attributes">Attributes</param>
        /// <returns></returns>
        protected IDictionary<string, object> ConvertToDynamic(IEnumerable<EnablementAttribute> attributes)
        {
            IDictionary<string, object> jsonFriendly = new ExpandoObject();
            foreach (var enablementAttribute in attributes)
            {
                jsonFriendly.Add(enablementAttribute.PropertyName, enablementAttribute.Disabled);
            }
            return jsonFriendly;
        }

        #region Grid Pagination - New implementation

        /// <summary>
        /// Merges Expression1 and Expression2 with And clause
        /// </summary>
        /// <typeparam name="TModel">ModelBase</typeparam>
        /// <param name="expression1">Expression</param>
        /// <param name="expression2">Expression</param>
        /// <returns>Merged Expression</returns>
        protected Expression<Func<TModel, bool>> MergeExpression<TModel>(Expression<Func<TModel, bool>> expression1,
            Expression<Func<TModel, bool>> expression2) where TModel : ModelBase
        {
            var binaryExpression = Expression.AndAlso(expression1.Body, expression2.Body);
            return Expression.Lambda<Func<TModel, bool>>(binaryExpression, expression1.Parameters[0]);
        }

        /// <summary>
        /// MergeChangeItem
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getPagedRecords">The get paged data.</param>
        /// <param name="getKey">The key filter.</param>
        /// <param name="getPreviousRecord"></param>
        /// <param name="newLineModel">The new line model.</param>
        /// <param name="resourceName">Resource Name</param>
        /// <returns></returns>
        protected EnumerableResponse<TModel> MergeChangeItem<TModel>(EnumerableResponse<TModel> model, int pageNumber,
            int pageSize, int insertIndex, string cacheKey,
            Func<PageOptions<TModel>, EnumerableResponse<TModel>> getPagedRecords, Func<TModel, string> getKey,
            Func<TModel, List<TModel>, TModel> getPreviousRecord, TModel newLineModel, string resourceName) where TModel : ModelBase
        {
            var cachedList = SessionHelper.Get<List<TModel>>(cacheKey);
            var hasDataChanged = false;
            var pageOptions = new PageOptions<TModel> { PageNumber = pageNumber, PageSize = pageSize, LatestCachingNotUsed = true };
            var clientList = (model == null || model.Items == null) ? null : model.Items.ToList();

            if (cachedList == null)
            {
                if (clientList != null)
                {
                    hasDataChanged = clientList.Any(c => c.HasChanged) || clientList.Any(c => c.IsNewLine) ||
                                     clientList.Any(c => c.IsDeleted) || insertIndex > 0;
                }

                if (!hasDataChanged)
                {
                    //Data is not modified by the user.
                    if (getPagedRecords != null)
                    {
                        return getPagedRecords(pageOptions);
                    }
                }
            }

            if (clientList != null && clientList.Count > 0)
            {
                ValidateDuplicateRecord(clientList, cachedList, getKey, resourceName);

                var modifiedData = new List<TModel>();

                #region Update Previous Key

                //Set the valid previous key based on the first record.
                string previousKey = !clientList[0].IsDeleted ? getKey(clientList[0]) : GetPreviousKey(cachedList, getKey, getPreviousRecord, clientList[0]);

                //Update PreviousKey (key of the previous record) for all inserted and deleted items.
                for (var i = 0; i < clientList.Count(); i++)
                {
                    if (clientList[i].HasChanged || clientList[i].IsDeleted || clientList[i].IsNewLine)
                    {
                        var modifiedItem = clientList[i];
                        if (string.IsNullOrEmpty(getKey(modifiedItem)))
                        {
                            continue;
                        }
                        modifiedData.Add(modifiedItem);
                    }
                    if (clientList[i].IsDeleted)
                    {
                        continue;
                    }
                    if (i > 0)
                    {
                        clientList[i].PreviousKey = previousKey;
                        previousKey = getKey(clientList[i]);
                    }
                }

                //If last record is modified, update the previous key of the next record from cache
                if (cachedList != null && clientList.Any())
                {
                    var lastRecord = clientList[clientList.Count() - 1];
                    if (lastRecord.IsDeleted)
                    {
                        //Get next record and update the key
                        var record = cachedList.FirstOrDefault(item => item.PreviousKey == getKey(lastRecord) && !item.IsDeleted);
                        if (record != null)
                        {
                            record.PreviousKey = previousKey;
                        }
                    }
                }

                #endregion

                #region Update Cache

                // Update cache.
                cachedList = UpdateCachedData(modifiedData, cachedList);

                // update cache with updated and deleted items.
                SessionHelper.Set(cacheKey, cachedList);

                #endregion
            }

            if (getPagedRecords != null)
            {
                pageOptions.ModifiedData = cachedList;
                pageOptions.GetKey = getKey;

                var result = getPagedRecords(pageOptions);
                var serverList = result.Items.ToList();

                var totalCount = result.TotalResultsCount;

                if (insertIndex > 0)
                {
                    int remainder;
                    Math.DivRem(insertIndex, pageSize, out remainder);
                    var previousRowIndex = remainder == 0 ? pageSize - 1 : remainder - 1;
                    if (clientList != null && clientList.Count >= previousRowIndex)
                    {
                        newLineModel.PreviousKey = getKey(clientList[previousRowIndex]);
                    }
                    serverList.Insert(remainder, newLineModel);
                    totalCount++;
                }

                var modelsToReturn = serverList.Take(pageSize).ToList();

                if (cachedList != null && cachedList.Any())
                {
                    var shouldUpdateCache = false;
                    foreach (var item in modelsToReturn)
                    {
                        //Remove all the cached item which are being displayed on UI
                        if (cachedList.Contains(item))
                        {
                            cachedList.Remove(item);
                            shouldUpdateCache = true;
                        }
                    }
                    if (shouldUpdateCache)
                    {
                        SessionHelper.Set(cacheKey, cachedList);
                    }
                }

                return new EnumerableResponse<TModel>
                {
                    Items = modelsToReturn,
                    TotalResultsCount = totalCount
                };
            }
            return new EnumerableResponse<TModel>
            {
                Items = cachedList
            };
        }

        /// <summary>
        /// Get Previous Key
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="cachedData">The cached data.</param>
        /// <param name="getKey">The get key.</param>
        /// <param name="getPreviousRecord">The get previous record.</param>
        /// <param name="firstRecord">The first record.</param>
        /// <returns></returns>
        private string GetPreviousKey<TModel>(List<TModel> cachedData, Func<TModel, string> getKey,
            Func<TModel, List<TModel>, TModel> getPreviousRecord, TModel firstRecord) where TModel : ModelBase
        {
            if (!string.IsNullOrEmpty(firstRecord.PreviousKey))
            {
                return firstRecord.PreviousKey;
            }

            var deletedRecords = new List<TModel>();

            if (cachedData != null)
            {
                deletedRecords = cachedData.Where(data => data.IsDeleted).ToList();
            }

            var previousRecord = getPreviousRecord(firstRecord, deletedRecords);
            int recordCount = 0;

            if (previousRecord != null && getKey(previousRecord) != null)
            {
                if (cachedData != null)
                {
                    //get the last record from the cache based on the previousRecord
                    //This while condition will make sure under no circumstances, this loop becomes infinite.
                    while (recordCount < cachedData.Count)
                    {
                        var record =
                            cachedData.FirstOrDefault(
                                item => item.PreviousKey == getKey(previousRecord) && !item.IsDeleted);
                        if (record == null)
                        {
                            break;
                        }
                        previousRecord = record;
                        recordCount++;
                    }
                }
                return getKey(previousRecord);
            }
            return null;
        }

        /// <summary>
        /// Updates Cached Data. 
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modifiedData">Modified Data.</param>
        /// <param name="cachedData">The cached list</param>
        /// <returns></returns>
        private List<TModel> UpdateCachedData<TModel>(List<TModel> modifiedData, List<TModel> cachedData) where TModel : ModelBase
        {
            if (cachedData == null)
            {
                cachedData = new List<TModel>();
            }
            if (modifiedData.Any())
            {
                foreach (var item in modifiedData)
                {
                    if (!(item.IsDeleted && item.IsNewLine))
                    {
                        // insert the modified row.
                        cachedData.Add(item);
                    }
                }

            }
            return cachedData;
        }

        /// <summary>
        /// Validate Duplicate Record
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <param name="clientList">List of models</param>
        /// <param name="cachedData">Cached Data</param>
        /// <param name="getKey">Key expression</param>
        /// <param name="resourceName">Resource name - Required for validation exception</param>
        private void ValidateDuplicateRecord<TModel>(List<TModel> clientList, List<TModel> cachedData,
            Func<TModel, string> getKey, string resourceName) where TModel : ModelBase
        {
            var keys = new List<string>();
            foreach (var item in clientList.Where(data => !data.IsDeleted))
            {
                string key = getKey(item);
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }
                if (keys.Contains(key))
                {
                    var entityErrors = new List<EntityError>
                    {
                        new EntityError
                        {
                            Message = string.Format(CommonResx.DuplicateMessage, resourceName, key),
                            Priority = Priority.Error
                        }
                    };
                    throw new DuplicateRecordException(string.Empty, entityErrors);
                }
                keys.Add(key);
                if (cachedData != null && item.IsNewLine)
                {
                    var existingItem =
                        cachedData.FirstOrDefault(
                            cachedItem => getKey(cachedItem) == getKey(item) && !cachedItem.IsDeleted);

                    if (existingItem != null)
                    {
                        var entityErrors = new List<EntityError>
                        {
                            new EntityError
                            {
                                Message = string.Format(CommonResx.DuplicateMessage, resourceName, getKey(item)),
                                Priority = Priority.Error
                            }
                        };
                        throw new DuplicateRecordException(string.Empty, entityErrors);
                    }
                }
            }
        }

        /// <summary>
        /// Save model data and manupulate cache in case of error.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model data (list).</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getKey">GetKey expression</param>
        /// <param name="getPreviousRecord">Get Previous Record expression</param>
        /// <param name="saveFunc">Save - handler</param>
        /// <returns>Model - list</returns>
        protected EnumerableResponse<TModel> Save<TModel>(EnumerableResponse<TModel> model, string cacheKey, Func<TModel, string> getKey,
            Func<TModel, List<TModel>, TModel> getPreviousRecord, Func<EnumerableResponse<TModel>, EnumerableResponse<TModel>> saveFunc) where TModel : ModelBase
        {

            var itemsFoeSave = MergeChangeItem(model, -1, -1, -1, cacheKey, null, getKey, getPreviousRecord, null, null);



            try
            {
                var data = saveFunc(itemsFoeSave);
                // Remove the cached data for fresh storage
                SessionHelper.Remove(cacheKey);
                return data;
            }
            catch (TransactionFailedException<TModel> exception)
            {
                var cachedList = itemsFoeSave.Items.ToList();
                if (cachedList.Any())
                {
                    var shouldUpdateCache = false;
                    foreach (var item in exception.Items)
                    {
                        //Remove all the saved items from cache, and keep the unsaved items as it is
                        if (cachedList.Contains(item))
                        {
                            cachedList.Remove(item);
                            shouldUpdateCache = true;
                        }
                    }
                    if (shouldUpdateCache)
                    {
                        SessionHelper.Set(cacheKey, cachedList);
                    }
                }
                throw;
            }
        }


        /// <summary>
        /// Save model data and manupulate cache in case of error.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model data (list).</param>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getKey">GetKey expression</param>
        /// <param name="saveFunc">Save - handler</param>
        /// <returns>
        /// Model - list
        /// </returns>
        protected EnumerableResponse<TModel> Save<TModel>(EnumerableResponse<TModel> model, int currentPageNumber, string cacheKey, Func<TModel, string> getKey,
             Func<EnumerableResponse<TModel>, EnumerableResponse<TModel>> saveFunc) where TModel : ModelBase
        {

            var itemsForSave = Get(model, -1, -1, currentPageNumber, -1, cacheKey, getKey, null, null);

            try
            {
                var data = saveFunc(itemsForSave);

                // Remove the cached data for fresh storage
                SessionHelper.Remove(cacheKey);
                return data;
            }
            catch (TransactionFailedException<TModel> exception)
            {
                var cachedList = itemsForSave.Items.ToList();
                if (cachedList.Any())
                {
                    var shouldUpdateCache = false;
                    foreach (var item in exception.Items)
                    {
                        //Remove all the saved items from cache, and keep the unsaved items as it is
                        if (cachedList.Contains(item))
                        {
                            cachedList.Remove(item);
                            shouldUpdateCache = true;
                        }
                    }

                    if (shouldUpdateCache)
                    {
                        SessionHelper.Set(cacheKey, cachedList);
                    }
                }
                throw;
            }
        }


        #endregion


        #region New Simple Cache implementation

        /// <summary>
        /// Get Page Details.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="previousPageNumber">The previous page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="getKey">The get key.</param>
        /// <param name="getPagedRecords">The get paged data.</param>
        /// <param name="newLineModel">The new line model.</param>
        /// <returns></returns>
        protected EnumerableResponse<TModel> Get<TModel>(EnumerableResponse<TModel> model, int pageNumber,
            int pageSize, int previousPageNumber, int insertIndex, string cacheKey, Func<TModel, string> getKey,
            Func<PageOptions<TModel>, EnumerableResponse<TModel>> getPagedRecords, TModel newLineModel) where TModel : ModelBase
        {
            var cachedList = SessionHelper.Get<List<TModel>>(cacheKey);
            var hasDataChanged = false;
            var pageOptions = new PageOptions<TModel> { PageNumber = pageNumber, PageSize = pageSize };
            var clientList = (model == null || model.Items == null) ? null : model.Items.ToList();

            if (cachedList == null)
            {
                if (clientList != null)
                {
                    hasDataChanged = clientList.Any(c => c.HasChanged) || clientList.Any(c => c.IsNewLine) ||
                                     clientList.Any(c => c.IsDeleted) || insertIndex > 0;
                }

                //Nothing is changed
                if (!hasDataChanged)
                {
                    if (getPagedRecords == null) return null;
                    var startIndex = CommonUtil.ComputeStartIndex(pageOptions.PageNumber, pageOptions.PageSize);

                    //Data is not modified by the user.
                    var result = getPagedRecords(pageOptions);
                    var serverList = result.Items.ToList();

                    // Update Display index after fetching data from server.
                    foreach (var item in serverList)
                    {
                        item.DisplayIndex = startIndex;
                        startIndex++;
                    }
                    return result;
                }
            }

            if (clientList != null && clientList.Count > 0)
            {
                var modifiedData = new List<TModel>();

                #region Update Display Index

                var pageStartIndex = previousPageNumber == 0 ? 1 : (previousPageNumber - 1) * pageSize + 1;
                var currentPageIndex = pageStartIndex;

                for (var i = 0; i < clientList.Count(); i++)
                {
                    var modifiedItem = clientList[i];

                    //DisplayIndex will be zero only for new items.
                    if (modifiedItem.DisplayIndex == 0)
                    {
                        modifiedItem.DisplayIndex = currentPageIndex;
                        if (!modifiedItem.IsDeleted)
                        {
                            if (string.IsNullOrEmpty(getKey(modifiedItem)))
                            {
                                continue;
                            }
                            // Add newly added line
                            modifiedData.Add(modifiedItem);

                            // increment the display item index for those item in the cache.
                            ReOrderCacheDataDisplayIndex(currentPageIndex, cachedList, false);
                        }
                        else
                        {
                            //This below record should not be in the cache
                            RemoveMatchigItemFromCache(cachedList, currentPageIndex);

                            // continue to the next record since newly added item is deleted.
                            continue;
                        }
                    }
                    else
                    {
                        //record is changed, so remove from cache, and later cache will updated values
                        if (modifiedItem.HasChanged || (modifiedItem.IsNewLine && modifiedItem.IsDeleted))
                        {
                            RemoveMatchigItemFromCache(cachedList, currentPageIndex);
                        }

                        if (modifiedItem.HasChanged || modifiedItem.IsDeleted)
                        {
                            if (modifiedItem.IsNewLine && modifiedItem.IsDeleted)
                            {
                                // since the items are deleted in above condition, consider re-ordering the display index for the items in the cache.
                                ReOrderCacheDataDisplayIndex(currentPageIndex, cachedList, true);
                                // continue to the next record since newly added item is deleted.
                                continue;
                            }
                            modifiedItem.DisplayIndex = currentPageIndex;
                            modifiedData.Add(modifiedItem);

                            if (modifiedItem.IsDeleted)
                            {
                                // since the row is deleted, consider re-ordering the display index for the items in the cache.
                                ReOrderCacheDataDisplayIndex(currentPageIndex, cachedList, true);
                                continue;
                            }
                        }
                    }
                    currentPageIndex++;
                }

                #endregion

                #region Update Cache

                // Update cache.
                cachedList = UpdateCachedData(modifiedData, cachedList);

                // update cache with updated and deleted items.
                SessionHelper.Set(cacheKey, cachedList);

                #endregion
            }

            #region Get Page Data

            if (getPagedRecords != null)
            {
                pageOptions.ModifiedData = cachedList;
                pageOptions.GetKey = getKey;

                var result = getPagedRecords(pageOptions);
                var serverList = result.Items.ToList();

                // Update Display index after fetching data from server.
                var startIndex = CommonUtil.ComputeStartIndex(pageOptions.PageNumber, pageOptions.PageSize);
                foreach (var item in serverList)
                {
                    item.DisplayIndex = startIndex;
                    startIndex++;
                }

                // get the total records.
                var totalCount = result.TotalResultsCount;

                if (insertIndex > 0)
                {
                    int remainder;
                    Math.DivRem(insertIndex, pageSize, out remainder);
                    serverList.Insert(remainder, newLineModel);
                    totalCount++;
                }

                var modelsToReturn = serverList.Take(pageSize).ToList();

                return new EnumerableResponse<TModel>
                {
                    Items = modelsToReturn.Take(pageOptions.PageSize).ToList(),
                    TotalResultsCount = totalCount
                };
            }

            #endregion

            // If cache Item is not empty then return the cached items.
            if (cachedList != null)
            {
                return new EnumerableResponse<TModel>
                {
                    Items = cachedList.ToList(),
                    TotalResultsCount = cachedList.Count()
                };
            }

            return null;
        }

        /// <summary>
        /// Helper method for deleting item from cache
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="cachedList"></param>
        /// <param name="currentPageIndex"></param>
        private static void RemoveMatchigItemFromCache<TModel>(List<TModel> cachedList, int currentPageIndex) where TModel : ModelBase
        {
            if (cachedList == null) return;
            //Remove from cache by checking if any item exists in cache for the given display index.
            var existingItem = cachedList.FirstOrDefault(cachedItem => cachedItem.DisplayIndex == currentPageIndex && (cachedItem.HasChanged || cachedItem.IsNewLine));
            // Remove the item from cache.
            cachedList.Remove(existingItem);
        }


        /// <summary>
        /// Increases the display index.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="currentItemDisplayIndex">Display index of the current item.</param>
        /// <param name="cachedData">The cached data.</param>
        /// <param name="isItemDeleted">if set to <c>true</c> [is item deleted].</param>
        private void ReOrderCacheDataDisplayIndex<TModel>(int currentItemDisplayIndex, List<TModel> cachedData, bool isItemDeleted) where TModel : ModelBase
        {
            //update display index for rest of inserted items.
            if (cachedData != null)
            {
                foreach (var dataItem in
                    cachedData.Where(c => c.DisplayIndex >= currentItemDisplayIndex && (c.IsNewLine || c.HasChanged) && !c.IsDeleted)
                        .OrderBy(o => o.DisplayIndex))
                {
                    if (!isItemDeleted)
                    {
                        dataItem.DisplayIndex++;
                    }
                    else
                    {
                        dataItem.DisplayIndex--;
                    }
                }
            }
        }

        #endregion

    }
}
