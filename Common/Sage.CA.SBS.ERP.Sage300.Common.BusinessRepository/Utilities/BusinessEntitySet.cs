/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Class BatchHeaderDetailBusinessEntitySet.
    /// </summary>
    /// <typeparam name="TBatch">The type of the t batch.</typeparam>
    /// <typeparam name="THeader">The type of the t header.</typeparam>
    /// <typeparam name="TDetail">The type of the t detail.</typeparam>
    public class BatchHeaderDetailBusinessEntitySet<TBatch, THeader, TDetail> where TBatch : ModelBase,new()
        where THeader : ModelBase,new()
        where TDetail : ModelBase,new()
    {
        //public EntityType BusinessEntityType { get; set; }

        /// <summary>
        /// Gets or sets the batch business entity.
        /// </summary>
        /// <value>The batch business entity.</value>
        public IBusinessEntity BatchBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the batch filter.
        /// </summary>
        /// <value>The batch filter.</value>
        public Expression<Func<TBatch, bool>> BatchFilter { get; set; }

        /// <summary>
        /// Gets or sets the batch mapper.
        /// </summary>
        /// <value>The batch mapper.</value>
        public ModelMapper<TBatch> BatchMapper { get; set; }

        /// <summary>
        /// Gets or sets the header business entity.
        /// </summary>
        /// <value>The header business entity.</value>
        public IBusinessEntity HeaderBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the header filter.
        /// </summary>
        /// <value>The header filter.</value>
        public Expression<Func<THeader, bool>> HeaderFilter { get; set; }

        /// <summary>
        /// Gets or sets the header mapper.
        /// </summary>
        /// <value>The header mapper.</value>
        public ModelMapper<THeader> HeaderMapper { get; set; }

        /// <summary>
        /// Gets or sets the detail business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity DetailBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TDetail, bool>> DetailFilter { get; set; }

        /// <summary>
        /// Gets or sets the detail mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TDetail> DetailMapper { get; set; }
    }

    /// <summary>
    /// Enum EntityType
    /// </summary>
    public enum EntityType
    {
        /// <summary>
        /// The batch
        /// </summary>
        Batch = 0,

        /// <summary>
        /// The header
        /// </summary>
        Header = 1,

        /// <summary>
        /// The detail
        /// </summary>
        Detail = 2
    }
}