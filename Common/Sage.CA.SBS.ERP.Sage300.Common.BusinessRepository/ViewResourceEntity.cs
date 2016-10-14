/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

// ReSharper disable BitwiseOperatorOnEnumWithoutFlags
namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Generic handler for exposing a single view as a resource
    /// </summary>
    /// <typeparam name="TModel">The model type that represents the top level view</typeparam>
    /// <typeparam name="TModelMapper">The model mapper that translates values between the model and the view</typeparam>
    public class ViewResourceEntity<TModel, TModelMapper> : IViewEntity
        where TModel : ModelBase, new()
        where TModelMapper : ModelMapper<TModel>
    {
        /// <summary>
        /// Creates a new instance of ViewResourceEntity with one key segment
        /// </summary>
        /// <typeparam name="TKeySegment"></typeparam>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">specify whether this view's key segments values are generated or user specified</param>
        /// <param name="keySegment">the model property that represents the key segment being introduced</param>
        /// <returns>the newly created instance of ViewResourceEntity</returns>
        public static ViewResourceEntity<TModel, TModelMapper> Create<TKeySegment>(string viewEntityName, ViewKeyType viewKeyType, Expression<Func<TModel, TKeySegment>> keySegment)
        {
            return new ViewResourceEntity<TModel, TModelMapper>(viewEntityName, viewKeyType, new List<MemberInfo> { GetMemberInfo(keySegment) });
        }

        /// <summary>
        /// Creates a new instance of ViewResourceEntity with two key segments
        /// </summary>
        /// <typeparam name="TKeySegment1"></typeparam>
        /// <typeparam name="TKeySegment2"></typeparam>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">specify whether this view's key segments values are generated or user specified</param>
        /// <param name="keySegment1"></param><param name="keySegment2"></param>
        /// <returns></returns>
        public static ViewResourceEntity<TModel, TModelMapper> Create<TKeySegment1, TKeySegment2>(string viewEntityName, ViewKeyType viewKeyType, Expression<Func<TModel, TKeySegment1>> keySegment1, Expression<Func<TModel, TKeySegment2>> keySegment2)
        {
            return new ViewResourceEntity<TModel, TModelMapper>(viewEntityName, viewKeyType, new List<MemberInfo> { GetMemberInfo(keySegment1), GetMemberInfo(keySegment2) });
        }

        /// <summary>
        /// Creates a new instance of ViewResourceEntity with three key segments
        /// </summary>
        /// <typeparam name="TKeySegment1"></typeparam><typeparam name="TKeySegment2"></typeparam><typeparam name="TKeySegment3"></typeparam>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">specify whether this view's key segments values are generated or user specified</param>
        /// <param name="keySegment1"></param><param name="keySegment2"></param><param name="keySegment3"></param>
        /// <returns></returns>
        public static ViewResourceEntity<TModel, TModelMapper> Create<TKeySegment1, TKeySegment2, TKeySegment3>(string viewEntityName, ViewKeyType viewKeyType, Expression<Func<TModel, TKeySegment1>> keySegment1, Expression<Func<TModel, TKeySegment2>> keySegment2, Expression<Func<TModel, TKeySegment3>> keySegment3)
        {
            return new ViewResourceEntity<TModel, TModelMapper>(viewEntityName, viewKeyType, new List<MemberInfo> { GetMemberInfo(keySegment1), GetMemberInfo(keySegment2), GetMemberInfo(keySegment3) });
        }

        /// <summary>
        /// Creates a new instance of ViewResourceEntity with four key segments
        /// </summary>
        /// <typeparam name="TKeySegment1"></typeparam><typeparam name="TKeySegment2"></typeparam><typeparam name="TKeySegment3"></typeparam><typeparam name="TKeySegment4"></typeparam>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">specify whether this view's key segments values are generated or user specified</param>
        /// <param name="keySegment1"></param><param name="keySegment2"></param><param name="keySegment3"></param><param name="keySegment4"></param>
        /// <returns></returns>
        public static ViewResourceEntity<TModel, TModelMapper> Create<TKeySegment1, TKeySegment2, TKeySegment3, TKeySegment4>(string viewEntityName, ViewKeyType viewKeyType, Expression<Func<TModel, TKeySegment1>> keySegment1, Expression<Func<TModel, TKeySegment2>> keySegment2, Expression<Func<TModel, TKeySegment3>> keySegment3, Expression<Func<TModel, TKeySegment4>> keySegment4)
        {
            return new ViewResourceEntity<TModel, TModelMapper>(viewEntityName, viewKeyType, new List<MemberInfo> { GetMemberInfo(keySegment1), GetMemberInfo(keySegment2), GetMemberInfo(keySegment3), GetMemberInfo(keySegment4) });
        }

        /// <summary>
        /// Creates a new instance of ViewResourceEntity with five key segments
        /// </summary>
        /// <typeparam name="TKeySegment1"></typeparam><typeparam name="TKeySegment2"></typeparam><typeparam name="TKeySegment3"></typeparam><typeparam name="TKeySegment4"></typeparam> <typeparam name="TKeySegment5"></typeparam>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">specify whether this view's key segments values are generated or user specified</param>
        /// <param name="keySegment1"></param><param name="keySegment2"></param><param name="keySegment3"></param><param name="keySegment4"></param><param name="keySegment5"></param>
        /// <returns></returns>
        public static ViewResourceEntity<TModel, TModelMapper> Create<TKeySegment1, TKeySegment2, TKeySegment3, TKeySegment4, TKeySegment5>(string viewEntityName, ViewKeyType viewKeyType, Expression<Func<TModel, TKeySegment1>> keySegment1, Expression<Func<TModel, TKeySegment2>> keySegment2, Expression<Func<TModel, TKeySegment3>> keySegment3, Expression<Func<TModel, TKeySegment4>> keySegment4, Expression<Func<TModel, TKeySegment5>> keySegment5)
        {
            return new ViewResourceEntity<TModel, TModelMapper>(viewEntityName, viewKeyType, new List<MemberInfo> { GetMemberInfo(keySegment1), GetMemberInfo(keySegment2), GetMemberInfo(keySegment3), GetMemberInfo(keySegment4), GetMemberInfo(keySegment5) });
        }

        /// <summary>
        /// Private contructor
        /// </summary>
        /// <param name="viewEntityName">roto ID of the view being handled (e.g. "GL0001")</param>
        /// <param name="viewKeyType">Specify whether this view's key segments values are generated or user specified</param>
        /// <param name="viewKeySegments">The model's property that corresponds to the key segments in the view</param>
        private ViewResourceEntity(string viewEntityName, ViewKeyType viewKeyType, List<MemberInfo> viewKeySegments)
        {
            EntityName = viewEntityName;
            KeyType = viewKeyType;
            KeySegments = viewKeySegments;
            DetailEntities = new List<DetailEntity>();
        }

        /// <summary>
        /// The instance of the view being exposed
        /// </summary>
        public IBusinessEntity View { get; private set; }

        /// <summary>
        /// The model type that represents the view
        /// </summary>
        public Type ViewModelType { get { return typeof(TModel); } }

        /// <summary>
        /// Roto ID of the view being exposed
        /// </summary>
        public string EntityName { get; private set; }

        /// <summary>
        /// Create view instances for each resource entity and initialize them 
        /// </summary>
        /// <param name="session">The session with which to opened the view</param>
        /// <param name="context">The context to instantiate the business entity which holds the view</param>
        /// <param name="consumer">A unique identifier used for referencing this class</param>
        /// <param name="ancestralKeySegmentNames">A collection of model field names that comprise the header level key segments</param>
        public void OpenViewHierarchy(IBusinessEntitySession session, Context context, string consumer, ReadOnlyCollection<string> ancestralKeySegmentNames = null)
        {
            Context = context;
            View = session.OpenView(EntityName, session, consumer, context, false);
            ViewProtocol = View.InstanceProtocol;
            AncestralKeySegmentNames = ancestralKeySegmentNames ?? new ReadOnlyCollection<string>(new List<string>());

            var fullKeySegmentNames = new ReadOnlyCollection<string>(AncestralKeySegmentNames.Concat(GetKeySegmentNames()).ToList());
            foreach (var detail in DetailEntities)
            {
                detail.Entity.OpenViewHierarchy(session, context, consumer, fullKeySegmentNames);
            }
        }

        /// <summary>
        /// Automatically compose the view hierarchy with an available list of view instances
        /// </summary>
        /// <param name="availableViewsToCompose">The list of available views to compose with for this resource</param>
        public void ComposeViewHierarchy(List<IBusinessEntity> availableViewsToCompose)
        {
            var compositeNames = View.ComposedViewNames;
            View.Compose(compositeNames.Select(compositeName => availableViewsToCompose.FirstOrDefault(x => string.Compare(x.Name, compositeName, StringComparison.Ordinal) == 0)).Select(entity => entity == null ? null : entity.View).ToArray());

            foreach (var detail in DetailEntities)
            {
                detail.Entity.ComposeViewHierarchy(availableViewsToCompose);
            }
        }

        /// <summary>
        /// Get the list of business entities encapsulating the views of this resource
        /// </summary>
        /// <returns>the list of business entities encapsulating the views of this resource</returns>
        public List<IBusinessEntity> GetViewHierarchy()
        {
            var results = new List<IBusinessEntity> { View };
            foreach (var detail in DetailEntities)
            {
                results.AddRange(detail.Entity.GetViewHierarchy());
            }
            return results;
        }

        /// <summary>
        /// returns the names of the properties that comprise the key 
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeySegmentNames()
        {
            return KeySegments.Select(keySegment => ((PropertyInfo)keySegment).Name).ToList();
        }

        /// <summary>
        /// Returns the access rights the current user has on the view
        /// </summary>
        /// <returns>a UserAccess instance representing the user's rights on the view</returns>
        public UserAccess GetAccessRights()
        {
            var userAccess = new UserAccess();

            if (View.CanModify)
            {
                userAccess.SecurityType = SecurityType.Add | SecurityType.Delete | SecurityType.Modify;
            }

            if (View.CanPost)
            {
                userAccess.SecurityType = userAccess.SecurityType == SecurityType.None ? SecurityType.Post : (userAccess.SecurityType | SecurityType.Post);
            }

            if (View.CanInquire)
            {
                userAccess.SecurityType = userAccess.SecurityType == SecurityType.None ? (SecurityType.Inquire | SecurityType.Print) : (userAccess.SecurityType | SecurityType.Inquire | SecurityType.Print);
            }
            return userAccess;
        }

        /// <summary>
        /// Resets the view to handle new requests to behave statelessly
        /// </summary>
        public void Reset()
        {
            View.Cancel();
            foreach (var detail in DetailEntities)
            {
                detail.Entity.Reset();
            }
        }

        /// <summary>
        /// Set the filter for the view
        /// </summary>
        /// <param name="filter">the filter to use</param>
        /// <param name="orderBy">how the records should be ordered for subsequent requests</param>
        /// <returns></returns>
        public int SetFilter(string filter, OrderBy orderBy)
        {
            View.FilterSelect(filter, OrderByHelper.IsAscending(orderBy), OrderByHelper.GetIndex<TModel>(orderBy), ViewFilterOrigin.FromStart);
            return View.FilterCount(filter, 0);
        }

        /// <summary>
        /// Move the record point to the record specified by the bookmark
        /// </summary>
        /// <param name="bookmark">the dictionary of key property names and value that identifies the record</param>
        public void MoveTo(Dictionary<string, object> bookmark)
        {
            for (var i = 0; i < KeySegments.Count; i++)
            {
                var fieldName = ((PropertyInfo)KeySegments[i]).Name;
                if (!bookmark.ContainsKey(fieldName))
                {
                    throw new ArgumentException("Key specification is invalid");
                }
                View.SetValue(i + AncestralKeySegmentNames.Count + 1, bookmark[fieldName]);
            }
            View.Read(false);
        }

        /// <summary>
        /// Gets the model at the current record pointer
        /// </summary>
        /// <returns>the model representing the current view record</returns>
        public object GetModel()
        {
            var mapper = (TModelMapper)Activator.CreateInstance(typeof(TModelMapper), Context);
            var model = mapper.Map(View);
            foreach (var detailEntity in DetailEntities)
            {
                if (detailEntity.Entity.View.Top())
                {
                    var listType = typeof(List<>).MakeGenericType(detailEntity.Entity.ViewModelType);
                    var details = (IList)Activator.CreateInstance(listType);
                    do
                    {
                        var detailModel = detailEntity.Entity.GetModel();
                        details.Add(Convert.ChangeType(detailModel, detailEntity.Entity.ViewModelType));
                    } while (detailEntity.Entity.View.Next());

                    var detailPropertyInfo = (PropertyInfo)detailEntity.DetailPropertyInfo;
                    var detailPropertyType = detailPropertyInfo.PropertyType;
                    if (detailPropertyType.IsGenericType)
                    {
                        if (detailPropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            detailPropertyInfo.SetValue(model, details);
                        }
                        else if (detailPropertyType.GetGenericTypeDefinition() == typeof(EnumerableResponse<>))
                        {
                            var enumerableResponseType = typeof(EnumerableResponse<>).MakeGenericType(detailEntity.Entity.ViewModelType);
                            var enumerableResponse = Activator.CreateInstance(enumerableResponseType);
                            enumerableResponseType.GetProperty("Items").SetValue(enumerableResponse, details);
                            enumerableResponseType.GetProperty("TotalResultsCount").SetValue(enumerableResponse, details.Count);
                            detailPropertyInfo.SetValue(model, enumerableResponse);
                        }
                        else
                        {
                            throw new HttpUnhandledException("Unhandled generic detail container.");
                        }
                    }
                    else
                    {
                        if (details.Count == 1)
                        {
                            detailPropertyInfo.SetValue(model, details[0]);
                        }
                        else if (details.Count > 1)
                        {
                            throw new InvalidOperationException("There is more than one record for the singleton detail definition");
                        }
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// Create a view record from a model instance
        /// </summary>
        /// <param name="model">the model to base the view record</param>
        public void Create(object model)
        {
            View.GenerateRecord(ViewType == ViewProtocolType.Batch);

            for (var idx = 1; idx <= AncestralKeySegmentNames.Count; idx++)
            {
                // Header key segment values must be preserved to prevent potential orphans
                var propertyInfo = typeof(TModel).GetProperty(AncestralKeySegmentNames[idx - 1]); // assume key field names in TModel follow ancestors
                propertyInfo.SetValue(model, View.GetValue<object>(idx));
            }

            if (KeyType == ViewKeyType.Sequenced)
            {
                // Sequenced key segments have been generated in View.GenerateRecord and must be preserved
                for (var i = 0; i < KeySegments.Count; i++)
                {
                    ((PropertyInfo)KeySegments[i]).SetValue(model, View.GetValue<object>(i + AncestralKeySegmentNames.Count + 1));
                }
            }

            var mapper = (TModelMapper)Activator.CreateInstance(typeof(TModelMapper), Context);
            mapper.Map((TModel)model, View);

            if (ViewType == ViewProtocolType.Batch)
                View.Update();

            CreateDetails(model);

            if (ViewType != ViewProtocolType.Batch)
                View.Insert();

            if (HasRevisions && ViewType != ViewProtocolType.Detail)
                View.Post();
        }

        /// <summary>
        /// Deletes the record at the current record pointer
        /// </summary>
        public void Delete()
        {
            View.Delete();
        }

        /// <summary>
        /// Replace the record at the current record pointer with the provided model
        /// </summary>
        /// <param name="model">the model to replace the current record with</param>
        public void Replace(object model)
        {
            // Preserve all key segments
            for (var i = 0; i < KeySegments.Count; i++)
            {
                ((PropertyInfo)KeySegments[i]).SetValue(model, View.GetValue<object>(i + AncestralKeySegmentNames.Count + 1));
            }

            var mapper = (TModelMapper)Activator.CreateInstance(typeof(TModelMapper), Context);
            mapper.Map((TModel)model, View);

            if (ViewType == ViewProtocolType.Batch)
                View.Update();

            // Purge all details
            foreach (var detailEntity in DetailEntities)
            {
                if (detailEntity.Entity.View.Top())
                {
                    do
                    {
                        detailEntity.Entity.View.Delete();
                    } while (detailEntity.Entity.View.Next());
                }
            }

            CreateDetails(model); // Create details based on new model

            View.Update();

            if (HasRevisions && ViewType != ViewProtocolType.Detail)
                View.Post();
        }

        /// <summary>
        /// The properties in the model which comprise the key segments inherited from ancestral ViewResourceEntities
        /// </summary>
        private ReadOnlyCollection<string> AncestralKeySegmentNames { get; set; }

        /// <summary>
        /// The property member info within the model representing the key segments this view introduces
        /// </summary>
        private List<MemberInfo> KeySegments { get; set; }

        /// <summary>
        /// A reference to the immediate details of this view entity
        /// </summary>
        private List<DetailEntity> DetailEntities { get; set; }

        /// <summary>
        /// A bitwise indicator that holds information about the view
        /// </summary>
        private ViewProtocol ViewProtocol { get; set; }
        
        /// <summary>
        /// Indicates whether the key segments are system generated or user specified
        /// </summary>
        private ViewKeyType KeyType { get; set; }

        /// <summary>
        /// The context with which the view was instantiated
        /// </summary>
        private Context Context { get; set; }

        /// <summary>
        /// Indicates whether the view uses revisions
        /// </summary>
        private bool HasRevisions { get { return ((ViewProtocol & ViewProtocol.MaskRevision) != 0); } }

        /// <summary>
        /// Indicates the type of view this is in the hierarchy
        /// </summary>
        private ViewProtocolType ViewType
        {
            get
            {
                switch (ViewProtocol & ViewProtocol.MaskBasic)
                {
                    case ViewProtocol.BasicHeader:
                        return ViewProtocolType.Header;
                    case ViewProtocol.BasicDetail:
                        return ViewProtocolType.Detail;
                    case ViewProtocol.BasicBatch:
                        return ViewProtocolType.Batch;
                    case ViewProtocol.BasicSuper:
                        return ViewProtocolType.Super;
                    default:
                        return ViewProtocolType.Flat;
                }
            }
        }

        /// <summary>
        /// Called on a header ViewResourceEntity to define a detail relationship with another ViewResourceEntity
        /// </summary>
        /// <typeparam name="TDetailField"></typeparam>
        /// <param name="entity">The detail entity to add</param>
        /// <param name="detailField">The field in the model which contain the detail records</param>
        public void AddDetail<TDetailField>(IViewEntity entity, Expression<Func<TModel, TDetailField>> detailField)
        {
            DetailEntities.Add(new DetailEntity { Entity = entity, DetailPropertyInfo = GetMemberInfo(detailField) });
        }

        /// <summary>
        /// Returns the MemberInfo for a generic model property being passed in
        /// </summary>
        /// <typeparam name="TObject">the model type</typeparam>
        /// <typeparam name="TProperty">the member property</typeparam>
        /// <param name="expression">the property of the model which holds the detail records</param>
        /// <returns></returns>
        private static MemberInfo GetMemberInfo<TObject, TProperty>(Expression<Func<TObject, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
            {
                return member.Member;
            }
            throw new ArgumentException("The specified member does not exist.");
        }

        /// <summary>
        /// Creates the corresponding detail view records for a given model
        /// </summary>
        /// <param name="model">the model holding the details to create</param>
        private void CreateDetails(object model)
        {
            foreach (var detailEntity in DetailEntities)
            {
                var detailPropertyInfo = (PropertyInfo)detailEntity.DetailPropertyInfo;
                var detailPropertyType = detailPropertyInfo.PropertyType;
                if (detailPropertyType.IsGenericType)
                {
                    if (detailPropertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        foreach (var detail in (IList)detailPropertyInfo.GetValue(model))
                        {
                            detailEntity.Entity.Create(detail);
                        }
                    }
                    else if (detailPropertyType.GetGenericTypeDefinition() == typeof(EnumerableResponse<>))
                    {
                        var enumerableResponse = detailPropertyInfo.GetValue(model);
                        var itemsPropertyInfo = enumerableResponse.GetType().GetProperty("Items");
                        foreach (var detail in (IList)itemsPropertyInfo.GetValue(enumerableResponse))
                        {
                            detailEntity.Entity.Create(detail);
                        }
                    }
                }
                else
                {
                    detailEntity.Entity.Create(detailPropertyInfo.GetValue(model));
                }
            }
        }
        
        /// <summary>
        /// internal view type info which determines the view protocol to use
        /// </summary>
        private enum ViewProtocolType
        {
            Flat,   // A one level view
            Batch,  // Batch level view for grouping headers together
            Header, // Top-most header level view with details
            Detail, // Detail level view
            Super,  // Specialized view for handling custom processing
        }

        /// <summary>
        /// internal class to hold detail information
        /// </summary>
        private class DetailEntity
        {
            public IViewEntity Entity { get; set; }
            public MemberInfo DetailPropertyInfo { get; set; }
        }
    }

    /// <summary>
    /// Indicates whether a key is system generated or user specified
    /// </summary>
    public enum ViewKeyType
    {
        Ordered,   // Key segments are user specified
        Sequenced, // Key segments are system generated
    }
}