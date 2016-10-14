// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Console output class
    /// </summary>
    public class ConsoleOut : IOutput
    {
        /// <summary>
        /// Writes text into output
        /// </summary>
        /// <param name="formatText">Text, optionally with format</param>
        /// <param name="args">Optional arguments</param>
        public void WriteLine(string formatText, params object[] args)
        {
            Console.WriteLine(formatText, args);
        }
    }
}
