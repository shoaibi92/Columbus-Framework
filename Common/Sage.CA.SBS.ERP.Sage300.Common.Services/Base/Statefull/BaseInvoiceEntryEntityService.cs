/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base.Statefull
{
    /// <summary>
    /// BaseInvoiceEntry Entity Service
    /// </summary>
    /// <typeparam name="TBatch">Batch Entity</typeparam>
    /// <typeparam name="THeader">Header Entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TEntity">Repository</typeparam>
    public abstract class BaseInvoiceEntryEntityService<TBatch, THeader, TDetail, TEntity> : BatchHeaderDetailEntityService<TBatch, THeader, TDetail, TEntity>,
        IBaseInvoiceEntryService<TBatch, THeader, TDetail>
        where TBatch : BaseInvoiceBatch, new()
        where THeader : BaseInvoice, new()
        where TDetail : BaseInvoiceDetail, new()
        where TEntity : IBaseInvoiceEntryEntity<TBatch, THeader, TDetail>
    {
        /// <summary>
        /// Constructor for BaseInvoiceEntryEntityService
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseInvoiceEntryEntityService(Context context)
            : base(context)
        {

        }

        /// <summary>
        /// Update Tax Calculation method
        /// </summary>
        /// <param name="model">Header model</param>
        /// <returns>Header model</returns>
        public virtual THeader UpdateTaxCalculateType(THeader model)
        {
            var repository = Resolve<TEntity>();
            return repository.UpdateTaxCalculateType(model);
        }

        /// <summary>
        /// Refreshes Tax
        /// </summary>
        /// <param name="processType">Process type</param>
        /// <returns>Header Data</returns>
        public virtual THeader TaxRefresh(int processType)
        {
            var repository = Resolve<TEntity>();
            return repository.TaxRefresh(processType);
        }

        /// <summary>
        /// Creates the distribution codes based on distribution set chosen. 
        /// </summary>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <returns>THeader model</returns>
        public virtual THeader CreateDistribution(string documentTotalIncludingTax, string distributionSetAmount)
        {
            var repository = Resolve<TEntity>();
            return repository.CreateDistribution(documentTotalIncludingTax, distributionSetAmount);
        }

        /// <summary>
        /// Sets TaxGroupAuthority model data to proper entity header entity model
        /// </summary>
        /// <param name="model">TaxGroupAuthority model</param>
        /// <param name="isDetailTaxData">if detail tax data is passed</param>
        /// <returns>THeader model</returns>
        public virtual  THeader SetTaxGroupAuthority(TaxGroupAuthority model, bool isDetailTaxData)
        {
            var repository = Resolve<TEntity>();
            return repository.SetTaxGroupAuthority(model, isDetailTaxData);
        }

        /// <summary>
        /// Refresh Details
        /// </summary>
        /// <param name="model">Detail model</param>
        /// <param name="eventType">Type of event</param>
        /// <returns>Detail model</returns>
        public virtual BaseInvoice RefreshDetail(BaseInvoiceDetail model, string eventType)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail(model, eventType);
        }

        /// <summary>
        /// Update the model when the Vendor number is changed
        /// </summary>
        /// <param name="id">Vendor Number</param>
        /// <returns>Header model</returns>
        public virtual THeader ChangeVendor(string id)
        {
            var repository = Resolve<TEntity>();
            return repository.ChangeVendor(id);
        }
        
        /// <summary>
        /// Maps the data to current detail
        /// </summary>
        /// <param name="currentDetail">Current Detail</param>
        /// <returns>Batch Model</returns>
        public virtual TBatch SetDetail(BaseInvoiceDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail(currentDetail);
        }

        /// <summary>
        /// To set the changed value and get the model
        /// </summary>
        /// <param name="value">changed value</param>
        /// <param name="property">Property that changed</param>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshHeader(string value, string property)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshHeader(value, property);
        }
        
        /// <summary>
        /// Clears the details with empty data
        /// </summary>
        /// <param name="model">Batch model</param>
        /// <returns>Batch model</returns>
        public virtual TBatch ClearDetails(TBatch model)
        {
            var repository = Resolve<TEntity>();
            return repository.ClearDetails(model);
        }

        /// <summary>
        /// Derive Rate
        /// </summary>
        /// <returns>THeader model</returns>
        public virtual THeader DeriveRate()
        {
            var repository = Resolve<TEntity>();
            return repository.DeriveRate();
        }

        /// <summary>
        /// Get corresponding Tax Authorities for a specific TaxGroup
        /// </summary>
        /// <param name="id">Tax Group</param>
        /// <returns>Header model</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetTaxAuthorities(string id)
        {
            var repository = Resolve<TEntity>();
            return repository.GetTaxAuthorities(id);
        }

        /// <summary>
        /// Gets optional field data
        /// </summary>
        /// <param name="pageNumber">Current PageNumber</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="isDetailOptField">If detail optional field</param>
        /// <returns>Enumerable Response of BaseInvoiceOptionalField model</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize, bool isDetailOptField)
        {
            var repository = Resolve<TEntity>();
            return repository.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
        }

        /// <summary>
        /// On change of Document Type returns updated header model
        /// </summary>
        /// <param name="documentType">Document Type string</param>
        /// <returns>THeader model</returns>
        public virtual THeader ChangeDocumentType(DocumentType documentType)
        {
            var repository = Resolve<TEntity>();
            return repository.ChangeDocumentType(documentType);
        }

        
        /// <summary>
        /// Creates a new Optional Field
        /// </summary>
        /// <param name="currentOptionalField">TOptionalField model</param>
        /// <returns>TOptionalField model</returns>
        public virtual BaseInvoiceOptionalField NewOptionalField(BaseInvoiceOptionalField currentOptionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.NewOptionalField(currentOptionalField);
        }

        /// <summary>
        /// Save for details
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns>Boolean value</returns>
        public virtual bool SaveDetails(IEnumerable<BaseInvoiceDetail> details)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails(details);
        }

        /// <summary>
        /// Gets Updated Model
        /// </summary>
        /// <returns>TBatch model</returns>
        public virtual TBatch UpdatedModel()
        {
            var repository = Resolve<TEntity>();
            return repository.UpdatedModel();
        }
        /// <summary>
        /// Save the optional field
        /// </summary>
        /// <param name="optionalField">TOptionalField model</param>
        /// <returns>TOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SaveOptionalField(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveOptionalField(optionalField);
        }

        /// <summary>
        /// Updates the Optional Field on Optional Field Entry
        /// </summary>
        /// <param name="optionalField">TOptionalField model</param>
        /// <returns>TOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.SetOptionalField(optionalField);
        }

        /// <summary>
        /// Updates the Optional Field Value on Optional Field Value Entry
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.SetOptionalFieldValue(optionalField);
        }

        /// <summary>
        /// To check if the optional field exists or not
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>Boolean value</returns>
        public virtual bool IsOptionalFieldExists(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.IsOptionalFieldExists(optionalField);
        }

        /// <summary>
        /// Save Optional Fields
        /// </summary>
        /// <param name="optionalFields">List of TOptionalField</param>
        /// <param name="isDetailOptionalField">If detail optional field</param>
        /// <returns>Boolean value</returns>
        public virtual bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields, bool isDetailOptionalField)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveOptionalFields(optionalFields,isDetailOptionalField);
        }

        /// <summary>
        /// Delete Optional Field
        /// </summary>
        /// <param name="model">List of TOptionalField</param>
        /// <returns>TOptionalField model</returns>
        public virtual BaseInvoiceOptionalField DeleteOptionalField(List<BaseInvoiceOptionalField> model)
        {
            var repository = Resolve<TEntity>();
            return repository.DeleteOptionalField(model);
        }

        /// <summary>
        /// Update Batch 
        /// </summary>
        /// <param name="model">Batch model</param>
        /// <returns>Batch model</returns>
        public virtual TBatch UpdateBatch(TBatch model)
        {
            var repository = Resolve<TEntity>();
            return repository.UpdateBatch(model);
        }

        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns></returns>
        //TODO: Suppress Warning
        public virtual UserAccess GetAccessRights()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual TBatch NewDetail(int pageNumber, int pageSize, BaseInvoiceDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail(pageNumber, pageSize, currentDetail);
        }

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TBatch model</returns>
        public virtual TBatch SaveDetail(BaseInvoiceDetail detail)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail(detail);
        }

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail</param>
        /// <returns>Enumerable Response of TaxGroupAuthority</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(BaseInvoiceDetail model)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetailTaxes(model);
        }

        /// <summary>
        /// Get data by Ids
        /// </summary>
        /// <typeparam name="TBatchKey">Batch key</typeparam>
        /// <typeparam name="THeaderKey">Header key</typeparam>
        /// <param name="batchKey">Batch Number</param>
        /// <param name="headerKey">Entry Number</param>
        /// <returns>TBatch model</returns>
        public virtual TBatch GetByIds<TBatchKey, THeaderKey>(TBatchKey batchKey, THeaderKey headerKey)
        {
            var repository = Resolve<TEntity>();
            return repository.GetByIds(batchKey, headerKey);
        }
        
        /// <summary>
        /// Unlock Batch Resource when exiting the screen
        /// </summary>
        public virtual void UnlockBatchResource()
        {
            var repository = Resolve<TEntity>();
            repository.UnlockBatchResource();
        }    
    }
}
