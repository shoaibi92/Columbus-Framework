using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Sage.Tools.ModelGenerator.Reports
{
    public static class ReportInputParser
    {
        public static ReportDefinition Parse(string reportDefinitionText, string reportName, string programId, string outputFolder)
        {
            var report = ReadRawText(reportDefinitionText, reportName, programId, outputFolder);
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            // Validate and process fields
            foreach (var field in report.Fields)
            {
                // Determine datatype
                //field.DataType = field.RawName.IndexOf('?') > 0 ? typeof (bool) : typeof(string);

                // Remove Question mark //TODO
                field.RawName = field.RawName.Replace("?", string.Empty);

                string[] words = field.RawName.Split('-');
                
                // Remove hiphen for raw name
                field.RawName = field.RawName.Replace("-", "");

                // Create Pascal case for normalized name
                var sb = new StringBuilder();
                foreach (var word in words)
                {
                    sb.Append(textInfo.ToTitleCase(word.ToLower()));
                }
                field.NormalizedName = sb.ToString();
            }

            return report;
        }

        private static ReportDefinition ReadRawText(string reportDefinitionText, string reportName, string programId, string outputFolder)
        {
            var projectShortName = programId.Substring(0, 2);
            var report = new ReportDefinition { Name = reportName, ProgramId = programId, OutputFolder = outputFolder, ProjectShortName = projectShortName };
            CreateOutputFolder(outputFolder);

            // Read the file and display it line by line.
            var isFirstLineWithEquals = false;
            using (var file = new StringReader(reportDefinitionText))
            {
                string line;
                var isFirstRow = true;
                while ((line = file.ReadLine()) != null)
                {
                    if (isFirstRow)
                    {
                        report.ModuleName = line.Trim().Contains("[") && line.Contains("]")
                            ? line.Trim().Substring(1, line.Length - 2)
                            : string.Empty;
                    }
                    if (line.StartsWith("2="))
                    {
                        isFirstLineWithEquals = true;
                    }

                    if (isFirstLineWithEquals)
                    {
                        var splitted = line.Split('=');
                        //var test = splitted[1].Split(' ')[splitted[1].Split(' ').Length - 1];
                        var dataType = TypeParser(splitted[1].Split(' '));
                        report.Fields.Add(new FieldDefinition
                        {
                            Sequence = Convert.ToInt16(splitted[0]),
                            RawName = splitted[1].Split(' ')[0],
                            NormalizedName = splitted[1].Split(' ')[0],
                            DataType = dataType
                            //DataType = Convert.ChangeType(splitted[1].Split(' ')[splitted[1].Split(' ').Length - 1], 
                        });
                    }

                    isFirstRow = false;
                }
            }

            return report;
        }

        /// <summary>
        /// Parses type from string value
        /// </summary>
        /// <param name="splittedValue"></param>
        /// <returns></returns>
        private static Type TypeParser(string[] splittedValue)
        {
            if (splittedValue.Length <= 2) return typeof (string);

            var dataType = splittedValue[splittedValue.Length - 1].Trim().ToLower();
            if (string.IsNullOrEmpty(dataType)) return typeof (string);

            if (dataType.StartsWith("int"))
            {
                return typeof (int);
            }
            if (dataType.StartsWith("string"))
            {
                return typeof(string);
            }
            if (dataType.StartsWith("date"))
            {
                return typeof(DateTime);
            }
            if (dataType.StartsWith("bool"))
            {
                return typeof(bool);
            }
            if (dataType.StartsWith("date"))
            {
                return typeof(DateTime);
            }
            if (dataType.StartsWith("decimal"))
            {
                return typeof(decimal);
            }
            return typeof(string);
        }

        /// <summary>
        /// Creates output folder
        /// </summary>
        /// <param name="outputFoler"></param>
        private static void CreateOutputFolder(string outputFoler)
        {
            // Ensure output folder is clear of contents
            if (Directory.Exists(outputFoler))
            {
                Directory.Delete(outputFoler, true);
            }
            Directory.CreateDirectory(outputFoler);
            Directory.CreateDirectory(outputFoler + "\\Interfaces");
        }
    }
}
