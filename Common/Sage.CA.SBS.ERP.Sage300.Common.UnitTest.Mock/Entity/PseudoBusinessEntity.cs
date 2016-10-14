/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using ACCPAC.Advantage;
using Newtonsoft.Json.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
{
    /// <summary>
    /// Class that implements Pseudo Business Entity
    /// </summary>
    public class PseudoBusinessEntity : IBusinessEntity, IDisposable
    {
        /// <summary>
        /// Constructor for PseudoBusinessEntity
        /// </summary>
        /// <param name="session">BusinessEntity Session</param>
        /// <param name="viewName">View Name</param>
        /// <param name="context">Current Context</param>
        public PseudoBusinessEntity(IBusinessEntitySession session, string viewName, Context context)
        {
            Session = session;
            Name = viewName;
            MockView = new PseudoView(viewName);
            View = MockView;
            Context = context;
        }

        /// <summary>
        /// Gets and sets session
        /// </summary>
        /// <value>The session.</value>
        public IBusinessEntitySession Session { get; set; }

        /// <summary>
        /// Gets and sets Context
        /// </summary>
        /// <value>The context</value>
        public Context Context { get; set; }

        /// <summary>
        /// Gets and sets Name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the repository that uses the view.
        /// </summary>
        public string CreatedRepositoryName { get; set; }

        /// <summary>
        /// ETag
        /// </summary>
        public string ETag
        {
            get { return View.GetETag(); }
        }

        /// <summary>
        /// Name of the views the current view is composed with
        /// </summary>
        public string[] ComposedViewNames { get; private set; }

        /// <summary>
        /// Gets or set record numbering
        /// </summary>
        /// <value><c>true</c> if [use record numbering]; otherwise, <c>false</c>.</value>
        public bool UseRecordNumbering { set; private get; }

        /// <summary>
        /// Gets or sets the current record number
        /// </summary>
        /// <value>The record number.</value>
        public int RecordNumber { get; private set; }

        /// <summary>
        /// MockView of type PseudoView
        /// </summary>
        /// <value>The mock view.</value>
        private PseudoView MockView { get; set; }

        /// <summary>
        /// Gets and sets view
        /// </summary>
        /// <value>The view.</value>
        public IViewComInterop View { get; set; }

        /// <summary>
        /// Gets and sets view
        /// </summary>
        /// <value>The fields.</value>
        public IViewFieldsComInterop Fields { get; set; }

        /// <summary>
        /// Gets exists
        /// </summary>
        /// <value><c>true</c> if exists; otherwise, <c>false</c>.</value>
        public bool Exists
        {
            get { return MockView.Exists; }
        }

        /// <summary>
        /// TO set value by name
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        public void SetValue<T>(string name, T value, bool verify = false)
        {
            MockView.SetValue(name, value, verify);
        }

        /// <summary>
        /// To set value by Id
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field INDEX</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        public void SetValue<T>(int index, T value, bool verify = false)
        {
            MockView.SetValue(index, value, verify);
        }

        /// <summary>
        /// set null value
        /// </summary>
        /// <param name="index"></param>
        /// <param name="verify"></param>
        public void SetNullValue(int index, bool verify = false)
        {
            MockView.SetValue(index, null, verify);
        }

        /// <summary>
        /// Gets FieldValue
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <returns>T.</returns>
        public T GetValue<T>(string name)
        {
            T value = default(T);
            object objectSet = MockView.GetValue(name);
            if (objectSet != null && ((JValue) (objectSet)).Value.ToString() != "")
            {
                objectSet = Convert.ChangeType(objectSet, typeof (T));
                value = (T) objectSet;
            }
            return value;
        }

        /// <summary>
        /// Gets FieldValue
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public DateTime? GetValue(string name)
        {
            DateTime? value = null;

            // Do null check
            if (MockView.GetValue(name) != null)
            {
                object objectSet = MockView.GetValue(name);
                if (objectSet != null && ((JValue) (objectSet)).Value.ToString() != "")
                {
                    objectSet = Convert.ChangeType(objectSet, typeof (DateTime));
                    value = (DateTime) objectSet;
                }
            }

            return value;
        }

        /// <summary>
        /// Gets FieldValueByID
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field Index</param>
        /// <returns>T.</returns>
        public T GetValue<T>(int index)
        {
            T value = default(T);
            if (MockView.GetValue(index) != null)
            {
                object objectEmpty = string.Empty;
                object val = MockView.GetValue(index);
                object actVal = ((JValue) val).Value;
                if (actVal != objectEmpty && actVal != null)
                {
                    if (typeof (T) == typeof (int))
                    {
                        if (actVal.ToString().ToLower() == "false" || actVal.ToString().ToLower() == "true")
                        {
                            actVal = Convert.ToBoolean(actVal.ToString());
                        }
                    }
                    object objectSet = Convert.ChangeType(actVal, typeof (T));
                    //objectSet = Convert.ChangeType(objectSet, typeof(T));
                    value = (T) objectSet;
                }
            }
            return value;
        }

        /// <summary>
        /// Get Timespan
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TimeSpan GetTimeSpan(int index)
        {
            return TimeSpan.Zero;
        }

        /// <summary>
        /// Method to Insert
        /// </summary>
        public void Insert()
        {
            MockView.Insert();
        }

        /// <summary>
        /// Method to Update
        /// </summary>
        public void Update()
        {
            MockView.Update();
        }

        /// <summary>
        /// Method to Delete
        /// </summary>
        public void Delete()
        {
            MockView.Delete();
        }

        /// <summary>
        /// Goes to next view
        /// </summary>
        /// <returns>A bool value if next record existes,else false</returns>
        public bool Next()
        {
            return MockView.GoNext();
        }

        /// <summary>
        /// Goes to previous view
        /// </summary>
        /// <returns>A bool value if previous record existes,else false</returns>
        public bool Previous()
        {
            return MockView.GoPrev();
        }

        /// <summary>
        /// Goes to top of the view
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Top()
        {
            return MockView.GoTop();
        }

        /// <summary>
        /// Fetches based on lock record
        /// </summary>
        /// <param name="lockRecord">if set to <c>true</c> [lock record].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Fetch(bool lockRecord)
        {
            return MockView.Fetch(lockRecord);
        }

        /// <summary>
        /// Refresh MetaData
        /// </summary>
        /// <remarks>Invokes InternalSet(256)</remarks>
        public void RefreshMetaData()
        {
            MockView.RefreshMetaData();
        }

        /// <summary>
        /// Browse based on filter and sorting order
        /// </summary>
        /// <param name="filter">Filter Citeria</param>
        /// <param name="ascending">Ascending</param>
        public void Browse(string filter, bool ascending)
        {
            MockView.Browse(filter, ascending);
        }

        /// <summary>
        /// Reads based on lockRecord
        /// </summary>
        /// <param name="lockRecord">lock Record</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Read(bool lockRecord)
        {
            return MockView.Read(lockRecord);
        }

        /// <summary>
        /// Process view
        /// </summary>
        public void Process()
        {
            MockView.Process();
        }

        /// <summary>
        /// Process based criterias
        /// </summary>
        /// <param name="setId">Set Id</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        public void Process(int setId, object value, bool verify)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel
        /// </summary>
        public void Cancel()
        {
            MockView.Cancel();
        }

        /// <summary>
        /// Filter Select
        /// </summary>
        /// <param name="filter">Filter based on which it is browsed Note: No support for AND/OR. Takes only one filter equation and that too only for '='</param>
        /// <param name="ascending">Ascending</param>
        /// <param name="viewKey">View Key</param>
        /// <param name="viewFilterOrigin">ViewFilter Origin</param>
        public void FilterSelect(string filter, bool ascending, int viewKey, ViewFilterOrigin viewFilterOrigin)
        {
            MockView.FilterSelect(filter, ascending, viewKey, viewFilterOrigin);
        }

        /// <summary>
        /// Filter count
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="flags">Flags</param>
        /// <returns>System.Int32.</returns>
        public int FilterCount(string filter, int flags)
        {
            return MockView.FilterCount(filter, flags);
        }

        /// <summary>
        /// CLears record
        /// </summary>
        public void ClearRecord()
        {
            MockView.RecordClear();
        }

        /// <summary>
        /// Sets FieldByID ToMin
        /// </summary>
        /// <param name="index">Field Index</param>
        public void SetMinimumValue(int index)
        {
            MockView.SetValue(index, int.MinValue);
        }

        /// <summary>
        /// Sets FieldByName ToMin
        /// </summary>
        /// <param name="name">Field Name</param>
        public void SetMinimumValue(string name)
        {
            MockView.SetValue(name, int.MinValue);
        }

        /// <summary>
        /// Sets FieldByID ToMax
        /// </summary>
        /// <param name="index">Field Index</param>
        public void SetMaximumValue(int index)
        {
            MockView.SetValue(index, int.MaxValue);
        }

        /// <summary>
        /// Sets FieldByName ToMax
        /// </summary>
        /// <param name="name">Field Name</param>
        public void SetMaximumValue(string name)
        {
            MockView.SetValue(name, int.MaxValue);
        }

        /// <summary>
        /// Generates record
        /// </summary>
        /// <param name="insertRecord">Insert Record</param>
        public void GenerateRecord(bool insertRecord)
        {
            MockView.RecordGenerate(insertRecord);
        }

        /// <summary>
        /// Used to initialize
        /// </summary>
        public void Init()
        {
            MockView.Init();
        }

        /// <summary>
        /// Gets Field MinValue
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T GetMinimumValue<T>(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets FieldMinValue By ID
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field Index</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T GetMinimumValue<T>(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TO dispose view
        /// </summary>
        public void Dispose()
        {
            MockView.Dispose();
        }

        /// <summary>
        /// Compose view
        /// </summary>
        /// <param name="views">Array of views</param>
        public void Compose(IViewComInterop[] views)
        {
            MockView.Compose(views);
        }

        /// <summary>
        /// Method to unlock
        /// </summary>
        public void Unlock()
        {
            MockView.Unlock();
        }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return MockView.Description; }
        }

        /// <summary>
        /// Bulk get
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <returns>Object array - values of all the field ID's</returns>
        public object[] BulkGet(int[] fieldIDs)
        {
            return MockView.BlkGet(fieldIDs);
        }

        /// <summary>
        /// Bulk put
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <param name="fieldValues">array of all the values</param>
        /// <param name="verifyValues">Indicates whether validation should be performed by the view on the new values</param>
        public void BulkPut(int[] fieldIDs, object[] fieldValues, bool verifyValues)
        {
            MockView.BlkPut(fieldIDs, fieldValues, verifyValues);
        }

        /// <summary>
        /// FilterDelete
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="strictness">Controls how the deletion operation acts on multiple tables</param>
        public void FilterDelete(string filter, ViewFilterStrictness strictness)
        {
            MockView.FilterDelete(filter, strictness);
        }

        /// <summary>
        /// Method to Verify models
        /// </summary>
        public void Verify()
        {
            MockView.Verify();
        }

        /// <summary>
        /// Keys
        /// </summary>
        /// <value>The keys.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public ViewKeys Keys
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// True if disposed else false
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// To dispose view
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Destroy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a record
        /// </summary>
        /// <param name="flags">Insert record, No Insert or DelayKey</param>
        public void RecordCreate(ViewRecordCreate flags)
        {
        }

        /// <summary>
        /// Method to navigate to the last record
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Bottom()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Post
        /// </summary>
        public void Post()
        {
            MockView.Post();
        }

        /// <summary>
        /// TO dispose view
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Has permission to inquire
        /// </summary>
        public bool CanInquire
        {
            get { return true; }
        }

        /// <summary>
        /// Has permission to Modify
        /// </summary>
        public bool CanModify
        {
            get { return true; }
        }

        /// <summary>
        /// Has permission to Delete
        /// </summary>
        public bool CanDelete
        {
            get { return true; }
        }

        /// <summary>
        /// Has permission to Add
        /// </summary>
        public bool CanAdd
        {
            get { return true; }
        }

        /// <summary>
        /// Has permission to Post
        /// </summary>
        public bool CanPost
        {
            get { return true; }
        }

        /// <summary>
        /// Returns always true
        /// </summary>
        public bool Dirty
        {
            get { return true; }
        }

        /// <summary>
        /// Security
        /// </summary>
        public ViewSecurity Security
        {
            get { return MockView.Security; }
        }

        /// <summary>
        /// Securities the check.
        /// </summary>
        /// <param name="resourceId">The resource identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool SecurityCheck(string resourceId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets/sets the current system access mode of the view
        /// </summary>
        public ViewSystemAccess SystemAccess
        {
            get { return View.SystemAccess; }
            set { View.SystemAccess = value; }
        }

        /// <summary>
        /// Looks up the predefined string and the cookie of a given value. Returns whether the value is defined in the list.
        /// This is method is created to for PresentationStrings.LookupValue() method of VB code.
        /// </summary>
        /// <param name="fieldIndex">Value to lookup for a corresponding presentation string</param>
        /// <param name="value">Presentation string that corresponds to the supplied value</param>
        /// <returns>Returns whether a presentation string corresponding to the supplied value is found.</returns>
        public bool PresentationStringExists(int fieldIndex, string value)
        {
            throw new NotImplementedException();
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public System.Collections.Generic.List<Models.Attributes.EnablementAttribute> GetAttributes<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Order
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Moves the record head to the particular position
        /// </summary>
        /// <param name="index">Non zero based index</param>
        public void MoveTo(int index)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Unposteds the revisions.
        /// </summary>
        public bool UnpostedRevisions
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Cancel revison for specify level
        /// </summary>
        /// <param name="level"></param>
        public void RevisionCancel(int level)
        {
            try
            {
                View.RevisionCancel(level);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Check whether revison exists for specify level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool RevisionExists(int level)
        {
            return (View.RevisionExists(level));
        }

        /// <summary>
        /// Post revision for specify level
        /// </summary>
        /// <param name="level"></param>
        public void RevisionPost(int level)
        {
            try
            {
                View.RevisionPost(level);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        /// <summary>
        /// Unpost revision for specify level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool RevisionUnposted(int level)
        {
            try
            {
                return (View.RevisionUnposted(level));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Indicates the view protocol specifications this view implements
        /// </summary>
        public ViewProtocol InstanceProtocol { get { return View.InstanceProtcol; } }
    }
}