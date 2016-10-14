/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GridFilterField : ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FieldVal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRequired { get; set; }
    }
}