/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base.Statefull
{
    /// <summary>
    /// PO OE Base Invoice Entry Base Service
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
    /// <typeparam name="TService">IPOOEBaseInvoiceEntryRepository interface</typeparam>
    public abstract class POOEBaseInvEntryEntityService<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15, TService> : SequencedHeaderDetailFiveService<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TService>, IPOOEBaseInvoiceEntryService
                <THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9,
                    TDetail10, TDetail11, TDetail12, TDetail13, TDetail14, TDetail15>
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
        where TService :
            IPOOEBaseInvoiceEntryRepository
                <THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9,
                    TDetail10, TDetail11, TDetail12, TDetail13, TDetail14, TDetail15>
    {
        #region Constructor

        /// <summary>
        /// Constructor for POOEBaseInvEntryEntityService
        /// </summary>
        /// <param name="context">Context</param>
        protected POOEBaseInvEntryEntityService(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a empty header data on load of page
        /// </summary>
        /// <returns>Header Model</returns>
        public virtual THeader GetEmptyData()
        {
            var repository = Resolve<TService>();
            return repository.GetEmptyData();
        }

        /// <summary>
        /// Gets the Header details by ID
        /// </summary>
        /// <typeparam name="TInvoiceKey">Type of InvoiceKey</typeparam>
        /// <typeparam name="TInvoiceSequenceKey">Type of Invoice Sequence key</typeparam>
        /// <param name="invoiceKey">Invoice Number</param>
        /// <param name="invoiceSequenceKey">Invoice Squence key</param>
        /// <returns>THeader model</returns>
        public virtual THeader GetByIds<TInvoiceSequenceKey, TInvoiceKey>(TInvoiceSequenceKey invoiceSequenceKey, TInvoiceKey invoiceKey)
        {
            var repository = Resolve<TService>();
            return repository.GetByIds(invoiceSequenceKey, invoiceKey);
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
            var repository = Resolve<TService>();
            return repository.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
        }

        /// <summary>
        /// Save Optional Fields
        /// </summary>
        /// <param name="optionalFields">List of TOptionalField</param>
        /// <param name="isDetailOptionalField">If detail optional field</param>
        /// <returns>Boolean value</returns>
        public virtual bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields, bool isDetailOptionalField)
        {
            var repository = Resolve<TService>();
            return repository.SaveOptionalFields(optionalFields, isDetailOptionalField);
        }

        /// <summary>
        /// Refreshes the data on change of value 
        /// </summary>
        /// <param name="value">New Value</param>
        /// <param name="property">Property that was changed</param>
        /// <returns>THeader</returns>
        public virtual THeader RefreshHeader(string value, string property)
        {
            var repository = Resolve<TService>();
            return repository.RefreshHeader(value, property);
        }

        /// <summary>
        /// Post invoice
        /// </summary>
        public virtual void Post(THeader model)
        {
            var repository = Resolve<TService>();
            repository.Post(model);
        }

        /// <summary>
        /// Retrieve Additional Cost records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<POOEInvBaseAddCostsSuperview> GetAdditionalCost(int currentPageNumber, int pageSize,
            Expression<Func<POOEInvBaseAddCostsSuperview, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TService>();
            return repository.GetAdditionalCost(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// On Tab select performs action based on last tab selected
        /// </summary>
        /// <param name="previousTab">Last Tab selected</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual THeader TabSelect(int previousTab)
        {
            var repository = Resolve<TService>();
            return repository.TabSelect(previousTab);
        }

        /// <summary>
        /// This calculates tax when button is pressed in UI
        /// </summary>
        /// <param name="calculateTaxWithoutPending">To calculate tax without pending amount.Default value is false</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual THeader CalculateTax(bool calculateTaxWithoutPending = false)
        {
            var repository = Resolve<TService>();
            return repository.CalculateTax(calculateTaxWithoutPending);
        }

        /// <summary>
        /// Updates the Optional Field on Optional Field Entry
        /// </summary>
        /// <param name="optionalField">TOptionalField model</param>
        /// <returns>TOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TService>();
            return repository.SetOptionalField(optionalField);
        }

        /// <summary>
        /// Updates the Optional Field Value on Optional Field Value Entry
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField)
        {
            var repository = Resolve<TService>();
            return repository.SetOptionalFieldValue(optionalField);
        }

        /// <summary>
        /// Check whether the optional field exists
        /// </summary>
        /// <returns>Boolean value</returns>
        public virtual bool IsOptionalFieldExists(string optionalField, bool isDetailOptionalField)
        {
            var repository = Resolve<TService>();
            return repository.IsOptionalFieldExists(optionalField, isDetailOptionalField);
        }
        /// <summary>
        /// Updates the Terms Payment schedule
        /// </summary>
        /// <param name="model">Invoices</param>
        /// <returns>TDetail4 Model</returns>
        public virtual TDetail4 UpdateTermsPaymentSchedule(TDetail4 model)
        {
            var repository = Resolve<TService>();
            return repository.UpdateTermsPaymentSchedule(model);
        }

        /// <summary>
        /// Updates the receipts grid when the when user changes from one row to another.
        /// </summary>
        /// <param name="model">Receipts model</param>
        /// <returns>return TDetail6 model</returns>
        public virtual TDetail6 InsertMultipleReceipts(TDetail6 model)
        {
            var repository = Resolve<TService>();
            return repository.InsertMultipleReceipts(model);
        }

        /// <summary>
        /// Service Interface for RefreshDetail,Refresh the invoice Detail
        /// </summary>
        /// <param name="model"> POOEBaseInvoiceLine model</param>
        /// <param name="eventType">Field changed</param>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshDetail(TDetail1 model, string eventType)
        {
            var repository = Resolve<TService>();
            return repository.RefreshDetail(model, eventType);
        }

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details">List of POOEBaseInvoiceLine</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveDetails(IEnumerable<POOEBaseInvoiceLine> details)
        {
            var repository = Resolve<TService>();
            return repository.SaveDetails(details);
        }

        /// <summary>
        /// Save Receipts
        /// </summary>
        /// <param name="receipts">List of POOEBaseInvoiceLine</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveMultiReceipts(IEnumerable<POOEBaseInvoiceReciepts> receipts)
        {
            var repository = Resolve<TService>();
            return repository.SaveMultiReceipts(receipts);
        }

        /// <summary>
        /// Gets optional field data
        /// </summary>
        /// <param name="pageNumber">Current PageNumber</param>
        /// <param name="pageSize"> PageSize</param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <returns>Enumerable Response of TDetail6 model</returns>
        public virtual EnumerableResponse<TDetail6> GetMultipleReceipts(int pageNumber, int pageSize, Expression<Func<TDetail6, Boolean>> filter = null,
            OrderBy orderBy = null)
        {
            var repository = Resolve<TService>();
            return repository.GetMultipleReceipts(pageNumber, pageSize);
        }

        /// <summary>
        /// Service Interface for NewDetail,Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>returns THeader model</returns>
        public virtual POOEBaseInvoiceReciepts NewInvoiceReceipt(int pageNumber, int pageSize, POOEBaseInvoiceReciepts currentDetail)
        {
            var repository = Resolve<TService>();
            return repository.NewInvoiceReceipt(pageNumber, pageSize, currentDetail);
        }

        /// <summary>
        /// Multiple Receipts process
        /// </summary>
        public virtual THeader MultiReceipts()
        {
            var repository = Resolve<TService>();
            return repository.MultiReceipts();
        }

        /// <summary>
        /// Refreshes Invoice model. This only returns the data not set any thing
        /// </summary>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshInvoice()
        {
            var repository = Resolve<TService>();
            return repository.RefreshInvoice();
        }

        /// <summary>
        /// Gets the purchase order line based on line number.
        /// </summary>
        /// <param name="sequenceKey">PO Sequence Key</param>
        /// <param name="lineNumber">Line Number</param>
        /// <param name="eventType">Event Type</param>
        /// <returns>Line Detail</returns>
        public virtual POOEInvBaseAddCostsSuperview GetAdditionalRefreshedLineDetail(decimal sequenceKey, decimal lineNumber, int eventType)
        {
            var repository = Resolve<TService>();
            return repository.GetAdditionalRefreshedLineDetail(sequenceKey, lineNumber,eventType);
        }

        /// <summary>
        /// Save for Comments
        /// </summary>
        /// <param name="comments">List of POOEBaseInvoiceComments</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveComments(IEnumerable<POOEBaseInvoiceComments> comments)
        {
            var repository = Resolve<TService>();
            return repository.SaveComments(comments);
        }

        /// <summary>
        /// Insert/Update Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction model</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        public virtual POOEBaseInvoiceComments SaveCommentInstruction(POOEBaseInvoiceComments model, string comment, string lineType)
        {
            var repository = Resolve<TService>();
            return repository.SaveCommentInstruction(model, comment, lineType);
        }

        /// <summary>
        /// Gets the Comment Instruction
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of Comment Instruction</returns>
        public virtual EnumerableResponse<POOEBaseInvoiceComments> GetCommentInstruction(int pageNumber, int pageSize,
            Expression<Func<POOEBaseInvoiceComments, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TService>();
            return repository.GetCommentInstruction(pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Derives Rates
        /// </summary>
        /// <returns>returns decimal property</returns>
        public virtual decimal DeriveRate()
        {
            var repository = Resolve<TService>();
            return repository.DeriveRate();
        }

        #region Taxes

        /// <summary>
        /// Service Interface for GetDetailTaxes,Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">POOEBaseInvoiceLine model</param>
        /// <returns>returns EnumerableRespomse of TaxGroupAuthority model</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(TDetail1 model)
        {
            var repository = Resolve<TService>();
            return repository.GetDetailTaxes(model);
        }

        /// <summary>
        /// Set value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>Receipt</returns>
        public virtual THeader SetTaxesValue(string property, string fieldValue)
        {
            var repository = Resolve<TService>();
            return repository.SetTaxesValue(property, fieldValue);
        }

        /// <summary>
        /// Set value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>Receipt</returns>
        public virtual TDetail1 SetDetailTaxesValue(string property, string fieldValue)
        {
            var repository = Resolve<TService>();
            return repository.SetDetailTaxesValue(property, fieldValue);
        }

        #endregion

        #endregion
    }
}
