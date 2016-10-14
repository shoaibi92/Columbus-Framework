using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Code generator
    /// </summary>
    public class CodeGenerator
    {
        private readonly string _filePathName = string.Empty;

        /// <summary>
        /// Code file path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="fileName">File name</param>
        public CodeGenerator(string filePath, string fileName)
        {
            _filePathName = Path.Combine(filePath, fileName);
        }

        /// <summary>
        /// Generate code file from the class definition
        /// </summary>
        /// <param name="classDefinition">Class definition</param>
        public bool Generate(ClassDefinition classDefinition)
        {
            // Local
            var retVal = true;
            var provider = CodeDomProvider.CreateProvider("CSharp");
            var options = new CodeGeneratorOptions { BracingStyle = "C" };

            try
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var fileWriter = new StreamWriter(_filePathName))
                    {
                        provider.GenerateCodeFromCompileUnit(classDefinition.TargetUnit, stringWriter, options);

                        StringBuilder sb = stringWriter.GetStringBuilder();
                        /* Remove the header autogenrated comment (384 is for C#, use 435 for VB) */
                        sb.Remove(0, 403);

                        // Add copyright comment
                        sb.Insert(0, Constants.Copyright);
                        fileWriter.Write(sb);
                    }
                }
            }
            catch (System.Exception)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
