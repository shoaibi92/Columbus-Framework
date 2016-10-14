/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models
{
    /// <summary>
    /// Represents database seed results
    /// </summary>
    public class DbSeedResult
    {
        /// <summary>
        /// List of Entity seed results
        /// </summary>
        public IEnumerable<EntitySeedResult> EntitySeedResults { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entitySeedResults">collection of EntitySeedResult objects</param>
        public DbSeedResult(IEnumerable<EntitySeedResult> entitySeedResults)
        {
            EntitySeedResults = entitySeedResults;
        }

        /// <summary>
        /// Converts content of the object to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();

            foreach (var entry in EntitySeedResults)
            {
                sb.AppendLine(entry.EntityName);

                if (entry.Messages.Count > 0)
                {
                    sb.Append("Messages:");
                    foreach (var message in entry.Messages)
                    {
                        sb.AppendLine(message);
                    }
                }

                if (entry.Errors.Count > 0)
                {
                    sb.AppendLine("Errors:");
                    foreach (var error in entry.Errors)
                    {
                        sb.AppendLine(error);
                    }
                }

                sb.AppendLine();
            }

            sb.AppendLine(HasErrors ? "Data seeding failed" : "Data seeding succedded.");
            sb.AppendLine();

            return sb.ToString();
        }

        public bool HasErrors
        {
            get { return EntitySeedResults.Any(result => result.Errors.Count > 0); }
        }
    }
}
