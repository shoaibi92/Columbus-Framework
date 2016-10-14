using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Class OrderedHeaderDetailBusinessEntitySet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    public class SequencedHeaderDetailBusinessEntitySet<T, TU>
        where T : ModelBase,new()
        where TU : ModelBase,new()
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
        public Expression<Func<T, bool>> HeaderFilter { get; set; }

        /// <summary>
        /// Gets or sets the header mapper.
        /// </summary>
        /// <value>The header mapper.</value>
        public ModelMapper<T> HeaderMapper { get; set; }

        /// <summary>
        /// Gets or sets the detail business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity DetailBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TU, bool>> DetailFilter { get; set; }

        /// <summary>
        /// Gets or sets the detail mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TU> DetailMapper { get; set; }
    }
}
