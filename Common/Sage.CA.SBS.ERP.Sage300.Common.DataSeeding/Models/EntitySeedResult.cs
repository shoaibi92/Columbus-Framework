/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Models
{
    /// <summary>
    /// Represents Entity seed results
    /// </summary>
    public class EntitySeedResult
    {
        #region Private Variables
        
        private List<string> _errors = new List<string>();

        private List<string> _messages = new List<string>();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        public EntitySeedResult(string entityName)
        {
            EntityName = entityName;
        }

        /// <summary>
        /// Entity Name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Entity seed errors
        /// </summary>
        public List<string> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        /// <summary>
        ///  Entity seed messages
        /// </summary>
        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }
    }
}
