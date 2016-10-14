/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class PivotColumnModelBase.
    /// </summary>
    public class PivotColumnModelBase : ModelBase
    {
        /// <summary>
        /// Gets the start index.
        /// </summary>
        /// <value>The start index.</value>
        public int StartIndex { get; private set; }

        /// <summary>
        /// Gets the end index.
        /// </summary>
        /// <value>The end index.</value>
        public int EndIndex { get; private set; }

        /// <summary>
        /// Gets the column names format.
        /// </summary>
        /// <value>The column names format.</value>
        public string[] ColumnNamesFormat { get; private set; }

        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>
        /// <value>The index of the column.</value>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PivotColumnModelBase"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="columnNamesFormat">The column names format.</param>
        public PivotColumnModelBase(int start, int end, string[] columnNamesFormat)
        {
            StartIndex = start;
            EndIndex = end;
            ColumnNamesFormat = columnNamesFormat;
        }
    }
}