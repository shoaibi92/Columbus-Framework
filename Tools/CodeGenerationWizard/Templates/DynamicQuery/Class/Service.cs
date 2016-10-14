﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Sage.CA.SBS.ERP.Sage300.CodeGenerationWizard.Templates.DynamicQuery.Class
{
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class Service : ServiceBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            
            #line 5 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"

    // Locals
    var moduleId = settings.ModuleId;
    var copyright = settings.Copyright;
    var companyNamespace = settings.CompanyNamespace;
    var modelName = view.Properties[BusinessView.ModelName];
    var entityName = view.Properties[BusinessView.EntityName];

            
            #line default
            #line hidden
            this.Write("// ");
            
            #line 13 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(copyright));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n#region Namespace\r\n\r\nusing Sage.CA.SBS.ERP.Sage300.Common.Models;\r\nusing Sage" +
                    ".CA.SBS.ERP.Sage300.Common.Services.Base;\r\nusing ");
            
            #line 19 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 19 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Interfaces.BusinessRepository;\r\nusing ");
            
            #line 20 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 20 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Interfaces.Services;\r\nusing ");
            
            #line 21 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 21 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Models;\r\n\r\n#endregion\r\n\r\nnamespace ");
            
            #line 25 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(companyNamespace));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 25 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(moduleId));
            
            #line default
            #line hidden
            this.Write(".Services\r\n{\r\n    /// <summary>\r\n    /// Service for ");
            
            #line 28 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("\r\n    /// </summary>\r\n    /// <typeparam name=\"T\">");
            
            #line 30 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write("</typeparam>\r\n    public class ");
            
            #line 31 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("EntityService<T> : DynamicQueryService<T, I");
            
            #line 31 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("Entity<T>>, I");
            
            #line 31 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("Service<T>\r\n        where T : ");
            
            #line 32 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write(", new()\r\n    {\r\n        #region Constructor\r\n\r\n        /// <summary>\r\n        ///" +
                    " Constructor for ");
            
            #line 37 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("\r\n        /// </summary>\r\n        /// <param name=\"context\">Request Context</para" +
                    "m>\r\n        public ");
            
            #line 40 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("EntityService(Context context)\r\n            : base(context)\r\n        {\r\n        }" +
                    "\r\n\r\n        #endregion\r\n\r\n        #region IDynamicQueryEntityService\r\n\r\n        " +
                    "/// <summary>\r\n        /// Gets ");
            
            #line 50 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelName));
            
            #line default
            #line hidden
            this.Write(@"
        /// </summary>
		/// <param name=""args"">Optional Parameters</param>
        /// <returns>DynamicQueryEnumerableResponse</returns>
        // TODO: Generic Get routine has been added and will require filter
        // TODO: parameters to be added based upon Dynamic Query requirements
        // TODO: Delete TODO statements when complete
        public DynamicQueryEnumerableResponse<T> Get(params object[] args)
        {
            using (var repository = Resolve<I");
            
            #line 59 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entityName));
            
            #line default
            #line hidden
            this.Write("Entity<T>>())\r\n            {\r\n                return repository.Get(args);\r\n     " +
                    "       }\r\n        }\r\n        #endregion\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\CNA2R2\Columbus-Framework\Tools\CodeGenerationWizard\Templates\DynamicQuery\Class\Service.tt"

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
    public class ServiceBase
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
