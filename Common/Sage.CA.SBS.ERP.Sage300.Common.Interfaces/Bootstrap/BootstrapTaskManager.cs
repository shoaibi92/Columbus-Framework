/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap
{
    /// <summary>
    /// Bootstapper tasks manager for executiing bootstrap tasks
    /// </summary>
    public static class BootstrapTaskManager
    {
        /// <summary>
        /// All bootstrap tasks composed.
        /// </summary>
        [ImportMany]
        public static IEnumerable<Lazy<IBootstrapperTask, IBootstrapMetadata>> BootstrapTasks { get; set; }

        /// <summary>
        /// Unity container
        /// </summary>
        private static readonly IUnityContainer UnityContainer;

        /// <summary>
        /// Get the Unity container
        /// </summary>
        public static IUnityContainer Container
        {
            get { return UnityContainer; }
        }

        /// <summary>
        /// Static constructor to configure unity container
        /// </summary>
        static BootstrapTaskManager()
        {
            UnityContainer = ConfigureContainer();
        }

        /// <summary>
        /// Setup web unity mappings for web
        /// </summary>
        /// <param name="path">Path to scan for IBootstrapperTask implementations </param>
        /// <param name="patterns">file types pattern to be searched</param>
        public static void SetupWeb(string path, string[] patterns)
        {
            Run(path, patterns, BootstrapAppliesTo.Web);
        }

        /// <summary>
        /// Setup worker unity mappings
        /// </summary>
        /// <param name="path">Path to scan for IBootstrapperTask implementations </param>
        /// <param name="patterns">file types pattern to be searched</param>
        public static void SetupWorker(string path, string[] patterns)
        {
            Run(path, patterns, BootstrapAppliesTo.Worker);
        }

        /// <summary>
        /// Setup Web Api unity mappings
        /// </summary>
        /// <param name="path">Path to scan for IBootstrapperTask implementations </param>
        /// <param name="patterns">file types pattern to be searched</param>
        public static void SetupWebApi(string path, string[] patterns)
        {
            Run(path, patterns, BootstrapAppliesTo.WebApi);
        }

        /// <summary>
        /// Run all the unity bootstrapper tasks based on AppliesTo
        /// </summary>
        /// <param name="path">Path to scan for IBootstrapperTask implementations </param>
        /// <param name="patterns">file types pattern to be searched</param>
        /// <param name="appliesTo">What implementations to be loaded based on AppliesTo attribute</param>
        private static void Run(string path, string[] patterns, BootstrapAppliesTo appliesTo)
        {
            var catalog = new AggregateCatalog();
            foreach (var p in patterns)
                catalog.Catalogs.Add(new DirectoryCatalog(path, p));

            // MEF container to compose implementaions
            var container = new CompositionContainer(catalog);

            try
            {
                // Get all the IBootstrapperTask implementations matching the criteria
                BootstrapTasks =
                    container.GetExports<IBootstrapperTask, IBootstrapMetadata>()
                        .Where(task => task.Metadata.AppliesTo.Contains(appliesTo))
                        .OrderBy(task => task.Metadata.Order);

            }
            catch (ReflectionTypeLoadException loadException)
            {
                // Get all the loader exceptions
                var exceptionInfo = new StringBuilder();
                foreach (Exception exSub in loadException.LoaderExceptions)
                {
                    exceptionInfo.Append(exSub.Message);
                }

                // Throw new exception with loader exception information
                throw new ApplicationException(exceptionInfo.ToString(), loadException);
            }

            // Execute the interfaces that are composed
            foreach (var task in BootstrapTasks)
            {
                task.Value.Execute(Container);
            }
        }

        /// <summary>
        /// Register plug in component types
        /// </summary>
        /// <param name="path"></param>
        public static void RegisterTypes(string path)
        {
            var patterns = GetSearchPattern(path, false);
            SetupWorker(Path.Combine(path, "bin"), patterns.ToArray());
        }

        /// <summary>
        /// Get bootstrapper search files patterns
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSearchPattern(string dir, bool includeSage = true)
        {
            const string sageDllPattern = "Sage.CA.SBS.ERP.Sage300*.dll";
            const string path = "/bootstrapper/assemblies/add[@assembly]";
            const string searhPattern = "*bootstrapper.xml";

            string[] files = Directory.GetFiles(dir, searhPattern);

            var patterns = (includeSage) ? new List<string>() { sageDllPattern } : new List<string>();
            var doc = new XmlDocument();

            foreach (var bootStrapperFile in files)
            {
                try
                {
                    doc.Load(bootStrapperFile);
                    var nodes = doc.SelectNodes(path);
                    if (nodes != null)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            if (node.Attributes != null && !string.IsNullOrEmpty(node.Attributes["assembly"].Value))
                            {
                                var pattern = node.Attributes["assembly"].Value;
                                if (pattern.StartsWith("*")) continue;
                                if (!pattern.ToLower().EndsWith(".dll"))
                                {
                                    pattern = pattern + ".dll";
                                }
                                patterns.Add(pattern);
                            }
                        }
                    }
                }
                catch (Exception) //suppresses any errors, not break application
                {
                }
            }
            return patterns;
        }

        /// <summary>
        /// Creates Sage Unity Container
        /// </summary>
        /// <returns>Unity Container</returns>
        private static IUnityContainer ConfigureContainer()
        {
            var container = new SageUnityContainer();
            return container;
        }
    }
}
