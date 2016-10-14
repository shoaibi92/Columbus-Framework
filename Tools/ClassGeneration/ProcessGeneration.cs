// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using ACCPAC.Advantage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary> Process Generation Class (worker) </summary>
    class ProcessGeneration
    {
        #region Private Vars
        /// <summary> Settings from UI (view id, output file) </summary>
        private Settings _settings;

        /// <summary> View to be used to generated class files </summary>
        private static View _view;

        private static Session _session;
        private static DBLink _dbLink;

        private static readonly Dictionary<string, bool> UniqueDescriptions = new Dictionary<string, bool>();

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
        /// <summary> Validate the settings based upon repository type</summary>
        /// <param name="settings">Settings</param>
        /// <returns>True if valid otherwise false</returns>
        /// <remarks>A valid ViewID must be entered</remarks>
        public bool ValidSettings(Settings settings)
        {

            // Check Output regardless of repository type
            if (settings.OutputFolder.Equals(string.Empty))
            {
                return false;
            }

            // Check Resx Name regardless of repository type
            if (settings.ResxName.Equals(string.Empty))
            {
                return false;
            }
            if (!settings.ResxName.EndsWith("Resx"))
            {
                return false;
            }

            // Dynamic Query validation
            if (settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
            {
                // Check ViewId, Module, Model Name and Name
                if (settings.BusinessView.Properties[BusinessView.ViewId].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.Module].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.ModelName].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.Name].Equals(string.Empty))
                {
                    return false;
                }

                // Check Fields. There must be at least one field entered
                if (settings.BusinessView.Fields.Count == 0)
                {
                    return false;
                }

                // Check Fields. For content
                var validFields = true;
                UniqueDescriptions.Clear();
                for (var i = 0; i < settings.BusinessView.Fields.Count; i++)
                {
                    // Locals
                    var field = settings.BusinessView.Fields[i];

                    // Assign id
                    field.Id = i + 1;

                    // Check Name
                    if (field.Name.Trim().Equals(string.Empty))
                    {
                        validFields = false;
                        break;
                    }

                    // Ensure Name is properly formatted
                    field.Name = Replace(field.Name);
                    field.ServerFieldName = field.Name;

                    // Ensure name is unique
                    if (UniqueDescriptions.ContainsKey(field.Name))
                    {
                        // Duplicate name entered
                        validFields = false;
                        break;
                    }

                    // Add for next check
                    UniqueDescriptions.Add(field.Name, false);
                }

                return validFields;
            }

            // Report Validation
            if (settings.RepositoryType.Equals(RepositoryType.Report))
            {
                // Check ViewId, Module, Model Name, Name, ReportKey and ProgramId
                if (settings.BusinessView.Properties[BusinessView.ViewId].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.Module].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.ModelName].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.Name].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.ReportKey].Equals(string.Empty) ||
                    settings.BusinessView.Properties[BusinessView.ProgramId].Equals(string.Empty))
                {
                    return false;
                }

                // Check Fields. There must be at least one field entered
                if (settings.BusinessView.Fields.Count == 0)
                {
                    return false;
                }

                // Check Fields. For content
                var validFields = true;
                UniqueDescriptions.Clear();
                for (var i = 0; i < settings.BusinessView.Fields.Count; i++)
                {
                    // Locals
                    var field = settings.BusinessView.Fields[i];

                    // Assign id
                    // field.Id = i + 1; // Already assigned from ini file

                    // Check Name
                    if (field.Name.Trim().Equals(string.Empty))
                    {
                        validFields = false;
                        break;
                    }

                    // Ensure Name is properly formatted
                    field.Name = Replace(field.Name);

                    // Ensure name is unique
                    if (UniqueDescriptions.ContainsKey(field.Name))
                    {
                        // Duplicate name entered
                        validFields = false;
                        break;
                    }

                    // Add for next check
                    UniqueDescriptions.Add(field.Name, false);
                }

                return validFields;
            }

            // Check requirements for validating a view
            if (settings.ViewId.Equals(string.Empty) || settings.Database.Equals(string.Empty) || settings.Password.Equals(string.Empty) ||
                settings.User.Equals(string.Empty) || settings.Version.Equals(string.Empty))
            {
                return false;
            }

            try
            {
                // Init
                if (_session == null)
                {
                    _session = new Session();
                    _session.InitEx(null, string.Empty, "XX", "XX1000", settings.Version);
                    _session.Open(settings.User, settings.Password, settings.Database, DateTime.UtcNow, 0);
                }

            }
            catch
            {
                _session = null;
            }

            if (_session != null)
            {
                try
                {
                    // Clean up first
                    if (_view != null)
                    {
                        _view.Dispose();
                        _view = null;
                    }

                    // Attempt to open a view
                    _dbLink = _session.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadOnly);
                    _view = _dbLink.OpenView(settings.ViewId);
                }
                catch
                {
                    _view = null;
                }
            }

            return (_view != null);
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
        /// <param name="view">Business View</param>
        private void ClearOutputFolder(BusinessView view)
        {
            // Locals
            var folder = _settings.OutputFolder + @"\" + view.Properties[BusinessView.Name];

            // Ensure output folder is clear of contents
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }
            Directory.CreateDirectory(folder);
        }

        /// <summary> Save a file </summary>
        /// <param name="view">Business View</param>
        /// <param name="fileName"> Name of file to be created</param>
        /// <param name="content">File contents</param>
        /// <returns>True if successful otherwise false</returns>
        private bool SaveFile(BusinessView view, string fileName, string content)
        {
            // Local
            var retVal = true;
            var folder = _settings.OutputFolder + @"\" + view.Properties[BusinessView.Name];

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

        /// <summary>
        /// Make it singular or best guess at it!
        /// </summary>
        /// <param name="name">Name to make singular</param>
        /// <returns>Singular name or entered name if not plural</returns>
        private static string MakeItSingular(string name)
        {
            // Default to entered value
            var retVal = name;

            // If Options or ... then exit
            if (retVal.Equals("Options"))
            {
                return retVal;
            }

            // If it ends in an "s", make it singular
            if (retVal.EndsWith("s"))
            {
                retVal = retVal.Substring(0, retVal.Length - 1);
            }

            return retVal;

        }

        /// <summary>
        /// Get the Field Name. (Note: The Field description attribute is used for name)
        /// </summary>
        /// <param name="field">The field the name has to be determined</param>
        /// <returns>Name of the field</returns>
        private static string FieldName(ViewField field)
        {
            if (UniqueDescriptions != null &&
                UniqueDescriptions.ContainsKey(field.Description) &&
                UniqueDescriptions[field.Description] == false)
            {
                return field.Name;
            }

            return Replace(field.Description);
        }

        /// <summary>
        /// Helper method that removes and replaces unwanted characters
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns></returns>
        private static string Replace(string s)
        {
            if (s == string.Empty)
            {
                return string.Empty;
            }
            var newString = s
                .Replace(" to ", "To")
                .Replace(" from ", "From")
                .Replace(" for ", "For")
                .Replace(" and ", "And")
                .Replace(" is ", "Is")
                .Replace(" in ", "In")
                .Replace(" of ", "Of")
                .Replace(" ", "")
                .Replace("/", "")
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
            }

            return newString;
        }

        /// <summary>
        /// Generate unique descriptions
        /// </summary>
        private static void GenerateUniqueDescriptions()
        {
            // Clear first
            UniqueDescriptions.Clear();

            for (var i = 0; i < _view.Fields.Count; i++)
            {
                //Ignore those fields having description "RESERVED"
                if (_view.Fields[i].Description.ToUpper() == "RESERVED")
                {
                    continue;
                }

                if (!UniqueDescriptions.ContainsKey(_view.Fields[i].Description))
                {
                    UniqueDescriptions.Add(_view.Fields[i].Description, true);
                }
                else
                {
                    UniqueDescriptions[_view.Fields[i].Description] = false;
                }
            }
        }

        /// <summary>
        /// Get value from presentation list
        /// </summary>
        /// <param name="i">Outer Loop</param>
        /// <param name="j">Inner Loop</param>
        private static Object GetValue(int i, int j)
        {
            int intVal;
            bool boolVal;
            if (Int32.TryParse(_view.Fields[i].PresentationList.PredefinedValue(j).ToString(), out intVal))
            {
                return intVal;
            }
            if (bool.TryParse(_view.Fields[i].PresentationList.PredefinedValue(j).ToString(), out boolVal))
            {
                return boolVal ? 0 : 1;
            }

            return Convert.ToChar(_view.Fields[i].PresentationList.PredefinedValue(j));
        }

        /// <summary>
        /// Get field's data type
        /// </summary>
        /// <param name="field">The field the data type is to be determined</param>
        /// <returns>Data type of the field</returns>
        private static BusinessDataType FieldType(ViewField field)
        {
            if (field.PresentationType == ViewFieldPresentationType.List)
            {
                return BusinessDataType.Enumeration;
            }

            //Need to use enum field.Type.HasFlag
            var viewfiledType = field.Type;

            if (viewfiledType.GetHashCode() == ViewFieldType.Long.GetHashCode())
            {
                return BusinessDataType.Long;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Char.GetHashCode())
            {
                return BusinessDataType.String;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Date.GetHashCode())
            {
                return BusinessDataType.DateTime;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Int.GetHashCode())
            {
                return BusinessDataType.Integer;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Decimal.GetHashCode())
            {
                return BusinessDataType.Decimal;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Bool.GetHashCode())
            {
                return BusinessDataType.Boolean;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Time.GetHashCode())
            {
                return BusinessDataType.TimeSpan;
            }
            if (viewfiledType.GetHashCode() == ViewFieldType.Byte.GetHashCode())
            {
                return BusinessDataType.Byte;
            }

            return BusinessDataType.Double;
        }

        /// <summary>
        /// Generate enums
        /// </summary>
        private static void GenerateFieldsAndEnums(BusinessView businessView)
        {
            for (var i = 0; i < _view.Fields.Count; i++)
            {

                //Ignore those fields having description "RESERVED"
                if (_view.Fields[i].Description.ToUpper() == "RESERVED")
                {
                    continue;
                }

                var field = _view.Fields[i];
                var businessField = new BusinessField
                {
                    ServerFieldName = field.Name,
                    Name = FieldName(field),
                    Description = field.Description,
                    Type = FieldType(field),
                    Id = field.ID,
                    Size = field.Size,
                    IsReadOnly = !field.Attributes.HasFlag(ViewFieldAttributes.Editable),
                    IsCalculated = field.Attributes.HasFlag(ViewFieldAttributes.Calculated),
                    IsRequired = field.Attributes.HasFlag(ViewFieldAttributes.Required),
                    IsKey = field.Attributes.HasFlag(ViewFieldAttributes.Key),
                    IsUpperCase = field.PresentationMask != null && field.PresentationMask.Contains("C"),
                    IsAlphaNumeric = field.PresentationMask != null && field.PresentationMask.Contains("N"),
                    IsNumeric = field.PresentationMask != null && field.PresentationMask.Contains("D"),
                    IsDynamicEnablement = field.Attributes.HasFlag(ViewFieldAttributes.CheckEditable)
                };

                if (field.PresentationType == ViewFieldPresentationType.List)
                {
                    var enumObject = new EnumHelper { Name = businessField.Name };

                    var builder = new StringBuilder();
                    for (var j = 0; j < field.PresentationList.Count; j++)
                    {
                        if (field.PresentationList.PredefinedString(j) != "N/A" || !string.IsNullOrEmpty(field.PresentationList.PredefinedString(j)))
                        {
                            // Will need to prefix key with value in case of dupes (have only seen this with one view (IC0281)) and 
                            // thus will need to resolve in enum class when coding
                            var key = Replace(field.PresentationList.PredefinedString(j));
                            var value = GetValue(i, j);

                            // Will strip out this prefix when building enum class
                            enumObject.Values.Add(value + ":" + key, value);

                            builder.Append(field.PresentationList[j]);
                        }
                    }

                    businessView.Enums.Add(enumObject.Name, enumObject);
                }

                // Add to fields collection
                businessView.Fields.Add(businessField);
            }
        }

        /// <summary> Initializes the Business View </summary>
        /// <returns>Business View</returns>
        private BusinessView Initialize()
        {
            // Locals
            BusinessView businessView = new BusinessView();

            // Dynamic Query already has business view!
            if (_settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
            {
                businessView = _settings.BusinessView;
                businessView.Properties[BusinessView.ModelName] = MakeItSingular(Replace(businessView.Properties[BusinessView.ModelName]));
                businessView.Properties[BusinessView.Name] = Replace(businessView.Properties[BusinessView.Name]);
            }
            // Report already has business view!
            else if (_settings.RepositoryType.Equals(RepositoryType.Report))
            {
                businessView = _settings.BusinessView;
                businessView.Properties[BusinessView.ModelName] = MakeItSingular(Replace(businessView.Properties[BusinessView.ModelName]));
                businessView.Properties[BusinessView.Name] = Replace(businessView.Properties[BusinessView.Name]);
                businessView.Properties[BusinessView.ProgramId] = Replace(businessView.Properties[BusinessView.ProgramId]);
            }
            else
            {
                businessView.Properties.Add(BusinessView.ViewId, _view.ViewID);
                businessView.Properties.Add(BusinessView.ModelName, MakeItSingular(Replace(_view.Description)));
                businessView.Properties.Add(BusinessView.Module, _view.ViewID.Substring(0, 2));
                businessView.Properties.Add(BusinessView.Name, businessView.Properties[BusinessView.ModelName]);

                GenerateUniqueDescriptions();
                GenerateFieldsAndEnums(businessView);
            }

            return businessView;
        }

        /// <summary> Iterate the view </summary>
        private void IterateView()
        {
            // Validate the settings which will also instantiate the view
            if (ValidSettings(_settings))
            {
                // Initialize the BusinessView
                var view = Initialize();

                // Ensure output folder is clear of contents
                ClearOutputFolder(view);

                // Create the Model class
                CreateClass(view, view.Properties[BusinessView.ModelName] + ".cs", BusinessViewHelper.CreateModel(view, _settings.RepositoryType, _settings.ResxName));

                // Create module security constant Class
                CreateClass(view, "Security.cs", BusinessViewHelper.CreateSecurityConstantClass(view));

                // Create the Model Mapper class
                if (!_settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
                {
                    CreateClass(view, view.Properties[BusinessView.ModelName] + "Mapper.cs", BusinessViewHelper.CreateModelMapper(view, _settings.RepositoryType));
                }

                // Create the Model Fields class
                CreateClass(view, view.Properties[BusinessView.ModelName] + "Fields.cs", BusinessViewHelper.CreateModelFields(view, _settings.RepositoryType, _settings.GenerateDynamicEnablement));

                // Create _Index.cshtml
                if (!_settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
                {
                    CreateClass(view, "_Index.cshtml", BusinessViewHelper.CreateIndexHtml(view));
                }

                // Create _Localization.cshtml
                if (!_settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
                {
                    CreateClass(view, "_Localization.cshtml", BusinessViewHelper.CreateLocalizationHtml(view));
                }

                // Create the Model Enumeration class(es)
                foreach (var value in view.Enums.Values)
                {
                    CreateClass(view, value.Name + ".cs", BusinessViewHelper.CreateModelEnum(view, value, _settings.RepositoryType));
                }

                // Create classes for Flat Repository Type
                if (_settings.RepositoryType.Equals(RepositoryType.Flat))
                {
                    CreateFlatRepositoryClasses(view);
                }

                // Create classes for Process Repository Type
                if (_settings.RepositoryType.Equals(RepositoryType.Process))
                {
                    CreateProcessRepositoryClasses(view);
                }

                // Create classes for Dynamic Query Repository Type
                if (_settings.RepositoryType.Equals(RepositoryType.DynamicQuery))
                {
                    CreateDynamicQueryRepositoryClasses(view);
                }

                // Create classes for Report Repository Type
                if (_settings.RepositoryType.Equals(RepositoryType.Report))
                {
                    CreateReportRepositoryClasses(view);
                }

                // Create classes for Inquiry Repository Type
                if (_settings.RepositoryType.Equals(RepositoryType.Inquiry))
                {
                    CreateInquiryRepositoryClasses(view);
                }

                // Create class for finder
                if (_settings.GenerateFinder)
                {
                    CreateClass(view, "Find" + view.Properties[BusinessView.Name] + "ControllerInternal.cs", BusinessViewHelper.CreateFinder(view, _settings.ResxName));
                }

                // Create the Resx Files
                CreateResx(view, _settings.ResxName + ".resx", true);
                CreateResx(view, _settings.ResxName + ".es.resx", false);
                CreateResx(view, _settings.ResxName + ".fr-CA.resx", false);
                CreateResx(view, _settings.ResxName + ".zh-Hans.resx", false);
                CreateResx(view, _settings.ResxName + ".zh-Hant.resx", false);
            }

        }

        /// <summary> Create the class </summary>
        /// <param name="view">Business View</param>
        /// <param name="fileName"> Name of file to be created</param>
        /// <param name="content">File contents</param>
        private void CreateClass(BusinessView view, string fileName, string content)
        {
            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(fileName);
            }

            // Save the file
            var success = SaveFile(view, fileName, content);

            // Update status
            LaunchStatusEvent(success, fileName);
        }

        /// <summary> Update UI </summary>
        /// <param name="success">True/False based upon class generation</param>
        /// <param name="fileName">name of file to be created</param>
        private void LaunchStatusEvent(bool success, string fileName)
        {
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

        /// <summary> Create Flat Repository Classes </summary>
        /// <param name="view">Business View</param>
        private void CreateFlatRepositoryClasses(BusinessView view)
        {
            // Create the Business Repository Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Entity.cs", BusinessViewHelper.CreateFlatBusRepoInterface(view));

            // Create the Service Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateFlatServicesInterface(view));

            // Create the Service class
            CreateClass(view, view.Properties[BusinessView.Name] + "EntityService.cs", BusinessViewHelper.CreateFlatService(view));

            // Create the ViewModel class
            CreateClass(view, view.Properties[BusinessView.Name] + "ViewModel.cs", BusinessViewHelper.CreateFlatViewModel(view));

            // Create the Internal Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "ControllerInternal.cs", BusinessViewHelper.CreateFlatInternalController(view));

            // Create the public Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "Controller.cs", BusinessViewHelper.CreateFlatController(view));

            //Create the Repository class
            CreateClass(view, view.Properties[BusinessView.Name] + "Repository.cs", BusinessViewHelper.CreateFlatRepository(view));

        }

        /// <summary> Create Process Repository Classes </summary>
        /// <param name="view">Business View</param>
        private void CreateProcessRepositoryClasses(BusinessView view)
        {
            // Create the Business Repository Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Entity.cs", BusinessViewHelper.CreateProcessBusRepoInterface(view));

            // Create the Service Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateProcessServicesInterface(view));

            // Create the Service class
            CreateClass(view, view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateProcessService(view));

            // Create the ViewModel class
            CreateClass(view, view.Properties[BusinessView.Name] + "ViewModel.cs", BusinessViewHelper.CreateProcessViewModel(view));

            // Create the Internal Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "ControllerInternal.cs", BusinessViewHelper.CreateProcessInternalController(view));

            // Create the public Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "Controller.cs", BusinessViewHelper.CreateProcessController(view));

            //Create the Repository class
            CreateClass(view, view.Properties[BusinessView.Name] + "Repository.cs", BusinessViewHelper.CreateProcessRepository(view));
        }

        /// <summary> Create Dynamic Query Repository Classes </summary>
        /// <param name="view">Business View</param>
        private void CreateDynamicQueryRepositoryClasses(BusinessView view)
        {
            // Create the Business Repository Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Entity.cs", BusinessViewHelper.CreateDynamicQueryBusRepoInterface(view));

            // Create the Service Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateDynamicQueryServicesInterface(view));

            // Create the Service class
            CreateClass(view, view.Properties[BusinessView.Name] + "EntityService.cs", BusinessViewHelper.CreateDynamicQueryService(view));

            // Create the ViewModel class
            CreateClass(view, view.Properties[BusinessView.Name] + "ViewModel.cs", BusinessViewHelper.CreateDynamicQueryViewModel(view));

            // Create the public Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "Controller.cs", BusinessViewHelper.CreateDynamicQueryController(view));

            //Create the Repository class
            CreateClass(view, view.Properties[BusinessView.Name] + "Repository.cs", BusinessViewHelper.CreateDynamicQueryRepository(view));

        }

        /// <summary> Create Report Repository Classes </summary>
        /// <param name="view">Business View</param>
        private void CreateReportRepositoryClasses(BusinessView view)
        {
            // Create the Business Repository Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Entity.cs", BusinessViewHelper.CreateReportBusRepoInterface(view));

            // Create the Service Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateReportServicesInterface(view));

            // Create the Service class
            CreateClass(view, view.Properties[BusinessView.Name] + "EntityService.cs", BusinessViewHelper.CreateReportService(view));

            // Create the ViewModel class
            CreateClass(view, view.Properties[BusinessView.Name] + "ViewModel.cs", BusinessViewHelper.CreateReportViewModel(view));

            // Create the public Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "Controller.cs", BusinessViewHelper.CreateReportController(view));

            // Create the internal Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "ControllerInternal.cs", BusinessViewHelper.CreateReportInternalController(view));

            //Create the Repository class
            CreateClass(view, view.Properties[BusinessView.Name] + "Repository.cs", BusinessViewHelper.CreateReportRepository(view));

        }


        /// <summary> Create Inquiry Repository Classes </summary>
        /// <param name="view">Business View</param>
        private void CreateInquiryRepositoryClasses(BusinessView view)
        {
            // Create the Business Repository Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Entity.cs", BusinessViewHelper.CreateInquiryBusRepoInterface(view));

            // Create the Service Interface class
            CreateClass(view, "I" + view.Properties[BusinessView.Name] + "Service.cs", BusinessViewHelper.CreateInquiryServicesInterface(view));

            // Create the Service class
            CreateClass(view, view.Properties[BusinessView.Name] + "EntityService.cs", BusinessViewHelper.CreateInquiryService(view));

            // Create the ViewModel class
            CreateClass(view, view.Properties[BusinessView.Name] + "ViewModel.cs", BusinessViewHelper.CreateInquiryViewModel(view));

            // Create the Internal Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "ControllerInternal.cs", BusinessViewHelper.CreateInquiryInternalController(view));

            // Create the public Controller class
            CreateClass(view, view.Properties[BusinessView.Name] + "Controller.cs", BusinessViewHelper.CreateInquiryController(view));

            //Create the Repository class
            CreateClass(view, view.Properties[BusinessView.Name] + "Repository.cs", BusinessViewHelper.CreateInquiryRepository(view));

        }

        /// <summary>
        /// Create the Resx content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="fileName">Resx File Name</param>
        /// <param name="addDescription">True to add descriptions otherwise false</param>
        private void CreateResx(BusinessView view, string fileName, bool addDescription)
        {
            // Vars
            var folder = _settings.OutputFolder + @"\" + view.Properties[BusinessView.Name];

            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(fileName);
            }

            // Create resx file
            var resx = new ResXResourceWriter(@folder + @"\" + fileName);

            // Iterate fields collection
            foreach (var node in view.Fields.Select(field => new ResXDataNode(field.Name, addDescription ? field.Description : string.Empty)))
            {
                resx.AddResource(node);
            }

            resx.Close();

            // Update status
            LaunchStatusEvent(true, fileName);

        }


        #endregion
    }
}
