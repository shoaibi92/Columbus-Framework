using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NND.CA.Common.Model;
using NND.CA.Common.Web.ServiceReferences;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.DataAccess
{
    /// <summary>
    /// Interface IWorkflowContext
    /// </summary>
    public interface IWorkflowContext : IDisposable
    {
        /// <summary>
        /// Returns UnitOfWorkInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<UnitOfWorkInstance> UnitOfWorkInstanceRepository();

        /// <summary>
        /// Returns UnitOfWorkKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<UnitOfWorkKind> UnitOfWorkKindRepository();

        /// <summary>
        /// Returns WorkflowInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowInstance> WorkflowInstanceRepository();

        /// <summary>
        /// Returns WorkflowKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowKind> WorkflowKindRepository();

        /// <summary>
        /// Returns WorkflowScheduleRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowSchedule> WorkflowScheduleRepository();

        /// <summary>
        /// Returns WorkStatusRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkStatus> WorkStatusRepository();

        /// <summary>
        /// Save
        /// </summary>
        void Save();
    }
}
