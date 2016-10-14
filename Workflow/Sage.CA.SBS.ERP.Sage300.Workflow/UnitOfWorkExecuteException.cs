/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System;
using System.Runtime.Serialization;

namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// Exception used to indicate some form of unit of work failure
    /// </summary>
    [Serializable]
    public class UnitOfWorkExecuteException : Exception
    {
        /// <summary>
        /// Exception, only with message
        /// </summary>
        /// <param name="msg">user message</param>
        public UnitOfWorkExecuteException(String msg)
            : base(msg)
        { }

        /// <summary>
        /// Exception with custom message and inner exception
        /// </summary>
        /// <param name="msg">user message</param>
        /// <param name="innerException">inner exception</param>
        public UnitOfWorkExecuteException(String msg, Exception innerException)
            : base(msg, innerException)
        { }

        /// <summary>
        /// Exception with serialization info and streaming context
        /// </summary>
        /// <param name="info">serialization info</param>
        /// <param name="context">streaming context</param>
        protected UnitOfWorkExecuteException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        /// <summary>
        /// Exception with user message inner exception and unit of work Id
        /// </summary>
        /// <param name="msg">user message</param>
        /// <param name="innerException">inner exception</param>
        /// <param name="unitOfWork">unit of work</param>
        public UnitOfWorkExecuteException(String msg, Exception innerException, UnitOfWorkInstance unitOfWork)
            : base(msg, innerException)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Unit of work
        /// </summary>
        public UnitOfWorkInstance UnitOfWork { get; set; }
    }
}
