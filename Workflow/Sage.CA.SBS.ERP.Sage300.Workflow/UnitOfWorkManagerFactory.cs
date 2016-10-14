/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// Unit Of Work Manager Factory
    /// </summary>
    public static class UnitOfWorkManagerFactory
    {
        /// <summary>
        /// create the instance
        /// </summary>
        /// <param name="workflowManager"></param>
        /// <returns></returns>
        public static IUnitOfWorkManager Create(IWorkflowManager workflowManager)
        {
            return new UnitOfWorkManager(workflowManager);
        }
    }
}
