using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.PODropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base.Statefull
{
    /// <summary>
    /// Base Service class for Ordered HEader detail service
    /// </summary>
    /// <typeparam name="T">Header entity</typeparam>
    /// <typeparam name="TU">Detail Entity</typeparam>
    /// <typeparam name="TDetail2">Detail Entity 2</typeparam>
    /// <typeparam name="TDetail3">Detail Entity 3</typeparam>
    /// <typeparam name="TDetail4">Detail Entity 4</typeparam>
    /// <typeparam name="TDetail5">Detail Entity 5</typeparam>
    /// <typeparam name="TEntity">Repository</typeparam>
    public abstract class SequencedHeaderDetailFiveService<T, TU, TDetail2, TDetail3, TDetail4, TDetail5, TEntity> : BaseService,
        ISequencedHeaderDetailFiveService<T, TU, TDetail2, TDetail3, TDetail4, TDetail5>
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TDetail4 : ModelBase, new()
        where TDetail5 : ModelBase, new()
        where TEntity : ISequencedHeaderDetailFiveRepository<T, TU, TDetail2, TDetail3, TDetail4, TDetail5>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected SequencedHeaderDetailFiveService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        public virtual T NewHeader()
        {
            var repository = Resolve<TEntity>();
            return repository.NewHeader();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesHeader()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesHeader();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail2()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail2();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail3()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail3();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail4()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail4();
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        public virtual List<EnablementAttribute> GetDynamicAttributesDetail5()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDynamicAttributesDetail5();
        }


        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual T NewDetail(int pageNumber, int pageSize, TU currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail(pageNumber, pageSize, currentDetail);
        }

        /// <summary>
        /// Creates a new detail 2
        /// </summary>
        /// <returns>Detail 2 record</returns>
        public virtual T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail2)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail2(pageNumber, pageSize, currentDetail2);
        }

        /// <summary>
        /// Creates a new detail 3
        /// </summary>
        /// <returns>Detail 3 record</returns>
        public virtual T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail3)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail3(pageNumber, pageSize, currentDetail3);
        }

        /// <summary>
        /// Creates a new detail 4
        /// </summary>
        /// <returns>Detail 4 record</returns>
        public virtual T NewDetail4(int pageNumber, int pageSize, TDetail4 currentDetail4)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail4(pageNumber, pageSize, currentDetail4);
        }

        /// <summary>
        /// Creates a new detail 5
        /// </summary>
        /// <returns>Detail 5 record</returns>
        public virtual T NewDetail5(int pageNumber, int pageSize, TDetail5 currentDetail5)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail5(pageNumber, pageSize, currentDetail5);
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<T> Get(PageOptions<T> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual EnumerableResponse<T> Get(Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.Get(filter, orderBy);
        }

        /// <summary>
        /// Get Records based on pase size 
        /// </summary>
        /// <param name="currentPageNumber">currentPageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns> </returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Retrieve first or default  based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.FirstOrDefault(filter, orderBy);
        }

        /// <summary>
        ///Save
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public virtual T Save(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.Save(model);
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual T Delete(Expression<Func<T, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.Delete(filter);
        }

        /// <summary>
        /// Get next 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public T Next(Expression<Func<T, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.Next(filter);
        }

        /// <summary>
        /// Get previous 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual T Previous(Expression<Func<T, bool>> filter)
        {
            var repository = Resolve<TEntity>();
            return repository.Previous(filter);
        }

        /// <summary>
        /// Refresh  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail(model);
        }

        /// <summary>
        /// Refresh  detail 2 records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail2(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail2(model);
        }

        /// <summary>
        /// Refresh  detail 3 records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail3(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail3(model);
        }

        /// <summary>
        /// Refresh  detail 4 records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail4(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail4(model);
        }

        /// <summary>
        /// Refresh  detail 5 records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail5(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail5(model);
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual T SetDetail(TU currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail(currentDetail);
        }

        /// <summary>
        /// Sets pointer to the current Detail 2
        /// </summary>
        /// <param name="currentDetail2"></param>
        /// <returns></returns>
        public virtual T SetDetail2(TDetail2 currentDetail2)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail2(currentDetail2);
        }

        /// <summary>
        /// Sets pointer to the current Detail 3
        /// </summary>
        /// <param name="currentDetail3"></param>
        /// <returns></returns>
        public virtual T SetDetail3(TDetail3 currentDetail3)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail3(currentDetail3);
        }

        /// <summary>
        /// Sets pointer to the current Detail 4
        /// </summary>
        /// <param name="currentDetail4"></param>
        /// <returns></returns>
        public virtual T SetDetail4(TDetail4 currentDetail4)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail4(currentDetail4);
        }

        /// <summary>
        /// Sets pointer to the current Detail 5
        /// </summary>
        /// <param name="currentDetail5"></param>
        /// <returns></returns>
        public virtual T SetDetail5(TDetail5 currentDetail5)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail5(currentDetail5);
        }

        /// <summary>
        /// Clear  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T ClearDetails(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.ClearDetails(model);
        }

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TU ProcessDetail(TU detail)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail(detail);
        }

        /// <summary>
        /// Process for detail 2 entity
        /// </summary>
        /// <param name="detail2">Detail 2 model</param>
        /// <returns>Detail 2 record</returns>
        public virtual TDetail2 ProcessDetail2(TDetail2 detail2)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail2(detail2);
        }

        /// <summary>
        /// Process for detail 3 entity
        /// </summary>
        /// <param name="detail3">Detail 3 model</param>
        /// <returns>Detail 3 record</returns>
        public virtual TDetail3 ProcessDetail3(TDetail3 detail3)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail3(detail3);
        }

        /// <summary>
        /// Process for detail 4 entity
        /// </summary>
        /// <param name="detail4">Detail 4 model</param>
        /// <returns>Detail 4 record</returns>
        public virtual TDetail4 ProcessDetail4(TDetail4 detail4)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail4(detail4);
        }

        /// <summary>
        /// Process for detail 5 entity
        /// </summary>
        /// <param name="detail5">Detail 5 model</param>
        /// <returns>Detail 5 record</returns>
        public virtual TDetail5 ProcessDetail5(TDetail5 detail5)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail5(detail5);
        }

        /// <summary>
        /// Insert a header record
        /// </summary>
        /// <param name="model">Ordered header detail model</param>
        /// <returns>Inserted ordered header record</returns>
        public virtual T Add(T model)
        {
            var repository = Resolve<TEntity>();
            return repository.Add(model);
        }

        /// <summary>
        /// Gets the record by ID
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns>Header record</returns>
        public virtual T GetById<TKey>(TKey key)
        {
            var repository = Resolve<TEntity>();
            return repository.GetById(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            var repository = Resolve<TEntity>();
            return repository.GetAccessRights();
        }

        /// <summary>
        /// Retrieve Details records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize,
            Expression<Func<TU, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Retrieve Details 2 records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail2> GetDetail2(int currentPageNumber, int pageSize,
            Expression<Func<TDetail2, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail2(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Retrieve Details 3 records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail3> GetDetail3(int currentPageNumber, int pageSize,
            Expression<Func<TDetail3, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail3(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Retrieve Details 4 records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail4> GetDetail4(int currentPageNumber, int pageSize,
            Expression<Func<TDetail4, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail4(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Retrieve Details 5 records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail5> GetDetail5(int currentPageNumber, int pageSize,
            Expression<Func<TDetail5, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail5(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public T Refresh(T header)
        {
            var repository = Resolve<TEntity>();
            return repository.Refresh(header);
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail(TU detail)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail(detail);
        }

        /// <summary>
        /// Save Detail 2
        /// </summary>
        /// <param name="detail2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail2(TDetail2 detail2)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail2(detail2);
        }

        /// <summary>
        /// Save Detail 3
        /// </summary>
        /// <param name="detail3"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail3(TDetail3 detail3)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail3(detail3);
        }

        /// <summary>
        /// Save Detail 4
        /// </summary>
        /// <param name="detail4"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail4(TDetail4 detail4)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail4(detail4);
        }

        /// <summary>
        /// Save Detail 5
        /// </summary>
        /// <param name="detail5"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail5(TDetail5 detail5)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail5(detail5);
        }

        /// <summary> 
        /// Save details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails(IEnumerable<TU> details)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails(details);
        }

        /// <summary>
        /// Save details 2
        /// </summary>
        /// <param name="details2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails2(IEnumerable<TDetail2> details2)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails2(details2);
        }

        /// <summary>
        /// Save details 3
        /// </summary>
        /// <param name="details3"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails3(IEnumerable<TDetail3> details3)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails3(details3);
        }

        /// <summary>
        /// Save details 4
        /// </summary>
        /// <param name="details4"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails4(IEnumerable<TDetail4> details4)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails4(details4);
        }

        /// <summary>
        /// Save details 5
        /// </summary>
        /// <param name="details5"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails5(IEnumerable<TDetail5> details5)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails5(details5);
        }

        /// <summary>
        /// Gets the currency rate composite.
        /// </summary>
        /// <param name="rateType">Type of the rate.</param>
        /// <param name="sourceCurrencyCode">The source currency code.</param>
        /// <param name="date">The date.</param>
        /// <param name="homeCurrency">The home currency.</param>
        /// <returns></returns>
        public CompositeCurrencyRate GetCurrencyRateComposite(
            string rateType,
            string sourceCurrencyCode,
            DateTime date,
            string homeCurrency = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetCurrencyRateComposite(rateType, sourceCurrencyCode, date, homeCurrency);
        }

        /// <summary>
        /// Gets the Distribution Proration 
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of POOEBaseInvDistProration</returns>
        public virtual EnumerableResponse<Proration> GetDistributionProrations(int pageNumber, int pageSize,
            Expression<Func<Proration, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDistributionProrations(pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="lineRevision">Line number to set</param>
        /// <param name="amount">Amount to set</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        public virtual void RefreshDistributionProration(int lineRevision, string amount)
        {
            var repository = Resolve<TEntity>();
            repository.RefreshDistributionProration(lineRevision, amount);
        }

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="getAmountRemaining">Return Amount Remaining or Manually prorated amount</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        public virtual decimal GetDistributionAmountRemaining(bool getAmountRemaining)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDistributionAmountRemaining(getAmountRemaining);
        }

        /// <summary>
        /// Gets Manually Prorated Amount
        /// </summary>
        /// <returns>Amount</returns>
        public virtual decimal GetManuallyProratedAmount()
        {
            var repository = Resolve<TEntity>();
            return repository.GetManuallyProratedAmount();
        }

        #region Comments & Instruction

        /// <summary>
        /// Gets the Comment Instruction
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of Comment Instruction</returns>
        public virtual EnumerableResponse<TDetail2> GetCommentInstruction(int pageNumber, int pageSize,
            Expression<Func<TDetail2, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetCommentInstruction(pageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Create New Comment/Instruction Line
        /// </summary>
        /// <param name="currentDetail">Current Line</param>
        /// <returns>Comments/Instruction</returns>
        public virtual TDetail2 NewCommentInstruction(TDetail2 currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.NewCommentInstruction(currentDetail);
        }

        /// <summary>
        /// Insert/Update Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction model</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        public virtual TDetail2 SaveCommentInstruction(TDetail2 model, string comment, string lineType)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveCommentInstruction(model, comment, lineType);
        }

        /// <summary>
        /// Get Result Count
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Total Count</returns>
        public virtual int GetCommentInstructionCount(Expression<Func<TDetail2, bool>> filter = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetCommentInstructionCount(filter);
        }

        #endregion Comments & Instruction

        /// <summary>
        /// GetDropShipAddressDetail
        /// </summary>
        /// <returns></returns>
        public virtual DropShipAddress GetDropShipAddressDetail()
        {
            var repository = Resolve<TEntity>();
            return repository.GetDropShipAddressDetail();

        }

        /// <summary>
        /// UpdateDropShipAddressDetail
        /// </summary>
        /// <param name="model"></param>
        public void UpdateDropShipAddressDetail(DropShipAddress model)
        {
            var repository = Resolve<TEntity>();
            repository.UpdateDropShipAddressDetail(model);
        }

        /// <summary>
        /// Gets Bill To Location
        /// </summary>
        /// <returns>Bill To Location Model</returns>
        public BillToLocation GetBillToLocation()
        {
            var repository = Resolve<TEntity>();
            return repository.GetBillToLocation();
        }

        /// <summary>
        /// Sets the Bill To Location Model Attributes.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        public BillToLocation SetBillToLocation(BillToLocation model)
        {
            var repository = Resolve<TEntity>();
            return repository.SetBillToLocation(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void SetVendorInformation(VendorBase model)
        {
            var repository = Resolve<TEntity>();
            repository.SetVendorInformation(model);
        }

        /// <summary>
        /// GetVendorInformation
        /// </summary>
        /// <returns>VendorBase</returns>
        public VendorBase GetVendorInformation()
        {
            var repository = Resolve<TEntity>();
            return repository.GetVendorInformation();
        }

        /// <summary>
        /// CheckValidDropShipData
        /// </summary>
        /// <param name="model">Value</param>
        /// <param name="type">Type</param>
        public void CheckValidDropShipData(DropShipAddress model, DropShipmentType type)
        {
            var repository = Resolve<TEntity>();
            repository.CheckValidDropShipData(model, type);
        }
    }
}
