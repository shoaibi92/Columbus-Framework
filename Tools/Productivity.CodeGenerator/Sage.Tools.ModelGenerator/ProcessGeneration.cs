/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;
using Sage.Tools.Framework.CodeGenerator;

namespace Sage.Tools.ModelGenerator
{
    /// <summary> Process Generation Class (worker) </summary>
    public class ProcessGeneration
    {
        #region Private Vars
        /// <summary> Settings from UI (view id, output file) </summary>
        private Settings _settings;

        /// <summary> View to be used to generated class files </summary>
        private static View _view;

        private static Session _session;
        private static DBLink _dbLink;

        #endregion

        #region Private Constants
        #endregion

        #region Public Constants
        /// <summary> settingsKey is used as a dictionary key for settings </summary>
        public const string SettingsKey = "settings";
        #endregion

        #region Public Delegates
        /// <summary> Delegate to update UI with name of file being processed </summary>
        /// <param name="text">Text for UI</param>
        public delegate void ProcessingEventHandler(string text);

        /// <summary> Delegate to update UI with status of file being processed </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="statusType">Status Type</param>
        /// <param name="text">Text for UI</param>
        public delegate void StatusEventHandler(string fileName, Info.StatusType statusType, string text);
        #endregion

        #region Public Events
        /// <summary> Event to update UI with name of file being processed </summary>
        public event ProcessingEventHandler ProcessingEvent;

        /// <summary> Event to update UI with status of file being processed </summary>
        public event StatusEventHandler StatusEvent;
        #endregion

        #region Constructor
        #endregion

        #region Public Methods

        /// <summary> Cleanup </summary>
        public void Dispose()
        {
            if (_view != null)
            {
                _view.Dispose();
                _view = null;
            }

            if (_dbLink != null)
            {
                _dbLink.Dispose();
                _dbLink = null;
            }

            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }

        }

        /// <summary> Build settings for background worker </summary>
        /// <param name="settings">Settings string</param>
        /// <returns>Settings</returns>
        public Settings BuildSettings(string settings)
        {
            var parsedLine = settings.Split(';');
            return new Settings
            {
                ViewId = parsedLine[0],
                OutputFolder = parsedLine[1],
                User = parsedLine[2],
                Password = parsedLine[3],
                Version = parsedLine[4],
                Database = parsedLine[5]
            };
        }

        /// <summary> Start the generation process </summary>
        /// <param name="settings">Settings for processing</param>
        public void Process(Settings settings)
        {
            _settings = settings;

            // Iterate View
            IterateView();
        }
        #endregion

        #region Private Methods

        /// <summary> Clear the output folder </summary>
        private void ClearOutputFolder()
        {
            // Locals
            var folder = _settings.OutputFolder + @"\" + BusinessViewHelper.ViewDescription;

            // Ensure output folder is clear of contents
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);

            Directory.CreateDirectory(folder + @"\Finder\");
            Directory.CreateDirectory(folder + @"\Interface\");
        }

        /// <summary> Save a file </summary>
        /// <returns>True if successful otherwise false</returns>
        private bool SaveFile(string fileName, string content)
        {
            // Local
            var retVal = true;
            var folder = _settings.OutputFolder + @"\" + BusinessViewHelper.ViewDescription;

            try
            {
                // Save the file
                File.WriteAllText(folder + @"\" + fileName, content);
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary> Iterate the view </summary>
        private void IterateView()
        {
            // Validate the settings which will also instantiate the view
            if (ValidSettings(_settings))
            {
                // Iniitialize the helper
                BusinessViewHelper.Initialize(_view);

                // Ensure output folder is clear of contents
                ClearOutputFolder();

                // Create the Model class
                CreateClass(BusinessViewHelper.ViewDescription + ".cs", BusinessViewHelper.CreateModel(_view));

                // Create the Model Mapper class
                CreateClass(BusinessViewHelper.ViewDescription + "Mapper.cs", BusinessViewHelper.CreateModelMapper(_view));

                // Create the Model Fields class
                CreateClass(BusinessViewHelper.ViewDescription + "Fields.cs", BusinessViewHelper.CreateModelFields(_view));

                // Create the Model Enumeration class(es)
                foreach (var value in BusinessViewHelper.Enums.Values)
                {
                    CreateClass(value.Name + ".cs", BusinessViewHelper.CreateModelEnum(value));
                }

                // Generate Code for Finder.
                var outputFolderName = _settings.OutputFolder + @"\" + BusinessViewHelper.ViewDescription + @"\Finder\";
                var finderCodeGenerator = new FinderCodeGenerator(BusinessViewHelper.ViewDescription, BusinessViewHelper.GetModelProperties(_view), outputFolderName, BusinessViewHelper.Module);
                var finderFileName = finderCodeGenerator.Generate();

                if (!string.IsNullOrEmpty(finderFileName))
                {
                    StatusEvent(finderFileName, Info.StatusType.Success, string.Empty);
                }

                outputFolderName = _settings.OutputFolder + @"\" + BusinessViewHelper.ViewDescription + @"\Interface\";

                // Generate Interface Code for Repository & Service.
                var codeGenerator = new InterfaceCodeGenerator(BusinessViewHelper.ViewDescription, outputFolderName);
                codeGenerator.Generate();
            }

        }

        /// <summary> Create the class </summary>
        private void CreateClass(string fileName, string content)
        {
            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(fileName);
            }

            // Save the file
            var success = SaveFile(fileName, content);

            // Update status
            if (StatusEvent != null)
            {
                if (success)
                {
                    StatusEvent(fileName, Info.StatusType.Success, string.Empty);
                }
                else
                {
                    StatusEvent(fileName, Info.StatusType.Error, string.Format(Properties.Resources.ErrorCreatingFile, fileName));
                }
            }
        }

        #endregion
    }
}
