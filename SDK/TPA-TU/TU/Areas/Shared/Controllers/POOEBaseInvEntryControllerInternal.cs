/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Type = Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry.Type;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers
{
    /// <summary>
    /// PO OE Base Invoice Entry Controller
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
    /// <typeparam name="TService">IPOOEBaseInvoiceEntryService service</typeparam>
    public class POOEBaseInvEntryControllerInternal<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6,
        TDetail7, TDetail8, TDetail9, TDetail10, TDetail11, TDetail12, TDetail13, TDetail14, TDetail15, TService> :
            BaseExportImportControllerInternal<THeader, TService>
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
            IPOOEBaseInvoiceEntryService
                <THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9,
                    TDetail10, TDetail11, TDetail12, TDetail13, TDetail14, TDetail15>
    {
        #region Private Constants
        /// <summary>
        /// Regular Expression Value
        /// </summary>
        private const string RegexValue = "[^0-9]";
        #endregion

        #region Constructor

        /// <summary>
        /// Invoice Controller Internal - Default constructor
        /// </summary>
        /// <param name="context"></param>
        public POOEBaseInvEntryControllerInternal(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the invoice entry data based on invoice number
        /// </summary>
        /// <param name="invoiceSequence">Invoice Sequence Number</param>
        /// <param name="invoiceNumber">Invoice Number</param>
        /// <returns>Invoice Entry Model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> Get(string invoiceSequence, string invoiceNumber)
        {
            var invoiceEntryData = Service.GetByIds(invoiceSequence, invoiceNumber);
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceEntryData,
            };
        }

        /// <summary>
        /// Gets optional fields
        /// </summary>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <param name="index">Index</param>
        /// <param name="isDetailOptField">if detail optional field</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize, int index,
            THeader model, bool isDetailOptField)
        {
            if (model == null)
            { return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField); }
            var optionalField = model.OptionalFieldList.Items.ToList();

            if (!optionalField.Any(x => x.HasChanged) && !optionalField.Any(x => x.IsNewLine) &&
                !optionalField.Any(x => x.IsDeleted) && index < 0)
            {
                return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
            }

            if (optionalField.Any(x => x.OptionalField != null))
            {
                SaveOptionalFields(optionalField, isDetailOptField);
            }

            var optionalFields = Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
            if (index > 0)
            {
                var row = new BaseInvoiceOptionalField();
                var list = optionalFields.Items.ToList();
                var item = optionalField[0];
                row.IsNewLine = true;
                row.InvoiceSequenceKey = item.InvoiceSequenceKey;
                row.LineKey = Convert.ToInt32(DateUtil.GetTicks() / TimeSpan.TicksPerHour);
                list.Insert(index % pageSize, row);
                optionalFields.Items = list.Take(pageSize);
                optionalFields.TotalResultsCount = optionalFields.TotalResultsCount + 1;
            }
            return optionalFields;
        }

        /// <summary>
        /// Gets details optional fields
        /// </summary>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="index">Index</param>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetDetailOptionalFields(int pageNumber, int pageSize, int index,
            List<BaseInvoiceOptionalField> model)
        {
            if (model == null)
            { return Service.GetOptionalFields(pageNumber, pageSize, true); }
            var optionalField = model;

            if (!optionalField.Any(x => x.HasChanged) && !optionalField.Any(x => x.IsNewLine) &&
                !optionalField.Any(x => x.IsDeleted) && index < 0)
            {
                return Service.GetOptionalFields(pageNumber, pageSize, true);
            }

            if (optionalField.Any(x => x.OptionalField != null))
            {
                SaveOptionalFields(optionalField, true);
            }

            var optionalFields = Service.GetOptionalFields(pageNumber, pageSize, true);
            if (index > 0)
            {
                var row = new BaseInvoiceOptionalField();
                var list = optionalFields.Items.ToList();
                var item = optionalField[0];
                row.IsNewLine = true;
                row.InvoiceSequenceKey = item.InvoiceSequenceKey;
                row.LineKey = Convert.ToInt32(DateUtil.GetTicks() / TimeSpan.TicksPerHour);
                list.Insert(index % pageSize, row);
                optionalFields.Items = list.Take(pageSize);
                optionalFields.TotalResultsCount = optionalFields.TotalResultsCount + 1;
            }
            return optionalFields;
        }

        /// <summary>
        /// Save optional field
        /// </summary>
        /// <param name="optionalFields">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">if detail optiona field</param>
        /// <returns>returns list of BaseInvoiceOptionalField model</returns>
        public virtual List<BaseInvoiceOptionalField> SaveOptionalFields(List<BaseInvoiceOptionalField> optionalFields,
            bool isDetailOptionalField)
        {
            if (optionalFields != null)
            {
                foreach (var model in optionalFields.Where(model => model.Type == Type.Date))
                {
                    SetOptionalFieldOffset(model);
                }
            }

            var savedOptionalFields = Service.SaveOptionalFields(optionalFields, isDetailOptionalField);
            if (!savedOptionalFields) { return optionalFields; }
            if (optionalFields == null) { return null; }
            foreach (var invoiceEntryDetailOptionalFields in optionalFields)
            {
                invoiceEntryDetailOptionalFields.IsNewLine = false;
                invoiceEntryDetailOptionalFields.HasChanged = false;
                invoiceEntryDetailOptionalFields.IsDeleted = false;
            }
            return optionalFields;
        }

        /// <summary>
        /// Check whether the optional field exists
        /// </summary>
        /// <returns>Boolean value</returns>
        public virtual bool IsOptionalFieldExists(string optionalField, bool isDetailOptionalField)
        {
            return Service.IsOptionalFieldExists(optionalField, isDetailOptionalField);
        }

        /// <summary>
        /// Delete Header Optional Field  
        /// </summary>
        /// <param name="model">Enumerable Response of Header Optional Field</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="isDetailOptionalField">Is Detail OptionalField</param>
        /// <returns>Enumerable Response of Header Optional Field</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> DeleteOptionalField(EnumerableResponse<BaseInvoiceOptionalField> model, int pageNumber, int pageSize, bool isDetailOptionalField)
        {
            if (model.Items != null)
            {
                foreach (var optionalField in model.Items.Where(optionalField => optionalField.Type == Type.Date))
                {
                    SetOptionalFieldOffset(optionalField);
                }
            }
            Service.SaveOptionalFields(model.Items, isDetailOptionalField);
            var header = new THeader
            {
                OptionalFieldList =
                    new EnumerableResponse<BaseInvoiceOptionalField>
                    {
                        Items = model.Items,
                        TotalResultsCount = model.TotalResultsCount
                    }
            };
            var pagedDetail = GetOptionalFields(pageNumber - 1, pageSize, -1, header, isDetailOptionalField);
            foreach (var optionalField in pagedDetail.Items)
            {
                optionalField.HasChanged = false;
                optionalField.IsDeleted = false;
                optionalField.IsNewLine = false;
            }
            var totalResultsCount = pagedDetail.Items.Count();
            var returnDetail = new EnumerableResponse<BaseInvoiceOptionalField>
            {
                Items = pagedDetail.Items,
                TotalResultsCount = totalResultsCount
            };
            return returnDetail;
        }

        /// <summary>
        /// Refreshes the data on change of value 
        /// </summary>
        /// <param name="value">New Value</param>
        /// <param name="property">Property that was changed</param>
        /// <returns>THeader</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> RefreshHeader(string value, string property)
        {
            if (property == InvoiceEntryConstants.DateFields.DiscountDate || property == InvoiceEntryConstants.DateFields.InvoiceDate ||
                property == InvoiceEntryConstants.DateFields.PostingDate || property == InvoiceEntryConstants.DateFields.RateDate ||
                property == InvoiceEntryConstants.DateFields.BatchDate || property == InvoiceEntryConstants.DateFields.AsofDate ||
                property == InvoiceEntryConstants.DateFields.DueDate || property == InvoiceEntryConstants.DateFields.TaxReportingRateDate)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    value = Convert.ToDateTime(value).ToShortDateString();
                }
            }
            // This is checked here because if invoice process fails we have to set the usermessage to false manually so 
            // invoice can be loaded correctly
            var invoiceEntry = Service.RefreshHeader(value, property);
            if (invoiceEntry.InvoiceSequenceKey != 0)
            {
                return new POOEBaseInvoiceViewModel<THeader>
                {
                    Data = invoiceEntry,
                    UserMessage = new UserMessage(invoiceEntry)
                };
            }
            var invoiceEntryViewModel = new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceEntry,
                UserMessage = new UserMessage(invoiceEntry)
            };
            invoiceEntryViewModel.UserMessage.IsSuccess = false;
            return invoiceEntryViewModel;
        }

        /// <summary>
        /// Post Invoice
        /// </summary>
        /// <param name="model">Invoice Numbers</param>
        /// <returns> New POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> Post(THeader model)
        {
            Service.Post(model);
            var invoiceEntry = Service.GetEmptyData();
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceEntry,
                UserMessage = new UserMessage(invoiceEntry, string.Format(InvoiceResx.PostDoneINVNP, model.InvoiceNumber))
            };
        }

        /// <summary>
        /// Gets currency code data based on currency code
        /// </summary>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns>CurrencyCode model</returns>
        /// This method is being used in Invoice Entry Controller Index method.
        public virtual Currency GetCurrencyDetails(string currencyCode)
        {
            var currencyCodeService =
                Context.Container.Resolve<ICommonService>(new ParameterOverride("context", Context));
            return currencyCodeService.GetCurrency(currencyCode);
        }

        /// <summary>
        /// On Tab select performs action based on last tab selected
        /// </summary>
        /// <param name="previousTab">Last Tab selected</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> TabSelect(int previousTab)
        {
            var invoiceEntry = Service.TabSelect(previousTab);
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceEntry,
                UserMessage = new UserMessage(invoiceEntry),
            };
        }

        /// <summary>
        /// This calculates tax when button is pressed in UI
        /// </summary>
        /// <param name="calculateTaxWithoutPending">To calculate tax without pending amount.Default value is false</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> CalculateTax(bool calculateTaxWithoutPending = false)
        {
            var invoiceEntry = Service.CalculateTax(calculateTaxWithoutPending);
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceEntry,
                UserMessage = new UserMessage(invoiceEntry),
            };
        }

        #region Taxes

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <param name="id">TaxGroup</param>
        /// <returns>returns EnumerableResponse of TaxGroupAuthority</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> GetDetailTaxes(TDetail1 model, string id)
        {
            if (model == null || string.IsNullOrEmpty(id))
            {
                return new POOEBaseInvoiceViewModel<THeader>();
            }
            var detailTaxes = Service.GetDetailTaxes(model);
            return new POOEBaseInvoiceViewModel<THeader> { ItemTaxes = detailTaxes };
        }

        /// <summary>
        ///  Set Value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="value">Value</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> SetDetailTaxesValue(string property, string value)
        {
            var detail = Service.SetDetailTaxesValue(property, value);
            return new POOEBaseInvoiceViewModel<THeader> { ItemTaxes = Service.GetDetailTaxes(detail) };
        }

        /// <summary>
        /// Get Receipt Item Tax Detail
        /// </summary>
        /// <param name="model">THeader model</param>
        /// <param name="id">Property changed</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> GetVendorTaxDetail(THeader model, string id)
        {
            var viewModel = new POOEBaseInvoiceViewModel<THeader>();
            if (model == null) { return viewModel; }
            viewModel.VendorTaxes = GetVendorTaxesDetail(model);
            return viewModel;
        }

        /// <summary>
        ///  Set Value for Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="value">Value</param>
        /// <returns>THeader model</returns>
        public virtual THeader SetTaxesValue(string property, string value)
        {
            return Service.SetTaxesValue(property, value);
        }

        #endregion

        /// <summary>
        /// Set Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>returns BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField)
        {
            var updatedOptionalField = Service.SetOptionalField(optionalField);
            updatedOptionalField.IsNewLine = optionalField.IsNewLine;
            updatedOptionalField.IsDetailOptionalField = optionalField.IsDetailOptionalField;
            return updatedOptionalField;
        }

        /// <summary>
        /// Set Optional Field Value
        /// </summary>
        /// <param name="model">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField model)
        {
            if (model.Type == Type.Date)
            {
                SetOptionalFieldOffset(model);
            }
            var updatedOptionalField = Service.SetOptionalFieldValue(model);
            updatedOptionalField.IsNewLine = model.IsNewLine;
            updatedOptionalField.IsDetailOptionalField = model.IsDetailOptionalField;
            return updatedOptionalField;
        }

        /// <summary>
        /// Gets the Payment schedule related to Invoice Entry 
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>returns EnumerableResponse of TDetail4 model</returns>
        public virtual EnumerableResponse<TDetail4> GetPaymentSchedules(int pageNumber, int pageSize)
        {
            //This calls GetDetail$ of base has it will return the payment schedule data
            //that we need to bind from common method
            return Service.GetDetail4(pageNumber, pageSize);
        }

        /// <summary>
        /// Updates the Terms Payment schedule
        /// </summary>
        /// <param name="model">Invoices</param>
        /// <returns>TDetail4 Model</returns>
        public virtual TDetail4 UpdateTermsPaymentSchedule(TDetail4 model)
        {
            return Service.UpdateTermsPaymentSchedule(model);
        }

        /// <summary>
        /// Updates the Terms Payment schedules
        /// </summary>
        /// <param name="invoicePaymentSchedules">LIst of InvoicePaymentSchedules</param>
        public virtual void SaveTermsDetails(List<TDetail4> invoicePaymentSchedules)
        {
            foreach (var payment in invoicePaymentSchedules)
            {
                Service.UpdateTermsPaymentSchedule(payment);
            }
        }


        /// <summary>
        /// Updates the receipts grid when the when user changes from one row to another.
        /// </summary>
        /// <param name="model">Receipts model</param>
        /// <returns>return TDetail6 model</returns>
        public virtual TDetail6 InsertMultipleReceipts(TDetail6 model)
        {
            return Service.InsertMultipleReceipts(model);
        }

        /// <summary>
        /// Derives Rates
        /// </summary>
        /// <returns>returns JsonNetResult of decimal property</returns>
        public virtual THeader DeriveRate()
        {
            Service.DeriveRate();
            return Service.RefreshInvoice();
        }

        /// <summary>
        /// Refreshes the detail when the data is changed.
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <param name="eventType">Type of event</param>
        /// <returns>returns POOEBaseInvoiceViewModel</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> RefreshDetail(TDetail1 detail, string eventType)
        {
            var refreshDetail = Service.RefreshDetail(detail, eventType);
            var baseInvoiceDetail = refreshDetail.InvoiceLine.Items.FirstOrDefault();
            if (baseInvoiceDetail != null)
            { baseInvoiceDetail.IsNewLine = detail.IsNewLine; }
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = refreshDetail,
                //Below we are passing only detail model to usermessage because in javascript it expects the
                //warning messages to be in UserMessage directly.
                UserMessage = new UserMessage(baseInvoiceDetail)
            };
        }

        /// <summary>
        /// Set Detail to current detail
        /// </summary>
        /// <param name="currentDetail"> Current Selected Detail</param>
        /// <returns>returns TBatch model</returns>
        public virtual THeader SetDetail(TDetail1 currentDetail)
        {
            return Service.SetDetail(currentDetail);
        }

        /// <summary>
        /// Get Multiple Receipts based on page
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="model">Model</param>
        /// <param name="filters">Filters</param>
        /// <returns>returns Enumerable response of TDetail</returns>
        public virtual EnumerableResponse<TDetail6> GetMultipleReceipts(int pageNumber, int pageSize, THeader model = null,
            IList<IList<Filter>> filters = null)
        {

            var invoiceMultiReceipts = Service.GetMultipleReceipts(pageNumber, pageSize);
            //var invoiceDetails = new EnumerableResponse<TDetail1>();
            var lineNumber = (pageSize * pageNumber) + 1;
            foreach (var invoiceDetail in invoiceMultiReceipts.Items)
            {
                invoiceDetail.DisplayIndex = lineNumber++;
            }
            return invoiceMultiReceipts;
        }

        /// <summary>
        /// Refreshes the model and Creates Invoice Receipts
        /// </summary>
        /// <param name="model">Invoice Batch</param>
        /// <param name="index">Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="pageNumber">Page Number</param>
        /// <returns>THeader model</returns>
        public virtual THeader CreateMultiReceiptLine(THeader model, int index, int pageSize, int pageNumber)
        {

            var details = model.MultipleReceiptsList.Items as IList<POOEBaseInvoiceReciepts> ??
                          model.MultipleReceiptsList.Items.ToList();
            var hasDetails = details.Count > 0 && details.All(receipts => receipts.LineNumber != 0);
            POOEBaseInvoiceReciepts data;
            var invoiceReceipts = new List<POOEBaseInvoiceReciepts>();

            //This method maps the model.
            if (model.HasChanged)
            {
                Service.Refresh(model);
            }

            var lineNumber = (pageSize * pageNumber) + 1;
            var currentRow = hasDetails ? details.Count > index ? details.ElementAt(index) : details.Last() : null;

            if (hasDetails)
            {
                //If in the grid you are trying to add the new detail at last line. This moves the new line to next page.
                if (pageSize > (index + 1))
                {
                    data = CreateMultiReceiptLine(pageSize, pageNumber, currentRow);
                    if (details.Count > index)
                    {
                        details[index].IsNewLine = false;
                    }
                    else
                    {
                        details[details.Count].IsNewLine = false;
                    }
                    //Any new line saves the detail
                    if (details.Any(invoiceDetail => invoiceDetail.IsNewLine))
                    {
                        // Service.SaveDetails(details);
                    }
                    invoiceReceipts = model.MultipleReceiptsList.Items.Take(pageSize - 1).ToList();
                    foreach (var receipts in invoiceReceipts)
                    {
                        receipts.HasChanged = false;
                    }
                    invoiceReceipts.Insert(index + 1, data);
                    foreach (var invoiceEntryDetail in invoiceReceipts)
                    {
                        invoiceEntryDetail.DisplayIndex = lineNumber;
                        lineNumber++;
                    }
                    model.MultipleReceiptsList.Items = invoiceReceipts;
                    model.MultipleReceiptsList.TotalResultsCount = model.MultipleReceiptsList.TotalResultsCount + 1;
                    return model;
                }

                // If page size is less than pagesize
                if (details.Any(invoiceDetail => invoiceDetail.HasChanged))
                {
                    // if (Service.SaveDetails(details))
                    currentRow.IsNewLine = false;
                }
                var pagedDetails = GetMultipleReceipts(pageNumber == 0 ? pageNumber : pageNumber - 1, pageSize);
                var totalRecords = pagedDetails.TotalResultsCount;
                data = CreateMultiReceiptLine(pageSize, pageNumber, currentRow);
                invoiceReceipts = new List<POOEBaseInvoiceReciepts>(pagedDetails.Items.ToList());
                if (pageSize != (index + 1))
                {
                    invoiceReceipts = invoiceReceipts.Take(pageSize - 1).ToList();
                    foreach (var invoiceEntryDetail in invoiceReceipts)
                    {
                        invoiceEntryDetail.HasChanged = false;
                    }
                    invoiceReceipts.Insert(0, data);
                    lineNumber = (pageSize * (pageNumber - 1)) + 1;
                }

                foreach (var invoiceEntryDetail in invoiceReceipts)
                {
                    invoiceEntryDetail.DisplayIndex = lineNumber;
                    lineNumber++;
                }
                model.MultipleReceiptsList.Items = invoiceReceipts;
                model.MultipleReceiptsList.TotalResultsCount = totalRecords + 1;
                return model;
            }

            //If adding in between the limit of grid.
            data = CreateMultiReceiptLine(pageSize, pageNumber, null);
            if (data != null)
            {
                data.DisplayIndex = invoiceReceipts.Count + 1;
                invoiceReceipts.Add(data);
            }
            model.MultipleReceiptsList.Items = invoiceReceipts;
            model.MultipleReceiptsList.TotalResultsCount++;
            return model;
        }

        /// <summary>
        /// Multiple Receipts Process
        /// </summary>
        /// <returns></returns>
        public virtual POOEBaseInvoiceViewModel<THeader> MultiReceipts()
        {
            var model = Service.MultiReceipts();
            // This is checked here because if invoice process fails we have to set the usermessage to false manually so 
            // invoice can be loaded correctly
            if (model.InvoiceSequenceKey != 0)
            {
                return new POOEBaseInvoiceViewModel<THeader>
                {
                    Data = model,
                    AmountDecimal = GetCurrencyDetails(model.Currency).Decimals
                };
            }
            var invoiceEntryViewModel = new POOEBaseInvoiceViewModel<THeader>
            {
                Data = model,
                AmountDecimal = GetCurrencyDetails(model.Currency).Decimals
            };
            invoiceEntryViewModel.UserMessage = new UserMessage(model);
            invoiceEntryViewModel.UserMessage.IsSuccess = false;
            return invoiceEntryViewModel;
        }

        /// <summary>
        /// Refreshes Invoice model. This only returns the data not set any thing
        /// </summary>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> RefreshInvoice()
        {
            var invoiceModel = Service.RefreshInvoice();
            return new POOEBaseInvoiceViewModel<THeader>
            {
                Data = invoiceModel,
                AmountDecimal = GetCurrencyDetails(invoiceModel.Currency).Decimals,
                UserMessage = new UserMessage(invoiceModel)
            };
        }

        /// <summary>
        /// Gets the purchase order line based on line number.
        /// </summary>
        /// <param name="additionalCostParameter">AdditionalCostParameter model</param>
        /// <returns>Line Detail</returns>
        public POOEBaseInvoiceViewModel<THeader> GetAdditionalRefreshedLineDetail(AdditionalCostParameter additionalCostParameter)
        {
            var poLine = Service.GetAdditionalRefreshedLineDetail(additionalCostParameter.SequenceNumber, additionalCostParameter.LineNumber, additionalCostParameter.EventType);
            if (poLine != null)
            {
                poLine.DisplayIndex = additionalCostParameter.DisplayIndex;
                poLine.HasChanged = additionalCostParameter.HasChanged;
                poLine.IsNewLine = additionalCostParameter.IsNewLine;
            }
            var header = new THeader();
            var purchaseOrderLine = new EnumerableResponse<POOEInvBaseAddCostsSuperview> { Items = new[] { poLine }, };
            header.AdditionalCostSuperView = purchaseOrderLine;
            var viewModel = new POOEBaseInvoiceViewModel<THeader>
            {
                Data = header,
                UserMessage = new UserMessage(poLine)
            };
            return viewModel;
        }
        /// <summary>
        /// Deletes additionalcost detai
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="pageNumber">Page Number.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <returns>InvoiceEntry View Model</returns>
        public virtual POOEBaseInvoiceViewModel<THeader> DeleteMultiReceipts(THeader model, int pageNumber, int pageSize)
        {
            var updatedModel = Service.SaveMultiReceipts(model.MultipleReceiptsList.Items);
            var pagedDetail = GetMultipleReceipts(pageNumber, pageSize, model);
            updatedModel.MultipleReceiptsList.Items = pagedDetail.Items;
            updatedModel.MultipleReceiptsList.TotalResultsCount = pagedDetail.TotalResultsCount;
            return new POOEBaseInvoiceViewModel<THeader> { Data = updatedModel };
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetDynamicAttributesHeader(string changeProperty = null)
        {
            var attributes = Service.GetDynamicAttributesHeader();
            switch (changeProperty)
            {
                case null:
                    return ConvertToDynamic(attributes);
                case InvoiceEntryConstants.DefaultLoad:
                    foreach (var attribute in attributes.Where(attribute => attribute.PropertyName != InvoiceEntryConstants.InvoiceNumber))
                    {
                        attribute.Disabled = true;
                    }
                    break;
                case InvoiceEntryConstants.InvoiceNumber:
                    foreach (var attribute in attributes)
                    {
                        if (attribute.PropertyName != InvoiceEntryConstants.InvoiceNumber &&
                            attribute.PropertyName != InvoiceEntryConstants.Vendor &&
                            attribute.PropertyName != InvoiceEntryConstants.ReceiptNumber)
                        {
                            attribute.Disabled = true;
                        }
                        else
                        {
                            attribute.Disabled = false;
                        }
                    }
                    break;
                case InvoiceEntryConstants.VendorNumber:
                    foreach (var attribute in attributes.Where(attribute => attribute.PropertyName != InvoiceEntryConstants.InvoiceNumber && attribute.PropertyName != InvoiceEntryConstants.Vendor
                                                                            && attribute.PropertyName != InvoiceEntryConstants.Name && attribute.PropertyName != InvoiceEntryConstants.ReceiptNumber && attribute.PropertyName != InvoiceEntryConstants.MultipleReceiptsAttribute))
                    {
                        attribute.Disabled = true;
                    }
                    break;
            }
            return ConvertToDynamic(attributes);
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetDynamicAttributesPaymentSchedule()
        {
            return ConvertToDynamic(Service.GetDynamicAttributesDetail4());
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetDynamicAttributesDetailLine()
        {
            return ConvertToDynamic(Service.GetDynamicAttributesDetail());
        }

        #endregion

        #region Comments/Instruction

        /// <summary>
        /// Gets the Details 2(Comments/Instruction)
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="model">Header</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>List of details 2(Comments/Instruction)</returns>
        public virtual EnumerableResponse<POOEBaseInvoiceComments> GetCommentInstruction(int pageNumber, int pageSize, THeader model, LineType lineType)
        {
            Expression<Func<POOEBaseInvoiceComments, bool>> filter = detail => detail.LineType == lineType;

            if (model == null)
            {
                return Service.GetCommentInstruction(pageNumber, pageSize, filter);
            }
            var comments = model.LineComments.Items.ToList();

            if (!comments.Any(x => x.HasChanged) && !comments.Any(x => x.IsNewLine) && !comments.Any(x => x.IsDeleted))
            {
                return Service.GetCommentInstruction(pageNumber, pageSize, filter);
            }

            if (comments.Any(x => x.Comment != null))
            {
                Service.SaveComments(comments);
            }

            return Service.GetCommentInstruction(pageNumber, pageSize, filter);
        }

        /// <summary>
        /// Save Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction Data</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        public virtual POOEBaseInvoiceComments SaveCommentInstruction(TDetail2 model, LineType lineType)
        {
            var commentLineType = EnumUtility.GetValue(lineType);
            return Service.SaveCommentInstruction(model, model.Comment, commentLineType);
        }

        /// <summary>
        /// Delete omment Instruction  
        /// </summary>
        /// <param name="model">Enumerable Response of Comment/Instruction</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Comments/Instruction</returns>
        public virtual EnumerableResponse<POOEBaseInvoiceComments> DeleteCommentInstruction(EnumerableResponse<TDetail2> model, int pageNumber, int pageSize)
        {
            Service.SaveDetails2(model.Items);
            var lineType = LineType.Comment;
            if (model.Items.Any())
            {
                lineType = model.Items.First().LineType;
            }

            return GetCommentInstruction(pageNumber, pageSize, null, lineType);
        }

        /// <summary>
        /// CreateCommentInstruction
        /// </summary>
        /// <param name="model">List of CreateCommentInstruction</param>
        /// <param name="index">current row</param>
        /// <param name="pageSize">current page</param>
        /// <param name="pageNumber">page number</param>
        /// <returns>List of CreateCommentInstruction</returns>
        public virtual EnumerableResponse<POOEBaseInvoiceComments> CreateCommentInstruction(List<TDetail2> model, int index, int pageSize, int pageNumber)
        {
            var hasDetails = model != null && model.Any();
            var currentRow = hasDetails ? model.Count > index ? model.ElementAt(index) : model.Last() : null;
            // Below filter is added to use the global methods than overriding everything again.
            Expression<Func<TDetail2, bool>> filter = detail => detail.LineType == LineType.Comment;
            TDetail2 newDetail;
            List<TDetail2> commentDetails;

            if (hasDetails)
            {
                if (pageSize > (index + 1))
                {
                    var resultCount = Service.GetCommentInstructionCount(filter);
                    newDetail = CreateCommentInstruction(currentRow);
                    if (newDetail != null)
                    {
                        newDetail.DisplayIndex = (int)(DateUtil.GetTicks() / TimeSpan.TicksPerMillisecond);
                        newDetail.IsNewLine = true;
                    }

                    if (model.Count > index)
                    {
                        model[index].IsNewLine = false;
                    }
                    else
                    {
                        model[model.Count].IsNewLine = false;
                    }

                    commentDetails = model.Take(pageSize - 1).ToList();
                    commentDetails.Insert(index + 1, newDetail);
                    return new EnumerableResponse<POOEBaseInvoiceComments>
                    {
                        Items = commentDetails,
                        TotalResultsCount = resultCount + 1,
                    };
                }

                var pagedDetails = Service.GetCommentInstruction(pageNumber, pageSize, filter);
                newDetail = CreateCommentInstruction(currentRow);
                if (newDetail != null)
                {
                    newDetail.DisplayIndex = (int)(DateUtil.GetTicks() / TimeSpan.TicksPerMillisecond);
                    newDetail.IsNewLine = true;
                }
                commentDetails = new List<TDetail2>(pagedDetails.Items.ToList());
                if (pageSize != (index + 1))
                {
                    commentDetails = commentDetails.Take(pageSize - 1).ToList();
                    commentDetails.Insert(0, newDetail);
                }
                return new EnumerableResponse<POOEBaseInvoiceComments>
                {
                    Items = commentDetails,
                    TotalResultsCount = pagedDetails.TotalResultsCount + 1,
                };
            }
            newDetail = CreateCommentInstruction(null);
            commentDetails = new List<TDetail2>();
            if (newDetail == null)
            {
                return new EnumerableResponse<POOEBaseInvoiceComments>
                {
                    Items = commentDetails,
                    TotalResultsCount = commentDetails.Count(),
                };
            }
            newDetail.DisplayIndex = (int)(DateUtil.GetTicks() / TimeSpan.TicksPerMillisecond);
            newDetail.IsNewLine = true;
            commentDetails.Add(newDetail);
            return new EnumerableResponse<POOEBaseInvoiceComments>
            {
                Items = commentDetails,
                TotalResultsCount = commentDetails.Count(),
            };
        }

        #endregion Comments/Instruction

        #region Private Methods

        /// <summary>
        /// Apply offset for optional fields date fields
        /// </summary>
        /// <param name="row">BaseInvoiceOptionalField model</param>
        private void SetOptionalFieldOffset(BaseInvoiceOptionalField row)
        {
            if (row == null) return;
            if (row.Type != Type.Date) return;

            row.Value = DateUtil.GetShortDate(row.Value, null, true);
        }

        /// <summary>
        /// Create invoice Entry Multiple Receipts
        /// </summary>
        /// <param name="pageSize">Page Size</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="currentRow">Current Selected Row</param>
        /// <returns> returns THeader model</returns>
        private POOEBaseInvoiceReciepts CreateMultiReceiptLine(int pageSize, int pageNumber, POOEBaseInvoiceReciepts currentRow)
        {
            var data = Service.NewInvoiceReceipt(pageNumber, pageSize, currentRow);
            data.IsNewLine = true;
            return data;
        }

        /// <summary>
        /// Create Comment/Instruction Detail
        /// </summary>
        /// <param name="currentRow">Current Row</param>
        /// <returns>New Comment/Instruction Detail</returns>
        private TDetail2 CreateCommentInstruction(TDetail2 currentRow)
        {
            return Service.NewCommentInstruction(currentRow);
        }

        #region Vendor Taxes Detail

        /// <summary>
        ///    Get the list of taxes 
        /// </summary>
        /// <returns>List</returns>
        private static EnumerableResponse<TaxGroupAuthority> GetVendorTaxesDetail(THeader invoiceEntry)
        {
            var taxGroups = new List<TaxGroupAuthority>();
            if (invoiceEntry.TaxAuthority1 != null)
            {
                var taxGroup1 = new TaxGroupAuthority
                {
                    LineNumber = 1,
                    TaxAuthority = invoiceEntry.TaxAuthority1,
                    TaxAuthorityDescription = invoiceEntry.TaxAuthority1Description,
                    TaxClass = invoiceEntry.TaxClass1,
                    TaxClassDescription = invoiceEntry.TaxClass1Description,
                    TaxBase = invoiceEntry.TaxBase1,
                    TaxAmount = invoiceEntry.TaxAmount1,
                    TaxExcluded = invoiceEntry.TaxExcluded1Sum,
                    TaxReportingAmount = invoiceEntry.TaxReportingAmount1,
                    TaxInclude = invoiceEntry.TaxIncluded1Sum,
                };

                taxGroups.Add(taxGroup1);
            }
            if (invoiceEntry.TaxAuthority2 != null)
            {
                var taxGroup2 = new TaxGroupAuthority
                {
                    LineNumber = 2,
                    TaxAuthority = invoiceEntry.TaxAuthority2,
                    TaxAuthorityDescription = invoiceEntry.TaxAuthority2Description,
                    TaxClass = invoiceEntry.TaxClass2,
                    TaxClassDescription = invoiceEntry.TaxClass2Description,
                    TaxBase = invoiceEntry.TaxBase2,
                    TaxAmount = invoiceEntry.TaxAmount2,
                    TaxExcluded = invoiceEntry.TaxExcluded2Sum,
                    TaxReportingAmount = invoiceEntry.TaxReportingAmount2,
                    TaxInclude = invoiceEntry.TaxIncluded2Sum,
                };
                taxGroups.Add(taxGroup2);
            }
            if (invoiceEntry.TaxAuthority3 != null)
            {
                var taxGroup3 = new TaxGroupAuthority
                {
                    LineNumber = 3,
                    TaxAuthority = invoiceEntry.TaxAuthority3,
                    TaxAuthorityDescription = invoiceEntry.TaxAuthority3Description,
                    TaxClass = invoiceEntry.TaxClass3,
                    TaxClassDescription = invoiceEntry.TaxClass3Description,
                    TaxBase = invoiceEntry.TaxBase3,
                    TaxAmount = invoiceEntry.TaxAmount3,
                    TaxExcluded = invoiceEntry.TaxExcluded3Sum,
                    TaxReportingAmount = invoiceEntry.TaxReportingAmount3,
                    TaxInclude = invoiceEntry.TaxIncluded3Sum,
                };
                taxGroups.Add(taxGroup3);
            }

            if (invoiceEntry.TaxAuthority4 != null)
            {
                var taxGroup4 = new TaxGroupAuthority
                {
                    LineNumber = 4,
                    TaxAuthority = invoiceEntry.TaxAuthority4,
                    TaxAuthorityDescription = invoiceEntry.TaxAuthority4Description,
                    TaxClass = invoiceEntry.TaxClass4,
                    TaxClassDescription = invoiceEntry.TaxClass4Description,
                    TaxBase = invoiceEntry.TaxBase4,
                    TaxAmount = invoiceEntry.TaxAmount4,
                    TaxExcluded = invoiceEntry.TaxExcluded4Sum,
                    TaxReportingAmount = invoiceEntry.TaxReportingAmount4,
                    TaxInclude = invoiceEntry.TaxIncluded4Sum,
                };
                taxGroups.Add(taxGroup4);
            }
            if (invoiceEntry.TaxAuthority5 != null)
            {
                var taxGroup5 = new TaxGroupAuthority
                {
                    LineNumber = 5,
                    TaxAuthority = invoiceEntry.TaxAuthority5,
                    TaxAuthorityDescription = invoiceEntry.TaxAuthority5Description,
                    TaxClass = invoiceEntry.TaxClass5,
                    TaxClassDescription = invoiceEntry.TaxClass5Description,
                    TaxBase = invoiceEntry.TaxBase5,
                    TaxAmount = invoiceEntry.TaxAmount5,
                    TaxExcluded = invoiceEntry.TaxExcluded5Sum,
                    TaxReportingAmount = invoiceEntry.TaxReportingAmount5,
                    TaxInclude = invoiceEntry.TaxIncluded5Sum,
                };
                taxGroups.Add(taxGroup5);
            }

            return new EnumerableResponse<TaxGroupAuthority> { Items = taxGroups };
        }

        #endregion

        #endregion
    }
}