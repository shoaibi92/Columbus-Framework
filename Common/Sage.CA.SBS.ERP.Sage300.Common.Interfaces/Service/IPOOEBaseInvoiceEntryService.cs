/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// PO OE Base Invoice Entry Service Interface 
    /// </summary>
    /// <typeparam name="THeader">POOEBaseInvoice model</typeparam>
    /// <typeparam name="TDetail1">POOEBaseInvoiceLine model</typeparam>
    /// <typeparam name="TDetail2">POOEBaseInvoiceComments model</typeparam>
    /// <typeparam name="TDetail3">POOEBaseAdditionalCost model</typeparam>
    /// <typeparam name="TDetail4">POOEBaseInvPaymentSchedule model</typeparam>
    /// <typeparam name="TDetail5">POOEBaseInvoiceFunction model</typeparam>
    /// <typeparam name="TDetail6">POOEBaseInvoiceReciepts model</typeparam>
    /// <typeparam name="TDetail7">POOEInvBaseAddCostsSuperview model</typeparam>
    /// <typeparam name="TDetail8">BaseInvoiceOptionalField model</typeparam>
    /// <typeparam name="TDetail9">BaseInvoiceOptionalField model</typeparam>
    /// <typeparam name="TDetail10">BaseInvoiceOptionalField model</typeparam>
    /// <typeparam name="TDetail11">POOEBaseInvPstCostDistribs model</typeparam>
    /// <typeparam name="TDetail12">POOEBaseInvCostDist model</typeparam>
    /// <typeparam name="TDetail13">POOEBaseInvDistProration model</typeparam>
    /// <typeparam name="TDetail14">POOEBaseInvoiceLineLot model</typeparam>
    /// <typeparam name="TDetail15">POOEBaseInvoiceLineSerial model</typeparam>
    public interface IPOOEBaseInvoiceEntryService<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> : ISequencedHeaderDetailFiveService<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5>
        where THeader : POOEBaseInvoice, new()
        where TDetail1 : POOEBaseInvoiceLine, new()
        where TDetail2 : POOEBaseInvoiceComments, new()
        where TDetail3 : POOEBaseAdditionalCost, new()
        where TDetail4 : POOEBaseInvPaymentSchedule, new()
        where TDetail5 : POOEBaseInvoiceFunction, new()
        where TDetail6 : POOEBaseInvoiceReciepts, new()
        where TDetail7 : POOEInvBaseAddCostsSuperview, new()
        where TDetail8 : BaseInvoiceOptionalField, new()
        where TDetail9 : BaseInvoiceOptionalField, new()
        where TDetail10 : BaseInvoiceOptionalField, new()
        where TDetail11 : POOEBaseInvPstCostDistribs, new()
        where TDetail12 : POOEBaseInvCostDist, new()
        where TDetail13 : POOEBaseInvDistProration, new()
        where TDetail14 : POOEBaseInvoiceLineLot, new()
        where TDetail15 : POOEBaseInvoiceLineSerial, new()
    {
        /// <summary>
        /// Gets Empty Data on Load of screen
        /// </summary>
        /// <returns>THeader model</returns>
        THeader GetEmptyData();

        /// <summary>
        /// Service Interface for GetOptionalField,Gets the Optional Field data
        /// </summary>
        /// <param name="pageNumber"> Current PageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="isDetailOptField">if detail optional field</param>
        /// <returns>Enumerable Response of  BaseInvoiceOptionalField model</returns>
        EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize, bool isDetailOptField);

        /// <summary>
        /// Service Interface for SaveOptionalFields,save optional fields
        /// </summary>
        /// <param name="optionalFields">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">if detail optional feild</param>
        /// <returns>Boolean value</returns>
        bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields, bool isDetailOptionalField);

        /// <summary>
        /// Check whether the optional field exists
        /// </summary>
        /// <returns>Boolean value</returns>
        bool IsOptionalFieldExists(string optionalField, bool isDetailOptionalField);

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TInvoiceKey">Type of InvoiceKey</typeparam>
        /// <typeparam name="TInvoiceSequenceKey">Type of Invoice Sequence key</typeparam>
        /// <param name="invoiceKey">Invoice Number</param>
        /// <param name="invoiceSequenceKey">Invoice Squence key</param>
        /// <returns>THeader model</returns>
        THeader GetByIds<TInvoiceSequenceKey, TInvoiceKey>(TInvoiceSequenceKey invoiceSequenceKey, TInvoiceKey invoiceKey);

        /// <summary>
        /// Refreshes the data on change of value 
        /// </summary>
        /// <param name="value">New Value</param>
        /// <param name="property">Property that was changed</param>
        /// <returns>THeader</returns>
        THeader RefreshHeader(string value, string property);

        /// <summary>
        /// Post Invoice
        /// </summary>
        void Post(THeader model);

        /// <summary>
        /// Gets Paged Data for Additional Cost
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>EnumerableResponse of TDetail7 </returns>
        EnumerableResponse<POOEInvBaseAddCostsSuperview> GetAdditionalCost(int currentPageNumber, int pageSize, Expression<Func<POOEInvBaseAddCostsSuperview, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for Multiple Receipts
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>EnumerableResponse of TDetail6 model</returns>
        EnumerableResponse<TDetail6> GetMultipleReceipts(int currentPageNumber, int pageSize, Expression<Func<TDetail6, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// On Tab select performs action based on last tab selected
        /// </summary>
        /// <param name="previousTab">Last Tab selected</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        THeader TabSelect(int previousTab);

        /// <summary>
        /// This calculates tax when button is pressed in UI
        /// </summary>
        /// <param name="calculateTaxWithoutPending">To calculate tax without pending amount.Default value is false</param>
        /// <returns>THeader model</returns>
        THeader CalculateTax(bool calculateTaxWithoutPending = false);

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
        /// Updates the Terms Payment schedule
        /// </summary>
        /// <param name="model">TDetail4 model</param>
        /// <returns>TDetail4 Model</returns>
        TDetail4 UpdateTermsPaymentSchedule(TDetail4 model);

        /// <summary>
        /// Updates the receipts grid when the when user changes from one row to another.
        /// </summary>
        /// <param name="model">TDetail6 model</param>
        /// <returns>return TDetail6 model</returns>
        TDetail6 InsertMultipleReceipts(TDetail6 model);

        /// <summary>
        /// Derives Rates
        /// </summary>
        /// <returns>returns decimal property</returns>
        decimal DeriveRate();

        /// <summary>
        /// Service Interface for RefreshDetail,Refresh the invoice Detail
        /// </summary>
        /// <param name="model"> TDetail1 model</param>
        /// <param name="eventType">Property that got changed</param>
        /// <returns>THeader model</returns>
        THeader RefreshDetail(TDetail1 model, string eventType);

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details">List of POOEBaseInvoiceLine</param>
        /// <returns>THeader model</returns>
        THeader SaveDetails(IEnumerable<POOEBaseInvoiceLine> details);

        /// <summary>
        /// Save Receipts
        /// </summary>
        /// <param name="receipts">List of POOEBaseInvoiceLine</param>
        /// <returns>THeader model</returns>
        THeader SaveMultiReceipts(IEnumerable<POOEBaseInvoiceReciepts> receipts);

        /// <summary>
        /// Save for Comments
        /// </summary>
        /// <param name="comments">List of POOEBaseInvoiceComments</param>
        /// <returns>THeader model</returns>
        THeader SaveComments(IEnumerable<POOEBaseInvoiceComments> comments);

        /// <summary>
        /// Service Interface for NewDetail,Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>returns THeader model</returns>
        POOEBaseInvoiceReciepts NewInvoiceReceipt(int pageNumber, int pageSize, POOEBaseInvoiceReciepts currentDetail);

        /// <summary>
        /// Multiple Receipts process
        /// </summary>
        THeader MultiReceipts();

        /// <summary>
        /// Refreshes Invoice model. This only returns the data not set any thing
        /// </summary>
        /// <returns>THeader model</returns>
        THeader RefreshInvoice();

        /// <summary>
        /// Gets the purchase order line based on line number.
        /// </summary>
        /// <param name="sequenceKey">PO Sequence Key</param>
        /// <param name="lineNumber">Line Number</param>
        /// <param name="eventType">Event Type</param>
        /// <returns>Line Detail</returns>
        POOEInvBaseAddCostsSuperview GetAdditionalRefreshedLineDetail(decimal sequenceKey, decimal lineNumber, int eventType);

        /// <summary>
        /// Insert/Update Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction model</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        POOEBaseInvoiceComments SaveCommentInstruction(POOEBaseInvoiceComments model, string comment, string lineType);

        /// <summary>
        /// Gets the Comment Instruction
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of Comment Instruction</returns>
        EnumerableResponse<POOEBaseInvoiceComments> GetCommentInstruction(int pageNumber, int pageSize,
            Expression<Func<POOEBaseInvoiceComments, bool>> filter = null, OrderBy orderBy = null);

        #region Taxes

        /// <summary>
        /// Service Interface for GetDetailTaxes,Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">POOEBaseInvoiceLine model</param>
        /// <returns>returns EnumerableRespomse of TaxGroupAuthority model</returns>
        EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(TDetail1 model);

        /// <summary>
        /// Set value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>Receipt</returns>
        THeader SetTaxesValue(string property, string fieldValue);

        /// <summary>
        /// Set value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>Receipt</returns>
        TDetail1 SetDetailTaxesValue(string property, string fieldValue);

        #endregion
    }
}
