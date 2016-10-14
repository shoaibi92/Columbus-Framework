#region

using System;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Worker;

#endregion

namespace Sage.CNA.WindowsService
{
    /// <summary>
    /// Class Service.
    /// </summary>
    public partial class Service : ServiceBase
    {
        /// <summary>
        /// The _task
        /// </summary>
        private Task _task;

        /// <summary>
        /// CancellationTokenSource
        /// </summary>
        private CancellationTokenSource _tokenSource;

        /// <summary>
        /// CancellationToken
        /// </summary>
        private CancellationToken _cancellationToken;

        /// <summary>
        /// Constructor
        /// </summary>
        public Service()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
            _task = Task.Factory.StartNew(() =>DoWork(_cancellationToken), _cancellationToken,  TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <summary>
        /// Stop
        /// </summary>
        protected override void OnStop()
        {
            bool finishedSuccessfully = false;
            try
            {
                _tokenSource.Cancel();
                //Wait for 60 seconds to complete the work if something is in process.
                finishedSuccessfully = _task.Wait(TimeSpan.FromSeconds(60));
            }
            finally
            {
                if (!finishedSuccessfully)
                {
                    Logger.Error("Some tasks failed to complete.", LoggingConstants.ModuleWorkerRole, null);
                }
                else
                {
                    Logger.Info("Worker role stopped successfully.", LoggingConstants.ModuleWorkerRole);
                }
            }
        }

        /// <summary>
        /// Do work - Start the dispatcher
        /// </summary>
        private void DoWork(CancellationToken cancellationToken)
        {
            try
            {
                Helper.HostWorkerService();
                Helper.GetWorkerDispatcherInstance().Start(cancellationToken);
            }
            catch (Exception ex)
            {
                Logger.Critical("The windows service failed to start.",  LoggingConstants.ModuleWorkerRole, ex);
            }
        }
    }
}