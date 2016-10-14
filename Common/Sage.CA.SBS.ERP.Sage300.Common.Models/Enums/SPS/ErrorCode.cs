// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.SPS
{
    /// <summary>
    /// Enum for ErrorCode
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Gets or sets SUCCESS
        /// </summary>
        Success = 0,

        /// <summary>
        /// Gets or sets INVALID_REQUEST_DATA
        /// </summary>
        Invalid_Request_Data = 1,

        /// <summary>
        /// Gets or sets COMMUNICATION_STARTUP_ERROR
        /// </summary>
        Communication_Startup_Error = 2,

        /// <summary>
        /// Gets or sets COMMUNICATION_ERROR
        /// </summary>
        Communication_Error = 3,

        /// <summary>
        /// Gets or sets MODULE_CONFIGURATION_NOT_FOUND
        /// </summary>
        Module_Configuration_Not_Found = 4,

        /// <summary>
        /// Gets or sets COMMUNICATION_RECOVERY_ERROR
        /// </summary>
        Communication_Recovery_Error = 5,

        /// <summary>
        /// Gets or sets USER_CANCELED
        /// </summary>
        User_Canceled = 6,

        /// <summary>
        /// Gets or sets TIME_OUT
        /// </summary>
        Time_Out = 7,

        /// <summary>
        /// Gets or sets INTERNET_CONNECTION_ERROR
        /// </summary>
        Internet_Connection_Error = 8,

        /// <summary>
        /// Gets or sets UNKNOWN_ERROR
        /// </summary>
        Unknown_Error = 9
    }
}