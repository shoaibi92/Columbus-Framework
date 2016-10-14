/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

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
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System;
using System.Data;
using System.IO;




#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork
{
    /// <summary>
    /// Export Unit of work
    /// </summary>
    public class ExportUow : BaseUnitOfWork
    {
        /// <summary>
        /// Constructor to initialize base class BaseUnitOfWork
        /// </summary>
        /// <param name="workflowInstance">WorkFlowInstance</param>
        /// <param name="unitOfWorkInstance">UnitOfWorkInstance</param>
        /// <param name="queue">Azure Queue</param>
        /// <param name="keepAlive">KeepAlive</param>
        /// <param name="container">Unity COntainer</param>
        public ExportUow(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
            : base(workflowInstance, unitOfWorkInstance, queue, keepAlive, container)
        {
        }

        /// <summary>
        /// Implementation of Execute method
        /// </summary>
        protected override void OnExecute()
        {
            ExportResponse response;
            Seed<ExportRequest> seedEntity;
            try
            {
                seedEntity = GetSeedEntity<ExportRequest>(WorkflowInstance.SeedEntity);
                seedEntity.Context.Container = Container;
                var dataSet = GetDataSet(seedEntity);
                response = Export(seedEntity.Context, dataSet, seedEntity.Model);
            }
            catch (BusinessException businessException)
            {
                response = new ExportResponse { Results = businessException.Errors };
            }
            UpdateResult(response);
        }

        private ExportResponse Export(Context context, DataSet dataSet, ExportRequest request)
        {
            var exportImportService = new CommonService(context).GetExportImport();
            var byteArray = exportImportService.Export(dataSet);
            return UploadByteArray(context, byteArray, dataSet, request);
        }

        private ExportResponse GetExportResult(DataSet dataSet, string fileName, ExportRequest request)
        {
            var response = new ExportResponse();
            foreach (DataTable table in dataSet.Tables)
            {
                var result = new EntityError
                {
                    Priority = Priority.Message,
                    Message = string.Format(CommonResx.ExportResult, table.TableName, (table.Rows.Count))
                };
                response.Results.Add(result);
            }
            response.Name = request.Name;
            response.FileName = fileName;
            return response;
        }

        private ExportResponse UploadByteArray(Context context, byte[] byteArray, DataSet dataSet, ExportRequest request)
        {
            var blobName = Guid.NewGuid() + ".xlsx";

            if (!ConfigurationHelper.IsOnPremise)
            {
                var container = new CommonService(context).GetBlobContainer();
                var subDirectory = container.GetDirectoryReference(Helper.ExportDirectory);
                var blob = subDirectory.GetBlobReference(blobName);
                blob.UploadByteArray(byteArray);
            }
            else
            {
                var commonFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var filePath = Path.Combine(commonFolderPath, blobName);
                var fileStream = File.Create(filePath);
                fileStream.Write(byteArray, 0, byteArray.Length);
                fileStream.Flush();
                fileStream.Close();
            }

            return GetExportResult(dataSet, blobName, request);
        }

        /// <summary>
        /// Update result/errors to database
        /// </summary>
        /// <param name="result"></param>
        /// <param name="isError">true is error</param>
        protected void UpdateResult(ExportResponse result, bool isError = false)
        {
            var processResultAsString = SerializationUtil.TypeToString(result);
            var unitOfWorkManager = UnitOfWorkManagerFactory.Create(WorkflowManagerFactory.Create(null, null));
            if (isError)
            {
                unitOfWorkManager.UpdateUnitOfWorkWithError(UnitOfWorkInstance.UnitOfWorkInstanceId,
                    processResultAsString);
            }
            unitOfWorkManager.UpdateUnitOfWorkWithResult(UnitOfWorkInstance.UnitOfWorkInstanceId, processResultAsString);
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
        /// 
        /// </summary>
        /// <param name="seedEntity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual DataSet GetDataSet(Seed<ExportRequest> seedEntity)
        {
            bool isRegistered = Container.IsRegistered<IExportImportRepository>(seedEntity.Model.Name);
            if (!isRegistered)
            {
                BootstrapTaskManager.RegisterTypes(seedEntity.Context.WebSitePath);
            }

            using (var repository = Resolve<IExportImportRepository>(seedEntity.Model.Name, seedEntity.Context))
            {
                var dataset = repository.Export(seedEntity.Model);
                return dataset;
            }
        }
    }
}