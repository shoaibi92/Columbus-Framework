/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.IO;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.BaseClasses;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// Class AdderInputReceiver
    /// </summary>
    class AdderInputReceiver : InputReceiverBase
    {
        /// <summary>
        /// Receive the input path from keyboard
        /// </summary>
        public override void ReceiveInputPath()
        {
            var isInputFileValid = false;

            Console.Write(Properties.Resources.AdderInputPrompt);

            while (!isInputFileValid)
            {
                InputPath = Console.ReadLine();

                if (File.Exists(InputPath))
                {
                    isInputFileValid = true;
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
            var isOutputFolderValid = false;
            while (!isOutputFolderValid)
            {
                Console.Write(Properties.Resources.AdderOutputPrompt);

                OutputPath = Console.ReadLine();

                if (OutputPath == "")
                {
                    continue;
                }

                // ReSharper disable once PossibleNullReferenceException
                if (OutputPath.EndsWith("\\"))
                {
                    OutputPath = OutputPath.Substring(0, OutputPath.Length - 1);       //Trim off the tail of "\"
                }

                if (Directory.Exists(OutputPath))
                {
                    isOutputFolderValid = true;
                }
            }
        }
    }
}