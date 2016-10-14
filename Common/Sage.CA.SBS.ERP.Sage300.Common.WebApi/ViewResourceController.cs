/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Linq;
using System.Net;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider;

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi
{
    /// <summary>
    /// Main web API controller for exposing Sage views generically
    /// </summary>
    /// <typeparam name="TModel">The model type that represents the top level view</typeparam>
    public abstract class ViewResourceController<TModel> : ODataController where TModel : ModelBase, new()
    {
        /// <summary>
        /// Dependecy injection container
        /// </summary>
        protected IUnityContainer Container { get; private set; }

        /// <summary>
        /// Query interpreter
        /// </summary>
        public IOrderedQueryable QueryableData { get; set; }

        /// <summary>
        /// The context
        /// </summary>
        protected Context Context { get; set; }

        ///// <summary>
        ///// A filter used to remove ignored properties from the ModelState.
        ///// </summary>
        //protected Func<KeyValuePair<string, ModelState>, bool> IgnoredPropertyFilter { get; set; }

        /// <summary>
        /// An attribute that stores ODataValidationSettings and ODataQuerySettings
        /// </summary>
        protected EnableQueryAttribute QueryAttribute { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseODataController&lt;TModel, TService, TRepository&gt;"/> class.
        /// </summary>
        /// <param name="container">Dependecy injection container</param>
        protected ViewResourceController(IUnityContainer container)
        {
            Container = container;
            //IgnoredPropertyFilter = kvp => false;
            QueryAttribute = new SageEnableQueryAttribute();
        }

        /// <summary>
        /// Initializes an IViewEntity which defines the Sage views being exposed
        /// </summary>
        /// <returns>IViewEntity of the Sage view being exposed</returns>
        protected abstract IViewEntity GetViewEntityHierarchy();

        /// <summary>
        /// HTTP Get with query and no entity key
        /// </summary>
        /// <param name="queryOptions">query parameters passed in by OData</param>
        [HttpGet]
        public IQueryable<TModel> Get(ODataQueryOptions queryOptions)
        {
            InitializeRepository();
            return QueryAttribute.ApplyQuery(QueryableData, queryOptions) as IQueryable<TModel>;
        }

        /// <summary>
        /// HTTP Get with entity key
        /// </summary>
        /// <param name="key">entity key that identifies the record being retrieved</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(string key)
        {
            var viewResourceRepository = InitializeRepository();
            return Ok(viewResourceRepository.Get(EntityKeyParser.ParseKeySegments(key)));
        }

        /// <summary>
        /// HTTP Post for creating a new record
        /// </summary>
        /// <param name="model">the model of the record being created</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(TModel model)
        {
            TModel result;
            try
            {
                //if (!ValidateModel())
                //{
                //    return BadRequest(ModelState);
                //}

                var viewResourceRepository = InitializeRepository();
                result = viewResourceRepository.Add(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Created(result);
        }

        /// <summary>
        /// HTTP DELETE for deleting the record identified by the given key, if it exists.
        /// </summary>
        /// <param name="key">entity key that identifies the record being deleted</param>
        [HttpDelete]
        public virtual IHttpActionResult Delete(string key)
        {
            try
            {
                var viewResourceRepository = InitializeRepository();
                viewResourceRepository.Delete(EntityKeyParser.ParseKeySegments(key));
            }
            catch (Exception)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent); 
        }

        /// <summary>
        /// HTTP PUT for replacing the record identified by the given key, if it exists,
        /// with the supplied model.
        /// </summary>
        /// <param name="key">entity key that identifies the record being replaced</param>
        /// <param name="model">the model that will replace the existing record</param>
        [HttpPut]
        public virtual IHttpActionResult Put(string key, TModel model)
        {
            TModel result;
            try
            {
                //if (!ValidateModel())
                //{
                //    return BadRequest(ModelState);
                //}

                var viewResourceRepository = InitializeRepository();
                result = viewResourceRepository.Replace(EntityKeyParser.ParseKeySegments(key), model);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Updated(result);
        }

        /// <summary>
        /// Initializes the repository instance for use in servicing the request
        /// </summary>
        private IViewResourceRepository<TModel> InitializeRepository()
        {
            SetContext();

            var viewResourceRepository = new ViewResourceRepository<TModel>(Context);
            viewResourceRepository.Initialize(GetViewEntityHierarchy(), GetType().Namespace + "," + GetType().Name);

            var viewResourceService = new ViewResourceService<TModel, IViewResourceRepository<TModel>>(Context)
            {
                Repository = viewResourceRepository
            };
            var queryProvider = new SageQueryProvider<TModel, IViewResourceService<TModel, IViewResourceRepository<TModel>>>(Context)
            {
                Service = viewResourceService
            };
            QueryableData = new QueryableSageData<TModel, IViewResourceService<TModel, IViewResourceRepository<TModel>>>(Context, queryProvider);

            return viewResourceRepository;
        }

        /// <summary>
        /// Checks whether the model passed into the request in valid from the model's required attributes standpoint
        /// </summary>
        protected bool ValidateModel()
        {
            // NOTE: The ToArray() is important; we must cache the values.
            //foreach (var kvp in ModelState.Where(IgnoredPropertyFilter).ToArray())
            //{
            //    ModelState.Remove(kvp.Key);
            //}
            return ModelState.IsValid;
        }

        /// <summary>
        /// Sets the context and all context-dependent properties
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

            Context.SessionId = string.Format("{0}_{1}_{2}", Context.ProductUserId, Context.TenantId, Context.Company);
        }
    }
}
