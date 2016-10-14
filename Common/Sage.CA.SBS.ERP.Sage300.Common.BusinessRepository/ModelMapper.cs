#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System.Collections.Generic;
using System.Dynamic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Class Model Mapper.
    /// </summary>
    public abstract class ModelMapper<T> where T : ModelBase, new()
    {
        #region Private Properties

        /// <summary>
        /// Context
        /// </summary>
        protected Context Context { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        protected ModelMapper(Context context)
        {
            Context = context;
        }

        #endregion

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>T</returns>
        public virtual T Map(IBusinessEntity entity)
        {
            var model = new T {ETag = entity.ETag};
            return model;
        }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="entity">entity</param>
        public abstract void Map(T model, IBusinessEntity entity);
        
        /// <summary>
        /// Map Key
        /// </summary>
        /// <param name="model">model</param>
        /// <param name="entity">entity</param>
        public abstract void MapKey(T model, IBusinessEntity entity);

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <returns></returns>
        public IDictionary<string, object> ConvertToDynamic(IEnumerable<EnablementAttribute> attributes)
        {
            IDictionary<string, object> jsonFriendly = new ExpandoObject();
            foreach (var enablementAttribute in attributes)
            {
                jsonFriendly.Add(enablementAttribute.PropertyName, enablementAttribute.Disabled);
            }
            return jsonFriendly;
        }

        /// <summary>
        /// Validates DrillDown Screen Type - Temporary for Feb Release.
        /// </summary>
        /// <param name="rotoId">Type of model</param>
        /// <returns></returns>
        public void ValidateDrillDown(string rotoId)
        {
            switch (rotoId)
            {
                case ScreenRotoIds.ARRefundEntry:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.ARRefund), new List<EntityError>());
                case ScreenRotoIds.ARAdjustmentEntry:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.ARAdjustment), new List<EntityError>());
                case ScreenRotoIds.APAdjustmentEntry:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.ARAdjustment), new List<EntityError>());
                case ScreenRotoIds.ICAssembly:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.ICAssembly), new List<EntityError>());
                case ScreenRotoIds.OEInvoiceEntry:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.OEInvoice), new List<EntityError>());
                case ScreenRotoIds.OEShipmentEntry:
                    throw new BusinessException(string.Format(CommonResx.NoScreenAvailable, CommonResx.OEShipment), new List<EntityError>());
            }
        }
    }
}
