/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.CSharp;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Controller;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.ExportImport
{
    /// <summary>
    /// Export/Import controller internal - base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public class BaseExportImportControllerInternal<T, TService> : InternalControllerBase<TService>, IExportImportController
        where T : ModelBase, new()
        where TService : IEntityService<T>, ISecurityService
    {
        /// <summary>
        /// Get Options
        /// </summary>
        /// <exception cref="NotImplementedException">Not Implemented Exception</exception>
        /// <returns></returns>
        public virtual IEnumerable<CustomSelectList> Options(bool isExport = false)
        {
            return new List<CustomSelectList>();
        }

        /// <summary>
        /// ExportItems
        /// </summary>
        /// <param name="request">Export request</param>
        /// <returns>Export Request</returns>
        public virtual ExportRequest ExportItems(ExportRequest request)
        {
            request.DataMigrationList.Add(GetDataMigrationItem<T>(request.Name));
            return request;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">context</param>
        public BaseExportImportControllerInternal(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Export method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual ExportResponse Export(ExportRequest request)
        {
            var result = Service.Export(request);
            return result;
        }

        /// <summary>
        /// Import method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual ImportResponse Import(ImportRequest request)
        {
            var result = Service.Import(request);
            return result;
        }

        /// <summary>
        /// Get Status
        /// </summary>
        /// <param name="request">token Id</param>
        /// <returns>Status Result</returns>
        public virtual ExportResponse ExportStatus(ExportResponse request)
        {
            var result = Service.ExportStatus(request);
            return result;
        }

        /// <summary>
        /// Get Status
        /// </summary>
        /// <param name="request">token Id</param>
        /// <returns>Status Result</returns>
        public virtual ImportResponse ImportStatus(ImportResponse request)
        {
            var result = Service.ImportStatus(request);
            return result;
        }

        /// <summary>
        /// Get Columns
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected IList<BusinessEntityField> GetColumns(Type type)
        {
            var columns = new List<BusinessEntityField>();

            if (type == null)
            {
                return columns;
            }

            var indexClass = type.GetNestedType("Index");

            if (indexClass == null)
            {
                return columns;
            }

            GetColumns(indexClass, type, columns, 1);
            return columns.OrderBy(field => field.columnId).ToList();
        }

        /// <summary>
        /// Get property attributes
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="indexClass"></param>
        /// <param name="property"></param>
        /// <returns>BusinessEntityField</returns>
        private static BusinessEntityField GetPropertyAttributes(List<Attribute> attributes, Type indexClass, PropertyInfo property)
        {
            var index = indexClass.GetField(property.Name);
            if (index == null)
            {
                return null;
            }

            var businessEntityField = new BusinessEntityField
            {
                field = property.Name,
                columnId = Convert.ToInt32(index.GetValue(null)),
            };

            using (var p = new CSharpCodeProvider())
            {
                var r = new CodeTypeReference(property.PropertyType);
                businessEntityField.dataType = p.GetTypeOutput(r);
            }

            var displayAttribute = attributes.Find(attr => attr is DisplayAttribute);
            businessEntityField.title = displayAttribute != null
                ? ((DisplayAttribute)displayAttribute).GetName()
                : property.Name;

            businessEntityField.IsKey = attributes.Exists(attr => attr is KeyAttribute);
            return businessEntityField;
        }

        /// <summary>
        /// Ignore property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="attributes">List of attributes</param>
        /// <returns></returns>
        private static bool IgnoreProperty(PropertyInfo property, out List<Attribute> attributes)
        {
            attributes = property.GetCustomAttributes().ToList();
            if (attributes.Exists(attr => attr is IgnoreExportImportAttribute))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get columns
        /// </summary>
        /// <param name="indexClass"></param>
        /// <param name="objectType"></param>
        /// <param name="columns"></param>
        /// <param name="level"></param>
        private void GetColumns(Type indexClass, Type objectType, IList<BusinessEntityField> columns, int level)
        {
            var props = objectType.GetProperties();
            List<Attribute> attributes;
            foreach (var prop in props)
            {
                if (IgnoreProperty(prop, out attributes))
                {
                    continue;
                }
                if (prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType.IsEnum || prop.PropertyType == typeof(string))
                {
                    var businessEntityField = GetPropertyAttributes(attributes, indexClass, prop);
                    if (businessEntityField != null)
                    {
                        columns.Add(businessEntityField);
                    }
                }
                else if (level == 1 && prop.PropertyType.IsClass && prop.PropertyType.IsSubclassOf(typeof(ModelBase)))
                {
                    GetColumns(indexClass, prop.PropertyType, columns, level + 1);
                }
            }
        }

        /// <summary>
        /// Get DataMigrationItem using reflection
        /// Key should have an entry in Model.Constants class
        /// </summary>
        /// <typeparam name="TModel">modelbase</typeparam>
        /// <param name="dataMigrationKey">key</param>
        /// <param name="useReflection">using reflection to get description</param>
        /// <returns>DataMigration</returns>
        protected DataMigration GetDataMigrationItem<TModel>(string dataMigrationKey, bool useReflection = true) where TModel : ModelBase
        {
            var description = (useReflection) ? CommonUtilities.GetExportImportTableName<TModel>(dataMigrationKey) : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dataMigrationKey.ToLower());
            return new DataMigration { Description = description, Items = GetColumns(typeof(TModel)) };
        }

        /// <summary>
        /// Import Request
        /// </summary>
        /// <returns>ImportRequest object</returns>
        public virtual ImportRequest GetDefaultImportRequest(string name, string importOption)
        {
            return new ImportRequest
            {
                Name = name,
                FileName = Guid.NewGuid().ToString(),
                ImportType = ImportType.InsertUpdate,
                SelectedOption = importOption
            };
        }
    }
}