/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

// THIS CLASS IS OBSOLETE AND WILL SOON BE REMOVED


using System.CodeDom;
using System.Collections.Generic;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Finder Code Generator
    /// </summary>
    public class FinderCodeGenerator
    {
        #region Private Properties

        /// <summary>
        /// The formatted output
        /// </summary>
        private const string FormattedOutput = "\t\t\tcolumns.Add(new GridField" +
                                           " {{" +
                                           " field = \"{0}\"," +
                                           " title = {1}Resx.{0}," +
                                           " attributes =  {3}," +
                                           " headerAttributes = {3}," +
                                           " {2}";

        /// <summary>
        /// The string property format
        /// </summary>
        private const string StringPropertyFormat = ", customAttributes = new Dictionary<string, string>" +
                                    "{{" +
                                    "   {{FinderConstant.CustomAttributeMaximumLength, \"{0}\"}}" +
                                    "}}";


        /// <summary>
        /// The string property format - text upper
        /// </summary>
        private const string StringPropertyFormatCapitalLetter = ", customAttributes = new Dictionary<string, string>" +
                                    "{{" +
                                    "  {{\"class\", FinderConstant.CssClassTxtUpper}}," +
                                    "   {{FinderConstant.CustomAttributeMaximumLength, \"{0}\"}}" +
                                    "}}";
        

        /// <summary>
        /// The string property format
        /// </summary>
        private const string StringPropertyFormatAlphaNumeric = ", customAttributes = new Dictionary<string, string>" +
                                    "{{" +
                                    "  {{\"class\", FinderConstant.CssClassTxtUpper}}," +
                                    "   {{FinderConstant.CustomAttributeMaximumLength, \"{0}\"}}" +
                                     "   {{FinderConstant.CustomAtrributeFormatTextBox, FinderConstant.AlphaNumeric}}" +
                                    "}}";


        /// <summary>
        /// The string property format
        /// </summary>
        private const string StringPropertyFormatNumeric = ", customAttributes = new Dictionary<string, string>" +
                                    "{{" +
                                    "  {{\"class\", FinderConstant.CssClassInputNumberRightAlign}}," +
                                    "   {{FinderConstant.CustomAttributeMaximumLength, \"{0}\"}}" +
                                     "   {{FinderConstant.CustomAtrributeFormatTextBox, FinderConstant.Numeric}}" +
                                    "}}";
        

        /// <summary>
        /// The amount property format
        /// </summary>
        private const string AmountPropertyFormat = ", customAttributes = new Dictionary<string, string>" +
                            "{{" +
                            "  {{\"class\", FinderConstant.CssClassInputNumberRightAlign}}," +
                            "   {{FinderConstant.CustomAttributeMaximumLength, \"16\"}}" +
                            "}}";

        /// <summary>
        /// The _finder name
        /// </summary>
        private readonly string _finderName;

        /// <summary>
        /// The _model properties
        /// </summary>
        private readonly List<ModelProperty> _modelProperties;

        /// <summary>
        /// The _output folder
        /// </summary>
        private readonly string _outputFolder;

        /// <summary>
        /// The _output folder
        /// </summary>
        private readonly string _moduleCode;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FinderCodeGenerator" /> class.
        /// </summary>
        /// <param name="finderName">Name of the finder.</param>
        /// <param name="modelProperties">The model properties.</param>
        /// <param name="outputFolder">The output folder.</param>
        /// <param name="moduleCode">The module code.</param>
        public FinderCodeGenerator(string finderName, List<ModelProperty> modelProperties, string outputFolder, string moduleCode)
        {
            _finderName = finderName;
            _modelProperties = modelProperties;
            _outputFolder = outputFolder;
            _moduleCode = moduleCode;
        }

        #endregion

        #region Generate

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            var fileName = string.Format("Find{0}ControllerInternal.cs", _finderName);

            // Declare a generic class.
            // Consider below code only for finder.
            var codeTypeReference = new CodeTypeReference("BaseFindControllerInternal",
                new[]
                    {
                        new CodeTypeReference("T"),
                        new CodeTypeReference(string.Format("I{0}Service<T>", _finderName))
                    });

            var codeTypeParameter = new CodeTypeParameter("T") { HasConstructorConstraint = true };
            codeTypeParameter.Constraints.Add(new CodeTypeReference(_finderName));

            var classDefinitionParameter = new ClassDefinitionParameter
            {
                IsNotPartialClass = true,
                ModuleName = "Web.Controllers.Finder",
                FolderName = "CS",
                ClassName = _finderName,
                CustomClassType = CustomClassType.Finder,
                ClassComment = string.Format("Class for {0} Finder.", _finderName),
                CodeTypeReference = codeTypeReference,
                CodeTypeParameter = codeTypeParameter,
                FormattedClassName = string.Format("Find{0}ControllerInternal", _finderName),
                BaseTypes = new CodeTypeReference("IFinder")
            };
            
            var classDefinitoin = new ClassDefinition(classDefinitionParameter);

            var imports = new List<string> { "System", "System.Collections.Generic", 
                "System.Linq", "System.Linq.Expressions", 
                "Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository", 
                "Sage.CA.SBS.ERP.Sage300.Common.Models", 
                "Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Finder" };

            classDefinitoin.AddImports(imports);

            var parameters = new CodeParameterDeclarationExpressionCollection
            {
                new CodeParameterDeclarationExpression("Context", "context")
            };

            var codeArgument = new CodeArgumentReferenceExpression("context");

            classDefinitoin.AddConstructor(parameters, codeArgument);

            //// Add GetAll Columns Method
            classDefinitoin.AddMethod(CreateGetAllColumnsMethod());
 
            // Generate Code
            var codeGenerator = new CodeGenerator(_outputFolder, fileName);
            codeGenerator.Generate(classDefinitoin);

            return fileName;
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Helper method to output the field's data type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// Data type of the field
        /// </returns>
        private string GetFinderConstantDataType(string type)
        {
            const string dataTypeFormat = "dataType = FinderConstant.{0}";
            const string presentationListType = "PresentationList = EnumUtility.GetItemsList<{0}>()";
            const string boolPresentationListType = "dataType = FinderConstant.DataTypeString, PresentationList = EnumUtility.GetItemsList<BooleanType>()";

            string result;

            switch (type.ToLower())
            {
                case "string":
                    result = string.Format(dataTypeFormat, "DataTypeString");
                    break;
                case "datetime":
                    result = string.Format(dataTypeFormat, "DataTypeDate");
                    break;
                case "bool":
                    result = boolPresentationListType;
                    break;
                case "timespan":
                    result = string.Format(dataTypeFormat, "DataTypeTime");
                    break;
                case "number":
                case "int":
                case "long":
                case "int32":
                case "int64":
                    result = string.Format(dataTypeFormat, "DataTypeNumber");
                    break;
                case "decimal":
                case "amount":
                    result = string.Format(dataTypeFormat, "DataTypeAmount");
                    break;
                case "smallint":
                    result = string.Format(dataTypeFormat, "DataTypeSmallInt");
                    break;
                default:
                    result = string.Format(presentationListType, type);
                    break;
            }

            return result;

        }

        /// <summary>
        /// Creates the get all columns method.
        /// </summary>
        /// <returns></returns>
        private CodeMemberMethod CreateGetAllColumnsMethod()
        {
            var method = new CodeMemberMethod
            {
                Name = "GetAllColumns",
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                ReturnType = new CodeTypeReference("IEnumerable<ModelBase>")
            };
            
            method.Statements.Add(new CodeSnippetStatement("\t\t\tvar columns = new List<GridField>();"));

            foreach (var modelProperty in _modelProperties)
            {
                var dataType = GetFinderConstantDataType(modelProperty.DataType);

                // if the datatype is string default css column otherwise 
                var attribute = dataType.Contains("DataTypeAmount") || dataType.Contains("DataTypeNumber") ? 
                        "FinderConstant.CssClassGridColumn10NumRightAlign" : "FinderConstant.CssClassGridColumn10";

                var output = string.Format(FormattedOutput, modelProperty.PropertyName, _finderName, dataType, attribute);

                switch (modelProperty.DataType)
                {
                    case "string":
                        if (modelProperty.IsFieldInputAlphaNumeric || modelProperty.IsFieldInputCapitalLetter || modelProperty.IsFieldInputNumeric)
                        {
                            if (modelProperty.IsFieldInputAlphaNumeric)
                            {
                                output = output + string.Format(StringPropertyFormatAlphaNumeric, modelProperty.MaxLength);
                            }

                            if (modelProperty.IsFieldInputCapitalLetter)
                            {
                                output = output + string.Format(StringPropertyFormatCapitalLetter, modelProperty.MaxLength);
                            }

                            if (modelProperty.IsFieldInputNumeric)
                            {
                                output = output + string.Format(StringPropertyFormatNumeric, modelProperty.MaxLength);
                            }
                        }
                        else
                        {
                            output = output + string.Format(StringPropertyFormat, modelProperty.MaxLength);                            
                        }
                        break;
                    case "decimal":
                    case "amount":
                        output = output + AmountPropertyFormat;
                        break;
                }

                output = output + "});";

                method.Statements.Add(new CodeSnippetStatement(output));

            }

            method.Statements.Add(new CodeSnippetStatement("\t\t\treturn columns;"));

            return method;

        }

        #endregion
    }
}
