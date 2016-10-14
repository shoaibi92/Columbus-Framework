using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// Duplicate Record Exception
    /// </summary>
    [Serializable]
    public class TransactionFailedException<T>: BusinessException
    {
         /// <summary>
        /// Constructor
        /// </summary>
        public TransactionFailedException()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="errorList">List of errors</param>
        public TransactionFailedException(string message, Exception exception, List<EntityError> errorList)
            : base(message, exception, errorList)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        public TransactionFailedException(string message, List<EntityError> errorList)
            : base(message, errorList)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        /// <param name="savedModel">List of errors</param>
        public TransactionFailedException(string message, List<EntityError> errorList, IEnumerable<T> savedModel)
            : base(message, errorList)
        {
            Items = savedModel;
        }

        /// <summary>
        /// Gets or sets Error List
        /// </summary>
        /// <value>The errors.</value>
        public IEnumerable<T> Items { get; private set; }
    }
}
