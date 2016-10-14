/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.CodeDom;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Class Definition Parameter
    /// </summary>
    public class ClassDefinitionParameter
    {
        /// <summary>
        /// Gets or sets the name of the module.
        /// </summary>
        /// <value>
        /// The name of the module.
        /// </value>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        /// <value>
        /// The name of the folder.
        /// </value>
        public string FolderName { get; set; }

        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets the name of the formatted class.
        /// </summary>
        /// <value>
        /// The name of the formatted class.
        /// </value>
        public string FormattedClassName { get; set; }

        /// <summary>
        /// Gets or sets the class comment.
        /// </summary>
        /// <value>
        /// The class comment.
        /// </value>
        public string ClassComment { get; set; }

        /// <summary>
        /// Gets or sets the type of the custom class.
        /// </summary>
        /// <value>
        /// The type of the custom class.
        /// </value>
        public CustomClassType CustomClassType { get; set; }

        /// <summary>
        /// Gets or sets the code type reference.
        /// </summary>
        /// <value>
        /// The code type reference.
        /// </value>
        public CodeTypeReference CodeTypeReference { get; set; }

        /// <summary>
        /// Gets or sets the base types.
        /// </summary>
        /// <value>
        /// The base types.
        /// </value>
        public CodeTypeReference BaseTypes { get; set; }

        /// <summary>
        /// Gets or sets the code type parameter.
        /// </summary>
        /// <value>
        /// The code type parameter.
        /// </value>
        public CodeTypeParameter CodeTypeParameter { get; set; }

        /// <summary>
        /// Gets or sets the project short name of the custom class.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [partial class].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [partial class]; otherwise, <c>false</c>.
        /// </value>
        public bool IsNotPartialClass { get; set; }
    }

    /// <summary>
    /// Custom Class Type
    /// </summary>
    public enum CustomClassType
    {
        Class = 0,
        Finder = 1,
        Interface = 2,
        Repository = 3
    }
}