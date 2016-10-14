/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Generic handler for exposing a set of Sage views as a resource 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ViewResourceRepository <TModel> : BaseRepository, IViewResourceRepository<TModel> where TModel : ModelBase, new()
    {
        /// <summary>
        /// The top level view resource entity being exposed
        /// </summary>
        private IViewEntity Entity { get; set; }

        /// <summary>
        /// A unique identifier used for referencing an instance of this resource class
        /// </summary>
        private string Consumer { get; set; }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        public ViewResourceRepository(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        public ViewResourceRepository(Context context, ObjectPoolType sessionPoolType)
            : base(context, sessionPoolType)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        public ViewResourceRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="sessionPoolType">Type of the session pool.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        public ViewResourceRepository(Context context, DBLinkType dbLinkType, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, sessionPoolType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Sets Context and Session and defaults DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        public ViewResourceRepository(Context context, IBusinessEntitySession session)
            : base(context, session)
        {
        }

        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        public ViewResourceRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session)
            : base(context, dbLinkType, session)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="sessionPoolType"></param>
        /// <param name="businessEntitySessionParams"></param>
        public ViewResourceRepository(Context context, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, sessionPoolType, businessEntitySessionParams)
        {
        }
        
        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        public ViewResourceRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : base(context, dbLinkType, session, sessionPoolType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Initialize this repository with the given parameters
        /// </summary>
        /// <param name="topLevelEntity">The top level view resource entity to be handled</param>
        /// <param name="consumer">The unique identifier for this class instance</param>
        public void Initialize(IViewEntity topLevelEntity, string consumer)
        {
            Entity = topLevelEntity;
            Consumer = consumer;

            Entity.OpenViewHierarchy(Session, Context, Consumer);
            Entity.ComposeViewHierarchy(Entity.GetViewHierarchy());
        }

        /// <summary>
        /// Converts a list of key value pairs into a record pointer that the entity would understand
        /// </summary>
        /// <param name="keySegments">A list of key value pairs which can identify a record. If the key is left out,
        /// the order of the list is assumed to match the order of the key segment specification in the entity</param>
        /// <returns></returns>
        private Dictionary<string, object> ConvertToBookmark(IReadOnlyList<KeyValuePair<string, object>> keySegments)
        {
            var keySegmentNames = Entity.GetKeySegmentNames();
            if (keySegmentNames.Count != keySegments.Count)
            {
                throw new ArgumentException("Key specification is invalid");
            }
            var bookmark = new Dictionary<string, object>();
            for (var i = 0; i < keySegments.Count; i++)
            {
                bookmark.Add(string.IsNullOrWhiteSpace(keySegments[i].Key) ? keySegmentNames[i] : keySegments[i].Key, keySegments[i].Value);
            }
            if (bookmark.Count != keySegmentNames.Count)
            {
                throw new ArgumentException("Key specification is invalid");
            }
            return bookmark;
        }

        /// <summary>
        /// Gets a set of resource records with a given filter and paging parameters
        /// </summary>
        /// <param name="currentPageNumber">the page to retreive</param>
        /// <param name="pageSize">the number of records to include in one page</param>
        /// <param name="filter">the filter specification used for retrieval</param>
        /// <param name="orderBy">how the record results should be ordered</param>
        /// <returns>a page of resource records as specified by the filter and paging parameters</returns>
        public virtual EnumerableResponse<TModel> Get(int currentPageNumber, int pageSize, Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            CheckRights(Entity.GetAccessRights(), SecurityType.Inquire);
            Entity.Reset();
            var count = Entity.SetFilter(ExpressionHelper.Translate(filter), orderBy);
            for (var startIndex = CommonUtil.ComputeStartIndex(currentPageNumber, pageSize); startIndex > 1; startIndex--)
            {
                if (!Entity.View.Next())
                {
                    return new EnumerableResponse<TModel>
                    {
                        Items = Enumerable.Empty<TModel>(),
                        TotalResultsCount = count
                    };
                }
            }

            var models = new List<TModel>();
            while (0 < pageSize-- && Entity.View.Next())
            {
                models.Add((TModel)Convert.ChangeType(Entity.GetModel(), typeof(TModel)));
            }
            return new EnumerableResponse<TModel>
            {
                Items = models,
                TotalResultsCount = count
            };
        }

        /// <summary>
        /// Gets a record in the resource
        /// </summary>
        /// <param name="keySegments">The key value pairs that identifies a record to be retrieved</param>
        public TModel Get(List<KeyValuePair<string, object>> keySegments)
        {
            CheckRights(Entity.GetAccessRights(), SecurityType.Inquire);
            Entity.Reset();
            Entity.MoveTo(ConvertToBookmark(keySegments));
            return (TModel)Convert.ChangeType(Entity.GetModel(), typeof(TModel));
        }

        /// <summary>
        /// Deletes a record in the resource
        /// </summary>
        /// <param name="keySegments">The key value pairs that identifies a record to be deleted</param>
        public void Delete(List<KeyValuePair<string, object>> keySegments)
        {
            CheckRights(Entity.GetAccessRights(), SecurityType.Delete);
            Entity.Reset();
            Entity.MoveTo(ConvertToBookmark(keySegments));
            Entity.Delete();
        }

        /// <summary>
        /// Replaces an existing record in the resource
        /// </summary>
        /// <param name="keySegments"></param>
        /// <param name="model"></param>
        public TModel Replace(List<KeyValuePair<string, object>> keySegments, ModelBase model)
        {
            CheckRights(Entity.GetAccessRights(), SecurityType.Modify);
            Entity.Reset();
            Entity.MoveTo(ConvertToBookmark(keySegments));
            Entity.Replace(model);
            return (TModel)Convert.ChangeType(Entity.GetModel(), typeof(TModel));
        }

        /// <summary>
        /// Gets Filtered Data
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public EnumerableResponse<TModel> Get(Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified current page number.
        /// </summary>
        /// <param name="pageOptions">The extra options.</param>
        /// <returns></returns>
        public EnumerableResponse<TModel> Get(PageOptions<TModel> pageOptions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets total count
        /// </summary>
        /// <returns></returns>
        public int GetEntityCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get First or default record
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="orderBy">Order By</param>
        /// <returns></returns>
        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null, OrderBy orderBy = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public TModel Save(TModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new record
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public TModel Add(TModel model)
        {
            CheckRights(Entity.GetAccessRights(), SecurityType.Add);
            Entity.Reset();
            Entity.Create(model);
            return (TModel)Convert.ChangeType(Entity.GetModel(), typeof(TModel));
        }

        /// <summary>
        /// Deletes the model
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public TModel Delete(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Next Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public TModel Next(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Previous Record
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>
        public TModel Previous(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        public TModel GetById<TKey>(TKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extract data for the model and export
        /// </summary>
        /// <param name="request">Export Request details</param>
        /// <returns>byte array</returns>
        public DataSet Export(ExportRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="dataSet">Data Set (all the tables)</param>
        /// <param name="request">Import Request</param>
        /// <returns>Import Response</returns>
        public ImportResponse Import(DataSet dataSet, ImportRequest request)
        {
            throw new NotImplementedException();
        }
    }
}