/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// Work flow Manager Factory
    /// </summary>
    public static class WorkflowManagerFactory
    {
        /// <summary>
        /// create the new instance
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IWorkflowManager Create(IQueue queue, IUnityContainer container)
        {
            return new WorkflowManager(queue, container);
        }
    }
}
