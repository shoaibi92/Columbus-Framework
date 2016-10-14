/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Business Entity field details
    /// </summary>
    public class BusinessEntityField : ModelBase
    {
        /// <summary>
        /// default constructor - set print to true
        /// </summary>
        public BusinessEntityField()
        {
            print = true;
        }

        /// <summary>
        /// Property
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// print
        /// </summary>
        public bool print { get; set; }

        /// <summary>
        /// Database column name
        /// Only for internal purpose
        /// </summary>
        public string columnName { get; set; }

        /// <summary>
        /// Database column Id
        /// Only for internal purpose
        /// </summary>
        public int columnId { get; set; }

        /// <summary>
        /// dataType of the field
        /// </summary>
        public string dataType { get; set; }

        /// <summary>
        /// Trie if field is key else false
        /// </summary>
        public bool IsKey { get; set; }
    }
}