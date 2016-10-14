/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Class to host WCF Services
    /// </summary>
    internal class WcfService : IDisposable
    {
        /// <summary>
        /// ServiceHost
        /// </summary>
        private ServiceHost _serviceHost;

        private bool _disposed;

        /// <summary>
        /// WcfService
        /// </summary>
        private static readonly WcfService Service = new WcfService();

        /// <summary>
        /// Private constructor
        /// </summary>
        private WcfService()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static WcfService Instance
        {
            get
            {
                return Service;
            }
        }

        /// <summary>
        /// Host worker service
        /// </summary>
        public void HostWorkerService()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            BootstrapTaskManager.SetupWorker(path, new[] { "Sage*.dll" });

            // Create the host
            _serviceHost = new ServiceHost(typeof(WorkerService));

            // Read config parameters
            var hostName = ConfigurationHelper.WcfHostName;
            var port = ConfigurationHelper.WcfPort;
            var mexport = ConfigurationHelper.WcfMexPort;

            // Create Metadata
            var metadatabehavior = new ServiceMetadataBehavior();
            _serviceHost.Description.Behaviors.Add(metadatabehavior);

            var mexBinding = MetadataExchangeBindings.CreateMexTcpBinding();
            var mexendpointurl = string.Format("net.tcp://{0}:{1}/WorkerServiceMetadata", hostName, mexport);
            _serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, mexendpointurl,
                new Uri(mexendpointurl));

            // Create end point
            var endpointurl = string.Format("net.tcp://{0}:{1}/WorkerService", hostName, port);
            _serviceHost.AddServiceEndpoint(typeof(IWorkerService), new NetTcpBinding(SecurityMode.None), endpointurl,
                new Uri(endpointurl));

            try
            {
                // Open the host
                _serviceHost.Open();

                // Trace output
                Logger.Info("WCF Listening At: " + endpointurl, LoggingConstants.ModuleWorkerRole);
                Logger.Info("WCF MetaData Listening At: " + mexendpointurl, LoggingConstants.ModuleWorkerRole);
            }
            catch (TimeoutException timeoutException)
            {
                Logger.Critical("The service operation timed out.", LoggingConstants.ModuleWorkerRole, timeoutException);
            }
            catch (CommunicationException communicationException)
            {
                Logger.Critical("Could not start WCF service host.", LoggingConstants.ModuleWorkerRole,
                    communicationException);
            }

        }

        /// <summary>
        /// StopWorkerService
        /// </summary>
        public void StopWorkerService()
        {
            if ((_serviceHost != null) && (_serviceHost.State != CommunicationState.Closed))
            {
                _serviceHost.Close();
            }
        }


        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopWorkerService();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// We want the remove object to be disposed only once the static object instance loses scope.
        /// </summary>
        ~WcfService()
        {
            Dispose(true);
        }
    }
}
