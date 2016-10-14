/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider;
using Sage.CA.SBS.ERP.Sage300.AR.Models;
using Sage.CA.SBS.ERP.Sage300.CS.Models;
using Sage.CA.SBS.ERP.Sage300.GL.Models;
using Sage.CA.SBS.ERP.Sage300.OE.Models;
using FiscalCalendar = Sage.CA.SBS.ERP.Sage300.CS.Models.FiscalCalendar;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi
{
    /// <summary>
    /// Base class for all ODataControllers.
    /// TODO: Verify that this layer should be directly accessing the Repository layer.
    /// </summary>
    public class BaseODataController<TModel, TService, TRepository> : ODataController
        where TModel : ModelBase, new()
        where TService : IEntityService<TModel>
        where TRepository : IBusinessRepository<TModel>
    {
        #region Private Methods.

        private static Dictionary<Type, string> InitTableNameDict()
        {
            var dict = new Dictionary<Type, string>();

            #region AR Table Names.

            dict[typeof(Customer)] = "Customers";
            dict[typeof(CustomerOptionalFieldValues)] = "Customer Optional Field Values";

            #endregion

            #region CS Table Names.

            dict[typeof(CompanyProfile)] = "Company Profiles";
            dict[typeof(CurrencyCode)] = "Currency Codes";
            dict[typeof(FiscalCalendar)] = "Fiscal_Calendars";

            #endregion

            #region GL Table Names.

            dict[typeof(AccountFiscalSets)] = "Account Fiscal Sets";
            dict[typeof(AccountGroup)] = "Account Groups";
            dict[typeof(Account)] = "Accounts";
            dict[typeof(AccountSegments)] = "Account Segments";
            dict[typeof(AccountStructure)] = "Structure Codes";
            dict[typeof(JournalBatch)] = "Journal_Batches";
            dict[typeof(RecurringJournalHeader)] = "Recurring Journal Header";
            dict[typeof(SegmentCodes)] = "Segment Codes";

            #endregion

            #region OE Table Names.

            dict[typeof(Order)] = "Orders";

            #endregion

            return dict;
        }

        private static Dictionary<Type, string> InitRequestNameDict()
        {
            var dict = new Dictionary<Type, string>();

            #region AR Request Names.

            dict[typeof(Customer)] = "customer";

            #endregion

            #region CS Request Names.

            dict[typeof(CompanyProfile)] = "companyprofile";
            dict[typeof(CurrencyCode)] = "CurrencyCodes";
            dict[typeof(FiscalCalendar)] = "fiscalcalendar";

            #endregion

            #region GL Request Names.

            dict[typeof(AccountFiscalSets)] = "accountfiscalset";
            dict[typeof(AccountGroup)] = "accountgroup";
            dict[typeof(Account)] = "account";
            dict[typeof(AccountSegments)] = "accountsegment";
            dict[typeof(AccountStructure)] = "accountstructure";
            dict[typeof(JournalBatch)] = "journalbatch";
            dict[typeof(RecurringJournalHeader)] = "recurringjournalheader";
            dict[typeof(SegmentCodes)] = "segmentcode";

            #endregion

            #region OE Request Names.

            dict[typeof(Order)] = "oeorderentry";

            #endregion

            return dict;
        }

        #endregion

        #region Properties.

        // TODO: Figure out a better way to achieve this.
        #region Temporary dictionaries.
        /// <summary>
        /// Table name dictionary
        /// </summary>
        protected Dictionary<Type, string> TableNameDict { get; private set; }

        /// <summary>
        /// Request name dictionary
        /// </summary>
        protected Dictionary<Type, string> RequestNameDict { get; private set; }

        #endregion

        /// <summary>
        /// The container.
        /// </summary>
        protected IUnityContainer Container { get; private set; }
        
        /// <summary>
        /// The queryable data.
        /// </summary>
        public QueryableSageData<TModel, TService> QueryableData { get; set; }

        /// <summary>
        /// The service.
        /// </summary>
        protected TService Service { get; set; }

        /// <summary>
        /// The context.
        /// </summary>
        protected Context Context { get; set; }

        /// <summary>
        /// A filter used to remove ignored properties from the ModelState.
        /// </summary>
        protected Func<KeyValuePair<string, ModelState>, bool> IgnoredPropertyFilter { get; set; }

        /// <summary>
        /// An attribute that stores ODataValidationSettings and ODataQuerySettings.
        /// </summary>
        protected EnableQueryAttribute QueryAttribute { get; set; }

        #endregion

        #region Constructor.

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseODataController&lt;TModel, TService, TRepository&gt;"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BaseODataController(IUnityContainer container)
        {
            TableNameDict = InitTableNameDict();
            RequestNameDict = InitRequestNameDict();
            Container = container;
            IgnoredPropertyFilter = kvp => false;

            QueryAttribute = new SageEnableQueryAttribute();
        }
        
        #endregion
        
        #region Five HTTP verbs for basic CRUD.

        /// <summary>
        /// Retrieves the requested data.
        /// </summary>
        /// <param name="queryOptions">The query options.</param>
        /// <returns>IQueryable&lt;TModel&gt;.</returns>
        public virtual IQueryable<TModel> Get(ODataQueryOptions queryOptions)
        {
            SetContext();

            return QueryAttribute.ApplyQuery(QueryableData, queryOptions) as IQueryable<TModel>;
        }

        /// <summary>
        /// Adds the given model.
        /// </summary>
        /// <param name="model">The new model to be added.</param>
        /// <returns>IHttpActionResult.</returns>
        public virtual IHttpActionResult Post(TModel model)
        {
            SetContext();

            if (!ValidateModel())
            {
                return BadRequest(ModelState); // Return a 400.
            }

            var dataSet = ToDataSet(model);
            var request = new ImportRequest
            {
                Name = RequestNameDict[typeof(TModel)],
                ImportType = ImportType.Insert
            };

            ImportResponse response;
            using (var repository = ResolveRepository<TRepository>())
            {
                response = repository.Import(dataSet, request);
            }

            // Check for any processed items that weren't inserted.
            if (response.Messages.Any(m => m.Processed > m.Inserted))
            {
                return Conflict(); // Return a 409.
            }
            return Created(model); // Return a 201.
        }

        /// <summary>
        /// Using the given model, this method completely updates the old model
        /// corresponding to the given key, if it exists.
        /// </summary>
        /// <param name="key">The key of the model to be updated.</param>
        /// <param name="model">The new replacement model.</param>
        /// <returns>IHttpActionResult.</returns>
        public virtual IHttpActionResult Put([FromODataUri] string key, TModel model)
        {
            SetContext();

            if (!ValidateModel())
            {
                return BadRequest(ModelState); // Return a 400.
            }

            // Construct the filter used to get the model to be updated.
            // NOTE: The key from the URI must match the model's key.
            Expression<Func<TModel, bool>> filter;
            var entityKeyProperty = GetEntityKeyProperty(typeof(TModel));
            var entityKeyType = entityKeyProperty.PropertyType;
            var entityKeyObj = entityKeyProperty.GetValue(model);
            if (entityKeyType == typeof(string))
            {
                var keyValue = key;
                var entityKeyValue = (string)entityKeyObj;
                if (keyValue != entityKeyValue)
                {
                    return BadRequest(); // Return a 400.
                }
                filter = m => (string) entityKeyProperty.GetValue(m) == key;
            }
            else
            {
                throw new NotImplementedException("Key must have type string.");
                //var keyValue = Convert.ChangeType(key, entityKeyType);
                //var entityKeyValue = Convert.ChangeType(entityKeyObj, entityKeyType);
                //if (keyValue != entityKeyValue)
                //{
                //    return BadRequest(); // Return a 400.
                //}

                //filter =
                //    m =>
                //        Convert.ChangeType(entityKeyProperty.GetValue(m), entityKeyType) ==
                //        Convert.ChangeType(key, entityKeyType);
            }

            // Verify that the old model to be updated actually exists.
            var oldModel = QueryableData.FirstOrDefault(filter);
            if (oldModel == default(TModel))
            {
                return NotFound(); // Return a 404.
            }

            // Copy the ETag, save the changes, then return a 204.
            model.ETag = oldModel.ETag;
            Service.Save(model);
            return Updated(model);
        }

        /// <summary>
        /// Using the given patch, this method partially updates the old model
        /// corresponding to the given key, if it exists.
        /// </summary>
        /// <param name="key">The key of the model to be updated.</param>
        /// <param name="patch">The tracked changes to be updated.</param>
        /// <returns>IHttpActionResult.</returns>
        [AcceptVerbs("PATCH", "MERGE")]
        public virtual IHttpActionResult Patch([FromODataUri] string key, Delta<TModel> patch)
        {
            SetContext();

            if (!ValidateModel())
            {
                return BadRequest(ModelState); // Return a 400.
            }

            // Construct the filter used to get the model to be updated.
            var filter = GetFilter(key);

            // Find the model to be updated, if it exists.
            var model = QueryableData.FirstOrDefault(filter);
            if (model == default(TModel))
            {
                return NotFound(); // Return a 404.
            }

            // Patch the model, save the changes, then return a 204.
            patch.Patch(model);
            Service.Save(model);
            return Updated(model);
        }

        /// <summary>
        /// Deletes the model corresponding to the given key, if it exists.
        /// </summary>
        /// <param name="key">The key of the model to be deleted.</param>
        /// <returns></returns>
        public virtual IHttpActionResult Delete([FromODataUri] string key)
        {
            SetContext();

            // Construct the filter used to get the model to be deleted.
            var filter = GetFilter(key);

            // Verify that the model to be deleted actually exists.
            var model = QueryableData.FirstOrDefault(filter);
            if (model == default(TModel))
            {
                return NotFound(); // Return a 404.
            }

            // Partially evaluate the filter, then compile its GetValue.
            var compiledFilter = (Expression<Func<TModel, bool>>)Evaluator.CompileGetValue(filter);

            // Delete the model, then return a 204.
            Service.Delete(compiledFilter);
            return StatusCode(HttpStatusCode.NoContent);
        }

        #endregion

        #region Helper methods.

        /// <summary>
        /// Sets the Context and all Context-dependent properties. Must be called after the
        /// Initialize() method is called so that ControllerContext is initialized (so it
        /// can't be called in the constructor). Must be called after the user is authorized
        /// via Sage ID (so it can't be called in Initialize()).
        /// TODO: Figure out a way to call this OnActionExecuting.
        /// </summary>
        protected virtual void SetContext()
        {
            // ControllerContext has now been initialized, so we can access the tenant 
            // and company from the URL.
            var routeValueDict = ControllerContext.RouteData.Values;
            Context = new Context
            {
                ApplicationType = ApplicationType.WebAPI,
                ScreenContext = new ScreenContext(),
                // Each request uses its own separate Session.
                ContextToken = Guid.NewGuid(),
                Container = Container
            };

            var company = routeValueDict["company"] ?? string.Empty;
            var userId = routeValueDict["ApplicationUserId"] ?? string.Empty;
            var password = routeValueDict["ApplicationUserPassword"] ?? string.Empty;
            var userTenantResolver = Container.Resolve<Web.Security.IUserTenantResolver>();
            userTenantResolver.ResolveUserTenant(Container, Context, company.ToString(), userId.ToString(), password.ToString());

            SetSessionId();

            QueryableData = new QueryableSageData<TModel, TService>(Context);
            Service = Context.Container.Resolve<TService>(new ParameterOverride("context", Context));
        }

        /// <summary>
        /// Sets the given context's SessionId. This guarantees that all requests from the
        /// same User, Tenant, and Company will share the same SessionPool.
        /// </summary>
        protected void SetSessionId()
        {
            Context.SessionId = string.Format("{0}_{1}_{2}",
                Context.ProductUserId, Context.TenantId, Context.Company);
        }

        /// <summary>
        /// Uses reflection in order to find the property of the given objectType that
        /// serves as its Entity Key. Assumes that:
        /// - Such an Entity Key exists.
        /// - No composite keys are used (returns the first Entity Key that it encounters).
        /// TODO: Provide composite key functionality.
        /// </summary>
        /// <param name="objectType">The type that reflection will be performed on.</param>
        /// <returns>PropertyInfo.</returns>
        protected static PropertyInfo GetEntityKeyProperty(Type objectType)
        {
            foreach (var prop in objectType.GetProperties())
            {
                var attributes = prop.GetCustomAttributes().ToList();
                // Lists can't be Entity Keys, so we ignore them.
                if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType.IsEnum || prop.PropertyType == typeof(string))
                {
                    if (attributes.Exists(attr => attr is KeyAttribute))
                    {
                        return prop;
                    }
                }
            }

            throw new NotSupportedException("No entity key found!");
        }

        /// <summary>
        /// Constructs a filter that can be used to find the model corresponding to the
        /// given key.
        /// TODO: Handle keys that aren't of type string.
        /// </summary>
        /// <param name="key">The key of the desired model.</param>
        /// <returns>Expression&lt;Func&lt;TModel, bool&gt;&gt;.</returns>
        protected static Expression<Func<TModel, bool>> GetFilter(string key)
        {
            var entityKeyProperty = GetEntityKeyProperty(typeof(TModel));
            var entityKeyType = entityKeyProperty.PropertyType;
            if (entityKeyType == typeof(string))
            {
                return m => (string)entityKeyProperty.GetValue(m) == key;
            }
            if (entityKeyType == typeof(decimal))
            {
                decimal decimalKey;
                if (!decimal.TryParse(key, out decimalKey))
                    throw new FormatException("Invalid key value");
                return m => (decimal)entityKeyProperty.GetValue(m) == decimalKey;
            }

            throw new NotImplementedException("Key type is not currently supported.");
            //return
            //    m =>
            //        Convert.ChangeType(entityKeyProperty.GetValue(m), entityKeyType) ==
            //        Convert.ChangeType(key, entityKeyType);
        }

        /// <summary>
        /// Converts the given model into a data set.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <returns>The data set.</returns>
        protected virtual DataSet ToDataSet(TModel model)
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable(TableNameDict[typeof(TModel)]);
            var dataRowList = new List<object>();
            
            // Iterate through each field that isn't MVC-specific.
            var modelType = model.GetType();
            foreach (var field in 
                modelType.GetNestedType("Fields").GetFields()
                         .Where(f => !f.GetCustomAttributes()
                                       .Any(a => a is IsMvcSpecificAttribute)))
            {
                // Add a new column to the data table.
                dataTable.Columns.Add((string) field.GetValue(null));

                // Add a new row value to the list of data row values.
                var property = modelType.GetProperty(field.Name);
                var rowValue = property.GetValue(model);
                if (property.PropertyType.IsEnum)
                {
                    rowValue = EnumUtility.EnumToString(rowValue);
                }
                dataRowList.Add(rowValue);
            }
            dataTable.Rows.Add(dataRowList.ToArray());
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        /// <summary>
        /// Resolves an instance of the requested repository type.
        /// </summary>
        /// <typeparam name="T">The type of the requested repository.</typeparam>
        /// <returns>The requested repository.</returns>
        protected T ResolveRepository<T>()
        {
            return Context.Container.Resolve<T>(UnityInjectionType.Default, new ParameterOverride("context", Context));
        }

        /// <summary>
        /// Removes ignored properties from ModelState, then validates the model to check
        /// if the model binder ran into any issues (for example, there could have been a
        /// type conversion issue).
        /// </summary>
        /// <returns>True iff the model is valid.</returns>
        protected bool ValidateModel()
        {
            // NOTE: The ToArray() is important; we must cache the values.
            foreach (var kvp in ModelState.Where(IgnoredPropertyFilter).ToArray())
            {
                ModelState.Remove(kvp.Key);
            }

            return ModelState.IsValid;
        }

        #endregion
    }
}