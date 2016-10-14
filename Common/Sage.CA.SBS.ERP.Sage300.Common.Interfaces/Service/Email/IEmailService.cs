/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using System.Threading.Tasks;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Email
{
    /// <summary>
    /// Interface IEmailService
    /// </summary>
    /// <typeparam name="T">Where type of T is EmailOption</typeparam>
    public interface IEmailService<T> : ISecurityService where T : EmailOption, new()
    {
        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="model">Model base</param>
        /// <returns>result- workFlowInstanceId</returns>
        int SendEmail(T model);
    }
}
