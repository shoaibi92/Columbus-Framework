﻿// Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard
{
    /// <summary>
    /// Static class to assist with class generation
    /// </summary>
    public static class BusinessViewHelper
    {
        #region Private Constants

        private const string TabTwo = "\t\t";
        private const string TabThree = "\t\t\t";
        private const string TabFour = "\t\t\t\t";

        #endregion

        #region Public Methods

        /// <summary>
        /// Register types for service/repository
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        public static void UpdateFlatBootStrappers(BusinessView view, Settings settings)
        {
            UpdateWebBootStrapper(view, settings);
            UpdateBootStrapper(view, settings);
        }

        /// <summary>
        /// Update Flat Bundles
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        public static void UpdateFlatBundles(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var projectInfoWeb = settings.Projects[ProcessGeneration.WebKey][moduleId];
            var pathProj = projectInfoWeb.ProjectFolder;
            var bundleFile = Path.Combine(pathProj, "BundleRegistration.cs");
            var scriptBase = projectInfoWeb.ProjectName.Replace(".Web", string.Empty);

            const string tag = "internal static void RegisterBundles(BundleCollection bundles)";
            //var textlineToAdded = string.Format("\t\t\tbundles.Add(new ScriptBundle(\"~/bundles/{0}\").Include(\r\n" +
            //                                    "\t\t\t// TODO: uncomment and possibly correct the following line once you have some screen specific JavaScript.\r\n" +
            //                                    "\t\t\t/* \"~/Areas/PM/Scripts/PMCostType/Sage.CostTypeBehaviour.js\", */\r\n" +
            //                                    "\t\t\t\"~/Areas/Core/Scripts/Process/Sage.CA.SBS.Sage300.Common.Process.js\"));\r\n", viewName);
            var textlineToAdded = string.Format(TabThree + @"#region {0}" + "\r\n" +
                                                TabThree + @"bundles.Add(new ScriptBundle(""~/bundles/{0}"").Include(" + "\r\n" +
                                                TabFour + @"""~/Areas/{1}/Scripts/{0}/{2}{0}Behaviour.js""," + "\r\n" +
                                                TabFour + @"""~/Areas/{1}/Scripts/{0}/{2}{0}KoExtn.js""," + "\r\n" +
                                                TabFour + @"""~/Areas/{1}/Scripts/{0}/{2}{0}Repository.js""," + "\r\n" +
                                                TabFour + @"""~/Areas/Core/Scripts/Process/Sage.CA.SBS.Sage300.Common.Process.js""));" + "\r\n" +
                                                TabThree + @"#endregion" + "\r\n", entityName, moduleId, scriptBase);

            if (File.Exists(bundleFile))
            {
                var txtLines = File.ReadAllLines(bundleFile).ToList();
                var trimLines = (File.ReadAllLines(bundleFile)).Select(l => l.Trim()).ToList();
                var index = trimLines.IndexOf(tag);
                if (index > -1)
                {
                    var pos = index + 2;
                    txtLines.Insert(pos, textlineToAdded);
                }
                File.WriteAllLines(bundleFile, txtLines);
            }
        }

        /// <summary>
        /// Update Flat View Page URL
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        public static void CreateFlatViewPageUrl(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var pathProj = settings.Projects[ProcessGeneration.WebKey][moduleId].ProjectFolder;
            var pageUrlFile = Path.Combine(pathProj, "pageUrl.txt");
            var pageUrl = "/OnPremise/" + moduleId + "/" + entityName;

            if (File.Exists(pageUrlFile))
            {
                File.Delete(pageUrlFile);
            }
            File.AppendAllLines(pageUrlFile, new[] { pageUrl });

        }

        /// <summary>
        /// Concat strings using Path object
        /// </summary>
        /// <param name="values">values to concatenate</param>
        /// <param name="changeToDot">True to replace separaor with dot (namespaces)</param>
        /// <returns>Concatenated string</returns>
        public static string ConcatStrings(IEnumerable<string> values, bool changeToDot = false)
        {
            // Locals
            var retVal = values.Aggregate(string.Empty, Path.Combine);

            // Trim any begining slash
            if (retVal.StartsWith(@"\"))
            {
                retVal = retVal.Substring(1);
            }

            // Replace seperator with dot?
            if (changeToDot)
            {
                retVal = retVal.Replace(@"\", ".");
            }

            return retVal;
        }

        /// <summary>
        /// Modify module level security const string class to add view security resource ID
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        public static void UpdateSecurityClass(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var pathBusinessRepository = settings.Projects[ProcessGeneration.BusinessRepositoryKey][moduleId].ProjectFolder;
            var filePath = Path.Combine(pathBusinessRepository, @"Security\Security.cs");
            var f = Environment.NewLine + TabTwo;
            var commentLine = f + "/// <summary>" + f + "/// Security resourceID for " + moduleId + " " + entityName + f + "/// </summary>" + Environment.NewLine;
            var constName = moduleId + entityName;
            var constLine = f + "public const string " + constName + " = \"" + constName.ToUpper() + "\";" + Environment.NewLine;

            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);
                var pos = text.IndexOf('}');
                if (pos > -1)
                {
                    var updateText = text.Substring(0, pos) + commentLine + constLine + text.Substring(pos - 2);
                    File.WriteAllText(filePath, updateText);
                }
            }
        }

        /// <summary>
        /// Helper method that removes and replaces unwanted characters
        /// </summary>
        /// <param name="value">Input string</param>
        /// <returns>Replaced string</returns>
        public static string Replace(string value)
        {
            return Replace(value, string.Empty);
        }

        /// <summary>
        /// Helper method that removes and replaces unwanted characters
        /// </summary>
        /// <param name="value">Input string</param>
        /// <param name="prefix">Prefix string</param>
        /// <returns>Replaced string</returns>
        public static string Replace(string value, string prefix)
        {
            if (value == string.Empty)
            {
                return string.Empty;
            }
            var newString = value
                .Replace(" to ", "To")
                .Replace(" from ", "From")
                .Replace(" for ", "For")
                .Replace(" and ", "And")
                .Replace(" is ", "Is")
                .Replace(" in ", "In")
                .Replace(" of ", "Of")
                .Replace(" ", "")
                .Replace("/", "")
                .Replace(@"\", "")
                .Replace("*", "")
                .Replace("#", "")
                .Replace("-", "")
                .Replace(".", "")
                .Replace("'", "")
                .Replace(":", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("!", "")
                .Replace("?", "")
                .Replace("&", "");

            if (newString.Length > 0)
            {
                var num = newString.ToArray()[0];
                if (Char.IsNumber(num))
                {
                    newString = "Num" + newString;
                }

                // Special prefix check
                if (newString.Equals("Type"))
                {
                    newString = prefix + newString;
                }
            }

            return newString;
        }

        /// <summary>
        /// Get the pural name for the entered value
        /// </summary>
        /// <param name="name">Name to be made plural</param>
        /// <returns>Plural name</returns>
        public static string PluralName(string name)
        {
            var pluralName = name;
            var lastSecond = name.ElementAt(name.Length - 2);

            // If already plural (best guess), then do nothing
            if (name.EndsWith("s"))
            {
                // Do nothing since it is already plural
            }
            else if (name.EndsWith("x") || name.EndsWith("z")
                || name.EndsWith("ch") || name.EndsWith("sh"))
            {
                pluralName = name + "es";
            }
            else if (name.EndsWith("y") &&
                (lastSecond != 'a' && lastSecond != 'e' && lastSecond != 'i' &&
                lastSecond != 'o' && lastSecond != 'u'))
            {
                pluralName = name.Substring(0, name.Length - 1) + "ies";
            }
            else if (!name.EndsWith("s"))
            {
                pluralName = name + "s";
            }

            return pluralName;
        }

        /// <summary>
        /// Update the Plugin Menu Details
        /// </summary>
        /// <param name="view"></param>
        /// <param name="settings"></param>
        public static void UpdateMenuDetails(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var pathProj = settings.Projects[ProcessGeneration.WebKey][moduleId].ProjectFolder;
            var menuFile = Path.Combine(pathProj, moduleId + "MenuDetails.xml");
            var xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.LoadXml(File.ReadAllText(menuFile));
                var root = xmlDoc.DocumentElement;
                if (root != null)
                {
                    var itemNodes = root.SelectNodes("item");
                    if (itemNodes != null)
                    {
                        var lastItemNode = itemNodes[itemNodes.Count - 1];
                        var itemNode = lastItemNode.Clone();

                        var node = itemNode.SelectSingleNode("MenuID");
                        var name = node.InnerText;
                        var updateName = name.Substring(0, 2) + (int.Parse(name.Substring(2)) + 1);
                        var key = moduleId + entityName;

                        node.InnerText = updateName;
                        node = itemNode.SelectSingleNode("MenuName");
                        node.InnerText = updateName;
                        node = itemNode.SelectSingleNode("ResourceKey");
                        node.InnerText = key;
                        node = itemNode.SelectSingleNode("IsGroupHeader");
                        node.InnerText = "false";
                        node = itemNode.SelectSingleNode("ScreenURL");
                        node.InnerText = moduleId + "/" + entityName;
                        node = itemNode.SelectSingleNode("MenuItemOrder");
                        node.InnerText = (int.Parse(node.InnerText) + 1).ToString();
                        node = itemNode.SelectSingleNode("SecurityResourceKey");
                        node.InnerText = key;

                        root.InsertAfter(itemNode, lastItemNode);
                    }
                }
                xmlDoc.Save(menuFile);
            }
            catch (Exception)
            {
                // do nothing, not throw exception to break application
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Register types for controller/Finder/ImportExport
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        private static void UpdateWebBootStrapper(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var pathProj = settings.Projects[ProcessGeneration.WebKey][moduleId].ProjectFolder;

            var webProjNs = settings.Projects[ProcessGeneration.WebKey][moduleId].ProjectName;
            var modelProjNs = settings.Projects[ProcessGeneration.ModelsKey][moduleId].ProjectName;

            var bsName = moduleId + "WebBootstrapper.cs";
            var bsFile = Path.Combine(pathProj, bsName);
            if (File.Exists(bsFile))
            {
                const string register = "\t\t\tUnityUtil.RegisterType";
                var trimLines = (File.ReadAllLines(bsFile)).Select(l => l.Trim()).ToList();
                var txtLines = File.ReadAllLines(bsFile).ToList();
                var pos = 1;

                string[] nameSpace =
                {
                    "using " + modelProjNs + ";" ,
                    "using " + webProjNs + ".Areas." + moduleId + ".Controllers;",
                    "using " + webProjNs + ".Areas." + moduleId + ".Controllers.Finder;"
                };

                for (var i = 0; i <= 2; i++)
                {
                    if (trimLines.IndexOf(nameSpace[i]) < 0)
                    {
                        txtLines.Insert(++pos, nameSpace[i]);
                    }
                }

                string[] tags =
                {
                    @"private void RegisterController(IUnityContainer container)",
                    @"private void RegisterFinder(IUnityContainer container)",
                    @"private void RegisterExportImportController(IUnityContainer container)"
                };
                string[] linesToAdded =
                {
                    string.Format(register + "<IController, {0}Controller<{0}>>(container, \"{1}{0}\");", entityName, moduleId),
                    string.Format(register + "<IFinder, Find{0}ControllerInternal<{0}>>(container, \"{1}{2}\", new InjectionConstructor(typeof(Context)));", entityName, moduleId.ToLower(), entityName.ToLower()),
                    string.Format(register + "<IExportImportController, {0}ControllerInternal<{0}>>(container, \"{1}{2}\", new InjectionConstructor(typeof(Context)));",entityName, moduleId.ToLower(), entityName.ToLower())
                };

                for (var i = 0; i <= 2; i++)
                {
                    if (!settings.GenerateFinder && i == 1)
                    {
                        pos--;
                        continue;
                    }
                    var index = trimLines.IndexOf(tags[i]) + 1 + i + pos;
                    txtLines.Insert(index, linesToAdded[i]);
                }
                File.WriteAllLines(bsFile, txtLines);
            }
        }

        /// <summary>
        /// Register types for service/repository
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="settings">Settings</param>
        private static void UpdateBootStrapper(BusinessView view, Settings settings)
        {
            var moduleId = view.Properties[BusinessView.ModuleId];
            var entityName = view.Properties[BusinessView.EntityName];
            var pathProj = settings.Projects[ProcessGeneration.ServicesKey][moduleId].ProjectFolder;
            var bsName = moduleId + "Bootstrapper.cs";
            var bsFile = Path.Combine(pathProj, bsName);

            if (File.Exists(bsFile))
            {
                var register = "\t\t\tUnityUtil.RegisterType";
                string[] tags =
                {
                    @"private void RegisterService(IUnityContainer container)",
                    @"private void RegisterRepositories(IUnityContainer container)",
                };

                string[] linesToAdded =
                {
                    string.Format(register + "<Interfaces.Services.I{0}Service<Models.{0}>, {0}EntityService<Models.{0}>>(container);",entityName),
                    string.Format(register + "<IExportImportRepository, BusinessRepository.{2}Repository<Models.{2}>>(container, \"{1}{0}\", new InjectionConstructor(typeof(Context)));", entityName.ToLower(), moduleId.ToLower(), entityName),
                    string.Format(register + "(container, typeof(Interfaces.BusinessRepository.I{0}Entity<Models.{0}>), typeof(BusinessRepository.{0}Repository<Models.{0}>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));", entityName),
                    string.Format(register + "(container, typeof(Interfaces.BusinessRepository.I{0}Entity<Models.{0}>), typeof(BusinessRepository.{0}Repository<Models.{0}>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));", entityName)
                };

                var txtLines = File.ReadAllLines(bsFile).ToList();
                var trimLines = (File.ReadAllLines(bsFile)).Select(l => l.Trim()).ToList();
                for (var i = 0; i < 2; i++)
                {
                    var index = trimLines.IndexOf(tags[i]) + 2 + i;
                    txtLines.Insert(index, linesToAdded[i]);
                    if (i == 1)
                    {
                        txtLines.Insert(++index, linesToAdded[2]);
                        txtLines.Insert(++index, linesToAdded[3]);
                    }
                }
                File.WriteAllLines(bsFile, txtLines);
            }
        }

        #endregion
    }
}
