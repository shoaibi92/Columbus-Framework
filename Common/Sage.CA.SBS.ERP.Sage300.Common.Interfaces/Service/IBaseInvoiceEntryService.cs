/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// Base Invoice Entry Service 
    /// </summary>
    /// <typeparam name="TBatch">TBatch model</typeparam>
    /// <typeparam name="THeader">THeader model</typeparam>
    /// <typeparam name="TDetail">TDetail model</typeparam>
    public interface IBaseInvoiceEntryService<TBatch, THeader, TDetail> : IBatchHeaderDetailService<TBatch, THeader, TDetail>, ISecurityService
        where TBatch : BaseInvoiceBatch
        where THeader : BaseInvoice
        where TDetail : BaseInvoiceDetail
    {

        /// <summary>
        /// Service Interface for UpdateTaxCalculateType,Updates the Tax tab when the dropdowns in the UI is changed
        /// </summary>
        /// <param name="model">Invoices </param>
        /// <returns></returns>
        THeader UpdateTaxCalculateType(THeader model);

        /// <summary>
        /// Service Interface for TaxRefresh,Updates the Tax tab Calculate or Distribute Button is clicked
        /// </summary>
        /// <param name="processType">Type of Process the header should Perform</param>
        /// <returns>Invoices model</returns>
        THeader TaxRefresh(int processType);

        /// <summary>
        /// Derive Rate
        /// </summary>
        /// <returns>Header  model</returns>
        THeader DeriveRate();

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        TBatch SetDetail(BaseInvoiceDetail currentDetail);
        
        /// <summary>
        /// To set the changed value and get the model
        /// </summary>
        /// <param name="value">Changed value</param>
        /// <param name="property">Property that changed</param>
        /// <returns>THeader model</returns>
        THeader RefreshHeader(string value, string property);

        /// <summary>
        /// Gets the Updated Model
        /// </summary>
        /// <returns>THeader model</returns>
        TBatch UpdatedModel();

        /// <summary>
        /// Creates the distribution codes based on distribution set chosen. 
        /// </summary>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <returns>returns THeader model</returns>
        THeader CreateDistribution(string documentTotalIncludingTax, string distributionSetAmount);

        /// <summary>
        /// Maps TaxGroupAuthority model to proper Header Data
        /// </summary>
        /// <param name="model">TaxGroupAuthority model</param>
        /// <param name="isDetailTaxData">if detail tax data is passed</param>
        /// <returns>THeader model</returns>
        THeader SetTaxGroupAuthority(TaxGroupAuthority model, bool isDetailTaxData);

        /// <summary>
        /// Service Interface for RefreshDetail,Refresh the invoice Detail
        /// </summary>
        /// <param name="model"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        BaseInvoice RefreshDetail(BaseInvoiceDetail model, string eventType);

        /// <summary>
        /// To check whether the invoice optional fields exist
        /// </summary>
        bool IsOptionalFieldExists(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Change Vendor
        /// </summary>
        /// <param name="id">Vendor Number</param>
        /// <returns>THeader model</returns>
        THeader ChangeVendor(string id);
        
        /// <summary>
        /// Service Interface for GetTaxAuthorities,Get tax Authority data for Tax group
        /// </summary>
        /// <param name="id">Tax Group</param>
        /// <returns>returns EnumerableRespomse of TaxGroupAuthority model</returns>
        EnumerableResponse<TaxGroupAuthority> GetTaxAuthorities(string id);

        /// <summary>
        /// Service Interface for GetDetailTaxes,Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <returns>returns EnumerableRespomse of TaxGroupAuthority model</returns>
        EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(BaseInvoiceDetail model);

        /// <summary>
        /// Service Interface for SaveDetails,Save for detail entry
        /// </summary>
        /// <param name="details">List of BaseInvoiceDetail model</param>
        /// <returns>Boolean value</returns>
        bool SaveDetails(IEnumerable<BaseInvoiceDetail> details);

        /// <summary>
        /// Service Interface for SaveDetail,Save for detail entry
        /// </summary>
        /// <param name="detail">BaseInvoiceDetail model</param>
        /// <returns>TBatch model</returns>
        TBatch SaveDetail(BaseInvoiceDetail detail);

        /// <summary>
        /// Service Interface for GetOptionalField,Gets the Optional Field data
        /// </summary>
        /// <param name="pageNumber"> Current PageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="isDetailOptField">if detail optional field</param>
        /// <returns>Enumerable Response of  BaseInvoiceOptionalField model</returns>
        EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize, bool isDetailOptField);


        /// <summary>
        /// Service Interface for NewOptionalField,To add new optional field
        /// </summary>
        /// <param name="currentOptionalField">Current Optional field</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField NewOptionalField(BaseInvoiceOptionalField currentOptionalField);

        /// <summary>
        /// Service Interface for SaveOptionalField,To save the invoice detail optional fields
        /// </summary>
        /// <param name="optionalField">List of invoice detail optional field</param>
        /// <returns>List of invoice detail optional fields</returns>
        BaseInvoiceOptionalField SaveOptionalField(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Service Interface for SetOptionalField,Set Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Service Interface for SetOptionalFieldValue,Set Optional Field Value
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Service Interface for SaveOptionalFields,save optional fields
        /// </summary>
        /// <param name="optionalFields">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">if detail optional feild</param>
        /// <returns>Boolean value</returns>
        bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields, bool isDetailOptionalField);

        /// <summary>
        /// Service Interface for DeleteOptionalField,,To delete invoice Detail Optional Field
        /// </summary>
        /// <param name="model">List of InvoiceDetailOptionalFields</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField DeleteOptionalField(List<BaseInvoiceOptionalField> model);

        /// <summary>
        /// Service Interface for UpdateBatch,Update batch data
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>TBatch model</returns>
        TBatch UpdateBatch(TBatch model);

        /// <summary>
        /// Service Interface for ChangeDocumentType,On change of Document Type returns updated header model
        /// </summary>
        /// <param name="documentType">Document Type string</param>
        /// <returns>THeader model</returns>
        THeader ChangeDocumentType(DocumentType documentType);

        /// <summary>
        /// Service Interface for NewDetail,Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>returns TBatch model</returns>
        TBatch NewDetail(int pageNumber, int pageSize, BaseInvoiceDetail currentDetail);

        /// <summary>
        /// Service Interface for GetByIds,Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TBatchKey">Batch model key</typeparam>
        /// <typeparam name="THeaderKey">Entry model key</typeparam>
        /// <param name="batchKey">Batch Number</param>
        /// <param name="headerKey">Entry Number</param>
        /// <returns>Batch model</returns>
        TBatch GetByIds<TBatchKey, THeaderKey>(TBatchKey batchKey, THeaderKey headerKey);

        /// <summary>
        /// Unlock Batch Resource when exiting the screen
        /// </summary>
        void UnlockBatchResource();
    }
}
