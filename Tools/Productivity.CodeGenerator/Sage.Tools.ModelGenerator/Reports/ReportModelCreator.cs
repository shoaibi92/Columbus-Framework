
using System;
using System.Collections.Generic;
using Sage.Tools.Framework.CodeGenerator;

namespace Sage.Tools.ModelGenerator.Reports
{
    public static class ReportModelCreator
    {

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
        public static event ProcessingEventHandler ProcessingEvent;

        /// <summary> Event to update UI with status of file being processed </summary>
        public static event StatusEventHandler StatusEvent;
        #endregion

        #region Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportDefinition"></param>
        public static void CreateModels(ReportDefinition reportDefinition)
        {
            CreateReportClass(reportDefinition);
            CreateReportFieldsClass(reportDefinition);
            CreateReportMapperClass(reportDefinition);
            CreateReportInterfaces(reportDefinition);
            CreateReportRepository(reportDefinition);
        }

        /// <summary>
        /// Updates the file creation status
        /// </summary>
        /// <param name="success"></param>
        /// <param name="fileName"></param>
        private static void StatusUpdate(bool success, string fileName)
        {
            var fileNames = fileName.Split(',');
            // Update status
            if (StatusEvent != null)
            {
                foreach (var item in fileNames)
                {
                    if (success)
                    {
                        StatusEvent(item, Info.StatusType.Success, string.Empty);
                    }
                    else
                    {
                        StatusEvent(item, Info.StatusType.Error, string.Format(Properties.Resources.ErrorCreatingFile, item));
                    }
                }
            }
        }

        /// <summary>
        /// Creates modes for the report.
        /// </summary>
        /// <param name="reportDefinition"></param>
        private static void CreateReportInterfaces(ReportDefinition reportDefinition)
        {
            var codeGenerator = new InterfaceCodeGenerator(reportDefinition.Name, reportDefinition.OutputFolder);
            var fileNames = "I" + reportDefinition.Name + "Entity.cs,I" + reportDefinition.Name + "Service.cs";
            StatusUpdate(codeGenerator.Generate(reportDefinition.ProjectShortName), fileNames);
        }

        /// <summary>
        /// Creates modes for the report.
        /// </summary>
        /// <param name="reportDefinition"></param>
        private static void CreateReportRepository(ReportDefinition reportDefinition)
        {
            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(reportDefinition.Name + "Repository");
            }

            var codeGenerator = new RepositoryCodeGenerator(reportDefinition.Name, reportDefinition.OutputFolder);
            var fileNames = reportDefinition.Name + "Service.cs," + reportDefinition.Name + "Repository.cs";
            StatusUpdate(codeGenerator.Generate(reportDefinition.ProjectShortName), fileNames);
        }

        /// <summary>
        /// Creates models for the report.
        /// </summary>
        /// <param name="reportDefinition"></param>
        private static void CreateReportClass(ReportDefinition reportDefinition)
        {
            //Create report models
            var modelClassDefinition = new ClassDefinition("Reports", "Models", reportDefinition.Name, string.Format("This class is used to generate the report for {0}", reportDefinition.Name), reportDefinition.ProjectShortName);
            var imports = new List<string>
            {
                "System",
                "System.ComponentModel.DataAnnotations",
                Constants.SageRootNamespace + "Common.Models.Attributes",
                Constants.SageRootNamespace + "Common.Models.Reports",
                Constants.SageRootNamespace + "Common.Resources",
                Constants.SageRootNamespace + reportDefinition.ProjectShortName + ".Models.Enums.Reports",
                Constants.SageRootNamespace + reportDefinition.ProjectShortName + ".Resources"
            };
            modelClassDefinition.AddImports(imports);
            modelClassDefinition.TargetClass.BaseTypes.Add("ReportBase");

            for (int i = 0; i < reportDefinition.Fields.Count; i++)
            {
                var field = reportDefinition.Fields[i];
                if (i == 0)
                {
                    var codeTypeProperty = modelClassDefinition.AddAutoProperty(field.NormalizedName, string.Format("Gets or Sets the {0} property", field.NormalizedName), field.DataType);
                    modelClassDefinition.StartRegion(codeTypeProperty, "Model Properties");
                }
                else if (i == reportDefinition.Fields.Count - 1)
                {
                    var codeTypeProperty = modelClassDefinition.AddAutoProperty(field.NormalizedName, string.Format("Gets or Sets the {0} property", field.NormalizedName), field.DataType);
                    modelClassDefinition.EndRegion(codeTypeProperty);
                }
                else
                {
                    modelClassDefinition.AddAutoProperty(field.NormalizedName, string.Format("Gets or Sets the {0} property", field.NormalizedName), field.DataType);
                }
            }

            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(reportDefinition.Name);
            }

            var codeGenerator = new CodeGenerator(reportDefinition.OutputFolder, reportDefinition.Name + ".cs");
            StatusUpdate(codeGenerator.Generate(modelClassDefinition), reportDefinition.Name + ".cs");
        }

        /// <summary>
        /// Creates fields for the report.
        /// </summary>
        /// <param name="reportDefinition"></param>
        private static void CreateReportFieldsClass(ReportDefinition reportDefinition)
        {
            var className = reportDefinition.Name + "Fields";

            //Create report models
            var modelClassDefinition = new ClassDefinition("Reports", "Models", className, string.Format("Contains list of {0} Report Constants", className), reportDefinition.ProjectShortName);

            modelClassDefinition.AddConstField("ViewName", "View Name", typeof(string), Guid.NewGuid().ToString());

            var subClassFields = modelClassDefinition.AddSubClass("Fields",
                string.Format("Class for fields of {0}", reportDefinition.Name));

            // Generate fields
            for (int i = 0; i < reportDefinition.Fields.Count; i++)
            {
                var field = reportDefinition.Fields[i];
                if (i == 0)
                {
                    var codeTypeProperty = subClassFields.AddConstField(field.NormalizedName, string.Format("The field for  {0}", field.NormalizedName), field.DataType, field.RawName);
                    modelClassDefinition.StartRegion(codeTypeProperty, "Fields");
                }
                else if (i == reportDefinition.Fields.Count - 1)
                {
                    var codeTypeProperty = subClassFields.AddConstField(field.NormalizedName, string.Format("The field for  {0}", field.NormalizedName), field.DataType, field.RawName);
                    modelClassDefinition.EndRegion(codeTypeProperty);
                }
                else
                {
                    subClassFields.AddConstField(field.NormalizedName, string.Format("The field for  {0}", field.NormalizedName), field.DataType, field.RawName);
                }
            }

            /* The Index is not used for Reports, so commenting the code */
            #region Create Index for Reports

            //var subClassIndex = modelClassDefinition.AddSubClass("Index",
            //  string.Format("Class for Index of {0}", reportDefinition.Name));

            ////Generate Indexes
            //for (int i = 0; i < reportDefinition.Fields.Count; i++)
            //{
            //    var fieldDefinition = reportDefinition.Fields[i];
            //    if (i == 0)
            //    {
            //        var codeTypeProperty = subClassIndex.AddConstField(fieldDefinition.NormalizedName, string.Format("The field for  {0}", fieldDefinition.NormalizedName), typeof(int), fieldDefinition.Sequence);
            //        modelClassDefinition.StartRegion(codeTypeProperty, "Fields");
            //    }
            //    else if (i == reportDefinition.Fields.Count - 1)
            //    {
            //        var codeTypeProperty = subClassIndex.AddConstField(fieldDefinition.NormalizedName, string.Format("The field for  {0}", fieldDefinition.NormalizedName), typeof(int), fieldDefinition.Sequence);
            //        modelClassDefinition.EndRegion(codeTypeProperty);
            //    }
            //    else
            //    {
            //        subClassIndex.AddConstField(fieldDefinition.NormalizedName, string.Format("The field for  {0}", fieldDefinition.NormalizedName), typeof(int), fieldDefinition.Sequence);
            //    }
            //} 

            #endregion

            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(className);
            }

            var codeGenerator = new CodeGenerator(reportDefinition.OutputFolder, reportDefinition.Name + "Fields.cs");
            StatusUpdate(codeGenerator.Generate(modelClassDefinition), reportDefinition.Name + "Fields.cs");
        }

        /// <summary>
        /// Creates mappers for the report.
        /// </summary>
        /// <param name="reportDefinition"></param>
        private static void CreateReportMapperClass(ReportDefinition reportDefinition)
        {
            var className = reportDefinition.Name + "Mapper";

            //Create report models
            var modelClassDefinition = new ClassDefinition("Reports", "BusinessRepository.Mappers", className, string.Format("Class for {0} mapping", className), reportDefinition.ProjectShortName);

            //Imports
            var imports = new List<string>
            {
                "System",
                Constants.SageRootNamespace + "Common.Models",
                Constants.SageRootNamespace + "Common.Models.Reports",
                Constants.SageRootNamespace + "Common.BusinessRepository",
                Constants.SageRootNamespace + "Common.Utilities",
                Constants.SageRootNamespace + reportDefinition.ProjectShortName + ".Models",
                Constants.SageRootNamespace + reportDefinition.ProjectShortName + ".Models.Reports",
                Constants.SageRootNamespace + reportDefinition.ProjectShortName + ".Models.Enums.Reports"
            };
            modelClassDefinition.AddImports(imports);

            //Generic types
            modelClassDefinition.AddCodeTypeParameter("T", true, reportDefinition.Name);
            modelClassDefinition.AddBaseTypes("IReportMapper", new List<string> { "T" });

            //Constructor
            var contructorMethod = modelClassDefinition.AddConstructor(new Dictionary<string, string> { { "Context", "context" } });
            modelClassDefinition.StartRegion(contructorMethod, "Constructors");
            modelClassDefinition.EndRegion(contructorMethod);
            modelClassDefinition.AddCodeAssignmentStatement(contructorMethod, "_context", "context");

            //Map method
            var mapMethod = modelClassDefinition.AddCodeMethod("Map", "Method to map the model", "Report", new Dictionary<string, string> { { "T", "model" } });
            
            modelClassDefinition.AddCodeVariableDeclarationStatement(mapMethod, "report", "Report", "Test");

            var i = 0;
            foreach (var field in reportDefinition.Fields)
            {
                var newLine = Environment.NewLine;
                const string threeTabs = "\t\t\t";
                const string fourTabs = "\t\t\t\t";
                var stmtValue = "Parameter" + newLine + threeTabs + "{" + newLine + fourTabs + "Id = " +
                                reportDefinition.Name + ".Fields." + field.NormalizedName + "," + newLine + fourTabs +
                                "Value = model." + field.NormalizedName + newLine + threeTabs + "};" + newLine + threeTabs +
                                "report.Parameters.Add(" + field.NormalizedName.ToLower() + ")";
                if (i == 0)
                {
                    modelClassDefinition.AddCodeAssignmentStatement(mapMethod,
                        "SetReportName(report, model);" + newLine + threeTabs + "var " + field.NormalizedName.ToLower(),
                        stmtValue);
                }
                else
                {
                    modelClassDefinition.AddCodeAssignmentStatement(mapMethod, "var " + field.NormalizedName.ToLower(),
                        stmtValue);
                }
                i++;
            }

            //Method to set Report Name
            var reportNameMethod = modelClassDefinition.AddCodeMethod("SetReportName", "Set Report Name", "",
                new Dictionary<string, string> { { "Report", "report" }, { "T", "model" } }, true, false, true);
            modelClassDefinition.AddCodeAssignmentStatement(reportNameMethod, "var fileName", "string.IsNullOrEmpty(model.ReportName) ? string.Empty : model.ReportName");
            modelClassDefinition.AddCodeAssignmentStatement(reportNameMethod, "report.Name",
                reportDefinition.ProjectShortName + "ReportName + " + Constants.DoubleQuotes + "[" +
                Constants.DoubleQuotes + " + fileName + " +
                Constants.DoubleQuotes + "]" + Constants.DoubleQuotes + "");


            //Fields
            modelClassDefinition.StartRegion(modelClassDefinition.AddField("_context", "The Context", typeof(Context), "", true), "Private Properties");
            modelClassDefinition.AddConstField("MenuId", "The Menu Id", typeof(string), "<MENU ID>", true);
            modelClassDefinition.AddConstField("ReportName", "The Report Name", typeof(string), reportDefinition.Name, true);
            modelClassDefinition.EndRegion(modelClassDefinition.AddConstField("ProgramId", "The programId", typeof(string), reportDefinition.ProgramId, true));

            // Update display of file being processed
            if (ProcessingEvent != null)
            {
                ProcessingEvent(className);
            }

            //Generate the file
            var codeGenerator = new CodeGenerator(reportDefinition.OutputFolder, reportDefinition.Name + "Mapper.cs");
            StatusUpdate(codeGenerator.Generate(modelClassDefinition), reportDefinition.Name + "Mapper.cs");
        }

        /* Create Enums is not used for Reports, so commenting the code */
        ///// <summary>
        ///// Creates enums for the report.
        ///// </summary>
        ///// <param name="reportDefinition"></param>
        //private static void CreateReportEnums(ReportDefinition reportDefinition)
        //{
        //    var className = reportDefinition.Name + "Types";
        //    //Create report enums
        //    var modelClassDefinition = new ClassDefinition("Reports", ".Models.Enums", className,
        //        string.Format("{0} Reports Types", reportDefinition.Name + "Types"));
        //    var imports = new List<string>
        //    {
        //        Constants.SageRootNamespace + "Common.Models",
        //        Constants.SageRootNamespace + ".Resources.Reports"
        //    };
        //    modelClassDefinition.AddImports(imports);
        //    modelClassDefinition.TargetClass.Members.Add(new CodeSnippetTypeMember("\t\t//TODO: Need to add enums here."));

        //    // Update display of file being processed
        //    if (ProcessingEvent != null)
        //    {
        //        ProcessingEvent(className);
        //    }

        //    var codeGenerator = new CodeGenerator(reportDefinition.OutputFolder, reportDefinition.Name + "Types.cs");
        //    StatusUpdate(codeGenerator.Generate(modelClassDefinition), reportDefinition.Name);
        //}
        #endregion
    }
}
