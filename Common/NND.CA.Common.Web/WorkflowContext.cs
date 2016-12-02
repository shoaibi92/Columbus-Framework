using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NND.CA.Common.Model;
using NND.CA.Common.Web.ServiceReferences;
using NND.CA.Common.Web;

namespace NND.CA.Common.Web
{
    /// <summary>
    /// Class WorkflowContext.
    /// </summary>
    public class WorkflowContext : IDisposable
    {
        #region Private Members

        /// <summary>
        /// The _context
        /// </summary>
        private readonly WorkflowDbContext _context = new WorkflowDbContext();

        /// <summary>
        /// The _unit of work instance repository
        /// </summary>
        private GenericRepository<UnitOfWorkInstance> _unitOfWorkInstanceRepository;

        /// <summary>
        /// The _unit of work kind repository
        /// </summary>
        private GenericRepository<UnitOfWorkKind> _unitOfWorkKindRepository;

        /// <summary>
        /// The _workflow instance repository
        /// </summary>
        private GenericRepository<WorkflowInstance> _workflowInstanceRepository;

        /// <summary>
        /// The _workflow kind repository
        /// </summary>
        private GenericRepository<WorkflowKind> _workflowKindRepository;

        /// <summary>
        /// The _workflow schedule repository
        /// </summary>
        private GenericRepository<WorkflowSchedule> _workflowScheduleRepository;

        /// <summary>
        /// The _work status repository
        /// </summary>
        private GenericRepository<WorkStatus> _workStatusRepository;

        /// <summary>
        /// The _disposed
        /// </summary>
        private bool _disposed;

        #endregion

        #region Protected Members

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion

        #region IUnitOfWork Implementation

        /// <summary>
        /// Saves user context related changes
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns UnitOfWorkInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<UnitOfWorkInstance> UnitOfWorkInstanceRepository()
        {
            return _unitOfWorkInstanceRepository ??
                   (_unitOfWorkInstanceRepository = new GenericRepository<UnitOfWorkInstance>(_context));
        }

        /// <summary>
        /// Returns UnitOfWorkKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<UnitOfWorkKind> UnitOfWorkKindRepository()
        {
            return _unitOfWorkKindRepository ??
                   (_unitOfWorkKindRepository = new GenericRepository<UnitOfWorkKind>(_context));
        }

        /// <summary>
        /// Returns WorkflowInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<WorkflowInstance> WorkflowInstanceRepository()
        {
            return _workflowInstanceRepository ??
                   (_workflowInstanceRepository = new GenericRepository<WorkflowInstance>(_context));
        }

        /// <summary>
        /// Returns WorkflowKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<WorkflowKind> WorkflowKindRepository()
        {
            return _workflowKindRepository ?? (_workflowKindRepository = new GenericRepository<WorkflowKind>(_context));
        }

        /// <summary>
        /// Returns WorkflowScheduleRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<WorkflowSchedule> WorkflowScheduleRepository()
        {
            return _workflowScheduleRepository ??
                   (_workflowScheduleRepository = new GenericRepository<WorkflowSchedule>(_context));
        }

        /// <summary>
        /// Returns UnitOfWorkKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        public GenericRepository<WorkStatus> WorkStatusRepository()
        {
            return _workStatusRepository ?? (_workStatusRepository = new GenericRepository<WorkStatus>(_context));
        }

        #endregion
    }
}
