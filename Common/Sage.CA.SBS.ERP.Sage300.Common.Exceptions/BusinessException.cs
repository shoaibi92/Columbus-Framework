/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// Class for Handling Business Validation Exception
    /// </summary>
    [Serializable]
    public class BusinessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        public BusinessException()
        {
        }

        /// <summary>
        /// Gets or sets Error List
        /// </summary>
        /// <value>The errors.</value>
        public List<EntityError> Errors { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="errorList">List of errors</param>
        public BusinessException(string message, Exception exception, List<EntityError> errorList)
            : base(message, exception)
        {
            Errors = errorList;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        public BusinessException(string message, List<EntityError> errorList)
            : base(message)
        {
            Errors = errorList;
        }
    }

    /// <summary>
    /// Class for Handling Business Validation Exception
    /// </summary>
    [Serializable]
    public class BusinessException<T> : Exception where T : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessException"/> class.
        /// </summary>
        public BusinessException()
        {
        }

        /// <summary>
        /// Gets or sets Error List
        /// </summary>
        /// <value>The errors.</value>
        public List<EntityError<T>> Errors { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="exception">Exception</param>
        /// <param name="errorList">List of errors</param>
        public BusinessException(string message, Exception exception, List<EntityError<T>> errorList)
            : base(message, exception)
        {
            Errors = errorList;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="errorList">List of errors</param>
        public BusinessException(string message, List<EntityError<T>> errorList)
            : base(message)
        {
            Errors = errorList;
        }
    }
}