/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// Class ExtractorInputReceiver
    /// </summary>
    class ExtractorInputReceiver : InputReceiverBase
    {
        /// <summary>
        /// Receive the input path from keyboard
        /// </summary>
        public override void ReceiveInputPath()
        {
            bool isInputFolderValid = false;

            Console.Write(Properties.Resources.ExtractorInputPrompt);

            while (!isInputFolderValid)
            {
                InputPath = Console.ReadLine();
                
                // ReSharper disable once PossibleNullReferenceException
                if (InputPath.EndsWith("\\"))
                {
                    InputPath = InputPath.Substring(0, InputPath.Length - 1);       //trim off the tail of "\"
                }

                if (Directory.Exists(InputPath))
                {
                    isInputFolderValid = true;
                }
                else
                {
                    Console.Write(Properties.Resources.ErrorInput);
                }
            }
        }

        /// <summary>
        /// Receive the output path from keyboard
        /// </summary>
        public override void ReceiveOutputPath()
        {
            var isOutputCreated = false;
            while (!isOutputCreated)
            {
                Console.Write(Properties.Resources.ExtractorOutputPrompt);

                OutputPath = Console.ReadLine();

                if (OutputPath == "")
                {
                    continue;
                }

                isOutputCreated = true;

                try
                {
                    var outputFolderPath = Path.GetDirectoryName(OutputPath);
                    // ReSharper disable once AssignNullToNotNullAttribute
                    Directory.CreateDirectory(outputFolderPath);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message + Properties.Resources.NewLine);
                    isOutputCreated = false;
                }
            }
        }
    }
}
