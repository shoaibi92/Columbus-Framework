/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces
{
    /// <summary>
    /// Interface definition for entity seeder object
    /// </summary>
    public interface IEntityDataSeeder
    {
        /// <summary>
        /// Entity Name
        /// </summary>
        string EntityName { get; }

        /// <summary>
        /// Performs data seeding operations for an Entity
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>EntitySeedResult</returns>
        EntitySeedResult Seed(string currencyCode);
    }
}
