/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Reflection;
using ACCPAC.Advantage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Entity
{
    /// <summary>
    /// Class that implements PseudoView
    /// </summary>
    public class PseudoView : IViewComInterop
    {
        #region Private properties

        /// <summary>
        /// Array that has data from json
        /// </summary>
        private JArray DataArray { get; set; }

        /// <summary>
        /// Object to hold the data to be saved
        /// </summary>
        private JObject DataSaveJObject { get; set; }

        /// <summary>
        /// Fix for First row being null in ACCPAC
        /// </summary>
        private int _goNextCount;

        /// <summary>
        /// List of PseudoViewFields
        /// </summary>
        private List<PseudoViewFields> _dataRows;

        /// <summary>
        /// Gets and sets LockRecord
        /// </summary>
        private bool LockRecord { get; set; }

        /// <summary>
        /// Exists value
        /// </summary>
        //_exists need not be implemented in constructor as of now
        private bool _exists;


        /// <summary>
        /// RecordNumber value
        /// </summary>
        private int _index = -1;

        /// <summary>
        /// ViewID value
        /// </summary>
        private readonly string _viewId;

        private string Filter { get; set; }

        /// <summary>
        /// Dispose value
        /// </summary>
        private bool _isDisposed;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for PseudoView
        /// </summary>
        /// <param name="viewName">View Name</param>
        public PseudoView(string viewName)
        {
            _viewId = viewName;
            InitializeData();
        }
        #endregion

        #region Faked methods and properties
        /// <summary>
        ///  Gets Exists value
        /// </summary>
        public bool Exists
        {
            get { return _exists; }
        }

        /// <summary>
        /// Gets the value by field id - If the row index is not set, this will return the first row
        /// </summary>
        /// <param name="fieldId">Based on which value is fetched</param>
        /// <returns>Object that contains value by index</returns>
        public object GetValue(int fieldId)
        {
            return GetValue(Convert.ToString(fieldId));
        }

        /// <summary>
        /// Gets the value by name - If the row index is not set, this will return the first row
        /// </summary>
        /// <param name="name">Based on which value is fetched</param>
        /// <returns>Object that contains value by name</returns>
        public object GetValue(string name)
        {
            if (_index < 0 || _index > DataArray.Count)
            {
                return null;
            }
            return DataArray[_index][name];
        }

        /// <summary>
        /// Sets the value by index
        /// </summary>
        /// <param name="fieldIndex">Index to be set</param>
        /// <param name="value">Value to be set</param>
        /// <param name="verify">Not used</param>
        public void SetValue(int fieldIndex, object value, bool verify = false)
        {
            SetValue(Convert.ToString(fieldIndex), value, verify);
        }

        /// <summary>
        /// Sets the value by name
        /// </summary>
        /// <param name="name">Name to be set</param>
        /// <param name="value">Value to be set</param>
        /// <param name="verify"></param>
        public void SetValue(string name, object value, bool verify = false)
        {
            var property = new JProperty(name, value);
            if (DataSaveJObject == null)
            {
                DataSaveJObject = new JObject();
            }
            DataSaveJObject.Add(property);
        }

        /// <summary>
        /// Bulk get 
        /// </summary>
        /// <param name="fieldIDs">view fieldIDs</param>
        /// <returns></returns>
        public object[] BlkGet(int[] fieldIDs)
        {
            var data = new object[500];
            for (int i = 0; i < fieldIDs.Count(); i++)
            {
                data[i] = GetValue(fieldIDs[i]);
            }
            return data;
        }

        /// <summary>
        /// Browse the record
        /// </summary>
        /// <param name="filter">Filter based on which it is browsed Note: No support for OR and multiple AND. Takes only one filter equation and that too only for '='</param>
        /// <param name="ascending">Browsed in ascending order</param>
        public void Browse(string filter, bool ascending)
        {
            Filter = filter;
            if (IsObjectNotDisposed())
            {
                _index = FoundIndex(filter);
            }
        }

        private int FoundIndex(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return 0;
            }
            int foundIndex = -1;
            int predicateIndex = 0;
            string[] filterPredicates = filter.Split(new[] { "=", "AND" }, StringSplitOptions.None);
            if (filter.Contains("="))
            {
                for (int i = 0; i < DataArray.Count; i++)
                {
                    if (DataArray[i] != null)
                    {
                        var key = filterPredicates[0].Trim();
                        predicateIndex++;
                        var value = filterPredicates[1].Trim(new[] { ' ', '\\', '"' });
                        
                        if (DataArray[i][key] != null)
                        {
                            if (DataArray[i][key].ToString() == value)
                            {
                                if (filter.Contains("AND"))
                                {
                                    if (predicateIndex < filterPredicates.Count())
                                    {
                                        predicateIndex++;
                                        var andKey = filterPredicates[predicateIndex].Trim();
                                        predicateIndex++;
                                        var andValue = filterPredicates[predicateIndex].Trim(new[] { ' ', '\\', '"' });
                                        predicateIndex++;
                                        if (DataArray[i][andKey].ToString() == andValue)
                                        {
                                            foundIndex = i;
                                            _exists = true;
                                            break;
                                        }
                                    }

                                }
                                else
                                {
                                    foundIndex = i;
                                    _exists = true;
                                    break;
                                }

                            }
                        }
                    }
                    else
                    {
                        foundIndex = 1;
                    }
                }
            }
            else
            {
                foundIndex = 0;
            }
            return foundIndex;
        }

        /// <summary>
        /// Method to cancel
        /// </summary>
        public void Cancel()
        {
            _index = -1;
        }

        /// <summary>
        /// Method to dispose
        /// </summary>
        public void Dispose()
        {
            if (IsObjectNotDisposed())
            {
                _isDisposed = true;
            }
        }

        /// <summary>
        /// Method to FilterCount
        /// </summary>
        /// <param name="filter">Filter based on which it is browsed Note: No support for AND/OR. Takes only one filter equation and that too only for '='</param>
        /// <param name="flags">Flags</param>
        /// <returns>Count</returns>
        public int FilterCount(string filter, int flags)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return 0;
            }
            string[] filterPredicates = filter.Split(new[] { "=" }, StringSplitOptions.None);
            int count = 0;
            if (filter.Contains("="))
            {
                count += (from t in DataArray
                          where t != null
                          let key = filterPredicates[0].Trim()
                          let value = filterPredicates[1].Trim(new[] { ' ', '\\', '"' })
                          where t[key] != null
                          where t[key].ToString() == value
                          select t).Count();
            }
            else
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// Method to Select with filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="ascending">Ascending order</param>
        /// <param name="order">Order Note: Not implemented for faking</param>
        /// <param name="origin">Origin Note: Not implemented for faking</param>
        public void FilterSelect(string filter, bool ascending, int order, ViewFilterOrigin origin)
        {
            Browse(filter, ascending);
        }

        /// <summary>
        /// Method to go to last record
        /// </summary>
        /// <returns>true if last record exists else false</returns>
        public bool GoBottom()
        {
            if (IsObjectNotDisposed() && _dataRows.Count > 0)
            {
                _index = DataArray.Count;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to navigate to next record
        /// </summary>
        /// <returns>Returns true if next record exists else false</returns>
        public bool GoNext()
        {
            if (_goNextCount == 0)
            {
                _goNextCount++;
                return true;
            }
            if (Filter == string.Empty)
            {
                if (DataArray.Count > _goNextCount)
                {
                    _goNextCount++;
                    _index++;
                    return true;
                }
            }
            else
            {
                int numberOfOccurence = FilterCount(Filter, 0);
                if (numberOfOccurence <= 1)
                {
                    return false;
                }
                if (numberOfOccurence > _goNextCount)
                {
                    _goNextCount++;
                    _index++;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Method to navigate to previous record
        /// </summary>
        /// <returns>Returns true if previous record exists else false</returns>
        public bool GoPrev()
        {
            if (IsObjectNotDisposed() && _index > 0 && DataArray.Count > 0)
            {
                _index--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to go to first record
        /// </summary>
        /// <returns>true if first record exist else false</returns>
        public bool GoTop()
        {
            if (IsObjectNotDisposed() && DataArray.Count > 0)
            {
                _index = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to go to specified RecordNumber
        /// </summary>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>true if record number is found else false</returns>
        public bool GotoRecordNumber(int recordNumber)
        {
            if (IsObjectNotDisposed() && DataArray.Count > 0)
            {
                _index = recordNumber;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to insert
        /// </summary>
        public void Insert()
        {
            if (IsObjectNotDisposed())
            {
                if (DataSaveJObject != null)
                {
                    DataArray.Add(DataSaveJObject);
                    _index = DataArray.Count - 1;
                    //viewFields.FieldValues.Add(DataSaveJObject);
                }

                ////Save to file
                //using (TextWriter fileStream = new StreamWriter(GetDataFileNameByConvention(), true))
                //{
                //    foreach (var fieldValue in viewFields.FieldValues)
                //    {
                //        fileStream.WriteLine(fieldValue);
                //    }
                //}

                ////Empty our data rows and prepare for refresh
                //_dataRows = new List<PseudoViewFields>();

                ////Refresh data after save
                //InitializeData();
            }
        }

        /// <summary>
        /// Method to read - SetValue is to be called before Read is called. If Set Value is not called, it will return the first row
        /// </summary>
        /// <param name="lockRecord">lockRecord</param>
        /// <returns>bool value</returns>
        public bool Read(bool lockRecord)
        {
            //Check if the values set in DataSaveObject is available in the JSON file
            if (DataSaveJObject != null)
            {
                var searchObject = new List<string>();
                foreach (var setValue in DataSaveJObject)
                {
                    searchObject.Add(setValue.Key + " = " + setValue.Value);
                }

                string filter;
                if (searchObject.Count == 1)
                {
                    filter = searchObject[0];
                }
                else
                {
                    filter = searchObject[0] + " AND " + searchObject[1];
                }

                FilterSelect(filter, true, 0, ViewFilterOrigin.FromStart);
            }
            return _exists;
        }

        /// <summary>
        /// Method to unlock
        /// </summary>
        public void Unlock()
        {
            if (IsObjectNotDisposed())
            {
                LockRecord = false;
            }
        }

        /// <summary>
        /// Method to verify
        /// </summary>
        public void Verify()
        {
            IsObjectNotDisposed();
        }

        /// <summary>
        /// Method to Delete
        /// </summary>
        public void Delete()
        {
            DataArray.Remove(DataSaveJObject);
        }


        /// <summary>
        /// Method to update
        /// </summary>
        public void Update()
        {
            //No op
        }

        /// <summary>
        /// Method to fecth values based on lockRecord
        /// </summary>
        /// <param name="lockRecord">lockRecord</param>
        /// <returns></returns>
        public bool Fetch(bool lockRecord)
        {
            //No Op
            // Could be extended to return true or false based values in data file to check for negative scenarios 
            return true;
        }

        /// <summary>
        /// Refresh MetaData
        /// </summary>
        public void RefreshMetaData()
        {
            // No Op
        }

        /// <summary>
        /// Method to initialise
        /// </summary>
        public void Init()
        {
            //No Op
        }



        /// <summary>
        /// Method to Compose
        /// </summary>
        /// <param name="views"></param>
        public void Compose(IViewComInterop[] views)
        {
            //No Op
        }

        /// <summary>
        /// Method to process
        /// </summary>
        public void Process()
        {
            //No Op
        }

        /// <summary>
        /// Method to clear record
        /// </summary>
        public void RecordClear()
        {
            //No Op
        }

        /// <summary>
        /// Method to create record - Doesn't create a record, the value to be created must be sent along with Insert
        /// </summary>
        /// <param name="flags">flags</param>
        public void RecordCreate(ViewRecordCreate flags)
        {
            //No op
        }

        /// <summary>
        /// Method to compose
        /// </summary>
        /// <param name="views">List of views</param>
        public void Compose(View[] views)
        {
            //No Op
        }

        /// <summary>
        /// Gets and sets ViewFields
        /// </summary>
        public ViewFields Fields
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets PseudoViewFields
        /// </summary>
        public PseudoViewFields PseudoFields
        {
            get;
            set;
        }
        #endregion

        #region Not Implemented View methods and properties

        /// <summary>
        /// Method to fetch with filter
        /// </summary>
        /// <param name="lockRecord">LockRecord</param>
        /// <returns></returns>
        public bool FilterFetch(bool lockRecord)
        {
            return IsObjectNotDisposed() && Fetch(lockRecord);
        }

        /// <summary>
        /// Method to Generate Record
        /// </summary>
        /// <param name="insertRecord"></param>
        public void RecordGenerate(bool insertRecord)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Etag
        /// </summary>
        /// <returns></returns>
        public string GetETag()
        {
            return string.Empty;
        }

        /// <summary>
        /// Gets ViewID
        /// </summary>
        public string ViewID
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets and sets if CheckDuplicateKeys
        /// </summary>
        public bool CheckDuplicateKeys
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
        /// Gets and sets CompositeNames
        /// </summary>
        public string[] CompositeNames
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets  Description
        /// </summary>
        public string Description
        {
            get { return _viewId; }
        }

        /// <summary>
        /// Gets  Description
        /// </summary>
        public bool Dirty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets and sets HeaderLinkedKeyFieldCount
        /// </summary>
        public short HeaderLinkedKeyFieldCount
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
        ///  Gets and sets InstanceNoncascading
        /// </summary>
        public bool InstanceNoncascading
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceNonheritable
        /// </summary>
        public bool InstanceNonheritable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets and sets InstancePrefetch
        /// </summary>
        public int InstancePrefetch
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceProtcol
        /// </summary>
        public ViewProtocol InstanceProtcol
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceRawPut
        /// </summary>
        public bool InstanceRawPut
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceReadonly
        /// </summary>
        public bool InstanceReadonly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceSecurity
        /// </summary>
        public ViewSecurity InstanceSecurity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceUnrevisioned
        /// </summary>
        public bool InstanceUnrevisioned
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets InstanceUnvalidated
        /// </summary>
        public bool InstanceUnvalidated
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets LastReturnCode
        /// </summary>
        public int LastReturnCode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets and sets Order
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
        /// Gets RecordBookmark
        /// </summary>
        public object RecordBookmark
        {
            get
            {
                throw new NotImplementedException();
            }

        }

        /// <summary>
        /// Gets RecordNumber
        /// </summary>
        public int RecordNumber
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets and sets ReferentialIntegrity
        /// </summary>
        public ViewReferentialIntegrity ReferentialIntegrity
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
        ///  Gets Security
        /// </summary>
        public ViewSecurity Security
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets and sets SystemAccess
        /// </summary>
        public ViewSystemAccess SystemAccess
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
        /// gets TemplateDate
        /// </summary>
        public DateTime TemplateDate
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets TemplateVersion
        /// </summary>
        public string TemplateVersion
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets Type
        /// </summary>
        public ViewRotoType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets UnpostedRevisions
        /// </summary>
        public bool UnpostedRevisions
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets and sets UseRecordNumbering
        /// </summary>
        public bool UseRecordNumbering
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
        /// Method for BlkPut
        /// </summary>
        /// <param name="fieldIDs">An array of IDs of the fields </param>
        /// <param name="fieldValues">An array of new field values</param>
        /// <param name="verifyValues">Indicates whether validation should be performed by the view on the new values</param>
        public void BlkPut(int[] fieldIDs, object[] fieldValues, bool verifyValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to Cancel
        /// </summary>
        /// <param name="inFieldIDs">In FieldID</param>
        /// <param name="outFieldValues">Out FieldValues</param>
        public void Cancel(int[] inFieldIDs, out object[] outFieldValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to clone
        /// </summary>
        /// <returns></returns>
        public IViewComInterop Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to fetch
        /// </summary>
        /// <param name="lockRecord">lockRecord</param>
        /// <param name="putFieldIDs">FieldID</param>
        /// <param name="putFieldValues">FieldValues</param>
        /// <param name="inFieldIDs">In FieldIDs</param>
        /// <param name="outFieldValues">Out FieldValues</param>
        /// <param name="recordNumber">Record Number</param>
        /// <returns></returns>
        public bool Fetch(bool lockRecord, int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to delete with filter
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="strictness">Controls how the deletion operation acts on multiple tables</param>
        public void FilterDelete(string filter, ViewFilterStrictness strictness)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to go to last record
        /// </summary>
        /// <param name="inFieldIDs">FieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>true if last record exists else false</returns>
        public bool GoBottom(int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to navigate to next record
        /// </summary>
        /// <param name="putFieldIDs">FieldIDs</param>
        /// <param name="putFieldValues">FieldValues</param>
        /// <param name="inFieldIDs">In FieldIDs</param>
        /// <param name="outFieldValues">OutFieldValues</param>
        /// <param name="recordNumber">Record Number</param>
        /// <returns>Returns true if next record exists else false</returns>
        public bool GoNext(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to navigate to previous record
        /// </summary>
        /// <param name="putFieldIDs">FieldIDs</param>
        /// <param name="putFieldValues">FieldValues</param>
        /// <param name="inFieldIDs">In FieldIDs</param>
        /// <param name="outFieldValues">OutFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>Returns true if previous record exists else false</returns>
        public bool GoPrev(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to GotoBookmark
        /// </summary>
        /// <param name="bookmark">bookmark object</param>
        /// <returns>true if datarows exist else false</returns>
        public bool GotoBookmark(object bookmark)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to GotoBookmark
        /// </summary>
        /// <param name="bookmark">Bookmark</param>
        /// <param name="inFieldIDs">FieldIDs</param>
        /// <param name="outFieldValues">OutFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>true if datarows exist else false</returns>
        public bool GotoBookmark(object bookmark, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to go to first record
        /// </summary>
        /// <param name="inFieldIDs">FieldIDs</param>
        /// <param name="outFieldValues">FieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>true if first record exist else false</returns>
        public bool GoTop(int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to go to specified RecordNumber
        /// </summary>
        /// <param name="recordNumber">recordNumber</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <returns></returns>
        public bool GotoRecordNumber(int recordNumber, int[] inFieldIDs, out object[] outFieldValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to initialise
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        public void Init(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to Initialise PrimaryKeyFields
        /// </summary>
        /// <param name="bookmark">bookmark</param>
        public void InitPrimaryKeyFields(ref object bookmark)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to insert
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        public void Insert(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to MacroAppend
        /// </summary>
        /// <param name="command">command</param>
        public void MacroAppend(string command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to post
        /// </summary>
        public void Post()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to post
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        public void Post(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to process
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        public void Process(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to read
        /// </summary>
        /// <param name="lockRecord">lockRecord</param>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        /// <returns>bool value</returns>
        public bool Read(bool lockRecord, int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to Reset Record Numbers 
        /// </summary>
        public void ResetRecordNumbers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to revision cancel
        /// </summary>
        /// <param name="level">level</param>
        public void RevisionCancel(int level)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to revision exists
        /// </summary>
        /// <param name="level">level</param>
        /// <returns>true if exists else false</returns>
        public bool RevisionExists(int level)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to RevisionPost
        /// </summary>
        /// <param name="level">level</param>
        public void RevisionPost(int level)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to check if Revision Unposted
        /// </summary>
        /// <param name="level"></param>
        /// <returns>bool valuebased on revision unposted</returns>
        public bool RevisionUnposted(int level)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TableEmpty
        /// </summary>
        public void TableEmpty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to update
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        /// <param name="recordNumber">RecordNumber</param>
        public void Update(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues, out int recordNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to verify
        /// </summary>
        /// <param name="putFieldIDs">putFieldIDs</param>
        /// <param name="putFieldValues">putFieldValues</param>
        /// <param name="inFieldIDs">inFieldIDs</param>
        /// <param name="outFieldValues">outFieldValues</param>
        public void Verify(int[] putFieldIDs, object[] putFieldValues, int[] inFieldIDs, out object[] outFieldValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to Clone
        /// </summary>
        /// <returns>View object</returns>
        View IViewComInterop.Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to get ViewInternal
        /// </summary>
        /// <param name="key">key</param>
        /// <returns></returns>
        public ViewInternal GetViewInternal(int key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Keys
        /// </summary>
        public ViewKeys Keys
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Method to get view field values from json file.
        /// </summary>
        /// <param name="fileName">Name of json file from which values are fecthed</param>
        /// <returns>List of PseudoViewFields</returns>
        private List<PseudoViewFields> CreateFromJsonFile(String fileName)
        {
            using (TextReader fileStream = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                using (var file = new JsonTextReader(fileStream))
                {
                    var localData = (JArray)serializer.Deserialize(file);
                    DataArray = localData;
                    var dataRows = new List<PseudoViewFields>();
                    var row = new PseudoViewFields(this);
                    foreach (var data1 in localData)
                    {
                        row.FieldValues.Add(data1);
                    }
                    dataRows.Add(row);
                    return dataRows;
                }
            }
        }

        /// <summary>
        /// Method to get the file name 
        /// </summary>
        /// <returns>File Name</returns>
        private string GetDataFileNameByConvention()
        {
            string folderPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + @"\Repository").LocalPath;
            return string.Format(@"{0}\{1}.json", folderPath, _viewId);
        }

        ///// <summary>
        ///// Check if the record exists by comparing with the count
        ///// </summary>
        ///// <returns></returns>
        //private bool CheckRecordExists()
        //{
        //    if (_index == -1)
        //    {
        //        return false;
        //    }
        //    return DataArray.Count >= _index;
        //}

        /// <summary>
        /// To check if object is disposed
        /// </summary>
        /// <returns></returns>
        private bool IsObjectNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("View has been disposed");
            }
            return true;
        }

        /// <summary>
        /// Method to InitializeData
        /// </summary>
        private void InitializeData()
        {
            _dataRows = CreateFromJsonFile(GetDataFileNameByConvention());
        }
        #endregion
    }
}
