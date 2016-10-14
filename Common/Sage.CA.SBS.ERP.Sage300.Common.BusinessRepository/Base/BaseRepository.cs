/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Class that contains base methods
    /// </summary>
    public abstract class BaseRepository : IDisposable
    {
        /// <summary>
        /// Ui screens that need system link
        /// </summary>
        private static readonly string[] sytemLinkUI = {ScreenName.User, ScreenName.SecurityGroup, ScreenName.UserAuthorizations, ScreenName.CurrencyCodes, ScreenName.CurrencyRate, ScreenName.CurrencyRateType };

        /// <summary>
        /// IsReadOnly property - opens business entity in readonly mode
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// BusinessEntitySession
        /// </summary>
        private IBusinessEntitySession _session;

        /// <summary>
        /// DBLinkType
        /// </summary>
        private readonly DBLinkType _dbLinkType;

        /// <summary>
        /// Name of the repository that is calling the Base Repository
        /// </summary>
        private string ConsumingRepositoryName
        {
            get
            {
                return GetType().Namespace + "," + GetType().Name;
            }
        }

        /// <summary>
        /// To checked if is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// This token is used when DisablePooling is true
        /// </summary>
        private Guid _token;

        /// <summary>
        /// To checked if Session Created 
        /// </summary>
        protected bool IsNewSessionCreated;

        /// <summary>
        /// Session Pool Type
        /// </summary>
        protected ObjectPoolType SessionPoolType { get; private set; }

        /// <summary>
        /// BusinessEntitySessionParams
        /// </summary>
        protected BusinessEntitySessionParams BusinessEntitySessionParams { get; private set; }

        /// <summary>
        /// Gets or sets Context
        /// </summary>
        protected Context Context { get; private set; }

        /// <summary>
        /// Gets or sets Session
        /// </summary>
        protected IBusinessEntitySession Session
        {
            get { return GetSession(); }
        }

        /// <summary>
        /// Get company session
        /// </summary>
        protected IBusinessEntitySession CompanySession
        {
            get { return GetCompanySession(); }
        }

        /// <summary>
        /// Check if Session is Available for the same Context token
        /// </summary>
        /// <returns></returns>
        protected bool IsSessionAvailable()
        {
            //The DB Link type is hard coded to company - the base assumption is all  the stateful screens will have to use Company database
            var entityErrors = new List<EntityError> { new EntityError { Message = CommonResx.ServerDownDataRefreshMessage, Priority = Priority.Error } };
            if (_session != null && IsNewSessionCreated)
            {
                throw ExceptionHelper.BusinessException(entityErrors);
            }

            if (BusinessPoolManager.IsSessionAvailable(Context, DBLinkType.Company, BusinessEntitySessionParams)) return true;
            throw ExceptionHelper.BusinessException(entityErrors);
        }

        /// <summary>
        /// Whether to use system db link. 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected static bool IsSystemLink(Context context)
        {
            return ConfigurationHelper.IsOnPremise && Array.IndexOf(sytemLinkUI, context.ScreenContext.ScreenName) > -1 ;
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="sessionPoolType"></param>
        /// <param name="businessEntitySessionParams"></param>
        protected BaseRepository(Context context, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, DBLinkType.Company, null, sessionPoolType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        protected BaseRepository(Context context)
            : this(context, DBLinkType.Company)
        {
        }

        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected BaseRepository(Context context, ObjectPoolType sessionPoolType)
            : this(context, DBLinkType.Company, null, sessionPoolType, null)
        {
        }


        /// <summary>
        /// Sets Context and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">Type of DBLink</param>
        protected BaseRepository(Context context, DBLinkType dbLinkType)
            : this(context, dbLinkType, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dbLinkType">Type of the database link.</param>
        /// <param name="sessionPoolType">Type of the session pool.</param>
        /// <param name="businessEntitySessionParams">The business entity session parameters.</param>
        protected BaseRepository(Context context, DBLinkType dbLinkType, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
            : this(context, dbLinkType, null, sessionPoolType, businessEntitySessionParams)
        {
        }

        /// <summary>
        /// Sets Context and Session and defaults DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        protected BaseRepository(Context context, IBusinessEntitySession session)
            : this(context, DBLinkType.Company, session)
        {
        }

        /// <summary>
        /// Sets Context and Session and DBLink
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLink</param>
        /// <param name="session">Session</param>
        protected BaseRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session) :
            this(context, dbLinkType, session, ObjectPoolType.Default, null)
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
        protected BaseRepository(Context context, DBLinkType dbLinkType, IBusinessEntitySession session, ObjectPoolType sessionPoolType, BusinessEntitySessionParams businessEntitySessionParams)
        {
            Context = context;
            _dbLinkType = dbLinkType;
            _session = session;
            SessionPoolType = sessionPoolType;
            BusinessEntitySessionParams = businessEntitySessionParams ?? BusinessEntitySessionParams.Get(Context);
        }

        /// <summary>
        /// Resolve T
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T</returns>
        protected T Resolve<T>()
        {
            return Helper.Resolve<T>(Context, Session);
        }

        /// <summary>
        /// Opens Entity 
        /// </summary>
        /// <param name="name">Entity Name</param>
        /// <param name="maintainState">If true cancel will not be called until disposed else it will be called whenever this method is called</param>
        /// <returns>BusinessEntity</returns>
        protected virtual IBusinessEntity OpenEntity(string name, bool maintainState)
        {
            return Session.OpenView(name, Session, maintainState, ConsumingRepositoryName, Context, IsReadOnly);
        }

        /// <summary>
        /// Opens Entity 
        /// </summary>
        /// <param name="name">Entity Name</param>
        /// <returns>BusinessEntity</returns>
        protected virtual IBusinessEntity OpenEntity(string name)
        {
            return Session.OpenView(name, Session, ConsumingRepositoryName, Context, IsReadOnly);
        }

        /// <summary>
        /// Opens Entity using open extra object
        /// </summary>
        /// <param name="name">Entity Name</param>
        /// <param name="extra"></param>
        /// <returns>BusinessEntity</returns>
        protected virtual IBusinessEntity OpenEntity(string name, object extra)
        {
            return Session.OpenView(name, Session, extra, ConsumingRepositoryName, Context, IsReadOnly);
        }

        /// <summary>
        /// Removes entity from cache if it exists.
        /// </summary>
        /// <param name="name"></param>
        protected void RemoveEntityFromCache(string name)
        {
            Session.RemoveViewFromCache(name, ConsumingRepositoryName, IsReadOnly);
        }

        /// <summary>
        ///  Get the list of editable and non editable attributes.
        /// </summary>
        /// <param name="businessEntity">Buiness Entity instance</param>
        /// <returns></returns>
        protected virtual List<EnablementAttribute> GetAttributes<T>(IBusinessEntity businessEntity)
        {
            return businessEntity.GetAttributes<T>();
        }

        /// <summary>
        /// Disposes Entity
        /// </summary>
        /// <param name="businessEntity">Entity To Dispose</param>
        protected void DisposeEntity(IBusinessEntity businessEntity)
        {
            if (businessEntity != null)
            {
                businessEntity.Dispose();
            }
        }

        /// <summary>
        /// Gets GetExceptions
        /// </summary>
        /// <returns>List of exception</returns>
        protected List<EntityError> GetExceptions()
        {
            return Helper.GetExceptions(Session);
        }

        #region Helper

        /// <summary>Starts a query and establishes the direction for subsequent calls that fetch records from the business entity.</summary>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="filter">Filter clause</param>
        /// <param name="activeFilter">Active Filter for filtering to be used if filter is null</param>
        /// <param name="isAscending">Order By - Whether it is ascending or not</param>
        protected void SetBrowse<T>(IBusinessEntity businessEntity, Expression<Func<T, bool>> filter,
            Expression<Func<T, bool>> activeFilter = null, bool isAscending = true)
        {
            string filterToApply = null;

            if (filter != null)
            {
                filterToApply = ExpressionHelper.Translate(filter);
            }

            if (string.IsNullOrEmpty(filterToApply) && activeFilter != null)
            {
                filterToApply = ExpressionHelper.Translate(activeFilter);
            }

            businessEntity.Browse(filterToApply, isAscending);
        }

        /// <summary>
        /// Starts a query and establishes the direction for subsequent calls that fetch records from the business entity. 
        /// </summary>
        /// <typeparam name="T">Modlebase</typeparam>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="filter">Filter expression</param>
        /// <param name="activeFilter">Active filter expression</param>
        /// <param name="orderBy">Order By</param>
        /// <param name="fetchTotalResultCount">If true then only fetch the total result</param>
        /// <returns>Filtered count of data</returns>
        protected int SetFilter<T>(IBusinessEntity businessEntity, Expression<Func<T, bool>> filter,
            Expression<Func<T, bool>> activeFilter = null, OrderBy orderBy = null, bool fetchTotalResultCount = true) where T : ModelBase
        {
            string filterToApply = null;

            if (filter != null)
            {
                filterToApply = ExpressionHelper.Translate(filter);
            }

            if (string.IsNullOrEmpty(filterToApply) && activeFilter != null)
            {
                filterToApply = ExpressionHelper.Translate(activeFilter);
            }

            businessEntity.FilterSelect(filterToApply, OrderByHelper.IsAscending(orderBy), OrderByHelper.GetIndex<T>(orderBy), ViewFilterOrigin.FromStart);

            return fetchTotalResultCount ? businessEntity.FilterCount(filterToApply, 0) : -1;
        }

        /// <summary>
        /// Filter Delete
        /// </summary>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="filter">Filter expression</param>
        /// <param name="viewFilterStrictness">Controls how the deletion operation acts on multiple tables</param>
        /// <typeparam name="T">Modelbase</typeparam>
        protected void FilterDelete<T>(IBusinessEntity businessEntity, Expression<Func<T, bool>> filter,
            ViewFilterStrictness viewFilterStrictness = ViewFilterStrictness.Simulate) where T : ModelBase
        {
            string filterToApply = null;

            if (filter != null)
            {
                filterToApply = ExpressionHelper.Translate(filter);
            }

            businessEntity.FilterDelete(filterToApply, viewFilterStrictness);
        }

        /// <summary>
        /// Get basic details for model
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <param name="mapper">Model converter</param>
        /// <param name="currentPageNumber">The current page number.</param>
        /// <param name="currentPageSize">Size of the current page.</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>
        /// Basic details
        /// </returns>
        protected IEnumerable<T> MapDataToModel<T>(IBusinessEntity businessEntity, ModelMapper<T> mapper,
            int? currentPageNumber = null, int? currentPageSize = null, int? filterCount = null, Func<T, bool> validator = null)
            where T : ModelBase, new()
        {
            var model = new List<T>();
            var startIndex = CommonUtil.ComputeStartIndex(currentPageNumber, currentPageSize);
            var endIndex = CommonUtil.ComputeEndIndex(currentPageNumber, currentPageSize, filterCount);
            var loopCounter = 1;

            do
            {
                if (loopCounter >= startIndex)
                {

                    var item = MapData(mapper, businessEntity);
                    if (validator != null)
                    {
                        if (!validator(item))
                        {
                            continue;
                        }
                    }

                    if (item != null)
                    {
                        //The below line is added so that people dont have to loop for updating display index again in controller internal
                        item.DisplayIndex = loopCounter;
                        model.Add(item);
                    }
                }

                loopCounter++;
            } while (loopCounter <= endIndex && businessEntity.Next());

            return model;
        }

        /// <summary>
        /// Get paged records based on the parameters.
        /// This method is only used to display records in grids.
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <param name="mapper">Model converter</param>
        /// <param name="pageOptions">Pagination options</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="totalCount">TotalCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>
        /// Basic details
        /// </returns>
        protected IEnumerable<T> MapDataToModel<T>(IBusinessEntity businessEntity, ModelMapper<T> mapper,
            PageOptions<T> pageOptions, int filterCount, int totalCount, Func<T, bool> validator = null)
            where T : ModelBase, new()
        {
            //There are no records
            if (filterCount == 0)
            {
                return GetInsertedRecords(pageOptions);
            }

            var models = new List<T>();
            var startIndex = CommonUtil.ComputeStartIndex(pageOptions.PageNumber, pageOptions.PageSize);
            var endIndex = CommonUtil.ComputeEndIndex(pageOptions.PageNumber, pageOptions.PageSize, totalCount);
            var loopCounter = 1;

            do
            {
                var item = MapData(mapper, businessEntity);

                if (validator != null)
                {
                    if (!validator(item))
                    {
                        continue;
                    }
                }

                // All records (update or deleted) can have child inserted items.
                var insertedRecords = GetInsertedRecords(pageOptions.ModifiedData, pageOptions.GetKey(item),
                    pageOptions.GetKey);

                var matchingRecord =
                    pageOptions.ModifiedData.FirstOrDefault(
                        data => pageOptions.GetKey(data) == pageOptions.GetKey(item) && !data.IsNewLine);

                if (matchingRecord != null)
                {
                    //If record exists in Modified Data and is not deleted then update the Item.
                    if (!matchingRecord.IsDeleted && loopCounter <= endIndex)
                    {
                        item = matchingRecord;
                        AddModel(models, item, startIndex, loopCounter);
                        loopCounter++;
                    }
                }
                else
                {
                    if (loopCounter <= endIndex)
                    {
                        AddModel(models, item, startIndex, loopCounter);
                        loopCounter++;
                    }
                }

                if (insertedRecords.Count > 0)
                {
                    foreach (var insertedRecord in insertedRecords)
                    {
                        if (loopCounter <= endIndex)
                        {
                            AddModel(models, insertedRecord, startIndex, loopCounter);
                            loopCounter++;
                        }
                    }
                }
            } while (loopCounter <= endIndex && businessEntity.Next());

            return models.Take(pageOptions.PageSize).ToList();
        }

        /// <summary>
        /// Get basic details for model
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntities">BusinessEntity</param>
        /// <param name="mapper">Model converter</param>
        /// <param name="currentPageNumber">CurrentPageNumber</param>
        /// <param name="pageSize">PageSize</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>Basic details</returns>
        protected IEnumerable<T> MapDataToModel<T>(List<IBusinessEntity> businessEntities,
            ModelHierarchyMapper<T> mapper, int? currentPageNumber = null, int? pageSize = null,
            int? filterCount = null, Func<T, bool> validator = null) where T : ModelBase, new()
        {
            var model = new List<T>();
            var startIndex = CommonUtil.ComputeStartIndex(currentPageNumber, pageSize);
            var endIndex = CommonUtil.ComputeEndIndex(currentPageNumber, pageSize, filterCount);
            var loopCounter = 1;
            var isInvalidRecord = false;

            if (!(filterCount > 0)) return model;

            do
            {
                if (loopCounter >= startIndex)
                {
                    var item = MapData(mapper, businessEntities);

                    if (validator != null)
                    {
                        isInvalidRecord = !validator(item);
                    }

                    if (item != null && !isInvalidRecord)
                    {
                        //The below line is added so that people dont have to loop for updating display index again in controller internal
                        item.DisplayIndex = loopCounter;
                        model.Add(item);
                    }
                }

                loopCounter++;
            } while (loopCounter <= endIndex && businessEntities[0].Next());
            return model;
        }

        /// <summary>
        /// Search business entity on the expression sent and also fetches the first record
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="expression">Expression on which seach will be applied.</param>
        /// <param name="orderBy">Order By</param>
        /// <param name="lockData">True to lock data otherwise false</param>
        /// <param name="filterOrigin">Filter Origin Enum</param>
        /// <returns>true if search is successfull</returns>
        protected bool Search<T>(IBusinessEntity businessEntity, Expression<Func<T, bool>> expression,
            OrderBy orderBy = null, bool lockData = false, ViewFilterOrigin filterOrigin = ViewFilterOrigin.FromStart)
            where T : ModelBase
        {
            var filter = ExpressionHelper.Translate(expression);

            businessEntity.FilterSelect(filter, OrderByHelper.IsAscending(orderBy), OrderByHelper.GetIndex<T>(orderBy),
                filterOrigin);
            return businessEntity.Fetch(lockData);
        }

        /// <summary>
        /// Validate ETag
        /// </summary>
        /// <typeparam name="T">ModelBase Type</typeparam>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="model">Model</param>
        protected void CheckETag<T>(IBusinessEntity businessEntity, T model) where T : ModelBase
        {
            if (string.CompareOrdinal(businessEntity.ETag, model.ETag) != 0)
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError {Message = CommonResx.UpdateFailedRecordModifiedMessage, Priority = Priority.Error}
                };
                throw ExceptionHelper.BusinessException(entityErrors);
            }
        }

        /// <summary>
        /// Check Access Rights
        /// </summary>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="securityType">Type of security</param>
        protected void CheckRights(IBusinessEntity businessEntity, SecurityType securityType)
        {
            bool hasAccess = false;
            switch (securityType)
            {
                case SecurityType.Inquire:
                    {
                        hasAccess = businessEntity.CanInquire;
                        break;
                    }
                case SecurityType.Add:
                    {
                        hasAccess = businessEntity.CanAdd;
                        break;
                    }
                case SecurityType.Delete:
                    {
                        hasAccess = businessEntity.CanDelete;
                        break;
                    }
                case SecurityType.Modify:
                    {
                        hasAccess = businessEntity.CanModify;
                        break;
                    }
                case SecurityType.Post:
                    {
                        hasAccess = businessEntity.CanPost;
                        break;
                    }
            }

            if (!hasAccess)
            {
                throw ExceptionHelper.NotAuthorizedException();
            }
        }

        /// <summary>
        /// Check Access Rights
        /// </summary>
        /// <param name="userAccess">UserAccess</param>
        /// <param name="securityType">Type of security</param>
        protected void CheckRights(UserAccess userAccess, SecurityType securityType)
        {
            if (!userAccess.SecurityType.HasFlag(securityType))
            {
                throw ExceptionHelper.NotAuthorizedException();
            }
        }

        /// <summary>
        /// Check Access Rights
        /// </summary>
        /// <param name="userAccess">UserAccess</param>
        /// <param name="securityType">Type of security</param>
        /// <param name="resourceId">Resource Id</param>
        protected void CheckRights(UserAccess userAccess, SecurityType securityType, string resourceId)
        {
            CheckRights(userAccess, securityType);
            if (userAccess.ResourceSecurity != null)
            {
                UserAccess resourceAccess;
                userAccess.ResourceSecurity.TryGetValue(resourceId, out resourceAccess);
                if (resourceAccess != null && !resourceAccess.SecurityType.HasFlag(securityType))
                {
                    throw ExceptionHelper.NotAuthorizedException();
                }
            }
            else
            {
                throw new InvalidOperationException("Resource Dictionary is empty");
            }
        }

        /// <summary>
        /// Get rights
        /// </summary>
        /// <param name="businessEntity">Business Entity</param>
        /// <returns>UserAccess</returns>
        protected UserAccess GetAccessRights(IBusinessEntity businessEntity)
        {
            var userAccess = new UserAccess();

            //Since this logic is common to most of the screens, user will have ADD and Delete permissions also if he has modify permission.
            if (businessEntity.CanModify)
            {
                userAccess.SecurityType = SecurityType.Add | SecurityType.Delete | SecurityType.Modify;
            }

            if (businessEntity.CanPost)
            {
                AddSecurityType(userAccess, SecurityType.Post);
            }

            if (businessEntity.CanInquire)
            {
                AddSecurityType(userAccess, SecurityType.Inquire);
                AddSecurityType(userAccess, SecurityType.Print);
            }

            if (Session.IsAdmin)
            {
                AddSecurityType(userAccess, SecurityType.Admin);
            }
            return userAccess;
        }

        /// <summary>
        /// Check if it has security right 
        /// </summary>
        /// <param name="userAccess">Current user access type</param>
        /// <param name="securityType">Current user security rights</param>
        /// <returns>Returns true if it has security right</returns>
        protected bool HasSecurityCheck(UserAccess userAccess, SecurityType securityType)
        {
            return userAccess.SecurityType.HasFlag(securityType);
        }

        /// <summary>
        /// Security Check for a resource
        /// </summary>
        /// <param name="resourceId">Resource Id</param>
        protected bool SecurityCheck(string resourceId)
        {
            return Session.SecurityCheck(resourceId);
        }

        /// <summary>
        /// Add Security
        /// </summary>
        /// <param name="userAccess">UserAccess</param>
        /// <param name="securitytoAdd">SecurityType</param>
        protected void AddSecurityType(UserAccess userAccess, SecurityType securitytoAdd)
        {
            if (userAccess.SecurityType.HasFlag(SecurityType.None))
            {
                userAccess.SecurityType = securitytoAdd;
            }
            else
            {
                userAccess.SecurityType = userAccess.SecurityType | securitytoAdd;
            }
        }

        /// <summary>
        /// Check whether application is active or not.
        /// </summary>
        /// <param name="applicationId">Application Id</param>
        /// <returns>True if application is active else false</returns>
        protected bool IsApplicationActive(string applicationId)
        {
            var application = Session.GetActiveApplications().FirstOrDefault(applications => applications.AppId == applicationId);
            return application != null &&
                   application.IsInstalled && !string.IsNullOrEmpty(application.AppVersion);
        }

        #endregion

        #region Private Methods

        #region Pagination

        /// <summary>
        /// Get inserted records based on the passed key.
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="modifiedData">Modified data</param>
        /// <param name="key">Key</param>
        /// <param name="getKey">GetKey function</param>
        /// <returns>List of inserted records.</returns>
        private List<T> GetInsertedRecords<T>(List<T> modifiedData, string key, Func<T, string> getKey)
           where T : ModelBase
        {
            var records = new List<T>();

            //This while condition will make sure under no circumstances, this loop becomes infinite.
            while (records.Count <= modifiedData.Count)
            {
                var record =
                    modifiedData.FirstOrDefault(
                        item => item.PreviousKey == key && !item.IsDeleted && item.IsNewLine);
                if (record == null || getKey(record) == key)
                {
                    break;
                }
                records.Add(record);
                key = getKey(record);
            }
            return records;
        }

        /// <summary>
        /// Get paginated records
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="pageOptions">Pagination Options</param>
        /// <returns>List of records</returns>
        private IEnumerable<T> GetInsertedRecords<T>(PageOptions<T> pageOptions) where T : ModelBase
        {
            var records = new List<T>();

            //Get the first record
            var parentRecord =
                pageOptions.ModifiedData.First(item => string.IsNullOrEmpty(item.PreviousKey) && !item.IsDeleted);
            records.Add(parentRecord);

            var childRecords = GetInsertedRecords(pageOptions.ModifiedData, pageOptions.GetKey(parentRecord),
                pageOptions.GetKey);

            records.AddRange(childRecords);

            var startIndex = pageOptions.PageNumber * pageOptions.PageSize;
            return records.Skip(startIndex).Take(pageOptions.PageSize).AsEnumerable();
        }

        /// <summary>
        /// Add model to the passed list based on startIndex and CurrentIndex
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="models">List of models</param>
        /// <param name="model">Model to be added</param>
        /// <param name="startIndex">StartIndex</param>
        /// <param name="currentIndex">CurrentIndex</param>
        private void AddModel<T>(List<T> models, T model, int startIndex, int currentIndex) where T : ModelBase
        {
            if ((startIndex - 1) < currentIndex)
            {
                models.Add(model);
            }
        }

        #endregion

        /// <summary>
        /// MapData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapper">ModelMapper</param>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <returns>T</returns>
        private T MapData<T>(ModelMapper<T> mapper, IBusinessEntity businessEntity) where T : ModelBase, new()
        {
            T item = null;

            if (mapper != null)
            {
                item = mapper.Map(businessEntity);
            }

            return item;
        }

        /// <summary>
        /// MapData
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mapper">ModelMapper</param>
        /// <param name="businessEntities">BusinessEntity</param>
        /// <returns>T</returns>
        private T MapData<T>(ModelHierarchyMapper<T> mapper, List<IBusinessEntity> businessEntities)
            where T : ModelBase
        {
            T item = null;

            if (mapper != null)
            {
                item = mapper.Map(businessEntities);
            }

            return item;
        }

        #endregion

        #region IDisposable Methods

        /// <summary>
        /// Disposes 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                if (_session != null && IsNewSessionCreated)
                {
                    if (SessionPoolType == ObjectPoolType.Disable && _token != Guid.Empty)
                    {
                        BusinessPoolManager.Destroy(Context, _token, _dbLinkType, BusinessEntitySessionParams);
                        _token = Guid.Empty;
                    }
                    else
                    {
                        _session.Dispose();
                    }
                    _session = null;
                }
            }
            _isDisposed = true;
        }

        #endregion

        #region Export/Import functionlity

        #region Export/Import functionlity - Virtual methods

        /// <summary>
        /// Insert/Update business entity
        /// </summary>
        /// <param name="businessEntity">Business entity with all the field value updated</param>
        /// <param name="importType">import type (update/insert/update-insert)</param>
        /// <param name="importResponse">Response details</param>
        /// <param name="isUpdate">update? or insert?</param>
        protected virtual bool Save(IBusinessEntity businessEntity, ImportType importType, ResponseMessage importResponse, bool isUpdate)
        {
            var isSavedOrUpdated = false;
            importResponse.Processed++;
            if (isUpdate && businessEntity.Exists)
            {
                if ((importType == ImportType.InsertUpdate || importType == ImportType.Update || importType == ImportType.Replace || importType == ImportType.InsertReplace) && businessEntity.Dirty)
                {
                    Save(businessEntity, importResponse);
                    importResponse.Updated++;
                    isSavedOrUpdated = true;
                }
            }
            else if (importType == ImportType.InsertUpdate || importType == ImportType.Insert || importType == ImportType.InsertReplace)
            {
                Save(businessEntity, importResponse, true);
                importResponse.Inserted++;
                isSavedOrUpdated = true;
            }
            return isSavedOrUpdated;
        }

        /// <summary>
        /// Import (helper method) - Each row into business entity and Update/Insert.
        /// </summary>
        /// <param name="dataTable">Table - for column details</param>
        /// <param name="row">Row item</param>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="generateRecord">calls RecordCreate in case the record does not exits</param>
        /// <returns>True if record exists else false</returns>
        protected virtual bool Import(DataTable dataTable, DataRow row, IBusinessEntity businessEntity, bool generateRecord = false)
        {
            return Import(dataTable, row, businessEntity, generateRecord, ViewRecordCreate.NoInsert);
        }

        /// <summary>
        /// Import (helper method) - Each row into business entity and Update/Insert.
        /// </summary>
        /// <param name="dataTable">Table - for column details</param>
        /// <param name="row">Row item</param>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="generateRecord">calls RecordCreate in case the record does not exits</param>
        /// <param name="recordCreateOption">ViewRecordCreate enum</param>
        /// <returns>True if record exists else false</returns>
        protected virtual bool Import(DataTable dataTable, DataRow row, IBusinessEntity businessEntity, bool generateRecord, ViewRecordCreate recordCreateOption)
        {
            try
            {
                businessEntity.SystemAccess = ViewSystemAccess.Import;
                businessEntity.ClearRecord();
                SetKeyFields(dataTable, row, businessEntity);
                var isExists = businessEntity.Read(false);
                if (!isExists && generateRecord)
                {
                    businessEntity.RecordCreate(recordCreateOption);
                }
                SetOtherFields(dataTable, row, businessEntity);
                return isExists;
            }
            catch (BusinessException businessException)
            {
                businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = string.Format(CommonResx.ProcessingStopped, dataTable.Rows.IndexOf(row), dataTable.TableName) });
                throw;
            }
            catch (Exception exception)
            {
                var businessException = new BusinessException(string.Empty, exception, Helper.GetExceptions(Session));
                businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = string.Format(CommonResx.ProcessingStopped, dataTable.Rows.IndexOf(row), dataTable.TableName) });
                if (businessException.Errors.Count == 1)
                {
                    throw;
                }
                throw businessException;
            }
        }

        /// <summary>
        /// Get and Set all the Key fields into business entity 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="row"></param>
        /// <param name="businessEntity"></param>
        protected virtual void SetKeyFields(DataTable dataTable, DataRow row, IBusinessEntity businessEntity)
        {
            var keyFields = GetKeyField(businessEntity);
            foreach (var field in keyFields)
            {
                ValidateRequiredField(dataTable, field.Name);
                SetFieldValueForImport(businessEntity, field, row);
            }
        }

        /// <summary>
        /// Get and Set all other fields into business entity
        /// </summary>
        /// <param name="dataTable">Field values to be set in all rows</param>
        /// <param name="row">Field values to be set in a row</param>
        /// <param name="businessEntity">Business Entity</param>
        protected virtual void SetOtherFields(DataTable dataTable, DataRow row, IBusinessEntity businessEntity)
        {
            SetOtherFields(dataTable, row, businessEntity, null);
        }

        /// <summary>
        /// Matches the Excel sheet (DataTable and DataRow) and returns the matching details for the headerRow.
        /// This method has to be overridden by the implementer class.
        /// </summary>
        /// <param name="headerRow">header row</param>
        /// <param name="detailTable">header details - DataTable</param>
        /// <param name="headerKeys">Key columns of header entity</param>
        /// <param name="importRequest">Export Request</param>
        /// <returns>list of rows</returns>
        protected virtual IList<DataRow> GetMatchingRows(DataRow headerRow, DataTable detailTable, List<ViewField> headerKeys, ImportRequest importRequest)
        {
            var detailRows = new List<DataRow>();
            foreach (var detailRow in detailTable.AsEnumerable())
            {
                var isRowMatched = true;
                foreach (var headerKey in headerKeys)
                {
                    var headerKeyValue = headerRow[headerKey.Name];
                    if (headerKeyValue.Equals(detailRow[headerKey.Name]))
                    {
                        continue;
                    }
                    isRowMatched = false;
                    break;
                }
                if (isRowMatched)
                {
                    detailRows.Add(detailRow);
                }
            }
            return detailRows;
        }

        #endregion

        /// <summary>
        /// OrderHeaderImport
        /// </summary>
        /// <param name="headerTable">Batch data</param>
        /// <param name="headerEntity">Batch business entity</param>
        /// <param name="detailTable">Header data</param>
        /// <param name="detailEntity">Header business entity</param>
        /// <param name="optionalFieldTable">Detail data</param>
        /// <param name="optionalFieldEntity">Detail business entity</param>
        /// <param name="importRequest">Import request details</param>
        /// <returns></returns>
        protected ImportResponse HeaderDetailOptionalFieldImport(DataTable headerTable,
                                                                    IBusinessEntity headerEntity,
                                                                    DataTable detailTable,
                                                                    IBusinessEntity detailEntity,
                                                                    DataTable optionalFieldTable,
                                                                    IBusinessEntity optionalFieldEntity,
                                                                    ImportRequest importRequest)
        {
            var importResponse = new ImportResponse();
            if (headerTable == null)
            {
                return importResponse;
            }

            CheckRights(GetAccessRights(headerEntity), SecurityType.Modify);
            headerEntity.SystemAccess = ViewSystemAccess.Import;
            detailEntity.SystemAccess = ViewSystemAccess.Import;
            optionalFieldEntity.SystemAccess = ViewSystemAccess.Import;

            var importType = importRequest.ImportType;

            var headerResponse = new ResponseMessage { BusinessEntity = headerTable.TableName };
            var detailResponse = new ResponseMessage { BusinessEntity = detailTable.TableName };
            var optionalFieldResponse = new ResponseMessage { BusinessEntity = optionalFieldTable.TableName };

            headerEntity.Top();
            var batchKeys = GetKeyField(headerEntity);

            // Iterate through each header row.
            foreach (DataRow headerRow in headerTable.Rows)
            {
                var detailResponseForHeader = new ResponseMessage { BusinessEntity = optionalFieldTable.TableName };
                var optionalFieldResponseForHeader = new ResponseMessage { BusinessEntity = optionalFieldTable.TableName };

                //Import header
                var isHeaderExists = Import(headerTable, headerRow, headerEntity, true);

                var detailRows = GetMatchingRows(headerRow, detailTable, batchKeys, importRequest);

                if (!detailRows.Any())
                {
                    //There are no detail records.
                    Save(headerEntity, importType, headerResponse, isHeaderExists);
                    continue;
                }

                CheckRights(GetAccessRights(detailEntity), SecurityType.Modify);

                // Iterate through each detail row.
                foreach (var detailRow in detailRows)
                {
                    var optionalFieldResponseForDetail = new ResponseMessage { BusinessEntity = optionalFieldTable.TableName };
                    var detailKeys = GetKeyField(detailEntity);

                    //Import Detail record
                    var isDetailExists = Import(detailTable, detailRow, detailEntity, true);

                    var optionalFieldRows = GetMatchingRows(detailRow, optionalFieldTable, detailKeys, importRequest);

                    if (!optionalFieldRows.Any())
                    {
                        //There are no optional fields
                        Save(detailEntity, importType, detailResponseForHeader, isDetailExists);
                        continue;
                    }

                    CheckRights(GetAccessRights(optionalFieldEntity), SecurityType.Modify);
                    foreach (var optionalFieldRow in optionalFieldRows)
                    {
                        var isOptionalFieldExists = Import(optionalFieldTable, optionalFieldRow, optionalFieldEntity, true);
                        Save(optionalFieldEntity, importType, optionalFieldResponseForDetail, isOptionalFieldExists);
                    }

                    var isDetailSavedOrUpdated = Save(detailEntity, importType, detailResponseForHeader, isDetailExists);
                    if (isDetailSavedOrUpdated)
                    {
                        optionalFieldResponseForHeader.Processed += optionalFieldResponseForDetail.Processed;
                        optionalFieldResponseForHeader.Updated += optionalFieldResponseForDetail.Updated;
                        optionalFieldResponseForHeader.Inserted += optionalFieldResponseForDetail.Inserted;
                    }
                }
                var isHeaderSavedOrUpdated = Save(headerEntity, importType, headerResponse, isHeaderExists);
                if (isHeaderSavedOrUpdated)
                {
                    detailResponse.Processed += detailResponseForHeader.Processed;
                    detailResponse.Updated += detailResponseForHeader.Updated;
                    detailResponse.Inserted += detailResponseForHeader.Inserted;
                    optionalFieldResponse.Processed += optionalFieldResponseForHeader.Processed;
                    optionalFieldResponse.Updated += optionalFieldResponseForHeader.Updated;
                    optionalFieldResponse.Inserted += optionalFieldResponseForHeader.Inserted;
                }
            }
            importResponse.Messages.Add(headerResponse);
            importResponse.Messages.Add(detailResponse);
            importResponse.Messages.Add(optionalFieldResponse);
            importResponse.Results.AddRange(Helper.GetExceptions(Session));
            return importResponse;
        }

        /// <summary>
        /// OrderHeaderImport
        /// </summary>
        /// <param name="headerTable">Header data</param>
        /// <param name="headerEntity">Header business entity</param>
        /// <param name="detailTable">detail data</param>
        /// <param name="detailEntity">detail business entity</param>
        /// <param name="importRequest">Import request details</param>
        /// <returns></returns>
        protected ImportResponse OrderHeaderImport(DataTable headerTable,
                                                    IBusinessEntity headerEntity,
                                                    DataTable detailTable,
                                                    IBusinessEntity detailEntity,
                                                    ImportRequest importRequest)
        {
            CheckRights(headerEntity, SecurityType.Modify);
            CheckRights(detailEntity, SecurityType.Modify);

            var importResponse = new ImportResponse();

            if (headerTable == null || detailTable == null)
            {
                return importResponse;
            }

            var importType = importRequest.ImportType;

            var headerResponse = new ResponseMessage { BusinessEntity = headerTable.TableName };
            var detailResponse = new ResponseMessage { BusinessEntity = detailTable.TableName };

            headerEntity.Top();
            var headerKeys = GetKeyField(headerEntity);
            // Iterate through each header row.
            foreach (DataRow row in headerTable.Rows)
            {
                var isHeaderExists = Import(headerTable, row, headerEntity, true);
                if (importRequest.ImportType.HasFlag(ImportType.Replace) && !isHeaderExists)
                {
                    continue;
                }
                if ((importType.HasFlag(ImportType.InsertReplace) || importType.HasFlag(ImportType.Replace)) && isHeaderExists)
                {
                    if (detailEntity.Top())
                    {
                        do
                        {
                            detailEntity.Delete();
                        } while (detailEntity.Next());
                    }
                }

                var detailRows = GetMatchingRows(row, detailTable, headerKeys, importRequest);
                if (!detailRows.Any())
                {
                    Save(headerEntity, importType, headerResponse, isHeaderExists);
                    continue;
                }
                // Iterate through each detail row.
                foreach (var detailRow in detailRows)
                {
                    var isDetailExists = Import(detailTable, detailRow, detailEntity, true);
                    detailResponse.Processed++;
                    if (isHeaderExists && isDetailExists)
                    {
                        if ((importType == ImportType.InsertUpdate || importType == ImportType.Update || importType == ImportType.Replace || importType == ImportType.InsertReplace) && detailEntity.Dirty)
                        {
                            Save(detailEntity, detailResponse);
                            detailResponse.Updated++;
                        }
                    }
                    else if (!isDetailExists && importType == ImportType.InsertUpdate || importType == ImportType.Insert || importType == ImportType.Replace || importType == ImportType.InsertReplace)
                    {
                        Save(detailEntity, detailResponse, true);
                        detailResponse.Inserted++;
                    }
                }
                Save(headerEntity, importType, headerResponse, isHeaderExists);
            }
            importResponse.Messages.Add(headerResponse);
            importResponse.Messages.Add(detailResponse);
            importResponse.Results.AddRange(Helper.GetExceptions(Session));
            return importResponse;
        }

        /// <summary>
        /// Try Insert/Update, and throw proper message to user
        /// </summary>
        /// <param name="businessEntity">business entity</param>
        /// <param name="responseMessage">response message</param>
        /// <param name="isInsert">true for insert</param>
        protected void Save(IBusinessEntity businessEntity, ResponseMessage responseMessage, bool isInsert = false)
        {
            try
            {
                if (isInsert)
                {
                    businessEntity.Insert();
                }
                else
                {
                    businessEntity.Update();
                }
            }
            catch (BusinessException businessException)
            {
                if (isInsert)
                {
                    businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = CommonResx.InsertFailedMessage });
                }
                else
                {
                    businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = CommonResx.UpdateRecordFailedMessage });
                }
                businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = string.Format(CommonResx.ProcessingStopped, responseMessage.Processed, responseMessage.BusinessEntity) });
                businessException.Errors.Add(new EntityError { Priority = Priority.Message, Message = responseMessage.ResponseText });

                throw;
            }
        }

        /// <summary>
        /// Import the item from table into database
        /// </summary>
        /// <param name="dataTable">Data Table with all required data</param>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="importType">Import Type</param>
        /// <returns>count of items inserted/updated</returns>
        protected ResponseMessage Import(DataTable dataTable, IBusinessEntity businessEntity, ImportType importType)
        {
            CheckRights(businessEntity, SecurityType.Modify);
            var responseMessage = new ResponseMessage();

            if (dataTable == null)
            {
                return responseMessage;
            }
            bool isExists;
            responseMessage.BusinessEntity = dataTable.TableName;
            businessEntity.Top();
            //Iterate through each row
            foreach (DataRow row in dataTable.Rows)
            {
                isExists = Import(dataTable, row, businessEntity);
                Save(businessEntity, importType, responseMessage, isExists);
            }

            return responseMessage;
        }

        /// <summary>
        /// set value into business entity fields
        /// </summary>
        /// <param name="businessEntity">Business ENtity</param>
        /// <param name="field">Business Entity fields</param>
        /// <param name="row">Value</param>
        protected void SetFieldValueForImport(IBusinessEntity businessEntity, ViewField field, DataRow row)
        {
            if (field == null || !Helper.IsEditable(field))
            {
                return;
            }

            var value = row[field.Name];
            if (Helper.IsNull(value))
            {
                businessEntity.SetNullValue(field.ID);
            }
            else
            {
                businessEntity.SetValue(field.ID, value);
            }
        }

        /// <summary>
        /// Get and Set all other fields into business entity
        /// </summary>
        /// <param name="dataTable">Field values to be set in all rows</param>
        /// <param name="row">Field values to be set in a row</param>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="ignoreKeyFields">List of key columns to be ignored.</param>
        protected void SetOtherFields(DataTable dataTable, DataRow row, IBusinessEntity businessEntity, List<string> ignoreKeyFields)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                var columnName = column.ColumnName;

                if (ignoreKeyFields != null && ignoreKeyFields.Contains(columnName))
                {
                    continue;
                }
                ViewField field = null;
                try
                {
                    field = businessEntity.Fields.FieldByName(columnName);
                }
                catch (Exception exception)
                {
                    Logger.Error(string.Format("Field Name {0} does not exits", columnName), exception);
                }
                SetFieldValueForImport(businessEntity, field, row);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="fieldName"></param>
        protected static void ValidateRequiredField(DataTable dataTable, string fieldName)
        {
            if (!dataTable.Columns.Contains(fieldName))
            {
                var entityError = new EntityError
                {
                    Message = CommonResx.ImportRequiredFieldMissing,
                    Priority = Priority.Error
                };

                var businessException = new BusinessException("Error In Export", new List<EntityError> { entityError });

                throw businessException;
            }
        }

        /// <summary>
        /// Fetch list of view fields
        /// </summary>
        /// <param name="businessEntity">business entity</param>
        /// <returns></returns>
        protected List<ViewField> GetKeyField(IBusinessEntity businessEntity)
        {
            var fieldCount = businessEntity.Fields.Count;

            var viewFields = new List<ViewField>();

            for (var i = 0; i < fieldCount; i++)
            {
                if (businessEntity.Fields[i].Attributes.HasFlag(ViewFieldAttributes.Key))
                {
                    viewFields.Add(businessEntity.Fields[i]);
                }
            }
            return viewFields;
        }

        /// <summary>
        /// Helper method for Export
        /// </summary>
        /// <param name="businessEntity">Business Entity</param>
        /// <param name="headerData">Data Migration - model</param>
        /// <returns>Data Table</returns>
        protected DataTable FlatExport(IBusinessEntity businessEntity, DataMigration headerData)
        {
            CheckRights(businessEntity, SecurityType.Inquire);
            businessEntity.SystemAccess = ViewSystemAccess.Export;

            var resultTable = new DataTable();
            IList<int> fieldIDs = new List<int>();

            resultTable.TableName = Helper.GetTableName(businessEntity);

            foreach (var item in headerData.Items)
            {
                resultTable.Columns.Add(new DataColumn(item.columnName, Helper.GetSystemType(item.dataType)));
                fieldIDs.Add(item.columnId);
            }

            var headerFilter = headerData.FilterString;
            businessEntity.FilterSelect(headerFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            businessEntity.Top();
            do
            {
                var columnValues = businessEntity.BulkGet(fieldIDs.ToArray());
                resultTable.Rows.Add(columnValues);
            } while (businessEntity.Next());

            businessEntity.Cancel();
            return resultTable;
        }

        /// <summary>
        /// Helper method for Export - Header/Detail view
        /// </summary>
        /// <param name="headerEntity">Business Entity - Header</param>
        /// <param name="detailEntity">Business Entity - Detail</param>
        /// <param name="headerData">Data Migration model - header</param>
        /// <param name="detailData">Data Migration model - detail</param>
        /// <returns>Data Table</returns>
        protected DataTable HeaderDetailExport(IBusinessEntity headerEntity, IBusinessEntity detailEntity, DataMigration headerData, DataMigration detailData)
        {
            CheckRights(headerEntity, SecurityType.Inquire);
            CheckRights(detailEntity, SecurityType.Inquire);

            headerEntity.SystemAccess = ViewSystemAccess.Export;
            detailEntity.SystemAccess = ViewSystemAccess.Export;

            var resultTable = new DataTable();
            IList<int> fieldIDs = new List<int>();

            resultTable.TableName = Helper.GetTableName(detailEntity);

            foreach (var item in detailData.Items)
            {
                resultTable.Columns.Add(new DataColumn(item.columnName, Helper.GetSystemType(item.dataType)));
                fieldIDs.Add(item.columnId);
            }

            var headerFilter = headerData == null ? null : headerData.FilterString;
            headerEntity.FilterSelect(headerFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            var detailFilter = detailData.FilterString;
            detailEntity.FilterSelect(detailFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            if (headerEntity.Top())
            {
                do
                {
                    if (detailEntity.Top())
                    {
                        do
                        {
                            var columnValues = detailEntity.BulkGet(fieldIDs.ToArray());
                            resultTable.Rows.Add(columnValues);
                        } while (detailEntity.Next());
                    }
                } while (headerEntity.Next());
            }

            headerEntity.Cancel();
            detailEntity.Cancel();
            return resultTable;
        }

        /// <summary>
        /// Helper method for Export - Header/Detail view
        /// </summary>
        /// <param name="batchEntity">Business Entity - Batch</param>
        /// <param name="headerEntity">Business Entity - Header</param>
        /// <param name="detailEntity">Business Entity - Detail</param>
        /// <param name="batchData">Data Migration model - header</param>
        /// <param name="headerData">Data Migration model - header</param>
        /// <param name="detailData">Data Migration model - detail</param>
        /// <returns>Data Table</returns>
        protected DataTable BatchHeaderDetailExport(IBusinessEntity batchEntity, IBusinessEntity headerEntity, IBusinessEntity detailEntity, DataMigration batchData, DataMigration headerData, DataMigration detailData)
        {
            CheckRights(batchEntity, SecurityType.Inquire);
            CheckRights(headerEntity, SecurityType.Inquire);
            CheckRights(detailEntity, SecurityType.Inquire);

            batchEntity.SystemAccess = ViewSystemAccess.Export;
            headerEntity.SystemAccess = ViewSystemAccess.Export;
            detailEntity.SystemAccess = ViewSystemAccess.Export;

            var resultTable = new DataTable();
            IList<int> fieldIDs = new List<int>();

            resultTable.TableName = Helper.GetTableName(detailEntity);

            foreach (var item in detailData.Items)
            {
                resultTable.Columns.Add(new DataColumn(item.columnName, Helper.GetSystemType(item.dataType)));
                fieldIDs.Add(item.columnId);
            }

            var batchFilter = batchData == null ? null : batchData.FilterString;
            headerEntity.FilterSelect(batchFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            var headerFilter = headerData == null ? null : headerData.FilterString;
            headerEntity.FilterSelect(headerFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            var detailFilter = detailData.FilterString;
            detailEntity.FilterSelect(detailFilter, OrderByHelper.IsAscending(null), 0, ViewFilterOrigin.FromStart);

            if (batchEntity.Top())
            {
                do
                {
                    if (headerEntity.Top())
                    {
                        do
                        {
                            if (detailEntity.Top())
                            {
                                do
                                {
                                    var columnValues = detailEntity.BulkGet(fieldIDs.ToArray());
                                    resultTable.Rows.Add(columnValues);
                                } while (detailEntity.Next());
                            }
                        } while (headerEntity.Next());
                    }
                } while (batchEntity.Next());
            }

            batchEntity.Cancel();
            headerEntity.Cancel();
            detailEntity.Cancel();
            return resultTable;
        }

        #endregion


        /// <summary>
        /// Count inserted and deleted records for the list of items passed.
        /// </summary>
        /// <param name="items">List of items.</param>
        /// <param name="insertedRecords">Number of inserted records.</param>
        /// <param name="deletedRecords">Number of deleted records</param>
        public void Count<T>(List<T> items, out int insertedRecords, out int deletedRecords) where T : ModelBase
        {
            insertedRecords = deletedRecords = 0;
            foreach (var item in items)
            {
                if (item.IsNewLine && !item.IsDeleted)
                {
                    insertedRecords++;
                    continue;
                }
                if (item.IsDeleted && !item.IsNewLine)
                {
                    deletedRecords++;
                }
            }
        }

        /// <summary>
        /// Destroy Sessions which are not in use.
        /// </summary>
        public void DestroyUnusedSessions()
        {
            if (_session == null)
            {
                //This is done because it will mark the current session as inuse.
                GetSession();
            }
            BusinessPoolManager.DestroyUnusedSessions(Context);
        }

        /// <summary>
        /// Unlock Organisation
        /// </summary>
        public void UnlockOrganisation()
        {
            Session.UnlockOrg();
        }

        /// <summary>
        /// Unlocks the Application for specific module. 
        /// </summary>
        /// <param name="applicationId">Application Id GL/AP/etc..</param>
        public void UnlockApplication(string applicationId)
        {
            Session.UnlockApplication(applicationId);
        }

        /// <summary>
        /// Get paged records based on the parameters.
        /// This method is only used to display records in grids.
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <param name="mapper">Model converter</param>
        /// <param name="pageOptions">Pagination options</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="totalCount">TotalCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>
        /// List of models
        /// </returns>
        protected IEnumerable<T> Get<T>(IBusinessEntity businessEntity, ModelMapper<T> mapper,
            PageOptions<T> pageOptions, int filterCount, int totalCount, Func<T, bool> validator = null)
            where T : ModelBase, new()
        {
            return Get(businessEntity, mapper, null, null, pageOptions, filterCount, totalCount, validator);
        }

        /// <summary>
        /// Get paged records based on the parameters.
        /// This method is only used to display records in grids.
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntities">The business entities.</param>
        /// <param name="mapper">Model converter</param>
        /// <param name="pageOptions">Pagination options</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="totalCount">TotalCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>
        /// List of models
        /// </returns>
        protected IEnumerable<T> Get<T>(List<IBusinessEntity> businessEntities, ModelHierarchyMapper<T> mapper,
            PageOptions<T> pageOptions, int filterCount, int totalCount, Func<T, bool> validator = null)
            where T : ModelBase, new()
        {
            return Get(null, null, businessEntities, mapper, pageOptions, filterCount, totalCount, validator);
        }

        /// <summary>
        /// Creates a JSON friendly object
        /// </summary>
        /// <param name="attributes">Attributes</param>
        /// <returns></returns>
        protected IDictionary<string, object> ConvertToDynamic(IEnumerable<EnablementAttribute> attributes)
        {
            IDictionary<string, object> jsonFriendly = new ExpandoObject();
            foreach (var enablementAttribute in attributes)
            {
                jsonFriendly.Add(enablementAttribute.PropertyName, enablementAttribute.Disabled);
            }
            return jsonFriendly;
        }

        /// <summary>
        /// This Get Method is used Inquiry repository, when businessentity and mapper is passed,
        /// returns the value. This method doesn't return total record count, coz superview has limitations in getting total recordcount.
        /// This method will return the total result count current page records + 1 (if any data available in next page).
        /// </summary>
        /// <param name="businessEntity">The business entity.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="pageOptions">The page options.</param>
        /// <returns></returns>
        protected EnumerableResponse<T> Get<T>(IBusinessEntity businessEntity, ModelMapper<T> mapper, PageOptions<T> pageOptions) where T : ModelBase, new()
        {
            // Get data.
            var resultData = MapDataToModel(businessEntity, mapper, pageOptions.PageNumber, pageOptions.PageSize).ToList();

            // check if next record exist to increment the count.
            var nextRecordExist = businessEntity.Next();

            // get the page record count
            var pageTotalCount = (pageOptions.PageNumber + 1) * pageOptions.PageSize;

            // increment the pageTotalCount + 1, if any record exist.
            var totalResultsCount = pageTotalCount + (nextRecordExist ? 1 : 0);

            return new EnumerableResponse<T>
            {
                Items = resultData,
                TotalResultsCount = totalResultsCount
            };

        }

        #region Private Methods

        /// <summary>
        /// Get session
        /// </summary>
        private IBusinessEntitySession GetSession()
        {
            if (_session == null)
            {
                if (SessionPoolType == ObjectPoolType.Disable)
                {
                    _token = Guid.NewGuid();
                    _session = BusinessPoolManager.GetNewSession(Context, _token, _dbLinkType, BusinessEntitySessionParams);
                    IsNewSessionCreated = true;
                }
                else
                {
                    _session = BusinessPoolManager.GetSession(Context, _dbLinkType, SessionPoolType, BusinessEntitySessionParams, out IsNewSessionCreated);
                }
            }
            return _session;
        }

        /// <summary>
        /// Get company session
        /// </summary>
        /// <returns></returns>
        private IBusinessEntitySession GetCompanySession()
        {
            IBusinessEntitySession session = null;
            if (SessionPoolType == ObjectPoolType.Disable)
            {
                session = BusinessPoolManager.GetNewSession(Context, Guid.NewGuid(), DBLinkType.Company, BusinessEntitySessionParams);
                IsNewSessionCreated = true;
            }
            else
            {
                session = BusinessPoolManager.GetSession(Context, DBLinkType.Company, SessionPoolType, BusinessEntitySessionParams, out IsNewSessionCreated);
            }
            return session;
        }
        /// <summary>
        /// Get paged records based on the parameters.
        /// This method is only used to display records in grids.
        /// </summary>
        /// <typeparam name="T">Generic model input</typeparam>
        /// <param name="businessEntity">BusinessEntity</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="businessEntities">The business entities.</param>
        /// <param name="hierarchyMapper">The hierarchy mapper.</param>
        /// <param name="pageOptions">Pagination options</param>
        /// <param name="filterCount">FilterCount</param>
        /// <param name="totalCount">TotalCount</param>
        /// <param name="validator">validator function</param>
        /// <returns>
        /// List of models
        /// </returns>
        private IEnumerable<T> Get<T>(IBusinessEntity businessEntity, ModelMapper<T> mapper,
            List<IBusinessEntity> businessEntities, ModelHierarchyMapper<T> hierarchyMapper,
            PageOptions<T> pageOptions, int filterCount, int totalCount, Func<T, bool> validator)
            where T : ModelBase, new()
        {
            //There are no records
            if (filterCount == 0)
            {
                return Get(pageOptions);
            }

            var models = new List<T>();
            var startIndex = CommonUtil.ComputeStartIndex(pageOptions.PageNumber, pageOptions.PageSize);
            var endIndex = CommonUtil.ComputeEndIndex(pageOptions.PageNumber, pageOptions.PageSize, totalCount);
            var loopCounter = 1;
            bool hasNextRecord = true;

            do
            {
                var item = (businessEntities != null & hierarchyMapper != null) ?
                                MapData(hierarchyMapper, businessEntities) :
                                MapData(mapper, businessEntity);

                if (businessEntities != null)
                {
                    businessEntity = businessEntities[0];
                }

                if (validator != null)
                {
                    if (!validator(item))
                    {
                        hasNextRecord = businessEntity.Next();
                        continue;
                    }
                }

                var insertedRecord = GetInsertedRecord(pageOptions.ModifiedData, loopCounter);

                if (insertedRecord != null)
                {
                    AddModel(models, insertedRecord, startIndex, loopCounter);
                    loopCounter++;
                    continue;
                }

                if (!hasNextRecord)
                {
                    break;
                }

                var matchingRecord =
                    pageOptions.ModifiedData.FirstOrDefault(
                        data => pageOptions.GetKey(data) == pageOptions.GetKey(item) && !data.IsNewLine);

                if (matchingRecord != null)
                {
                    if (!matchingRecord.IsDeleted)
                    {
                        item = matchingRecord;
                        AddModel(models, item, startIndex, loopCounter);
                        loopCounter++;
                    }
                }
                else
                {
                    AddModel(models, item, startIndex, loopCounter);
                    loopCounter++;
                }

                hasNextRecord = businessEntity.Next();


            } while (loopCounter <= endIndex);

            return models.Take(pageOptions.PageSize).ToList();
        }

        /// <summary>
        /// Get inserted record from the list of modified records based on display index.
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="modifiedData">Modified data</param>
        /// <param name="loopCounter">The loop counter.</param>
        /// <returns>T</returns>
        private T GetInsertedRecord<T>(List<T> modifiedData, int loopCounter) where T : ModelBase
        {
            return modifiedData.SingleOrDefault(inserted => inserted.IsNewLine && inserted.DisplayIndex == loopCounter);
        }

        /// <summary>
        /// Get paginated records
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="pageOptions">Pagination Options</param>
        /// <returns>List of records</returns>
        private IEnumerable<T> Get<T>(PageOptions<T> pageOptions) where T : ModelBase
        {
            var startIndex = pageOptions.PageNumber * pageOptions.PageSize;
            return
                pageOptions.ModifiedData.OrderBy(item => item.DisplayIndex)
                    .Skip(startIndex)
                    .Take(pageOptions.PageSize)
                    .AsEnumerable();
        }

        #endregion

    }
}