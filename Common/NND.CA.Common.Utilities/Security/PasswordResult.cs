// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Password Result
    /// </summary>
    public class PasswordResult
    {
        #region Public Properties
        /// <summary>
        /// Does password expire today
        /// </summary>
        public bool ExpiresToday { get; set; }

        /// <summary>
        /// Does password expire in two weeks
        /// </summary>
        public bool ExpiresTwoWeeks { get; set; }

        /// <summary>
        /// Days left before password expires
        /// </summary>
        public int DaysRemaining { get; set; }

        /// <summary>
        /// Minimum password length
        /// </summary>
        public int MinimumPasswordLength { get; set; }

        /// <summary>
        /// Password Exception
        /// </summary>
        public PasswordException PasswordException { get; set; }

        /// <summary>
        /// Password successfully changed
        /// </summary>
        public bool PasswordChanged { get; set; }
        #endregion
    }
}