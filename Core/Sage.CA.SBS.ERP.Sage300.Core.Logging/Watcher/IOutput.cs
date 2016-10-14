// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Logging.Watcher
{
    /// <summary>
    /// Interface for output implementation
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Writes text into output
        /// </summary>
        /// <param name="formatText">Text, optionally with format</param>
        /// <param name="args">Optional arguments</param>
        void WriteLine(string formatText, params object[] args);
    }
}
