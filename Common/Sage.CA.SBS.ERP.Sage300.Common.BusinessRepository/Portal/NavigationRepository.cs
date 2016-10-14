/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Portal
{
    /// <summary>
    /// Reads XML Based navigation base structure
    /// </summary>
    /// <typeparam name="T">NavigableMenu</typeparam>
    public class NavigationRepository<T> : INavigationEntity<T> where T : NavigableMenu, new()
    {
        #region Public Methods

        /// <summary>
        /// Gets the NavigableMenu object for Menu Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <param name="isReturnNonActiveMenu">bool</param>
        /// <returns>list of menu objects</returns>
        public List<T> GetMenuDetails(string fileLocation, bool isReturnNonActiveMenu)
        {
            //List of raw menu items
            var menuXmlDocument = ReadMenuXmlFile(fileLocation);

            // Prepare Navigable menu object
            var menuItems =
                        from menu in menuXmlDocument.Descendants("item")
                        let isWidget = menu.Element("IsWidget")
                        let isIntelligence = menu.Element("Isintelligence")
                        let isGroupEnd = menu.Element("IsGroupEnd")
                        let isActive = menu.Element("IsActive")
                        let isReport = menu.Element("IsReport")
                        let isGroupHeader = menu.Element("IsGroupHeader")
                        let menuId = menu.Element("MenuID")
                        where menuId != null

                        let moduleName = menu.Element("ModuleName")

                        let menuName = menu.Element("MenuName")
                        where menuName != null
                        let resourceKey = menu.Element("ResourceKey")
                        where resourceKey != null
                        let parentMenuId = menu.Element("ParentMenuID")
                        where parentMenuId != null
                        let screenUrl = menu.Element("ScreenURL")
                        where screenUrl != null
                        let menuItemLevel = menu.Element("MenuItemLevel")
                        where menuItemLevel != null
                        let menuItemOrder = menu.Element("MenuItemOrder")
                        where menuItemOrder != null
                        let securityResourceKey = menu.Element("SecurityResourceKey")
                        where securityResourceKey != null
                        let colOrder = menu.Element("ColOrder")
                        where colOrder != null
                        let widgetId = menu.Element("WidgetId")
                        let rank = menu.Element("Rank")
                        let isConfigurable = menu.Element("IsConfigurable")
                        select new T
                        {
                            MenuId = menuId.Value,
                            MenuName = menuName.Value,
                            ResourceKey = resourceKey.Value,
                            ParentMenuId = parentMenuId.Value,
                            IsGroupHeader = isGroupHeader != null && Convert.ToBoolean(isGroupHeader.Value),
                            ScreenUrl = screenUrl.Value,
                            MenuItemLevel = Convert.ToInt32(menuItemLevel.Value),
                            MenuItemOrder = Convert.ToInt32(menuItemOrder.Value),
                            SecurityResourceKeys = ProcessSecurityCheckList(securityResourceKey.Value),
                            IsReport = isReport != null && Convert.ToBoolean(isReport.Value),
                            IsActive = isActive != null && Convert.ToBoolean(isActive.Value),
                            IsGroupEnd = isGroupEnd != null && Convert.ToBoolean(isGroupEnd.Value),
                            IsWidget = isWidget != null && Convert.ToBoolean(isWidget.Value),
                            ColOrder = Convert.ToInt32(colOrder.Value),
                            Isintelligence = isIntelligence != null && Convert.ToBoolean(isIntelligence.Value),
                            WidgetId = widgetId == null ? string.Empty : widgetId.Value,
                            Rank = rank == null ? string.Empty : rank.Value,
                            IsConfigurable = isConfigurable != null && Convert.ToBoolean(isConfigurable.Value),
                            ModuleName = moduleName == null ? string.Empty : moduleName.Value
                        };

            if (isReturnNonActiveMenu)
            {
                return menuItems.ToList();
            }
            else
            {
                // Return only active menu items
                return menuItems.Where(menu => menu.IsActive == true).ToList();
            }
            
        }

        /// <summary>
        /// Dispose any items that are disposable
        /// </summary>
        public void Dispose()
        {
            // Nothing to dispose;  its idisposable because base entity is idisposable
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Processes security key lists - single value, comma seperated and hyphen seperated
        /// </summary>
        /// <param name="securityResourceKey">string security keys</param>
        /// <returns>list of security key list</returns>
        private Dictionary<string, List<string>> ProcessSecurityCheckList(string securityResourceKey)
        {
            var securityKeyList = new Dictionary<string, List<string>>();

            if (!string.IsNullOrEmpty(securityResourceKey) && securityResourceKey != Constants.NotAppplicableWord)
            {
                if (securityResourceKey.Contains(Constants.CommaCharacter) && securityResourceKey.Contains(Constants.HyphenCharacter))
                {
                    // combined case with mix of comma(and) and hyphen(or)
                    // Note: Constants.HyphenCharacter is a lie, it really is a string
                    var commaHyphenList = new List<string>();
                    commaHyphenList.AddRange(securityResourceKey.Split(new[] { Constants.HyphenCharacter }, StringSplitOptions.RemoveEmptyEntries));
                    securityKeyList.Add(Constants.CommaHyphenWord, commaHyphenList);
                }
                else if (securityResourceKey.Contains(Constants.CommaCharacter))
                {
                    // Both security keys needs to exist
                    var commaList = new List<string>();
                    commaList.AddRange(securityResourceKey.Split(new[] { Constants.CommaCharacter }, StringSplitOptions.RemoveEmptyEntries));
                    securityKeyList.Add(Constants.CommaWord, commaList);
                }
                else if (securityResourceKey.Contains(Constants.HyphenCharacter))
                {
                    // Either one of the list of items needs to exist
                    var hyphenList = new List<string>();
                    hyphenList.AddRange(securityResourceKey.Split(new[] { Constants.HyphenCharacter }, StringSplitOptions.RemoveEmptyEntries));
                    securityKeyList.Add(Constants.HyphenWord, hyphenList);
                }
                else
                {
                    // single item without hyphen or comma seperated
                    var noneList = new List<string>();
                    noneList.Add(securityResourceKey);
                    securityKeyList.Add(Constants.NoneWord, noneList);
                }
            }

            return securityKeyList;
        }

        /// <summary>
        ///  Read XML documnet from the configured location
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns>NavigableMenu</returns>
        private XDocument ReadMenuXmlFile(string fileLocation)
        {
            var menuXmlDocument = XDocument.Load(fileLocation);
            return menuXmlDocument;
        }

        #endregion
    }
}