// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 

using System;
using System.Linq;
using System.Text;

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
{
    /// <summary>
    /// Static class to assist with class generation
    /// </summary>
    public static class BusinessViewHelper
    {
        #region Private Constants

        private const string At = "@";
        private const string AreaConstants = ".AreaConstants";
        private const string BusinessEntityParam = @"<param name=""entity"">Business Entity</param>";
        private const string BracketOpen = @"{";
        private const string BracketClose = @"}";
        private const string CircularBracketClose = @")";
        private const string BaseContext = @": base(context)";
        private const string BaseContextNew = @": base(context, new ";
        private const string Base = @".Base";
        private const string BusReposMapper = @".BusinessRepository.Mappers";
        private const string BusEntitySessionParam = @"<param name=""session"">Business Entity Session";
        private const string Copyright = @"Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.";
        private const string CommonInterface = @"Common.Interfaces";
        private const string CommonWeb = @"Common.Web";
        private const string CommonModels = "Common.Models";
        private const string CommonResources = "Common.Resources";
        private const string CommonServices = "Common.Services";
        private const string CommonUtilities = "Common.Utilities";
        private const string CommonBus = "Common.BusinessRepository";
        private const string ContainsList = "Contains list of {0}{1} Constants";
        private const string Comment = @"// ";
        private const string CommentRazorOpen = @"@*";
        private const string CommentRazorClose = @"*@";
        private const string ControllerInternal = "ControllerInternal";
        private const string ContextParam = @"<param name=""context"">Context</param>";
        private const string ContextParamStart = @"<param name=""context"">";
        private const string ContextMethodParam = @"(Context context)";
        private const string CatchBusExp = "catch (BusinessException businessException)";
        private const string ConstructorFor = @"Constructor for ";
        private const string Comma = ",";
        private const string DefaultColumns = "All columns have been added and must be reduced to only default columns";
        private const string DeleteToDo = @"Delete TODO statements when complete";
        private const string DivTagClose = @"</div>";
        private const string DynamicQueryFirstStringController = @"Replace first string.Empty with constant for User Preference Key (i.e. Constant.{0}WidgetId)";
        private const string DynamicQuerySecondStringController = @"Replace second string.Empty with constant for Blob Name (i.e. Constant.{0}BlobName)";
        private const string DynamicQueryThirdStringController = @"Replace third string.Empty with resx string for Widget Title (i.e. HomePage.{0})";
        private const string DynamicQueryFourthStringController = @"Replace fourth string.Empty with constant for Edit View (i.e. Widget.Edit{0}Title)";
        private const string DynamicQueryGetOne = "Generic Get routine has been added and will require filter";
        private const string DynamicQueryGetTwo = "parameters to be added based upon Dynamic Query requirements";
        private const string DynamicQueryRepositoryConstant = @"Create constants here for Filters, if any (i.e. private const string FilterTopCount = ""TopCount"";)";
        private const string DynamicQueryRepositoryQuery = @"Replace first string.Empty with key to resx file for query (i.e. ""KPI019"")";
        private const string DynamicQueryRepositoryFilter = @"Add any filters to SQL as optional parameters for validation (i.e. Execute(""KPI019"", topCount))";
        private const string DynamicQueryRepositoryFilters = @"Add any filters to Filters collection here (i.e. response.Filters.Add(FilterTopCount, topCount.ToString()))";
        private const string DynamicQueryRepositoryMap = @"Map to model here (i.e. Amount = BusinessEntity.GetValue<decimal>(Customer.Index.Amount))";
        private const string EmptyString = @"string.Empty))";
        private const string Evaluate = "The naming convention of this property has to be manually evaluated";
        private const string Field = @"""{0}""";
        private const string FinderClass = @"public class Find{0}ControllerInternal<T> : BaseFindControllerInternal<T, I{0}Service<T>>, IFinder";
        private const string GetsOrSets = "Gets or sets ";
        private const string Generated = @"[EnumValue(""Generated"", typeof(CommonResx))]";
        private const string GeneratedDisplay = @"[Display(Name = ""{0}"", ResourceType = typeof ({1}))]";
        private const string HttpPost = "[HttpPost]";
        private const string Internal = @"internal ";
        private const string IfSecurityCheck = @"if (SecurityCheck(Security.";
        private const string IdParamStart = @"<param name=""id"">Id for ";
        private const string InterfaceI = @"Interface I";
        private const string InterfaceBusRepos = @".Interfaces.BusinessRepository";
        private const string InterfaceService = @".Interfaces.Services";
        private const string JsonIControllerAdd = @"? JsonNet(ControllerInternal.Add(model))";
        private const string JsonNetViewModel = @": JsonNet(viewModel)";
        private const string JsonNetBuildErrorModel = @"JsonNet(BuildErrorModelBase(CommonResx.";
        private const string ModelsEnums = @".Models.Enums";
        private const string ModelProcess = @".Models.Process";
        private const string ModelParamStart = @"<param name=""model"">Model for ";
        private const string ModelParam = @"<param name=""model"">Model</param>";
        private const string ValueParam = @"<param name=""value"">Parameter Value</param>";
        private const string MicrosoftPracUnity = @"Microsoft.Practices.Unity";
        private const string ParenClose = @")";
        private const string Public = @"public ";
        private const string PublicClass = @"public class ";
        private const string PublicInterface = @"public interface I";
        private const string PublicOverride = @"public override ";
        private const string Private = @"private ";
        private const string Protected = @"protected ";
        private const string ProtectedOver = @"protected override ";
        private const string Process = @".Process";
        private const string Forms = @".Forms";
        private const string QuotPBracketClose = @"""/>";
        private const string ParamEnd = @"</param>";
        private const string ReturnGetView = @"return GetViewModel(data, userMessage)";
        private const string RegionNamespace = @"#region Namespace";
        private const string RegionStart = @"#region ";
        private const string RegionEnd = @"#endregion";
        private const string RegionVar = @"#region Variables";
        private const string RegionPirvateVar = @"#region Private variables";
        private const string RegionPublicVar = @"#region Public variables";
        private const string RegionConstructor = @"#region Constructor";
        private const string RegionConstants = @"#region Constants";
        private const string RegionPrivateMethods = @"#region Private methods";
        private const string RegionPublicMethods = @"#region Public methods";
        private const string RegionAbstractMethods = @"#region Abstract methods";
        private const string RegionProperties = @"#region Properties";
        private const string RegionInternalMethods = @"#region Internal methods";
        private const string RegionInternalVariables = @"#region Internal variables";
        private const string RegionInitialize = @"#region Initialize";
        private const string RequestContextParam = @"<param name=""requestContext"">Request Context</param>";
        private const string ReturnStart = @"<returns>";
        private const string ReturnStartJson = @"<returns>JSON object for ";
        private const string ReturnEnd = @"</returns>";
        private const string ReservedWord = "RESERVED";
        private const string ReplaceFirstString = @"Replace first string.Empty with Resx string (i.e. ";
        private const string EnsureGenerated = "Ensure the generated string is a valid string in the referenced resx file";
        private const string ReplaceGenerated = "Replace 'Generated' with resx string once created and 'CommonResx' with correct resx reference";
        private const string RemoveGenerated = "OR remove 'Display' attribute if not required on property";
        private const string ReplaceString = @"Replace string.Empty with Resx string (i.e. ";
        private const string Resx = @"sResx.SomeString";
        private const string ReplaceSecondString = @"Replace second string.Empty with property from model (i.e. data.";
        private const string ReplaceToDo = @"Replace TODO in LINQ Statement with property from model";
        private const string ReplaceScreenName = @"Replace ScreenName.None with screen name (i.e. ScreenName.";
        private const string ReturnJsonNet = @"return JsonNet(";
        private const string ReturnValidateModelState = @"return ValidateModelState(ModelState, out viewModel)";
        private const string SectionScripts = @"@section scripts{";
        private const string ServiceInit = @"Service = Context.Container.Resolve<I{0}Service<T>>(new ParameterOverride(Parameter, Context))";
        private const string SummaryStart = @"/// <summary>";
        private const string SummaryEnd = @"/// </summary>";
        private const string SageRoot = "Sage.CA.SBS.ERP.Sage300.";
        private const string SemiColon = @";";
        private const string SystemCollections = "System.Collections";
        private const string SystemLinq = "System.Linq";
        private const string SystemWeb = "System.Web";
        private const string ServiceT = @"Service<T>>";
        private const string TypeParamStart = @"<typeparam name=""T"">";
        private const string TypeParamStartViewModel = @"<typeparam name=""TViewModel"">";
        private const string TypeParamStartService = @"<typeparam name=""TService"">";
        private const string TypeParamEnd = @"</typeparam>";
        private const string TabOne = "\t";
        private const string TabTwo = "\t\t";
        private const string TabThree = "\t\t\t";
        private const string TabFour = "\t\t\t\t";
        private const string TabFive = "\t\t\t\t\t";
        private const string TabSix = "\t\t\t\t\t\t";
        private const string TabSeven = "\t\t\t\t\t\t\t";
        private const string Try = "try";
        private const string ToDo = "TODO: ";
        private const string UserMsgDef = @"var userMessage = new UserMessage(data";
        private const string UserAccessSecurity = @"userAccess.SecurityType |= SecurityType";
        private const string Using = "using ";
        private const string UsingSystem = "using System;";
        private const string UsingSystemCollGeneric = "using System.Collections.Generic;";
        private const string UsingDataAnnotations = "using System.ComponentModel.DataAnnotations;";
        private const string ViewModelT = @"ViewModel<T> ";
        private const string ViewModelDef = @"ViewModelBase<ModelBase> viewModel";
        private const string VarDataService = @"var data = Service.";
        private const string VitualJsonNet = @"public virtual JsonNetResult";
        private const string WhiteSpace = "";
        private const string WhereT = @"where T : ";
        private const string WhereTXML = @"Where T is type of <see cref=""";
        private const string XmlComment = @"/// ";
        private const string DataTypeFormat = "dataType = FinderConstant.{0}";
        private const string PresentationListFormat = "PresentationList = EnumUtility.GetItemsList<{0}>()";
        private const string FinderMaxLength = @"FinderConstant.CustomAttributeMaximumLength, ""{0}""";
        private const string FinderCapitalLetter = @"""class"", FinderConstant.CssClassTxtUpper";
        private const string FinderRightAlign = @"""class"", FinderConstant.CssClassInputNumberRightAlign";
        private const string FinderNumericMax = @"Value of 16 defaulted for max length. Modify as required";
        private const string FinderNumeric = "FinderConstant.CustomAtrributeFormatTextBox, FinderConstant.Numeric";
        private const string FinderAlphanumeric = "FinderConstant.CustomAtrributeFormatTextBox, FinderConstant.AlphaNumeric";
        private const string Reports = @".Reports";
        private const string ReportName = @"private const string ReportName = ""{0}""";
        private const string ProgramId = @"private const string ProgramId = ""{0}""";
        private const string MenuId = @"private const String MenuId = ""<MENU ID>""";
        private const string ReportModelParam = @"<param name=""model"">Model to be converted to report</param>";
        private const string FieldsVar = @"var {0} = SetParameter(";
        private const string FieldsId = @"{0}.Fields.{1},";
        private const string FieldsValue = @"model.{0}";
        private const string FieldsAdd = @"report.Parameters.Add({0});";
        private const string ReportParam = @"<param name=""report"">Report</param>";
        private const string IdParam = @"<param name=""id"">Parameter Field Id</param>";
        private const string ReportViewName = @"Replace string.Empty with model's view name (i.e. AgeDocument.ViewName)";
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the model content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="repositoryType">Repository Type</param>
        /// <param name="resxName">Resx Name</param>
        public static string CreateModel(BusinessView view, RepositoryType repositoryType, string resxName)
        {
            // Vars
            var builder = new StringBuilder();
            var extension = string.Empty;
            var resourceExtension = Forms;
            var application = string.Empty;
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];

            // Determine value for extension
            if (repositoryType.Equals(RepositoryType.Process))
            {
                extension = Process;
                resourceExtension = Process;
            }
            else if (repositoryType.Equals(RepositoryType.Report))
            {
                extension = Reports;
                resourceExtension = Reports;
            }

            // Determine value for application
            if (repositoryType.Equals(RepositoryType.DynamicQuery))
            {
                application = "Application";
            }

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);

            if (repositoryType.Equals(RepositoryType.DynamicQuery))
            {
                builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            }
            else
            {
                builder.AppendLine(UsingSystem);
                builder.AppendLine(UsingDataAnnotations);
                builder.AppendLine(Using + SageRoot + CommonModels + (repositoryType.Equals(RepositoryType.Report) ? extension : string.Empty) + SemiColon);
                builder.AppendLine(Using + SageRoot + CommonModels + ".Attributes" + SemiColon);
                builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
                builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
                builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + extension + SemiColon);
                builder.AppendLine(Using + SageRoot + viewModule + ".Resources" + resourceExtension + SemiColon);
            }

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Models" + extension);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Partial class for " + modelName);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + "public partial class " + modelName + " : " + application + (repositoryType.Equals(RepositoryType.Report) ? "ReportBase" : "ModelBase"));
            builder.AppendLine(TabOne + BracketOpen);

            // Iterate fields collection
            for (var i = 0; i < view.Fields.Count; i++)
            {
                // locals
                var field = view.Fields[i];
                var fieldName = field.Name;
                var annotation = string.Empty;

                // Only create if it is not RESERVED
                if (!fieldName.ToUpper().Contains(ReservedWord))
                {
                    // Naming convention is potentially invalid
                    if (CheckNamingConvention(fieldName))
                    {
                        builder.AppendLine(TabTwo + Comment + ToDo + Evaluate);
                    }

                    builder.AppendLine(TabTwo + SummaryStart);
                    builder.AppendLine(TabTwo + XmlComment + GetsOrSets + fieldName);
                    builder.AppendLine(TabTwo + SummaryEnd);

                    if (!repositoryType.Equals(RepositoryType.DynamicQuery) && !repositoryType.Equals(RepositoryType.Report))
                    {
                        // Check for Key annotation
                        annotation = KeyFieldAnnotation(field);
                        if (!annotation.Equals(string.Empty))
                        {
                            builder.AppendLine(TabTwo + annotation);
                        }

                        // Check for Required annotation
                        annotation = RequiredFieldAnnotation(field);
                        if (!annotation.Equals(string.Empty))
                        {
                            builder.AppendLine(TabTwo + annotation);
                        }

                        // Check for Stringlength annotation
                        annotation = StringLengthAnnotation(field);
                        if (!annotation.Equals(string.Empty))
                        {
                            builder.AppendLine(TabTwo + annotation);
                        }

                        // Check for DateTime annotation
                        if (field.Type.Equals(BusinessDataType.DateTime))
                        {
                            builder.AppendLine(TabTwo + ValidateDateFormatAnnotation());

                        }
                    }

                    if (!repositoryType.Equals(RepositoryType.DynamicQuery))
                    {
                        // Display attribute
                        builder.AppendLine(TabTwo + Comment + ToDo + EnsureGenerated);
                        builder.AppendLine(TabTwo + Comment + ToDo + RemoveGenerated);
                        builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
                        builder.AppendLine(TabTwo + string.Format(GeneratedDisplay, fieldName, resxName));
                    }

                    // Property
                    builder.AppendLine(TabTwo + Public +
                        (field.Type.Equals(BusinessDataType.Enumeration) ? field.Name : EnumValue.GetValue(field.Type)) +
                        " " + fieldName + " { get; set; }");
                    builder.AppendLine(WhiteSpace);

                }
            }

            if (!repositoryType.Equals(RepositoryType.DynamicQuery) && !repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(TabTwo + RegionStart + "UI Strings");
                builder.AppendLine(WhiteSpace);

                // UI access methods
                foreach (var value in view.Enums.Values)
                {
                    builder.AppendLine(TabTwo + SummaryStart);
                    builder.AppendLine(TabTwo + XmlComment + "Gets " + value.Name + " string value");
                    builder.AppendLine(TabTwo + SummaryEnd);

                    builder.AppendLine(TabTwo + Public + "string " + value.Name + "String");
                    builder.AppendLine(TabTwo + BracketOpen);
                    builder.AppendLine(TabThree + "get { return EnumUtility.GetStringValue(" + value.Name + "); }");
                    builder.AppendLine(TabTwo + BracketClose);
                    builder.AppendLine(WhiteSpace);
                }

                builder.AppendLine(TabTwo + RegionEnd);
            }

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the model mapper content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="repositoryType">Repository Type</param>
        public static string CreateModelMapper(BusinessView view, RepositoryType repositoryType)
        {
            // Vars
            var builder = new StringBuilder();
            var extension = string.Empty;
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Determine value for extension
            if (repositoryType.Equals(RepositoryType.Process))
            {
                extension = Process;
            }
            else if (repositoryType.Equals(RepositoryType.Report))
            {
                extension = Reports;
            }

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            if (repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(Using + SageRoot + CommonModels + extension + SemiColon);
            }
            builder.AppendLine(Using + SageRoot + "Common.BusinessRepository" + SemiColon);
            if (!repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            }
            if (repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            }
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + extension + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + extension + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository.Mappers" + extension);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Class for " + modelName + " mapping");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + modelName + "Mapper<T> : " + (repositoryType.Equals(RepositoryType.Report) ? "IReport" : "Model") + "Mapper<T> where T : " + modelName + ", new ()");
            builder.AppendLine(TabOne + BracketOpen);

            if (repositoryType.Equals(RepositoryType.Report))
            {
                // Private variables
                builder.AppendLine(TabTwo + RegionPirvateVar);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Current context");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + "private readonly Context _context" + SemiColon);
                builder.AppendLine(TabTwo + RegionEnd);
                builder.AppendLine(WhiteSpace);

                // Constants
                builder.AppendLine(TabTwo + RegionConstants);
                builder.AppendLine(WhiteSpace);

                // Report Name
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Default report name");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + string.Format(ReportName, view.Properties[BusinessView.ReportKey]) + SemiColon);
                builder.AppendLine(WhiteSpace);

                // Program Id
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "The program identifier");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + string.Format(ProgramId, view.Properties[BusinessView.ProgramId]) + SemiColon);
                builder.AppendLine(WhiteSpace);

                // Menu Id
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "The menu identifier");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + MenuId + SemiColon);
                builder.AppendLine(WhiteSpace);

                builder.AppendLine(TabTwo + RegionEnd);
                builder.AppendLine(WhiteSpace);
            }

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Constructor to set the Context");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + modelName + "Mapper" + ContextMethodParam);

            if (!repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(TabThree + BaseContext);
            }

            builder.AppendLine(TabTwo + BracketOpen);

            if (repositoryType.Equals(RepositoryType.Report))
            {
                builder.AppendLine(TabThree + "_context = context" + SemiColon);
            }

            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionStart + (repositoryType.Equals(RepositoryType.Report) ? "IReport" : "Model") + "Mapper methods");
            builder.AppendLine(WhiteSpace);

            if (repositoryType.Equals(RepositoryType.Report))
            {
                // Map Getter
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Map a report");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + ReportModelParam);
                builder.AppendLine(TabTwo + XmlComment + @"<returns>Mapped Report</returns>");
                builder.AppendLine(TabTwo + "public Report Map(T model)");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabThree + "var report = new Report");
                builder.AppendLine(TabThree + BracketOpen);
                builder.AppendLine(TabFour + "ProgramId = ProgramId,");
                builder.AppendLine(TabFour + "Context = _context,");
                builder.AppendLine(TabFour + "MenuId = MenuId,");
                builder.AppendLine(TabFour + "Name = ReportName");
                builder.AppendLine(TabThree + BracketClose + SemiColon);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabThree + "SetReportName(report, model)" + SemiColon);
                builder.AppendLine(WhiteSpace);

                // Iterate fields collection
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only create a mapping if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        builder.AppendLine(TabThree + string.Format(FieldsVar, fieldName.ToLower()) + string.Format(FieldsId, modelName, fieldName) + string.Format(FieldsValue, fieldName) + CircularBracketClose + SemiColon);
                        builder.AppendLine(TabThree + string.Format(FieldsAdd, fieldName.ToLower()));
                        builder.AppendLine(WhiteSpace);
                    }
                }

                builder.AppendLine(TabThree + "return report" + SemiColon);

                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);

                builder.AppendLine(TabTwo + RegionEnd);
                builder.AppendLine(WhiteSpace);

                builder.AppendLine(TabTwo + RegionPrivateMethods);
                builder.AppendLine(WhiteSpace);

                // Set Report Name
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Set report name");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + ReportParam);
                builder.AppendLine(TabTwo + XmlComment + ModelParam);
                builder.AppendLine(TabTwo + "private static void SetReportName(Report report, T model)");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabThree + "var fileName = string.IsNullOrEmpty(model.ReportName) ? string.Empty : model.ReportName" + SemiColon);
                builder.AppendLine(TabThree + @"report.Name = ReportName + ""["" + fileName + ""]""" + SemiColon);
                builder.AppendLine(TabTwo + BracketClose);

                //Get Parameter
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "To set all parameter id and values");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + IdParam);
                builder.AppendLine(TabTwo + XmlComment + ValueParam);
                builder.AppendLine(TabTwo + "private static  Parameter SetParameter(string id, string value)");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabThree + " var parameter = new Parameter { Id = id, Value = string.IsNullOrEmpty(value) ? string.Empty : value }" + SemiColon);
                builder.AppendLine(TabThree + @" return parameter" + SemiColon);
                builder.AppendLine(TabTwo + BracketClose);

                builder.AppendLine(TabTwo + RegionEnd);
            }
            else
            {
                // Map Getter
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Get Mapper");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + BusinessEntityParam);
                builder.AppendLine(TabTwo + XmlComment + @"<returns>Mapped Model</returns>");
                builder.AppendLine(TabTwo + "public override T Map(IBusinessEntity entity)");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "var model = base.Map(entity);");
                builder.AppendLine(WhiteSpace);

                // Iterate fields collection
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only create a mapping if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        // Check for an enumeration for property
                        if (field.Type.Equals(BusinessDataType.Enumeration))
                        {
                            // Developer to evaluate
                            builder.AppendLine(TabThree + Comment + ToDo + "Verify the intrinsic datatype for " + fieldName + " as string was used. Delete this line when confirmed");
                            builder.AppendLine(TabThree + "model." + fieldName + " = EnumUtility.GetEnum<" + fieldName + ">(entity.GetValue<string>(" + modelName + ".Index." + fieldName + "))" + SemiColon);
                        }
                        else
                        {
                            // Normal data type
                            builder.AppendLine(TabThree + "model." + fieldName + " = entity.GetValue<" + (field.Type.Equals(BusinessDataType.Enumeration) ? field.Name : EnumValue.GetValue(field.Type)) + ">(" + modelName + ".Index." + fieldName + ParenClose + SemiColon);
                        }
                    }
                }

                builder.AppendLine(TabThree + "return model;");
                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);

                // Map Setter
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "SetValue Mapper");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + ModelParam);
                builder.AppendLine(TabTwo + XmlComment + BusinessEntityParam);
                builder.AppendLine(TabTwo + "public override void Map(T model, IBusinessEntity entity)");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "if (model == null)");
                builder.AppendLine(TabThree + BracketOpen);
                builder.AppendLine(TabFour + "return;");
                builder.AppendLine(TabThree + BracketClose);
                builder.AppendLine(WhiteSpace);

                // Iterate fields collection
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only create a mapping if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        // Locals
                        var commentChars = (field.IsReadOnly || field.IsCalculated) ? Comment : WhiteSpace;

                        builder.AppendLine(TabThree + commentChars + "entity.SetValue(" + modelName + ".Index." + fieldName + ", model." + fieldName + ParenClose + SemiColon);
                    }
                }

                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);

                // MapKey
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Map Key");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + XmlComment + ModelParam);
                builder.AppendLine(TabTwo + XmlComment + BusinessEntityParam);

                // Determine if key exists first
                var keyFound = false;
                // Iterate fields collection
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only create if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        // Check for Key annotation
                        if (field.IsKey)
                        {
                            keyFound = true;
                            break;
                        }
                    }
                }

                // insert into XML comments if no key was found
                if (!keyFound)
                {
                    builder.AppendLine(TabTwo + XmlComment + @"<exception cref=""NotImplementedException""></exception>");
                }

                builder.AppendLine(TabTwo + "public override void MapKey(T model, IBusinessEntity entity)");
                builder.AppendLine(TabTwo + BracketOpen);

                // If key field, add keys else throw error
                if (keyFound)
                {
                    // Iterate fields collection
                    for (var i = 0; i < view.Fields.Count; i++)
                    {
                        // locals
                        var field = view.Fields[i];
                        var fieldName = field.Name;

                        // Only create if it is not RESERVED
                        if (!fieldName.ToUpper().Contains(ReservedWord))
                        {
                            // Check for Key annotation
                            if (field.IsKey)
                            {
                                builder.AppendLine(TabThree + "entity.SetValue(" + modelName + ".Index." + fieldName + ", model." + fieldName + ParenClose + SemiColon);
                            }
                        }
                    }
                }
                else
                {
                    builder.AppendLine(TabThree + "throw new NotImplementedException();");
                }

                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabTwo + RegionEnd);
            }

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the enum content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="enumHelper">Enumeration Helper</param>
        /// <param name="repositoryType">Repository Type</param>
        public static string CreateModelEnum(BusinessView view, EnumHelper enumHelper, RepositoryType repositoryType)
        {
            // Vars
            var builder = new StringBuilder();
            var extension = string.Empty;
            var viewModule = view.Properties[BusinessView.Module];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Determine value for extension
            if (repositoryType.Equals(RepositoryType.Process))
            {
                extension = Process;
            }

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ModelsEnums + extension);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Enum for " + enumHelper.Name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + "public enum " + enumHelper.Name);
            builder.AppendLine(TabOne + BracketOpen);

            // Iterate values collection
            var count = 0;
            foreach (var value in enumHelper.Values)
            {
                // Locals - Used to split out prefix and replace invalid characters
                var tmp = value.Key.Split(':');
                var valueName = Replace(tmp[1]);

                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + GetsOrSets + valueName);
                builder.AppendLine(TabTwo + SummaryEnd);

                builder.AppendLine(TabTwo + Comment + ToDo + ReplaceGenerated);
                builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
                builder.AppendLine(TabTwo + Generated);

                if (value.Value is int)
                {
                    builder.Append(TabTwo + valueName + " = " + value.Value);
                }

                if (value.Value is char)
                {
                    builder.Append(TabTwo + valueName + " = '" + value.Value + "'");
                }

                count++;
                if (count != enumHelper.Values.Count)
                {
                    builder.AppendLine(Comma);
                }

                builder.AppendLine(WhiteSpace);
            }


            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the model fields content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="repositoryType">Repository Type</param>
        /// <param name="generateDynamicEnablement">True to generate dynamic enablement routine otherwise false</param>
        public static string CreateModelFields(BusinessView view, RepositoryType repositoryType, bool generateDynamicEnablement)
        {
            // Vars
            var builder = new StringBuilder();
            var extension = string.Empty;
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var viewId = view.Properties[BusinessView.ViewId];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Determine value for extension
            if (repositoryType.Equals(RepositoryType.Process))
            {
                extension = Process;
            }
            else if (repositoryType.Equals(RepositoryType.Report))
            {
                extension = Reports;
            }

            // Namespaces
            if (generateDynamicEnablement)
            {
                builder.AppendLine(RegionNamespace);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(UsingSystemCollGeneric);
                builder.AppendLine(Using + SageRoot + CommonModels + ".Attributes" + SemiColon);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(RegionEnd);
                builder.AppendLine(WhiteSpace);
            }

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Models" + extension);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + string.Format(ContainsList, modelName, string.Empty));
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + "public partial class " + modelName);
            builder.AppendLine(TabOne + BracketOpen);

            if (!repositoryType.Equals(RepositoryType.DynamicQuery))
            {
                // View Name
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "View Name");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + "public const string ViewName = " + '\u0022' + viewId + '\u0022' + SemiColon);
                builder.AppendLine(WhiteSpace);
            }

            // Dynamic enablement
            if (generateDynamicEnablement)
            {
                // Dynamic Attributes property
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + "Dynamic Attributes contain a reverse mapping of field and property");
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + "[IgnoreExportImport]");
                builder.AppendLine(TabTwo + "public static Dictionary<string, string> DynamicAttributes");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "get");
                builder.AppendLine(TabThree + BracketOpen);
                builder.AppendLine(TabFour + "return new Dictionary<string, string>");
                builder.AppendLine(TabFour + BracketOpen);

                // Iterate fields to determine which field(s) have isDynamicEnablement
                var fieldAdded = false;
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        // Is DynamicEnablement attribute set?
                        if (field.IsDynamicEnablement)
                        {
                            // Comma logic. If a field has already been added, then append comma first
                            if (fieldAdded)
                            {
                                builder.AppendLine(Comma);
                            }

                            // Add reverse mapping
                            builder.Append(TabFive + BracketOpen + "\"" + field.ServerFieldName + "\", \"" + fieldName + "\"" + BracketClose);
                            fieldAdded = true;
                        }
                    }
                }

                // If a field was added, end the line
                if (fieldAdded)
                {
                    builder.AppendLine(string.Empty);
                }

                builder.AppendLine(TabFour + BracketClose + SemiColon);
                builder.AppendLine(TabThree + BracketClose);
                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
            }

            if (!repositoryType.Equals(RepositoryType.DynamicQuery))
            {
                // Fields Class
                builder.AppendLine(TabTwo + RegionProperties);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + string.Format(ContainsList, modelName, " Field"));
                builder.AppendLine(TabTwo + SummaryEnd);
                builder.AppendLine(TabTwo + "public class Fields");
                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(WhiteSpace);

                // Iterate fields collection
                for (var i = 0; i < view.Fields.Count; i++)
                {
                    // locals
                    var field = view.Fields[i];
                    var fieldName = field.Name;

                    // Only create if it is not RESERVED
                    if (!fieldName.ToUpper().Contains(ReservedWord))
                    {
                        // Naming convention is potentially invalid
                        if (CheckNamingConvention(fieldName))
                        {
                            builder.AppendLine(TabThree + Comment + ToDo + Evaluate);
                        }

                        // Property
                        builder.AppendLine(TabThree + SummaryStart);
                        builder.AppendLine(TabThree + XmlComment + "Property for " + fieldName);
                        builder.AppendLine(TabThree + SummaryEnd);
                        builder.AppendLine(TabThree + "public const string " + fieldName + " = \"" + field.ServerFieldName + "\";");
                        builder.AppendLine(WhiteSpace);
                    }
                }

                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
                builder.AppendLine(TabTwo + RegionEnd);
                builder.AppendLine(WhiteSpace);
            }

            // Index Class
            builder.AppendLine(TabTwo + RegionProperties);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + string.Format(ContainsList, modelName, " Index"));
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + "public class Index");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(WhiteSpace);

            // Iterate fields collection
            for (var i = 0; i < view.Fields.Count; i++)
            {
                // locals
                var field = view.Fields[i];
                var fieldName = field.Name;

                // Only create if it is not RESERVED
                if (!fieldName.ToUpper().Contains(ReservedWord))
                {
                    // Naming convention is potentially invalid
                    if (CheckNamingConvention(fieldName))
                    {
                        builder.AppendLine(TabThree + Comment + ToDo + Evaluate);
                    }

                    // Property
                    builder.AppendLine(TabThree + SummaryStart);
                    builder.AppendLine(TabThree + XmlComment + "Property Indexer for " + fieldName);
                    builder.AppendLine(TabThree + SummaryEnd);
                    builder.AppendLine(TabThree + "public const int " + fieldName + " = " + field.Id + SemiColon);
                    builder.AppendLine(WhiteSpace);
                }
            }

            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create _Index.cshtml
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateIndexHtml(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(CommentRazorOpen + Copyright + CommentRazorClose);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine(At + Using + SageRoot + CommonWeb + AreaConstants);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(At + Using + @"(Html.BeginForm(null, null, FormMethod.Post, new {id = ""frm" + name + @"""}))");
            builder.AppendLine(BracketOpen);

            // Body
            builder.AppendLine(TabOne + @"<div id=""antiforgerytoken_holder"">");
            builder.AppendLine(TabTwo + At + @"Html.AntiForgeryToken()");
            builder.AppendLine(TabOne + DivTagClose);
            builder.AppendLine(TabOne + Comment + ToDo + "Replace string.Empty with partial view string once created (i.e. AccountReceiveable." + name + "Partial)");
            builder.AppendLine(TabOne + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabOne + At + @"Html.Partial(string.Empty)");
            builder.AppendLine(BracketClose);
            builder.AppendLine(WhiteSpace);

            // Script
            builder.AppendLine(SectionScripts);
            builder.AppendLine(BracketOpen);
            builder.AppendLine(TabOne + CommentRazorOpen + ToDo
                + "Replace string.Empty with bundle string once created (i.e. ~/bundles/" + name + ")" + CommentRazorClose);
            builder.AppendLine(TabOne + CommentRazorOpen + ToDo + DeleteToDo + CommentRazorClose);
            builder.AppendLine(TabOne + "@Scripts.Render(string.Empty)");
            builder.AppendLine(BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(At + BracketOpen);
            builder.AppendLine(TabOne + "Layout = Shared.LocalizedLayout;");
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create _Localization.cshtml
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateLocalizationHtml(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(CommentRazorOpen + Copyright + CommentRazorClose);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine(At + Using + "CommonResx = " + SageRoot + CommonResources + ".CommonResx" + SemiColon);
            builder.AppendLine(At + Using + SageRoot + CommonWeb + ".HtmlHelperExtension" + SemiColon);
            builder.AppendLine(WhiteSpace);

            // Script
            builder.AppendLine(@"<script type=""text/javascript"">");

            var viewDesc = name.Substring(0, 1).ToLower() + name.Substring(1);
            builder.AppendLine(TabOne + "var " + viewDesc + "Resources =");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabTwo + "FinderTitle: '@Html.SageRaw(CommonResx.Select)'");
            builder.AppendLine(TabOne + BracketClose + SemiColon);
            builder.AppendLine("</script>");

            return builder.ToString();
        }


        #region Flat Repository
        /// <summary>
        /// Create the flat business repository interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatBusRepoInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceBusRepos);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for entity");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Entity<T> : IBusinessRepository<T>, ISecurity where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the flat services interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatServicesInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceService);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Service<T> : IEntityService<T>, ISecurityService where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the flat service content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatService(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonServices + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Services");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Service for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "EntityService<T> : FlatService<T, I" + name + "Entity<T>>, I" + name + "Service<T>");
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParamStart + "Request Context</param>");
            builder.AppendLine(TabTwo + Public + name + "EntityService" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the flat view model content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatViewModel(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemCollections + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Models");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "ViewModel for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ViewModelT + ": ViewModelBase<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(WhiteSpace);

            foreach (var value in view.Enums.Values)
            {
                var enumName = value.Name;

                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + enumName + " list");
                builder.AppendLine(TabTwo + SummaryEnd);

                var plural = PluralName(enumName);
                builder.AppendLine(TabTwo + Public + "IEnumerable " + plural);

                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "get " + BracketOpen + " return EnumUtility.GetItems<" + enumName + ">()" + SemiColon + " " + BracketClose);
                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
            }


            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the flat internal controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatInternalController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemLinq + SemiColon);
            builder.AppendLine(Using + SystemLinq + ".Expressions" + SemiColon);
            builder.AppendLine(Using + SystemCollections + ".Generic" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Resources.Forms" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Internal controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ControllerInternal + "<T> : InternalControllerBase<I" + name + ServiceT);
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Private variables
            builder.AppendLine(TabTwo + RegionPirvateVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"New instance of <see cref=""" + name + ControllerInternal + @"{T}""/>");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + ControllerInternal + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Internal methods
            builder.AppendLine(TabTwo + RegionInternalMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Create a " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Create()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "var viewModel = GetViewModel(new T(), null)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "viewModel.UserAccess = GetAccessRights()" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return viewModel" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Get a " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Get(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + VarDataService + "GetById(id)" + SemiColon);
            builder.AppendLine(TabThree + UserMsgDef + ParenClose + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + ReturnGetView + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Add a " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Add(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + VarDataService + "Add(model)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceFirstString + name + Resx + ParenClose);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceSecondString + modelName + ParenClose);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + UserMsgDef + Comma);
            builder.AppendLine(TabFour + @"string.Format(CommonResx.AddSuccessMessage, string.Empty, string.Empty))" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + ReturnGetView + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Update a " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Save(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + VarDataService + "Save(model)" + SemiColon);
            builder.AppendLine(TabThree + UserMsgDef + ", CommonResx.SaveSuccessMessage)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + ReturnGetView + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Delete a " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Delete(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceToDo);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "Expression<Func<T, bool>> filter = param => param.TODO == id" + SemiColon);
            builder.AppendLine(TabThree + VarDataService + "Delete(filter)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceFirstString + name + Resx + ParenClose);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceSecondString + modelName + ParenClose);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + UserMsgDef + Comma);
            builder.AppendLine(TabFour + "string.Format(CommonResx.DeleteSuccessMessage, string.Empty, string.Empty));");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + ReturnGetView + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Private methods
            builder.AppendLine(TabTwo + RegionPrivateMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Generic routine to return a view model for " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""userMessage"">User Message for " + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>View Model for " + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Private + name + ViewModelT + "GetViewModel(T model, UserMessage userMessage)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + @"return new " + modelName + @"CodeViewModel<T>");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"Data = model,");
            builder.AppendLine(TabFour + @"UserMessage = userMessage");
            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the flat public controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SystemWeb + ".Mvc" + SemiColon);
            builder.AppendLine(Using + SageRoot + "Common.Exceptions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Resources.Forms" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Public controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Controller<T> : MultitenantControllerBase<" + name + "ViewModel<T>>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Public variables
            builder.AppendLine(TabTwo + RegionPublicVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Gets or sets the internal controller");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Public + name + ControllerInternal + @"<T> " + ControllerInternal + @" { get; set; }");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Constructor for " + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""container"">Unity Container</param>");
            builder.AppendLine(TabTwo + Public + name + "Controller(IUnityContainer container)");
            builder.AppendLine(TabThree + @": base(container," + "\"" + viewModule + name + "\")");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Internal methods
            builder.AppendLine(TabTwo + RegionStart + "Initialize MultitenantControllerBase");
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Override Initialize method");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""requestContext"">Request Context</param>");
            builder.AppendLine(TabTwo + @"protected override void Initialize(System.Web.Routing.RequestContext requestContext)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "base.Initialize(requestContext)" + SemiColon);
            builder.AppendLine(TabThree + ControllerInternal + " = new " + name + ControllerInternal + @"<T>(Context)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Public methods
            builder.AppendLine(TabTwo + RegionPublicMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Load screen");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + @"public virtual ActionResult Index(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + name + ViewModelT + " viewModel" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"viewModel = !string.IsNullOrEmpty(id) ? " + ControllerInternal + @".GetById(id) : " + ControllerInternal + ".Create()" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "GetFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return View(viewModel)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Get " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Get(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "if (!string.IsNullOrEmpty(id))");
            builder.AppendLine(TabFour + BracketOpen);
            builder.AppendLine(TabFive + ReturnJsonNet + ControllerInternal + ".Get(id))" + SemiColon);
            builder.AppendLine(TabFour + BracketClose);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "GetFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + ReturnJsonNet + "new " + name + @"ViewModel<T>())" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Add " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Add(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + ViewModelDef + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabFour + ReturnValidateModelState);
            builder.AppendLine(TabFive + JsonIControllerAdd);
            builder.AppendLine(TabFive + JsonNetViewModel + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "AddFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Create " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Create()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + ReturnJsonNet + ControllerInternal + @".Create());");
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Update " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Save(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + ViewModelDef + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabFour + ReturnValidateModelState);
            builder.AppendLine(TabFive + JsonIControllerAdd);
            builder.AppendLine(TabFive + JsonNetViewModel + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + ReturnJsonNet + "BuildErrorModelBase(CommonResx.SaveFailedMessage, businessException))" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Delete " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Delete(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + ReturnJsonNet + ControllerInternal + ".Delete(id))" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "DeleteFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the module security constant class
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateSecurityConstantClass(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var viewModule = view.Properties[BusinessView.Module];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository");

            // Constant Class
            builder.AppendLine(BracketOpen);
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + viewModule + " module security constants");
            builder.AppendLine(TabOne + SummaryEnd);

            builder.AppendLine(TabOne + PublicClass + "Security");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + viewModule + " Import");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + "public const string " + viewModule + "Import = " + '\u0022' + viewModule + "Import" + '\u0022' + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + viewModule + " Export");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + "public const string " + viewModule + "Export = " + '\u0022' + viewModule + "Export" + '\u0022' + SemiColon);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);
            return builder.ToString();

        }

        /// <summary>
        /// Create the flat Repository content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateFlatRepository(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemLinq + ".Expressions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonUtilities + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + BusReposMapper + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Repository Class for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Repository<T> : FlatRepository<T>, I" + name + "Entity<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //private variables
            builder.AppendLine(TabTwo + RegionVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Mapper");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "ModelMapper<T> _mapper" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Business Entity");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "IBusinessEntity _businessEntity" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "Repository" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContextNew + modelName + @"Mapper<T>(context), ActiveFilter)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "SetFilter(context);");
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + XmlComment + BusEntitySessionParam + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context, IBusinessEntitySession session)");
            builder.AppendLine(TabThree + BaseContextNew + modelName + "Mapper<T>(context), ActiveFilter, session)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "SetFilter(context);");
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Protected/Public methods
            builder.AppendLine(TabTwo + RegionStart + "Protected/public methods");
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Additional Access Check for Export and Import");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>User Access" + ReturnEnd);
            builder.AppendLine(TabTwo + PublicOverride + "UserAccess GetAccessRights()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "var userAccess = base.GetAccessRights()" + SemiColon);
            builder.AppendLine(TabThree + IfSecurityCheck + viewModule + "Import))");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + UserAccessSecurity + ".Import" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + IfSecurityCheck + viewModule + "Export))");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + UserAccessSecurity + ".Export" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + "return userAccess" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Create entities for repository");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>Business Entity" + ReturnEnd);
            builder.AppendLine(TabTwo + ProtectedOver + "IBusinessEntity CreateBusinessEntities()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "CreateBusinessEntitiesInternal()" + SemiColon);
            builder.AppendLine(TabThree + "return _businessEntity" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Get Update Expression");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>Expression" + ReturnEnd);
            builder.AppendLine(TabTwo + ProtectedOver + "Expression<Func<T, bool>> GetUpdateExpression(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + ToDo + "Replace TODO in LINQ Statement with property from entity and model");
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "return entity => entity.TODO.StartsWith(model.TODO)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Private methods
            builder.AppendLine(TabTwo + RegionPrivateMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"ActiveFilter Condition");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<value>The active filter</value>");
            builder.AppendLine(TabTwo + Private + "static Expression<Func<T, bool>> ActiveFilter");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "get { return null; }");
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Creates the business entities");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "void CreateBusinessEntitiesInternal()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "_businessEntity = OpenEntity(" + modelName + ".EntityName)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Set Filter");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Private + "void SetFilter" + ContextMethodParam);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "ValidRecordFilter = null" + SemiColon);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceToDo);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "ValidRecordFilter = model => !string.IsNullOrEmpty(model.TODO)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + @"_mapper = new " + modelName + @"Mapper<T>(context)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }


        #endregion

        #region Process Repository

        /// <summary>
        /// Create the process business repository interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessBusRepoInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceBusRepos + Process);
            builder.AppendLine(BracketOpen);

            // interface
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + InterfaceI + name + "Entity");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicInterface + name + "Entity<T> : IProcessingRepository<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process service interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessServicesInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + Process + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceService + Process);
            builder.AppendLine(BracketOpen);

            //interface
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + InterfaceI + name + "Service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicInterface + name + "Service<T> : IProcessService<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process Service content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessService(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + @".Repository.Base" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + @".Enums.Process" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonServices + Process + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Services.Process");
            builder.AppendLine(BracketOpen);

            //interface
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + @"Class for " + name + "Service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Service<T> : ProcessService<T, I" + name + @"Entity<T>>,");
            builder.AppendLine(TabTwo + @"I" + name + @"Service<T> " + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParamStart + "Request Context</param>");
            builder.AppendLine(TabTwo + Comment + ToDo + @"Replace WorkFlowKind.None with work flow kind (i.e. WorkFlowKind." + name + ParenClose);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + Public + name + "Service" + ContextMethodParam);
            builder.AppendLine(TabThree + @": base(context, WorkFlowKind.None)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process ViewModel content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessViewModel(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SystemCollections + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ModelProcess + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Models.Process");
            builder.AppendLine(BracketOpen);

            //interface
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + name + "ViewModel class");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ViewModelT + ": ProcessViewModel<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(WhiteSpace);

            foreach (var value in view.Enums.Values)
            {
                var enumName = value.Name;

                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + enumName + " list");
                builder.AppendLine(TabTwo + SummaryEnd);

                var plural = PluralName(enumName);
                builder.AppendLine(TabTwo + Public + "IEnumerable " + plural);

                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "get " + BracketOpen + " return EnumUtility.GetItems<" + enumName + ">()" + SemiColon + " " + BracketClose);
                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
            }

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process internal controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessInternalController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web" + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Controllers.Process" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers.Process");
            builder.AppendLine(BracketOpen);

            //Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + name + " " + "Internal Controller");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ControllerInternal + "<T> :");
            builder.AppendLine(TabTwo + "ProcessControllerInternal<T, " + name + ViewModelT + ", I" + name + ServiceT);
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + XmlComment + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + XmlComment + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + ControllerInternal + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process public controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models.Process" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Controllers.Process" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers.Process");
            builder.AppendLine(BracketOpen);

            //Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Class " + name + " Controller");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Controller<T> :");
            builder.AppendLine(TabTwo + "ProcessController<T, " + name + ViewModelT + Comma + " " +
                               name + ControllerInternal + "<T>, I" + name + ServiceT);
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""container"">Unity container" + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Controller(IUnityContainer container)");
            builder.AppendLine(TabThree + @": base(");
            builder.AppendLine(TabFour + @"container,");
            builder.AppendLine(TabFour + @"(context =>new " + name + ControllerInternal + "<T>(context)),");
            builder.AppendLine(TabFour + "\"" + viewModule + name + "\"" + ParenClose);

            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the process repository content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateProcessRepository(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + BusReposMapper + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelProcess + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository.Process");
            builder.AppendLine(BracketOpen);

            //Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Class " + name + " Repository");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + WhereTXML + modelName + QuotPBracketClose + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Repository<T> : ProcessingRepository<T>,");
            builder.AppendLine(TabTwo + "I" + name + "Entity<T> " + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Business Entity
            builder.AppendLine(TabTwo + RegionStart + "Business Entity");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Business Entity");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "IBusinessEntity _businessEntity" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context)");
            builder.AppendLine(TabThree + BaseContextNew + modelName + @"Mapper<T>(context))");

            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + XmlComment + BusEntitySessionParam + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context, IBusinessEntitySession session)");
            builder.AppendLine(TabThree + BaseContextNew + modelName + @"Mapper<T>(context), session)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Abstract methods
            builder.AppendLine(TabTwo + RegionStart + " Abstract methods");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Create Business Entity");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + "<returns>IBusinessEntity" + ReturnEnd);
            builder.AppendLine(TabTwo + Protected + "override IBusinessEntity CreateBusinessEntities()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "_businessEntity = OpenEntity(" + modelName + ".ViewName)" + SemiColon);
            builder.AppendLine(TabThree + "return _businessEntity" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }


        #endregion

        #region DynamicQuery Repository

        /// <summary>
        /// Create the dynamic query business repository interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryBusRepoInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceBusRepos);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for entity");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Entity<T> : IDynamicQueryRepository<T>, ISecurity where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + @"DynamicQueryEnumerableResponse<T> Get()" + SemiColon);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the dynamic query services interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryServicesInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceService);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Service<T> : IDynamicQueryEntityService<T>, ISecurityService where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + @"DynamicQueryEnumerableResponse<T> Get()" + SemiColon);
            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the dynamic query service content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryService(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonServices + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Services");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Service for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "EntityService<T> : DynamicQueryService<T, I" + name + "Entity<T>>, I" + name + "Service<T>");
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParamStart + "Request Context</param>");
            builder.AppendLine(TabTwo + Public + name + "EntityService" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // IDynamicQueryEntityService
            builder.AppendLine(TabTwo + RegionStart + "IDynamicQueryEntityService");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + Public + @"DynamicQueryEnumerableResponse<T> Get()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + @"using (var repository = Resolve<I" + name + @"Entity<T>>())");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "return repository.Get()" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the dynamic query view model content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryViewModel(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Models");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "ViewModel for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ViewModelT + ": DynamicQueryViewModel<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the dynamic query public controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SystemWeb + ".Mvc" + SemiColon);
            builder.AppendLine(Using + SystemWeb + ".Routing" + SemiColon);
            builder.AppendLine(Using + SystemWeb + ".SessionState" + SemiColon);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SageRoot + "Common.Exceptions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonUtilities + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + AreaConstants + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + ".Portal" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models.Preference" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Controllers.Base" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Constants" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Public controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"[SessionState(SessionStateBehavior.ReadOnly)]");
            builder.AppendLine(TabOne + PublicClass + name + "Controller<T> : DynamicQueryController<" + name + "ViewModel<T>, WidgetConfiguration, T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Internal variables
            builder.AppendLine(TabTwo + RegionInternalVariables);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Service class");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Internal + "I" + name + "Service" + @"<T> Service" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Constructor for " + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""container"">Unity Container</param>");
            builder.AppendLine(TabTwo + Public + name + "Controller(IUnityContainer container)");
            builder.AppendLine(TabThree + @": base(container," + "\"" + viewModule + name + "\")");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Initialize
            builder.AppendLine(TabTwo + RegionInitialize);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Override Initialize method");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + RequestContextParam);
            builder.AppendLine(TabTwo + Protected + "override void Initialize(RequestContext requestContext)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + "Base initializations");
            builder.AppendLine(TabThree + "base.Initialize(requestContext)" + SemiColon);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabThree + Comment + "Additional initializations");
            builder.AppendLine(TabThree + Comment + ToDo + string.Format(DynamicQueryFirstStringController, name));
            builder.AppendLine(TabThree + Comment + ToDo + string.Format(DynamicQuerySecondStringController, name));
            builder.AppendLine(TabThree + Comment + ToDo + string.Format(DynamicQueryThirdStringController, name));
            builder.AppendLine(TabThree + Comment + ToDo + string.Format(DynamicQueryFourthStringController, name));
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "AdditionalInitializations(string.Empty,");
            builder.AppendLine(TabFour + "string.Empty, string.Empty,");
            builder.AppendLine(TabFour + "string.Empty)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Comment + "Service initialization");
            builder.AppendLine(TabThree + string.Format(ServiceInit, name) + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Public methods
            builder.AppendLine(TabTwo + RegionPublicMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Public + "ActionResult Index()");
            builder.AppendLine(TabTwo + BracketOpen);

            builder.AppendLine(TabThree + "try");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "var model = new " + name + @"ViewModel<T>");
            builder.AppendLine(TabFour + BracketOpen);
            builder.AppendLine(TabFive + "UserAccess = new UserAccess(),");
            builder.AppendLine(TabFive + "UserMessage = new UserMessage(),");
            builder.AppendLine(TabFive + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabFive + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabFive + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFive + "Data = Get(),");
            builder.AppendLine(TabFive + "WidgetName = GetWidgetTitle()");
            builder.AppendLine(TabFour + BracketClose + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabFour + "return View(model)" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + "catch (BusinessException businessException)");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabThree + "return JsonNet(BuildErrorModelKPI(CommonResx.GetFailedMessage, businessException, CommonResx.DynamicQuery))" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Private methods
            builder.AppendLine(TabTwo + RegionPrivateMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + Private + @"DynamicQueryEnumerableResponse<T> Get()");
            builder.AppendLine(TabTwo + BracketOpen);

            builder.AppendLine(TabThree + Comment + "Init return");
            builder.AppendLine(TabThree + @"DynamicQueryEnumerableResponse<T> response" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Comment + "Determine if cached (get from cache) or not (get it then cache it)");
            builder.AppendLine(TabThree + "if (CommonService.IsBlobValid(BlobName))");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"var jsonModel = CommonService.PullTextFromCache(BlobName)" + SemiColon);
            builder.AppendLine(TabFour + @"response = JsonSerializer.Deserialize<DynamicQueryEnumerableResponse<T>>(jsonModel)" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + "else");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"response = Service.Get()" + SemiColon);
            builder.AppendLine(TabFour + @"CommonService.PushTextInToCache(BlobName, JsonSerializer.Serialize(response))" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return response" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the dynamic query Repository content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateDynamicQueryRepository(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SystemCollections + ".Generic" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Repository Class for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Repository<T> : DynamicQueryRepository<T>, I" + name + "Entity<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constants
            builder.AppendLine(TabTwo + RegionConstants);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryRepositoryConstant);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "Repository" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + XmlComment + BusEntitySessionParam + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context, IBusinessEntitySession session)");
            builder.AppendLine(TabThree + ": base(context, session)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Public methods
            builder.AppendLine(TabTwo + RegionPublicMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Gets " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetOne);
            builder.AppendLine(TabTwo + Comment + ToDo + DynamicQueryGetTwo);
            builder.AppendLine(TabTwo + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + Public + @"DynamicQueryEnumerableResponse<T> Get()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment +
                               "Init and execute query in base class (check rights, validate args, init business entity, map data) and store filters");
            builder.AppendLine(TabThree + Comment + ToDo + DynamicQueryRepositoryQuery);
            builder.AppendLine(TabThree + Comment + ToDo + DynamicQueryRepositoryFilter);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "var response = Execute(string.Empty)" + SemiColon);
            builder.AppendLine(TabThree + Comment + ToDo + DynamicQueryRepositoryFilters);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return response" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Abstract methods
            builder.AppendLine(TabTwo + RegionAbstractMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Map the data");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "DynamicQueryEnumerableResponse" + ReturnEnd);
            builder.AppendLine(TabTwo + Protected + @"override DynamicQueryEnumerableResponse<T> Map()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + "Init response and items for mapping");
            builder.AppendLine(TabThree + @"var response = new DynamicQueryEnumerableResponse<T>()" + SemiColon);
            builder.AppendLine(TabThree + @"var items = new List<T>()" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Comment + "Iterate results of query");
            builder.AppendLine(TabThree + @"while (BusinessEntity.Fetch(false))");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "var model = new T");
            builder.AppendLine(TabFour + BracketOpen);
            builder.AppendLine(TabFive + Comment + ToDo + DynamicQueryRepositoryMap);
            builder.AppendLine(TabFive + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + BracketClose + SemiColon);
            builder.AppendLine(TabFour + "items.Add(model)" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "response.Items = items" + SemiColon);
            builder.AppendLine(TabThree + "return response" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        #endregion

        #region Report Repository


        /// <summary>
        /// Create the report business repository interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportBusRepoInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceBusRepos + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for entity");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Entity<T> : IReportRepository<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report services interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportServicesInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceService + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Service<T> : IReportService<T>, ISecurityService where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report service content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportService(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonServices + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Services" + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Service for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Service<T> : BaseReportService<T, I" + name + "Entity<T>>, I" + name + "Service<T>");
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParamStart + "Request Context</param>");
            builder.AppendLine(TabTwo + Public + name + "Service" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report view model content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportViewModel(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SystemCollections + SemiColon);
            builder.AppendLine(UsingSystemCollGeneric);
            builder.AppendLine(Using + SystemLinq + SemiColon);
            builder.AppendLine(UsingDataAnnotations);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models.Enums" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Models" + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "ViewModel for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ViewModelT + ": ReportViewModel<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report public controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Controllers" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers" + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Public controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Controller<T> : ReportController<T, " + name + "ViewModel<T>, ");
            builder.AppendLine(TabTwo + name + "ControllerInternal<T, " + name + "ViewModel<T>, I" + name + "Service<T>>, ");
            builder.AppendLine(TabTwo + "I" + name + "Service<T>> " + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Constructor for " + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""container"">Unity Container</param>");
            builder.AppendLine(TabTwo + Public + name + "Controller(IUnityContainer container)");
            builder.AppendLine(TabThree + @": base(container, context => new " + name + "ControllerInternal<T, " + name + "ViewModel<T>,");
            builder.AppendLine(TabFour + @"I" + name + "Service<T>>(context)," + "\"" + viewModule + name + "\")");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report internal controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportInternalController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem + SemiColon);
            builder.AppendLine(UsingSystemCollGeneric + SemiColon);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service.Base" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + Process + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Controllers" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers" + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Internal controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStartViewModel + name + "ViewModel" + TypeParamEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStartService + "I" + name + "Service" + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "ControllerInternal<T, TViewModel, TService> :");
            builder.AppendLine(TabTwo + "ReportControllerInternal<T, TViewModel, TService>");
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabTwo + "where TViewModel : " + name + "ViewModel<T>, new()");
            builder.AppendLine(TabTwo + "where TService : I" + name + "Service<T>");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Constructor for " + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "ControllerInternal(Context context)");
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the report Repository content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateReportRepository(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SageRoot + CommonBus + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + BusReposMapper + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + Reports + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + Reports + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository" + Reports);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Repository Class for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Repository<T> : BaseReportRepository<T>, I" + name + "Entity<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Private variables
            builder.AppendLine(TabTwo + RegionVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Business Entity");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "IBusinessEntity _businessEntity" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "Repository" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContextNew + modelName + @"Mapper<T>(context), " + modelName + ".ViewName)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + XmlComment + BusEntitySessionParam + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context, IBusinessEntitySession session)");
            builder.AppendLine(TabThree + BaseContextNew + modelName + "Mapper<T>(context), session)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Abstract methods
            builder.AppendLine(TabTwo + RegionAbstractMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Execute the report");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>GUID - Cache Token" + ReturnEnd);
            builder.AppendLine(TabTwo + PublicOverride + "Guid Execute(T model)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "CreateBusinessEntities()" + SemiColon);
            builder.AppendLine(TabThree + "CheckRights(_businessEntity, SecurityType.Inquire)" + SemiColon);
            builder.AppendLine(TabThree + "return base.Execute(model)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Get default model values");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""applyUserPreferences"">True to return user preferences otherwise false</param>");
            builder.AppendLine(TabTwo + XmlComment + @"<returns>" + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + PublicOverride + "T Get(bool applyUserPreferences = true)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "CreateBusinessEntities()" + SemiColon);
            builder.AppendLine(TabThree + "CheckRights(_businessEntity, SecurityType.Inquire)" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "if (applyUserPreferences)");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "return GetUserPreference()" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "var model = new T");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return model" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Create business entities");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>IBusinessEntity" + ReturnEnd);
            builder.AppendLine(TabTwo + ProtectedOver + "IBusinessEntity CreateBusinessEntities()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + ToDo + ReportViewName);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabTwo + "_businessEntity = OpenEntity(string.Empty)" + SemiColon);
            builder.AppendLine(TabTwo + "return _businessEntity" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        #endregion

        #region Inquiry Repository

        /// <summary>
        /// Create the inquiry business repository interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryBusRepoInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceBusRepos);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for entity");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Entity<T> : IInquiryRepository<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry services interface content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryServicesInterface(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Service" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + InterfaceService);
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Interface for service");
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + @"public interface I" + name + "Service<T> : IInquiryService<T>, ISecurityService where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry service content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryService(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonServices + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Services");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Service for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "EntityService<T> : InquiryService<T, I" + name + "Entity<T>>, I" + name + "Service<T>");
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParamStart + "Request Context</param>");
            builder.AppendLine(TabTwo + Public + name + "EntityService" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry view model content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryViewModel(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemCollections + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Models");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "ViewModel for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ViewModelT + ": ViewModelBase<T> where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);
            builder.AppendLine(WhiteSpace);

            foreach (var value in view.Enums.Values)
            {
                var enumName = value.Name;

                builder.AppendLine(TabTwo + SummaryStart);
                builder.AppendLine(TabTwo + XmlComment + enumName + " list");
                builder.AppendLine(TabTwo + SummaryEnd);

                var plural = PluralName(enumName);
                builder.AppendLine(TabTwo + Public + "IEnumerable " + plural);

                builder.AppendLine(TabTwo + BracketOpen);
                builder.AppendLine(TabThree + "get " + BracketOpen + " return EnumUtility.GetItems<" + enumName + ">()" + SemiColon + " " + BracketClose);
                builder.AppendLine(TabTwo + BracketClose);
                builder.AppendLine(WhiteSpace);
            }


            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry internal controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryInternalController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemLinq + SemiColon);
            builder.AppendLine(Using + SystemLinq + ".Expressions" + SemiColon);
            builder.AppendLine(Using + SystemCollections + ".Generic" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Resources.Forms" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Internal controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + ControllerInternal + "<T> : InternalControllerBase<I" + name + ServiceT);
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Private variables
            builder.AppendLine(TabTwo + RegionPirvateVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"New instance of <see cref=""" + name + ControllerInternal + @"{T}""/>");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + ControllerInternal + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Internal methods
            builder.AppendLine(TabTwo + RegionInternalMethods);
            builder.AppendLine(WhiteSpace);


            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Generic routine to return a view model for " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>View Model for " + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Get()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + @"return new " + modelName + @"CodeViewModel<T>");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"Data = Service.Get(),");
            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);


            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Generic routine to return a view model for " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""pageNumber"">Page Number " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""pageSize"">Page Size " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""filters"">Filter Expression " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<returns>View Model for " + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Internal + name + ViewModelT + "Get(T model, int pageNumber, int pageSize, IList<IList<IList<Filter>>> filters)");
            builder.AppendLine(TabTwo + BracketOpen);

            builder.AppendLine(TabThree + "var pageOptions = new PageOptions<T>");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + "PageNumber = pageNumber,");
            builder.AppendLine(TabFour + "PageSize = pageSize,");
            builder.AppendLine(TabFour + "Filter = filter");
            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "var dataItems = Service.Get(model, pageOptions)");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + @"return new " + modelName + @"CodeViewModel<T>");
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"DataList = dataItems.Items,");
            builder.AppendLine(TabFour + @"TotalResultsCount = dataItems.TotalResultsCount");
            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry public controller content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryController(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(Using + MicrosoftPracUnity + SemiColon);
            builder.AppendLine(Using + SystemWeb + ".Mvc" + SemiColon);
            builder.AppendLine(Using + SageRoot + "Common.Exceptions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Resources.Forms" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Web.Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Public controller for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Controller<T> : MultitenantControllerBase<" + name + "ViewModel<T>>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //Public variables
            builder.AppendLine(TabTwo + RegionPublicVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Gets or sets the internal controller");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Public + name + ControllerInternal + @"<T> " + ControllerInternal + @" { get; set; }");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Constructor for " + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""container"">Unity Container</param>");
            builder.AppendLine(TabTwo + Public + name + "Controller(IUnityContainer container)");
            builder.AppendLine(TabThree + @": base(container, " + "\"" + viewModule + name + "\")");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Internal methods
            builder.AppendLine(TabTwo + RegionStart + "Initialize MultitenantControllerBase");
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Override Initialize method");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""requestContext"">Request Context</param>");
            builder.AppendLine(TabTwo + @"protected override void Initialize(System.Web.Routing.RequestContext requestContext)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "base.Initialize(requestContext)" + SemiColon);
            builder.AppendLine(TabThree + ControllerInternal + " = new " + name + ControllerInternal + @"<T>(Context)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Public methods
            builder.AppendLine(TabTwo + RegionPublicMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Load screen");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + @"public virtual ActionResult Index()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + name + ViewModelT + " viewModel" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + @"viewModel = " + ControllerInternal + ".Get()");
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "GetFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + "return View(viewModel)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"Get " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ModelParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""pageNumber"">Page Number " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""pageSize"">Page Size " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<param name=""filters"">Filter Expression " + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStartJson + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + HttpPost);
            builder.AppendLine(TabTwo + VitualJsonNet + " Get(T model, int pageNumber, int pageSize, IList<IList<IList<Filter>>> filters)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Try);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + BracketOpen);
            builder.AppendLine(TabFive + ReturnJsonNet + ControllerInternal + ".Get(model, pageNumber, pageSize, filters))" + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(TabThree + CatchBusExp);
            builder.AppendLine(TabThree + BracketOpen);
            builder.AppendLine(TabFour + Comment + ToDo + ReplaceString + name + Resx + ParenClose);
            builder.AppendLine(TabFour + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabFour + "return");
            builder.AppendLine(TabFive + JsonNetBuildErrorModel + "GetFailedMessage, businessException,");
            builder.AppendLine(TabSix + EmptyString + SemiColon);
            builder.AppendLine(TabThree + BracketClose);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Create the inquiry Repository content
        /// </summary>
        /// <param name="view">Business View</param>
        public static string CreateInquiryRepository(BusinessView view)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(UsingSystem);
            builder.AppendLine(Using + SystemLinq + ".Expressions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonBus + Base + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Entity" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonUtilities + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + ".Enums" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + BusReposMapper + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceBusRepos + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".BusinessRepository");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Repository Class for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + PublicClass + name + "Repository<T> : InquiryRepository<T>, I" + name + "Entity<T>");
            builder.AppendLine(TabTwo + WhereT + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            //private variables
            builder.AppendLine(TabTwo + RegionVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Mapper");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "ModelMapper<T> _mapper" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Business Entity");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + Private + "IBusinessEntity _businessEntity" + SemiColon);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + name + "Repository" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContextNew + modelName + @"Mapper<T>(context), ActiveFilter)");
            builder.AppendLine(TabTwo + BracketOpen);

            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + XmlComment + BusEntitySessionParam + ParamEnd);
            builder.AppendLine(TabTwo + Public + name + "Repository(Context context, IBusinessEntitySession session)");
            builder.AppendLine(TabThree + BaseContextNew + modelName + "Mapper<T>(context), ActiveFilter, session)");
            builder.AppendLine(TabTwo + BracketOpen);

            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Protected/Public methods
            builder.AppendLine(TabTwo + RegionStart + "Protected/public methods");
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabThree + Comment + ToDo + "Override the below base method if required.");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabFour + Comment + ToDo + "public override EnumerableResponse<T> Get(PageOptions<T> pageOptions)");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabFour + Comment + ToDo + "public override EnumerableResponse<T> Get(T model, PageOptions<T> pageOptions)");
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            //Private methods
            builder.AppendLine(TabTwo + RegionPrivateMethods);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + @"ActiveFilter Condition");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + @"<value>The active filter</value>");
            builder.AppendLine(TabTwo + Private + "static Expression<Func<T, bool>> ActiveFilter");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + "get { return null; }");
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }


        #endregion


        /// <summary>
        /// Create the finder content
        /// </summary>
        /// <param name="view">Business View</param>
        /// <param name="resxName">Resx Name</param>
        public static string CreateFinder(BusinessView view, string resxName)
        {
            // Vars
            var builder = new StringBuilder();
            var modelName = view.Properties[BusinessView.ModelName];
            var viewModule = view.Properties[BusinessView.Module];
            var name = view.Properties[BusinessView.Name];

            // Copyright
            builder.AppendLine(Comment + Copyright);
            builder.AppendLine(WhiteSpace);

            // Namespaces
            builder.AppendLine(RegionNamespace);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(UsingSystem);
            builder.AppendLine(UsingSystemCollGeneric);
            builder.AppendLine(Using + SystemLinq + SemiColon);
            builder.AppendLine(Using + SystemLinq + ".Expressions" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonResources + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonInterface + ".Repository" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonModels + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Controllers.Finders" + SemiColon);
            builder.AppendLine(Using + SageRoot + CommonWeb + ".Utilities" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + InterfaceService + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ".Models" + SemiColon);
            builder.AppendLine(Using + SageRoot + viewModule + ModelsEnums + SemiColon);

            builder.AppendLine(WhiteSpace);
            builder.AppendLine(RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Namespace for file
            builder.AppendLine("namespace " + SageRoot + viewModule + ".Web.Controllers.Finder");
            builder.AppendLine(BracketOpen);

            // Class
            builder.AppendLine(TabOne + SummaryStart);
            builder.AppendLine(TabOne + XmlComment + "Finder class for " + name);
            builder.AppendLine(TabOne + SummaryEnd);
            builder.AppendLine(TabOne + XmlComment + TypeParamStart + modelName + TypeParamEnd);
            builder.AppendLine(TabOne + string.Format(FinderClass, name));
            builder.AppendLine(TabTwo + "where T : " + modelName + ", new()");
            builder.AppendLine(TabOne + BracketOpen);

            // Private variables region
            builder.AppendLine(TabTwo + RegionPirvateVar);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Constructor
            builder.AppendLine(TabTwo + RegionConstructor);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + ConstructorFor + name);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ContextParam);
            builder.AppendLine(TabTwo + Public + "Find" + name + "ControllerInternal" + ContextMethodParam);
            builder.AppendLine(TabThree + BaseContext);
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            // Public methods
            builder.AppendLine(TabTwo + RegionPublicMethods);
            builder.AppendLine(WhiteSpace);

            // Get method
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Get first or default " + modelName);
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + IdParamStart + modelName + ParamEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "Get first or default " + modelName + ReturnEnd);
            builder.AppendLine(TabTwo + Public + "virtual ModelBase Get(string id)");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + ToDo + ReplaceToDo);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.AppendLine(TabThree + "Expression<Func<T, bool>> filter = param => param.TODO == id" + SemiColon);
            builder.AppendLine(TabThree + "return Service.FirstOrDefault(filter)" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            // GetDefaultColumns method
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Get the default columns");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "Default columns" + ReturnEnd);
            builder.AppendLine(TabTwo + PublicOverride + @"List<string> GetDefaultColumns()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(TabThree + Comment + ToDo + DefaultColumns);
            builder.AppendLine(TabThree + Comment + ToDo + DeleteToDo);
            builder.Append(TabThree + "return new List<string> " + BracketOpen);

            // Iterate fields collection
            var fieldAdded = false;
            for (var i = 0; i < view.Fields.Count; i++)
            {
                // locals
                var field = view.Fields[i];
                var fieldName = field.Name;

                // Only add if it is not RESERVED
                if (!fieldName.ToUpper().Contains(ReservedWord))
                {
                    // Comma logic. If a field has already been added, then append comma first
                    if (fieldAdded)
                    {
                        builder.Append(Comma + " ");
                    }

                    // Only enter 4 fields per line
                    if ((i > 0) && (i % 4).Equals(0))
                    {
                        builder.AppendLine(string.Empty);
                        builder.Append(TabFour);
                    }

                    builder.Append(string.Format(Field, fieldName + (field.Type.Equals(BusinessDataType.Enumeration) ? "String" : string.Empty)));
                    fieldAdded = true;
                }
            }

            builder.AppendLine(" " + BracketClose + SemiColon);

            builder.AppendLine(TabTwo + BracketClose);
            builder.AppendLine(WhiteSpace);

            // GetAllColumns method
            builder.AppendLine(TabTwo + SummaryStart);
            builder.AppendLine(TabTwo + XmlComment + "Get all columns");
            builder.AppendLine(TabTwo + SummaryEnd);
            builder.AppendLine(TabTwo + XmlComment + ReturnStart + "All columns" + ReturnEnd);
            builder.AppendLine(TabTwo + PublicOverride + @"IEnumerable<ModelBase> GetAllColumns()");
            builder.AppendLine(TabTwo + BracketOpen);
            builder.AppendLine(WhiteSpace);
            builder.AppendLine(TabThree + @"var columns = new List<ModelBase>");
            builder.AppendLine(TabThree + BracketOpen);

            // Iterate fields collection
            for (var i = 0; i < view.Fields.Count; i++)
            {
                // locals
                var field = view.Fields[i];
                var fieldName = field.Name;

                // Only add if it is not RESERVED
                if (!fieldName.ToUpper().Contains(ReservedWord))
                {
                    builder.AppendLine(TabFour + "new GridField");
                    builder.AppendLine(TabFour + BracketOpen);
                    builder.AppendLine(TabFive + "field = " + string.Format(Field, fieldName + (field.Type.Equals(BusinessDataType.Enumeration) ? "String" : string.Empty)) + Comma);
                    builder.AppendLine(TabFive + Comment + ToDo + EnsureGenerated);
                    builder.AppendLine(TabFive + Comment + ToDo + DeleteToDo);
                    builder.AppendLine(TabFive + "title = " + resxName + "." + fieldName + Comma);

                    // Assign attributes based upon type
                    var attributes = field.Type.Equals(BusinessDataType.Decimal) ||
                                     field.Type.Equals(BusinessDataType.Double) ||
                                     field.Type.Equals(BusinessDataType.Integer) ||
                                     field.Type.Equals(BusinessDataType.Long) ? "FinderConstant.CssClassGridColumn10NumRightAlign" :
                                     "FinderConstant.CssClassGridColumn10";
                    builder.AppendLine(TabFive + "attributes = " + attributes + Comma);
                    builder.AppendLine(TabFive + "headerAttributes = " + attributes + Comma);

                    // Assign data type / Presentation List
                    switch (field.Type)
                    {
                        case BusinessDataType.Decimal:
                        case BusinessDataType.Double:
                            builder.Append(TabFive + string.Format(DataTypeFormat, "DataTypeAmount"));
                            break;
                        case BusinessDataType.Integer:
                        case BusinessDataType.Long:
                            builder.Append(TabFive + string.Format(DataTypeFormat, "DataTypeNumber"));
                            break;
                        case BusinessDataType.String:
                            // UI Strings (Enumerations) are presentation lists
                            if (view.Enums.ContainsKey(fieldName))
                            {
                                builder.Append(TabFive + string.Format(PresentationListFormat, fieldName));
                            }
                            else
                            {
                                builder.Append(TabFive + string.Format(DataTypeFormat, "DataTypeString"));
                            }
                            break;
                        case BusinessDataType.DateTime:
                            builder.Append(TabFive + string.Format(DataTypeFormat, "DataTypeDate"));
                            break;
                        case BusinessDataType.Boolean:
                            builder.AppendLine(TabFive + string.Format(DataTypeFormat, "DataTypeString") + Comma);
                            builder.Append(TabFive + string.Format(PresentationListFormat, "BooleanType"));
                            break;
                        case BusinessDataType.TimeSpan:
                            builder.Append(TabFive + string.Format(DataTypeFormat, "DataTypeTime"));
                            break;
                        default:
                            builder.Append(TabFive + string.Format(PresentationListFormat, fieldName));
                            break;
                    }

                    // Custom Attributes
                    if (field.Type.Equals(BusinessDataType.Decimal) || field.Type.Equals(BusinessDataType.Double) ||
                        (field.Type.Equals(BusinessDataType.String) && !view.Enums.ContainsKey(fieldName)))
                    {
                        // End the previous section first
                        builder.AppendLine(Comma);

                        builder.AppendLine(TabFive + "customAttributes = ");
                        builder.AppendLine(TabSix + @"new Dictionary<string, string>");
                        builder.AppendLine(TabSix + BracketOpen);

                        // String attributes
                        if (field.Type.Equals(BusinessDataType.String))
                        {
                            builder.AppendLine(TabSeven + BracketOpen + string.Format(FinderMaxLength, field.Size) + BracketClose +
                                ((field.IsAlphaNumeric || field.IsNumeric || field.IsUpperCase) ? Comma : string.Empty));

                            // Is numeric?
                            if (field.IsNumeric)
                            {
                                builder.AppendLine(TabSeven + BracketOpen + FinderRightAlign + BracketClose + Comma);
                                builder.AppendLine(TabSeven + BracketOpen + FinderNumeric + BracketClose +
                                    ((field.IsAlphaNumeric || field.IsUpperCase) ? Comma : string.Empty));
                            }

                            // Is lphanumeric or Is upper?
                            if (field.IsAlphaNumeric || field.IsUpperCase)
                            {
                                builder.AppendLine(TabSeven + BracketOpen + FinderCapitalLetter + BracketClose +
                                    ((field.IsAlphaNumeric) ? Comma : string.Empty));

                                // Is alphanumeric?
                                if (field.IsAlphaNumeric)
                                {
                                    builder.AppendLine(TabSeven + BracketOpen + FinderAlphanumeric + BracketClose);
                                }
                            }
                        }
                        else
                        {
                            // Amount attributes
                            builder.AppendLine(TabSeven + Comment + ToDo + FinderNumericMax);
                            builder.AppendLine(TabSeven + Comment + ToDo + DeleteToDo);
                            builder.AppendLine(TabSeven + BracketOpen + string.Format(FinderMaxLength, 16) + BracketClose + Comma);
                            builder.AppendLine(TabSeven + BracketOpen + FinderRightAlign + BracketClose);
                        }

                        // Close the custom attributes
                        builder.AppendLine(TabSix + BracketClose);
                    }
                    else
                    {
                        // End the previous section first
                        builder.AppendLine(string.Empty);
                    }

                    // Close the gridfield
                    builder.AppendLine(TabFour + BracketClose + (i.Equals(view.Fields.Count - 1) ? string.Empty : Comma));
                }
            }

            builder.AppendLine(TabThree + BracketClose + SemiColon);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabThree + "return columns.AsEnumerable()" + SemiColon);
            builder.AppendLine(TabTwo + BracketClose);

            builder.AppendLine(TabTwo + RegionEnd);
            builder.AppendLine(WhiteSpace);

            builder.AppendLine(TabOne + BracketClose);
            builder.AppendLine(BracketClose);

            return builder.ToString();
        }

        /// <summary>
        /// Helper method to output the StringLenth attribute
        /// </summary>
        /// <param name="field">The field the length to be based on</param>
        /// <returns>StringLength attribute string</returns>
        public static string StringLengthAnnotation(BusinessField field)
        {
            return field.Type.Equals(BusinessDataType.String) ? string.Format("[StringLength({0}, ErrorMessageResourceName = \"" + "MaxLength" + "\",ErrorMessageResourceType = typeof(AnnotationsResx))]", field.Size) : string.Empty;
        }

        /// <summary>
        /// Helper method to output the RequiredField attribute
        /// </summary>
        /// <param name="field">The field that is to be determined if required or not</param>
        /// <returns>Required attribute string</returns>
        public static string RequiredFieldAnnotation(BusinessField field)
        {
            return field.IsRequired ? string.Format("[Required(ErrorMessageResourceName = \"" + "Required" + "\", ErrorMessageResourceType = typeof(AnnotationsResx))]") : string.Empty;
        }

        /// <summary>
        /// Helper method to output EntityKey attribute
        /// </summary>
        /// <param name="field">The field that is to be determined if key or not</param>
        /// <returns>EntityKey attribute string</returns>
        public static string KeyFieldAnnotation(BusinessField field)
        {
            return field.IsKey ? string.Format("[Key]") : string.Empty;
        }

        /// <summary>
        /// Helper method to output the ValidateDateFormat attribute
        /// </summary>
        /// <returns>ValidateDateFormat attribute string</returns>
        public static string ValidateDateFormatAnnotation()
        {
            return string.Format("[ValidateDateFormat(ErrorMessageResourceName=\"DateFormat\"" + ", ErrorMessageResourceType = typeof(AnnotationsResx))]");
        }

        /// <summary>
        /// Check naming convention to ensure upper case
        /// </summary>
        /// <param name="fieldName">Field name</param>
        /// <returns>Upper case field name</returns>
        public static bool CheckNamingConvention(string fieldName)
        {
            return fieldName.All(Char.IsUpper);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the pural name for the entered value
        /// </summary>
        /// <param name="name">Name to be made plural</param>
        /// <returns>Plural name</returns>
        private static string PluralName(string name)
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
        #endregion
    }
}
