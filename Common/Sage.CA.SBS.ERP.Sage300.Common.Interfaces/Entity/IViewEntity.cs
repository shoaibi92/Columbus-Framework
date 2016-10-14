/* Copyright (c) 2016 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity
{
    public interface IViewEntity
    {
        /// <summary>
        /// The instance of the view being exposed
        /// </summary>
        IBusinessEntity View { get; }

        /// <summary>
        /// The model type that represents the view
        /// </summary>
        Type ViewModelType { get; }

        /// <summary>
        /// Roto ID of the view being exposed
        /// </summary>
        string EntityName { get; }

        /// <summary>
        /// Create view instances for each resource entity and initialize them 
        /// </summary>
        /// <param name="session">The session with which to opened the view</param>
        /// <param name="context">The context to instantiate the business entity which holds the view</param>
        /// <param name="consumer">A unique identifier used for referencing this class</param>
        /// <param name="ancestralKeySegmentNames">A collection of model field names that comprise the header level key segments</param>
        void OpenViewHierarchy(IBusinessEntitySession session, Context context, string consumer, ReadOnlyCollection<string> ancestralKeySegmentNames = null);

        /// <summary>
        /// Automatically compose the view hierarchy with an available list of view instances
        /// </summary>
        /// <param name="availableViewsToCompose">The list of available views to compose with for this resource</param>
        void ComposeViewHierarchy(List<IBusinessEntity> availableViewsToCompose);

        /// <summary>
        /// Get the list of business entities encapsulating the views of this resource
        /// </summary>
        /// <returns>the list of business entities encapsulating the views of this resource</returns>
        List<IBusinessEntity> GetViewHierarchy();

        /// <summary>
        /// returns the names of the properties that comprise the key 
        /// </summary>
        /// <returns></returns>
        List<string> GetKeySegmentNames();

        /// <summary>
        /// Returns the access rights the current user has on the view
        /// </summary>
        /// <returns>a UserAccess instance representing the user's rights on the view</returns>
        UserAccess GetAccessRights();

        /// <summary>
        /// Resets the view to handle new requests to behave statelessly
        /// </summary>
        void Reset();

        /// <summary>
        /// Set the filter for the view
        /// </summary>
        /// <param name="filter">the filter to use</param>
        /// <param name="orderBy">how the records should be ordered for subsequent requests</param>
        /// <returns></returns>
        int SetFilter(string filter, OrderBy orderBy);

        /// <summary>
        /// Move the record point to the record specified by the bookmark
        /// </summary>
        /// <param name="bookmark">the dictionary of key property names and value that identifies the record</param>
        void MoveTo(Dictionary<string, object> bookmark);

        /// <summary>
        /// Gets the model at the current record pointer
        /// </summary>
        /// <returns>the model representing the current view record</returns>
        object GetModel();

        /// <summary>
        /// Create a view record from a model instance
        /// </summary>
        /// <param name="model">the model to base the view record</param>
        void Create(object model);

        /// <summary>
        /// Deletes the record at the current record pointer
        /// </summary>
        void Delete();

        /// <summary>
        /// Replace the record at the current record pointer with the provided model
        /// </summary>
        /// <param name="model">the model to replace the current record with</param>
        void Replace(object model);
    }
}
