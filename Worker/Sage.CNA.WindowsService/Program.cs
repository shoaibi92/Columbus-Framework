/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.ServiceProcess;

namespace Sage.CNA.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun = new ServiceBase[] 
            { 
                new Service() 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
