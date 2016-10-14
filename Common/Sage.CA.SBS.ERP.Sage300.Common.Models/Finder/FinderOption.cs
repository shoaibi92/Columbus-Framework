/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Finder
{
    /// <summary>
    /// Class to include all the options related to finder, like page number, filters etc.
    /// </summary>
    public class FinderOption
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FinderOption()
        {
            AdvancedFilter = new List<IList<Filter>>();
            ColumnPreferences = new List<GridColumn>();
        }

        /// <summary>
        /// Name of the finder
        /// </summary>
        public string SearchFinder { get; set; }

        /// <summary>
        /// Current Page Number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page Size of the finder grid
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// True if sort is by ascending order
        /// TODO: This needs to be renamed to SortDesc
        /// </summary>
        public bool SortAsc { get; set; }

        /// <summary>
        /// Simple Filter 
        /// </summary>
        public Filter SimpleFilter { get; set; }

        /// <summary>
        /// True if user preferences needs to be deleted else false.
        /// </summary>
        public bool CanDeletePreferences { get; set; }

        /// <summary>
        /// True if user preferences needs to be saved else false.
        /// </summary>
        public bool CanSavePreferences { get; set; }

        /// <summary>
        /// List of columns selected by user
        /// </summary>
        public List<GridColumn> ColumnPreferences { get; set; }

        /// <summary>
        /// Advanced filter
        /// </summary>
        public IList<IList<Filter>> AdvancedFilter { get; set; }
    }
}