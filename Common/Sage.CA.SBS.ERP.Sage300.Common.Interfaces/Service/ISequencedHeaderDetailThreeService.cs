using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Linq.Expressions;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// Interface ISequencedHeaderDetailThreeService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    /// <typeparam name="TDetail2"></typeparam>
    /// <typeparam name="TDetail3"></typeparam>
    public interface ISequencedHeaderDetailThreeService<T, TU,TDetail2,TDetail3> : IEntityService<T>, ISecurityService
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
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
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail2(TDetail2 detail);

        /// <summary>
        /// Save for detail 3 entry
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns></returns>
        T SaveDetail3(TDetail3 detail);

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail.</returns>
        T SetDetail(TU detail);

        /// <summary>
        /// Sets pointer to the current Detail 2
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail2.</returns>
        T SetDetail2(TDetail2 detail);

        /// <summary>
        /// Sets pointer to the current Detail 3
        /// </summary>
        /// <param name="detail">The current detail.</param>
        /// <returns>TDetail3.</returns>
        T SetDetail3(TDetail3 detail);

        /// <summary>
        /// Save for detail entry
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails(IEnumerable<TU> details);

        /// <summary>
        /// Save for detail entry 2
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails2(IEnumerable<TDetail2> details);

        /// <summary>
        /// Save for detail entry 3
        /// </summary>
        /// <param name="details">Detail model</param>
        /// <returns></returns>
        bool SaveDetails3(IEnumerable<TDetail3> details);

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
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail);

        /// <summary>
        /// Creates a new detail 3
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentDetail">The current detail.</param>
        /// <returns>Detail record</returns>
        T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail);


        /// <summary>
        /// Refresh the details
        /// </summary>
        /// <param name="model">Ordered Header Model object</param>
        /// <returns>Updated Ordered header detail object</returns>
        T RefreshDetail(T model);

        /// <summary>
        /// Clear the detail records
        /// </summary>
        /// <param name="model">Header Detail model</param>
        /// <returns>Header record</returns>
        T ClearDetails(T model);

        /// <summary>
        /// Gets the detail.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TU> GetDetail(PageOptions<TU> pageOptions);

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
        /// Gets the detail.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TDetail2> GetDetail2(PageOptions<TDetail2> pageOptions);

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
        /// Gets the detail.
        /// </summary>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        EnumerableResponse<TDetail3> GetDetail3(PageOptions<TDetail3> pageOptions);

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
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TU.</returns>
        TU ProcessDetail(TU detail);

        /// <summary>
        /// Process for detail 2 entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TDetail2.</returns>
        TDetail2 ProcessDetail2(TDetail2 detail);

        /// <summary>
        /// Process for detail 3 entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>TDetail2.</returns>
        TDetail3 ProcessDetail3(TDetail3 detail);


        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        void Refresh(T header);
    }
}
