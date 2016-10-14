/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sage.CA.SBS.ERP.Sage300.ResxGeneration
{
    static class Program
    {
        /// <summary> The main entry point for the application </summary>
        /// <param name="args">Command line arguments</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run headless or via generation form?
            if (args.Length == 0)
            {
                Application.Run(new Generation());
            }
            else
            {
                var generation = new ProcessGeneration();

                // Get rid of quotes
                for (var arg = 0; arg < args.Length; arg++)
                {
                    args[arg] = args[arg].Replace("\"", "");
                }

                // Get resource info and validate
                var resourceInfo = generation.GetResourceInfo(@args[0]);
                if (!generation.ValidResourceInfo(resourceInfo))
                {
                    throw new Exception(Properties.Resources.ErrorResourceFile);
                }

                // Get settings and validate
                var settings = generation.BuildSettings(generation.GetSettings(@args[1]));
                if (!generation.ValidSettings(settings))
                {
                    throw new Exception(Properties.Resources.ErrorSettingsFile);
                }

                // Add resource info and settings to a dictionary to be passed to processing class
                var dictionary = new Dictionary<string, object>
                    {
                        {ProcessGeneration.ResourceInfoKey, resourceInfo},
                        {ProcessGeneration.SettingsKey, settings}
                    };

                // Start process
                generation.Process(dictionary);
                               
            }
        }
    }
}
