// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Microsoft.WindowsAzure.Storage.Table;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table
{
    /// <summary>
    /// Azure Session Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AzureSessionRepository<T> : AzureBaseRepository, ISessionRepository<T> where T : ISession
    {
        private const string Session = "SessionLogsTable";

        /// <summary>
        /// Constructor
        /// </summary>
        public AzureSessionRepository() : base(Session)
        {
        }

        /// <summary>
        /// Insert Audit
        /// </summary>
        /// <param name="entities">The entity.</param>
        public void Insert(List<T> entities)
        {
            InsertInternal(entities);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete()
        {
            //Delete all the entities
            Helper.DeleteAllEntitiesInBatches(CloudTable,
                entity => entity.PartitionKey == SessionEntity.GetPartitionKey());
        }

        /// <summary>
        /// Insert Audit
        /// </summary>
        /// <param name="entities">The entity.</param>
        public void InsertInternal(List<T> entities)
        {
            //Delete all the entities
            Helper.DeleteAllEntitiesInBatches(CloudTable,
                entity => entity.PartitionKey == SessionEntity.GetPartitionKey());

            var tableEntities = new List<ITableEntity>();
            foreach (var entity in entities)
            {
                var sessionEntity = entity as SessionEntity;
                if (sessionEntity == null)
                {
                    throw new ArgumentException("entities");
                }
                sessionEntity.SetKeys();
                tableEntities.Add(sessionEntity);
            }

            //Add all entities
            Helper.AddEntitiesInBatchesAsync(CloudTable, tableEntities);
        }
    }
}