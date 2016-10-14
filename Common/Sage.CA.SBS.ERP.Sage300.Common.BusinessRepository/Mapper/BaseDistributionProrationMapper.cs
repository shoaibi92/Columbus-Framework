using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// Class to set Distribution Proration. 
    /// This mapper has been added here has distribution proration code is being made common.
    /// </summary>
    /// <typeparam name="T">POOEBaseInvDistProration model</typeparam>
    public class BaseDistributionProrationMapper<T> : ModelMapper<T> where T : Proration, new()
    {

        #region Constructor
        /// <summary>
        /// Constructor to set the Context
        /// </summary>
        /// <param name="context">Context</param>
        public BaseDistributionProrationMapper(Context context)
            : base(context)
        {
        }
        #endregion

        #region IModelMapper methods
        /// <summary>
        /// Get Mapper
        /// </summary>
        /// <param name="entity">Business Entity</param>
        /// <returns>Mapped Model</returns>
        public override T Map(IBusinessEntity entity)
        {
            var model = base.Map(entity);

            model.LineRevision = entity.GetValue<decimal>(POOEBaseInvDistProration.BaseFields.LineRevision);
            model.Contract = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.Contract);
            model.Project = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.Project);
            model.CostCategory = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.CostCategory);
            model.CostClass = (CostClass)(entity.GetValue<int>(POOEBaseInvDistProration.BaseFields.CostClass));
            model.ItemNumber = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.ItemNumber);
            model.ItemDescription = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.ItemDescription);
            model.Amount = entity.GetValue<decimal>(POOEBaseInvDistProration.BaseFields.Amount);
            model.BillingType = (BillingType)(entity.GetValue<int>(POOEBaseInvDistProration.BaseFields.BillingType));
            model.BillingRate = entity.GetValue<decimal>(POOEBaseInvDistProration.BaseFields.BillingRate);
            model.BillingCurrency = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.BillingCurrency);
            model.ARItemNumber = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.ARItemNumber);
            model.ARUnitOfMeasure = entity.GetValue<string>(POOEBaseInvDistProration.BaseFields.ARUnitOfMeasure);
            model.ProjectType = (ProjectType)(entity.GetValue<int>(POOEBaseInvDistProration.BaseFields.ProjectType));
            model.AccountingMethod = (AccountingMethod)(entity.GetValue<int>(POOEBaseInvDistProration.BaseFields.AccountingMethod));
            return model;
        }
        /// <summary>
        /// SetValue Mapper
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        public override void Map(T model, IBusinessEntity entity)
        {
            if (model == null)
            {
                return;
            }

            entity.SetValue(POOEBaseInvDistProration.BaseFields.LineRevision, model.LineRevision);
            entity.SetValue(POOEBaseInvDistProration.BaseFields.Amount, model.Amount);
            entity.SetValue(POOEBaseInvDistProration.BaseFields.BillingRate, model.BillingRate);

        }

        /// <summary>
        /// Map Key
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Business Entity</param>
        /// <exception cref="NotImplementedException"></exception>
        public override void MapKey(T model, IBusinessEntity entity)
        {
            entity.SetValue(POOEBaseInvDistProration.BaseFields.LineRevision, model.LineRevision);
        }
        #endregion
    }
}
