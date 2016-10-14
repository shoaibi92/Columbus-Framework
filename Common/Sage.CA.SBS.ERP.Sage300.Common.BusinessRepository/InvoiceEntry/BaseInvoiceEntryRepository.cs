﻿/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.InvoiceEntry
{
    /// <summary>
    /// Base Invoice Entry Repository - Provides Basic Operationss related to invoice entry
    /// </summary>
    /// <typeparam name="TBatch">Batch Entity</typeparam>
    /// <typeparam name="THeader">Header Entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TPayment">Payment Entity</typeparam>
    /// <typeparam name="TDetailOptional">Optional Fields Entity</typeparam>
    public abstract class BaseInvoiceEntryRepository<TBatch, THeader, TDetail, TPayment, TDetailOptional> :
        BatchHeaderDetailRepository<TBatch, THeader, TDetail>, IBaseInvoiceEntryEntity<TBatch, THeader, TDetail>
        where TBatch : BaseInvoiceBatch, new()
        where THeader : BaseInvoice, new()
        where TDetail : BaseInvoiceDetail, new()
        where TPayment : ModelBase, new()
        where TDetailOptional : BaseInvoiceOptionalField, new()
    {

        #region Private Variables

        /// <summary>
        /// Payment Business Entity
        /// </summary>
        private IBusinessEntity _paymentEntity;

        /// <summary>
        /// Payment Mapper - Instance
        /// </summary>
        private ModelMapper<TPayment> _paymentMapper;

        /// <summary>
        /// Detail Business Entity
        /// </summary>
        private IBusinessEntity _detailOptionalEntity;

        /// <summary>
        /// Invoice Business Entity
        /// </summary>
        private IBusinessEntity _headerOptionalEntity;


        /// <summary>
        /// Batch mapper - Instance
        /// </summary>
        protected readonly BaseInvoiceEntryMapper<TBatch, THeader, TDetail, TPayment, TDetailOptional> InvoiceMapper;

        /// <summary>
        /// Composes business entities
        /// </summary>
        /// <returns>Business Entity Session opened</returns>
        protected abstract BaseInvoiceEntryBusinessSet<TBatch, THeader, TDetail, TPayment, TDetailOptional>
            GetInvoiceEntryBusinessSet();

        /// <summary>
        /// Gets the BaseInvoice model from the batch data
        /// </summary>
        /// <param name="batch">TBatch model</param>
        /// <returns>BaseInvoice model</returns>
        protected abstract BaseInvoice GetBaseInvoiceModel(TBatch batch);

        /// <summary>
        /// Gets the details from the Header model.
        /// </summary>
        /// <param name="entry">BaseInvoice model</param>
        /// <returns>List of TDetail</returns>
        protected abstract IEnumerable<BaseInvoiceDetail> GetBaseInvoiceDetailModel(BaseInvoice entry);

        /// <summary>
        /// Gets the Sales Split Model From Header.
        /// </summary>
        /// <param name="header">Base Invoice - Header</param>
        /// <returns>List Of Sales Split</returns>
        protected abstract SalesSplit GetSalesSplitModel(BaseInvoice header);

        /// <summary>
        /// Gets the details from the Header model.
        /// </summary>
        /// <param name="detail">BaseInvoiceDetail model</param>
        /// <returns>List of TDetail</returns>
        protected abstract IEnumerable<BaseInvoiceOptionalField> GetBaseInvoiceOptionalModel(BaseInvoice detail);

        /// <summary>
        /// Instance of Header Mapper
        /// </summary>
        protected ModelMapper<BaseInvoice> InvoiceHeaderMapper;

        /// <summary>
        /// Instance of Detail Mapper
        /// </summary>
        protected ModelMapper<BaseInvoiceDetail> InvoiceDetailMapper;

        /// <summary>
        /// Instance of Invoice Optional Field Mapper
        /// </summary>
        protected ModelMapper<BaseInvoiceOptionalField> InvoiceOptFieldMapper;

        /// <summary>
        /// Instance of Invoice Detail Optional Field Mapper
        /// </summary>
        protected ModelMapper<BaseInvoiceOptionalField> InvoiceDetailOptFieldMapper;

        #endregion

        #region Constructors

        /// <summary>
        /// BaseInvoiceEntryRepository Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        protected BaseInvoiceEntryRepository(Context context,
            BaseInvoiceEntryMapper<TBatch, THeader, TDetail, TPayment, TDetailOptional> mapper)
            : base(context, mapper)
        {
            ValidRecordFilter = x => x.BatchNumber > 0;
            InvoiceMapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = GetInvoiceEntryBusinessSet();
            SetAdditionalBusinessEntity(businessEntitySet);
        }

        /// <summary>
        /// BaseInvoiceEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="session">Session to be used</param>
        protected BaseInvoiceEntryRepository(Context context,
            BaseInvoiceEntryMapper<TBatch, THeader, TDetail, TPayment, TDetailOptional> mapper,
            IBusinessEntitySession session)
            : base(context, mapper, session)
        {
            ValidRecordFilter = x => x.BatchNumber > 0;
            InvoiceMapper = mapper;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            var businessEntitySet = GetInvoiceEntryBusinessSet();
            SetAdditionalBusinessEntity(businessEntitySet);
        }

        /// <summary>
        /// BaseInvoiceEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        protected BaseInvoiceEntryRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// BaseInvoiceEntryRepository Contructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        protected BaseInvoiceEntryRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new batch and new header
        /// </summary>
        /// <returns>Returns the batch and header Entity</returns>
        public override TBatch NewBatch()
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);
            ClearBusinessEntities(ClearLevel.Batch);

            BatchEntity.RecordCreate(ViewRecordCreate.Insert);

            BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.ProcessCommandCode, Constant.DefaultValue1);
            BatchEntity.Process();
            BatchEntity.Read(false);

            HeaderEntity.RecordCreate(ViewRecordCreate.DelayKey);

            DetailEntity.Cancel();

            var batchModel = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
            return !HeaderEntity.Exists ? EntryNumberUpdate(batchModel) : batchModel;
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>TBatch.</returns>
        public override TBatch NewHeader()
        {
            CheckRights(HeaderEntity, SecurityType.Modify);
            ClearBusinessEntities(ClearLevel.Header);
            HeaderEntity.RecordCreate(ViewRecordCreate.DelayKey);
            var batchModel = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
            return !HeaderEntity.Exists ? EntryNumberUpdate(batchModel) : batchModel;
        }

        /// <summary>
        /// Adds Entry 
        /// </summary>
        /// <param name="model">Batch model</param>
        /// <returns>Batch model</returns>
        public override TBatch Add(TBatch model)
        {
            IsSessionAvailable();
            return HeaderEntity.Exists ? SaveInvoiceBatch(model) : AddInvoiceBatch(model);
        }

        /// <summary>
        /// Updates Entry model
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>TBatch model</returns>
        public override TBatch Save(TBatch model)
        {
            IsSessionAvailable();
            //This logic is added for prepayment, where the entity is getting cleared after printing the check.
            //This currently solves the issue but have to come back and figure out why entity was getting cleared first place.
            if (Convert.ToInt16(HeaderEntity.Fields.FieldByID(1).Value) == 0)
            {
                GetByIds(model.BatchNumber, model.Invoices.EntryNumber);
            }
            return HeaderEntity.Exists ? SaveInvoiceBatch(model) : AddInvoiceBatch(model);
        }

        /// <summary>
        /// Get first of default Invoice Batch
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">order by</param>
        /// <returns>TBatch.</returns>
        public override TBatch FirstOrDefault(Expression<Func<TBatch, bool>> filter = null, OrderBy orderBy = null)
        {
            IsSessionAvailable();
            var invoiceBatch = base.FirstOrDefault(filter, orderBy);
            return invoiceBatch != null ? AddDefaultDetailsToInvoiceBatch(invoiceBatch) : null;

        }

        /// <summary>
        /// Gets Batch Info by Batch Number
        /// </summary>
        /// <typeparam name="TKey">type of the key</typeparam>
        /// <param name="key">key value</param>
        /// <returns>Batch Information</returns>
        public override TBatch GetById<TKey>(TKey key)
        {
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            var fields = GetKeyField(BatchEntity);
            //Assumes Batch key is at 1
            BatchEntity.SetValue(fields[0].ID, key);
            BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.ProcessCommandCode, Constant.DefaultValue1);
            BatchEntity.Process();
            if (!BatchEntity.Read(false))
            {
                return null;
            }

            HeaderEntity.Top();
            HeaderEntity.Browse("", true);
            HeaderEntity.Fetch(false);
            HeaderEntity.Read(false);
            DetailEntity.Top();

            var invoiceBatch = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });

            return invoiceBatch != null ? AddDefaultDetailsToInvoiceBatch(invoiceBatch) : null;

        }

        /// <summary>
        /// Derives Rate Information
        /// </summary>
        /// <returns>Header model</returns>
        public virtual THeader DeriveRate()
        {
            IsSessionAvailable();
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue6, HeaderEntity);
            HeaderEntity.Process();
            var headerModel = HeaderMapper.Map(HeaderEntity);
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;
        }

        /// <summary>
        /// Maps Tax Group Authority to Header model
        /// </summary>
        /// <param name="model">Tax Group Authority model</param>
        /// <param name="isDetailTaxData">Is Request for detail tax data</param>
        /// <returns>THeader model</returns>
        public virtual THeader SetTaxGroupAuthority(TaxGroupAuthority model, bool isDetailTaxData)
        {
            IsSessionAvailable();
            InvoiceMapper.SetTaxGroupAuthority(model, isDetailTaxData ? DetailEntity : HeaderEntity, isDetailTaxData);
            THeader headerModel;
            if (isDetailTaxData)
            {
                if (DetailEntity.Name != "AR0033")
                {
                    headerModel = new THeader
                    {
                        InvoiceDetails =
                            new EnumerableResponse<BaseInvoiceDetail>
                            {
                                Items =
                                    new List<BaseInvoiceDetail>
                                    {
                                        new BaseInvoiceDetail
                                        {
                                            DetailTaxes =
                                                InvoiceMapper.GetDetailTaxAuthority(
                                                    InvoiceDetailMapper.Map(DetailEntity), HeaderEntity),
                                            TaxTotal =
                                                DetailEntity.GetValue<decimal>(BaseInvoiceDetail.BaseFields.TaxTotal),
                                            TaxReportingTotal =
                                                DetailEntity.GetValue<decimal>(
                                                    BaseInvoiceDetail.BaseFields.TaxReportingTotal),
                                            RetainageTaxTotal =
                                                DetailEntity.GetValue<decimal>(
                                                    BaseInvoiceDetail.BaseFields.RetainageTaxTotal),
                                        }
                                    }
                            }
                    };
                }
                else
                {
                    var items = InvoiceDetailMapper.Map(DetailEntity);
                    items.DetailTaxes = InvoiceMapper.GetDetailTaxAuthority(items, HeaderEntity);
                    headerModel = new THeader
                    {
                        InvoiceDetails =
                            new EnumerableResponse<BaseInvoiceDetail>
                            {
                                Items =
                                    new List<BaseInvoiceDetail>
                                    {
                                        items
                                    }
                            }
                    };
                }
            }
            else
            {
                headerModel = HeaderMapper.Map(HeaderEntity);              
            }
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;
        }

        /// <summary>
        /// Gets Updated Theader Model after Tax Group is set
        /// </summary>
        /// <param name="id">Tax Group.</param>
        /// <returns>THeader Model</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetTaxAuthorities(string id)
        {
            IsSessionAvailable();
            InvoiceMapper.MapTaxGroup(id, HeaderEntity);
            var headerModel = HeaderMapper.Map(HeaderEntity);
            if (!HeaderEntity.Exists)
            {
                headerModel = EntryNumberUpdate(headerModel);
            }
            return InvoiceMapper.GetTaxAuthority(headerModel);
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual TBatch SetDetail(BaseInvoiceDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail == null)
                return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                    SetFilter(DetailEntity, DetailActiveFilter));
            InvoiceDetailMapper.MapKey(currentDetail, DetailEntity);
            if (!DetailEntity.Exists)
                return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                    SetFilter(DetailEntity, DetailActiveFilter));
            DetailEntity.Read(false);
            InvoiceDetailMapper.Map(currentDetail, DetailEntity);
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                SetFilter(DetailEntity, DetailActiveFilter));
        }

        /// <summary>
        /// Gets Batch & Entry Info By Ids
        /// </summary>
        /// <typeparam name="TBatchKey">type of the t batch key.</typeparam>
        /// <typeparam name="THeaderKey">type of the t header key.</typeparam>
        /// <param name="batchKey">batch key.</param>
        /// <param name="headerKey">header key.</param>
        /// <returns>TBatch.</returns>
        public virtual TBatch GetByIds<TBatchKey, THeaderKey>(TBatchKey batchKey, THeaderKey headerKey)
        {
            CheckRights(BatchEntity, SecurityType.Inquire);
            CheckRights(HeaderEntity, SecurityType.Inquire);

            InvoiceMapper.MapBatchNumber(batchKey.ToString(), BatchEntity);
            BatchEntity.Read(false);
            InvoiceMapper.MapBatchNumber(batchKey.ToString(), HeaderEntity);
            InvoiceMapper.MapEntryNumber(headerKey.ToString(), HeaderEntity);
            if (HeaderEntity.Read(false))
            {
                DetailEntity.Top();

                return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
            }
            var entityErrors = new List<EntityError>
            {
                new EntityError {Message = CommonResx.NotFoundMessage, Priority = Priority.Error}
            };
            throw ExceptionHelper.BusinessException(entityErrors);
        }

        /// <summary>
        /// Gets the list of Invoice details optional fields
        /// </summary>
        /// <param name="id">Tax Group.</param>
        /// <returns>List of invoice detail optional fields</returns>
        public virtual EnumerableResponse<TPayment> GetInvoicePaymentSchedules(string id)
        {

            IsSessionAvailable();
            var paymentSchedules = new List<TPayment>();
            var index = 0;
            InvoiceMapper.MapPaymentSchedule(id, new List<IBusinessEntity> { HeaderEntity, _paymentEntity });
            _paymentEntity.Browse("", true);
            if (_paymentEntity.Fetch(false))
            {
                do
                {
                    var data = _paymentMapper.Map(_paymentEntity);
                    data.DisplayIndex = ++index;
                    paymentSchedules.Add(data);
                } while (_paymentEntity.Next());
            }

            return new EnumerableResponse<TPayment>
            {
                Items = paymentSchedules,
                TotalResultsCount = paymentSchedules.Count
            };
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
                InvoiceMapper.MapOptionalField(null, _detailOptionalEntity);
                _detailOptionalEntity.Browse("", true);
                _detailOptionalEntity.Fetch(false);
                return RetrieveOptionalField(pageNumber, pageSize, _detailOptionalEntity, InvoiceDetailOptFieldMapper, 0);
            }
            InvoiceMapper.MapOptionalField(null, _headerOptionalEntity);
            _headerOptionalEntity.Browse("", true);
            _headerOptionalEntity.Fetch(false);
            return RetrieveOptionalField(pageNumber, pageSize, _headerOptionalEntity, InvoiceOptFieldMapper, 0);
        }

        /// <summary>
        /// To add Invoice detail optional fields
        /// </summary>
        /// <param name="currentOptionalField">Current Base Invoice Optional Field</param>
        /// <returns>List of Invoice detail optional fields</returns>
        public virtual BaseInvoiceOptionalField NewOptionalField(BaseInvoiceOptionalField currentOptionalField)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify, Security.TransactionalOptionalField);

            if (currentOptionalField != null)
            {
                InvoiceOptFieldMapper.MapKey(currentOptionalField, _detailOptionalEntity);
                if (!currentOptionalField.IsNewLine && _detailOptionalEntity.Exists)
                {
                    _detailOptionalEntity.Read(false);
                    InvoiceOptFieldMapper.Map(currentOptionalField, _detailOptionalEntity);
                    _detailOptionalEntity.Update();
                }
                else if (currentOptionalField.IsNewLine)
                {
                    InvoiceOptFieldMapper.Map(currentOptionalField, _detailOptionalEntity);
                    _detailOptionalEntity.Insert();
                }

            }

            _detailOptionalEntity.RecordCreate(ViewRecordCreate.NoInsert);
            return InvoiceOptFieldMapper.Map(_detailOptionalEntity);
        }

        /// <summary>
        /// Save Optional Field
        /// </summary>
        /// <param name="optionalField">List of BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SaveOptionalField(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            if (optionalField.IsNewLine)
            {
                InsertOptionalField(optionalField, optionalField.IsDetailOptionalField);
            }
            else
            {
                SyncOptionalField(optionalField, optionalField.IsDetailOptionalField);
            }


            var invoiceDetailOptionalField = InvoiceOptFieldMapper.Map(_detailOptionalEntity);
            invoiceDetailOptionalField.IsNewLine = false;
            return invoiceDetailOptionalField;
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
        /// Refreshes the specified batch.
        /// </summary>
        /// <param name="batch">The batch.</param>
        public override TBatch Refresh(TBatch batch)
        {
            IsSessionAvailable();
            Mapper.Map(batch, new List<IBusinessEntity> { BatchEntity, HeaderEntity });
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                SetFilter(DetailEntity, DetailActiveFilter));

        }

        /// <summary>
        /// Refreshes the specified batch.
        /// </summary>
        public virtual TBatch UpdatedModel()
        {
            IsSessionAvailable();
            var invoiceModel = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity }, null,
                null, SetFilter(DetailEntity, DetailActiveFilter));
            if (!HeaderEntity.Exists)
            {
                return EntryNumberUpdate(invoiceModel);
            }
            return invoiceModel;
        }

        /// <summary>
        /// To set the changed value and get the model
        /// </summary>
        /// <param name="value">value to be set</param>
        /// <param name="property">Property to be set</param>
        /// <returns>refreshed model</returns>
        public virtual THeader RefreshHeader(string value, string property)
        {
            IsSessionAvailable();
            switch (property)
            {
                //Terms Tab 
                case InvoiceEntryConstants.DateFields.DiscountDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DiscountDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.DiscountPercentage:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DiscountPercentage,
                        string.IsNullOrEmpty(value) ? "0" : value, true);
                    break;
                case InvoiceEntryConstants.DiscountAmount:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DiscountAmountAvailable,
                        string.IsNullOrEmpty(value) ? "0" : value, true);
                    break;
                case InvoiceEntryConstants.DiscountBase:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DiscountBase, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.DateFields.DueDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DueDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.DateFields.AsofDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.AsofDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.TermsCode:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.Terms, value, true);
                    break;
                //Terms Tab Ends Here
                case InvoiceEntryConstants.TaxReportingRateType:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxReportingRateType, value, true);
                    break;
                case InvoiceEntryConstants.DateFields.TaxReportingRateDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxReportingRateDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.RemitToLocation:
                    InvoiceMapper.MapRemitToLocation(value, HeaderEntity);
                    InvoiceMapper.MapProcessCommand(Constant.DefaultValue4, HeaderEntity);
                    HeaderEntity.Process();
                    break;
                case InvoiceEntryConstants.DistributionSet:
                    InvoiceMapper.MapDistributionSet(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.RateType:
                    InvoiceMapper.MapRateType(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.DateFields.RateDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.RateDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.Retainage:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.HasRetainage, value, true);
                    break;
                case InvoiceEntryConstants.Terms:
                    InvoiceMapper.MapTerms(value, property, HeaderEntity);
                    return InvoiceMapper.MapGetTerms(HeaderEntity);
                case InvoiceEntryConstants.OnHold:
                    InvoiceMapper.MapOnHold(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.AccountSet:
                    InvoiceMapper.MapAccountSet(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.DateFields.DocumentDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DocumentDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.DateFields.PostingDate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.PostingDate, DateUtil.GetDate(value, null), true);
                    break;
                case InvoiceEntryConstants.DateFields.BatchDate:
                    BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.BatchDate,DateUtil.GetDate(value, null), true);
                    BatchEntity.Update();
                    BatchEntity.Read(false);
                    if (BatchEntity.GetValue<int>(BaseInvoiceBatch.BaseFields.NumberOfEntries) == 0)
                    {
                        HeaderEntity.RecordCreate(ViewRecordCreate.DelayKey);
                    }
                    break;
                case InvoiceEntryConstants.BatchDescription:
                    BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.Description, value);
                    BatchEntity.Update();
                    break;
                case InvoiceEntryConstants.RetainageTerms:
                    InvoiceMapper.MapTerms(value, property, HeaderEntity);
                    break;
                case InvoiceEntryConstants.TaxGroup:
                    InvoiceMapper.MapTaxGroup(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.DocumentNumber:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DocumentNumber, value, true);
                    break;
                case InvoiceEntryConstants.ApplyToDocument:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.ApplytoDocument, value, true);
                    break;
                case InvoiceEntryConstants.OriginialDocumentNumber:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.OriginalDocNo, value, true);
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.ProcessCommandCode, Constant.DefaultValue4);
                    HeaderEntity.Process();
                    break;
                case InvoiceEntryConstants.TaxBase1:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxBase1, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.TaxBase2:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxBase2, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.TaxBase3:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxBase3, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.TaxBase4:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxBase4, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.TaxBase5:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxBase5, string.IsNullOrEmpty(value) ? "0" : value,
                        true);
                    break;
                case InvoiceEntryConstants.RetainageTermsCode:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.RetainageTermsCode, value, true);
                    break;
                case InvoiceEntryConstants.RetainageExchangeRate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.RetainageExchangeRate,
                        string.IsNullOrEmpty(value) ? 0 : (RetainageExchangeRate)Convert.ToInt16(value), true);
                    break;
                case InvoiceEntryConstants.TaxReportingExchangeRate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.TaxReportingExchangeRate,
                        string.IsNullOrEmpty(value) ? 0 : Convert.ToDecimal(value), true);
                    break;
                case InvoiceEntryConstants.RateExchangeRate:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.ExchangeRate,
                        string.IsNullOrEmpty(value) ? 0 : Convert.ToDecimal(value), true);
                    break;
                case InvoiceEntryConstants.DocumentTotalIncludingTax:
                    InvoiceMapper.MapDocumentTotal(value, HeaderEntity);
                    break;
                case InvoiceEntryConstants.InvoiceDescription:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.InvoiceDescription, value);
                    break;
                case InvoiceEntryConstants.PONumber:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.APPONumber, value);
                    break;
                case InvoiceEntryConstants.OrderNumber:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.OrderNumber, value);
                    break;
                case InvoiceEntryConstants.InvoiceType:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.InvoiceType, value);
                    break;
                case InvoiceEntryConstants.DocumentType:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DocumentType, value);
                    break;
                case InvoiceEntryConstants._1099CPRS:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.Num1099OrCPRSCode, value, true);
                    break;
                case InvoiceEntryConstants._1099CPRSAmount:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.Num1099OrCPRSAmount,
                        string.IsNullOrEmpty(value) ? "0" : value, true);
                    break;
                case InvoiceEntryConstants.DistributionSetAmount:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.DistributionSetAmount,
                        string.IsNullOrEmpty(value) ? "0" : value, true);
                    break;
                case BaseInvoice.BaseFields.PrepaymentNumber:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.PrepaymentNumber, value, true);
                    HeaderEntity.Update();
                    break;
                case BaseInvoice.BaseFields.PrepaymentAmount:
                    HeaderEntity.SetValue(BaseInvoice.BaseFields.PrepaymentAmount, decimal.Parse(value), true);
                    HeaderEntity.Update();
                    break;
            }

            var headerModel = HeaderMapper.Map(HeaderEntity);
            if (!property.Equals(InvoiceEntryConstants.TaxGroup))
                return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;
            var warnings = headerModel.Warnings.ToList();
            var error = new EntityError { Priority = Priority.Warning, Message = InvoiceResx.VerifyTaxGroupMessage };
            warnings.Insert(0, error);
            headerModel.Warnings = warnings;
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;
        }

        /// <summary>
        /// Refreshs the Invoice Detail
        /// </summary>
        /// <param name="detail">BaseInvoiceDetail model</param>
        /// <param name="eventType">Property that changed</param>
        /// <returns>BaseInvoiceDetail model</returns>
        public virtual BaseInvoice RefreshDetail(BaseInvoiceDetail detail, string eventType)
        {

            IsSessionAvailable();
            var commentsValue = DetailEntity.GetValue<string>(BaseInvoiceDetail.BaseFields.Comment);
            InvoiceDetailMapper.MapKey(detail, DetailEntity);
            if (DetailEntity.Exists)
            {
                DetailEntity.Read(false);
            }
            string dataToUpper;
            switch (eventType)
            {
                case InvoiceEntryConstants.DetailFields.DistributionCode:
                    dataToUpper = detail.DistributionCode != null
                        ? detail.DistributionCode.ToUpper()
                        : detail.DistributionCode;
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.DistributionCode, dataToUpper, true);
                    break;
                case InvoiceEntryConstants.DetailFields.Description:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.DistributionDescription,
                        detail.DistributionDescription, true);
                    break;
                case InvoiceEntryConstants.DetailFields.GLAccount:
                    dataToUpper = detail.GLAccount != null ? detail.GLAccount.ToUpper() : detail.GLAccount;
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.GLAccount, dataToUpper, true);
                    break;
                case InvoiceEntryConstants.DetailFields.Discountable:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.Discountable, detail.Discountable);
                    break;
                case InvoiceEntryConstants.DetailFields.Comment:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.Comment, detail.Comment);
                    commentsValue = DetailEntity.GetValue<string>(BaseInvoiceDetail.BaseFields.Comment);
                    break;
                case InvoiceEntryConstants.DetailFields.RetainageDueDate:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.RetainageDueDate, detail.RetainageDueDate, true);
                    break;
                case InvoiceEntryConstants.DetailFields.DaysRetained:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.DaysRetained, detail.DaysRetained, true);
                    break;
                case InvoiceEntryConstants.DetailFields.RetainageAmount:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.RetainageAmount, detail.RetainageAmount, true);
                    break;
                case InvoiceEntryConstants.DetailFields.PercentRetained:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.PercentRetained, detail.PercentRetained, true);
                    break;
                case InvoiceEntryConstants.DetailFields.DistributionAmount:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.DistributedAmount, detail.DistributedAmount, true);
                    break;
                case InvoiceEntryConstants.DetailFields.OriginalLineIdentifier:
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.OriginalLineIdentifier,
                        detail.OriginalLineIdentifier, true);
                    DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.ProcessCommandCode, Constant.DefaultValue0);
                    DetailEntity.Process();
                    break;
            }
            if (DetailEntity.Exists)
            {
                DetailEntity.Update();
            }
            else if (eventType == InvoiceEntryConstants.DetailFields.DistributionAmount && detail.IsNewLine)
            {
                // save the detail only if it is a new line and the distribution amount is being updated.
                DetailEntity.Insert();
            }

            DetailEntity.SetValue(BaseInvoiceDetail.BaseFields.Comment, commentsValue);
            var detailData = InvoiceDetailMapper.Map(DetailEntity);
            var headerData = HeaderMapper.Map(HeaderEntity);
            if (!HeaderEntity.Exists)
            {
                headerData = EntryNumberUpdate(headerData);
            }
            headerData.InvoiceDetails = new EnumerableResponse<BaseInvoiceDetail>
            {
                Items = new List<BaseInvoiceDetail> { detailData }
            };
            return headerData;

        }

        /// <summary>
        /// Save Details
        /// </summary>
        /// <param name="details">List of BaseInvoiceDetail model</param>
        /// <returns>Boolean model</returns>
        public virtual bool SaveDetails(IEnumerable<BaseInvoiceDetail> details)
        {
            IsSessionAvailable();
            return SyncDetails(details);
        }

        /// <summary>
        /// Changes Vendor
        /// </summary>
        /// <param name="id">Vendor number</param>
        /// <returns>THeader model</returns>
        public virtual THeader ChangeVendor(string id)
        {
            //To Move to mapper
            IsSessionAvailable();
            InvoiceMapper.MapVendor(id, HeaderEntity);
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue7, HeaderEntity);
            HeaderEntity.Process();
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue4, HeaderEntity);
            HeaderEntity.Process();

            var headerModel = HeaderMapper.Map(HeaderEntity);
            if (!HeaderEntity.Exists)
            {
                return EntryNumberUpdate(headerModel);
            }
            return headerModel;
        }

        /// <summary>
        /// On change of Document Type returns updated header model
        /// </summary>
        /// <param name="documentType">Document Type string</param>
        /// <returns>THeader model</returns>
        public virtual THeader ChangeDocumentType(DocumentType documentType)
        {
            IsSessionAvailable();
            InvoiceMapper.MapDocumentType(documentType, HeaderEntity);
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue7, HeaderEntity);
            HeaderEntity.Process();
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue4, HeaderEntity);
            HeaderEntity.Process();
            var headerModel = HeaderMapper.Map(HeaderEntity);
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;

        }

        /// <summary>
        /// Check if Multicurrency is available
        /// </summary>
        /// <returns>true/false</returns>
        public virtual bool GetMultiCurrency()
        {
            IsSessionAvailable();
            return Session.IsMultiCurrency;
        }

        /// <summary>
        /// Set Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalField(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            var entity = optionalField.IsDetailOptionalField ? _detailOptionalEntity : _headerOptionalEntity;
            var entityMapper = optionalField.IsDetailOptionalField ? InvoiceDetailOptFieldMapper : InvoiceOptFieldMapper;
            InvoiceMapper.MapOptionalField(optionalField, entity);
            var updatedOptionalField = entityMapper.Map(entity);
            return FormatOptionalFields(updatedOptionalField);
        }

        /// <summary>
        /// Check whether the optional field exists
        /// </summary>
        /// <returns>Boolean value</returns>
        public virtual bool IsOptionalFieldExists(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            var entity = optionalField.IsDetailOptionalField ? _detailOptionalEntity : _headerOptionalEntity;
            var entityMapper = optionalField.IsDetailOptionalField ? InvoiceDetailOptFieldMapper : InvoiceOptFieldMapper;
            entityMapper.Map(optionalField, entity);
            return entity.Exists;
        }

        /// <summary>
        /// Set Optional Field Value
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField SetOptionalFieldValue(BaseInvoiceOptionalField optionalField)
        {
            IsSessionAvailable();
            var entity = optionalField.IsDetailOptionalField ? _detailOptionalEntity : _headerOptionalEntity;
            var entityMapper = optionalField.IsDetailOptionalField ? InvoiceDetailOptFieldMapper : InvoiceOptFieldMapper;
            entityMapper.MapKey(optionalField, entity);
            entity.Read(false);

            switch (optionalField.Type)
            {
                case Models.Enums.InvoiceEntry.Type.Text:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.TextValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.Integer:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.IntegerValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.Amount:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.AmountValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.Number:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.NumberValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.Date:
                    if (optionalField.Value == string.Empty)
                    {
                        optionalField.Value = null;
                    }
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.DateValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.Time:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.TimeValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
                case Models.Enums.InvoiceEntry.Type.YesOrNo:
                    entity.SetValue(BaseInvoiceOptionalField.BaseFields.YesOrNoValue, optionalField.Value,
                        optionalField.Validate == BatchPrintedFlag.Yes);
                    break;
            }

            var updatedOptionalField = entityMapper.Map(entity);
            updatedOptionalField.HasChanged = false;
            return FormatOptionalFields(updatedOptionalField);
        }

        /// <summary>
        /// Delete Optional Field
        /// </summary>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        public virtual BaseInvoiceOptionalField DeleteOptionalField(List<BaseInvoiceOptionalField> model)
        {
            IsSessionAvailable();
            foreach (var optionalField in model.Where(optionalField => optionalField.IsDeleted))
            {
                CheckRights(GetAccessRights(), SecurityType.Modify, Security.TransactionalOptionalField);
                InvoiceOptFieldMapper.MapKey(optionalField, _detailOptionalEntity);
                if (_detailOptionalEntity.Read(false))
                {
                    _detailOptionalEntity.Delete();
                }
                _detailOptionalEntity.ClearRecord();
                if (DetailEntity.Exists)
                    DetailEntity.Update();
            }

            var invoiceDetailOptionalField = InvoiceOptFieldMapper.Map(_detailOptionalEntity);
            return invoiceDetailOptionalField;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override TBatch Delete(Expression<Func<TBatch, bool>> filter)
        {
            IsSessionAvailable();
            CheckRights(GetAccessRights(), SecurityType.Modify);
            if (HeaderEntity.Exists)
            {
                HeaderEntity.Delete();
                if (HeaderEntity.Next())
                {
                    var model = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
                    return !HeaderEntity.Exists ? EntryNumberUpdate(model) : model;
                }
                if (!HeaderEntity.Previous()) return NewHeader();
                var batchModel = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
                return !HeaderEntity.Exists ? EntryNumberUpdate(batchModel) : batchModel;
            }

            var entityErrors = new List<EntityError>
            {
                new EntityError {Message = CommonResx.DeleteFailedNoRecordMessage, Priority = Priority.Error}
            };
            throw ExceptionHelper.BusinessException(entityErrors);

        }

        /// <summary>
        /// Updates the Tax tab Calculate or Distribute Button is clicked. 
        /// </summary>
        /// <param name="processType">Type of Process the header should Perform</param>
        /// <returns>Invoices model</returns>
        public virtual THeader TaxRefresh(int processType)
        {
            IsSessionAvailable();
            //To set to a specific payment number 
            InvoiceMapper.MapProcessCommand(processType, HeaderEntity);
            HeaderEntity.Process();
            var headerModel = HeaderMapper.Map(HeaderEntity);
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;

        }

        /// <summary>
        /// Updates Terms Payment Schedule grid. 
        /// </summary>
        /// <param name="model">THeader model</param>
        /// <returns>THeader model</returns>
        public virtual THeader UpdateTaxCalculateType(THeader model)
        {
            IsSessionAvailable();
            // To set only the changed data
            //Move to Batch Mapper
            InvoiceMapper.MapTaxCalculateType(model, HeaderEntity);
            var headerModel = HeaderMapper.Map(HeaderEntity);
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;

        }

        /// <summary>
        /// Creates the distribution codes based on distribution set chosen. 
        /// </summary>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <returns>THeader model</returns>
        public virtual THeader CreateDistribution(string documentTotalIncludingTax, string distributionSetAmount)
        {
            IsSessionAvailable();
            InvoiceMapper.MapDistribution(documentTotalIncludingTax, distributionSetAmount, HeaderEntity);
            InvoiceMapper.MapProcessCommand(Constant.DefaultValue3, HeaderEntity);
            HeaderEntity.Process();

            var headerModel = HeaderMapper.Map(HeaderEntity);
            return !HeaderEntity.Exists ? EntryNumberUpdate(headerModel) : headerModel;

        }

        /// <summary>
        /// Creates a new Detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>TDetail.</returns>
        public virtual TBatch NewDetail(int pageNumber, int pageSize, BaseInvoiceDetail currentDetail)
        {
            IsSessionAvailable();
            if (currentDetail != null)
            {
                InvoiceDetailMapper.MapKey(currentDetail, DetailEntity);
                if (currentDetail.HasChanged && !currentDetail.IsNewLine && DetailEntity.Exists)
                {
                    DetailEntity.Read(false);
                    InvoiceDetailMapper.Map(currentDetail, DetailEntity);
                    DetailEntity.Update();
                }
                else if (currentDetail.IsNewLine && !DetailEntity.Exists)
                {
                    //Have removed map because there is no need to Map all the data for insert has it will be already set to entity.
                    //If user clicks on add line directly instead of tabbing out the values will not be present in model and .Insert will throw an issue.
                    DetailEntity.Insert();
                }
            }
            //ClearBusinessEntities(ClearLevel.Detail);
            DetailEntity.RecordCreate(ViewRecordCreate.NoInsert);
            InvoiceMapper.MapDetailProcessCmd(0, DetailEntity);
            DetailEntity.Process();
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                SetFilter(DetailEntity, DetailActiveFilter));
        }

        /// <summary>
        /// Save for detail Entry
        /// </summary>
        /// <param name="detail">BaseInvoiceDetail model</param>
        /// <returns>TBatch model</returns>
        public virtual TBatch SaveDetail(BaseInvoiceDetail detail)
        {
            IsSessionAvailable();
            if (detail.IsNewLine)
            {
                InsertDetail(detail);
            }
            else
            {
                SyncDetail(detail);
            }
            return Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity }, null, null,
                SetFilter(DetailEntity, DetailActiveFilter));
        }

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <returns>Enumerable Response of TaxGroupAuthority model</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(BaseInvoiceDetail model)
        {
            IsSessionAvailable();
            var taxGroup = HeaderEntity.GetValue<string>(BaseInvoice.BaseFields.TaxGroup);
            InvoiceMapper.MapTaxGroup(taxGroup, HeaderEntity);
            InvoiceDetailMapper.MapKey(model, DetailEntity);

            return InvoiceMapper.GetDetailTaxAuthority(model, HeaderEntity);
        }

        /// <summary>
        /// Unlock Batch Resource when exiting the screen
        /// </summary>
        public virtual void UnlockBatchResource()
        {
            BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.BatchNumber, Constant.DefaultValue0);
            BatchEntity.SetValue(BaseInvoiceBatch.BaseFields.ProcessCommandCode, Constant.DefaultValue1);
            BatchEntity.Process();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Clears the business entities.
        /// </summary>
        private void ClearBusinessEntities(ClearLevel clearLevel)
        {
            switch (clearLevel)
            {
                case ClearLevel.Batch:
                    BatchEntity.Cancel();
                    HeaderEntity.Cancel();
                    DetailEntity.Cancel();
                    break;
                case ClearLevel.Header:
                    HeaderEntity.Cancel();
                    HeaderEntity.Cancel();
                    break;
                case ClearLevel.Detail:
                    DetailEntity.Cancel();
                    break;
            }

        }

        /// <summary>
        /// Adds model
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TBatch.</returns>
        private TBatch AddInvoiceBatch(TBatch model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);

            // Commented because we should not call Batch Update before Adding an Invoice (Vefified using RVSpy)
            BatchMapper.Map(model, BatchEntity);
            BatchEntity.Update();

            var header = GetBaseInvoiceModel(model);

            var salesSplit = GetSalesSplitModel(header);
            var details = GetBaseInvoiceDetailModel(header);
            var optionalField = GetBaseInvoiceOptionalModel(header).ToList();
            if (!HeaderEntity.Exists)
            {
                var baseInvoiceDetails = details as BaseInvoiceDetail[] ?? details.ToArray();
                SyncOptionalFields(optionalField, false);
                SyncDetails(baseInvoiceDetails);
                if (salesSplit != null)
                {
                    InvoiceMapper.MapSalesSplit(salesSplit, HeaderEntity);
                }
                //header.NumberOfDetails = baseInvoiceDetails.Count();
                InvoiceHeaderMapper.Map(header, HeaderEntity);
                HeaderEntity.Insert();
            }
            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError
                    {
                        Message = string.Format(CommonResx.UpdateFailedMessage, CommonResx.HeaderEntity),
                        Priority = Priority.Error
                    }
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }

            DetailEntity.Top();
            return NewHeader();
        }

        /// <summary>
        /// Updates the model, this even takes care of Save for details optional field as well.
        /// </summary>
        /// <param name="model">TBatch model.</param>
        /// <returns>TBatch model.</returns>
        public virtual TBatch SaveInvoiceBatch(TBatch model)
        {
            CheckRights(GetAccessRights(), SecurityType.Modify);


            BatchMapper.Map(model, BatchEntity);
            BatchEntity.Update();

            var header = GetBaseInvoiceModel(model);

            var salesSplit = GetSalesSplitModel(header);
            IEnumerable<BaseInvoiceDetail> details = new List<BaseInvoiceDetail>();
            IEnumerable<BaseInvoiceOptionalField> optionalField = new List<BaseInvoiceOptionalField>();
            if (header.InvoiceDetails != null)
            {
                details = GetBaseInvoiceDetailModel(header).ToList();
            }
            if (header.OptionalFieldList != null)
            {
                optionalField = GetBaseInvoiceOptionalModel(header).ToList();
            }
            if (HeaderEntity.Exists)
            {
                SyncOptionalFields(optionalField, false);
                SyncDetails(details);
                DetailEntity.Top();
                if (details.Any())
                {
                    DetailEntity.Update();
                }
                if (salesSplit != null)
                {
                    InvoiceMapper.MapSalesSplit(salesSplit, HeaderEntity);
                }
                InvoiceHeaderMapper.Map(header, HeaderEntity);
                HeaderEntity.Update();
            }
            else
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError
                    {
                        Message = string.Format(CommonResx.UpdateFailedMessage, CommonResx.HeaderEntity),
                        Priority = Priority.Error
                    }
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }



            var batchModel = Mapper.Map(new List<IBusinessEntity> { BatchEntity, HeaderEntity, DetailEntity });
            return !HeaderEntity.Exists ? EntryNumberUpdate(batchModel) : batchModel;
        }

        /// <summary>
        /// Adds default values to invoice batch
        /// </summary>
        /// <param name="invoiceBatch">TBatch model</param>
        /// <returns>TBatch model.</returns>
        private TBatch AddDefaultDetailsToInvoiceBatch(TBatch invoiceBatch)
        {
            if ((string.IsNullOrEmpty(invoiceBatch.Invoices.EntryNumber) || invoiceBatch.Invoices.EntryNumber == "0") &&
                invoiceBatch.BatchStatus != BatchStatus.Deleted &&
                invoiceBatch.BatchStatus != BatchStatus.PostInProgress)
            {
                return NewHeader();
            }
            if (invoiceBatch.BatchStatus == BatchStatus.Deleted &&
                invoiceBatch.BatchStatus == BatchStatus.PostInProgress)
            {
                return new TBatch();
            }
            return invoiceBatch;
        }

        /// <summary>
        /// Set the additional business entities
        /// </summary>
        /// <param name="businessEntities">BaseInvoiceEntryBusinesSet model</param>
        private void SetAdditionalBusinessEntity(
            BaseInvoiceEntryBusinessSet<TBatch, THeader, TDetail, TPayment, TDetailOptional> businessEntities)
        {
            _paymentEntity = businessEntities.PaymentBusinessEntity;
            _paymentMapper = businessEntities.PaymentMapper;
            _headerOptionalEntity = businessEntities.OptionalBusinessEntity;
            _detailOptionalEntity = businessEntities.DetailOptionalBusinessEntity;
            InvoiceHeaderMapper = businessEntities.InvoiceHeaderMapper;
            InvoiceDetailMapper = businessEntities.InvoiceDetailMapper;
            InvoiceOptFieldMapper = businessEntities.InvoiceOptFldMapper;
            InvoiceDetailOptFieldMapper = businessEntities.InvoiceDetailOptFldMapper;
        }

        /// <summary>
        /// To set fields for Detail Optional Fields
        /// </summary>
        /// <param name="optionalField">Optional Fields</param>
        /// <param name="isDetailOptionalField">is detail optional field</param>
        private bool SyncOptionalField(BaseInvoiceOptionalField optionalField, bool isDetailOptionalField)
        {
            var entity = isDetailOptionalField ? _detailOptionalEntity : _headerOptionalEntity;
            var entityMapper = isDetailOptionalField ? InvoiceDetailOptFieldMapper : InvoiceOptFieldMapper;

            if (string.IsNullOrEmpty(optionalField.OptionalField)) return true;
            var isUpdated = false;
            entityMapper.MapKey(optionalField, entity);
            entity.Read(false);

            if (optionalField.IsDeleted && entity.Exists)
            {
                // CheckRights(GetAccessRights(), SecurityType.Modify, Security.TransactionalOptionalField);
                entity.Delete();
                entity.ClearRecord();
                isUpdated = true;
            }
            else if (optionalField.IsDeleted && !entity.Exists)
            {
                entity.ClearRecord();
                isUpdated = true;
            }
            else if (entity.Exists)
            {
                //CheckRights(GetAccessRights(), SecurityType.Modify);
                entityMapper.MapKey(optionalField, entity);
                entity.Read(false);
                entityMapper.Map(optionalField, entity);
                entity.Update();
                isUpdated = true;
            }
            if (!isDetailOptionalField) return isUpdated;
            if (!DetailEntity.Exists) return isUpdated;
            DetailEntity.Update();
            return true;
        }

        /// <summary>
        /// Insert Optional field
        /// </summary>
        /// <param name="newLine">BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptionalField">if detail optional field</param>
        /// <returns>Boolean Value</returns>
        private bool InsertOptionalField(BaseInvoiceOptionalField newLine, bool isDetailOptionalField)
        {
            var entity = isDetailOptionalField ? _detailOptionalEntity : _headerOptionalEntity;
            if (string.IsNullOrEmpty(newLine.OptionalField))
                return true;
            if (isDetailOptionalField)
            {
                InvoiceDetailOptFieldMapper.Map(newLine, entity);
            }
            else
            {
                InvoiceOptFieldMapper.Map(newLine, entity);
            }
            //The reason for the exists check is that when an exception is thrown, new line will still be true.
            if (!newLine.IsDeleted && !entity.Exists)
            {
                entity.Insert();
            }
            if (!isDetailOptionalField) return true;
            if (DetailEntity.Exists)
                DetailEntity.Update();

            return true;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="detailOptionalFields">The details.</param>
        /// <param name="isDetailOptionalField">if detail optional field</param>
        private bool SyncOptionalFields(IEnumerable<BaseInvoiceOptionalField> detailOptionalFields,
            bool isDetailOptionalField)
        {
            var isDetailUpdated = false;
            if (detailOptionalFields == null) return false;
            var allDetails = detailOptionalFields as IList<BaseInvoiceOptionalField> ?? detailOptionalFields.ToList();

            foreach (var detail in allDetails.Where(detail => detail.HasChanged || detail.IsDeleted))
            {
                isDetailUpdated = SyncOptionalField(detail, isDetailOptionalField);
            }
            foreach (var newLine in allDetails.Where(detail => detail.IsNewLine && !detail.IsDeleted))
            {
                isDetailUpdated = InsertOptionalField(newLine, isDetailOptionalField);
            }

            return isDetailUpdated;
        }


        /// <summary>
        /// Format Optional Field
        /// </summary>
        /// <param name="optionalField">BaseInvoiceOptionalField model</param>
        /// <returns>BaseInvoiceOptionalField model</returns>
        private BaseInvoiceOptionalField FormatOptionalFields(BaseInvoiceOptionalField optionalField)
        {
            if (optionalField.Type == Models.Enums.InvoiceEntry.Type.Date)
            {
                optionalField.Value = DateUtil.GetShortDate(optionalField.Value, string.Empty, true);
            }

            if (optionalField.Type != Models.Enums.InvoiceEntry.Type.Time) return optionalField;
            if (optionalField.Value != null)
            {
                optionalField.Value = Regex.Replace(optionalField.Value, @"(\w{2})(\w{2})(\w{2})", @"$1:$2:$3");
            }
            return optionalField;
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
                return new EnumerableResponse<BaseInvoiceOptionalField>
                {
                    Items = optionalFieldList,
                    TotalResultsCount = filterCount != 0 ? filterCount : GetOptionalFieldsCount(entity)
                };
            do
            {
                if (loopCounter >= startIndex)
                {
                    var optionalField = mapper.Map(entity);
                    optionalField.LineKey = lineNumber++;
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
        private int GetOptionalFieldsCount(IBusinessEntity entity)
        {
            entity.Top();
            var total = 0;
            do
            {
                total++;
            } while (entity.Next());
            if (!entity.Exists && total == 1)
            {
                return 0;
            }
            return total;
        }

        /// <summary>
        /// Synchronizes the detail.
        /// </summary>
        /// <param name="details">The details.</param>
        private bool SyncDetails(IEnumerable<BaseInvoiceDetail> details)
        {
            var isDetailUpdated = false;
            if (details == null) return false;
            var allDetails = details as IList<BaseInvoiceDetail> ?? details.ToList();
            var newLine = allDetails.FirstOrDefault(detail => detail.IsNewLine);
            if (newLine != null)
            {
                isDetailUpdated = InsertDetail(newLine);
            }
            foreach (var detail in
                allDetails.Where(detail => detail.HasChanged || detail.IsDeleted).Where(detail => detail != newLine))
            {
                isDetailUpdated = SyncDetail(detail);
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// Insert Detail
        /// </summary>
        /// <param name="newLine">BaseInvoiceDetail model</param>
        /// <returns>Boolean value</returns>
        private bool InsertDetail(BaseInvoiceDetail newLine)
        {
            //This has been changed to MapKey instead of Map, if user directly clicks on AddLine model will not be updated on the client side
            // which will cause entity to be updated with wrong data. 
            InvoiceDetailMapper.MapKey(newLine, DetailEntity);
            //The reason for the exists check is that when an exception is thrown, new line will still be true.
            if (!DetailEntity.Exists && !newLine.IsDeleted)
            {
                DetailEntity.Insert();
            }
            else if (DetailEntity.Exists && !newLine.IsDeleted)
            {
                DetailEntity.Read(false);
                DetailEntity.Update();
            }
            else if (DetailEntity.Exists && newLine.IsDeleted)
            {
                DetailEntity.Read(false);
                DetailEntity.Delete();
                DetailEntity.ClearRecord();
            }
            else if (!DetailEntity.Exists && newLine.IsDeleted)
            {
                DetailEntity.ClearRecord();
            }

            return true;
        }

        /// <summary>
        /// Delete or Update detail 
        /// </summary>
        /// <param name="detail">BaseInvoiceDetail model</param>
        /// <returns>Boolean value</returns>
        private bool SyncDetail(BaseInvoiceDetail detail)
        {
            bool isDetailUpdated = false;
            InvoiceDetailMapper.MapKey(detail, DetailEntity);
            if (detail.IsDeleted && DetailEntity.Exists)
            {
                DetailEntity.Read(false);
                DetailEntity.Delete();
                DetailEntity.ClearRecord();
                isDetailUpdated = true;
            }
            else if (detail.IsDeleted && !DetailEntity.Exists)
            {
                DetailEntity.ClearRecord();
                isDetailUpdated = true;
            }
            else if (DetailEntity.Exists)
            {
                DetailEntity.Read(false);
                InvoiceDetailMapper.Map(detail, DetailEntity);
                DetailEntity.Update();
                isDetailUpdated = true;
            }
            return isDetailUpdated;
        }

        /// <summary>
        /// Updates Entry Number after mapping of data if not a saved entry.
        /// </summary>
        /// <param name="model">THeader model</param>
        /// <returns>THeader model</returns>
        private THeader EntryNumberUpdate(THeader model)
        {
            model.EntryNumber = Convert.ToString(BatchMapper.Map(BatchEntity).LastEntryNumber + 1,
                CultureInfo.InvariantCulture);
            return model;
        }

        /// <summary>
        /// Updates Entry Number after mapping of data if not a saved entry.
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>TBatch model</returns>
        private TBatch EntryNumberUpdate(TBatch model)
        {
            model.Invoices.EntryNumber = Convert.ToString(model.LastEntryNumber + 1, CultureInfo.InvariantCulture);
            return model;
        }

        #endregion
    }
}
