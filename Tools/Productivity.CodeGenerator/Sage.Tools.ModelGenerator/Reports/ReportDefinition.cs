using System;
using System.Collections.Generic;

namespace Sage.Tools.ModelGenerator.Reports
{
    /// <summary>
    /// Accpac report definition format
    /// </summary>
    public class ReportDefinition
    {
        public ReportDefinition()
        {
            Fields = new List<FieldDefinition>();
        }

        public string ModuleName { get; set; }
        public string Name { get; set; }
        public string ProgramId { get; set; }
        public string OutputFolder { get; set; }
        public string ProjectShortName { get; set; }
        public List<FieldDefinition> Fields { get; set; }
    }

    /// <summary>
    /// Accpac report fields
    /// </summary>
    public class FieldDefinition
    {
        public int Sequence { get; set; }
        public string RawName { get; set; }
        public string NormalizedName { get; set; }
        public Type DataType { get; set; }
    }
}
