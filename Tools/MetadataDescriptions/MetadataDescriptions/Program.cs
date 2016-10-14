/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Enum;
using Sage.CA.SBS.ERP.Sage300.MetadataDescriptions.Properties;

namespace Sage.CA.SBS.ERP.Sage300.MetadataDescriptions
{
    /// <summary>
    /// Class Main
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        static void Main()
        {
            try
            {
                ChooseTool:
                Console.WriteLine(Resources.PromptToolChoose);
                var input =  Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine(Resources.PromptWrongChoice);
                    goto ChooseTool;
                }
                
                var toolType = (ToolType)(Convert.ToInt32(input));
                var tool = new Tool(toolType);
                tool.Run();
            }
            catch (Exception e)
            {
                Console.Write(e.Message + Resources.NewLine);
                Console.WriteLine(Resources.PromptExit);
                Console.ReadKey();
            }

        }

    }
}
