/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.ComponentModel;
using System.Globalization;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Enum;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// Class Tool
    /// </summary>
    class Tool
    {
        private readonly DataProcessorBase _dataProcessor;
        private readonly BackgroundWorker _wrkBackground;

        /// <summary>
        /// Property ToolType
        /// </summary>
        public ToolType ToolType
        {
            get; set; 
        }

        /// <summary>
        /// Tool Constructor
        /// </summary>
        /// <param name="toolType">ToolType</param>
        public Tool(ToolType toolType)
        {
            _wrkBackground = new BackgroundWorker();
            _wrkBackground.DoWork += wrkBackground_DoWork;
            _wrkBackground.RunWorkerCompleted += wrkBackground_RunWorkerCompleted;
            // 

            

            ToolType = toolType;

            switch (toolType)
            {
                case ToolType.Extractor:
                    InputReceiverBase inputReceiver = new ExtractorInputReceiver();
                    inputReceiver.ReadInputOutput();
                    _dataProcessor = new DescriptionExtractor(inputReceiver);
                    break;
                case ToolType.Adder:
                    inputReceiver = new AdderInputReceiver();
                    inputReceiver.ReadInputOutput();
                    _dataProcessor = new DescriptionAdder(inputReceiver);
                    break;
            }

            _dataProcessor.StatusEvent += StatusEvent;
            _dataProcessor.DisplayEvent += DisplayEvent;
        }

        /// <summary>
        /// Run the data processor to process the input and generate the output
        /// </summary>
        public void Run()
        {
            Console.WriteLine(Properties.Resources.FileProcessSummary, _dataProcessor.TotalFiles.ToString(CultureInfo.InvariantCulture));
            Console.WriteLine(Properties.Resources.PromptContinue);
            Console.ReadKey();

            _wrkBackground.RunWorkerAsync();
            Console.ReadKey();
                 
        }

        /// <summary> Background worker started event </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Background worker will run process</remarks>
        private void wrkBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            _dataProcessor.Process();
        }

        /// <summary> Background worker completed event </summary>
        /// <param name="sender">Sender object </param>
        /// <param name="e">Event Args </param>
        /// <remarks>Background worker has completed process</remarks>
        private void wrkBackground_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            
            Console.WriteLine(_dataProcessor.PromptEnd);
            Console.WriteLine(Properties.Resources.PromptExit);
            Console.ReadKey();
            
        }

        /// <summary> Update status display </summary>
        /// <param name="success">True/False based upon file processing</param>
        /// <param name="text">Extra text to dispaly</param>
        private static void StatusEvent(bool success, string text=null)
        {
            var status = success ? Properties.Resources.Succeed + text : Properties.Resources.Fail;

            Console.WriteLine(status);

        }

        /// <summary> Ouput text in console </summary>
        /// <param name="text">Text to display</param>
        private static void DisplayEvent(string text)
        {
            Console.Write(text);
        }
    }
}
