// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using Microsoft.Win32;
using Sage300CUIWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace Sage.CA.SBS.ERP.Sage300.SolutionWizard
{
    public static class RegistryHelper
    {
        /// <summary>
        /// The path to the Registry Key where the name of the shared folder is stored
        /// </summary>
        private const string CONFIGURATION_KEY = "SOFTWARE\\ACCPAC International, Inc.\\ACCPAC\\Configuration";

        /// <summary>
        /// The name of the Registry Value containing the name of the shared folder
        /// </summary>
        public static string Sage300CWebFolder
        {
            get
            {
                // Get the registry key
                var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                var configurationKey = baseKey.OpenSubKey(CONFIGURATION_KEY);

                // Find path tp shared folder
                return configurationKey == null ? string.Empty : Path.Combine(configurationKey.GetValue("Programs").ToString(), @"Online\Web");
            }
        }
    }

    public class Sage300CUISolutionWizardUserInterface : IWizard
    {
        private string _companyName;
        private string _applicationID;
        private string _solutionFolder;
        private string _destinationFolder;
        private DTE _dte;
        private string _safeprojectname;
        private string _namespace;
        private string _sage300webfolder;

        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {


        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {

        }

        // This method is called after the project is created.
        public void RunFinished()
        {
            var sln = (Solution2)_dte.Solution;

            var csTemplatePath = Path.GetDirectoryName(sln.GetProjectTemplate("Sage 300 Solution Wizard", "CSharp")) + @"\..\";

            //this will create a solution
            sln.Create(_destinationFolder, _safeprojectname);

            var namespaceForProject = _companyName + "." + _applicationID + ".";

            var projects = new string[] { "Web", "BusinessRepository", "Interfaces", "Models", "Resources", "Services" };

            var parameters = "$companyname$" + "=" + _companyName + "|$applicationid$=" + _applicationID +
                                "|$companynamespace$=" + _namespace +
                                "|$sage300webfolder$=" + _sage300webfolder;

            foreach (var proj in projects)
            {
                var templateFilename = proj + ".vstemplate";
                var sourceFilenameAndParameters = csTemplatePath + proj + @".zip\" + templateFilename + "|" + parameters;
                if (string.Compare(proj, "Web", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    sln.AddFromTemplate(sourceFilenameAndParameters, Path.Combine(_destinationFolder, _namespace + "." + proj), 
                        _namespace + "." + proj, false);
                }
                else
                {
                    sln.AddFromTemplate(sourceFilenameAndParameters, Path.Combine(_destinationFolder, _namespace + "." + _applicationID + "." + proj), 
                        _namespace + "." + _applicationID + "." + proj, false);
                    
                }
            }

        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {

            _dte = (DTE)automationObject;

            _solutionFolder = replacementsDictionary["$solutiondirectory$"];
            _destinationFolder = replacementsDictionary["$destinationdirectory$"];
            _safeprojectname = replacementsDictionary["$safeprojectname$"];

            try
            {
                // Display a form to the user. The form collects 
                // input for the custom message.
                var inputForm = new UserInputForm();

                var res = inputForm.ShowDialog();

                // cancel wizard
                if (res != DialogResult.OK)
                    throw new WizardBackoutException();

                // save parameters
                _companyName = inputForm.ThirdPartyCompanyName.Trim();
                _applicationID = inputForm.ThirdPartyApplicationId.Trim();
                _namespace = inputForm.CompanyNamespace.Trim();
                _sage300webfolder = RegistryHelper.Sage300CWebFolder;


                // Add custom parameters.
                replacementsDictionary.Add("$companyname$", _companyName);
                replacementsDictionary.Add("$applicationid$", _applicationID);
                replacementsDictionary.Add("$companynamespace$", _namespace);
                replacementsDictionary.Add("$sage300webfolder$", _sage300webfolder);

            }
            catch
            {
                // Clean up the template that was written to disk
                if (Directory.Exists(_solutionFolder))
                {
                    try
                    {
                        Directory.Delete(_solutionFolder);
                    }
                    catch
                    {
                        ; // don't care
                    }
                }

                throw;
            }

        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {

            return true;
        }
    }
}