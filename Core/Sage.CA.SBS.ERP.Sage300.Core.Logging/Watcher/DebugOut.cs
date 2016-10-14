// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Diagnostics;

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Debug output class
    /// </summary>
    public class DebugOut : IOutput
    {
        /// <summary>
        /// Writes text into output
        /// </summary>
        /// <param name="formatText">Text, optionally with format</param>
        /// <param name="args">Optional arguments</param>
        public void WriteLine(string formatText, params object[] args)
        {
            Debug.WriteLine(formatText, args);
        }
    }
}
