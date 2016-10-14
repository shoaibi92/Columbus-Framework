/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu
{
    /// <summary>
    /// Class to manager all Menu Module Helper, currently only manage caching
    /// </summary>
    public class MenuModuleHelperManager : IMenuModuleHelperManager
    {

        #region Public Properties

        /// <summary>
        /// To hold list of all existing menu module helper in the system
        /// </summary>
        public IEnumerable<Lazy<IMenuModuleHelper, IBootstrapMetadata>> AllModuleManagers
        {
            get;
            private set;
        }

        /// <summary>
        /// To indicate whether has third party plug in menu
        /// </summary>
        public bool HasPluginMenu { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuModuleHelperManager()
        {
            var path = HttpRuntime.BinDirectory;
            var catalog = new AggregateCatalog();
            var patterns = BootstrapTaskManager.GetSearchPattern(HttpContext.Current.Server.MapPath("~"));

            foreach (var p in patterns)
                catalog.Catalogs.Add(new DirectoryCatalog(path, p));

            // MEF container to compose implementaions
            var container = new CompositionContainer(catalog);

            AllModuleManagers =
                    container.GetExports<IMenuModuleHelper, IBootstrapMetadata>()
                        .Where(task => task.Metadata.AppliesTo.Contains(BootstrapAppliesTo.Web))
                        .OrderBy(task => task.Metadata.Order);
        }
        #endregion

        #region XML File Merging

        /// <summary>
        /// static function to merage change from master copy to comapny cache XML file
        /// </summary>
        public static void MergeMasterFileToCompanyCache(string dataSubFolder)
        {
            var xmlMenuPath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), dataSubFolder);

            var companyCacheFolders = Directory.GetDirectories(xmlMenuPath);

            try
            {
                foreach (var companyfolderName in companyCacheFolders)
                {
                    var masterMenuFilePaths = Directory.GetFiles(xmlMenuPath, "*.xml");

                    foreach (var masterMenuFilePath in masterMenuFilePaths)
                    {
                        var fileName = Path.GetFileName(masterMenuFilePath);
                        var companyCacheFilePath = string.Format(@"{0}\{1}", companyfolderName, fileName);

                        if (File.Exists(companyCacheFilePath))
                        {
                            var masterXmlDoc = new XmlDocument();
                            masterXmlDoc.Load(masterMenuFilePath);

                            var cacheXmlDoc = new XmlDocument();
                            cacheXmlDoc.Load(companyCacheFilePath);

                            MerageXMLDocument(masterXmlDoc, cacheXmlDoc);

                            // save master to cache after cache
                            masterXmlDoc.Save(companyCacheFilePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed on MergeMasterFileToCompanyCache", ex);
            }
        }

        /// <summary>
        /// Merage new XML nodes from masterXmlDoc to cacheXmlDoc
        /// </summary>
        /// <param name="masterXmlDoc">XmlDocument</param>
        /// <param name="cacheXmlDoc">XmlDocument</param>
        /// <returns>true if there is mssing item(s), false otherwise </returns>
        private static void MerageXMLDocument(XmlDocument masterXmlDoc, XmlDocument cacheXmlDoc)
        {
            var allMasterItemNodes = masterXmlDoc.SelectNodes("Navigation/item");
            var elementName = "IsActive";

            try
            {
                foreach (XmlNode masterItemNode in allMasterItemNodes)
                {
                    string menuId = masterItemNode.SelectSingleNode("MenuID").InnerText;
                    var targetItemNode = cacheXmlDoc.SelectSingleNode("descendant::item[MenuID=\"" + menuId + "\"]");
                    if (targetItemNode != null)
                    {
                        // Found matching node from cached XML file, move "IsHidden" element value to master (if found)
                        var targetIsHiddenNode = targetItemNode.SelectSingleNode(elementName);
                        if (targetIsHiddenNode != null)
                        {
                            var masterIsHiddenNode = masterItemNode.SelectSingleNode(elementName);
                            if (masterIsHiddenNode != null)
                            {
                                masterIsHiddenNode.InnerText = targetIsHiddenNode.InnerText;
                            }
                            else
                            {
                                // create the missing node in master with target value
                                var newHiddenNode = masterXmlDoc.CreateNode(XmlNodeType.Element, elementName, string.Empty);
                                newHiddenNode.InnerText = targetIsHiddenNode.InnerText;

                                masterItemNode.AppendChild(newHiddenNode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to merge XML", ex);
            }
        }

        #endregion
    }
}
