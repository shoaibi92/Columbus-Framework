/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.ComponentModel.DataAnnotations.Schema;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess
{
    /// <summary>
    /// Workflow DB Context
    /// </summary>
    public class WorkflowDbContext : BaseDbContext
    {

        private const string ConnectionString = "WorkflowDbContext";

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkflowDbContext()
            : base(GetConnectionString(ConnectionString))
        {
            Database.SetInitializer<WorkflowDbContext>(null);
        }

        

        /// <summary>
        /// UnitOfWorkInstances
        /// </summary>
        public DbSet<UnitOfWorkInstance> UnitOfWorkInstances { get; set; }

        /// <summary>
        /// UnitOfWorkKinds
        /// </summary>
        public DbSet<UnitOfWorkKind> UnitOfWorkKinds { get; set; }

        /// <summary>
        /// WorkStatuses
        /// </summary>
        public DbSet<WorkStatus> WorkStatuses { get; set; }

        /// <summary>
        /// WorkflowInstances
        /// </summary>
        public DbSet<WorkflowInstance> WorkflowInstances { get; set; }

        /// <summary>
        /// WorkflowKinds
        /// </summary>
        public DbSet<WorkflowKind> WorkflowKinds { get; set; }

        /// <summary>
        /// WorkflowSchedules
        /// </summary>
        public DbSet<WorkflowSchedule> WorkflowSchedules { get; set; }


        /// <summary>
        /// Steps to be implemented when models are being created.
        /// 1. Does not allow table names to be pluralized
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<WorkflowKind>().Property(prop=>prop.WorkflowKindId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
