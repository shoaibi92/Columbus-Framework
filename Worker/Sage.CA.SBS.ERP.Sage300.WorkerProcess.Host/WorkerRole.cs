/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using Sage.CA.SBS.ERP.Sage300.Core.Azure;
using Sage.CA.SBS.ERP.Sage300.Worker;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.WorkerProcess.Host
{
    /// <summary>
    /// Class WorkerRole.
    /// </summary>
    public class WorkerRole : RoleEntryPoint
    {
        /// <summary>
        /// override method Run - initialize all the work processors
        /// and executed the work
        /// </summary>
        public override void Run()
        {
            if (RoleEnvironment.IsEmulated)
            {

                try
                {
                    Helper.HostWorkerService();
                    Helper.GetWorkerDispatcherInstance().Start();
                }
                catch (Exception ex)
                {
                    AzureDiagnosticEnvironment.WriteLine(ex.ToString(), true);
                }
            }
            else
            {
                AzureDiagnosticEnvironment.WriteLine("Worker role uses windows service");
                while (true)
                {
                    Thread.Sleep(10000);
                }
            }
        }

        /// <summary>
        /// On Start - we initialize and open the worker service here
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            //Some times in worker role network drive fail to connect to azure file service ,so code is commented here and executing the command script to connect to azure file service. 
            //try
            //{
            //    //Make Azure file server, persistant 
            //    AzureDiagnosticEnvironment.MountShare();
            //}
            //catch (Exception ex)
            //{
            //    AzureDiagnosticEnvironment.WriteLine(ex.ToString(), true);
            //}


            ////Hook on to the RoleEnvironment events
            RoleEnvironment.Changing += RoleEnvironmentChanging;
            RoleEnvironment.Changed += RoleEnvironmentChanged;

            return base.OnStart();
        }

        /// <summary>
        /// RoleEventChanging - Called when a change is about to be applied to the role.  Determines whether or not to recycle the role instance.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">A list of what is changing</param>
        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            AzureDiagnosticEnvironment.WriteLine("Role changing");

            // Note: e.Cancel == true -> Azure should recycle the role.  If all the changes are in our "exempt" list,
            // we don't need to recycle the role.
            e.Cancel = AzureDiagnosticEnvironment.HasNonExemptConfigurationChanges(e.Changes);

            // Note that we use Trace.WriteLine here rather than going through the Diagnostics class so that we will always log
            // this, even when the switch for whether to log or not is being changed.
            AzureDiagnosticEnvironment.WriteLine(
                !e.Cancel
                    ? "WorkerRole::RoleEnvironmentChanging - role is not recycling, getting new switch values from config file."
                    : "WorkerRole::RoleEnvironmentChanging - recycling role instance due to non-exempt configuration changes.");
        }

        /// <summary>
        /// RoleEnvironmentChanged - Called after a change has been applied to the role.
        /// NOTE: This is called AFTER RoleEnvironmentChanging is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">List of what has changed</param>
        private void RoleEnvironmentChanged(object sender, RoleEnvironmentChangedEventArgs e)
        {
            AzureDiagnosticEnvironment.WriteLine("UpdateLoggingFilters");

            // Refresh the diagnostic switches from the role config values.
            // This allows for run-time changing of the values of the switches without recycling (i.e. rebooting)
            // the role so we can turn on or off more verbose diagnostic output based on the switches we've
            // defined in ServiceConfiguration.cscfg.
            Core.Logging.Logger.UpdateLoggingFilters();

            AzureDiagnosticEnvironment.WriteLine(
                "WorkerRole:: RoleEnvironmentChanged - Logging Filters Updated from the Azure Configuration file.");
        }
    }
}