/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// This SageQueryProvider class defines methods to create and execute queries
    /// that are described by an <see cref="T:System.Linq.IQueryable"/> object.
    /// </summary>
    /// <typeparam name="TModel">The data model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    public class SageQueryProvider<TModel, TService> : IQueryProvider
        where TModel : ModelBase, new()
        where TService : IEntityService<TModel>
    {
        #region Properties

        /// <summary>
        /// The Sage query context.
        /// </summary>
        internal SageQueryContext<TModel, TService> SageQueryContext { get; set; }

        public TService _service;

        #endregion

        #region Constructor.

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SageQueryProvider()
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SageQueryProvider&lt;TModel, TService&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SageQueryProvider(Context context)
        {
            SageQueryContext = new SageQueryContext<TModel, TService>(context);
        }

        public TService Service
        {
            get { return _service; }
            set
            {
                _service = value;
                SageQueryContext.Service = Service;
            }
        }

        #endregion

        #region IQueryProvider implementations.

        /// <summary>
        /// This non-generic CreateQuery should produce the same result as calling the 
        /// generic CreateQuery method with the correct type argument.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable"/> that can evaluate the query represented
        /// by the specified expression tree.
        /// </returns>
        public virtual IQueryable CreateQuery(Expression expression)
        {
            try
            {
                // ASSERT: The expression's type matches the TModel type.
                var closedType = typeof(QueryableSageData<TModel, TService>);
                return (IQueryable)Activator.CreateInstance(closedType, new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        /// <summary>
        /// Queryable's collection-returning standard query operators call this method.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the elements of the <see cref="T:System.Linq.IQueryable`1"/> that is
        /// returned.
        /// </typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable`1"/> that can evaluate the query represented
        /// by the specified expression tree.
        /// </returns>
        public virtual IQueryable<TResult> CreateQuery<TResult>(Expression expression)
        {
            return (IQueryable<TResult>)new QueryableSageData<TModel,TService>(this, expression);
        }

        /// <summary>
        /// Executes the query represented by the specified expression tree.
        /// </summary>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>The value that results from executing the specified query.</returns>
        public virtual object Execute(Expression expression)
        {
            return SageQueryContext.Execute(expression, false);
        }

        /// <summary>
        /// Executes the strongly-typed query represented by a specified expression tree.
        /// Queryable's "single value" standard query operators call this method.
        /// It is also called from QueryableSageData.GetEnumerator(). 
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the value that results from executing the query.
        /// </typeparam>
        /// <param name="expression">An expression tree that represents a LINQ query.</param>
        /// <returns>The value that results from executing the specified query.</returns>
        public virtual TResult Execute<TResult>(Expression expression)
        {
            var isEnumerable = typeof(TResult).Name.Contains("IEnumerable");
            return (TResult)SageQueryContext.Execute(expression, isEnumerable);
        }

        #endregion
    }
}