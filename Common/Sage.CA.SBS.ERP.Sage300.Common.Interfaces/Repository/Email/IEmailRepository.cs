/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Email;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Email
{
    /// <summary>
    /// interface IEmailRepository
    /// </summary>
    /// <typeparam name="T">Where type of T is EmailOption</typeparam>
    public interface IEmailRepository<T> : ISecurity, IRepository, IDisposable where T : EmailOption
    {

        /// <summary>
        /// Send Email 
        /// </summary>
        /// <param name="model">Object contains email details</param>
        /// <returns>Email sent successfully or failed message</returns>
        EmailResponse SendEmail(T model);

    }
}
