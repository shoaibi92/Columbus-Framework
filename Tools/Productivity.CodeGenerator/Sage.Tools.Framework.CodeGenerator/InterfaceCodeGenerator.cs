/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

// THIS CLASS IS OBSOLETE AND WILL SOON BE REMOVED


using System.CodeDom;
using System.Collections.Generic;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Interface Code Generator
    /// </summary>
    public class InterfaceCodeGenerator
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
        /// Initializes a new instance of the <see cref="InterfaceCodeGenerator" /> class.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="outputFolder">The output folder.</param>
        public InterfaceCodeGenerator(string entityName, string outputFolder)
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
            GenerateServiceInterface();
            GenerateEntityInterface();

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
            GenerateServiceInterface();
            GenerateEntityInterface();

            return true;
        }

        #endregion

        #region GenerateServiceInterface

        /// <summary>
        /// Generates the service interface.
        /// </summary>
        /// <returns></returns>
        public bool GenerateServiceInterface()
        {
            var fileName = string.Format("I{0}Service.cs", _entityName);

            var codeTypeReference = new CodeTypeReference("IReportService<T>, ISecurityService");
            var codeTypeParameter = new CodeTypeParameter("T") { HasConstructorConstraint = true };
            codeTypeParameter.Constraints.Add(new CodeTypeReference(_entityName));

            // Class Properties
            var classDefinitionParameter = new ClassDefinitionParameter
            {
                ModuleName = "Reports",
                FolderName = "Services",
                ClassName = _entityName,
                CustomClassType = CustomClassType.Interface,
                ClassComment = string.Format("Interface for {0} Service.", _entityName),
                CodeTypeReference = codeTypeReference,
                CodeTypeParameter = codeTypeParameter,
                FormattedClassName = string.Format("I{0}Service", _entityName),
                ShortName = _projectShortName
            };

            var classDefinitoin = new ClassDefinition(classDefinitionParameter);
            
            // Imports
            var imports = new List<string>
            {
                "Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports",
                "Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service", 
                string.Format("Sage.CA.SBS.ERP.Sage300.{0}.Models.Reports", _projectShortName)
            };
            classDefinitoin.AddImports(imports);

            // Generate Code
            var codeGenerator = new CodeGenerator(_outputFolder + "\\Interfaces", fileName);
            codeGenerator.Generate(classDefinitoin);

            return true;
        }

        #endregion

        #region GenerateEntityInterface

        /// <summary>
        /// Generates the entity interface.
        /// </summary>
        /// <returns></returns>
        public bool GenerateEntityInterface()
        {
            var fileName = string.Format("I{0}Entity.cs", _entityName);

            var codeTypeReference = new CodeTypeReference("IReportRepository<T>, ISecurity");

            var codeTypeParameter = new CodeTypeParameter("T") { HasConstructorConstraint = true };
            codeTypeParameter.Constraints.Add(new CodeTypeReference(_entityName));

            var classDefinitionParameter = new ClassDefinitionParameter
            {
                ModuleName = "Reports",
                FolderName = "BusinessRepository",
                ClassName = _entityName,
                CustomClassType = CustomClassType.Interface,
                ClassComment = string.Format("Interface for {0} Entity.", _entityName),
                CodeTypeReference = codeTypeReference,
                CodeTypeParameter = codeTypeParameter,
                FormattedClassName = string.Format("I{0}Entity", _entityName),
                ShortName = _projectShortName
            };

            var classDefinitoin = new ClassDefinition(classDefinitionParameter);

            var imports = new List<string>
            {
                "Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports",
                string.Format("Sage.CA.SBS.ERP.Sage300.{0}.Models.Reports", _projectShortName)
            };

            classDefinitoin.AddImports(imports);

            // Generate Code
            var codeGenerator = new CodeGenerator(_outputFolder + "\\Interfaces", fileName);
            codeGenerator.Generate(classDefinitoin);

            return true;
        }

        #endregion
    }
}
