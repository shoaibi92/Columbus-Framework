#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{

    /// <summary>
    /// Class Model Mapper.
    /// </summary>
    public abstract class ModelHierarchyMapper<T> where T : ModelBase
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="detailPageNumber">The detail page number.</param>
        /// <param name="detailPageSize">Size of the detail page.</param>
        /// <param name="filterCount">The filter count.</param>
        public abstract T Map(List<IBusinessEntity> entities, int? detailPageNumber = null, int? detailPageSize = null,
             int? filterCount = null);

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="entity">entity</param>
        public abstract void Map(T model, List<IBusinessEntity> entity);
    }

}


