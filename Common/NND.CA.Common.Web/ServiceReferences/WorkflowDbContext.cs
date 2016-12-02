using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NND.CA.Common.Model;

namespace NND.CA.Common.Web.ServiceReferences
{
    public class WorkflowDbContext : BaseDbContext
    {
        private const string ConnectionString = "NNDCIDCSQL01DbContextString";

        
        public WorkflowDbContext()
            : base(ConnectionString)
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

            modelBuilder.Entity<WorkflowKind>().Property(prop => prop.WorkflowKindId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

    }
}