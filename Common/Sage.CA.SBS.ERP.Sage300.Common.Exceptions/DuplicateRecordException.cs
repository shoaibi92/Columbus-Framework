using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// Duplicate Record Exception
    /// </summary>
    [Serializable]
    public class DuplicateRecordException: BusinessException
    {
         /// <summary>
        /// Constructor
        /// </summary>
        public DuplicateRecordException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="errorList">List of errors</param>
        public DuplicateRecordException(string message, Exception exception, List<EntityError> errorList)
            : base(message, exception, errorList)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        public DuplicateRecordException(string message, List<EntityError> errorList)
            : base(message, errorList)
        {
        }
    }
}
