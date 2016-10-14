/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of properties for UserMessage
    /// </summary>
    public class UserMessage
    {
        #region Constructor

        /// <summary>
        /// UserMessage
        /// </summary>
        public UserMessage()
        {
            IsSuccess = true;
            Warnings = new List<EntityError>();
        }

        /// <summary>
        /// UserMessage
        /// </summary>
        /// <param name="modelBase">ModelBase</param>
        public UserMessage(ModelBase modelBase) : this()
        {
            IsSuccess = true;

            if (modelBase != null)
            {
                if (modelBase.Warnings != null)
                {
                    InitializeVariables(modelBase.Warnings.ToList());
                }
            }
        }

        /// <summary>
        /// UserMessage
        /// </summary>
        /// <param name="modelBase">ModelBase</param>
        /// <param name="message">Message</param>
        public UserMessage(ModelBase modelBase, string message)
            : this(modelBase)
        {
            Message = message;
        }

        /// <summary>
        /// Usermessage Constructor
        /// </summary>
        /// <param name="errors">list of entityerrors</param>
        public UserMessage(List<EntityError> errors) : this()
        {
            InitializeVariables(errors);
        }

        /// <summary>
        /// Initialize all UserMessage variables
        /// </summary>
        /// <param name="errors"></param>
        private void InitializeVariables(List<EntityError> errors)
        {
            if (errors != null && errors.Any())
            {
                if (errors.Exists(err => err.Priority == Priority.Error))
                {
                    Errors = errors;
                    return;
                }
                if (errors.Exists(err => err.Priority == Priority.Warning))
                {
                    Warnings = errors;
                    return;
                }

                Info = errors;
            }
        }

        #endregion

        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Errors List
        /// </summary>
        public IEnumerable<EntityError> Errors { get; set; }

        /// <summary>
        /// Errors
        /// </summary>
        public IEnumerable<EntityError> Warnings { get; set; }

        /// <summary>
        /// Errors List
        /// </summary>
        public IEnumerable<EntityError> Info { get; set; }
    }
}