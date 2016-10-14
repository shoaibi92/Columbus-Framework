using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// Model Mapper for the Invoice Entry Screens
    /// </summary>
    /// <typeparam name="TBatch">Batch Model</typeparam>
    /// <typeparam name="THeader">Entry Model</typeparam>
    /// <typeparam name="TDetail">Detail Model</typeparam>
    /// <typeparam name="TPayment">Payment Model</typeparam>
    /// <typeparam name="TOptional">Optional Field Model</typeparam>
    public abstract class BaseInvoiceEntryMapper<TBatch, THeader, TDetail, TPayment, TOptional> : ModelHierarchyMapper<TBatch>
        where TBatch : ModelBase, new()
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TPayment : ModelBase, new()
        where TOptional : ModelBase, new()
    {
        /// <summary>
        ///  Maps Tax Group
        /// </summary>
        /// <param name="taxGroup">T model</param>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public abstract void MapTaxGroup(string taxGroup, IBusinessEntity entity);


        /// <summary>
        /// Map Payment Schedule
        /// </summary>
        /// <param name="taxGroup">Tax Group</param>
        /// <param name="entities">Entity</param>
        public abstract void MapPaymentSchedule(string taxGroup, List<IBusinessEntity> entities);

        /// <summary>
        /// Map Optional Field
        /// </summary>
        /// <param name="optionalField">Optional Field</param>
        /// <param name="entity">Entity</param>
        public abstract void MapOptionalField(BaseInvoiceOptionalField optionalField, IBusinessEntity entity);

        /// <summary>
        /// Map Vendors
        /// </summary>
        /// <param name="vendorNumber">Vendor Number</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapVendor(string vendorNumber, IBusinessEntity entity);

        /// <summary>
        /// Map Batch Number
        /// </summary>
        /// <param name="batchNumber">Batch Number</param>
        /// <param name="entity">Entity</param>
        public abstract void MapBatchNumber(string batchNumber, IBusinessEntity entity);

        /// <summary>
        /// Map Entry Number
        /// </summary>
        /// <param name="entryNumber">Batch Number</param>
        /// <param name="entity">Entity</param>
        public abstract void MapEntryNumber(string entryNumber, IBusinessEntity entity);

        /// <summary>
        /// Map Remit Location
        /// </summary>
        /// <param name="remitToLocation">Remit to Location</param>
        /// <param name="entity">IBusinessEntity</param>
        /// <returns></returns>
        public abstract void MapRemitToLocation(string remitToLocation, IBusinessEntity entity);

        /// <summary>
        /// Map Terms
        /// </summary>
        /// <param name="terms">Remit to Location</param>
        /// <param name="type"></param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapTerms(string terms,string type, IBusinessEntity entity);

        /// <summary>
        /// Map Terms
        /// </summary>
        /// <param name="total">Document Total</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapDocumentTotal(string total ,IBusinessEntity entity);

        /// <summary>
        /// Map DocumentType
        /// </summary>
        /// <param name="documentType">Document Type</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapDocumentType(DocumentType documentType, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data only Related to Terms
        /// </summary>
        /// <param name="entity">IBusinessEntity</param>
        /// <returns></returns>
        public abstract THeader MapGetTerms(IBusinessEntity entity);

        /// <summary>
        /// Get Header Data only Related to Terms
        /// </summary>
        /// <param name="processType">Type Of Process</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapProcessCommand(int processType, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data only Related to Terms
        /// </summary>
        /// <param name="processType">Type Of Process</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapDetailProcessCmd(int processType, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data when RateType is Changed in Rate Tab
        /// </summary>
        /// <param name="rateType">Rate Type</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapRateType(string rateType, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data when Distribution Set is Changed in Distribution Tab
        /// </summary>
        /// <param name="distributionSet">Distribution Set</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapDistributionSet(string distributionSet, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data when On Hold is Changed in Document Tab
        /// </summary>
        /// <param name="onHold">On Hold</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapOnHold(string onHold, IBusinessEntity entity);

        /// <summary>
        /// Get Header Data when Account set is Changed in Document Tab
        /// </summary>
        /// <param name="accountSet">On Hold</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapAccountSet(string accountSet, IBusinessEntity entity);

        /// <summary>
        /// Get Type of Calculate
        /// </summary>
        /// <param name="model">THeader Model</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapTaxCalculateType(THeader model, IBusinessEntity entity);

        /// <summary>
        /// Set Distribution Type
        /// </summary>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void MapDistribution(string documentTotalIncludingTax, string distributionSetAmount, IBusinessEntity entity);

        /// <summary>
        /// Update Fiscal Year and Period
        /// </summary>
        /// <param name="period">Fiscal Period</param>
        /// <param name="year">Fiscal Year</param>
        /// <param name="entity">Entity</param>
        public abstract void UpdateFiscalYearPeriod(string period, string year, IBusinessEntity entity);

        /// <summary>
        /// Converts the Header Models Tax Authority Data to List of TaxGroupAuthority
        /// </summary>
        /// <param name="model">THeader Model</param>
        public abstract EnumerableResponse<TaxGroupAuthority> GetTaxAuthority(THeader model);

        /// <summary>
        /// Converts the Header Models Tax Authority Data to List of TaxGroupAuthority
        /// </summary>
        /// <param name="model">BaseInvoiceDetail Model</param>
        /// <param name="headerEntity">Header Entity</param>
        public abstract EnumerableResponse<TaxGroupAuthority> GetDetailTaxAuthority(BaseInvoiceDetail model, IBusinessEntity headerEntity);

        /// <summary>
        /// Sets the TaxGroupAuthority model to the correct entity value
        /// </summary>
        /// <param name="model">TaxGroupAuthority model</param>
        /// <param name="isDetailTaxData">if detail tax data is passed</param>
        /// <param name="entity">IBusinessEntity</param>
        public abstract void SetTaxGroupAuthority(TaxGroupAuthority model, IBusinessEntity entity, bool isDetailTaxData);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="entity"></param>
        public virtual void MapSalesSplit(SalesSplit model, IBusinessEntity entity) 
        {
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual SalesSplit MapSalesSplit(IBusinessEntity entity)
        {
            throw new KeyNotFoundException();
        }
    }
}
