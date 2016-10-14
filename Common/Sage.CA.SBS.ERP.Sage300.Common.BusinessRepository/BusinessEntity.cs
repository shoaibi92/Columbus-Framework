/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;
using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Class for Business Entity
    /// </summary>
    public sealed class BusinessEntity : IBusinessEntity, IDisposable
    {
        #region Private Variables
        /// <summary>
        /// The _is composed
        /// </summary>
        private bool _isComposed;

        /// <summary>
        /// True if disposed else false
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        private bool _isDisposed;

        /// <summary>
        /// Database Audit
        /// </summary>
        private readonly IDatabaseAuditRepository<IDatabaseAudit> _databaseAuditRepository;
        #endregion

        #region Constant
        /// <summary>
        /// View - IC Label Header
        /// </summary>
        private const string ViewICLabelHeader = "IC0365";

        /// <summary>
        /// View - PO Distribution Proration
        /// </summary>
        private const string ViewPODistributionProration = "PO0424";

        /// <summary>
        /// View - PO Distribution Proration
        /// </summary>
        private const string ViewReceiptDistributionProration = "PO0704";

        /// <summary>
        /// View - PO Credit Debit Note Entry Distribution Proration
        /// </summary>
        private const string ViewPOCrDrDistributeProration = "PO0319";

        /// <summary>
        /// View - IC Label Header
        /// </summary>
        private const string ViewGLCreateAllocationBatch = "GL0029";

        /// <summary>
        /// View - IC Label Header
        /// </summary>
        private const string ViewGLAutoAllocationOptionalField = "GL0409";

        #endregion

        /// <summary>
        /// Constructor for Business Entity
        /// </summary>
        /// <param name="session">BusinessEntitySession object</param>
        /// <param name="view">ACCPAC view</param>
        /// <param name="name">View Name</param>
        /// <param name="context">Current Context</param>
        public BusinessEntity(IBusinessEntitySession session, IViewComInterop view, string name, Context context)
        {
            Session = session;
            View = view;
            Name = name;
            Context = context;

            // Database auditing repository (Logger for local or WAD table for Azure deployment)
            _databaseAuditRepository = context.Container.Resolve<IDatabaseAuditRepository<IDatabaseAudit>>();
        }

        /// <summary>
        /// Gets or sets Session
        /// </summary>
        /// <value>The session.</value>
        public IBusinessEntitySession Session { get; set; }

        /// <summary>
        /// Gets Context
        /// </summary>
        /// <value>The context</value>
        public Context Context { get; set; }

        /// <summary>
        /// Name of the views the current view can compose with
        /// </summary>
        public string[] ComposedViewNames
        {
            get { return View.CompositeNames; }

        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

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
        /// Gets or set record numbering
        /// </summary>
        /// <value><c>true</c> if [use record numbering]; otherwise, <c>false</c>.</value>
        public bool UseRecordNumbering
        {
            set { View.UseRecordNumbering = value; }
        }

        /// <summary>
        /// Gets or sets the current record number
        /// </summary>
        /// <value>The record number.</value>
        public int RecordNumber
        {
            get { return View.RecordNumber; }
        }

        /// <summary>
        /// View
        /// </summary>
        /// <value>The view.</value>
        public IViewComInterop View { get; private set; }

        /// <summary>
        /// Fields
        /// </summary>
        /// <value>The fields.</value>
        public IViewFieldsComInterop Fields
        {
            get { return View.Fields; }
        }

        /// <summary>
        /// Keys
        /// </summary>
        /// <value>The keys.</value>
        public ViewKeys Keys
        {
            get { return View.Keys; }
        }

        /// <summary>
        /// Exists
        /// </summary>
        /// <value><c>true</c> if exists; otherwise, <c>false</c>.</value>
        public bool Exists
        {
            get { return View.Exists; }
        }

        /// <summary>
        /// Gets a value indicating whether [unposted revisions].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [unposted revisions]; otherwise, <c>false</c>.
        /// </value>
        public bool UnpostedRevisions
        {
            get { return View.UnpostedRevisions; }
        }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return View.Description; }
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
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByName(name);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    SetValue(viewField, value, verify);
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
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
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByID(index);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    SetValue(viewField, value, verify); ;
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Sets field value
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="field">Field to set the value for</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify flag</param>
        private void SetValue<T>(ViewField field, T value, bool verify)
        {
            //The below logic is to workaround the 'bad' implementations when a Date repository field is assigned a string value, like '9/2/2020'. 
            //It causes formatting issues if server culture is not the same as client's.
            object valueToSet = value;

            if (field.Type == ViewFieldType.Date && typeof(T) == typeof(string))
            {
                var stringValue = value as string;
                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    DateTime date;
                    if (DateUtil.IsDateValid(stringValue, false, out date))
                    {
                        valueToSet = date;
                    }
                    else
                    {
                        var message =
                            string.Format(
                                "Attempting to assign a string value to the Date field using invalid format [View={0}, Field ID={1}, Value={2}]",
                                View.ViewID, field.ID, stringValue);
                        Logger.Error(message, LoggingConstants.ApplicationError, Context);
                    }
                }
            }

            field.SetValue(valueToSet, verify);
        }

        /// <summary>
        /// Set Null value into businessEntity
        /// </summary>
        /// <param name="index">Field Index/Id</param>
        /// <param name="verify">Verify</param>
        public void SetNullValue(int index, bool verify = false)
        {
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByID(index);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    viewField.SetValue(null, verify);
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Sets FieldByID ToMin
        /// </summary>
        /// <param name="index">Field Index</param>
        public void SetMinimumValue(int index)
        {
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByID(index);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    viewField.SetToMin();
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Sets FieldByName ToMin
        /// </summary>
        /// <param name="name">Field Name</param>
        public void SetMinimumValue(string name)
        {
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByName(name);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    viewField.SetToMin();
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Sets FieldByID ToMax
        /// </summary>
        /// <param name="index">Field Index</param>
        public void SetMaximumValue(int index)
        {
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByID(index);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    viewField.SetToMax();
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Sets FieldByName ToMax
        /// </summary>
        /// <param name="name">Field Name</param>
        public void SetMaximumValue(string name)
        {
            try
            {
                //Added to support Dynamic enablement. Sets the value only if the field is editable
                var viewField = View.Fields.FieldByName(name);
                if (viewField.Attributes.HasFlag(ViewFieldAttributes.Editable))
                {
                    viewField.SetToMax();
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Generates record
        /// </summary>
        /// <param name="insertRecord">Insert Record</param>
        public void GenerateRecord(bool insertRecord)
        {
            try
            {
                View.RecordGenerate(insertRecord);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// CLears record
        /// </summary>
        public void ClearRecord()
        {
            try
            {
                View.RecordClear();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Used to initialize
        /// </summary>
        public void Init()
        {
            try
            {
                View.Init();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        public void Insert()
        {
            try
            {
                View.Insert();
                _databaseAuditRepository.Log(EventType.Insert, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Moves the record head to the particular position
        /// </summary>
        /// <param name="index">Non zero based index</param>
        public void MoveTo(int index)
        {
            try
            {
                for (int i = 1; i < index; i++)
                {
                    if (i == 1)
                    {
                        if (View.Exists)
                        {
                            View.GoTop();
                        }
                        else
                        {
                            View.GoNext();

                        }
                    }
                    else
                    {
                        View.GoNext();
                    }
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }

        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            try
            {
                View.Update();
                _databaseAuditRepository.Log(EventType.Update, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        //TODO: This method is to be replace using generic type
        /// <summary>
        /// Gets FieldValue
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        public DateTime? GetValue(string name)
        {
            DateTime? value = null;
            try
            {
                // Do null check
                if (View.Fields.FieldByName(name).Value != null)
                {
                    object objectEmpty = string.Empty;
                    if (View.Fields.FieldByName(name).Value != objectEmpty)
                    {
                        object objectSet = Convert.ChangeType(View.Fields.FieldByName(name).Value, typeof(DateTime));
                        value = (DateTime)objectSet;
                    }
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
            return value;
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
            try
            {
                // Get the field value
                var fieldValue = View.Fields.FieldByName(name).Value;

                // Do null check
                if (fieldValue != null)
                {
                    object objectEmpty = string.Empty;
                    if (((IViewFieldsComInterop)View.Fields).FieldByName(name).Value != objectEmpty)
                    {
                        // Check if the type of enum is expected.
                        if (typeof(Enum) == typeof(T).BaseType)
                        {
                            // return the enumeration.
                            return EnumUtility.GetEnum<T>(fieldValue.ToString());
                        }

                        var objectSet = Convert.ChangeType(fieldValue, typeof(T));
                        return (T)objectSet;
                    }
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }

            return value;
        }

        /// <summary>
        /// Get TimeSpan
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TimeSpan GetTimeSpan(int index)
        {
            try
            {
                if (View.Fields.FieldByID(index).Value != null)
                {
                    var dateTime = (DateTime)Convert.ChangeType(View.Fields.FieldByID(index).Value, typeof(DateTime));
                    return TimeUtil.ConvertToTimeSpan(dateTime);
                }
                return TimeSpan.Zero;
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Get the list of editable and non editable attributes.
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <returns></returns>
        public List<EnablementAttribute> GetAttributes<T>()
        {
            var dynamicFields = GetDynamicFields<T>();
            return (from dynamicField in dynamicFields
                    select View.Fields.FieldByName(dynamicField.Key) into field
                    let attributes = field.Attributes
                    select new EnablementAttribute { PropertyName = dynamicFields[field.Name], Disabled = !attributes.HasFlag(ViewFieldAttributes.Editable) }).ToList();
        }

        /// <summary>
        /// Get the list of fields marked 'X' for dynamic enablement.
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <returns></returns>
        private Dictionary<string, string> GetDynamicFields<T>()
        {
            var propertyInfo = typeof(T).GetProperty("DynamicAttributes");
            if (propertyInfo != null)
            {
                var attributeList = (Dictionary<string, string>)propertyInfo.GetValue(null);

                if (attributeList != null)
                {
                    return attributeList;
                }
            }
            return null;
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

            try
            {
                // Get the field value
                object fieldValue = View.Fields.FieldByID(index).Value;

                // Do null check
                if (fieldValue != null)
                {
                    object objectEmpty = string.Empty;
                    if (fieldValue != objectEmpty)
                    {
                        // Check if the type of enum is expected.
                        if (typeof(Enum) == typeof(T).BaseType)
                        {
                            // return the enumeration.
                            return EnumUtility.GetEnum<T>(fieldValue.ToString());
                        }

                        object objectSet = Convert.ChangeType(fieldValue, typeof(T));

                        // return value with appropriate type.
                        return (T)objectSet;
                    }
                }
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
            return value;
        }

        /// <summary>
        /// Gets Field MinValue
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="name">Field Name</param>
        /// <returns>T.</returns>
        public T GetMinimumValue<T>(string name)
        {
            var value = default(T);
            object objectEmpty = string.Empty;

            try
            {
                // Do null check
                if (View.Fields.FieldByName(name).MinValue == null ||
                    View.Fields.FieldByName(name).MinValue == objectEmpty)
                {
                    return value;
                }

                var objectSet = Convert.ChangeType(View.Fields.FieldByName(name).MinValue, typeof(T));
                value = (T)objectSet;
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
            return value;
        }

        /// <summary>
        /// Gets FieldMinValue By ID
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="index">Field Index</param>
        /// <returns>T.</returns>
        public T GetMinimumValue<T>(int index)
        {
            var value = default(T);
            object objectEmpty = string.Empty;
            try
            {
                // Do null check
                if (View.Fields.FieldByID(index).MinValue == null ||
                    View.Fields.FieldByID(index).MinValue == objectEmpty)
                {
                    return value;
                }

                var objectSet = Convert.ChangeType(View.Fields.FieldByID(index).MinValue, typeof(T));
                value = (T)objectSet;
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
            return value;
        }

        /// <summary>
        /// Goes to next view
        /// </summary>
        /// <returns>A bool value if next record existes,else false</returns>
        public bool Next()
        {
            try
            {
                return View.GoNext();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Goes to previous view
        /// </summary>
        /// <returns>A bool value if previous record existes,else false</returns>
        public bool Previous()
        {
            try
            {
                return View.GoPrev();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Goes to top of the view
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Top()
        {
            try
            {
                return View.GoTop();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Fetches based on lock record
        /// </summary>
        /// <param name="lockRecord">if set to <c>true</c> [lock record].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Fetch(bool lockRecord)
        {
            try
            {
                return View.Fetch(lockRecord);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Refresh MetaData
        /// </summary>
        /// <remarks>Invokes InternalSet(256). Needs to cast to View since Interop interface does not have InternalSet exposed</remarks>
        public void RefreshMetaData()
        {
            try
            {
                ((View)View).InternalSet(256);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Browse based on filter and sorting order
        /// </summary>
        /// <param name="filter">Filter Citeria</param>
        /// <param name="ascending">Ascending</param>
        public void Browse(string filter, bool ascending)
        {
            try
            {
                View.Browse(filter, ascending);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Reads based on lockRecord
        /// </summary>
        /// <param name="lockRecord">lock Record</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Read(bool lockRecord)
        {
            try
            {
                return View.Read(lockRecord);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Process view
        /// </summary>
        public void Process()
        {
            try
            {
                View.Process();
                _databaseAuditRepository.Log(EventType.Process, this);
            }
            catch (Exception exception)
            {
                var errors = Helper.GetExceptions(Session);
                //When Process throw COM exception with no session Errors and LastReturnCode greater than zero.No need to throw any exception to the view.
                if (!(errors.Count == 0 && View.LastReturnCode > 0))
                {
                    throw ExceptionHelper.BusinessException(exception, errors);
                }
            }
        }

        /// <summary>
        /// Process based criterias
        /// </summary>
        /// <param name="setId">Set Id</param>
        /// <param name="value">Value</param>
        /// <param name="verify">Verify</param>
        public void Process(int setId, object value, bool verify)
        {
            try
            {
                SetValue(setId, value, verify);
                Process();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Cancel
        /// </summary>
        public void Cancel()
        {
            try
            {
                // IC View Label Headers IC0365 - ICLBLH.viewCancel is not available. Hence skip View.Cancel() 
                // PO Distribution Proration PO0424 - POINVK.viewCancel is not available. Hence skip View.Cancel() 
                if (View.ViewID == ViewICLabelHeader || View.ViewID == ViewPODistributionProration
                    || View.ViewID == ViewReceiptDistributionProration || View.ViewID == ViewPOCrDrDistributeProration)
                {
                    return;
                }

                View.Cancel();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Filter Select
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="ascending">Ascending</param>
        /// <param name="viewKey">View Key</param>
        /// <param name="viewFilterOrigin">ViewFilter Origin</param>
        public void FilterSelect(string filter, bool ascending, int viewKey, ViewFilterOrigin viewFilterOrigin)
        {
            try
            {
                View.FilterSelect(filter, ascending, viewKey, viewFilterOrigin);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Filter count
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="flags">Flags</param>
        /// <returns>System.Int32.</returns>
        public int FilterCount(string filter, int flags)
        {
            try
            {
                return View.FilterCount(filter, flags);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Dispose View
        /// </summary>
        public void Destroy()
        {
            Destroy(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///  TO dispose view
        /// </summary>
        /// <param name="disposing"></param>
        public void Destroy(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // GL0409 should not be disposed as this is throwing error
                    // This is a temporary fix given
                    if (View.ViewID != ViewGLCreateAllocationBatch)
                        View.Dispose();
                }

                // Release any unmanaged resource
                _isDisposed = true;
            }
        }


        /// <summary>
        /// This method does not do anythings. Views are not disposed
        /// </summary>
        public void Dispose()
        {
            View.Cancel();
        }

        /// <summary>
        /// Compose view
        /// </summary>
        /// <param name="views">Array of views</param>
        public void Compose(IViewComInterop[] views)
        {
            try
            {
                if (_isComposed) return;

                View.Compose(Array.ConvertAll(views, item => (View)item));

                _isComposed = true;
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// UNlock
        /// </summary>
        public void Unlock()
        {
            try
            {
                View.Unlock();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete()
        {
            try
            {
                View.Delete();
                _databaseAuditRepository.Log(EventType.Delete, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Bulk get
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <returns>Object array - values of all the field ID's</returns>
        public object[] BulkGet(int[] fieldIDs)
        {
            try
            {
                return View.BlkGet(fieldIDs);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Bulk put
        /// </summary>
        /// <param name="fieldIDs">array of all the field ID's</param>
        /// <param name="fieldValues">array of all the field values's</param>
        /// <param name="verifyValues">Indicates whether validation should be performed by the view on the new values</param>
        /// <returns>Object array - values of all the field ID's</returns>
        public void BulkPut(int[] fieldIDs, object[] fieldValues, bool verifyValues)
        {
            try
            {
                View.BlkPut(fieldIDs, fieldValues, verifyValues);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// FilterDelete
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="strictness">Controls how the deletion operation acts on multiple tables</param>
        public void FilterDelete(string filter, ViewFilterStrictness strictness)
        {
            try
            {
                View.FilterDelete(filter, strictness);
                _databaseAuditRepository.Log(EventType.FilterDelete, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Creates a record
        /// </summary>
        /// <param name="flags">Insert record, No Insert or DelayKey</param>
        public void RecordCreate(ViewRecordCreate flags)
        {
            try
            {
                View.RecordCreate(flags);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Navigates to the last record
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Bottom()
        {
            try
            {
                return (View.GoBottom());
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Invoke Post method of library
        /// </summary>
        public void Post()
        {
            try
            {
                View.Post();
                _databaseAuditRepository.Log(EventType.Post, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Has permission to inquire
        /// </summary>
        public bool CanInquire
        {
            get
            {
                if (Session.IsAdmin)
                {
                    return true;
                }
                if (CanModify)
                {
                    return true;
                }
                return View.Security.HasFlag(ViewSecurity.Inquire);
            }
        }

        /// <summary>
        /// Has permission to Modify
        /// </summary>
        public bool CanModify
        {
            get
            {
                if (Session.IsAdmin)
                {
                    return true;
                }
                return View.Security.HasFlag(ViewSecurity.Modify);
            }
        }

        /// <summary>
        /// Has permission to Delete
        /// </summary>
        public bool CanDelete
        {
            get
            {
                if (Session.IsAdmin)
                {
                    return true;
                }
                return View.Security.HasFlag(ViewSecurity.Delete);
            }
        }

        /// <summary>
        /// Has permission to Add
        /// </summary>
        public bool CanAdd
        {
            get
            {
                if (Session.IsAdmin)
                {
                    return true;
                }
                return View.Security.HasFlag(ViewSecurity.Add);
            }
        }

        /// <summary>
        /// Has permission to Post
        /// </summary>
        /// <returns><c>true</c> if this instance can post; otherwise, <c>false</c>.</returns>
        public bool CanPost
        {
            get
            {
                if (Session.IsAdmin)
                {
                    return true;
                }
                return View.Security.HasFlag(ViewSecurity.Post);
            }
        }

        /// <summary>
        /// Indicates whether the current business entity is dirty. A record is dirty if any of the field values was modified by the application. 
        /// </summary>
        public bool Dirty
        {
            get { return View.Dirty; }
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~BusinessEntity()
        {
            Destroy(false);
        }

        /// <summary>
        /// Verify
        /// </summary>
        public void Verify()
        {
            try
            {
                View.Verify();
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }


        /// <summary>
        /// Security
        /// </summary>
        public ViewSecurity Security
        {
            get { return View.Security; }
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
            var presentationItems = View.Fields.FieldByID(fieldIndex).PresentationList;
            for (var i = 0; i < presentationItems.Count; i++)
            {
                if (presentationItems[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets/sets the current selected key on the view. Changing the selected key affects the order in which records are fetched from the view. 
        /// When a view is first opened, the default selected key is always key 0. 
        /// </summary>
        /// <value>
        /// The Order.
        /// </value>
        public int Order
        {
            get { return View.Order; }
            set { View.Order = value; }
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
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Check whether revison exists for specify level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool RevisionExists(int level)
        {
            try 
            {
                return (View.RevisionExists(level));
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
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
                _databaseAuditRepository.Log(EventType.Post, this);
            }
            catch (Exception exception)
            {
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
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
                throw ExceptionHelper.BusinessException(exception, Helper.GetExceptions(Session));
            }
        }

        /// <summary>
        /// Indicates the view protocol specifications this view implements
        /// </summary>
        public ViewProtocol InstanceProtocol
        {
            get { return View.InstanceProtcol; }
        }
    }
}