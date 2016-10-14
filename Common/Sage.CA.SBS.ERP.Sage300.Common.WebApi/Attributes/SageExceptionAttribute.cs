/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Net;
using System.Web.Http.Filters;
using System.Web.Http.OData.Extensions;
using Microsoft.Data.OData;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.WebApi.Attributes
{
    /// <summary>
    /// This exception filter handles Sage's customized exceptions.
    /// NOTE: ExceptionFilterAttribute is the Web API version of MVC's HandleErrorAttribute.
    /// </summary>
    public class SageExceptionAttribute : ExceptionFilterAttribute 
    {
        const HttpStatusCode TooManyRequests = (HttpStatusCode)429;

        /// <summary>
        /// Gets called when a controller method throws any unhandled exception that
        /// is NOT an HttpResponseException.
        /// </summary>
        /// <param name="executedContext">The action executed context.</param>
        public override void OnException(HttpActionExecutedContext executedContext)
        {
            Logger.Error(string.Format("An unhandled exception occured. Url='{0}'", executedContext.Request.RequestUri), executedContext.Exception);

            var baseException = executedContext.Exception.GetBaseException();
            if (baseException is SessionOverflowException)
            {
                // Return a 429 (Too Many Requests).
                // TODO: Use a better error message.
                var response = executedContext.Request.CreateErrorResponse(TooManyRequests, new ODataError
                {
                    ErrorCode = TooManyRequests.ToString(),
                    Message =
                        "Sorry, but the Web API server has been flooded with too many requests. Please try again later."
                });
                executedContext.Response = response;
            }
            else
            {
                // Return a generic 500 (Internal Server Error).
                base.OnException(executedContext);
            }
        }
    }
}
