// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit
{
    /// <summary>
    ///  Interface for database auditing
    /// </summary>
    public interface IDatabaseAudit
    {
        /// <summary> Event date </summary>
        /// <remarks> DateUtil.GetUtcNowDate() </remarks>
        DateTime EventDate { get; set; }

        /// <summary> Event type </summary>
        /// <remarks> Set by logger of event </remarks>
        string EventType { get; set; }

        /// <summary> Tenant id </summary>
        /// <remarks> Get from Context.TenantId </remarks>
        Guid TenantId { get; set; }

        /// <summary> Product user id </summary>
        /// <remarks> Get from Context.ProductUserId </remarks>
        Guid ProductUserId { get; set; }

        /// <summary> User id </summary>
        /// <remarks> Get from Context.ApplicationUserId </remarks>
        string UserId { get; set; }

        /// <summary> True if user is an administrator otherwise false </summary>
        /// <remarks> Get from BusinessEntitySession.IsAdmin </remarks>
        bool IsAdmin { get; set; }

        /// <summary> Company </summary>
        /// <remarks> Get from Context.Company </remarks>
        string Company { get; set; }

        /// <summary> Language (locale) </summary>
        /// <remarks> Get from Context.Language </remarks>
        string Language { get; set; }

        /// <summary> Session date </summary>
        /// <remarks> Get from BusinessEntitySession.SessionDate </remarks>
        DateTime SessionDate { get; set; }

        /// <summary> Session id </summary>
        /// <remarks> Get from Context.SessionId </remarks>
        string SessionId { get; set; }

        /// <summary> Screen Name </summary>
        /// <remarks> Get from Context.ScreenContext.ScreenName </remarks>
        string ScreenName { get; set; }

        /// <summary> Repository name </summary>
        /// <remarks> Get from BusinessEntity.CreatedRepositoryName </remarks>
        string RepositoryName { get; set; }

        /// <summary> View name </summary>
        /// <remarks> Get from BusinessEntity.Name </remarks>
        string ViewName { get; set; }
    }
}
