/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.CodeDom;
using System.Collections.Generic;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Interface Code Generator
    /// </summary>
    public class RepositoryCodeGenerator
    {
        #region Private Members

        /// <summary>
        /// The _entity name
        /// </summary>
        private readonly string _entityName;

        private readonly string _outputFolder;

        private string _projectShortName;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryCodeGenerator" /> class.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="outputFolder">The output folder.</param>
        public RepositoryCodeGenerator(string entityName, string outputFolder)
        {
            _entityName = entityName;
            _outputFolder = outputFolder;
        }

        #endregion

        #region Generate

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Generate()
        {
            GenerateService();
            GenerateRepository();

            return true;
        }

        /// <summary>
        /// Generates the instance
        /// </summary>
        /// <param name="projectShortName"></param>
        /// <returns></returns>
        public bool Generate(string projectShortName)
        {
            _projectShortName = projectShortName;
            GenerateService();
            GenerateRepository();

            return true;
        }

        #endregion

        #region Generate Service

        /// <summary>
        /// Generates the service interface.
        /// </summary>
        /// <returns></returns>
        public bool GenerateService()
        {
            var fileName = string.Format("{0}Service.cs", _entityName);

            var codeTypeReference = new CodeTypeReference("BaseReportService<T, I" + _entityName + "Entity<T>>, I" + _entityName + "Service<T>");
            var codeTypeParameter = new CodeTypeParameter("T") { HasConstructorConstraint = true };
            codeTypeParameter.Constraints.Add(new CodeTypeReference(_entityName));

            // Class Properties
            var classDefinitionParameter = new ClassDefinitionParameter
            {
                ModuleName = "Reports",
                FolderName = "Services",
                ClassName = _entityName,
                CustomClassType = CustomClassType.Class,
                ClassComment = string.Format("Class for {0} Service.", _entityName),
                CodeTypeReference = codeTypeReference,
                CodeTypeParameter = codeTypeParameter,
                FormattedClassName = string.Format("{0}EntityService", _entityName)
            };

            var classDefinition = new ClassDefinition(classDefinitionParameter);
            
            // Imports
            var imports = new List<string>
            {
                Constants.SageRootNamespace + "Common.Services.Base",
                Constants.SageRootNamespace + "Common.Models",
                Constants.SageRootNamespace + _projectShortName + ".Interfaces.BusinessRepository.Reports", 
                Constants.SageRootNamespace + _projectShortName + ".Interfaces.Services.Reports", 
                Constants.SageRootNamespace + _projectShortName + ".Models.Reports"
            };
            classDefinition.AddImports(imports);

            //Constructor
            var baseParams = new List<string>
            {
                "context"
            };
            var contructorMethod =
                classDefinition.AddConstructor(new Dictionary<string, string> { { "Context", "context" } }, baseParams);
            classDefinition.StartRegion(contructorMethod, "Constructors");
            classDefinition.EndRegion(contructorMethod);
            classDefinition.AddCodeAssignmentStatement(contructorMethod, "_context", "context");

            // Generate Code
            var codeGenerator = new CodeGenerator(_outputFolder, fileName);
            codeGenerator.Generate(classDefinition);

            return true;
        }

        #endregion

        #region Generate Business Repository

        /// <summary>
        /// Generates the entity interface.
        /// </summary>
        /// <returns></returns>
        public bool GenerateRepository()
        {
            var fileName = string.Format("{0}Repository.cs", _entityName);

            var codeTypeReference = new CodeTypeReference("BaseReportRepository<T>, I" + _entityName + "Entity<T>");

            var codeTypeParameter = new CodeTypeParameter("T") { HasConstructorConstraint = true };
            codeTypeParameter.Constraints.Add(new CodeTypeReference(_entityName));

            var classDefinitionParameter = new ClassDefinitionParameter
            {
                ModuleName = "Reports",
                FolderName = "BusinessRepository",
                ClassName = _entityName,
                CustomClassType = CustomClassType.Class,
                ClassComment = string.Format("Class for {0}", _entityName),
                CodeTypeReference = codeTypeReference,
                CodeTypeParameter = codeTypeParameter,
                FormattedClassName = string.Format("{0}Repository", _entityName)
                
            };

            var classDefinition = new ClassDefinition(classDefinitionParameter);

            var imports = new List<string> { 
                "System",
                "System.Globalization",
                Constants.SageRootNamespace + "Common.Utilities",
                Constants.SageRootNamespace + "Common.Models.Enums",
                Constants.SageRootNamespace + "Common.Models",
                Constants.SageRootNamespace + "Common.Interfaces.Entity",
                Constants.SageRootNamespace + "Common.BusinessRepository.Base",
                Constants.SageRootNamespace + _projectShortName + ".Models.Enums.Reports",
                Constants.SageRootNamespace + _projectShortName + ".Models.Process",
                Constants.SageRootNamespace + _projectShortName + ".Models.Reports",
                Constants.SageRootNamespace + _projectShortName + ".Models",
                Constants.SageRootNamespace + _projectShortName + ".BusinessRepository.Reports",
                Constants.SageRootNamespace + _projectShortName + ".BusinessRepository",
                Constants.SageRootNamespace + _projectShortName + ".BusinessRepository.Mappers.Reports" };

            classDefinition.AddImports(imports);

            //Private Variables
            classDefinition.StartRegion(classDefinition.AddField("_entity", string.Format("OE - {0} entity",_entityName), typeof(string) , "", true), "Private Variables");
            classDefinition.EndRegion(classDefinition.AddConstField("Z", "Constant", typeof(char), "z", true));

            //Constructor
            var baseParams = new List<string>
            {
                "context",
                string.Format("new {0}Mapper<T>(context)", _entityName),
                string.Format("{0}.ViewName", _entityName)
            };
            var contructorMethod = classDefinition.AddConstructor(new Dictionary<string, string> { { "Context", "context" }}, baseParams);
            classDefinition.StartRegion(contructorMethod, "Constructors");
            classDefinition.EndRegion(contructorMethod);

            var contructorMethodOverload = classDefinition.AddConstructor(new Dictionary<string, string> { { "Context", "context" }, { "IBusinessEntitySession", "session" } });
            classDefinition.EndRegion(contructorMethodOverload);


            // Abstract Methods
            var abstractMethod = classDefinition.AddCodeMethod("Execute", "Execute the report", "Guid",
                new Dictionary<string, string> {{"T", "model"}}, false, true);
            classDefinition.StartRegion(abstractMethod, "Abstract Methods");

            classDefinition.AddCodeMethod("Get", "Method to get default model values.", "T",
                new Dictionary<string, string> { { " bool", "applyUserPreferences = true" } }, false, true);

            classDefinition.EndRegion(classDefinition.AddCodeMethod("CreateBusinessEntities", "Create Business Entities",
                "IBusinessEntity", new Dictionary<string, string>(), false, true));

            // Generate Code
            var codeGenerator = new CodeGenerator(_outputFolder, fileName);
            codeGenerator.Generate(classDefinition);

            return true;
        }

        #endregion
    }
}
