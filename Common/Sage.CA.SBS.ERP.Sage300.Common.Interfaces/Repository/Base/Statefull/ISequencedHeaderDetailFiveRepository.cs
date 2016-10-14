/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.DropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.PODropShipment;
using Sage.CA.SBS.ERP.Sage300.Common.Models.POVendorInformation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base.Statefull
{
    /// <summary>
    /// Interface ISequencedHeaderDetailFiveRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU">The type of the tu.</typeparam>
    /// <typeparam name="TDetail2">The type of the TDetail2.</typeparam>
    /// <typeparam name="TDetail3">The type of the TDetail3.</typeparam>
    /// <typeparam name="TDetail4">The type of the TDetail4.</typeparam>
    /// <typeparam name="TDetail5">The type of the TDetail5.</typeparam>
    public interface ISequencedHeaderDetailFiveRepository<T, TU, TDetail2, TDetail3, TDetail4, TDetail5> : IBusinessRepository<T>, ISecurity
        where T : ModelBase
        where TU : ModelBase
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TDetail4 : ModelBase, new()
        where TDetail5 : ModelBase, new()
    {
        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        T NewHeader();

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail(TU detail);

        /// <summary>
        /// Save for detail 2 entry
        /// </summary>
        /// <param name="detail2">Detail 2 model</param>
        /// <returns></returns>
        T SaveDetail2(TDetail2 detail2);

        /// <summary>
        /// Save for detail 3 entry
        /// </summary>
        /// <param name="detail3">Detail 3 model</param>
        /// <returns></returns>
        T SaveDetail3(TDetail3 detail3);

        /// <summary>
        /// Save for detail 4 entry
        /// </summary>
        /// <param name="detail4">Detail 4 model</param>
        /// <returns></returns>
        T SaveDetail4(TDetail4 detail4);


        /// <summary>
        /// Save for detail 5 entry
        /// </summary>
        /// <param name="detail5">Detail 5 model</param>
        /// <returns></returns>
        T SaveDetail5(TDetail5 detail5);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail(TU detail);

        /// <summary>
        /// Sets pointer to the current Detail 2
        /// </summary>
        /// <param name="detail2">The current detail 2.</param>
        /// <returns>TDetail2.</returns>
        T SetDetail2(TDetail2 detail2);

        /// <summary>
        /// Sets pointer to the current Detail 3
        /// </summary>
        /// <param name="detail3">The current detail 3.</param>
        /// <returns>TDetail3.</returns>
        T SetDetail3(TDetail3 detail3);

        /// <summary>
        /// Sets pointer to the current Detail 4
        /// </summary>
        /// <param name="detail4">The current detail 4.</param>
        /// <returns>TDetail4.</returns>
        T SetDetail4(TDetail4 detail4);

        /// <summary>
        /// Sets pointer to the current Detail 5
        /// </summary>
        /// <param name="detail5">The current detail 5.</param>
        /// <returns>TDetail5.</returns>
        T SetDetail5(TDetail5 detail5);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TU> details);

        /// <summary>
        /// Save for detail 2 entry
        /// </summary>
        /// <param name="details2">Detail model</param>
        /// <returns></returns>
        bool SaveDetails2(IEnumerable<TDetail2> details2);

        /// <summary>
        /// Save for detail 3 entry
        /// </summary>
        /// <param name="details3">Detail model</param>
        /// <returns></returns>
        bool SaveDetails3(IEnumerable<TDetail3> details3);

        /// <summary>
        /// Save for detail 4 entry
        /// </summary>
        /// <param name="details4">Detail model</param>
        /// <returns></returns>
        bool SaveDetails4(IEnumerable<TDetail4> details4);

        /// <summary>
        /// Save for detail 5 entry
        /// </summary>
        /// <param name="details5">Detail model</param>
        /// <returns></returns>
        bool SaveDetails5(IEnumerable<TDetail5> details5);

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesHeader();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail2();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail3();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail4();

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <returns></returns>
        List<EnablementAttribute> GetDynamicAttributesDetail5();


        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail(int pageNumber, int pageSize, TU currentDetail);

        /// <summary>
        /// Creates a new detail 2
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail2">The current detail 2.</param>
        /// <returns>Detail record</returns>
        T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail2);

        /// <summary>
        /// Creates a new detail 3
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail3">The current detail 3.</param>
        /// <returns>Detail record</returns>
        T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail3);

        /// <summary>
        /// Creates a new detail 4
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail4">The current detail 4.</param>
        /// <returns>Detail record</returns>
        T NewDetail4(int pageNumber, int pageSize, TDetail4 currentDetail4);

        /// <summary>
        /// Creates a new detail 5
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail5">The current detail 5.</param>
        /// <returns>Detail record</returns>
        T NewDetail5(int pageNumber, int pageSize, TDetail5 currentDetail5);

        /// <summary>
        /// To sync details data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail Model</param>
        /// <returns>Header Detail record</returns>
        T RefreshDetail(T model);

        /// <summary>
        /// To sync details 2 data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail 2 Model</param>
        /// <returns>Header Detail 2 record</returns>
        T RefreshDetail2(T model);

        /// <summary>
        /// To sync details 3 data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail 3 Model</param>
        /// <returns>Header Detail 3 record</returns>
        T RefreshDetail3(T model);

        /// <summary>
        /// To sync details 4 data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail 4 Model</param>
        /// <returns>Header Detail 4 record</returns>
        T RefreshDetail4(T model);

        /// <summary>
        /// To sync details 5 data based on field changes in details
        /// </summary>
        /// <param name="model">Header Detail 5 Model</param>
        /// <returns>Header Detail 5 record</returns>
        T RefreshDetail5(T model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        T ClearDetails(T model);

        /// <summary>
        /// Gets Paged Data for details
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TU> GetDetail(int currentPageNumber, int pageSize, Expression<Func<TU, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for details 2
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail2> GetDetail2(int currentPageNumber, int pageSize, Expression<Func<TDetail2, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for details 3
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail3> GetDetail3(int currentPageNumber, int pageSize, Expression<Func<TDetail3, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for details 4
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail4> GetDetail4(int currentPageNumber, int pageSize, Expression<Func<TDetail4, Boolean>> filter = null,
            OrderBy orderBy = null);

        /// <summary>
        /// Gets Paged Data for details 5
        /// </summary>
        /// <param name="currentPageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns>T.</returns>
        EnumerableResponse<TDetail5> GetDetail5(int currentPageNumber, int pageSize, Expression<Func<TDetail5, Boolean>> filter = null,
            OrderBy orderBy = null);


        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TU ProcessDetail(TU detail);

        /// <summary>
        /// Process for detail 2 entity
        /// </summary>
        /// <param name="detail2">Detail 2 model</param>
        /// <returns>TDetail2.</returns>
        TDetail2 ProcessDetail2(TDetail2 detail2);

        /// <summary>
        /// Process for detail 3 entity
        /// </summary>
        /// <param name="detail3">Detail 2 model</param>
        /// <returns>TDetail2.</returns>
        TDetail3 ProcessDetail3(TDetail3 detail3);

        /// <summary>
        /// Process for detail 4 entity
        /// </summary>
        /// <param name="detail4">Detail 4 model</param>
        /// <returns>TDetail2.</returns>
        TDetail4 ProcessDetail4(TDetail4 detail4);

        /// <summary>
        /// Process for detail 5 entity
        /// </summary>
        /// <param name="detail5">Detail 5 model</param>
        /// <returns>TDetail2.</returns>
        TDetail5 ProcessDetail5(TDetail5 detail5);

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        T Refresh(T header);

        /// <summary>
        /// Gets the Distribution Proration 
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of POOEBaseInvDistProration</returns>
        EnumerableResponse<Proration> GetDistributionProrations(int pageNumber, int pageSize,
            Expression<Func<Proration, bool>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="lineRevision">Line number to set</param>
        /// <param name="amount">Amount to set</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        void RefreshDistributionProration(int lineRevision, string amount);

        /// <summary>
        /// Sets the changed data when the user changes distribution proration value.
        /// </summary>
        /// <param name="getAmountRemaining">Return Amount Remaining or Manually prorated amount</param>
        /// <returns>Amount Remaining or Manually prorated amount</returns>
        decimal GetDistributionAmountRemaining(bool getAmountRemaining);

        /// <summary>
        /// Gets Manually Prorated Amount
        /// </summary>
        /// <returns>Amount</returns>
        decimal GetManuallyProratedAmount();

        /// <summary>
        /// Retrieves the composite rate between the given source and home currencies. 
        /// If the currencies are non-block currencies, the call functions the same as GetCurrencyRate.
        /// </summary>
        /// <param name="rateType">String param for Rate type</param>
        /// <param name="sourceCurrencyCode">String param for Source Currency Code </param>
        /// <param name="homeCurrency">String param for Home Currency Code</param>
        /// <param name="date">DateTime param for Date</param>
        /// <returns>Returns the corresponding Currency Rate object.</returns>
        CompositeCurrencyRate GetCurrencyRateComposite(string rateType, string sourceCurrencyCode, DateTime date,
            string homeCurrency = null);

        #region Comments & Instruction

        /// <summary>
        /// Gets the Comment Instruction
        /// </summary>
        /// <param name="pageNumber">Current Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="filter">Filters, if any</param>
        /// <param name="orderBy">Order By, if any</param>
        /// <returns>List of Comment Instruction</returns>
        EnumerableResponse<TDetail2> GetCommentInstruction(int pageNumber, int pageSize,
            Expression<Func<TDetail2, bool>> filter = null, OrderBy orderBy = null);

        /// <summary>
        /// Create New Comment/Instruction Line
        /// </summary>
        /// <param name="currentDetail">Current Line</param>
        /// <returns>Comments/Instruction</returns>
        TDetail2 NewCommentInstruction(TDetail2 currentDetail);

        /// <summary>
        /// Insert/Update Comments/Instruction
        /// </summary>
        /// <param name="model">Comments/Instruction model</param>
        /// <param name="comment">Comment/Instruction to set</param>
        /// <param name="lineType">Line Type</param>
        /// <returns>Comments/Instruction</returns>
        TDetail2 SaveCommentInstruction(TDetail2 model, string comment, string lineType);

        /// <summary>
        /// Get Result Count
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Total Count</returns>
        int GetCommentInstructionCount(Expression<Func<TDetail2, bool>> filter = null);

        #endregion Comments & Instruction

        /// <summary>
        /// GetDropShipAddressDetail
        /// </summary>
        /// <returns></returns>
        DropShipAddress GetDropShipAddressDetail();

        /// <summary>
        /// UpdateDropShipAddressDetail
        /// </summary>
        /// <param name="model"></param>
        void UpdateDropShipAddressDetail(DropShipAddress model);

        /// <summary>
        /// Gets Bill To Location
        /// </summary>
        /// <returns>Bill To Location Model</returns>
        BillToLocation GetBillToLocation();

        /// <summary>
        /// Sets the Bill To Location Model Attributes.
        /// </summary>
        /// <param name="model">Bill To Location Model</param>
        /// <returns>Bill To Location</returns>
        BillToLocation SetBillToLocation(BillToLocation model);

        /// <summary>
        /// GetVendorInformation
        /// </summary>
        /// <returns>VendorBase</returns>
        VendorBase GetVendorInformation();

        /// <summary>
        /// SetVendorInformation
        /// </summary>
        /// <param name="model"></param>
        void SetVendorInformation(VendorBase model);

        /// <summary>
        /// CheckValidDropShipData
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        void CheckValidDropShipData(DropShipAddress model, DropShipmentType type);
    }
}
