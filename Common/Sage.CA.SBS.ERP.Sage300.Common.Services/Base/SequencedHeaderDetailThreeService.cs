using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Base Service class for Ordered HEader detail service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    /// <typeparam name="TDetail2"></typeparam>
    /// <typeparam name="TDetail3"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SequencedHeaderDetailThreeService<T, TU, TDetail2, TDetail3, TEntity> : BaseService,
        ISequencedHeaderDetailThreeService<T, TU, TDetail2, TDetail3>
        where T : ModelBase, new()
        where TU : ModelBase, new()
        where TDetail2 : ModelBase, new()
        where TDetail3 : ModelBase, new()
        where TEntity : ISequencedHeaderDetailThreeRepository<T, TU, TDetail2, TDetail3>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        protected SequencedHeaderDetailThreeService(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Creates a new Header.
        /// </summary>
        /// <returns>Header record</returns>
        public virtual T NewHeader()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewHeader();
            }
        }

        /// <summary>
        /// Creates a new detail
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual T NewDetail(int pageNumber, int pageSize, TU currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewDetail(pageNumber, pageSize, currentDetail);
            }
        }

        /// <summary>
        /// Creates a new detail 2
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual T NewDetail2(int pageNumber, int pageSize, TDetail2 currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewDetail2(pageNumber, pageSize, currentDetail);
            }
        }

        /// <summary>
        /// Creates a new detail 2
        /// </summary>
        /// <returns>Detail record</returns>
        public virtual T NewDetail3(int pageNumber, int pageSize, TDetail3 currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.NewDetail3(pageNumber, pageSize, currentDetail);
            }
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
        public virtual EnumerableResponse<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Get(filter, orderBy);
            }
        }

        /// <summary>
        /// Get Records based on page size 
        /// </summary>
        /// <param name="currentPageNumber">currentPageNumber</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="filter">filter</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns> </returns>
        public virtual EnumerableResponse<T> Get(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<T, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
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
        public virtual T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> filter = null,
            OrderBy orderBy = null)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.FirstOrDefault(filter, orderBy);
            }
        }

        /// <summary>
        ///Save
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public virtual T Save(T model)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Save(model);
            }
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual T Delete(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Delete(filter);
            }
        }

        /// <summary>
        /// Get next 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public T Next(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Next(filter);
            }
        }

        /// <summary>
        /// Get previous 
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public virtual T Previous(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Previous(filter);
            }
        }

        /// <summary>
        /// Refresh  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T RefreshDetail(T model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.RefreshDetail(model);
            }
        }

        /// <summary>
        /// Sets pointer to the current Detail
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual T SetDetail(TU currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SetDetail(currentDetail);
            }
        }

        /// <summary>
        /// Sets pointer to the current Detail 2
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual T SetDetail2(TDetail2 currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SetDetail2(currentDetail);
            }
        }

        /// <summary>
        /// Sets pointer to the current Detail 3
        /// </summary>
        /// <param name="currentDetail"></param>
        /// <returns></returns>
        public virtual T SetDetail3(TDetail3 currentDetail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SetDetail3(currentDetail);
            }
        }

        /// <summary>
        /// Clear  detail records
        /// </summary>
        /// <param name="model"> model</param>
        /// <returns></returns>
        public virtual T ClearDetails(T model)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ClearDetails(model);
            }
        }

        /// <summary>
        /// Process for detail entity
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TU ProcessDetail(TU detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ProcessDetail(detail);
            }
        }

        /// <summary>
        /// Process for detail entity 2
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TDetail2 ProcessDetail2(TDetail2 detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ProcessDetail2(detail);
            }
        }

        /// <summary>
        /// Process for detail entity 2
        /// </summary>
        /// <param name="detail">Detail model</param>
        /// <returns>Detail record</returns>
        public virtual TDetail3 ProcessDetail3(TDetail3 detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.ProcessDetail3(detail);
            }
        }

        /// <summary>
        /// Insert a header record
        /// </summary>
        /// <param name="model">Ordered header detail model</param>
        /// <returns>Inserted ordered header record</returns>
        public virtual T Add(T model)
        {
            using (var repository = Resolve<IBusinessRepository<T>>())
            {
                return repository.Add(model);
            }
        }

        /// <summary>
        /// Gets the record by ID
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns>Header record</returns>
        public virtual T GetById<TKey>(TKey key)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetById(key);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetAccessRights();
            }
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TU> GetDetail(PageOptions<TU> extraOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(extraOptions);
            }
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
            System.Linq.Expressions.Expression<Func<TU, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TDetail2> GetDetail2(PageOptions<TDetail2> extraOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail2(extraOptions);
            }
        }

        /// <summary>
        /// Retrieve Details records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail2> GetDetail2(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<TDetail2, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail2(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Gets Paged Data
        /// </summary>
        /// <param name="extraOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TDetail3> GetDetail3(PageOptions<TDetail3> extraOptions)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail3(extraOptions);
            }
        }

        /// <summary>
        /// Retrieve Details records page wise
        /// </summary>
        /// <param name="currentPageNumber">Page Number</param>
        /// <param name="pageSize">No of records to be retrieved per page</param>
        /// <param name="filter">Filter criteria</param>
        /// <param name="orderBy">Sorting order</param>
        /// <returns>Paged data for details record</returns>
        public virtual EnumerableResponse<TDetail3> GetDetail3(int currentPageNumber, int pageSize,
            System.Linq.Expressions.Expression<Func<TDetail3, bool>> filter = null, OrderBy orderBy = null)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetDetail3(currentPageNumber, pageSize, filter, orderBy);
            }
        }

        /// <summary>
        /// Refreshes the specified header.
        /// </summary>
        /// <param name="header">header entity.</param>
        public void Refresh(T header)
        {
            using (var repository = Resolve<TEntity>())
            {
                repository.Refresh(header);
            }
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail(TU detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetail(detail);
            }
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail2(TDetail2 detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetail2(detail);
            }
        }

        /// <summary>
        /// Save Detail
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T SaveDetail3(TDetail3 detail)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetail3(detail);
            }
        }


        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails(IEnumerable<TU> details)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetails(details);
            }
        }

        /// <summary>
        /// Save details 2
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails2(IEnumerable<TDetail2> details)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetails2(details);
            }
        }

        /// <summary>
        /// Save details 2
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveDetails3(IEnumerable<TDetail3> details)
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.SaveDetails3(details);
            }
        }
    }
}
