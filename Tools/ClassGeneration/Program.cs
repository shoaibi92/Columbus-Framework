// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. 


using System;
using System.Windows.Forms;

namespace Sage.CA.SBS.ERP.Sage300.ClassGeneration
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
            Application.Run(new Generation());
        }
    }
}
