using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EntityState = System.Data.Entity.EntityState;


namespace NND.CA.Common.Web.ServiceReferences
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(WorkflowDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Private Members

        private readonly WorkflowDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entityToDelete">Entity</param>
        protected virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get list of Entity objects
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        /// <summary>
        /// Get an Entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Insert an Entity object
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Delete an Entity by Id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Update an Entity by Id
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        #endregion

    }
}