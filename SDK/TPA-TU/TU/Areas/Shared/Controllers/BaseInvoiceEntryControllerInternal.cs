/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Type = Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry.Type;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers
{
    /// <summary>
    /// BaseInvoiceEntryControllerInternal
    /// </summary>
    /// <typeparam name="TBatch">Batch Entity</typeparam>
    /// <typeparam name="THeader">Header Entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TService">Service</typeparam>
    public class BaseInvoiceEntryControllerInternal<TBatch, THeader, TDetail, TService> :
        BaseExportImportControllerInternal<TBatch, TService>
        where TBatch : BaseInvoiceBatch, new()
        where THeader : BaseInvoice, new()
        where TDetail : BaseInvoiceDetail, new()
        where TService : IBaseInvoiceEntryService<TBatch, THeader, TDetail>
    {
        #region Constructor

        /// <summary>
        /// Invoice Controller Internal - Default constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseInvoiceEntryControllerInternal(Context context)
            : base(context)
        {
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Create a new batch
        /// </summary>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> CreateBatch()
        {
            var invoiceEntryData = Service.NewBatch();
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = invoiceEntryData,
                UserMessage = new UserMessage(invoiceEntryData)
            };
        }

        /// <summary>
        /// Create a new entry
        /// </summary>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> CreateEntry()
        {
            var data = Service.NewEntry();
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = data,
                UserMessage =
                    new UserMessage(data,
                        string.Format(CommonResx.AddSuccessMessage, InvoiceResx.InvoiceEntry, data.Invoices.EntryNumber))
            };
        }

        /// <summary>
        /// Create a new invoice detail
        /// </summary>
        /// <param name="model">invoice batch model</param>
        /// <param name="index">Index number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="pageNumber">Current Page number</param>
        /// <returns>returns batch model</returns>
        public virtual TBatch CreateDetail(TBatch model, int index, int pageSize, int pageNumber)
        {
            if (model.Invoices.VendorNumber == null && model.Invoices.CustomerNumber == null) return model;

            var details = model.Invoices.InvoiceDetails.Items as IList<BaseInvoiceDetail> ??
                          model.Invoices.InvoiceDetails.Items.ToList();

            var hasDetails = details.Count > 0 && details.All(invoiceDetail => invoiceDetail.LineNumber != 0);

            // SetTimeOffset(model);

            //This method maps the model.
            if (model.HasChanged)
            {
                Service.Refresh(model);
            }

            var lineNumber = (pageSize * pageNumber) + 1;
            var currentRow = hasDetails ? details.Count > index ? details.ElementAt(index) : details.Last() : null;

            TBatch batch;
            BaseInvoiceDetail data;
            var invoiceDetails = new List<BaseInvoiceDetail>();

            if (hasDetails)
            {
                //If in the grid you are trying to add the new detail at last line. This moves the new line to next page.
                if (pageSize > (index + 1))
                {
                    batch = CreateDetail(pageSize, pageNumber, currentRow);
                    data = batch.Invoices.InvoiceDetails.Items.FirstOrDefault();
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
                        Service.SaveDetails(details);
                    }
                    invoiceDetails = model.Invoices.InvoiceDetails.Items.Take(pageSize - 1).ToList();
                    foreach (var invoiceEntryDetail in invoiceDetails)
                    {
                        invoiceEntryDetail.HasChanged = false;
                    }
                    invoiceDetails.Insert(index + 1, data);
                    foreach (var invoiceEntryDetail in invoiceDetails)
                    {
                        invoiceEntryDetail.DisplayIndex = lineNumber;
                        lineNumber++;
                    }
                    batch.Invoices.InvoiceDetails.Items = invoiceDetails;
                    batch.Invoices.InvoiceDetails.TotalResultsCount = model.Invoices.InvoiceDetails.TotalResultsCount + 1;
                    return batch;
                }

                // If page size is less than pagesize
                if (details.Any(invoiceDetail => invoiceDetail.HasChanged || invoiceDetail.IsNewLine))
                {
                    if (Service.SaveDetails(details))
                        currentRow.IsNewLine = false;
                }
                //var pagedDetails = GetDetails(pageNumber == 0 ? pageNumber : pageNumber - 1, pageSize);
                var pagedDetails = GetDetails(pageNumber, pageSize);
                var totalRecords = pagedDetails.TotalResultsCount;
                batch = CreateDetail(pageSize, pageNumber, currentRow);
                data = batch.Invoices.InvoiceDetails.Items.FirstOrDefault();
                invoiceDetails = new List<BaseInvoiceDetail>(pagedDetails.Items.ToList());
                if (pageSize != (index + 1))
                {
                    invoiceDetails = invoiceDetails.Take(pageSize - 1).ToList();
                    foreach (var invoiceEntryDetail in invoiceDetails)
                    {
                        invoiceEntryDetail.HasChanged = false;
                    }
                    invoiceDetails.Insert(0, data);
                    //lineNumber = (pageSize * (pageNumber - 1)) + 1;
                    lineNumber = (pageSize * pageNumber) + 1;
                }

                foreach (var invoiceEntryDetail in invoiceDetails)
                {
                    invoiceEntryDetail.DisplayIndex = lineNumber;
                    lineNumber++;
                }
                batch.Invoices.InvoiceDetails.Items = invoiceDetails;
                batch.Invoices.InvoiceDetails.TotalResultsCount = totalRecords + 1;
                return batch;
            }

            //If adding in between the limit of grid.
            batch = CreateDetail(pageSize, pageNumber, null);
            data = batch.Invoices.InvoiceDetails.Items.FirstOrDefault();
            if (data != null)
            {
                data.DisplayIndex = invoiceDetails.Count + 1;
                invoiceDetails.Add(data);
            }
            batch.Invoices.InvoiceDetails.Items = invoiceDetails;
            batch.Invoices.InvoiceDetails.TotalResultsCount++;
            return batch;
        }


        /// <summary>
        /// Gets the data based on selected document type
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> ChangeDocumentType(TBatch model)
        {
            var data = Service.ChangeDocumentType(model.Invoices.DocumentType);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = data },
                UserMessage = new UserMessage(data)
            };
        }

        /// <summary>
        /// Get detail based on page
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="model">Model</param>
        /// <param name="filters">Filters</param>
        /// <returns>returns Enumerable response of TDetail</returns>
        public virtual EnumerableResponse<TDetail> GetDetails(int pageNumber, int pageSize, TBatch model = null,
            IList<IList<Filter>> filters = null)
        {
            // SetTimeOffset(model);
            if (model != null && model.Invoices != null && model.Invoices.InvoiceDetails != null)
            {
                if (model.Invoices.InvoiceDetails.Items.Any(x => x.HasChanged) ||
                    model.Invoices.InvoiceDetails.Items.Any(x => x.IsNewLine) ||
                    model.Invoices.InvoiceDetails.Items.Any(x => x.IsDeleted))
                {
                    if (model.Invoices.InvoiceDetails.Items.Any(x => x.GLAccount != null))
                    {
                        Service.SaveDetails(model.Invoices.InvoiceDetails.Items);
                    }

                }
            }
            var invoiceDetails = Service.GetDetail(pageNumber, pageSize);
            var lineNumber = (pageSize * pageNumber) + 1;
            foreach (var invoiceDetail in invoiceDetails.Items)
            {
                invoiceDetail.DisplayIndex = lineNumber++;
            }
            return invoiceDetails;
        }

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
        /// Delete Optional Fields
        /// </summary>
        /// <param name="model">Enumerable Response of BaseInvoiceOptionalField model</param>
        /// <param name="pageNumber">Current PageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField model</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> DeleteOptionalFields(
            EnumerableResponse<BaseInvoiceOptionalField> model, int pageNumber, int pageSize)
        {
            foreach (
                var invoiceEntryDetailOptionalFields in
                    model.Items.Where(
                        invoiceOptionalField =>
                            (invoiceOptionalField.HasChanged || invoiceOptionalField.IsDeleted ||
                            invoiceOptionalField.IsNewLine) && invoiceOptionalField.Type == Type.Date))
            {
                invoiceEntryDetailOptionalFields.Value = DateUtil.GetShortDate(invoiceEntryDetailOptionalFields.Value, null);
            }
            Service.SaveOptionalFields(model.Items, false);

            var pagedDetail = GetOptionalFields(pageNumber, pageSize, null, true);
            var refreshedDetail = (List<BaseInvoiceOptionalField>)pagedDetail.Items;
            var totalResultsCount = pagedDetail.TotalResultsCount;
            var returnDetail = new EnumerableResponse<BaseInvoiceOptionalField>
            {
                Items = refreshedDetail,
                TotalResultsCount = totalResultsCount
            };
            return returnDetail;
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
            if (!savedOptionalFields) return optionalFields;
            if (optionalFields == null) return null;
            foreach (var invoiceEntryDetailOptionalFields in optionalFields)
            {
                invoiceEntryDetailOptionalFields.IsNewLine = false;
                invoiceEntryDetailOptionalFields.HasChanged = false;
                invoiceEntryDetailOptionalFields.IsDeleted = false;
            }
            return optionalFields;
        }

        /// <summary>
        /// Get Batch data
        /// </summary>
        /// <param name="batchId">Batch Id</param>
        /// <param name="entryId">Entry Id</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> Get(string batchId, string entryId)
        {
            var invoiceEntryData = Service.GetByIds(batchId, entryId);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = invoiceEntryData,
                UserMessage = new UserMessage(invoiceEntryData)
            };
        }


        /// <summary>
        /// Get Invoice entry data
        /// </summary>
        /// <param name="entryNumber">Invoice Entry Number</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> GetInvoiceEntry(string entryNumber)
        {
            var invoiceEntryData = Service.GetHeaderById(entryNumber);
            // If data returned is null
            if (invoiceEntryData == null)
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = new TBatch(),
                    UserMessage =
                        ConstructErrorMessage(string.Format(CommonResx.RecordNotFoundMessage, CommonResx.Entry,
                            entryNumber)),
                };

            //If entry data is found
            if (invoiceEntryData.Invoices.EntryNumber == entryNumber)
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = invoiceEntryData,
                    UserMessage = new UserMessage(invoiceEntryData)
                };

            //If data is there but entry number is not matching then update entry number with the old data and through error.
            invoiceEntryData.Invoices.EntryNumber = entryNumber;
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = invoiceEntryData,
                UserMessage =
                    ConstructErrorMessage(string.Format(CommonResx.RecordNotFoundMessage, CommonResx.Entry, entryNumber)),
            };
        }

        /// <summary>
        /// Gets batch data
        /// </summary>
        /// <param name="id">Batch number</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> Get(string id)
        {
            var invoiceEntryData = Service.GetById(id);
            if (invoiceEntryData == null || invoiceEntryData.BatchNumber == 0)
            {

                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = new TBatch(),
                    UserMessage =
                        ConstructErrorMessage(string.Format(CommonResx.RecordNotFoundMessage, InvoiceResx.Batch, id)),
                };
            }
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = invoiceEntryData,
                UserMessage = new UserMessage(invoiceEntryData),
            };
        }

        /// <summary>
        /// Get Tax Authorities
        /// </summary>
        /// <param name="id">Tax group</param>
        /// <returns>List of Tax Authorities</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetTaxAuthorities(string id)
        {
            return string.IsNullOrEmpty(id)
                ? new EnumerableResponse<TaxGroupAuthority> { Items = new List<TaxGroupAuthority>() }
                : Service.GetTaxAuthorities(id);
        }

        /// <summary>
        /// Gets optional fields
        /// </summary>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptField">if detail optional field</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize,
            BaseInvoice model, bool isDetailOptField)
        {
            if (model == null)
                return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
            var optionalField = model.OptionalFieldList.Items.ToList();

            if (!optionalField.Any(x => x.HasChanged) && !optionalField.Any(x => x.IsNewLine) &&
                !optionalField.Any(x => x.IsDeleted))
            {
                return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
            }

            if (optionalField.Any(x => x.OptionalField != null))
            {
                SaveOptionalFields(optionalField, isDetailOptField);
            }

            return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
        }

        /// <summary>
        /// Gets details optional fields
        /// </summary>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int pageSize,
            List<BaseInvoiceOptionalField> model)
        {
            if (model == null)
                return Service.GetOptionalFields(pageNumber, pageSize, true);
            var optionalField = model;

            if (!optionalField.Any(x => x.HasChanged) && !optionalField.Any(x => x.IsNewLine) &&
                !optionalField.Any(x => x.IsDeleted))
            {
                return Service.GetOptionalFields(pageNumber, pageSize, true);
            }

            if (optionalField.Any(x => x.OptionalField != null))
            {
                SaveOptionalFields(optionalField, true);
            }

            return Service.GetOptionalFields(pageNumber, pageSize, true);
        }

        /// <summary>
        /// Gets optional fields, add new line
        /// </summary>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="index">New line inserted index</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="model">List of BaseInvoiceOptionalField model</param>
        /// <param name="isDetailOptField">is detail optional field</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> GetOptionalFields(int pageNumber, int index, int pageSize,
            BaseInvoice model, bool isDetailOptField)
        {
            if (model == null)
                return Service.GetOptionalFields(pageNumber, pageSize, isDetailOptField);
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
                row.EntryNumber = item.EntryNumber;
                row.BatchNumber = item.BatchNumber;
                row.LineKey =(DateUtil.GetTicks() /TimeSpan.TicksPerMillisecond);
                list.Insert(index % pageSize, row);
                optionalFields.Items = list.Take(pageSize);
                optionalFields.TotalResultsCount = optionalFields.TotalResultsCount + 1;
            }
            return optionalFields;
        }

        /// <summary>
        /// Add Invoice entry
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> Add(TBatch model)
        {
            if (model.BatchNumber == 0)
            {
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = model,
                    UserMessage =
                        new UserMessage(model,
                            string.Format(CommonResx.RecordNotFoundMessage, InvoiceResx.Batch, model.BatchNumber))
                };
            }
            if (model.Invoices.EntryNumber == "0")
            {
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = model,
                    UserMessage =
                        new UserMessage(model,
                            string.Format(CommonResx.RecordNotFoundMessage, CommonResx.Entry, model.Invoices.EntryNumber))
                };
            }
            // SetTimeOffset(model);
            var data = Service.Add(model);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = data,
                UserMessage =
                    new UserMessage(data,
                        string.Format(CommonResx.AddSuccessMessage, CommonResx.Entry, model.Invoices.EntryNumber))
            };
        }

        /// <summary>
        /// Update Invoice entry
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> Save(TBatch model)
        {
            if (model.BatchNumber == 0)
            {
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = model,
                    UserMessage =
                        new UserMessage(model,
                            string.Format(CommonResx.RecordNotFoundMessage, InvoiceResx.Batch, model.BatchNumber))
                };
            }
            if (model.Invoices.EntryNumber == "0")
            {
                return new BaseInvoiceEntryViewModel<TBatch>
                {
                    Data = model,
                    UserMessage =
                        new UserMessage(model,
                            string.Format(CommonResx.RecordNotFoundMessage, CommonResx.Entry, model.Invoices.EntryNumber))
                };
            }
            // SetTimeOffset(model);
            var data = Service.Save(model);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = data,
                UserMessage = new UserMessage(data, CommonResx.SaveSuccessMessage)
            };
        }

        /// <summary>
        /// Delete invoice entry 
        /// </summary>
        /// <param name="id">Batch Number</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> Delete(string id)
        {
            Expression<Func<TBatch, Boolean>> filter = invoiceBatch => invoiceBatch.Invoices.EntryNumber == id;
            var data = Service.Delete(filter);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = data,
                UserMessage =
                    new UserMessage(data, string.Format(CommonResx.DeleteSuccessMessage, InvoiceResx.InvoiceEntry, id))
            };
        }

        /// <summary>
        /// Deletes Details
        /// </summary>
        /// <param name="model">TBatch model</param>
        /// <param name="pageNumber">Current pageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> DeleteDetails(TBatch model, int pageNumber, int pageSize)
        {
            // SetTimeOffset(model);

            if (model != null && model.Invoices != null && model.Invoices.InvoiceDetails != null)
            {
                if (model.Invoices.InvoiceDetails.Items.Any(x => x.HasChanged) ||
                    model.Invoices.InvoiceDetails.Items.Any(x => x.IsNewLine) ||
                    model.Invoices.InvoiceDetails.Items.Any(x => x.IsDeleted))
                {
                        Service.SaveDetails(model.Invoices.InvoiceDetails.Items);

                }
            }
            var pagedDetail = GetDetails(pageNumber, pageSize);
            var data = Service.UpdatedModel();
            data.Invoices.InvoiceDetails.Items = pagedDetail.Items;
            data.Invoices.InvoiceDetails.TotalResultsCount = pagedDetail.TotalResultsCount;
            return new BaseInvoiceEntryViewModel<TBatch> { Data = data, UserMessage = new UserMessage(model) };
        }

        /// <summary>
        /// Updates the Tax tab when the dropdowns in the UI is changed
        /// </summary>
        /// <param name="model">THeader model</param>
        /// <returns>returns BaseInvoice model</returns>
        public virtual BaseInvoice UpdateTaxCalculateType(THeader model)
        {
            return Service.UpdateTaxCalculateType(model);
        }

        /// <summary>
        ///  Updates the Tax tab Calculate or Distribute Button is clicked
        /// </summary>
        /// <param name="processType">Type of Process the header should Perform</param>
        /// <returns>Invoice Entry View Model</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> TaxRefresh(int processType)
        {
            var headerModel = Service.TaxRefresh(processType);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = headerModel, },
                UserMessage = new UserMessage(headerModel)
            };
        }


        /// <summary>
        /// Derive Rate
        /// </summary>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> DeriveRate()
        {
            var invoiceEntry = Service.DeriveRate();

            var data = new BaseInvoiceBatch();
            if (invoiceEntry != null)
            {
                data = new TBatch { Invoices = invoiceEntry };
            }
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = (TBatch)data,
                UserMessage = new UserMessage(invoiceEntry)
            };
        }

        /// <summary>
        /// Set Detail to current detail
        /// </summary>
        /// <param name="currentDetail"> Current Selected Detail</param>
        /// <returns>returns TBatch model</returns>
        public virtual TBatch SetDetail(BaseInvoiceDetail currentDetail)
        {
            return Service.SetDetail(currentDetail);
        }

        /// <summary>
        /// Save current detail row
        /// </summary>
        /// <param name="currentDetail"> Current Selected Detail</param>
        /// <returns>returns TBatch model</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> SaveDetail(BaseInvoiceDetail currentDetail)
        {
            var headerData = Service.SaveDetail(currentDetail);
            return new BaseInvoiceEntryViewModel<TBatch> { Data = headerData, UserMessage = new UserMessage(headerData) };
        }


        /// <summary>
        /// Changes Vendor 
        /// </summary>
        /// <param name="id">Vendor number</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> ChangeVendor(string id)
        {
            var data = Service.ChangeVendor(id);

            if (data == null || data.InvoiceDetails == null)
                return new BaseInvoiceEntryViewModel<TBatch> { Data = new TBatch { Invoices = data }, };
            foreach (var item in data.InvoiceDetails.Items)
            {
                item.IsNewLine = true;
            }

            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = data },
                UserMessage = new UserMessage(data)
            };
        }

        /// <summary>
        /// Creates the distribution codes based on distribution set chosen. 
        /// </summary>
        /// <param name="documentTotalIncludingTax">Document Total Including Tax</param>
        /// <param name="distributionSetAmount">Distribution Set Amount</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> CreateDistribution(string documentTotalIncludingTax,
            string distributionSetAmount)
        {
            var data = Service.CreateDistribution(documentTotalIncludingTax, distributionSetAmount);

            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = data },
                UserMessage = new UserMessage(data)
            };
        }

        /// <summary>
        /// Set Tax Authority
        /// </summary>
        /// <param name="model">Current selected TaxAuthority model</param>
        /// <param name="isDetailTaxData">if detail tax data is passed</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> SetTaxGroupAuthority(TaxGroupAuthority model,
            bool isDetailTaxData)
        {
            var data = Service.SetTaxGroupAuthority(model, isDetailTaxData);

            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = data },
                UserMessage = new UserMessage(data)
            };
        }


        /// <summary>
        /// Refreshes the detail when the data is changed.
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <param name="eventType">Type of event</param>
        /// <returns>returns BaseInvoiceEntryViewModel</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> RefreshDetail(BaseInvoiceDetail detail, string eventType)
        {
            var refreshDetail = Service.RefreshDetail(detail, eventType);
            var baseInvoiceDetail = refreshDetail.InvoiceDetails.Items.FirstOrDefault();
            if (baseInvoiceDetail != null)
                baseInvoiceDetail.IsNewLine = detail.IsNewLine;
            var invoiceBatch = new TBatch { Invoices = refreshDetail };
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = invoiceBatch,
                //Below we are passing only detail model to usermessage because in javascript it expects the
                //warning messages to be in UserMessage directly.
                UserMessage = new UserMessage(baseInvoiceDetail)
            };

        }

        /// <summary>
        /// Gets Tax Authority Data for specific detail.
        /// </summary>
        /// <param name="model">BaseInvoiceDetail model</param>
        /// <returns>returns EnumerableResponse of TaxGroupAuthority</returns>
        public virtual EnumerableResponse<TaxGroupAuthority> GetDetailTaxes(BaseInvoiceDetail model)
        {
            return model == null
                ? new EnumerableResponse<TaxGroupAuthority> { Items = new List<TaxGroupAuthority>() }
                : Service.GetDetailTaxes(model);
        }

        /// <summary>
        /// To set the changed value and get the model
        /// </summary>
        /// <param name="value">changed value</param>
        /// <param name="property">property that changed</param>
        /// <returns>returns BaseInvoiceEntryViewModel </returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> RefreshHeader(string value, string property)
        {
            var invoiceModel = Service.RefreshHeader(value, property);
            return new BaseInvoiceEntryViewModel<TBatch>
            {
                Data = new TBatch { Invoices = invoiceModel, },
                UserMessage = new UserMessage(invoiceModel)
            };
        }

        /// <summary>
        /// Save the details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Invoice Batch Viewmodel - that contains the info about the saved details</returns>
        public virtual BaseInvoiceEntryViewModel<TBatch> SaveDetails(TBatch model)
        {
            // SetTimeOffset(model);
            Service.SaveDetails(model.Invoices.InvoiceDetails.Items);
            var data = Service.UpdatedModel();
            return new BaseInvoiceEntryViewModel<TBatch> { Data = data, UserMessage = new UserMessage(data) };

        }

        /// <summary>
        /// Delete Optional Fields
        /// </summary>
        /// <param name="model">Enumerable Response of BaseInvoiceOptionalField model</param>
        /// <param name="pageNumber">Current PageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <returns>returns Enumerable Response of BaseInvoiceOptionalField model</returns>
        public virtual EnumerableResponse<BaseInvoiceOptionalField> DeleteDetailOptionalField(
            EnumerableResponse<BaseInvoiceOptionalField> model, int pageNumber, int pageSize)
        {
            foreach (
                var invoiceEntryDetailOptionalFields in
                    model.Items.Where(
                        invoiceOptionalField =>
                            (invoiceOptionalField.HasChanged || invoiceOptionalField.IsDeleted ||
                            invoiceOptionalField.IsNewLine) && invoiceOptionalField.Type == Type.Date))
            {
                invoiceEntryDetailOptionalFields.Value = DateUtil.GetShortDate(invoiceEntryDetailOptionalFields.Value, null);
            }
            Service.SaveOptionalFields(model.Items, true);
            var pagedDetail = GetOptionalFields(pageNumber, pageSize, null, true);
            var refreshedDetail = (List<BaseInvoiceOptionalField>)pagedDetail.Items;
            var totalResultsCount = pagedDetail.TotalResultsCount;
            var returnDetail = new EnumerableResponse<BaseInvoiceOptionalField>
            {
                Items = refreshedDetail,
                TotalResultsCount = totalResultsCount
            };
            return returnDetail;
        }

        /// <summary>
        /// Check whether detail exists
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public virtual bool IsDetailExists(BaseInvoiceOptionalField detail)
        {
            return Service.IsOptionalFieldExists(detail);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create invoice Entry Detail
        /// </summary>
        /// <param name="pageSize">Page Size</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="currentRow">Current Selected Row</param>
        /// <returns> returns Batch model</returns>
        private TBatch CreateDetail(int pageSize, int pageNumber, BaseInvoiceDetail currentRow)
        {
            var data = Service.NewDetail(pageNumber, pageSize, currentRow);
            data.Invoices.InvoiceDetails.Items.ToList()[0].IsNewLine = true;
            return data;
        }

        ///// <summary>
        ///// This will be removed when Off set is added to Javascript Deserializer.
        ///// </summary>
        ///// <param name="model">Model</param>
        //private void SetTimeOffset(TBatch model)
        //{
        //    if (model == null) return;
        //    model.BatchDate = model.BatchDate;

        //    if (model.Invoices.DocumentDate.HasValue)
        //    {
        //        model.Invoices.DocumentDate =
        //            model.Invoices.DocumentDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices.PostingDate.HasValue)
        //    {
        //        model.Invoices.PostingDate = model.Invoices.PostingDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices.DiscountDate.HasValue)
        //    {
        //        model.Invoices.DiscountDate =
        //            model.Invoices.DiscountDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices.AsofDate.HasValue)
        //    {
        //        model.Invoices.AsofDate = model.Invoices.AsofDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices.DueDate.HasValue)
        //    {
        //        model.Invoices.DueDate = model.Invoices.DueDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices.RateDate != DateUtil.GetMinDate())
        //    {
        //        model.Invoices.RateDate = model.Invoices.RateDate;
        //    }

        //    if (model.Invoices.DateGenerated != DateUtil.GetMinDate())
        //    {
        //        model.Invoices.DateGenerated = model.Invoices.DateGenerated;
        //    }

        //    if (model.Invoices.RetainageDueDate != DateUtil.GetMinDate())
        //    {
        //        model.Invoices.RetainageDueDate = model.Invoices.RetainageDueDate;
        //    }

        //    if (model.Invoices.TaxReportingRateDate.HasValue)
        //    {
        //        model.Invoices.TaxReportingRateDate =
        //            model.Invoices.TaxReportingRateDate.GetValueOrDefault();
        //    }

        //    if (model.Invoices == null || model.Invoices.InvoiceDetails == null ||
        //        model.Invoices.InvoiceDetails.Items == null || !model.Invoices.InvoiceDetails.Items.Any()) return;
        //    var details = model.Invoices.InvoiceDetails.Items.ToList();
        //    model.Invoices.InvoiceDetails.Items = details;
        //    var optionalFields = model.Invoices.OptionalFieldList.Items.ToList();
        //    foreach (
        //        var optionalField in
        //            optionalFields.Where(
        //                optionalField =>
        //                    optionalField.Type == Type.Date &&
        //                    optionalField.Value != null))
        //    {
        //        if (!string.IsNullOrEmpty(optionalField.Value))
        //        {
        //            optionalField.Value =
        //                Convert.ToDateTime(optionalField.Value).ToShortDateString();
        //        }
        //        if (optionalField.Value == string.Empty)
        //        {
        //            optionalField.Value = null;
        //        }
        //    }
        //}

        /// <summary>
        /// Apply offset for optional fields date fields
        /// </summary>
        /// <param name="row">BaseInvoiceOptionalField model</param>
        private void SetOptionalFieldOffset(BaseInvoiceOptionalField row)
        {
            if (row == null) return;
            if (row.Type != Type.Date) return;
            if (!string.IsNullOrEmpty(row.Value))
            {
                row.Value = Convert.ToDateTime(row.Value).ToShortDateString();
            }
        }

        #endregion
    }
}