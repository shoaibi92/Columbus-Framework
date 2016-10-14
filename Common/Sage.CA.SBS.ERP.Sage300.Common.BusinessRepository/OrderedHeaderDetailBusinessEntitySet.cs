/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq.Expressions;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Class OrderedHeaderDetailBusinessEntitySet.
    /// </summary>
    /// <typeparam name="THeader">The type of the header.</typeparam>
    /// <typeparam name="TDetail">The type of the detail.</typeparam>
    public class OrderedHeaderDetailBusinessEntitySet<THeader, TDetail> where THeader : ModelBase, new() where TDetail : ModelBase,new()
    {
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
}
