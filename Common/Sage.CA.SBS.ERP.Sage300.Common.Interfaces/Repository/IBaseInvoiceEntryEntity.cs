/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// The API definition of the functions exposed by the Invoice Entry 
    /// </summary>
    /// <typeparam name="TBatch">T of type ModelBase</typeparam>
    /// <typeparam name="THeader">T Header of type ModelBase</typeparam>
    /// <typeparam name="TDetail">T Detail of type ModelBase</typeparam>
    public interface IBaseInvoiceEntryEntity<TBatch, THeader, TDetail> : IBatchHeaderDetailRepository<TBatch, THeader, TDetail>
        where TBatch : BaseInvoiceBatch
        where THeader : BaseInvoice
        where TDetail : BaseInvoiceDetail
    {
        /// <summary>
        /// Repository Interface for GetPagedOptionalField,Get the data for Optional Fields 
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="isDetailOptField">is detail optional field </param>
        /// <returns>Enumerable Response of BaseInvoiceOptionalField model</returns>
        EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize, bool isDetailOptField);


        /// <summary>
        /// Repository Interface for NewOptionalField,To add a  optional fields
        /// </summary>
        /// <param name="currentOptionalField">Current Optional field</param>
        /// <returns>List of BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField NewOptionalField(BaseInvoiceOptionalField currentOptionalField);

        /// <summary>
        /// Repository Interface for DeriveRate,Derive Rate
        /// </summary>
        /// <returns>Header  model</returns>
        THeader DeriveRate();

        /// <summary>
        /// Repository Interface for SaveDetails,Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns>Boolean value</returns>
        bool SaveDetails(IEnumerable<BaseInvoiceDetail> details);

        /// <summary>
        /// Gets the Updated Model
        /// </summary>
        /// <returns>THeader model</returns>
        TBatch UpdatedModel();

        /// <summary>
        /// Repository Interface for SaveDetail,Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Batch model</returns>
        TBatch SaveDetail(BaseInvoiceDetail detail);

        /// <summary>
        /// Repository Interface for SetDetail,Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail model</returns>
        TBatch SetDetail(BaseInvoiceDetail currentDetail);

        /// <summary>
        /// Repository Interface for SaveOptionalField,To save the invoice detail optional fields
        /// </summary>
        /// <param name="optionalField">List of BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField SaveOptionalField(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Repository Interface for SaveOptionalFields,To save the invoice detail optional fields
        /// </summary>
        /// <param name="optionalFields">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">is detail optional field</param>
        /// <returns>Boolean value</returns>
        bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields, bool isDetailOptionalField);

        /// <summary>
        /// Repository Interface for IsOptionalFieldExists,To check whether the invoice optional fields exist
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>Boolean value</returns>
        bool IsOptionalFieldExists(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Repository Interface for SetOptionalField,Set Optional 
        /// </summary>
        /// <param name="optionalField">Optional Field</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Repository Interface for SetOptionalFieldValue,Set Optional Field Value
        /// </summary>
        /// <param name="optionalField">Optional Field</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField);

        /// <summary>
        /// Repository Interface for GetMultiCurrency,To fetch the Multicurrency property set for the company
        /// </summary>
        /// <returns>Boolean value</returns>
        bool GetMultiCurrency();


        /// <summary>
        /// Repository Interface for DeleteOptionalField,Deletes Optional Field
        /// </summary>
        /// <param name="model">List of InvoiceDetailOptionalFields </param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        BaseInvoiceOptionalField DeleteOptionalField(List<BaseInvoiceOptionalField> model);

        ///// <summary>
        ///// Repository Interface for UpdateFiscalYearPeriod,Updates the Entry Date so that it updates Fiscal year/period
        ///// </summary>
        ///// <param name="period">Fiscal Period</param>
        ///// <param name="year">Fiscal Year</param>
        ///// <returns></returns>
        //void UpdateFiscalYearPeriod(string period, string year);

        /// <summary>
        /// Repository Interface for RefreshDetail,Refresh the invoice Detail
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <param name="eventType">Property that changed</param>
        /// <returns>BaseInvoiceDetail model</returns>
        BaseInvoice RefreshDetail(BaseInvoiceDetail model, string eventType);

        /// <summary>
        /// Repository Interface for ChangeVendor,Changes Vendor
        /// </summary>
        /// <param name="id">Vendor Number</param>
        /// <returns>THeader model</returns>
        THeader ChangeVendor(string id);

        /// <summary>
        /// Repository Interface for SetValue,To set the changed value and get the model
        /// </summary>
        /// <param name="value">Changed value</param>
        /// <param name="property">Property that changed</param>
        /// <returns>THeader value</returns>
        THeader RefreshHeader(string value, string property);

        /// <summary>
        /// Repository Interface for UpdateTaxCalculateType,Updates the Tax tab when the dropdowns in the UI is changed
        /// </summary>
        /// <param name="model">Invoices</param>
        /// <returns>THeader model</returns>
        THeader UpdateTaxCalculateType(THeader model);

        /// <summary>
        /// Repository Interface for TaxRefresh, Updates the Tax tab Calculate or Distribute Button is clicked. 
        /// </summary>
        /// <param name="processType">Type of Process the header should Perform</param>
        /// <returns>Invoices model</returns>
        THeader TaxRefresh(int processType);

        /// <summary>
        /// Creates the distribution codes based on distribution set chosen. 
        /// </summary>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <returns>THeader model</returns>
        THeader CreateDistribution(string documentTotalIncludingTax, string distributionSetAmount);

        /// <summary>
        /// Sets TaxGroupAuthority model to proper Header entity
        /// </summary>
        /// <param name="model">TaxGroupAuthority model</param>
        /// <param name="isDetailTaxData">if detail tax data is passed</param>
        /// <returns>THeader model</returns>
        THeader SetTaxGroupAuthority(TaxGroupAuthority model, bool isDetailTaxData);

        /// <summary>
        /// Get Tax Authorities based on tax group 
        /// </summary>
        /// <param name="id">Tax Group</param>
        /// <returns>Enumerable Response of TaxGroupAuthority</returns>
        EnumerableResponse<TaxGroupAuthority> GetTaxAuthorities(string id);

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail</param>
        /// <returns>Enumerable Response of TaxGroupAuthority</returns>
        EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(BaseInvoiceDetail model);

        /// <summary>
        /// On change of Document Type returns updated header model
        /// </summary>
        /// <param name="documentType">Document Type string</param>
        /// <returns>THeader model</returns>
        THeader ChangeDocumentType(DocumentType documentType);

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Returns the Batch and Header data</returns>
        TBatch NewDetail(int pageNumber, int pageSize, BaseInvoiceDetail currentDetail);

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TBatchKey">Batch Key</typeparam>
        /// <typeparam name="THeaderKey">Header Key</typeparam>
        /// <param name="batchKey">Batch Number</param>
        /// <param name="headerKey">Entry Number</param>
        /// <returns>TBatch model</returns>
        TBatch GetByIds<TBatchKey, THeaderKey>(TBatchKey batchKey, THeaderKey headerKey);

        /// <summary>
        /// Unlock Batch Resource when exiting the screen
        /// </summary>
        void UnlockBatchResource();
    }
}
