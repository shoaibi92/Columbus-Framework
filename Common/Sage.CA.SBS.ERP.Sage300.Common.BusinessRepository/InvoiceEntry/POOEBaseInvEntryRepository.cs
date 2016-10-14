/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.InvoiceEntry
{
    /// <summary>
    /// PO OE Base Invoice Entry Repository which talks to AccPac components
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
    public abstract class POOEBaseInvEntryRepository<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> : SequencedHeaderDetailFiveRepository<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5>
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
        #region Private Variable

        #region Tab Constants

        private const int InvoiceTab = 1;
        private const int TaxesTab = 2;
        private const int TermsTab = 3;
        private const int AdditionalCostTab = 4;
        private const int TotalsTab = 7;

        #endregion

        /// <summary>
        /// PO0416 - Invoice
        /// </summary>
        private IBusinessEntity _header;

        /// <summary>
        /// PO0416 - Invoice Line
        /// </summary>
        private IBusinessEntity _invoiceLine;

        /// <summary>
        /// PO0416 - Invoice Comment
        /// </summary>
        private IBusinessEntity _invoiceComment;

        /// <summary>
        /// PO0436 - Invoice Payment Schedule
        /// </summary>
        private IBusinessEntity _invoicePaymentSchedule;

        /// <summary>
        /// PO0419 - Invoice Function
        /// </summary>
        private IBusinessEntity _invoiceFunction;

        /// <summary>
        /// PO0438 - Invoice Reeceipts
        /// </summary>
        private IBusinessEntity _invoiceReciepts;

        /// <summary>
        /// PO0444 - Invoice Cost Superview
        /// </summary>
        private IBusinessEntity _invoiceCostSuperview;

        /// <summary>
        /// PO0423 - Invoice Optional Field
        /// </summary>
        private IBusinessEntity _invoiceOptionalField;

        /// <summary>
        /// PO0433 - Invoice Detail Optional Field
        /// </summary>
        private IBusinessEntity _invoiceDetailOptionalField;

        /// <summary>
        /// Comment Mapper - Instance
        /// </summary>
        private ModelMapper<THeader> _headerMapper;

        /// <summary>
        /// Payment Schedule Mapper - Instance
        /// </summary>
        private ModelMapper<TDetail4> _invoicePaymentScheduleMapper;

        /// <summary>
        /// Invoice Receipt Mapper - Instance
        /// </summary>
        private ModelMapper<TDetail6> _invoiceRecieptsMapper;

        /// <summary>
        /// Invoice Additional Cost Superview Mapper - Instance
        /// </summary>
        private ModelMapper<POOEInvBaseAddCostsSuperview> _invoiceCostSuperviewMapper;

        /// <summary>
        /// Invoice Optional Field Mapper - Instance
        /// </summary>
        private ModelMapper<BaseInvoiceOptionalField> _invoiceOptionalFieldMapper;

        /// <summary>
        /// Invoice Detail Optional Field Mapper - Instance
        /// </summary>
        private ModelMapper<BaseInvoiceOptionalField> _invoiceDetailOptionalFieldMapper;

        /// <summary>
        /// Invoice Line  Mapper - Instance
        /// </summary>
        private ModelMapper<TDetail1> _invoiceLineMapper;

        /// <summary>
        /// Invoice Line  Mapper - Instance
        /// </summary>
        private ModelMapper<POOEBaseInvoiceLine> _lineMapper;

        /// <summary>
        /// Invoice Line  Mapper - Instance
        /// </summary>
        private ModelMapper<POOEBaseInvoiceReciepts> _recieptMapper;

        /// <summary>
        /// Invoice Comment  Mapper - Instance
        /// </summary>
        private ModelMapper<POOEBaseInvoiceComments> _commentMapper;

        /// <summary>
        /// Detail Active Filter
        /// </summary>
        protected Expression<Func<TDetail1, bool>> InvoiceLineActiveFilter;

        /// <summary>
        /// Invoice mapper - Instance
        /// </summary>
        protected readonly POOEBaseInvoiceEntryMapper<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> InvoiceMapper;

        /// <summary>
        /// Invoice Line Entity Value
        /// </summary>
        private const string InvoiceLineEntity = "PO0430";
        #endregion

        #region Protected Variable

        /// <summary>
        /// Composes business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract POOEBaseInvoiceEntryBusinessSet<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> GetInvoiceEntryBusinessSet();

        /// <summary>
        /// Gets the details from the Header model.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <returns>List of TDetail</returns>
        protected abstract IEnumerable<BaseInvoiceOptionalField> GetBaseInvoiceOptionalModel(THeader model);

        #endregion

        #region Constructors

        /// <summary>
        /// POBOBaseInvEntryRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="businessEntitySessionParams"></param>
        protected POOEBaseInvEntryRepository(Context context,
            POOEBaseInvoiceEntryMapper<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> mapper, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, mapper, businessEntitySessionParams)
        {
            ValidRecordFilter = x => x.InvoiceNumber != "0";
            InvoiceMapper = mapper;
            var businessEntitySet = GetInvoiceEntryBusinessSet();
            SetAdditionalBusinessEntity(businessEntitySet);
        }

        /// <summary>
        /// POBOBaseInvEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session to be used</param>
        protected POOEBaseInvEntryRepository(Context context,
            POOEBaseInvoiceEntryMapper<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> mapper,
            IBusinessEntitySession session)
            : base(context, mapper, session)
        {
            ValidRecordFilter = x => x.InvoiceNumber != "0";
            InvoiceMapper = mapper;
            var businessEntitySet = GetInvoiceEntryBusinessSet();
            SetAdditionalBusinessEntity(businessEntitySet);
        }

        /// <summary>
        /// POBOBaseInvEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        protected POOEBaseInvEntryRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// POBOBaseInvEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        protected POOEBaseInvEntryRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region Public  Methods

        /// <summary>
        /// Gets a empty header data on load of page
        /// </summary>
        /// <returns>Header Model</returns>
        public virtual THeader GetEmptyData()
        {
            _header.Order = 0;
            _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceSequenceKey, 0);
            _header.Init();
            _header.Order = 1;
            if (_invoicePaymentSchedule.Exists)
            {
                _invoicePaymentSchedule.Init();
            }
            return _headerMapper.Map(_header);
        }

        /// <summary>
        /// Gets Optional Fields
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="isDetailOptField">Is request for detail optional fields</param>
        /// <returns>Enumerable response of Base Invoice Optional Field</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize,
            bool isDetailOptField)
        {
            IsSessionAvailable();
            if (isDetailOptField)
            {
                InvoiceMapper.MapOptionalField(null, _invoiceDetailOptionalField);
                if (_invoiceDetailOptionalField.Top())
                {
                    return RetrieveOptionalField(pageNumber, pageSize, _invoiceDetailOptionalField,
                        _invoiceDetailOptionalFieldMapper, 0);
                }
                return new EnumerableResponse<BaseInvoiceOptionalField>();
            }
            InvoiceMapper.MapOptionalField(null, _invoiceOptionalField);
            if (_invoiceOptionalField.Top())
            {
                return RetrieveOptionalField(pageNumber, pageSize, _invoiceOptionalField, _invoiceOptionalFieldMapper, 0);
            }
            return new EnumerableResponse<BaseInvoiceOptionalField>();
        }

        /// <summary>
        /// Save Optional Field
        /// </summary>
        /// <param name="optionalFields">List of Invoice detail optional field</param>
        /// <param name="isDetailOptionalField">Is Request for detail optional field</param>
        /// <returns>Success result - Boolean</returns>
        public virtual bool SaveOptionalFields(IEnumerable<BaseInvoiceOptionalField> optionalFields,
            bool isDetailOptionalField)
        {
            IsSessionAvailable();
            return SyncOptionalFields(optionalFields, isDetailOptionalField);
        }

        /// <summary>
        /// Check whether the optional field exists
        /// </summary>
        /// <param name="optionalField">Optional field</param>
        /// <param name="isDetailOptionalField">Is Detail optional field</param>
        /// <returns>True if Optional field exists</returns>
        public virtual bool IsOptionalFieldExists(string optionalField, bool isDetailOptionalField)
        {
            IsSessionAvailable();
            var entity = isDetailOptionalField ? _invoiceDetailOptionalField : _invoiceOptionalField;
            entity.SetValue(BaseInvoiceOptionalField.BaseFields.OptionalField, optionalField);
            return entity.Exists;
        }

        /// <summary>
        /// Set Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            var entity = optionalField.IsDetailOptionalField ? _invoiceDetailOptionalField : _invoiceOptionalField;
            var entityMapper = optionalField.IsDetailOptionalField ? _invoiceDetailOptionalFieldMapper : _invoiceOptionalFieldMapper;
            InvoiceMapper.MapOptionalField(optionalField, entity);
            var updatedOptionalField = entityMapper.Map(entity);
            return FormatOptionalFields(updatedOptionalField);
        }

        /// <summary>
        /// Set Optional Field Value
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            var entity = optionalField.IsDetailOptionalField ? _invoiceDetailOptionalField : _invoiceOptionalField;
            var entityMapper = optionalField.IsDetailOptionalField ? _invoiceDetailOptionalFieldMapper : _invoiceOptionalFieldMapper;
            entityMapper.MapKey(optionalField, entity);
            if (optionalField.Type != Models.Enums.InvoiceEntry.Type.Date)
            {
                entity.SetValue(BaseInvoiceOptionalField.BaseFields.Value, optionalField.Value,
                          optionalField.Validate == BatchPrintedFlag.Yes);
            }
            else
            {
                entity.SetValue(BaseInvoiceOptionalField.BaseFields.DateValue, optionalField.Value,
                         optionalField.Validate == BatchPrintedFlag.Yes);
            }
            var updatedOptionalField = entityMapper.Map(entity);
            updatedOptionalField.HasChanged = false;
            return FormatOptionalFields(updatedOptionalField);
        }

        /// <summary>
        /// Get By Ids
        /// </summary>
        /// <typeparam name="TInvoiceSequence">The type of the t Invoice Sequence Number key.</typeparam>
        /// <typeparam name="TInvoiceNumber">The type of the t Invoice Number key.</typeparam>
        /// <param name="invoiceSequence">The batch key.</param>
        /// <param name="invoiceNumber">The header key.</param>
        /// <returns>THeader model</returns>
        public virtual THeader GetByIds<TInvoiceSequence, TInvoiceNumber>(TInvoiceSequence invoiceSequence,
            TInvoiceNumber invoiceNumber)
        {
            CheckRights(_header, SecurityType.Inquire);

            if (invoiceSequence != null && invoiceSequence.ToString() == "0")
            {
                if (_header.GetValue<decimal>(POOEBaseInvoice.BaseFields.InvoiceSequenceKey) == 0 || _header.GetValue<bool>(POOEBaseInvoice.BaseFields.DocumentLocked))
                {
                    _header.Order = 0;
                    _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceSequenceKey, 0);
                    _header.Init();
                }
                _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceNumber, invoiceNumber, true);
                if (!_header.CanModify)
                {
                    //This Read() will just set the entity and get the latest data
                    //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
                    _header.Read(false);
                }
                return ReturnHeaderModel();
            }
            _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceNumber, invoiceNumber, false);
            _header.Order = 0;
            _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceSequenceKey, invoiceSequence);
            //This Read() will just set the entity and get the latest data
            //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
            _header.Read(false);
            return ReturnHeaderModel();
        }

        /// <summary>
        /// Refresh Header Based on value and property
        /// </summary>
        /// <param name="value">Value that was changed</param>
        /// <param name="property">Field that was changed</param>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshHeader(string value, string property)
        {
            IsSessionAvailable();
            CheckRights(_header, SecurityType.Inquire);
            switch (property)
            {
                case InvoiceEntryConstants.VendorNumber:
                    _header.SetValue(POOEBaseInvoice.BaseFields.Vendor, string.Empty);
                    _header.SetValue(POOEBaseInvoice.BaseFields.Vendor, value, true);
                    break;
                case InvoiceEntryConstants.ReceiptNumber:
                    var vendorNumber = _header.GetValue<string>(POOEBaseInvoice.BaseFields.Vendor);
                    if (!string.IsNullOrEmpty(vendorNumber))
                    {
                        _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Vendor, vendorNumber, true);
                        _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.ReceiptNumber, value, true);
                        _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Function, 9);
                    }
                    else
                    {
                        _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.ReceiptNumber, value, true);
                        _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Function, 2);
                    }
                    // This logic is to throw the error only when LastReturnCode is 6666.
                    // Else if any other value is returned in LastReturnCode we will have to set the Header entity(PO0420 View)back to correct order 
                    // and perform init of Header entity, because when process happens in Function View(PO0419) it internally changes HeaderEntity 
                    //which has to be initialized once process fails with any other return code.
                    try
                    {
                        _invoiceFunction.Process();
                    }
                    catch (BusinessException exception)
                    {
                        if (_invoiceFunction.View.LastReturnCode != 1000)
                        {
                            return OnProcessErrorHandler(exception);
                        }
                        throw;
                    }
                    break;
                case InvoiceEntryConstants.TaxGroup:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxGroup, value, true);
                    break;
                case InvoiceEntryConstants.TaxReportingRateType:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingRateType, value, true);
                    break;
                case InvoiceEntryConstants.DateFields.TaxReportingRateDate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingRateDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.DateFields.RateDate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.RateDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.RateType:
                    _header.SetValue(POOEBaseInvoice.BaseFields.RateType, value, true);
                    break;
                case InvoiceEntryConstants.RateExchangeRate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.ExchangeRate, value, true);
                    break;
                case InvoiceEntryConstants.TaxReportingExchangeRate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingExchangeRate, value, true);
                    break;
                case InvoiceEntryConstants.Terms:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TermsCode, value, true);
                    break;
                case InvoiceEntryConstants.DiscountAmount:
                    _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DiscountAmount, value, true);
                    _invoicePaymentSchedule.Verify();
                    _invoicePaymentSchedule.Update();
                    break;
                case InvoiceEntryConstants.DiscountPercentage:
                    _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DiscountPercentage, value,
                        true);
                    _invoicePaymentSchedule.Verify();
                    _invoicePaymentSchedule.Update();
                    break;
                case InvoiceEntryConstants.DateFields.DiscountDate:
                    _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DiscountDate, DateUtil.GetDate(value, null), true);
                    _invoicePaymentSchedule.Verify();
                    _invoicePaymentSchedule.Update();
                    break;
                case InvoiceEntryConstants.DateFields.DueDate:
                    _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DueDate, DateUtil.GetDate(value, null), true);
                    _invoicePaymentSchedule.Verify();
                    _invoicePaymentSchedule.Update();
                    break;
                case InvoiceEntryConstants.TotalDiscPercentage:
                    _header.SetValue(POOEBaseInvoice.BaseFields.DiscountPercentage, value, true);
                    return CalculateTax();
                case InvoiceEntryConstants.TotalDiscAmount:
                    _header.SetValue(POOEBaseInvoice.BaseFields.DiscountAmount, value, true);
                    return CalculateTax();
                case InvoiceEntryConstants.TotalComment:
                    _header.SetValue(POOEBaseInvoice.BaseFields.Comment, value, true);
                    break;
                case InvoiceEntryConstants.DateFields.InvoiceDate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceDate, value, true);
                    _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Function, 3);
                    _invoiceFunction.Process();
                    break;
                case InvoiceEntryConstants.DateFields.PostingDate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.PostingDate, value, true);
                    break;
                case InvoiceEntryConstants.InvoiceDescription:
                    _header.SetValue(POOEBaseInvoice.BaseFields.Description, value, true);
                    break;
                case InvoiceEntryConstants.Reference:
                    _header.SetValue(POOEBaseInvoice.BaseFields.Reference, value, true);
                    break;
                case InvoiceEntryConstants.InvoiceTotal:
                    _header.SetValue(POOEBaseInvoice.BaseFields.InvoiceTotal, value, true);
                    break;
                case InvoiceEntryConstants.BillToLocation:
                    _header.SetValue(POOEBaseInvoice.BaseFields.BillToLocation, value, true);
                    break;
                case InvoiceEntryConstants.RemitToLocation:
                    _header.SetValue(POOEBaseInvoice.BaseFields.RemitToLocation, value, true);
                    break;
                case InvoiceEntryConstants.AccountSet:
                    _header.SetValue(POOEBaseInvoice.BaseFields.VendorAccountSet, value, true);
                    break;
                case InvoiceEntryConstants.OnHold:
                    _header.SetValue(POOEBaseInvoice.BaseFields.OnHold, value, true);
                    break;
                case InvoiceEntryConstants.DateFields.AsofDate:
                    _header.SetValue(POOEBaseInvoice.BaseFields.PaymentAsOfDate, value, true);
                    break;
                case InvoiceEntryConstants.MultipleReceipts:
                    _header.SetValue(POOEBaseInvoice.BaseFields.MultipleReceipts, value, true);
                    break;
                case InvoiceEntryConstants.The1099CPRSAmount:
                    _header.SetValue(POOEBaseInvoice.BaseFields.The1099CPRSAmount, value, true);
                    break;
                case InvoiceEntryConstants.Num1099CPRSClass:
                    _header.SetValue(POOEBaseInvoice.BaseFields.Num1099CPRSClass, value, true);
                    break;
            }
            var headerModel = ReturnHeaderModel();
            var warnings = headerModel.Warnings.ToList();
            EntityError error;
            var taxGroupChangeMessage = string.Format(InvoiceResx.DocumentAndTaxReportingCurrenciesDiffer, headerModel.Currency,
                headerModel.TaxReportingCurrency, headerModel.TaxGroup);
            var rateChangeMessage = string.Format(InvoiceResx.RateNotExist, headerModel.Currency, Session.HomeCurrency,
                headerModel.RateType, DateUtil.GetShortDate(headerModel.RateDate, string.Empty));
            var taxReportingChangeMessage = string.Format(InvoiceResx.RateNotExist, headerModel.Currency,
                headerModel.TaxReportingCurrency, headerModel.TaxReportingRateType,
                DateUtil.GetShortDate(headerModel.TaxReportingRateDate, string.Empty));
            switch (property)
            {
                case InvoiceEntryConstants.TaxGroup:
                    if (headerModel.TaxReportingCurrency != null &&
                        headerModel.Currency != headerModel.TaxReportingCurrency)
                    {
                        error = CreateEntityError(taxGroupChangeMessage, Priority.Warning);
                        warnings.Insert(0, error);
                        if (headerModel.TaxReportingExchRateExists == AllowedType.No)
                        {
                            error = CreateEntityError(taxReportingChangeMessage, Priority.Warning);
                            warnings.Insert(0, error);
                        }
                    }
                    break;
                case InvoiceEntryConstants.VendorNumber:
                    if (headerModel.VendorExists == AutoTaxCalculationOnSave.No)
                    {
                        error = CreateEntityError(string.Format(InvoiceResx.VendorNotExist, headerModel.Vendor), Priority.Warning);
                        warnings.Insert(0, error);

                    }
                    if (headerModel.ExchangeRateExists == AllowedType.No)
                    {
                        error = CreateEntityError(rateChangeMessage, Priority.Warning);
                        warnings.Insert(0, error);
                    }
                    if (headerModel.TaxReportingCurrency != null &&
                        headerModel.Currency != headerModel.TaxReportingCurrency)
                    {

                        if (headerModel.TaxReportingExchRateExists == AllowedType.No)
                        {
                            error = CreateEntityError(taxReportingChangeMessage, Priority.Warning);
                            warnings.Insert(0, error);
                        }
                        error = CreateEntityError(taxGroupChangeMessage, Priority.Warning);
                        warnings.Insert(0, error);
                    }

                    break;
                case InvoiceEntryConstants.RateType:
                case InvoiceEntryConstants.DateFields.RateDate:
                    if (headerModel.ExchangeRateExists != AllowedType.No) { return headerModel; }
                    error = CreateEntityError(rateChangeMessage, Priority.Warning);
                    warnings.Insert(0, error);
                    break;
                case InvoiceEntryConstants.TaxReportingRateType:
                case InvoiceEntryConstants.DateFields.TaxReportingRateDate:
                    if (headerModel.TaxReportingExchRateExists != AllowedType.No) { return headerModel; }
                    error = CreateEntityError(taxReportingChangeMessage, Priority.Warning);
                    warnings.Insert(0, error);
                    break;
                case InvoiceEntryConstants.ReceiptNumber:
                    if (headerModel.ExchangeRateExists == AllowedType.No)
                    {
                        error = CreateEntityError(rateChangeMessage, Priority.Warning);
                        warnings.Insert(0, error);
                    }
                    if (headerModel.TaxReportingExchRateExists == AllowedType.No)
                    {
                        error = CreateEntityError(taxReportingChangeMessage, Priority.Warning);
                        warnings.Insert(0, error);
                    }
                    break;
            }
            headerModel.Warnings = warnings;
            return headerModel;
        }

        /// <summary>
        /// Post Invoice
        /// </summary>
        public virtual void Post(THeader model)
        {
            IsSessionAvailable();
            IEnumerable<BaseInvoiceOptionalField> optionalField = new List<BaseInvoiceOptionalField>();
            if (model.OptionalFieldList != null)
            {
                optionalField = GetBaseInvoiceOptionalModel(model).ToList();
            }
            SyncOptionalFields(optionalField, false);
            _headerMapper.Map(model, _header);
            CalculateTax(true);
            _header.Verify();
            _header.Insert();
        }

        /// <summary>
        /// On Tab select performs action based on last tab selected
        /// </summary>
        /// <param name="previousTab">Last Tab selected</param>
        /// <returns>POOEBaseInvoiceViewModel model</returns>
        public virtual THeader TabSelect(int previousTab)
        {
            IsSessionAvailable();
            switch (previousTab)
            {
                case TermsTab:
                    break;
                case TaxesTab:
                    //This is as per VB. They are setting the tax group value again and then calculating tax on click of Rates Tab
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxGroup, _header.GetValue<string>(POOEBaseInvoice.BaseFields.TaxGroup), true);
                    return CalculateTax(true);
                case AdditionalCostTab:
                    break;
                case InvoiceTab:
                    CalculateTax(true);
                    break;
                case TotalsTab:
                    break;
            }
            return ReturnHeaderModel();
        }

        /// <summary>
        /// This calculates tax when button is pressed in UI
        /// </summary>
        /// <param name="calculateTaxWithoutPending">To calculate tax without pending amount.Default value is false</param>
        /// <returns>THeader model</returns>
        public virtual THeader CalculateTax(bool calculateTaxWithoutPending = false)
        {
            IsSessionAvailable();
            if (calculateTaxWithoutPending && !_header.GetValue<bool>(POOEBaseInvoice.BaseFields.TaxcalculationIspending))
            {
                return ReturnHeaderModel();
            }
            var detailSequenceKey = _invoiceLine.GetValue<decimal>(POOEBaseInvoiceLine.BaseFields.InvoiceSequenceKey);
            var detailLine = _invoiceLine.GetValue<decimal>(POOEBaseInvoiceLine.BaseFields.DetailLineNumber);

            var calculateTaxtype = calculateTaxWithoutPending ? 6 : 3;
            _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Function, calculateTaxtype);
            _invoiceFunction.Process();

            //This is to make sure the detail Line is set back to the current line that was selected in UI.
            //This will bring the Total Tax correctly.
            _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.InvoiceSequenceKey, detailSequenceKey);
            _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.DetailLineNumber, detailLine);
            _invoiceLine.Read(false);

            return ReturnHeaderModel();
        }

        /// <summary>
        /// Derive Rates
        /// </summary>
        /// <returns>Rate</returns>
        public virtual decimal DeriveRate()
        {
            IsSessionAvailable();
            _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingExchangeRate, _header.GetValue<decimal>(POOEBaseInvoice.BaseFields.DerivedTaxReportingExchRate), true);
            return _header.GetValue<decimal>(POOEBaseInvoice.BaseFields.TaxReportingExchangeRate);
        }

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details">InvoiceLine model</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveDetails(IEnumerable<POOEBaseInvoiceLine> details)
        {
            IsSessionAvailable();
            SyncDetails(details);
            var model = ReturnHeaderModel();
            if (model.InvoiceLine != null)
            {
                foreach (var invoiceDetail in model.InvoiceLine.Items)
                {
                    SetAttributes(invoiceDetail, _invoiceLine);
                }
            }
            return model;
        }

        /// <summary>
        /// Save Multi Receipts
        /// </summary>
        /// <param name="receipts">Invoice Reciepts</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveMultiReceipts(IEnumerable<POOEBaseInvoiceReciepts> receipts)
        {
            IsSessionAvailable();
            SyncMultiReceipts(receipts);
            return ReturnHeaderModel();
        }

        /// <summary>
        /// Updates the Terms Payment schedule
        /// </summary>
        /// <param name="model">TDetail4 model</param>
        /// <returns>TDetail4 Model</returns>
        public virtual TDetail4 UpdateTermsPaymentSchedule(TDetail4 model)
        {
            IsSessionAvailable();

            //To set to a specific payment number 
            _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.PaymentNumber, model.PaymentNumber, true);
            _invoicePaymentSchedule.Read(false);

            //Map the data 
            if (model.DueDate != null)
            {
                _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DueDate, model.DueDate, true);
            }
            _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.AmountDue, model.AmountDue, true);
            _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DiscountAmount, model.DiscountAmount, true);
            _invoicePaymentSchedule.SetValue(POOEBaseInvPaymentSchedule.BaseFields.DiscountDate, model.DiscountDate, true);

            //Update the payment schedule view
            _invoicePaymentSchedule.Verify();
            _invoicePaymentSchedule.Update();

            return _invoicePaymentScheduleMapper.Map(_invoicePaymentSchedule);
        }

        /// <summary>
        /// Updates the receipts grid when the when user changes from one row to another.
        /// </summary>
        /// <param name="model">TDetail6 model</param>
        /// <returns>TDetail6 model</returns>
        public virtual TDetail6 InsertMultipleReceipts(TDetail6 model)
        {
            IsSessionAvailable();
            if (model == null) { return _invoiceRecieptsMapper.Map(_invoiceReciepts); }
            _invoiceRecieptsMapper.MapKey(model, _invoiceReciepts);
            _invoiceReciepts.SetValue(POOEBaseInvoiceReciepts.BaseFields.ReceiptNumber,
                model.ReceiptNumber, true);
            _invoiceReciepts.Verify();
            _invoiceReciepts.Insert();
            return _invoiceRecieptsMapper.Map(_invoiceReciepts);
        }

        /// <summary>
        /// Refreshes the Invoice Detail
        /// </summary>
        /// <param name="detail">TDetail1 model</param>
        /// <param name="eventType">Property that changed</param>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshDetail(TDetail1 detail, string eventType)
        {
            IsSessionAvailable();
            _invoiceLineMapper.MapKey(detail, _invoiceLine);
            var ifExists = _invoiceLine.Exists;
            if (ifExists)
            {
                //This Read() will just set the entity and get the latest data
                //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
                _invoiceLine.Read(false);
            }
            switch (eventType)
            {
                case InvoiceEntryConstants.DetailFields.ItemDescription:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.ItemDescription, detail.ItemDescription, true);
                    break;
                case InvoiceEntryConstants.DetailFields.QuantityReceived:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.QuantityReceived, detail.QuantityReceived, true);
                    break;
                case InvoiceEntryConstants.DetailFields.UnitCost:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.UnitCost, detail.UnitCost, true);
                    break;
                case InvoiceEntryConstants.DetailFields.ExtendedCost:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.ExtendedCost, detail.ExtendedCost, true);
                    break;
                case InvoiceEntryConstants.DiscountPercentage:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.DiscountPercentage, detail.DiscountPercentage, true);
                    break;
                case InvoiceEntryConstants.DiscountAmount:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.DiscountAmount, detail.DiscountAmount, true);
                    break;
                case InvoiceEntryConstants.DetailFields.WeightUnitOfMeasure:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.WeightUnitOfMeasure, detail.WeightUnitOfMeasure, true);
                    break;
                case InvoiceEntryConstants.DetailFields.UnitWeight:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.UnitWeight, detail.UnitWeight, true);
                    break;
                case InvoiceEntryConstants.DetailFields.ExtendedWeight:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.ExtendedWeight, detail.ExtendedWeight, true);
                    break;
                case InvoiceEntryConstants.OrderNumber:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.OrderNumber, detail.OrderNumber, true);
                    break;
                case InvoiceEntryConstants.DetailFields.VendorItemNumber:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.VendorItemNumber, detail.VendorItemNumber, true);
                    break;
                case InvoiceEntryConstants.DetailFields.ExpenseAccount:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.ExpenseAccount, detail.ExpenseAccount, true);
                    break;
                case InvoiceEntryConstants.DetailFields.NonStockClearingAccount:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.NonStockClearingAccount, detail.NonStockClearingAccount, true);
                    break;
                case InvoiceEntryConstants.DetailFields.Comment:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.Comments, detail.Comments, true);
                    break;
                case InvoiceEntryConstants.DetailFields.ManufacturersItemNumber:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.ManufacturersItemNumber, detail.ManufacturersItemNumber, true);
                    break;
                case InvoiceEntryConstants.DetailFields.PaymentDiscountable:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.PaymentDiscountable, detail.PaymentDiscountable, true);
                    break;
                case InvoiceEntryConstants.FullyInvoiced:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.FullyInvoiced, detail.FullyInvoiced);
                    _invoiceLine.Verify();
                    break;
            }
            if (ifExists)
            {
                _invoiceLine.Update();
            }
            var model = ReturnHeaderModel();
            if (model.InvoiceLine != null)
            {
                foreach (var invoiceDetail in model.InvoiceLine.Items)
                {
                    SetAttributes(invoiceDetail, _invoiceLine);
                }
            }
            return model;
        }

        /// <summary>
        /// Retrieve Additional Cost records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail6> GetMultipleReceipts(int currentPageNumber, int pageSize,
            Expression<Func<TDetail6, bool>> filter = null, OrderBy orderBy = null)
        {
            IsSessionAvailable();
            _header.SetValue(POOEBaseInvoice.BaseFields.MultipleReceipts, 1, true);
            _invoiceReciepts.ClearRecord();
            _invoiceReciepts.RecordCreate(ViewRecordCreate.NoInsert);
            _invoiceReciepts.ClearRecord();
            var resultsCount = SetFilter(_invoiceReciepts, filter, null, orderBy);

            if (_invoiceReciepts.Fetch(false))
            {
                return new EnumerableResponse<TDetail6>
                {
                    Items = MapDataToModel(_invoiceReciepts, _invoiceRecieptsMapper, currentPageNumber, pageSize, resultsCount),
                    TotalResultsCount = GetTotalRecords(_invoiceReciepts)
                };
            }

            return new EnumerableResponse<TDetail6> { Items = new List<TDetail6>(), TotalResultsCount = 0 };
        }

        /// <summary>
        /// Creates a new Invoice Receipt
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>POOEBaseInvoiceReciepts model</returns>
        public virtual POOEBaseInvoiceReciepts NewInvoiceReceipt(int pageNumber, int pageSize, POOEBaseInvoiceReciepts currentDetail)
        {
            IsSessionAvailable();
            //This Read() will just set the entity and get the latest data
            //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
            if (currentDetail != null)
            {
                _invoiceReciepts.SetValue(POOEBaseInvoiceReciepts.BaseFields.LineNumber, currentDetail.LineNumber);
            }
            _invoiceReciepts.Read(false);
            _invoiceReciepts.RecordCreate(ViewRecordCreate.NoInsert);
            return _recieptMapper.Map(_invoiceReciepts);
        }

        /// <summary>
        /// Multiple Receipts process
        /// </summary>
        /// <returns>THeader model</returns>
        public virtual THeader MultiReceipts()
        {
            IsSessionAvailable();
            if (_header.GetValue<int>(POOEBaseInvoice.BaseFields.ReceiptSequenceKey) == 0 &&
                _header.GetValue<bool>(POOEBaseInvoice.BaseFields.MultipleReceipts) &&
                _header.GetValue<int>(POOEBaseInvoice.BaseFields.Receipts) > 0)
            {
                _invoiceFunction.SetValue(POOEBaseInvoiceFunction.BaseFields.Function, 12);
                // This logic is to throw the error only when LastReturnCode is 6666.
                // Else if any other value is returned in LastReturnCode we will have to set the Header entity(PO0420 View)back to correct order 
                // and perform init of Header entity, because when process happens in Function View(PO0419) it internally changes HeaderEntity 
                //which has to be initialized once process fails with any other return code.
                try
                {
                    _invoiceFunction.Process();
                }
                catch (BusinessException exception)
                {
                    var lastReturnCode = _invoiceFunction.View.LastReturnCode;
                    if (lastReturnCode == 6666)
                    {
                        throw new BusinessException(string.Empty, exception.Errors);
                    }
                    return OnProcessErrorHandler(exception);
                }
            }
            return ReturnHeaderModel();
        }

        /// <summary>
        /// Refreshes Invoice model. This only returns the data not set any thing
        /// </summary>
        /// <returns>THeader model</returns>
        public virtual THeader RefreshInvoice()
        {
            IsSessionAvailable();
            return ReturnHeaderModel();
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
            IsSessionAvailable();
            var isDirty = _invoiceComment.Dirty;
            _commentMapper.MapKey(model, _invoiceComment);

            if (!isDirty && _invoiceComment.Exists)
            {
                _invoiceComment.Read(false);
            }

            if (model.IsNewLine)
            {
                InsertCommentInstruction(model, comment, lineType);
            }
            else
            {
                SyncCommentInstruction(model, comment);
            }

            var updatedComment = _commentMapper.Map(_invoiceComment);
            updatedComment.DisplayIndex = model.DisplayIndex;
            return updatedComment;
        }

        /// <summary>
        /// Save Comments
        /// </summary>
        /// <param name="comments">POOEBaseInvoiceComments model</param>
        /// <returns>THeader model</returns>
        public virtual THeader SaveComments(IEnumerable<POOEBaseInvoiceComments> comments)
        {
            IsSessionAvailable();
            SyncComments(comments);
            return ReturnHeaderModel();
        }

        /// <summary>
        /// Gets Comment Instruction
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of POOEBaseInvoiceComments</returns>
        public virtual EnumerableResponse<POOEBaseInvoiceComments> GetCommentInstruction(int pageNumber, int pageSize, Expression<Func<POOEBaseInvoiceComments, bool>> filter = null,
            OrderBy orderBy = null)
        {
            IsSessionAvailable();
            var commentFilter = ExpressionHelper.Translate(filter);
            var loopCounter = 1;

            _invoiceComment.SetValue(Constant.DefaultValue2, _invoiceComment.GetMinimumValue<decimal>(Constant.DefaultValue2));
            _invoiceComment.Browse(commentFilter, true);

            var resultsCount = SetFilter(_invoiceComment, filter);
            var startIndex = CommonUtil.ComputeStartIndex(pageNumber, pageSize);
            var endIndex = CommonUtil.ComputeEndIndex(pageNumber, pageSize, resultsCount);

            if (_invoiceComment.Fetch(false))
            {
                var lineNumber = 0;
                var commentList = new List<POOEBaseInvoiceComments>();
                do
                {
                    if (loopCounter >= startIndex)
                    {
                        var commentDetail = _commentMapper.Map(_invoiceComment);
                        commentDetail.DisplayIndex = lineNumber++;
                        commentList.Add(commentDetail);
                    }

                    loopCounter++;
                } while (loopCounter <= endIndex && _invoiceComment.Next());


                return new EnumerableResponse<POOEBaseInvoiceComments>
                {
                    Items = commentList,
                    TotalResultsCount = GetTotalRecords(_invoiceComment)
                };
            }
            return new EnumerableResponse<POOEBaseInvoiceComments> { Items = new List<POOEBaseInvoiceComments>(), TotalResultsCount = Constant.DefaultValue0 };
        }



        #region Taxes

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <returns>Enumerable Response of TaxGroupAuthority model</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(TDetail1 model)
        {
            IsSessionAvailable();
            var taxGroup = _header.GetValue<string>(POOEBaseInvoice.BaseFields.TaxGroup);
            _header.SetValue(POOEBaseInvoice.BaseFields.TaxGroup, taxGroup, true);
            _invoiceLineMapper.MapKey(model, _invoiceLine);
            //This Read() will just set the entity and get the latest data
            //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
            _invoiceLine.Read(false);
            return InvoiceMapper.GetDetailTaxAuthority(_invoiceLineMapper.Map(_invoiceLine), _header);
        }

        /// <summary>
        /// Set the Tax Group
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>THeader model</returns>
        public virtual THeader SetTaxesValue(string property, string fieldValue)
        {
            IsSessionAvailable();
            switch (property)
            {
                case InvoiceEntryConstants.TaxClass1:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxClass1, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass2:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxClass2, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass3:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxClass3, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass4:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxClass4, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass5:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxClass1, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxAmount1:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxAmount1, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxAmount2:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxAmount2, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxAmount3:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxAmount3, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxAmount4:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxAmount4, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxAmount5:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxAmount5, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxReportingAmount1:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingAmount1, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxReportingAmount2:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingAmount2, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxReportingAmount3:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingAmount3, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxReportingAmount4:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingAmount4, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxReportingAmount5:
                    _header.SetValue(POOEBaseInvoice.BaseFields.TaxReportingAmount5, fieldValue, true);
                    break;
            }

            var receipt = _headerMapper.Map(_header);
            return receipt;
        }

        /// <summary>
        /// Set the Tax Group for Detail
        /// </summary>
        /// <param name="property">Property</param>
        /// <param name="fieldValue">Value</param>
        /// <returns>TDetail1 model</returns>
        public virtual TDetail1 SetDetailTaxesValue(string property, string fieldValue)
        {
            IsSessionAvailable();
            switch (property)
            {
                case InvoiceEntryConstants.TaxClass1:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxClass1, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass2:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxClass2, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass3:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxClass3, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass4:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxClass4, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxClass5:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxClass1, string.IsNullOrEmpty(fieldValue) ? "0" : fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxIncludable1:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxIncludable1, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxIncludable2:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxIncludable2, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxIncludable3:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxIncludable3, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxIncludable4:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxIncludable4, fieldValue, true);
                    break;
                case InvoiceEntryConstants.TaxIncludable5:
                    _invoiceLine.SetValue(POOEBaseInvoiceLine.BaseFields.TaxIncludable5, fieldValue, true);
                    break;
            }
            if (_invoiceLine.Exists)
            {
                _invoiceLine.Update();
            }
            var invoiceDetail = _invoiceLineMapper.Map(_invoiceLine);
            return invoiceDetail;
        }

        #endregion

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>THeader model</returns>
        public override THeader SetDetail(TDetail1 currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                _invoiceLineMapper.MapKey(currentDetail, _invoiceLine);
                if (_invoiceLine.Exists)
                {
                    //This Read() will just set the entity and get the latest data
                    //There is no further action that needs to be performed based on the return value of Read(), that is why not checking the any return value.
                    _invoiceLine.Read(false);
                }
            }
            var model = ReturnHeaderModel();
            if (model.InvoiceLine != null)
            {
                foreach (var invoiceDetail in model.InvoiceLine.Items)
                {
                    SetAttributes(invoiceDetail, _invoiceLine);
                }
            }
            return model;
        }

        /// <summary>
        /// Insert Detail Models
        /// </summary>
        /// <typeparam name="TU">ModelBase</typeparam>
        /// <param name="businessEntity">Entity</param>
        /// <param name="mapper">Model Mapper</param>
        /// <param name="newLine">Model</param>
        /// <returns></returns>
        public override bool InsertDetailModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, TU newLine)
        {
            mapper.MapKey(newLine, businessEntity);
            if (!businessEntity.Exists && newLine.IsDeleted)
            {
                businessEntity.ClearRecord();
            }
            else if (!businessEntity.Exists && !newLine.IsDeleted)
            {
                businessEntity.Insert();
                newLine.IsNewLine = false;
            }
            else if (businessEntity.Exists && !newLine.IsDeleted)
            {
                businessEntity.Read(false);
                businessEntity.Update();
            }
            return true;
        }

        /// <summary>
        /// Gets the Details
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of details</returns>
        public override EnumerableResponse<TDetail1> GetDetail(int pageNumber, int pageSize, Expression<Func<TDetail1, bool>> filter = null, OrderBy orderBy = null)
        {
            var model = base.GetDetail(pageNumber, pageSize, filter, orderBy);
            foreach (var detail in model.Items)
            {
                _invoiceLineMapper.MapKey(detail, _invoiceLine);
                _invoiceLine.Read(false);
                SetAttributes(detail, _invoiceLine);
            }
            return model;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set the additional business entities
        /// </summary>
        /// <param name="businessEntities">BaseInvoiceEntryBusinesSet model</param>
        private void SetAdditionalBusinessEntity(
            POOEBaseInvoiceEntryBusinessSet<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5, TDetail6, TDetail7, TDetail8, TDetail9, TDetail10
        , TDetail11, TDetail12, TDetail13, TDetail14, TDetail15> businessEntities)
        {
            _header = businessEntities.HeaderBusinessEntity;
            _headerMapper = businessEntities.HeaderMapper;
            _invoiceLine = businessEntities.DetailBusinessEntity;
            _invoiceLineMapper = businessEntities.DetailMapper;
            _invoiceComment = businessEntities.CommentBusinessEntity;
            _invoicePaymentSchedule = businessEntities.PaymentBusinessEntity;
            _invoicePaymentScheduleMapper = businessEntities.PaymentMapper;
            _invoiceFunction = businessEntities.FunctionBusinessEntity;
            _invoiceReciepts = businessEntities.RecieptsBusinessEntity;
            _invoiceRecieptsMapper = businessEntities.RecieptsMapper;
            _invoiceCostSuperview = businessEntities.CostSuperViewBusinessEntity;
            _invoiceCostSuperviewMapper = businessEntities.CostSuperViewMapper;
            _invoiceOptionalField = businessEntities.OptionalFieldBusinessEntity;
            _invoiceOptionalFieldMapper = businessEntities.OptionalFieldMapper;
            _invoiceDetailOptionalField = businessEntities.DetailOptionalFieldBusinessEntity;
            _invoiceDetailOptionalFieldMapper = businessEntities.DetailOptionalFieldMapper;
            InvoiceLineActiveFilter = businessEntities.DetailFilter;
            _lineMapper = businessEntities.LineMapper;
            _recieptMapper = businessEntities.RecieptMapper;
            _commentMapper = businessEntities.BaseCommentMapper;
        }

        /// <summary>
        /// To retrieve the List of Optional Fields
        /// </summary>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="entity">Entity</param>
        /// <param name="mapper">OptionalFieldMapper</param>
        /// <param name="filterCount">The filter count.</param>
        /// <returns>List of Invoice detail optional fields</returns>
        private EnumerableResponse<BaseInvoiceOptionalField> RetrieveOptionalField(int currentPageNumber, int pageSize,
        IBusinessEntity entity, ModelMapper<BaseInvoiceOptionalField> mapper, int filterCount)
        {
            CheckRights(GetAccessRights(), SecurityType.Inquire);

            var optionalFieldList = new List<BaseInvoiceOptionalField>();
            var startIndex = CommonUtil.ComputeStartIndex(currentPageNumber, pageSize);
            var endIndex = CommonUtil.ComputeEndIndex(currentPageNumber, pageSize, filterCount);
            var loopCounter = 1;
            var lineNumber = 0;
            if (!entity.Top())
            {
                return new EnumerableResponse<BaseInvoiceOptionalField>
                {
                    Items = optionalFieldList,
                    TotalResultsCount = filterCount != 0 ? filterCount : GetOptionalFieldsCount(entity)
                };
            }
            do
            {
                if (loopCounter >= startIndex)
                {
                    var optionalField = mapper.Map(entity);
                    optionalField.DisplayIndex = lineNumber++;
                    switch (optionalField.Type)
                    {
                        case Models.Enums.InvoiceEntry.Type.Date:
                            optionalField.Value = DateUtil.GetShortDate(optionalField.Value, string.Empty, true);
                            break;
                        case Models.Enums.InvoiceEntry.Type.Time:
                            if (optionalField.Value != null)
                            {
                                optionalField.Value = Regex.Replace(optionalField.Value, @"(\w{2})(\w{2})(\w{2})",
                                    @"$1:$2:$3");
                            }
                            break;
                    }

                    //if (invoiceDetailOptionalField.OptionalField != null)
                    //Added to return an empty list if there are no optional fields
                    optionalFieldList.Add(optionalField);
                }

                loopCounter++;
            } while (loopCounter <= endIndex && entity.Next());
            return new EnumerableResponse<BaseInvoiceOptionalField>
            {
                Items = optionalFieldList,
                TotalResultsCount = filterCount != 0 ? filterCount : GetOptionalFieldsCount(entity)
            };
        }

        /// <summary>
        /// Gets the optional fields count.
        /// </summary>
        /// <returns>Integer value</returns>
        private static int GetOptionalFieldsCount(IBusinessEntity entity)
        {
            var total = 0;
            if (entity.Top())
            {
                do
                {
                    total++;
                } while (entity.Next());
                if (!entity.Exists && total == 1)
                {
                    return 0;
                }
            }
            return total;
        }

        /// <summary>
        /// Synchronizes optional fields
        /// </summary>
        /// <param name="detailOptionalFields">Detail Optional Fields</param>
        /// <param name="isDetailOptionalField">Is Detail OptionalField</param>
        /// <returns>True if optional fields are synched</returns>
        private bool SyncOptionalFields(IEnumerable<BaseInvoiceOptionalField> detailOptionalFields,
            bool isDetailOptionalField)
        {
            var isDetailUpdated = false;
            if (detailOptionalFields == null) { return false; }
            var allDetails = detailOptionalFields as IList<BaseInvoiceOptionalField> ?? detailOptionalFields.ToList();

            foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted))
            {
                isDetailUpdated = SyncOptionalField(detail, isDetailOptionalField);
            }
            foreach (var newLine in allDetails.Where(detail => detail.IsNewLine && !detail.IsDeleted))
            {
                isDetailUpdated = InsertOptionalField(newLine, isDetailOptionalField);
            }
            if (!isDetailOptionalField) { return isDetailUpdated; }
            if (_invoiceLine.Exists)
            {
                _invoiceLine.Update();
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// To set fields for Detail Optional Fields
        /// </summary>
        /// <param name="optionalField">Optional Fields</param>
        /// <param name="isDetailOptionalField">is detail optional field</param>
        /// <returns>True if optional field are synched</returns>
        private bool SyncOptionalField(BaseInvoiceOptionalField optionalField, bool isDetailOptionalField)
        {
            var entity = isDetailOptionalField ? _invoiceDetailOptionalField : _invoiceOptionalField;
            var entityMapper = isDetailOptionalField ? _invoiceDetailOptionalFieldMapper : _invoiceOptionalFieldMapper;

            if (string.IsNullOrEmpty(optionalField.OptionalField)) { return true; }
            var isUpdated = false;
            entityMapper.MapKey(optionalField, entity);
            var isExist = entity.Read(false);

            if (optionalField.IsDeleted && isExist)
            {
                entity.Delete();
                entity.ClearRecord();
                isUpdated = true;
            }
            else if (optionalField.IsDeleted && !isExist)
            {
                entity.ClearRecord();
                isUpdated = true;
            }
            else if (isExist)
            {
                entityMapper.MapKey(optionalField, entity);
                entity.Read(false);
                entityMapper.Map(optionalField, entity);
                entity.Update();
                isUpdated = true;
            }
            return isUpdated;
        }

        /// <summary>
        /// Insert Optional field
        /// </summary>
        /// <param name="newLine">BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">if detail optional field</param>
        /// <returns>True if optional field is Inserted</returns>
        private bool InsertOptionalField(BaseInvoiceOptionalField newLine, bool isDetailOptionalField)
        {
            var entity = isDetailOptionalField ? _invoiceDetailOptionalField : _invoiceOptionalField;
            if (string.IsNullOrEmpty(newLine.OptionalField))
            { return true; }
            if (isDetailOptionalField)
            {
                _invoiceDetailOptionalFieldMapper.Map(newLine, entity);
            }
            else
            {
                _invoiceOptionalFieldMapper.Map(newLine, entity);
            }
            //The reason for the exists check is that when an exception is thrown, new line will still be true.
            if (!newLine.IsDeleted && !entity.Exists)
            {
                entity.Insert();
            }
            return true;
        }

        /// <summary>
        /// Return HeaderModel
        /// </summary>
        /// <returns>THeader model</returns>
        private THeader ReturnHeaderModel()
        {
            return InvoiceMapper.Map(new List<IBusinessEntity> { _header, _invoiceLine, _invoicePaymentSchedule }, null, null, SetFilter(_invoiceLine, InvoiceLineActiveFilter));
        }

        /// <summary>
        /// Format Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        private static BaseInvoiceOptionalField FormatOptionalFields(BaseInvoiceOptionalField optionalField)
        {
            if (optionalField.Type == Models.Enums.InvoiceEntry.Type.Date)
            {
                optionalField.Value = DateUtil.GetShortDate(optionalField.Value, string.Empty, true);
            }

            if (optionalField.Type != Models.Enums.InvoiceEntry.Type.Time) { return optionalField; }
            if (optionalField.Value != null)
            {
                optionalField.Value = Regex.Replace(optionalField.Value, @"(\w{2})(\w{2})(\w{2})", @"$1:$2:$3");
            }
            return optionalField;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">POOEBaseInvoiceLine model</param>
        private void SyncDetails(IEnumerable<POOEBaseInvoiceLine> details)
        {
            SyncDetailsModels(_invoiceLine, _lineMapper, details);
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">POOEBaseInvoiceReciepts model</param>
        private void SyncMultiReceipts(IEnumerable<POOEBaseInvoiceReciepts> details)
        {
            SyncDetailsModels(_invoiceReciepts, _recieptMapper, details);
        }

        /// <summary>
        /// Synchronizes the detail 2.
        /// </summary>
        /// <param name="details2">The details.</param>
        private void SyncComments(IEnumerable<POOEBaseInvoiceComments> details2)
        {
            SyncDetailsModels(_invoiceComment, _commentMapper, details2);
        }

        /// <summary>
        /// Sync Detail Models
        /// </summary>
        /// <typeparam name="TU">ModelBase</typeparam>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <param name="mapper">TU mapper</param>
        /// <param name="details">List of TU model</param>
        private void SyncDetailsModels<TU>(IBusinessEntity businessEntity, ModelMapper<TU> mapper, IEnumerable<TU> details) where TU : ModelBase, new()
        {
            if (details == null) { return; }

            var allDetails = details as IList<TU> ?? details.ToList();
            var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);

            foreach (
               var detail in
                   allDetails.Where(detail => detail.IsNewLine && !detail.IsDeleted))
            {
                InsertDetailModels(businessEntity, mapper, detail);
            }
            foreach (
                var detail in
                    allDetails.Where(detail => detail.HasChanged || detail.IsDeleted).Where(detail => detail != newLine))
            {
                SyncDetailModels(businessEntity, mapper, detail);
            }
        }

        /// <summary>
        /// Insert Comment/Instruction Line
        /// </summary>
        /// <param name="model">Comment/Instruction</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        private void InsertCommentInstruction(POOEBaseInvoiceComments model, string comment, string lineType)
        {
            if (model.IsDeleted || _invoiceComment.Exists) { return; }
            _invoiceComment.SetValue(Constant.DefaultValue5, lineType);
            _invoiceComment.SetValue(Constant.DefaultValue6, comment);
            _invoiceComment.Insert();
        }

        /// <summary>
        /// Update Comment/Instruction Line
        /// </summary>
        /// <param name="model">Comment/Instruction</param>
        /// <param name="comment">Comment/Instruction to set</param>
        private void SyncCommentInstruction(POOEBaseInvoiceComments model, string comment)
        {
            if (model.IsDeleted && _invoiceComment.Exists)
            {
                _invoiceComment.Delete();
                _invoiceComment.ClearRecord();
            }
            else if (model.IsDeleted)
            {
                _invoiceComment.ClearRecord();
            }
            else if (_invoiceComment.Exists)
            {
                _invoiceComment.SetValue(Constant.DefaultValue6, comment);
                _invoiceComment.Update();
            }
        }

        /// <summary>
        /// Sets the Order of correctly and initializes Header Entity on Process Fail.
        /// </summary>
        /// <param name="exception">BusinessException thrown</param>
        /// <returns>THeader model</returns>
        private THeader OnProcessErrorHandler(BusinessException exception)
        {
            _header.Order = 0;
            _header.Order = 1;
            if (_invoicePaymentSchedule.Exists)
            {
                _invoicePaymentSchedule.Init();
                _invoicePaymentSchedule.Order = 0;
            }
            _invoiceFunction.SetValue(POOEBaseInvoice.BaseFields.InvoiceSequenceKey, 0);
            _header.Order = 0;
            _header.Order = 1;

            if (_invoicePaymentSchedule.Exists)
            {
                _invoicePaymentSchedule.Init();
                _invoicePaymentSchedule.Order = 0;
            }
            var invoiceModel = ReturnHeaderModel();
            invoiceModel.Warnings = exception.Errors;
            return invoiceModel;
        }

        /// <summary>
        /// Creates a entity error based on string and priority
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="priority">Type of Error</param>
        /// <returns>EntityError model</returns>
        private static EntityError CreateEntityError(string message, Priority priority)
        {
            return new EntityError
            {
                Message = message,
                Priority = priority
            };
        }

        /// <summary>
        ///  Fetches Atrtibutes for the Particular detail
        /// </summary>
        /// <typeparam name="TDetail7">Model</typeparam>
        /// <param name="item">Item</param>
        /// <param name="businessEntity">BusinessEntity</param>
        private void SetAttributes(POOEBaseInvoiceLine item, IBusinessEntity businessEntity)
        {
            if (businessEntity.Name.Equals(InvoiceLineEntity))
            {
                var detail = item;
                if (detail != null)
                {
                    var attributes = GetAttributes<TDetail1>(businessEntity);
                    if (!_header.CanModify)
                    {
                        foreach (var attribute in attributes.Where(
                        attribute =>
                            attribute.PropertyName != "OptionalFields"))
                        {
                            attribute.Disabled = true;
                        }
                    }
                    detail.Attributes = ConvertToDynamic(attributes);
                }
            }

        }
        #endregion

        #region Overriden Methods

        /// <summary>
        /// Get Detail Model
        /// </summary>
        /// <param name="header">THeader model</param>
        /// <returns>List of TDetail1</returns>
        protected override IEnumerable<TDetail1> GetDetailModel(THeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Detail2 Model
        /// </summary>
        /// <param name="header">THeader model</param>
        /// <returns>List of TDetail2</returns>
        protected override IEnumerable<TDetail2> GetDetail2Model(THeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Detail3 Model
        /// </summary>
        /// <param name="header">THeader model</param>
        /// <returns>List of TDetail3</returns>
        protected override IEnumerable<TDetail3> GetDetail3Model(THeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Detail4 Model
        /// </summary>
        /// <param name="header">THeader model</param>
        /// <returns>List of TDetail4</returns>
        protected override IEnumerable<TDetail4> GetDetail4Model(THeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Detail5 Model
        /// </summary>
        /// <param name="header">THeader model</param>
        /// <returns>List of TDetail5</returns>
        protected override IEnumerable<TDetail5> GetDetail5Model(THeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process Map
        /// </summary>
        /// <param name="detail">TDetail1 model</param>
        /// <param name="detail1Entity">Detail1 Entity</param>
        protected override void ProcessMap(TDetail1 detail, IBusinessEntity detail1Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process Map
        /// </summary>
        /// <param name="detail2">TDetail2 model</param>
        /// <param name="detail2Entity">Detail2 Entity</param>
        protected override void ProcessMap2(TDetail2 detail2, IBusinessEntity detail2Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process Map
        /// </summary>
        /// <param name="detail3">TDetail3 model</param>
        /// <param name="detail3Entity">Detail3 Entity</param>
        protected override void ProcessMap3(TDetail3 detail3, IBusinessEntity detail3Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process Map
        /// </summary>
        /// <param name="detail4">TDetail4 model</param>
        /// <param name="detail4Entity">Detail4 Entity</param>
        protected override void ProcessMap4(TDetail4 detail4, IBusinessEntity detail4Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Process Map
        /// </summary>
        /// <param name="detail5">TDetail5 model</param>
        /// <param name="detail5Entity">Detail5 Entity</param>
        protected override void ProcessMap5(TDetail5 detail5, IBusinessEntity detail5Entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override SequencedHeaderDetailFiveBusinessEntitySet<THeader, TDetail1, TDetail2, TDetail3, TDetail4, TDetail5> CreateBusinessEntities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Details count from Header
        /// </summary>
        /// <param name="headerEntity">Header Entity</param>
        /// <returns>Number of details</returns>
        protected override int GetDetailCount(IBusinessEntity headerEntity)
        {

            return 0;
        }

        #endregion
    }
}
