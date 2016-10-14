/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.LinqToSageProvider
{
    /// <summary>
    /// This QueryableSageData class provides functionality to evaluate queries.
    /// NOTE: QueryableSageData indirectly implements the IQueryable interface.
    /// </summary>
    /// <typeparam name="TModel">The data model.</typeparam>
    /// <typeparam name="TService">TModel's corresponding service.</typeparam>
    public class QueryableSageData<TModel, TService> : IOrderedQueryable<TModel>
        where TModel : ModelBase, new()
        where TService : IEntityService<TModel>
    {
        #region Two constructors.

        public QueryableSageData()
        {            
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="QueryableSageData&lt;TModel, TService&gt;"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called by the ODataController layer to create the data source.
        /// </remarks>
        public QueryableSageData(Context context)
        {
            Provider = new SageQueryProvider<TModel, TService>(context);
            Expression = Expression.Constant(this);
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="QueryableSageData&lt;TModel, TService&gt;"/> class.
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="provider">The query provider associated with this data source</param>
        public QueryableSageData(Context context, IQueryProvider provider) : this(context)
        {
            Provider = provider;
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="QueryableSageData&lt;TModel, TService&gt;"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called internally by Provider.CreateQuery(). 
        /// </remarks>
        /// <param name="provider">The query provider associated with this data source.</param>
        /// <param name="expression">The associated expression tree.</param>
        public QueryableSageData(IQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<TModel>).IsAssignableFrom(expression.Type))
            {
                throw new NotSupportedException("expression");
            }

            Provider = provider;
            Expression = expression;
        }

        #endregion

        #region Three IQueryable properties.

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        public IQueryProvider Provider { get; protected set; }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable"/>.
        /// </summary>
        public  Expression Expression { get; protected set; }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated
        /// with this instance of <see cref="T:System.Linq.IQueryable"/> is executed.
        /// </summary>
        public virtual Type ElementType
        {
            get { return typeof(TModel); }
        }

        #endregion

        #region Two IEnumerable methods.

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be
        /// used to iterate through the collection.
        /// </returns>
        public virtual IEnumerator<TModel> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<TModel>>(Expression)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be
        /// used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<IEnumerable>(Expression)).GetEnumerator();
        }

        #endregion
    }
}