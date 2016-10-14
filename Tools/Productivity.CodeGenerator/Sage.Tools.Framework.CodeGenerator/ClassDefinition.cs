using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Class definition
    /// </summary>
    public class ClassDefinition
    {

        /// <summary> 
        /// Define the compile unit to use for code generation.  
        /// </summary>
        private CodeCompileUnit _targetUnit;

        /// <summary>
        /// Namespace for the class
        /// </summary>
        private CodeNamespace _classNamespace;

        /// <summary>
        /// Namespace for the using statements
        /// </summary>
        private CodeNamespace _usingDummyNamespace;

        /// <summary> 
        /// The only class in the compile unit. This class contains 2 fields, 
        /// 3 properties, a constructor, an entry point, and 1 simple method.
        /// </summary>
        private CodeTypeDeclaration _targetClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDefinition"/> class.
        /// </summary>
        /// <param name="clsDefinitionParameter">The CLS definition parameter.</param>
        public ClassDefinition(ClassDefinitionParameter clsDefinitionParameter)
        {

            _targetUnit = new CodeCompileUnit();
            // To keep the using statements on top of the file
            _usingDummyNamespace = new CodeNamespace("");

            _classNamespace =
                new CodeNamespace(string.Format("{0}.{1}",
                    Constants.SageRootNamespace + clsDefinitionParameter.ShortName + "." +
                    clsDefinitionParameter.FolderName,
                    clsDefinitionParameter.ModuleName));

            var className = clsDefinitionParameter.ClassName;

            if (!string.IsNullOrEmpty(clsDefinitionParameter.FormattedClassName))
            {
                className = clsDefinitionParameter.FormattedClassName;
            }

            _targetClass = new CodeTypeDeclaration(className)
            {
                TypeAttributes = TypeAttributes.Public,
                IsPartial = !clsDefinitionParameter.IsNotPartialClass,
            };

            if (clsDefinitionParameter.BaseTypes != null)
            {
                _targetClass.BaseTypes.Add(clsDefinitionParameter.BaseTypes);
            }

            // set partial class based on parameter.
            switch (clsDefinitionParameter.CustomClassType)
            {
                case CustomClassType.Interface:
                    _targetClass.IsInterface = true;
                    break;
                default:
                    _targetClass.IsClass = true;
                    break;
            }

            TargetClass.Comments.AddRange(AddDocSummaryComment(clsDefinitionParameter.ClassComment));
            ClassNamespace.Types.Add(TargetClass);

            TargetUnit.Namespaces.Add(_usingDummyNamespace);
            TargetUnit.Namespaces.Add(ClassNamespace);

            if (clsDefinitionParameter.CodeTypeReference != null)
                _targetClass.BaseTypes.Add(clsDefinitionParameter.CodeTypeReference);

            if (clsDefinitionParameter.CodeTypeParameter != null)
                _targetClass.TypeParameters.Add(clsDefinitionParameter.CodeTypeParameter);

        }

        /// <summary> 
        /// Defines the class without namespace for creating sub classes
        /// </summary> 
        public ClassDefinition(string className, string classComment)
        {
            _targetClass = new CodeTypeDeclaration(className)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public,
                IsPartial = true

            };

            TargetClass.Comments.AddRange(AddDocSummaryComment(classComment));
        }

        /// <summary> 
        /// Defines the class. 
        /// </summary> 
        public ClassDefinition(string moduleName, string folderName, string className, string classComment, string shortName)
            : this(new ClassDefinitionParameter { ModuleName = moduleName, FolderName = folderName, ClassName = className, ClassComment = classComment, ShortName = shortName })
        {

        }
        public void AddMethod(CodeMemberMethod method)
        {
            method.Comments.AddRange(AddDocSummaryComment(method.Name));

            _targetClass.Members.Add(method);
        }

        public void AddConstructor(CodeParameterDeclarationExpressionCollection parameters, CodeArgumentReferenceExpression codeArgumentReferenceExpression = null)
        {
            // Declare the constructor
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
            var constructor = new CodeConstructor { Attributes = MemberAttributes.Public | MemberAttributes.Final };

            constructor.Comments.AddRange(AddDocSummaryComment("Initializes the Constructor"));

            // Add parameters.
            constructor.Parameters.AddRange(parameters);

            if (codeArgumentReferenceExpression != null)
                constructor.BaseConstructorArgs.Add(codeArgumentReferenceExpression);

            _targetClass.Members.Add(constructor);
        }


        /// <summary>
        /// Add generic types
        /// </summary>
        /// <param name="typeParameter">Type Parameter</param>
        /// <param name="hasConstructorContraint">Has constraint</param>
        /// <param name="constraintClass">Constraint class</param>
        public void AddCodeTypeParameter(string typeParameter, bool hasConstructorContraint, string constraintClass)
        {
            var type = new CodeTypeParameter(typeParameter);
            if (hasConstructorContraint)
            {
                type.HasConstructorConstraint = true;
            }
            type.Constraints.Add(new CodeTypeReference(constraintClass));

            TargetClass.TypeParameters.Add(type);

        }

        /// <summary>
        /// Add base types
        /// </summary>
        /// <param name="baseClassName">Base class type</param>
        /// <param name="typeList">Generic types</param>
        public void AddBaseTypes(string baseClassName, IEnumerable<string> typeList)
        {
            TargetClass.BaseTypes.Add(new CodeTypeReference(baseClassName, typeList.Select(type => new CodeTypeReference(type)).ToArray()));
        }

        public CodeMemberMethod AddConstructor(Dictionary<string, string> parameters)
        {
            var constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            foreach (var parameter in parameters)
            {
                constructor.Parameters.Add(new CodeParameterDeclarationExpression(parameter.Key, parameter.Value.ToLower()));
            }

            constructor.Comments.AddRange(AddDocSummaryComment("Initializes the class"));

            TargetClass.Members.Add(constructor);

            return constructor;
        }

        public CodeMemberMethod AddConstructor(Dictionary<string, string> parameters, IEnumerable<string> baseParameters)
        {
            var constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            foreach (var parameter in parameters)
            {
                constructor.Parameters.Add(new CodeParameterDeclarationExpression(parameter.Key, parameter.Value.ToLower()));
            }

            foreach (var baseParam in baseParameters)
            {
                constructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(baseParam));
            }

            constructor.Comments.AddRange(AddDocSummaryComment("Initializes the class"));

            TargetClass.Members.Add(constructor);

            return constructor;
        }

        public CodeMemberMethod AddCodeMethod(string methodName, string comment, string returnType, Dictionary<string, string> parameters, bool isPrivate = false, bool isOverride = false, bool isStatic=false)
        {
            var method = new CodeMemberMethod
            {
                // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
                Attributes = isPrivate ? MemberAttributes.Private : MemberAttributes.Public | MemberAttributes.Override,
                Name = methodName,
                ReturnType = new CodeTypeReference(returnType),
            };

            if (isOverride)
            {
                method.Attributes = MemberAttributes.Override | MemberAttributes.Family;
            }

            if (isStatic)
            {
                method.Attributes = MemberAttributes.Static | MemberAttributes.Private;
            }

            foreach (var parameter in parameters)
            {
                method.Parameters.Add(new CodeParameterDeclarationExpression(parameter.Key, parameter.Value.ToLower()));
            }

            method.Comments.AddRange(AddDocSummaryComment(comment));

            TargetClass.Members.Add(method);

            return method;
        }

        public void AddCodeAssignmentStatement(CodeMemberMethod method, string variableName, string value)
        {
            var assignmentStatement = new CodeAssignStatement(new CodeVariableReferenceExpression(variableName), new CodeSnippetExpression(value));
            method.Statements.Add(assignmentStatement);
        }
        public void AddCodeVariableDeclarationStatement(CodeMemberMethod method, string variableName, string type, string value)
        {
            var variableDeclarationStatement = new CodeVariableDeclarationStatement("var", variableName, new CodeObjectCreateExpression(type));
            method.Statements.Add(variableDeclarationStatement);
        }

        /// <summary> 
        /// Define the compile unit to use for code generation.  
        /// </summary>
        public CodeCompileUnit TargetUnit
        {
            get { return _targetUnit; }
        }

        /// <summary>
        /// Namespace for the class
        /// </summary>
        public CodeNamespace ClassNamespace
        {
            get { return _classNamespace; }
        }

        /// <summary> 
        /// The only class in the compile unit. This class contains 2 fields, 
        /// 3 properties, a constructor, an entry point, and 1 simple method.  
        /// </summary>
        public CodeTypeDeclaration TargetClass
        {
            get { return _targetClass; }
        }

        /// <summary>
        /// Adds using imports
        /// </summary>
        /// <param name="importsList">list of name spaces to import</param>
        public void AddImports(IEnumerable<string> importsList)
        {
            foreach (var import in importsList)
            {
                _usingDummyNamespace.Imports.Add(new CodeNamespaceImport(import));
            }
        }

        /// <summary>
        /// Adds a subclass into the main class
        /// </summary>
        /// <param name="className">The class name</param>
        /// <param name="comment">The comments</param>
        public ClassDefinition AddSubClass(string className, string comment)
        {
            var subClassDefinition = new ClassDefinition(className, comment);
            TargetClass.Members.Add(subClassDefinition.TargetClass);
            return subClassDefinition;
        }

        /// <summary>
        /// Add a property into the class
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="propertyComment">Property comment</param>
        /// <param name="typeName">Property type name</param>
        /// <returns>Added property</returns>
        public CodeTypeMember AddProperty(string propertyName, string propertyComment, Type typeName)
        {
            return AddProperty(propertyName, propertyComment, typeName, false);
        }

        /// <summary>
        /// Add a field into the class
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="fieldComment">Field comment</param>
        /// <param name="typeName">Field type name</param>
        /// <param name="defaultValue">default value for the field</param>
        /// <param name="isPrivate">Is it private</param>
        /// <param name="isReadOnly">Is it read-only</param>
        /// <returns>Added field</returns>
        public CodeTypeMember AddField(string fieldName, string fieldComment, Type typeName, string defaultValue,
            bool isPrivate = false, bool isReadOnly = false)
        {
            var field = new CodeMemberField
            {
                Attributes = isPrivate ? MemberAttributes.Private : MemberAttributes.Public,
                Name = fieldName,
                Type = new CodeTypeReference(typeName),
            };

            if (!string.IsNullOrEmpty(defaultValue))
            {
                field.InitExpression = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeName.Name),
                    defaultValue);
            }

            field.Comments.AddRange(AddDocSummaryComment(fieldComment));

            TargetClass.Members.Add(field);

            return field;
        }

        /// <summary>
        /// Add a field into the class
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="fieldComment">Field comment</param>
        /// <param name="typeName">Field type name</param>
        /// <param name="defaultValue">default value for the field</param>
        /// <param name="isPrivate">Is it private</param>
        /// <returns>Added field</returns>
        public CodeTypeMember AddConstField(string fieldName, string fieldComment, string typeName, object defaultValue,
            bool isPrivate = false)
        {
            var field = new CodeMemberField
            {
                // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
                Attributes = isPrivate ? MemberAttributes.Private | MemberAttributes.Const : MemberAttributes.Public | MemberAttributes.Const,
                // ReSharper restore BitwiseOperatorOnEnumWithoutFlags
                Name = fieldName,
                Type = new CodeTypeReference(typeName),

            };

            if (defaultValue != null)
            {
                field.InitExpression = new CodePrimitiveExpression(defaultValue);

            }

            field.Comments.AddRange(AddDocSummaryComment(fieldComment));

            TargetClass.Members.Add(field);

            return field;
        }


        /// <summary>
        /// Add a field into the class
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="fieldComment">Field comment</param>
        /// <param name="typeName">Field type name</param>
        /// <param name="defaultValue">default value for the field</param>
        /// <param name="isPrivate">Is it private</param>
        /// <returns>Added field</returns>
        public CodeTypeMember AddConstField(string fieldName, string fieldComment, Type typeName, object defaultValue,
            bool isPrivate = false)
        {
            return AddConstField(fieldName, fieldComment, typeName.Name, defaultValue, isPrivate);
        }

        /// <summary>
        /// Add a property into the class
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="propertyComment">Property comment</param>
        /// <param name="typeName">Property type name</param>
        /// <param name="isPrivate">Private or public method</param>
        /// <returns>Added property</returns>
        public CodeTypeMember AddProperty(string propertyName, string propertyComment, Type typeName, bool isPrivate)
        {
            var property = new CodeMemberProperty
            {
                Attributes = isPrivate ? MemberAttributes.Private : MemberAttributes.Public,
                Name = propertyName,
                Type = new CodeTypeReference(typeName),
                HasGet = true,
                HasSet = true
            };

            property.Comments.AddRange(AddDocSummaryComment(propertyComment));

            TargetClass.Members.Add(property);

            return property;
        }

        /// <summary>
        /// Start a region
        /// </summary>
        /// <param name="member">Type member for starting the region</param>
        /// <param name="regionName">Name of the region</param>
        public void StartRegion(CodeTypeMember member, string regionName)
        {
            member.StartDirectives.Add(new CodeRegionDirective
            {
                RegionMode = CodeRegionMode.Start,
                RegionText = regionName
            });
        }

        /// <summary>
        /// Start a region
        /// </summary>
        /// <param name="member">Type member for ending the region</param>
        /// <param name="regionName">Name of the region</param>
        public void EndRegion(CodeTypeMember member, string regionName = "")
        {
            member.EndDirectives.Add(new CodeRegionDirective
            {
                RegionMode = CodeRegionMode.End,
                RegionText = regionName
            });
        }

        /// <summary>
        /// Adds auto property using code snippet - CodeDom does not support auto property.
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="propertyComment">Property comment</param>
        /// <param name="typeName">Property type name</param>
        /// <returns>Added property</returns>
        public CodeTypeMember AddAutoProperty(string propertyName, string propertyComment, Type typeName)
        {
            var customAttributeName = Constants.DoubleQuotes + propertyName + Constants.DoubleQuotes;
            var snippet = new CodeSnippetTypeMember
            {
                Text =
                    string.Format(
                        "\t\t[Display(Name = {0}, ResourceType = typeof(CommonResx))]{1}\t\tpublic {2} {3} {{ get; set; }}\n\n",
                        customAttributeName, Environment.NewLine, typeName.Name,
                        propertyName)
            };

            snippet.Comments.AddRange(AddDocSummaryComment(propertyComment));
            TargetClass.Members.Add(snippet);

            return snippet;
        }

        /// <summary>
        /// Adds XML comments
        /// </summary>
        /// <param name="comment">Comment to be used</param>
        /// <returns></returns>
        private CodeCommentStatementCollection AddDocSummaryComment(string comment)
        {
            return new CodeCommentStatementCollection
            {
                new CodeCommentStatement("<summary>", true),
                new CodeCommentStatement(comment, true),
                new CodeCommentStatement("</summary>", true)
            };

        }
    }
}
