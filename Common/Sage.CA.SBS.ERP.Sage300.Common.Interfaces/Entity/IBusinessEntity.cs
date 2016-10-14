/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity
{
    /// <summary>
    /// Interface for Business Entity
    /// </summary>
    public interface IBusinessEntity
    {
        /// <summary>
        /// Gets or sets Session
        /// </summary>
        IBusinessEntitySession Session { get; set; }

        /// <summary>
        /// Gets Context
        /// </summary>
        /// <value>The context</value>
        Context Context { get; set; }

        /// <summary>
        /// Gets Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the name of the repository that uses the view.
        /// </summary>
        string CreatedRepositoryName { get; set; }

        /// <summary>
        /// Name of the views the current view is composed with
        /// </summary>
        string[] ComposedViewNames { get; }

        /// <summary>
        /// Gets or set record numbering
        /// </summary>
        bool UseRecordNumbering { set; }

        /// <summary>
        /// Gets or sets the current record number
        /// </summary>
        int RecordNumber { get; }

        /// <summary>
        /// ETag
        /// </summary>
        string ETag { get; }
    
        /// <summary>
        /// Gets View
        /// </summary>
        IViewComInterop View { get; }

        /// <summary>
        /// Gets Fields
        /// </summary>
        IViewFieldsComInterop Fields { get; }

        /// <summary>
        /// Exists
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// TO set value by name
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        void SetValue<T>(string name, T value, bool verify = false);

        /// <summary>
        /// To set value by Id
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field INDEX</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        void SetValue<T>(int index, T value, bool verify = false);

        /// <summary>
        /// To set value by Id
        /// </summary>
        /// <param name="index">Field INDEX</param>
        /// <param name="verify">Verify</param>
        void SetNullValue(int index, bool verify = false);

        /// <summary>
        /// Gets FieldValue
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <returns></returns>
        T GetValue<T>(string name);

        //TODO: This method is to be replace using generic type
        /// <summary>
        /// Gets FieldValue
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        DateTime? GetValue(string name);

        /// <summary>
        /// Gets FieldValueByID
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field Index</param>
        /// <returns></returns>
        T GetValue<T>(int index);

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<EnablementAttribute> GetAttributes<T>();


        /// <summary>
        /// Get TimeSpan
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        TimeSpan GetTimeSpan(int index);

        /// <summary>
        /// Method ro insert 
        /// </summary>
        void Insert();

        /// <summary>
        /// Moves the record head to the particular position
        /// </summary>
        /// <param name="index">Non zero based index</param>
        void MoveTo(int index);

        /// <summary>
        /// Method ro Update 
        /// </summary>
        void Update();

        /// <summary>
        /// Method ro Delete 
        /// </summary>
        void Delete();

        /// <summary>
        /// Method to navigate to next record
        /// </summary>
        /// <returns>A bool value if next record existes,else false</returns>
        bool Next();

        /// <summary>
        /// Method to navigate to previous record
        /// </summary>
        /// <returns>A bool value if previous record existes,else false</returns>
        bool Previous();

        /// <summary>
        /// Method to navigate to first record
        /// </summary>
        /// <returns></returns>
        bool Top();

        /// <summary>
        /// Method to navigate to the last record
        /// </summary>
        /// <returns></returns>
        bool Bottom();

        /// <summary>
        /// Fetches based on lock record
        /// </summary>
        /// <param name="lockRecord"></param>
        bool Fetch(bool lockRecord);

        /// <summary>
        /// RefreshMetaData
        /// </summary>
        void RefreshMetaData();

        /// <summary>
        /// Browse based on filter and sorting order
        /// </summary>
        /// <param name="filter">Filter Citeria</param>
        /// <param name="ascending">Ascending</param>
        void Browse(string filter, bool ascending);

        /// <summary>
        /// Reads based on lockRecord
        /// </summary>
        /// <param name="lockRecord">lock Record</param>
        bool Read(bool lockRecord);

        /// <summary>
        /// Process view
        /// </summary>
        void Process();

        /// <summary>
        /// Process based criterias
        /// </summary>
        /// <param name="setId">Set Id</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        void Process(int setId, object value, bool verify);

        /// <summary>
        /// Unposteds the revisions.
        /// </summary>
        /// <returns></returns>
        bool UnpostedRevisions { get; }

        /// <summary>
        /// Cancel
        /// </summary>
        void Cancel();

        /// <summary>
        /// Filter Select
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="ascending">Ascending</param>
        /// <param name="viewKey">View Key</param>
        /// <param name="viewFilterOrigin">ViewFilter Origin</param>
        void FilterSelect(string filter, bool ascending, int viewKey, ViewFilterOrigin viewFilterOrigin);

        /// <summary>
        /// Filter count
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="flags">Flags</param>
        /// <returns></returns>
        int FilterCount(string filter, int flags);

        /// <summary>
        /// CLears record
        /// </summary>
        void ClearRecord();

        /// <summary>
        /// Sets FieldByID ToMin
        /// </summary>
        /// <param name="index">Field Index</param>
        void SetMinimumValue(int index);

        /// <summary>
        /// Sets FieldByName ToMin
        /// </summary>
        /// <param name="name">Field Name</param>
        void SetMinimumValue(string name);

        /// <summary>
        /// Sets FieldByID ToMax
        /// </summary>
        /// <param name="index">Field Index</param>
        void SetMaximumValue(int index);

        /// <summary>
        /// Sets FieldByName ToMax
        /// </summary>
        /// <param name="name">Field Name</param>
        void SetMaximumValue(string name);

        /// <summary>
        /// Generates record
        /// </summary>
        /// <param name="insertRecord">Insert Record</param>
        void GenerateRecord(bool insertRecord);

        /// <summary>
        /// Creates a record
        /// </summary>
        /// <param name="flags">Insert record, No Insert or DelayKey</param>
        void RecordCreate(ViewRecordCreate flags);

        /// <summary>
        /// Used to initialize
        /// </summary>
        void Init();

        /// <summary>
        /// Gets Field MinValue
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <returns></returns>
        T GetMinimumValue<T>(string name);

        /// <summary>
        /// Gets FieldMinValue By ID
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field Index</param>
        /// <returns></returns>
        T GetMinimumValue<T>(int index);

        /// <summary>
        /// TO dispose view
        /// </summary>
        void Dispose();

        /// <summary>
        /// Compose view
        /// </summary>
        /// <param name="views">Array of views</param>
        void Compose(IViewComInterop[] views);

        /// <summary>
        /// Method to unlock
        /// </summary>
        void Unlock();

        /// <summary>
        /// Gets Description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets Keys
        /// </summary>
        ViewKeys Keys { get; }

        /// <summary>
        /// Bulk get
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <returns>Object array - values of all the field ID's</returns>
        object[] BulkGet(int[] fieldIDs);
        /// <summary>
        /// TO dispose view
        /// </summary>
        void Destroy();

        /// <summary>
        /// Post
        /// </summary>
        void Post();

        /// <summary>
        /// Can Inquire
        /// </summary>
        bool CanInquire { get; }

        /// <summary>
        /// Can Modify
        /// </summary>
        bool CanModify { get; }

        /// <summary>
        /// Can Add
        /// </summary>
        bool CanAdd { get; }

        /// <summary>
        /// Can Delete
        /// </summary>
        bool CanDelete { get; }

        /// <summary>
        /// Can Post
        /// </summary>
        bool CanPost { get; }

        /// <summary>
        /// Indicates whether the current business entity is dirty. A record is dirty if any of the field values was modified by the application. 
        /// </summary>
        bool Dirty { get; }

        /// <summary>
        /// Bulk put
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <param name="fieldValues">array of all the field values's</param>
        /// <param name="verifyValues">Indicates whether validation should be performed by the view on the new values</param>
        /// <returns>Object array - values of all the field ID's</returns>
        void BulkPut(int[] fieldIDs, object[] fieldValues, bool verifyValues);

        /// <summary>
        /// FilterDelete
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="strictness">Controls how the deletion operation acts on multiple tables</param>
        void FilterDelete(string filter, ViewFilterStrictness strictness);

        /// <summary>
        /// Method ro Verify 
        /// </summary>
        void Verify();

        /// <summary>
        /// Security
        /// </summary>
        ViewSecurity Security { get; }

        /// <summary>
        /// Gets/sets the current system access mode of the view
        /// </summary>
        ViewSystemAccess SystemAccess { get; set; }

        /// <summary>
        /// Looks up the predefined string and the cookie of a given value. Returns whether the value is defined in the list.
        /// This is method is created to for PresentationStrings.LookupValue() method of VB code.
        /// </summary>
        /// <param name="fieldIndex">Value to lookup for a corresponding presentation string</param>
        /// <param name="value">Presentation string that corresponds to the supplied value</param>
        /// <returns>Returns whether a presentation string corresponding to the supplied value is found.</returns>
        bool PresentationStringExists(int fieldIndex, string value);

        /// <summary>
        /// Gets/sets the current selected key on the view. Changing the selected key affects the order in which records are fetched from the view. 
        /// When a view is first opened, the default selected key is always key 0. 
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// Cancel revison for specify level
        /// </summary>
        /// <param name="level"></param>
        void RevisionCancel(int level);

        /// <summary>
        /// Check whether revison exists for specify level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool RevisionExists(int level);

        /// <summary>
        /// Post revision for specify level
        /// </summary>
        /// <param name="level"></param>
        void RevisionPost(int level) ;

        /// <summary>
        /// Unpost revision for specify level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool RevisionUnposted(int level);

        /// <summary>
        /// Indicates the view protocol specifications this view implements
        /// </summary>
        ViewProtocol InstanceProtocol { get; }
    }
}