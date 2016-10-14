/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Properties;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Helpers;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// Class DescpExtractor
    /// </summary>
    class DescriptionExtractor: DataProcessorBase
    {
        private readonly List<string> _files;
        private readonly XmlDocument _xmlDoc;
        private readonly Logger _logger;
        private readonly FileWriter _outputWriter;
        private readonly string _inputFolder;
        private readonly string _outputFile;
        public  StringBuilder Result{get;set;}


        /// <summary>
        /// DescpExtractor Constructor
        /// </summary>
        /// <param name="inputReceiver">InputReceiverBase</param>
        public DescriptionExtractor(IInputReceiver inputReceiver)
        {
            Result = new StringBuilder();
            _inputFolder = inputReceiver.InputPath;
            _outputFile = inputReceiver.OutputPath;
            PromptEnd = Resources.PromptExtractorFinish;
            _xmlDoc = new XmlDocument();

            _files = Directory.EnumerateFiles(inputReceiver.InputPath, "*.htm", SearchOption.AllDirectories).ToList();
            TotalFiles = _files.Count();
            _logger = new Logger(Path.GetDirectoryName(inputReceiver.OutputPath));
            _outputWriter = new FileWriter(inputReceiver.OutputPath);
        }


        /// <summary>
        /// Process the input files and generate extracted description
        /// </summary>
        public override void Process()
        {
                
            try{
                Result.AppendLine(Resources.TitleLine);

                var fileCount = 0;

                foreach (var file in _files)
                {
                    fileCount++;
                    var text = string.Format(Resources.PromptProcessing,fileCount, TotalFiles, file);
                    LaunchDisplayEvent(text);

                    try
                    {
                        _xmlDoc.Load(file);
                    }
                    catch (Exception e)
                    {
                        WriteLog(e, file);
                        LaunchStatusEvent(false);
                        continue;
                    }

                    //Check if it contains meta tag 
                    var isContainDesc = false;

                    // ReSharper disable once PossibleNullReferenceException
                    var nodes = _xmlDoc.DocumentElement.GetElementsByTagName("meta");
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (XmlNode node in nodes)
                    {
                        if (node.Attributes == null ||
                            (node.Attributes["name"] == null || node.Attributes["content"] == null))
                        {
                            continue;
                        }

                        if (node.Attributes["name"].Value == "description")
                        {
                            isContainDesc = true;
                            break;
                        }
                    }

                    if (isContainDesc)
                    {
                        LaunchStatusEvent(true);
                        continue;
                    }

                    //Check if html element has any of the following class values
                    var isConcept = _xmlDoc.DocumentElement.GetAttribute("class") == "concept";
                    var isMinitoc = _xmlDoc.DocumentElement.GetAttribute("class") == "minitoc";
                    var isReference = _xmlDoc.DocumentElement.GetAttribute("class") == "reference";
                    var isScreenguide = _xmlDoc.DocumentElement.GetAttribute("class") == "screenguide";
                    var isTask = _xmlDoc.DocumentElement.GetAttribute("class") == "task";
                    var isAnyFiveValues = isConcept || isMinitoc ||
                                            isReference || isScreenguide || isTask;

                    if (!isAnyFiveValues)
                    {
                        LaunchStatusEvent(true);
                        continue;
                    }

                    //Extract the required information
                    var topic = _xmlDoc.DocumentElement.GetAttribute("class");
                    var fileFullName = file;
                    var fileFullPath = "";
                    var fileName = "";

                    GetFilePathAndName(fileFullName, ref fileFullPath, ref fileName);
                    var fileRelativePath = RelativePath(fileFullPath, _inputFolder);

                    var outputRelativePath = Transform(fileRelativePath);

                    var metaDescp = "";

                    if (topic == "concept" || topic == "minitoc" || topic == "reference" || topic == "task")
                    {
                        XmlNode firstPargrah = GetFirstParagraphAfterH1(_xmlDoc);
                        metaDescp = ExtractDescp(firstPargrah);

                    }

                    if (topic == "screenguide")
                    {
                        var firstPargrah = GetFirstParagAfterOverViewH2(_xmlDoc);
                        metaDescp = ExtractDescp(firstPargrah);
                    }

                    if (string.IsNullOrEmpty(metaDescp) )
                    {
                        LaunchStatusEvent(true);
                        continue;
                    }

                    //strip out all quotes in metaDescp, and then enclose it with double quotes
                    if (metaDescp.Contains('"'))
                    {
                        metaDescp = metaDescp.Replace('"', ' ');
                    }

                    if (metaDescp.Contains('\''))
                    {
                        metaDescp = metaDescp.Replace('\'', ' ');
                    }

                    metaDescp = '"' + metaDescp + '"';

                    var line = fileRelativePath + "," + outputRelativePath + "," + fileName + "," + topic + "," + metaDescp;

                    //Check if the capacity of result is big enough to hold the new line
                    if (Result.Length + line.Length < Result.MaxCapacity)
                    {
                        Result.AppendLine(line);                        
                    }
                    else
                    {
                        _outputWriter.Write(Result.ToString());
                        Result.Clear();
                        Result.AppendLine(line);
                    }

                    LaunchStatusEvent(true, Resources.GetDescription);
                    
                }

                _outputWriter.Write(Result.ToString());
                LaunchDisplayEvent(string.Format(Resources.ErrorFailSummary + Resources.LogFile + Resources.NewLine, 
                    _logger.FailCount, Path.GetDirectoryName(_outputFile)));
                
            }
            catch (Exception e)
            {
                Console.Write(e.Message + Resources.NewLine);
            }
                     
        }

        /// <summary>
        /// Write log info
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="filePath">File which produces the exception</param>
        private void WriteLog(Exception exception, String filePath)
        {
            try
            {
                var loginfo = string.Format(Resources.ExpectionLogInfo, filePath, exception.Message);
                _logger.WriteLine(loginfo);
            }
            catch (Exception logEx)
            {
                LaunchDisplayEvent(exception.Message + logEx.Message);
            }
        }

        /// <summary>
        /// Get the rest path relative to root
        /// </summary>
        /// <param name="fullPath">Full path</param>
        /// <param name="root">Root path</param>
        /// <returns>Relative path</returns>
        private static string RelativePath(string fullPath, string root)
        {
            if ( fullPath == null || root == null || !fullPath.StartsWith(root) )
            {
                return null;
            }

            //If fullPath equals to root, then return ""
            return fullPath.Length > root.Length ? fullPath.Substring(root.Length + 1) : "";
        }

        /// <summary>
        /// Etract the required description
        /// </summary>
        /// <param name="firstParagraph">Xml P node</param>
        /// <returns>Descrption</returns>
        private static string ExtractDescp(XmlNode firstParagraph)
        {
            if (firstParagraph == null)
            {
                return null;
            }

            string metaDescp = "";

            if (firstParagraph.InnerText != "")
            {
                metaDescp += firstParagraph.InnerText;
            }

            XmlNode immediateList = firstParagraph.NextSibling;

            if (immediateList != null && (immediateList.Name == "ul" || immediateList.Name == "ol" || immediateList.Name == "dl"))
            {
                metaDescp += GetTextInLines(immediateList);
            }

            return metaDescp;

        }

        /// <summary>
        /// Transfrom input file paths to output file paths
        /// </summary>
        /// <param name="filePath">Input file path</param>
        /// <returns>Output file path</returns>
        private static string Transform(string filePath)
        {
            if (filePath == null)
            {
                return null;
            }

            string retStr = filePath;

            retStr = retStr.Replace(@"Portal\Content", "Content");
            retStr = retStr.Replace("Financials", "Subsystems");
            retStr = retStr.Replace("Operations", "Subsystems");

            return retStr;
        }

        /// <summary>
        /// Get the text in an Xml list
        /// </summary>
        /// <param name="list">Xml list node</param>
        /// <returns>text</returns>
        private static string GetTextInLines(XmlNode list)
        {
            if ( list == null ){
                return null;
            }

            string retStr = "";
            XmlNodeList items = list.ChildNodes;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (XmlNode item in items)
            {
                if (item.InnerText != "")
                {
                    retStr += "\n" + item.InnerText;
                }
            }

            return retStr;
        }

        /// <summary>
        /// Get the first paragraph after the first heading h1
        /// </summary>
        /// <param name="xmlDoc">XmlDocument</param>
        /// <returns>The first paragraph node</returns>
        private static XmlNode GetFirstParagraphAfterH1(XmlDocument xmlDoc)
        {
            XmlNode h1 = xmlDoc.GetElementsByTagName("h1")[0];
            if (h1 == null)
            {
                return null;
            }

            XmlNode nextSibling = h1.NextSibling;
            while (nextSibling != null && nextSibling.Name != "p")
            {
                nextSibling = nextSibling.NextSibling;
            }

            return nextSibling;
        }

        /// <summary>
        /// Get the first paragraph after the over view heading h2
        /// </summary>
        /// <param name="xmlDoc">XmlDocument</param>
        /// <returns>The first pargraph node</returns>
        private static XmlNode GetFirstParagAfterOverViewH2(XmlDocument xmlDoc)
        {
            XmlNode h2 = xmlDoc.GetElementsByTagName("h2")[0];
            if ( h2 == null )
            {
                return null;
            }

            var firstChild = h2.FirstChild;

            if (firstChild.Name == "#text")
            {
                if (h2.InnerText != "Overview")
                {
                    return null;
                }
            }
            else
            {
                if (firstChild.Attributes != null && 
                    (firstChild.Name != "span" || firstChild.Attributes["class"] == null 
                    || firstChild.Attributes["class"].Value != "UIOverview" || h2.InnerText != "Overview"))
                {
                    return null;
                }
            }

            XmlNode nextSibling = h2.NextSibling;
            while (nextSibling != null && nextSibling.Name != "p")
            {
                nextSibling = nextSibling.NextSibling;
            }

            return nextSibling;
        }

        /// <summary>
        /// Get the file path and name
        /// </summary>
        /// <param name="fileFullName">Full file name</param>
        /// <param name="filePath">Reference to file path</param>
        /// <param name="fileName">Reference to file name</param>
        private static void GetFilePathAndName(string fileFullName, ref string filePath, ref string fileName)
        {
            if (fileFullName == null)
            {
                return;
            }

            var idxOfLastSlash = fileFullName.LastIndexOf(@"\", StringComparison.Ordinal);

            if (idxOfLastSlash == -1) return;

            fileName = fileFullName.Substring(idxOfLastSlash + 1);
            //filePath does not end with "\" by getting rid of the last '\'
            filePath = fileFullName.Substring(0, idxOfLastSlash);
        }

    }
}
