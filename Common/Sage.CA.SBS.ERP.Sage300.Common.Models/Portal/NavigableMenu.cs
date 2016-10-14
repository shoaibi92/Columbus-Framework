/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Portal
{
    /// <summary>
    /// Contains list of properties for Navigable Menu
    /// </summary>
    public class NavigableMenu : ModelBase
    {
        /// <summary>
        /// Gets or sets MenuId 
        /// </summary>
        public string MenuId { get; set; }

        /// <summary>
        /// Gets or sets MenuName 
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// Gets or sets the module name
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets ResourceKey 
        /// </summary>
        public string ResourceKey { get; set; }

        /// <summary>
        /// Gets or sets ParentMenuId 
        /// </summary>
        public string ParentMenuId { get; set; }

        /// <summary>
        /// Gets or sets IsGroupHeader 
        /// </summary>
        public bool? IsGroupHeader { get; set; }

        /// <summary>
        /// Gets or sets ScreenUrl 
        /// </summary>
        public string ScreenUrl { get; set; }

        /// <summary>
        /// Gets or sets MenuItemLevel 
        /// </summary>
        public int? MenuItemLevel { get; set; }

        /// <summary>
        /// Gets or sets ItemOrder 
        /// </summary>
        public int? MenuItemOrder { get; set; }

        /// <summary>
        /// Gets or sets SecurityResourceKeys
        /// </summary>
        public Dictionary<string, List<string>> SecurityResourceKeys { get; set; }

        /// <summary>
        /// Gets or sets IsReport 
        /// </summary>
        public bool? IsReport { get; set; }

        /// <summary>
        /// Gets or sets IsActive 
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets IsGroupEnd 
        /// </summary>
        public bool? IsGroupEnd { get; set; }

        /// <summary>
        /// Gets or sets IsWidget
        /// </summary>
        public bool? IsWidget { get; set; }

        /// <summary>
        /// Gets or sets ColOrder
        /// </summary>
        public int? ColOrder { get; set; }

        /// <summary>
        /// Gets or sets Isintelligence
        /// </summary>
        public bool? Isintelligence { get; set; }

        /// <summary>
        /// Gets or sets WidgetId
        /// </summary>
        public string WidgetId { get; set; }

        /// <summary>
        /// Gets or sets Rank
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets IsConfigurable
        /// </summary>
        public bool? IsConfigurable { get; set; }

        /// <summary>
        /// Flag to if this sub menu need column customization or not
        /// </summary>
        public bool UseColGrouping { get; set; }

        /// <summary>
        /// Combine with UseColGrouping to indicate which column this item belongs to
        /// </summary>
        public int ColGrouping { get; set; }

        /// <summary>
        /// Flag to tell if the screen should be hidden permanently
        /// </summary>
        public bool? IsHidden { get; set; }

    }
}
