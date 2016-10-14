/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi
{
    /// <summary>
    /// Base class for all ODataControllers of OrderedHeaderDetail models.
    /// </summary>
    public class BaseOrderedHeaderDetailODataController<THeader, TDetail, TService, TRepository> : BaseODataController<THeader, TService, TRepository>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TService : IOrderedHeaderDetailService<THeader, TDetail>
        where TRepository : IOrderedHeaderDetailRepository<THeader, TDetail>
    {
        /// <summary>
        /// Initializes a new instance of BaseOrderedHeaderDetailODataController
        ///     class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BaseOrderedHeaderDetailODataController(IUnityContainer container) : base(container)
        {
        }


        /// <summary>
        /// Sets the Context and all Context-dependent properties. Must be called after the
        /// Initialize() method is called so that ControllerContext is initialized (so it
        /// can't be called in the constructor). Must be called after the user is authorized
        /// via Sage ID (so it can't be called in Initialize()).
        /// </summary>
        protected override void SetContext()
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

            QueryableData = new OrderedHeaderDetailQueryableSageData<THeader, TDetail, TService>(Context);
            Service = Context.Container.Resolve<TService>(new ParameterOverride("context", Context));
        }

        /// <summary>
        /// Converts the given model into a data set.
        /// </summary>
        /// <param name="model">The model to convert.</param>
        /// <returns>The data set.</returns>
        protected override DataSet ToDataSet(THeader model)
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable(TableNameDict[typeof(THeader)]);
            var dataRowList = new List<object>();

            var modelName = model.GetType().FullName;

            // Iterate through each field that isn't MVC-specific.
            var modelType = model.GetType();
            foreach (var field in
                modelType.GetNestedType("Fields").GetFields()
                         .Where(field => !field.GetCustomAttributes()
                                       .Any(a => a is IsMvcSpecificAttribute)))
            {
                // Add a new column to the data table.
                dataTable.Columns.Add((string)field.GetValue(null));

                // Add a new row value to the list of data row values.
                var property = modelType.GetProperty(field.Name);
                var rowValue = property.GetValue(model);
                if (property.PropertyType.IsEnum)
                {
                    //The field "CheckLanguage" is stored in database 
                    //as the string of its EnumValue, e.g. "ENG", but not the string of its actual enum value, e.g. "1", "2"
                    rowValue = field.Name == "CheckLanguage" && modelName == "Sage.CA.SBS.ERP.Sage300.AR.Models.Customer"
                        ? EnumUtility.GetStringValue(rowValue as Enum)
                        : EnumUtility.EnumToString(rowValue);

                }
                dataRowList.Add(rowValue);
            }
            dataTable.Rows.Add(dataRowList.ToArray());
            dataSet.Tables.Add(dataTable);

            //Get TDetail name
            var tdetailType = typeof (TDetail);
            var tdetailName = tdetailType.Name;

            var optionTable = new DataTable(TableNameDict[tdetailType]);

            // Iterate through each field of TDetails that isn't MVC-specific.
            var prop = modelType.GetProperty(tdetailName);
            dynamic options = prop.GetValue(model);

            foreach (var option in options.Items)
            {
                var optionType = option.GetType();
                var optionRowList = new List<object>();
                FieldInfo[] fields = optionType.GetNestedType("Fields").GetFields();

                foreach (var field in
                    fields.Where(f => !f.GetCustomAttributes()
                            .Any(a => a is IsMvcSpecificAttribute)))
                {
                    // Add a new column to the data table.
                    if (!optionTable.Columns.Contains((string)field.GetValue(null)))
                    {
                        optionTable.Columns.Add((string)field.GetValue(null));
                    }

                    // Add a new row value to the list of data row values.
                    var property = optionType.GetProperty(field.Name);
                    var rowValue = property.GetValue(option);
                    if (property.PropertyType.IsEnum)
                    {
                        rowValue = EnumUtility.EnumToString(rowValue);
                    }
                    optionRowList.Add(rowValue);
                }

                optionTable.Rows.Add(optionRowList.ToArray());
            }
            dataSet.Tables.Add(optionTable);


            return dataSet;
        }

    }
}
