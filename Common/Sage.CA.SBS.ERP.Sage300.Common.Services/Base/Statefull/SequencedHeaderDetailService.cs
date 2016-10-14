using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base.Statefull;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base.Statefull
{
     /// <summary>
    /// Base Service class for Ordered HEader detail service
    /// </summary>
    /// <typeparam name="THeader">Header entity</typeparam>
    /// <typeparam name="TDetail">Detail Entity</typeparam>
    /// <typeparam name="TEntity">Repositry</typeparam>
    public abstract class SequencedHeaderDetailService<THeader, TDetail, TEntity> : BaseService,
        ISequencedHeaderDetailService<THeader, TDetail>
        where THeader : ModelBase, new()
        where TDetail : ModelBase, new()
        where TEntity : ISequencedHeaderDetailRepository<THeader, TDetail>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected SequencedHeaderDetailService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        public virtual THeader NewHeader()
        {
            var repository = Resolve<TEntity>();
            return repository.NewHeader();
        }

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual THeader NewDetail(int pageNumber, int pageSize, TDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.NewDetail(pageNumber, pageSize, currentDetail);
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<THeader> Get(PageOptions<THeader> extraOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get record based on filter
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public virtual EnumerableResponse<THeader> Get(System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
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
        public virtual EnumerableResponse<THeader> Get(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            {
                return repository.Get(currentPageNumber, pageSize, filter, orderBy);
            }
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
        /// Retrieve first or default  based on the filter expression
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns></returns>
        public virtual THeader FirstOrDefault(System.Linq.Expressions.Expression<Func<THeader, bool>> filter = null,
            OrderBy orderBy = null)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.FirstOrDefault(filter, orderBy);
        }

        /// <summary>
        ///Save
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public virtual THeader Save(THeader model)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.Save(model);
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual THeader Delete(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.Delete(filter);
        }

        /// <summary>
        /// Get next 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public THeader Next(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.Next(filter);
        }

        /// <summary>
        /// Get previous 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual THeader Previous(System.Linq.Expressions.Expression<Func<THeader, bool>> filter)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.Previous(filter);
        }

        /// <summary>
        /// Refresh  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual THeader RefreshDetail(THeader model)
        {
            var repository = Resolve<TEntity>();
            return repository.RefreshDetail(model);
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual THeader SetDetail(TDetail currentDetail)
        {
            var repository = Resolve<TEntity>();
            return repository.SetDetail(currentDetail);
        }

        /// <summary>
        /// Clear  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual THeader ClearDetails(THeader model)
        {
            var repository = Resolve<TEntity>();
            return repository.ClearDetails(model);
        }

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TDetail ProcessDetail(TDetail detail)
        {
            var repository = Resolve<TEntity>();
            return repository.ProcessDetail(detail);
        }

        /// <summary>
        /// Insert a header record
        /// </summary>
        /// <param name="model">Ordered header detail model</param>
        /// <returns>Inserted ordered header record</returns>
        public virtual THeader Add(THeader model)
        {
            var repository = Resolve<IBusinessRepository<THeader>>();
            return repository.Add(model);
        }

        /// <summary>
        /// Gets the record by ID
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns>Header record</returns>
        public virtual THeader GetById<TKey>(TKey key)
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
        public virtual EnumerableResponse<TDetail> GetDetail(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<TDetail, bool>> filter = null, OrderBy orderBy = null)
        {
            var repository = Resolve<TEntity>();
            return repository.GetDetail(currentPageNumber, pageSize, filter, orderBy);
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public void Refresh(THeader header)
        {
            var repository = Resolve<TEntity>();
            repository.Refresh(header);
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public THeader SaveDetail(TDetail detail)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetail(detail);
        }

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails(IEnumerable<TDetail> details)
        {
            var repository = Resolve<TEntity>();
            return repository.SaveDetails(details);
        }
    }
}
