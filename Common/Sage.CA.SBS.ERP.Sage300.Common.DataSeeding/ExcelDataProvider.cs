/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Data;
using System.IO;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding
{
    /// <summary>
    /// Reads seed data from an Excel file
    /// </summary>
    public class ExcelDataProvider
        : IEntityDataProvider
    {
        #region Private Members
        /// <summary>
        /// Context
        /// </summary>
        protected Context Context;

        /// <summary>
        /// File to read
        /// </summary>
        private readonly string _filePath;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="filePath">Path to the file to read</param>
        public ExcelDataProvider(Context context, string filePath)
        {
            Context = context;
            _filePath = filePath;
        }

        /// <summary>
        /// Reads seed data
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            var reader = Context.Container.Resolve<IExportImport>(new ParameterOverride("context", Context));
            using (Stream stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                return reader.Import(stream);
            }
        }
    }
}
