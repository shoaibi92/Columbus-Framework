/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu
{
    /// <summary>
    /// Implementation common interface IMenuModuleHelper as base class
    /// </summary>
    public abstract class AbstractMenuModuleHelper : IMenuModuleHelper
    {
        #region private members
        /// <summary>
        /// Data sub folder name
        /// </summary>
        public static string DataSubFolder = "MenuDetail";

        /// <summary>
        /// To hold NavigableMenu for the module
        /// </summary>
        private List<NavigableMenu> _menuItems;

        #endregion

        #region abstract members
        /// <summary>
        /// Return Module specified
        /// </summary>
        public abstract string Module { get; }

        /// <summary>
        /// Return Name of the screen file
        /// </summary>
        public abstract string MenuDetailFileName { get; }

        /// <summary>
        /// Initialize the module manager
        /// </summary>
        /// <param name="company">String</param>
        /// <param name="context">Context</param>
        public abstract void Initialize(string company, Context context);

        /// <summary>
        /// Return Menu Items with activation filter applied
        /// </summary>
        /// <returns>List</returns>
        public abstract List<NavigableMenu> GetFilteredMenuItems();

        #endregion

        #region protected members

        /// <summary>
        /// Return menu items after applying input criteria
        /// </summary>
        /// <param name="filterCriteria">List of criteria</param>
        /// <returns>List</returns>
        protected List<NavigableMenu> GetApplyFilteredMenuItems(List<Func<NavigableMenu, bool>> filterCriteria)
        {
            IEnumerable<NavigableMenu> result = _menuItems;

            if (filterCriteria != null)
            {
                foreach (var filterCriterion in filterCriteria)
                {
                    result = result.Where(filterCriterion);
                }
            }

            return result.ToList();
        }

        #endregion

        #region public members

        /// <summary>
        /// Return all Menu items for the module
        /// </summary>
        /// <returns>List</returns>
        public virtual List<NavigableMenu> GetMenuItems()
        {
            return GetFilteredMenuItems();
        }

        /// <summary>
        /// Save the menuItems back to module screen file
        /// </summary>
        /// <param name="menuItems">List</param>
        /// <param name="subFolder">string of subfolder name</param>
        public void SaveMenuItems(List<NavigableMenu> menuItems, string subFolder)
        {
            // find matching NavigableMenu and update the IsActive value

            if (_menuItems != null)
            {
                var isSaveNeeded = false;
                foreach (var item in menuItems)
                {
                    var targetNavigableMenu = _menuItems.FirstOrDefault(menu => menu.MenuId == item.MenuId);

                    if (targetNavigableMenu != null)
                    {
                        isSaveNeeded = true;
                        targetNavigableMenu.IsActive = item.IsActive;
                    }
                }

                if (isSaveNeeded)
                {
                    var fileName = string.Format(@"{0}\{1}\{2}\{3}", GetDataDirectory(), DataSubFolder, subFolder, MenuDetailFileName);

                    using (var writer = XmlWriter.Create(fileName))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Navigation");

                        foreach (var menuItem in _menuItems)
                        {
                            writer.WriteStartElement("item");

                            writer.WriteElementString("MenuID", menuItem.MenuId);
                            writer.WriteElementString("MenuName", menuItem.MenuName);
                            writer.WriteElementString("ResourceKey", menuItem.ResourceKey);
                            writer.WriteElementString("ParentMenuID", menuItem.ParentMenuId);
                            if (menuItem.IsGroupHeader != null)
                                writer.WriteElementString("IsGroupHeader", menuItem.IsGroupHeader.Value.ToString());
                            writer.WriteElementString("ScreenURL", menuItem.ScreenUrl);
                            writer.WriteElementString("MenuItemLevel", menuItem.MenuItemLevel.ToString());
                            writer.WriteElementString("MenuItemOrder", menuItem.MenuItemOrder.ToString());
                            writer.WriteElementString("ColOrder", menuItem.ColOrder.ToString());

                            writer.WriteElementString("SecurityResourceKey", ProcessSecurityResourceKey(menuItem.SecurityResourceKeys));

                            writer.WriteElementString("IsReport", menuItem.IsReport.ToString());
                            writer.WriteElementString("IsActive", menuItem.IsActive.ToString());
                            writer.WriteElementString("IsGroupEnd", menuItem.IsGroupEnd.ToString());
                            writer.WriteElementString("IsWidget", menuItem.IsWidget.ToString());
                            writer.WriteElementString("Isintelligence", menuItem.Isintelligence.ToString());
                            if (!string.IsNullOrEmpty(menuItem.ModuleName))
                                writer.WriteElementString("ModuleName", menuItem.ModuleName);

                            if (menuItem.UseColGrouping)
                            {
                                writer.WriteElementString("UseColGrouping", menuItem.UseColGrouping.ToString());
                            }

                            if (menuItem.ColGrouping > 0)
                            {
                                writer.WriteElementString("ColGrouping", menuItem.ColGrouping.ToString());
                            }

                            if (menuItem.IsHidden.HasValue)
                            {
                                writer.WriteElementString("IsHidden", menuItem.IsHidden.ToString());
                            }

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
            }
        }

        /// <summary>
        /// Read and load screen file data
        /// </summary>
        /// <param name="subFolder">string of subfolder name</param>
        protected void PrepareDataFile(string subFolder)
        {
            var destinationFilePath = HandleCreateDestinationFile(subFolder);

            _menuItems = GetMenuDetails(destinationFilePath, true);

            ModuleHeader = _menuItems.FirstOrDefault(menu => menu.ParentMenuId == HeaderMenuId);
        }

        /// <summary>
        /// Return the head of the module
        /// </summary>
        public virtual NavigableMenu ModuleHeader { get; private set; }

        /// <summary>
        /// Id of Header Menu
        /// </summary>
        public virtual string HeaderMenuId
        {
            get { return "101"; }
        }

        /// <summary>
        /// Flag to indicate if optional field is enable
        /// </summary>
        public bool IsOptionalFieldEnable { get; set; }

        /// <summary>
        /// Flag for national account license
        /// </summary>
        public bool HasNationalAccountLicense { get; set; }

        /// <summary>
        /// Flag to indicate if the module is screen UI specific
        /// </summary>
        public virtual bool IsScreenUIModule
        {
            get { return true; }
        }

        /// <summary>
        /// Flag to indicate whether the menu is third part development menu
        /// </summary>
        public virtual bool IsPlugInMenu
        {
            get { return false; }
        }

        /// <summary>
        /// To hold a list of active applications
        /// </summary>
        public List<Sage.CA.SBS.ERP.Sage300.Common.Models.ActiveApplication> ActiveApplicationList { get; set; }

        /// <summary>
        /// Store current product seriese
        /// </summary>
        public ProductSeries ProductSeries { get; set; }

        #endregion

        #region private functions

        /// <summary>
        /// Create destination file and return path of destination file path (use this to help unit testing)
        /// </summary>
        /// <param name="subFolder"></param>
        /// <returns></returns>
        private string HandleCreateDestinationFile(string subFolder)
        {
            var destinationPath = string.Format(@"{0}\{1}\{2}", GetDataDirectory(), DataSubFolder, subFolder);
            var destinationFilePath = Path.Combine(destinationPath, MenuDetailFileName);

            if (!File.Exists(destinationFilePath))
            {
                var sourceFilePath = string.Format(@"{0}\{1}\{2}", GetDataDirectory(), DataSubFolder, MenuDetailFileName);
                Directory.CreateDirectory(destinationPath);
                if (File.Exists(sourceFilePath))
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                }
            }

            return destinationFilePath;
        }

        /// <summary>
        /// Return data folder (use this to help unit testing)
        /// </summary>
        /// <returns>string</returns>
        private string GetDataDirectory()
        {
            return AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        }

        /// <summary>
        /// Return string representation of security resource key
        /// </summary>
        /// <param name="securityResourceKey">Dictionary</param>
        /// <returns>string</returns>
        private string ProcessSecurityResourceKey(Dictionary<string, List<string>> securityResourceKey)
        {
            string result = Constants.NotAppplicableWord;
            
            if(securityResourceKey.ContainsKey(Constants.CommaHyphenWord))
            {
                result = string.Join(Constants.HyphenCharacter, securityResourceKey[Constants.CommaHyphenWord]);
            }
            else if (securityResourceKey.ContainsKey(Constants.CommaWord))
            {
                result = string.Join(Constants.CommaCharacter, securityResourceKey[Constants.CommaWord]);
            }
            else if (securityResourceKey.ContainsKey(Constants.HyphenWord))
            {
                result = string.Join(Constants.HyphenCharacter, securityResourceKey[Constants.HyphenWord]);
            }
            else if (securityResourceKey.ContainsKey(Constants.NoneWord))
            {
                result = securityResourceKey[Constants.NoneWord][0];
            }

            return result;
        }

        /// <summary>
        /// Gets the NavigableMenu object for Menu Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <param name="isReturnNonActiveMenu">bool</param>
        /// <returns>list of menu objects</returns>
        private List<NavigableMenu> GetMenuDetails(string fileLocation, bool isReturnNonActiveMenu)
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
                        let useColGrouping = menu.Element("UseColGrouping")
                        let colGrouping = menu.Element("ColGrouping")
                        let isHidden = menu.Element("IsHidden")
                        select new NavigableMenu
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
                            ModuleName = moduleName == null ? string.Empty : moduleName.Value,
                            UseColGrouping = useColGrouping == null ? false : Convert.ToBoolean(useColGrouping.Value),
                            ColGrouping = colGrouping == null ? 0 : Convert.ToInt32(colGrouping.Value),
                            IsHidden = isHidden == null ? (bool?)null : (bool?)Convert.ToBoolean(isHidden.Value)
                        };

            if (isReturnNonActiveMenu)
            {
                return menuItems.ToList();
            }

            // Return only active menu items
            return menuItems.Where(menu => menu.IsActive == true).ToList();
        }

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
