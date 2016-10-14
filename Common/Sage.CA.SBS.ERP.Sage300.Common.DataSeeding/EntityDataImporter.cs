/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Data;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding
{
    /// <summary>
    /// Performs data import task
    /// </summary>
    public class EntityDataImporter
        : IEntityDataImporter
    {
        #region Private Members
        protected readonly Context Context;

        private readonly ImportRequest _request;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="request">ImportRequest</param>
        public EntityDataImporter(Context context, ImportRequest request)
        {
            Context = context;
            _request = request;
        }

        /// <summary>
        /// Imports data into the database
        /// </summary>
        /// <param name="data">DataSet to import</param>
        /// <returns></returns>
        public ImportResponse Import(DataSet data)
        {
            using (var repository = Context.Container.Resolve<IExportImportRepository>(_request.Name, new ParameterOverride("context", Context)))
            {
                return repository.Import(data, _request);
            }
        }
    }
}
