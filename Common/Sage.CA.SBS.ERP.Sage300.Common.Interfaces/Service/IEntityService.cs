///* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

//#region

//using Sage.CA.SBS.ERP.Sage300.Common.Models;
//using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
//using System;
//using System.Linq.Expressions;

//#endregion

//namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
//{
//    /// <summary>
//    /// The API definition of the functions exposed by the Business Views
//    /// </summary>
//    /// <typeparam name="T">T of type ModelBase</typeparam>
//    public interface IEntityService<T> where T : ModelBase
//    {
//        /// <summary>
//        /// IsReadOnly property - opens business entity in readonly mode
//        /// </summary>
//        bool IsReadOnly { get; set; }

//        /// <summary>
//        /// Gets Filtered Data
//        /// </summary>
//        /// <param name="filter">Filter</param>
//        /// <param name="orderBy">Order By</param>
//        /// <returns></returns>
//        EnumerableResponse<T> Get(Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

//        /// <summary>
//        /// Gets Paged Data
//        /// </summary>
//        /// <param name="pageOptions">The extra options.</param>
//        /// <returns></returns>
//        EnumerableResponse<T> Get(PageOptions<T> pageOptions);

//        /// <summary>
//        /// Gets Paged Data
//        /// </summary>
//        /// <param name="currentPageNumber">Current Page Number</param>
//        /// <param name="pageSize">Page Size</param>
//        /// <param name="filter">Filter</param>
//        /// <param name="orderBy">Order By</param>
//        /// <returns></returns>
//        EnumerableResponse<T> Get(int currentPageNumber, int pageSize, Expression<Func<T, Boolean>> filter = null,
//            OrderBy orderBy = null);

//        /// <summary>
//        /// Get First record
//        /// </summary>
//        /// <param name="filter">Filter</param>
//        /// <param name="orderBy">Order By</param>
//        /// <returns></returns>
//        T FirstOrDefault(Expression<Func<T, Boolean>> filter = null, OrderBy orderBy = null);

//        /// <summary>
//        /// Add new model 
//        /// </summary>
//        /// <param name="model">Model to be added</param>
//        /// <returns>T</returns>
//        T Add(T model);

//        /// <summary>
//        /// Update model 
//        /// </summary>
//        /// <param name="model">Model to be updated</param>
//        /// <returns>Updated model</returns>
//        T Save(T model);

//        /// <summary>
//        /// Delete model
//        /// </summary>
//        /// <param name="filter"></param>
//        /// <returns></returns>
//        T Delete(Expression<Func<T, Boolean>> filter);

//        /// <summary>
//        /// Next Record
//        /// </summary>
//        /// <param name="filter">filter</param>
//        /// <returns></returns>
//        T Next(Expression<Func<T, Boolean>> filter);

//        /// <summary>
//        /// Previous Record
//        /// </summary>
//        /// <param name="filter">filter</param>
//        /// <returns></returns>
//        T Previous(Expression<Func<T, Boolean>> filter);

//        /// <summary>
//        /// Get data by Id
//        /// </summary>
//        /// <typeparam name="TKey"></typeparam>
//        /// <param name="key">key</param>
//        /// <returns></returns>
//        T GetById<TKey>(TKey key);

//        /// <summary>
//        /// Get all the details of all the items for the selected options, which has to be exported
//        /// </summary>
//        /// <param name="request">Request data</param>
//        /// <returns>Request data with item details filled</returns>
//        ExportResponse Export(ExportRequest request);

//        /// <summary>
//        /// Import - add to queue
//        /// </summary>
//        /// <param name="request"></param>
//        /// <returns></returns>
//        ImportResponse Import(ImportRequest request);

//        /// <summary>
//        /// Get Status - Export
//        /// </summary>
//        /// <param name="request">Request</param>
//        /// <returns>Status Model</returns>
//        ExportResponse ExportStatus(ExportResponse request);

//        /// <summary>
//        /// Get Status - Import
//        /// </summary>
//        /// <param name="request">Request</param>
//        /// <returns>Status Model</returns>
//        ImportResponse ImportStatus(ImportResponse request);
//    }
//}