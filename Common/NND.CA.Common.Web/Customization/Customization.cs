///* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

//#region

//using Sage.CA.SBS.ERP.Sage300.Common.Models;
//using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;
//using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
//using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
//using Sage.CA.SBS.ERP.Sage300.Core.Logging;
//using System;
//using System.IO;
//using System.Reflection;

//#endregion

//namespace NND.CA.Common.Web.Customization
//{
//    /// <summary>
//    /// Class Customization.
//    /// </summary>
//    public class Customization
//    {
//        /// <summary>
//        /// The _screens
//        /// </summary>
//        private Screens _screens;

//        /// <summary>
//        /// The _watcher
//        /// </summary>
//        private FileSystemWatcher _watcher;

//        /// <summary>
//        /// The synchronize root
//        /// </summary>
//        private static readonly object SyncRoot = new object();

//        /// <summary>
//        /// The _folder path
//        /// </summary>
//        private readonly string _folderPath;

//        /// <summary>
//        /// The _instance
//        /// </summary>
//        private static Customization _instance;

//        /// <summary>
//        /// Constructor
//        /// </summary>
//        private Customization()
//        {
//            _folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + @"\Customization";
//            _watcher = new FileSystemWatcher(new Uri(_folderPath).LocalPath, "ScreenDefinitions.xml");
//            _watcher.Changed += _watcher_Changed;
//            _watcher.NotifyFilter = NotifyFilters.LastWrite;
//            _watcher.EnableRaisingEvents = true;
//        }

//        /// <summary>
//        /// Event handling when the file is changes
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="e">The <see cref="FileSystemEventArgs"/> instance containing the event data.</param>
//        private void _watcher_Changed(object sender, FileSystemEventArgs e)
//        {
//            _screens = null;
//        }

//        /// <summary>
//        /// Get the shared instance
//        /// </summary>
//        /// <returns>Customization.</returns>
//        public static Customization GetInstance()
//        {
//            if (_instance == null)
//            {
//                lock (SyncRoot)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new Customization();
//                    }
//                }
//            }
//            return _instance;
//        }

//        /// <summary>
//        /// Get screen definition
//        /// </summary>
//        /// <param name="context">Context</param>
//        /// <param name="screenName">ScreenName</param>
//        /// <returns>Screen</returns>
//        public Screen GetScreen(Context context, string screenName)
//        {
//            if (screenName == ScreenName.None)
//            {
//                return null;
//            }

//            try
//            {
//                if (_screens == null)
//                {
//                    lock (SyncRoot)
//                    {
//                        if (_screens == null)
//                        {
//                            //Load Screen Definitions from xml file
//                            //TODO:There should be different xml file per tenant
//                            var filePath = _folderPath + @"\ScreenDefinitions.xml";
//                            _screens = CommonUtil.DeSerialize<Screens>(new Uri(filePath).LocalPath);
//                        }
//                    }
//                }
//                return _screens.ScreenList.Find(screen => screen.Name == screenName);
//            }
//            catch (Exception ex)
//            {
//                Logger.Error("Unable to load Configuration file", "Common", context, ex);
//                return null;
//            }
//        }

//        /// <summary>
//        /// Dispose when the application is down
//        /// </summary>
//        ~Customization()
//        {
//            if (_watcher != null)
//            {
//                _watcher.Dispose();
//                _watcher = null;
//            }
//        }
//    }
//}