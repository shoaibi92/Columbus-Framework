/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Portal
{
    /// <summary>
    /// Class HelpRepository For XML Based Menu Help.
    /// </summary>
    /// <typeparam name="T">MenuHelp</typeparam>
    public class HelpRepository<T> : IHelpEntity<T> where T : MenuHelp, new()
    {
        #region Public Methods

        /// <summary>
        /// Gets the MenuHelp object for Menu Help Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns>list of help objects</returns>
        public List<T> GetMenuHelp(string fileLocation)
        {
            // Read the XML file
            var menuHelpData = ReadMenuHelpFile(fileLocation);

            // Read the xml elements into MenuHelp object
            var menuList = from menuItems in menuHelpData.Descendants("item")
                           let screenMenuId = menuItems.Element("ScreenMenuID")
                           where screenMenuId != null
                           select new T
                           {
                               ScreenMenuId = screenMenuId.Value,
                               ScreenHelps = new List<Help>(from helps in menuItems.Descendants("Help")
                                                            let cshId = helps.Element("CSHID")
                                                            where cshId != null
                                                            let resourceKey = helps.Element("ResourceKey")
                                                            where resourceKey != null
                                                            select new Help
                                                            {
                                                                CshId = cshId.Value,
                                                                ResourceKey = resourceKey.Value
                                                            })

                           };

            return menuList.ToList();
        }

        /// <summary>
        /// Dispose any items that are disposable
        /// </summary>
        public void Dispose()
        {
            // Nothing to dispose;  its idisposable because base entity is idisposable
        }

        #endregion

        #region Private Method

        /// <summary>
        ///  Read the XML based on configuration path
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns>MenuHelp</returns>
        private XDocument ReadMenuHelpFile(string fileLocation)
        {
            // Load the xml document
            var menuHelpData = XDocument.Load(fileLocation);
            return menuHelpData;
        }

        #endregion
    }
}
