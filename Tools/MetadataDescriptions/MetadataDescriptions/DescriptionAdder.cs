/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Properties;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Helpers;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Interfaces;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// DescpAdder Class
    /// </summary>
    class DescriptionAdder: DataProcessorBase
    {
        private readonly XmlDocument _xmlDoc;
        private readonly Logger _logger;
        private readonly string _inputFile;
        private readonly string _outputFolder;
        private List<InputRecord> _inputRecords;

        /// <summary>
        /// Input record which stores the output file path relative to output folder where 
        /// actually the input .htm files are located as well, 
        /// and the corresponding meta description that will be inserted to the output file
        /// </summary>
        private struct InputRecord
        {
            public readonly string InputFile;
            public readonly string Description;

            public InputRecord(string filePath, string description)
            {
                InputFile = filePath;
                Description = description;
            }
        }

        /// <summary>
        /// DescpAdder Constructor
        /// </summary>
        /// <param name="inputReceiver">InputReceiverBase</param>
        public DescriptionAdder(IInputReceiver inputReceiver)
        {
            _xmlDoc = new XmlDocument();
            _logger = new Logger(Path.GetDirectoryName(inputReceiver.InputPath));
            _inputFile = inputReceiver.InputPath;
            _outputFolder = inputReceiver.OutputPath;
            PromptEnd = Resources.PromptAdderFinish;

            IntializeInputRecords();
            TotalFiles = _inputRecords.Count;
        }

        /// <summary>
        /// Get the meta description from the input htm files
        /// and insert it to the correspondg output file
        /// </summary>
        public override void Process()
        {

            try
            {
                //Tranverse all the input files to insert the description
                var fileCount = 0;
                
                foreach (var inputRecord in _inputRecords)
                {
                    fileCount++;
                    LaunchDisplayEvent(string.Format(Resources.PromptProcessing, 
                        fileCount, TotalFiles, inputRecord.InputFile));

                    //Note: The output folder actually acts as the input folder too
                    var inputFullName = Path.Combine(_outputFolder, inputRecord.InputFile);
                    try
                    {
                        _xmlDoc.PreserveWhitespace = true;
                        _xmlDoc.Load(inputFullName);
                    }
                    catch (Exception e)
                    {
                        WriteLog(e, inputFullName);
                        LaunchStatusEvent(false);
                        continue;
                    }

                    //Find the head tag 
                    // ReSharper disable PossibleNullReferenceException
                    var nodes = _xmlDoc.DocumentElement.GetElementsByTagName("head");
                    // ReSharper restore PossibleNullReferenceException
                    foreach (XmlNode node in nodes)
                    {
                        var firstChild = node.FirstChild;
                        var descriptionElement = _xmlDoc.CreateElement("meta");

                        descriptionElement.SetAttribute("name", "description");
                        descriptionElement.SetAttribute("content", inputRecord.Description);
                        node.InsertBefore(descriptionElement, firstChild);
                    }

                    //Write xmlDoc to its file
                    try
                    {
                        var outputFile = Path.Combine(_outputFolder, inputRecord.InputFile);

                        var writer = XmlWriter.Create(outputFile);
                        _xmlDoc.Save(writer);
                        LaunchStatusEvent(true, Resources.PromptInsert);
                    }
                    catch (Exception e)
                    {
                        LaunchStatusEvent(false);
                        WriteLog(e, inputRecord.InputFile);
                    }
                }

                LaunchDisplayEvent(string.Format(Resources.ErrorFailSummary + Resources.LogFile + Resources.NewLine, 
                    _logger.FailCount, Path.GetDirectoryName(_inputFile)));
            }
            catch (Exception e)
            {
                LaunchDisplayEvent(e.Message);
            }

        }

        /// <summary>
        /// Intialize inputRecords which stores all the InputRecords generated from the input file
        /// </summary>
        private void IntializeInputRecords () 
        {
            //Get the list of output file name and meta description
            GenerateInputRecords:
            try
            {
                var inputLines = File.ReadAllLines(_inputFile);
                _inputRecords = new List<InputRecord>();
                var isDescpClose = true;
                var filePath = "";
                var descp = "";

                //Note the fourth column 'meta description' may contain charater '\n'
                //Therefore some line may start with description
                for (var i = 1; i < inputLines.Length; i++ )
                {
                    var line = inputLines[i];
                    string revisedLine;
                    if (isDescpClose)
                    {
                        //Note the description may contain ',' but it must be enclosed with double quotes
                        var columns = MySplit(line, ',');

                        //Make sure get five columns in one line
                        if (columns.Count != 5)
                        {
                            Console.WriteLine(Resources.ErrorWrongFormat, i);
                            continue;
                        }
                        filePath = Path.Combine(columns[1], columns[2]);
                        revisedLine = columns[4].Substring(1);        //Remove first double quote mark
                    }
                    else
                    {
                        revisedLine = line;
                    }

                    if (revisedLine.Contains('"'))
                    {
                        isDescpClose = true;
                        descp += revisedLine.Substring(0, revisedLine.Length - 1);    //Trim off the double quote mark at the tail
                        var inputRecord = new InputRecord(filePath, descp);
                        _inputRecords.Add(inputRecord);
                        descp = "";
                    }
                    else
                    {
                        descp += revisedLine + " ";
                        isDescpClose = false;
                    }
                }
            }
            catch (Exception e)
            {
                Retry:
                LaunchDisplayEvent(e.Message);
                LaunchDisplayEvent(Resources.PromptRetry);
                var retry = Console.ReadLine();
                if (retry == "Y" || retry == "y")
                {
                    goto GenerateInputRecords;
                }
                if (retry == "N" || retry == "n")
                {
                    Application.Exit();
                }
                goto Retry;
            }
        }

        /// <summary>
        /// Split one line of the input file by comma
        /// Ignore the commas in meta description, which is enclosed by double quotes
        /// </summary>
        /// <param name="str">One line of the input file </param>
        /// <param name="ch">Delimiter</param>
        /// <returns>String list</returns>
        private static List<string> MySplit(string str, char ch)
        {
            var result = new List<string>();
            var idxOfComma = str.IndexOf(ch);
            var idxOfQuote = str.IndexOf('"');

            //If string contains a comma and the quote is behinde the comma then extract the part prior to the comma
            while ( idxOfComma != -1 && idxOfQuote > idxOfComma )
            {
                result.Add(str.Substring(0, idxOfComma));
                str = str.Substring(idxOfComma + 1);
                idxOfComma = str.IndexOf(ch);
                idxOfQuote = str.IndexOf('"');
            }
            result.Add(str);

            return result;
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
                var loginfo = exception != null ? string.Format(Resources.ExpectionLogInfo, filePath, exception.Message) 
                    : string.Format(Resources.FailLogInfo, filePath);
                _logger.WriteLine(loginfo);
            }
            catch (Exception logEx)
            {
                if (exception != null)
                {
                    LaunchDisplayEvent(exception.Message);
                }
                LaunchDisplayEvent(logEx.Message);
            }
        }

    }
}
