#region

using System;
using System.Collections.Generic;

using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// Exception to handle security
    /// </summary>
    [Serializable]
    public class SecurityException : BusinessException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SecurityException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="errorList">List of errors</param>
        public SecurityException(string message, Exception exception, List<EntityError> errorList)
            : base(message, exception, errorList)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        public SecurityException(string message, List<EntityError> errorList) : base(message, errorList)
        {
        }
    }
}