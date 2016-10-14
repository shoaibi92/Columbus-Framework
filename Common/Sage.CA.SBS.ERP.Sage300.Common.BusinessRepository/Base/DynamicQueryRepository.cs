/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base
{
    /// <summary>
    /// Dynamic Query Repository
    /// </summary>
    /// <typeparam name="T">Model for repository</typeparam>
    public abstract class DynamicQueryRepository<T> : BaseRepository, IDynamicQueryRepository<T>, ISecurity
        where T : ApplicationModelBase, new()
    {
        #region Protected Region
        /// <summary>
        /// Map
        /// </summary>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        protected abstract DynamicQueryEnumerableResponse<T> Map();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        protected DynamicQueryRepository(Context context)
            : this(context, DBLinkType.Company)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        protected DynamicQueryRepository(Context context, DBLinkType dbLinkType)
            : base(context, dbLinkType)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        protected DynamicQueryRepository(Context context, IBusinessEntitySession session)
            : this(context, DBLinkType.Company, session, ObjectPoolType.Default)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DB Link type</param>
        /// <param name="session">Session</param>
        /// <param name="sessionPoolType">SessionPoolType</param>
        protected DynamicQueryRepository(Context context, DBLinkType dbLinkType,
            IBusinessEntitySession session, ObjectPoolType sessionPoolType)
            : base(context, dbLinkType, session, sessionPoolType, new BusinessEntitySessionParams())
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Business Entity
        /// </summary>
        public virtual IBusinessEntity BusinessEntity { get; set; }

        #endregion

        #region Public methods
        /// <summary>
        /// Execute T-SQL Query
        /// </summary>
        /// <param name="id">ID in resource for T-SQL Query</param>
        /// <param name="args">Arguments for T-SQL Query, if any</param>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        public DynamicQueryEnumerableResponse<T> Execute(string id, params object[] args)
        {
            // Retrieve T-SQL Query from resource file, validate and do token replacement
            var validSql = ValidSql(DynamicQueryResx.ResourceManager.GetString(id), id, args);
            return Execute(validSql);
        }

        /// <summary>
        /// Execute T-SQL Query
        /// </summary>
        /// <param name="sql">Sql statement string</param>
        /// <param name="args">Arguments for T-SQL Query, if any</param>
        /// <returns></returns>
        public DynamicQueryEnumerableResponse<T> ExecuteSQL(string sql, params object[] args)
        {
            var validSql = ValidSql(sql, string.Empty, args);
            return Execute(validSql);
        }

        #endregion

        #region Security Method
        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public virtual UserAccess GetAccessRights()
        {
            BusinessEntity = OpenEntity("CS0120");
            return GetAccessRights(BusinessEntity);
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Execute Sql query to Return Dynamic Query Enumerable Response
        /// </summary>
        /// <param name="sql">Valid Sql Query</param>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        private DynamicQueryEnumerableResponse<T> Execute(string sql)
        {
            // Ensure inquiry rights are enabled (also will create the business entity)
            CheckRights(GetAccessRights(), SecurityType.Inquire);
            // Issue the query and refresh the view's metadata
            BusinessEntity.Browse(sql, true);
            BusinessEntity.RefreshMetaData();
            return AbstractMap();
        }
        /// <summary>
        /// Map the data
        /// </summary>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        private DynamicQueryEnumerableResponse<T> AbstractMap()
        {
            return Map();
        }

        /// <summary>
        /// Validate SQL for SQL injection and return parameterzied query
        /// </summary>
        /// <param name="sql">T-SQL Query</param>
        /// <param name="id">ID in resource for T-SQL Query</param>
        /// <param name="args">Arguments for T-SQL Query, if any</param>
        /// <returns>Parameterized query</returns>
        private string ValidSql(string sql, string id, params object[] args)
        {
            // Has a sql query been found?
            if (string.IsNullOrEmpty(sql))
            {
                var entityErrors = new List<EntityError>
                {
                    new EntityError {Message = string.Format(CommonResx.RecordNotFoundMessage, CommonResx.DynamicQuery, id), 
                        Priority = Priority.Error}
                };
                throw ExceptionHelper.SecurityException(entityErrors);
            }

            // Iterate arguments, if any
            for (var i = 0; i < args.Length; i++)
            {
                // Only care about string types
                if (args[i].GetType().Name.Equals("String"))
                {
                    var arg = args[i].ToString().ToUpper();
                    // Must not contain SQL injection potentials
                    if (arg.Contains("SELECT ") || arg.Contains("DELETE ") || arg.Contains("UPDATE ") || arg.Contains("INSERT ") ||
                        arg.Contains("DROP ") || arg.Contains("ALTER ") || arg.Contains("'") || arg.Contains(" OR ") ||
                        arg.Contains("#") || arg.Contains("--") || arg.Contains(";") || arg.Contains("UNION "))
                    {
                        var entityErrors = new List<EntityError>
                        {
                            new EntityError {Message = CommonResx.SqlInjectionMessage, Priority = Priority.Error}
                        };
                        throw ExceptionHelper.SecurityException(entityErrors);
                    }
                }
            }

            return string.Format(sql, args);
        }

        #endregion
    }
}