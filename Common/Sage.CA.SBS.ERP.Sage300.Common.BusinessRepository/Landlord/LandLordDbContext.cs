/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord
{
    /// <summary>
    /// Class LandLordDbContext.
    /// </summary>
    public class LandlordDbContext : BaseDbContext
    {

        private const string ConnectionString = "LandLordDbContext";

        /// <summary>
        /// Initializes a new instance of the <see cref="LandlordDbContext"/> class.
        /// </summary>
        public LandlordDbContext()
            : base(GetConnectionString(ConnectionString))
        {
            Database.SetInitializer<LandlordDbContext>(null);
        }

        /// <summary>
        /// Gets or sets the user mappers.
        /// </summary>
        /// <value>The user mappers.</value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the tenants.
        /// </summary>
        /// <value>The tenants.</value>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the user tenants.
        /// </summary>
        /// <value>The tenants.</value>
        public DbSet<UserTenant> UserTenants { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}