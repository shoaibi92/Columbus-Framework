/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Exceptions
{
    /// <summary>
    /// Exception Helper to throw exception 
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Throws Business Exception
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        /// <param name="errors"></param>
        /// <returns>Current context business exception</returns>
        public static Exception BusinessException(Exception innerException, List<EntityError> errors)
        {
            return new BusinessException(string.Empty, innerException, errors);
        }

        /// <summary>
        /// Throws Business Exception
        /// </summary>
        /// <param name="errors">Error list</param>
        /// <returns>Current context business exception</returns>
        public static Exception BusinessException<T>(List<EntityError<T>> errors) where T : ModelBase
        {
            return new BusinessException<T>(string.Empty, errors);
        }

        /// <summary>
        /// Throws Business Exception
        /// </summary>
        /// <param name="innerException">Inner exception</param>
        /// <param name="errors">Error list</param>
        /// <returns>Current context business exception</returns>
        public static Exception BusinessException<T>(Exception innerException, List<EntityError<T>> errors) where T : ModelBase
        {
            return new BusinessException<T>(string.Empty, innerException, errors);
        }

        /// <summary>
        /// Throws Business Exception
        /// </summary>
        /// <param name="errors">Error list</param>
        /// <returns>Current context business exception</returns>
        public static Exception BusinessException(List<EntityError> errors)
        {
            return new BusinessException(string.Empty, errors);
        }

        /// <summary>
        /// Throws Security Exception
        /// </summary>
        /// <param name="errors">Error list</param>
        /// <returns>Security voilation exeception</returns>
        public static Exception SecurityException(List<EntityError> errors)
        {
            return new SecurityException(string.Empty, errors);
        }

        /// <summary>
        /// Throws row not find exception
        /// </summary>
        /// <param name="message">Custom error message to display</param>
        /// <returns>Row not find exception</returns>
        public static Exception RowNotFoundException(string message = null)
        {
            var entityErrors = new List<EntityError>
            {
                new EntityError {Message = message ?? CommonResx.UpdateFailedNoRecordMessage, Priority = Priority.Error}
            };
            throw BusinessException(entityErrors);
        }

        /// <summary>
        /// Throws not authorized exception
        /// </summary>
        /// <returns>Not authorized exception</returns>
        public static Exception NotAuthorizedException()
        {
            var entityErrors = new List<EntityError>
            {
                new EntityError {Message = CommonResx.NotAuthorizedMesage, Priority = Priority.Error}
            };
            throw SecurityException(entityErrors);
        }
    }
}