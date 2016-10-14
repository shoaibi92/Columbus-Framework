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
    /// <typeparam name="TDetail2">The type of the TDetail2.</typeparam>
    /// <typeparam name="TDetail3">The type of the TDetail3.</typeparam>
    /// <typeparam name="TDetail4">The type of the TDetail4.</typeparam>
    /// <typeparam name="TDetail5">The type of the TDetail5.</typeparam>
    public class SequencedHeaderDetailFiveBusinessEntitySet<T, TU, TDetail2, TDetail3, TDetail4, TDetail5>
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TDetail4 : ModelBase, new()
        where TDetail5 : ModelBase, new()
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
        /// Gets or sets the detail 2 business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity Detail2BusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail 3 business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity Detail3BusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail 4 business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity Detail4BusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail 5 business entity.
        /// </summary>
        /// <value>The detail business entity.</value>
        public IBusinessEntity Detail5BusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the Distribution Proration business entity.
        /// </summary>
        /// <value>The DistributionProration entity.</value>
        public IBusinessEntity DistributionProrationBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TU, bool>> DetailFilter { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TDetail2, bool>> Detail2Filter { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TDetail3, bool>> Detail3Filter { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TDetail4, bool>> Detail4Filter { get; set; }

        /// <summary>
        /// Gets or sets the detail filter.
        /// </summary>
        /// <value>The detail filter.</value>
        public Expression<Func<TDetail5, bool>> Detail5Filter { get; set; }

        /// <summary>
        /// Gets or sets the detail mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TU> DetailMapper { get; set; }

        /// <summary>
        /// Gets or sets the detail 2 mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TDetail2> Detail2Mapper { get; set; }

        /// <summary>
        /// Gets or sets the detail 3 mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TDetail3> Detail3Mapper { get; set; }

        /// <summary>
        /// Gets or sets the detail 4 mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TDetail4> Detail4Mapper { get; set; }

        /// <summary>
        /// Gets or sets the detail 5 mapper.
        /// </summary>
        /// <value>The detail mapper.</value>
        public ModelMapper<TDetail5> Detail5Mapper { get; set; }


        /// <summary>
        /// Gets or sets the DistributionProrationMapper mapper.
        /// </summary>
        /// <value>The DistributionProrationMapper mapper.</value>
        public ModelMapper<Proration> DistributionProrationMapper { get; set; }

        /// <summary>
        /// Gets or sets the BillToLocation mapper.
        /// </summary>
        /// <value>The BillToLocation mapper.</value>
        public ModelMapper<BillToLocation> BillToLocation { get; set; }

    }
}
