﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Templates.Flat.Class
{
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class InternalController : InternalControllerBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 5 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"

   // Locals
    var moduleId = settings.ModuleId;
    var copyright = settings.Copyright;
    var companyNamespace = settings.CompanyNamespace;
    var resxName = settings.ResxName;
    var modelName = view.Properties[BusinessView.ModelName];
    var entityName = view.Properties[BusinessView.EntityName];
    var keyFieldName = view.Keys.FirstOrDefault();

    var webModuleNamespace = settings.DoesAreasExist ? "Web.Areas." + moduleId : moduleId + ".Web";

            
            #line default
            #line hidden
            this.Write("// ");
            
            #line 17 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(copyright));
            
            #line default
            #line hidden
            this.Write(@"

#region Namespace

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.ExportImport;
using ");
            
            #line 29 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 29 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Interfaces.Services;\r\nusing ");
            
            #line 30 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 30 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Models;\r\n");
            
            #line 31 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"

	if (view.Enums.Count > 0)
	{

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 35 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 35 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Models.Enums;\r\n");
            
            #line 36 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"

	}

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 39 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 39 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Resources.Forms;\r\nusing ");
            
            #line 40 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 40 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(webModuleNamespace));
            
            #line default
            #line hidden
            this.Write(".Models;\r\n\r\n#endregion\r\n\r\nnamespace ");
            
            #line 44 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 44 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(webModuleNamespace));
            
            #line default
            #line hidden
            this.Write(".Controllers\r\n{\r\n    /// <summary>\r\n    /// ");
            
            #line 47 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write(" Internal Controller\r\n    /// </summary>\r\n    /// <typeparam name=\"T\">Where T is " +
                    "type of <see cref=\"");
            
            #line 49 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\"/></typeparam>\r\n    public class ");
            
            #line 50 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ControllerInternal<T> : BaseExportImportControllerInternal<T, I");
            
            #line 50 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("Service<T>>\r\n        where T : ");
            
            #line 51 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write(", new()\r\n    {\r\n        #region Private variables\r\n\r\n        #endregion\r\n\r\n      " +
                    "  #region Constructor\r\n\r\n        /// <summary>\r\n        /// New instance of <see" +
                    " cref=\"");
            
            #line 60 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ControllerInternal{T}\"/>\r\n        /// </summary>\r\n        /// <param name=\"contex" +
                    "t\">Context</param>\r\n        public ");
            
            #line 63 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ControllerInternal(Context context)\r\n            : base(context)\r\n        {\r\n    " +
                    "    }\r\n\r\n        #endregion\r\n\r\n        #region Internal methods\r\n\r\n        /// <" +
                    "summary>\r\n        /// Create a ");
            
            #line 73 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <returns>JSON object for ");
            
            #line 75 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        internal ");
            
            #line 76 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T> Create()\r\n        {\r\n            var viewModel = GetViewModel(new T(" +
                    "), null);\r\n\r\n            viewModel.UserAccess = GetAccessRights();\r\n\r\n          " +
                    "  return viewModel;\r\n        }\r\n\r\n        /// <summary>\r\n        /// Get a ");
            
            #line 86 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"id\">Id for ");
            
            #line 88 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <returns>JSON object for ");
            
            #line 89 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        internal ");
            
            #line 90 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T> GetById(string id)\r\n        {\r\n            var data = Service.GetByI" +
                    "d(id);\r\n            var userMessage = new UserMessage(data);\r\n\r\n            retu" +
                    "rn GetViewModel(data, userMessage);\r\n        }\r\n\r\n        /// <summary>\r\n       " +
                    " /// Add a ");
            
            #line 99 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"model\">Model for ");
            
            #line 101 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <returns>JSON object for ");
            
            #line 102 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        internal ");
            
            #line 103 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T> Add(T model)\r\n        {\r\n            var data = Service.Add(model);\r" +
                    "\n\r\n            var userMessage = new UserMessage(data,\r\n                string.F" +
                    "ormat(CommonResx.AddSuccessMessage, ");
            
            #line 108 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resxName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 108 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyFieldName));
            
            #line default
            #line hidden
            this.Write(", data.");
            
            #line 108 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyFieldName));
            
            #line default
            #line hidden
            this.Write("));\r\n\r\n            return GetViewModel(data, userMessage);\r\n       }\r\n\r\n        /" +
                    "// <summary>\r\n        /// Update a ");
            
            #line 114 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"model\">Model for ");
            
            #line 116 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <returns>JSON object for ");
            
            #line 117 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        internal ");
            
            #line 118 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write(@"ViewModel<T> Save(T model)
        {
            var data = Service.Save(model);
            var userMessage = new UserMessage(data, CommonResx.SaveSuccessMessage);

            return GetViewModel(data, userMessage);
        }

        /// <summary>
        /// Delete a ");
            
            #line 127 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"id\">Id for ");
            
            #line 129 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <returns>JSON object for ");
            
            #line 130 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        internal ");
            
            #line 131 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T> Delete(string id)\r\n        {\r\n            Expression<Func<T, bool>> " +
                    "filter = param => param.");
            
            #line 133 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyFieldName));
            
            #line default
            #line hidden
            this.Write(" == id;\r\n            var data = Service.Delete(filter);\r\n\r\n            var userMe" +
                    "ssage = new UserMessage(data,\r\n                string.Format(CommonResx.DeleteSu" +
                    "ccessMessage, ");
            
            #line 137 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(resxName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 137 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyFieldName));
            
            #line default
            #line hidden
            this.Write(", data.");
            
            #line 137 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyFieldName));
            
            #line default
            #line hidden
            this.Write("));\r\n\r\n            return GetViewModel(data, userMessage);\r\n        }\r\n\r\n        " +
                    "#endregion\r\n\r\n        #region Private methods\r\n\r\n        /// <summary>\r\n        " +
                    "/// Generic routine to return a view model for ");
            
            #line 147 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"model\">Model for ");
            
            #line 149 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <param name=\"userMessage\">User Message for ");
            
            #line 150 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</param>\r\n        /// <returns>View Model for ");
            
            #line 151 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</returns>\r\n        private ");
            
            #line 152 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T> GetViewModel(T model, UserMessage userMessage)\r\n        {\r\n         " +
                    "   return new ");
            
            #line 154 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("ViewModel<T>\r\n            {\r\n                Data = model,\r\n                UserM" +
                    "essage = userMessage\r\n            };\r\n        }\r\n\r\n        #endregion\r\n\r\n\t}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\Flat\Class\InternalController.tt"

private global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.BusinessView _viewField;

/// <summary>
/// Access the view parameter of the template.
/// </summary>
private global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.BusinessView view
{
    get
    {
        return this._viewField;
    }
}

private global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Settings _settingsField;

/// <summary>
/// Access the settings parameter of the template.
/// </summary>
private global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Settings settings
{
    get
    {
        return this._settingsField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool viewValueAcquired = false;
if (this.Session.ContainsKey("view"))
{
    this._viewField = ((global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.BusinessView)(this.Session["view"]));
    viewValueAcquired = true;
}
if ((viewValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("view");
    if ((data != null))
    {
        this._viewField = ((global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.BusinessView)(data));
    }
}
bool settingsValueAcquired = false;
if (this.Session.ContainsKey("settings"))
{
    this._settingsField = ((global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Settings)(this.Session["settings"]));
    settingsValueAcquired = true;
}
if ((settingsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("settings");
    if ((data != null))
    {
        this._settingsField = ((global::Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Settings)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class InternalControllerBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}