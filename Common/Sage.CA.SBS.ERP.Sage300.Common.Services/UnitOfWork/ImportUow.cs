/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork
{
    /// <summary>
    /// Import Unit of work
    /// </summary>
    public class ImportUow : BaseUnitOfWork
    {
        /// <summary>
        /// Constructor to initialize base class BaseUnitOfWork
        /// </summary>
        /// <param name="workflowInstance">WorkFlowInstance</param>
        /// <param name="unitOfWorkInstance">UnitOfWorkInstance</param>
        /// <param name="queue">Azure Queue</param>
        /// <param name="keepAlive">KeepAlive</param>
        /// <param name="container">Unity COntainer</param>
        public ImportUow(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
            : base(workflowInstance, unitOfWorkInstance, queue, keepAlive, container)
        {
        }

        /// <summary>
        /// Implementation of Execute method
        /// </summary>
        protected override void OnExecute()
        {
            var response = new ImportResponse();
            Seed<ImportRequest> seedEntity = null;
            try
            {
                seedEntity = GetSeedEntity<ImportRequest>(WorkflowInstance.SeedEntity);
                seedEntity.Context.Container = Container;
                var dataSet = GetDataSet(seedEntity);
                response = Import(dataSet, seedEntity.Model, seedEntity.Context);
            }
            catch (BusinessException businessException)
            {
                response.Results = businessException.Errors;
            }
            catch (Exception exception)
            {
                Logger.Error("Exception in Import", LoggingConstants.ModuleWorkerRole,
                    seedEntity != null ? seedEntity.Context : null, exception);
                var result = new EntityError { Priority = Priority.Error, Message = CommonResx.ImportFileContentNotValid };
                response.Results.Add(result);
            }
            finally
            {
                if (seedEntity != null)
                {
                    UpdateResult(response);
                    Delete(seedEntity.Context, seedEntity.Model.FileName);
                }
            }
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual ImportResponse Import(DataSet dataSet, ImportRequest request, Context context)
        {
            Logger.Info(string.Format("Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork.ImportUow.Import request.Name: {0}", request.Name), "Sage.CA.SBS.ERP.Sage300.Common.Services");
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Logger.Info(string.Format("Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork.ImportUow.Import column.ColumnName: {0}", column.ColumnName), "Sage.CA.SBS.ERP.Sage300.Common.Services");
                }
            }

            bool isRegistered = Container.IsRegistered<IExportImportRepository>(request.Name);
            if (!isRegistered)
            {
                BootstrapTaskManager.RegisterTypes(context.WebSitePath);
            }

            using (var repository = Resolve<IExportImportRepository>(request.Name, context))
            {
                var response = repository.Import(dataSet, request);
                return response;
            }
        }

        /// <summary>
        /// Update result/errors to database
        /// </summary>
        /// <param name="result"></param>
        /// <param name="isError"></param>
        private void UpdateResult(ImportResponse result, bool isError = false)
        {
            if (result.Messages.ToList().Any() || result.Results.ToList().Any())
            {
                foreach (var item in result.Messages)
                {
                    result.Results.Add(new EntityError { Priority = Priority.Message, Message = item.ResponseText });
                }
            }
            else
            {
                result.Results.Add(new EntityError { Priority = Priority.Error, Message = CommonResx.ImportFileContentNotValid });
            }
            var processResultAsString = SerializationUtil.TypeToString(result);
            var unitOfWorkManager = UnitOfWorkManagerFactory.Create(WorkflowManagerFactory.Create(null, null));
            if (isError)
            {
                unitOfWorkManager.UpdateUnitOfWorkWithError(UnitOfWorkInstance.UnitOfWorkInstanceId,
                    processResultAsString);
            }
            unitOfWorkManager.UpdateUnitOfWorkWithResult(UnitOfWorkInstance.UnitOfWorkInstanceId,
                    processResultAsString);
        }

        /// <summary>
        /// Implementation for getting Status
        /// </summary>
        /// <returns></returns>
        protected override ProgressMeter GetProgressStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel the process
        /// </summary>
        protected override void CancelProcess()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Date Set
        /// </summary>
        /// <param name="seedEntity"></param>
        /// <returns></returns>
        private DataSet GetDataSet(Seed<ImportRequest> seedEntity)
        {
            var fileName = seedEntity.Model.FileName;

            using (Stream result = new MemoryStream())
            {
                if (ConfigurationHelper.IsOnPremise)
                {
                    var commonFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                    var importFilename = Path.Combine(commonFolderPath, fileName);

                    using (var input = new FileStream(importFilename, FileMode.Open))
                    {
                        input.CopyTo(result);
                    }
                }
                else
                {
                    var blobReference =
                        new CommonService(seedEntity.Context).GetBlobContainer()
                            .GetDirectoryReference(Helper.ImportDirectory)
                            .GetBlobReference(fileName);

                    blobReference.DownloadStream(result);
                }

                if (result.Length <= 0)
                {
                    return new DataSet();
                }

                IExportImport exportImportService = new CommonService(seedEntity.Context).GetExportImport();
                return exportImportService.Import(result);
            }
        }

        /// <summary>
        /// Delete the blob after import
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fileName"></param>
        private void Delete(Context context, string fileName)
        {
            if (ConfigurationHelper.IsOnPremise)
            {
                var commonFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                var importFilename = Path.Combine(commonFolderPath, fileName);

                File.Delete(importFilename);
            }
            else
            {

                var blobReference =
                    new CommonService(context).GetBlobContainer()
                        .GetDirectoryReference(Helper.ImportDirectory)
                        .GetBlobReference(fileName);

                if (blobReference != null)
                {
                    blobReference.Delete();
                }
            }
        }

    }
}