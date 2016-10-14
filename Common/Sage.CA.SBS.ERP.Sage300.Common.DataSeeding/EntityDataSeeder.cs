/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding
{
    /// <summary>
    /// Performs database seeding tasks for an Entity
    /// </summary>
    public class EntityDataSeeder
        : IEntityDataSeeder
    {
        #region Private Members

        private readonly string _entityName;

        private readonly IEntityDataProvider _dataProvider;

        private readonly IEntityDataImporter _dataImporter;

        private readonly List<CurrencyFieldInfo> _currencyFields;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        /// <param name="dataProvider">Entity data provider implementation</param>
        /// <param name="dataImporter">Entity data importer implementation</param>
        /// <param name="currencyFields">List of currency fields. Should be in format TableName.FieldName</param>
        public EntityDataSeeder(string entityName, IEntityDataProvider dataProvider, IEntityDataImporter dataImporter, params CurrencyFieldInfo[] currencyFields)
        {
            _entityName = entityName;
            _dataProvider = dataProvider;
            _dataImporter = dataImporter;
            _currencyFields = currencyFields == null ? new List<CurrencyFieldInfo>() : currencyFields.ToList();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        /// <param name="dataProvider">Entity data provider implementation</param>
        /// <param name="dataImporter">Entity data importer implementation</param>
        public EntityDataSeeder(string entityName, IEntityDataProvider dataProvider, IEntityDataImporter dataImporter)
            : this (entityName, dataProvider, dataImporter, null)
        {
        }
        #endregion

        /// <summary>
        /// Gets Entity Name
        /// </summary>
        public string EntityName
        {
            get { return _entityName; }
        }

        /// <summary>
        /// Performs data seeding tasks
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns></returns>
        public EntitySeedResult Seed(string currencyCode)
        {
            var result = new EntitySeedResult(_entityName);
            try
            {
                var data = _dataProvider.GetData();

                UpdateCurrencyFields(data, currencyCode);

                var response = _dataImporter.Import(data);
                result.Messages = response.Messages.Select(message => message.ResponseText).ToList();
            }
            catch (BusinessException ex)
            {
                result.Errors.AddRange(ex.Errors.Select(error => error.Message).ToList());
            }

            return result;
        }

        /// <summary>
        /// Updates currency fields with the correct currency code
        /// </summary>
        /// <param name="data">DataSet to update</param>
        /// <param name="currencyCode">Currency Code</param>
        protected void UpdateCurrencyFields(DataSet data, string currencyCode)
        {
            foreach (var currencyField in _currencyFields)
            {
                var table = data.Tables[currencyField.TableName];

                //Validate table name
                if (table == null)
                {
                    throw new BusinessException(string.Empty,
                        new List<EntityError>
                        {
                            new EntityError { Priority = Priority.Error, Message = string.Format(DataSeedingResx.InvalidTableName, currencyField.TableName)}
                        });
                }

                //Validate field name
                if (!table.Columns.Contains(currencyField.FieldName))
                {
                    throw new BusinessException(string.Empty,
                        new List<EntityError>
                        {
                            new EntityError { Priority = Priority.Error, Message = string.Format(DataSeedingResx.InvalidFieldName, currencyField.FieldName)}
                        });
                }

                //Update currency fields
                foreach (DataRow row in table.Rows)
                {
                    row[currencyField.FieldName] = currencyCode;
                }
            }
        }
    }
}
